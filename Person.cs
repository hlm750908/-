using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 巧用_ToolStripControlHost_自定义WinForm右键菜单
{
   public class Person
    {
        [System.ComponentModel.DisplayName("流水码")]
        public int id { get; set; }
        [System.ComponentModel.DisplayName("工号")]
        public string code { get; set; }
        [System.ComponentModel.DisplayName("姓名")]
        public string name { get; set; }


    }


    public class Blog
    {
        [System.ComponentModel.DisplayName("博客id")]
        public int id { get; set; }
        [System.ComponentModel.DisplayName("博客网址")]
        public string Url { get; set; }
        [System.ComponentModel.DisplayName("排名")]
        public int Rating { get; set; }
    }
}
