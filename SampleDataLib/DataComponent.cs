using System;

namespace SampleDataLib.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientAddress { get; set; }
        public DateTime BillDate { get; set; }
        public int BillAmount { get; set; }
    }
}

namespace SampleDataLib.DataLayer
{
    using SampleDataLib.Entities;
    using System.Collections.Generic;
    using SampleDataLib.DataComponents;
    using System.Linq;
    public interface IPatientDB
    {
        void AddNewPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int pId);
        List<Patient> GetAllPatients();
    }

    public static class PatientFactory
    {
        public static IPatientDB CreateComponent()
        {
            return new PatientDB();
        }
    }

    //I dont want to expose the class.
    class PatientDB : IPatientDB
    {
        private Patient do_Convert(PatientTable tableData)
        {
            return new Patient 
            {
                PatientId = tableData.PatientID,
                PatientName = tableData.Name,
                PatientAddress = tableData.Address,
                BillAmount = Convert.ToInt32(tableData.Amount),
                BillDate = tableData.BillDate
            };
        }

        private PatientTable do_Convert(Patient tableData)
        {
            return new PatientTable
            {
                PatientID = tableData.PatientId,
                Name = tableData.PatientName,
                Address = tableData.PatientAddress,
                Amount = tableData.BillAmount,
                BillDate = tableData.BillDate
            };
        }


        public void AddNewPatient(Patient patient)
        {
            var pRecord = do_Convert(patient);
            pRecord.PatientID = 0;//We dont pass the Patient ID as it is auto generated. 
            var context = new ResilienceDemoEntities();
            context.PatientTables.Add(pRecord);
            context.SaveChanges();
        }

        public void DeletePatient(int pId)
        {
            throw new NotImplementedException("Do It as assignment");
        }

        public List<Patient> GetAllPatients()
        {
            var context = new ResilienceDemoEntities();
            //----------------------One way------------------//
            //var data = context.PatientTables.ToList();
            //List<Patient> records = new List<Patient>();
            //foreach(var p in data)
            //    records.Add(do_Convert(p));
            //return records;
            //--------------------Another way-----------------//
            var records = (from rec in context.PatientTables
                          select new Patient {
                              PatientId = rec.PatientID,
                              PatientName = rec.Name,
                              PatientAddress = rec.Address,
                              BillAmount = (int)(rec.Amount),
                              BillDate = rec.BillDate
                          }).ToList();
            return records;

        }

        public void UpdatePatient(Patient patient)
        {
            var data = do_Convert(patient);
            var context = new ResilienceDemoEntities();
            var selected = context.PatientTables.FirstOrDefault((p) => p.PatientID == data.PatientID);
            selected = data;
            context.SaveChanges();
        }
    }
}