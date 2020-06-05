using System;
using static Cirnix.Memory.Component;
using static Cirnix.Memory.NativeMethods;

namespace Cirnix.Memory
{
    public static class ControlDelay
    {
        private static readonly byte[] SearchPattern = new byte[] { 0xC0, 0xD6, 0xDB, 0x68, 0xC0 };
        internal static IntPtr Offset = IntPtr.Zero;

        private static void GetOffset()
        {
            Offset = SearchAddress(SearchPattern, 0x7FFFFFFF, 4);
            if (Offset != IntPtr.Zero) Offset += 0x2EC;
        }

        public static int GameDelay {
            get {
                int CurrentDelay = -1;
                GetOffset();
                if (Offset != IntPtr.Zero)
                {
                    byte[] buffer = new byte[4];
                    ReadProcessMemory(Warcraft3Info.Handle, Offset, buffer, 4, out uint num);
                    num = BitConverter.ToUInt32(buffer, 0);
                    if (num >= 0 && num <= 0x230)
                        CurrentDelay = (int)num;
                }
                return CurrentDelay;
            }
            set {
                GetOffset();
                if (Offset == IntPtr.Zero) return;
                byte[] bytes = BitConverter.GetBytes(value);
                for (int i = 0; i <= 0x440; i += 0x220)
                    for (int j = 0; j <= 4; j += 4)
                        WriteProcessMemory(Warcraft3Info.Handle, Offset + i + j, bytes, 4, out uint num);
            }
        }
    }
}
