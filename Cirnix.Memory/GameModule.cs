using System;
using System.Diagnostics;
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

        public static WarcraftState InitWarcraft3Info()
        {
            if (!Warcraft3Info.HasExited) return WarcraftState.OK;
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
    }
}
