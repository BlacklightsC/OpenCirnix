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
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 27, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 27, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x100, 46, 0);
            PostMessage(Warcraft3Info.Process.MainWindowHandle, 0x101, 46, 0);
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