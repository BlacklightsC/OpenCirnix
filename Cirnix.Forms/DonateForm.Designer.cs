namespace Cirnix.Forms
{
    partial class DonateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonateForm));
            this.Label_Title = new System.Windows.Forms.Label();
            this.Label_Text = new System.Windows.Forms.Label();
            this.BTN_Paypal = new System.Windows.Forms.Button();
            this.Label_Toonation = new System.Windows.Forms.Label();
            this.BTN_Toonation = new System.Windows.Forms.Button();
            this.BTN_Patreon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Bank = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label_Title
            // 
            this.Label_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Title.BackColor = System.Drawing.Color.Transparent;
            this.Label_Title.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_Title.Location = new System.Drawing.Point(130, 10);
            this.Label_Title.Margin = new System.Windows.Forms.Padding(200, 0, 200, 0);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(340, 20);
            this.Label_Title.TabIndex = 9;
            this.Label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Text
            // 
            this.Label_Text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Label_Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Text.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Label_Text.Location = new System.Drawing.Point(10, 46);
            this.Label_Text.Name = "Label_Text";
            this.Label_Text.Size = new System.Drawing.Size(580, 446);
            this.Label_Text.TabIndex = 12;
            this.Label_Text.Text = resources.GetString("Label_Text.Text");
            // 
            // BTN_Paypal
            // 
            this.BTN_Paypal.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.BTN_Paypal.Location = new System.Drawing.Point(225, 580);
            this.BTN_Paypal.Name = "BTN_Paypal";
            this.BTN_Paypal.Size = new System.Drawing.Size(150, 50);
            this.BTN_Paypal.TabIndex = 15;
            this.BTN_Paypal.Text = "페이팔";
            this.BTN_Paypal.UseVisualStyleBackColor = true;
            this.BTN_Paypal.Click += new System.EventHandler(this.BTN_Paypal_Click);
            // 
            // Label_Toonation
            // 
            this.Label_Toonation.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Label_Toonation.Location = new System.Drawing.Point(35, 635);
            this.Label_Toonation.Name = "Label_Toonation";
            this.Label_Toonation.Size = new System.Drawing.Size(150, 20);
            this.Label_Toonation.TabIndex = 17;
            this.Label_Toonation.Text = "국내 후원 대행사";
            this.Label_Toonation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BTN_Toonation
            // 
            this.BTN_Toonation.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.BTN_Toonation.Location = new System.Drawing.Point(35, 580);
            this.BTN_Toonation.Name = "BTN_Toonation";
            this.BTN_Toonation.Size = new System.Drawing.Size(150, 50);
            this.BTN_Toonation.TabIndex = 18;
            this.BTN_Toonation.Text = "투네이션";
            this.BTN_Toonation.UseVisualStyleBackColor = true;
            this.BTN_Toonation.Click += new System.EventHandler(this.BTN_Toonation_Click);
            // 
            // BTN_Patreon
            // 
            this.BTN_Patreon.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.BTN_Patreon.Location = new System.Drawing.Point(415, 580);
            this.BTN_Patreon.Name = "BTN_Patreon";
            this.BTN_Patreon.Size = new System.Drawing.Size(150, 50);
            this.BTN_Patreon.TabIndex = 19;
            this.BTN_Patreon.Text = "Patreon";
            this.BTN_Patreon.UseVisualStyleBackColor = true;
            this.BTN_Patreon.Click += new System.EventHandler(this.BTN_Patreon_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.label1.Location = new System.Drawing.Point(225, 635);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "해외 송금 서비스";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.label2.Location = new System.Drawing.Point(415, 635);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "해외 정기 구독 서비스";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TB_Bank
            // 
            this.TB_Bank.BackColor = System.Drawing.Color.White;
            this.TB_Bank.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Bank.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.TB_Bank.Location = new System.Drawing.Point(183, 502);
            this.TB_Bank.Margin = new System.Windows.Forms.Padding(1);
            this.TB_Bank.Multiline = true;
            this.TB_Bank.Name = "TB_Bank";
            this.TB_Bank.ReadOnly = true;
            this.TB_Bank.Size = new System.Drawing.Size(235, 65);
            this.TB_Bank.TabIndex = 22;
            this.TB_Bank.Text = "카카오뱅크 3333-09-4274361\r\n농협중앙회 302-0627-1751-31\r\n예금주: 박성현";
            this.TB_Bank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DonateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 670);
            this.Controls.Add(this.TB_Bank);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_Patreon);
            this.Controls.Add(this.BTN_Toonation);
            this.Controls.Add(this.Label_Toonation);
            this.Controls.Add(this.BTN_Paypal);
            this.Controls.Add(this.Label_Text);
            this.Controls.Add(this.Label_Title);
            this.DisplayHeader = false;
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DonateForm";
            this.Padding = new System.Windows.Forms.Padding(5, 30, 5, 5);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Cirnix 부가 기능";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.Label Label_Text;
        private System.Windows.Forms.Button BTN_Paypal;
        private System.Windows.Forms.Label Label_Toonation;
        private System.Windows.Forms.Button BTN_Toonation;
        private System.Windows.Forms.Button BTN_Patreon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Bank;
    }
}