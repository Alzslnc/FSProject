using System.Collections.Generic;

namespace FSProject
{
    public class ObjectData
    {
        public string Name = string.Empty;
        public int Count = 0;
    }

    public static class ObjectDataMethods
    {
        public static bool ContainsData(this List<ObjectData> datas, string name)
        {
            if (string.IsNullOrEmpty(name) || datas.Count == 0) return false;
            foreach (ObjectData data in datas)
            { 
                if (data.Name == name) return true;
            }
            return false;
        }
        public static ObjectData GetData(this List<ObjectData> datas, string name)
        {
            foreach (ObjectData data in datas)
            { 
                if (data.Name == name) return data;
            }
            return null;
        }
    }
}
