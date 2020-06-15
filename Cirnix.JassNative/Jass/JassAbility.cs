using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hability;")]
    [Serializable]
    public struct JassAbility
    {
        public readonly IntPtr Handle;

        public JassAbility(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}