namespace Cirnix.Forms
{
    partial class AdditionalToolForm
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
            this.BTN_CheatMapCheck = new System.Windows.Forms.Button();
            this.BTN_ConvertScreenShot = new System.Windows.Forms.Button();
            this.List_Data = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.States = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Combo_ScreenShotExtension = new MetroFramework.Controls.MetroComboBox();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.List_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_Title
            // 
            this.Label_Title.BackColor = System.Drawing.Color.Transparent;
            this.Label_Title.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_Title.Location = new System.Drawing.Point(80, 10);
            this.Label_Title.Margin = new System.Windows.Forms.Padding(150, 0, 150, 0);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(140, 20);
            this.Label_Title.TabIndex = 9;
            this.Label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_CheatMapCheck
            // 
            this.BTN_CheatMapCheck.Location = new System.Drawing.Point(15, 37);
            this.BTN_CheatMapCheck.Name = "BTN_CheatMapCheck";
            this.BTN_CheatMapCheck.Size = new System.Drawing.Size(90, 31);
            this.BTN_CheatMapCheck.TabIndex = 10;
            this.BTN_CheatMapCheck.Text = "치트맵 검사";
            this.BTN_CheatMapCheck.UseVisualStyleBackColor = true;
            this.BTN_CheatMapCheck.Click += new System.EventHandler(this.BTN_CheatMapCheck_Click);
            // 
            // BTN_ConvertScreenShot
            // 
            this.BTN_ConvertScreenShot.Location = new System.Drawing.Point(120, 37);
            this.BTN_ConvertScreenShot.Name = "BTN_ConvertScreenShot";
            this.BTN_ConvertScreenShot.Size = new System.Drawing.Size(100, 31);
            this.BTN_ConvertScreenShot.TabIndex = 11;
            this.BTN_ConvertScreenShot.Text = "스크린샷 변환";
            this.BTN_ConvertScreenShot.UseVisualStyleBackColor = true;
            this.BTN_ConvertScreenShot.Click += new System.EventHandler(this.BTN_ConvertScreenShot_Click);
            // 
            // List_Data
            // 
            this.List_Data.AllowUserToAddRows = false;
            this.List_Data.AllowUserToDeleteRows = false;
            this.List_Data.AllowUserToResizeColumns = false;
            this.List_Data.AllowUserToResizeRows = false;
            this.List_Data.BackgroundColor = System.Drawing.Color.White;
            this.List_Data.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.List_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.List_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.States});
            this.List_Data.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.List_Data.Location = new System.Drawing.Point(8, 73);
            this.List_Data.MultiSelect = false;
            this.List_Data.Name = "List_Data";
            this.List_Data.ReadOnly = true;
            this.List_Data.RowHeadersVisible = false;
            this.List_Data.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.List_Data.RowTemplate.Height = 23;
            this.List_Data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.List_Data.Size = new System.Drawing.Size(284, 319);
            this.List_Data.TabIndex = 14;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "파일 이름";
            this.FileName.MinimumWidth = 110;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FileName.Width = 203;
            // 
            // States
            // 
            this.States.FillWeight = 50F;
            this.States.HeaderText = "상태";
            this.States.MinimumWidth = 20;
            this.States.Name = "States";
            this.States.ReadOnly = true;
            this.States.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.States.Width = 61;
            // 
            // Combo_ScreenShotExtension
            // 
            this.Combo_ScreenShotExtension.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Combo_ScreenShotExtension.FormattingEnabled = true;
            this.Combo_ScreenShotExtension.ItemHeight = 23;
            this.Combo_ScreenShotExtension.Items.AddRange(new object[] {
            "PNG",
            "JPG",
            "GIF",
            "BMP"});
            this.Combo_ScreenShotExtension.Location = new System.Drawing.Point(225, 38);
            this.Combo_ScreenShotExtension.Name = "Combo_ScreenShotExtension";
            this.Combo_ScreenShotExtension.Size = new System.Drawing.Size(60, 29);
            this.Combo_ScreenShotExtension.TabIndex = 20;
            this.Combo_ScreenShotExtension.UseSelectable = true;
            // 
            // Worker
            // 
            this.Worker.WorkerReportsProgress = true;
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // AdditionalToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 400);
            this.Controls.Add(this.Combo_ScreenShotExtension);
            this.Controls.Add(this.List_Data);
            this.Controls.Add(this.BTN_ConvertScreenShot);
            this.Controls.Add(this.BTN_CheatMapCheck);
            this.Controls.Add(this.Label_Title);
            this.DisplayHeader = false;
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "AdditionalToolForm";
            this.Padding = new System.Windows.Forms.Padding(5, 30, 5, 5);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Cirnix 부가 기능";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdditionalToolForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.List_Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.Button BTN_CheatMapCheck;
        private System.Windows.Forms.Button BTN_ConvertScreenShot;
        private System.Windows.Forms.DataGridView List_Data;
        private MetroFramework.Controls.MetroComboBox Combo_ScreenShotExtension;
        private System.ComponentModel.BackgroundWorker Worker;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn States;
    }
}