using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hcamerafield;")]
    [Serializable]
    public struct JassCameraField
    {
        public readonly IntPtr Handle;

        public JassCameraField(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}