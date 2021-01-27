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

        public static string LoadedMap {
            get {
                byte[] buffer = new byte[0x100];
                ReadProcessMemory(Warcraft3Info.Handle, Offset - 0x80, buffer, 4, out _);
                int count = BitConverter.ToInt32(buffer, 0);
                string FilePath;
                for (int i = 0, ofs = 0; i < count; i++, ofs += 0x268)
                {
                    ReadProcessMemory(Warcraft3Info.Handle, Offset + ofs, buffer, 0x100, out _);
                    string Extention;
                    try
                    {
                        FilePath = Encoding.UTF8.GetString(buffer).Replace("\0", string.Empty);
                        Extention = Path.GetExtension(FilePath).ToLower();
                    }
                    catch
                    {
                        continue;
                    }
                    if (Extention != ".w3x" && Extention != ".w3m") continue;
                    ReadProcessMemory(Warcraft3Info.Handle, Offset + ofs - 0x10, buffer, 3, out _);
                    if (buffer[0] == 0x68 && buffer[1] == 2 && buffer[2] == 4)
                        return FilePath;
                }
                return string.Empty;
            }
        }
    }
}
