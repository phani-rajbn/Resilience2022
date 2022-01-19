using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Object class
 * E2E Application
 */
namespace SampleConApp_Day6
{
    //All classes/structs/enums are types derived from System.Object, the super base class of .NET Framework. 
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public long CustomerPhone { get; set; }

        //U can override the ToString method to provide a Custom conversion to string. 
        public override string ToString()
        {
            string content = $"{CustomerName}-{CustomerPhone}-{CustomerID}";
            return content;
        }

        public override bool Equals(object obj)
        {
            if (obj is Customer)//is and as operator works only for reference types...
            {
                Customer other =obj as Customer; //UNBOXING....
                return other.CustomerID == this.CustomerID;
            } 
            else return false;
        }        
    }

    internal class ObjectClassDemo
    {
        static void Main(string[] args)
        {
            //object data = intBasedExample();
            //data = doubleBasedExample();
            //data = stringBasedExample();
            //classBasedExample();
            Customer customer = new Customer { CustomerID = 123, CustomerPhone =9945205684, CustomerName ="Phaniraj" };
            //Default Implementation of ToString to a class will be its classname            
            Console.WriteLine(customer);//Displays the Classname of the object if not overriden.
        //Console.WriteLine always evaluates a value to its string format and displays it. ToString method of the variable will be called internally and then the display happens 
        //As in this example, we have overriden the ToString method, it will display accordingly..

            Customer customer2 = new Customer { CustomerID = 123, CustomerPhone = 9945205684, CustomerName = "Phaniraj" };
            Console.WriteLine(customer.Equals(customer2));//Equals is used to evaluate the object equivalence with another passed as arg. Returns true if equal, else false
        }

        private static void classBasedExample()
        {
            //Example of boxing Customer object to the object type. 
            object obj = new Customer { CustomerID = 123, CustomerName = "Phaniraj", CustomerPhone = 9945205684 };//BOXING..
            //Customer dataCopy = (Customer)obj;//old style of casting...
            Customer dataCopy = obj as Customer;
            Console.WriteLine(dataCopy.CustomerName + " can be contacted on " + dataCopy.CustomerPhone);
        }

        private static object stringBasedExample()
        {
            object data;
            data = "Sample String";//Hold a string. 
            Console.WriteLine("The data type of date is " + data.GetType().Name);
            string strCopy = data.ToString();
            Console.WriteLine($"To display it in Upper case: {strCopy.ToUpper()}");
            return data;
        }

        private static object doubleBasedExample()
        {
            object data;
            data = 123.345;//Hold a double value
            Console.WriteLine("The data type of date is " + data.GetType().Name);
            //double copy = (double)data;//rightway
            //int copy = (int)data;//wrong way as double cannot be converted to int. 
            //int copy =(int)(double)data; ==>To much confusing...
            int copy = Convert.ToInt32(data);//Use Convert method instead of old C Style casting. 
            copy += 123;//Do the operation
            data = copy;//set it back to the data.
            return data;
        }

        private static object intBasedExample()
        {
            object data = 123;//data holds the data of the type int.
            Console.WriteLine("The data type of date is " + data.GetType().Name);
            return data;
        }
    }
}
