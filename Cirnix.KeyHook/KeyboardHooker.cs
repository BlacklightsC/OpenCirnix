using Cirnix.Global;
using Cirnix.Memory;
using System;
using System.Diagnostics;
using static Cirnix.Global.Globals;
using static Cirnix.KeyHook.Component;
using static Cirnix.KeyHook.NativeMethods;
using static Cirnix.Memory.CProcess;

namespace Cirnix.KeyHook
{
    public static class KeyboardHooker
    {
        private static HookProc _proc = HookCallback;
        private static IntPtr _HookID = IntPtr.Zero;
        private static bool WaitKeyInput = true;
        private static Stopwatch Timer = new Stopwatch();
        private static int Counter = 0;
        private const int
            WM_KEYDOWN = 0x100,
            WM_KEYUP = 0x101,
            WM_SYSKEYDOWN = 0x104,
            WM_SYSKEYUP = 0x105;

        private static IntPtr HookCallback(int nCode, int wParam, ref KeyData lParam)
        {
            if (nCode >= 0 && ForegroundWar3())
            {
                bool isChatBoxOpen = States.IsChatBoxOpen;
                if (Timer.ElapsedMilliseconds >= 50 || isChatBoxOpen)
                {
                    Counter = 0;
                    Timer.Reset();
                }

                switch (wParam)
                {
                    case WM_KEYDOWN:
                    case WM_SYSKEYDOWN:
                        goto KEYDOWN;

                    case WM_KEYUP:
                    case WM_SYSKEYUP:
                        goto KEYUP;
                }

            KEYDOWN:
                if (Counter >= 4) goto KEYUP;
                if (WaitKeyInput)
                {
                    WaitKeyInput = false;
                    if (!isChatBoxOpen)
                    {
                        int vkCode = lParam.vkCode;
                        var hotkey = hotkeyList.Find(item => (int)item.vk == vkCode);
                        if (hotkey != null && !(hotkey.onlyInGame && !States.IsInGame))
                        {
                            hotkey.function(hotkey.fk);
                            if (!hotkey.recall)
                                return (IntPtr)1;
                        }
                    }
                    else if (Settings.IsCommandHide)
                    {
                        try
                        {
                            if (States.IsInGame
                             && lParam.vkCode == 0xD
                             && Message.GetMessage()[0] == '!')
                            {
                                System.Windows.Forms.SendKeys.Send("{ESC}");
                                return (IntPtr)1;
                            }
                        }
                        catch { }
                    }
                }
                else if (lParam.flags == 0x00)
                {
                    switch (lParam.vkCode)
                    {
                        case 0x58: // X
                        case 0x43: // C
                            ClipboardConverter.IsUTF8 = true;
                            break;
                    }
                }
                goto RETURN;
            KEYUP:
                WaitKeyInput = true;
                Counter++;
                Timer.Restart();
            }
        RETURN: return CallNextHookEx(_HookID, nCode, wParam, ref lParam);
        }

        public static void HookStart()
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
                _HookID = SetWindowsHookEx(0xD, _proc, GetModuleHandle(curModule.ModuleName), 0);
        }
        public static void HookEnd()
        {
            UnhookWindowsHookEx(_HookID);
        }
    }
}
