using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 巧用_ToolStripControlHost_自定义WinForm右键菜单
{
    public delegate void AfterSelectorEventHandler(object sender, AfterSelectorEventArgs e);

    public class AfterSelectorEventArgs : EventArgs
    {
        private int _rowIndex;
        private int _columnIndex;
        private DataGridViewRow _value;

        public int RowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
        }
        public int ColumnIndex
        {
            get { return _columnIndex; }
            set { _columnIndex = value; }
        }
        public DataGridViewRow Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public AfterSelectorEventArgs(int rowIndex, int columnIndex, DataGridViewRow value)
            : base()
        {
            _rowIndex = rowIndex;
            _columnIndex = columnIndex;
            _value = value;
        }
    }
}
