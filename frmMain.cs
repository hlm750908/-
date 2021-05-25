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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.button1.ContextMenuStrip = this.contextMenuStrip1;
            UserControl1 uc = new UserControl1();
            ToolStripControlHost tsc = new ToolStripControlHost(uc);
            this.contextMenuStrip1.Items.Add(tsc);
            MiddleInvoker.invoker = new MiddleInvoker.MyInvoker(UpdateValue);


            List<Person> list = new List<Person>();
            list.Add(new Person { id = 1, code = "20151763", name = "黄良谋" });
            list.Add(new Person { id = 2, code = "20180009", name = "张三" });
            userControl21.setDataSource<Person>(list);

            var list2 = new List<Blog>();
            list2.Add(new Blog() { id = 1, Url = "https://www.baidu.com/", Rating = 3 });
            list2.Add(new Blog() { id = 2, Url = "https://bbs.csdn.net/topics/370072476?list=lz", Rating = 3 });
            dataWindow1.setDataSource<Blog>(list2);

            DataGridViewColumn column = new DataGridViewDataWindowColumn();

            (column as DataGridViewDataWindowColumn).SDisplayField = "学号,姓名,性别,专业,入学年份";
            (column as DataGridViewDataWindowColumn).SDisplayMember = "学号";
            (column as DataGridViewDataWindowColumn).SKeyWords = "学号";
            (column as DataGridViewDataWindowColumn).DataSource = list;
            dataGridView1.Columns.Add(column);

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
        }

        void UpdateValue(string str)
        {
            this.textBox1.Text = str;
        }



        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            var cc = new System.Windows.Forms.ContextMenuStrip();
            UserControl1 uc = new UserControl1();
            ToolStripControlHost tsc = new ToolStripControlHost(uc);
            cc.Items.Add(tsc);
            this.textBox1.ContextMenuStrip = cc;
            MiddleInvoker.invoker = new MiddleInvoker.MyInvoker(UpdateValue);
        }

        private void userControl21_AfterSelector(object sender, AfterSelectorEventArgs e)
        {
            //var cc = e.Value.DataBoundItem as Person;
            //userControl21.Text = cc.name;
            //MessageBox.Show(userControl21.SelectedValue.ToString());
        }

        private void dataWindow1_AfterSelector(object sender, AfterSelectorEventArgs e)
        {
            //var cc = e.Value.DataBoundItem as Blog;
            //dataWindow1.Text = cc.Url;
            //MessageBox.Show(dataWindow1.SelectedValue.ToString());
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataWindow)
            {
                (e.Control as DataWindow).AfterSelector -= new AfterSelectorEventHandler(SalePageAddOrEditForm_AfterSelector);
                (e.Control as DataWindow).AfterSelector += new AfterSelectorEventHandler(SalePageAddOrEditForm_AfterSelector);
            }
        }

        private void SalePageAddOrEditForm_AfterSelector(object sender, AfterSelectorEventArgs e)
        {
            var cc = e.Value.DataBoundItem as Person; 
            dataGridView1.Rows[e.RowIndex].Cells[1].Value = cc.name;
 
        }
    }
}
