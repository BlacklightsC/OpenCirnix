using System;
using System.Text;

using static Cirnix.Memory.Component;
using static Cirnix.Memory.NativeMethods;

namespace Cirnix.Memory
{

    public static class ChannelChat
    {
        private static readonly byte[] ChannelSignature = { 0x1A, 0x27, 0xBA, 0x66, 0x1A };
        private static readonly byte[] MessageSignature = { 0x16, 0x3C, 0x47, 0x5B, 0x16 };
        internal static IntPtr ChannelOffset = IntPtr.Zero;
        internal static IntPtr MessageOffset = IntPtr.Zero;
        private static int PreviousLength = 0;

        private static string SearchChannelOffset()
        {
            ChannelOffset = FollowPointer(StormDllOffset + 0x58098, ChannelSignature);
            if (ChannelOffset != IntPtr.Zero)
            {
                byte[] buffer = new byte[0x20];
                if (ReadProcessMemory(Warcraft3Info.Handle, ChannelOffset + 0x384, buffer, 0x20, out _))
                    return Encoding.UTF8.GetString(buffer);
            }
            ChannelOffset = IntPtr.Zero;
            return null;
        }

        private static int SearchMessageOffset()
        {
            MessageOffset = FollowPointer(StormDllOffset + 0x58088, MessageSignature);
            if (MessageOffset != IntPtr.Zero)
            {
                byte[] buffer = new byte[4];
                if (ReadProcessMemory(Warcraft3Info.Handle, MessageOffset + 0x18, buffer, 4, out _))
                    return BitConverter.ToInt32(buffer, 0);
            }
            PreviousLength = 0;
            MessageOffset = IntPtr.Zero;
            return -1;
        }

        public static string GetChannelName()
        {
            string Text;
            if(string.IsNullOrEmpty(Text = SearchChannelOffset())) return string.Empty;
            return Text.Replace(Encoding.UTF8.GetString(new byte[] { 0xEF, 0xBF, 0xBD }), null);
        }

        public static string GetChannelChat()
        {
            if (States.CurrentMusicState != MusicState.BattleNet) return null;
            string Text = string.Empty;
            int Length;
            if((Length = SearchMessageOffset()) != -1)
            {
                byte[] buffer = new byte[Length];
                try
                {
                    ReadProcessMemory(Warcraft3Info.Handle, MessageOffset + 0x88, buffer, Length, out _);
                }
                catch
                {
                    return string.Empty;
                }
                if (PreviousLength > Length) PreviousLength = 0;
                byte[] buffer2 = new byte[Length - PreviousLength];
                Array.ConstrainedCopy(buffer, PreviousLength, buffer2, 0, Length - PreviousLength);
                Text = Encoding.UTF8.GetString(buffer2);
                PreviousLength = Length - 1;
                if (PreviousLength < 0) PreviousLength = 0;
                if (string.IsNullOrEmpty(Text)) Text = string.Empty;
            }
            return Text;
        }
    }
}
