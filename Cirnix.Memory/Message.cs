using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Cirnix.Global;

using static Cirnix.Global.Globals;
using static Cirnix.Global.NativeMethods;
using static Cirnix.Memory.Component;
using static Cirnix.Memory.NativeMethods;

namespace Cirnix.Memory
{
    public static class Message
    {
        private static readonly byte[] MessageSearchPattern = { 0x94, 0x28, 0x49, 0x65, 0x94 };
        private static readonly byte[] MessageAdditionalPattern = { 0x65, 0x9B, 3, 0x36, 0x65 };
        private static readonly byte[] SelectedReceiverPattern = { 0xD3, 0xAF, 0x2A, 0x26, 0xD3 }; // 0x260
        private static readonly byte[] TargetReceiverPattern = { 0xB0, 0x32, 0x5B, 0x2C, 0xB0 }; // 0x2A8
        internal static IntPtr CEditBoxOffset = IntPtr.Zero;
        internal static IntPtr MessageOffset = IntPtr.Zero;
        internal static IntPtr SelectedReceiverOffset = IntPtr.Zero;
        internal static IntPtr TargetReceiverOffset = IntPtr.Zero;
        private static byte chatTarget = 0;
        private static ChatMode chatMode = ChatMode.Team;
        private static byte[] Stack = new byte[0x100];
        
        internal static bool GetOffset()
        {
            if (StormDllOffset == IntPtr.Zero) return false;
            CEditBoxOffset = FollowPointer(StormDllOffset + 0x58280, MessageSearchPattern);
            return CEditBoxOffset != IntPtr.Zero;
        }

        public static string GetMessage()
        {
            if (GetOffset())
            {
                byte[] buffer = new byte[0x100];
                if (ReadProcessMemory(Warcraft3Info.Handle, MessageOffset = CEditBoxOffset + 0x88 + (Settings.IsAutoFrequency ? 0 : 0x110 * Settings.ChatFrequency), buffer, 0x100, out _))
                    return ConvertToString(buffer);
            }
            CEditBoxOffset = IntPtr.Zero;
            return null;
        }

