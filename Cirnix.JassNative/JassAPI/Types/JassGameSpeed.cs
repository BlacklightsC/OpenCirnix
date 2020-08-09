using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hgamespeed;")]
    [Serializable]
    public struct JassGameSpeed
    {
        public readonly IntPtr Handle;

        public JassGameSpeed(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}