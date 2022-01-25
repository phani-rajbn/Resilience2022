using System;
using System.Collections.Generic;
using System.Data.SqlClient;//Namespace that contains classes to connect to SQL server database exclusively...
using System.Diagnostics;

namespace SampleConApp_Day10
{
    class Employee
    {
        public int DeptId  { get; set; }
        public int EmpSalary { get; set; }
        public string EmpAddress { get; set; }
        public string EmpName { get; set; }
        public int EmpID { get; set; }
    }
    internal class ConnectedDemo
    {
        const string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=ResilienceDemo;Integrated Security=True";
        const string sqlSelect = "SELECT * FROM EmpTable";
        static void Main(string[] args)
        {
            //readTheRecords();
            //Console.WriteLine("Enter the ID of the Employee to search");
            //findRecordById(int.Parse(Console.ReadLine()));
            //addNewEmployee("Priyanka", "Baroda", 55000, 2);//modify the code to take inputs from user and pass it into the func.
            //updateEmployee(105, "Priyanka Gulia", "Varodara", 55000, 2);
            
            //Create a Class called Employee, implement the getAllEmployees function that returns the data as List<Employee>.
            //Use the return data and display it on Console by overriding the ToString method to display it as Coma seperated values.
            List<Employee> employees = getAllEmployees();
            foreach (var emp in employees) Console.WriteLine(emp.EmpName);
        }

        private static List<Employee> getAllEmployees()
        {
            List<Employee> list = new List<Employee>(); ;
            using(SqlConnection con = new SqlConnection(strCon))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Select * from EmpTable";
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var emp = new Employee();
                    emp.EmpID = Convert.ToInt32(reader[0]);
                    emp.EmpName = reader[1].ToString();
                    emp.EmpAddress = reader[2].ToString();
                    emp.EmpSalary = Convert.ToInt32(reader[3]);
                    emp.DeptId = Convert.ToInt32(reader[4]);
                    list.Add(emp);
                }
                con.Close();
            }
            return list;
        }

        private static void updateEmployee(int id, string name, string address, int salary, int deptId)
        {
            var query = "Update EmpTable Set Empname = @name, EmpAddress = @address, EmpSalary = @salary, DeptID = @deptId where EmpID = @id";//Write the query.
            //Create the connection object
            using (SqlConnection conn = new SqlConnection(strCon))//create the Connection object.
            {
                var cmd = new SqlCommand(query, conn); //create the Command object
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@deptId", deptId);
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();//execute the query
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();//close the resources
                }
            }
        }

        private static void addNewEmployee(string name, string address, int salary, int deptId)
        {
            
            //var query = $"Insert into EmpTable values('{name}','{address}', {salary}, {deptId})";
             var query = "Insert into EmpTable values(@name, @address, @salary, @deptId)";//Write the query.
            //Create the connection object
            using(SqlConnection conn = new SqlConnection(strCon))//create the Connection object.
            {
                var cmd = new SqlCommand(query, conn); //create the Command object
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@deptId", deptId);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();//execute the query
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();//close the resources
                }
            }
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
