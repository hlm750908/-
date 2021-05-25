using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 巧用_ToolStripControlHost_自定义WinForm右键菜单
{
    public class MiddleInvoker
    {
        public delegate void MyInvoker(string str);
        public static MyInvoker invoker;
    }
}
