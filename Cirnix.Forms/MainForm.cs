using Cirnix.Global;
using Cirnix.Memory;

using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using static Cirnix.Global.Globals;

namespace Cirnix.Forms
{
    internal partial class MainForm : DraggableLabelForm
    {
        internal Action TrayCheck;
        internal Action optionForm;
        internal Action infoForm;
        internal Action<string[]> roomListForm;
        internal Action additonalToolForm;
        internal Action selectProcess;
        private bool isUpdating;

        internal MainForm()
        {
            InitializeComponent();
            Icon = Global.Properties.Resources.CirnixIcon;
            Label_Title.MouseDown += new MouseEventHandler(Label_Title_MouseDown);
            Label_Title.MouseMove += new MouseEventHandler(Label_Title_MouseMove);
            Label_Title.MouseUp += new MouseEventHandler(Label_Title_MouseUp);
            Label_Title.Text = Text = $"{Global.Theme.Title} v{version[0]}.{version[1]}";
            ImageBox.MouseDown += new MouseEventHandler(Label_Title_MouseDown);
            ImageBox.MouseMove += new MouseEventHandler(Label_Title_MouseMove);
            ImageBox.MouseUp += new MouseEventHandler(Label_Title_MouseUp);
        }

        private void BTN_Option_Click(object sender, EventArgs e)
        {
            optionForm();
        }

        private void BTN_Info_Click(object sender, EventArgs e)
        {
            infoForm();
        }

        private void BTN_RoomList_Click(object sender, EventArgs e)
        {
            roomListForm(null);
        }

        private void BTN_AdditionalTool_Click(object sender, EventArgs e)
        {
            additonalToolForm();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProgramShutDown();
        }

        public async void InvokedListUpdate(int depth = 0)
        {
            await Task.Delay(100);
            try
            {
                Invoke(new Action<int>(ListUpdate), depth);
            }
            catch
            {
                await Task.Delay(1000);
                Invoke(new Action<int>(ListUpdate), depth);
            }
        }

        public void ListUpdate(int depth = 0)
        {
            isUpdating = true;
            Box_MapType.Items.Clear();
            foreach (SavePath item in saveFilePath)
                Box_MapType.Items.Add(string.IsNullOrEmpty(item.nameKR) ? item.nameEN : item.nameKR);
            Box_MapType.Text = saveFilePath.ConvertName(Category[0]);
            if (string.IsNullOrEmpty(Category[0]))
            {
                Box_HeroType.Enabled = false;
                Box_SaveText.Enabled = false;
            }
            else
            {
                Box_HeroType.Enabled = true;
                Box_SaveText.Enabled = true;
            }
            if (depth > 0)
            {
                Box_HeroType.Items.Clear();
                if (!Directory.Exists(GetCurrentPath(0) + @"\미지정"))
                    Directory.CreateDirectory(GetCurrentPath(0) + @"\미지정");
                foreach (FileInfo item in new DirectoryInfo(GetCurrentPath(0)).GetFiles())
                    if (item.Extension.ToLower() == ".txt")
                        item.MoveTo(GetCurrentPath(0) + @"\미지정\" + item.Name);
                Box_HeroType.Items.AddRange(GetDirectoryList(GetCurrentPath(0)));
                Box_HeroType.Text = Category[1];
            }
            if (depth > 1)
            {
                Box_SaveText.Items.Clear();
                Box_SaveText.Items.AddRange(GetFileList(GetCurrentPath(1)));
                Box_SaveText.Text = Category[2] = Path.GetFileName(GetLastest(GetCurrentPath(1)));
            }
            isUpdating = false;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            isUpdating = true;
            Box_MapType.Items.Clear();
            foreach (SavePath item in saveFilePath)
                Box_MapType.Items.Add(string.IsNullOrEmpty(item.nameKR) ? item.nameEN : item.nameKR);
            Box_MapType.Text = saveFilePath.ConvertName(Category[0]);
            Box_HeroType.Items.Clear();
            if (string.IsNullOrEmpty(Category[0]))
            {
                Box_HeroType.Enabled = false;
                Box_SaveText.Enabled = false;
                return;
            }
            else
            {
                Box_HeroType.Enabled = true;
                Box_SaveText.Enabled = true;
            }
            if (GetCurrentPath(0) != null)
            {
                string path = $"{GetCurrentPath(0)}\\미지정";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                foreach (FileInfo item in new DirectoryInfo(GetCurrentPath(0)).GetFiles())
                    if (item.Extension.ToLower() == ".txt")
                    {
                        string innerPath = $"{path}\\{Path.GetFileNameWithoutExtension(item.Name)}";
                        try
                        {
                            item.MoveTo($"{innerPath}.txt");
                        }
                        catch
                        {
                            for (int i = 1; true; i++)
                            {
                                if (Directory.Exists($"{innerPath}~{i}.txt")) continue;
                                item.MoveTo($"{innerPath}~{i}.txt");
                                break;
                            }
                        }
                    }
                Box_HeroType.Items.AddRange(GetDirectoryList(GetCurrentPath(0)));
                Box_HeroType.Text = Category[1];
                Box_SaveText.Items.Clear();
                Box_SaveText.Items.AddRange(GetFileList(GetCurrentPath(1)));
                Box_SaveText.Text = Category[2] = Path.GetFileName(GetLastest(GetCurrentPath(1)));
            }
            CommandPreset = Settings.SelectedCommand;
            isUpdating = false;
        }

        private void MainForm_Update(object sender, EventArgs e)
        {
            ListUpdate();
        }

        private void Box_MapType_TextChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;
            Category[0] = saveFilePath.ConvertName(Box_MapType.Text, true);
            Box_HeroType.Items.Clear();
            Box_SaveText.Items.Clear();
            if (string.IsNullOrEmpty(Category[0]))
            {
                Box_HeroType.Enabled = false;
                Box_SaveText.Enabled = false;
                return;
            }
            else
            {
                Box_HeroType.Enabled = true;
                Box_SaveText.Enabled = true;
            }
            if (!Directory.Exists(GetCurrentPath(0) + @"\미지정"))
                Directory.CreateDirectory(GetCurrentPath(0) + @"\미지정");
            foreach (FileInfo item in new DirectoryInfo(GetCurrentPath(0)).GetFiles())
                if (item.Extension.ToLower() == ".txt")
                    item.MoveTo(GetCurrentPath(0) + @"\미지정\" + item.Name);
            Box_HeroType.Items.AddRange(GetDirectoryList(GetCurrentPath(0)));
            Box_HeroType.Text = Category[1] = "미지정";
            Box_HeroType_TextChanged(sender, e);
        }

        private void Box_HeroType_TextChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;
            Category[1] = Box_HeroType.Text;
            Box_SaveText.Items.Clear();
            Box_SaveText.Items.AddRange(GetFileList(GetCurrentPath(1)));
            Box_SaveText.Text = Category[2] = Path.GetFileName(GetLastest(GetCurrentPath(1)));
        }

