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
    /// ���������� ����� ��� �������� ������ ������������� � �� ��������
    /// </summary>
    [Serializable]
    public partial class ExperimentList
    {
        public List<ExperimentInfo> eList;

        public ExperimentList()
        {
            eList = new List<ExperimentInfo>();
        }

        /// <summary>
        /// �������� ������ �� dll-����������
        /// </summary>
        /// <param name="Path">���� � dll-����������</param>
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
                        object objj = Activator.CreateInstance(p);
                        eList.Add(new ExperimentInfo(Path, (GraphicPrimitive)objj));

                        isModule = true;
                        break;
                    }
                }
                if (!isModule) MessageBox.Show("���� "+Path+" �� �������� �������");
            }
            catch (Exception e)
            {
                MessageBox.Show("���-�� ����� �� ���:\n" + e.ToString() + "\n � ����-��, �� �������� ��������� "+Path);
            }
        }

        public Type[] GetTypes()
        {
            List<Type> types = new List<Type>();

            foreach (ExperimentInfo inf in eList)
            {
                types.Add(inf.GraphicsObj.GetType());
            }
            
            return types.ToArray();
        }

        /// <summary>
        /// ��������� ������(����� ��������)
        /// </summary>
        /// <param name="x">����������� ���</param>
        /// <param name="p">����</param>
        void LoadModule(Type x, string p)
        {
            object obj = Activator.CreateInstance(x);
            
            eList.Add(new ExperimentInfo(p, (GraphicPrimitive)obj));
        }
    }

    /// <summary>
    /// ���������� ����� ��� �������� ���������� �� ������������
    /// </summary>
    [Serializable]
    public partial class ExperimentInfo
    {
        public string Path;
        public ExperimentAbout About;
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
            string IcoPath = @"modules\icons\" + About.sName + ".bmp";
            string BigIcoPath = @"modules\icons\" + About.sName + ".bmp";
            
            if(File.Exists(IcoPath)) Ico = new Bitmap(IcoPath);
            if(File.Exists(BigIcoPath)) BigIco = new Bitmap(BigIcoPath);
        }

        public override string ToString()
        {
            return this.About.Name;
        }
    }
}
