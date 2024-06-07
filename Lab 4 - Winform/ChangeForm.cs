using System;
using System.Windows.Forms;

namespace Lab_4___Winform
{
    public partial class ChangeForm : Form
    {
        private Lager lager;
        public ChangeForm(Lager lager)
        {
            InitializeComponent();
            this.lager = lager;
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(orderBox.Text))
            {
                int i = int.Parse(orderBox.Text);
                lager.changingProduct(i);
                this.Close();
            }
            else
            {
                MessageBox.Show("Du behöver skriva in siffror");
            }

        }
    }
}
