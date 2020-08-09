using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hagent;")]
    [Serializable]
    public struct JassAgent
    {
        public readonly IntPtr Handle;

        public JassAgent(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}