using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSconcepts
{
    /// <summary>
    /// AccountNumberGenerator is a static Class that contains a single method to generate Sequential Account Numbers
    /// </summary>
    /// <example>
    /// <code>
    /// AccountNumberGenerator.getAccountNumber(); // 1_00_00_00_00_001
    /// AccountNumberGenerator.getAccountNumber(); // 1_00_00_00_00_002
    /// </code>
    /// </example>
    /// <remarks>Account Numbers are type ling and starting with value 1_00_00_00_00_000</remarks>
    public static class AccountNumberGenerator {

        static long account_number_series = 100000000000;

        /// <summary>
        /// A static Method to generate Sequential Account Number with each call
        /// </summary>
        /// <code>
        /// AccountNumberGenerator.getAccountNumber(); // 1_00_00_00_00_001
        /// AccountNumberGenerator.getAccountNumber(); // 1_00_00_00_00_002
        /// </code>
        /// <returns> long type Account Number such as 1_00_00_00_00_002</returns>
        public static long getAccountNumber() {
            account_number_series += 1;

            return account_number_series;
        }
    }

    /// <summary>
    /// An Abstract Class to avail Basic Bank Account Properties such as
    /// <list type="bullet">
    /// <item>Account Holder Name</item>
    /// <item>Account Number</item>
    /// <item>Balance</item>
    /// </list>
    /// </summary>
    public abstract class BankAccount
    {
        public string account_holder_name;
        public long account_number;
        public float balance;
    
    
    }


    /// <summary>
    /// Bank Account Interface to Enforce Basic Operations such as
    /// <list type="bullet">
    /// <item>Deposit Money</item>
    /// <item>Withdraw</item>
    /// <item>getBalance</item>
    /// </list>
    /// </summary>
    public interface IBankAccount
    {
        bool deposit(float amount);
        bool withdraw(float amount);
        float getBalance();
        
        
    
    }


    /// <summary>
    /// Savings Account Interface to Enable Saving Account Property Interest Rate
    /// Provides Mehthods such as
    /// <list type="bullet">
    /// <item>setInterestRate</item>
    /// <item>getInterestRate</item>
    /// </list>
    /// </summary>
    /// <remarks>Extends <see cref="IBankAccount"/></remarks>
    public interface ISavingBankAccount:IBankAccount
    {
        bool setInterestRate(float rate);
        float getInterestRate();
    
    }


    /// <summary>
    /// Current Account Interface to Enable Current Account Property Limit
    /// Methods are as follows
    /// <list type="bullet">
    /// <item>setLimit</item>
    /// <item>getLimit</item>
    /// </list>
    /// </summary>
    /// <remarks>Extends <see cref="IBankAccount"/></remarks>
    public interface ICurrentBankAccount : IBankAccount
    {

        bool setLimit(float amount);
        float getLimit();
    }



    /// <summary>
    /// Current Bank Account Class with Current Account Operations
    /// Implemets following Interface
    /// <list type="bullet">
    /// <item><see cref="ICurrentBankAccount"/></item>
    /// <item><see cref="IBankAccount"/></item>
    /// </list>
    /// Extends an absract class <see cref="BankAccount"/>
    /// </summary>
    public class CurrentBankAccount : BankAccount, ICurrentBankAccount
    {
        float limit;



        public CurrentBankAccount(string name)
        {
            this.balance = 0;
            this.limit = this.getDefaultLimit();
            this.account_holder_name = name;
            this.account_number = AccountNumberGenerator.getAccountNumber();
        
        }

        public CurrentBankAccount(string name,float OpeningBalance)
        {
            this.balance = OpeningBalance;
            this.limit = this.getDefaultLimit();
            this.account_holder_name = name;
            this.account_number = AccountNumberGenerator.getAccountNumber();

        }
        public CurrentBankAccount(string name,float OpeningBalance, float limit)
        {
            this.balance = OpeningBalance;
            this.limit = limit;
            this.account_holder_name = name;
            this.account_number = AccountNumberGenerator.getAccountNumber();

        }

        //Retrieve the default Limit for a current Bank Account
        public float getDefaultLimit()
        {

            return 10_00_000;
        }


        /// <summary>
        /// Method to deposit a amount to Current Bank Account
        /// </summary>
        /// <param name="amount"> Float Type amount to be deposited</param>
        /// <returns> Boolean representing Operations Success</returns>
        public bool deposit(float amount)
        {
            try
            {
                //To Ensure No Overflow;
                checked
                {
                    this.balance += amount;
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }



        /// <summary>
        /// Method to Withdraw amount from Current Account
        /// </summary>
        /// <param name="amount"> Floatr type amount to be withdrawn</param>
        /// <returns> Boolean Representing Operation Success</returns>
        public bool withdraw(float amount)
        {
            //User Cannot Withdraw More than Balance
            if (amount <= balance)
            {
                this.balance -= amount;
            }
            else
            {
                return false;
            }


            return true;
        }



        /// <summary>
        /// Method to Return Current Account Balance
        /// </summary>
        /// <returns> Float Type Balance</returns>
        public float getBalance()
        {
            return balance;
        }


        /// <summary>
        /// Method to set available Limit for a Current Account                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
        /// </summary>
        /// <param name="amount"></param>
        /// <returns> Returns a Boolean Value Representing Operation Success</returns>
        public bool setLimit(float amount)
        {
            this.limit = amount;
            return true;
        }


        /// <summary>
        /// Method to Retrieve the Current Limit
        /// </summary>
        /// <returns></returns>
        public float getLimit()
        {
            return this.limit;
        
        }



    }



    /// <summary>
    /// Saving Bank Account Class with Current Account Operations
    /// Implemets following Interface
    /// <list type="bullet">
    /// <item><see cref="ISavingBankAccount"/></item>
    /// <item><see cref="IBankAccount"/></item>
    /// </list>
    /// Extends an absract class <see cref="BankAccount"/>
    /// </summary>
    public class SavingBankAccount : BankAccount, ISavingBankAccount
    {
        static float interest = 4.0F;
        public SavingBankAccount(string name, float OpeningBalance)
        {
            this.account_holder_name = name;
            this.balance = OpeningBalance;
            this.account_number = AccountNumberGenerator.getAccountNumber();
        }
        public SavingBankAccount(string name)
        {
            this.account_holder_name = name;
            this.balance = 0;
            this.account_number = AccountNumberGenerator.getAccountNumber();
        }



        /// <summary>
        /// Method To Perform Deposit Operation on a Savings Bank Account
        /// </summary>
        /// <param name="amount"> Float type amount to be  deposited</param>
        /// <returns>Return Boolean Success?</returns>
        public bool deposit(float amount)
        {
            try
            {
                //To ensure no overflow
                checked
                {
                    this.balance += amount;
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }



        /// <summary>
        /// Method to Perform Withdraw Operation on the Saving Account 
        /// </summary>
        /// <param name="amount">Float type Amount to be withdrawn</param>
        /// <returns>Returns Boolean Success?</returns>
        public bool withdraw(float amount)
        {

            //User Cannot Withdraw More than Balance
            if (amount <= balance)
            {
                this.balance -= amount;
            }
            else
            {
                return false;
            }


            return true;
        }


        /// <summary>
        /// Method To Retrieve Saving Account Balance
        /// </summary>
        /// <returns> Return FLoat type Balance</returns>
        public float getBalance()
        {
            return balance;
        }



        /// <summary>
        /// Method to set Interest Rate for an Saving Account
        /// </summary>
        /// <param name="rate"> Float type Rate percentage value</param>
        /// <returns>Returns Boolean Type Success?</returns>
        public bool setInterestRate(float rate)
        {
           interest = rate;
            return true;
        }


        /// <summary>
        /// Method to Retrieve Interest Rate for an Saving Account
        /// </summary>
        /// <returns>Float type Interest Rate</returns>
        public float getInterestRate()
        {
            return interest;
        }


    
    
    
    
    }



    /// <summary>
    /// Main Class to Operate the Banking operations
    /// </summary>
    class BankOperations
    {
        static void Main(string[] args)
        {

            //List to hold the Accounts 
            List<BankAccount> list = new List<BankAccount>();

            //A New Saving Bank Account with Name "Rookey"

            SavingBankAccount ac1 = new SavingBankAccount("Rookey", 500);

            //A new Current Account with Name "Noobie"

            CurrentBankAccount ac2 = new CurrentBankAccount("Noobie", 10_000,  20_00_000);

            list.Add(ac1);
            list.Add(ac2);
            //ac1.getBalance()
            //Test for Account Number Generation
            Console.WriteLine("Information for Account 1\n");
            Console.WriteLine("Account Number : "+ac1.account_number);
            Console.WriteLine("Account Holder Name : " + ac1.account_holder_name);
            //Console.WriteLine("Account Type : " typeof(ac1));
            Console.WriteLine(ac2.account_number);
            ac1.getBalance();


            //TO Stop Console Outputs
            Console.ReadKey();


        }
    }
}
