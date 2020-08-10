namespace Cirnix.Forms.ServerStatus
{
    partial class RoomListForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Label_Title = new System.Windows.Forms.Label();
            this.RoomList = new System.Windows.Forms.ListBox();
            this.TB_ID = new System.Windows.Forms.TextBox();
            this.Label_ID = new System.Windows.Forms.Label();
            this.Label_Flag = new System.Windows.Forms.Label();
            this.RTB_MapName = new System.Windows.Forms.RichTextBox();
            this.Label_Status = new System.Windows.Forms.Label();
            this.Label_RegDate = new System.Windows.Forms.Label();
            this.TB_RegDate = new System.Windows.Forms.TextBox();
            this.TB_Player0 = new System.Windows.Forms.TextBox();
            this.Label_Player0 = new System.Windows.Forms.Label();
            this.TB_Player1 = new System.Windows.Forms.TextBox();
            this.Label_Player1 = new System.Windows.Forms.Label();
            this.TB_Player2 = new System.Windows.Forms.TextBox();
            this.Label_Player2 = new System.Windows.Forms.Label();
            this.TB_Player5 = new System.Windows.Forms.TextBox();
            this.Label_Player5 = new System.Windows.Forms.Label();
            this.TB_Player4 = new System.Windows.Forms.TextBox();
            this.Label_Player4 = new System.Windows.Forms.Label();
            this.TB_Player3 = new System.Windows.Forms.TextBox();
            this.Label_Player3 = new System.Windows.Forms.Label();
            this.TB_Player11 = new System.Windows.Forms.TextBox();
            this.Label_Player11 = new System.Windows.Forms.Label();
            this.TB_Player10 = new System.Windows.Forms.TextBox();
            this.Label_Player10 = new System.Windows.Forms.Label();
            this.TB_Player9 = new System.Windows.Forms.TextBox();
            this.Label_Player9 = new System.Windows.Forms.Label();
            this.TB_Player8 = new System.Windows.Forms.TextBox();
            this.Label_Player8 = new System.Windows.Forms.Label();
            this.TB_Player7 = new System.Windows.Forms.TextBox();
            this.Label_Player7 = new System.Windows.Forms.Label();
            this.TB_Player6 = new System.Windows.Forms.TextBox();
            this.Label_Player6 = new System.Windows.Forms.Label();
            this.Label_Player = new System.Windows.Forms.Label();
            this.TB_Player = new System.Windows.Forms.TextBox();
            this.BTN_Refresh = new System.Windows.Forms.Button();
            this.CB_RealTimeSet = new System.Windows.Forms.CheckBox();
            this.CB_DisplayAll = new System.Windows.Forms.CheckBox();
            this.CB_ShowPrivate = new System.Windows.Forms.CheckBox();
            this.Label_Current = new System.Windows.Forms.Label();
            this.TB_WaitRoom = new System.Windows.Forms.TextBox();
            this.Label_WaitRoom = new System.Windows.Forms.Label();
            this.TB_Room = new System.Windows.Forms.TextBox();
            this.Label_Room = new System.Windows.Forms.Label();
            this.TB_Search = new System.Windows.Forms.TextBox();
            this.Label_Search = new System.Windows.Forms.Label();
            this.Label_MapExist = new System.Windows.Forms.Label();
            this.Label_Loading = new System.Windows.Forms.Label();
            this.BTN_ChangeType = new System.Windows.Forms.Button();
            this.MapImage = new System.Windows.Forms.PictureBox();
            this.TB_StartTime = new System.Windows.Forms.TextBox();
            this.Label_StartTime = new System.Windows.Forms.Label();
            this.BTN_SearchPlayer = new System.Windows.Forms.Button();
            this.BTN_Statistics = new System.Windows.Forms.Button();
            this.BTN_ReserveRoom = new System.Windows.Forms.Button();
            this.ServerStatus = new System.Windows.Forms.Timer(this.components);
            this.BTN_MapLog = new System.Windows.Forms.Button();
            this.BTN_RoomJoin = new System.Windows.Forms.Button();
            this.RTB_Name = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MapImage)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_Title
            // 
            this.Label_Title.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_Title.Location = new System.Drawing.Point(110, 10);
            this.Label_Title.Margin = new System.Windows.Forms.Padding(105, 0, 105, 0);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(160, 15);
            this.Label_Title.TabIndex = 0;
            this.Label_Title.Text = "M16 서버 - 방 리스트 뷰어";
            this.Label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RoomList
            // 
            this.RoomList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.RoomList.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RoomList.ItemHeight = 15;
            this.RoomList.Items.AddRange(new object[] {
            ""});
            this.RoomList.Location = new System.Drawing.Point(8, 105);
            this.RoomList.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.RoomList.Name = "RoomList";
            this.RoomList.Size = new System.Drawing.Size(175, 364);
            this.RoomList.TabIndex = 1;
            this.RoomList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.RoomList_DrawItem);
            this.RoomList.SelectedIndexChanged += new System.EventHandler(this.RoomList_SelectedIndexChanged);
            this.RoomList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RoomList_MouseDoubleClick);
            // 
            // TB_ID
            // 
            this.TB_ID.BackColor = System.Drawing.Color.White;
            this.TB_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_ID.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_ID.Location = new System.Drawing.Point(340, 31);
            this.TB_ID.Margin = new System.Windows.Forms.Padding(0);
            this.TB_ID.Name = "TB_ID";
            this.TB_ID.ReadOnly = true;
            this.TB_ID.Size = new System.Drawing.Size(30, 15);
            this.TB_ID.TabIndex = 3;
            // 
            // Label_ID
            // 
            this.Label_ID.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_ID.Location = new System.Drawing.Point(332, 30);
            this.Label_ID.Margin = new System.Windows.Forms.Padding(0);
            this.Label_ID.Name = "Label_ID";
            this.Label_ID.Size = new System.Drawing.Size(8, 15);
            this.Label_ID.TabIndex = 5;
            this.Label_ID.Text = "#";
            this.Label_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Flag
            // 
            this.Label_Flag.BackColor = System.Drawing.Color.White;
            this.Label_Flag.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_Flag.Location = new System.Drawing.Point(240, 30);
            this.Label_Flag.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Flag.Name = "Label_Flag";
            this.Label_Flag.Size = new System.Drawing.Size(43, 15);
            this.Label_Flag.TabIndex = 6;
            this.Label_Flag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RTB_MapName
            // 
            this.RTB_MapName.BackColor = System.Drawing.Color.White;
            this.RTB_MapName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB_MapName.DetectUrls = false;
            this.RTB_MapName.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.RTB_MapName.Location = new System.Drawing.Point(196, 66);
            this.RTB_MapName.Margin = new System.Windows.Forms.Padding(1);
            this.RTB_MapName.Multiline = false;
            this.RTB_MapName.Name = "RTB_MapName";
            this.RTB_MapName.ReadOnly = true;
            this.RTB_MapName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.RTB_MapName.Size = new System.Drawing.Size(176, 15);
            this.RTB_MapName.TabIndex = 8;
            this.RTB_MapName.Text = "";
            // 
            // Label_Status
            // 
            this.Label_Status.BackColor = System.Drawing.Color.White;
            this.Label_Status.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_Status.Location = new System.Drawing.Point(196, 30);
            this.Label_Status.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(47, 15);
            this.Label_Status.TabIndex = 2;
            this.Label_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_RegDate
            // 
            this.Label_RegDate.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_RegDate.Location = new System.Drawing.Point(196, 263);
            this.Label_RegDate.Margin = new System.Windows.Forms.Padding(0);
            this.Label_RegDate.Name = "Label_RegDate";
            this.Label_RegDate.Size = new System.Drawing.Size(61, 15);
            this.Label_RegDate.TabIndex = 9;
            this.Label_RegDate.Text = "생성 일시 :";
            this.Label_RegDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_RegDate
            // 
            this.TB_RegDate.BackColor = System.Drawing.Color.White;
            this.TB_RegDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_RegDate.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_RegDate.Location = new System.Drawing.Point(260, 264);
            this.TB_RegDate.Margin = new System.Windows.Forms.Padding(1);
            this.TB_RegDate.Name = "TB_RegDate";
            this.TB_RegDate.ReadOnly = true;
            this.TB_RegDate.Size = new System.Drawing.Size(110, 15);
            this.TB_RegDate.TabIndex = 10;
            this.TB_RegDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_Player0
            // 
            this.TB_Player0.BackColor = System.Drawing.Color.White;
            this.TB_Player0.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Player0.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_Player0.Location = new System.Drawing.Point(216, 298);
            this.TB_Player0.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Player0.Name = "TB_Player0";
            this.TB_Player0.ReadOnly = true;
            this.TB_Player0.Size = new System.Drawing.Size(125, 15);
            this.TB_Player0.TabIndex = 14;
            // 
            // Label_Player0
            // 
            this.Label_Player0.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Player0.Location = new System.Drawing.Point(196, 297);
            this.Label_Player0.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Player0.Name = "Label_Player0";
            this.Label_Player0.Size = new System.Drawing.Size(19, 15);
            this.Label_Player0.TabIndex = 13;
            this.Label_Player0.Text = "1";
            this.Label_Player0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Player1
            // 
            this.TB_Player1.BackColor = System.Drawing.Color.White;
            this.TB_Player1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Player1.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_Player1.Location = new System.Drawing.Point(216, 312);
            this.TB_Player1.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Player1.Name = "TB_Player1";
            this.TB_Player1.ReadOnly = true;
            this.TB_Player1.Size = new System.Drawing.Size(125, 15);
            this.TB_Player1.TabIndex = 16;
            // 
            // Label_Player1
            // 
            this.Label_Player1.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Player1.Location = new System.Drawing.Point(196, 311);
            this.Label_Player1.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Player1.Name = "Label_Player1";
            this.Label_Player1.Size = new System.Drawing.Size(19, 15);
            this.Label_Player1.TabIndex = 15;
            this.Label_Player1.Text = "2";
            this.Label_Player1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Player2
            // 
            this.TB_Player2.BackColor = System.Drawing.Color.White;
            this.TB_Player2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Player2.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_Player2.Location = new System.Drawing.Point(216, 326);
            this.TB_Player2.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Player2.Name = "TB_Player2";
            this.TB_Player2.ReadOnly = true;
            this.TB_Player2.Size = new System.Drawing.Size(125, 15);
            this.TB_Player2.TabIndex = 18;
            // 
            // Label_Player2
            // 
            this.Label_Player2.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Player2.Location = new System.Drawing.Point(196, 325);
            this.Label_Player2.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Player2.Name = "Label_Player2";
            this.Label_Player2.Size = new System.Drawing.Size(19, 15);
            this.Label_Player2.TabIndex = 17;
            this.Label_Player2.Text = "3";
            this.Label_Player2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Player5
            // 
            this.TB_Player5.BackColor = System.Drawing.Color.White;
            this.TB_Player5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Player5.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_Player5.Location = new System.Drawing.Point(216, 368);
            this.TB_Player5.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Player5.Name = "TB_Player5";
            this.TB_Player5.ReadOnly = true;
            this.TB_Player5.Size = new System.Drawing.Size(125, 15);
            this.TB_Player5.TabIndex = 24;
            // 
            // Label_Player5
            // 
            this.Label_Player5.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Player5.Location = new System.Drawing.Point(196, 367);
            this.Label_Player5.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Player5.Name = "Label_Player5";
            this.Label_Player5.Size = new System.Drawing.Size(19, 15);
            this.Label_Player5.TabIndex = 23;
            this.Label_Player5.Text = "6";
            this.Label_Player5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Player4
            // 
            this.TB_Player4.BackColor = System.Drawing.Color.White;
            this.TB_Player4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Player4.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_Player4.Location = new System.Drawing.Point(216, 354);
            this.TB_Player4.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Player4.Name = "TB_Player4";
            this.TB_Player4.ReadOnly = true;
            this.TB_Player4.Size = new System.Drawing.Size(125, 15);
            this.TB_Player4.TabIndex = 22;
            // 
            // Label_Player4
            // 
            this.Label_Player4.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Player4.Location = new System.Drawing.Point(196, 353);
            this.Label_Player4.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Player4.Name = "Label_Player4";
            this.Label_Player4.Size = new System.Drawing.Size(19, 15);
            this.Label_Player4.TabIndex = 21;
            this.Label_Player4.Text = "5";
            this.Label_Player4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Player3
            // 
            this.TB_Player3.BackColor = System.Drawing.Color.White;
            this.TB_Player3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Player3.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_Player3.Location = new System.Drawing.Point(216, 340);
            this.TB_Player3.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Player3.Name = "TB_Player3";
            this.TB_Player3.ReadOnly = true;
            this.TB_Player3.Size = new System.Drawing.Size(125, 15);
            this.TB_Player3.TabIndex = 20;
            // 
            // Label_Player3
            // 
            this.Label_Player3.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Player3.Location = new System.Drawing.Point(196, 339);
            this.Label_Player3.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Player3.Name = "Label_Player3";
            this.Label_Player3.Size = new System.Drawing.Size(19, 15);
            this.Label_Player3.TabIndex = 19;
            this.Label_Player3.Text = "4\\";
            this.Label_Player3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Player11
            // 
            this.TB_Player11.BackColor = System.Drawing.Color.White;
            this.TB_Player11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Player11.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_Player11.Location = new System.Drawing.Point(216, 452);
            this.TB_Player11.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Player11.Name = "TB_Player11";
            this.TB_Player11.ReadOnly = true;
            this.TB_Player11.Size = new System.Drawing.Size(125, 15);
            this.TB_Player11.TabIndex = 36;
            // 
            // Label_Player11
            // 
            this.Label_Player11.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Player11.Location = new System.Drawing.Point(196, 451);
            this.Label_Player11.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Player11.Name = "Label_Player11";
            this.Label_Player11.Size = new System.Drawing.Size(19, 15);
            this.Label_Player11.TabIndex = 35;
            this.Label_Player11.Text = "12";
            this.Label_Player11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Player10
            // 
            this.TB_Player10.BackColor = System.Drawing.Color.White;
            this.TB_Player10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Player10.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_Player10.Location = new System.Drawing.Point(216, 438);
            this.TB_Player10.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Player10.Name = "TB_Player10";
            this.TB_Player10.ReadOnly = true;
            this.TB_Player10.Size = new System.Drawing.Size(125, 15);
            this.TB_Player10.TabIndex = 34;
            // 
            // Label_Player10
            // 
            this.Label_Player10.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Player10.Location = new System.Drawing.Point(196, 437);
            this.Label_Player10.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Player10.Name = "Label_Player10";
            this.Label_Player10.Size = new System.Drawing.Size(19, 15);
            this.Label_Player10.TabIndex = 33;
            this.Label_Player10.Text = "11";
            this.Label_Player10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Player9
            // 
            this.TB_Player9.BackColor = System.Drawing.Color.White;
            this.TB_Player9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Player9.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_Player9.Location = new System.Drawing.Point(216, 424);
            this.TB_Player9.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Player9.Name = "TB_Player9";
            this.TB_Player9.ReadOnly = true;
            this.TB_Player9.Size = new System.Drawing.Size(125, 15);
            this.TB_Player9.TabIndex = 32;
            // 
            // Label_Player9
            // 
            this.Label_Player9.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Player9.Location = new System.Drawing.Point(196, 423);
            this.Label_Player9.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Player9.Name = "Label_Player9";
            this.Label_Player9.Size = new System.Drawing.Size(19, 15);
            this.Label_Player9.TabIndex = 31;
            this.Label_Player9.Text = "10";
            this.Label_Player9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Player8
            // 
            this.TB_Player8.BackColor = System.Drawing.Color.White;
            this.TB_Player8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Player8.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_Player8.Location = new System.Drawing.Point(216, 410);
            this.TB_Player8.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Player8.Name = "TB_Player8";
            this.TB_Player8.ReadOnly = true;
            this.TB_Player8.Size = new System.Drawing.Size(125, 15);
            this.TB_Player8.TabIndex = 30;
            // 
            // Label_Player8
            // 
            this.Label_Player8.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Player8.Location = new System.Drawing.Point(196, 409);
            this.Label_Player8.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Player8.Name = "Label_Player8";
            this.Label_Player8.Size = new System.Drawing.Size(19, 15);
            this.Label_Player8.TabIndex = 29;
            this.Label_Player8.Text = "9";
            this.Label_Player8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Player7
            // 
            this.TB_Player7.BackColor = System.Drawing.Color.White;
            this.TB_Player7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Player7.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_Player7.Location = new System.Drawing.Point(216, 396);
            this.TB_Player7.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Player7.Name = "TB_Player7";
            this.TB_Player7.ReadOnly = true;
            this.TB_Player7.Size = new System.Drawing.Size(125, 15);
            this.TB_Player7.TabIndex = 28;
            // 
            // Label_Player7
            // 
            this.Label_Player7.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Player7.Location = new System.Drawing.Point(196, 395);
            this.Label_Player7.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Player7.Name = "Label_Player7";
            this.Label_Player7.Size = new System.Drawing.Size(19, 15);
            this.Label_Player7.TabIndex = 27;
            this.Label_Player7.Text = "8";
            this.Label_Player7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Player6
            // 
            this.TB_Player6.BackColor = System.Drawing.Color.White;
            this.TB_Player6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Player6.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_Player6.Location = new System.Drawing.Point(216, 382);
            this.TB_Player6.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Player6.Name = "TB_Player6";
            this.TB_Player6.ReadOnly = true;
            this.TB_Player6.Size = new System.Drawing.Size(125, 15);
            this.TB_Player6.TabIndex = 26;
            // 
            // Label_Player6
            // 
            this.Label_Player6.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Player6.Location = new System.Drawing.Point(196, 381);
            this.Label_Player6.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Player6.Name = "Label_Player6";
            this.Label_Player6.Size = new System.Drawing.Size(19, 15);
            this.Label_Player6.TabIndex = 25;
            this.Label_Player6.Text = "7";
            this.Label_Player6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Player
            // 
            this.Label_Player.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Player.Location = new System.Drawing.Point(358, 311);
            this.Label_Player.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Player.Name = "Label_Player";
            this.Label_Player.Size = new System.Drawing.Size(12, 15);
            this.Label_Player.TabIndex = 37;
            this.Label_Player.Text = "명";
            this.Label_Player.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Player
            // 
            this.TB_Player.BackColor = System.Drawing.Color.White;
            this.TB_Player.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Player.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_Player.Location = new System.Drawing.Point(344, 312);
            this.TB_Player.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Player.Name = "TB_Player";
            this.TB_Player.ReadOnly = true;
            this.TB_Player.Size = new System.Drawing.Size(15, 15);
            this.TB_Player.TabIndex = 38;
            this.TB_Player.Text = "0";
            this.TB_Player.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BTN_Refresh
            // 
            this.BTN_Refresh.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.BTN_Refresh.Location = new System.Drawing.Point(108, 28);
            this.BTN_Refresh.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_Refresh.Name = "BTN_Refresh";
            this.BTN_Refresh.Size = new System.Drawing.Size(75, 45);
            this.BTN_Refresh.TabIndex = 39;
            this.BTN_Refresh.Text = "새로고침";
            this.BTN_Refresh.UseVisualStyleBackColor = true;
            this.BTN_Refresh.Click += new System.EventHandler(this.RefreshRoomList);
            // 
            // CB_RealTimeSet
            // 
            this.CB_RealTimeSet.BackColor = System.Drawing.Color.Transparent;
            this.CB_RealTimeSet.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CB_RealTimeSet.Checked = true;
            this.CB_RealTimeSet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_RealTimeSet.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.CB_RealTimeSet.Location = new System.Drawing.Point(8, 28);
            this.CB_RealTimeSet.Margin = new System.Windows.Forms.Padding(1);
            this.CB_RealTimeSet.Name = "CB_RealTimeSet";
            this.CB_RealTimeSet.Size = new System.Drawing.Size(100, 16);
            this.CB_RealTimeSet.TabIndex = 40;
            this.CB_RealTimeSet.Text = "실시간 데이터";
            this.CB_RealTimeSet.UseVisualStyleBackColor = false;
            this.CB_RealTimeSet.CheckedChanged += new System.EventHandler(this.RefreshRoomList);
            // 
            // CB_DisplayAll
            // 
            this.CB_DisplayAll.BackColor = System.Drawing.Color.Transparent;
            this.CB_DisplayAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CB_DisplayAll.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.CB_DisplayAll.Location = new System.Drawing.Point(8, 43);
            this.CB_DisplayAll.Margin = new System.Windows.Forms.Padding(1);
            this.CB_DisplayAll.Name = "CB_DisplayAll";
            this.CB_DisplayAll.Size = new System.Drawing.Size(100, 16);
            this.CB_DisplayAll.TabIndex = 41;
            this.CB_DisplayAll.Text = "모든 방 표시";
            this.CB_DisplayAll.UseVisualStyleBackColor = false;
            this.CB_DisplayAll.Visible = false;
            this.CB_DisplayAll.CheckedChanged += new System.EventHandler(this.StatusChanged);
            // 
            // CB_ShowPrivate
            // 
            this.CB_ShowPrivate.BackColor = System.Drawing.Color.Transparent;
            this.CB_ShowPrivate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CB_ShowPrivate.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.CB_ShowPrivate.Location = new System.Drawing.Point(8, 58);
            this.CB_ShowPrivate.Margin = new System.Windows.Forms.Padding(1);
            this.CB_ShowPrivate.Name = "CB_ShowPrivate";
            this.CB_ShowPrivate.Size = new System.Drawing.Size(100, 16);
            this.CB_ShowPrivate.TabIndex = 42;
            this.CB_ShowPrivate.Text = "비공개 방 표시";
            this.CB_ShowPrivate.UseVisualStyleBackColor = false;
            this.CB_ShowPrivate.Visible = false;
            this.CB_ShowPrivate.CheckedChanged += new System.EventHandler(this.StatusChanged);
            // 
            // Label_Current
            // 
            this.Label_Current.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Current.Location = new System.Drawing.Point(343, 297);
            this.Label_Current.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Current.Name = "Label_Current";
            this.Label_Current.Size = new System.Drawing.Size(29, 15);
            this.Label_Current.TabIndex = 43;
            this.Label_Current.Text = "현재";
            this.Label_Current.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_WaitRoom
            // 
            this.TB_WaitRoom.BackColor = System.Drawing.Color.White;
            this.TB_WaitRoom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_WaitRoom.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_WaitRoom.Location = new System.Drawing.Point(72, 90);
            this.TB_WaitRoom.Margin = new System.Windows.Forms.Padding(1);
            this.TB_WaitRoom.Name = "TB_WaitRoom";
            this.TB_WaitRoom.ReadOnly = true;
            this.TB_WaitRoom.Size = new System.Drawing.Size(30, 15);
            this.TB_WaitRoom.TabIndex = 45;
            this.TB_WaitRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label_WaitRoom
            // 
            this.Label_WaitRoom.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_WaitRoom.Location = new System.Drawing.Point(8, 89);
            this.Label_WaitRoom.Margin = new System.Windows.Forms.Padding(0);
            this.Label_WaitRoom.Name = "Label_WaitRoom";
            this.Label_WaitRoom.Size = new System.Drawing.Size(68, 15);
            this.Label_WaitRoom.TabIndex = 44;
            this.Label_WaitRoom.Text = "대기실 개수:";
            this.Label_WaitRoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Room
            // 
            this.TB_Room.BackColor = System.Drawing.Color.White;
            this.TB_Room.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Room.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_Room.Location = new System.Drawing.Point(151, 90);
            this.TB_Room.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Room.Name = "TB_Room";
            this.TB_Room.ReadOnly = true;
            this.TB_Room.Size = new System.Drawing.Size(30, 15);
            this.TB_Room.TabIndex = 47;
            this.TB_Room.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label_Room
            // 
            this.Label_Room.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Room.Location = new System.Drawing.Point(109, 89);
            this.Label_Room.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Room.Name = "Label_Room";
            this.Label_Room.Size = new System.Drawing.Size(46, 15);
            this.Label_Room.TabIndex = 46;
            this.Label_Room.Text = "방 개수:";
            this.Label_Room.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Search
            // 
            this.TB_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TB_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Search.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_Search.Location = new System.Drawing.Point(52, 74);
            this.TB_Search.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Search.Name = "TB_Search";
            this.TB_Search.Size = new System.Drawing.Size(110, 15);
            this.TB_Search.TabIndex = 49;
            this.TB_Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_Search.TextChanged += new System.EventHandler(this.StatusChanged);
            // 
            // Label_Search
            // 
            this.Label_Search.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_Search.Location = new System.Drawing.Point(8, 74);
            this.Label_Search.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Search.Name = "Label_Search";
            this.Label_Search.Size = new System.Drawing.Size(46, 15);
            this.Label_Search.TabIndex = 48;
            this.Label_Search.Text = "방 필터:";
            this.Label_Search.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_MapExist
            // 
            this.Label_MapExist.BackColor = System.Drawing.Color.White;
            this.Label_MapExist.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_MapExist.Location = new System.Drawing.Point(280, 30);
            this.Label_MapExist.Margin = new System.Windows.Forms.Padding(0);
            this.Label_MapExist.Name = "Label_MapExist";
            this.Label_MapExist.Size = new System.Drawing.Size(47, 15);
            this.Label_MapExist.TabIndex = 50;
            this.Label_MapExist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Loading
            // 
            this.Label_Loading.Location = new System.Drawing.Point(97, 233);
            this.Label_Loading.Name = "Label_Loading";
            this.Label_Loading.Size = new System.Drawing.Size(186, 16);
            this.Label_Loading.TabIndex = 51;
            this.Label_Loading.Text = "방 리스트를 가져오는 중입니다...";
            this.Label_Loading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label_Loading.Visible = false;
            this.Label_Loading.Click += new System.EventHandler(this.Label_Loading_Click);
            // 
            // BTN_ChangeType
            // 
            this.BTN_ChangeType.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_ChangeType.Location = new System.Drawing.Point(163, 72);
            this.BTN_ChangeType.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_ChangeType.Name = "BTN_ChangeType";
            this.BTN_ChangeType.Size = new System.Drawing.Size(20, 19);
            this.BTN_ChangeType.TabIndex = 52;
            this.BTN_ChangeType.Text = "↔";
            this.BTN_ChangeType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTN_ChangeType.UseVisualStyleBackColor = true;
            this.BTN_ChangeType.Click += new System.EventHandler(this.BTN_ChangeType_Click);
            // 
            // MapImage
            // 
            this.MapImage.BackColor = System.Drawing.Color.Transparent;
            this.MapImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MapImage.Location = new System.Drawing.Point(196, 85);
            this.MapImage.Name = "MapImage";
            this.MapImage.Size = new System.Drawing.Size(176, 176);
            this.MapImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MapImage.TabIndex = 7;
            this.MapImage.TabStop = false;
            // 
            // TB_StartTime
            // 
            this.TB_StartTime.BackColor = System.Drawing.Color.White;
            this.TB_StartTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_StartTime.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_StartTime.Location = new System.Drawing.Point(260, 281);
            this.TB_StartTime.Margin = new System.Windows.Forms.Padding(1);
            this.TB_StartTime.Name = "TB_StartTime";
            this.TB_StartTime.ReadOnly = true;
            this.TB_StartTime.Size = new System.Drawing.Size(110, 15);
            this.TB_StartTime.TabIndex = 12;
            this.TB_StartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label_StartTime
            // 
            this.Label_StartTime.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_StartTime.Location = new System.Drawing.Point(196, 280);
            this.Label_StartTime.Margin = new System.Windows.Forms.Padding(0);
            this.Label_StartTime.Name = "Label_StartTime";
            this.Label_StartTime.Size = new System.Drawing.Size(61, 15);
            this.Label_StartTime.TabIndex = 11;
            this.Label_StartTime.Text = "시작 일시 :";
            this.Label_StartTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_SearchPlayer
            // 
            this.BTN_SearchPlayer.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_SearchPlayer.Location = new System.Drawing.Point(339, 365);
            this.BTN_SearchPlayer.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_SearchPlayer.Name = "BTN_SearchPlayer";
            this.BTN_SearchPlayer.Size = new System.Drawing.Size(37, 20);
            this.BTN_SearchPlayer.TabIndex = 53;
            this.BTN_SearchPlayer.Text = "검색";
            this.BTN_SearchPlayer.UseVisualStyleBackColor = true;
            this.BTN_SearchPlayer.Click += new System.EventHandler(this.BTN_SearchPlayer_Click);
            // 
            // BTN_Statistics
            // 
            this.BTN_Statistics.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_Statistics.Location = new System.Drawing.Point(339, 345);
            this.BTN_Statistics.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_Statistics.Name = "BTN_Statistics";
            this.BTN_Statistics.Size = new System.Drawing.Size(37, 20);
            this.BTN_Statistics.TabIndex = 54;
            this.BTN_Statistics.Text = "통계";
            this.BTN_Statistics.UseVisualStyleBackColor = true;
            this.BTN_Statistics.Click += new System.EventHandler(this.BTN_Statistics_Click);
            // 
            // BTN_ReserveRoom
            // 
            this.BTN_ReserveRoom.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_ReserveRoom.Location = new System.Drawing.Point(339, 325);
            this.BTN_ReserveRoom.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_ReserveRoom.Name = "BTN_ReserveRoom";
            this.BTN_ReserveRoom.Size = new System.Drawing.Size(37, 20);
            this.BTN_ReserveRoom.TabIndex = 55;
            this.BTN_ReserveRoom.Text = "예약";
            this.BTN_ReserveRoom.UseVisualStyleBackColor = true;
            this.BTN_ReserveRoom.Visible = false;
            // 
            // ServerStatus
            // 
            this.ServerStatus.Interval = 10000;
            this.ServerStatus.Tick += new System.EventHandler(this.ServerStatus_Tick);
            // 
            // BTN_MapLog
            // 
            this.BTN_MapLog.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_MapLog.Location = new System.Drawing.Point(339, 385);
            this.BTN_MapLog.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_MapLog.Name = "BTN_MapLog";
            this.BTN_MapLog.Size = new System.Drawing.Size(37, 20);
            this.BTN_MapLog.TabIndex = 56;
            this.BTN_MapLog.Text = "기록";
            this.BTN_MapLog.UseVisualStyleBackColor = true;
            this.BTN_MapLog.Click += new System.EventHandler(this.BTN_MapLog_Click);
            // 
            // BTN_RoomJoin
            // 
            this.BTN_RoomJoin.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_RoomJoin.Location = new System.Drawing.Point(339, 405);
            this.BTN_RoomJoin.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_RoomJoin.Name = "BTN_RoomJoin";
            this.BTN_RoomJoin.Size = new System.Drawing.Size(37, 20);
            this.BTN_RoomJoin.TabIndex = 57;
            this.BTN_RoomJoin.Text = "입장";
            this.BTN_RoomJoin.UseVisualStyleBackColor = true;
            this.BTN_RoomJoin.Click += new System.EventHandler(this.BTN_RoomJoin_Click);
            // 
            // RTB_Name
            // 
            this.RTB_Name.BackColor = System.Drawing.Color.White;
            this.RTB_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB_Name.DetectUrls = false;
            this.RTB_Name.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.RTB_Name.Location = new System.Drawing.Point(196, 49);
            this.RTB_Name.Margin = new System.Windows.Forms.Padding(1);
            this.RTB_Name.Multiline = false;
            this.RTB_Name.Name = "RTB_Name";
            this.RTB_Name.ReadOnly = true;
            this.RTB_Name.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.RTB_Name.Size = new System.Drawing.Size(176, 15);
            this.RTB_Name.TabIndex = 58;
            this.RTB_Name.Text = "";
            // 
            // RoomListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 477);
            this.Controls.Add(this.RTB_Name);
            this.Controls.Add(this.BTN_RoomJoin);
            this.Controls.Add(this.BTN_MapLog);
            this.Controls.Add(this.BTN_ReserveRoom);
            this.Controls.Add(this.BTN_Statistics);
            this.Controls.Add(this.BTN_SearchPlayer);
            this.Controls.Add(this.BTN_ChangeType);
            this.Controls.Add(this.Label_Loading);
            this.Controls.Add(this.Label_MapExist);
            this.Controls.Add(this.TB_Search);
            this.Controls.Add(this.Label_Search);
            this.Controls.Add(this.TB_Room);
            this.Controls.Add(this.Label_Room);
            this.Controls.Add(this.TB_WaitRoom);
            this.Controls.Add(this.Label_WaitRoom);
            this.Controls.Add(this.Label_Current);
            this.Controls.Add(this.CB_ShowPrivate);
            this.Controls.Add(this.CB_DisplayAll);
            this.Controls.Add(this.CB_RealTimeSet);
            this.Controls.Add(this.BTN_Refresh);
            this.Controls.Add(this.TB_Player);
            this.Controls.Add(this.Label_Player);
            this.Controls.Add(this.TB_Player11);
            this.Controls.Add(this.Label_Player11);
            this.Controls.Add(this.TB_Player10);
            this.Controls.Add(this.Label_Player10);
            this.Controls.Add(this.TB_Player9);
            this.Controls.Add(this.Label_Player9);
            this.Controls.Add(this.TB_Player8);
            this.Controls.Add(this.Label_Player8);
            this.Controls.Add(this.TB_Player7);
            this.Controls.Add(this.Label_Player7);
            this.Controls.Add(this.TB_Player6);
            this.Controls.Add(this.Label_Player6);
            this.Controls.Add(this.TB_Player5);
            this.Controls.Add(this.Label_Player5);
            this.Controls.Add(this.TB_Player4);
            this.Controls.Add(this.Label_Player4);
            this.Controls.Add(this.TB_Player3);
            this.Controls.Add(this.Label_Player3);
            this.Controls.Add(this.TB_Player2);
            this.Controls.Add(this.Label_Player2);
            this.Controls.Add(this.TB_Player1);
            this.Controls.Add(this.Label_Player1);
            this.Controls.Add(this.TB_Player0);
            this.Controls.Add(this.Label_Player0);
            this.Controls.Add(this.TB_StartTime);
            this.Controls.Add(this.Label_StartTime);
            this.Controls.Add(this.TB_RegDate);
            this.Controls.Add(this.Label_RegDate);
            this.Controls.Add(this.RTB_MapName);
            this.Controls.Add(this.MapImage);
            this.Controls.Add(this.Label_Flag);
            this.Controls.Add(this.Label_ID);
            this.Controls.Add(this.TB_ID);
            this.Controls.Add(this.Label_Status);
            this.Controls.Add(this.RoomList);
            this.Controls.Add(this.Label_Title);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.Name = "RoomListForm";
            this.Padding = new System.Windows.Forms.Padding(5, 30, 5, 5);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "M16 서버 - 방 리스트 뷰어";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoomListForm_FormClosing);
            this.Load += new System.EventHandler(this.RoomListForm_Load);
            this.Shown += new System.EventHandler(this.RoomListForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.MapImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.ListBox RoomList;
        private System.Windows.Forms.TextBox TB_ID;
        private System.Windows.Forms.Label Label_ID;
        private System.Windows.Forms.Label Label_Flag;
        private System.Windows.Forms.PictureBox MapImage;
        private System.Windows.Forms.RichTextBox RTB_MapName;
        private System.Windows.Forms.Label Label_Status;
        private System.Windows.Forms.Label Label_RegDate;
        private System.Windows.Forms.TextBox TB_RegDate;
        private System.Windows.Forms.TextBox TB_Player0;
        private System.Windows.Forms.Label Label_Player0;
        private System.Windows.Forms.TextBox TB_Player1;
        private System.Windows.Forms.Label Label_Player1;
        private System.Windows.Forms.TextBox TB_Player2;
        private System.Windows.Forms.Label Label_Player2;
        private System.Windows.Forms.TextBox TB_Player5;
        private System.Windows.Forms.Label Label_Player5;
        private System.Windows.Forms.TextBox TB_Player4;
        private System.Windows.Forms.Label Label_Player4;
        private System.Windows.Forms.TextBox TB_Player3;
        private System.Windows.Forms.Label Label_Player3;
        private System.Windows.Forms.TextBox TB_Player11;
        private System.Windows.Forms.Label Label_Player11;
        private System.Windows.Forms.TextBox TB_Player10;
        private System.Windows.Forms.Label Label_Player10;
        private System.Windows.Forms.TextBox TB_Player9;
        private System.Windows.Forms.Label Label_Player9;
        private System.Windows.Forms.TextBox TB_Player8;
        private System.Windows.Forms.Label Label_Player8;
        private System.Windows.Forms.TextBox TB_Player7;
        private System.Windows.Forms.Label Label_Player7;
        private System.Windows.Forms.TextBox TB_Player6;
        private System.Windows.Forms.Label Label_Player6;
        private System.Windows.Forms.Label Label_Player;
        private System.Windows.Forms.TextBox TB_Player;
        private System.Windows.Forms.Button BTN_Refresh;
        private System.Windows.Forms.CheckBox CB_RealTimeSet;
        private System.Windows.Forms.CheckBox CB_DisplayAll;
        private System.Windows.Forms.CheckBox CB_ShowPrivate;
        private System.Windows.Forms.Label Label_Current;
        private System.Windows.Forms.TextBox TB_WaitRoom;
        private System.Windows.Forms.Label Label_WaitRoom;
        private System.Windows.Forms.TextBox TB_Room;
        private System.Windows.Forms.Label Label_Room;
        private System.Windows.Forms.TextBox TB_Search;
        private System.Windows.Forms.Label Label_Search;
        private System.Windows.Forms.Label Label_MapExist;
        private System.Windows.Forms.Label Label_Loading;
        private System.Windows.Forms.Button BTN_ChangeType;
        private System.Windows.Forms.TextBox TB_StartTime;
        private System.Windows.Forms.Label Label_StartTime;
        private System.Windows.Forms.Button BTN_SearchPlayer;
        private System.Windows.Forms.Button BTN_Statistics;
        private System.Windows.Forms.Button BTN_ReserveRoom;
        private System.Windows.Forms.Timer ServerStatus;
        private System.Windows.Forms.Button BTN_MapLog;
        private System.Windows.Forms.Button BTN_RoomJoin;
        private System.Windows.Forms.RichTextBox RTB_Name;
    }
}

