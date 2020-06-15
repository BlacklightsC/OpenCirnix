using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Heffecttype;")]
    [Serializable]
    public struct JassEffectType
    {
        public readonly IntPtr Handle;

        public JassEffectType(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}