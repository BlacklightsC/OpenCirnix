using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.WarAPI.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 28)]
    public struct HT_Node
    {
        public int Hash;
        public unsafe HT_Bucket* Parent;
        public unsafe HT_Node* Next;
        public IntPtr field000C;
        public IntPtr field0010;
        public StringPtr Key;
        public unsafe void* Value;
    }
}