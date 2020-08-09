using System.Threading;

using Cirnix.Global;

using static Cirnix.Memory.Message;

namespace Cirnix.Worker
{
    internal static class AutoRG
    {
        private static readonly Timer Timer;
        private static readonly HangWatchdog Worker;
        private static int AutoRGCount = 0, LoopedCount = 0;
        internal static bool IsRunning { get; private set; } = false;
        static AutoRG()
        {
            Worker = new HangWatchdog(0, 0, 10);
            Worker.Condition = () => IsRunning;
            Worker.Actions += Worker_Actions;

            Timer = new Timer(state => Worker.Check());
        }

        internal static void RunWorkerAsync(int count)
        {
            if (IsRunning || count == 0) return;
            Timer.Change(0, 1000);
            IsRunning = true;
            AutoRGCount = count;
            Worker_Actions();
        }

        internal static void CancelAsync()
        {
            if (!IsRunning) return;
            Worker.Reset();
            Timer.Change(Timeout.Infinite, Timeout.Infinite);
            IsRunning = false;
            AutoRGCount = LoopedCount = 0;
        }

        private static void Worker_Actions()
        {
            SendMsg(false, "/rg");
            if (AutoRGCount > 0)
            {
                SendMsg(true, string.Format("자동 RG 사용 중: {0}회", ++LoopedCount));
                if (LoopedCount >= AutoRGCount)
                {
                    CancelAsync();
                    SendMsg(true, "자동 RG 기능이 자동적으로 종료되었습니다.");
                }
            }
        }
    }
}
