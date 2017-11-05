using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BankOfBIT.Models;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TransactionManager" in code, svc and config file together.
public class TransactionManager : ITransactionManager
{
    //Creating an instance og bank of bit context database
    BankOfBITContext db = new BankOfBITContext();

    public void DoWork()
    {
    }

    /// <summary>
    /// This method updates the balance of the account after a deposit.
    /// </summary>
    /// <param name="accountId">Represents the user account id</param>
    /// <param name="amount">Represents the amount being deposited</param>
    /// <param name="notes">Account description</param>
    /// <returns>the new balance</returns>
    public double? Deposit(int accountId, double amount, string notes)
    {
        //creating an nullable variable and storing the updated account balance aquired from update account balance method
        double? updatedBalance = updateAccountBalance(accountId, amount);

        //Creating a record in transaction table
        TransactionRecord(accountId, amount, notes, true, (int)Utility.TransactionTypeValues.Deposit);

        //returning the updated balance
        return updatedBalance;


    }

    /// <summary>
    /// This method updates the balance of the account after a withdrawal.
    /// </summary>
    /// <param name="accountId">Represents the user account id</param>
    /// <param name="amount">Represents the amount being withdrawan</param>
    /// <param name="notes">Account description</param>
    /// <returns>the new balance</returns>
    public double? Withdrawal(int accountId, double amount, string notes)
    {
        //creating an nullable variable and storing the updated account balance aquired from update account balance method
        double? updatedBalance = updateAccountBalance(accountId, -amount);

        //Creating a record in transaction table
        TransactionRecord(accountId, amount, notes, false, (int)Utility.TransactionTypeValues.Withdrawal);

        //returning the updated balance
        return updatedBalance;
    }

    /// <summary>
    /// This method updates the balance of the account after a bill payment.
    /// </summary>
    /// <param name="accountId">Represents the user account id</param>
    /// <param name="amount">Represents the amount of the payment</param>
    /// <param name="notes">Account description</param>
    /// <returns>the new balance</returns>
    public double? BillPayment(int accountId, double amount, string notes)
    {
        //creating an nullable variable and storing the updated account balance aquired from update account balance method
        double? updatedBalance = updateAccountBalance(accountId, -amount);

        //Creating a record in transaction table
        TransactionRecord(accountId, amount, notes, false, (int)Utility.TransactionTypeValues.BillPayment);

        //returning the updated balance
        return updatedBalance;
    }

    /// <summary>
    /// This method updates the balance of the account after a transfer.
    /// </summary>
    /// <param name="fromAccountId">Represents the user account id</param>
    /// <param name="amount">Represents thhe amount tranfered</param>
    /// <param name="notes">Account description</param>
    /// <param name="deposit">Determins if a deposit happened</param>
    /// <param name="transactionType">Represent the transaction type</param>
    public double? Transfer(int fromAccountId, int toAccountId, double amount, string notes)
    {
        //creating an nullable variable and storing the updated account balance aquired from update account balance method
        double? fromAccountBalance = updateAccountBalance(fromAccountId, -amount);

        //Checking if the account where money is being transfered is greater than 0
        if (fromAccountBalance != null)
        {
            //Creating a transaction record where money is being withdrawn from the from account
            TransactionRecord(fromAccountId, amount, notes, false, (int)Utility.TransactionTypeValues.Transfer);

            //creating an nullable variable and storing the updated account balance aquired from update account balance method
            double? toAccountBalance = updateAccountBalance(toAccountId, amount);

            //Creating a transaction record where money is being deposited to the receiver's account
            TransactionRecord(toAccountId, amount, notes, true, (int)Utility.TransactionTypeValues.TransferRecipient);

            //Checking if the receiver didn't recieve the transfer
            if (toAccountBalance == null)
            {
                //Updating the balance
                updateAccountBalance(fromAccountId, amount);

                //Setting the from balance to null
                fromAccountBalance = null;
            }
        }

        //Returing the updated balance
        return fromAccountBalance;
    }

    /// <summary>
    /// Responsible for updating the balance based on the transaction
    /// </summary>
    /// <param name="accountId">Represents the user account Id</param>
    /// <param name="amount">Represents the amount changed</param>
    /// <returns>Account balance</returns>
    private double? updateAccountBalance(int accountId, double amount)
    {
        try
        {
           //Creating an instance of bank account
            BankAccount bankAccount = db.BankAccounts.Where(x => x.BankAccountId == accountId).SingleOrDefault();

            //Setting account balance
            bankAccount.Balance += amount;

            //Ensuring bank account is always associated with the correct state
            bankAccount.ChangeState();

            //Saving the changes made to the account
            updateChanges();

            //Returning updated balance
            return bankAccount.Balance;
        }
        //Catching any exception
        catch (Exception)
        {
            //Returning null if there is exception
            return null;
        }
    }


    /// <summary>
    /// Creates a record in transaction table
    /// </summary>
    /// <param name="accountId">Represents the user account id</param>
    /// <param name="amount">Represents thhe amount tranfered</param>
    /// <param name="notes">Account description</param>
    /// <param name="depositOrWithdrawal">Determins if a deposit happened</param>
    /// <param name="transactionType">Represent the transaction type</param>
    public void TransactionRecord(int accountId, double amount, string notes, bool depositWithdrawal, int transactionTypeId)
    {
        //Creating an instance of transaction
        Transaction transaction = new Transaction();

        //Setting the bank account id
        transaction.BankAccountId = accountId;

        //Checks for a deposit and setting the deposit amount
        transaction.Deposit = depositWithdrawal ? amount : 0;

        //Checks for a withdrawal and setting the withdrawal amount
        transaction.Withdrawal = depositWithdrawal ? 0 : amount;

        //Setting the account notes
        transaction.Notes = notes;

        //setting the next transaction number
        transaction.SetNextTransactionNumber();

        //Setting the transaction type
        transaction.TransactionTypeId = transactionTypeId;

        //setting the date of the transaction to the current date
        transaction.DateCreated = DateTime.Now;

        //Adding a transaction
        db.Transactions.Add(transaction);

        //Saving the database changes made to the account
        db.SaveChanges();
    }

    /// <summary>
    /// Calculates interest
    /// </summary>
    /// <param name="accountId">Represents the unique account Id</param>
    /// <param name="amount">Represents the amount for interest calculation</param>
    /// <param name="notes">Account description</param>
    /// <returns>The interest calculated</returns>
    public double? CalculateInterest(int accountId, double amount, string notes)
    {
        return 0;
    }
    // Save the changes in the database
    private void updateChanges()
    {
        db.SaveChanges();
    }


}
