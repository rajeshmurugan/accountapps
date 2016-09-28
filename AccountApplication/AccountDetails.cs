using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace AccountApplication
{
    public partial class AccountDetails : Form
    {
        Welcome welcome = null;
 
        public AccountDetails()
        {
            InitializeComponent();
            welcome = new Welcome();
        }

        private void AccountDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'accountsDBDataSet.AccountsTable' table. You can move, or remove it, as needed.
            this.accountsTableTableAdapter.Fill(this.accountsDBDataSet.AccountsTable);
            comboBoxCompanyName.Items.Clear();
            comboBoxCompanyName.Items.Add("All");
            comboBoxCompanyName.SelectedIndex = 0;
            FillCompanyName();            
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Text.Equals(""))
            { 
                MessageBox.Show("Please check the date", "Alert!!!", MessageBoxButtons.OK);
                return;
            }
            DateTime dateFrom = Convert.ToDateTime(dateTimePickerFrom.Text);
            DateTime dateEnd = Convert.ToDateTime(dateTimePickerEnd.Text);
            if (dateFrom > DateTime.Today || dateEnd > DateTime.Today)
            {
                MessageBox.Show("Please check the date which shouldn't be future date", "Alert!!!", MessageBoxButtons.OK);
                return;
            }

            ReFillSearchInformation();
        }

        private void FillCompanyName()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.AccountsDBConnectionString);
            try
            {
                string query = "SELECT DISTINCT CompanyName FROM AccountsTable";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable table = new DataTable();
                SqlDataReader DR = cmd.ExecuteReader();
                while (DR.Read())
                {
                    comboBoxCompanyName.Items.Add(DR[0]);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database failed to connect/fetch information" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void ReFillSearchInformation()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.AccountsDBConnectionString);
            try
            {
                string query = "SELECT CompanyName, PurchaseDate, Quantity, BaseRate, PaidAmount, Balance, Notes FROM AccountsTable WHERE ";
                query += "PurchaseDate >= '" + dateTimePickerFrom.Text + "' and PurchaseDate <= '" + dateTimePickerEnd.Text + "' ";

                if (!comboBoxCompanyName.SelectedItem.ToString().Equals("All"))
                    query += " and CompanyName <= '" + comboBoxCompanyName.SelectedText + "' ";

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable table = new DataTable();
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                {
                    a.Fill(table);
                }
                dataGridViewAccountDetails.DataSource = table;
                dataGridViewAccountDetails.Refresh();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database failed to connect/fetch information" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void AccountDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            welcome.Show();
        }
    }
}
