using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hregion;")]
    [Serializable]
    public struct JassRegion
    {
        public readonly IntPtr Handle;

        public JassRegion(IntPtr handle)
        {
            Handle = handle;
        }
    }
}