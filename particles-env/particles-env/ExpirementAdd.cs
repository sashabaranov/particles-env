using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace particles_env
{
    using Expirement;
    using ObjectGraphics;

    public partial class ExpirementAdd : Form
    {
        /// <summary>
        /// Объект, который будем возвращать.
        /// </summary>
        public Expirement ExpirementObject;

        public ExpirementAdd(ExpirementList e)
        {
            InitializeComponent();

            foreach (ExpirementInfo p in e.eList)
            {
                listBox1.Items.Add(p);
            }
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConstructExpirement();

            ParametersEdit EditDialog = new ParametersEdit();
            EditDialog.eList = ExpirementObject.Graphics.ParameterListTemplate;
            EditDialog.ShowDialog();
            
        }

        private void ExpirementAdd_Load(object sender, EventArgs e)
        {
            
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConstructExpirement();
        }

        private void ConstructExpirement()
        {
            ExpirementObject = new Expirement();
            ExpirementInfo Selected = (ExpirementInfo) listBox1.SelectedItem;
            ExpirementObject.Graphics = Selected.GraphicsObj;
        }
    }
}