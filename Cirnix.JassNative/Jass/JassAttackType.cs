using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hattacktype;")]
    [Serializable]
    public struct JassAttackType
    {
        public readonly IntPtr Handle;

        public JassAttackType(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}