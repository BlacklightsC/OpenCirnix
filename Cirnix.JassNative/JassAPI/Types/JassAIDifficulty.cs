using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Haidifficulty;")]
    [Serializable]
    public struct JassAIDifficulty
    {
        public readonly IntPtr Handle;

        public JassAIDifficulty(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}