using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp_Day16
{
    delegate void RefFunc();

    delegate double MathFunc(double firstVal, double secondVal);

    delegate void OnClick();


    internal class Program
    {
        static void OnButtonClick(OnClick func)
        {
            func();
        }

        static void someFunc() => Console.WriteLine("Some operation");

        //
        static void invokeMathFunc(MathFunc func)
        {
            //invoke that function
            Console.WriteLine("Enter 1st value");
            double v1 = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter 2nd value");
            double v2 = double.Parse(Console.ReadLine());

            var res = func(v1, v2);
            Console.WriteLine("The result is " + res);
        }
        
        static void Main(string[] args)
        {
            RefFunc instance = new RefFunc(someFunc);
            instance();//call the method thru this instance. instance becomes an alias for the actual method. 

            invokeMathFunc((v1, v2) => v1 * v2 - v1 + 123 / 12);

            OnButtonClick(() => Console.WriteLine("This is on Click"));

        }
    }
}
