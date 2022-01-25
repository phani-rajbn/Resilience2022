using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
namespace Assignment
{
    interface IDataManager
    {
        void AddData(Data data);
        void Updatedata(Data data);
        Data FindDatabyId(int id);
        List<Data> FindDataByDesc(String Description);
        void DeleteData(int id);
    }
    class DataManager : IDataManager
    {
        List<Data> data = new List<Data>();
        private void savedata()
        {
            using (FileStream fs = new FileStream("recordinfo.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                XmlSerializer format = new XmlSerializer(typeof(List<Data>));
                format.Serialize(fs, data);
            }
        }
        private void loadData()
        {
            if (!File.Exists("recordinfo.xml"))
            {
                data = new List<Data>();
            }
            else
            {
                using (FileStream fs = new FileStream("recordinfo.xml", FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer format = new XmlSerializer(typeof(List<Data>));
                    data = format.Deserialize(fs) as List<Data> ;
                }
            }
        }
        public void AddData(Data data)
        {
            this.data.Add(data);
            savedata();
        }
        public void DeleteData(int id)
        {
            throw new NotImplementedException();
        }
        public List<Data> FindDataByDesc(string Description)
        {
            throw new NotImplementedException();
        }
        public Data FindDatabyId(int id)
        {
            throw new NotImplementedException();
        }
        public void Updatedata(Data data)
        {
            throw new NotImplementedException();
        }
    }
}
