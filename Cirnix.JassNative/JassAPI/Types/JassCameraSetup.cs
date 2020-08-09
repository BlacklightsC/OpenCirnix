using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hcamerasetup;")]
    [Serializable]
    public struct JassCameraSetup
    {
        public readonly IntPtr Handle;

        public JassCameraSetup(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}