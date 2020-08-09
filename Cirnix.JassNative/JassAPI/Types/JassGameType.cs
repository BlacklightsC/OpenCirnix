using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hgametype;")]
    [Serializable]
    public struct JassGameType
    {
        public readonly IntPtr Handle;

        public JassGameType(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}