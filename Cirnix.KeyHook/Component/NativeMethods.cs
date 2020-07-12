using System;
using System.Runtime.InteropServices;
using static Cirnix.KeyHook.Component;

namespace Cirnix.KeyHook
{
    internal static class NativeMethods
    {
        [DllImport("user32")]
        internal static extern IntPtr CallNextHookEx
        (
            IntPtr hhk,
            int nCode,
            int wParam,
            ref KBDLLHOOKSTRUCT lParam
        );

        [DllImport("user32", SetLastError = true)]
        internal static extern IntPtr SetWindowsHookEx
        (
            int idHook, 
            LowLevelKeyboardProc lpfn,
            IntPtr hMod,
            uint dwThreadId
        );

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetModuleHandle
        (
            string lpModuleName
        );

        [DllImport("user32", SetLastError = true)]
        internal static extern bool UnhookWindowsHookEx
        (
            IntPtr hhk
        );

        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool IsClipboardFormatAvailable
        (
            uint format
        );

        [DllImport("user32", SetLastError = true)]
        internal static extern IntPtr GetClipboardData
        (
            uint uFormat
        );

        [DllImport("user32", SetLastError = true)]
        internal static extern IntPtr SetClipboardData
        (
            uint uFormat,
            IntPtr hMem
        );

        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool OpenClipboard
        (
            IntPtr hWndNewOwner
        );

        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EmptyClipboard();

        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseClipboard();

        [DllImport("kernel32", SetLastError = true)]
        internal static extern IntPtr GlobalLock(IntPtr hMem);

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GlobalUnlock(IntPtr hMem);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern int GlobalSize(IntPtr hMem);

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("user32.dll")]
        internal static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
    }
}
