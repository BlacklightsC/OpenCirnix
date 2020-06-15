using Cirnix.JassNative.Runtime.Windows;
using EasyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Cirnix.JassNative.Runtime.Utilities
{
    public static class Memory
    {
        private static List<LocalHook> hooks = new List<LocalHook>();

        public static T Read<T>(IntPtr address) where T : struct
        {
            return (T)Marshal.PtrToStructure(address, typeof(T));
        }

        public static T Read<T>(IntPtr address, int offset) where T : struct
        {
            return (T)Marshal.PtrToStructure(address + offset, typeof(T));
        }

        public static string ReadString(IntPtr address)
        {
            int len = 0;
            while (Marshal.ReadByte(address, len) != 0) ++len;
            byte[] buffer = new byte[len];
            Marshal.Copy(address, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        public static string ReadString(IntPtr address, int length)
        {
            int len = 0;
            while (Marshal.ReadByte(address, len) != 0 && len != length) ++len;
            byte[] buffer = new byte[len];
            Marshal.Copy(address, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        public static void Write<T>(IntPtr address, T data) where T : struct
        {
            Marshal.StructureToPtr(data, address, true);
        }

        public static void Write<T>(IntPtr address, int offset, T data) where T : struct
        {
            Marshal.StructureToPtr(data, address + offset, true);
        }

        public static void WriteString(IntPtr address, string data)
        {
            Marshal.Copy(Encoding.UTF8.GetBytes(data), 0, address, Encoding.UTF8.GetByteCount(data));
            Marshal.WriteByte(address + Encoding.UTF8.GetByteCount(data), 0x00); // null terminate
        }

        public static T InstallHook<T>(IntPtr address, T newFunc, bool inclusive, bool exclusive) where T : class
        {
            if (!typeof(Delegate).IsAssignableFrom(typeof(T)))
                throw new InvalidOperationException("Generic T is not a delegate type");

            Delegate oldFunc = Marshal.GetDelegateForFunctionPointer(address, typeof(T));

            Trace.Write($"{(newFunc as Delegate).Method.Name}: 0x{(int)address:X8} . ");
            LocalHook hook = LocalHook.Create(address, newFunc as Delegate, null);
            Trace.WriteLine("hook installed!");
            if (inclusive) hook.ThreadACL.SetInclusiveACL(new[] { 0 });
            if (exclusive) hook.ThreadACL.SetExclusiveACL(new[] { 0 });

            // Unreferences hooks gets cleaned up, so we prevent that by keeping them referenced.
            hooks.Add(hook);

            return (T)(object)oldFunc;
        }

        public static string PtrAsString(IntPtr address)
        {
            return ReadString(address);
        }

        public static IntPtr StringAsPtr(string data)
        {
            byte[] buffer = new byte[Encoding.UTF8.GetByteCount(data) + 1];
            Encoding.UTF8.GetBytes(data, 0, data.Length, buffer, 0);
            IntPtr address = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, address, buffer.Length);
            return address;
        }

        public static IntPtr Alloc(int size)
        {
            return Alloc(size, MemoryProtection.ReadWrite);
        }

        public static IntPtr Alloc(int size, MemoryProtection protection)
        {
            return Alloc(size, protection, AllocationType.Commit);
        }

        public static IntPtr Alloc(int size, MemoryProtection protection, AllocationType allocationType)
        {
            return Alloc(IntPtr.Zero, size, protection, allocationType);
        }

        public static IntPtr Alloc(IntPtr address, int size)
        {
            return Alloc(address, size, MemoryProtection.ReadWrite);
        }

        public static IntPtr Alloc(IntPtr address, int size, MemoryProtection protection)
        {
            return Alloc(address, size, protection, AllocationType.Commit);
        }

        public static IntPtr Alloc(IntPtr address, int size, MemoryProtection protection, AllocationType allocationType)
        {
            return Kernel32.VirtualAlloc(address, size, allocationType, protection);
        }

        public static void Free(IntPtr address)
        {
            Kernel32.VirtualFree(address, 0, MemoryFreeType.Release);
        }

        public static void Copy(IntPtr source, IntPtr destination, int size)
        {
            Kernel32.CopyMemory(destination, source, size);
        }
    }
}
