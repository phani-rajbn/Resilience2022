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

        public Employee FindEmployee(int id)
        {
            Employee emp = new Employee();
            using(SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                try
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM EMPTABLE WHERE EMPID = " + id;
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        emp.EmpId = Convert.ToInt32(reader[0]);
                        emp.EmpName = reader[1].ToString();
                        emp.EmpAddress = reader[2].ToString();
                        emp.EmpSalary = Convert.ToInt32(reader[3]);
                    }
                    else
                        throw new Exception("No Employee found");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
            return emp;
        }

        public void UpdateEmployee(Employee emp)
        {
            using(SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var query = $"UPDATE EmpTable set EmpName = '{ emp.EmpName }', EmpAddress = '{emp.EmpAddress}', EmpSalary = {emp.EmpSalary} WHERE EmpId = {emp.EmpId}";
                SqlCommand cmd = new SqlCommand(query, con); 
                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new Exception("No Details were updated");
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void AddNewEmployee(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var query = "Insert into EmpTable values(@name, @address, @salary, 3)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", emp.EmpName);
                cmd.Parameters.AddWithValue("@address", emp.EmpAddress);
                cmd.Parameters.AddWithValue("@salary", emp.EmpSalary);
                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new Exception("No Details were added");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

    }
}