using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using ObjectGraphics;

namespace particles_env
{
    [Serializable]
    public class ExpirementList
    {
        public List<ExpirementInfo> eList;

        public ExpirementList()
        {
            eList = new List<ExpirementInfo>();
        }

        public void LoadDll(string Path)
        {
            Assembly asm = Assembly.LoadFile(Path); //возможное исключение, нуждается в обработке при вызове
            Type gType = asm.GetType("gLib.gType");
            object obj = Activator.CreateInstance(gType);
            FieldInfo[] membs = gType.GetFields();

            string Name = null;
            string sName = null; //будут передаваться в список
            
            foreach (FieldInfo p in membs)
            {
                //MessageBox.Show(p.Name + " : " + p.GetValue(obj).ToString());
                switch (p.Name)
                {
                    case "sName": sName = p.GetValue(obj).ToString(); break;
                    case "ExpirementName": Name = p.GetValue(obj).ToString(); break;                           
                }
            }

            eList.Add(new ExpirementInfo(Path, Name, sName, (GraphicPrimitive)obj));
        }
    }

    [Serializable]
    public class ExpirementInfo
    {
        public string Path;
        public string Name;
        public string sName;
        public GraphicPrimitive GraphicsObj;

        public ExpirementInfo() { }
        public ExpirementInfo(string Path, string Name, string sName, GraphicPrimitive g)
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