        internal static string ConvertToString(byte[] buffer)
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
            if (!GetOffset()) return;
            byte[] buffer = new byte[1];
            byte[] bytes = Encoding.UTF8.GetBytes($"\x1{Theme.MsgTitleColor}{Theme.MsgTitle} {Theme.MsgColor}채팅 주파수 검색 중...");
            for (int i = 0; i < 20; i++)
                WriteProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x88 + 0x110 * i, bytes, bytes.Length + 1, out _);
            ApplyChat(false);
            await Task.Delay(200);
            for (int i = 0; i < 20; i++)
                if (ReadProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x88 + 0x110 * i, buffer, 1, out _) && buffer[0] == 0)
                {
                    Settings.ChatFrequency = i;
                    for (int j = 0; j < 20; j++)
                        WriteProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x88 + 0x110 * j, new byte[] { 0 }, 1, out _);
                    return;
                }
        }

        public static bool GetSelectedReceiveStatus()
        {
            SelectedReceiverOffset = FollowPointer(StormDllOffset + 0x5837C, SelectedReceiverPattern);
            if (SelectedReceiverOffset != IntPtr.Zero)
            {
                byte[] buffer = new byte[4];
                if (ReadProcessMemory(Warcraft3Info.Handle, SelectedReceiverOffset += 0x260, buffer, 4, out _))
                    return true;
            }
            SelectedReceiverOffset = IntPtr.Zero;
            return false;
        }

        public static bool GetTargetReceiveStatus()
        {
            TargetReceiverOffset = FollowPointer(StormDllOffset + 0x582F0, TargetReceiverPattern);
            if (TargetReceiverOffset != IntPtr.Zero)
            {
                if (DirectBring(TargetReceiverOffset += 0x2A8, 4, out _))
                    return true;
            }
            TargetReceiverOffset = IntPtr.Zero;
            return false;
        }

        public static void SetEmpty()
        {
            DirectPatch(Settings.IsAutoFrequency ? MessageOffset : (CEditBoxOffset + 0x88 + 0x110 * Settings.ChatFrequency), 0);
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
                DirectBring(SelectedReceiverOffset, 8, out byte[] buffer);
                chatMode = (ChatMode)buffer[0];
                chatTarget = buffer[4];
                buffer[0] = 0;
                buffer[4] = 0x7F;
                DirectPatch(SelectedReceiverOffset, buffer);
            }
            else
            {
                byte[] buffer = new byte[8];
                buffer[0] = (byte)chatMode;
                buffer[4] = chatTarget;
                DirectPatch(SelectedReceiverOffset, buffer);
            }
        }

        public static void MessageHide()
        {
            if (!GetTargetReceiveStatus()) return;
            byte[] buffer = new byte[4];
            buffer[0] = 0x7F;
            DirectPatch(TargetReceiverOffset, buffer);
        }

        [Obsolete]
        public static void MessageStack(bool IsPush)
        {
            if (CEditBoxOffset == IntPtr.Zero)
            {
                CEditBoxOffset = SearchAddress(MessageAdditionalPattern);
                MessageOffset = CEditBoxOffset + 0x88;
            }
            if (CEditBoxOffset == IntPtr.Zero) return;
            if (IsPush)
            {
                if (Settings.IsAutoFrequency) ReadProcessMemory(Warcraft3Info.Handle, MessageOffset, Stack, 0x100, out _);
                else ReadProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x88 + 0x110 * Settings.ChatFrequency, Stack, 0x100, out _);
            }
            else
            {
                if (Settings.IsAutoFrequency) WriteProcessMemory(Warcraft3Info.Handle, MessageOffset, Stack, 0x100, out _);
                else WriteProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x88 + 0x110 * Settings.ChatFrequency, Stack, 0x100, out _);
                for (int i = 0; i < 0x100; i++) Stack[i] = 0;
            }
        }

        internal static void ApplyChat(bool TryHide)
        {
            if (!States.IsChatBoxOpen)
            {
                PostMessage(Warcraft3Info.MainWindowHandle, 0x100, 13, 0);
                PostMessage(Warcraft3Info.MainWindowHandle, 0x101, 13, 0);
                if (TryHide) Thread.Sleep(50);
            }
            if (TryHide) MessageHide();
            PostMessage(Warcraft3Info.MainWindowHandle, 0x100, 13, 0);
            PostMessage(Warcraft3Info.MainWindowHandle, 0x101, 13, 0);
            Thread.Sleep(50);
            if (States.IsChatBoxOpen)
            {
                PostMessage(Warcraft3Info.MainWindowHandle, 0x100, 13, 0);
                PostMessage(Warcraft3Info.MainWindowHandle, 0x101, 13, 0);
            }
        }

        private static void MessageCut(string pMessage, bool IsHide)
        {
            if (string.IsNullOrEmpty(pMessage)) return;
            if (CEditBoxOffset == IntPtr.Zero)
            {
                CEditBoxOffset = SearchAddress(MessageAdditionalPattern);
                MessageOffset = CEditBoxOffset + 0x88;
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
            else WriteProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x88 + 0x110 * Settings.ChatFrequency, bytes, bytes.Length + 1, out _);
            if (bytes[0] != 0) ApplyChat(IsHide && Settings.IsCommandHide);
        }

        public static bool SendMsg(bool UseTitle, params string[] args)
        {
            if (args == null || args.Length == 0) return false;
            if (args.Length == 1)
            {
                Thread.Sleep(100);
                return SendInstantMsg(UseTitle, args[0]);
            }
            else return SendMsg(UseTitle, args, 100);
        }
        public static bool SendMsg(bool UseTitle, string[] args, int delay, bool IsHide = true)
        {
            if (Warcraft3Info.Process == null) return false;
            foreach (var arg in args)
            {
                if (delay > 0) Thread.Sleep(delay);
                if (!string.IsNullOrEmpty(arg))
                    MessageCut((UseTitle ? $"\x1{Theme.MsgTitleColor}{Theme.MsgTitle} {Theme.MsgColor}" : string.Empty) + arg, IsHide);
            }
            return true;
        }
        public static bool SendInstantMsg(bool UseTitle, string arg, bool IsHide = true)
        {
            if (Warcraft3Info.Process == null || string.IsNullOrEmpty(arg)) return false;
            MessageCut((UseTitle ? $"\x1{Theme.MsgTitleColor}{Theme.MsgTitle} {Theme.MsgColor}" : string.Empty) + arg, IsHide);
            return true;
        }
    }
}
