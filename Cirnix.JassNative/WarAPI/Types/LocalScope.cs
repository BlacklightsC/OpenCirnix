using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.WarAPI.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 188)]
    public struct LocalScope
    {
        public unsafe LocalScope* Ret;
        public unsafe LocalScope* Parent;
        public int NAlloc;
        private unsafe fixed byte Variables[1280];
        public int NStack;
        public Hashtable Locals;
        public IntPtr field00B8;
    }
}