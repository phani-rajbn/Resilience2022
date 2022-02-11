using System;
using System.Data.SqlClient;
using System.IO;

namespace SampleConApp_Day16
{
    class SimpleClass : IDisposable
    {
        int no = 0;
        public SimpleClass(int no)
        {
            this.no = no;
            Console.WriteLine($"Constructor for object {no}" );
        }

        ~SimpleClass()
        {
            Console.WriteLine($"Destructor for object {no}");
        }

        public void Dispose()
        {
            Console.WriteLine("Write the implementation of Unmanaged code destruction");
        }
    }
    internal class GarbageCollection
    {
        static void createAndDestroyObjects()
        {
            for (int i = 0; i < 10; i++)
            {
                using (SimpleClass cls = new SimpleClass(i)) //Once the scope goes, the Dispose method will be called implicitly.
                {
                    GC.Collect();//It starts freeing in a new thread(Background thread)
                    GC.WaitForPendingFinalizers();//Main thread will wait till the objects are finalized.
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("App has started");
            createAndDestroyObjects();
            Console.WriteLine("App has ended");
        }
    }
}
