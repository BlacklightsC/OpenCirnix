using Cirnix.Forms.Update;
using Cirnix.Global;

using MetroFramework.Forms;

using System;
using System.ComponentModel;
using System.Reflection;

namespace Cirnix.Forms
{
    internal sealed partial class InfoForm : MetroForm
    {

        BackgroundWorker VersionChecker;
        internal Action historyForm;
        internal Action licenceForm;
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
            Current = new int[2] { ver.Major, ver.Minor };
            Recommanded = new int[2];
            Latest = new int[2];
            CurrentVersion.Text = $"{Current[0]}.{Current[1]}";
        }

        private void InfoForm_Shown(object sender, EventArgs e)
        {
            UpdateButton.Text = "업데이트";
            UpdateButton.Enabled = false;
            VersionChecker.RunWorkerAsync();
        }

        private void VersionChecker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) LatestVersion.Text = "연결 실패";
            else VersionUpdate();
        }

        private void VersionUpdate()
        {
            int[] version = Settings.BetaUser ? Latest : Recommanded;
            LatestVersion.Text = $"{version[0]}.{version[1]}";
            for (int i = 0; i < 2; i++)
            {
                if (i != 1 && Current[i] == version[i]) continue;
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
            ReleaseChecker.GetRelease();
            string[] latestTemp = ReleaseChecker.Recommanded.tag_name.Split('.');
            for (int i = 0; i < 2; i++)
                Recommanded[i] = int.Parse(latestTemp[i]);
            RecommandedURL = ReleaseChecker.Recommanded.assets[0].browser_download_url;
            latestTemp = ReleaseChecker.Latest.tag_name.Split('.');
            for (int i = 0; i < 2; i++)
                Latest[i] = int.Parse(latestTemp[i]);
            LatestURL = ReleaseChecker.Latest.assets[0].browser_download_url;
        }

        private void Update_Click(object sender, EventArgs e)
        {
            new UpdateForm(Global.Theme.Title, Settings.BetaUser ? LatestURL : RecommandedURL).ShowDialog();
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

        private void LicenceButton_Click(object sender, EventArgs e)
        {
            licenceForm();
        }
    }
}
