﻿namespace Cirnix.Forms
{
    partial class LicenceForm
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
            this.BTN_OK = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // BTN_OK
            // 
            this.BTN_OK.Highlight = true;
            this.BTN_OK.Location = new System.Drawing.Point(419, 716);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(100, 35);
            this.BTN_OK.TabIndex = 4;
            this.BTN_OK.Text = "확인";
            this.BTN_OK.UseSelectable = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_click);
            // 
            // LicenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 764);
            this.Controls.Add(this.BTN_OK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenceForm";
            this.Padding = new System.Windows.Forms.Padding(10, 60, 10, 10);
            this.Resizable = false;
            this.Text = "MIT Licence";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.LicenceForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public MetroFramework.Controls.MetroButton BTN_OK;
    }
}