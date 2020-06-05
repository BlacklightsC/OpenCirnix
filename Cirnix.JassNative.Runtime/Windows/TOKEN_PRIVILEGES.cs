using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Cirnix.JassNative.Runtime.Windows
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TOKEN_PRIVILEGES
    {
        public Int32 PrivilegeCount;
        public Int64 Luid;
        public Int32 Attributes;
    }
}
