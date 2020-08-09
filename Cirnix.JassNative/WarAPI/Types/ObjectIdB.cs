using System;
using System.Text;

namespace Cirnix.JassNative.WarAPI.Types
{
    [Serializable]
    public struct ObjectIdB
    {
        private readonly int value;

        public ObjectIdB(int id)
        {
            value = id;
        }

        public ObjectIdB(string id)
        {
            if (id.Length != 4)
                throw new ArgumentOutOfRangeException(nameof(id), "Invalid id. Must be 4 characters long");
            value = id[0] | id[1] << 8 | id[2] << 16 | id[3] << 24;
        }

        public static explicit operator int(ObjectIdB from)
        {
            return from.value;
        }

        public static explicit operator ObjectIdB(int from)
        {
            return new ObjectIdB(from);
        }

        public static explicit operator ObjectIdB(ObjectIdL from)
        {
            byte[] bytes = BitConverter.GetBytes((int)from);
            Array.Reverse(bytes);
            return new ObjectIdB(BitConverter.ToInt32(bytes, 0));
        }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(BitConverter.GetBytes(value));
        }
    }
}