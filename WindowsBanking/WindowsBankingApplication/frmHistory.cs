using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Utility;
using BankOfBIT.Models;
//note:  this needed to be done because during development
//ef released v. 6
//ef6 needed to add this
//using System.Data.Entity.Core;

namespace WindowsBankingApplication
{
    public partial class frmHistory : Form
    {

        ///given:  client and bankaccount data will be retrieved
        ///in this form and passed throughout application
        ///this object will be used to store the current
        ///client and selected bankaccount
        ConstructorData constructorData;

        //Creating an instance of bank of BIT database
        BankOfBITContext db = new BankOfBITContext();

        public frmHistory()
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
        public frmHistory(ConstructorData constructorData)
        {
            InitializeComponent();
            this.constructorData = constructorData;

            //Populating the corresponding data in the client number label
            lblClientNumber.Text = constructorData.client.ClientNumber.ToString();

            //Populating the corresponding data in the fullname label
            lblFullName.Text = constructorData.client.FullName.ToString();

            //Populating the corresponding data in the account number label
            lblAccountNumber.Text = constructorData.bankAccount.AccountNumber.ToString();

            //Populating the corresponding data in the balance label
            lblBalance.Text = constructorData.bankAccount.Balance.ToString("c");
        }

        /// <summary>
        /// given:  this code will navigate back to frmClient with
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
        /// given - further code required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistory_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            try
            {
                //Setting the account number masked label using the utility project
                lblAccountNumber.Mask = Utility.BusinessRules.AccountFormat(constructorData.bankAccount.Description);

                //Querying selecting data from the Transaction and TransactionTypes entity classes whose BankAccountId corresponds to the one passed in the form
                var transactionQuery = db.Transactions.Join(db.TransactionTypes,
                                                            transaction => transaction.TransactionTypeId,
                                                            transactionTypes => transactionTypes.TransactionTypeId,
                                                            (transaction, transactionTypes) => new { Transaction = transaction, TransactionTypes = transactionTypes })
                                                            .Where(results => results.Transaction.BankAccountId == constructorData.bankAccount.BankAccountId)
                                                            .Select(record => new
                                                            {
                                                               record.Transaction.DateCreated,
                                                               record.TransactionTypes.Description,
                                                               record.Transaction.Deposit,
                                                               record.Transaction.Withdrawal,
                                                               record.Transaction.Notes
                                                            });

                //Setting the DataSource property of the BindingSource object representing the DataGridView control
                transactionBindingSource.DataSource = transactionQuery.ToList();
            }
            catch (Exception ex)
            {
                //Showing an error in case an exception is caught
                MessageBox.Show("Error", ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
