using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static Cirnix.Memory.NativeMethods;

namespace Cirnix.Memory
{

    public static class Component
    {
        public static WarcraftInfo Warcraft3Info;

        #region [    Custom Enum    ]
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

        public struct MEMORY_BASIC_INFORMATION
        {
            public IntPtr BaseAddress;
            public IntPtr AllocationBase;
            public MemProtect AllocationProtect;
            public IntPtr RegionSize;
            public MemState State;
            public MemProtect Protect;
            public MemType Type;
        }
        [Flags]
        public enum MemProtect : uint
        {
            PAGE_EXECUTE = 0x00000010,
            PAGE_EXECUTE_READ = 0x00000020,
            PAGE_EXECUTE_READWRITE = 0x00000040,
            PAGE_EXECUTE_WRITECOPY = 0x00000080,
            PAGE_NOACCESS = 0x00000001,
            PAGE_READONLY = 0x00000002,
            PAGE_READWRITE = 0x00000004,
            PAGE_WRITECOPY = 0x00000008,
            PAGE_GUARD = 0x00000100,
            PAGE_NOCACHE = 0x00000200,
            PAGE_WRITECOMBINE = 0x00000400
        }

        public enum MemState : uint
        {
            MEM_COMMIT = 0x1000,
            MEM_FREE = 0x10000,
            MEM_RESERVE = 0x2000
        }

        public enum MemType : uint
        {
            MEM_IMAGE = 0x1000000,
            MEM_MAPPED = 0x40000,
            MEM_PRIVATE = 0x20000
        }

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

        internal enum ChatMode : int
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

        public struct WarcraftInfo
        {
            public uint ID => (uint)(_Process?.Id ?? 0);
            public IntPtr BaseAddress => _Process?.MainModule.BaseAddress ?? IntPtr.Zero;
            public IntPtr Handle { get; private set; }
            private Process _Process;
            public Process Process {
                get => _Process;
                set {
                    if (value?.Id == _Process?.Id) return;
                    Reset();
                    if (value != null
                     && value.MainModule.FileVersionInfo.FileVersion == "1.28.5.7680"
                     && value.MainWindowHandle != IntPtr.Zero)
                    {
                        try
                        {
                            Handle = OpenProcess(0x38, false, (uint)value.Id);
                            if (Handle == IntPtr.Zero) return;

                            value.EnableRaisingEvents = true;
                            Action ResetAction = Reset;
                            value.Exited += (sender, e) => ResetAction();
                            _Process = value;
                        }
                        catch
                        {
                            if (Handle != IntPtr.Zero)
                            {
                                CloseHandle(Handle);
                                Handle = IntPtr.Zero;
                            }
                        }
                    }
                }
            }
            
            public bool HasExited {
                get {
                    if (_Process == null)
                        return true;
                    try
                    {
                        return _Process.HasExited;
                    }
                    catch
                    {
                        return true;
                    }
                }
            }

            public bool Close()
            {
                try
                {
                    _Process?.Kill();
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    Reset();
                }
            }

            public void Reset()
            {
                if (_Process != null)
                {
                    if (Handle != IntPtr.Zero)
                    {
                        CloseHandle(Handle);
                        Handle = IntPtr.Zero;
                    }
                    _Process.Close();
                    _Process = null;
                }

                ChannelChat.ChannelOffset =
                ChannelChat.MessageOffset =
                ControlDelay.Offset =
                GameDll.GameDllOffset =
                LoadedFiles.Offset =
                Message.CEditBoxOffset =
                Message.MessageOffset =
                Message.SelectedReceiverOffset =
                Message.TargetReceiverOffset =
                Join.Offset = IntPtr.Zero;
            }
        }

        internal static void Patch(IntPtr Offset, params byte[] buffer) => Patch(Offset, buffer.Length, buffer);

        internal static void Patch(IntPtr Offset, int size, params byte[] buffer)
        {
            VirtualProtectEx(Warcraft3Info.Handle, Offset, size, 0x40, out uint lpflOldProtect);
            WriteProcessMemory(Warcraft3Info.Handle, Offset, buffer, size, out _);
            VirtualProtectEx(Warcraft3Info.Handle, Offset, size, lpflOldProtect, out _);
        }
        internal static byte[] Bring(IntPtr Offset, int size)
        {
            byte[] lpBuffer = new byte[size];
            VirtualProtectEx(Warcraft3Info.Handle, Offset, size, 0x40, out uint lpflOldProtect);
            ReadProcessMemory(Warcraft3Info.Handle, Offset, lpBuffer, size, out _);
            VirtualProtectEx(Warcraft3Info.Handle, Offset, size, lpflOldProtect, out _);
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
        internal static IntPtr SearchAddress(byte[] search, uint maxAdd, int offset, uint interval = 0x10000)
        {
            byte[] lpBuffer = new byte[search.Length];
            for (uint num = 0x10000; num <= maxAdd; num += interval)
            {
                IntPtr lpBaseAddress = new IntPtr(num + offset);
                if (ReadProcessMemory(Warcraft3Info.Handle, lpBaseAddress, lpBuffer, search.Length, out int innerNum) && CompareArrays(search, lpBuffer, innerNum))
                    return lpBaseAddress;
            }
            return IntPtr.Zero;
        }

        internal static IntPtr SearchMemoryRegion(byte[] signature, int offset = 4, uint maxAdd = 0x70000000)
        {
            IntPtr lpBaseAddress = IntPtr.Zero;
            byte[] buffer = new byte[signature.Length];
            while (lpBaseAddress.ToInt32() < maxAdd)
            {
                VirtualQueryEx(Warcraft3Info.Handle, lpBaseAddress, out MEMORY_BASIC_INFORMATION info, Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));
                if (info.State == MemState.MEM_COMMIT && (uint)info.Protect < 0x100)
                {
                    IntPtr lpAddress = lpBaseAddress + offset;
                    if (ReadProcessMemory(Warcraft3Info.Handle, lpAddress, buffer, signature.Length, out _) && buffer.SequenceEqual(signature))
                        return lpAddress;                        
                }
                lpBaseAddress += info.RegionSize.ToInt32();
            }
            return IntPtr.Zero;
        }

        private static bool IsWindows10 = Environment.OSVersion.Version.Major == 10;
        internal static IntPtr SearchAddress(byte[] search, int offset = 4)
        {
            if (IsWindows10)
                return SearchMemoryRegion(search, offset);
            else
                return SearchAddress(search, 0x7FFFFFFF, offset);
        }

        private static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T stuff = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return stuff;
        }

        public static string GetCommandLine(uint processId)
        {
            IntPtr proc = OpenProcess(0x410, false, processId);
            if (proc == IntPtr.Zero) return null;
            try
            {
                PROCESS_BASIC_INFORMATION pbi = new PROCESS_BASIC_INFORMATION();
                if (NtQueryInformationProcess(proc, 0, ref pbi, pbi.Size, IntPtr.Zero) == 0)
                {
                    byte[] rupp = new byte[IntPtr.Size];
                    if (ReadProcessMemory(proc, (IntPtr)(pbi.PebBaseAddress.ToInt32() + 0x10), rupp, IntPtr.Size, out _))
                    {
                        int ruppPtr = BitConverter.ToInt32(rupp, 0);
                        byte[] cmdl = new byte[Marshal.SizeOf(typeof(UNICODE_STRING))];

                        if (ReadProcessMemory(proc, (IntPtr)(ruppPtr + 0x40), cmdl, Marshal.SizeOf(typeof(UNICODE_STRING)), out _))
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

        public static string[] GetArguments(uint processId)
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
    }
}
