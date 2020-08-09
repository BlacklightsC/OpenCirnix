using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hubersplat;")]
    [Serializable]
    public struct JassUberSplat
    {
        public readonly IntPtr Handle;

        public JassUberSplat(IntPtr handle)
        {
            Handle = handle;
        }
    }
}