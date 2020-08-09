using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.WarAPI.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 80)]
    public struct ThreadLocalStorage
    {
        public IntPtr field0000;
        public IntPtr field0004;
        public IntPtr field0008;
        public IntPtr field000C;
        public IntPtr field0010;
        public JassPtr Jass;
        public IntPtr field0018;
        public IntPtr field001C;
        public IntPtr field0020;
        public IntPtr field0024;
        public IntPtr field0028;
        public IntPtr field002C;
        public IntPtr field0030;
        public IntPtr field0034;
        public IntPtr NetProvider;
        public IntPtr field003C;
        public IntPtr field0040;
        public IntPtr field0044;
        public IntPtr field0048;
        public IntPtr field004C;
    }
}