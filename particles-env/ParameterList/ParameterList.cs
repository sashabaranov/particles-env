using System;
using System.Collections.Generic;
using System.Text;

namespace ParameterList
{
    public class ParameterList
    {
        // �� ����
        /// <summary>
        /// ������ ����������
        /// </summary>
        public List<ParameterListUnit> Parameters;

        /// <summary>
        /// ����������� �� ���������, �������� ������ ��� ������ ����������
        /// </summary>
        public ParameterList()
        {
            Parameters = new List<ParameterListUnit>();
        }

        /// <summary>
        /// ���� �� �������� ��������
        /// </summary>
        /// <param name="sName">������� ���������� ��������</param>
        /// <returns>��������</returns>
        public double this[string sName]
        {
            get { return SearchBySName(sName); }
            set { SetBySName(sName, value); }

        }
        
        /// <summary>
        /// ����� �� ��������� ��������
        /// </summary>
        /// <param name="sName">�������� ��������</param>
        /// <returns>��������</returns>
        private double SearchBySName(string sName)
        {
            double toReturn = 0;
            foreach(ParameterListUnit u in Parameters)
            {
                if(u.sName == sName)
                {
                    toReturn = u.Value;
                    break;
                }
            }
            return toReturn;
        }

        /// <summary>
        /// ����� �������� �� ��������� ��������
        /// </summary>
        /// <param name="sName">�������� ��������</param>
        /// <param name="Value">��������</param>
        private void SetBySName(string sName, double Value)
        {
            foreach (ParameterListUnit u in Parameters)
            {
                if (u.sName == sName)
                {
                    u.Value = Value;
                    break;
                }
            }
        }

        public void Add(string Name, string sName, double Value)
        {

            Parameters.Add(new ParameterListUnit(Name, sName, Value));
        }

    }
    public class ParameterListUnit
    {
        /// <summary>
        /// ������ ���
        /// ��������: "���������� ����������"
        /// </summary>
        public string Name;

        /// <summary>
        /// �������� ���, ��� ���������� � ������
        /// ��������: b
        /// </summary>
        public string sName;

        /// <summary>
        /// �������� ���������
        /// ��������: 3.141592
        /// </summary>
        public double Value;

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="Name">������ ��������</param>
        /// <param name="sName">�������� ���������� ����������</param>
        /// <param name="Value">��������</param>
        public ParameterListUnit(string Name, string shortName, double Value)
        {
            this.Name = Name;
            this.sName = shortName;
            this.Value = Value;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
