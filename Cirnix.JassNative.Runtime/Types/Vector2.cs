using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.Runtime.Types
{
    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct Vector2
    {
        public float X, Y;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"({X}; {Y})";
    }
}
