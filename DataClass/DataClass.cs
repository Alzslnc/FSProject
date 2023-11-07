using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSProject
{
    public class DataClass
    {
        public DataClass(List<ObjectId> ids)
        { 
            Ids = ids;
            CurrDb = HostApplicationServices.WorkingDatabase;
            CurrDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            GetBase();
        }
        
        public void SelectSelected()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            if (doc == null) return;
            if (doc != CurrDoc) return;
            using (doc.LockDocument())
            { 
                List<ObjectId> SelectedId = new List<ObjectId>();
                if (HostApplicationServices.WorkingDatabase == CurrDb)
                {
                    using (Transaction tr = HostApplicationServices.WorkingDatabase.TransactionManager.StartTransaction())
                    {                        
                        foreach (ObjectId id in Ids)
                        {
                            if (id == null || id == ObjectId.Null || !id.IsValid || id.IsErased) continue;
                            using (Entity e = tr.GetObject(id, OpenMode.ForRead, false, true) as Entity)
                            {
                                if (e != null)
                                {
                                    string eColor = e.Color.ToString();
                                    string eLayer = e.Layer.ToString();
                                    string eType = id.ObjectClass.Name;
                                    string eLength = string.Empty;
                                    if (e is Curve c)
                                    {
                                        double length = GetLength(c);
                                        eLength = length.ToString("F3");                              
                                    }
                                    if (SelectedColors.Contains(eColor))
                                    {
                                        if (!Full)
                                        {
                                            SelectedId.Add(id);
                                            continue;
                                        }
                                    }
                                    else if (Full) continue;
                                    if (SelectedLayers.Contains(eLayer))
                                    {
                                        if (!Full)
                                        {
                                            SelectedId.Add(id);
                                            continue;
                                        }
                                    }
                                    else if (Full) continue;
                                    if (SelectedTypes.Contains(eType))
                                    {
                                        if (!Full)
                                        {
                                            SelectedId.Add(id);
                                            continue;
                                        }
                                    }
                                    else if (Full) continue;
                                    if (string.IsNullOrEmpty(eLength))
                                    {
                                        if (Full)
                                        {
                                            SelectedId.Add(id);
                                        }
                                        continue;
                                    }
                                    else
                                    {
                                        if (SelectedLengths.Contains(eLength))
                                        {
                                            SelectedId.Add(id);
                                        }
                                    }

                                }
                            
                            }
                        }
                    }
                }
                CurrentSelect = SelectedId.Count;
                doc.Editor.SetImpliedSelection(SelectedId.ToArray());
            }
        }
        private void GetBase()
        {
            Full = Properties.Settings.Default.Full;

            using (Transaction tr = HostApplicationServices.WorkingDatabase.TransactionManager.StartTransaction())
            {
                foreach (ObjectId id in Ids)
                {
                    if (id == null || id == ObjectId.Null || !id.IsValid || id.IsErased) continue;
                    using (Entity e = tr.GetObject(id, OpenMode.ForRead, false, true) as Entity)
                    {
                        if (e != null)
                        {
                            if (!AllColors.Contains(e.Color.ToString())) AllColors.Add(e.Color.ToString());
                            if (!AllLayers.Contains(e.Layer)) AllLayers.Add(e.Layer);                         
                            if (!AllTypes.Contains(id.ObjectClass.Name)) AllTypes.Add(id.ObjectClass.Name);
                            if (e is Curve c)
                            { 
                                double length = GetLength(c);
                                string lengthString = length.ToString("F3");
                                if (!AllLengths.Contains(lengthString)) AllLengths.Add(lengthString);
                            }
                        }

                    }
                }
            }
        }
        private double GetLength(Curve curve)
        {
            if (curve == null || curve.IsDisposed || curve.IsErased) return 0;
            return curve.GetDistanceAtParameter(curve.EndParam) - curve.GetDistanceAtParameter(curve.StartParam);
        }
        public int CurrentSelect { get; private set; } = 0;
        public List<string> AllColors { get; private set; } = new List<string>();
        public List<string> AllLayers { get; private set; } = new List<string>();
        public List<string> AllTypes { get; private set; } = new List<string>();
        public List<string> AllLengths { get; private set; } = new List<string>();
        public List<string> SelectedColors { get; set; } = new List<string>();
        public List<string> SelectedLayers { get; set; } = new List<string>();
        public List<string> SelectedTypes { get; set; } = new List<string>();
        public List<string> SelectedLengths { get; set; } = new List<string>();
        public List<ObjectId> Ids { get; set; }        
        private Database CurrDb { get; set; } 
        private Document CurrDoc { get; set; }
        public bool Full { get; set; } = true;
    }
}
