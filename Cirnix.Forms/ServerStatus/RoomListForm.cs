using Cirnix.Global;
using Cirnix.Memory;
using Cirnix.ServerStatus;

using CirnoLib.Format.BLPLib;
using CirnoLib.MPQ.Struct;

using Newtonsoft.Json.Linq;

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

using static Cirnix.Forms.Component;
using static Cirnix.Global.Globals;
using static Cirnix.ServerStatus.RoomWebDataBase;

namespace Cirnix.Forms.ServerStatus
{
    internal sealed partial class RoomListForm : DraggableLabelForm
    {
        private RoomListStatistics Statistics;
        private bool IsMapSearch = false, IsSearchResult = false;
        private RoomInformation.Field CurrentField;
        private string FilePath, FilterMapName = null;
        internal RoomListForm(string arg)
        {
            InitializeComponent();
            Icon = Global.Properties.Resources.CirnixIcon;
            Label_Title.MouseDown += new MouseEventHandler(Label_Title_MouseDown);
            Label_Title.MouseMove += new MouseEventHandler(Label_Title_MouseMove);
            Label_Title.MouseUp += new MouseEventHandler(Label_Title_MouseUp);
            TB_Search.Text = arg;
            MapImage.InitialImage = MapImage.ErrorImage = Properties.Resources.Unknown;
            FormEnable = false;
            RoomList.Items.Clear();
            ReleaseFormInfo();
            CB_DisplayAll.Visible = CB_ShowPrivate.Visible = false;
            CB_RealTimeSet.Location = new Point(8, 43); 
        }
        private void RoomListForm_Shown(object sender, EventArgs e)
        {
            if (!InitEvent())
                foreach (var item in infoList)
                    Invoked_Insert(item);
            DBInsert += item => Invoke(new Action<RoomInformation.Field>(Invoked_Insert), item);
            DBUpdate += item => Invoke(new Action<RoomInformation.Field>(Invoked_Update), item);
            DBDelete += item => Invoke(new Action<RoomInformation.Field>(Invoked_Delete), item);
            BeginFirstConnect += () => Invoke(new Action(Invoked_BeginFirstConnect));
            EndFirstConnect += () => Invoke(new Action(Invoked_EndFirstConnect));
            Disconnected += () => Invoke(new Action(Invoked_Disconnected));
            Connect();
        }
        private void RoomListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
            RemoveAllEvent();
            if (!(Statistics == null
             || Statistics.IsDisposed))
                Statistics.Dispose();
        }
        private void Invoked_Insert(RoomInformation.Field item)
        {
            if (!string.IsNullOrWhiteSpace(FilterMapName))
            {
                int length = 5;
                string first = Path.GetFileNameWithoutExtension(FilterMapName);
                if (first.Length > 2 && first[first.Length - 2] == '~') first = first.Substring(0, first.Length - 2);
                first = first.Substring(0, first.Length >= length ? length : (length = first.Length));
                string second = Path.GetFileNameWithoutExtension(item.mapname);
                if (second.Length > 2 && second[second.Length - 2] == '~') second = second.Substring(0, second.Length - 2);
                if (second.Length >= length && first.Equals(second.Substring(0, length), StringComparison.OrdinalIgnoreCase))
                {
                    StringBuilder Builder = new StringBuilder();
                    Builder.AppendFormat("[{0}] {1} - {2}"
                                       , ConvertAtTimeStamp(item.regdate).ToString("yyyy-MM-dd HH:mm:ss")
                                       , item.mapname, item.player0);
                    Builder.AppendLine();
                    File.AppendAllText("CirnixStartFilter.log", Builder.ToString());
                }
            }
            if (!CB_RealTimeSet.Checked) return;
            TB_Room.Text = infoList.Count.ToString();
            if (ListFilter(item)) return;
            RoomList.Items.Add(item);
            RefreshFormInfo();
        }
        private void Invoked_Update(RoomInformation.Field item)
        {
            if (!CB_RealTimeSet.Checked) return;
            for (int i = RoomList.Items.Count - 1; i >= 0; i--)
                if (item == RoomList.Items[i] as RoomInformation.Field)
                {
                    if (ListFilter(item))
                    {
                        RoomList.Items.RemoveAt(i);
                        RefreshFormInfo();
                    }
                    else RoomList.Items[i] = item;
                    return;
                }
        }
        private void Invoked_Delete(RoomInformation.Field item)
        {
            if (!CB_RealTimeSet.Checked) return;
            if (CurrentField == item)
            {
                CurrentField = null;
                ReleaseFormInfo();
            }
            TB_Room.Text = infoList.Count.ToString();
            if (ListFilter(item)) return;
            for (int i = RoomList.Items.Count - 1; i >= 0; i--)
                if (item == RoomList.Items[i] as RoomInformation.Field)
                {
                    RoomList.Items.RemoveAt(i);
                    RefreshFormInfo();
                    return;
                }
            
        }
        private void Invoked_BeginFirstConnect()
        {
            RoomList.Items.Clear();
        }
        private void Invoked_EndFirstConnect()
        {
            RefreshRoomList(null, null);
            RoomList.Focus();
        }
        private void Invoked_Disconnected()
        {
            Label_Loading.Text = "재 연결 하는 중 입니다...";
            FormEnable = false;
            BTN_Refresh.Enabled = false;
        }
        private void RefreshFormInfo()
        {
            int OpenRoom = 0;
            foreach (RoomInformation.Field item in RoomList.Items)
                if (item.status == "open") OpenRoom++;
            TB_WaitRoom.Text = OpenRoom.ToString();
            TB_Room.Text = infoList.Count.ToString();
        }
        private bool ListFilter(RoomInformation.Field item)
            => (!CB_ShowPrivate.Checked && item.flag == "private")
                || (!CB_DisplayAll.Checked && item.status != "open")
                || (!string.IsNullOrEmpty(TB_Search.Text) && IsMapSearch
                ? item.mapname.ToLower().IndexOf(TB_Search.Text.ToLower()) == -1
                : item.gname.ToLower().IndexOf(TB_Search.Text.ToLower()) == -1);

