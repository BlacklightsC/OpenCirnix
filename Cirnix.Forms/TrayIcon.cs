using Cirnix.Forms.ServerStatus;
using Cirnix.Forms.Update;
using Cirnix.Global;
using Cirnix.KeyHook;
using Cirnix.Worker;

using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using static Cirnix.Global.Globals;
using static Cirnix.Global.NativeMethods;

namespace Cirnix.Forms
{
    public partial class TrayIcon : Form
    {
        private static int[] Latest;
        private static string LatestURL;
        private MainForm main;
        private OptionForm option;
        private InfoForm info;
        private SelectProcess sepro;
        private ChannelChatForm channel;
        private RoomListForm room;
        private AdditionalToolForm tool;
        //private HistoryForm history;
        private LicenceForm licenceForm;

        public TrayIcon()
        {
            InitializeComponent();
            bool IsUpdated = false;
            if (File.Exists("update.tmp"))
            {
                File.Delete("update.tmp");
                IsUpdated = true;
            }
            InitGlobal(IsUpdated);
            MainTrayIcon.Icon = Icon = Global.Properties.Resources.CirnixIcon;
        }

        private void TrayIcon_Shown(object o, EventArgs e)
        {
            try
            {
                Hide();
                GlobalHandle = Handle;
                Globals.ProgramShutDown = ProgramShutDown;
                InitFunction.Init();
                KeyboardHooker.HookStart();
                if (Settings.IsFixClipboard)
                    ClipboardConverter.FixStart();
                MainWorker.RunWorkers();
                commandList.Register("rl", "기", args => Invoke(new Action<string[]>(InitRoomListForm), new object[] { args }));
                channel = new ChannelChatForm();
                InitBanList();
                channel.ChatTimer.Enabled = Settings.IsChannelChatDetect;
                InitMainForm();
                main.Show();
                main.Activate();
                CheckLatestVersion();
                DebugWarcraftOutput();
            }
            catch (Exception ex)
            {
                ExceptionSender.ExceptionSendAsync(ex, true);
                MessageBox.Show(this, "설정 불러오기에 실패하여, 설정을 초기화 해야합니다.", "불러오기 실패", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                Application.ExitThread();
                Environment.Exit(0);
            }
        }

        #region [    Initialize Form    ]
        private void TrayCheck()
        {
            MainTrayIcon.BalloonTipTitle = $"{Theme.Title} v{version[0]}.{version[1]}";
            MainTrayIcon.BalloonTipText = "여기서 창을 다시 열수있어요!";
            MainTrayIcon.ShowBalloonTip(5000);
        }

        [Conditional("DEBUG")]
        public async void DebugWarcraftOutput()
        {
            await Task.Delay(3000);
            Memory.Message.SendMsg(true, $"Debug Mode On, Version: {version[0]}.{version[1]}");
        }

        private void InitBanList()
        {
            List<BanlistModel> list = Memory.SaveBanlistUsers.Load();
            if (list != null)
                foreach (BanlistModel banlistModel in list)
                    if (banlistModel != null)
                        Memory.BanList.Add(banlistModel);
        }

        private void InitMainForm()
        {
            if (!(main == null
             || main.IsDisposed))
            {
                main.Activate();
                return;
            }
            main = new MainForm
            {
                optionForm = InitOptionForm,
                infoForm = InitInfoForm,
                roomListForm = InitRoomListForm,
                additonalToolForm = InitAdditionalToolForm,
                TrayCheck = TrayCheck,
                selectProcess = SelectProcessForm
            };

            ListUpdate = main.InvokedListUpdate;
            main.Show();
            main.Activate();
        }

        private void SelectProcessForm()
        {
            if (!(sepro == null
                || sepro.IsDisposed))
            {
                sepro.Activate();
                return;
            }
            sepro = new SelectProcess();
            sepro.Show();
            sepro.Activate();
        }

        private void InitOptionForm()
        {
            if (!(option == null
             || option.IsDisposed))
            {
                option.Activate();
                return;
            }
            try
            {
                option = new OptionForm();
            }
            catch (Exception ex)
            {
                ExceptionSender.ExceptionSendAsync(ex, true);
                MessageBox.Show(this, "설정 불러오기에 실패하여, 설정을 초기화 해야합니다.", "불러오기 실패", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                Application.ExitThread();
                Environment.Exit(0);
                return;
            }
            option.ChannelChatState = b => channel.ChatTimer.Enabled = b;
            option.Show();
            option.Activate();
        }
        private void InitInfoForm()
        {
            if (!(info == null
             || info.IsDisposed))
            {
                info.Activate();
                return;
            }
            info = new InfoForm
            {
                historyForm = InitHistoryForm,
                licenceForm = LicenceForm
            };
            info.Show();
            info.Activate();
        }

        private void LicenceForm()
        {
            if (!(licenceForm == null
                || licenceForm.IsDisposed))
            {
                sepro.Activate();
                return;
            }
            licenceForm = new LicenceForm();
            licenceForm.Show();
            licenceForm.Activate();
        }
        private void InitRoomListForm(string[] args)
        {
            string value = string.Empty;
            if (args != null)
            {
                StringBuilder arg = new StringBuilder();
                for (int i = 1; i < args.Length; i++)
                {
                    arg.Append(args[i]);
                    if (i + 1 != args.Length) arg.Append(" ");
                }
                value = arg.ToString();
            }
            if (!(room == null
             || room.IsDisposed))
            {
                room.Activate();
                return;
            }
            room = new RoomListForm(value);
            room.Show();
            room.Activate();
        }
        private void InitAdditionalToolForm()
        {
            if (!(tool == null
             || tool.IsDisposed))
            {
                tool.Activate();
                return;
            }
            tool = new AdditionalToolForm();
            tool.Show();
            tool.Activate();
        }
        private void InitHistoryForm()
        {
            if (string.IsNullOrEmpty(ReleaseChecker.HistoryURL)) return;
            Process.Start(ReleaseChecker.HistoryURL);

            //if (!(history == null
            // || history.IsDisposed))
            //{
            //    history.Activate();
            //    return;
            //}
            //history = new HistoryForm(HistoryURL);
            //history.Show();
            //history.Activate();
        }
        #endregion

        #region [    Check Latest Version    ]
        private void CheckLatestVersion()
        {
            BackgroundWorker VersionChecker;
            VersionChecker = new BackgroundWorker();
            VersionChecker.DoWork += new DoWorkEventHandler(VersionChecker_DoWork);
            VersionChecker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(VersionChecker_RunWorkerCompleted);
            Latest = new int[2];
            VersionChecker.RunWorkerAsync();
        }
        private void VersionChecker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MetroDialog.OK("연결 오류", "업데이트 서버에 연결할 수 없습니다.");
                return;
            }
            isOnline = true;
            if (isUpdated) InitHistoryForm();
            if (version[0] > Latest[0]) return;
            else if (version[0] == Latest[0])
                if (version[1] >= Latest[1]) return;
            if (MetroDialog.YesNo("업데이트 필요", $"최신 버전이 확인되었습니다.\n 현재: {version[0]}.{version[1]}\n 최신: {Latest[0]}.{Latest[1]}\n업데이트 하시겠습니까?"))
            {
                try
                {
                    if (main != null)
                        main.Dispose();
                    if (option != null)
                        option.Dispose();
                    if (info != null)
                        info.Dispose();
                    if (channel != null)
                        channel.Dispose();
                    if (sepro != null)
                        sepro.Dispose();
                    MainTrayIcon.Visible = false;
                }
                catch { }
                finally
                {
                    new UpdateForm("Cirnix", LatestURL).ShowDialog();
                }
            }
        }
        private void VersionChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            #region [    Cirnix Config    ]
            bool IsBeta = Settings.BetaUser;
            
