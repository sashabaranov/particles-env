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
        /// ������, ������� ����� ����������.
        /// </summary>
        public Expirement ExpirementObject;

        public ExpirementAdd(ExpirementList e)
        {
            InitializeComponent();

            ExpirementObject = new Expirement(); /* ������������� ������� ������������, � ������� ����� ��������
                                                    ���������, � ������� ����� ��������� ������� � MainForm    */

            foreach (ExpirementInfo p in e.eList) // ������ ������ ����� �������������
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
            ExpirementObject = new Expirement();

            ExpirementInfo Selected = (ExpirementInfo)listBox1.SelectedItem;
            ExpirementObject.Graphics = Selected.GraphicsObj; // ����� ������
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContinueButton.Enabled = true;
        }
    }
}