        private void ReleaseFormInfo()
        {
            MapImage.Image = null;
            Label_Status.Text =
            Label_Flag.Text =
            Label_MapExist.Text =
            TB_ID.Text =
            RTB_Name.Text =
            RTB_MapName.Text =
            TB_RegDate.Text =
            TB_StartTime.Text =
            TB_Player0.Text =
            TB_Player1.Text =
            TB_Player2.Text =
            TB_Player3.Text =
            TB_Player4.Text =
            TB_Player5.Text =
            TB_Player6.Text =
            TB_Player7.Text =
            TB_Player8.Text =
            TB_Player9.Text =
            TB_Player10.Text =
            TB_Player11.Text = string.Empty;
            TB_Player.Text = "0";
        }
        internal bool FormEnable {
            get => BTN_Refresh.Enabled;
            set {
                Label_Loading.Visible = !value;
                RoomList.Enabled =
                TB_Search.Enabled =
                BTN_ChangeType.Enabled =
                BTN_SearchPlayer.Enabled =
                BTN_Statistics.Enabled =
                CB_RealTimeSet.Enabled =
                CB_DisplayAll.Enabled =
                CB_ShowPrivate.Enabled = value;
                BTN_Refresh.Enabled = value ? !CB_RealTimeSet.Checked : value;
            }
        }
        private void RefreshRoomList(object sender, EventArgs e)
        {
            FormEnable = false;
            TB_WaitRoom.Text = TB_Room.Text = string.Empty;
            RoomList.SelectedIndex = -1;
            ReleaseFormInfo();
            StatusChanged(sender, e);
            FormEnable = true;
        }
        private void StatusChanged(object sender, EventArgs e)
        {
            RoomList.Items.Clear();
            foreach (var item in infoList)
            {
                if (ListFilter(item)) continue;
                RoomList.Items.Add(item);
            }
            RefreshFormInfo();
            if (IsSearchResult)
            {
                foreach (var item in infoList)
                {
                    if (item == CurrentField)
                    {
                        SetRoomInfo(item);
                        return;
                    }
                }
                IsSearchResult = false;
            }
            else
            {
                for (int i = RoomList.Items.Count - 1; i >= 0; i--)
                {
                    RoomInformation.Field item = RoomList.Items[i] as RoomInformation.Field;
                    if (item == CurrentField)
                    {
                        RoomList.SelectedIndex = i;
                        return;
                    }
                }
                RoomList.SelectedIndex = -1;
            }
            ReleaseFormInfo();
        }
        private void DirFileSearch(string path, string file)
        {
            try
            {
                string[] files = Directory.GetFiles(path, file);
                foreach (string f in files)
                {
                    FilePath = f;
                    return;
                }

                string[] dirs = Directory.GetDirectories(path);
                if (dirs.Length > 0)
                    foreach (string dir in dirs)
                        DirFileSearch(dir, file);
            }
            catch { }
        }
        private DateTime ConvertAtTimeStamp(int TimeStamp) => new DateTime(1970, 1, 1, 9, 0, 0).AddSeconds(TimeStamp);
        #region [    RoomList Event    ]
        private void RoomList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (RoomList.Items.Count == 0) return;
            Brush FontBrush;
            e.DrawBackground();
            if (e.Index == -1) return;
            var Target = RoomList.Items[e.Index] as RoomInformation.Field;
            if (Target == null) return;
            switch (Target.status)
            {
                case "started": FontBrush = Brushes.Red; break;
                case "full": FontBrush = Brushes.Orange; break;
                case "open":
                    switch (Target.flag)
                    {
                        case "private": FontBrush = Brushes.DarkOliveGreen; break;
                        case "public": FontBrush = Brushes.Black; break;
                        default: FontBrush = Brushes.BlueViolet; break;
                    }
                    break;
                case "loaded": FontBrush = Brushes.BlueViolet; break;
                default: FontBrush = Brushes.BlueViolet; break;
            }
            if (Target.flag == "private") e.Graphics.FillRectangle(new SolidBrush(Color.LightGreen), e.Bounds);
            e.Graphics.DrawString(RoomList.Items[e.Index].ToString(), e.Font, FontBrush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
        private void RoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RoomList.Items.Count == 0) return;
            if (RoomList.SelectedIndex == -1)
            {
                ReleaseFormInfo();
                return;
            }
            IsSearchResult = false;
            SetRoomInfo(RoomList.Items[RoomList.SelectedIndex] as RoomInformation.Field);
        }
        private void SetRoomInfo(RoomInformation.Field Target)
        {
            if (Target == null) return;
            CurrentField = Target;
            switch (Target.status)
            {
                case "started":
                    Label_Status.Text = "게임 중";
                    Label_Status.ForeColor = Color.Red;
                    break;
                case "full":
                    Label_Status.Text = "꽉 참";
                    Label_Status.ForeColor = Color.Orange;
                    break;
                case "loaded":
                    Label_Status.Text = "로딩 중";
                    Label_Status.ForeColor = Color.BlueViolet;
                    break;
                case "open":
                    Label_Status.Text = "대기실";
                    Label_Status.ForeColor = Color.Black;
                    break;
                default:
                    Label_Status.Text = Target.status;
                    Label_Status.ForeColor = Color.BlueViolet;
                    break;
            }
            switch (Target.flag)
            {
                case "private":
                    Label_Flag.Text = "비공개";
                    Label_Flag.ForeColor = Color.SeaGreen;
                    break;
                case "public":
                    Label_Flag.Text = "공개";
                    Label_Flag.ForeColor = Color.Black;
                    break;
                default:
                    Label_Flag.Text = Target.flag;
                    Label_Flag.ForeColor = Color.BlueViolet;
                    break;
            }
            TB_ID.Text = Target.gid.ToString();
            SetRTBText(ref RTB_Name, Target.gname, true, true, true);
            TB_RegDate.Text = ConvertAtTimeStamp(Target.regdate).ToString("yyyy-MM-dd HH:mm:ss");
            TB_StartTime.Text = Target.starttime != null ? ConvertAtTimeStamp(Convert.ToInt32(Target.starttime)).ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
            TB_Player0.Text = Target.player0 ?? string.Empty;
            TB_Player1.Text = Target.player1 ?? string.Empty;
            TB_Player2.Text = Target.player2 ?? string.Empty;
            TB_Player3.Text = Target.player3 ?? string.Empty;
            TB_Player4.Text = Target.player4 ?? string.Empty;
            TB_Player5.Text = Target.player5 ?? string.Empty;
            TB_Player6.Text = Target.player6 ?? string.Empty;
            TB_Player7.Text = Target.player7 ?? string.Empty;
            TB_Player8.Text = Target.player8 ?? string.Empty;
            TB_Player9.Text = Target.player9 ?? string.Empty;
            TB_Player10.Text = Target.player10 ?? string.Empty;
            TB_Player11.Text = Target.player11 ?? string.Empty;
            TB_Player.Text = Target.now_players.ToString();
            FilePath = string.Empty;
            string ResourceDataPath = $@"{ResourcePath}\MapThumbnail";
            if (!Directory.Exists(ResourceDataPath)) Directory.CreateDirectory(ResourceDataPath);
            string ResourceDataJson = $@"{ResourceDataPath}\{Target.mapname}.json";
            if (File.Exists(ResourceDataJson))
            {
                JObject json = JObject.Parse(File.ReadAllText(ResourceDataJson));
                SetRTBText(ref RTB_MapName, (json["Title"] as JValue)?.Value as string, true, true, true);
                if (!((json["Thumbnail"] as JValue)?.Value is string imagePath)) return;
                MapImage.Image = new Bitmap($@"{ResourceDataPath}\{imagePath}");
                Label_MapExist.Text = "맵 있음";
                Label_MapExist.ForeColor = Color.LimeGreen;
                DirFileSearch(DocumentPath + @"\Maps", Target.mapname);
                if (string.IsNullOrEmpty(FilePath))
                {
                    if (!string.IsNullOrEmpty(Settings.InstallPath)
                      && Directory.Exists(Settings.InstallPath + @"\Maps"))
                        DirFileSearch(Settings.InstallPath + @"\Maps", Target.mapname);
                    if (string.IsNullOrEmpty(FilePath))
                    {
                        Label_MapExist.Text = "맵 없음";
                        Label_MapExist.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                DirFileSearch(DocumentPath + @"\Maps", Target.mapname);
                if (string.IsNullOrEmpty(FilePath))
                {
                    if (!string.IsNullOrEmpty(Settings.InstallPath)
                      && Directory.Exists(Settings.InstallPath + @"\Maps"))
                        DirFileSearch(Settings.InstallPath + @"\Maps", Target.mapname);
                    if (string.IsNullOrEmpty(FilePath))
                    {
                        Label_MapExist.Text = "맵 없음";
                        Label_MapExist.ForeColor = Color.Red;
                        MapImage.Image = Properties.Resources.Unknown;
                        SetRTBText(ref RTB_MapName, Target.mapname, true, true, true);
                        return;
                    }
                }
                Label_MapExist.Text = "맵 있음";
                Label_MapExist.ForeColor = Color.LimeGreen;
                try
                {
                    using (W3MArchive map = new W3MArchive(FilePath, true, false))
                    {
                        byte[] thumbnail = map.Find("war3mapPreview.tga")?.File;
                        Bitmap image;
                        if (thumbnail == null)
                        {
                            thumbnail = map.Find("war3mapMap.blp")?.File;
                            BlpTexture blp = new BlpTexture(thumbnail);
                            image = new Bitmap(blp.Mipmaps[0].CreateStream());
                        }
                        else
                        {
                            image = TgaReader.Load(thumbnail);
                        }
                        JObject json = new JObject
                        {
                            { "Title", map.MapHeader.Name },
                            { "Thumbnail", $"{Target.mapname}.png" }
                        };
                        image.Save($@"{ResourceDataPath}\{Target.mapname}.png", ImageFormat.Png);
                        File.WriteAllText(ResourceDataJson, json.ToString());
                        SetRTBText(ref RTB_MapName, map.MapHeader.Name, true, true, true);
                        MapImage.Image = image;
                    }
                }
                catch
                {
                    MapImage.Image = Properties.Resources.Unknown;
                }               
            }
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Default);
        }
        #endregion
        private void BTN_ChangeType_Click(object sender, EventArgs e)
        {
            Label_Search.Text = (IsMapSearch = !IsMapSearch) ? "맵 필터:" : "방 필터:";
            if (!string.IsNullOrEmpty(TB_Search.Text)) StatusChanged(sender, e);
        }

        private void ServerStatus_Tick(object sender, EventArgs e) => StatusWebDataBase.GetServerStatusAsync();

        private void BTN_MapLog_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FilterMapName))
            {
                using (RoomListStartLogDialog SLD = new RoomListStartLogDialog())
                {
                    if (SLD.ShowDialog() != DialogResult.OK) return;
                    FilterMapName = SLD.MapName;
                }
                BTN_MapLog.Text = "중단";
            }
            else
            {
                FilterMapName = null;
                BTN_MapLog.Text = "기록";
            }
        }

        private void BTN_RoomJoin_Click(object sender, EventArgs e)
        {
            Join.RoomJoin(CurrentField.gname);
        }

        private void RoomListForm_Load(object sender, EventArgs e)
        {

        }

        private void Label_Loading_Click(object sender, EventArgs e)
        {

        }

        private void RoomList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point point = e.Location;
            int selectedIndex = RoomList.IndexFromPoint(point);
            if (selectedIndex != -1)
            {
                Join.RoomJoin(CurrentField.gname);
            }
        }

        private void BTN_SearchPlayer_Click(object sender, EventArgs e)
        {
            if (infoList.Count <= 0)
            {
                MetroDialog.OK("대기실 리스트 없음", "대기실 리스트가 존재하지 않습니다.\n대기실 리스트를 새로고침하여 방을 불러와주세요.");
                return;
            }
            using (RoomListSearchPlayerDialog SPD = new RoomListSearchPlayerDialog { infoList = infoList })
            {
                if (SPD.ShowDialog() != DialogResult.OK) return;
                if (SPD.ResultIndex == -1)
                {
                    MetroDialog.OK("플레이어를 찾을 수 없음", SPD.PlayerName + "(을)를 찾을 수 없습니다.\n서버에 접속해있지 않거나, 게임 중이 아닐 수도 있습니다.");
                    return;
                }
                RoomList.SelectedIndex = -1;
                IsSearchResult = true;
                SetRoomInfo(infoList[SPD.ResultIndex]);
            }
        }
        private void BTN_Statistics_Click(object sender, EventArgs e)
        {
            if (infoList.Count <= 0)
            {
                MetroDialog.OK("대기실 리스트 없음", "대기실 리스트가 존재하지 않습니다.\n대기실 리스트를 새로고침하여 방을 불러와주세요.");
                return;
            }
            if (!(Statistics == null
             || Statistics.IsDisposed))
            {
                Statistics.Activate();
                return;
            }
            Statistics = new RoomListStatistics(infoList);
            Statistics.Show();
        }
    }
}
