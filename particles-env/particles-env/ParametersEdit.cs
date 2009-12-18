using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDK;

namespace particles_env
{
    public partial class ParametersEdit : Form
    {
        #region Данные из внешнего мира
        public Image ExperimentPicture;
        public String Description;

        public ParameterList eList;

        #endregion


        public ParametersEdit()
        {
            InitializeComponent();
        }

        private void ParametersEdit_Load(object sender, EventArgs e)
        {
            //передаём данные
            pictureBox1.Image = this.ExperimentPicture;
            eDescription.Text = this.Description;


            int _top = 150;
            int _left = 0;
            
            //Создаём контроллы
            for(int i = 0; i< eList.Parameters.Count; i++)
            {
                ParameterControl c = new ParameterControl(EditingType.TextBox, eList.Parameters[i]);


                c.Left = _left;
                c.Top = _top;

                if ((i+1) % 2 == 0)
                {
                    _top += c.Height;
                    _left -= c.Width + 20;

                }
                else
                {
                    _left += c.Width + 20;
                }


                
                Controls.Add(c);
            }

            
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().ToString().Contains("ParameterControl"))
                {
                    ParameterControl a = (ParameterControl)c;
                    eList[a.Unit.sName] = a.Value;
                }
            }
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void d_values_button_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().ToString().Contains("ParameterControl"))
                {
                    ParameterControl a = (ParameterControl)c;
                    a.Value = a.Unit.dValue;
                }
            }
        }
    
    }
}