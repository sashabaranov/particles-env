using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace particles_env
{
    using ParameterList;

    public partial class ParametersEdit : Form
    {
        public ParameterList eList;

        public ParametersEdit()
        {
            InitializeComponent();
        }

        private void ParametersEdit_Load(object sender, EventArgs e)
        {
            foreach (ParameterListUnit Unit in eList.Parameters)
            {
                listBox1.Items.Add(Unit);
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            int SelectedIndex = listBox1.SelectedIndex; //��������� ������
            ParameterListUnit Selected = (ParameterListUnit)listBox1.SelectedItem; //���� ������� �������
            ParameterEdit CurrentParameterEditor = new ParameterEdit(Selected.sName + ":", Selected.Value); //������ �����

            if (CurrentParameterEditor.ShowDialog() != DialogResult.Cancel)
            {
                Selected.Value = CurrentParameterEditor.Value;

                listBox1.Items[SelectedIndex] = Selected;
                
            }
            CurrentParameterEditor.Dispose();
        }

    
    }
}