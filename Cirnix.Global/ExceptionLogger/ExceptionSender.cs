using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Cirnix.Global
{
    public static class ExceptionSender
    {
        public struct ExceptionSendState
        {
            public Exception ex;
            public bool IsSendSettingDump;

            public ExceptionSendState(Exception ex, bool IsSendSettingDump)
            {
                this.ex = ex;
                this.IsSendSettingDump = IsSendSettingDump;
            }
        }

        private static BackgroundWorker MailAsyncSender;

        internal static void Init()
        {
            MailAsyncSender = new BackgroundWorker();
            MailAsyncSender.DoWork += MailAsyncSender_DoWork;
        }

        private static void MailAsyncSender_DoWork(object sender, DoWorkEventArgs e)
        {
            // Global Exception Catcher
            Exception ex = ((ExceptionSendState)e.Argument).ex;
            if (ex is FileLoadException || ex is BadImageFormatException)
            {
                MetroDialog.OK("백신에 의해 차단됨", "필요한 파일을 불러올 수 없었습니다.\n백신에서 허용 처리나 예외 설정을 해주세요.");
                Application.Exit();
            }
            else if (ex is MissingMethodException)
            {
                MetroDialog.OK("필요한 프로그램이 설치되지 않음", ".NET Framework 4.6.2 가 설치되어 있지 않습니다.\n확인을 누르면 치르닉스가 종료되면서 다운로드 페이지로 갑니다.");
                Process.Start("https://www.microsoft.com/ko-kr/download/confirmation.aspx?id=53345");
                Globals.ProgramShutDown.Invoke();
                Application.Exit();
            }
            else
            {
                File.AppendAllLines($"{Globals.ResourcePath}\\CirnixError.log", new string[] { ex.GetType().Name, ex.Message, ex.StackTrace });
            }
        }

        internal static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ExceptionSendAsync(e.Exception);
        }
        internal static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex) ExceptionSendAsync(ex);
        }
        public static void ExceptionSendAsync(Exception ex, bool IsSendSettingDump = false)
        {
            if (MailAsyncSender.IsBusy) return;
            MailAsyncSender.RunWorkerAsync(new ExceptionSendState(ex, IsSendSettingDump));
        }
    }
}