            string[] latestTemp = (IsBeta ? ReleaseChecker.Latest.tag_name : ReleaseChecker.Recommanded.tag_name).Split('.');
            for (int i = 0; i < 2; i++)
                Latest[i] = int.Parse(latestTemp[i]);
            LatestURL = IsBeta ? ReleaseChecker.Latest.assets[0].browser_download_url : ReleaseChecker.Recommanded.assets[0].browser_download_url;
            #endregion
        }
        #endregion

        #region [    ContextMenuStrip Event    ]
        private void OpenWindow_Click(object sender, EventArgs e)
        {
            InitMainForm();
        }
        private void OpenRoomList_Click(object sender, EventArgs e)
        {
            InitRoomListForm(null);
        }
        private void OpenAnalyzer_Click(object sender, EventArgs e)
        {

        }
        private void OpenAdditionalTool_Click(object sender, EventArgs e)
        {
            InitAdditionalToolForm();
        }
        private void Option_Click(object sender, EventArgs e)
        {
            InitOptionForm();
        }
        private void Information_Click(object sender, EventArgs e)
        {
            InitInfoForm();
        }
        private void ShutDown_Click(object sender, EventArgs e)
        {
            ProgramShutDown();
        }
        #endregion

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0308:    // WM_DRAWCLIPBOARD
                    if (ClipboardConverter.IsBusy) break;
                    ClipboardConverter.IsBusy = true;
                    if (ClipboardConverter.IsUTF8)
                    {
                        ClipboardConverter.IsUTF8 = false;
                        string text = ClipboardConverter.GetUTF8Text();
                        if (text == null) break;
                        try
                        {
                            Clipboard.SetText(text);
                            ClipboardConverter.SetUTF8Text(text);
                        }
                        catch
                        {
                            // ExternalException : 요청한 클립보드 작업을 수행하지 못했습니다.
                        }
                    }
                    else
                    {
                        ClipboardConverter.SetUTF8Text(Clipboard.GetText());
                    }
                    SendMessage(ClipboardConverter.ChainedWnd, m.Msg, m.WParam, m.LParam);
                    ClipboardConverter.IsBusy = false;
                    break;

                case 0x030D:    // WM_CHANGECBCHAIN
                    if (ClipboardConverter.ChainedWnd == m.WParam)
                        ClipboardConverter.ChainedWnd = m.LParam;
                    else
                        SendMessage(ClipboardConverter.ChainedWnd, m.Msg, m.WParam, m.LParam);
                    break;
            }
            base.WndProc(ref m);
        }

        public void ProgramShutDown()
        {
            MainTrayIcon.Visible = false;
            KeyboardHooker.HookEnd();
            if (Settings.IsFixClipboard)
                ClipboardConverter.FixEnd();
            try
            {
                Application.Exit();
            }
            catch
            {
                Application.Exit();
            }
        }
    }
}
