using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hdestructable;")]
    [Serializable]
    public struct JassDestructable
    {
        public readonly IntPtr Handle;

        public JassDestructable(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}