using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab_4___Winform
{
    public partial class PayForm : Form
    {
        private List<string> cartList;
        public PayForm(List<string> cartList)
        {
            InitializeComponent();
            this.cartList = cartList;
            receiptListBox.Items.Clear();
            foreach (string item in cartList)
            {
                receiptListBox.Items.Add(item.Replace(",", " "));
            }

        }
    }
}
