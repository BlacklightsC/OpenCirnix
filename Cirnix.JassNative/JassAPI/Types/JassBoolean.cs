using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("B")]
    [Serializable]
    public struct JassBoolean
    {
        private readonly int value;

        private JassBoolean(int value)
        {
            this.value = value;
        }

        public static implicit operator bool(JassBoolean from)
        {
            return (uint)from.value > 0U;
        }

        public static implicit operator JassBoolean(bool from)
        {
            return new JassBoolean(from ? 1 : 0);
        }

        public override string ToString()
        {
            return this.ToString();
        }

        public string ToString(IFormatProvider provider)
        {
            return this.ToString(provider);
        }
    }
}