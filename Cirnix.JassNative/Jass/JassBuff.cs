using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hbuff;")]
    [Serializable]
    public struct JassBuff
    {
        public readonly IntPtr Handle;

        public JassBuff(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}