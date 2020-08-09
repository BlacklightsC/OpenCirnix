using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hitempool;")]
    [Serializable]
    public struct JassItemPool
    {
        public readonly IntPtr Handle;

        public JassItemPool(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}