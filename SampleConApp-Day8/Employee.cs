using System;

namespace SampleConApp_Day8
{
    internal class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }
        public override string ToString()
        {
            return $"{EmpId},{EmpName},{EmpAddress},{EmpSalary}\n";
        }
    }
}
