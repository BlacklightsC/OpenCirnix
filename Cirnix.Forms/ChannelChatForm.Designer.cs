namespace Cirnix.Forms
{
    partial class ChannelChatForm
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
            this.components = new System.ComponentModel.Container();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.Title = new System.Windows.Forms.Label();
            this.ChatTimer = new System.Windows.Forms.Timer(this.components);
            this.WindowsCloseTimer = new System.Windows.Forms.Timer(this.components);
            this.ColorChange = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.AutoClose = new MetroFramework.Controls.MetroToggle();
            this.ClearScreen = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.richTextBox.ForeColor = System.Drawing.Color.White;
            this.richTextBox.Location = new System.Drawing.Point(8, 33);
            this.richTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 5);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(484, 270);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Title.Location = new System.Drawing.Point(125, 9);
            this.Title.Margin = new System.Windows.Forms.Padding(120, 0, 120, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(250, 20);
            this.Title.TabIndex = 1;
            this.Title.Text = "접속 중 - ";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChatTimer
            // 
            this.ChatTimer.Interval = 2000;
            this.ChatTimer.Tick += new System.EventHandler(this.ChatTimer_Tick);
            // 
            // WindowsCloseTimer
            // 
            this.WindowsCloseTimer.Interval = 1000;
            this.WindowsCloseTimer.Tick += new System.EventHandler(this.WindowsCloseTimer_Tick);
            // 
            // ColorChange
            // 
            this.ColorChange.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.ColorChange.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.ColorChange.Location = new System.Drawing.Point(8, 312);
            this.ColorChange.Name = "ColorChange";
            this.ColorChange.Size = new System.Drawing.Size(90, 30);
            this.ColorChange.TabIndex = 2;
            this.ColorChange.Text = "배경색 변경";
            this.ColorChange.UseMnemonic = false;
            this.ColorChange.UseSelectable = true;
            this.ColorChange.Click += new System.EventHandler(this.ColorChange_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(200, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "창 자동 종료";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoClose
            // 
            this.AutoClose.AutoSize = true;
            this.AutoClose.BackColor = System.Drawing.Color.Transparent;
            this.AutoClose.Location = new System.Drawing.Point(200, 310);
            this.AutoClose.Name = "AutoClose";
            this.AutoClose.Size = new System.Drawing.Size(80, 16);
            this.AutoClose.TabIndex = 8;
            this.AutoClose.Text = "Off";
            this.AutoClose.Checked = true;
            this.AutoClose.UseSelectable = true;
            this.AutoClose.CheckedChanged += new System.EventHandler(this.AutoClose_CheckedChanged);
            // 
            // ClearScreen
            // 
            this.ClearScreen.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.ClearScreen.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.ClearScreen.Location = new System.Drawing.Point(104, 312);
            this.ClearScreen.Name = "ClearScreen";
            this.ClearScreen.Size = new System.Drawing.Size(90, 30);
            this.ClearScreen.TabIndex = 9;
            this.ClearScreen.Text = "채팅창 청소";
            this.ClearScreen.UseMnemonic = false;
            this.ClearScreen.UseSelectable = true;
            this.ClearScreen.Click += new System.EventHandler(this.ClearScreen_Click);
            // 
            // ChannelChatForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.ClearScreen);
            this.Controls.Add(this.AutoClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ColorChange);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.richTextBox);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.Name = "ChannelChatForm";
            this.Padding = new System.Windows.Forms.Padding(5, 30, 5, 5);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChannelChatForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.ChannelChatForm_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Timer WindowsCloseTimer;
        private MetroFramework.Controls.MetroButton ColorChange;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton ClearScreen;
        public System.Windows.Forms.Timer ChatTimer;
        public MetroFramework.Controls.MetroToggle AutoClose;
    }
}