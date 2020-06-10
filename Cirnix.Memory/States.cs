using System;
using static Cirnix.Memory.GameDll;
using static Cirnix.Memory.Message;
using static Cirnix.Memory.Component;
using static Cirnix.Memory.NativeMethods;
namespace Cirnix.Memory
{
    
    public static class States
    {
        private static readonly byte[] ChatStartPattern = new byte[] { 0x6D, 0x6F };
        private static readonly byte[] HostStatePattern = new byte[] { 0x4C, 0x7F, 0x65, 7, 0x4C };

        public static bool IsLobbyList {
            get {
                if (CEditBoxOffset != IntPtr.Zero)
                {
                    byte[] buffer = new byte[2];
                    ReadProcessMemory(Warcraft3Info.Handle, CEditBoxOffset + 0x6E2, buffer, 2, out _);
                    if (CompareArrays(buffer, ChatStartPattern, 2))
                        return true;
                }
                return false;
            }
        }

        public static bool IsChatBoxOpen {
            get {
                if (GameDllOffset != IntPtr.Zero)
                    return BitConverter.ToBoolean(Bring(GameDllOffset + 0xD04FEC, 4), 0);
                return false;
            }
        }

        public static MusicState CurrentMusicState {
            get {
                if (GameDllOffset != IntPtr.Zero)
                {
                    int A = BitConverter.ToInt32(Bring(GameDllOffset + 0xD32318, 4), 0);
                    int B = BitConverter.ToInt32(Bring(GameDllOffset + 0xD3231C, 4), 0);
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

        public static int PlayerNumber => BitConverter.ToInt32(Bring(SearchAddress(HostStatePattern, 0x7FFFFFFF, 4) + 0x33C, 4), 0);

        public static bool IsHostPlayer => BitConverter.ToInt32(Bring(SearchAddress(HostStatePattern, 0x7FFFFFFF, 4) + 0x210, 4), 0) == 2;
    }
}
