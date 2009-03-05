using System;
using System.Drawing;
using System.Windows.Forms;

namespace ObjectGraphics
{
        public abstract class GraphicPrimitive
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
            private Size Size;

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
            GraphicPrimitive(int Left,int Top)
            {
                this.Top = Top;
                this.Left = Left;
                
            }

            /// <summary>
            /// Функция для перегурзки в будующем,используется для прорисовки объекта.
            /// </summary>
            /// <param name="e">PaintEventArgs-аргумент,позволяющий рисовать.</param>
            public virtual void Draw(PaintEventArgs e)
            {
                MessageBox.Show("Abstract Draw call recived");
            }
        }
}
