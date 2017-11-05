using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BankOfBIT.Models;

public partial class wfAccount : System.Web.UI.Page
{
    //Creating an instance of bank of bit database
    BankOfBITContext db = new BankOfBITContext();

    /// <summary>
    /// Handles the page load event
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Getting the client name from the session variable and assigning it to the lable
            lblClient.Text = Session["FullName"].ToString();

            //Getting the client number from the session variable and assigning it to the account number label
            lblAccountNumber.Text = Session["AccountNumber"].ToString();

            //Getting the balance from the session variable and assigning it to the balance label
            lblBalance.Text = Session["Balance"].ToString();

            //Storing account number into a variable for easier use in the query
            int accountNumber = int.Parse(Session["AccountNumber"].ToString());

            //Obtaining bank account id that corresponds with the account number
            Session["BankAccountId"] = db.BankAccounts.Where(x => x.AccountNumber == accountNumber).Select(x => x.BankAccountId).SingleOrDefault();

            //Storing bank account id from the session variable into an int variable for easier use
            int bankAccountId = int.Parse(Session["BankAccountId"].ToString());

            //Querying the database to obtain values to put in the grid view based on the bank account id retrieved
            var transactionQuery = db.Transactions.Where(result => result.BankAccountId == bankAccountId).Select(record => new
                                                                               {
                                                                                   record.DateCreated,
                                                                                   record.TransactionType.Description,
                                                                                   record.Deposit,
                                                                                   record.Withdrawal,
                                                                                   record.Notes
                                                                               });

            //Setting the data obtained in the query to the grid view
            gvAccount.DataSource = transactionQuery.ToList();

            //Binding the data
            this.DataBind();
        }
        catch (Exception ex)
        {
            //Enabling the error button
            lblError.Visible = true;

            //Displays an error message when an exception occures
            lblError.Text = ex.Message;
        }
    }

    /// <summary>
    /// Handles the link button event and transfers to transaction form
    /// </summary>
    protected void btnLinkButton_Click(object sender, EventArgs e)
    {
        //Transfering the user to the transaction web page
        Server.Transfer("wfTransaction.aspx");
    }
}