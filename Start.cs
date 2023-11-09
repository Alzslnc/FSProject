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
            ObjectsPanel panel = new ObjectsPanel();
            panel.Show();
        }
    }
}
