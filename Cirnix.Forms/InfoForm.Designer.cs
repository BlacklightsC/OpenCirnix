namespace Cirnix.Forms
{
    partial class InfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.Picture = new System.Windows.Forms.PictureBox();
            this.CopyRight = new MetroFramework.Controls.MetroLabel();
            this.Label_CurrentVersion = new MetroFramework.Controls.MetroLabel();
            this.Label_LatestVersion = new MetroFramework.Controls.MetroLabel();
            this.UpdateButton = new MetroFramework.Controls.MetroButton();
            this.LatestVersion = new MetroFramework.Controls.MetroLabel();
            this.CurrentVersion = new MetroFramework.Controls.MetroLabel();
            this.Toggle_BetaUser = new MetroFramework.Controls.MetroToggle();
            this.Label_BetaUser = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.LicenceButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Picture
            // 
            this.Picture.Image = ((System.Drawing.Image)(resources.GetObject("Picture.Image")));
            this.Picture.Location = new System.Drawing.Point(10, 65);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(256, 256);
            this.Picture.TabIndex = 0;
            this.Picture.TabStop = false;
            // 
            // CopyRight
            // 
            this.CopyRight.BackColor = System.Drawing.Color.Transparent;
            this.CopyRight.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.CopyRight.Location = new System.Drawing.Point(10, 327);
            this.CopyRight.Name = "CopyRight";
            this.CopyRight.Size = new System.Drawing.Size(256, 20);
            this.CopyRight.Style = MetroFramework.MetroColorStyle.Blue;
            this.CopyRight.TabIndex = 1;
            this.CopyRight.Text = "제작: 평타천국 (BlacklightsC)\r\n\r\n";
            this.CopyRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CopyRight.UseStyleColors = true;
            // 
            // Label_CurrentVersion
            // 
            this.Label_CurrentVersion.BackColor = System.Drawing.Color.Transparent;
            this.Label_CurrentVersion.Location = new System.Drawing.Point(39, 419);
            this.Label_CurrentVersion.Name = "Label_CurrentVersion";
            this.Label_CurrentVersion.Size = new System.Drawing.Size(72, 20);
            this.Label_CurrentVersion.TabIndex = 2;
            this.Label_CurrentVersion.Text = "현재 버전:";
            this.Label_CurrentVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_LatestVersion
            // 
            this.Label_LatestVersion.BackColor = System.Drawing.Color.Transparent;
            this.Label_LatestVersion.Location = new System.Drawing.Point(39, 440);
            this.Label_LatestVersion.Name = "Label_LatestVersion";
            this.Label_LatestVersion.Size = new System.Drawing.Size(72, 20);
            this.Label_LatestVersion.TabIndex = 3;
            this.Label_LatestVersion.Text = "최신 버전:";
            this.Label_LatestVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Enabled = false;
            this.UpdateButton.Highlight = true;
            this.UpdateButton.Location = new System.Drawing.Point(150, 470);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(100, 35);
            this.UpdateButton.TabIndex = 4;
            this.UpdateButton.Text = "업데이트";
            this.UpdateButton.UseSelectable = true;
            this.UpdateButton.Click += new System.EventHandler(this.Update_Click);
            // 
            // LatestVersion
            // 
            this.LatestVersion.BackColor = System.Drawing.Color.Transparent;
            this.LatestVersion.Location = new System.Drawing.Point(117, 440);
            this.LatestVersion.Name = "LatestVersion";
            this.LatestVersion.Size = new System.Drawing.Size(120, 20);
            this.LatestVersion.TabIndex = 6;
            this.LatestVersion.Text = "연결 중...";
            this.LatestVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentVersion
            // 
            this.CurrentVersion.BackColor = System.Drawing.Color.Transparent;
            this.CurrentVersion.Location = new System.Drawing.Point(117, 419);
            this.CurrentVersion.Name = "CurrentVersion";
            this.CurrentVersion.Size = new System.Drawing.Size(120, 20);
            this.CurrentVersion.TabIndex = 5;
            this.CurrentVersion.Text = "확인 중...";
            this.CurrentVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CurrentVersion.Click += new System.EventHandler(this.CurrentVersion_Click);
            // 
            // Toggle_BetaUser
            // 
            this.Toggle_BetaUser.BackColor = System.Drawing.SystemColors.ControlText;
            this.Toggle_BetaUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Toggle_BetaUser.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Toggle_BetaUser.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.Toggle_BetaUser.Location = new System.Drawing.Point(135, 402);
            this.Toggle_BetaUser.Name = "Toggle_BetaUser";
            this.Toggle_BetaUser.Size = new System.Drawing.Size(70, 15);
            this.Toggle_BetaUser.Style = MetroFramework.MetroColorStyle.Green;
            this.Toggle_BetaUser.TabIndex = 70;
            this.Toggle_BetaUser.Text = "Off";
            this.Toggle_BetaUser.UseSelectable = true;
            this.Toggle_BetaUser.UseStyleColors = true;
            this.Toggle_BetaUser.CheckedChanged += new System.EventHandler(this.Toggle_BetaUser_CheckedChanged);
            // 
            // Label_BetaUser
            // 
            this.Label_BetaUser.BackColor = System.Drawing.Color.Transparent;
            this.Label_BetaUser.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.Label_BetaUser.Location = new System.Drawing.Point(51, 399);
            this.Label_BetaUser.Name = "Label_BetaUser";
            this.Label_BetaUser.Size = new System.Drawing.Size(80, 20);
            this.Label_BetaUser.Style = MetroFramework.MetroColorStyle.Green;
            this.Label_BetaUser.TabIndex = 72;
            this.Label_BetaUser.Text = "베타 버전";
            this.Label_BetaUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label_BetaUser.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(10, 350);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(256, 20);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 73;
            this.metroLabel1.Text = "수정: 류아릴 (Drev_H.Kirito)\r\n\r\n";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.UseStyleColors = true;
            // 
            // LicenceButton
            // 
            this.LicenceButton.Highlight = true;
            this.LicenceButton.Location = new System.Drawing.Point(24, 470);
            this.LicenceButton.Name = "LicenceButton";
            this.LicenceButton.Size = new System.Drawing.Size(100, 35);
            this.LicenceButton.TabIndex = 74;
            this.LicenceButton.Text = "라이선스";
            this.LicenceButton.UseSelectable = true;
            this.LicenceButton.Click += new System.EventHandler(this.LicenceButton_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(10, 373);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(256, 20);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 75;
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel2.UseStyleColors = true;
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 515);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.LicenceButton);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.Label_BetaUser);
            this.Controls.Add(this.Toggle_BetaUser);
            this.Controls.Add(this.LatestVersion);
            this.Controls.Add(this.CurrentVersion);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.Label_LatestVersion);
            this.Controls.Add(this.Label_CurrentVersion);
            this.Controls.Add(this.CopyRight);
            this.Controls.Add(this.Picture);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoForm";
            this.Padding = new System.Windows.Forms.Padding(10, 60, 10, 10);
            this.Resizable = false;
            this.Text = "프로그램 정보";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Shown += new System.EventHandler(this.InfoForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Picture;
        private MetroFramework.Controls.MetroLabel CopyRight;
        private MetroFramework.Controls.MetroLabel Label_CurrentVersion;
        private MetroFramework.Controls.MetroLabel Label_LatestVersion;
        public MetroFramework.Controls.MetroButton UpdateButton;
        public MetroFramework.Controls.MetroLabel LatestVersion;
        public MetroFramework.Controls.MetroLabel CurrentVersion;
        private MetroFramework.Controls.MetroToggle Toggle_BetaUser;
        private MetroFramework.Controls.MetroLabel Label_BetaUser;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        public MetroFramework.Controls.MetroButton LicenceButton;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}