using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MDK;
namespace particles_env
{
    public partial class ExperimentAddControl : UserControl
    {
        public Experiment ExperimentObject;
        ExperimentList lst;

        public ExperimentAddControl()
        {
            InitializeComponent();
        }

        public void SetList(ExperimentList e)
        {
            lst = e;

            ExperimentObject = new Experiment(); /* инициализация объекта эксперимента, в который будут вносится
                                                    изминения, и который будет возвращёт обратно в MainForm    */
            foreach (ExperimentInfo p in e.eList) // Создаём список типов экспериментов
            {
                listBox1.Items.Add(p.ToString()); // в списке будут p.ToString();
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            bool flg = true;
            try
            {
                ConstructExperiment();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Пожалуйста, выберите эксперимент");
                flg = false;
            }
            finally
            {
                
                if (flg) UserSelected(this, ExperimentObject);
            }
        }

        private void ConstructExperiment()
        {
            ExperimentObject = new Experiment();
            //ExperimentObject.Graphics = (GraphicPrimitive) lst.eList[listBox1.SelectedIndex].GraphicsObj.Clone(); // сырой шаблон
            ExperimentObject.Graphics = (GraphicPrimitive) Activator.CreateInstance(lst.eList[listBox1.SelectedIndex].GraphicsObj.GetType());
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (lst.eList.Count > 0)
            {
                e.DrawBackground();
                ExperimentInfo inf = lst.eList[e.Index];

                if (inf.Ico != null) e.Graphics.DrawImage(Image.FromHbitmap(inf.Ico.GetHbitmap()), e.Bounds.Left, e.Bounds.Top);

                Font fnt = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);

                e.Graphics.DrawString(inf.About.Name, fnt, Brushes.Black, e.Bounds.Left + 65, e.Bounds.Top + 10);
            }

            Invalidate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Description.Text = lst.eList[listBox1.SelectedIndex].About.Description;
        }

        private void ExperimentAddControl_Load(object sender, EventArgs e)
        {
            listBox1.ItemHeight = 60;
            DescriptionBox.Height = listBox1.Height;
        }


        public event UserSelectedHandler UserSelected;

        public delegate void UserSelectedHandler(object sender, Experiment ExperimentObject);

        private void ExperimentAddControl_Resize(object sender, EventArgs e)
        {
            DescriptionBox.Height = listBox1.Height;
        }

    }
}
