using System;
using System.Runtime.InteropServices;

namespace Cirnix.KeyHook
{
    internal static class NativeMethods
    {
        [DllImport("user32")]
        internal static extern IntPtr CallNextHookEx
        (
            [In]IntPtr hhk,
            [In]int nCode,
            [In]IntPtr wParam,
            [In]IntPtr lParam
        );
        [DllImport("user32", SetLastError = true)]
        internal static extern IntPtr SetWindowsHookEx
        (
            [In]int idHook, 
            [In]HookProc lpfn,
            [In]IntPtr hMod,
            [In]uint dwThreadId
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

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr LoadLibrary
        (
            [MarshalAs(UnmanagedType.LPStr)]string lpFileName
        );

        internal delegate IntPtr HookProc
        (
            int nCode, 
            IntPtr wParam, 
            IntPtr lParam
        );
    }
}
