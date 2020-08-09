using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("C")]
    [Serializable]
    public struct JassCode
    {
        public readonly IntPtr Handle;

        public JassCode(IntPtr handle)
        {
            this.Handle = handle;
        }

        public override string ToString()
        {
            return this.Handle.ToString();
        }

        public string ToString(string format)
        {
            return this.Handle.ToString(format);
        }
    }
}