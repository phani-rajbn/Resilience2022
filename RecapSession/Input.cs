using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapSession
{
    /// <summary>
    /// Custom class created for taking inputs from the user by asking him/her the questions.
    /// </summary>
    internal class Input
    {
        public static int GetNumber(string question)
        {
            string answer = GetAnswer(question);
            return Convert.ToInt32(answer);
        }

        public static double GetDouble(string question)
        {
            string answer = GetAnswer(question);
            return Convert.ToDouble(answer);
        }

        public static string GetAnswer(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        /// <summary>
        /// Gets the valid Date from the user 
        /// </summary>
        /// <param name="question"></param>
        /// <returns>A Valid date converted from the given input</returns>
        public static DateTime GetDate(string question)
        {
            Console.WriteLine($"{question}\nThe format should be dd/MM/yyyy");
            return DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        }
    }
}
