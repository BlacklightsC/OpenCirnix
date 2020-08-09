using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hdialog;")]
    [Serializable]
    public struct JassDialog
    {
        public readonly IntPtr Handle;

        public JassDialog(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}