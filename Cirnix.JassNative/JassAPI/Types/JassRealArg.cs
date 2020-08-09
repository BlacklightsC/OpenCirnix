using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("R")]
    [Serializable]
    public struct JassRealArg
    {
        private readonly IntPtr valueAsPtr;

        private JassRealArg(IntPtr valueAsPtr)
        {
            this.valueAsPtr = valueAsPtr;
        }

        public static implicit operator float(JassRealArg from)
        {
            byte[] destination = new byte[4];
            Marshal.Copy(from.valueAsPtr, destination, 0, 4);
            return BitConverter.ToSingle(destination, 0);
        }

        public static implicit operator JassRealArg(float from)
        {
            IntPtr num = Marshal.AllocHGlobal(4);
            Marshal.Copy(BitConverter.GetBytes(from), 0, num, 4);
            return new JassRealArg(num);
        }

        public static implicit operator JassRealRet(JassRealArg from)
        {
            return (float)from;
        }
    }
}
