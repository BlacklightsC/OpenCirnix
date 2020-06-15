using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hdamagetype;")]
    [Serializable]
    public struct JassDamageType
    {
        public readonly IntPtr Handle;

        public JassDamageType(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}