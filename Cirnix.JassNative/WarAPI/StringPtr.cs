using System;

using Cirnix.JassNative.Runtime.Utilities;

namespace Cirnix.JassNative.WarAPI
{
    public struct StringPtr
    {
        public IntPtr Pointer;

        public string AsString() => Memory.ReadString(Pointer);
    }
}
