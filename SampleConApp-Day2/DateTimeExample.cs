using System;
namespace SampleConApp_Day2
{
    internal class DateTimeExample
    {
        static void Main(string[] args)
        {
            //DateTime is one of the most frequently used Data Structure. Used to work with date and Time of the application. 
            DateTime dt = new DateTime(); //Default date and Time(Jan 1 0001
            dt = new DateTime(2022, 01, 13);//create a new DateTime with specified values including date and time. 
            dt = DateTime.Now;//sets the object to the system date time. 
            Console.WriteLine(dt);
            Console.WriteLine($"The Longer version: {dt.ToLongDateString()}");
            Console.WriteLine($"The Longer version of time: {dt.ToLongTimeString()}");
            Console.WriteLine($"The Shorter version of Date: {dt.ToShortDateString()}");
            Console.WriteLine($"The Shorter version of Time: {dt.ToShortTimeString()}");
            Console.WriteLine($"The Custom format: {dt.ToString("dd-MMMM-yyyy hh:mm:ss tt")}");
            Console.WriteLine($"The year part is {dt.Year}, month's part is {dt.Month} and the Day's part is {dt.Day}");

            Console.WriteLine("Enter the Date of Birth as dd-MM-yyyy");
            dt = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);//ParseExact will try to convert the string to the valid date in the format specified. 
            Console.WriteLine($"The Date of birth is {dt.ToLongDateString()}");
            TimeSpan sp = DateTime.Now - dt;
            //Timespan is a structure that defines  the difference of 2 valid dates. 
            Console.WriteLine($"The Age is  { (int)sp.TotalDays / 365}");
        }
    }
}
