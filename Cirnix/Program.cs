using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static Cirnix.Global.Globals;

namespace Cirnix
{
    public static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Mutex mutex = new Mutex(true, "Cirnix", out bool bnew);
            if (!bnew) return;
            bool IsUpdated = false;
            if (File.Exists("update.tmp"))
            {
                File.Delete("update.tmp");
                IsUpdated = true;
            }
            if (!Directory.Exists(ResourcePath)) Directory.CreateDirectory(ResourcePath);
            //#region [    Analyzer Config Setting    ]
            //Analyzer.Eden.Properties.Settings.Default.SettingsKey = SettingsRoot + @"\Eden.config";
            //Analyzer.IS9.Properties.Settings.Default.SettingsKey = SettingsRoot + @"\IS9.config";
            //#endregion
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitGlobal(IsUpdated);
            Application.Run(new Forms.TrayIcon());
            mutex.ReleaseMutex();
        }
    }
}
