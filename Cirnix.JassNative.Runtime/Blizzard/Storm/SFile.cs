using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.Runtime.Blizzard.Storm
{
    public unsafe class SFile
    {
        [DllImport("storm.dll", EntryPoint = "#253")]
        public static extern bool CloseFile(IntPtr handle);

        [DllImport("storm.dll", EntryPoint = "#265")]
        public static extern int GetFileSize(IntPtr handle, out int fileSizeHigh);

        [DllImport("storm.dll", EntryPoint = "#268")]
        public static extern bool OpenFileEx(IntPtr handle, string filename, uint mode, out IntPtr result);

        [DllImport("storm.dll", EntryPoint = "#269")]
        public static extern int ReadFile(IntPtr handle, IntPtr buffer, int numberOfBytesToRead, out int numberOfBytesRead, int distanceToMoveHigh = 0);

        [DllImport("storm.dll", EntryPoint = "#269")]
        public static extern int SetFilePointer(IntPtr handle, int filePosition, out int filePositionHigh, uint moveMethod);

        public static int GetFileSize(IntPtr handle)
        {
            return GetFileSize(handle, out int high);
        }

        public static long GetFileSizeLong(IntPtr handle)
        {
            int low = GetFileSize(handle, out int high);
            return unchecked((long)high << 32 | (uint)low);
        }

        public static IntPtr OpenFileEx(IntPtr handle, string filename, uint mode)
        {
            if (OpenFileEx(handle, filename, mode, out IntPtr result))
                return result;
            return IntPtr.Zero;
        }

        public static int ReadFile(IntPtr handle, byte[] buffer, int numberOfBytesToRead, out int numberOfBytesRead, int distanceToMoveHigh = 0)
        {
            fixed (byte* pBuffer = buffer)
                return ReadFile(handle, new IntPtr(pBuffer), numberOfBytesToRead, out numberOfBytesRead);
        }

        public static byte[] ReadFileToEnd(IntPtr handle)
        {
            int size = GetFileSize(handle);
            var buffer = Marshal.AllocHGlobal(size);
            ReadFile(handle, buffer, size, out int read);
            var output = new byte[size];
            Marshal.Copy(buffer, output, 0, size);
            Marshal.FreeHGlobal(buffer);
            return output;
        }

        public static int SetFilePointer(IntPtr handle, int filePosition, out int filePositionHigh, SeekOrigin moveMethod)
        {
            return SetFilePointer(handle, filePosition, out filePositionHigh, (uint)moveMethod);
        }

        public static int SetFilePointer(IntPtr handle, int filePosition, uint moveMethod)
        {
            return SetFilePointer(handle, filePosition, out int filePositionHigh, moveMethod);
        }

        public static int SetFilePointer(IntPtr handle, int filePosition, SeekOrigin moveMethod)
        {
            return SetFilePointer(handle, filePosition, (uint)moveMethod);
        }

        public static long SetFilePointerLong(IntPtr handle, long filePosition, uint moveMethod)
        {
            int high = (int)(filePosition >> 32);
            int low = (int)(filePosition & uint.MaxValue);

            low = SetFilePointer(handle, low, out high, moveMethod);

            return unchecked((long)high << 32 | (uint)low);
        }

        public static long SetFilePointerLong(IntPtr handle, long filePosition, SeekOrigin moveMethod)
        {
            return SetFilePointerLong(handle, filePosition, (uint)moveMethod);
        }

        private SFile() { }
    }
}
