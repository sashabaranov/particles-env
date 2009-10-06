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

        Type x;
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
                        LoadModule(p, Path);
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

        /// <summary>
        /// ��������� ������(����� ��������)
        /// </summary>
        /// <param name="x">����������� ���</param>
        /// <param name="p">����</param>
        void LoadModule(Type x, string p)
        {
            object obj = Activator.CreateInstance(x);
            string Name = (string)obj.GetType().GetField("ExpirementName").GetValue(obj);
            string sName = (string)obj.GetType().GetField("sName").GetValue(obj); //����� ������������ � ������

            Icon ico = new Icon(@"modules\icons\" + sName + ".ico");

            eList.Add(new ExperimentInfo(p, ico, Name, sName, (GraphicPrimitive)obj));
        }
    }

    /// <summary>
    /// ���������� ����� ��� �������� ���������� �� ������������
    /// </summary>
    [Serializable]
    public partial class ExperimentInfo
    {
        public string Path;
        public string Name;
        public string sName;
        public GraphicPrimitive GraphicsObj;
        public Icon ico;
        
        public ExperimentInfo() { }

        public ExperimentInfo(string Path, Icon _ico, string Name, string sName, GraphicPrimitive g)
        { 
            this.Path = Path;
            this.Name = Name;
            this.sName = sName;
            this.GraphicsObj = g;
            this.ico = _ico;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
