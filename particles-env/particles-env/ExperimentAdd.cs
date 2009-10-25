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
        ExperimentList lst;
        /// <summary>
        /// ������, ������� ����� ����������.
        /// </summary>
        public Experiment ExpirementObject;

        public ExperimentAdd(ExperimentList e)
        {
            lst = e;
            InitializeComponent();

            ExpirementObject = new Experiment(); /* ������������� ������� ������������, � ������� ����� ��������
                                                    ���������, � ������� ����� ��������� ������� � MainForm    */

            foreach (ExperimentInfo p in e.eList) // ������ ������ ����� �������������
            {
                listBox1.Items.Add(p.ToString()); // � ������ ����� p.ToString();
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
            
            //������� ������ � ����� ������
            EditDialog.eList = ExpirementObject.Graphics.ParameterListTemplate; // ������ ���������� � GraphicsPrimitive
            EditDialog.Description = lst.eList[listBox1.SelectedIndex].About.Description;
            EditDialog.ExpirementPicture = lst.eList[listBox1.SelectedIndex].BigIco;

            if (EditDialog.ShowDialog() != DialogResult.Cancel) // ���� ������������ �� ������ ������
            {
                //ExpirementObject.pList = EditDialog.eList; // ��������� ����������������� ��������� �� ������� � �������
                ExpirementObject.Graphics.SetParameters(EditDialog.eList); // ��������� ��������
            }

            this.DialogResult = DialogResult.OK;
            this.Close();            
        }

      
        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConstructExpirement();
        }

        private void ConstructExpirement()
        {
            ExpirementObject = new Experiment();
            ExpirementObject.Graphics = lst.eList[listBox1.SelectedIndex].GraphicsObj; // ����� ������
        }


        private void ExperimentAdd_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            switch (e.KeyCode)
            {
                case Keys.Enter: ContinueButton_Click(sender, e); break;
            }
        }


        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (lst.eList.Count > 0)
            {
                e.DrawBackground();
                ExperimentInfo inf = lst.eList[e.Index];

                if(inf.Ico != null) e.Graphics.DrawImage(Image.FromHbitmap(inf.Ico.GetHbitmap()), e.Bounds.Left, e.Bounds.Top);

                Font fnt = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
                
                e.Graphics.DrawString(inf.About.Name, fnt, Brushes.Black, e.Bounds.Left + 65, e.Bounds.Top + 10);
            }
            Invalidate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContinueButton.Enabled = true;
        }

        private void ExperimentAdd_Load(object sender, EventArgs e)
        {
            listBox1.ItemHeight = 60;
            
        }


    }
}