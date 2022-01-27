using System;
using System.Linq;
namespace SampleConApp_Day11
{
    static class MyExtensions
    {
        //Method is extended to the instance of the class, not to the class definition itself.  Extension methods are not overriden methods, They are static and cannot be overriden. They dont follow the features of Runtime Polymorphism. It is used to add custom methods to an existing class without breaking it. If the class is extendable, it is recommended to go for inheritance, else go for extension methods. 
        public static int GetNoOfWords(this string sentence)//This function is added to the instance of the string object. 
        {
            var words = sentence.Split(' ');
            return words.Length;
        }
    }
    internal class NewFeatures
    {
        static void Main(string[] args)
        {
            //anonymousExample();
            //extensionExample();
            linqExample();
        }

        private static void linqExample()
        {
            //Language integrated queries(LINQ) is a new syntax for C# and VB.NET to allow programmers to perform queries on language based collection objects. 
            var data = new string[] { "Apples", "Mangoes", "Oranges", "PineApples", "Bananas" };
            var query = from varName in data
                        where varName.Contains("es")
                        select varName; //SELECT * FROM DATA WHERE name LIKE  *'es'*
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            //As LINQ can be performed on Collections, it would be helpfull to extract parts of data from a large datasource like database. U can get all the data from the database and perform queries on the collection instead of hitting the database all the time.  
        }

        private static void extensionExample()
        {
            string data = "Some data that was quite big and a long sentense with lots of words in it. However the string class did not have a method or a property that gets the no of words within the string";
            Console.WriteLine("The no of words: " + data.GetNoOfWords());
        }

        private static void anonymousExample()
        {
            //Anonymous Types.
            var obj = new { Name = "Data1", Address = "Address1", Phone = 234324324 };//Here U have created an object of an undefined type. This object will be stored as var and U can access the members without unboxing. 
            Console.WriteLine(obj.Name);
            Console.WriteLine(obj.Address);
            Console.WriteLine(obj);
        }
    }
}
