using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Heffect;")]
    [Serializable]
    public struct JassEffect
    {
        public readonly IntPtr Handle;

        public JassEffect(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}