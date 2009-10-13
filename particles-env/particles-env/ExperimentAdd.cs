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
        /// Объект, который будем возвращать.
        /// </summary>
        public Experiment ExpirementObject;

        public ExperimentAdd(ExperimentList e)
        {
            lst = e;
            InitializeComponent();

            ExpirementObject = new Experiment(); /* инициализация объекта эксперимента, в который будут вносится
                                                    изминения, и который будет возвращёт обратно в MainForm    */

            foreach (ExperimentInfo p in e.eList) // Создаём список типов экспериментов
            {
                listBox1.Items.Add(p.ToString()); // в списке будут p.ToString();
            }
        }

        private void ContinueButton_Click(object sender, EventArgs e) // пользователь нажал на кнопку "продолжить"
        {
            try
            {
                ConstructExpirement();
            }
            catch (NullReferenceException) //если эксперимент не выбран, будет сгенерированно исключение.
            { 
                MessageBox.Show("Пожалуйста, выберите эксперимент");
                return;
            }

            // всё хорошо, продолжаем создавать эксперимент

            ParametersEdit EditDialog = new ParametersEdit(); // диалог редактирования параметров
            
            //передаём данные в новый диалог
            EditDialog.eList = ExpirementObject.Graphics.ParameterListTemplate; // шаблон параметров и GraphicsPrimitive
            EditDialog.Description = ExpirementObject.Graphics.GetDescription();


            if (EditDialog.ShowDialog() != DialogResult.Cancel) // если пользователь не закрыл диалог
            {
                //ExpirementObject.pList = EditDialog.eList; // переносим отредактированные параметры из диалога в объекта
                ExpirementObject.Graphics.SetParameters(EditDialog.eList); // переносим напрямую
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
            ExpirementObject.Graphics = lst.eList[listBox1.SelectedIndex].GraphicsObj; // сырой шаблон
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
            e.DrawBackground();
            ExperimentInfo inf = lst.eList[e.Index];

            if (e.State == DrawItemState.HotLight)
            {
                e.Graphics.DrawRectangle(Pens.Red, e.Bounds);
                
            }
            //e.Graphics.DrawIcon(inf.ico, e.Bounds.Left, e.Bounds.Top + 10);


            e.Graphics.DrawImage(Image.FromHbitmap(inf.ico.GetHbitmap()), e.Bounds.Left, e.Bounds.Top);
            Font fnt = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
            e.Graphics.DrawString(inf.Name, fnt, Brushes.Black, e.Bounds.Left + 65, e.Bounds.Top + 10);
            
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