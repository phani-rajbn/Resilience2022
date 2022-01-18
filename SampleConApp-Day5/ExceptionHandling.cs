using System;


namespace SampleConApp_Day4
{
    internal class ExceptionHandling
    {
        static void Main(string[] args)
        {
            DOAGAIN:
            Console.WriteLine("Enter a number");
            int no = 0;
            try
            {
                no = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Input should be a number only");
                
                goto DOAGAIN;
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The range of the number should be b/w {int.MinValue} and {int.MaxValue}");
                goto DOAGAIN;
            }
            finally
            {
                Console.WriteLine("This block of the code is to clean up and will run all the time");
            }
            Console.WriteLine("The No entered is " + no);
        }
    }
}
