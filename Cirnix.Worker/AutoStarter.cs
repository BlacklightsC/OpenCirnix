using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Cirnix.Global;
using Cirnix.Memory;
using static Cirnix.Memory.Message;
using static Cirnix.Global.NativeMethods;
using static Cirnix.Global.SoundManager;
using static Cirnix.Memory.Component;
using static Cirnix.Memory.States;
using Cirnix.Global.Properties;


namespace Cirnix.Worker
{
    class AutoStarter
    {
        private static int Maxs;
        private static readonly Timer Timer;
        private static readonly HangWatchdog Worker;
        private static int AutoStarterCount = 0, LoopedCount = 0;
        internal static bool IsRunning { get; private set; } = false;
        static AutoStarter()
        {
            Worker = new HangWatchdog(999, 999, 999); //시간될대마다 조건무시하고 worker_actions함수 강제발동으로 마서용
            Worker.Condition = () => IsRunning;
            Worker.Actions += Worker_Actions;

            Timer = new Timer(state => Worker.Check());
        }

        internal async static void RunWorkerAsync(int Max)
        {
            if (IsRunning) return;
            Timer.Change(0, 1000);
            Maxs = Max;
            IsRunning = true;
            do
            {
                await Task.Delay(500);
            }
            while (Maxs > PlayerCount);  //타이머 미사용으로 대기 딜레이 다시 추가
            Worker_Actions(); 
        }

        internal static void CancelAsync()
        {
            if (!IsRunning) return;
            Worker.Reset();
            Timer.Change(Timeout.Infinite, Timeout.Infinite);
            IsRunning = false;
        }

        private async static void Worker_Actions()
        {
            try
            {
                if (!IsRunning) return;
                Play(Resources.max);
                for (int i = 10; i > 0; i--)
                {
                    
                    if (Maxs > PlayerCount)
                    {
                        SendMsg(true, "지정된 인원보다 수가 적습니다. 시작을 취소합니다.");
                        CancelAsync();
                        return;
                    }
                    SendMsg(true, $"{i}초후 게임을 시작합니다.");
                    await Task.Delay(1000);
                }
                PostMessage(Warcraft3Info.MainWindowHandle, 0x100, 18, 0);
                PostMessage(Warcraft3Info.MainWindowHandle, 0x100, 83, 0);
                PostMessage(Warcraft3Info.MainWindowHandle, 0x101, 18, 0);
                PostMessage(Warcraft3Info.MainWindowHandle, 0x101, 83, 0);
            }

            catch
            {
                SendMsg(true, "알림설정을 실패하였습니다.");
            }
        }
    }
}

