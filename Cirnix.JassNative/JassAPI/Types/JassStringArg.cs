using Cirnix.JassNative.WarAPI;
using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("S")]
    public struct JassStringArg
    {
        private readonly IntPtr Handle;

        public JassStringArg(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator string(JassStringArg from)
        {
            return GameFunctions.JassStringHandleToString(from.Handle);
        }

        public static implicit operator JassStringArg(string from)
        {
            return new JassStringArg(GameFunctions.JassStringIndexToJassStringHandle(GameFunctions.StringToJassStringIndex(from)));
        }

        public override string ToString() => GameFunctions.JassStringHandleToString(Handle);
    }
}