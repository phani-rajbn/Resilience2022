using System;
using System.Collections.Generic;
using System.IO;

namespace SampleConApp_Day8
{
    internal class FileDemo
    {
        //const string FileName = @"D:\Trainings\Resilience-2022\Notes.txt";
        const string FileName = @"../../SampleData.csv";//CSV is a text based file where data is represented in the form of text where each line represents an individual record and each record has multiple values seperated by , where each value represents info about the record. 
        static List<Employee> employees = new List<Employee>();//NO data in it...
                                                               //
        static void createObjectsFromFile()
        {
            string [] lines = File.ReadAllLines(FileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                Employee employee = new Employee();
                employee.EmpId = int.Parse(parts[0]);
                employee.EmpName = parts[1];
                employee.EmpAddress = parts[2];
                employee.EmpSalary = int.Parse(parts [3]);
                employees.Add(employee);
            }

        }
        static void Main(string[] args)
        {
            //////////////////////////Reading all the content and display//////////////////////////////////////
            //string content = File.ReadAllText(FileName);
            //Console.WriteLine(content);

            ////////////////////////Reading each line of the file and do some operation////////////////////////
            //string[] lines = File.ReadAllLines(FileName);
            //for (int i = 0; i < lines.Length; i++)
            //{
            //    var words = lines[i].Split(' ');    
            //    Console.WriteLine($"The no of words in line no {i+1} is {words.Length}");
            //}

            //////////////////////Appending content to an existing data in the file/////////////////////////////
            //File.AppendAllText(FileName, "Add this content to the end of the file");

            /////////////////////Read a CSV file, put it into List<T> and read the data////////////////////////
            //readAnddisplayData();

            //////////////////////////Creating and working on a custom file with all CURD operations/////////////////
            IEmpDatabase db = new FileEmpDatabase();
            //db.AddNewEmployee(new Employee { EmpId = 125, EmpName ="Pawan", EmpAddress ="Hyderabad", EmpSalary = 65000 });
            //db.UpdateEmployee(new Employee { EmpId = 124, EmpName ="GopalRathnam", EmpAddress ="Vadapalani Chennai", EmpSalary = 55000 });
            //db.DeleteEmployee(125);
            //var records = db.GetAllEmployees("a");
            //foreach (var record in records)
            //{
            //    Console.WriteLine(record.EmpName);
            //}
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private static void readAnddisplayData()
        {
            createObjectsFromFile();
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"{emp.EmpName} comes from {emp.EmpAddress}");
            }
        }
    }
}
