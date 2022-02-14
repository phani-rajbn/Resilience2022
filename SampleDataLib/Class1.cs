using System;

//Whenn
namespace SampleDataLib
{
    public static class Input
    {
        public static int GetNumber(string question)
        {
            int result = 0;
            do
            {
                Console.WriteLine(question);                
            } while (!int.TryParse(Console.ReadLine(), out result));
            return result;
        }

        public static string GetAnswer(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static double GetDouble(string question)
        {
            double result = 0;
            do
            {
                Console.WriteLine(question);
            } while (!double.TryParse(Console.ReadLine(), out result));
            return result;
        }
        public static DateTime GetDate(string question)
        {
            DateTime dt;
            do
            {
                Console.WriteLine(question);
                Console.WriteLine("Date should follow the format as dd/MM/yyyy");

            } while (!DateTime.TryParse(Console.ReadLine(), out dt));
            return dt;
        }

    }
}
