using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AccountApplication
{
    public partial class Welcome : Form
    {
        Entry entry = null;
        AccountDetails accountDetail = null;
        public Welcome()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            entry = new Entry();          
            entry.Show();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            accountDetail = new AccountDetails();
            accountDetail.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
