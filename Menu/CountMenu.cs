using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace FSProject
{
    public class ExampleRibbon : IExtensionApplication
    {
        public void Initialize()
        {
            CountMenu.Attach();
        }
        public void Terminate()
        {
            CountMenu.Detach();
        }
    }
    public class CountMenu
    {
        private static ContextMenuExtension cmeEb;
        public static void Attach()
        {
            cmeEb = new ContextMenuExtension();      
            MenuItem mi = new MenuItem("FSCStart");
            mi.Click += new EventHandler(FSCStart);
            cmeEb.MenuItems.Add(mi);        
            RXClass rxc = Entity.GetClass(typeof(Entity));
            Application.AddObjectContextMenuExtension(rxc, cmeEb);        
        }
        public static void Detach()
        {
            RXClass rxc = Entity.GetClass(typeof(Entity));
            Application.RemoveObjectContextMenuExtension(rxc, cmeEb);
        }
        private static void FSCStart(Object o, EventArgs e)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            doc.SendStringToExecute("FSCStart ", true, false, false);
        }
    }
}
