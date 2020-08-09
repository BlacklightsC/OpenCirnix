using System;
using System.Runtime.InteropServices;

using Cirnix.JassNative.Runtime.Windows;

namespace Cirnix.JassNative.Common
{
    internal static class Component
    {
        internal static byte[] Bring(IntPtr Offset, int size)
        {
            if (Kernel32.VirtualProtect(Offset, size, 0x40, out uint lpflOldProtect))
            {
                byte[] lpBuffer = new byte[size];
                for (int i = 0; i < size; i++)
                    lpBuffer[i] = Marshal.ReadByte(Offset + i);
                Kernel32.VirtualProtect(Offset, size, lpflOldProtect, out _);
                return lpBuffer;
            }
            return null;
        }

        internal static int BringInt(IntPtr Offset)
        {
            int ret = 0;
            if (Kernel32.VirtualProtect(Offset, 4, 0x40, out uint lpflOldProtect))
            {
                ret = Marshal.ReadInt32(Offset);
                Kernel32.VirtualProtect(Offset, 4, lpflOldProtect, out _);
            }
            return ret;
        }

        internal static void Patch(IntPtr Offset, params byte[] buffer)
        {
            if (Kernel32.VirtualProtect(Offset, buffer.Length, 0x40, out uint lpflOldProtect))
            {
                for (int i = 0; i < buffer.Length; i++)
                    Marshal.WriteByte(Offset + i, buffer[i]);
                Kernel32.VirtualProtect(Offset, buffer.Length, lpflOldProtect, out _);
            }
        }

        internal static void Patch(IntPtr Offset, int value)
        {
            if (Kernel32.VirtualProtect(Offset, 4, 0x40, out uint lpflOldProtect))
            {
                Marshal.WriteInt32(Offset, value);
                Kernel32.VirtualProtect(Offset, 4, lpflOldProtect, out _);
            }
        }
    }
}
