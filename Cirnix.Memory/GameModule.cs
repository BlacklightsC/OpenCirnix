using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using Cirnix.Global;

using static Cirnix.Memory.Component;
using static Cirnix.Memory.NativeMethods;

namespace Cirnix.Memory
{
    public static class GameModule
    {
        public static void GetOffset(bool isForced = false)
        {
            if (!isForced && GameDllOffset != IntPtr.Zero) return;
            GameDllOffset = IntPtr.Zero;
            StormDllOffset = IntPtr.Zero;
            if (Warcraft3Info.Process == null) return;
            foreach (ProcessModule module in Warcraft3Info.Process.Modules)
            {
                switch (module.ModuleName.ToLower())
                {
                    case "game.dll": GameDllOffset = module.BaseAddress; break;
                    case "storm.dll": StormDllOffset = module.BaseAddress; break;
                }
            }
        }

        public static bool WarcraftCheck()
        {
            byte[] lpBuffer = new byte[1];
            IntPtr baseAddress = Warcraft3Info.BaseAddress;
            if (baseAddress == IntPtr.Zero) return false;
            try
            {
                return ReadProcessMemory(Warcraft3Info.Handle, baseAddress, lpBuffer, 1, out _) && lpBuffer[0] > 0;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<WarcraftState> StartWarcraft3(string path, int windowState = 0)
        {
            Global.Registry.Warcraft.SetFullQualityGraphics();
            string EXEPath = $"{path}\\JNLoader.exe";
            string updaterPath = $"{path}\\JNUpdater.exe";
            if (!File.Exists(EXEPath) || !File.Exists(updaterPath))
            {
                try
                {
                    if (File.Exists(updaterPath))
                        File.Delete(updaterPath);
                    File.WriteAllBytes(updaterPath, Properties.Resources.JNUpdater);
                    ProcessStartInfo info = new ProcessStartInfo("JNUpdater.exe", "-updateonly -force");
                    info.WorkingDirectory = path;
                    using (Process proc = Process.Start(info))
                    {
                        proc.WaitForExit();
                        int ExitCode = proc.ExitCode;
                        if (ExitCode >> 16 < 0 || ExitCode << 16 >> 16 < 0)
                        {
                            MetroDialog.OK("오류", "JNLoader 설치에 실패했습니다.\n백신에 의해 차단됬을 수도 있습니다.");
                            return 0;
                        }
                    }
                }
                catch { return 0; }
            }

            string WindowsStateString;
            switch (windowState)
            {
                case 0: WindowsStateString = "-windows"; break;
                case 1: WindowsStateString = string.Empty; break;
                case 2: WindowsStateString = "-nativefullscr"; break;
                default: return 0;
            }
            try
            {
                using (Process proc = Process.Start(EXEPath, WindowsStateString))
                {
                    proc.WaitForExit();
                    int procId = proc.ExitCode;
                    if (procId <= 0) return WarcraftState.Error;
                    return InitWarcraft3Info(procId);
                }
            }
            catch (ArgumentException ex)
            {
                MetroDialog.OK("오류", "Warcraft III를 실행하지 못했습니다.\nCirnix를 다시 실행시켜주세요.");
                ExceptionSender.ExceptionSendAsync(ex);
                return 0;
            }
        }

        public static WarcraftState InitWarcraft3Info()
        {
            if (!Warcraft3Info.HasExited) return WarcraftState.OK;
            try
            {
                Process[] procs = Process.GetProcessesByName("Warcraft III");
                if (procs.Length == 0)
                {
                    procs = Process.GetProcessesByName("war3");
                    if (procs.Length == 0)
                    {
                        if (Warcraft3Info.Process != null)
                            Warcraft3Info.Reset();
                        return WarcraftState.Closed;
                    }
                }
                return InitWarcraft3Info(procs[0]);
            }
            catch (InvalidOperationException)
            {
                return WarcraftState.Error;
            }
        }

        public static WarcraftState InitWarcraft3Info(string name)
        {
            Process[] procs = Process.GetProcessesByName(name);
            if (procs.Length == 0)
            {
                if (Warcraft3Info.ID != 0)
                    Warcraft3Info.Reset();
                return WarcraftState.Closed;
            }
            return InitWarcraft3Info(procs[0]);
        }

        public static WarcraftState InitWarcraft3Info(int id) => InitWarcraft3Info(Process.GetProcessById(id));

        public static WarcraftState InitWarcraft3Info(Process proc)
        {
            try
            {
                if (proc.HasExited)
                {
                    try { proc.Kill(); } catch { }
                    return WarcraftState.Closed;
                }
                Warcraft3Info.Process = proc;
                if (Warcraft3Info.Process == null)
                    return WarcraftState.Error;
                return WarcraftState.OK;
            }
            catch
            {
                return WarcraftState.Error;
            }
        }
    }
}
