using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.Runtime.Types
{
    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct Vector3
    {
        public float X, Y, Z;

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(Vector2 vector, float z)
        {
            X = vector.X;
            Y = vector.Y;
            Z = z;
        }

        public override string ToString() => $"({X}; {Y}; {Z})";
    }
}
