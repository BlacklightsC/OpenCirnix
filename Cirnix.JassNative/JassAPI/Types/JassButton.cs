using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hbutton;")]
    [Serializable]
    public struct JassButton
    {
        public readonly IntPtr Handle;

        public JassButton(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}