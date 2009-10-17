using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MDK;
using ZedGraph;

namespace RutherfordScatteringLib
{   
    public class  RutherfordScatteringLib : GraphicPrimitive
    {
        public override ExpirementAbout GetAbout()
        {
            return new ExpirementAbout("RutherfordScatteringLib", "Рассеяние Резерфорда", "Рассеяние альфа-частиц на атомах");
        }

        #region Поля

        /// <summary>
        /// Объект альфа-частицы
        /// </summary>
        public Particle Alpha;
        
        ///<summary>Считалось ли еще прицельное растояние?</summary>
        private bool b_flag = false;

        /// <summary>
        /// Объект ядра
        /// </summary>
        public Particle Nucl;

        /// <summary>
        /// Все наши частицы
        /// </summary>
        List<AlphaParticle> Particles = new List<AlphaParticle>();

        /// <summary>
        /// Нижняя граница b
        /// </summary>
        public float bLow;

        /// <summary>
        /// Верхняя граница b
        /// </summary>
        public float bHigh;

        /// <summary>
        /// Массив прицельных расстояний
        /// </summary>
        public float[] bArray;

        // мы должны их хранить, для передачи обратно, при редактировании параметров
        private double pNum;
        private double bMin;
        private double bMax;

        #endregion

        #region Методы


        /// <summary>
        /// Без него не загрузить
        /// </summary>
        public RutherfordScatteringLib() : base(0, 0, new Size())
        {
            this.Needs = ExpirementNeeds.Normal;
            AddParametersToTemplate();
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Left">x левого верхнего угла</param>
        /// <param name="Top">y левого верхнего угла</param>
        public RutherfordScatteringLib(int Left, int Top, Size Size)
            : base(Left, Top, Size)
        {
            this.Needs = ExpirementNeeds.Normal;
            this.Left = Left;
            this.Top = Top;

            this.Size = Size;

            AddParametersToTemplate();
        }


        public void SetParticles(Particle Alpha, Particle Nucl)
        {
            this.Alpha = Alpha;
            this.Nucl = Nucl;
        }


        /// <summary>
        /// Метод рисования
        /// </summary>
        /// <param name="e"></param>
        public override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            //инициализируемся
            Nucl.x = this.Left + this.Size.Width / 2;
            Nucl.y = this.Top + this.Size.Height / 2;
            
            b = GenerateB((int)pNum, (int)bMin, (int)bMax);
            AddParticles(b);
            b_flag = true;
            //начинаем рисовать
            
            e.Graphics.FillEllipse(Brushes.Blue, Nucl.x - 10, Nucl.y - 10, 20, 20);
            
            for (int i = 0; i < this.Width*3/4; i++)
            {
                foreach (AlphaParticle a in Particles)
                {
                    a.Move();
                    DrawParticle(a, e.Graphics, Pens.Red);   
                }
            }

            // чистим мусор
            Particles.Clear();

            // подписи и обозначения

            Font fnt = new Font("Arial", 12, FontStyle.Regular);

            
            float nx = (float)(Nucl.x + 20 * Math.Cos(45 * Math.PI / 180));
            float ny = (float)(Nucl.y + 20 * Math.Sin(45 * Math.PI / 180));
            e.Graphics.DrawLine(Pens.Black, nx, ny, (float)(nx + Width * Math.Cos(45 * Math.PI / 180)/6), (float)(ny + Width * Math.Sin(45 * Math.PI / 180)/6));
            nx += (float)(Width * Math.Cos(45 * Math.PI / 180) / 6);
            ny += (float)(Width * Math.Sin(45 * Math.PI / 180) / 6);
            e.Graphics.DrawLine(Pens.Black, nx, ny, nx + 40, ny);
            e.Graphics.DrawString("Ядро атома", fnt, Brushes.Black, nx + 50, ny - 10);
            e.Graphics.DrawRectangle(Pens.DarkBlue, nx + 40, ny - 11, 112, 22);
            
            float b_min = b[0];
            for (int j = 1; j < b.Length; j++)
            {
                if (b[j] < b_min) b_min = b[j];
            }
            
            nx = (float)(this.Left + 2 * Width / 5);
            ny = Nucl.y - b_min + 10;
            e.Graphics.DrawLine(Pens.Black, nx, ny, (float)(nx - Width * Math.Cos(66 * Math.PI / 180) / 7),(float)(ny + Width * Math.Sin(66 * Math.PI / 180) / 7));
            nx -= (float)(Width * Math.Cos(66 * Math.PI / 180) / 7);
            ny += (float)(Width * Math.Sin(66 * Math.PI / 180) / 7);
            e.Graphics.DrawLine(Pens.Black, nx, ny, nx - 40, ny);

            e.Graphics.DrawString("Траектория частицы", fnt, Brushes.Black, nx - 200, ny - 10);
            e.Graphics.DrawRectangle(Pens.DarkBlue, nx - 210, ny - 11, 170, 22);
        }


