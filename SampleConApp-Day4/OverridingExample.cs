using System;

namespace SampleConApp_Day4
{
    class FatherClass
    {
        public void DisplayBoard() //non-virtual method...
        {
            Console.WriteLine("Shopping City, Bangalore".ToUpper());
        }
        public virtual void MakePayment(string mode, int amount)
        {
            if((mode == "Cash") || (mode == "Cheque"))
                Console.WriteLine($"The Amount of {amount:C} has been made in the form of {mode}");
            else
                Console.WriteLine("This mode of payment is not accepted");
        }
    }
    class SonClass : FatherClass
    {
        public new void DisplayBoard()//Consider this as new function and all the rules of Substitution will be applicable
        {
            Console.WriteLine("Shopper's City, Bangalore".ToUpper());
        }

        public override void MakePayment(string mode, int amount)
        {
            // base.MakePayment(mode, amount);//calling the base version. base refers to the immediate base class. 
            if ((mode == "Cash") || (mode == "Card"))
                Console.WriteLine($"The Amount of {amount:C} has been made in the form of {mode}");
            else
                Console.WriteLine("This mode of payment is not accepted");
        }
    }
    /// <summary>
    /// This class job is to create an instance of any derived class based on the user requirement.
    /// </summary>
    class BusinessFactory
    {
        public static FatherClass GetBusinessComponent(string name)
        {
            if (name.ToUpper() == "FATHER")
                return new FatherClass();
            else
                return new SonClass();
        }
    }
    internal class OverridingExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Type of the class U want: Father or Son");
            string input = Console.ReadLine();
            FatherClass business = BusinessFactory.GetBusinessComponent(input);//User is not supposed to create the object(Abstraction). Factory is a seperate class that gives the required object based on the user requirement.  
            if(business is SonClass)
            {
                var temp = business as SonClass; //explicit downcasting. 
                temp.DisplayBoard();
            }else
                business.DisplayBoard();//This will not be polymorphic as no method overriding is done 
            business.MakePayment("Card", 65000);
            
        }
    }
}
