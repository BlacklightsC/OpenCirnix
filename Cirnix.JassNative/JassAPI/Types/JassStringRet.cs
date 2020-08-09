using Cirnix.JassNative.WarAPI;
using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("S")]
    [Serializable]
    public struct JassStringRet
    {
        private readonly int Reference;

        public JassStringRet(int reference)
        {
            Reference = reference;
        }

        public static implicit operator string(JassStringRet from)
        {
            return GameFunctions.JassStringHandleToString(GameFunctions.JassStringIndexToJassStringHandle(from.Reference));
        }

        public static implicit operator JassStringRet(string from)
        {
            return new JassStringRet(GameFunctions.StringToJassStringIndex(from));
        }

        public override string ToString()
        {
            return GameFunctions.JassStringHandleToString(GameFunctions.JassStringIndexToJassStringHandle(Reference));
        }
    }
}
