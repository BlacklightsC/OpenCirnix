using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.WarAPI.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 40)]
    public struct Variable
    {
        public int Hash;
        public unsafe HT_Bucket* Parent;
        public unsafe Variable* Next;
        public IntPtr field000C;
        public IntPtr field0010;
        public StringPtr Name;
        public JassType Type;
        public JassType Type2;
        public IntPtr Value;
        public bool IsFunctionArgument;

        public unsafe IntPtr AsIntPtr()
        {
            fixed (Variable* variablePtr = &this)
                return new IntPtr((void*)variablePtr);
        }
    }
}