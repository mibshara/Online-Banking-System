using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BankOfBIT.Models;
using net.kowabunga.currencyconverter;
using net.webservicex.www;


public partial class wfClient : System.Web.UI.Page
{
    //Creating an instance of the database
    BankOfBITContext db = new BankOfBITContext();

    /// <summary>
    /// Handles the load event of the web form
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {   
        //Ensures that instances are only created once when the page loads
        if (!IsPostBack)
        {
            try
            {
                //Getting the client's logging in Id (client number)
                int clientNumber = int.Parse(Page.User.Identity.Name);

                //Creating an instance of a client and getting the client info from the database using the client number
                Client client = db.Clients.Where(x => x.ClientNumber == clientNumber).SingleOrDefault();

                //Getting client's full name and storing it into a session variable.
                Session["FullName"] = client.FullName;

                //Getting the client's id and storing it in a variable for easier use later.
                int clientId = client.ClientId;

                //Storing the client's id into a session variable
                Session["ClientId"] = clientId;

                //Displaying the client's full name into the client lable
                lblClientFullName.Text = Session["FullName"].ToString();

                //Getting a collection of BankAccount records whose client id matches
                IQueryable<BankAccount> recordsQuery = db.BankAccounts.Where(x => x.ClientId == clientId);

                //Showing the data collection to the  gridview list
                gvClient.DataSource = recordsQuery.ToList();

                //Binding the data
                this.DataBind();

                //Creating an instance of web service currency convertor
                CurrencyConvertor convertor = new CurrencyConvertor();

                //Displays the current value of the exchange eate between CAD and USD
                lblRate.Text = string.Format("The exchange rate between Canada and the United States is currently {0:c}", convertor.ConversionRate(Currency.CAD, Currency.USD));
            }
            catch (Exception ex)
            {
                //Enabling the error button
                lblError.Visible = true;

                //Displaying an error message if an exeption occures
                lblError.Text = ex.Message;
            }
        }
        
    }


    /// <summary>
    /// Handles the select index change event in the client grid view
    /// </summary>
    protected void gvClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Getting the client's account number and storing it in a session variable
        Session["AccountNumber"] = gvClient.Rows[gvClient.SelectedIndex].Cells[1].Text;

        //Getting the client's balance and storing it in a session variable
        Session["Balance"] = gvClient.Rows[gvClient.SelectedIndex].Cells[3].Text;

        //Getting the client's bankaccount id and storing it in a session variable
        //Session["BankAccountId"] = ((GridView)sender).SelectedDataKey["BankAccountId"];

        //Transfereing the user to the account web page
        Server.Transfer("wfAccount.aspx");
    }
}