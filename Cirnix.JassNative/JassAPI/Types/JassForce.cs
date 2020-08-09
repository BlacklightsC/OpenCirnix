using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hforce;")]
    [Serializable]
    public struct JassForce
    {
        public readonly IntPtr Handle;

        public JassForce(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}