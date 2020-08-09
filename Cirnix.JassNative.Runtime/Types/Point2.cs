using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.Runtime.Types
{
    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct Point2
    {
        public int X, Y;

        public Point2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"({X}; {Y})";
    }
}
