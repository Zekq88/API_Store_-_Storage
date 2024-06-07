namespace Lab_4___Winform
{
    partial class AddProduct
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
            this.productBox = new System.Windows.Forms.ComboBox();
            this.labelProduct = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.AddProductBtn = new System.Windows.Forms.Button();
            this.STOCKbox = new System.Windows.Forms.TextBox();
            this.IDbox = new System.Windows.Forms.TextBox();
            this.StockText = new System.Windows.Forms.Label();
            this.IdText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // productBox
            // 
            this.productBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productBox.FormattingEnabled = true;
            this.productBox.Items.AddRange(new object[] {
            "Böcker",
            "Dataspel",
            "Filmer"});
            this.productBox.Location = new System.Drawing.Point(138, 43);
            this.productBox.Name = "productBox";
            this.productBox.Size = new System.Drawing.Size(121, 21);
            this.productBox.TabIndex = 0;
            this.productBox.SelectedIndexChanged += new System.EventHandler(this.productBox_SelectedIndexChanged);
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(12, 46);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(69, 13);
            this.labelProduct.TabIndex = 1;
            this.labelProduct.Text = "Välj produkt: ";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(13, 135);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(13, 166);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(24, 13);
            this.priceLabel.TabIndex = 3;
            this.priceLabel.Text = "Pris";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Författare";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Genre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Format";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Språk";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(111, 132);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 20);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(111, 162);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(165, 20);
            this.textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(111, 232);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(165, 20);
            this.textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(111, 267);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(165, 20);
            this.textBox4.TabIndex = 11;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(111, 304);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(165, 20);
            this.textBox5.TabIndex = 12;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(111, 341);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(165, 20);
            this.textBox6.TabIndex = 13;
            // 
            // AddProductBtn
            // 
            this.AddProductBtn.Location = new System.Drawing.Point(201, 415);
            this.AddProductBtn.Name = "AddProductBtn";
            this.AddProductBtn.Size = new System.Drawing.Size(75, 23);
            this.AddProductBtn.TabIndex = 14;
            this.AddProductBtn.Text = "Lägg till";
            this.AddProductBtn.UseVisualStyleBackColor = true;
            this.AddProductBtn.Click += new System.EventHandler(this.AddProductBtn_Click);
            // 
            // STOCKbox
            // 
            this.STOCKbox.Location = new System.Drawing.Point(111, 198);
            this.STOCKbox.Name = "STOCKbox";
            this.STOCKbox.Size = new System.Drawing.Size(165, 20);
            this.STOCKbox.TabIndex = 15;
            // 
            // IDbox
            // 
            this.IDbox.Location = new System.Drawing.Point(111, 101);
            this.IDbox.Name = "IDbox";
            this.IDbox.Size = new System.Drawing.Size(165, 20);
            this.IDbox.TabIndex = 16;
            // 
            // StockText
            // 
            this.StockText.AutoSize = true;
            this.StockText.Location = new System.Drawing.Point(12, 201);
            this.StockText.Name = "StockText";
            this.StockText.Size = new System.Drawing.Size(31, 13);
            this.StockText.TabIndex = 17;
            this.StockText.Text = "Antal";
            // 
            // IdText
            // 
            this.IdText.AutoSize = true;
            this.IdText.Location = new System.Drawing.Point(12, 104);
            this.IdText.Name = "IdText";
            this.IdText.Size = new System.Drawing.Size(16, 13);
            this.IdText.TabIndex = 18;
            this.IdText.Text = "Id";
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 467);
            this.Controls.Add(this.IdText);
            this.Controls.Add(this.StockText);
            this.Controls.Add(this.IDbox);
            this.Controls.Add(this.STOCKbox);
            this.Controls.Add(this.AddProductBtn);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.labelProduct);
            this.Controls.Add(this.productBox);
            this.Name = "AddProduct";
            this.Text = "Lägg till produkt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox productBox;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button AddProductBtn;
        private System.Windows.Forms.TextBox STOCKbox;
        private System.Windows.Forms.TextBox IDbox;
        private System.Windows.Forms.Label StockText;
        private System.Windows.Forms.Label IdText;
    }
}