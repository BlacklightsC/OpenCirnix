using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hblendmode;")]
    [Serializable]
    public struct JassBlendMode
    {
        public readonly IntPtr Handle;

        public JassBlendMode(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}