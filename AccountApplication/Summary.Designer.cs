namespace AccountApplication
{
    partial class Summary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewSummary = new System.Windows.Forms.DataGridView();
            this.buttonGo = new System.Windows.Forms.Button();
            this.comboBoxCompanyList = new System.Windows.Forms.ComboBox();
            this.accountsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountsDBDataSetCompanyName = new AccountApplication.AccountsDBDataSetCompanyName();
            this.accountsTableTableAdapter = new AccountApplication.AccountsDBDataSetCompanyNameTableAdapters.AccountsTableTableAdapter();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.printDocumentAccounts = new System.Drawing.Printing.PrintDocument();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsDBDataSetCompanyName)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSummary
            // 
            this.dataGridViewSummary.AllowUserToAddRows = false;
            this.dataGridViewSummary.AllowUserToDeleteRows = false;
            this.dataGridViewSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSummary.Location = new System.Drawing.Point(7, 195);
            this.dataGridViewSummary.Name = "dataGridViewSummary";
            this.dataGridViewSummary.ReadOnly = true;
            this.dataGridViewSummary.Size = new System.Drawing.Size(633, 294);
            this.dataGridViewSummary.TabIndex = 0;
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(351, 120);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(59, 26);
            this.buttonGo.TabIndex = 1;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // comboBoxCompanyList
            // 
            this.comboBoxCompanyList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxCompanyList.DataSource = this.accountsTableBindingSource;
            this.comboBoxCompanyList.DisplayMember = "CompanyName";
            this.comboBoxCompanyList.FormattingEnabled = true;
            this.comboBoxCompanyList.Location = new System.Drawing.Point(48, 120);
            this.comboBoxCompanyList.Name = "comboBoxCompanyList";
            this.comboBoxCompanyList.Size = new System.Drawing.Size(249, 21);
            this.comboBoxCompanyList.TabIndex = 2;
            this.comboBoxCompanyList.ValueMember = "CompanyName";
            // 
            // accountsTableBindingSource
            // 
            this.accountsTableBindingSource.DataMember = "AccountsTable";
            this.accountsTableBindingSource.DataSource = this.accountsDBDataSetCompanyName;
            // 
            // accountsDBDataSetCompanyName
            // 
            this.accountsDBDataSetCompanyName.DataSetName = "AccountsDBDataSetCompanyName";
            this.accountsDBDataSetCompanyName.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // accountsTableTableAdapter
            // 
            this.accountsTableTableAdapter.ClearBeforeFill = true;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(556, 164);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 25);
            this.buttonPrint.TabIndex = 8;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // printDocumentAccounts
            // 
            this.printDocumentAccounts.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocumentAccounts_BeginPrint);
            this.printDocumentAccounts.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentAccounts_PrintPage);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(556, 34);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 32);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Add Details";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(556, 92);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 26);
            this.buttonExit.TabIndex = 10;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(124, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 36);
            this.label1.TabIndex = 11;
            this.label1.Text = "PSV Fruits Ltd";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 509);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.comboBoxCompanyList);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.dataGridViewSummary);
            this.Name = "Summary";
            this.Text = "Summary";
            this.Load += new System.EventHandler(this.Summary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsDBDataSetCompanyName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSummary;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.ComboBox comboBoxCompanyList;
        private AccountsDBDataSetCompanyName accountsDBDataSetCompanyName;
        private System.Windows.Forms.BindingSource accountsTableBindingSource;
        private AccountsDBDataSetCompanyNameTableAdapters.AccountsTableTableAdapter accountsTableTableAdapter;
        private System.Windows.Forms.Button buttonPrint;
        private System.Drawing.Printing.PrintDocument printDocumentAccounts;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label1;
    }
}
