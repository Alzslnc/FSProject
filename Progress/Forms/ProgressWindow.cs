﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Progress
{
    public partial class ProgressWindow : Form
    {
        private readonly object _lock = new object();

        public ProgressWindow(ProgressDialog dialog)
        {
            InitializeComponent();
            MainBar.Maximum = 100;
            MainBar.Minimum = 0;
            SubBar.Maximum = 100;
            SubBar.Minimum = 0;

            TopMost = true;

            this.StartPosition = FormStartPosition.Manual;
            Size screenSize = Screen.PrimaryScreen.WorkingArea.Size;
            Location = new Point(screenSize.Width / 2 - Width / 2, screenSize.Height / 2 - Height / 2);

            //проверяет требуется ли отображать дополнительный бар и управляет его видимостью


            _ProgressDialog = dialog;
            if (_ProgressDialog != null)
            {
                //получаем первичные данные
                GetData();
                //подписываемся на изменение данных
                _ProgressDialog.OnChange += this.Event;
                this.Shown += new EventHandler(OnShow);
            }
        }
        private void Event(string name)
        {
            lock (_lock)
            {
                if (name == "CloseWindow")
                {
                    Stopped = true;
                    if (this.InvokeRequired) Invoke(new Action(() => Close()));
                    else Close();
                }
                if (_ProgressDialog == null) return;
                //в зависимости от переданного имени меняем соответствующую переменную
                switch (name)
                {
                    case "SubMessage":
                        {
                            SubMessage = _ProgressDialog.SubMessage;
                            break;
                        }
                    case "MainMessage":
                        {
                            MainMessage = _ProgressDialog.MainMessage;
                            break;
                        }
                    case "MainCancelMessage":
                        {
                            MainCancelMessage = _ProgressDialog.MainCancelMessage;
                            break;
                        }
                    case "UseSubBar":
                        {
                            UseSubBar = _ProgressDialog.UseSubBar;
                            break;
                        }
                    case "UseCancel":
                        {
                            UseCancel = _ProgressDialog.UseCancel;
                            break;
                        }
                    case "MainBarValue":
                        {
                            MainBarValue = (int)_ProgressDialog.MainBarValue;
                            break;
                        }
                    case "SubBarValue":
                        {
                            SubBarValue = (int)_ProgressDialog.SubBarValue;
                            break;
                        }
                }
            }
        }
        /// <summary>
        /// обновляет элементы формы
        /// </summary>
        private void GetData()
        {
            if (_ProgressDialog != null)
            {
                if (_ProgressDialog.SubMessage != SubMessage) SubMessage = _ProgressDialog.SubMessage;
                if (_ProgressDialog.MainMessage != MainMessage) MainMessage = _ProgressDialog.MainMessage;
                if (_ProgressDialog.MainCancelMessage != MainCancelMessage) MainCancelMessage = _ProgressDialog.MainCancelMessage;
                if (_ProgressDialog.UseSubBar != UseSubBar) UseSubBar = _ProgressDialog.UseSubBar;
                if (_ProgressDialog.UseCancel != UseCancel) UseCancel = _ProgressDialog.UseCancel;
                if ((int)_ProgressDialog.MainBarValue != MainBarValue) MainBarValue = (int)_ProgressDialog.MainBarValue;
                if ((int)_ProgressDialog.SubBarValue != SubBarValue) SubBarValue = (int)_ProgressDialog.SubBarValue;               
            }
        }

        private void OnShow(object sender, EventArgs e)
        {
            this.Shown -= new EventHandler(OnShow);
            CheckSubBar();
            CheckCancel();
        }
        /// <summary>
        /// использовать второй бар?
        /// </summary>
        public bool UseSubBar
        {
            get => _useSubBar;
            set 
            {           
                _useSubBar = value;
                CheckSubBar();
            }            
        }
        public bool UseCancel
        {
            get => _useCancel;
            set
            {
                _useCancel = value;
                CheckCancel();
            }
        }
        /// <summary>
        /// текст над первым баром
        /// </summary>
        public string MainMessage
        {
            get => _MainMessage;
            set
            {              
                _MainMessage = value;
                if (MainMessageLabel.InvokeRequired) MainMessageLabel.Invoke(new Action(() => MainMessageLabel.Text = _MainMessage));
                else MainMessageLabel.Text = _MainMessage;            
            }           
        }
        /// <summary>
        /// текст над вторым баром
        /// </summary>
        public string SubMessage
        {
            get => _SubMessage;
            set
            {             
                _SubMessage = value;
                if (SubMessageLabel.InvokeRequired) SubMessageLabel.Invoke(new Action(() => SubMessageLabel.Text = _SubMessage));
                else SubMessageLabel.Text = _SubMessage;
            }
        }
        /// <summary>
        /// текст при отмене
        /// </summary>
        public string MainCancelMessage
        {
            get => _MainCancelMessage;
            set 
            {             
                _MainCancelMessage = value;             
            }
        }
        /// <summary>
        /// счетчик первого бара
        /// </summary>
        public int MainBarValue
        {
            get => _MainBarValue;
            set
            {      
                if (value > 100) _MainBarValue = 100;
                else if (value < 0) _MainBarValue = 0;
                else _MainBarValue = value;

                if (MainBar.InvokeRequired) MainBar.Invoke(new Action(() => MainBar.Value = _MainBarValue));
                else MainBar.Value = _MainBarValue;       
            }
        }
        /// <summary>
        /// счетчик второго бара
        /// </summary>
        public int SubBarValue
        {
            get => _SubBarValue;
            set
            {              
                if (value > 100) _SubBarValue = 100;
                else if (value < 0) _SubBarValue = 0;
                else _SubBarValue = value;
                if (SubBar.InvokeRequired) SubBar.Invoke(new Action(() => SubBar.Value = _SubBarValue));
                else SubBar.Value = _SubBarValue;         
            }
        }
      
        /// <summary>
        /// проверяет и настраивает элементы
        /// </summary>
        private void CheckSubBar()
        {        
            if (_useSubBar)
            {
                if (!this.SubMessageLabel.Visible)
                {
                    if (this.SubMessageLabel.InvokeRequired)
                    {
                        SubMessageLabel.Invoke(new Action(() => this.SubMessageLabel.Visible = true));
                    }
                    else this.SubMessageLabel.Visible = true;

                    if (this.InvokeRequired) this.Invoke(new Action(() => this.Height += 90));
                    else this.Height += 90;
                }
                if (!this.SubBar.Visible)
                {
                    if (this.SubBar.InvokeRequired)
                    {
                        SubBar.Invoke(new Action(() => this.SubBar.Visible = true));
                    }
                    else this.SubBar.Visible = true;
                }       
            }
            else
            {
                if (this.SubMessageLabel.Visible)
                {
                    if (this.SubMessageLabel.InvokeRequired)
                    {
                        SubMessageLabel.Invoke(new Action(() => this.SubMessageLabel.Visible = false));
                    }
                    else this.SubMessageLabel.Visible = false;

                    if (this.InvokeRequired) this.Invoke(new Action(() => this.Height -= 90));
                    else this.Height -= 90;
                }
                if (this.SubBar.Visible)
                {
                    if (this.SubBar.InvokeRequired)
                    {
                        SubBar.Invoke(new Action(() => this.SubBar.Visible = false));
                    }
                    else this.SubBar.Visible = false;
                }
            }
        }
        private void CheckCancel()
        {
            if (_useCancel)
            {               
                if (!Cancel.Visible)
                {
                    if (Cancel.InvokeRequired)
                    {
                        Cancel.Invoke(new Action(() => Cancel.Visible = true));
                    }
                    else Cancel.Visible = true;

                    if (this.InvokeRequired) this.Invoke(new Action(() => this.Height += 50));
                    else this.Height += 50;
                }
            }
            else
            {             
                if (Cancel.Visible)
                {
                    if (Cancel.InvokeRequired)
                    {
                        Cancel.Invoke(new Action(() => this.Cancel.Visible = false));
                    }
                    else Cancel.Visible = false;

                    if (this.InvokeRequired) this.Invoke(new Action(() => this.Height -= 50));
                    else this.Height -= 50;
                }
            }
        }

        private int _MainBarValue = 0;
        private int _SubBarValue = 0;
        private readonly ProgressDialog _ProgressDialog = null;
        private bool _useSubBar = true;
        private bool _useCancel = true;
        private string _MainMessage = string.Empty;
        private string _SubMessage = string.Empty;
        private string _MainCancelMessage = "Идет отмена";
        private bool Stopped = false;

        private void Cancel_Click(object sender, System.EventArgs e)
        {
            _ProgressDialog.IsStopNeed = true;
            Cancel.Enabled = false;
            Cancel.Text = MainCancelMessage;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, new Rectangle(1, 1, this.Width - 2, this.Height - 2), Color.Black, ButtonBorderStyle.Solid);
        }

    }   
}
