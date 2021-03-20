using System;
using System.IO;
using System.Text;

using static Cirnix.Memory.Component;
using static Cirnix.Memory.NativeMethods;

namespace Cirnix.Memory
{

    public static class LoadedFiles
    {
        private static readonly byte[] SearchPattern = { 0x53, 0x8E, 0x3F, 0x7F, 0x53 };
        private static readonly byte[] FileLoadedPattern = { 0x68, 2, 4 };
        internal static IntPtr Offset = IntPtr.Zero;

        private static bool GetOffset()
        {
            if (StormDllOffset == IntPtr.Zero) return false;
            Offset = FollowPointer(StormDllOffset + 0x5817C, SearchPattern);
            if (Offset != IntPtr.Zero)
            {
                byte[] innerBuffer = new byte[4];
                if (ReadProcessMemory(Warcraft3Info.Handle, Offset += 0xA0, innerBuffer, 4, out _))
                    return true;
                Offset = IntPtr.Zero;
            }
            return false;
        }

        public static bool IsLoadedMap(out string MapPath)
        {
            MapPath = string.Empty;
            if (!GetOffset()) return false;
            MapPath = LoadedMap;
            return !string.IsNullOrEmpty(MapPath);
        }

        public static string LoadedMap
        {
            get
            {
                byte[] buffer = new byte[0x100];
                string FilePath;
                for (int i = 0; i < 0x1F64; i += 0x268)
                {
                    ReadProcessMemory(Warcraft3Info.Handle, Offset + i, buffer, 0x100, out _);
                    FilePath = Encoding.UTF8.GetString(buffer).Replace("\0", string.Empty);
                    string Extention;
                    try
                    {
                        Extention = System.IO.Path.GetExtension(FilePath).ToLower();
                    }
                    catch
                    {
                        continue;
                    }
                    if (Extention != ".w3x" && Extention != ".w3m") continue;
                    ReadProcessMemory(Warcraft3Info.Handle, Offset + i - 0x10, buffer, 3, out _);
                    if (!CompareArrays(FileLoadedPattern, buffer, 3)) continue;
                    return FilePath;
                }
                return string.Empty;
            }
        }
    }
}
