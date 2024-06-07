namespace Lab_4___Winform
{
    partial class ChangeForm
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
            this.orderBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.orderBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // orderBtn
            // 
            this.orderBtn.Location = new System.Drawing.Point(287, 47);
            this.orderBtn.Name = "orderBtn";
            this.orderBtn.Size = new System.Drawing.Size(75, 23);
            this.orderBtn.TabIndex = 0;
            this.orderBtn.Text = "Beställ";
            this.orderBtn.UseVisualStyleBackColor = true;
            this.orderBtn.Click += new System.EventHandler(this.orderBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hur mycket vill du beställa? Skriv en summa.";
            // 
            // orderBox
            // 
            this.orderBox.Location = new System.Drawing.Point(97, 47);
            this.orderBox.Name = "orderBox";
            this.orderBox.Size = new System.Drawing.Size(144, 20);
            this.orderBox.TabIndex = 2;
            // 
            // ChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 83);
            this.Controls.Add(this.orderBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.orderBtn);
            this.Name = "ChangeForm";
            this.Text = "ChangeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button orderBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox orderBox;
    }
}