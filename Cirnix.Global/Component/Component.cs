using System;
using System.Drawing;
using System.Runtime.InteropServices;
using static Cirnix.Global.NativeMethods;

namespace Cirnix.Global
{
    public static class Component
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X, Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static implicit operator Point(POINT p) => new Point(p.X, p.Y);

            public static implicit operator POINT(Point p) => new POINT(p.X, p.Y);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public RECT(Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

            public int X {
                get => Left;
                set {
                    Right -= Left - value;
                    Left = value;
                }
            }

            public int Y {
                get => Top;
                set {
                    Bottom -= Top - value; 
                    Top = value;
                }
            }

            public int Height {
                get => Bottom - Top;
                set => Bottom = value + Top;
            }

            public int Width {
                get => Right - Left;
                set => Right = value + Left;
            }

            public Point Location {
                get => new Point(Left, Top);
                set {
                    X = value.X;
                    Y = value.Y;
                }
            }

            public Size Size {
                get => new Size(Width, Height);
                set { 
                    Width = value.Width; 
                    Height = value.Height; 
                }
            }

            public static implicit operator Rectangle(RECT r) => new Rectangle(r.Left, r.Top, r.Width, r.Height);

            public static implicit operator RECT(Rectangle r) => new RECT(r);

            public static bool operator ==(RECT r1, RECT r2) => r1.Equals(r2);

            public static bool operator !=(RECT r1, RECT r2) => !r1.Equals(r2);

            public bool Equals(RECT r) => r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;

            public override bool Equals(object obj)
            {
                if (obj is RECT)
                    return Equals((RECT)obj);
                else if (obj is Rectangle)
                    return Equals(new RECT((Rectangle)obj));
                return false;
            }

            public override int GetHashCode() => ((Rectangle)this).GetHashCode();

            public override string ToString()
                => $"{{Left={Left},Top={Top},Right={Right},Bottom={Bottom}}}";
        }

        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }

        public enum InputState
        {
            Chat,
            Command,
            None
        }

        public static string GetLastErrorMessage()
        {
            FormatMessage(0x1300, IntPtr.Zero, GetLastError(), 0x400, out string errmsg, 260, IntPtr.Zero);
            return errmsg;
        }
    }
}
