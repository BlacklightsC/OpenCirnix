using System;
using System.Runtime.InteropServices;
using System.Text;
using static Cirnix.Global.Globals;
using static Cirnix.KeyHook.NativeMethods;

namespace Cirnix.KeyHook
{
    public static class ClipboardConverter
    {
        private static bool _IsUTF8 = false;
        public static bool IsUTF8 {
            get => _IsUTF8;
            set {
                if (Global.Settings.IsFixClipboard)
                    _IsUTF8 = true;
            }
        }
        public static bool IsBusy = false;
        public static IntPtr ChainedWnd;
        private const uint CF_TEXT = 1;

        public static string GetUTF8Text()
        {
            if (!IsClipboardFormatAvailable(CF_TEXT)
             || !OpenClipboard(IntPtr.Zero))
                return null;

            string ret = null;
            IntPtr hGlob = GetClipboardData(CF_TEXT);
            if (hGlob != IntPtr.Zero)
            {
                IntPtr lptstr = GlobalLock(hGlob);
                if (lptstr != IntPtr.Zero)
                {
                    int size = GlobalSize(hGlob) - 1;
                    byte[] buffer = new byte[size];
                    Marshal.Copy(lptstr, buffer, 0, size);
                    ret = Encoding.UTF8.GetString(buffer);
                    GlobalUnlock(hGlob);
                }
            }
            CloseClipboard();
            return ret;
        }

        public static void SetUTF8Text(string text)
        {
            if (!OpenClipboard(IntPtr.Zero)) return;
            int length = Encoding.UTF8.GetByteCount(text) + 1;
            if (length >= 0x80) length = 0x7F;
            byte[] buffer = new byte[Encoding.UTF8.GetByteCount(text) + 1];
            Encoding.UTF8.GetBytes(text, 0, text.Length, buffer, 0);
            IntPtr hGlob = Marshal.AllocHGlobal(length + 1);
            Marshal.Copy(buffer, 0, hGlob, length);
            if (SetClipboardData(CF_TEXT, hGlob) == IntPtr.Zero)
            {
                CloseClipboard();
                Marshal.FreeHGlobal(hGlob);
                return;
            }
            CloseClipboard();
        }

        public static void FixStart()
        {
            ChainedWnd = SetClipboardViewer(GlobalHandle);
        }
        public static void FixEnd()
        {
            ChangeClipboardChain(GlobalHandle, ChainedWnd);
        }
    }
}