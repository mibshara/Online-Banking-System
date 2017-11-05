using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

// Data annotations
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankOfBIT.Models
{
    /// <summary>
    /// Represents the information needed to start a bank account
    /// </summary>
    public abstract class BankAccount
    {
        /// <summary>
        /// Represents how many account states are there
        /// </summary>
        private const int NUMBER_OF_ACCOUNT_STATES = 4;

        /// <summary>
        /// Bank account unique id
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BankAccountId { get; set; }

        /// <summary>
        /// The bank account number
        /// </summary>
        [Display(Name = "Account\nNumber")]
        public long AccountNumber { get; set; }

        /// <summary>
        /// Unique client id
        /// </summary>
        [Required]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        /// <summary>
        /// Unique id represents the state of the client
        /// </summary>
        [Required]
        [ForeignKey("AccountState")]
        public int AccountStateId { get; set; }

        /// <summary>
        /// Bank account balance
        /// </summary>
        [Required]
        [Display(Name = "Current\nBalance")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Balance { get; set; }

        /// <summary>
        /// Bank account opening balance
        /// </summary>
        [Required]
        [Display(Name = "Opening\nBalance")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double OpeningBalance { get; set; }

        /// <summary>
        /// The data the bank account is created
        /// </summary>
        [Required]
        [Display(Name = "Date\nCreated")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Notes about the account
        /// </summary>
        [Display(Name = "Account Notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Account description
        /// </summary>
        [Display(Name = "Account\nType")]
        public string Description { get { return GetType().Name.Remove(GetType().Name.Length - 72); } }

        /// <summary>
        /// Navigational properties
        /// </summary>
        public virtual AccountState AccountState { get; set; }
        public virtual Client Client { get; set; }

        /// <summary>
        /// Sets the next account number
        /// </summary>
        public abstract void SetNextAccountNumber();

        /// <summary>
        /// Changes the state of the account based on the balance
        /// </summary>
        public void ChangeState()
        {
            //Creating a new instance of the database
            BankOfBITContext db = new BankOfBITContext();

            //Loops through the number of the available bank account types
            for (int i = 0; i < NUMBER_OF_ACCOUNT_STATES; i++)
            {
                //Sets the state id to the account sate id
                int currentStateId = this.AccountStateId;

                //Sets the account current state to the one that is stored in the database
                AccountState currentState = db.AccountStates.Where(x => x.AccountStateId == currentStateId).SingleOrDefault();

                //Changing the current state
                currentState.StateChangeCheck(this);

                //Saving the entries to the database
                db.SaveChanges();
            }
        }

    }

    /// <summary>
    /// Represents the properties of a general account state
    /// </summary>
    public abstract class AccountState
    {
        /// <summary>
        /// Represents the account uniqe id
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AccountStateId { get; set; }

        /// <summary>
        /// Represents the lowest limit of the state
        /// </summary>
        [Display(Name = "Lower\nLimit")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double LowerLimit { get; set; }


        /// <summary>
        /// Represents the highest limit of the pacific state
        /// </summary>
        [Display(Name = "Upper\nLimit")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double UpperLimit { get; set; }

        /// <summary>
        /// Represents the state rate
        /// </summary>
        [Required]
        [Display(Name = "Interest\nRate")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double Rate { get; set; }

        /// <summary>
        /// Represents a description of the state
        /// </summary>
        [Display(Name = "Account\nState")]
        public string Description { get { return GetType().Name.Replace("State", ""); } }

        //Navigational Properties
        /// <summary>
        /// Adjusts the state rate based on the balance
        /// </summary>
        public virtual double RateAdjustment(BankAccount bankAccount) { return 0; }

        /// <summary>
        /// Checks if the state is supposed to change based on the balance
        /// </summary>
        public virtual void StateChangeCheck(BankAccount bankAccount) { }

    }

    /// <summary>
    /// Represents information of back client
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Client's id
        /// </summary>
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        /// <summary>
        /// Client's number
        /// </summary>
        [Display(Name = "Client")]
        public long ClientNumber { get; set; }

        /// <summary>
        /// Represents client's first name
        /// </summary>
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Represents client's last name
        /// </summary>
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Client's address
        /// </summary>
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        /// <summary>
        /// Client's city
        /// </summary>
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        /// <summary>
        /// Client's province
        /// </summary>
        [Required(ErrorMessage = "Please Enter a Valid Province")]
        [StringLength(2)]
        [Display(Name = "Province")]
        [RegularExpression("^(^N[BLSTU]$)|(^[AMN]B$)|(^[BQ]C$)|(^ON$)|(^PE$)|(^SK$)$")]
        public string Province { get; set; }

        /// <summary>
        /// Client's postal code
        /// </summary>
        [Required]
        [StringLength(7)]
        [Display(Name = "Postal\nCode")]
        [RegularExpression("[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]", ErrorMessage = "Please Enter a Valid Postal Code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Represent the date that the client was created in the system
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Date\nCreated")]
        public string DateCreated { get; set; }

        /// <summary>
        /// Nots about the client
        /// </summary>
        [Display(Name = "Client\nNotes")]
        public string Notes { get; set; }

        /// <summary>
        /// Client's full Name
        /// </summary>
        [Display(Name = "Name")]
        public string FullName { get { return FirstName + " " + LastName; } }

        /// <summary>
        /// Client's full address
        /// </summary>
        [Display(Name = "Address")]
        public string FullAddress { get { return Address + " " + City + " " + Province + " " + PostalCode; } }

        // Navigational Properties
        /// <summary>
        /// Sets the next client number to the next available number
        /// </summary>
        public void SetNextClientNumber() 
        {
            ClientNumber = (long)StoredProcedures.NextNumber("NextClientNumbers");
        }




    }

    /// <summary>
    /// Representes the information of a pacific savings account
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Represents the service charge of a savings account
        /// </summary>
        [Required]
        [Display(Name = "Service\nCharges")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double SavingsServiceCharge { get; set; }

        /// <summary>
        /// Sets the next savings account number to the next available number
        /// </summary>
        public override void SetNextAccountNumber()
        {
            //Extracting the next available number from the database using stored procedure
           AccountNumber = (long)StoredProcedures.NextNumber("NextSavingsAccounts");
        }
    }

    /// <summary>
    /// Representes the information of a pacific investment account
    /// </summary>
    public class InvestmentAccount : BankAccount
    {
        /// <summary>
        /// represents the service charge of an investment account
        /// </summary>
        [Required]
        [Display(Name = "Interest\nRate")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double InterestRate { get; set; }

        /// <summary>
        /// Sets the account number to the next available one
        /// </summary>
        public override void SetNextAccountNumber()
        {
            AccountNumber = (long)StoredProcedures.NextNumber("NextInvestmentAccounts");
        }
    }

    /// <summary>
    /// Representes the information of a pacific mortgage account
    /// </summary>
    public class MortgageAccount : BankAccount
    {
        /// <summary>
        /// Represents a mortgage account service charge
        /// </summary>
        [Required]
        [Display(Name = "Interest\nRate")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double MortgageRate { get; set; }

        /// <summary>
        /// Represents the amortization rate of a mortgage account
        /// </summary>
        [Display(Name = "Amortization")]
        public int Amortization { get; set; }

        /// <summary>
        /// Sets the account number to the next available one
        /// </summary>
        public override void SetNextAccountNumber()
        {
            AccountNumber = (long)StoredProcedures.NextNumber("NextMortgageAccounts");
        }
    }

    /// <summary>
    /// Representes the information of a pacific chequing account
    /// </summary>
    public class ChequingAccount : BankAccount
    {
        /// <summary>
        /// Represents the service charge for a chequing account
        /// </summary>
        [Required]
        [Display(Name = "Service\nCharges")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double ChequingServiceCharges { get; set; }

        /// <summary>
        /// Sets the next account number to the next available one in the database
        /// </summary>
        public override void SetNextAccountNumber()
        {
            AccountNumber = (long)StoredProcedures.NextNumber("NextChequingAccounts");
        }
    }

    /// <summary>
    /// Represents a bronze state account
    /// </summary>
    public class BronzeState : AccountState
    {
        /// <summary>
        /// Constructor for a bronze state
        /// </summary>
        private static BronzeState bronzeState;


        // Bronze state values
        public const double LOWER_LIMIT = 0,
                             UPPER_LIMIT = 5000,
                             RATE = 0.01;

        public new double LowerLimit { get; set; }
        public new double UpperLimit { get; set; }
        public new double Rate { get; set; }

        /// <summary>
        /// Setting the bronze state values
        /// </summary>
        private BronzeState()
        {
            this.LowerLimit = LOWER_LIMIT;
            this.UpperLimit = UPPER_LIMIT;
            this.Rate = RATE;
        }

        /// <summary>
        /// Checks if there is a record of the bronze state in the database,
        /// if there is one, it returns it, if there is not, it creates one
        /// </summary>
        /// <returns>The bronze state found or created</returns>
        public static BronzeState GetInstance()
        {
            BankOfBITContext db = new BankOfBITContext();

            if (bronzeState == null)
            {
                bronzeState = db.BronzeStates.SingleOrDefault();

                if (bronzeState == null)
                {
                    bronzeState = new BronzeState();
                    bronzeState = db.BronzeStates.Add(bronzeState);
                    db.SaveChanges();
                }
            }
            return bronzeState;
        }

        /// <summary>
        /// Adjusts the rates based on the balance
        /// </summary>
        /// <returns>The adjusted rate</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            if (bankAccount.Balance > 0)
            {
                return this.Rate;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Checks if balance is more than the upper limit and sets the right state.
        /// </summary>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            //Checks if balance is more than the upper limit to change the state to the next one
            if (bankAccount.Balance > UpperLimit)
            {
                bankAccount.AccountStateId = SilverState.GetInstance().AccountStateId;
            }
        }
    }

    /// <summary>
    /// Represents a silver state account
    /// </summary>
    public class SilverState : AccountState
    {
        /// <summary>
        /// Constructs a silver state
        /// </summary>
        private static SilverState silverState;

        /// <summary>
        /// Siver state values
        /// </summary>
        private const double LOWER_LIMIT = 5000,
                             UPPER_LIMIT = 10000,
                             RATE = 0.0125;

        public new double LowerLimit { get; set; }
        public new double UpperLimit { get; set; }
        public new double Rate { get; set; }

        private SilverState()
        {
            this.LowerLimit = LOWER_LIMIT;
            this.UpperLimit = UPPER_LIMIT;
            this.Rate = RATE;
        }

        /// <summary>
        /// Gets an instatce of silverstate object
        /// </summary>
        /// <returns></returns>
        public static SilverState GetInstance()
        {
            BankOfBITContext db = new BankOfBITContext();

            //Checks the database for a silverstate
            if (silverState == null)
            {
                silverState = db.SilverStates.SingleOrDefault();

                if (silverState == null)
                {
                    silverState = new SilverState();
                    silverState = db.SilverStates.Add(silverState);
                    db.SaveChanges();
                }
            }
            return silverState;
        }

        /// <summary>
        /// Adjust the rate of a silver state, 
        /// </summary>
        public override double RateAdjustment(BankAccount bankAccount) { return this.Rate; }

        /// <summary>
        /// Checks the current state and matches it with silverste requiremnets
        /// </summary>
        /// <param name="bankAccount"></param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            //Checks if balance is lower than the lower limit
            if (bankAccount.Balance < LowerLimit)
            {
                bankAccount.AccountStateId = BronzeState.GetInstance().AccountStateId;
            }
            //Checks if balance is more than upper limit
            if (bankAccount.Balance > this.UpperLimit)
            {
                bankAccount.AccountStateId = GoldState.GetInstance().AccountStateId;
            }
        }
    }


    /// <summary>
    /// Represents a gold state account
    /// </summary>
    public class GoldState : AccountState
    {
        /// <summary>
        /// Constructs a gold state
        /// </summary>
        private static GoldState goldState;

        private const double LOWER_LIMIT = 10000,
                             UPPER_LIMIT = 20000,
                             RATE = 0.02;

        public new double LowerLimit { get; set; }
        public new double UpperLimit { get; set; }
        public new double Rate { get; set; }

        /// <summary>
        /// Sets gold state limit values
        /// </summary>
        private GoldState()
        {
            this.LowerLimit = LOWER_LIMIT;
            this.UpperLimit = UPPER_LIMIT;
            this.Rate = RATE;
        }

        /// <summary>
        /// Gets an instance of a gold state (singleton pattern)
        /// </summary>
        public static GoldState GetInstance()
        {
            BankOfBITContext db = new BankOfBITContext();

            //Checks if gold state has a value
            if (goldState == null)
            {
                goldState = db.GoldStates.SingleOrDefault();

                if (goldState == null)
                {
                    goldState = new GoldState();
                    goldState = db.GoldStates.Add(goldState);
                    db.SaveChanges();
                }
            }
            return goldState;
        }

        /// <summary>
        /// Adjusts the rate for goldstate
        /// </summary>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            //Checks how old is the account and adjusts rate accordingly
            if ((bankAccount.DateCreated >= bankAccount.DateCreated.AddYears(10)))
            {
                return this.Rate + 0.01;
            }

            return this.Rate;
        }

        /// <summary>
        /// Setting the current state to the right one
        /// </summary>
        /// <param name="bankAccount"></param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            //Checks if balance is less than lower limit
            if (bankAccount.Balance < this.LowerLimit)
            {
                bankAccount.AccountStateId = SilverState.GetInstance().AccountStateId;
            }

            //Checks if balance is more than upper limit
            if (bankAccount.Balance > this.UpperLimit)
            {
                bankAccount.AccountStateId = PlatinumState.GetInstance().AccountStateId;
            }
        }
    }
    /// <summary>
    /// Represents a platinum state account
    /// </summary>
    public class PlatinumState : AccountState
    {
        /// <summary>
        /// Constructs a platinum state
        /// </summary>
        private static PlatinumState platinumState;

        static BankOfBITContext db = new BankOfBITContext();

        private const double LOWER_LIMIT = 20000,
                             RATE = 0.0250;
        private const double UPPER_LIMIT = double.NaN;

        public new double LowerLimit { get; set; }
        public new double UpperLimit { get; set; }
        public new double Rate { get; set; }

        /// <summary>
        /// Sets state values
        /// </summary>
        private PlatinumState()
        {
            this.LowerLimit = LOWER_LIMIT;
            this.UpperLimit = UPPER_LIMIT;
            this.Rate = RATE;
        }

        /// <summary>
        /// Gets an instates of platinum state - singlton pattern
        /// </summary>
        public static PlatinumState GetInstance()
        {
            if (platinumState == null)
            {
                platinumState = db.PlatinumStates.SingleOrDefault();

                if (platinumState == null)
                {
                    platinumState = new PlatinumState();
                    platinumState = db.PlatinumStates.Add(platinumState);
                    db.SaveChanges();
                }
            }
            return platinumState;
        }

        /// <summary>
        /// Adjusts state rate
        /// </summary>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            if ((bankAccount.DateCreated >= bankAccount.DateCreated.AddYears(10)))
            {
                return this.Rate + 0.01;
            }
            if (bankAccount.Balance > this.LowerLimit * 2)
            {
                return this.Rate + 0.005;
            }

            return this.Rate;
        }

        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Balance < this.LowerLimit)
            {
                bankAccount.AccountStateId = GoldState.GetInstance().AccountStateId;
            }
        }
    }

    /// <summary>
    /// The charactersitics of a transaction
    /// </summary>
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [Display(Name = "Transaction Number")]
        public long TransactionNumber { get; set; }

        [ForeignKey("BankAccount")]
        [Required]
        [Display(Name = "Account\nNotes")]
        public int BankAccountId { get; set; }

        [Required]
        [ForeignKey("TransactionType")]
        [Display(Name = "Transaction Type")]
        public int TransactionTypeId { get; set; }

        [Display(Name = "Deposit")]
        public double Deposit { get; set; }

        [Display(Name = "Withdrawal")]
        public double Withdrawal { get; set; }

        [Required]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Sets the next transaction number
        /// </summary>
        public void SetNextTransactionNumber()
        {
            TransactionNumber = (long)StoredProcedures.NextNumber("NextTransactionNumbers");
        }

        /// <summary>
        /// Uset to get a transaction type
        /// </summary>
        public virtual TransactionType TransactionType { get; set; }

        /// <summary>
        /// Used to get a bank account
        /// </summary>
        public virtual BankAccount BankAccount { get; set; }
    }

    /// <summary>
    /// Represents a set of transaction types available
    /// </summary>
    public class TransactionType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionTypeId { get; set; }

        [Display(Name = "Transaction Type")]
        public string Description { get; set; }

        [Display(Name = "Service Charge")]
        public double ServiceCharge { get; set; }
    }

    /// <summary>
    /// auxillary that represents the next transaction number
    /// </summary>
    public class NextTransactionNumber
    {
        

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NextTransactionNumberId { get; set; }

        public long NextAvailableNumber { get; set; }

        public static NextTransactionNumber nextTransactionNumber { get; set; }

        // Navigation properties
        private const long NEXT_AVAILABLE_NUMBER = 700;

        public NextTransactionNumber()
        {
            this.NextAvailableNumber = NEXT_AVAILABLE_NUMBER;
        }

        /// <summary>
        /// Gets an instance of the next transaction number
        /// </summary>
        /// <returns></returns>
        public static NextTransactionNumber GetInstance()
        {
            BankOfBITContext db = new BankOfBITContext();

            if (nextTransactionNumber == null)
            {
                nextTransactionNumber = db.NextTransactionNumbers.SingleOrDefault();

                if (nextTransactionNumber == null)
                {
                    nextTransactionNumber = new NextTransactionNumber();
                    nextTransactionNumber = db.NextTransactionNumbers.Add(nextTransactionNumber);
                    db.SaveChanges();
                }
            }
            return nextTransactionNumber;
        }
    }

    /// <summary>
    /// Represents the names and ids of payees
    /// </summary>
    public class Payee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PayeeId { get; set; }

        [Display(Name = "Payee")]
        public string Description { get; set; }
    }

    /// <summary>
    /// Represents different institution names and numbers
    /// </summary>
    public class Institution
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstitutionId { get; set; }

        [Display(Name = "Institution Number")]
        public int InstitutionNumber { get; set; }

        [Display(Name = "Institution")]
        public string Description { get; set; }
    }

    /// <summary>
    /// The properties of an RFID Tag for clients
    /// </summary>
    public class RFIDTag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RFIDTagId { get; set; }

        public long CardNumber { get; set; }

        [Required]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        // Nav properties
        public virtual Client Client { get; set; }
    }

    /// <summary>
    /// auxillary that represents the next client number
    /// </summary>
    public class NextClientNumber
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NextClientNumberId { get; set; }

        /// <summary>
        /// Represents the next available number
        /// </summary>
        public long NextAvailableNumber { get; set; }

        public static NextClientNumber nextClientNumber { get; set; }

        private const long NEXT_AVAILABLE_NUMBER = 20000000;

        public NextClientNumber()
        {
            this.NextAvailableNumber = NEXT_AVAILABLE_NUMBER;
        }

        /// <summary>
        /// Gets an instance of the next client number
        /// </summary>
        /// <returns></returns>
        public static NextClientNumber GetInstance()
        {
            BankOfBITContext db = new BankOfBITContext();

            if (nextClientNumber == null)
            {
                nextClientNumber = db.NextClientNumbers.SingleOrDefault();

                if (nextClientNumber == null)
                {
                    nextClientNumber = new NextClientNumber();
                    nextClientNumber = db.NextClientNumbers.Add(nextClientNumber);
                    db.SaveChanges();
                }
            }
            return nextClientNumber;

        }
    }

    /// <summary>
    /// auxillary that represents the next chequing account number
    /// </summary>
    public class NextChequingAccount
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NextChequingAccountId { get; set; }

        /// <summary>
        /// Represents the next available number
        /// </summary>
        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Represents the next chequing account
        /// </summary>
        public static NextChequingAccount nextChequingAccount { get; set; }

        //Nav properties
        private const long NEXT_AVAILABLE_NUMBER = 20000000;

        public NextChequingAccount()
        {
            this.NextAvailableNumber = NEXT_AVAILABLE_NUMBER;
        }

        // Singleton pattern implementation
        public static NextChequingAccount GetInstance()
        {
            BankOfBITContext db = new BankOfBITContext();

            if (nextChequingAccount == null)
            {
                nextChequingAccount = db.NextChequingAccounts.SingleOrDefault();

                if (nextChequingAccount == null)
                {
                    nextChequingAccount = new NextChequingAccount();
                    nextChequingAccount = db.NextChequingAccounts.Add(nextChequingAccount);
                    db.SaveChanges();
                }
            }
            return nextChequingAccount;
          
        }

    }

    /// <summary>
    /// auxillary that represents the next investment account number
    /// </summary>
    public class NextInvestmentAccount
    {
        

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NextInvestmentAccountId { get; set; }

        /// <summary>
        /// Represents the next available number
        /// </summary>
        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Represents the next investment account
        /// </summary>
        public static NextInvestmentAccount nextInvestmentAccount { get; set; }

        //Nav prop
        private const long NEXT_AVAILABLE_NUMBER = 2000000;

        public NextInvestmentAccount()
        {
            this.NextAvailableNumber = NEXT_AVAILABLE_NUMBER;
        }

        /// <summary>
        /// Gets an instance of the next investment account
        /// </summary>
        /// <returns></returns>
        public static NextInvestmentAccount GetInstance()
        {
            BankOfBITContext db = new BankOfBITContext();

            if (nextInvestmentAccount == null)
            {
                nextInvestmentAccount = db.NextInvestmentAccounts.SingleOrDefault();

                if (nextInvestmentAccount == null)
                {
                    nextInvestmentAccount = new NextInvestmentAccount();
                    nextInvestmentAccount = db.NextInvestmentAccounts.Add(nextInvestmentAccount);
                    db.SaveChanges();
                }
            }
            return nextInvestmentAccount;
        }
    }

    /// <summary>
    /// auxillary that represents the next mortgage account number
    /// </summary>
    public class NextMortgageAccount
    {


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NextMortgageAccountId { get; set; }

        /// <summary>
        /// Represents the next available number
        /// </summary>
        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Represents the next mortgage account
        /// </summary>
        public static NextMortgageAccount nextMortgageAccount { get; set; }

        private const long NEXT_AVAILABLE_NUMBER = 200000;

        /// <summary>
        /// Sets the next available number
        /// </summary>
        public NextMortgageAccount()
        {
            this.NextAvailableNumber = NEXT_AVAILABLE_NUMBER;
        }

        /// <summary>
        /// Gets an instance of the next mortgage account
        /// </summary>
        public static NextMortgageAccount GetInstance()
        {
           BankOfBITContext db = new BankOfBITContext();

            if (nextMortgageAccount == null)
            {
                nextMortgageAccount = db.NextMortgageAccounts.SingleOrDefault();

                if (nextMortgageAccount == null)
                {
                    nextMortgageAccount = new NextMortgageAccount();
                    nextMortgageAccount = db.NextMortgageAccounts.Add(nextMortgageAccount);
                    db.SaveChanges();
                }
            }
            return nextMortgageAccount;
        }

    }

    /// <summary>
    /// auxillary that represents the next savings account number
    /// </summary>
    public class NextSavingsAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NextSavingsAccountId { get; set; }

        /// <summary>
        /// Represents the next available number
        /// </summary>
        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Represents the next savings account
        /// </summary>
        public static NextSavingsAccount nextSavingsAccount { get; set; }

        private const long NEXT_AVAILABLE_NUMBER = 20000;

        /// <summary>
        /// Sets the next available number
        /// </summary>
        public NextSavingsAccount()
        {
            this.NextAvailableNumber = NEXT_AVAILABLE_NUMBER;
        }

        /// <summary>
        /// Gets an instance of the next savings account
        /// </summary>
        public static NextSavingsAccount GetInstance()
        {
            BankOfBITContext db = new BankOfBITContext();

            if (nextSavingsAccount == null)
            {
                nextSavingsAccount = db.NextSavingsAccounts.SingleOrDefault();

                if (nextSavingsAccount == null)
                {
                    nextSavingsAccount = new NextSavingsAccount();
                    nextSavingsAccount = db.NextSavingsAccounts.Add(nextSavingsAccount);
                    db.SaveChanges();
                }
            }
            return nextSavingsAccount;
        }
    }

    /// <summary>
    /// Stored procedure used to set next numbers
    /// </summary>
    public static class StoredProcedures
    {
        /// <summary>
        /// a static method that call the next number procedure in the database
        /// </summary>
        /// <param name="tableName">the table name which wanna access</param>
        /// <returns>the next number available</returns>
        public static long? NextNumber(string tableName)
        {
            //Creating a new connection with the provided connection string
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=BankofBITContext;Integrated Security=True");

            //A variable to hold the return value, set to long? so it could be nullable
            long? returnValue = 0;

            // Initiating a new sqlcommand with the command name and the connection created
            SqlCommand storedProcedure = new SqlCommand("next_number", connection);

            //Settomg the stored procedure's command type to the type was set above
            storedProcedure.CommandType = CommandType.StoredProcedure;

            //Passing the table name as a parameter to the stored procedure
            storedProcedure.Parameters.AddWithValue("@TableName", tableName);

            //Setting the new output value
            SqlParameter outputParameter = new SqlParameter("@NewVal", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.Output
            };

            try
            {
                //Adding the putput parameter into the stored procedure
                storedProcedure.Parameters.Add(outputParameter);

                //Opening the database connection
                connection.Open();

                //Excuting the stored procedure query
                storedProcedure.ExecuteNonQuery();

                //Closing the database connection
                connection.Close();

                //Stroing the output value in to the return value variable
                returnValue = (long?)outputParameter.Value;

            }
            //Catching the exeption
            catch (Exception)
            {
                //Setting the output returnValue variable to non if there is an exception
                returnValue = null;
            }
            // Returning the output value
            return returnValue;
        }
    }
}