using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //For Binary serialization
using System.Collections.Generic;
using System.Xml.Serialization;//For xml serialization..


namespace SampleConApp_Day8
{
    [Serializable]//Attributes are sp properties that are added to the target element at runtime. Mandatory for Binary....
    public class Customer//public mandatory for XML serialization
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int BillAmount { get; set; }
        public DateTime BillDate { get; set; }
    }

    internal class SerializationDemo
    {
        static void Main(string[] args)
        {
            //saveBinaryData();
            //readBinaryData();

            //saveAsXml();
            readXmlData();
        }


        private static void readXmlData()
        {
            using (FileStream fs = new FileStream("CustomerInfo.xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
                var data = formatter.Deserialize(fs) as List<Customer>;
                foreach (var rec in data)
                {
                    Console.WriteLine($"{rec.CustomerName} has billed an amount of {rec.BillAmount:C} on {rec.BillDate.ToLongDateString()}");
                }
            }
        }

        private static void saveAsXml()
        {
            //What to serialize?
            List<Customer> data = new List<Customer>();
            var customer = new Customer { CustomerID = 124, BillAmount = 77000, BillDate = DateTime.Now.AddDays(-122), CustomerName = "Phaniraj" };
            data.Add(customer);
            customer = new Customer { CustomerID = 125, BillAmount = 90000, BillDate = DateTime.Now.AddDays(-12), CustomerName = "Ramesh" };
            data.Add(customer);
            customer = new Customer { CustomerID = 126, BillAmount = 60000, BillDate = DateTime.Now.AddDays(-100), CustomerName = "Mohan" };
            data.Add(customer);
            customer = new Customer { CustomerID = 127, BillAmount = 37000, BillDate = DateTime.Now.AddDays(-2), CustomerName = "Kumar" };
            data.Add(customer);
            using (FileStream fs = new FileStream("CustomerInfo.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
                formatter.Serialize(fs, data);
            }
        }

        private static void readBinaryData()
        {
            using(FileStream fs = new FileStream("CustomerInfo.bin", FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                List<Customer> data = formatter.Deserialize(fs) as List<Customer>;
                foreach (var cst in data)
                {
                    Console.WriteLine(cst.CustomerName);
                }
            }
        }

        private static void saveBinaryData()
        {
            List<Customer> data = new List<Customer>();
            var customer = new Customer { CustomerID = 124, BillAmount = 77000, BillDate = DateTime.Now.AddDays(-122), CustomerName = "Phaniraj" };
            data.Add(customer);
            customer = new Customer { CustomerID = 125, BillAmount = 90000, BillDate = DateTime.Now.AddDays(-12), CustomerName = "Ramesh" };
            data.Add(customer);
            customer = new Customer { CustomerID = 126, BillAmount = 60000, BillDate = DateTime.Now.AddDays(-100), CustomerName = "Mohan" };
            data.Add(customer);
            customer = new Customer { CustomerID = 127, BillAmount = 37000, BillDate = DateTime.Now.AddDays(-2), CustomerName = "Kumar" };
            data.Add(customer);

            //using resource will ensure that the resource is closed and deleted after it exits the block..
            using (FileStream fs = new FileStream("CustomerInfo.bin", FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, data);
            }
        }
    }
}
