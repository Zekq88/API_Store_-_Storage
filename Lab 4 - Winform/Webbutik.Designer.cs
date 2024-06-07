namespace Lab_4___Winform
{
    partial class Webbutik
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
            this.getBackBtn = new System.Windows.Forms.Button();
            this.cartBtn = new System.Windows.Forms.Button();
            this.buyBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cartNr = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.movieListView = new System.Windows.Forms.ListView();
            this.gameListView = new System.Windows.Forms.ListView();
            this.bookListView = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // getBackBtn
            // 
            this.getBackBtn.Location = new System.Drawing.Point(17, 410);
            this.getBackBtn.Name = "getBackBtn";
            this.getBackBtn.Size = new System.Drawing.Size(75, 23);
            this.getBackBtn.TabIndex = 5;
            this.getBackBtn.Text = "Tillbaka";
            this.getBackBtn.UseVisualStyleBackColor = true;
            this.getBackBtn.Click += new System.EventHandler(this.getBackBtn_Click);
            // 
            // cartBtn
            // 
            this.cartBtn.Location = new System.Drawing.Point(17, 327);
            this.cartBtn.Name = "cartBtn";
            this.cartBtn.Size = new System.Drawing.Size(75, 23);
            this.cartBtn.TabIndex = 7;
            this.cartBtn.Text = "Betala";
            this.cartBtn.UseVisualStyleBackColor = true;
            this.cartBtn.Click += new System.EventHandler(this.cartBtn_Click);
            // 
            // buyBtn
            // 
            this.buyBtn.Location = new System.Drawing.Point(17, 246);
            this.buyBtn.Name = "buyBtn";
            this.buyBtn.Size = new System.Drawing.Size(75, 23);
            this.buyBtn.TabIndex = 6;
            this.buyBtn.Text = "Köp";
            this.buyBtn.UseVisualStyleBackColor = true;
            this.buyBtn.Click += new System.EventHandler(this.buyBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.movieListView);
            this.groupBox1.Controls.Add(this.gameListView);
            this.groupBox1.Controls.Add(this.bookListView);
            this.groupBox1.Location = new System.Drawing.Point(119, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 637);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Webb Butik";
            // 
            // cartNr
            // 
            this.cartNr.AutoSize = true;
            this.cartNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartNr.Location = new System.Drawing.Point(87, 35);
            this.cartNr.Name = "cartNr";
            this.cartNr.Size = new System.Drawing.Size(26, 29);
            this.cartNr.TabIndex = 9;
            this.cartNr.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Kundkorg:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(282, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Filmer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(293, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Spel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(282, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Böcker";
            // 
            // movieListView
            // 
            this.movieListView.HideSelection = false;
            this.movieListView.Location = new System.Drawing.Point(6, 455);
            this.movieListView.Name = "movieListView";
            this.movieListView.Size = new System.Drawing.Size(653, 171);
            this.movieListView.TabIndex = 8;
            this.movieListView.UseCompatibleStateImageBehavior = false;
            // 
            // gameListView
            // 
            this.gameListView.HideSelection = false;
            this.gameListView.Location = new System.Drawing.Point(6, 244);
            this.gameListView.Name = "gameListView";
            this.gameListView.Size = new System.Drawing.Size(653, 167);
            this.gameListView.TabIndex = 7;
            this.gameListView.UseCompatibleStateImageBehavior = false;
            // 
            // bookListView
            // 
            this.bookListView.HideSelection = false;
            this.bookListView.Location = new System.Drawing.Point(6, 47);
            this.bookListView.Name = "bookListView";
            this.bookListView.Size = new System.Drawing.Size(653, 155);
            this.bookListView.TabIndex = 6;
            this.bookListView.UseCompatibleStateImageBehavior = false;
            // 
            // Webbutik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 666);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cartNr);
            this.Controls.Add(this.getBackBtn);
            this.Controls.Add(this.cartBtn);
            this.Controls.Add(this.buyBtn);
            this.Controls.Add(this.groupBox1);
            this.Name = "Webbutik";
            this.Text = "Webbutik";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getBackBtn;
        private System.Windows.Forms.Button cartBtn;
        private System.Windows.Forms.Button buyBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label cartNr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView movieListView;
        private System.Windows.Forms.ListView gameListView;
        private System.Windows.Forms.ListView bookListView;
    }
}