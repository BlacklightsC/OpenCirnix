using System;
using System.Text;

namespace Cirnix.JassNative.WarAPI.Types
{
  [Serializable]
  public struct ObjectIdL
  {
    private readonly int value;

    public ObjectIdL(int id)
    {
      this.value = id;
    }

    public ObjectIdL(string id)
    {
      if (id.Length != 4)
        throw new ArgumentOutOfRangeException(nameof (id), "Invalid id. Must be 4 characters long");
      this.value = (int) id[3] | (int) id[2] << 8 | (int) id[1] << 16 | (int) id[0] << 24;
    }

    public static explicit operator int(ObjectIdL from)
    {
      return from.value;
    }

    public static explicit operator ObjectIdL(int from)
    {
      return new ObjectIdL(from);
    }

    public static explicit operator ObjectIdL(ObjectIdB from)
    {
      byte[] bytes = BitConverter.GetBytes((int) from);
      Array.Reverse((Array) bytes);
      return new ObjectIdL(BitConverter.ToInt32(bytes, 0));
    }

    public override string ToString()
    {
      byte[] bytes = BitConverter.GetBytes(this.value);
      Array.Reverse((Array) bytes);
      return Encoding.UTF8.GetString(bytes);
    }
  }
}
