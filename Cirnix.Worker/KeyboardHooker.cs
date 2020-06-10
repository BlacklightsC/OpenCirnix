using System;
using Cirnix.Memory;
using System.Diagnostics;
using static Cirnix.Global.Globals;
using static Cirnix.Memory.CProcess;
using System.Runtime.InteropServices;
using static Cirnix.Worker.NativeMethods;

namespace Cirnix.Worker
{
    public static class KeyboardHooker
    {
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static bool WaitKeyInput = true;
        private static Stopwatch Timer = new Stopwatch();
        private static int Counter = 0;
        private const int
            WM_KEYDOWN = 0x100,
            WM_KEYUP = 0x101,
            WM_SYSKEYDOWN = 0x104,
            WM_SYSKEYUP = 0x105;

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && ForegroundWar3())
            {
                bool isChatBoxOpen = States.IsChatBoxOpen;
                if (Timer.ElapsedMilliseconds >= 50 || isChatBoxOpen)
                {
                    Counter = 0;
                    Timer.Reset();
                }
                if (wParam == (IntPtr)WM_KEYDOWN && Counter < 4)
                {
                    if (WaitKeyInput)
                    {
                        WaitKeyInput = false;
                        int vkCode = Marshal.ReadInt32(lParam);
                        if (!isChatBoxOpen)
                        {
                            var hotkey = hotkeyList.Find(item => (int)item.vk == vkCode);
                            if (hotkey != null && !(hotkey.onlyInGame && !States.IsInGame))
                            {
                                hotkey.function(hotkey.fk);
                                if (!hotkey.recall)
                                    return (IntPtr)1;
                            }
                        }
                        else if (Global.Settings.IsCommandHide)
                        {
                            try
                            {
                                if (States.IsInGame
                                 && vkCode == 0xD
                                 && Message.GetMessage()[0] == '!')
                                {
                                    System.Windows.Forms.SendKeys.Send("{ESC}");
                                    return (IntPtr)1;
                                }
                            }
                            catch { }
                        }
                    }
                }
                else if (wParam == (IntPtr)WM_KEYUP)
                {
                    WaitKeyInput = true;
                    Counter++;
                    Timer.Restart();
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        public static void HookStart()
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                _hookID = SetWindowsHookEx(0xD, _proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        public static void HookEnd()
        {
            UnhookWindowsHookEx(_hookID);
        }
    }
}
