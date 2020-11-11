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
    class MaxRoom
    {
        private static int Maxs;
        private static readonly Timer Timer;
        private static readonly HangWatchdog Worker;
        private static int AutoStarterCount = 0, LoopedCount = 0;
        internal static bool IsRunning { get; private set; } = false;
        static MaxRoom()
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
                SendMsg(true, $"'{Maxs}'명 이상이 되었습니다.");
                Play(Resources.max);
                Maxs = 0;
                CancelAsync();
            }
            catch
            {
                SendMsg(true, "알림설정을 실패하였습니다.");
            }
        }
    }
}

