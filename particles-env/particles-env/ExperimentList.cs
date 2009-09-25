using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using MDK;

namespace particles_env
{
    [Serializable]
    public class ExperimentList
    {
        public List<ExperimentInfo> eList;

        public ExperimentList()
        {
            eList = new List<ExperimentInfo>();
        }

        Type x;
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
                    if (p.BaseType.ToString().CompareTo("MDK.GraphicPrimitive") == 0)
                    {
                        LoadModule(p, Path);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("„то-то пошло не так:\n" + e.ToString() + "\n   тому-же, мы пытались загрузить "+Path);
            }
        }

        void LoadModule(Type x, string p)
        {
            object obj = Activator.CreateInstance(x);

            
            string Name = (string)obj.GetType().GetField("ExpirementName").GetValue(obj);
            string sName = (string)obj.GetType().GetField("sName").GetValue(obj); //будут передаватьс€ в список
            
            eList.Add(new ExperimentInfo(p, Name, sName, (GraphicPrimitive)obj));
        }
    }

    [Serializable]
    public class ExperimentInfo
    {
        public string Path;
        public string Name;
        public string sName;
        public GraphicPrimitive GraphicsObj;

        public ExperimentInfo() { }
        public ExperimentInfo(string Path, string Name, string sName, GraphicPrimitive g)
        {
            this.Path = Path;
            this.Name = Name;
            this.sName = sName;
            this.GraphicsObj = g;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
