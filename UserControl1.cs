using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 巧用_ToolStripControlHost_自定义WinForm右键菜单
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strInput = this.txtInput.Text;
            MiddleInvoker.invoker.Invoke(strInput);
            this.Parent.Hide();
        }
    }
}
