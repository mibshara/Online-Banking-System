using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility;
using WindowsBankingApplication.ServiceReference;
using BankOfBIT.Models;

//note:  this needed to be done because during development
//ef released v. 6
//ef6 needed to add this
//using System.Data.Entity.Core;

namespace WindowsBankingApplication
{
    public partial class frmTransaction : Form
    {

        ///given:  client and bankaccount data will be retrieved
        ///in this form and passed throughout application
        ///this object will be used to store the current
        ///client and selected bankaccount
        ConstructorData constructorData;

        //Creating an instance of bank of bank of BIT database
        BankOfBITContext db = new BankOfBITContext();

        public frmTransaction()
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
        public frmTransaction(ConstructorData constructorData)
        {
            InitializeComponent();
            this.constructorData = constructorData;

            ////Populating the corresponding data in the account number label
            lblAccountNumber.Text = constructorData.bankAccount.AccountNumber.ToString();

            ////Populating the corresponding data in the client number label
            lblClientNumber.Text = constructorData.client.ClientNumber.ToString();

            ////Populating the corresponding data in the name label
            lblName.Text = constructorData.client.FullName.ToString();

            ////Populating the corresponding data in the balance label
            lblBalance.Text = constructorData.bankAccount.Balance.ToString("c");
        }

        /// <summary>
        /// given: this code will navigate back to frmClient with
        /// the specific client and account data that launched
        /// this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //return to client with the data selected for this form
            frmClients frmClients = new frmClients(constructorData);
            frmClients.MdiParent = this.MdiParent;
            frmClients.Show();
            this.Close();

        }

