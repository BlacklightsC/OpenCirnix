using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace Cirnix.JassNative.Runtime
{
    internal class DebuggerApplication : Application
    {
        public static bool IsReady { get; private set; }

        private static string HackPath;

        public static void Start(string hackPath)
        {
            HackPath = hackPath;

            var thread = new Thread(new ThreadStart(Thread));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private static void Thread()
        {
            try
            {
                var application = new DebuggerApplication();
                var window = new DebuggerWindow(HackPath);
                IsReady = true;
                application.Run(window);
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "Fatal exception!" + Environment.NewLine +
                    exception + Environment.NewLine +
                    "Aborting execution!",
                    typeof(DebuggerApplication) + ".Thread()", MessageBoxButton.OK, MessageBoxImage.Error);
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
