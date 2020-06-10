using System;
using System.Diagnostics;
using System.Windows.Forms;
using static Cirnix.Global.Globals;
using static Cirnix.Memory.Component;
using static Cirnix.Memory.NativeMethods;

namespace Cirnix.Memory
{
    public static class GameModule
    {
        #region [    Unused Functions    ]
        /*
                private static IntPtr getLANAddr()
                {
                    if ((Warcraft3Info.BaseVersion.Version != 0L) || (Warcraft3Info.BaseVersion.BaseAddress != IntPtr.Zero))
                    {
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x7eL))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x661a91;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x7dL))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x661861;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x4dcL))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6616a1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x7cL))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x661551;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x7bL))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x652c01;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x7aL))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6517e1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x4bbL))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6e8251;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x4baL))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6e8231;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x4b4L))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6e41e1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x4b3L))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6e41d1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x1259aeL))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6e4211;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0xf92bdL))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6e39b1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0xf92bcL))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6e38a1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x3fbL))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6e38a1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x3faL))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6e33a1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x3f9L))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6e2131;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x3f8L))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6b50d1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x3f7L))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6b50d1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x9ad036L))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x698da1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x9ad030L))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6986b1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x9aa908L))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6984a1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x9aa905L))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x6984a1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x3f4L))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x67a5c1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x3f3L))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x67a5d1;
                        }
                        if (numStartsWith(Warcraft3Info.BaseVersion.Version, 0x6bL))
                        {
                            return Warcraft3Info.BaseVersion.BaseAddress + 0x674911;
                        }
                    }
                    return IntPtr.Zero;
                }
               
                private static bool numStartsWith(long value, long number)
                {
                    while (value > number) value /= 10L;
                    return value == number;
                }

                */
        #endregion

        private static bool GetBase(BaseVersion bv)
        {
            try
            {
                foreach (ProcessModule item in Warcraft3Info.Process.Modules)
                {
                    if (string.Compare(item.ModuleName, TargetProcess + ".exe", true) == 0)
                    {
                        Warcraft3Info.BaseVersion.BaseAddress = item.BaseAddress;
                        Warcraft3Info.BaseVersion.Version = 
                            int.Parse(item.FileVersionInfo.FileVersion.Replace(" ", string.Empty)
                                                                      .Replace(".", string.Empty)
                                                                      .Replace(",", string.Empty));
                        return true;
                    }
                }
            }
            catch
            {
                Warcraft3Info.BaseVersion.Version = 0L;
                Warcraft3Info.BaseVersion.BaseAddress = IntPtr.Zero;
            }
            return false;
        }

        private static void ResetWarcraft3Info()
        {
            Warcraft3Info.BaseVersion.Version = 0L;
            Warcraft3Info.ID = 0;
            Warcraft3Info.Process = null;

            Warcraft3Info.BaseVersion.BaseAddress =
            Warcraft3Info.Handle =
            ChannelChat.ChannelOffset =
            ChannelChat.MessageOffset =
            ControlDelay.Offset =
            GameDll.GameDllOffset =
            LoadedFiles.Offset =
            Message.CEditBoxOffset =
            Message.MessageOffset =
            Message.ReceiverOffset = IntPtr.Zero;
        }

        public static bool WarcraftCheck()
        {
            byte[] lpBuffer = new byte[1];
            IntPtr baseAddress = Warcraft3Info.BaseVersion.BaseAddress;
            if (baseAddress == IntPtr.Zero) return false;
            try
            {
                ReadProcessMemory(Warcraft3Info.Handle, baseAddress, lpBuffer, 1, out uint num);
            }
            catch
            {
                return false;
            }
            return lpBuffer[0] > 0;
        }

        public static WarcraftState WarcraftDetect()
        {
            if (Warcraft3Info.Process != null && !Warcraft3Info.Process.HasExited) return WarcraftState.OK;
            Process[] processesByName = Process.GetProcessesByName(TargetProcess = "Warcraft III");
            if (processesByName.Length == 0)
            {
                processesByName = Process.GetProcessesByName(TargetProcess = "war3");
                if (processesByName.Length == 0)
                {
                    ResetWarcraft3Info();
                    return WarcraftState.Closed;
                }
            }
            Warcraft3Info.Process = processesByName[0];
            if (Warcraft3Info.Process.Id != Warcraft3Info.ID)
            {
                CloseHandle(Warcraft3Info.Handle);
                Warcraft3Info.ID = processesByName[0].Id;
                Warcraft3Info.Handle = OpenProcess(0x38, false, (uint)Warcraft3Info.ID);
                if (Warcraft3Info.Handle == IntPtr.Zero)
                {
                    ResetWarcraft3Info();
                    return WarcraftState.Error;
                }
                if (!GetBase(Warcraft3Info.BaseVersion))
                {
                    Warcraft3Info.BaseVersion.BaseAddress = IntPtr.Zero;
                    Warcraft3Info.BaseVersion.Version = 0L;
                    return WarcraftState.Error;
                }
            }
            if (!(Warcraft3Info.BaseVersion.BaseAddress == IntPtr.Zero) && Warcraft3Info.BaseVersion.Version != 0L || GetBase(Warcraft3Info.BaseVersion))
                return WarcraftState.OK;
            ResetWarcraft3Info();
            return WarcraftState.Error;
        }


        public static WarcraftState SelectWarcraft(int id)
        {
            Process processesByName = Process.GetProcessById(id);
            Warcraft3Info.Process = processesByName;
            if (Warcraft3Info.Process.Id != Warcraft3Info.ID)
            {
                CloseHandle(Warcraft3Info.Handle);
                Warcraft3Info.ID = processesByName.Id;
                Warcraft3Info.Handle = OpenProcess(0x38, false, (uint)Warcraft3Info.ID);
                if (Warcraft3Info.Handle == IntPtr.Zero)
                {
                    ResetWarcraft3Info();
                    return WarcraftState.Error;
                }
                if (!GetBase(Warcraft3Info.BaseVersion))
                {
                    Warcraft3Info.BaseVersion.BaseAddress = IntPtr.Zero;
                    Warcraft3Info.BaseVersion.Version = 0L;
                    return WarcraftState.Error;
                }
            }
            if (!(Warcraft3Info.BaseVersion.BaseAddress == IntPtr.Zero) && Warcraft3Info.BaseVersion.Version != 0L || GetBase(Warcraft3Info.BaseVersion))
                return WarcraftState.OK;

            ResetWarcraft3Info();
            return WarcraftState.Error;
        }



    

    }
}
