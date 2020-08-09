using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.WarAPI.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 12)]
    public struct HT_Bucket
    {
        public int Offset;
        public IntPtr field0004;
        public unsafe HT_Node* List;
    }
}