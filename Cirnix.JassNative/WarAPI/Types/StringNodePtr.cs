using System;

namespace Cirnix.JassNative.WarAPI.Types
{
    public struct StringNodePtr
    {
        private IntPtr pointer;

        public unsafe StringNodePtr(StringNode* pointer)
        {
            this.pointer = new IntPtr((void*)pointer);
        }

        public unsafe StringNode* AsUnsafe() => (StringNode*)(void*)pointer;

        public IntPtr AsIntPtr() => pointer;
    }
}