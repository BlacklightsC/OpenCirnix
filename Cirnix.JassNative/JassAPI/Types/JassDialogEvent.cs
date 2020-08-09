using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hdialogevent;")]
    [Serializable]
    public struct JassDialogEvent
    {
        public readonly IntPtr Handle;

        public JassDialogEvent(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}