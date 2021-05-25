using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;

namespace 巧用_ToolStripControlHost_自定义WinForm右键菜单
{
    public class DataGridViewDataWindowColumn:DataGridViewColumn
    {
        private object m_dataSoruce = null;
        private string sDisplayMember = "";
        private string sDisplayField = "";
        private string sKeyWords = "";


        public string SDisplayField
        {
            get { return sDisplayField; }
            set { sDisplayField = value; }
        }

        public string SDisplayMember
        {
            get { return sDisplayMember; }
            set { sDisplayMember = value; }
        }

        public string SKeyWords
        {
            get { return sKeyWords; }
            set { sKeyWords = value; }
        }


        public DataGridViewDataWindowColumn()
            : base(new DataGridViewDataWindowCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewDataWindowCell)))
                {
                    throw new InvalidCastException("不是DataGridViewDataWindowCell");
                }
                
                base.CellTemplate = value; 
            }
        }
        private DataGridViewDataWindowCell ComboBoxCellTemplate
        {
            get
            {
                return (DataGridViewDataWindowCell)this.CellTemplate;
            }
        }
        public Object DataSource
        {
            get
            {
                return m_dataSoruce;

            }
            set
            {
                if (ComboBoxCellTemplate != value)
                {
             
                    m_dataSoruce = value;
                }
            }
        }
    }
}
