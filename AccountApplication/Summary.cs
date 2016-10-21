using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AccountApplication
{
    public partial class Summary : Form
    {
        public Summary()
        {
            InitializeComponent();
        }

        private void Summary_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'accountsDBDataSetCompanyName.AccountsTable' table. You can move, or remove it, as needed.
            this.accountsTableTableAdapter.Fill(this.accountsDBDataSetCompanyName.AccountsTable);

            // Load Summary Table information
            FillSummaryInformation();

        }        
        private void buttonGo_Click(object sender, EventArgs e)
        {

        }
        private void FillSummaryInformation()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.AccountsDBConnectionString);
            try
            {
                string query = "SELECT ROW_NUMBER() Over (Order by CompanyName) As [S.No], CompanyName, Balance FROM AccountsTable WHERE IsIncludePreviousBill = 'True'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable table = new DataTable();
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                {
                    a.Fill(table);
                }
                dataGridViewSummary.DataSource = table;
                dataGridViewSummary.Refresh();
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
    }
}
