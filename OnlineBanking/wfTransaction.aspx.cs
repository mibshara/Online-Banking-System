using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BankOfBIT.Models;
using System.Data;
using BankServiceReference;
using Utility;

public partial class wfTransaction : System.Web.UI.Page
{
    //Creating an instance of bank of bit context database
    BankOfBITContext db = new BankOfBITContext();

    //Creating statics variable to for the access
    static int clientId;
    static int accountNumber;

    //Binding the data fields using this array
    private string[,] dataFieldsArray = new string[2, 2] {{"Description", "PayeeId"},
                                                         {"AccountNumber", "BankAccountId"}};

    //Constant that holds the error message when funds are insufficient
    private const string ERROR_INSUFFICIENT_FUNDS = "Insufficient funds.";

    //Constant that holds an error message when an error happens
    private const string ERROR_OCCURED = "An error occured when {0}";

    /// <summary>
    /// Handles the page load event
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        //Alligning text to the right
        txtAmount.Style.Add("text-align", "right");

        //Ensures that instances are only created once when the page loads
        if (!IsPostBack)
        {
            //Setting client id to the right client id from the session variable
            clientId = (int)Session["ClientId"];

            //Setting acount number to the right account number from the session variable
            accountNumber = int.Parse(Session["AccountNumber"].ToString());
            lblAccountNumber.Text = Session["AccountNumber"].ToString();

            //Setting balance label to the right balance from the session variable
            lblBalance.Text = Session["Balance"].ToString();

            //Calling the account payee dropdown list control method
            DropdownListAccountPayee();
        }
    }

    /// <summary>
    /// Sets the account payee dropdown list controls
    /// </summary>
    private void DropdownListAccountPayee()
    {
        //Selecting what is going to be displayed in the drop down list
        switch (ddlTransactionType.SelectedIndex)
        {
            //Happens if bill payment is selected
            case 0:
                //Selecting payees from payee table
                IEnumerable<Payee> payees = from result in db.Payees select result;

                //Showing the data in the dropdown list controls
                ddlTo.DataSource = payees.ToList();
                break;

            case 1:
                //Selecting bank accounts where the client id matche the one logged in to the website
                IQueryable<BankAccount> bankAccounts = from result in db.BankAccounts
                                                       where result.ClientId == clientId
                                                       && result.AccountNumber != accountNumber
                                                       select result;

                //Showing the data in the dropdown list controls
                ddlTo.DataSource = bankAccounts.ToList();
                break;
        }

        //Setting the dropdown list data text field
        ddlTo.DataTextField = dataFieldsArray[ddlTransactionType.SelectedIndex, 0];

        //Setting the dropdown list value field
        ddlTo.DataValueField = dataFieldsArray[ddlTransactionType.SelectedIndex, 1];

        //Binding the payee and accounts dropdown list controls
        ddlTo.DataBind();

        //Setting the default selected index to the first option
        ddlTo.SelectedIndex = 0;

    }

    /// <summary>
    /// Handles the event when the transaction type is changed
    /// </summary>
    protected void ddlTransactionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Clearing previous data in the payee and account dropdown list controls
        ddlTo.DataSource = null;
        ddlTo.DataTextField = null;
        ddlTo.DataValueField = null;

        //Calling the account payee dropdown list control method
        DropdownListAccountPayee();
    }

    /// <summary>
    /// Handles the event of clicking complete transaction button
    /// </summary>
    protected void btnCompleteTransaction_Click(object sender, EventArgs e)
    {
        try
        {
            //Setting current balance to the balance available
            double currentBalance = double.Parse(lblBalance.Text.Replace("$", ""));

            //Setting the requested amount the amount entered
            double requestedAmount = double.Parse(txtAmount.Text);

            //Comparing the requested amount to the available current balance and displaying an error messages if it is less
            if (requestedAmount > currentBalance)
            {
                //Displaying error message if the current balance is less than the requested amount
                lblError.Text = ERROR_INSUFFICIENT_FUNDS;
            }
            else
            {
                //Creating an instance of TransactionManagerClient
                TransactionManagerClient transactionManagerClient = new TransactionManagerClient();

                //Checking if index selected is bill payment or a transfer
                if (ddlTransactionType.SelectedIndex == 0)
                {
                    //Quering and storing the account id logged in
                    int accountId = (from result in db.BankAccounts
                                     where result.AccountNumber == accountNumber
                                     select result.BankAccountId).SingleOrDefault();

                    //Calling the bill payment method
                    double? newBalance = transactionManagerClient.BillPayment(accountId, requestedAmount, "Bill Payment");

                    //Checking if bill payment method returns a value that indicates a failed transaction
                    if (newBalance == null)
                    {
                       //Throwing an exception with the right error message
                       throw new Exception(string.Format(ERROR_OCCURED, "paying bill!."));
                    }
                    //Happens if bill payment succeeds
                    else
                    {
                        //Showing the right new balance
                        lblBalance.Text = string.Format("{0:c}", newBalance);

                        //Updating the balance session variable
                        Session["Balance"] = newBalance;

                        //Clearing the amount text field
                        txtAmount.Text = string.Empty;
                    }
                }
               //Happens if a transfer is selected
                else if (ddlTransactionType.SelectedIndex == 1)
                {
                    //Quering and storing the account id logged in
                    int fromAccountId = (from result in db.BankAccounts
                                         where result.AccountNumber == accountNumber
                                         select result.BankAccountId).SingleOrDefault();

                    //Getting the receiver's account id
                    int toAccountId = int.Parse(ddlTo.Text);

                    //Calling the transfer method
                    double? newBalanceTransfer = transactionManagerClient.Transfer(fromAccountId, toAccountId, requestedAmount, "Transfer");

                    //Checking if transfer method returns a value that indicates a failed transaction
                    if (newBalanceTransfer == null)
                    {
                        //Throwing an exception with the right error message
                        throw new Exception(string.Format(ERROR_OCCURED, "transferring money!."));
                    }
                    //Happens if the transfer succeeds
                    else
                    {
                        //Showing the right new balance
                        lblBalance.Text = string.Format("{0:c}", newBalanceTransfer);

                        //Updating the balance session variable
                        Session["Balance"] = newBalanceTransfer;

                        //Clearing the amount text field
                        txtAmount.Text = string.Empty;
                    }
                }
            }
        }
       //Hanldes all thrown exceptions
        catch (Exception ex)
        {
            //Displays the error message
            lblError.Text = ex.Message;
        }
    }
}