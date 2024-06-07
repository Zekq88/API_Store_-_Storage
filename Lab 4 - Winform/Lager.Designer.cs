namespace Lab_4___Winform
{
    partial class Lager
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.orderBtn = new System.Windows.Forms.Button();
            this.getBackBtn = new System.Windows.Forms.Button();
            this.rebootBtn = new System.Windows.Forms.Button();
            this.bookListView = new System.Windows.Forms.ListView();
            this.gameListView = new System.Windows.Forms.ListView();
            this.movieListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.movieListView);
            this.groupBox1.Controls.Add(this.gameListView);
            this.groupBox1.Controls.Add(this.bookListView);
            this.groupBox1.Location = new System.Drawing.Point(123, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 653);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lager Saldo";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(21, 191);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "Lägg till";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(21, 294);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(75, 23);
            this.removeBtn.TabIndex = 2;
            this.removeBtn.Text = "Ta bort";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // orderBtn
            // 
            this.orderBtn.Location = new System.Drawing.Point(21, 246);
            this.orderBtn.Name = "orderBtn";
            this.orderBtn.Size = new System.Drawing.Size(75, 23);
            this.orderBtn.TabIndex = 3;
            this.orderBtn.Text = "Beställ";
            this.orderBtn.UseVisualStyleBackColor = true;
            this.orderBtn.Click += new System.EventHandler(this.orderBtn_Click);
            // 
            // getBackBtn
            // 
            this.getBackBtn.Location = new System.Drawing.Point(21, 415);
            this.getBackBtn.Name = "getBackBtn";
            this.getBackBtn.Size = new System.Drawing.Size(75, 23);
            this.getBackBtn.TabIndex = 1;
            this.getBackBtn.Text = "Tillbaka";
            this.getBackBtn.UseVisualStyleBackColor = true;
            this.getBackBtn.Click += new System.EventHandler(this.getBackBtn_Click);
            // 
            // rebootBtn
            // 
            this.rebootBtn.Location = new System.Drawing.Point(12, 52);
            this.rebootBtn.Name = "rebootBtn";
            this.rebootBtn.Size = new System.Drawing.Size(96, 23);
            this.rebootBtn.TabIndex = 4;
            this.rebootBtn.Text = "Nollställ Data";
            this.rebootBtn.UseVisualStyleBackColor = true;
            this.rebootBtn.Click += new System.EventHandler(this.rebootBtn_Click);
            // 
            // bookListView
            // 
            this.bookListView.HideSelection = false;
            this.bookListView.Location = new System.Drawing.Point(6, 52);
            this.bookListView.Name = "bookListView";
            this.bookListView.Size = new System.Drawing.Size(653, 155);
            this.bookListView.TabIndex = 0;
            this.bookListView.UseCompatibleStateImageBehavior = false;
            // 
            // gameListView
            // 
            this.gameListView.HideSelection = false;
            this.gameListView.Location = new System.Drawing.Point(6, 249);
            this.gameListView.Name = "gameListView";
            this.gameListView.Size = new System.Drawing.Size(653, 167);
            this.gameListView.TabIndex = 1;
            this.gameListView.UseCompatibleStateImageBehavior = false;
            // 
            // movieListView
            // 
            this.movieListView.HideSelection = false;
            this.movieListView.Location = new System.Drawing.Point(6, 460);
            this.movieListView.Name = "movieListView";
            this.movieListView.Size = new System.Drawing.Size(653, 171);
            this.movieListView.TabIndex = 2;
            this.movieListView.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(282, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Böcker";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(293, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Spel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(282, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Filmer";
            // 
            // Lager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 687);
            this.Controls.Add(this.rebootBtn);
            this.Controls.Add(this.getBackBtn);
            this.Controls.Add(this.orderBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.groupBox1);
            this.Name = "Lager";
            this.Text = "Lager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Button orderBtn;
        private System.Windows.Forms.Button getBackBtn;
        private System.Windows.Forms.Button rebootBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView movieListView;
        private System.Windows.Forms.ListView gameListView;
        private System.Windows.Forms.ListView bookListView;
    }
}