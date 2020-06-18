namespace Cirnix.Forms
{
    partial class TrayIcon
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
            this.MainTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.OpenWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.Line1 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenRoomList = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenAnalyzer = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenAdditionalTool = new System.Windows.Forms.ToolStripMenuItem();
            this.Line2 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenOption = new System.Windows.Forms.ToolStripMenuItem();
            this.Information = new System.Windows.Forms.ToolStripMenuItem();
            this.Line3 = new System.Windows.Forms.ToolStripSeparator();
            this.ShutDown = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTrayIcon
            // 
            this.MainTrayIcon.ContextMenuStrip = this.TrayMenu;
            this.MainTrayIcon.Visible = true;
            this.MainTrayIcon.DoubleClick += new System.EventHandler(this.OpenWindow_Click);
            // 
            // TrayMenu
            // 
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenWindow,
            this.Line1,
            this.OpenRoomList,
            this.OpenAnalyzer,
            this.OpenAdditionalTool,
            this.Line2,
            this.OpenOption,
            this.Information,
            this.Line3,
            this.ShutDown});
            this.TrayMenu.Name = "OpenWindow";
            this.TrayMenu.Size = new System.Drawing.Size(156, 176);
            this.TrayMenu.Style = MetroFramework.MetroColorStyle.Blue;
            this.TrayMenu.UseCustomBackColor = true;
            this.TrayMenu.UseCustomForeColor = true;
            this.TrayMenu.UseStyleColors = true;
            // 
            // OpenWindow
            // 
            this.OpenWindow.Name = "OpenWindow";
            this.OpenWindow.Size = new System.Drawing.Size(155, 22);
            this.OpenWindow.Text = "프로그램 열기";
            this.OpenWindow.Click += new System.EventHandler(this.OpenWindow_Click);
            // 
            // Line1
            // 
            this.Line1.Name = "Line1";
            this.Line1.Size = new System.Drawing.Size(152, 6);
            // 
            // OpenRoomList
            // 
            this.OpenRoomList.Name = "OpenRoomList";
            this.OpenRoomList.Size = new System.Drawing.Size(155, 22);
            this.OpenRoomList.Text = "M16 방 리스트";
            this.OpenRoomList.Click += new System.EventHandler(this.OpenRoomList_Click);
            // 
            // OpenAnalyzer
            // 
            this.OpenAnalyzer.Enabled = false;
            this.OpenAnalyzer.Name = "OpenAnalyzer";
            this.OpenAnalyzer.Size = new System.Drawing.Size(155, 22);
            this.OpenAnalyzer.Text = "코드 리더기";
            this.OpenAnalyzer.Visible = false;
            this.OpenAnalyzer.Click += new System.EventHandler(this.OpenAnalyzer_Click);
            // 
            // OpenAdditionalTool
            // 
            this.OpenAdditionalTool.Name = "OpenAdditionalTool";
            this.OpenAdditionalTool.Size = new System.Drawing.Size(155, 22);
            this.OpenAdditionalTool.Text = "부가 기능";
            this.OpenAdditionalTool.Click += new System.EventHandler(this.OpenAdditionalTool_Click);
            // 
            // Line2
            // 
            this.Line2.Name = "Line2";
            this.Line2.Size = new System.Drawing.Size(152, 6);
            // 
            // OpenOption
            // 
            this.OpenOption.Name = "OpenOption";
            this.OpenOption.Size = new System.Drawing.Size(155, 22);
            this.OpenOption.Text = "설정 및 도움말";
            this.OpenOption.Click += new System.EventHandler(this.Option_Click);
            // 
            // Information
            // 
            this.Information.Name = "Information";
            this.Information.Size = new System.Drawing.Size(155, 22);
            this.Information.Text = "프로그램 정보";
            this.Information.Click += new System.EventHandler(this.Information_Click);
            // 
            // Line3
            // 
            this.Line3.Name = "Line3";
            this.Line3.Size = new System.Drawing.Size(152, 6);
            // 
            // ShutDown
            // 
            this.ShutDown.Name = "ShutDown";
            this.ShutDown.Size = new System.Drawing.Size(155, 22);
            this.ShutDown.Text = "프로그램 종료";
            this.ShutDown.Click += new System.EventHandler(this.ShutDown_Click);
            // 
            // TrayIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TrayIcon";
            this.Text = "TrayIcon";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Shown += new System.EventHandler(this.TrayIcon_Shown);
            this.TrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon MainTrayIcon;
        private MetroFramework.Controls.MetroContextMenu TrayMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenWindow;
        private System.Windows.Forms.ToolStripSeparator Line1;
        private System.Windows.Forms.ToolStripMenuItem OpenOption;
        private System.Windows.Forms.ToolStripMenuItem Information;
        private System.Windows.Forms.ToolStripSeparator Line2;
        private System.Windows.Forms.ToolStripMenuItem ShutDown;
        private System.Windows.Forms.ToolStripMenuItem OpenRoomList;
        private System.Windows.Forms.ToolStripSeparator Line3;
        private System.Windows.Forms.ToolStripMenuItem OpenAnalyzer;
        private System.Windows.Forms.ToolStripMenuItem OpenAdditionalTool;
    }
}