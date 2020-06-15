using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Higamestate;")]
    [Serializable]
    public struct JassIGameState
    {
        public readonly IntPtr Handle;

        public JassIGameState(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}