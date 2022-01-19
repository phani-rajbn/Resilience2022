
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
        class DrugFileManager : IDrugManager
        {
            public void DeleteDrug(int id)
            {
                throw new NotImplementedException();
            }

            public Drug[] FindDrug(string name)
            {
                throw new NotImplementedException();
            }

            public Drug FindDrug(int drugNo)
            {
                throw new NotImplementedException();
            }

            public void RegisterNewDrug(Drug drug)
            {
                File.AppendAllText("Temp.txt", drug.ToString());
            }

            public void UpdateDrug(Drug drug)
            {
                throw new NotImplementedException();
            }
        }
        class DrugListManager : IDrugManager
        {
            private List<Drug> _drugs = new List<Drug>();
            public void DeleteDrug(int id)
            {
                throw new NotImplementedException();
            }

            public Drug[] FindDrug(string name)
            {
                throw new NotImplementedException();
            }

            public Drug FindDrug(int drugNo)
            {
                throw new NotImplementedException();
            }

            public void RegisterNewDrug(Drug drug)
            {
                _drugs.Add(drug);
            }

            public void UpdateDrug(Drug drug)
            {
                throw new NotImplementedException();
            }
        }
        class DrugManager : IDrugManager
        {
            private Drug[] _drugs = new Drug[100];//Limitation of the Array, its fixed in size...
            public void DeleteDrug(int id)
            {
                throw new NotImplementedException();
            }

            public Drug[] FindDrug(string name)
            {
                throw new NotImplementedException();
            }

            public Drug FindDrug(int drugNo)
            {
                throw new NotImplementedException();
            }

            public void RegisterNewDrug(Drug drug)
            {
                for(int i =0; i < 100; i++)
                {
                    if(_drugs[i] == null)
                    {
                        _drugs[i] = new Drug();
                        _drugs[i].Copy(drug);
                        return;//Exit the function after the copy is done;
                    }
                }
                throw new Exception("No more drugs to be registered by the System!!!");
            }

            public void UpdateDrug(Drug drug)
            {
                throw new NotImplementedException();
            }
        }
    }

    /// <summary>
    /// User interface of the Application
    /// </summary>
    internal class e2eApp
    {
        private static DataLayer.IDrugManager mgr = new DataLayer.DrugFileManager();//instantiating the object.
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
                case "F":
                case "I":
                case "D":
                    return true;
                default:
                    return false;
            }
        }

        private static void addDrugHelper()
        {
            int id = Input.GetNumber("Enter the ID for the Drug");
            string name = Input.GetAnswer("Enter the name for the drug");
            string composition = Input.GetAnswer("Enter the Composition seperated by ,");
            double price = Input.GetDouble("Enter the cost for 10 Units");
            DateTime doM = Input.GetDate("Enter the Manufacturing date");
            Drug drg = new Drug { Composition = composition, DateOfManufacture = doM, DrugNo = id,  Name = name, Price = price};
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
