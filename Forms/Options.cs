using System;
using System.Windows.Forms;

namespace FSProject.Forms
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            string round = Properties.Settings.Default.Round.ToString();
            if (Combo_Round.Items.Contains(round)) Combo_Round.SelectedItem = round;
            else Combo_Round.SelectedIndex = 4;
            TopMost = true;
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Combo_Round.Text, out int result))
            {
                Properties.Settings.Default.Round = result;
                Properties.Settings.Default.Save();
            }
            Close();
        }
    }
}
