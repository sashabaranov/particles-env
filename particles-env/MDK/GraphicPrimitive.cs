using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;
using System.Xml.Serialization;
namespace MDK
{
    [Serializable][XmlInclude(typeof(GraphicPrimitive))]
    public abstract class GraphicPrimitive
    {

        /// <summary>
        /// Нужды эксперимента
        /// </summary>
        public ExperimentNeeds Needs;

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

        /// <summary>
        /// Шаблон списка параметров.
        /// </summary>
        public ParameterList ParameterListTemplate;


        public virtual ExperimentAbout GetAbout()
        {
            return new ExperimentAbout();
        }

        /// <summary>
        /// Публичные Width и Height для задания размера.
        /// </summary>
        public int Width
        {
            get { return Size.Width; }
            set { Size.Width = value; }
        }
        public int Height
        {
            get { return Size.Height; }
            set { Size.Height = value; }
        }

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
        /// Метод для инициализации экспериментов, использующих OpenGL
        /// </summary>
        /// <param name="w">Width эксперимента</param>
        /// <param name="h">Height эксперимента</param>
        public virtual void GL_init(int w, int h)
        {
            return;
        }

        /// <summary>
        /// Функция для работы с камерой
        /// </summary>
        public virtual void GL_camera(double[] cameraPos, double[] targetPos, double[] rotateA)
        {
            return;
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

        public virtual void CreateControl(ZedGraphControl zgc)
        {
            throw new Exception("Abstract CreateControl recieved");
        }

        /* ExperimentNeeds.Graph */

        /// <summary>
        /// Поставка информации о графике: заголовок, x title, y title
        /// </summary>
        /// <param name="pane">GraphPane, где будет виден сам график</param>
        public virtual void SetGraphInfo(ZedGraph.GraphPane pane)
        {
            throw new Exception("Abstract SetGraphInfo recieved");
        }

        public virtual ZedGraph.PointPairList GetPoints()
        {
            return new ZedGraph.PointPairList();
        }
    }

    public enum ExperimentNeeds { None, Normal, ZedGraph, XNA, Graph, OpenGL };

    public class ExperimentAbout
    {
        public string sName;
        public string Name;
        public string Description;

        public ExperimentAbout() { }

        public ExperimentAbout(string _sName, string _Name, string _Description)
        {
            this.sName = _sName;
            this.Name = _Name;
            this.Description = _Description;
        }
    }

}
