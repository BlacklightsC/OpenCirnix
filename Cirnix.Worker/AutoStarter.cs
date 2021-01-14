using System.Threading;
using System.Threading.Tasks;

using Cirnix.Global.Properties;

using static Cirnix.Global.NativeMethods;
using static Cirnix.Global.SoundManager;
using static Cirnix.Memory.Component;
using static Cirnix.Memory.Message;
using static Cirnix.Memory.States;

namespace Cirnix.Worker
{
    internal static class AutoStarter
    {
        private static readonly Timer Timer = new Timer(state => Action());
        internal static bool IsRunning { get; private set; } = false;
        internal static int Dest { get; set; }

        internal static void RunWorkerAsync(int dest)
        {
            if (IsRunning) return;
            Dest = dest;
            Timer.Change(0, 500);
            IsRunning = true;
        }

        internal static void CancelAsync()
        {
            if (!IsRunning) return;
            Timer.Change(Timeout.Infinite, Timeout.Infinite);
            IsRunning = false;
        }

        private async static void Action()
        {
            if (Dest > PlayerCount) return;
            CancelAsync();
            Play(Resources.max);
            for (int i = 10; i > 0; i--)
            {
                if (Dest > PlayerCount)
                {
                    SendMsg(true, "지정된 인원보다 수가 적습니다. 시작을 취소합니다.");
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
    }
}

