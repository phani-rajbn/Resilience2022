using System;
/// <summary>
/// This example will show you on how to create arrays and consume it in the application
/// </summary>
namespace SampleConApp_Day2
{
    internal class ArraysExample
    {
        static void Main(string[] args)
        {
            //firstExample();
            //secondExample();
            //thirdExample();
            fourthExample();
        }

        private static void fourthExample()
        {
            //.NET provides a class called System.Array. All arrays created in C# are objects of this class.
            //With this class, U can get methods and properties to set/get information as well perform operations on the array.
            //U can create dynamically arrays using System.Array class. 
            Console.WriteLine("Enter the Size of the Array");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Data Type Of the Array as CTS Name");
            string typeInfo = Console.ReadLine();
            Type type = Type.GetType(typeInfo);
            Array array = Array.CreateInstance(type, size);
            if(array == null)
            {
                Console.WriteLine("Array could not be created");
                return;
            }
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter the value for the position {i} of the type {type.Name}");
                object value = Convert.ChangeType(Console.ReadLine(), type);
                //object is a universal data type of .NET that can store any kind of data(similar to void* of C++)
                array.SetValue(value, i);
            }
            foreach (object value in array)
                Console.WriteLine(value);
        }

        /// <summary>
        /// This example shows how to create and use Jagged Arrays in C#
        /// </summary>
        private static void thirdExample()
        {
            //Jagged array is used for creating array of arrays. An Array which contains other arrays in it. A school is an array of classrooms and each class has an array of students in it.
            //It allows to create an array of elements where each element will represent an independent array. 
            //Here U will have n number of rows and each row has different no of columns in it. 
            int[][] jaggedArray = new int[5][];//1st [] will tell the no of rows in the array. 
            jaggedArray[0] = new int[] { 45, 56, 77, 88 };
            jaggedArray[1] = new int[] { 23, 45, 67, 56, 77, 88 };
            jaggedArray[2] = new int[] { 45, 56, 77 };
            jaggedArray[3] = new int[] { 45, 56, 77, 88,76, 45, 23, 11 };
            jaggedArray[4] = new int[] { 45, 56, 77, 88, 77, 99, 00, 56 };

            ////////Display the data/////////////
            for (int i = 0; i < jaggedArray.Length; i++)//Length is a property in Array class to give the size of the array
            {
                foreach(int value in jaggedArray[i])
                    Console.Write(value + " ");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// This example shows how to create 2 Dimensional Array
        /// </summary>
        private static void secondExample()
        {
            int[,] Arr2D = new int[4, 3]//4 rows and 3 columnss
                        {
                            { 23,34,56 },
                            {54,34,12 },
                            {67, 50,12 },
                            {78, 43, 90 }
                        };
            //2 For loops to display the data in matrix format...
            for (int i = 0; i < Arr2D.GetLength(0); i++)//Gets the no of elements in the first dimension(4)
            {
                for (int j = 0; j < Arr2D.GetLength(1); j++)
                {
                    Console.Write(Arr2D[i, j] + " ");
                }
                Console.WriteLine();//To move to the next line after the row is completed. 
            }
        }

        /// <summary>
        /// Example on creating a simple array in C#
        /// </summary>
        private static void firstExample()
        {
            const int size = 6;//Define the size of the array, make it const if U dont intend to change. 
            //Array is a reference type in .NET
            int[] elements = new int[size];//6 is the size of the array. new operator is used to create an instance of the array. 
            //By default, all the elements in the array will be set to their default value based on the type of the data. 

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"enter the value for the position {i + 1}");
                elements[i] = int.Parse(Console.ReadLine());
            }

            foreach (var item in elements)//foreach is a way of traversing the array by reading each element at at time and incrementing it by 1.
            {
                Console.WriteLine(item);
            }
        }
    }
}

