using System;

namespace Cirnix.JassNative.WarAPI.Types
{
    public struct JassString
    {
        public IntPtr VTable;
        public IntPtr Field_0004;
        public unsafe RCString* Value;
        public IntPtr Field_000C;

        public override unsafe string ToString()
        {
            return Value->AsString();
        }
    }
}