using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;

namespace FSProject
{
    public class DataClassList
    {
        public DataClass AddNewData()
        {
            int i = 1;
            string name = "";
            using (Transaction tr = HostApplicationServices.WorkingDatabase.TransactionManager.StartTransaction())
            {
                using (BlockTableRecord btr = tr.GetObject(HostApplicationServices.WorkingDatabase.CurrentSpaceId, OpenMode.ForRead) as BlockTableRecord) name = btr.Name;
                tr.Commit();
            }
            //while (ContainName(name + "_" + i.ToString())) i++;
            //DataClass data = new DataClass(name + "_" + i.ToString());
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
