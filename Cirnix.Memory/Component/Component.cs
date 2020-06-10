using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using static Cirnix.Memory.NativeMethods;

namespace Cirnix.Memory
{
    
    public static class Component
    {
        public static WarcraftInfo Warcraft3Info;

        #region [    Custom Enum    ]
        [StructLayout(LayoutKind.Sequential)]
        internal struct MODULEENTRY32
        {
            public uint dwSize;
            public uint th32ModuleID;
            public uint th32ProcessID;
            public uint GlblcntUsage;
            public uint ProccntUsage;
            public IntPtr modBaseAddr;
            public uint modBaseSize;
            public IntPtr hModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExePath;
        }
        [Flags]
        internal enum SnapshotFlags : uint
        {
            All = TH32CS_SNAPHEAPLIST | TH32CS_SNAPMODULE | TH32CS_SNAPPROCESS | TH32CS_SNAPTHREAD,
            TH32CS_SNAPHEAPLIST = 0x00000001,
            TH32CS_SNAPPROCESS = 0x00000002,
            TH32CS_SNAPTHREAD = 0x00000004,
            TH32CS_SNAPMODULE = 0x00000008,
            TH32CS_SNAPMODULE32 = 0x00000010,
            TH32CS_INHERIT = 0x80000000
        }
        public enum WarcraftState : byte
        {
            None = 0,
            Closed = 1,
            Error = 3,
            OK = 2
        }
        internal enum ChatMode : byte
        {
            Private = 0,
            Team = 1,
            Spectator = 2,
            All = 3
        }
        public enum MusicState : byte
        {
            None = 0,
            Offline = 1,
            BattleNet = 2,
            InGameDefault = 3,
            InGameCustom = 4,
            Stopped = 5
        }
        public enum HackState : byte
        {
            Off = 0,
            Semi = 1,
            Share = 2,
            Full = 3
        }
        #endregion

        [StructLayout(LayoutKind.Sequential)]
        public struct BaseVersion
        {
            public IntPtr BaseAddress { get; set; }
            public long Version { get; set; }
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct WarcraftInfo
        {
            public int ID;
            public BaseVersion BaseVersion;
            public IntPtr Handle;
            public System.Diagnostics.Process Process;
        }

        internal static void Patch(IntPtr Offset, params byte[] buffer)
        {
            VirtualProtectEx(Warcraft3Info.Handle, Offset, (uint)buffer.Length, 0x40, out uint lpflOldProtect);
            WriteProcessMemory(Warcraft3Info.Handle, Offset, buffer, (uint)buffer.Length, out uint _);
            VirtualProtectEx(Warcraft3Info.Handle, Offset, (uint)buffer.Length, lpflOldProtect, out uint _);
        }
        internal static byte[] Bring(IntPtr Offset, uint size)
        {
            byte[] lpBuffer = new byte[size];
            VirtualProtectEx(Warcraft3Info.Handle, Offset, size, 0x40, out uint lpflOldProtect);
            ReadProcessMemory(Warcraft3Info.Handle, Offset, lpBuffer, size, out uint _);
            VirtualProtectEx(Warcraft3Info.Handle, Offset, size, lpflOldProtect, out uint _);
            return lpBuffer;
        }
        internal static bool CompareArrays(byte[] a, byte[] b, int num)
        {
            for (int i = 0; i < num; i++)
                try
                {
                    if (a[i] != b[i])
                        return false;
                }
                catch
                {
                    return false;
                }
            return true;
        }
        internal static IntPtr SearchAddress(byte[] search, uint maxAdd, uint offset, uint interval = 0x10000)
        {
            byte[] lpBuffer = new byte[search.Length];
            for (uint num = 0x10000; num <= maxAdd; num += interval)
            {
                IntPtr lpBaseAddress = new IntPtr(num + offset);
                if (ReadProcessMemory(Warcraft3Info.Handle, lpBaseAddress, lpBuffer, (uint)search.Length, out uint innerNum) && CompareArrays(search, lpBuffer, (int)innerNum))
                    return lpBaseAddress;
            }
            return IntPtr.Zero;
        }

