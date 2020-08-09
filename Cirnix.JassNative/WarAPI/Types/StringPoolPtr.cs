using System;

namespace Cirnix.JassNative.WarAPI.Types
{
    public struct StringPoolPtr
    {
        private IntPtr pointer;

        public unsafe StringPoolPtr(StringPool* pointer)
        {
            this.pointer = new IntPtr((void*)pointer);
        }

        public unsafe StringPool* AsUnsafe() => (StringPool*)(void*)pointer;

        public IntPtr AsIntPtr() => pointer;
    }
}