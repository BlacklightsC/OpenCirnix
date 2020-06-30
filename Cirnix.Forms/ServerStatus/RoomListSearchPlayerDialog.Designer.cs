namespace Cirnix.Forms.ServerStatus
{
    partial class RoomListSearchPlayerDialog
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
            this.Label_Title = new System.Windows.Forms.Label();
            this.BTN_Search = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.TB_ID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label_Title
            // 
            this.Label_Title.BackColor = System.Drawing.Color.Transparent;
            this.Label_Title.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_Title.Location = new System.Drawing.Point(45, 10);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(90, 20);
            this.Label_Title.TabIndex = 9;
            this.Label_Title.Text = "플레이어 검색";
            this.Label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_Search
            // 
            this.BTN_Search.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_Search.Location = new System.Drawing.Point(9, 59);
            this.BTN_Search.Name = "BTN_Search";
            this.BTN_Search.Size = new System.Drawing.Size(80, 23);
            this.BTN_Search.TabIndex = 2;
            this.BTN_Search.Text = "검색";
            this.BTN_Search.UseVisualStyleBackColor = true;
            this.BTN_Search.Click += new System.EventHandler(this.BTN_Search_Click);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_Cancel.Location = new System.Drawing.Point(91, 59);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(80, 23);
            this.BTN_Cancel.TabIndex = 3;
            this.BTN_Cancel.Text = "취소";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // TB_ID
            // 
            this.TB_ID.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.TB_ID.Location = new System.Drawing.Point(10, 35);
            this.TB_ID.MaxLength = 15;
            this.TB_ID.Name = "TB_ID";
            this.TB_ID.Size = new System.Drawing.Size(160, 22);
            this.TB_ID.TabIndex = 1;
            this.TB_ID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RoomListSearchPlayerDialog_KeyDown);
            // 
            // RoomListSearchPlayerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 90);
            this.Controls.Add(this.TB_ID);
            this.Controls.Add(this.BTN_Cancel);
            this.Controls.Add(this.BTN_Search);
            this.Controls.Add(this.Label_Title);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomListSearchPlayerDialog";
            this.Padding = new System.Windows.Forms.Padding(5, 30, 5, 5);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "플레이어 검색";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RoomListSearchPlayerDialog_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.Button BTN_Search;
        private System.Windows.Forms.Button BTN_Cancel;
        private System.Windows.Forms.TextBox TB_ID;
    }
}