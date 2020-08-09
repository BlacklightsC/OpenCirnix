using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.WarAPI.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 28)]
    public struct JassArray
    {
        public int field0000;
        public int Size;
        public int Length;
        public unsafe IntPtr* Data;
    }
}