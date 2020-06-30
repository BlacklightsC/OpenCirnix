using Cirnix.Global;

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using static Cirnix.Memory.Component;
using static Cirnix.Memory.NativeMethods;
using static Cirnix.Memory.Message;

namespace Cirnix.Memory
{
    public static class BanList
    {
		private static readonly byte[] SearchPattern = new byte[] { 0x1B, 0xA3, 0x1E, 0x0F };
		internal static IntPtr Offset = IntPtr.Zero;
		private static List<BanlistModel> Banlist = new List<BanlistModel>();

		/*
        private static void GetOffset()
        {
            Offset = SearchAddress(SearchPattern);
            //if (Offset != IntPtr.Zero) Offset += 0x2EC;

        }
		*/

		private static bool GetOffset()
		{
			Offset = SearchAddress(SearchPattern);
			if (Offset != IntPtr.Zero)
			{
				return true;
			}
			Offset = IntPtr.Zero;
			return false;
		}

		public static async void CheckBanList()
		{
			
			byte[] array2 = new byte[3000];
			int num;
			if (GetOffset())
			{
				
				ReadProcessMemory(Warcraft3Info.Handle, Offset, array2, array2.Length, out num);
				List<byte[]> list = CheckArea(array2);
				SendMsg(true, $"현재 연결된 유저를 검사합니다.");
				foreach (byte[] array3 in list)
				{
					byte[] array4 = new byte[4];
					Array.Copy(array3, 92, array4, 0, 4);
					IPAddress ipaddress = new IPAddress(array4);
					string text = StringFromArray(array3, 125);
					
					BanlistModel banlistModel = Maching(ipaddress.ToString(), text);
					if (banlistModel != null)
					{
						SendMsg(true, "근접 발견 ID - " + text + " IP - " + ipaddress.ToString());
						await Task.Delay(300);
						SendMsg(true, "밴리 사유 :" + banlistModel.Reason);
					}
					else
					{
						SendMsg(true, $"밴 리스트에 추가한 유저가 없습니다.");
					}
					await Task.Delay(300);
				}
				SendMsg(true, $"현재 연결된 유저의 검사를 종료합니다.");
            }
		
		}

		public static async void IPAddrMaching()
        {
			byte[] array2 = new byte[3000];
			int num;
			if (GetOffset())
            {
				ReadProcessMemory(Warcraft3Info.Handle, Offset, array2, array2.Length, out num);
				List<byte[]> list = CheckArea(array2);
				foreach (byte[] array3 in list)
				{
					byte[] array4 = new byte[4];
					Array.Copy(array3, 92, array4, 0, 4);
					IPAddress ipaddress = new IPAddress(array4);
					string text = StringFromArray(array3, 125);
					Message.SendMsg(true, "ID - " + text + " IP - " + ipaddress.ToString());
					await Task.Delay(300);

				}

			}

		}

		private static string StringFromArray(byte[] Data, int Offset)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (; ; )
			{
				char c = (char)Data[Offset++];
				if (c == '\0')
				{
					break;
				}
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

		public static BanlistModel Maching(string ip, string id)
		{
			return (from e in Banlist
					where (e.ID.ToLower() == id.ToLower() && !string.IsNullOrEmpty(e.ID)) || (!string.IsNullOrEmpty(e.IP) && ip.IndexOf(e.IP) != -1)
					select e).FirstOrDefault<BanlistModel>();
		}
	}

	public class SaveBanlistUsers
	{
		public List<BanlistModel> Load()
		{
		
			return SaveLoad.Load<List<BanlistModel>>("Banlist");
		}

		public void Save(List<BanlistModel> data)
		{
			SaveLoad.Save("Banlist", data);
		}

		public bool Load2()
		{
			return SaveLoad.Load<bool>("UseBanlist");
		}

		public void Save2(bool data)
		{
			SaveLoad.Save("UseBanlist", data);
		}
	}
}
