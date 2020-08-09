using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.WarAPI.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 124)]
    public struct CTriggerWar3
    {
        public unsafe VTable* Virtual;
        public IntPtr field0004;
        public IntPtr field0008;
        public IntPtr field000C;
        public IntPtr field0010;
        public IntPtr field0014;
        public IntPtr field0018;
        public IntPtr field001C;
        public IntPtr field0020;
        public IntPtr field0024;
        public IntPtr field0028;
        public IntPtr field002C;
        public IntPtr field0030;
        public IntPtr field0034;
        public IntPtr field0038;
        public IntPtr field003C;
        public IntPtr field0040;
        public IntPtr field0044;
        public IntPtr field0048;
        public IntPtr field004C;
        public IntPtr field0050;
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

        public static unsafe CTriggerWar3* FromHandle(IntPtr trigger)
        {
            return GameFunctions.GetTriggerFromHandle(trigger).AsUnsafe();
        }

        public unsafe CTriggerWar3Ptr AsSafe()
        {
            fixed (CTriggerWar3* pointer = &this)
                return new CTriggerWar3Ptr(pointer);
        }

        public unsafe IntPtr AsIntPtr()
        {
            fixed (CTriggerWar3* ctriggerWar3Ptr = &this)
                return new IntPtr((void*)ctriggerWar3Ptr);
        }

        public struct VTable
        {
            public unsafe IntPtr* Function;
        }
    }
}
