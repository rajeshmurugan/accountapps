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
    public partial class Entry : Form
    {
        Welcome welcome = null;
        String companyName = "";
        public Entry(String _companyName = "")
        {
            InitializeComponent();
            this.companyName = _companyName;
            textBoxCompanyName.Text = _companyName;
            welcome = new Welcome();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Validate Information.
            if (dateTimePickerDate.Text.Equals(""))
            {
                MessageBox.Show("Please check the date", "Alert!!!", MessageBoxButtons.OK);
                return;
            }
            DateTime dateFrom = Convert.ToDateTime(dateTimePickerDate.Text);
            if (dateFrom > DateTime.Today)
            {
                MessageBox.Show("Please check the date which shouldn't be future date", "Alert!!!", MessageBoxButtons.OK);
                return;
            }
            if (textBoxCompanyName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter the company name", "Alert!!!", MessageBoxButtons.OK);
                return;
            }
            if (textBoxItemName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please check the item name", "Alert!!!", MessageBoxButtons.OK);
                return;
            }
            if (textBoxQuantity.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter the Quantity detail", "Alert!!!", MessageBoxButtons.OK);
                return;
            }
            if (textBoxBaseRate.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter the BaseRate detail", "Alert!!!", MessageBoxButtons.OK);
                return;
            }
            if (textBoxPaidAmount.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter the Paid Amount detail", "Alert!!!", MessageBoxButtons.OK);
                return;
            }
            if (textBoxBalance.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter the Balance detail", "Alert!!!", MessageBoxButtons.OK);
                return;
            }
            if (textBoxBillNumber.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter the Bill number detail", "Alert!!!", MessageBoxButtons.OK);
                return;
            }

            SqlConnection conn = new SqlConnection(Properties.Settings.Default.AccountsDBConnectionString);
            try
            {
                conn.Open();
                // If mention the previous balance then simply remove all existing balance
                if (checkBoxPreviousBal.Checked)
                {
                    SqlCommand commandUpdate = new SqlCommand("UPDATE AccountsTable set IsIncludePreviousBill = 'False' WHERE companyName ='"+ textBoxCompanyName.Text.Trim() + "'", conn);
                    commandUpdate.ExecuteNonQuery();
                }
                SqlCommand commandInsert = new SqlCommand("INSERT INTO AccountsTable (CompanyName, PurchaseDate, Quantity, BaseRate, PaidAmount, Balance, BillNumber, ItemName) VALUES (@CompanyName, @PurchaseDate, @Quantity, @BaseRate, @PaidAmount, @Balance, @BillNumber, @ItemName)", conn);
                commandInsert.Parameters.AddWithValue("@CompanyName", textBoxCompanyName.Text.Trim());
                commandInsert.Parameters.AddWithValue("@PurchaseDate", dateTimePickerDate.Text.Trim());
                commandInsert.Parameters.AddWithValue("@Quantity", textBoxQuantity.Text.Trim());
                commandInsert.Parameters.AddWithValue("@BaseRate", textBoxBaseRate.Text.Trim());
                commandInsert.Parameters.AddWithValue("@PaidAmount", textBoxPaidAmount.Text.Trim());
                commandInsert.Parameters.AddWithValue("@Balance", textBoxBalance.Text.Trim());
                commandInsert.Parameters.AddWithValue("@BillNumber", textBoxBillNumber.Text.Trim());
                commandInsert.Parameters.AddWithValue("@ItemName", textBoxItemName.Text.Trim());
                commandInsert.ExecuteNonQuery();
                MessageBox.Show("Information has been added successfully", "Information", MessageBoxButtons.OK);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database failed to connect/insert information" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxCompanyName.ResetText();
             dateTimePickerDate.ResetText();
            textBoxQuantity.ResetText();
            textBoxBaseRate.ResetText();
            textBoxPaidAmount.ResetText();
            textBoxBalance.ResetText();
            textBoxBillNumber.ResetText();
        }

        private void Entry_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            welcome.Show();
        }
    }
}