        /// <summary>
        /// given:  further code required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTransaction_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            try
            {
                //Setting the account number masked label using the utility project
                lblAccountNumber.Mask = Utility.BusinessRules.AccountFormat(constructorData.bankAccount.Description);

                //Querying all data from the TransactionTypes Entity class other than the recepient and interest records
                var transQuery = db.TransactionTypes.Where(type => type.TransactionTypeId < 5).ToList();

                ////Setting the DataSource property of the BindingSource object representing the upper combobox
                transactionTypeBindingSource.DataSource = transQuery;
            }
            catch (Exception ex)
            {
                //Showing an error in case an exception is caught
                MessageBox.Show("Error", ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the selected index change of transaction combo box
        /// </summary>
        private void cboTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Determining what is going to happen based on what user is going to select
            switch (cboTransactionType.Text)
            {
                //In case user chooses bill payment
                case "Bill Payment":
                    //Quering the payee list from the database
                    var payeeQuery = db.Payees.ToList();

                    //Populating the account type combo box with payees
                    cboAccountPayee.DataSource = payeeQuery;

                    //Displaying their description from the database
                    cboAccountPayee.DisplayMember = "Description";

                    //The value of the payees will be their payee Id
                    cboAccountPayee.ValueMember = "PayeeId";

                    //Setting the payee combo box to visable
                    cboAccountPayee.Visible = true;

                    //Setting the account payee label to visable
                    lblAccountPayee.Visible = true;
                    break;

                //In case user chooses Transfer
                case "Transfer":

                    //Quering the payee list from the database and binding it to the account payee combo box
                    cboAccountPayee.DataSource = db.BankAccounts.Where(x => x.ClientId == constructorData.client.ClientId &&
                        x.AccountNumber != constructorData.bankAccount.AccountNumber).ToList();

                    //Happens if the client number who launched the form does not have additional bank account records
                    if (cboAccountPayee == null)
                    {
                        //Setting the payee combo box visibility to false
                        cboAccountPayee.Visible = false;

                        //Setting the acount payee label visibility to false
                        lblAccountPayee.Visible = false;

                        //Setting the no account exists label visibility to true
                        lblNoAccountsExist.Visible = true;
                    }
                    //If the client number have records
                    else
                    {
                        //Displaying the account number from the database
                        cboAccountPayee.DisplayMember = "AccountNumber";

                        // The value of the selections will be the bank account id
                        cboAccountPayee.ValueMember = "BankAccountId";

                        //Setting the payee combo box to visable
                        cboAccountPayee.Visible = true;

                        //Setting the account payee label to visable
                        lblAccountPayee.Visible = true;
                    }
                    break;

                default:
                    //By default account payee label and combo box's visibility is set to false
                    lblAccountPayee.Visible = false;
                    cboAccountPayee.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// Handles the link clicked event of process transactoin link
        /// </summary>
        private void lnkProcessTransaction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Ensuring numeric data has been entered into the Amount textbox
            if (!Utility.Numeric.isNumeric(txtAmount.Text, System.Globalization.NumberStyles.Currency))
            {
                //Showing an error if the wrong data type is entered
                MessageBox.Show("Please enter a numeric value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Evaluating the upper combo box
                switch (cboTransactionType.Text)
                {
                    //In case the user chose Transfer, Bill Payment, or Withdrawal
                    case "Transfer":
                    case "Bill Payment":
                    case "Withdrawal":

                        //Ensuring that there are enough funds to complete the transaction
                        if (double.Parse(txtAmount.Text) > double.Parse(lblBalance.Text.Replace("$", "")))
                        {
                            //Showing a message if the is insufficient funds
                            MessageBox.Show("Insufficient Funds", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            //Performing the transaction chosen by calling the peroform transaction method passing the transaction type
                            PerformTransaction(cboTransactionType.Text);
                        }
                        break;

                    //In case user chooses deposit
                    case "Deposit":
                        //Performing the transaction chosen by calling the peroform transaction method passing the transaction type
                        PerformTransaction(cboTransactionType.Text);
                        break;
                }

                // Clearing the amount textbox
                txtAmount.Text = "";
            }

        }

        /// <summary>
        /// Perform the transaction chosen by the user
        /// </summary>
        /// <param name="transactionType">The type of the transaction chosen by the user</param>
        public void PerformTransaction(string transactionType)
        {
            //Creating an instance of transacion manager
            TransactionManagerClient transactionManager = new TransactionManagerClient();

            //Creating a variable to store the new balance in it
            double newBalance;

            try
            {
                //Evaluating the type chosen by the user
                switch (cboTransactionType.Text)
                {
                    //In case the user choice is a bill payment
                    case "Bill Payment":

                        //Performing the payment and storing the new balance
                        newBalance = (double)transactionManager.BillPayment(constructorData.bankAccount.BankAccountId, double.Parse(txtAmount.Text), "Bill Payment");

                        //Update the current balance to be equal to the new one
                        lblBalance.Text = newBalance.ToString("c");

                        //Checking if the transaction was successfull by calling the check transaction success method
                        CheckTransactionSuccess(newBalance);
                        break;

                    //In case the user choice is a transfer
                    case "Transfer":

                        //Getting the recepient's account number
                        int toAccountNumber = int.Parse(cboAccountPayee.Text);

                        //Quering the reciepient's account number
                        int toAccountId = db.BankAccounts.Where(x => x.AccountNumber == toAccountNumber).Select(x => x.BankAccountId).SingleOrDefault();

                        //Performing the transfer and storing the new balance
                        newBalance = (double)transactionManager.Transfer(constructorData.bankAccount.BankAccountId, toAccountId, double.Parse(txtAmount.Text), "Transfer");

                        //Update the current balance to be equal to the new one
                        lblBalance.Text = newBalance.ToString("c");

                        //Checking if the transaction was successfull by calling the check transaction success method
                        CheckTransactionSuccess(newBalance);
                        break;

                    //In case the user choice is a withdrawal
                    case "Withdrawal":

                        //Performing the withdrawal and storing the new balance
                        newBalance = (double)transactionManager.Withdrawal(constructorData.bankAccount.BankAccountId, double.Parse(txtAmount.Text), "Withdrawal");

                        //Update the current balance to be equal to the new one
                        lblBalance.Text = newBalance.ToString("c");

                        //Checking if the transaction was successfull by calling the check transaction success method
                        CheckTransactionSuccess(newBalance);
                        break;

                    //In case the user choice is a deposit
                    case "Deposit":

                        //Performing the deposit and storing the new balance
                        newBalance = (double)transactionManager.Deposit(constructorData.bankAccount.BankAccountId, double.Parse(txtAmount.Text), "Deposit");

                        //Update the current balance to be equal to the new one
                        lblBalance.Text = newBalance.ToString("c");

                        //Checking if the transaction was successfull by calling the check transaction success method
                        CheckTransactionSuccess(newBalance);
                        break;
                }
            }
            catch (Exception ex)
            {
                //Displaying a message in case an exception is caught
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Checks if the transaction is successful
        /// </summary>
        /// <param name="balance">The balance after performing the transaction</param>
        private void CheckTransactionSuccess(double balance)
        {
            //Checks if balance is null
            if (balance == null)
            {
                //Displaying message to the user if the transaction is unsuccessful
                MessageBox.Show("Cannot Complete Transaction", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
