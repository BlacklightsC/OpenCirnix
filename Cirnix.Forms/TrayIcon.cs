using Cirnix.Global;
using Cirnix.Worker;

using Newtonsoft.Json.Linq;

using System;
using System.ComponentModel;
using System.Windows.Forms;

using static Cirnix.Global.Globals;

namespace Cirnix.Forms
{
    public partial class TrayIcon : Form
    {
        private static int[] Latest;
        private static string LatestURL, HistoryURL;
        private MainForm main;
        private OptionForm option;
        private InfoForm info;
        private SelectProcess sepro;
        private ChannelChatForm channel;
        private RoomListForm room;
        private AdditionalToolForm tool;
        private HistoryForm history;

        public TrayIcon()
        {
            InitializeComponent();
            MainTrayIcon.Icon = Icon = Global.Properties.Resources.CirnixIcon;
        }

        private void TrayIcon_Shown(object o, EventArgs e)
        {
            try
            {
                Hide();
                GlobalHandle = Handle;
                Globals.ProgramShutDown = ProgramShutDown;
                InitFunction.InitCommand();
                InitFunction.InitHotkey();
                KeyboardHooker.HookStart();
                MainWorker.RunWorkers();
                CLRHook.Injector.InstallHookLib();
                channel = new ChannelChatForm();
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

        [System.Diagnostics.Conditional("DEBUG")]
        public void DebugWarcraftOutput()
        {
            Delay(200);
            Memory.Message.SendMsg(true, $"Debug Mode On, Version: {version[0]}.{version[1]}.{version[2]}.{version[3]}");
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
            option.ChannelChatState = delegate (bool b) { channel.ChatTimer.Enabled = b; };
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
                historyForm = InitHistoryForm
            };
            info.Show();
            info.Activate();
        }
        private void InitRoomListForm()
        {
            if (!(room == null
             || room.IsDisposed))
            {
                room.Activate();
                return;
            }
            room = new RoomListForm();
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
            if (string.IsNullOrEmpty(HistoryURL)) return;
            if (!(history == null
             || history.IsDisposed))
            {
                history.Activate();
                return;
            }
            history = new HistoryForm(HistoryURL);
            history.Show();
            history.Activate();
        }
        #endregion

        #region [    Check Latest Version    ]
        private void CheckLatestVersion()
        {
            BackgroundWorker VersionChecker;
            VersionChecker = new BackgroundWorker();
            VersionChecker.DoWork += new DoWorkEventHandler(VersionChecker_DoWork);
            VersionChecker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(VersionChecker_RunWorkerCompleted);
            Latest = new int[4];
            VersionChecker.RunWorkerAsync();
        }
        private void VersionChecker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(infoURL)) return;
            if (e.Error != null)
            {
                MetroDialog.OK("연결 오류", "업데이트 서버에 연결할 수 없습니다.");
                return;
            }
            isOnline = true;
            if (isUpdated) InitHistoryForm();
            if (version[0] > Latest[0]) return;
            else if (version[0] == Latest[0])
                if (version[1] > Latest[1]) return;
                else if (version[1] == Latest[1])
                    if (version[2] > Latest[2]) return;
                    else if (version[2] == Latest[2])
                        if (version[3] >= Latest[3]) return;
            if (MetroDialog.YesNo("업데이트 필요", $"최신 버전이 확인되었습니다.\n 현재: {version[0]}.{version[1]}.{version[2]}.{version[3]}\n 최신: {Latest[0]}.{Latest[1]}.{Latest[2]}.{Latest[3]}\n업데이트 하시겠습니까?"))
            {
                try
                {
                    main.Dispose();
                    option.Dispose();
                    info.Dispose();
                    channel.Dispose();
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
            if (string.IsNullOrWhiteSpace(infoURL)) return;
            JObject json = JObject.Parse(GetDataFromServer(infoURL));
            #region [    Cirnix Config    ]
            bool IsBeta = Settings.BetaUser;
            string[] latestTemp = json[IsBeta ? "Latest_Version" : "Recommanded_Version"].ToString().Split('.');
            for (int i = 0; i < 4; i++)
                Latest[i] = int.Parse(latestTemp[i]);
            LatestURL = json[IsBeta ? "Latest_URL" : "Recommanded_URL"].ToString();
            HistoryURL = json["History"].ToString();
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

        //protected override void WndProc(ref System.Windows.Forms.Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        case 0x312:
        //            Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
        //            KeyModifiers modifier = (KeyModifiers)((int)m.LParam & 0xFFFF);
        //            if (ForegroundWar3() && !States.IsChatBoxOpen)
        //            {
        //                var hotkey = hotkeyList.Find(item => item.vk == key);
        //                if (hotkey != null)
        //                {
        //                    Memory.Component.GameState state = States.CurrentGameState;
        //                    if (!(hotkey.onlyInGame
        //                     && state != Memory.Component.GameState.StartedGame
        //                     && state != Memory.Component.GameState.InGame))
        //                    {
        //                        hotkey.function(hotkey.fk);
        //                        if (!hotkey.recall)
        //                            return;
        //                    }
        //                }
        //            }
        //            hotkeyList.Pause(key);
        //            SendKeys.Send(Hotkey.GetSendKeyString(key));
        //            hotkeyList.Resume(key);
        //            break;
        //    }
        //    base.WndProc(ref m);
        //}

        public void ProgramShutDown()
        {
            MainTrayIcon.Visible = false;
            KeyboardHooker.HookEnd();
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
