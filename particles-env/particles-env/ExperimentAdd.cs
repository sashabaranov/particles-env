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
        /// Объект, который будем возвращать.
        /// </summary>
        public Experiment ExpirementObject;

        public ExperimentAdd(ExperimentList e)
        {
            InitializeComponent();

            ExpirementObject = new Experiment(); /* инициализация объекта эксперимента, в который будут вносится
                                                    изминения, и который будет возвращёт обратно в MainForm    */

            foreach (ExperimentInfo p in e.eList) // Создаём список типов экспериментов
            {
                listBox1.Items.Add(p); // в списке будут p.ToString();
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
            EditDialog.eList = ExpirementObject.Graphics.ParameterListTemplate; // шаблон параметров и GraphicsPrimitive

            if (EditDialog.ShowDialog() != DialogResult.Cancel) // если пользователь не закрыл диалог
            {
                //ExpirementObject.pList = EditDialog.eList; // переносим отредактированные параметры из диалога в объекта
                ExpirementObject.Graphics.SetParameters(EditDialog.eList); // переносим напрямую
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
            ExpirementObject.Graphics = Selected.GraphicsObj; // сырой шаблон
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