
//Simple Drug Registration Software:
//Drug: ID, Name, Composition, Price., DateOfManufacture. ExpiryDate(Read Only)
//Register new Drugs, update Drugs and delete Drugs, GetInfo about drugs. 
//Menu Driven Program. 
using SampleConApp_Day6.Entities;
using System;
using System.IO;//For file reading....
using System.Collections.Generic;
namespace SampleConApp_Day6
{
    namespace Entities
    {
        class Drug
        {
            public override string ToString()
            {
                return $"{DrugNo},{Name},{Composition},{Price},{DateOfManufacture}\n";
            }
            public int DrugNo { get; set; }
            public string Name { get; set; }
            public string Composition { get; set; }
            public double Price { get; set; }
            public DateTime DateOfManufacture{ get; set; }
            public DateTime ExpiryDate { get; private set; }
            public Drug()
            {
                ExpiryDate = DateOfManufacture.AddMonths(6);
            }

            public void Copy(Drug drg)
            {
                DrugNo = drg.DrugNo;
                Name = drg.Name;
                Composition = drg.Composition;
                Price = drg.Price;
                DateOfManufacture = drg.DateOfManufacture;
                ExpiryDate = drg.ExpiryDate;
            }
        }
    }

    namespace DataLayer
    {
        using Entities;
        //interface is like a plan, implementation can be done later. 
        interface IDrugManager
        {
            void RegisterNewDrug(Drug drug);
            void UpdateDrug(Drug drug);
            Drug[] FindDrug(string name);
            Drug FindDrug(int drugNo);
            void DeleteDrug(int id);
        }

        class DrugManager : IDrugManager
        {
            private Drug[] _drugs = new Drug[100];//Limitation of the Array, its fixed in size...
            public DrugManager()
            {
                RegisterNewDrug(new Drug { DrugNo =1, Composition ="SimpleComposition", DateOfManufacture = DateTime.Now.AddDays(15), Name ="SampleDrug1", Price = 600 });
                RegisterNewDrug(new Drug { DrugNo = 2, Composition = "ExampleComposition", DateOfManufacture = DateTime.Now.AddDays(45), Name = "SampleDrug2", Price = 60 });
                RegisterNewDrug(new Drug { DrugNo = 3, Composition = "SampleExampleComposition", DateOfManufacture = DateTime.Now.AddDays(41), Name = "SampleDrug3", Price = 50 });
                RegisterNewDrug(new Drug { DrugNo = 4, Composition = "ExampleSimpleComposition", DateOfManufacture = DateTime.Now.AddDays(12), Name = "SampleDrug4", Price = 780 });
                RegisterNewDrug(new Drug { DrugNo = 5, Composition = "VerySampleComposition", DateOfManufacture = DateTime.Now.AddDays(70), Name = "SampleDrug5", Price = 80 });
            }
            public void DeleteDrug(int id)
            {
                throw new NotImplementedException();
            }

            public Drug[] FindDrug(string name)
            {
                Drug[] drugs = new Drug[100];
                int index = 0;
                foreach (Drug drug in _drugs)
                {
                    if ((drug != null )&& (drug.Name.Contains(name)))
                    {
                        drugs[index] = new Drug();
                        drugs[index].Copy(drug);
                        index++;
                    }
                    else continue;
                }
                return drugs;
            }
            /// <summary>
            /// Finds a single Drug based on the Id. 
            /// </summary>
            /// <param name="drugNo">ID of the Drug to find</param>
            /// <returns>First Occurance of the Drug with matching ID</returns>
            /// <exception cref="Exception">No Drug was found</exception>
            public Drug FindDrug(int drugNo)
            {
                foreach (Drug item in _drugs)//iterate the collection
                {
                    if(item != null && item.DrugNo == drugNo)
                    {
                        return item;
                    }
                }
                throw new Exception($"No Drug by ID {drugNo} is found in our database");
            }


            public void RegisterNewDrug(Drug drug)
            {
                for(int i =0; i < 100; i++)//iterating thru the elements
                {
                    if(_drugs[i] == null)//find the first occurance of null object.
                    {
                        _drugs[i] = new Drug();//create the instance
                        _drugs[i].Copy(drug);//copy the values into the specific element
                        return;//Exit the function after the copy is done;
                    }
                }
                throw new Exception("No more drugs to be registered by the System!!!");
            }

            public void UpdateDrug(Drug drug)
            {
                for (int i = 0; i < 100; i++)//iterate thru the elements
                {
                    //find the matching drug based on id
                    if ((_drugs[i] != null) && (_drugs[i].DrugNo == drug.DrugNo))
                    {
                        _drugs[i].Copy(drug);//set the new values
                        return;//exit the function
                    }
                }
                throw new Exception($"No drug found by this ID {drug.DrugNo} to update");
            }
        }
    }

    /// <summary>
    /// User interface of the Application
    /// </summary>
    internal class e2eApp
    {
        private static DataLayer.IDrugManager mgr = new DataLayer.DrugManager();//instantiating the object.
        static void Main(string[] args)
        {
            string menu = File.ReadAllText(args[0]);//API of the .NET to get all the text content of a file...
            bool processing = true;
            do
            {
                processing = processMenu(menu);
            } while (processing);
        }

        private static bool processMenu(string menu)
        {
            string choice = Input.GetAnswer(menu);
            switch (choice.ToUpper())
            {
                case "N":
                    addDrugHelper();
                    return true;
                case "U":
                    updateDrugHelper();
                    return true;
                case "F":
                    string name = Input.GetAnswer("Enter the name of the drug to find");
                    var records = mgr.FindDrug(name);
                    displayRecords(records);
                    return true;
                case "I":
                    int id = Input.GetNumber("Enter the Id of the drug to find");
                    var record = mgr.FindDrug(id);
                    displayRecords(record);
                    return true;
                case "D":
                    return true;
                default:
                    return false;
            }
        }

        private static void displayRecords(object records)//records could be array or single record.
        {
            if((records != null) && (records.GetType() == typeof(Drug[])))
            {
                Drug[] unBoxed = (Drug[])records;
                foreach (Drug drg in unBoxed)
                {
                    if (drg != null)
                    {
                        Console.WriteLine(drg.Name);
                    }
                }
            }
            else
            {
                if(records is Drug)
                {
                    Drug drg = records as Drug;
                    Console.WriteLine(drg.Name);
                }
            }
        }

        /// <summary>
        /// Helper function that takes inputs and updates the data into the system
        /// </summary>
        private static void updateDrugHelper()
        {
            Drug drug = createDrug();
            try
            {
                mgr.UpdateDrug(drug);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Helper to create Drug object.
        /// </summary>
        /// <returns></returns>
        private static Drug createDrug()
        {
            int id = Input.GetNumber("Enter the ID for the Drug");
            string name = Input.GetAnswer("Enter the name for the drug");
            string composition = Input.GetAnswer("Enter the Composition seperated by -");
            double price = Input.GetDouble("Enter the cost for 10 Units");
            DateTime doM = Input.GetDate("Enter the Manufacturing date");
            Drug drg = new Drug { Composition = composition, DateOfManufacture = doM, DrugNo = id, Name = name, Price = price };
            return drg;
        }
        private static void addDrugHelper()
        {
            Drug drg = createDrug();
            try
            {
                mgr.RegisterNewDrug(drg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
