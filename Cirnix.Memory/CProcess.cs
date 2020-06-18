using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static Cirnix.Global.Component;
using static Cirnix.Global.Globals;
using static Cirnix.Memory.Component;
using static Cirnix.Memory.NativeMethods;

namespace Cirnix.Memory
{
    public static class CProcess
    {
        public static long[] MemoryValue = new long[3];

        public static bool ForegroundWar3()
        {
            if (Warcraft3Info.Process == null) return false;
            return Warcraft3Info.Process.MainWindowHandle == GetForegroundWindow();
        }

        public static RECT GetWar3Rect()
        {
            RECT lpRect = new RECT();
            if (Warcraft3Info.Process != null)
                GetWindowRect(Warcraft3Info.Process.MainWindowHandle, out lpRect);
            else
                lpRect.Left = lpRect.Top = lpRect.Right = lpRect.Bottom = 0;
            return lpRect;
        }

        /// <summary>
        /// 시스템에서 실행중인 모든 프로세스에 대해, 사용하지 않는 WorkingSet 메모리를 OS에게 반환하도록 합니다.
        /// </summary>
        /// <param name="excludeThisProcess">현재 프로세스를 제외할 것인가 여부 (기본값은 제외)</param>
        /// <param name="excludeProcessNames">메모리 반환을 하지 않을 프로세스 명의 컬렉션</param>
        public static void TrimAllProcessMemory(bool excludeThisProcess = true, string[] excludeProcessNames = null)
        {
            //if (log.IsInfoEnabled)
            //    log.Info("컴퓨터의 모든 프로세스에 대해 사용하지 않는 메모리를 OS에 반환하도록 합니다...");

            Process currentProcess = Process.GetCurrentProcess();

            Parallel.ForEach(Process.GetProcesses(),
                             process =>
                             {
                                 if (excludeThisProcess && (process.ProcessName == currentProcess.ProcessName))
                                     return;

                                 if (excludeProcessNames != null &&
                                    excludeProcessNames.Any(procName => procName == process.ProcessName))
                                     return;

                                 TrimProcessMemory(process, false);
                             });
        }

        /// <summary>
        /// 지정된 프로세스의 사용하지 않는 WorkingSet 메모리를 OS에게 반환하도록 합니다.
        /// </summary>
        /// <param name="process">메모리 해제를 할 프로세스</param>
        /// <returns>메모리 해제 여부</returns>
        public static bool TrimProcessMemory(Process process, bool isSingle)
        {
            if (process == null) return false;
            bool _result;
            try
            {
                long oldWorkingSet64 = process.WorkingSet64;
                _result = EmptyWorkingSet(process.Handle);
                Process targetProcess = Process.GetProcessById(process.Id);

                if (_result && isSingle)
                {
                    MemoryValue[0] = oldWorkingSet64;
                    Delay(5000);
                    MemoryValue[1] = targetProcess.WorkingSet64;
                    MemoryValue[2] = oldWorkingSet64 - targetProcess.WorkingSet64;
                }
            }
            catch
            {
                _result = false;
            }

            return _result;
        }

        /// <summary>
        /// 지정된 프로세스의 사용하지 않는 WorkingSet 메모리를 OS에게 반환하도록 합니다.
        /// </summary>
        /// <param name="ProcessName">메모리 해제를 할 프로세스의 이름</param>
        /// <returns>메모리 해제 여부</returns>
        public static bool TrimProcessMemory(string ProcessName, bool NeedResult = false)
        {
            Process[] ProcessbyName = Process.GetProcessesByName(ProcessName);
            
            if(ProcessbyName.Length > 0)
                return TrimProcessMemory(ProcessbyName[0], NeedResult);

            return false;
        }
    }
}
