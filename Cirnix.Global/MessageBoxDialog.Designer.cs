namespace Cirnix.Global
{
    partial class MessageBoxDialog
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
            this.BTN_Two = new System.Windows.Forms.Button();
            this.BTN_One = new System.Windows.Forms.Button();
            this.Label_Message = new System.Windows.Forms.Label();
            this.BTN_Three = new System.Windows.Forms.Button();
            this.BTN_Four = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label_Title
            // 
            this.Label_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Title.BackColor = System.Drawing.Color.Transparent;
            this.Label_Title.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_Title.Location = new System.Drawing.Point(30, 10);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(120, 20);
            this.Label_Title.TabIndex = 9;
            this.Label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_Two
            // 
            this.BTN_Two.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Two.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_Two.Location = new System.Drawing.Point(9, 59);
            this.BTN_Two.Name = "BTN_Two";
            this.BTN_Two.Size = new System.Drawing.Size(80, 23);
            this.BTN_Two.TabIndex = 2;
            this.BTN_Two.Text = "2";
            this.BTN_Two.UseVisualStyleBackColor = true;
            this.BTN_Two.Visible = false;
            // 
            // BTN_One
            // 
            this.BTN_One.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_One.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_One.Location = new System.Drawing.Point(91, 59);
            this.BTN_One.Name = "BTN_One";
            this.BTN_One.Size = new System.Drawing.Size(80, 23);
            this.BTN_One.TabIndex = 3;
            this.BTN_One.Text = "1";
            this.BTN_One.UseVisualStyleBackColor = true;
            // 
            // Label_Message
            // 
            this.Label_Message.AutoSize = true;
            this.Label_Message.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_Message.Location = new System.Drawing.Point(10, 37);
            this.Label_Message.Name = "Label_Message";
            this.Label_Message.Size = new System.Drawing.Size(0, 15);
            this.Label_Message.TabIndex = 10;
            this.Label_Message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_Message.Visible = false;
            // 
            // BTN_Three
            // 
            this.BTN_Three.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Three.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_Three.Location = new System.Drawing.Point(-73, 59);
            this.BTN_Three.Name = "BTN_Three";
            this.BTN_Three.Size = new System.Drawing.Size(80, 23);
            this.BTN_Three.TabIndex = 11;
            this.BTN_Three.Text = "3";
            this.BTN_Three.UseVisualStyleBackColor = true;
            this.BTN_Three.Visible = false;
            // 
            // BTN_Four
            // 
            this.BTN_Four.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Four.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_Four.Location = new System.Drawing.Point(-155, 59);
            this.BTN_Four.Name = "BTN_Four";
            this.BTN_Four.Size = new System.Drawing.Size(80, 23);
            this.BTN_Four.TabIndex = 12;
            this.BTN_Four.Text = "4";
            this.BTN_Four.UseVisualStyleBackColor = true;
            this.BTN_Four.Visible = false;
            // 
            // MessageBoxDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 90);
            this.Controls.Add(this.BTN_Four);
            this.Controls.Add(this.BTN_Three);
            this.Controls.Add(this.Label_Message);
            this.Controls.Add(this.BTN_One);
            this.Controls.Add(this.BTN_Two);
            this.Controls.Add(this.Label_Title);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageBoxDialog";
            this.Padding = new System.Windows.Forms.Padding(5, 30, 5, 5);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.Button BTN_Two;
        private System.Windows.Forms.Button BTN_One;
        private System.Windows.Forms.Label Label_Message;
        private System.Windows.Forms.Button BTN_Three;
        private System.Windows.Forms.Button BTN_Four;
    }
}