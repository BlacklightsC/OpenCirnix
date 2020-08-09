using System;

namespace Cirnix.JassNative.WarAPI.Types
{
    [Serializable]
    public struct Color
    {
        public static Color White = new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue);
        public static Color Yellow = new Color(byte.MaxValue, 0xCC, 0);
        public static Color Unique = new Color(0x8B, 0, byte.MaxValue);
        public static Color Consumable = new Color(0x87, 0xCE, 0xEB);
        public static Color Artifact = new Color(byte.MaxValue, 0x68, 0);
        public byte B, G, R, A;

        public static Color FromRGB(byte red, byte green, byte blue)
        {
            return new Color(red, green, blue);
        }

        public static Color FromARGB(byte alpha, byte red, byte green, byte blue)
        {
            return new Color(alpha, red, green, blue);
        }

        public Color(byte alpha, byte red, byte green, byte blue)
        {
            A = alpha;
            R = red;
            G = green;
            B = blue;
        }

        public Color(byte red, byte green, byte blue)
        {
            A = byte.MaxValue;
            R = red;
            G = green;
            B = blue;
        }

        public string ToHexString() => $"{A:X2}{R:X2}{G:X2}{B:X2}";

        public override string ToString() => $"(a:{A:X2}; r:{R:X2}; g:{G:X2}; b:{B:X2})";
    }
}