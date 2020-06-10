using Cirnix.Global;

using MetroFramework.Forms;

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

using static System.Threading.Thread;

namespace Cirnix.Forms
{
    internal sealed partial class UpdateForm : MetroForm
    {
        private string name, URL;
        private bool isDownload = false, successfullyDownload = false;
        WebClient client;
        Stopwatch sw;
        private string ProgramPath = System.Reflection.Assembly.GetEntryAssembly().Location;
        internal UpdateForm(string name, string URL)
        {
            InitializeComponent();
            client = new WebClient();
            sw = new Stopwatch();
            client.DownloadProgressChanged += webClient_DownloadProgressChanged;
            client.DownloadFileCompleted += webClient_DownloadFileCompleted;
            Shown += UpdateForm_Shown;
            this.name = name;
            this.URL = URL;
            Text = $"{name} 자동 업데이트 도구";
        }

        private void UpdateForm_Shown(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)))
                    File.Move(Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location), "update.tmp");
                while (!successfullyDownload)
                {
                    Application.DoEvents();
                    if (!isDownload)
                    {
                        sw.Start();
                        client.DownloadFileAsync(new Uri(URL), name + ".exe");
                        break;
                    }
                    Sleep(200);
                }
            }
            catch { }
        }
        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            LabelTitle.Text = "업데이트 완료!";
            LabelMsg.Text = "잠시 후, 자동으로 종료됩니다.\n프로그램을 다시 실행시켜주세요!";
            successfullyDownload = true;
            LabelMsg.Text = "잠시 후, 자동으로 재시작됩니다.";
            MetroDialog.OK("업데이트 완료!", "\"확인\"을 누르면 다시 시작됩니다.");
            ProceedRestartBat();
        }
        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarUpdateState.Value = e.ProgressPercentage;
            LabelMsg.Text = string.Format("{0,-30}{1,-10}\n{2, -20}{3,-15}",
                $"내려받는 중...  {Math.Round(e.BytesReceived / 1048576.0, 1)}MB / {Math.Round(e.TotalBytesToReceive / 1048576.0, 1)}MB",
                $"진행률: {e.ProgressPercentage}%",
                $"전송 속도: {TransmissionSpeed(e.BytesReceived)}/s",
                $"남은 시간: {RemainingTime(e.BytesReceived, e.TotalBytesToReceive)}"
                );
            isDownload = true;
        }

        private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!successfullyDownload) e.Cancel = true;
        }

        private string TransmissionSpeed(long received)
        {
            if (sw.ElapsedMilliseconds <= 0) return string.Empty;
            double speed = received / (sw.ElapsedMilliseconds / 1000);
            if (speed >= 1000000) return $"{Math.Round(speed / 1048576.0, 1)}MB";
            else if (speed >= 1000) return $"{Math.Round(speed / 1024.0, 1)}KB";
            else return $"{Math.Round(speed)}bytes";
        }
        private string RemainingTime(long received, long totalReceived)
        {
            if (received <= 0 || sw.ElapsedMilliseconds <= 0) return string.Empty;
            long leftTime = (totalReceived - received) / (received / (sw.ElapsedMilliseconds / 1000));
            StringBuilder timeText = new StringBuilder();

            if (leftTime >= 60) timeText.AppendFormat("{0}분{1}", leftTime / 60, leftTime % 60 > 0 ? " " : string.Empty);
            if (leftTime % 60 > 0) timeText.AppendFormat("{0}초", leftTime % 60);
            return timeText.ToString();
        }
        private void ProceedRestartBat()
        {
            File.Delete("Restart.bat");
            using (var writer = File.CreateText("Restart.bat"))
            {
                writer.WriteLine("@ECHO OFF");
                writer.WriteLine("start /d \"" + Path.GetDirectoryName(ProgramPath) + "\\\" " + Path.GetFileName(ProgramPath));
                writer.WriteLine("del \"" + Path.Combine(Path.GetDirectoryName(ProgramPath), "Restart.bat") + '"');
                writer.Flush();
                writer.Close();
            }
            ProcessStartInfo StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c " + Path.Combine(Application.StartupPath, "Restart.bat"),
                CreateNoWindow = true,
                UseShellExecute = true
            };
            Process.Start(StartInfo);
            Environment.Exit(0);
        }
    }
}
