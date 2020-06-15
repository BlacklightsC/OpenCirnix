using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hgamecache;")]
    [Serializable]
    public struct JassGameCache : IEquatable<JassGameCache>
    {
        public readonly IntPtr Handle;

        public static bool operator ==(JassGameCache left, JassGameCache right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(JassGameCache left, JassGameCache right)
        {
            return !left.Equals(right);
        }

        public bool Equals(JassGameCache other)
        {
            return this.Handle == other.Handle;
        }

        public override bool Equals(object other)
        {
            return other is JassGameCache cache && this.Equals(cache);
        }

        public override int GetHashCode()
        {
            return this.Handle.ToInt32();
        }

        public JassGameCache(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}