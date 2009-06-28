using System;
using System.Collections.Generic;
using System.Text;
using ObjectGraphics;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace gLib
{
    using ParameterList;
    using Particle;
    
    public class gType  : GraphicPrimitive
    {
        public string sName = "RutherfordScatteringLib";
        public string ExpirementName = "Рассеяние Резерфорда";
        #region Поля

        /// <summary>
        /// Объект альфа-частицы
        /// </summary>
        public Particle Alpha;
        

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
        public gType() : base(0, 0, new Size())
        {
            AddParametersToTemplate();
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Left">x левого верхнего угла</param>
        /// <param name="Top">y левого верхнего угла</param>
        public gType(int Left, int Top, Size Size) : base(Left, Top, Size)
        {
            this.Left = Left;
            this.Top = Top;

            this.Size = Size;
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

            AddParticles(GenerateB((int)pNum, (int)bMin, (int)bMax)); 
            
            //начинаем рисовать
            DrawParticle(Nucl, e.Graphics, Pens.Blue);

            for (int i = 0; i < 500; i++)
            {
                foreach (AlphaParticle a in Particles)
                {
                    a.Move();

                    DrawParticle(a, e.Graphics, Pens.Red);
                   
                }
            }

            //чистим мусор
            Particles.Clear();
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

            return bArray;
        }

        private void AddParametersToTemplate()
        {
            ParameterListTemplate = new ParameterList();

            ParameterListTemplate.Add("Заряд ядра", "Q", 47);
            ParameterListTemplate.Add("Минимальное прицельное расстояние", "bMin", -50);
            ParameterListTemplate.Add("Максимальное прицельное расстояние", "bMax", 50);
            ParameterListTemplate.Add("Количество частиц", "pN", 30);
            ParameterListTemplate.Add("Начальная скороть частиц", "V", 1);
        }

        

        #endregion
    }
}
