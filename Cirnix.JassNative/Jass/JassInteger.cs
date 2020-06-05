using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("I")]
    [Serializable]
    public struct JassInteger
    {
        private readonly int value;

        private JassInteger(int value)
        {
            this.value = value;
        }

        public static implicit operator int(JassInteger from)
        {
            return from.value;
        }

        public static implicit operator JassInteger(int from)
        {
            return new JassInteger(from);
        }

        public static implicit operator JassInteger(long? from)
        {
            if (from is null)
                return new JassInteger(0);
            else if (from >= int.MaxValue)
                return new JassInteger(int.MaxValue);
            else if (from <= int.MinValue)
                return new JassInteger(int.MinValue);
            else
                return new JassInteger(Convert.ToInt32(from));
        }

        public override string ToString()
        {
            return this.ToString();
        }

        public string ToString(string format)
        {
            return this.ToString(format);
        }

        public string ToString(IFormatProvider provider)
        {
            return this.ToString(provider);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return this.ToString(format, provider);
        }
    }
}
