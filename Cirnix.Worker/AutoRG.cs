using Cirnix.Global;
using System;
using System.Threading;
using static Cirnix.Memory.Message;

namespace Cirnix.Worker.InnerWorker
{
    public sealed class AutoRG
    {
        private readonly Timer Timer;
        private readonly HangWatchdog Worker;
        private int AutoRGCount = 0, LoopedCount = 0;
        public bool isRunning { get; private set; } = false;
        internal AutoRG()
        {
            Worker = new HangWatchdog(0, 0, 10);
            Worker.Condition = () => isRunning;
            Worker.Actions += Worker_Actions;

            Timer = new Timer(state => Worker.Check());
        }

        internal void RunWorkerAsync(int count)
        {
            if (isRunning || count == 0) return;
            Timer.Change(0, 1000);
            isRunning = true;
            AutoRGCount = count;
            Worker_Actions();
        }

        internal void CancelAsync()
        {
            if (!isRunning) return;
            Worker.Reset();
            Timer.Change(Timeout.Infinite, Timeout.Infinite);
            isRunning = false;
            AutoRGCount = LoopedCount = 0;
        }

        private void Worker_Actions()
        {
            SendMsg(false, "/rg");
            if (AutoRGCount > 0)
            {
                SendMsg(true, $"자동 RG 사용 중: {++LoopedCount}회");
                if (LoopedCount >= AutoRGCount)
                {
                    CancelAsync();
                    SendMsg(true, "자동 RG 기능이 자동적으로 종료되었습니다.");
                }
            }
        }
    }
}
