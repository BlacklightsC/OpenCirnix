using System.Runtime.InteropServices;

namespace Cirnix.Forms
{
    internal static class NativeMethods
    {
        [DllImport("kernel32", CharSet = CharSet.Auto, ThrowOnUnmappableChar = true)]
        internal static extern bool WritePrivateProfileString
        (
            [In, MarshalAs(UnmanagedType.LPTStr, SizeConst = 260)]string Section,
            [In, MarshalAs(UnmanagedType.LPTStr, SizeConst = 260)]string Key,
            [In, MarshalAs(UnmanagedType.LPTStr, SizeConst = 260)]string Value,
            [In, MarshalAs(UnmanagedType.LPTStr, SizeConst = 260)]string FilePath
        );
        [DllImport("kernel32", CharSet = CharSet.Auto, ThrowOnUnmappableChar = true)]
        internal static extern int GetPrivateProfileInt
        (
            [In, MarshalAs(UnmanagedType.LPTStr, SizeConst = 260)]string lpAppName,
            [In, MarshalAs(UnmanagedType.LPTStr, SizeConst = 260)]string lpKeyName,
            [In]int nDefault,
            [In, MarshalAs(UnmanagedType.LPTStr, SizeConst = 260)]string lpFileName
        );
    }
}
