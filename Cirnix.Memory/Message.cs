using Cirnix.Global;

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Cirnix.Global.Globals;
using static Cirnix.Global.NativeMethods;
using static Cirnix.Memory.Component;
using static Cirnix.Memory.NativeMethods;

namespace Cirnix.Memory
{
    public static class Message
    {
        private static readonly byte[] MessageSearchPattern = new byte[] { 0x94, 0x28, 0x49, 0x65, 0x94 };
        private static readonly byte[] MessageAdditionalPattern = new byte[] { 0x65, 0x9B, 3, 0x36, 0x65 };
        private static readonly byte[] MessageDialogPattern = new byte[] { 0x6D, 0x6F };
        private static readonly byte[] SelectedReceiverPattern = new byte[] { 0xD3, 0xAF, 0x2A, 0x26, 0xD3 }; // 0x25C
        private static readonly byte[] TargetReceiverPattern = new byte[] { 0xB0, 0x32, 0x5B, 0x2C, 0xB0 }; // 0x2A4
        internal static IntPtr CEditBoxOffset = IntPtr.Zero;
        internal static IntPtr MessageOffset = IntPtr.Zero;
        internal static IntPtr SelectedReceiverOffset = IntPtr.Zero;
        internal static IntPtr TargetReceiverOffset = IntPtr.Zero;
        private static byte chatTarget = 0;
        private static ChatMode chatMode = ChatMode.Team;
        private static byte[] Stack = new byte[0x100];

        public static string GetMessage()
        {
            CEditBoxOffset = SearchAddress(MessageSearchPattern);
            if (CEditBoxOffset != IntPtr.Zero)
            {
                byte[] buffer = new byte[0x100];
                if (Settings.IsAutoFrequency)
                    for (int i = 0; i < 20; i++)
                        if (ReadProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x82 + (0x110 * i), buffer, 2, out _))
                        {
                            if (!CompareArrays(MessageDialogPattern, buffer, 2)) continue;
                            if (ReadProcessMemory(Warcraft3Info.Handle, MessageOffset = CEditBoxOffset + 0x84 + (0x110 * i), buffer, 0x100, out _))
                                return ConvertToString(buffer);
                        }
                else if (ReadProcessMemory(Warcraft3Info.Handle, MessageOffset = CEditBoxOffset + 0x84 + (0x110 * Settings.ChatFrequency), buffer, 0x100, out _))
                    return ConvertToString(buffer);
            }
            CEditBoxOffset = IntPtr.Zero;
            return null;
        }

        private static string ConvertToString(byte[] buffer)
        {
            int Length = buffer.Length - 1;
            for (int i = 1; i < buffer.Length; i++)
            {
                if (buffer[i] != 0) continue;
                Length = i;
                if (Length == 1 && buffer[0] == 0) return null;
                break;
            }
            byte[] iBuffer = new byte[Length];
            Array.ConstrainedCopy(buffer, 0, iBuffer, 0, Length);
            return Encoding.UTF8.GetString(iBuffer);
        }

