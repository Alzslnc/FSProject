using System.Collections.Generic;

namespace FSProject
{
    public class DataClassList
    {
        public DataClass AddNewData()
        {
            int i = 1;
            while (ContainName(i.ToString())) i++;
            DataClass data = new DataClass(i.ToString());
            if (!data.Exist) return null;
            DataClasses.Add(data);
            return data;
        }
        public DataClass GetData(string name)
        { 
            foreach (DataClass data in DataClasses) if (data.Name == name) return data;
            return null;            
        }
        private bool ContainName(string name)
        { 
            foreach (DataClass data in DataClasses) if (data.Name == name) return true;
            return false;
        }
        public List<DataClass> DataClasses { get; private set; } = new List<DataClass>();
    }
}
