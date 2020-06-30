namespace Cirnix.Forms.Update
{
	partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.progressBarUpdateState = new MetroFramework.Controls.MetroProgressBar();
            this.LabelMsg = new MetroFramework.Controls.MetroLabel();
            this.LabelTitle = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // progressBarUpdateState
            // 
            this.progressBarUpdateState.Location = new System.Drawing.Point(12, 38);
            this.progressBarUpdateState.Name = "progressBarUpdateState";
            this.progressBarUpdateState.Size = new System.Drawing.Size(350, 25);
            this.progressBarUpdateState.TabIndex = 1;
            // 
            // LabelMsg
            // 
            this.LabelMsg.Location = new System.Drawing.Point(12, 69);
            this.LabelMsg.Margin = new System.Windows.Forms.Padding(3);
            this.LabelMsg.Name = "LabelMsg";
            this.LabelMsg.Size = new System.Drawing.Size(350, 50);
            this.LabelMsg.TabIndex = 2;
            this.LabelMsg.Text = "업데이트 서버에 연결 중...";
            this.LabelMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelTitle
            // 
            this.LabelTitle.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.LabelTitle.Location = new System.Drawing.Point(62, 12);
            this.LabelTitle.Margin = new System.Windows.Forms.Padding(3);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(250, 20);
            this.LabelTitle.TabIndex = 3;
            this.LabelTitle.Text = "업데이트 중이니 종료하지 마세요!";
            this.LabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 130);
            this.Controls.Add(this.LabelTitle);
            this.Controls.Add(this.LabelMsg);
            this.Controls.Add(this.progressBarUpdateState);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateForm_FormClosing);
            this.ResumeLayout(false);

		}

		#endregion
		private MetroFramework.Controls.MetroProgressBar progressBarUpdateState;
		private MetroFramework.Controls.MetroLabel LabelMsg;
		private MetroFramework.Controls.MetroLabel LabelTitle;
	}
}