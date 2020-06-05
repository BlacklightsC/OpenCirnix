using System;
using static Cirnix.Memory.Component;
using static Cirnix.Memory.NativeMethods;

namespace Cirnix.Memory
{
    public static class BanList
    {
        private static readonly byte[] SearchPattern = new byte[] { 0x1B, 0xA3, 0x1E, 0x0F };
        internal static IntPtr Offset = IntPtr.Zero;

        private static void GetOffset()
        {
            Offset = SearchAddress(SearchPattern, 0x7FFFFFFF, 4);
            //if (Offset != IntPtr.Zero) Offset += 0x2EC;
        }

    }
}
