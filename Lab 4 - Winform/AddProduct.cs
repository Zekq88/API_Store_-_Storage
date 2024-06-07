using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4___Winform
{
    
    public partial class AddProduct : Form
    {
        private Lager lager;
        private Product product = new Product();
        private Movie movie;
        private Game game;
        private Book book;
        private List<int> ProductId;

        
        public AddProduct(Lager lager, List<int> i)
        {
            InitializeComponent();
            
            this.lager = lager;
           ProductId = i;
           productBox.SelectedIndex = 0;
        }

        private void productBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productBox.SelectedIndex == 0)
            {
                label1.Text = string.Empty;
                label2.Text = "Genre";
                label3.Text = "Format";
                label4.Text = "Språk";

                IDbox.Text = string.Empty;
                STOCKbox.Text = string.Empty; 
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Visible = false;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
            } 
            else if (productBox.SelectedIndex == 1)
            {
                label1.Text = "Plattform";
                label2.Text = string.Empty;
                label3.Text = string.Empty;
                label4.Text = string.Empty;

                IDbox.Text = string.Empty;
                STOCKbox.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox3.Visible = true;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
            }
            else if (productBox.SelectedIndex == 2)
            {
                label1.Text = "Format";
                label2.Text = "Speltid";
                label3.Text = string.Empty;
                label4.Text = string.Empty;
                IDbox.Text = string.Empty;
                STOCKbox.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = false;
                textBox6.Visible = false;
            }
            else
            {
                IDbox.Visible = false;
                STOCKbox.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
            }
        }

        private void AddProductBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (productBox.SelectedIndex == 0)
                {
                    int i = int.Parse(IDbox.Text);
                    if (ProductId.Contains(i))
                    {
                        i = ProductId.Max() + 1;
                        MessageBox.Show("Det Id du har anget är existerar redan,\n Programmet ger produkten ett nytt Id", "Ogiltit Id");
                    }

                    book = new Book(i, textBox1.Text, int.Parse(textBox2.Text), int.Parse(STOCKbox.Text), textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);

                    product.AddProduct(book);
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                    textBox6.Text = string.Empty;
                    IDbox.Text = string.Empty;
                    STOCKbox.Text = string.Empty;

                    
                    lager.addObj(book);
                    this.Close();
                }
                else if (productBox.SelectedIndex == 1)
                {
                    int i = int.Parse(IDbox.Text);
                    if (ProductId.Contains(i))
                    {
                        i = ProductId.Max() + 1;
                        MessageBox.Show("Det Id du har anget är existerar redan,\n Programmet ger produkten ett nytt Id", "Ogiltit Id");
                    }
                    game = new Game(i, textBox1.Text, int.Parse(textBox2.Text), int.Parse(STOCKbox.Text), textBox3.Text);
   
                    product.AddProduct(game);
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                    textBox6.Text = string.Empty;
                    IDbox.Text = string.Empty;
                    STOCKbox.Text = string.Empty;

                   
                    lager.addObj(game);
                    this.Close();
                }
                else if (productBox.SelectedIndex == 2)
                {
                    int i = int.Parse(textBox4.Text);
                    if (i < 0)
                    {
                        MessageBox.Show("Speltid kan inte vara negativ eller en bokstav", "Fel inmatning");
                        return;
                    }
                    else
                    {
                        int j = int.Parse(IDbox.Text);
                        if (ProductId.Contains(j))
                        {
                            j = ProductId.Max() + 1;
                            MessageBox.Show("Det Id du har anget är existerar redan,\n Programmet ger produkten ett nytt Id", "Ogiltit Id");
                        }
                        movie = new Movie(j, textBox1.Text, int.Parse(textBox2.Text), int.Parse(STOCKbox.Text), textBox3.Text, textBox4.Text);

                        product.AddProduct(movie);
                        textBox1.Text = string.Empty;
                        textBox2.Text = string.Empty;
                        textBox3.Text = string.Empty;
                        textBox4.Text = string.Empty;
                        textBox5.Text = string.Empty;
                        textBox6.Text = string.Empty;
                        IDbox.Text = string.Empty;
                        STOCKbox.Text = string.Empty;


                        lager.addObj(movie);
                    }

                    this.Close();
                }
            } catch (Exception ex){ MessageBox.Show(ex.Message); }
        }
    }
}
