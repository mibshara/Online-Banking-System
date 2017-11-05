using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using BankOfBIT.Models;
//note:  this needed to be done because during development
//ef released v. 6
//ef6 needed to add this
//using System.Data.Entity.Core;

using System.IO.Ports;      //for rfid assignment

namespace WindowsBankingApplication
{


    public partial class frmClients : Form
    {
        ///given: client and bankaccount data will be retrieved
        ///in this form and passed throughout application
        ///these variables will be used to store the current
        ///client and selected bankaccount
        ConstructorData constructorData = new ConstructorData();

        //A list of bank account to store query
        List<BankAccount> bankAccountQuery = new List<BankAccount>();

        //Creating an instance of bank of bit database
        BankOfBITContext db = new BankOfBITContext();

        public frmClients()
        {
            InitializeComponent();
        }


        /// <summary>
        /// given:  This constructor will be used when returning to frmClient
        /// from another form.  This constructor will pass back
        /// specific information about the client and bank account
        /// based on activites taking place in another form
        /// </summary>
        /// <param name="client">specific client instance</param>
        /// <param name="account">specific bank account instance</param>
        public frmClients(ConstructorData constructorData)
        {
            InitializeComponent();

            //Populating the corresponding data in the client number text box
            txtClientNumber.Text = constructorData.client.ClientNumber.ToString();

            //Triggering the MaskedTextBox_Leave event
            txtClientNumber_Leave(this, EventArgs.Empty);

            //Checks if bank account is not null
            if (constructorData.bankAccount != null)
            {
                //Populating the corresponding data in the account number combo box
                cboAccountNumber.Text = constructorData.bankAccount.AccountNumber.ToString();
            }
        
        }

        /// <summary>
        /// given: open history form passing data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Updating the BankAccount entry in the ConstructorData instance with the latest selection
            constructorData.bankAccount = bankAccountBindingSource.Current as BankAccount;

            //instance of frmHistory passing constructor data
            frmHistory frmHistory = new frmHistory(constructorData);
            //open in frame
            frmHistory.MdiParent = this.MdiParent;
            //show form
            frmHistory.Show();
            this.Close();
        }

        /// <summary>
        /// given: open transaction form passing constructor data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkTransaction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Updating the BankAccount entry in the ConstructorData instance with the latest selection
            constructorData.bankAccount = bankAccountBindingSource.Current as BankAccount;

            //instance of frmTransaction passing constructor data
            frmTransaction frmTransaction = new frmTransaction(constructorData);
            //open in frame
            frmTransaction.MdiParent = this.MdiParent;
            //show form
            frmTransaction.Show();
            this.Close();
        }


       /// <summary>
       /// given
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void frmClients_Load(object sender, EventArgs e)
        {
            //keeps location of form static when opened and closed
            this.Location = new Point(0, 0);
        }

        /// <summary>
        /// Handles the leave event of the client number textbox
        /// </summary>
        private void txtClientNumber_Leave(object sender, EventArgs e)
        {
            try
            {
                //Resuming binding
                bankAccountBindingSource.ResumeBinding();

                //Capturing client number from the form to a variable
                long clientNumber = long.Parse(txtClientNumber.Text.Replace("-", ""));

                //Quering client number from the database when it is matching the entered client number
                var clientQuery = db.Clients.Where(x => x.ClientNumber == clientNumber).SingleOrDefault();

                //Happens if client query retrieves a value from the database
                if (clientQuery != null)
                {
                    //Binding the client data to the one from the database
                    clientBindingSource.DataSource = clientQuery;

                    //Creating an instance of client
                    Client client = clientQuery;

                    //Setting the constructor data to the client 
                    constructorData.client = client;

                    //Querring the bank account info from the database of the client whose number is entered
                    bankAccountQuery = db.BankAccounts.Where(x => x.ClientId == clientQuery.ClientId).ToList();

                    //Binding the client's account info
                    bankAccountBindingSource.DataSource = bankAccountQuery.ToList();

                    //Enabling the links at the buttom
                    lnkDetails.Enabled = true;
                    lnkTransaction.Enabled = true;

                    //Disabling the links if no account queries are returned
                    if (!bankAccountQuery.Any())
                    {
                        //Suspending binding
                        bankAccountBindingSource.SuspendBinding();
                        lnkDetails.Enabled = false;
                        lnkTransaction.Enabled = false;
                    }
                }
                else
                {
                    //Displaying an error message when the client number entered does not exist
                    MessageBox.Show("The client number you entered does not exist.", "Error", MessageBoxButtons.OK);

                    //Disabling the links at the buttom of the form
                    lnkDetails.Enabled = false;
                    lnkTransaction.Enabled = false;

                    //Susbending binding
                    bankAccountBindingSource.SuspendBinding();

                    //Clearing the binding source object
                    clientBindingSource.Clear();
                    bankAccountBindingSource.Clear();
                    txtClientNumber.Focus();
                }
            }
            catch (Exception ex)
            {
                //Showing a message when an exception is caught
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void cboAccountNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Populating the constructor data with the bank account selected
            if (cboAccountNumber.SelectedIndex >= 0)
            {
                //Setting constructor data to the account selected
                constructorData.bankAccount = bankAccountQuery[cboAccountNumber.SelectedIndex];
            }
        }

  }
}
