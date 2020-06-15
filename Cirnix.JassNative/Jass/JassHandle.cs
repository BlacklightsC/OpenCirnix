using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("H")]
    [Serializable]
    public struct JassHandle
    {
        private readonly IntPtr Handle;

        public JassHandle(IntPtr handle)
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