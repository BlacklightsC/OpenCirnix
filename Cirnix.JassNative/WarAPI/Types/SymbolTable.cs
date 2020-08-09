using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.WarAPI.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 12)]
    public struct SymbolTable
    {
        public unsafe OpCode* FirstOperation;
        public int ProgramLength;
        public unsafe StringPool* StringPool;

        public unsafe SymbolTablePtr AsSafe()
        {
            fixed (SymbolTable* pointer = &this)
                return new SymbolTablePtr(pointer);
        }

        public unsafe IntPtr AsIntPtr()
        {
            fixed (SymbolTable* symbolTablePtr = &this)
                return new IntPtr((void*)symbolTablePtr);
        }
    }
}