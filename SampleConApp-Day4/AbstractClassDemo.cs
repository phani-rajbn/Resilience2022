using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp_Day4
{
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

    class RDAccount : Account
    {
        //Formula for calculating the RD for 5 Years at rate of 5.5% with 5000*60
        public override void CalculateInterest()
        {
            throw new NotImplementedException();
        }
    }
    internal class AbstractClassDemo
    {
        static void Main(string[] args)
        {
            Account account = new SBAccount();
            account.Credit(10000);
            account.AccountNo = 111;
            account.HolderName = "Phaniraj";
            account.CalculateInterest();
            Console.WriteLine("The Current Balance is {0:C}", account.Balance);
        }
    }
}
