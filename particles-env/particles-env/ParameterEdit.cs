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
        List<char> OkChars = new List<char>();
        public ParameterEdit(string sName, double DefaultValue)
        {
            InitializeComponent();

            this.label1.Text = sName;
            this.ValueBox.Text = DefaultValue.ToString();

            
            OkChars.Add(',');
            OkChars.Add('-');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool NumericFlag = true;
            
            if (CheckParameter())
            {
                this.Value = double.Parse(this.ValueBox.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else MessageBox.Show("Неправильно введён параметр");
        }

        private bool CheckParameter()
        {
            bool ok = true;

            foreach (char c in ValueBox.Text)
            {
                if (!OkChars.Contains(c) && !char.IsNumber(c)) ok = false;
            }

            return ok;
        }



        private void ParameterEdit_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            switch (e.KeyCode)
            {
                case Keys.Enter: button1_Click(sender, e); break;
            }
        }
    }
}