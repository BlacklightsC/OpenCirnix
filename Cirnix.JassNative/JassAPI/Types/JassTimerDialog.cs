using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Htimerdialog;")]
    [Serializable]
    public struct JassTimerDialog
    {
        public readonly IntPtr Handle;

        public JassTimerDialog(IntPtr handle)
        {
            Handle = handle;
        }
    }
}
