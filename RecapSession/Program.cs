using System;
using System.Data.SqlClient;

//One book written by more than one author and one author can write multiple books. (Many to Many relation)
//One Dept has many employees. Here one employee is always associated with one dept only.(One to Many)
namespace RecapSession
{
    internal class Program
    {
        const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ResilienceDemo;Integrated Security=True";
        const string addQuery = "AddNewBook";
        static void Main(string[] args)
        {
            addBookToDatabase();
        }

        private static void addBookToDatabase()
        {
            int id = Input.GetNumber("Enter the ID of the book");
            string title = Input.GetAnswer("Enter the title of the book");
            int price = Input.GetNumber("Enter the Price of the book");
            int au_id = Input.GetNumber("Enter the ID of the Author");
            string au_name = Input.GetAnswer("Enter the Name of the Author");
            string au_address = Input.GetAnswer("Enter the Address of the Author");

            var connection = new SqlConnection(ConnectionString);
            var cmd = connection.CreateCommand();
            cmd.CommandText = addQuery;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bookid", id);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@authorId", au_id);
            cmd.Parameters.AddWithValue("@authorName", au_name);
            cmd.Parameters.AddWithValue("@authorAddress", au_address);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
