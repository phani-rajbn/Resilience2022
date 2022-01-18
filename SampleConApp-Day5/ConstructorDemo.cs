using System;

namespace SampleConApp_Day4
{
    class BaseClass
    {
        protected string baseValue;
        public BaseClass()
        {
            baseValue = "Some Default value for the base";
        }
        public BaseClass(string baseValue)
        {
            Console.WriteLine($"Base class Constructor with base value: {baseValue}");
        }
    }
    class SimpleClass : BaseClass
    {
        private string value;
        private static int objCount;
        //static constructors.
        static SimpleClass()//no access specifier, no args, no explicit call be made. Created to initialize static variables.
        {
            objCount = 1;
            Console.WriteLine("Called once and only once");
        }

        public SimpleClass() : base("someValue") //Default constructor
        {
            value = "Default Value";
            objCount++;
            Console.WriteLine($"Object no {objCount}is created");

        }

        public SimpleClass(string arg) : base(arg)//Parameterized Constructor. 
        {
            value = arg;
        }
        public void Display() => Console.WriteLine(value);
    }
    internal class ConstructorDemo
    {
        //Called even before UR Main is called as Static constructors are called. 
        static ConstructorDemo()
        {
            Console.WriteLine("Code to execute even before UR Main starts!!!");
        }
        static void Main(string[] args)
        {
            SimpleClass cls = new SimpleClass();
            cls.Display();//Displays default value
            cls = new SimpleClass("Specific Value");
            cls.Display();//Display specific value

            for (int i = 0; i < 100; i++)
            {
                SimpleClass instance = new SimpleClass();
            }
        }
    }
}
