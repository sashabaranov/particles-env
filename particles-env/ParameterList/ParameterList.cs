using System;
using System.Collections.Generic;
using System.Text;

namespace ParameterList
{
    public class ParameterList
    {
        
        /// <summary>
        /// Список параметров
        /// </summary>
        public List<ParameterListUnit> Parameters;

        /// <summary>
        /// Конструктор по умолчанию, выделяет память для списка параметров
        /// </summary>
        public ParameterList()
        {
            Parameters = new List<ParameterListUnit>();
        }

        /// <summary>
        /// Берём по краткому названию
        /// </summary>
        /// <param name="sName">Краткое физическое название</param>
        /// <returns>Значение</returns>
        public double this[string sName]
        {
            get { return SearchBySName(sName); }
            set { SetBySName(sName, value); }

        }
        
        /// <summary>
        /// Поиск по короткому названию
        /// </summary>
        /// <param name="sName">Короткое название</param>
        /// <returns>Значение</returns>
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
        /// Задаёт значение по короткому названию
        /// </summary>
        /// <param name="sName">Короткое название</param>
        /// <param name="Value">Значение</param>
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
        /// Полное имя
        /// Например: "Прицельное расстояние"
        /// </summary>
        public string Name;

        /// <summary>
        /// Короткое имя, как переменная в физике
        /// Например: b
        /// </summary>
        public string sName;

        /// <summary>
        /// Значение параметра
        /// Например: 3.141592
        /// </summary>
        public double Value;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Name">Полное название</param>
        /// <param name="sName">Короткая физическая переменная</param>
        /// <param name="Value">Значение</param>
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