        public static async Task DetectChatFrequency()
        {
            CEditBoxOffset = SearchAddress(MessageSearchPattern);
            if (CEditBoxOffset == IntPtr.Zero) return;
            byte[] buffer = new byte[1];
            byte[] bytes = Encoding.UTF8.GetBytes($"{Theme.MsgTitle} 채팅 주파수 검색 중...");
            for (int i = 0; i < 20; i++)
                WriteProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x84 + (0x110 * i), bytes, bytes.Length + 1, out _);
            ApplyChat(false);
            await Task.Delay(200);
            for (int i = 0; i < 20; i++)
                if (ReadProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x84 + (0x110 * i), buffer, 1, out _) && buffer[0] == 0)
                {
                    Settings.ChatFrequency = i;
                    for (int j = 0; j < 20; j++)
                        WriteProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x84 + (0x110 * j), new byte[] { 0 }, 1, out _);
                    return;
                }
        }

        public static bool GetSelectedReceiveStatus()
        {
            SelectedReceiverOffset = SearchAddress(SelectedReceiverPattern);
            if (SelectedReceiverOffset != IntPtr.Zero)
            {
                byte[] buffer = new byte[4];
                if (ReadProcessMemory(Warcraft3Info.Handle, SelectedReceiverOffset += 0x25C, buffer, 4, out _))
                    return true;
            }
            SelectedReceiverOffset = IntPtr.Zero;
            return false;
        }

        public static bool GetTargetReceiveStatus()
        {
            TargetReceiverOffset = SearchAddress(TargetReceiverPattern);
            if (TargetReceiverOffset != IntPtr.Zero)
            {
                byte[] buffer = new byte[4];
                if (ReadProcessMemory(Warcraft3Info.Handle, TargetReceiverOffset += 0x2A4, buffer, 4, out _))
                    return true;
            }
            TargetReceiverOffset = IntPtr.Zero;
            return false;
        }

        public static void SetEmpty()
        {
            if (Settings.IsAutoFrequency) WriteProcessMemory(Warcraft3Info.Handle, MessageOffset, new byte[] { 0 }, 1, out _);
            else WriteProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x84 + (0x110 * Settings.ChatFrequency), new byte[] { 0 }, 1, out _);
        }

        public static void CheckErrorChat()
        {
            int type = 0, target = -1;
            byte[] buffer = new byte[8];
            ReadProcessMemory(Warcraft3Info.Handle, SelectedReceiverOffset, buffer, 8, out _);
            if (type != 0 || target != 0xF) return;
            WriteProcessMemory(Warcraft3Info.Handle, SelectedReceiverOffset, new byte[] { 0x01 }, 1, out _);
            WriteProcessMemory(Warcraft3Info.Handle, SelectedReceiverOffset + 4, new byte[] { 0x00 }, 1, out _);
        }
        
        public static void MessageHideAll(bool isHide)
        {
            if (!GetSelectedReceiveStatus()) return;
            if (isHide)
            {
                if (chatMode == ChatMode.Private) return;
                byte[] buffer = new byte[8];
                ReadProcessMemory(Warcraft3Info.Handle, SelectedReceiverOffset, buffer, 8, out _);
                chatMode = (ChatMode)buffer[0];
                chatTarget = buffer[4];
                buffer[0] = 0;
                buffer[4] = 0x7F;
                WriteProcessMemory(Warcraft3Info.Handle, SelectedReceiverOffset, buffer, 8, out _);
            }
            else
            {
                byte[] buffer = new byte[8];
                buffer[0] = (byte)chatMode;
                buffer[4] = chatTarget;
                WriteProcessMemory(Warcraft3Info.Handle, SelectedReceiverOffset, buffer, 8, out _);
            }
        }

        public static void MessageHide()
        {
            if (!GetTargetReceiveStatus()) return;
            byte[] buffer = new byte[4];
            buffer[0] = 0x7F;
            WriteProcessMemory(Warcraft3Info.Handle, TargetReceiverOffset, buffer, 4, out _);
        }

        public static void MessageStack(bool IsPush)
        {
            if (CEditBoxOffset == IntPtr.Zero)
            {
                CEditBoxOffset = SearchAddress(MessageAdditionalPattern);
                MessageOffset = CEditBoxOffset + 0x84;
            }
            if (CEditBoxOffset == IntPtr.Zero) return;
            if (IsPush)
            {
                if (Settings.IsAutoFrequency) ReadProcessMemory(Warcraft3Info.Handle, MessageOffset, Stack, 0x100, out _);
                else ReadProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x84 + (0x110 * Settings.ChatFrequency), Stack, 0x100, out _);
            }
            else
            {
                if (Settings.IsAutoFrequency) WriteProcessMemory(Warcraft3Info.Handle, MessageOffset, Stack, 0x100, out _);
                else WriteProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x84 + (0x110 * Settings.ChatFrequency), Stack, 0x100, out _);
                for (int i = 0; i < 0x100; i++) Stack[i] = 0;
            }
        }

        internal static void ApplyChat(bool TryHide)
        {
            if (!States.IsChatBoxOpen)
            {
                PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 13, 0);
                PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 13, 0);
                if (TryHide) Thread.Sleep(50);
            }
            if (TryHide) MessageHide();
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 13, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 13, 0);
            Thread.Sleep(20);
            if (States.IsChatBoxOpen)
            {
                PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 13, 0);
                PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 13, 0);
            }
        }

        private static void MessageCut(string pMessage, bool IsHide)
        {
            if (string.IsNullOrEmpty(pMessage)) return;
            if (CEditBoxOffset == IntPtr.Zero)
            {
                CEditBoxOffset = SearchAddress(MessageAdditionalPattern);
                MessageOffset = CEditBoxOffset + 0x84;
            }
            if (CEditBoxOffset == IntPtr.Zero) return;
            byte[] bytes = Encoding.UTF8.GetBytes(pMessage);
            //if (Status.IsLobbyList)
            //    WriteProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x6E4, bytes, bytes.Length + 1, out _);
            //else
            switch (pMessage[0])
            {
                case '!':
                    UserState = CommandTag.Default;
                    bytes[0] = 0;
                    break;
                case '-':
                    UserState = CommandTag.Chat;
                    break;
            }

            if (Settings.IsAutoFrequency) WriteProcessMemory(Warcraft3Info.Handle, MessageOffset, bytes, bytes.Length + 1, out _);
            else WriteProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x84 + (0x110 * Settings.ChatFrequency), bytes, bytes.Length + 1, out _);
            if (bytes[0] != 0) ApplyChat(IsHide && Settings.IsCommandHide);
        }

        public static bool SendMsg(bool UseTitle, params string[] args)
        {
            if (args == null || args.Length == 0) return false;
            if (args.Length == 1) return SendSingleMsg(UseTitle, args[0]);
            else return SendMsg(UseTitle, args, 100);
        }
        public static bool SendMsg(bool UseTitle, string[] args, int delay, bool IsHide = true)
        {
            if (Warcraft3Info.Process == null) return false;
            foreach (var arg in args)
            {
                Thread.Sleep(delay);
                if (!string.IsNullOrEmpty(arg))
                    MessageCut((UseTitle ? $"{Theme.MsgTitle} " : string.Empty) + arg, IsHide);
            }
            return true;
        }
        public static bool SendSingleMsg(bool UseTitle, string arg, bool IsHide = true)
        {
            if (Warcraft3Info.Process == null || string.IsNullOrEmpty(arg)) return false;
            MessageCut((UseTitle ? $"{Theme.MsgTitle} " : string.Empty) + arg, IsHide);
            return true;
        }
    }
}
