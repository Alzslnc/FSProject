using System.Collections.Generic;
using static BaseFunction.BaseGeometryClass;

namespace FSProject
{
    public class ObjectData
    {
        public ObjectData(string name, string name2, EntityType entityType)
        {
            EntityType = entityType;
            Name = name;         
        }
        public ObjectData(string name) 
        { 
            Name = name;
        }
        public ObjectData(double length, EntityType entityType)
        {
            EntityType = entityType;
            Length = length;
        }
        public EntityType EntityType { get; private set; } = EntityType.none;
        public double Length { get; private set; } = 0;
        public bool Check { get; set; } = true;
        public string Name { get; private set; } = "";
        public int Count { get; set; } = 0;
        public List<ObjectData> ObjectDatas { get; private set; } = new List<ObjectData>();
    }

    public static class ObjectDataMethods
    {
        public static void CheckChange(this List<ObjectData> datas, List<string> changes)
        {
            int round =  Properties.Settings.Default.Round;
            foreach (ObjectData data in datas)
            {
                string parametr;
                if (data.EntityType == EntityType.Curve || data.EntityType == EntityType.Text) parametr = data.Length.ToString("F" + round);             
                else parametr = data.Name;
                if (changes.Contains(parametr)) data.Check = true; 
                else data.Check = false;            
            }        
        }
        public static void ClearData(this List<ObjectData> datas)
        {
            for (int i = datas.Count - 1; i >= 0; i--)
            { 
                if (datas[i].Count == 0) datas.RemoveAt(i);
            }        
        }
        public static void ClearDataCounts(this List<ObjectData> datas)
        {
            for (int i = datas.Count - 1; i >= 0; i--)
            {
                datas[i].Count = 0;
            }
        }
        public static void SortData(this List<ObjectData> datas)
        {
            if (datas.Count < 2) return;
            List<string> strings = new List<string>();
            List<double> doubles = new List<double>();
            foreach (ObjectData data in datas)
            { 
                if (data.EntityType == EntityType.Curve || data.EntityType == EntityType.Text) doubles.Add(data.Length);
                else strings.Add(data.Name);            
            }
            strings.Sort();
            doubles.Sort();
            List<ObjectData> result = new List<ObjectData> ();
            if (strings.Count != 0)
            {
                foreach (string s in strings)
                {
                    ObjectData data = datas.GetData(s);
                    result.Add(data);
                    datas.Remove(data);
                }            
            }
            else if (doubles.Count != 0)
            {
                foreach (double s in doubles)
                {
                    ObjectData data = datas.GetData(s);
                    result.Add(data);
                    datas.Remove(data);
                }
            }
            foreach (ObjectData data in result)
            {
                if (data != null) datas.Add(data);
            }          
        }   
        public static bool CheckData(this List<ObjectData> datas, string name)
        { 
            ObjectData data = GetData(datas, name);
            if (data == null) return false;
            else return data.Check;
        }
        public static bool CheckData(this List<ObjectData> datas, double length)
        {
            ObjectData data = GetData(datas, length);
            if (data == null) return false;
            else return data.Check;
        }
        public static bool ContainsData(this List<ObjectData> datas, string name)
        {
            if (string.IsNullOrEmpty(name) || datas.Count == 0) return false;
            foreach (ObjectData data in datas) if (data.EntityType == EntityType.none && data.Name == name) return true;           
            return false;
        }
        public static ObjectData GetData(this List<ObjectData> datas, string name)
        {
            foreach (ObjectData data in datas) if ((data.EntityType == EntityType.none || data.EntityType == EntityType.BlockReference) && data.Name == name) return data;         
            return null;
        }
        public static bool ContainsData(this List<ObjectData> datas, double length)
        {
            if (datas.Count == 0) return false;
            foreach (ObjectData data in datas) if ((
                    data.EntityType == EntityType.Curve || 
                    data.EntityType == EntityType.Text) && data.Length.IsEqualTo(length)) return true;
            return false;
        }
        public static ObjectData GetData(this List<ObjectData> datas, double length)
        {
            foreach (ObjectData data in datas) if ((
                    data.EntityType == EntityType.Curve ||
                    data.EntityType == EntityType.Text) && data.Length.IsEqualTo(length)) return data;
            return null;
        }
    }
}
