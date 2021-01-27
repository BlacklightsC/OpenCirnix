using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Cirnix.Global;

using static Cirnix.Memory.Component;
using static Cirnix.Memory.Message;
using static Cirnix.Memory.NativeMethods;

namespace Cirnix.Memory
{
    public static class BanList
    {
		private static readonly byte[] SearchPattern = { 0x1B, 0xA3, 0x1E, 0x0F, 0x1B };
		internal static IntPtr Offset = IntPtr.Zero;
		private static readonly List<BanlistModel> Banlist = new List<BanlistModel>();

		private static bool GetOffset()
		{
			return (Offset = FollowPointer(StormDllOffset + 0x5809C, SearchPattern)) != IntPtr.Zero;
	    }


		public static async void CheckBanList()
		{
			byte[] array2 = new byte[3000];
			if (GetOffset())
			{
				ReadProcessMemory(Warcraft3Info.Handle, Offset, array2, array2.Length, out _);
				List<byte[]> list = CheckArea(array2);
				SendMsg(true, "현재 연결된 유저를 검사합니다.");
				foreach (byte[] array3 in list)
				{
					byte[] array4 = new byte[4];
					Array.Copy(array3, 92, array4, 0, 4);
					IPAddress ipaddress = new IPAddress(array4);
					string text = StringFromArray(array3, 125);
					
					BanlistModel banlistModel = Matching(ipaddress.ToString(), text);
					if (banlistModel != null)
					{
						SendMsg(true, $"근접 발견 ID - {text} IP - {ipaddress}");
						await Task.Delay(300);
						SendMsg(true, $"밴리 사유 : {banlistModel.Reason}");
					}
					await Task.Delay(300);
				}
				SendMsg(true, "현재 연결된 유저의 검사를 종료합니다.");
            }
		}

		public static async void IPAddrMaching()
        {
			byte[] buffer = new byte[3000];
			if (GetOffset())
            {
				ReadProcessMemory(Warcraft3Info.Handle, Offset, buffer, buffer.Length, out _);
				List<byte[]> list = CheckArea(buffer);
				foreach (byte[] array3 in list)
				{
					byte[] ipAddr = new byte[4];
					Array.Copy(array3, 92, ipAddr, 0, 4);
					SendMsg(true, $"ID - {StringFromArray(array3, 125)} IP - {new IPAddress(ipAddr)}");
					await Task.Delay(300);
				}
			}
		}

		private static string StringFromArray(byte[] Data, int Offset)
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (true)
			{
				char c = (char)Data[Offset++];
				if (c == '\0') break;
				stringBuilder.Append(c);
			}
			return stringBuilder.ToString();
		}

		private static List<byte[]> CheckArea(byte[] tmp)
		{
			List<byte[]> list = new List<byte[]>();
			for (int i = 0; i < tmp.Length - 3; i++)
			{
				if (tmp[i] == 255 && tmp[i + 1] == 255 && tmp[i + 2] == 255 && tmp[i + 3] == 255)
				{
					byte[] array = new byte[142];
					Array.Copy(tmp, i, array, 0, 142);
					list.Add(array);
					i += 142;
				}
			}
			return list;
		}


		public static void Add(string ID, string IP, string Reason)
		{
			Banlist.Add(new BanlistModel
			{
				ID = ID,
				IP = IP,
				Reason = Reason
			});
		}

		public static void Add(BanlistModel data)
		{
			Banlist.Add(data);
		}

		public static void Clear()
		{
			Banlist.Clear();
		}

		public static BanlistModel Matching(string ip, string id)
		{
			return (from e in Banlist
					where (!string.IsNullOrEmpty(e.ID) && e.ID.Equals(id, StringComparison.OrdinalIgnoreCase)) || (!string.IsNullOrEmpty(e.IP) && ip.IndexOf(e.IP) != -1)
					select e).FirstOrDefault();
		}
	}

	public static class SaveBanlistUsers
	{
		public static List<BanlistModel> Load() => SaveLoad.Load<List<BanlistModel>>("Banlist");

		public static void Save(List<BanlistModel> data) => SaveLoad.Save("Banlist", data);

		public static bool Load2() => SaveLoad.Load<bool>("UseBanlist");

		public static void Save2(bool data) => SaveLoad.Save("UseBanlist", data);
	}
}
