using System;

/*Create a class called Patient and should have  properties like Id, Name, DateOfbirth, DateOfVisit, DoctorName and Fees. 
Develop a program to take input from the User for a single patient and display the details  of that patient*/
namespace SampleConApp_Day4
{
    /// <summary>
    /// Represents a real time patient of a Hospital that store info about outpatient.
    /// </summary>
    internal class Patient
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public DateTime DateOfBirth{ get; set; }
        public DateTime DateOfVisit { get; set; } = DateTime.Now;//Default value is current date of the system. 
        public string DoctorName { get; set; }
        public double BillAmount { get; set; }
    }

    /// <summary>
    /// The User interface class will do all the user interactions like taking inputs and presenting the data to the user.
    /// </summary>
    class TestingApp
    {
        /// <summary>
        /// Takes inputs from the user and creates a valid Patient object
        /// </summary>
        /// <returns>A Valid Patient object</returns>
        static Patient createPatient()
        {
            Patient patient = new Patient();
            patient.PatientID = Input.GetNumber("Enter the Patient ID");
            patient.PatientName = Input.GetAnswer("Enter the Patient Name");
            patient.DateOfBirth = Input.GetDate("Enter the Date of Birth");
            patient.BillAmount = Input.GetDouble("Enter the bill Amount");
            return patient;
        }
        static void Main(string[] args)
        {
            Patient patient = createPatient();
            Console.WriteLine($"The patient named {patient.PatientName} information has been stored");
        }
    }
}
