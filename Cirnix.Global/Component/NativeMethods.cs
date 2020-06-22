using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using static Cirnix.Global.Component;

namespace Cirnix.Global
{
    public static class NativeMethods
    {
        [DllImport("user32")]
        public static extern void mouse_event
        (
            [In]uint dwFlags,
            [In]uint dx,
            [In]uint dy,
            [In]uint dwData,
            [In]uint dwExtraInfo
        );
        [DllImport("user32")]
        public static extern void keybd_event
        (
            [In]byte bVk,
            [In]byte bScan,
            [In]uint dwFlags,
            [In]uint dwExtraInfo
        );

        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostMessage
        (
            [In]IntPtr hWnd,
            [In]uint Msg,
            [In]uint wParam,
            [In]uint lParam
        );

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32")]
        public static extern int GetCursorPos
        (
            [Out]out POINT point
        );

        [DllImport("user32")]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32")]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        public static extern int GetLastError();
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        public static extern int FormatMessage(int dwFlags, IntPtr lpSource, int dwMessageId, int dwLanguageId, out string lpBuffer, int dwSize, IntPtr lpArguments);
    }
}
