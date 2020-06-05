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
      MemoryStream memoryStream = new MemoryStream(4);
      new BinaryWriter((Stream) memoryStream).Write(from.valueAsInt32);
      return BitConverter.ToSingle(memoryStream.ToArray(), 0);
    }

    public static implicit operator JassRealRet(float from)
    {
      MemoryStream memoryStream = new MemoryStream(4);
      new BinaryWriter((Stream) memoryStream).Write(from);
      return new JassRealRet(BitConverter.ToInt32(memoryStream.ToArray(), 0));
    }

    public static implicit operator JassRealArg(JassRealRet from)
    {
      return (JassRealArg) (float) from;
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
