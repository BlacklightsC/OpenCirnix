using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.WarAPI.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 1108)]
    public struct COrderTarget
    {
        public IntPtr VTable;
        public IntPtr field0004;
        public IntPtr field0008;
        public IntPtr field000C;
        public IntPtr field0010;
        public IntPtr field0014;
        public IntPtr field0018;
        public IntPtr field001C;
        public IntPtr field0020;
        public int Order;
        public IntPtr field0028;
        public IntPtr field002C;
        public IntPtr field0030;
        public IntPtr field0034;
        public IntPtr field0038;
        public IntPtr field003C;
        public IntPtr field0040;
        public IntPtr field0044;
        public float X;
        public IntPtr field004C;
        public float Y;
        public IntPtr field0054;
        public IntPtr field0058;
        public IntPtr field005C;
        public IntPtr field0060;
        public IntPtr field0064;
        public IntPtr field0068;
        public IntPtr field006C;
        public IntPtr field0070;
        public IntPtr field0074;
        public IntPtr field0078;
        public IntPtr field007C;
        public IntPtr field0080;
        public IntPtr field0084;

        public unsafe COrderTargetPtr AsSafe()
        {
            fixed (COrderTarget* pointer = &this)
                return new COrderTargetPtr(pointer);
        }

        public unsafe IntPtr AsIntPtr()
        {
            fixed (COrderTarget* corderTargetPtr = &this)
                return new IntPtr((void*)corderTargetPtr);
        }
    }
}