namespace Cirnix.Forms
{
    partial class HistoryForm
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
            this.TB_History = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label_Title
            // 
            this.Label_Title.BackColor = System.Drawing.Color.Transparent;
            this.Label_Title.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_Title.Location = new System.Drawing.Point(180, 10);
            this.Label_Title.Margin = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(140, 20);
            this.Label_Title.TabIndex = 9;
            this.Label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_History
            // 
            this.TB_History.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_History.BackColor = System.Drawing.Color.White;
            this.TB_History.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_History.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.TB_History.Location = new System.Drawing.Point(10, 35);
            this.TB_History.Margin = new System.Windows.Forms.Padding(0);
            this.TB_History.Multiline = true;
            this.TB_History.Name = "TB_History";
            this.TB_History.ReadOnly = true;
            this.TB_History.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_History.Size = new System.Drawing.Size(480, 455);
            this.TB_History.TabIndex = 10;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.TB_History);
            this.Controls.Add(this.Label_Title);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistoryForm";
            this.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.TextBox TB_History;
    }
}