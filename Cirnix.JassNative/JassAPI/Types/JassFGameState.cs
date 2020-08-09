using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hfgamestate;")]
    [Serializable]
    public struct JassFGameState
    {
        public readonly IntPtr Handle;

        public JassFGameState(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}