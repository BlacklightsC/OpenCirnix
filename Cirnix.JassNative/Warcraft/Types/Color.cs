using System;

namespace Cirnix.JassNative.WarAPI.Types
{
  [Serializable]
  public struct Color
  {
    public static Color White = new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue);
    public static Color Yellow = new Color(byte.MaxValue, (byte) 204, (byte) 0);
    public static Color Unique = new Color((byte) 139, (byte) 0, byte.MaxValue);
    public static Color Consumable = new Color((byte) 135, (byte) 206, (byte) 235);
    public static Color Artifact = new Color(byte.MaxValue, (byte) 140, (byte) 0);
    public byte B;
    public byte G;
    public byte R;
    public byte A;

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
      this.A = alpha;
      this.R = red;
      this.G = green;
      this.B = blue;
    }

    public Color(byte red, byte green, byte blue)
    {
      this.A = byte.MaxValue;
      this.R = red;
      this.G = green;
      this.B = blue;
    }

    public string ToHexString()
    {
      return this.A.ToString("X2") + this.R.ToString("X2") + this.G.ToString("X2") + this.B.ToString("X2");
    }

    public override string ToString()
    {
      return "(a:" + this.A.ToString("X2") + "; r:" + this.R.ToString("X2") + "; g:" + this.G.ToString("X2") + "; b:" + this.B.ToString("X2") + ")";
    }
  }
}
