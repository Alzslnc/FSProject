namespace FSProject.Forms
{
    partial class ObjectsPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel_Color = new System.Windows.Forms.Panel();
            this.Check_AllColors = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Panel_Layer = new System.Windows.Forms.Panel();
            this.Check_AllLayers = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Panel_Type = new System.Windows.Forms.Panel();
            this.Check_AllTypes = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Panel_Length = new System.Windows.Forms.Panel();
            this.Check_AllLengths = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Label_All = new System.Windows.Forms.Label();
            this.Label_Current = new System.Windows.Forms.Label();
            this.Check_Full = new System.Windows.Forms.CheckBox();
            this.Panel_All = new System.Windows.Forms.Panel();
            this.Sets = new System.Windows.Forms.Label();
            this.Check_Auto = new System.Windows.Forms.CheckBox();
            this.Button_Update = new System.Windows.Forms.Button();
            this.Button_NewSet = new System.Windows.Forms.Button();
            this.Button_Options = new System.Windows.Forms.Button();
            this.Panel_Attributes = new System.Windows.Forms.Panel();
            this.Check_AllAttributes = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Button_FullUpdate = new System.Windows.Forms.Button();
            this.Label_Deleted = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Panel_Color.SuspendLayout();
            this.Panel_Layer.SuspendLayout();
            this.Panel_Type.SuspendLayout();
            this.Panel_Length.SuspendLayout();
            this.Panel_All.SuspendLayout();
            this.Panel_Attributes.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Color
            // 
            this.Panel_Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel_Color.Controls.Add(this.Check_AllColors);
            this.Panel_Color.Controls.Add(this.label1);
            this.Panel_Color.Location = new System.Drawing.Point(122, 52);
            this.Panel_Color.Name = "Panel_Color";
            this.Panel_Color.Size = new System.Drawing.Size(270, 150);
            this.Panel_Color.TabIndex = 0;
            // 
            // Check_AllColors
            // 
            this.Check_AllColors.AutoSize = true;
            this.Check_AllColors.Checked = true;
            this.Check_AllColors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Check_AllColors.Location = new System.Drawing.Point(6, 19);
            this.Check_AllColors.Name = "Check_AllColors";
            this.Check_AllColors.Size = new System.Drawing.Size(44, 20);
            this.Check_AllColors.TabIndex = 1;
            this.Check_AllColors.Text = "All";
            this.Check_AllColors.UseVisualStyleBackColor = true;
            this.Check_AllColors.CheckedChanged += new System.EventHandler(this.Check_All_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color";
            // 
            // Panel_Layer
            // 
            this.Panel_Layer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel_Layer.Controls.Add(this.Check_AllLayers);
            this.Panel_Layer.Controls.Add(this.label2);
            this.Panel_Layer.Location = new System.Drawing.Point(122, 208);
            this.Panel_Layer.Name = "Panel_Layer";
            this.Panel_Layer.Size = new System.Drawing.Size(270, 150);
            this.Panel_Layer.TabIndex = 1;
            // 
            // Check_AllLayers
            // 
            this.Check_AllLayers.AutoSize = true;
            this.Check_AllLayers.Checked = true;
            this.Check_AllLayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Check_AllLayers.Location = new System.Drawing.Point(6, 19);
            this.Check_AllLayers.Name = "Check_AllLayers";
            this.Check_AllLayers.Size = new System.Drawing.Size(44, 20);
            this.Check_AllLayers.TabIndex = 2;
            this.Check_AllLayers.Text = "All";
            this.Check_AllLayers.UseVisualStyleBackColor = true;
            this.Check_AllLayers.CheckedChanged += new System.EventHandler(this.Check_All_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Layer";
            // 
            // Panel_Type
            // 
            this.Panel_Type.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel_Type.Controls.Add(this.Check_AllTypes);
            this.Panel_Type.Controls.Add(this.label3);
            this.Panel_Type.Location = new System.Drawing.Point(122, 364);
            this.Panel_Type.Name = "Panel_Type";
            this.Panel_Type.Size = new System.Drawing.Size(270, 150);
            this.Panel_Type.TabIndex = 1;
            // 
            // Check_AllTypes
            // 
            this.Check_AllTypes.AutoSize = true;
            this.Check_AllTypes.Checked = true;
            this.Check_AllTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Check_AllTypes.Location = new System.Drawing.Point(6, 19);
            this.Check_AllTypes.Name = "Check_AllTypes";
            this.Check_AllTypes.Size = new System.Drawing.Size(44, 20);
            this.Check_AllTypes.TabIndex = 3;
            this.Check_AllTypes.Text = "All";
            this.Check_AllTypes.UseVisualStyleBackColor = true;
            this.Check_AllTypes.CheckedChanged += new System.EventHandler(this.Check_All_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Type";
            // 
            // Panel_Length
            // 
            this.Panel_Length.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel_Length.Controls.Add(this.Check_AllLengths);
            this.Panel_Length.Controls.Add(this.label4);
            this.Panel_Length.Location = new System.Drawing.Point(398, 52);
            this.Panel_Length.Name = "Panel_Length";
            this.Panel_Length.Size = new System.Drawing.Size(270, 150);
            this.Panel_Length.TabIndex = 2;
            // 
            // Check_AllLengths
            // 
            this.Check_AllLengths.AutoSize = true;
            this.Check_AllLengths.Checked = true;
            this.Check_AllLengths.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Check_AllLengths.Location = new System.Drawing.Point(6, 19);
            this.Check_AllLengths.Name = "Check_AllLengths";
            this.Check_AllLengths.Size = new System.Drawing.Size(44, 20);
            this.Check_AllLengths.TabIndex = 4;
            this.Check_AllLengths.Text = "All";
            this.Check_AllLengths.UseVisualStyleBackColor = true;
            this.Check_AllLengths.CheckedChanged += new System.EventHandler(this.Check_All_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Length";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Всего  -";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Выбрано  -";
            // 
            // Label_All
            // 
            this.Label_All.AutoSize = true;
            this.Label_All.Location = new System.Drawing.Point(87, 9);
            this.Label_All.Name = "Label_All";
            this.Label_All.Size = new System.Drawing.Size(14, 16);
            this.Label_All.TabIndex = 5;
            this.Label_All.Text = "0";
            // 
            // Label_Current
            // 
            this.Label_Current.AutoSize = true;
            this.Label_Current.Location = new System.Drawing.Point(87, 30);
            this.Label_Current.Name = "Label_Current";
            this.Label_Current.Size = new System.Drawing.Size(14, 16);
            this.Label_Current.TabIndex = 6;
            this.Label_Current.Text = "0";
            // 
            // Check_Full
            // 
            this.Check_Full.AutoSize = true;
            this.Check_Full.Location = new System.Drawing.Point(134, 5);
            this.Check_Full.Name = "Check_Full";
            this.Check_Full.Size = new System.Drawing.Size(173, 20);
            this.Check_Full.TabIndex = 7;
            this.Check_Full.Text = "Полное соответствие";
            this.Check_Full.UseVisualStyleBackColor = true;
            this.Check_Full.CheckedChanged += new System.EventHandler(this.Check_Full_CheckedChanged);
            // 
            // Panel_All
            // 
            this.Panel_All.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel_All.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel_All.Controls.Add(this.Sets);
            this.Panel_All.Location = new System.Drawing.Point(12, 52);
            this.Panel_All.Name = "Panel_All";
            this.Panel_All.Size = new System.Drawing.Size(104, 477);
            this.Panel_All.TabIndex = 2;
            // 
            // Sets
            // 
            this.Sets.AutoSize = true;
            this.Sets.Location = new System.Drawing.Point(3, 0);
            this.Sets.Name = "Sets";
            this.Sets.Size = new System.Drawing.Size(34, 16);
            this.Sets.TabIndex = 0;
            this.Sets.Text = "Sets";
            // 
            // Check_Auto
            // 
            this.Check_Auto.AutoSize = true;
            this.Check_Auto.Location = new System.Drawing.Point(313, 5);
            this.Check_Auto.Name = "Check_Auto";
            this.Check_Auto.Size = new System.Drawing.Size(56, 20);
            this.Check_Auto.TabIndex = 8;
            this.Check_Auto.Text = "Auto";
            this.Check_Auto.UseVisualStyleBackColor = true;
            this.Check_Auto.CheckedChanged += new System.EventHandler(this.Check_Auto_CheckedChanged);
            // 
            // Button_Update
            // 
            this.Button_Update.Location = new System.Drawing.Point(375, 9);
            this.Button_Update.Name = "Button_Update";
            this.Button_Update.Size = new System.Drawing.Size(66, 34);
            this.Button_Update.TabIndex = 9;
            this.Button_Update.Text = "Select";
            this.Button_Update.UseVisualStyleBackColor = true;
            this.Button_Update.Click += new System.EventHandler(this.Button_Update_Click);
            // 
            // Button_NewSet
            // 
            this.Button_NewSet.Location = new System.Drawing.Point(532, 9);
            this.Button_NewSet.Name = "Button_NewSet";
            this.Button_NewSet.Size = new System.Drawing.Size(66, 34);
            this.Button_NewSet.TabIndex = 10;
            this.Button_NewSet.Text = "NewSet";
            this.Button_NewSet.UseVisualStyleBackColor = true;
            this.Button_NewSet.Click += new System.EventHandler(this.Button_NewSet_Click);
            // 
            // Button_Options
            // 
            this.Button_Options.Location = new System.Drawing.Point(604, 9);
            this.Button_Options.Name = "Button_Options";
            this.Button_Options.Size = new System.Drawing.Size(66, 34);
            this.Button_Options.TabIndex = 11;
            this.Button_Options.Text = "Options";
            this.Button_Options.UseVisualStyleBackColor = true;
            this.Button_Options.Click += new System.EventHandler(this.Button_Options_Click);
            // 
            // Panel_Attributes
            // 
            this.Panel_Attributes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel_Attributes.Controls.Add(this.Check_AllAttributes);
            this.Panel_Attributes.Controls.Add(this.label8);
            this.Panel_Attributes.Location = new System.Drawing.Point(398, 208);
            this.Panel_Attributes.Name = "Panel_Attributes";
            this.Panel_Attributes.Size = new System.Drawing.Size(270, 150);
            this.Panel_Attributes.TabIndex = 5;
            // 
            // Check_AllAttributes
            // 
            this.Check_AllAttributes.AutoSize = true;
            this.Check_AllAttributes.Checked = true;
            this.Check_AllAttributes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Check_AllAttributes.Location = new System.Drawing.Point(6, 19);
            this.Check_AllAttributes.Name = "Check_AllAttributes";
            this.Check_AllAttributes.Size = new System.Drawing.Size(44, 20);
            this.Check_AllAttributes.TabIndex = 4;
            this.Check_AllAttributes.Text = "All";
            this.Check_AllAttributes.UseVisualStyleBackColor = true;
            this.Check_AllAttributes.CheckedChanged += new System.EventHandler(this.Check_All_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Attribute";
            // 
            // Button_FullUpdate
            // 
            this.Button_FullUpdate.Location = new System.Drawing.Point(447, 9);
            this.Button_FullUpdate.Name = "Button_FullUpdate";
            this.Button_FullUpdate.Size = new System.Drawing.Size(79, 34);
            this.Button_FullUpdate.TabIndex = 12;
            this.Button_FullUpdate.Text = "Update";
            this.Button_FullUpdate.UseVisualStyleBackColor = true;
            this.Button_FullUpdate.Click += new System.EventHandler(this.Button_FullUpdate_Click);
            // 
            // Label_Deleted
            // 
            this.Label_Deleted.AutoSize = true;
            this.Label_Deleted.Location = new System.Drawing.Point(228, 30);
            this.Label_Deleted.Name = "Label_Deleted";
            this.Label_Deleted.Size = new System.Drawing.Size(14, 16);
            this.Label_Deleted.TabIndex = 14;
            this.Label_Deleted.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(131, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "Удаленные  -";
            // 
            // ObjectsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 538);
            this.Controls.Add(this.Label_Deleted);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Button_FullUpdate);
            this.Controls.Add(this.Panel_Attributes);
            this.Controls.Add(this.Button_Options);
            this.Controls.Add(this.Button_NewSet);
            this.Controls.Add(this.Button_Update);
            this.Controls.Add(this.Check_Auto);
            this.Controls.Add(this.Panel_All);
            this.Controls.Add(this.Check_Full);
            this.Controls.Add(this.Label_Current);
            this.Controls.Add(this.Panel_Length);
            this.Controls.Add(this.Label_All);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Panel_Type);
            this.Controls.Add(this.Panel_Layer);
            this.Controls.Add(this.Panel_Color);
            this.MinimumSize = new System.Drawing.Size(700, 585);
            this.Name = "ObjectsPanel";
            this.Text = "Panel";
            this.Panel_Color.ResumeLayout(false);
            this.Panel_Color.PerformLayout();
            this.Panel_Layer.ResumeLayout(false);
            this.Panel_Layer.PerformLayout();
            this.Panel_Type.ResumeLayout(false);
            this.Panel_Type.PerformLayout();
            this.Panel_Length.ResumeLayout(false);
            this.Panel_Length.PerformLayout();
            this.Panel_All.ResumeLayout(false);
            this.Panel_All.PerformLayout();
            this.Panel_Attributes.ResumeLayout(false);
            this.Panel_Attributes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Color;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Panel_Layer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel Panel_Type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel Panel_Length;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Label_All;
        private System.Windows.Forms.Label Label_Current;
        private System.Windows.Forms.CheckBox Check_AllColors;
        private System.Windows.Forms.CheckBox Check_AllLayers;
        private System.Windows.Forms.CheckBox Check_AllTypes;
        private System.Windows.Forms.CheckBox Check_AllLengths;
        private System.Windows.Forms.CheckBox Check_Full;
        private System.Windows.Forms.Panel Panel_All;
        private System.Windows.Forms.Label Sets;
        private System.Windows.Forms.CheckBox Check_Auto;
        private System.Windows.Forms.Button Button_Update;
        private System.Windows.Forms.Button Button_NewSet;
        private System.Windows.Forms.Button Button_Options;
        private System.Windows.Forms.Panel Panel_Attributes;
        private System.Windows.Forms.CheckBox Check_AllAttributes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Button_FullUpdate;
        private System.Windows.Forms.Label Label_Deleted;
        private System.Windows.Forms.Label label9;
    }
}