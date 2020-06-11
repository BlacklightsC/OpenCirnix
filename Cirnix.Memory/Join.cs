using System;
using System.Text;
using Cirnix.Global;

using static Cirnix.Memory.Component;
using static Cirnix.Global.NativeMethods;
using static Cirnix.Global.Globals;

namespace Cirnix.Memory
{
    public static class Join
    {
        private static readonly byte[] RoomJoinPattern = new byte[] { 0x94, 0x28, 0x49, 0x65, 0x94 };
        internal static IntPtr RoomJoinOffset = IntPtr.Zero;

        public static void RoomJoin(string roomname)
        {

            if (roomname.Length == 0)
            {
                Message.SendMsg(true, $"방이름을 지정해주세요.");
                return;
            }
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 18, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 71, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 71, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 18, 0);
            Delay(3000);



            RoomJoinOffset = (IntPtr)SearchAddress(RoomJoinPattern, 0x7FFFFFFF, 4).ToInt32() + 1764;

            uint num = 0U;
            uint num2 = 0;
            byte[] array2 = new byte[10];
            NativeMethods.VirtualProtectEx(Warcraft3Info.Handle, RoomJoinOffset, (uint)(UIntPtr)((ulong)((long)array2.Length)), 64U, out num);
            NativeMethods.ReadProcessMemory(Warcraft3Info.Handle, RoomJoinOffset, array2, (uint)array2.Length, out num2);
            Encoding.UTF8.GetString(array2);
            byte[] bytes = Encoding.UTF8.GetBytes(roomname.Trim());
            NativeMethods.WriteProcessMemory(Warcraft3Info.Handle, RoomJoinOffset, bytes, (uint)bytes.Length + 1, out num2);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 13, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 13, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 13, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 13, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 13, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 13, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 13, 0);
        }

    }
}
