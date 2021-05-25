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
    public partial class DataWindow : ComboBox
    {
        private const int WM_LBUTTONDOWN = 0x201, WM_LBUTTONDBLCLK = 0x203;
        public event AfterSelectorEventHandler AfterSelector;
        private bool m_blDropShow = false;
        private int m_SelectedIndex = -1;
        private bool m_blPopupAutoSize = true;
        private ToolStripControlHost dataGridViewHost;
        private ToolStripControlHost textBoxHost;
        private ToolStripDropDown dropDown;

        /// <summary>
        /// 保存选择的id
        /// </summary>
        public object value { get; set; }

        public DataWindow()
        {
            DrawDataGridView();
        }

        /// <summary>
        /// 设置数据源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void setDataSource<T>(List<T> list)
        {
            DataGridView.Columns.Clear();
            //DataGridView.AutoGenerateColumns = false;
            DataGridView.DataSource = list;
        }
        object _DataSource;
        public new object DataSource
        {
            get
            {
                return DataGridView.DataSource;
            }
            set
            {
                DataGridView.DataSource = value;
               _DataSource = value;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            ShowDropDown();
        }

        /// <summary>
        /// 取值字段
        /// </summary>
        public string sValueMember { get; set; }

        /// <summary>
        /// 下拉表格显示列，空为显示所有列！
        /// </summary>
        public string sDisplayField { get; set; }
        /// <summary>
        /// 查询字段
        /// </summary>
        public string sKeyWords { get; set; }
        private void ShowDropDown()
        {
            if (dropDown != null)
            {
                if (DataSource != null)
                {
                    //DataView.RowFilter = "";
                    TextBox.Text = "";
                    textBoxHost.Width = DropDownWidth;
                    dataGridViewHost.AutoSize = true;
                    dataGridViewHost.Size = new Size(DropDownWidth - 2, DropDownHeight);
                    dropDown.Show(this, 0, this.Height);
                    TextBox.Focus();
                }
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                this.TextBox.Text = e.KeyChar.ToString();
                this.TextBox.SelectionStart = this.TextBox.Text.Length;
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }
        private void DrawDataGridView()
        {
            DataGridView dataGridView = new DataGridView();
            dataGridView.ScrollBars = ScrollBars.Both;
            dataGridView.AutoSize = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.Dock = DockStyle.Fill;

            dataGridView.BackgroundColor = SystemColors.Control;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.DoubleClick += new EventHandler(dataGridView_DoubleClick);
            dataGridView.KeyDown += new KeyEventHandler(dataGridView_KeyDown);

            //设置DataGridView的数据源
            Form frmDataSource = new Form();
            frmDataSource.Controls.Add(dataGridView);
            frmDataSource.SuspendLayout();
            dataGridViewHost = new ToolStripControlHost(dataGridView);
            dataGridViewHost.AutoSize = m_blPopupAutoSize;

            TextBox textBox = new TextBox();
            textBox.BackColor = Color.Red;
            textBox.Width = dataGridView.Width;
            textBox.TextChanged += new EventHandler(textBox_TextChanged);
            textBox.KeyDown += new KeyEventHandler(textBox_KeyDown);
            textBoxHost = new ToolStripControlHost(textBox);
            textBoxHost.AutoSize = false;

            dropDown = new ToolStripDropDown();
            dropDown.Items.Add(textBoxHost);
            dropDown.Items.Add(dataGridViewHost);
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                PopupGridView(e);
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                PopupGridView(e);
            }
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            PopupGridView(e);
        }
        protected void OnAfterSelector(object sender, AfterSelectorEventArgs e)
        {
            if (AfterSelector != null)
            {
                AfterSelector(sender, e);
            }
        }
        protected virtual void RaiseAfterSelector(object sender, AfterSelectorEventArgs e)
        {
            OnAfterSelector(sender, e);
        }
        private void PopupGridView(EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvRow = DataGridView.CurrentRow;
                m_SelectedIndex = DataGridView.CurrentRow.Index;
                this.value = dgvRow.Cells[0].Value;//此处默认第1列为  key
                this.Text = dgvRow.Cells[1].Value?.ToString();  //此处默认第2列为 文本
                RaiseAfterSelector(this, new AfterSelectorEventArgs(-1, -1, dgvRow));
                dropDown.Close();
                m_blDropShow = false;
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK || m.Msg == WM_LBUTTONDOWN)
            {
                if (m_blDropShow)
                {
                    m_blDropShow = false;
                }
                else
                {
                    m_blDropShow = true;
                }
                if (m_blDropShow)
                {
                    ShowDropDown();
                }
                else
                {
                    dropDown.Close();
                }
                return;
            }
            base.WndProc(ref m);
        }
        public DataGridView DataGridView
        {
            get
            {
                return dataGridViewHost.Control as DataGridView;
            }
        }
        public TextBox TextBox
        {
            get
            {
                return textBoxHost.Control as TextBox;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dropDown != null)
                {
                    dropDown.Dispose();
                    dropDown = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}




