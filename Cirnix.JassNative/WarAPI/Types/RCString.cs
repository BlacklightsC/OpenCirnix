using System;
using Cirnix.JassNative.Runtime.Utilities;

namespace Cirnix.JassNative.WarAPI.Types
{
    public struct RCString
    {
        public IntPtr VTable;
        public IntPtr Field_0004;
        public IntPtr Field_0008;
        public IntPtr Field_000C;
        public IntPtr Field_0010;
        public IntPtr Field_0014;
        public IntPtr Field_0018;
        public IntPtr Value;

        public string AsString() => Memory.ReadString(Value);
    }
}