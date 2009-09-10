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
    public partial class ExperimentAdd : Form
    {
        /// <summary>
        /// ������, ������� ����� ����������.
        /// </summary>
        public Experiment ExpirementObject;

        public ExperimentAdd(ExperimentList e)
        {
            InitializeComponent();

            ExpirementObject = new Experiment(); /* ������������� ������� ������������, � ������� ����� ��������
                                                    ���������, � ������� ����� ��������� ������� � MainForm    */

            foreach (ExperimentInfo p in e.eList) // ������ ������ ����� �������������
            {
                listBox1.Items.Add(p); // � ������ ����� p.ToString();
            }
        }

        private void ContinueButton_Click(object sender, EventArgs e) // ������������ ����� �� ������ "����������"
        {
            try
            {
                ConstructExpirement();
            }
            catch (NullReferenceException) //���� ����������� �� ������, ����� �������������� ����������.
            { 
                MessageBox.Show("����������, �������� �����������");
                return;
            }

            // �� ������, ���������� ��������� �����������

            ParametersEdit EditDialog = new ParametersEdit(); // ������ �������������� ����������
            EditDialog.eList = ExpirementObject.Graphics.ParameterListTemplate; // ������ ���������� � GraphicsPrimitive

            if (EditDialog.ShowDialog() != DialogResult.Cancel) // ���� ������������ �� ������ ������
            {
                //ExpirementObject.pList = EditDialog.eList; // ��������� ����������������� ��������� �� ������� � �������
                ExpirementObject.Graphics.SetParameters(EditDialog.eList); // ��������� ��������
            }

            this.DialogResult = DialogResult.OK;
            this.Close();            
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
            ExpirementObject = new Experiment();

            ExperimentInfo Selected = (ExperimentInfo)listBox1.SelectedItem;
            ExpirementObject.Graphics = Selected.GraphicsObj; // ����� ������
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContinueButton.Enabled = true;
        }

        private void ExperimentAdd_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            switch (e.KeyCode)
            {
                case Keys.Enter: ContinueButton_Click(sender, e); break;
            }
        }
    }
}