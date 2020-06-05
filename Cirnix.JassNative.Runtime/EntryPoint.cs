using Cirnix.JassNative.Runtime.Utilities;
using Cirnix.JassNative.Runtime.Windows;

using EasyHook;

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;

namespace Cirnix.JassNative.Runtime
{
    unsafe public class EntryPoint : IEntryPoint
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr Unknown__SetStateDelegate(IntPtr @this, Boolean endMap, Boolean endEngine);

        private Unknown__SetStateDelegate Unknown__SetState;

        private Kernel32.LoadLibraryAPrototype LoadLibraryA;

        private String pluginsFolder;

        public Boolean IsInGame;

        public Boolean IsInMap;

        public EntryPoint(RemoteHooking.IContext hookingContext, Boolean isDebugging, String hackPath, String installPath)
        {
            try
            {
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "Fatal exception!" + Environment.NewLine +
                    exception + Environment.NewLine +
                    "Aborting execution!",
                    this.GetType() + ".ctor(...)", MessageBoxButton.OK, MessageBoxImage.Error);
                Process.GetCurrentProcess().Kill();
            }
        }

        public void Run(RemoteHooking.IContext hookingContext, Boolean isDebugging, String hackPath, String installPath)
        {
            try
            {
                if (isDebugging)
                {
                    DebuggerApplication.Start(hackPath);
                    while (!DebuggerApplication.IsReady)
                        Thread.Sleep(1); // Sleep(0) is a nono.
                }
                Trace.IndentSize = 2;

                // We autoflush our trace, so we get everything immediately. This 
                // makes tracing a bit more expensive, but means we still get a log
                // even if there's a fatal crash.
                Trace.AutoFlush = true;

                // Everything traced will be written to "debug.log".
                Trace.Listeners.Add(new TextWriterTraceListener(Path.Combine(hackPath, "debug.log")));

                Trace.WriteLine("-------------------");
                Trace.WriteLine(DateTime.Now);
                Trace.WriteLine("-------------------");


                AppDomain.CurrentDomain.AssemblyResolve += (Object sender, ResolveEventArgs args) =>
                {
                    var path = String.Empty;
                    // extract the file name
                    var file = String.Empty;
                    if (args.Name.IndexOf(',') >= 0)
                        file = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";
                    else if (args.Name.IndexOf(".dll") >= 0)
                        file = Path.GetFileName(args.Name);
                    else
                        return null;

                    // locate the actual file
                    path = Directory.GetFiles(hackPath, file, SearchOption.AllDirectories).FirstOrDefault();
                    if (!String.IsNullOrEmpty(path))
                        return Assembly.LoadFrom(path);

                    path = Directory.GetFiles(pluginsFolder, file, SearchOption.AllDirectories).FirstOrDefault();
                    if (!String.IsNullOrEmpty(path))
                        return Assembly.LoadFrom(path);

                    return null;
                };

                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += (Object sender, ResolveEventArgs args) =>
                {
                    var path = String.Empty;
                    // extract the file name
                    var file = String.Empty;
                    if (args.Name.IndexOf(',') >= 0)
                        file = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";
                    else if (args.Name.IndexOf(".dll") >= 0)
                        file = Path.GetFileName(args.Name);
                    else
                        return null;

                    // locate the actual file
                    path = Directory.GetFiles(hackPath, file, SearchOption.AllDirectories).FirstOrDefault();
                    if (!String.IsNullOrEmpty(path))
                        return Assembly.ReflectionOnlyLoadFrom(path);

                    path = Directory.GetFiles(pluginsFolder, file, SearchOption.AllDirectories).FirstOrDefault();
                    if (!String.IsNullOrEmpty(path))
                        return Assembly.ReflectionOnlyLoadFrom(path);

                    return null;
                };

                var sw = new Stopwatch();

                Trace.WriteLine("Preparing folders . . . ");
                Trace.Indent();
                sw.Restart();
                pluginsFolder = Path.Combine(hackPath, "plugins");
                if (!Directory.Exists(pluginsFolder))
                    Directory.CreateDirectory(pluginsFolder);
                sw.Stop();
                Trace.WriteLine("Install Path: " + installPath);
                Trace.WriteLine("Hack Path:    " + hackPath);
                if (installPath.Equals(hackPath, StringComparison.OrdinalIgnoreCase))
                    Trace.WriteLine("WARNING: Install Path and Hack Path are the same. This is not supported.");
                if (File.Exists(Path.Combine(installPath, "Launcher.exe")))
                    Trace.WriteLine("WARNING: Launcher.exe detected in the Warcraft III folder. This is not supported.");
                if (File.Exists(Path.Combine(installPath, "Cirnix.JassNative.Runtime.dll")))
                    Trace.WriteLine("WARNING: Cirnix.JassNative.Runtime.dll detected in the Warcraft III folder. This is not supported.");
                Trace.WriteLine("Done! (" + sw.Elapsed.TotalMilliseconds.ToString("0.00") + " ms)");
                Trace.Unindent();

                Trace.WriteLine("Loading plugins from '" + pluginsFolder + "' . . .");
                Trace.Indent();
                sw.Restart();
                PluginSystem.LoadPlugins(pluginsFolder);
                sw.Stop();
                Trace.WriteLine("Done! (" + sw.Elapsed.TotalMilliseconds.ToString("0.00") + " ms)");
                Trace.Unindent();


                // Prepare the OnGameLoad hook.
                LoadLibraryA = Memory.InstallHook(LocalHook.GetProcAddress("kernel32.dll", "LoadLibraryA"), new Kernel32.LoadLibraryAPrototype(LoadLibraryAHook), false, true);

                // Everyone has had their chance to inject stuff,
                // time to wake up the process.
                RemoteHooking.WakeUpProcess();
                Trace.WriteLine("WakeUpProcess Proceed!");
                // Let the thread stay alive, so all hooks stay alive as well.
                // This might need to be shutdown properly on exit.
                Trace.WriteLine("Sleep Proceed!");
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "Fatal exception!" + Environment.NewLine +
                    exception + Environment.NewLine +
                    "Aborting execution!",
                    GetType() + ".Run(...)", MessageBoxButton.OK, MessageBoxImage.Error);
                Process.GetCurrentProcess().Kill();
            }
        }

        private IntPtr LoadLibraryAHook(String fileName)
        {
            IntPtr module = LoadLibraryA(fileName);

            switch (fileName.ToLower())
            {
                case "game.dll":
                    Stopwatch sw = new Stopwatch();

                    PluginSystem.OnGameLoad();

                    // Prepare the Unknown__SetState hook.
                    Unknown__SetState = Memory.InstallHook(module + Addresses.Unknown__SetStateOffset, new Unknown__SetStateDelegate(Unknown__SetStateHook), true, false);

                    break;
            }

            return module;
        }

        private void OnEngineStart()
        {

        }

        private void OnEngineEnd()
        {

        }

        private void OnMapStart()
        {
            PluginSystem.OnMapStart();
        }

        private void OnMapEnd()
        {
            PluginSystem.OnMapEnd();
        }

        private IntPtr Unknown__SetStateHook(IntPtr @this, Boolean endMap, Boolean endEngine)
        {
            try
            {
                if (endEngine)
                {
                    if (this.IsInMap)
                    {
                        this.IsInMap = false;
                        this.OnMapEnd();
                    }
                    if (this.IsInGame)
                    {
                        this.IsInGame = false;
                        this.OnEngineEnd();
                    }
                }
                else
                {
                    if (endMap)
                    {
                        if (this.IsInMap)
                        {
                            this.IsInMap = false;
                            this.OnMapEnd();
                        }
                    }
                    else
                    {
                        if (!this.IsInGame)
                        {
                            this.OnEngineStart();
                            this.IsInGame = true;
                        }

                        if (this.IsInMap)
                        {
                            this.OnMapEnd();
                        }
                        this.OnMapStart();
                        this.IsInMap = true;
                    }
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine("Unhandled Exception in " + typeof(EntryPoint).Name + ".Unknown__SetStateHook!");
                Trace.WriteLine(e.ToString());
            }

            return this.Unknown__SetState(@this, endMap, endEngine);
        }
    }
}
