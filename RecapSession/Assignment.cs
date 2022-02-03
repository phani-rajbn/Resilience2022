using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapSession
{
  
    internal class Assignment
    {
        static void fillData(List<string> list, ref List<string>nonIntegers, ref List<int> integers)
        {
            foreach (var element in list)
            {
                int no = 0;
                if (int.TryParse(element, out no))
                    integers.Add(no);
                else
                    nonIntegers.Add(element);
            }
        }
        static List<string> createList()
        {
            bool checkValue = true;
            List<string> list = new List<string>();
            do
            {
                Console.WriteLine("Enter a value");
                list.Add(Console.ReadLine());
                Console.WriteLine("Press YES to continue or NO to exit the loop");
                string answer = Console.ReadLine();
                checkValue = answer.ToUpper() == "YES";
            } while (checkValue);
            return list;
        }
        static void loopingExample()
        {
            var list = createList();//Take inputs till the person enters NO....
            Console.WriteLine("The No of Inputs:" + list.Count);
            List<int> integers = new List<int>();
            List<string> nonIntegers = new List<string>();
            fillData(list, ref nonIntegers, ref integers);
            Console.WriteLine("The no of Integer count: " + integers.Count);
            Console.WriteLine("The Sum of integers : " + integers.Sum());
            displayIntegers(integers);
            Console.WriteLine("The no of Non-Integer count: " + nonIntegers.Count);
            displayNonIntegers(nonIntegers);
        }

        private static void displayNonIntegers(List<string> nonIntegers)
        {
            string output = "The Non-Number inputs: ";
            foreach (var item in nonIntegers)
            {
                output += item.ToUpper() + ",";
            }
            Console.WriteLine(output.TrimEnd(','));
        }
        private static void displayIntegers(List<int> integers)
        {
            string output = "The Number inputs: ";
            foreach (var item in integers)
            {
                output += item + ",";
            }
            Console.WriteLine(output.TrimEnd(','));
        }

        static void Main(string[] args)
        {
            loopingExample();
        }
    }
}
