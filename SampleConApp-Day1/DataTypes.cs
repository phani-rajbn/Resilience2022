using System;
/// <summary>
/// This Example will show on using data types of .NET/C#. 
/// How to convert a string to a specific primitive data type using Parse Method.
/// Conversion of data into different types using casting operators.
/// Explicit casting vs. Implicit Casting.
/// </summary>  
namespace SampleConApp_Day1
{
    internal class DataTypes
    {
        static void simpleCalc()
        {
            //int x = 0, y = 0;
            double x = 0, y = 0;
            Console.WriteLine("Enter the valid number value for x");
            x = double.Parse(Console.ReadLine());//Parse method is used to convert string to its type. 
            Console.WriteLine("Enter the valid number value for y");
            y = double.Parse(Console.ReadLine());
            Console.WriteLine("The added value " + (x + y));
            //Parse method can raise an Exception(Runtime Error) if the string is not a valid type.
        }
    
        static void Main(string[] args)
        {
            //simpleCalc();
            int x = 123;
            long y = x;//int value is converted to a long value(Implicit). 
            x = (int)y;//U need to tell the compiler to convert a larger value to a smaller value, which is called as CASTING. Here long is type casted to int. This is called Explicit 
            Console.WriteLine("The range of integer is between " + int.MinValue + " and " + int.MaxValue);
            Console.WriteLine($"The range of long is between {long.MinValue} and {long.MaxValue}");//New syntax for string manipulation. Use this format for placing strings with variable data. 
            Console.WriteLine("The range of short is between {0} and {1}" , short.MinValue, short.MaxValue);
                                                                                                   
        }
    }
}
