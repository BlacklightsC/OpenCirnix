using System;
using System.Diagnostics;
using System.Windows.Forms;

using Cirnix.Global;
using Cirnix.Memory;

using static Cirnix.Global.Globals;
using static Cirnix.KeyHook.Component;
using static Cirnix.KeyHook.NativeMethods;
using static Cirnix.Memory.CProcess;

namespace Cirnix.KeyHook
{
    public static class KeyboardHooker
    {
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _HookID = IntPtr.Zero;
        private static Stopwatch Timer = Stopwatch.StartNew();
        private static Keys LastDownKey;
        private static bool IsControlKeyDown = false;
        private const int
            WM_KEYDOWN = 0x100,
            WM_KEYUP = 0x101,
            WM_SYSKEYDOWN = 0x104,
            WM_SYSKEYUP = 0x105;

        private static IntPtr HookCallback(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam)
        {
            if (nCode >= 0 && ForegroundWar3())
            {
                bool isChatBoxOpen = States.IsChatBoxOpen;

                switch (wParam)
                {
                    case WM_KEYDOWN:
                        goto KEYDOWN;

                    case WM_KEYUP:
                        goto KEYUP;

                    case WM_SYSKEYDOWN:
                    case WM_SYSKEYUP:
                        goto RETURN;
                }

            KEYDOWN:
                if (lParam.vkCode == Keys.LControlKey) IsControlKeyDown = true;
                if (isChatBoxOpen)
                {
                    if (IsControlKeyDown)
                    {
                        switch (lParam.vkCode)
                        {
                            case Keys.X: // X
                            case Keys.C: // C
                                ClipboardConverter.IsUTF8 = true;
                                break;
                        }
                    }
                    if (Settings.IsCommandHide)
                        try
                        {
                            if (lParam.vkCode == Keys.Enter)
                            {
                                string msg = Memory.Message.GetMessage();
                                if (msg != null && msg.Length >= 0 && msg[0] == '!')
                                    Memory.Message.SetEmpty();
                            }
                        }
                        catch { }
                    goto RETURN;
                }
                else
                {
                    Keys vkCode = lParam.vkCode;
                    var hotkey = hotkeyList.Find(item => item.vk == vkCode);
                    if (hotkey != null && !(hotkey.onlyInGame && !States.IsInGame))
                    {
                        if (Timer.ElapsedMilliseconds >= 65 || vkCode != LastDownKey)
                        {
                            Timer.Restart();
                            LastDownKey = vkCode;
                            hotkey.function(hotkey.fk);
                            if (!hotkey.recall)
                                return (IntPtr)1;
                        }
                    }
                    goto RETURN;
                }
                //else goto KEYUP;
            KEYUP:
                if (lParam.vkCode == Keys.LControlKey) IsControlKeyDown = false;
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
