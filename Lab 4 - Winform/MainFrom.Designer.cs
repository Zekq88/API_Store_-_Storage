﻿namespace Lab_4___Winform
{
    partial class MainForm
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
            this.logInBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logInBox
            // 
            this.logInBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logInBox.FormattingEnabled = true;
            this.logInBox.Items.AddRange(new object[] {
            "Webbutik",
            "Lager"});
            this.logInBox.Location = new System.Drawing.Point(105, 60);
            this.logInBox.Name = "logInBox";
            this.logInBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logInBox.Size = new System.Drawing.Size(107, 21);
            this.logInBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Logga in";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 179);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.logInBox);
            this.Name = "MainForm";
            this.Text = "Inloggning";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox logInBox;
        private System.Windows.Forms.Button button1;
    }
}
