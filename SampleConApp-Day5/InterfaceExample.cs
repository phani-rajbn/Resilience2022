using System;


namespace SampleConApp_Day4
{
    interface IExample
    {
       //default public and only public. 
        void ExampleFunc();
    }

    interface ISimple
    {
        void SimpleFunc();
    }
    //This is an example to show that a class can implement few methods of the interface and make itself abstract. 
    abstract class ExampleClass : IExample, ISimple//UR class can implement multiple interfaces at the same level. 
    {
        public void ExampleFunc()
        {
            Console.WriteLine("Example Func");
        }

        public abstract void SimpleFunc();

    }

    class ExampleImpl : ExampleClass
    {
        public override void SimpleFunc()
        {
            Console.WriteLine("Simple Func");
        }
    }
    internal class InterfaceExample
    {
        static void Main(string[] args)
        {
            IExample example = new ExampleImpl();
            example.ExampleFunc();

            ISimple sim = new ExampleImpl();
            sim.SimpleFunc();
        }
    }
}
