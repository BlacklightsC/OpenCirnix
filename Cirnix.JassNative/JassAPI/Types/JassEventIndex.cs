using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Heventid;")]
    [Serializable]
    public struct JassEventIndex
    {
        public readonly IntPtr Handle;

        public JassEventIndex(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}