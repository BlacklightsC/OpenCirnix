using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hevent;")]
    [Serializable]
    public struct JassEvent
    {
        public readonly IntPtr Handle;

        public JassEvent(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}