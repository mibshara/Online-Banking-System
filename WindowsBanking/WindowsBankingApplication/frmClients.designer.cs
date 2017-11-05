namespace WindowsBankingApplication
{
    partial class frmClients
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
            System.Windows.Forms.Label clientNumberLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.Label provinceLabel;
            System.Windows.Forms.Label postalCodeLabel;
            System.Windows.Forms.Label dateCreatedLabel;
            System.Windows.Forms.Label accountNumberLabel;
            System.Windows.Forms.Label balanceLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label notesLabel;
            System.Windows.Forms.Label descriptionLabel1;
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblState = new System.Windows.Forms.Label();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.cboAccountNumber = new System.Windows.Forms.ComboBox();
            this.lnkTransaction = new System.Windows.Forms.LinkLabel();
            this.lnkDetails = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDateCreated = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblPostalCode = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.lblProvince = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtClientNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblRFID = new System.Windows.Forms.Label();
            clientNumberLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            addressLabel = new System.Windows.Forms.Label();
            cityLabel = new System.Windows.Forms.Label();
            provinceLabel = new System.Windows.Forms.Label();
            postalCodeLabel = new System.Windows.Forms.Label();
            dateCreatedLabel = new System.Windows.Forms.Label();
            accountNumberLabel = new System.Windows.Forms.Label();
            balanceLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            notesLabel = new System.Windows.Forms.Label();
            descriptionLabel1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // clientNumberLabel
            // 
            clientNumberLabel.AutoSize = true;
            clientNumberLabel.Location = new System.Drawing.Point(52, 57);
            clientNumberLabel.Name = "clientNumberLabel";
            clientNumberLabel.Size = new System.Drawing.Size(76, 13);
            clientNumberLabel.TabIndex = 30;
            clientNumberLabel.Text = "Client Number:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(52, 94);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(57, 13);
            fullNameLabel.TabIndex = 31;
            fullNameLabel.Text = "Full Name:";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(52, 133);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(48, 13);
            addressLabel.TabIndex = 32;
            addressLabel.Text = "Address:";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(52, 168);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(27, 13);
            cityLabel.TabIndex = 33;
            cityLabel.Text = "City:";
            // 
            // provinceLabel
            // 
            provinceLabel.AutoSize = true;
            provinceLabel.Location = new System.Drawing.Point(321, 168);
            provinceLabel.Name = "provinceLabel";
            provinceLabel.Size = new System.Drawing.Size(52, 13);
            provinceLabel.TabIndex = 34;
            provinceLabel.Text = "Province:";
            // 
            // postalCodeLabel
            // 
            postalCodeLabel.AutoSize = true;
            postalCodeLabel.Location = new System.Drawing.Point(451, 168);
            postalCodeLabel.Name = "postalCodeLabel";
            postalCodeLabel.Size = new System.Drawing.Size(67, 13);
            postalCodeLabel.TabIndex = 35;
            postalCodeLabel.Text = "Postal Code:";
            // 
            // dateCreatedLabel
            // 
            dateCreatedLabel.AutoSize = true;
            dateCreatedLabel.Location = new System.Drawing.Point(52, 209);
            dateCreatedLabel.Name = "dateCreatedLabel";
            dateCreatedLabel.Size = new System.Drawing.Size(73, 13);
            dateCreatedLabel.TabIndex = 36;
            dateCreatedLabel.Text = "Date Created:";
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new System.Drawing.Point(52, 50);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new System.Drawing.Size(90, 13);
            accountNumberLabel.TabIndex = 5;
            accountNumberLabel.Text = "Account Number:";
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new System.Drawing.Point(466, 50);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new System.Drawing.Size(49, 13);
            balanceLabel.TabIndex = 6;
            balanceLabel.Text = "Balance:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(437, 88);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(77, 13);
            descriptionLabel.TabIndex = 8;
            descriptionLabel.Text = "Account Type:";
            // 
            // notesLabel
            // 
            notesLabel.AutoSize = true;
            notesLabel.Location = new System.Drawing.Point(52, 129);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new System.Drawing.Size(38, 13);
            notesLabel.TabIndex = 10;
            notesLabel.Text = "Notes:";
            // 
            // descriptionLabel1
            // 
            descriptionLabel1.AutoSize = true;
            descriptionLabel1.Location = new System.Drawing.Point(52, 88);
            descriptionLabel1.Name = "descriptionLabel1";
            descriptionLabel1.Size = new System.Drawing.Size(35, 13);
            descriptionLabel1.TabIndex = 11;
            descriptionLabel1.Text = "State:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(descriptionLabel1);
            this.groupBox2.Controls.Add(this.lblState);
            this.groupBox2.Controls.Add(notesLabel);
            this.groupBox2.Controls.Add(this.lblNotes);
            this.groupBox2.Controls.Add(descriptionLabel);
            this.groupBox2.Controls.Add(this.lblAccountType);
            this.groupBox2.Controls.Add(balanceLabel);
            this.groupBox2.Controls.Add(this.lblBalance);
            this.groupBox2.Controls.Add(accountNumberLabel);
            this.groupBox2.Controls.Add(this.cboAccountNumber);
            this.groupBox2.Controls.Add(this.lnkTransaction);
            this.groupBox2.Controls.Add(this.lnkDetails);
            this.groupBox2.Location = new System.Drawing.Point(13, 358);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(772, 306);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account Data";
            // 
            // lblState
            // 
            this.lblState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblState.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "AccountState.Description", true));
            this.lblState.Location = new System.Drawing.Point(156, 87);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(121, 23);
            this.lblState.TabIndex = 12;
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataSource = typeof(BankOfBIT.Models.BankAccount);
            // 
            // lblNotes
            // 
            this.lblNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Notes", true));
            this.lblNotes.Location = new System.Drawing.Point(156, 129);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(465, 77);
            this.lblNotes.TabIndex = 11;
            // 
            // lblAccountType
            // 
            this.lblAccountType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAccountType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Description", true));
            this.lblAccountType.Location = new System.Drawing.Point(521, 87);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(100, 23);
            this.lblAccountType.TabIndex = 9;
            // 
            // lblBalance
            // 
            this.lblBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Balance", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.lblBalance.Location = new System.Drawing.Point(521, 47);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(100, 23);
            this.lblBalance.TabIndex = 7;
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboAccountNumber
            // 
            //this.cboAccountNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "AccountNumber", true));
            this.cboAccountNumber.DataSource = this.bankAccountBindingSource;
            this.cboAccountNumber.DisplayMember = "AccountNumber";
            this.cboAccountNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountNumber.FormattingEnabled = true;
            this.cboAccountNumber.Location = new System.Drawing.Point(156, 47);
            this.cboAccountNumber.Name = "cboAccountNumber";
            this.cboAccountNumber.Size = new System.Drawing.Size(121, 21);
            this.cboAccountNumber.TabIndex = 6;
            this.cboAccountNumber.ValueMember = "AccountNumber";
            this.cboAccountNumber.SelectedIndexChanged += new System.EventHandler(this.cboAccountNumber_SelectedIndexChanged);
            // 
            // lnkTransaction
            // 
            this.lnkTransaction.AutoSize = true;
            this.lnkTransaction.Enabled = false;
            this.lnkTransaction.Location = new System.Drawing.Point(235, 261);
            this.lnkTransaction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkTransaction.Name = "lnkTransaction";
            this.lnkTransaction.Size = new System.Drawing.Size(102, 13);
            this.lnkTransaction.TabIndex = 4;
            this.lnkTransaction.TabStop = true;
            this.lnkTransaction.Text = "Perform Transaction";
            this.lnkTransaction.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTransaction_LinkClicked);
            // 
            // lnkDetails
            // 
            this.lnkDetails.AutoSize = true;
            this.lnkDetails.Enabled = false;
            this.lnkDetails.Location = new System.Drawing.Point(453, 261);
            this.lnkDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkDetails.Name = "lnkDetails";
            this.lnkDetails.Size = new System.Drawing.Size(65, 13);
            this.lnkDetails.TabIndex = 5;
            this.lnkDetails.TabStop = true;
            this.lnkDetails.Text = "View Details";
            this.lnkDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetails_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(dateCreatedLabel);
            this.groupBox1.Controls.Add(this.lblDateCreated);
            this.groupBox1.Controls.Add(postalCodeLabel);
            this.groupBox1.Controls.Add(this.lblPostalCode);
            this.groupBox1.Controls.Add(provinceLabel);
            this.groupBox1.Controls.Add(this.lblProvince);
            this.groupBox1.Controls.Add(cityLabel);
            this.groupBox1.Controls.Add(this.lblCity);
            this.groupBox1.Controls.Add(addressLabel);
            this.groupBox1.Controls.Add(this.lblAddress);
            this.groupBox1.Controls.Add(fullNameLabel);
            this.groupBox1.Controls.Add(this.lblFullName);
            this.groupBox1.Controls.Add(clientNumberLabel);
            this.groupBox1.Controls.Add(this.txtClientNumber);
            this.groupBox1.Controls.Add(this.lblRFID);
            this.groupBox1.Location = new System.Drawing.Point(13, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 288);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Data";
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDateCreated.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "DateCreated", true));
            this.lblDateCreated.Location = new System.Drawing.Point(156, 208);
            this.lblDateCreated.Mask = "0000-00-00";
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(100, 23);
            this.lblDateCreated.TabIndex = 37;
            this.lblDateCreated.Text = "    -  -";
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(BankOfBIT.Models.Client);
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPostalCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "PostalCode", true));
            this.lblPostalCode.Location = new System.Drawing.Point(524, 167);
            this.lblPostalCode.Mask = ">L0L 0L0";
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(82, 23);
            this.lblPostalCode.TabIndex = 36;
            this.lblPostalCode.Text = "    ";
            // 
            // lblProvince
            // 
            this.lblProvince.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProvince.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "Province", true));
            this.lblProvince.Location = new System.Drawing.Point(379, 167);
            this.lblProvince.Mask = ">LL";
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(54, 23);
            this.lblProvince.TabIndex = 35;
            // 
            // lblCity
            // 
            this.lblCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "City", true));
            this.lblCity.Location = new System.Drawing.Point(156, 167);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(158, 23);
            this.lblCity.TabIndex = 34;
            // 
            // lblAddress
            // 
            this.lblAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "Address", true));
            this.lblAddress.Location = new System.Drawing.Point(156, 132);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(450, 23);
            this.lblAddress.TabIndex = 33;
            // 
            // lblFullName
            // 
            this.lblFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFullName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "FullName", true));
            this.lblFullName.Location = new System.Drawing.Point(156, 93);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(450, 23);
            this.lblFullName.TabIndex = 32;
            // 
            // txtClientNumber
            // 
            this.txtClientNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "ClientNumber", true));
            this.txtClientNumber.Location = new System.Drawing.Point(156, 54);
            this.txtClientNumber.Mask = "0000/0000";
            this.txtClientNumber.Name = "txtClientNumber";
            this.txtClientNumber.Size = new System.Drawing.Size(158, 20);
            this.txtClientNumber.TabIndex = 31;
            this.txtClientNumber.Leave += new System.EventHandler(this.txtClientNumber_Leave);
            // 
            // lblRFID
            // 
            this.lblRFID.ForeColor = System.Drawing.Color.Red;
            this.lblRFID.Location = new System.Drawing.Point(321, 49);
            this.lblRFID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRFID.Name = "lblRFID";
            this.lblRFID.Size = new System.Drawing.Size(285, 28);
            this.lblRFID.TabIndex = 30;
            this.lblRFID.Text = "RFID unavailable.  Enter Client ID manually.";
            this.lblRFID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmClients
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(836, 715);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmClients";
            this.Text = "Client Information";
            this.Load += new System.EventHandler(this.frmClients_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel lnkTransaction;
        private System.Windows.Forms.LinkLabel lnkDetails;
        private System.Windows.Forms.Label lblRFID;
        private EWSoftware.MaskedLabelControl.MaskedLabel lblDateCreated;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private EWSoftware.MaskedLabelControl.MaskedLabel lblPostalCode;
        private EWSoftware.MaskedLabelControl.MaskedLabel lblProvince;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.MaskedTextBox txtClientNumber;
        private System.Windows.Forms.ComboBox cboAccountNumber;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblState;
 
    }
}