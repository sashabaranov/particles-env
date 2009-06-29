using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace particles_env
{
    public partial class ParameterEdit : Form
    {
        public double Value;

        public ParameterEdit(string sName, double DefaultValue)
        {
            InitializeComponent();

            this.label1.Text = sName;
            this.ValueBox.Text = DefaultValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Value = double.Parse(this.ValueBox.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ParameterEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(sender, e);
            }
        }
    }
}