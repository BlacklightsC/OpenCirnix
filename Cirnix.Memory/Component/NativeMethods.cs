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
            [In]uint dwSize,
            [Out]out uint lpNumberOfBytesRead
        );

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool VirtualProtectEx
        (
            [In]IntPtr hProcess,
            [In]IntPtr lpAddress,
            [In]uint dwSize,
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
            [In]uint nSize,
            [Out]out uint lpNumberOfBytesWritten
        );

        [DllImport("kernel32", SetLastError = true)]
        internal static extern IntPtr CreateToolhelp32Snapshot
        (
            [In]SnapshotFlags dwFlags,
            [In]uint th32ProcessID
        );

        [DllImport("kernel32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool Module32First
        (
            [In]IntPtr hSnapshot,
            [In, Out]ref MODULEENTRY32 lpme
        );

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool Module32Next
        (
            [In]IntPtr hSnapshot,
            [In, Out]ref MODULEENTRY32 lpme
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

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct PROCESS_BASIC_INFORMATION
        {
            internal int ExitProcess;
            internal IntPtr PebBaseAddress;
            internal UIntPtr AffinityMask;
            internal int BasePriority;
            internal UIntPtr UniqueProcessId;
            internal UIntPtr InheritedFromUniqueProcessId;

            internal uint Size => (uint)Marshal.SizeOf(typeof(PROCESS_BASIC_INFORMATION));
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct UNICODE_STRING
        {
            internal ushort Length;
            internal ushort MaximumLength;
            internal IntPtr buffer;
        }

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
    }
}
