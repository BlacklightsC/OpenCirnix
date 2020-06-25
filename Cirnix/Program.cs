using Cirnix.Forms;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Cirnix
{
    public class Program
    {
        /// <summary>
        /// Main 진입 전에 동작할 함수들 입니다.
        /// 추가 라이브러리가 로드되기 전의 부분 입니다.
        /// </summary>
        static Program()
        {
            // 라이브러리가 외부에 있을 경우 문제가 생김
            foreach (var item in Directory.GetFiles(".", "CirnoLib.*"))
                try { File.Delete(item); } catch { }
            foreach (var item in Directory.GetFiles(".", "Cirnix.*dll"))
                try { File.Delete(item); } catch { }
        }

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Mutex mutex = new Mutex(true, "Cirnix", out bool bnew);
            if (!bnew) return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TrayIcon());
            mutex.ReleaseMutex();
        }
    }
}
