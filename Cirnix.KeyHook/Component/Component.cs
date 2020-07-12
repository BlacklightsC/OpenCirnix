using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Cirnix.KeyHook
{
    public static class Component
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/winmsg/lowlevelkeyboardproc
        /// </summary>
        internal delegate IntPtr LowLevelKeyboardProc
        (
            int nCode,
            int wParam,
            ref KBDLLHOOKSTRUCT lParam
        );

        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-kbdllhookstruct
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct KBDLLHOOKSTRUCT
        {
            internal Keys vkCode;
            internal int scanCode;
            internal KBDLLHOOKSTRUCTFlags flags;
            internal int time;
            internal IntPtr dwExtraInfo;
        }

        [Flags]
        internal enum KBDLLHOOKSTRUCTFlags : int
        {
            LLKHF_EXTENDED = 0x01,
            LLKHF_INJECTED = 0x10,
            LLKHF_ALTDOWN = 0x20,
            LLKHF_UP = 0x80,
        }
    }
}
