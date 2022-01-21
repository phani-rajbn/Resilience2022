using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml.Linq;

namespace SampleConApp_Day8
{
    internal class FileEmpDatabase : IEmpDatabase
    {
        DataTable memTable = new DataTable("EmpTable");//DataTable is a builtin class of .NET that allows to have in memory data in the form of real time database tables. 
        const string fileName = "Employees.csv";
        public FileEmpDatabase()
        {
            memTable.Columns.Add("EmpId", typeof(int));
            memTable.Columns.Add("EmpName", typeof(string));
            memTable.Columns.Add("EmpAddress", typeof(string));
            memTable.Columns.Add("EmpSalary", typeof(int));
        }
        public void AddNewEmployee(Employee employee)
        {
            File.AppendAllText(fileName, employee.ToString());
        }

        public void DeleteEmployee(int id)
        {
            //First get the records
            fillTable();
            //delete the matching record
            foreach (DataRow row in memTable.Rows)
            {
                if(row[0].ToString() == id.ToString())
                {
                    row.Delete();//Delete the row from the table....
                    break;//exit the foreach loop
                }
            }
            memTable.AcceptChanges();//Commiting the values to save
            //put back the records to the file.
            writeTofile();
        }

        public List<Employee> GetAllEmployees(string name)
        {
            var lines = File.ReadAllLines(fileName);//Get all the lines of CSV file
            var employees = new List<Employee>();//Create a blank list of employees
            foreach (var line in lines)//iterate thru each line
            {
                var parts = line.Split(',');//split each line into words
                if (parts[1].Contains(name))//check if name part of the word contains the name passed as arg....
                {
                    Employee employee = new Employee();//Create the employee and fill the data
                    employee.EmpId = int.Parse(parts[0]);
                    employee.EmpName = parts[1];
                    employee.EmpAddress = parts[2];
                    employee.EmpSalary = int.Parse(parts[3]);
                    employees.Add(employee);//add it to the empList
                }
            }
            return employees;//return the list. 
        }

        public Employee GetEmployee(int id)
        {
            var lines = File.ReadAllLines(fileName);//Get all the lines of CSV file
            foreach (var line in lines)//iterate thru each line
            {
                var parts = line.Split(',');//split each line into words
                if (parts[0]== id.ToString())//check if name part of the word contains the name passed as arg....
                {
                    Employee employee = new Employee();//Create the employee and fill the data
                    employee.EmpId = int.Parse(parts[0]);
                    employee.EmpName = parts[1];
                    employee.EmpAddress = parts[2];
                    employee.EmpSalary = int.Parse(parts[3]);
                    return employee;
                }
            }
            throw new Exception($"Employee with ID {id} not found");//return the list. 
        }

        public void UpdateEmployee(Employee employee)
        {
            fillTable();//reading operation
            foreach (DataRow row in memTable.Rows)
            {
                if (row[0].ToString() == employee.EmpId.ToString())
                {
                    row[1] = employee.EmpName;
                    row[2] = employee.EmpAddress;
                    row[3] = employee.EmpSalary;
                    break;
                }
            }
            writeTofile();//writing operation
        }
        //Helper function to fill the data from the file into the table created. 
        private void fillTable()
        {
            memTable.Rows.Clear();//Clears any data available.
            var lines = File.ReadAllLines(fileName);//Get all the lines of CSV file
            foreach(var line in lines)
            {
                var words = line.Split(',');
                DataRow row = memTable.NewRow();//Creates a blank row with the schema defined by the table. 
                for (int i = 0; i < words.Length; i++) row[i] = words[i];
                memTable.Rows.Add(row);
            }
            memTable.AcceptChanges();//Committing the changes
        }

        private void writeTofile()
        {
            List<string> lines = new List<string>();
            foreach(DataRow row in memTable.Rows)
            {
                string line = $"{row[0]}, {row[1]},{row[2]},{row[3]}";
                lines.Add(line);
            }
            File.WriteAllLines(fileName, lines.ToArray());
        }
    }
}
