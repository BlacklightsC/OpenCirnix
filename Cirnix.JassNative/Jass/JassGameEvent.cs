using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hgameevent;")]
    [Serializable]
    public struct JassGameEvent
    {
        public readonly IntPtr Handle;

        public JassGameEvent(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}