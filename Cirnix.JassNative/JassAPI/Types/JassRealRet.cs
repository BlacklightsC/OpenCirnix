using System;
using System.IO;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("R")]
    public struct JassRealRet
    {
        private readonly int valueAsInt32;

        private JassRealRet(int valueAsInt32)
        {
            this.valueAsInt32 = valueAsInt32;
        }

        public static implicit operator float(JassRealRet from)
        {
            using (var stream = new MemoryStream(4))
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(from.valueAsInt32);
                return BitConverter.ToSingle(stream.ToArray(), 0);
            }
        }

        public static implicit operator JassRealRet(float from)
        {
            using (var stream = new MemoryStream(4))
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(from);
                return new JassRealRet(BitConverter.ToInt32(stream.ToArray(), 0));
            }
        }

        public static implicit operator JassRealArg(JassRealRet from) => (float)from;
    }
}