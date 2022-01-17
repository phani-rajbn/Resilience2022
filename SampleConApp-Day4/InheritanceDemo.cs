using System;


namespace SampleConApp_Day4
{
    //Assumption: The Parent class is created and U  dont have the source code of it, but U have a DLL or a Reference of it. 
    class ParentClass
    {
        public void TestFunc() => Console.WriteLine("Test Func from the base");
    }

    //Syntax of Inheritance. While inheriting, there is no access specifier for the inheritance
    class DerivedClass :  ParentClass
    {
        public void DerivedFunc() => Console.WriteLine("Derived Func from the Derived");
    }

    internal class InheritanceDemo
    {
        static void Main(string[] args)
        {
            ParentClass cls = new ParentClass();
            cls.TestFunc();

            if (cls is DerivedClass)
            {
                var obj = cls as DerivedClass;
                obj.DerivedFunc();//obj is an alias to the cls where no new object is created but a reference of it is made
            }
            else
            {
                Console.WriteLine("Cls is not an object of the type Derived class");
            }
            //DerivedClass cls2 = new DerivedClass();
            //cls2.TestFunc();
            //cls2.DerivedFunc();
            Console.WriteLine("Now creating the object as Derived type");
            cls = new DerivedClass();//A base type could be substituted  to its derived type.
            cls.TestFunc();
            //New methods of the derived class will not be accessible to the base class object. 
            ((DerivedClass)cls).DerivedFunc();//This is called as Downcasting, where the base type is casted to its derived type and then used. 
            //If U want to do downcasting, it is recommended to use is and as operators. is operator is used to check for the instance type and as operator type casted to the type
            if(cls is DerivedClass)
            {
                var obj = cls as DerivedClass;
                obj.DerivedFunc();//obj is an alias to the cls where no new object is created but a reference of it is made
            }else
            {
                Console.WriteLine("Cls is not an object of the type Derived class");
            }
        }
    }
}
