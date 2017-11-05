using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITransactionManager" in both code and config file together.
[ServiceContract]
public interface ITransactionManager
{
	[OperationContract]
	void DoWork();

    /// <summary>
    /// Creates the interface for deposits
    /// </summary>
    /// <param name="accountId">Represents the unique account Id</param>
    /// <param name="amount">Represents the amount being deposited</param>
    /// <param name="notes"> Account description</param>
    [OperationContract]
    double? Deposit(int accountId, double amount, string notes);

    /// <summary>
    /// Creates the interface for withdrawal
    /// </summary>
    /// <param name="accountId">Represents the unique account Id</param>
    /// <param name="amount">Represents the amount being withdrawn</param>
    /// <param name="notes"> Account description</param>
    [OperationContract]
    double? Withdrawal(int accountId, double amount, string notes);

    /// <summary>
    /// Creates the interface for bill Payments
    /// </summary>
    /// <param name="accountId">Represents the unique account Id</param>
    /// <param name="amount">Represents the amount bill payment amount</param>
    /// <param name="notes">Account description</param>
    [OperationContract]
    double? BillPayment(int accountId, double amount, string notes);

    /// <summary>
    /// Creates the interface for transfers
    /// </summary>
    /// <param name="fromAccountId">Represents the account that the money is being sent from</param>
    /// <param name="toAmountId">Represents the account that the money is being sent to</param>
    /// <param name="amount">Represents the amount transfered</param>
    /// <param name="notes">Account description</param>
    /// <returns></returns>
    [OperationContract]
    double? Transfer(int fromAccountId, int toAmountId, double amount, string notes);

    /// <summary>
    /// Creates the interface for Calculating interest
    /// </summary>
    /// <param name="accountId">Represents the unique account Id</param>
    /// <param name="amount">Represents the amount for interest calculation</param>
    /// <param name="notes">Account description</param>
    [OperationContract]
    double? CalculateInterest(int accountId, double amount, string notes);
}