        private void Box_SaveText_TextChanged(object sender, EventArgs e)
        {
            Category[2] = Box_SaveText.Text;
            Settings.MapType = Category[0];
            Settings.HeroType = Category[1];
        }

        private int CommandPreset {
            get {
                if (RB_Preset1.Checked) return 1;
                else if (RB_Preset2.Checked) return 2;
                else if (RB_Preset3.Checked) return 3;
                return 0;
            }
            set {
                switch (value)
                {
                    case 1:
                        RB_Preset1.Checked = true;
                        RB_Preset2.Checked =
                        RB_Preset3.Checked = false;
                        break;
                    case 2:
                        RB_Preset2.Checked = true;
                        RB_Preset1.Checked =
                        RB_Preset3.Checked = false;
                        break;
                    case 3:
                        RB_Preset3.Checked = true;
                        RB_Preset1.Checked =
                        RB_Preset2.Checked = false;
                        break;
                }
            }
        }

        private void RB_Preset_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SelectedCommand = CommandPreset;
        }

        private async void BTN_LaunchWC3_Click(object sender, EventArgs e)
        {
            string LastInstallPath = Settings.InstallPath;
            if (!File.Exists(Path.Combine(LastInstallPath, "JNLoader.exe")))
            {
                OpenFileDialog FDialog = new OpenFileDialog
                {
                    Title = "실행 파일을 선택하세요.",
                    Filter = "워크래프트 EXE파일|JNLoader.exe;Warcraft III.exe;war3.exe"
                };
                if (FDialog.ShowDialog() != DialogResult.OK) return;
                Settings.InstallPath = LastInstallPath = Path.GetDirectoryName(FDialog.FileName);
                string MixPath = $"{LastInstallPath}\\Cirnix";
                if (!File.Exists(MixPath + ".mix"))
                {
                    File.WriteAllBytes(MixPath + ".mix", Global.Properties.Resources.Cirnix);
                    NativeMethods.WritePrivateProfileString("Cirnix", "Mana Bar", "0", MixPath + ".ini");
                    NativeMethods.WritePrivateProfileString("Cirnix", "Show AS & MS in Number", "1", MixPath + ".ini");
                }
            }
            if (Memory.Component.Warcraft3Info.Process != null)
                if (MetroDialog.YesNo("기존 프로세스 감지 됨", "Warcraft III 프로세스가 아직 실행 중입니다.\n종료하고 실행하시겠습니까?"))
                {
                    if (!Memory.Component.Warcraft3Info.Close())
                    {
                        MetroDialog.OK("액세스 오류", "Warcraft III 프로세스를 종료할 수 없었습니다.\n작업 관리자에서 수동으로 프로세스를 종료하세요.");
                        return;
                    }
                }
                else return;
            GameModule.StartWarcraft3(LastInstallPath, MetroDialog.Select("화면 표기 설정", "창 모드", "전체 창", "전체화면"));
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Hide();
                Globals.ListUpdate = i => { };
                TrayCheck();
                FormClosing -= MainForm_FormClosing;
                Close();
                Dispose();
            }
        }

        private void BTN_Analyzer_Click(object sender, EventArgs e)
        {
            selectProcess();
        }
    }
}
