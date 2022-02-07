using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
namespace SampleMvcApp.Models
{
    //const cannot be set with a variable value,  U should pass literal value.
    public class DataComponent
    {
        static string CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
        public List<Employee> GetAllEmployees()
        {
            var list = new List<Employee>();
            using(SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                try
                {
                    con.Open();
                    SqlCommand sqlCmd = con.CreateCommand();
                    sqlCmd.CommandText = "SELECT * FROM EMPTABLE";
                    var reader = sqlCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var emp = new Employee();
                        emp.EmpId = Convert.ToInt32(reader[0]);
                        emp.EmpName = reader[1].ToString();
                        emp.EmpAddress = reader[2].ToString();
                        emp.EmpSalary = Convert.ToInt32(reader[3]);
                        list.Add(emp);
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return list;
        }
    }
}