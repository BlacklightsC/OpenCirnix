using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hfilterfunc;")]
    [Serializable]
    public struct JassFilterFunction
    {
        public readonly IntPtr Handle;

        public JassFilterFunction(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}