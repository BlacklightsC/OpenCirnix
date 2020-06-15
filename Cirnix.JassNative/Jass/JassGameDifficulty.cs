using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hgamedifficulty;")]
    [Serializable]
    public struct JassGameDifficulty
    {
        public readonly IntPtr Handle;

        public JassGameDifficulty(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}