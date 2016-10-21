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
        String companyName = "";
        public Welcome(String _companyName = "")
        {
            InitializeComponent();
            this.companyName = _companyName;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            entry = new Entry(companyName);          
            entry.Show();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            this.Hide();
            accountDetail = new AccountDetails(companyName);
            accountDetail.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
