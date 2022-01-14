using System;
namespace SampleConApp_Day3
{
    enum ClinicalTest { Blood = 5 , Urine, Tissue }    
    class EnumsDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select the type of sample given");
            var possibleTests = Enum.GetValues(typeof(ClinicalTest));
            foreach (var item in possibleTests)
            {
                Console.WriteLine(item);
            }
            ClinicalTest testType = (ClinicalTest)Enum.Parse(typeof(ClinicalTest), Console.ReadLine(), true);//Use  true if U want to ignore the case.
            Console.WriteLine("The selected Test is " + testType);
            Console.WriteLine("The integral value associated is " + (int)testType);
        }
    }
}
