using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hgamestate;")]
    [Serializable]
    public struct JassGameState
    {
        public readonly IntPtr Handle;

        public JassGameState(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}