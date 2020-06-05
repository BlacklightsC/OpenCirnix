using Cirnix.JassNative.WarAPI.Types;
using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hplayercolor;")]
  [Serializable]
  public struct JassPlayerColor
  {
    public static JassPlayerColor Red = Natives.ConvertPlayerColor(0);
    public static JassPlayerColor Blue = Natives.ConvertPlayerColor(1);
    public static JassPlayerColor Cyan = Natives.ConvertPlayerColor(2);
    public static JassPlayerColor Purple = Natives.ConvertPlayerColor(3);
    public static JassPlayerColor Yellow = Natives.ConvertPlayerColor(4);
    public static JassPlayerColor Orange = Natives.ConvertPlayerColor(5);
    public static JassPlayerColor Green = Natives.ConvertPlayerColor(6);
    public static JassPlayerColor Pink = Natives.ConvertPlayerColor(7);
    public static JassPlayerColor LightGray = Natives.ConvertPlayerColor(8);
    public static JassPlayerColor LightBlue = Natives.ConvertPlayerColor(9);
    public static JassPlayerColor Aqua = Natives.ConvertPlayerColor(10);
    public static JassPlayerColor Brown = Natives.ConvertPlayerColor(11);
    public readonly IntPtr Handle;

    public JassPlayerColor(IntPtr handle)
    {
      this.Handle = handle;
    }

    public Color ToColor()
    {
      switch ((int) this.Handle)
      {
        case 0:
          return new Color(byte.MaxValue, (byte) 3, (byte) 3);
        case 1:
          return new Color((byte) 0, (byte) 66, byte.MaxValue);
        case 2:
          return new Color((byte) 28, (byte) 230, (byte) 185);
        case 3:
          return new Color((byte) 84, (byte) 0, (byte) 129);
        case 4:
          return new Color(byte.MaxValue, (byte) 252, (byte) 1);
        case 5:
          return new Color((byte) 254, (byte) 186, (byte) 14);
        case 6:
          return new Color((byte) 32, (byte) 192, (byte) 0);
        case 7:
          return new Color((byte) 229, (byte) 91, (byte) 176);
        case 8:
          return new Color((byte) 149, (byte) 150, (byte) 151);
        case 9:
          return new Color((byte) 126, (byte) 191, (byte) 241);
        case 10:
          return new Color((byte) 16, (byte) 98, (byte) 70);
        case 11:
          return new Color((byte) 78, (byte) 42, (byte) 4);
        default:
          return new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue);
      }
    }
  }
}
