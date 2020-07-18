using System;

using static Cirnix.Global.NativeMethods;
using static Cirnix.Memory.Component;

namespace Cirnix.Memory
{
    public static class GameDll
    {
        public static bool HPView {
            get {
                if (GameDllOffset != IntPtr.Zero)
                {
                    byte[] pattern = { 0 };
                    byte[] buffer = Bring(GameDllOffset + 0xAAF3C2, 1);
                    if (CompareArrays(buffer, pattern, 1))
                        return true;
                }
                return false;
            }
            set {
                if (GameDllOffset == IntPtr.Zero) return;
                Patch(GameDllOffset + 0xAAF3C2, value ? new byte[] { 0 } : new byte[] { 0x20 });
            }
        }

        public static float StartDelay {
            get {
                if (GameDllOffset != IntPtr.Zero)
                    try
                    {
                        return BitConverter.ToSingle(Bring(GameDllOffset + 0x324146, 4), 0);
                    }
                    catch { }
                return -1;
            }
            set {
                if (GameDllOffset == IntPtr.Zero) return;
                Patch(GameDllOffset + 0x324146, BitConverter.GetBytes(value));
            }
        }

        public static float RefreshCooldown {
            get {
                if (GameDllOffset != IntPtr.Zero)
                    try
                    {
                        return BitConverter.ToSingle(Bring(GameDllOffset + 0x310C07, 4), 0);
                    }
                    catch { }
                return -1;
            }
            set {
                if (GameDllOffset == IntPtr.Zero) return;
                Patch(GameDllOffset + 0x310C07, BitConverter.GetBytes(value));
            }
        }

        public static bool ColorfulChat {
            get {
                if (GameDllOffset != IntPtr.Zero)
                {
                    byte[] pattern = { 0xE9 };
                    byte[] buffer = Bring(GameDllOffset + 0x1518C0, 1);
                    if (CompareArrays(buffer, pattern, 1))
                        return true;
                }
                return false;
            }
            set {
                if (GameDllOffset == IntPtr.Zero) return;
                Patch(GameDllOffset + 0x1518C0, value ? new byte[] { 0xE9, 0x9B, 0x00, 0x00, 0x00, 0x90, 0x90, 0x90, 0x90 }
                                                      : new byte[] { 0x83, 0xF8, 0x03, 0x0F, 0x87, 0x97, 0x00, 0x00, 0x00 });
                Patch(GameDllOffset + 0x1D00E0, value ? new byte[] { 0x44, 0x24, 0x18, 0x5E, 0x5B, 0x5D, 0xC2, 0x18, 0x00 }
                                                      : new byte[] { 0xC6, 0x5E, 0x5B, 0x5D, 0xC2, 0x18, 0x00, 0xCC, 0xCC });
            }
        }

        #region [    Camera Settings    ]
        public static void CameraInit()
        {
            #region [    Original Version    ]
            //keybd_event(0xD, 0, 0, 0x21);
            //keybd_event(0xD, 0, 2, 0x21);
            //Thread.Sleep(1);
            //keybd_event(0x21, 0, 0, 0x21);
            //keybd_event(0x21, 0, 2, 0x21);
            //Thread.Sleep(1);
            //keybd_event(0x22, 0, 0, 0x21);
            //keybd_event(0x22, 0, 2, 0x21);
            #endregion
            if (!Message.GetSelectedReceiveStatus()) return;
            PostMessage(Warcraft3Info.MainWindowHandle, 0x100, 27, 0);
            PostMessage(Warcraft3Info.MainWindowHandle, 0x101, 27, 0);
            PostMessage(Warcraft3Info.MainWindowHandle, 0x100, 46, 0);
            PostMessage(Warcraft3Info.MainWindowHandle, 0x101, 46, 0);
        }
        public static float CameraDistance {
            get {
                if (GameDllOffset != IntPtr.Zero)
                    try
                    {
                        return BitConverter.ToSingle(Bring(GameDllOffset + 0xA8F300, 4), 0);
                    }
                    catch { }
                return -1;
            }
            set {
                if (GameDllOffset == IntPtr.Zero) return;
                Patch(GameDllOffset + 0xA8F300, BitConverter.GetBytes(value));
            }
        }
        public static float CameraAngleX {
            get {
                if (GameDllOffset != IntPtr.Zero)
                    try
                    {
                        return BitConverter.ToSingle(Bring(GameDllOffset + 0xA8F2D0, 4), 0);
                    }
                    catch { }
                return -1;
            }
            set {
                if (GameDllOffset == IntPtr.Zero) return;
                Patch(GameDllOffset + 0xA8F2D0, BitConverter.GetBytes(value));
            }
        }
        public static float CameraAngleY {
            get {
                if (GameDllOffset != IntPtr.Zero)
                    try
                    {
                        return BitConverter.ToSingle(Bring(GameDllOffset + 0xA8F2F0, 4), 0);
                    }
                    catch { }
                return -1;
            }
            set {
                if (GameDllOffset == IntPtr.Zero) return;
                Patch(GameDllOffset + 0xA8F2F0, BitConverter.GetBytes(value));
            }
        }
        #endregion
    }
}