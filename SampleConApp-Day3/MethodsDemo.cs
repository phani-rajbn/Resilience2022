using System;

//In static methods, U cannot call the instance methods directly even if they belong to the same class. U must create an instance of the class and thru the instance, U should call the method. 
namespace SampleConApp_Day3
{
    internal class MethodsDemo
    {
        static void staticFunction() => Console.WriteLine("Static function Example");

        static void passByExample(ref int x)//paramters scope is only within the function. 
        {
            x = 123;
            Console.WriteLine($"The value inside this function is {x}");
        }
        //Function that returns more than one value at a time. 
        static void mathFunc(double v1, double v2, ref double res1, ref double res2, ref double res3)
        {
            res1 = v1 + v2;
            res2 = v1 - v2;
            res3 = v1 * v2;
        }

        static void mathOutFunc(double v1, double v2, out double res1, out double res2, out double res3)
        {
            res1 = v1 + v2;
            res2 = v1 - v2;
            res3 = v1 * v2;
        }


        void normalFunction() => Console.WriteLine("Some activity");
        
        static void Main()
        {
            //staticFunction();//Static methods dont need any instances
            //MethodsDemo demo = new MethodsDemo();
            //demo.normalFunction();

            int x = 345;
            passByExample(ref x);
            Console.WriteLine($"The value of x after it returns from the Function {x}");

            double res1 , res2 , res3 ;//For passing variables of ref, U must initialize them before sending to the func. 
            //mathFunc(123, 23, ref res1, ref res2, ref res3);
            mathOutFunc(123, 23, out res1, out res2, out res3);
            Console.WriteLine($"The Res1: {res1}, \tThe Res2: {res2}\t The Res3: {res3}");

        }
    }
}
