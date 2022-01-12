using System;
/// <summary>
/// This example shows how to take inputs from the Console and use it in the Program.
/// This is an IO Program on Console.
/// How to add a new File into the current project.
/// How to take inputs from the user thru code
/// How to set the Main program if U have multiple Mains in your project.
/// </summary>
namespace SampleConApp_Day1
{
    class InputOutputExample
    {
        static void Main()
        {
            Console.WriteLine("Enter the name:");
            var name = Console.ReadLine();//ReadLine is a function of Console class that reads the input made on the Console and returns a string value of the input.

            Console.WriteLine("Enter the Age");
            var age = Console.ReadLine();
            Console.WriteLine("The Name entered is " + name );
            Console.WriteLine("The Age is " + age);
        }
    }
}
/*Tip: Setting the startup object does not mean that U can ignore the errors in other files of the project.*/
