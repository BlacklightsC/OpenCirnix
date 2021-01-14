using System.Threading;

using Cirnix.Global;
using Cirnix.Global.Properties;

using static Cirnix.Global.SoundManager;
using static Cirnix.Memory.Message;
using static Cirnix.Memory.States;


namespace Cirnix.Worker
{
    internal static class MaxRoom
    {
        private static readonly Timer Timer;
        private static readonly HangWatchdog Worker;
        private static int MaxCount;
        internal static bool IsRunning { get; private set; } = false;
        static MaxRoom()
        {
            Worker = new HangWatchdog(0, 0, 0);
            Worker.Condition = () => IsRunning && MaxCount <= PlayerCount;
            Worker.Actions += Actions;

            Timer = new Timer(state => Worker.Check());
        }

        internal static void RunWorkerAsync(int count)
        {
            if (IsRunning || count == 0) return;
            Timer.Change(0, 500);
            IsRunning = true;
            MaxCount = count;
            Worker.Check();
        }

        internal static void CancelAsync()
        {
            if (!IsRunning) return;
            Worker.Reset();
            Timer.Change(Timeout.Infinite, Timeout.Infinite);
            IsRunning = false;
            MaxCount = 0;
        }

        private static void Actions()
        {
            try
            {
                CancelAsync();
                SendMsg(true, $"'{MaxCount}'명 이상이 되었습니다.");
                Play(Resources.max);
            }
            catch
            {
                SendMsg(true, "실행 도중 문제가 발생했습니다.");
            }
        }
    }
}

