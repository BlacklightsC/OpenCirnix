using System;

using static Cirnix.Memory.Component;
using static Cirnix.Memory.Message;
using static Cirnix.Memory.NativeMethods;

namespace Cirnix.Memory
{

    public static class States
    {
        private static readonly byte[] ChatStartPattern = { 0x6D, 0x6F };
        private static readonly byte[] OsTcpSearchPattern = { 0x4C, 0x7F, 0x65, 7, 0x4C };
        internal static IntPtr OsTcpOffset = IntPtr.Zero;

        public static bool IsLobbyList {
            get {
                if (CEditBoxOffset != IntPtr.Zero)
                {
                    byte[] buffer = new byte[2];
                    ReadProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x6E6, buffer, 2, out _);
                    if (CompareArrays(buffer, ChatStartPattern, 2))
                        return true;
                }
                return false;
            }
        }

        public static bool IsChatBoxOpen => GameDllOffset != IntPtr.Zero && BitConverter.ToBoolean(Bring(GameDllOffset + 0xD04FEC, 4), 0);

        public static MusicState CurrentMusicState {
            get {
                if (GameDllOffset != IntPtr.Zero)
                {
                    byte[] a = Bring(GameDllOffset + 0xD32318, 4);
                    byte[] b = Bring(GameDllOffset + 0xD3231C, 4);
                    int A = BitConverter.ToInt32(a, 0);
                    int B = BitConverter.ToInt32(b, 0);
                    if (A == 2 && B == 2) return MusicState.Offline;
                    if (A == 16 && B == 10) return MusicState.BattleNet;
                    if (A == 4 && B == 4) return MusicState.InGameDefault;
                    if (A == 1 && B == 1) return MusicState.InGameCustom;
                    if (A == 0 && B == 0) return MusicState.Stopped;
                }
                return MusicState.None;
            }
        }

        public static bool IsInGame {
            get {
                MusicState state = CurrentMusicState;
                return state == MusicState.InGameDefault || state == MusicState.InGameCustom || state == MusicState.Stopped;
            }
        }

        private static bool GetOsTcpOffset()
        {
            if (StormDllOffset == IntPtr.Zero) return false;
            OsTcpOffset = FollowPointer(StormDllOffset + 0x58160, OsTcpSearchPattern);
            return OsTcpOffset != IntPtr.Zero;
        }

        public static int PlayerCount => GetOsTcpOffset() ? BitConverter.ToInt32(Bring(OsTcpOffset + 0x340, 4), 0) : 0;

        public static bool IsHostPlayer => GetOsTcpOffset() && BitConverter.ToInt32(Bring(OsTcpOffset + 0x214, 4), 0) == 2;
    }
}
