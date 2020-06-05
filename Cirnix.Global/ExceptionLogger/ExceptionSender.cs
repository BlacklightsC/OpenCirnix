using System;
using System.Threading;
using System.ComponentModel;

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
