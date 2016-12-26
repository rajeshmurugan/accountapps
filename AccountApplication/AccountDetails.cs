using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace AccountApplication
{
    public partial class AccountDetails : Form
    {
        Summary summary = null;
        String CompanyName = "";
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        public AccountDetails(String CompanyName = "R")
        {
            InitializeComponent();
            summary = new Summary();
            this.CompanyName = CompanyName;
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
            Cursor.Current = Cursors.WaitCursor;
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
                comboBoxCompanyName.SelectedItem = CompanyName;
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
                if (!this.CompanyName.Equals(""))
                    dataGridViewAccountDetails.Columns[0].Visible = false;

                string query = "SELECT CompanyName, ItemName, PurchaseDate, BillNumber, Quantity, BaseRate, PaidAmount, Balance FROM AccountsTable WHERE ";
                query += "PurchaseDate >= '" + dateTimePickerFrom.Text + "' and PurchaseDate <= '" + dateTimePickerEnd.Text + "' ";

                if (!comboBoxCompanyName.SelectedItem.ToString().Equals("All"))
                {
                    query += " and CompanyName <= '" + comboBoxCompanyName.SelectedText + "' ";
                    
                }
                else
                    dataGridViewAccountDetails.Columns[0].Visible = true;

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
            summary.Show();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocumentAccounts;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocumentAccounts.DocumentName = "Account Details";
                printDocumentAccounts.Print();
            }
            //Open the print preview dialog
            PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            objPPdialog.Document = printDocumentAccounts;
            objPPdialog.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridViewAccountDetails.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                            (double)iTotalWidth * (double)iTotalWidth *
                            ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridViewAccountDetails.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridViewAccountDetails.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("PSV Fruits Ltd",
                                new Font(dataGridViewAccountDetails.Font, FontStyle.Bold),
                                Brushes.Blue, e.MarginBounds.Left,
                                e.MarginBounds.Top - e.Graphics.MeasureString("PSV Fruits Ltd",
                                new Font(dataGridViewAccountDetails.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString();
                            //Draw Date
                            e.Graphics.DrawString(strDate,
                                new Font(dataGridViewAccountDetails.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                new Font(dataGridViewAccountDetails.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Width),
                                e.MarginBounds.Top - e.Graphics.MeasureString("PSV Fruits Ltd",
                                new Font(new Font(dataGridViewAccountDetails.Font, FontStyle.Bold),
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridViewAccountDetails.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(),
                                    Cel.InheritedStyle.Font,
                                    new SolidBrush(Cel.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)arrColumnWidths[iCount], (float)iCellHeight),
                                    strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iCellHeight));
                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }
                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridViewAccountDetails.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
