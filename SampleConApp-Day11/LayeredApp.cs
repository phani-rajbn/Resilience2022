using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using SampleConApp_Day7;
//SQL -> IDataBase -> MainApp-> Collections. 
namespace SampleConApp_Day11
{
    class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public override string ToString()
        {
            return $"Name:{Name}\tDate:{Date.ToLongDateString()}\tAmount:{Amount:C}\tID:{Id}";
        }
    }

    interface IBusinessObject
    {
        void AddRecord(Data data);
        void UpdateRecord(Data data);
        void DeleteRecord(int id);
        List<Data> GetAllRecords();
    }

    class BusinessObject : IBusinessObject
    {
        private IDataObject dataComponent = null;//Loose Coupling!!!!

        public BusinessObject(IDataObject obj)
        {
            this.dataComponent = obj;
        }
        public void AddRecord(Data data)
        {
            //U should enforce the business rules here. reject if the data is not appropriate. 
            dataComponent.AddRecord(data.Id, data.Name, data.Date, data.Amount);
        }

        public void DeleteRecord(int id)
        {
            dataComponent.DeleteRecord(id);
        }

        public List<Data> GetAllRecords()
        {
            var list = new List<Data>();
            DataTable data = dataComponent.GetAllRecords();//Table needs to be converted to List<Data>
            foreach(DataRow row in data.Rows)
            {
                var dt = new Data();
                dt.Id = Convert.ToInt32(row[0]);
                dt.Name = row[1].ToString();
                dt.Date = Convert.ToDateTime(row[2]);
                dt.Amount = Convert.ToInt32(row[3]);
                list.Add(dt);
            }
            return list;
        }

        public void UpdateRecord(Data data)
        {
            //U should enforce the business rules here. reject if the data is inappropriate. 
            dataComponent.UpdateRecord(data.Id, data.Name, data.Date, data.Amount);
        }
    }

    interface IDataObject
    {
        void AddRecord(int id, string name, DateTime date, double amount);
        void UpdateRecord(int id, string name, DateTime date, double amount);
        void DeleteRecord(int id);
        DataTable GetAllRecords();
    }

    class DataObject : IDataObject
    {
        const string STRCONNECTION = "Data Source=.\\SQLEXPRESS;Initial Catalog=ResilienceDemo;Integrated Security=True";
        const string STRADD = "AddRecord";
        const string STRUPDATE = "UpdateRecord";
        const string STRDELETE = "DeleteRecord";
        const string STRSELECT = "SELECT * FROM TBLDATA";

        public void AddRecord(int id, string name, DateTime date, double amount)
        {
            using(SqlConnection conn = new SqlConnection(STRCONNECTION))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = STRADD;//Name of the SP...
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@amount", amount);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine(ex.Message);//Log the exception
                    throw ex;//pushing the exception to the next layer
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void DeleteRecord(int id)
        {
            using (SqlConnection conn = new SqlConnection(STRCONNECTION))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = STRDELETE;//Name of the SP...
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine(ex.Message);//Log the exception
                    throw ex;//pushing the exception to the next layer
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public DataTable GetAllRecords()
        {
            using(SqlConnection conn = new SqlConnection(STRCONNECTION))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = STRSELECT;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    //Code to convert reader to DataTable...
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);//Load the data of the reader into the table.
                    return dataTable;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void UpdateRecord(int id, string name, DateTime date, double amount)
        {
            using (SqlConnection conn = new SqlConnection(STRCONNECTION))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = STRUPDATE;//Name of the SP...
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@amount", amount);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine(ex.Message);//Log the exception
                    throw ex;//pushing the exception to the next layer
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }

    internal class LayeredApp
    {
        static IDataObject obj = new DataObject();//The required DataObject
        static IBusinessObject bo = new BusinessObject(obj);//The required Business object
        const string MENU = "------------Demo App----------\nPress A to Add\nPress D to delete\nPress U for Update\nPress F to Find/Display records\nPS: Any other key is considered as END\n-----------------------------------";
        static void Main(string[] args)
        {
            bool processing = true;
            do
            {
                string answer = Input.GetAnswer(MENU);
                processing = processMenu(answer);
            } while (processing);
        }

        private static bool processMenu(string answer)
        {
            switch (answer)
            {
                case "A":
                    addingDemo();
                    return true;
                case "U":
                    updatingDemo();
                    return true;
                case "D":
                    deleteDemo();
                    return true;
                case "F":
                    displayAll();
                    return true;
                default:
                    return false;
            }
        }

        private static void displayAll()
        {
            var records = bo.GetAllRecords();
            foreach (var rec in records)
            {
                Console.WriteLine(rec);
            }
        }

        private static void deleteDemo()
        {
            var id = Input.GetNumber("Enter the ID to Update");
            try
            {
                bo.DeleteRecord(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void updatingDemo()
        {
            var id = Input.GetNumber("Enter the ID to Update");
            var name = Input.GetAnswer("Enter the name to Update");
            var date = Input.GetDate("Enter the date of info");
            var amount = Input.GetDouble("Enter the Amount");
            var obj = new Data { Id = id, Name = name, Amount = amount, Date = date };
            try
            {
                bo.UpdateRecord(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void addingDemo()
        {
            var id = Input.GetNumber("Enter the ID to Add");
            var name = Input.GetAnswer("Enter the name");
            var date = Input.GetDate("Enter the date of info");
            var amount = Input.GetDouble("Enter the Amount");
            var obj = new Data { Id = id, Name = name, Amount = amount, Date = date };
            try
            {
                bo.AddRecord(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
