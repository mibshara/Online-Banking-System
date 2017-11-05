namespace WindowsBankingApplication
{
    partial class frmTransaction
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
            System.Windows.Forms.Label balanceLabel;
            System.Windows.Forms.Label accountNumberLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label clientNumberLabel;
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboTransactionType = new System.Windows.Forms.ComboBox();
            this.transactionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboAccountPayee = new System.Windows.Forms.ComboBox();
            this.lblNoAccountsExist = new System.Windows.Forms.Label();
            this.lblAccountPayee = new System.Windows.Forms.Label();
            this.lnkProcessTransaction = new System.Windows.Forms.LinkLabel();
            this.lnkReturn = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAccountNumber = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblBalance = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblClientNumber = new EWSoftware.MaskedLabelControl.MaskedLabel();
            balanceLabel = new System.Windows.Forms.Label();
            accountNumberLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            clientNumberLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTypeBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new System.Drawing.Point(376, 84);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new System.Drawing.Size(86, 13);
            balanceLabel.TabIndex = 6;
            balanceLabel.Text = "Current Balance:";
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new System.Drawing.Point(7, 84);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new System.Drawing.Size(90, 13);
            accountNumberLabel.TabIndex = 4;
            accountNumberLabel.Text = "Account Number:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(424, 30);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(38, 13);
            fullNameLabel.TabIndex = 2;
            fullNameLabel.Text = "Name:";
            // 
            // clientNumberLabel
            // 
            clientNumberLabel.AutoSize = true;
            clientNumberLabel.Location = new System.Drawing.Point(7, 29);
            clientNumberLabel.Name = "clientNumberLabel";
            clientNumberLabel.Size = new System.Drawing.Size(76, 13);
            clientNumberLabel.TabIndex = 0;
            clientNumberLabel.Text = "Client Number:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(164, 90);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(160, 20);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblName
            // 
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "FullName", true));
            this.lblName.Location = new System.Drawing.Point(487, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(172, 23);
            this.lblName.TabIndex = 3;
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(BankOfBIT.Models.Client);
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.DataSource = this.transactionTypeBindingSource;
            this.cboTransactionType.DisplayMember = "Description";
            this.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionType.FormattingEnabled = true;
            this.cboTransactionType.Location = new System.Drawing.Point(164, 44);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(160, 21);
            this.cboTransactionType.TabIndex = 33;
            this.cboTransactionType.ValueMember = "TransactionTypeId";
            this.cboTransactionType.SelectedIndexChanged += new System.EventHandler(this.cboTransactionType_SelectedIndexChanged);
            // 
            // transactionTypeBindingSource
            // 
            this.transactionTypeBindingSource.DataSource = typeof(BankOfBIT.Models.TransactionType);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboTransactionType);
            this.groupBox2.Controls.Add(this.cboAccountPayee);
            this.groupBox2.Controls.Add(this.lblNoAccountsExist);
            this.groupBox2.Controls.Add(this.lblAccountPayee);
            this.groupBox2.Controls.Add(this.lnkProcessTransaction);
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Controls.Add(this.lnkReturn);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(190, 201);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(403, 234);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transaction Data";
            // 
            // cboAccountPayee
            // 
            this.cboAccountPayee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountPayee.FormattingEnabled = true;
            this.cboAccountPayee.Location = new System.Drawing.Point(164, 128);
            this.cboAccountPayee.Name = "cboAccountPayee";
            this.cboAccountPayee.Size = new System.Drawing.Size(160, 21);
            this.cboAccountPayee.TabIndex = 32;
            this.cboAccountPayee.Visible = false;
            // 
            // lblNoAccountsExist
            // 
            this.lblNoAccountsExist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNoAccountsExist.Location = new System.Drawing.Point(8, 161);
            this.lblNoAccountsExist.Name = "lblNoAccountsExist";
            this.lblNoAccountsExist.Size = new System.Drawing.Size(355, 23);
            this.lblNoAccountsExist.TabIndex = 8;
            this.lblNoAccountsExist.Text = "No accounts exist to receive transferred funds";
            this.lblNoAccountsExist.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblNoAccountsExist.Visible = false;
            // 
            // lblAccountPayee
            // 
            this.lblAccountPayee.AutoSize = true;
            this.lblAccountPayee.Location = new System.Drawing.Point(30, 131);
            this.lblAccountPayee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccountPayee.Name = "lblAccountPayee";
            this.lblAccountPayee.Size = new System.Drawing.Size(66, 13);
            this.lblAccountPayee.TabIndex = 4;
            this.lblAccountPayee.Text = "To Account:";
            this.lblAccountPayee.Visible = false;
            // 
            // lnkProcessTransaction
            // 
            this.lnkProcessTransaction.AutoSize = true;
            this.lnkProcessTransaction.Location = new System.Drawing.Point(83, 201);
            this.lnkProcessTransaction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkProcessTransaction.Name = "lnkProcessTransaction";
            this.lnkProcessTransaction.Size = new System.Drawing.Size(104, 13);
            this.lnkProcessTransaction.TabIndex = 6;
            this.lnkProcessTransaction.TabStop = true;
            this.lnkProcessTransaction.Text = "Process Transaction";
            this.lnkProcessTransaction.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProcessTransaction_LinkClicked);
            // 
            // lnkReturn
            // 
            this.lnkReturn.AutoSize = true;
            this.lnkReturn.Location = new System.Drawing.Point(218, 201);
            this.lnkReturn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkReturn.Name = "lnkReturn";
            this.lnkReturn.Size = new System.Drawing.Size(106, 13);
            this.lnkReturn.TabIndex = 7;
            this.lnkReturn.TabStop = true;
            this.lnkReturn.Text = "Return to Client Data";
            this.lnkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReturn_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Transaction Type:";
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAccountNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "AccountNumber", true));
            this.lblAccountNumber.Location = new System.Drawing.Point(103, 84);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(100, 23);
            this.lblAccountNumber.TabIndex = 5;
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataSource = typeof(BankOfBIT.Models.BankAccount);
            // 
            // lblBalance
            // 
            this.lblBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Balance", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.lblBalance.Location = new System.Drawing.Point(487, 84);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(172, 23);
            this.lblBalance.TabIndex = 7;
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(balanceLabel);
            this.groupBox1.Controls.Add(this.lblBalance);
            this.groupBox1.Controls.Add(accountNumberLabel);
            this.groupBox1.Controls.Add(this.lblAccountNumber);
            this.groupBox1.Controls.Add(fullNameLabel);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(clientNumberLabel);
            this.groupBox1.Controls.Add(this.lblClientNumber);
            this.groupBox1.Location = new System.Drawing.Point(33, 30);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(685, 127);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Data";
            // 
            // lblClientNumber
            // 
            this.lblClientNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClientNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "ClientNumber", true));
            this.lblClientNumber.Location = new System.Drawing.Point(106, 28);
            this.lblClientNumber.Mask = "0000-0000";
            this.lblClientNumber.Name = "lblClientNumber";
            this.lblClientNumber.Size = new System.Drawing.Size(100, 23);
            this.lblClientNumber.TabIndex = 1;
            this.lblClientNumber.Text = "    -";
            // 
            // frmTransaction
            // 
            this.ClientSize = new System.Drawing.Size(751, 464);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTransaction";
            this.Text = "Account Transaction";
            this.Load += new System.EventHandler(this.frmTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTypeBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.ComboBox cboTransactionType;
        private System.Windows.Forms.BindingSource transactionTypeBindingSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboAccountPayee;
        private System.Windows.Forms.Label lblNoAccountsExist;
        private System.Windows.Forms.Label lblAccountPayee;
        private System.Windows.Forms.LinkLabel lnkProcessTransaction;
        private System.Windows.Forms.LinkLabel lnkReturn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private EWSoftware.MaskedLabelControl.MaskedLabel lblAccountNumber;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private EWSoftware.MaskedLabelControl.MaskedLabel lblBalance;
        private System.Windows.Forms.GroupBox groupBox1;
        private EWSoftware.MaskedLabelControl.MaskedLabel lblClientNumber;

    }
}
