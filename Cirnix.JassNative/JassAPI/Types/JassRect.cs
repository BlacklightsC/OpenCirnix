using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hrect;")]
    [Serializable]
    public struct JassRect
    {
        public readonly IntPtr Handle;

        public JassRect(IntPtr handle)
        {
            Handle = handle;
        }
    }
}