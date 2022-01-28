using System;
using System.Linq;

//Using LINQ to interact with SQL server. 
//Instead of ADO.NET, we will use LINQ to SQL to connect and interact with the database.
//ORM: Object Relational Mapping is a design pattern of interacting with databases without using SQL. Here we convert the data into object oriented objects and perform queries on the objects using language based queries and Collection related APIs. 
//Hibernate, FastObjectsToSQL(ORM for CPP), LINQ to SQL, EF, nHibernate are some of the ORM technologies. 
//The idea is to reduce the usage of SQL for a Front end developer.
//Install LINQ to SQL Component from VS Installer
//Project->Add New Item->LINQ to SQL Classes->*.dbml
//Configure the SQL server to UR server explorer of the VS.
//Drag and drop the tables on which U want to perform LINQ into the ORM Designer(DBML file).
//Context class will be the FileName of the DBML suffixed with DataContext. 
namespace SampleConApp_Day12
{
    internal class Program
    {
        static ExampleDataContext context = new ExampleDataContext();
        static void Main(string[] args)
        {
            //displayAllEmployees();
            //displayGroupedByCity();
            //displayNameAndDept();
            //displayEmployeesOfEachDept();
            //displayDetails("ani");
            //addEmployee(new EmpTable { EmpName = "Ramesh",  EmpAddress = "Bangalore", EmpSalary = 39000, Dept = new Dept { DeptName = "Security" } });
            //updateEmployee(new EmpTable { EmpId = 108, EmpName = "Ramesh Gowda", EmpAddress = "Bangalore" });
            deleteEmployee(108);//Take the input from the user and try it...
        }

        private static void deleteEmployee(int v)
        {
            var rec = context.EmpTables.FirstOrDefault((e)=>e.EmpId == v);
            if (rec != null)
            {
                context.EmpTables.DeleteOnSubmit(rec);
                context.SubmitChanges();
                return;
            }
            throw new Exception("Employee not found to delete");
        }

        private static void updateEmployee(EmpTable empTable)
        {
            //find the matching record
            var rec = (from emp in context.EmpTables
                      where emp.EmpId == empTable.EmpId
                      select emp).SingleOrDefault();//Gets the Single record or null if no record is found, However, if the query returns more than one record, it throws an Exception. 
            //set the values
            if(rec == null)
            {
                Console.WriteLine("No Record found");
                return;
            }
            if(!string.IsNullOrEmpty(empTable.EmpName)) rec.EmpName = empTable.EmpName;
            if(!string.IsNullOrEmpty(empTable.EmpAddress)) rec.EmpAddress = empTable.EmpAddress;
            if(empTable.EmpSalary > 0) rec.EmpSalary = empTable.EmpSalary;
            if(empTable.DeptID > 0) rec.DeptID = empTable.DeptID;
            context.SubmitChanges(); //submit for changes
        }

        private static void addEmployee(EmpTable empTable)
        {
            context.EmpTables.InsertOnSubmit(empTable);//Adds the data into the collection
            context.SubmitChanges();//Update the collection to the database. 
        }

        private static void displayDetails(string name)
        {
            var records = from emp in context.EmpTables
                          where emp.EmpName.Contains(name)
                          select emp;
            foreach (var rec in records)
            {
                Console.WriteLine(rec.EmpName);
            }
        }

        private static void displayEmployeesOfEachDept()
        {
            var records = from dept in context.Depts
                          select dept;
            foreach (var dept in records)
            {
                Console.WriteLine("People under dept: " + dept.DeptName);
                foreach (var emp in dept.EmpTables)
                {
                    Console.WriteLine(emp.EmpName);
                }
                Console.WriteLine("\n\n");
            }
        }

        private static void displayNameAndDept()
        {
            var context = new ExampleDataContext();
            var data = from emp in context.EmpTables
                       select new { Name = emp.EmpName, DeptName = emp.Dept.DeptName };
            foreach (var emp in data)
            {
                Console.WriteLine(emp);
            }
        }

        private static void displayGroupedByCity()
        {
            var context = new ExampleDataContext();
            var data = from emp in context.EmpTables
                       group emp by emp.EmpAddress into gr
                       orderby gr.Key descending
                       select gr;
            foreach(var group in data)
            {
                Console.WriteLine("People from City: " + group.Key);
                foreach (var emp in group)
                {
                    Console.WriteLine(emp.EmpName);
                }
            }
        }

        private static void displayAllEmployees()
        {
            ExampleDataContext context = new ExampleDataContext();
            var data = from emp in context.EmpTables//Pluralized name of the table
                       select new { Name = emp.EmpName, Address = emp.EmpAddress } ;
            foreach (var emp in data)
            {
                Console.WriteLine(emp.Name + " from " + emp.Address);
            }
        }
    }
}
