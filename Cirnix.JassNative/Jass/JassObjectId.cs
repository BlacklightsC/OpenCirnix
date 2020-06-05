using Cirnix.JassNative.WarAPI.Types;
using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("I")]
  [Serializable]
  public struct JassObjectId
  {
    private readonly int value;

    public JassObjectId(int value)
    {
      this.value = value;
    }

    public JassObjectId(string objectId)
    {
      if (objectId.Length != 4)
        throw new ArgumentOutOfRangeException(nameof (objectId), "Invalid objectId. id must be 4 characters long");
      this.value = (int) objectId[0] << 24 | (int) objectId[1] << 16 | (int) objectId[2] << 8 | (int) objectId[3];
    }

    public static implicit operator string(JassObjectId from)
    {
      return new string(new char[4]
      {
        (char) (((long) from.value & 0xFF000000L) >> 24),
        (char) ((from.value & 0xFF0000) >> 16),
        (char) ((from.value & 0xFF00) >> 8),
        (char) (from.value & (int) byte.MaxValue)
      });
    }

    public static explicit operator JassObjectId(string from)
    {
      return new JassObjectId(from);
    }

    public static implicit operator int(JassObjectId from)
    {
      return from.value;
    }

    public static implicit operator JassObjectId(int from)
    {
      return new JassObjectId(from);
    }

    public static implicit operator ObjectIdL(JassObjectId from)
    {
      return new ObjectIdL(from.value);
    }

    public static implicit operator ObjectIdB(JassObjectId from)
    {
      return (ObjectIdB) new ObjectIdL(from.value);
    }

    public override string ToString()
    {
      return (string) this.ToString();
    }

    public string ToString(IFormatProvider provider)
    {
      return (string) this.ToString(provider);
    }

    public int ToInt32()
    {
      return this.value;
    }

    public override int GetHashCode()
    {
      return this.value;
    }
  }
}
