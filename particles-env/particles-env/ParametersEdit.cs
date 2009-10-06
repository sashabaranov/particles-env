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
        Image ExpirementPicture;
        String Description;

        public ParameterList eList;
        #endregion


        public ParametersEdit()
        {
            InitializeComponent();
        }

        private void ParametersEdit_Load(object sender, EventArgs e)
        {
            //передаём данные
            pictureBox1.Image = this.ExpirementPicture;
            eDescription.Text = this.Description;


            int _top = 150;
            //Создаём контроллы
            foreach (ParameterListUnit Unit in eList.Parameters)
            {
                ParameterControl c = new ParameterControl(EditingType.TextBox, Unit);
                c.Left = 0;
                c.Top = _top;
                _top += c.Height;

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
    
    }
}