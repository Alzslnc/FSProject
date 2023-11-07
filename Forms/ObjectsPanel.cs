using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FSProject.Forms
{
    public partial class ObjectsPanel : Form
    {
        private DataClass Data { get; set; }
        private bool blockEvents { get; set; } = false;

        public ObjectsPanel(DataClass data)
        {
            InitializeComponent();
            Data = data;
            this.TopMost = true;
            CreateObjects();
        }


        private void CreateObjects()
        { 
            Label_All.Text = Data.Ids.Count.ToString();
            Label_Current.Text = Data.Ids.Count.ToString();
            CreateObjectInPanel(Panel_Color, Data.AllColors);
            CreateObjectInPanel(Panel_Layer, Data.AllLayers);
            CreateObjectInPanel(Panel_Type, Data.AllTypes);
            CreateObjectInPanel(Panel_Length, Data.AllLengths);
            Check_Full.Checked = Data.Full;
        }
        private void CreateObjectInPanel(Panel panel, List<string> names)
        { 
            int i = 2;
            foreach (string name in names)
            {
                CheckBox checkBox = new CheckBox
                {
                    Text = name,
                    Width = 141,
                    Left = 6,
                    Top = i * 26,
                };
                checkBox.CheckedChanged += new EventHandler(ChangeObject);
                panel.Controls.Add(checkBox);   
                i++;
            }        
        }
        private void ChangeObject(Object sender, EventArgs e)
        {
            if (blockEvents) return;
            if (Data == null) return;
            if (!(sender is CheckBox box)) return;
            if (box.Parent is Panel panel) ChangeObject(panel);     
        }
        private void ChangeObject(Panel Panel)
        {
            string name = string.Empty;
            List<string> selectedObject = new List<string>();
            foreach (Control control in Panel.Controls)
            {               
                if (control is CheckBox checkBox && checkBox.Checked) selectedObject.Add(checkBox.Text);
                else if (control is Label l) name = l.Text;
            }
            switch (name)
            {
                case "Color":
                    {
                        Data.SelectedColors = selectedObject;
                        break;
                    }
                case "Layer":
                    {
                        Data.SelectedLayers = selectedObject;
                        break;
                    }
                case "Type":
                    {
                        Data.SelectedTypes = selectedObject;
                        break;
                    }
                case "Length":
                    {
                        Data.SelectedLengths = selectedObject;
                        break;
                    }
                default: return;
            }
            Data.SelectSelected();
            Label_Current.Text = Data.CurrentSelect.ToString();
        }  
        private void Check_All_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is CheckBox box)) return;
            if (!(box.Parent is Panel panel)) return;
            blockEvents = true;
            foreach (Control control in panel.Controls)
            {
                if (control is CheckBox checkBox && checkBox != box) checkBox.Checked = box.Checked;
            }
            blockEvents = false;
            ChangeObject(panel);
        }    
        private void Check_Full_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Full = Check_Full.Checked;
            Properties.Settings.Default.Save();
            Data.Full = Check_Full.Checked;
            Data.SelectSelected();
            Label_Current.Text = Data.CurrentSelect.ToString();
        }

    }
}
