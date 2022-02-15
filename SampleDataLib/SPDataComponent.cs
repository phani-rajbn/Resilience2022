using SampleDataLib.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace SampleDataLib.DataLayer
{
    internal class SPDataComponent : IPatientDB
    {
        private static string strConnectionstring = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        const string ADDRECORD = "AddPatient";
        const string SELECTALL = "AllPatients";
        const string UPDATERECORD = "UpdatePatient";
        const string DELETERECORD = "DeletePatient";

        public void AddNewPatient(Patient patient)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnectionstring))
                {
                    SqlCommand sqlCmd = new SqlCommand(ADDRECORD, sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@name", patient.PatientName);
                    sqlCmd.Parameters.AddWithValue("@address", patient.PatientAddress);
                    sqlCmd.Parameters.AddWithValue("@amount", patient.BillAmount);
                    sqlCmd.Parameters.AddWithValue("@date", patient.BillDate);
                    sqlCon.Open();
                    sqlCmd.ExecuteNonQuery();
                }            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletePatient(int pId)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnectionstring))
                {
                    SqlCommand sqlCmd = new SqlCommand(DELETERECORD, sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@id", pId);
                    sqlCon.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Patient> GetAllPatients()
        {
            List<Patient> allPatients = new List<Patient>();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnectionstring))
                {
                    SqlCommand sqlCmd = new SqlCommand(SELECTALL, sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCon.Open();
                    var reader = sqlCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var patient = new Patient();
                        patient.PatientId = Convert.ToInt32(reader[0]);
                        patient.PatientName = reader[1].ToString();
                        patient.PatientAddress = reader[2].ToString();
                        patient.BillDate = Convert.ToDateTime(reader[3]);
                        patient.BillAmount = Convert.ToInt32(reader[4]);
                        allPatients.Add(patient);
                    }
                }
                return allPatients;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePatient(Patient patient)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnectionstring))
                {
                    SqlCommand sqlCmd = new SqlCommand(UPDATERECORD, sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@name", patient.PatientName);
                    sqlCmd.Parameters.AddWithValue("@address", patient.PatientAddress);
                    sqlCmd.Parameters.AddWithValue("@amount", patient.BillAmount);
                    sqlCmd.Parameters.AddWithValue("@date", patient.BillDate);
                    sqlCmd.Parameters.AddWithValue("@id", patient.PatientId);
                    sqlCon.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
