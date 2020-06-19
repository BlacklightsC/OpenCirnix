using System;
using System.Text;
using System.Threading.Tasks;
using static Cirnix.Global.Globals;
using static Cirnix.Global.NativeMethods;
using static Cirnix.Memory.Component;
using static Cirnix.Memory.NativeMethods;

namespace Cirnix.Memory
{
    public static class Join
    {
        private static readonly byte[] SearchPattern = new byte[] { 0x94, 0x28, 0x49, 0x65, 0x94 };
        internal static IntPtr Offset = IntPtr.Zero;

        private static bool GetOffset()
        {
            Offset = SearchAddress(SearchPattern);
            if (Offset != IntPtr.Zero)
            {
                Offset += 0x6E4;
                return true;
            }
            Offset = IntPtr.Zero;
            return false;
        }

        public static void RoomJoin(string roomname)
        {
            if (roomname.Length == 0) return;
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 18, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 71, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 71, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 18, 0);
            Delay(3000);

            if (GetOffset())
            {
                byte[] buffer = Encoding.UTF8.GetBytes(roomname.Trim());
                WriteProcessMemory(Warcraft3Info.Handle, Offset, buffer, buffer.Length + 1, out _);
                PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 13, 0);
                PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 13, 0);
                PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 13, 0);
                PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 13, 0);
                PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 13, 0);
                PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 13, 0);
                PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 13, 0);
            }
        }


        public static void RoomCreate(string roomname)
        {
            if (roomname.Length == 0) return;
            
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 18, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 71, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 71, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 18, 0);
            Task.Delay(3000);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 18, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 67, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 67, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 18, 0);
            Task.Delay(1000);

            if (GetOffset())
            {
                byte[] buffer = Encoding.UTF8.GetBytes(roomname.Trim());
                WriteProcessMemory(Warcraft3Info.Handle, Offset, buffer, buffer.Length + 1, out _);
                Delay(3000);
                PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 18, 0);
                PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 67, 0);
                PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 67, 0);
                PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 18, 0);
            }
        }

    }
}
