using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Cirnix.JassNative.Runtime.Windows
{
    public delegate int ProcessMessagesDelegate(int code, int wParam, ref Message lParam);

    public static class User32
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(WindowsHookId windowsHookId, ProcessMessagesDelegate function, IntPtr mod, int threadId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int UnhookWindowsHookEx(IntPtr hook);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int CallNextHookEx(IntPtr hook, int code, int wParam, ref Message lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool TranslateMessage(ref Message message);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);
    }
}
