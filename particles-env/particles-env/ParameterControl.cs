using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MDK;

namespace particles_env
{
    /// <summary>
    /// ������������ ��� ������� ���� ParameterControl
    /// </summary>
    public enum EditingType { TextBox, Scroll, None }

    public partial class ParameterControl : UserControl
    {
        EditingType Type;
        public ParameterListUnit Unit;

        public double Value
        {
            get
            {
                switch (this.Type)
                {
                    case EditingType.TextBox: return float.Parse(this.Controls["box"].Text); break;
                    default: return 0; break;
                }
            }
            set
            {
                switch (this.Type)
                {
                    case EditingType.TextBox: this.Controls["box"].Text = value.ToString(); break;
                    default: break;
                }
            }
        }


        public ParameterControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ����������� ��� ������ �� ParametersEdit
        /// </summary>
        /// <param name="t">���(������, ��������� ����)</param>
        /// <param name="DefaultValue">�������� �� ���������</param>
        public ParameterControl(EditingType t, ParameterListUnit Unit)
        {
            InitializeComponent();
            this.Unit = Unit;
            
            
            ParameterName.Text = Unit.sName;
            
            this.Type = t;

            switch (t)
            {
                case EditingType.None: break;
                case EditingType.TextBox: AddTextBox(Unit.Value); break; // ��������� textbox
                case EditingType.Scroll: break;
            }
        }



        private void AddTextBox( double v)
        {
            TextBox box = new TextBox();
            
            box.Left = this.ParameterName.Right + 10;
            box.Top = ParameterName.Top;
            box.Name = "box";
            box.Text = v.ToString();

            this.Controls.Add(box);
        }

    }
}
