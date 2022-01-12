using System;
/// <summary>
/// This example will demo on creating a simple arithematic calculator. 
/// How to use statements and expressions.
/// Std Arithematic operators. 
/// </summary>
namespace SampleConApp_Day1
{
    internal class CalcDemo
    {
        static double getValue(string question)
        {
            Console.WriteLine(question);
            return double.Parse(Console.ReadLine());
        }
        static char getChar(string question)
        {
            Console.WriteLine(question);
            return char.Parse(Console.ReadLine());
        }

        static double calculate(double fValue, double sValue, char operation)
        {
            double res = 0;
            switch (operation)
            {
                case '+':
                    res = fValue + sValue;
                    break;
                case '-':
                    res = fValue - sValue;
                    break;
                case '*':
                    res = fValue * sValue;
                    break;
                case '/':
                    res = fValue / sValue;
                    break;
                default:
                    break;
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("--------------MATH CALC PROGRAM-----------------");
            double fValue = getValue("ENTER THE FIRST VALUE:");
            double sValue = getValue("ENTER THE SECOND VALUE:");
            char cValue = getChar("ENTER THE CHOICE OF OPERATOR AS: + , -, * OR /");
            Console.WriteLine( $"The result of this operation is {calculate(fValue, sValue, cValue)} ");
        }
    }
}
