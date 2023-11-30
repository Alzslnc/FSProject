using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;

namespace FSProject
{
    public class DataClass
    {
        public DataClass(string name)
        {
            List<ObjectId> ids = new List<ObjectId>();
            CurrDb = HostApplicationServices.WorkingDatabase;
            //CurrSpaceId = HostApplicationServices.WorkingDatabase.CurrentSpaceId;
            CurrDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor ed = CurrDoc.Editor;
            using (CurrDoc.LockDocument())
            {
                PromptSelectionResult psr = ed.SelectImplied();
                if (psr.Value != null) ids.AddRange(psr.Value.GetObjectIds());
                if (ids.Count == 0) return;
                Ids = ids;
                Update();
                Name = name;
                Exist = true;
            }
        }
        
        public bool SelectSelected()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            if (doc == null) return false;
            if (doc != CurrDoc) return false;
            if (Ids.Count == 0) return false;
             

            int deleted = 0;

            Progress.ProgressDialog dialog = null;

            using (doc.LockDocument())
            {
                bool necurr = true;
                using (BlockTableRecord btr = HostApplicationServices.WorkingDatabase.CurrentSpaceId.Open(OpenMode.ForRead) as BlockTableRecord)
                {
                    foreach (ObjectId id in btr)
                    {
                        if (id.Equals(Ids[0]))
                        { 
                            necurr = false;
                            break;
                        }                    
                    }                
                }                 
                if (necurr)
                {
                    System.Windows.Forms.MessageBox.Show("Объекты находятся в другом пространстве");
                    return false;
                }
                List<ObjectId> SelectedId = new List<ObjectId>();
                if (HostApplicationServices.WorkingDatabase == CurrDb)
                {      
                    int step = 0;
                    int curStep = 0;

                    if (Ids.Count > 3000)
                    {
                        dialog = new Progress.ProgressDialog();
                        dialog.MainBarCount = Ids.Count;                     
                        dialog.MainStep = 20;
                        dialog.UseCancel = false;
                        dialog.UseSubBar = false;
                        dialog.MainMessage = "Считываем данные (" + step + " из " + Ids.Count + ")";
                        dialog.Start();
                       
                    }

                    foreach (ObjectId id in Ids)
                    {
                        if (dialog != null)
                        {
                            step++;
                            curStep++;
                            if (curStep == 19)
                            {
                                curStep = 0;
                                dialog.StepMainBar();
                                dialog.MainMessage = "Считываем данные (" + step + " из " + Ids.Count + ")";
                            }
                        }
                        if (id == null || id == ObjectId.Null || !id.IsValid || id.IsErased)
                        {
                            deleted++;
                            continue;
                        }
                        using (Entity e = id.Open(OpenMode.ForRead, false, true) as Entity)
                        {
                            if (e != null)
                            {
                                string eColor = e.Color.ToString();
                                string eLayer = e.Layer.ToString();
                                string eType = id.ObjectClass.Name;
                                double length = -1;
                                List<string> attributes = new List<string>();
                                List<string> attributesVal = new List<string>();
                                EntityType entityType = EntityType.none;
                                if (e is Curve c)
                                {
                                    length = Math.Round(GetLength(c), Round);
                                    entityType = EntityType.Curve;
                                }
                                else if (e is DBText dText)
                                {
                                    length = Math.Round(dText.Height, Round);
                                    entityType = EntityType.Text;
                                }
                                else if (e is MText mText)
                                {
                                    length = Math.Round(mText.TextHeight, Round);
                                    entityType = EntityType.Text;
                                }
                                if (e is BlockReference reference)
                                {
                                    foreach (ObjectId attrId in reference.AttributeCollection)
                                    {
                                        using (AttributeReference attRef = attrId.Open(OpenMode.ForRead, false, true) as AttributeReference)
                                        {
                                            if (attRef == null)
                                            {
                                                attRef.Close();
                                                continue;
                                            }
                                            attributes.Add(attRef.Tag);
                                            attributesVal.Add(attRef.TextString);
                                            attRef.Close();
                                        }
                                    }
                                    if (attributes.Count == 0)
                                    {
                                        attributes.Add("_none_attributed");
                                        attributesVal.Add("_none_attributed");
                                    }   
                                }
                                if (Colors.CheckData(eColor))
                                {
                                    if (!Full)
                                    {
                                        SelectedId.Add(id);
                                        e.Close();
                                        continue;
                                    }
                                }
                                else if (Full)
                                {
                                    e.Close();
                                    continue;
                                }
                                if (Layers.CheckData(eLayer))
                                {
                                    if (!Full)
                                    {
                                        SelectedId.Add(id);
                                        e.Close();
                                        continue;
                                    }
                                }
                                else if (Full)
                                {
                                    e.Close();
                                    continue;
                                }
                                if (Types.CheckData(eType))
                                {
                                    if (!Full)
                                    {
                                        SelectedId.Add(id);
                                        e.Close();
                                        continue;
                                    }
                                }
                                else if (Full)
                                {
                                    e.Close();
                                    continue;
                                }
                                if (length < 0 && attributes.Count == 0 && attributesVal.Count == 0)
                                {
                                    if (Full)
                                    {
                                        SelectedId.Add(id);
                                    }
                                    e.Close();
                                    continue;
                                }
                                else if (attributes.Count > 0 && attributesVal.Count > 0)
                                {
                                    bool norm = false;
                                    foreach (string attribute in attributes)
                                    {
                                        if (Attributes.CheckData(attribute))
                                        {
                                            ObjectData data = Attributes.GetData(attribute);
                                            foreach (string val in attributesVal)
                                            {
                                                if (data.ObjectDatas.CheckData(val))
                                                {
                                                    norm = true;
                                                    SelectedId.Add(id);
                                                    break;
                                                }
                                            }
                                        }                                      
                                        if (norm) break;
                                    }                                   
                                }                             
                                else if (length >= 0)
                                {
                                    if (entityType == EntityType.Curve && Lengths.CheckData(length))
                                    {
                                        SelectedId.Add(id);
                                    }
                                    else if (entityType == EntityType.Text && TextHeigths.CheckData(length))
                                    {
                                        SelectedId.Add(id);
                                    }
                                }
                            }
                            e?.Close();
                        }

                    }
                 
                }
                CurrentSelect = SelectedId.Count;
                Deleted = deleted;

                if (dialog != null)
                {
                    dialog.MainMessage = "Выбираем объекты";
                }
                try
                {
                    doc.Editor.SetImpliedSelection(SelectedId.ToArray());
                    if (SelectedId.Count == 0)
                    { 
                        doc.Window.Focus();                    
                    }
                }
                catch 
                {
                    System.Windows.Forms.MessageBox.Show("Объекты находятся в другом пространстве");
                    dialog?.Dispose();
                    return false;
                }
            }
            dialog?.Dispose();
            return true;
        }
        public void Update()
        {
            if (Ids.Count == 0) return;
           
            Entity entity = Ids[0].Open(OpenMode.ForRead) as Entity;
            CurrSpaceId = entity.OwnerId;
            entity.Close();            

            Colors.ClearDataCounts();
            Layers.ClearDataCounts();
            Types.ClearDataCounts();
            Attributes.ClearDataCounts();
            Lengths.ClearDataCounts();
            TextHeigths.ClearDataCounts();

            Full = Properties.Settings.Default.Full;
            Round = Properties.Settings.Default.Round;

            int deleted = 0;

            Progress.ProgressDialog dialog = null;

            int step = 0;
            int curStep = 0;

            if (Ids.Count > 3000)
            {
                dialog = new Progress.ProgressDialog();
                dialog.MainBarCount = Ids.Count;
                dialog.UseCancel = false;
                dialog.UseSubBar = false;
                dialog.MainStep = 20;
                dialog.MainMessage = "Считываем данные (" + step + " из " + Ids.Count + ")";
                dialog.Start();           
            }
            

            foreach (ObjectId id in Ids)
            {
                if (dialog != null)
                {                    
                    if (curStep == 19)
                    {
                        curStep = 0;
                        dialog.StepMainBar();
                        dialog.MainMessage = "Считываем данные (" + step + " из " + Ids.Count + ")";
                    }
                    step++;
                    curStep++;
                }
                if (id == null || id == ObjectId.Null || !id.IsValid || id.IsErased)
                {
                    deleted++;
                    continue;
                }
                using (Entity e = id.Open(OpenMode.ForRead, false, true) as Entity)
                {
                    if (e != null)
                    {
                        AddData(Colors, e.Color.ToString());
                        AddData(Layers, e.Layer.ToString());
                        AddData(Types, id.ObjectClass.Name);
                        if (e is Curve c)
                        {
                            double length = Math.Round(GetLength(c), Round);
                            AddData(Lengths, length, EntityType.Curve);
                        }
                        else if (e is DBText dText)
                        {
                            double length = Math.Round(dText.Height, Round);
                            AddData(TextHeigths, length, EntityType.Text);
                        }
                        else if (e is MText mText)
                        {
                            double length = Math.Round(mText.TextHeight, Round);
                            AddData(TextHeigths, length, EntityType.Text);
                        }
                        else if (e is BlockReference reference)
                        {
                            bool noneAttr = true;
                            foreach (ObjectId attrId in reference.AttributeCollection)
                            {
                                using (AttributeReference attRef = attrId.Open(OpenMode.ForRead, false, true) as AttributeReference)
                                {
                                    if (attRef == null)
                                    {
                                        attRef.Close();
                                        continue;
                                    }                                       
                                    AddData(Attributes, attRef.Tag, attRef.TextString, EntityType.BlockReference);                                 
                                    noneAttr = false;
                                    attRef.Close();
                                }
                            }
                            if (noneAttr)
                            {
                                AddData(Attributes, "_none_attributed");                              
                            }
                        }
                    }
                    e?.Close();
                }               
            }            

            Deleted = deleted;

            Colors.ClearData();
            Layers.ClearData();
            Types.ClearData();
            Attributes.ClearData();
            Lengths.ClearData();

            Colors.SortData();
            Layers.SortData();
            Types.SortData();
            Attributes.SortData();
            Lengths.SortData();  

            dialog?.Dispose();
        }
        private void AddData(List<ObjectData> dataList, string name, string name2, EntityType entityType)
        {
            ObjectData data = dataList.GetData(name);
            if (data == null)
            {
                data = new ObjectData(name, name2, entityType);
                dataList.Add(data);
            }
            ObjectData data2 = data.ObjectDatas.GetData(name2);
            if (data2 == null)
            {
                data2 = new ObjectData(name2);
                data.ObjectDatas.Add(data2);
            }
            data2.Count++;
            data.Count++;     
        }
        private void AddData(List<ObjectData> dataList, string name)
        {
            ObjectData data = dataList.GetData(name);
            if (data == null)
            {
                data = new ObjectData(name);
                dataList.Add(data);
            }
            data.Count++;
        }
        private void AddData(List<ObjectData> dataList, double length, EntityType entityType)
        {
            ObjectData data = dataList.GetData(length);
            if (data == null)
            {
                data = new ObjectData(length, entityType);
                dataList.Add(data);
            }
            data.Count++;
        }

        private double GetLength(Curve curve)
        {
            if (curve == null || curve.IsDisposed || curve.IsErased) return 0;
            return curve.GetDistanceAtParameter(curve.EndParam) - curve.GetDistanceAtParameter(curve.StartParam);
        }

        public int CurrentSelect { get; private set; } = 0;
        public int Deleted { get; private set; } = 0;
        public List<ObjectData> Colors { get; private set; } = new List<ObjectData>();
        public List<ObjectData> Layers { get; private set; } = new List<ObjectData>();
        public List<ObjectData> Types { get; private set; } = new List<ObjectData>();
        public List<ObjectData> Lengths { get; private set; } = new List<ObjectData>();
        public List<ObjectData> TextHeigths { get; private set; } = new List<ObjectData>();
        public List<ObjectData> Attributes { get; private set; } = new List<ObjectData>();
        public List<ObjectId> Ids { get; set; }        
        private Database CurrDb { get; set; } 
        private Document CurrDoc { get; set; }
        private ObjectId CurrSpaceId { get; set; } = ObjectId.Null;
        public bool Exist { get; private set; } = false;
        public string Name { get; private set; } = "";
        public bool Full { get; set; } = true;
        public int Round { get; set; } = 3;

    }
}
