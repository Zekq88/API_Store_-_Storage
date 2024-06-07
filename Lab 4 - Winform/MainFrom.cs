using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using System.Xml;

namespace Lab_4___Winform
{
    public partial class MainForm : Form
    {
        private Lager lager;
        private Webbutik webbutik;

        
        public MainForm()
        {

            InitializeComponent();
            logInBox.SelectedIndex = 0;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = logInBox.SelectedIndex;

            if (index == 0)
            {
                //Webb
                webbutik = new Webbutik(this);
                webbutik.FormClosed += (s, args) => this.Show();
                this.Hide();
                webbutik.Show();
            }
            else if (index == 1)
            {
                //Lager
                lager = new Lager(this);
                lager.FormClosed += (s, args) => this.Show();
                this.Hide();
                lager.Show();
            }
            else
            {
                return;
            }
        }
    }
}
