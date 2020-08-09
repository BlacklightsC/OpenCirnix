using System;

namespace Cirnix.JassNative.WarAPI.Types
{
    public struct SymbolTablePtr
    {
        private IntPtr pointer;

        public unsafe SymbolTablePtr(SymbolTable* pointer)
        {
            this.pointer = new IntPtr((void*)pointer);
        }

        public unsafe SymbolTable* AsUnsafe() => (SymbolTable*)(void*)pointer;

        public IntPtr AsIntPtr() => pointer;
    }
}