using System.ComponentModel;
using static Cirnix.Memory.Message;

namespace Cirnix.Worker.InnerWorker
{
    public sealed class AutoRG
    {
        private BackgroundWorker Worker;
        private int DelayCount = 50, AutoRGCount = 0, LoopedCount = 0;
        public bool isRunning { get; private set; } = false;
        internal AutoRG()
        {
            Worker = new BackgroundWorker();
            Worker.WorkerReportsProgress = true;
            Worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            Worker.ProgressChanged += new ProgressChangedEventHandler(Worker_ProgressChanged);
            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
        }

        internal void RunWorkerAsync(int count)
        {
            if (isRunning || count == 0) return;
            isRunning = true;
            AutoRGCount = count;
            Worker.RunWorkerAsync();
        }

        internal void CancelAsync()
        {
            if (!isRunning) return;
            isRunning = false;
            AutoRGCount = LoopedCount = 0;
            DelayCount = 50;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Worker.ReportProgress(0);
            MainWorker.WorkerReset.Reset();
            MainWorker.WorkerReset.WaitOne(200);
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(isRunning) DelayCount++;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!isRunning) return;
            if (DelayCount > 50)
            {
                DelayCount = 0;
                if (AutoRGCount == -1)
                {
                    //MessageStack(true);
                    SendMsg(false, "/rg");
                    //MessageStack(false);
                }
                else if (AutoRGCount > 0)
                {
                    //MessageStack(true);
                    SendMsg(false, "/rg");
                    SendMsg(true, $"자동 RG 사용 중: {++LoopedCount}회");
                    if (LoopedCount >= AutoRGCount)
                    {
                        isRunning = false;
                        SendMsg(true, "자동 RG 기능이 자동적으로 종료되었습니다.");
                    }
                    //MessageStack(false);
                }
            }
            Worker.RunWorkerAsync();
        }
    }
}
