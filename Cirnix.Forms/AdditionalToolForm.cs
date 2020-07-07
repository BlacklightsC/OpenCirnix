using Cirnix.Global;

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Cirnix.Forms
{
    internal partial class AdditionalToolForm : DraggableLabelForm
    {
        internal AdditionalToolForm()
        {
            InitializeComponent();
            Icon = Global.Properties.Resources.CirnixIcon;
            Label_Title.MouseDown += new MouseEventHandler(Label_Title_MouseDown);
            Label_Title.MouseMove += new MouseEventHandler(Label_Title_MouseMove);
            Label_Title.MouseUp += new MouseEventHandler(Label_Title_MouseUp);
            Label_Title.Text = Text = $"{Global.Theme.Title} 부가 기능";
            Combo_ScreenShotExtension.Text = Settings.ConvertExtention;
        }
        private bool IsFormEnabled {
            get {
                return Combo_ScreenShotExtension.Enabled;
            }
            set {
                BTN_CheatMapCheck.Enabled = 
                BTN_ConvertScreenShot.Enabled = 
                Combo_ScreenShotExtension.Enabled = value;
            }
        }
        private void BTN_CheatMapCheck_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "검사할 맵 파일을 선택해주세요.";
            OFD.InitialDirectory = $"{Globals.DocumentPath}\\Maps";
            OFD.CheckFileExists = true;
            OFD.Multiselect = true;
            OFD.Filter = "Warcraft III 맵 (*.w3m;*.w3x)|*.w3m;*.w3x|모든 파일 (*.*)|*.*";
            if (OFD.ShowDialog() != DialogResult.OK) return;
            IsFormEnabled = false;
            List_Data.Rows.Clear();
            string[] SafeFileNames = OFD.SafeFileNames;
            for (int i = 0; i < SafeFileNames.Length; i++)
            {
                List_Data.Rows.Add(SafeFileNames[i]);
                List_Data.Rows[i].Cells[1].Value = "검사 대기";
            }
            Worker.RunWorkerAsync(OFD.FileNames);
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] FileNames = (string[])e.Argument;
            for (int i = 0; i < FileNames.Length; i++)
            {
                Worker.ReportProgress(i, 0);
                try
                {
                    int value = Globals.IsCheatMap(FileNames[i]) ? 1 : 2;
                    if (Worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    Worker.ReportProgress(i, value);
                }
                catch
                {
                    Worker.ReportProgress(i, 3);
                }
            }
        }
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Worker.CancellationPending) return;
            switch ((int)e.UserState)
            {
                case 0:
                    List_Data.Rows[e.ProgressPercentage].Cells[1].Value = "검사 중...";
                    List_Data.Rows[e.ProgressPercentage].Cells[1].Style.BackColor = Color.Yellow;
                    return;
                case 1:
                    List_Data.Rows[e.ProgressPercentage].Cells[1].Value = "치트 발견";
                    List_Data.Rows[e.ProgressPercentage].Cells[1].Style.BackColor = Color.Orange;
                    return;
                case 2:
                    List_Data.Rows[e.ProgressPercentage].Cells[1].Value = "정상";
                    List_Data.Rows[e.ProgressPercentage].Cells[1].Style.BackColor = Color.LightGreen;
                    return;
                case 3:
                    List_Data.Rows[e.ProgressPercentage].Cells[1].Value = "읽기 오류";
                    List_Data.Rows[e.ProgressPercentage].Cells[1].Style.BackColor = Color.Violet;
                    return;
            }
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) return;
            IsFormEnabled = true;
        }

        private async void BTN_ConvertScreenShot_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "변환할 스크린샷 파일을 선택해주세요.";
            OFD.InitialDirectory = $"{Globals.DocumentPath}\\ScreenShots";
            OFD.CheckFileExists = true;
            OFD.Multiselect = true;
            OFD.Filter = "TGA 파일 (*.tga)|*.tga|모든 파일 (*.*)|*.*";
            if (OFD.ShowDialog() != DialogResult.OK) return;
            IsFormEnabled = false;
            List_Data.Rows.Clear();
            string[] SafeFileNames = OFD.SafeFileNames;
            for (int i = 0; i < SafeFileNames.Length; i++)
            {
                List_Data.Rows.Add(SafeFileNames[i]);
                List_Data.Rows[i].Cells[1].Value = "변환 대기";
            }
            string[] FileNames = OFD.FileNames;
            for (int i = 0; i < FileNames.Length; i++)
            {
                List_Data.Rows[i].Cells[1].Value = "변환 중...";
                List_Data.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                Application.DoEvents();
                if (TgaReader.SaveTo(await Globals.ReadFile(FileNames[i]), $"{Path.GetDirectoryName(FileNames[i])}\\{Path.GetFileNameWithoutExtension(FileNames[i])}", Combo_ScreenShotExtension.Text))
                {
                    List_Data.Rows[i].Cells[1].Value = "변환 완료";
                    List_Data.Rows[i].Cells[1].Style.BackColor = Color.LightGreen;
                }
                else
                {
                    List_Data.Rows[i].Cells[1].Value = "변환 실패";
                    List_Data.Rows[i].Cells[1].Style.BackColor = Color.Violet;
                }
            }
            IsFormEnabled = true;
        }

        private void AdditionalToolForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Worker.CancelAsync();
        }
    }
}
