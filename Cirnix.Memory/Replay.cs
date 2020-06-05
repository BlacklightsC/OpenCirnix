using System;
using static Cirnix.Global.Globals;
using static Cirnix.Memory.Component;
using static Cirnix.Memory.NativeMethods;

namespace Cirnix.Memory
{
    public static class Replay
    {
        private static byte[] SearchPattern = new byte[] { 0x78, 0x60, 0x34, 0x2F, 0x78 };
        internal static IntPtr Offset = IntPtr.Zero;

        private static void GetOffset()
        {
            Offset = SearchAddress(SearchPattern, 0x7FFFFFFF, 4);
            if (Offset != IntPtr.Zero) Offset += 0x25B0;
        }

        public static int PlaySpeed {
            get {
                int CurrentDelay = -1;
                GetOffset();
                if (Offset != IntPtr.Zero)
                {
                    uint num;
                    byte[] buffer = new byte[4];
                    ReadProcessMemory(Warcraft3Info.Handle, Offset, buffer, 4, out num);
                    num = BitConverter.ToUInt32(buffer, 0);
                    if (num >= 0 && num <= 0x230)
                        CurrentDelay = (int)num;
                }
                return CurrentDelay;
            }
            set {
                GetOffset();
                if (Offset == IntPtr.Zero) return;
                uint num;
                byte[] bytes = BitConverter.GetBytes(value);
                WriteProcessMemory(Warcraft3Info.Handle, Offset, bytes, 4, out num);
                WriteProcessMemory(Warcraft3Info.Handle, Offset + 4, bytes, 4, out num);
                WriteProcessMemory(Warcraft3Info.Handle, Offset + 0x220, bytes, 4, out num);
                WriteProcessMemory(Warcraft3Info.Handle, Offset + 0x224, bytes, 4, out num);
                WriteProcessMemory(Warcraft3Info.Handle, Offset + 0x440, bytes, 4, out num);
                WriteProcessMemory(Warcraft3Info.Handle, Offset + 0x444, bytes, 4, out num);
            }
        }
    }
}
