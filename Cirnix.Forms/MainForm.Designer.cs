namespace Cirnix.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Box_MapType = new MetroFramework.Controls.MetroComboBox();
            this.Box_HeroType = new MetroFramework.Controls.MetroComboBox();
            this.Box_SaveText = new MetroFramework.Controls.MetroComboBox();
            this.Label_Title = new System.Windows.Forms.Label();
            this.BTN_Option = new System.Windows.Forms.Button();
            this.BTN_RoomList = new System.Windows.Forms.Button();
            this.BTN_Info = new System.Windows.Forms.Button();
            this.BTN_Analyzer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Label_Command = new System.Windows.Forms.Label();
            this.RB_Preset2 = new System.Windows.Forms.RadioButton();
            this.RB_Preset3 = new System.Windows.Forms.RadioButton();
            this.RB_Preset1 = new System.Windows.Forms.RadioButton();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.BTN_AdditionalTool = new System.Windows.Forms.Button();
            this.BTN_LaunchWC3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Box_MapType
            // 
            this.Box_MapType.DisplayFocus = true;
            this.Box_MapType.FormattingEnabled = true;
            this.Box_MapType.ItemHeight = 23;
            this.Box_MapType.Location = new System.Drawing.Point(5, 15);
            this.Box_MapType.Name = "Box_MapType";
            this.Box_MapType.Size = new System.Drawing.Size(155, 29);
            this.Box_MapType.TabIndex = 1;
            this.Box_MapType.UseSelectable = true;
            this.Box_MapType.TextChanged += new System.EventHandler(this.Box_MapType_TextChanged);
            // 
            // Box_HeroType
            // 
            this.Box_HeroType.DisplayFocus = true;
            this.Box_HeroType.FormattingEnabled = true;
            this.Box_HeroType.ItemHeight = 23;
            this.Box_HeroType.Location = new System.Drawing.Point(5, 45);
            this.Box_HeroType.Name = "Box_HeroType";
            this.Box_HeroType.Size = new System.Drawing.Size(155, 29);
            this.Box_HeroType.TabIndex = 3;
            this.Box_HeroType.UseSelectable = true;
            this.Box_HeroType.TextChanged += new System.EventHandler(this.Box_HeroType_TextChanged);
            // 
            // Box_SaveText
            // 
            this.Box_SaveText.DisplayFocus = true;
            this.Box_SaveText.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.Box_SaveText.FormattingEnabled = true;
            this.Box_SaveText.ItemHeight = 19;
            this.Box_SaveText.Location = new System.Drawing.Point(5, 75);
            this.Box_SaveText.Name = "Box_SaveText";
            this.Box_SaveText.Size = new System.Drawing.Size(155, 25);
            this.Box_SaveText.TabIndex = 5;
            this.Box_SaveText.UseSelectable = true;
            this.Box_SaveText.TextChanged += new System.EventHandler(this.Box_SaveText_TextChanged);
            // 
            // Label_Title
            // 
            this.Label_Title.BackColor = System.Drawing.Color.Transparent;
            this.Label_Title.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_Title.Location = new System.Drawing.Point(80, 6);
            this.Label_Title.Margin = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(160, 20);
            this.Label_Title.TabIndex = 8;
            this.Label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_Option
            // 
            this.BTN_Option.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.BTN_Option.Location = new System.Drawing.Point(3, 161);
            this.BTN_Option.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_Option.Name = "BTN_Option";
            this.BTN_Option.Size = new System.Drawing.Size(39, 23);
            this.BTN_Option.TabIndex = 9;
            this.BTN_Option.Text = "설정";
            this.BTN_Option.UseVisualStyleBackColor = true;
            this.BTN_Option.Click += new System.EventHandler(this.BTN_Option_Click);
            // 
            // BTN_RoomList
            // 
            this.BTN_RoomList.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.BTN_RoomList.Location = new System.Drawing.Point(42, 161);
            this.BTN_RoomList.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_RoomList.Name = "BTN_RoomList";
            this.BTN_RoomList.Size = new System.Drawing.Size(85, 23);
            this.BTN_RoomList.TabIndex = 10;
            this.BTN_RoomList.Text = "대기실 리스트";
            this.BTN_RoomList.UseVisualStyleBackColor = true;
            this.BTN_RoomList.Click += new System.EventHandler(this.BTN_RoomList_Click);
            // 
            // BTN_Info
            // 
            this.BTN_Info.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.BTN_Info.Location = new System.Drawing.Point(3, 184);
            this.BTN_Info.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_Info.Name = "BTN_Info";
            this.BTN_Info.Size = new System.Drawing.Size(39, 23);
            this.BTN_Info.TabIndex = 11;
            this.BTN_Info.Text = "정보";
            this.BTN_Info.UseVisualStyleBackColor = true;
            this.BTN_Info.Click += new System.EventHandler(this.BTN_Info_Click);
            // 
            // BTN_Analyzer
            // 
            this.BTN_Analyzer.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.BTN_Analyzer.Location = new System.Drawing.Point(42, 184);
            this.BTN_Analyzer.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_Analyzer.Name = "BTN_Analyzer";
            this.BTN_Analyzer.Size = new System.Drawing.Size(85, 23);
            this.BTN_Analyzer.TabIndex = 12;
            this.BTN_Analyzer.Text = "강제설정";
            this.BTN_Analyzer.UseVisualStyleBackColor = true;
            this.BTN_Analyzer.Click += new System.EventHandler(this.BTN_Analyzer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label_Command);
            this.groupBox1.Controls.Add(this.RB_Preset2);
            this.groupBox1.Controls.Add(this.RB_Preset3);
            this.groupBox1.Controls.Add(this.RB_Preset1);
            this.groupBox1.Controls.Add(this.Box_MapType);
            this.groupBox1.Controls.Add(this.Box_HeroType);
            this.groupBox1.Controls.Add(this.Box_SaveText);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.groupBox1.Location = new System.Drawing.Point(4, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 131);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "세이브 분류";
            // 
            // Label_Command
            // 
            this.Label_Command.BackColor = System.Drawing.Color.Transparent;
            this.Label_Command.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.Label_Command.Location = new System.Drawing.Point(5, 101);
            this.Label_Command.Margin = new System.Windows.Forms.Padding(0);
            this.Label_Command.Name = "Label_Command";
            this.Label_Command.Size = new System.Drawing.Size(55, 26);
            this.Label_Command.TabIndex = 87;
            this.Label_Command.Text = "명령어";
            this.Label_Command.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RB_Preset2
            // 
            this.RB_Preset2.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Preset2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RB_Preset2.Location = new System.Drawing.Point(96, 101);
            this.RB_Preset2.Name = "RB_Preset2";
            this.RB_Preset2.Size = new System.Drawing.Size(30, 26);
            this.RB_Preset2.TabIndex = 86;
            this.RB_Preset2.Text = "2";
            this.RB_Preset2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Preset2.UseVisualStyleBackColor = true;
            this.RB_Preset2.CheckedChanged += new System.EventHandler(this.RB_Preset_CheckedChanged);
            // 
            // RB_Preset3
            // 
            this.RB_Preset3.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Preset3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RB_Preset3.Location = new System.Drawing.Point(131, 101);
            this.RB_Preset3.Name = "RB_Preset3";
            this.RB_Preset3.Size = new System.Drawing.Size(30, 26);
            this.RB_Preset3.TabIndex = 85;
            this.RB_Preset3.Text = "3";
            this.RB_Preset3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Preset3.UseVisualStyleBackColor = true;
            this.RB_Preset3.CheckedChanged += new System.EventHandler(this.RB_Preset_CheckedChanged);
            // 
            // RB_Preset1
            // 
            this.RB_Preset1.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Preset1.Checked = true;
            this.RB_Preset1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RB_Preset1.Location = new System.Drawing.Point(61, 101);
            this.RB_Preset1.Name = "RB_Preset1";
            this.RB_Preset1.Size = new System.Drawing.Size(30, 26);
            this.RB_Preset1.TabIndex = 84;
            this.RB_Preset1.TabStop = true;
            this.RB_Preset1.Text = "1";
            this.RB_Preset1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Preset1.UseVisualStyleBackColor = true;
            this.RB_Preset1.CheckedChanged += new System.EventHandler(this.RB_Preset_CheckedChanged);
            // 
            // ImageBox
            // 
            this.ImageBox.Image = ((System.Drawing.Image)(resources.GetObject("ImageBox.Image")));
            this.ImageBox.Location = new System.Drawing.Point(173, 27);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(143, 180);
            this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageBox.TabIndex = 14;
            this.ImageBox.TabStop = false;
            // 
            // BTN_AdditionalTool
            // 
            this.BTN_AdditionalTool.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.BTN_AdditionalTool.Location = new System.Drawing.Point(127, 161);
            this.BTN_AdditionalTool.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_AdditionalTool.Name = "BTN_AdditionalTool";
            this.BTN_AdditionalTool.Size = new System.Drawing.Size(42, 23);
            this.BTN_AdditionalTool.TabIndex = 15;
            this.BTN_AdditionalTool.Text = "부가";
            this.BTN_AdditionalTool.UseVisualStyleBackColor = true;
            this.BTN_AdditionalTool.Click += new System.EventHandler(this.BTN_AdditionalTool_Click);
            // 
            // BTN_LaunchWC3
            // 
            this.BTN_LaunchWC3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.BTN_LaunchWC3.Location = new System.Drawing.Point(127, 184);
            this.BTN_LaunchWC3.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_LaunchWC3.Name = "BTN_LaunchWC3";
            this.BTN_LaunchWC3.Size = new System.Drawing.Size(42, 23);
            this.BTN_LaunchWC3.TabIndex = 16;
            this.BTN_LaunchWC3.Text = "실행";
            this.BTN_LaunchWC3.UseVisualStyleBackColor = true;
            this.BTN_LaunchWC3.Click += new System.EventHandler(this.BTN_LaunchWC3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(320, 210);
            this.Controls.Add(this.BTN_LaunchWC3);
            this.Controls.Add(this.BTN_AdditionalTool);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BTN_Analyzer);
            this.Controls.Add(this.BTN_Info);
            this.Controls.Add(this.BTN_RoomList);
            this.Controls.Add(this.BTN_Option);
            this.Controls.Add(this.Label_Title);
            this.Controls.Add(this.ImageBox);
            this.DisplayHeader = false;
            this.Font = new System.Drawing.Font("굴림", 8F);
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Activated += new System.EventHandler(this.MainForm_Update);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroComboBox Box_MapType;
        private MetroFramework.Controls.MetroComboBox Box_HeroType;
        private MetroFramework.Controls.MetroComboBox Box_SaveText;
        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.Button BTN_Option;
        private System.Windows.Forms.Button BTN_RoomList;
        private System.Windows.Forms.Button BTN_Info;
        private System.Windows.Forms.Button BTN_Analyzer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.Button BTN_AdditionalTool;
        private System.Windows.Forms.RadioButton RB_Preset2;
        private System.Windows.Forms.RadioButton RB_Preset3;
        private System.Windows.Forms.RadioButton RB_Preset1;
        private System.Windows.Forms.Label Label_Command;
        private System.Windows.Forms.Button BTN_LaunchWC3;
    }
}

