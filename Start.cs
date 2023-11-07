using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using FSProject.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSProject
{
    public class Start
    {
        [CommandMethod("FSCStart", CommandFlags.UsePickSet | CommandFlags.Modal | CommandFlags.Redraw)]
        public void FSCStart()
        {
            List<ObjectId> ids = new List<ObjectId>();
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            PromptSelectionResult psr = ed.SelectImplied();
            if (psr.Value != null) ids.AddRange(psr.Value.GetObjectIds());
            if (ids.Count == 0) return;
            DataClass data = new DataClass(ids);
            ObjectsPanel panel = new ObjectsPanel(data);
            panel.Show();
        }
    }
}
