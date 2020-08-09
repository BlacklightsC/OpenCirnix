using System;
using System.Runtime.InteropServices;

using static Cirnix.Global.Component;
using static Cirnix.Memory.Component;

namespace Cirnix.Memory
{
    internal static class NativeMethods
    {
        [DllImport("psapi", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EmptyWorkingSet
        (
            [In]IntPtr hWnd
        );

        [DllImport("user32")]
        internal static extern IntPtr GetForegroundWindow();

        [DllImport("user32", SetLastError = true)]
        internal static extern IntPtr GetWindowRect
        (
            [In]IntPtr hWnd, 
            [Out]out RECT rect
        );

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ReadProcessMemory
        (
            [In]IntPtr hProcess,
            [In]IntPtr lpBaseAddress,
            [Out]byte[] lpBuffer,
            [In]int dwSize,
            [Out]out int lpNumberOfBytesRead
        );

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool VirtualProtectEx
        (
            [In]IntPtr hProcess,
            [In]IntPtr lpAddress,
            [In]int dwSize,
            [In]uint flNewProtect, 
            [Out]out uint lpflOldProtect
        );

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool WriteProcessMemory
        (
            [In]IntPtr hProcess,
            [In]IntPtr lpBaseAddress,
            [In]byte[] lpBuffer,
            [In]int nSize,
            [Out]out int lpNumberOfBytesWritten
        );

        [DllImport("kernel32", SetLastError = true)]
        internal static extern IntPtr OpenProcess
        (
            [In]uint dwDesiredAccess,
            [In, MarshalAs(UnmanagedType.Bool)]bool bInheritHandle,
            [In]uint dwProcessId
        );

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseHandle
        (
            [In]IntPtr hObject
        );

        [DllImport("ntdll.dll")]
        internal static extern int NtQueryInformationProcess
        (
            IntPtr processHandle,
            int processInformationClass,
            ref PROCESS_BASIC_INFORMATION ProcessInformation,
            uint processInformationLength,
            IntPtr returnLength
        );

        [DllImport("shell32.dll", SetLastError = true)]
        internal static extern IntPtr CommandLineToArgvW
        (
            [MarshalAs(UnmanagedType.LPWStr)]string lpCmdLine,
            out int pNumArgs
        );

        [DllImport("kernel32.dll")]
        internal static extern IntPtr LocalFree
        (
            IntPtr hMem
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int VirtualQueryEx
        (
            IntPtr hProcess,
            IntPtr lpAddress,
            out MEMORY_BASIC_INFORMATION lpBuffer,
            int dwLength
        );
    }
}
