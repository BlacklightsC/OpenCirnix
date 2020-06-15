using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.Runtime.Windows
{
    public class ProcessMemory
    {
        public static ProcessMemory FromProcess(Process process)
        {
            return new ProcessMemory(process);
        }

        private IntPtr buffer { get; set; }

        public Process Process { get; private set; }

        public IntPtr ProcessHandle { get; private set; }

        private ProcessMemory(Process process)
        {
            Process = process;

            ProcessHandle = Kernel32.OpenProcess(PROCESS.ALL_ACCESS, 0, (IntPtr)Process.Id);
            if (ProcessHandle == IntPtr.Zero)
            {
                AdvancedServices.GetSecurityInfo(Process.GetCurrentProcess().Handle, /*SE_KERNEL_OBJECT*/ 6, /*DACL_SECURITY_INFORMATION*/ 4, 0, 0, out IntPtr pDACL, IntPtr.Zero, out _);
                ProcessHandle = Kernel32.OpenProcess(/*WRITE_DAC*/ (PROCESS)0x40000, 0, (IntPtr)Process.Id);
                AdvancedServices.SetSecurityInfo(ProcessHandle, /*SE_KERNEL_OBJECT*/ 6, /*DACL_SECURITY_INFORMATION*/ 4 | /*UNPROTECTED_DACL_SECURITY_INFORMATION*/ 0x20000000, 0, 0, pDACL, IntPtr.Zero);
                Kernel32.CloseHandle(ProcessHandle);

                ProcessHandle = Kernel32.OpenProcess(PROCESS.ALL_ACCESS, 0, (IntPtr)Process.Id);
            }
            if (ProcessHandle == IntPtr.Zero)
                throw new InvalidOperationException("Failed to open up process");

            buffer = Marshal.AllocHGlobal(8192);
        }

        public T Read<T>(IntPtr address) where T : struct
        {
            Kernel32.ReadProcessMemory(ProcessHandle, address, buffer, Marshal.SizeOf(typeof(T)));
            return (T)Marshal.PtrToStructure(buffer, typeof(T));
        }

        public void Write<T>(IntPtr address, T data) where T : struct
        {
            Marshal.StructureToPtr(data, buffer, true);
            Kernel32.WriteProcessMemory(ProcessHandle, address, buffer, Marshal.SizeOf(typeof(T)));
        }
    }
}
