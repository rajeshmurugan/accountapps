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
            this.buttonGo.Location = new System.Drawing.Point(507, 85);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(59, 26);
            this.buttonGo.TabIndex = 1;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // comboBoxCompanyList
            // 
            this.comboBoxCompanyList.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.accountsTableBindingSource, "CompanyName", true));
            this.comboBoxCompanyList.DataSource = this.accountsTableBindingSource;
            this.comboBoxCompanyList.DisplayMember = "CompanyName";
            this.comboBoxCompanyList.FormattingEnabled = true;
            this.comboBoxCompanyList.Location = new System.Drawing.Point(35, 89);
            this.comboBoxCompanyList.Name = "comboBoxCompanyList";
            this.comboBoxCompanyList.Size = new System.Drawing.Size(426, 21);
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
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 509);
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
    }
}
