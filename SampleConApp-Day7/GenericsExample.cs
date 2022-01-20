using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleConApp_Day7
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }
        public override string ToString()
        {
            return EmpName;
        }

        public override bool Equals(object obj)
        {
            if (obj is Employee)
            {
                Employee other = obj as Employee;
                return other.EmpName == EmpName && other.EmpAddress ==  EmpAddress && other.EmpId == EmpId && other.EmpSalary == EmpSalary;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return EmpId.GetHashCode();
        }
    }
    internal class GenericsExample
    {
        static Dictionary<string, string> users = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            //listExample();
            //hashSetExample();
            //dictionaryExample();
            //queueExample();
            stackExample();
        }

        private static void stackExample()
        {
            Stack<string> bookRack =  new Stack<string>();
            bookRack.Push("MyFirstBook");//Adds the itemm to the top of the Collection. 
            bookRack.Push("MysecondBook");
            bookRack.Push("MythirdBook");
            bookRack.Push("MyFourthBook");
            bookRack.Push("MyFifthBook");
            //Read all the books in the shelf
            foreach (string title in bookRack) Console.WriteLine(title);  
            string book = bookRack.Pop();//Removes the last Item U added to the stack. U cannot remove any item other than the top...
            Console.WriteLine("The book that U have romoved from the shelf is " + book);
            foreach (string title in bookRack) Console.WriteLine(title);  

        }

        private static void queueExample()
        {
            ViewItemsInFlipKart();
            
        }

        private static void ViewItemsInFlipKart()
        {
            Queue<string> recentList = new Queue<string>();
            do
            {
                string product = Input.GetAnswer("Enter the Item U want to view...");
                if (recentList.Count == 5)
                    recentList.Dequeue();//Removes the first item in the list...
                recentList.Enqueue(product);//adds the item to the bottom...
                Console.WriteLine("The list of the recently viewed Items: ");
                {
                    //Display the data in the recent list...
                    var templist = recentList.Reverse();//From LINQ...
                    foreach (var item in templist)
                    {
                        Console.WriteLine(item);
                    }
                }
            } while (true);
        }

        //Dictionary is a data structure that store the data in the form of pairs. It is called key-value pair. Here key is unique to the collection(Id) and value may or may not be unique within the collection. Key's uniqueness is set by the hash value of the key. As far as performance is concerned, Dictionary is most performance oriented compared to any other data structure, but will consume more memory. 
        private static void dictionaryExample()
        {
            do
            {
                SignInOrSignUp();
            } while (true);
        }

        private static void SignInOrSignUp()
        {
            string input = Input.GetAnswer("Press L for login and S for Sign Up");
            if(input.ToLower() == "l")
            {
                string username = Input.GetAnswer("Enter UR Username");
                string password = Input.GetAnswer("Enter UR Password");
                if ((users.ContainsKey(username)) && (users[username] == password))
                {
                    Console.WriteLine("Welcome to the User!!!");                }
                else
                {
                    Console.WriteLine("Invalid UserName or Password!!!");
                }
            }
            else
            {
                RETRY:
                string username = Input.GetAnswer("Enter the Username");
                string password = Input.GetAnswer("Enter the Password");
                if (users.ContainsKey(username))
                {
                    Console.WriteLine("User Already exists, Please retype again");
                    goto RETRY;
                }
                else
                {
                    //users.Add(username, password);
                    users[username] = password;
                }
            }
        }

        private static void listExample()
        {
            simpleListExample();
            listWithEmployees();
        }

        //HashSet<T> works very similar to List but will store only unique values in it. Hashset<T> implements an interface called ISet<T> which ensures that values are unique. The uniqueness of the object is determined by the hashvalue(unique value generated by the clr when an object is created).
        //It first checks if the hash-code of 2 objects are same, if same they are said to be equal. Then it checks the Equals method for its object equivalence, if they are equal, then hashset will not add the new item. 
        //If the hashcode itself is different, then it will simply add the item into the collection without a need to check the equals method. 
        private static void hashSetExample()
        {
            simpleHashSetExample();
            objectHashCodeDemo();
        }

        private static void objectHashCodeDemo()
        {
            HashSet<Employee> empSet = new HashSet<Employee>();
            empSet.Add(new Employee { EmpAddress = "Bangalore", EmpId = 123, EmpName = "Phaniraj" });
            empSet.Add(new Employee { EmpAddress = "Mysore", EmpId = 124, EmpName = "Soumya" });
            empSet.Add(new Employee { EmpAddress = "Dharwad", EmpId = 125, EmpName = "Rajesh" });
            empSet.Add(new Employee { EmpAddress = "Tumkur", EmpId = 126, EmpName = "Ananth" });
            if (!empSet.Add(new Employee { EmpAddress = "Dharwad", EmpId = 125, EmpName = "Rajesh" })) Console.WriteLine("The employee is already available");
            empSet.Add(new Employee { EmpAddress = "Tumkur", EmpId = 126, EmpName = "Ananth" });
            Console.WriteLine("The Count: " + empSet.Count);
            foreach (Employee emp in empSet)
            {
                Console.WriteLine(emp);
            }
        }

        private static void simpleHashSetExample()
        {
            HashSet<string> basket = new HashSet<string>();
            basket.Add("Apples");
            basket.Add("Mangoes");
            basket.Add("Oranges");
            basket.Add("Bananas");
            if (!basket.Add("Apples")) Console.WriteLine("Apples already exists"); ;//Will not be added. 
            Console.WriteLine("The no of Fruits in the basket is " + basket.Count);
            //Go thru other APIs provided by Hashset. 
            foreach (string fruit in basket) Console.WriteLine(fruit);
        }

        private static void listWithEmployees()
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee { EmpAddress = "Bangalore", EmpId = 123, EmpName = "Phaniraj" });
            list.Add(new Employee { EmpAddress = "Mysore", EmpId = 124, EmpName = "Soumya" });
            list.Add(new Employee { EmpAddress = "Dharwad", EmpId = 125, EmpName = "Rajesh" });
            list.Add(new Employee { EmpAddress = "Tumkur", EmpId = 126, EmpName = "Ananth" });
            //foreach (Employee employee in list)
            //{
            //    Console.WriteLine(employee);
            //}
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].EmpName);
            }
            
        }

        //List<T> is a generic class that works like array where the data is store as U fill in. In List<T>, T represents the type of List U wish to create. Once U define the T, the object will store the data of that type only. Hense Generic Collections are called as Type Safe collections.
        //List does not check for duplicates. If U want to store unique values in the collection, then U should go for HashSet<T>. 
        private static void simpleListExample()
        {
            List<string> fruits = new List<string>();
            fruits.Add("Apples");//Adds the Item to the bottom of the List. 
            fruits.Add("Mangoes");
            fruits.Insert(0, "Bananas");//Used to insert in a specific index. 
            fruits.Add("Kiwis");
            foreach (string fruit in fruits) Console.WriteLine(fruit);
            fruits.Remove("Apples");//Removes the specified item based on value
            fruits.RemoveAt(1);//Removes the specified item based on index.
            foreach (string fruit in fruits) Console.WriteLine(fruit);
            for (int i = 0; i < fruits.Count; i++)//No of elements in the List
            {
                Console.WriteLine(fruits[i]);
            }
        }
    }
}

//Create a program that calls a function that passes data into a Hashset and should determine if the value is added or not. if the value is not addable, U should ask the user to retry with new data and pass it. 
