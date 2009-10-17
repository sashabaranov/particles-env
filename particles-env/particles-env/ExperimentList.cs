using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using MDK;


namespace particles_env
{
    /// <summary>
    /// Внутренний класс для хранения списка экспериментов и их загрузки
    /// </summary>
    [Serializable]
    public partial class ExperimentList
    {
        public List<ExperimentInfo> eList;

        public ExperimentList()
        {
            eList = new List<ExperimentInfo>();
        }

        Type x;
        /// <summary>
        /// Загрузка модуля из dll-библиотеки
        /// </summary>
        /// <param name="Path">Путь к dll-библиотеке</param>
        public void LoadDll(string Path)
        {
            try
            {

                Assembly asm = Assembly.LoadFrom(Path);
                Type[] types = asm.GetTypes();

                object obj = new object();
                bool isModule = false;

                foreach (Type p in types)
                {
                    if (p.BaseType.FullName.ToString().CompareTo("MDK.GraphicPrimitive") == 0 )
                    {
                        LoadModule(p, Path);
                        isModule = true;
                        break;
                    }
                }
                if (!isModule) MessageBox.Show("Файл "+Path+" не является модулем");
            }
            catch (Exception e)
            {
                MessageBox.Show("Что-то пошло не так:\n" + e.ToString() + "\n К тому-же, мы пытались загрузить "+Path);
            }
        }

        /// <summary>
        /// Загрузчик модуля(после проверки)
        /// </summary>
        /// <param name="x">Загружаемый тип</param>
        /// <param name="p">Путь</param>
        void LoadModule(Type x, string p)
        {
            object obj = Activator.CreateInstance(x);
            /*string Name = (string)obj.GetType().GetField("ExpirementName").GetValue(obj);
            string sName = (string)obj.GetType().GetField("sName").GetValue(obj); //будут передаваться в список

            Bitmap ico = new Bitmap(@"modules\icons\" + sName + ".bmp");*/
            
            
            eList.Add(new ExperimentInfo(p, (GraphicPrimitive)obj));
        }
    }

    /// <summary>
    /// Внутренний класс для хранения информации об эксперименте
    /// </summary>
    [Serializable]
    public partial class ExperimentInfo
    {
        public string Path;
        public ExpirementAbout About;
        public GraphicPrimitive GraphicsObj;
        
        public Bitmap Ico;
        public Bitmap BigIco;
        
        public ExperimentInfo() { }

        public ExperimentInfo(string Path, GraphicPrimitive g)
        {
            About = g.GetAbout();
            
            this.Path = Path;
            this.GraphicsObj = g;
            
            MakeIcons();
            
        }

        void MakeIcons()
        {
            Ico = new Bitmap(@"modules\icons\"+About.sName+".bmp");
            BigIco = new Bitmap(@"modules\icons\" + About.sName + ".bmp");
        }

        public override string ToString()
        {
            return this.About.Name;
        }
    }
}