        public void AddParticles(float[] bArray)
        {
            Random rnd = new Random();

            for (int i = 0; i < bArray.Length; i++)
            {
                Particle m = new Particle();
                m.x = Nucl.x - this.Size.Width/2;
                m.y = Nucl.y - bArray[i];

                m.vx = Alpha.vx;

                AlphaParticle p = new AlphaParticle(m, bArray[i]);

                Particles.Add(p);
            }
        }

        public void DrawParticle(Particle p, Graphics g, Pen pen)
        {
            //g.FillEllipse(pen.Brush, p.x, p.y, 10, 10);
            g.DrawRectangle(pen, p.x, p.y, 1, 1);

        }

        public override void SetParameters(ParameterList pList)
        {
            Nucl = new Particle();
            Nucl.ElectricCharge = pList["Q"]; // заряд ядра

            Alpha = new Particle();
            Alpha.vx = pList["V"]; // начальная скорость

            AlphaParticle.Nucl = Nucl; // для всех альфа-частиц
            SetParticles(Alpha, Nucl); 

            // сохраняем, для будующей передачи обратно через GetParameters()
            this.pNum = pList["pN"];
            this.bMin = pList["bMin"];
            this.bMax = pList["bMax"];

            
        }
        float[] teta_array;

        public float Actg(double value)
        {
            return ((float)Math.PI / 2 - (float)Math.Atan(value));
        }

        PointPairList tetaList = new PointPairList();
        private float CountTeta(float b)
        {

            //return 20 * Actg((float)((Alpha.m * b * (Alpha.V * Alpha.V) / (Z * 2 * 2.56 * (float)Math.Pow(10, -3))));
            // z - заряд ядра
            //const double p = 1; //порядок, на что домножать
            //double r = Alpha.m * Alpha.V * Alpha.V * b;


            //return (2 * Actg(p * r));
            //return (2 * Actg((Alpha.m * b * Alpha.vx * Alpha.vx) / (2 * Nucl.Q)));
            return (2 * Actg((b * Alpha.vx * Alpha.vx) / (2 * Nucl.Q)));
        }
        float[] b;
        private void makeTeta()
        {
            
            tetaList.Clear();
            teta_array = new float[6];
            float curr_teta;
            foreach (float b_elem in b)
            {
                curr_teta = CountTeta(b_elem);
                //MessageBox.Show("Teta: " + curr_teta.ToString() + ", b: " + b_elem);
                if (curr_teta >= 0 && curr_teta <= Math.PI / 3)
                    teta_array[0]++;
                else if (curr_teta > Math.PI / 3 && curr_teta <= 2 * Math.PI / 3)
                    teta_array[1]++;
                else if (curr_teta > 2 * Math.PI / 3 && curr_teta <= Math.PI)
                    teta_array[2]++;
                else if (curr_teta > Math.PI && curr_teta <= 4 * Math.PI / 3)
                    teta_array[3]++;
                else if (curr_teta > 4 * Math.PI / 3 && curr_teta <= 5 * Math.PI / 3)
                    teta_array[4]++;
                else if (curr_teta > 5 * Math.PI / 3 && curr_teta <= 2 * Math.PI)
                    teta_array[5]++;
            }

            for (int i = 0; i < 6; i++)
            {
                tetaList.Add((i * Math.PI / 3) * (180 / Math.PI), teta_array[i]);
            }

        }

        public override PointPairList GetResults()
        {
            if (!b_flag) GenerateB((int)pNum, (int)bMin, (int)bMax);

            makeTeta();

            //MessageBox.Show(teta_array[3].ToString() + " " + teta_array[4].ToString() + " " + teta_array[5].ToString());

            return tetaList;
        }

        public override ParameterList  GetParameters()
        {
 	        ParameterList RetList = ParameterListTemplate;
            RetList["Q"] = Nucl.Q;
            RetList["V"] = Alpha.vx;
            RetList["pN"] = this.pNum;
            RetList["bMin"] = this.bMin;
            RetList["bMax"] = this.bMax;

            return RetList;
        }

        /// <summary>
        /// Функция для генерации массива прицельных расстояний
        /// </summary>
        /// <param name="pNum">Количество частиц</param>
        /// <param name="bHigh">Минимальное прицельное расстояние</param>
        /// <param name="bLow">Максимальное прицельное расстояние</param>
        /// <returns>Массив, случайно сгенерированных, прицельных расстояний</returns>
        private float[] GenerateB(int pNum, int bLow, int bHigh)
        {
            Random rnd = new Random();
            float[] bArray = new float[pNum];

            for (int i = 0; i < bArray.Length; i++)
            {
                bArray[i] = rnd.Next(bLow, bHigh);
            }

            b = bArray;
            return bArray;
        }

        private void AddParametersToTemplate()
        {
            ParameterListTemplate = new ParameterList();

            ParameterListTemplate.Add("Заряд ядра", "Q", 47);
            ParameterListTemplate.Add("Минимальное прицельное расстояние", "bMin", -50);
            ParameterListTemplate.Add("Максимальное прицельное расстояние", "bMax", 50);
            ParameterListTemplate.Add("Количество частиц", "pN", 10);
            ParameterListTemplate.Add("Начальная скороть частиц", "V", 1);
        }

        


        #endregion
    }
}