        private static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T stuff = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return stuff;
        }

        public static string GetCommandLine(int processId)
        {
            IntPtr proc = OpenProcess(0x410, false, (uint)processId);
            if (proc == IntPtr.Zero) return null;
            try
            {
                PROCESS_BASIC_INFORMATION pbi = new PROCESS_BASIC_INFORMATION();
                if (NtQueryInformationProcess(proc, 0, ref pbi, pbi.Size, IntPtr.Zero) == 0)
                {
                    byte[] rupp = new byte[IntPtr.Size];
                    if (ReadProcessMemory(proc, (IntPtr)(pbi.PebBaseAddress.ToInt32() + 0x10), rupp, (uint)IntPtr.Size, out _))
                    {
                        int ruppPtr = BitConverter.ToInt32(rupp, 0);
                        byte[] cmdl = new byte[Marshal.SizeOf(typeof(UNICODE_STRING))];

                        if (ReadProcessMemory(proc, (IntPtr)(ruppPtr + 0x40), cmdl, (uint)Marshal.SizeOf(typeof(UNICODE_STRING)), out _))
                        {
                            UNICODE_STRING ucsData = ByteArrayToStructure<UNICODE_STRING>(cmdl);
                            byte[] parms = new byte[ucsData.Length];
                            if (ReadProcessMemory(proc, ucsData.buffer, parms, ucsData.Length, out _))
                                return Encoding.Unicode.GetString(parms);
                        }
                    }
                }
            }
            finally
            {
                CloseHandle(proc);
            }
            return null;
        }

        public static string[] GetArguments(int processId)
        {
            string CommandLine = GetCommandLine(processId);
            if (CommandLine == null) return null;
            List<string> args = new List<string>(SplitArgs(CommandLine));
            args.RemoveAt(0);
            return args.ToArray();
        }

        private static string[] SplitArgs(string unsplitArgumentLine)
        {
            IntPtr ptrToSplitArgs = CommandLineToArgvW(unsplitArgumentLine, out int numberOfArgs);

            if (ptrToSplitArgs == IntPtr.Zero) throw new ArgumentException("Unable to split argument.", new Win32Exception());

            try
            {
                string[] splitArgs = new string[numberOfArgs];
                for (int i = 0; i < numberOfArgs; i++)
                    splitArgs[i] = Marshal.PtrToStringUni(Marshal.ReadIntPtr(ptrToSplitArgs, i * IntPtr.Size));

                return splitArgs;
            }
            finally
            {
                LocalFree(ptrToSplitArgs);
            }
        }


        //internal static IntPtr SearchAddress(string array, uint maxAdd, uint offset, uint interval = 0x10000)
        //{
        //    byte[] lpBuffer = new byte[search.Length];
        //    array = array.Replace(" ", string.Empty);
        //    if (array.Length % 2 == 1) return IntPtr.Zero;
        //    byte?[] a = new byte?[array.Length / 2];
        //    for (int i = 0; i < array.Length; i += 2)
        //    {
        //        string part = array.Substring(i, 2);
        //        if (part.IndexOf('.') != -1) a[i / 2] = null;
        //        else a[i / 2] = Convert.ToByte(part, 16);
        //    }
        //    for (uint num = 0x10000; num <= maxAdd; num += interval)
        //    {
        //        IntPtr lpBaseAddress = new IntPtr(num + offset);
        //        if (ReadProcessMemory(Warcraft3Info.Handle, lpBaseAddress, lpBuffer, (uint)search.Length, out uint innerNum) && CompareArrays(search, lpBuffer, (int)innerNum))
        //            return lpBaseAddress;
        //    }
        //    return IntPtr.Zero;
        //}
    }
}
