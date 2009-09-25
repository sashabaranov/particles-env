using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace MDK
{
        public abstract partial class GraphicPrimitive
        {
            /// <summary>
            /// Координаты объекта(Top,Left - обязательны).
            /// </summary>
            protected int Top;
            protected int Left;
            protected int Right;
            protected int Bottom;

            /// <summary>
            /// Размер объекта
            /// </summary>
            protected Size Size;

            ///<summary>
            /// Имя эксперимента.
            /// </summary>
            public string ExpirementName;
            
            /// <summary>
            /// Шаблон списка параметров.
            /// </summary>
            public ParameterList ParameterListTemplate;

            /// <summary>
            /// Публичные Width и Height для задания размера.
            /// </summary>
            public int Width
            {
                get{ return Size.Width; }
                set{ Size.Width = value; }
            }
            public int Height
            {
                get { return Size.Height; }
                set { Size.Height = value; }
            }
            
            /// <summary>
            /// Описание объекта.
            /// </summary>
            protected String Description;

            /// <summary>
            /// Абстрактный конструктор.
            /// Задаёт верхний левый угол графического примитива.
            /// </summary>
            /// <param name="Left">Левая граница(x).</param>
            /// <param name="Top">Верхняя граница(y).</param>
            /// <param name="_Size">Размер</param>
            public GraphicPrimitive(int Left, int Top, Size _Size)
            {
                this.Top = Top;
                this.Left = Left;
                this.Size = _Size;
                
            }


            /// <summary>
            /// Задаёт границы рисования.
            /// </summary>
            /// <param name="Left">Левая граница(x).</param>
            /// <param name="Top">Верхняя граница(y).</param>
            /// <param name="_Size">Размер</param>
            public void SetDrawingBorder(int Left, int Top, Size _Size)
            {
                this.Top = Top;
                this.Left = Left;
                this.Size = _Size;
            }

            /// <summary>
            /// Функция для перегурзки в будующем,используется для прорисовки объекта.
            /// </summary>
            /// <param name="e">PaintEventArgs-аргумент,позволяющий рисовать.</param>
            public virtual void Draw(PaintEventArgs e)
            {
                throw new Exception("Abstract Draw recieved");
            }

            /// <summary>
            /// Виртуальный метод для получения параметров.
            /// </summary>
            /// <param name="pList">Список параметров</param>
            public virtual void SetParameters(ParameterList pList)
            {
                throw new Exception("Abstract SetParameters recieved");
            }

            /// <summary>
            /// Виртуальный метод для возвращения параметров
            /// </summary>
            /// <returns>Список параметров</returns>
            public virtual ParameterList GetParameters()
            {
                throw new Exception("Abstract GetParameters recieved");
            }

            public virtual PointPairList GetResults()
            {
                //throw new Exception("Abstract GetResults recieved");
                
                return new PointPairList();
            }
        }
}
