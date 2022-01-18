using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp_Day4
{
    //If any method of a class is marked as abstract, then the class must also be an abstract class. 
    //If a class is marked as abstract, then, the class cannot be instantiated. As one or more methods of the class is not implemented, it is an incomplete class, so the class is not usable until all the methods are implemented. 
    //The methods will be implemented in the derived classes. The derived class must implement all the abstract methods of the base class, else even this class must be marked as abstract.  
    //abstract methods are implemented using override keyword. Abstract classes follow single inheritance pattern. U cannot derive from 2 abstract classes at the same level.  
    abstract class Account
    {
        public int AccountNo { get; set; }
        public string HolderName { get; set; }
        public double Balance { get; private set; }//This property value cannot be set outside the class.
        public void Credit(double amount) => Balance += amount;
        public void Debit(double amount)
        {
            if (amount > Balance)
                throw new Exception("Insufficient funds");//Raise an error.
            Balance -= amount;
        }
        public abstract void CalculateInterest();//This method is must for all kinds of accounts but the base class does not have a concrete business rule for implementing it. 
    }

    class SBAccount : Account
    {
        public override void CalculateInterest()
        {
            double pricipal = this.Balance;
            double rateOfInterest = 6.5 / 100;
            double time = 0.25;
            double interest = pricipal * rateOfInterest * time;
            Credit(interest);
        }
    }
    //A = P*(1+R/N)^(N*T)
    class FDAccount : Account
    {
        //Do the implementation....
        public override void CalculateInterest()
        {
            throw new NotImplementedException();
        }
    }
    class RDAccount : Account
    {
        //Formula for calculating the RD for 5 Years at rate of 5.5% with 5000*60
        public override void CalculateInterest()
        {
            throw new NotImplementedException();
        }
    }
    enum AccountType {  SB, RD, FD};

    class AccountFactory
    {
        public static Account CreateAccount(AccountType type)
        {
            Account acc = null;
            switch (type)
            {
                case AccountType.SB:
                    acc = new SBAccount(); 
                    break;
                case AccountType.RD:
                    acc = new RDAccount();
                    break;
                case AccountType.FD:
                    acc = new FDAccount();
                    break;
                default:
                    break;
            }
            return acc;
        }
    }
    internal class AbstractClassDemo
    {
        static void Main(string[] args)
        {
            Account account = AccountFactory.CreateAccount(AccountType.SB);
            account.Credit(10000);
            account.AccountNo = 111;
            account.HolderName = "Phaniraj";
            account.CalculateInterest();
            Console.WriteLine("The Current Balance is {0:C}", account.Balance);
        }
    }
}
