using Cirnix.Global;

using MetroFramework.Forms;

using Newtonsoft.Json.Linq;

using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

using static Cirnix.Global.Globals;

namespace Cirnix.Forms
{
    internal sealed partial class InfoForm : MetroForm
    {
        BackgroundWorker VersionChecker;
        internal Action historyForm;
        internal static int[] Current;
        internal static int[] Recommanded;
        internal static int[] Latest;
        internal static string RecommandedURL;
        internal static string LatestURL;
        private bool IsUpdating = false;

        internal InfoForm()
        {
            InitializeComponent();
            Icon = Global.Properties.Resources.CirnixIcon;
            IsUpdating = true;
            Toggle_BetaUser.Checked = Settings.BetaUser;
            IsUpdating = false;
            VersionChecker = new BackgroundWorker();
            VersionChecker.DoWork += new DoWorkEventHandler(VersionChecker_DoWork);
            VersionChecker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(VersionChecker_RunWorkerCompleted);

            Version ver = Assembly.GetEntryAssembly().GetName().Version;
            Current = new int[4] { ver.Major, ver.Minor, ver.Build, ver.Revision };
            Recommanded = new int[4];
            Latest = new int[4];
            CurrentVersion.Text = string.Format("{0}.{1}.{2}.{3}", Current[0], Current[1], Current[2], Current[3]);
        }

        private void InfoForm_Shown(object sender, EventArgs e)
        {
            UpdateButton.Text = "업데이트";
            UpdateButton.Enabled = false;
            VersionChecker.RunWorkerAsync();
        }

        private void VersionChecker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(infoURL)) LatestVersion.Text = "서버 없음";
            else if (e.Error != null) LatestVersion.Text = "연결 실패";
            else VersionUpdate();
        }

        private void VersionUpdate()
        {
            int[] version = Settings.BetaUser ? Latest : Recommanded;
            LatestVersion.Text = string.Format("{0}.{1}.{2}.{3}", version[0], version[1], version[2], version[3]);
            for (int i = 0; i < 4; i++)
            {
                if (i != 3 && Current[i] == version[i]) continue;
                if (Current[i] >= version[i])
                {
                    UpdateButton.Text = "최신 버전";
                    UpdateButton.Enabled = false;
                }
                else
                {
                    UpdateButton.Text = "업데이트";
                    UpdateButton.Enabled = true;
                }
                break;
            }
        }

        private void VersionChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(infoURL)) return;
            JObject json = JObject.Parse(GetDataFromServer(infoURL));
            string[] latestTemp = json["Recommanded_Version"].ToString().Split('.');
            for (int i = 0; i < 4; i++)
                Recommanded[i] = int.Parse(latestTemp[i]);
            RecommandedURL = json["Recommanded_URL"].ToString();
            latestTemp = json["Latest_Version"].ToString().Split('.');
            for (int i = 0; i < 4; i++)
                Latest[i] = int.Parse(latestTemp[i]);
            LatestURL = json["Latest_URL"].ToString();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            new UpdateForm("Cirnix", Settings.BetaUser ? LatestURL : RecommandedURL).ShowDialog();
        }

        private bool IsEECorrect()
        {
            if (Settings.SmartKeyFlag != 503
             || Settings.KeyMap7 != 67
             || Settings.KeyMap8 != 78
             || Settings.KeyMap4 != 73
             || Settings.KeyMap5 != 79
             || Settings.KeyMap1 != 82
             || Settings.KeyMap2 != 57
             || Settings.CommandPreset3.IndexOf("치르노의 퍼펙트 산수교실") == -1)
                return false;
            return true;
        }

        private void HiddenBTN_Click(object sender, EventArgs e)
        {
            if(Settings.EEStatus)
            {
                Settings.EEStatus = false;
                Cursor = Cursors.Default;
                MetroDialog.OK("개발자 모드 해제", "개발자 모드가 해제되었습니다.\n더 이상 추가 기능을 사용하실 수 없습니다.");
                return;
            }
            if (!IsEECorrect()) return;
            Settings.EEStatus = true;
            MetroDialog.OK("개발자 모드 해금", "개발자 모드를 발견하셨습니다.\n일부 비공개 추가 기능을 사용하실 수 있습니다.\n명령어: !mh (맵핵)\n기능: 전체 방 리스트 보기");
        }

        private void HiddenBTN_MouseEnter(object sender, EventArgs e)
        {
            if (!IsEECorrect() && !Settings.EEStatus) return;
            Cursor = Cursors.Help;
        }

        private void HiddenBTN_MouseLeave(object sender, EventArgs e)
        {
            if (!IsEECorrect() && !Settings.EEStatus) return;
            Cursor = Cursors.Default;
        }

        private void CurrentVersion_Click(object sender, EventArgs e)
        {
            historyForm();
        }

        private void Toggle_BetaUser_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.BetaUser = Toggle_BetaUser.Checked;
            VersionUpdate();
        }
    }
}
