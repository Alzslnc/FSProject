using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FSProject.Forms
{
    public partial class ObjectsPanel : Form
    {
        private DataClassList DataClassList { get; set; } = new DataClassList();
        private DataClass Data { get; set; }
        private bool BlockEvents { get; set; } = false;
        private bool AllCheckLock { get; set; } = false;

        public ObjectsPanel()
        {
            InitializeComponent();
            AddNewData();         
            this.TopMost = true;
            CreateObjects();
            Panel_All.VerticalScroll.Enabled = true;
            Panel_All.VerticalScroll.Visible = true;
            Check_Full.Checked = Properties.Settings.Default.Full;
            Check_Auto.Checked = Properties.Settings.Default.Auto;
        }

        private void CreateObjects()
        { 
            Label_All.Text = Data.Ids.Count.ToString();
            Label_Current.Text = Data.Ids.Count.ToString();
            CreateObjectInPanel(Panel_Color, Data.Colors);
            CreateObjectInPanel(Panel_Layer, Data.Layers);
            CreateObjectInPanel(Panel_Type, Data.Types);
            CreateObjectInPanel(Panel_Length, Data.Lengths);
            CreateObjectInPanel(Panel_Attributes, Data.Attributes);
            Check_Full.Checked = Data.Full;
        }
        private void CreateObjectInPanel(Panel panel, List<ObjectData> datas)
        {
            for (int j = panel.Controls.Count - 1; j > 1; j--)
            {
                panel.Controls[j]?.Dispose();                            
            }
            int round = Data.Round;
            int i = 2;
            foreach (ObjectData data in datas)
            {
                CheckBox checkBox = new CheckBox
                {
                    AutoSize = false,
                    Width = panel.Width - 87,
                    Height = 20,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                    Left = 6,
                    Top = i * 26,
                    Checked = data.Check,
                };
                if (data.EntityType == EntityType.Curve) checkBox.Text = data.Length.ToString("F" + round);
                else if (data.EntityType == EntityType.none) checkBox.Text = data.Name;
                Label label = new Label
                {
                    Left = 210,
                    Width = 48,
                    Top = i * 26,
                    Anchor = AnchorStyles.Right | AnchorStyles.Top,
                    Text = data.Count.ToString(),
                    AutoSize = false,
                    TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                };
                int pw = panel.Width;
                int lw = label.Left;
                checkBox.CheckedChanged += new EventHandler(ChangeObject);
                panel.Controls.Add(checkBox);
                panel.Controls.Add(label);
                i++;
            }
            if (i > 5)
            { 
                panel.VerticalScroll.Enabled = true;
                panel.VerticalScroll.Visible = true;            
            }
        }
        private void ChangeObject(Object sender, EventArgs e)
        {         
            if (BlockEvents) return;
            if (Data == null) return;
            if (!(sender is CheckBox box)) return;
            if (!(box.Parent is Panel panel)) return;
            bool allCleck = true;
            for (int i = 2; i < panel.Controls.Count; i++)
            {
                if (panel.Controls[i] is CheckBox b && !b.Checked)
                { 
                    allCleck = false;
                    break;
                }
            }
            if (panel.Controls[0] is CheckBox allBox && allBox.Checked != allCleck)
            {
                AllCheckLock = true;
                allBox.Checked = allCleck;
                AllCheckLock = false;
            }
                       
            ChangeObject(panel);     
        }
        private void ChangeObject(Panel Panel)
        {
            string name = "";
            if (Panel.Controls.Count > 2 && Panel.Controls[1] is Label label)
            {
                name = label.Text;
            }
            List<string> selectedObject = new List<string>();
            foreach (Control control in Panel.Controls)
            {               
                if (control is CheckBox checkBox && checkBox.Checked) selectedObject.Add(checkBox.Text);           
            }
            switch (name)
            {
                case "Color":
                    {
                        Data.Colors.CheckChange(selectedObject);
                        break;
                    }
                case "Layer":
                    {
                        Data.Layers.CheckChange(selectedObject);                   
                        break;
                    }
                case "Type":
                    {
                        Data.Types.CheckChange(selectedObject);                     
                        break;
                    }
                case "Length":
                    {
                        Data.Lengths.CheckChange(selectedObject);                      
                        break;
                    }
                case "Attribute":
                    {
                        Data.Attributes.CheckChange(selectedObject);                   
                        break;
                    }
                default: return;
            }
            UpdateSelected();
        }  
        private void Check_All_CheckedChanged(object sender, EventArgs e)
        {
            if (AllCheckLock) return;
            if (!(sender is CheckBox box)) return;
            if (!(box.Parent is Panel panel)) return;
            bool curBlockEvent = BlockEvents;
            BlockEvents = true;
            foreach (Control control in panel.Controls)
            {
                if (control is CheckBox checkBox && checkBox != box) checkBox.Checked = box.Checked;
            }
            BlockEvents = curBlockEvent;
            ChangeObject(panel);
        }    
        private void Check_Full_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Full = Check_Full.Checked;
            Properties.Settings.Default.Save();
            Data.Full = Check_Full.Checked;
            UpdateSelected();
        }
        private void Check_Auto_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Auto = Check_Auto.Checked;
            Properties.Settings.Default.Save();
            BlockEvents = !Check_Auto.Checked;
        }
        private void Button_Update_Click(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (!(control is Panel panel)) continue;
                ChangeObject(panel);
            }
            UpdateSelected();
        }
        private void Button_NewSet_Click(object sender, EventArgs e)
        {
            AddNewData();
            CreateObjects();
        }
        private void Radio_Change_Click(object sender, EventArgs e)
        {
            if (!(sender is RadioButton radio)) return;
            if (!radio.Checked) return;
            DataClass data = DataClassList.GetData(radio.Text);
            if (data == null) return;
            Data = data;
            CreateObjects();
            UpdateSelected();
        }
        private void UpdateSelected()
        {          
            Data.SelectSelected();
            Label_Current.Text = Data.CurrentSelect.ToString();
            Label_Deleted.Text = Data.Deleted.ToString();
        }
        private void AddNewData()
        {
            DataClass data = DataClassList.AddNewData();
            if (data != null)
            {
                foreach (Control control in Panel_All.Controls)
                {
                    if (control is RadioButton r) r.Checked = false;                
                }
                Data = data;
                int i = 1;
                foreach (Control control in Panel_All.Controls)
                {
                    if (control is RadioButton) i++;                
                }
                RadioButton radio = new RadioButton()
                {
                    Text = Data.Name,
                    Left = 6,
                    Top = i * 28,
                    Checked = true,
                };
                radio.CheckedChanged += new EventHandler(Radio_Change_Click);
                Panel_All.Controls.Add(radio);              
                CreateObjects();
                UpdateSelected();
            }
            else
            {
                MessageBox.Show("Не удалось создать новый набор");
            }
        }
        private void Button_FullUpdate_Click(object sender, EventArgs e)
        {
            Data.Update();
            CreateObjects();
            UpdateSelected();
        }
        private void Button_Options_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.ShowDialog();
        }
    }
}
