using System;

using CirnoLib;

using static Cirnix.Memory.Component;

namespace Cirnix.Memory
{
    public static class MessageFrame
    {
        private static readonly byte[] FrameDefSignature = { 0xCE, 0x78, 0xE1, 0x3A, 0xCE };
        private static readonly byte[] AVCSimpleMessageFrameLineSignature = { 0x33, 0x71, 0x6C, 0x0F, 0x33 };
        internal static IntPtr TextArrayDoublePointer = IntPtr.Zero;
        internal static IntPtr TextArrayPointer = IntPtr.Zero;

        private static bool GetFrameDefOffset()
        {
            if (StormDllOffset == IntPtr.Zero) return false;
            TextArrayDoublePointer = FollowPointer(StormDllOffset + 0x58368, FrameDefSignature);
            if (TextArrayDoublePointer != IntPtr.Zero)
            {
                TextArrayPointer = FollowPointer(TextArrayDoublePointer += 0x4B4);
                if (TextArrayPointer == IntPtr.Zero)
                {
                    TextArrayPointer = FollowPointer(TextArrayDoublePointer -= 0x240);
                    if (TextArrayPointer != IntPtr.Zero) return true;
                }
                else return true;
            }
            TextArrayDoublePointer = IntPtr.Zero;
            TextArrayPointer = IntPtr.Zero;
            return false;
        }

        private static bool GetMessageFrameOffset()
        {
            if (StormDllOffset == IntPtr.Zero) return false;
            TextArrayPointer = FollowPointer(StormDllOffset + 0x580FC, AVCSimpleMessageFrameLineSignature);
            if (TextArrayPointer != IntPtr.Zero)
            {
                TextArrayPointer += 0xF8;
                return true;
            }
            else return false;
        }

        public static string GetLastLobbyChat()
        {
            if (!GetFrameDefOffset()) return null;
            if (!DirectBring(TextArrayDoublePointer - 4, 4, out byte[] buffer)) return null;
            int index = buffer.ToInt32() - 1;
            if (index == 0x7F)
            {
                if (!DirectBring(TextArrayDoublePointer + 8, 4, out buffer)) return null;
                index = buffer.ToInt32() - 1;
            }
            else if (index == -1) return null;
            IntPtr TextOffset = FollowPointer(TextArrayPointer + (index * 4));
            if (TextOffset == IntPtr.Zero) return null;
            if (!DirectBring(TextOffset - 8, 2, out buffer)) return null;
            if (!DirectBring(TextOffset, buffer.ToInt16() - 9, out buffer)) return null;
            return buffer.GetString().TrimEnd('\0');
        }

        public static string GetLastInGameChat()
        {
            if (!GetMessageFrameOffset()) return null;
            IntPtr TextPointer = FollowPointer(TextArrayPointer);
            if (TextPointer == IntPtr.Zero
            || (TextPointer = FollowPointer(TextPointer + 0xA4)) == IntPtr.Zero
            || !DirectBring(TextPointer, 0xA0, out byte[] buffer))
                return null;
            return buffer.GetString().TrimEnd('\0');
        }

        public static string GetLastChat()
        {
            if (Message.GetSelectedReceiveStatus())
                return GetLastInGameChat();
            else
                return GetLastLobbyChat();
        }
    }
}
