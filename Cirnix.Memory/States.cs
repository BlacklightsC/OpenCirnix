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

        public static GameState CurrentGameState {
            get {
                if (GameDllOffset != IntPtr.Zero)
                {
                    int A = BitConverter.ToInt32(Bring(GameDllOffset + 0xD32318, 4), 0);
                    int B = BitConverter.ToInt32(Bring(GameDllOffset + 0xD3231C, 4), 0);
                    if (A == 2 && B == 2) return GameState.Offline;
                    if (A == 4 && B == 4) return GameState.StartedGame;
                    if (A == 1 && B == 1) return GameState.InGame;
                    if (A == 16 && B == 10) return GameState.BattleNet;
                    if (A == 0 && B == 0)
                    {
                        if (Global.Globals.ExtendForce)
                            return GameState.InGame;
                        else
                            return GameState.Unknown;
                    }
                }
                return GameState.None;
            }
        }

        public static int PlayerNumber {
            get {
                return BitConverter.ToInt32(Bring(SearchAddress(HostStatePattern, 0x7FFFFFFF, 4) + 0x33C, 4), 0);
            }
        }

        public static bool IsHostPlayer {
            get {
                return BitConverter.ToInt32(Bring(SearchAddress(HostStatePattern, 0x7FFFFFFF, 4) + 0x210, 4), 0) == 2;
            }
        }
    }
}
