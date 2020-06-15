using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.Runtime.Windows
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TOKEN_PRIVILEGES
    {
        public int PrivilegeCount;
        public long Luid;
        public int Attributes;
    }
}
