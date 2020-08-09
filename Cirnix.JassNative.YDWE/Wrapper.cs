using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

using Cirnix.JassNative.Plugin;
using Cirnix.JassNative.Runtime.Windows;

namespace Cirnix.JassNative.YDWE
{
    public class Wrapper : IPlugin
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void InitializePrototype();

        private List<IntPtr> plugins = new List<IntPtr>();

        private IntPtr LoadLibraryA(string path)
        {
            IntPtr BaseAddr = Kernel32.LoadLibrary(path);
            if (BaseAddr == IntPtr.Zero)
                Trace.WriteLine($"{path} Load Failed!");
            else
                Trace.WriteLine($"0x{BaseAddr.ToString("X8")} : {path} Loaded!");
            return BaseAddr;
        }

        public void Initialize()
        {
            string YDPath = $"{Environment.GetEnvironmentVariable("APPDATA")}\\Cirnix\\JNService\\YDWE";
            try
            {
                if (!Directory.Exists(YDPath))
                {
                    Trace.WriteLine("YD isn't exist, passed initialize");
                    return;
                }
                foreach (var item in File.ReadAllLines($"{YDPath}\\bin\\loadfiles.txt"))
                    LoadLibraryA($"{YDPath}\\bin\\{item}");
                foreach (var item in Directory.GetFiles($"{YDPath}\\plugin\\warcraft3"))
                {
                    IntPtr plugin = LoadLibraryA(item);
                    if (plugin != IntPtr.Zero)
                        plugins.Add(plugin);
                }
            }
            catch
            {
                Trace.WriteLine("Library Load Failed!");
            }
        }

        public void OnGameLoad()
        {
            try
            {
                Trace.Write("YDWE Engine Initializing . . . ");
                foreach (var plugin in plugins)
                {
                    IntPtr pInit = Kernel32.GetProcAddress(plugin, "Initialize");
                    if (pInit != IntPtr.Zero)
                        Marshal.GetDelegateForFunctionPointer<InitializePrototype>(pInit)();
                }
                plugins.Clear();
                Trace.WriteLine("Successed!");
            }
            catch
            {
                Trace.WriteLine("Initialize Failed!");
            }
        }

        public void OnMapStart() { }

        public void OnMapEnd() { }
    }
}
