using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hhashtable;")]
    [Serializable]
    public struct JassHashTable
    {
        public readonly IntPtr Handle;

        public JassHashTable(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}