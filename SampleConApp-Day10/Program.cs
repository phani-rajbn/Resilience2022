using System;
using System.Data.SqlClient;//Namespace that contains classes to connect to SQL server database exclusively...
using System.Diagnostics;

namespace SampleConApp_Day10
{
    internal class ConnectedDemo
    {
        const string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=ResilienceDemo;Integrated Security=True";
        const string sqlSelect = "SELECT * FROM EmpTable";
        static void Main(string[] args)
        {
            //readTheRecords();
            Console.WriteLine("Enter the ID of the Employee to search");
            findRecordById(int.Parse(Console.ReadLine()));
        }
        //Finds the matching record and displays..
        private static void findRecordById(int empId)
        {
            string query = $"SELECT * FROM EMPTABLE WHERE EMPID = '{empId}'";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine($"Name: {dr["EmpName"]} from {dr["EmpAddress"]} earns {dr["EmpSalary"]:C}");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private static void readTheRecords()
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = strCon;//Info about the physical db that U want to connect. 
            SqlCommand cmd = sqlCon.CreateCommand();// It will create a new SqlCommand object that is associated with the Connection.
            cmd.CommandText = sqlSelect;
            try
            {
                sqlCon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Name: {reader[1]}\tAddress: {reader["EmpAddress"]}");//Column name or Column index..
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(sqlCon.State == System.Data.ConnectionState.Open)
                    sqlCon.Close();
            }
        }
    }
}
