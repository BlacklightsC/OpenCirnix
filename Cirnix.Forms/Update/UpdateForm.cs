using Cirnix.Global;

using MetroFramework.Forms;

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cirnix.Forms.Update
{
    public sealed partial class UpdateForm : MetroForm
    {
        private readonly string name, URL;
        private readonly bool IsSingle;
        private readonly WebClient client;
        private readonly Stopwatch sw;
        private readonly string ProgramPath = System.Reflection.Assembly.GetEntryAssembly().Location;
        public UpdateForm(string name, string URL)
        {
            InitializeComponent();
            sw = new Stopwatch();
            client = new WebClient();
            client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.106 Safari/537.36");
            client.DownloadProgressChanged += webClient_DownloadProgressChanged;
            client.DownloadFileCompleted += webClient_DownloadFileCompleted;
            Shown += UpdateForm_Shown;
            this.name = name;
            this.URL = URL;
            Text = $"{name} 자동 업데이트 도구";
        }
        public UpdateForm(string name, string URL, bool IsSingle) : this(name, URL)
        {
            this.IsSingle = IsSingle;
        }

        private async void UpdateForm_Shown(object sender, EventArgs e)
        {
            try
            {
                if (!IsSingle)
                {
                    string fileName = Path.GetFileName(ProgramPath);
                    if (File.Exists(fileName))
                        File.Move(fileName, "update.tmp");
                }
                sw.Start();
                await client.DownloadFileTaskAsync(URL, $"{name}.exe");
            }
            catch { }
        }
        private async void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                if (!IsSingle)
                {
                    File.Delete($"{name}.exe");
                    File.Move("update.tmp", Path.GetFileName(ProgramPath));
                }
                Close();
            }
            else if (e.Error != null)
            {
                LabelTitle.Text = "업데이트 실패!";
                MetroDialog.OK("오류 발생!", "업데이트 파일을 불러오는데 실패했습니다.");
                Close();
            }
            else
            {
                LabelTitle.Text = "업데이트 완료!";
                if (IsSingle)
                {
                    LabelMsg.Text = "잠시 후, 자동으로 창이 종료됩니다.";
                    MetroDialog.OK("업데이트 완료!", "\"확인\"을 누르면 창이 종료됩니다.");
                    await Task.Delay(3000);
                    Close();
                }
                else
                {
                    LabelMsg.Text = "잠시 후, 자동으로 재시작됩니다.";
                    MetroDialog.OK("업데이트 완료!", "\"확인\"을 누르면 다시 시작됩니다.");
                    ProceedRestartBat();
                }
            }
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
        }

        private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client.IsBusy)
                if (MetroDialog.YesNo("업데이트 중단", "업데이트를 중단하시겠습니까?"))
                {
                    client.CancelAsync();
                }
                else
                {
                    e.Cancel = true;
                }
        }

        private string TransmissionSpeed(long received)
        {
            if (sw.ElapsedMilliseconds <= 0) return string.Empty;
            double speed = received / (sw.ElapsedMilliseconds / 1000.0);
            if (speed >= 1000000) return $"{Math.Round(speed / 1048576, 1)}MB";
            else if (speed >= 1000) return $"{Math.Round(speed / 1024, 1)}KB";
            else return $"{Math.Round(speed)}bytes";
        }
        private string RemainingTime(long received, long totalReceived)
        {
            if (received <= 0 || sw.ElapsedMilliseconds <= 0) return string.Empty;
            long leftTime = (long)Math.Round((totalReceived - received) / (received / (sw.ElapsedMilliseconds / 1000.0)), 0);
            StringBuilder timeText = new StringBuilder();

            if (leftTime >= 60) timeText.AppendFormat("{0}분{1}", leftTime / 60, leftTime % 60 > 0 ? " " : string.Empty);
            if (leftTime % 60 > 0) timeText.AppendFormat("{0}초", leftTime % 60);
            if (timeText.Length == 0) timeText.Append("완료 중...");
            return timeText.ToString();
        }
        private void ProceedRestartBat()
        {
            File.Delete("Restart.bat");
            using (var writer = File.CreateText("Restart.bat"))
            {
                string path = Path.GetDirectoryName(ProgramPath);
                writer.WriteLine("@ECHO OFF");
                writer.WriteLine($"start /d \"{path}\\\" {Path.GetFileName(ProgramPath)}");
                writer.WriteLine($"del \"{path}\\Restart.bat\"");
                writer.Flush();
                writer.Close();
            }
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {Path.Combine(Application.StartupPath, "Restart.bat")}",
                CreateNoWindow = true,
                UseShellExecute = true
            });
            Environment.Exit(0);
        }
    }
}
