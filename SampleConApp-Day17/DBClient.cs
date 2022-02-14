using System;
using SampleDataLib.DataLayer;
using SampleDataLib.Entities;

namespace SampleConApp_Day17
{
    internal class DBClient
    {
        static IPatientDB dbComponent = PatientFactory.CreateComponent();
        static void Main(string[] args)
        {
            try
            {
                dbComponent.AddNewPatient(new Patient { BillAmount = 5000, BillDate = DateTime.Now, PatientAddress = "Tumkur", PatientId = 111, PatientName = "Phaniraj" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
