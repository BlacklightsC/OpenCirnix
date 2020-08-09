using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.WarAPI.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 12)]
    public struct StringPool
    {
        public IntPtr field0000;
        public IntPtr field0004;
        public unsafe StringNode** Nodes;

        public unsafe StringPoolPtr AsSafe()
        {
            fixed (StringPool* pointer = &this)
                return new StringPoolPtr(pointer);
        }

        public unsafe IntPtr AsIntPtr()
        {
            fixed (StringPool* stringPoolPtr = &this)
                return new IntPtr((void*)stringPoolPtr);
        }
    }
}