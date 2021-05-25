
namespace 巧用_ToolStripControlHost_自定义WinForm右键菜单
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataWindow1 = new 巧用_ToolStripControlHost_自定义WinForm右键菜单.DataWindow();
            this.userControl21 = new 巧用_ToolStripControlHost_自定义WinForm右键菜单.DataWindow();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(292, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(251, 21);
            this.textBox1.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(23, 212);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(667, 222);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // dataWindow1
            // 
            this.dataWindow1.FormattingEnabled = true;
            this.dataWindow1.Location = new System.Drawing.Point(37, 166);
            this.dataWindow1.Name = "dataWindow1";
            this.dataWindow1.sDisplayField = null;
            this.dataWindow1.Size = new System.Drawing.Size(506, 20);
            this.dataWindow1.sKeyWords = null;
            this.dataWindow1.sValueMember = null;
            this.dataWindow1.TabIndex = 6;
            this.dataWindow1.SelectedValue = 0;
            this.dataWindow1.AfterSelector += new 巧用_ToolStripControlHost_自定义WinForm右键菜单.AfterSelectorEventHandler(this.dataWindow1_AfterSelector);
            // 
            // userControl21
            // 
            this.userControl21.FormattingEnabled = true;
            this.userControl21.Location = new System.Drawing.Point(37, 122);
            this.userControl21.Name = "userControl21";
            this.userControl21.sDisplayField = null;
            this.userControl21.Size = new System.Drawing.Size(506, 20);
            this.userControl21.sKeyWords = null;
            this.userControl21.sValueMember = null;
            this.userControl21.TabIndex = 5;
            this.userControl21.SelectedValue = 0;
            this.userControl21.AfterSelector += new 巧用_ToolStripControlHost_自定义WinForm右键菜单.AfterSelectorEventHandler(this.userControl21_AfterSelector);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 497);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataWindow1);
            this.Controls.Add(this.userControl21);
            this.Controls.Add(this.button1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DataWindow userControl21;
        private DataWindow dataWindow1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

