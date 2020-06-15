using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Himage;")]
    [Serializable]
    public struct JassImage
    {
        public readonly IntPtr Handle;

        public JassImage(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}