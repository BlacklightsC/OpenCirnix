using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hfogmodifier;")]
    [Serializable]
    public struct JassFogModifier
    {
        public readonly IntPtr Handle;

        public JassFogModifier(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}