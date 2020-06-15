using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hgroup;")]
    [Serializable]
    public struct JassGroup
    {
        public readonly IntPtr Handle;

        public JassGroup(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}