using System;
using System.Threading;

namespace SampleConApp_Day16
{
    internal class ThreadExample
    {
        static int resource = 0;
        static void ArgbasedTest(object parameter)
        {
            Monitor.Enter(typeof(ThreadExample));
 //           lock (typeof(ThreadExample))
            //{
                int no = Convert.ToInt32(parameter);
                Console.WriteLine("Parameterised Thread");
                for (int i = 1; i <= no; i++)
                {
                    resource++;
                    Console.WriteLine($"Parameterised Thread Beep# {i} with resource value {resource}");
                    Thread.Sleep(1000);//Delay of 1 sec for every iteration
                }
   //         }
            Monitor.Exit(typeof(ThreadExample));    
        }
        static void TestFunc()
        {
            lock (typeof(ThreadExample))
            {
                for (int i = 1; i <= 10; i++)
                {
                        resource++;
                    Console.WriteLine($"Thread Beep# {i} with resource value {resource}");
                    Thread.Sleep(1000);//Delay of 1 sec for every iteration
                }
            }
        }
        static void Main(string[] args)
        {
            //TestFunc();
            //Thread th = new Thread(new ThreadStart(TestFunc));
            //Thread th = new Thread(TestFunc);
            Thread th = new Thread(new ParameterizedThreadStart(ArgbasedTest));//Only object could be passed as arg.
            Thread th2 = new Thread(TestFunc);//Only object could be passed as arg.
            //th.IsBackground = true;
            th.Start(15);
            th2.Start();
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Main Beep# {i}");
                Thread.Sleep(1000);//Delay of 1 sec for every iteration
            }
        }
    }
}
