namespace zlMedimgSystem.BaseSettings
{
    partial class frmReportDataConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbTest = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxDBSource = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.rtbContext = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbTest,
            this.tsbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(940, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = global::zlMedimgSystem.BaseSettings.Properties.Resources.check;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(75, 28);
            this.tsbSave.Text = "确定(&S)";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbTest
            // 
            this.tsbTest.Image = global::zlMedimgSystem.BaseSettings.Properties.Resources.debug_view;
            this.tsbTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTest.Name = "tsbTest";
            this.tsbTest.Size = new System.Drawing.Size(75, 28);
            this.tsbTest.Text = "测试(&T)";
            this.tsbTest.Click += new System.EventHandler(this.tsbTest_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::zlMedimgSystem.BaseSettings.Properties.Resources.exit;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(76, 28);
            this.tsbExit.Text = "取消(&C)";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxDBSource);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 35);
            this.panel1.TabIndex = 1;
            // 
            // cbxDBSource
            // 
            this.cbxDBSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDBSource.FormattingEnabled = true;
            this.cbxDBSource.Location = new System.Drawing.Point(270, 8);
            this.cbxDBSource.Name = "cbxDBSource";
            this.cbxDBSource.Size = new System.Drawing.Size(154, 20);
            this.cbxDBSource.TabIndex = 3;
            this.cbxDBSource.SelectedIndexChanged += new System.EventHandler(this.cbxDBSource_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据源";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "查询名称";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(63, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(154, 21);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // rtbContext
            // 
            this.rtbContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContext.Location = new System.Drawing.Point(0, 56);
            this.rtbContext.Name = "rtbContext";
            this.rtbContext.Size = new System.Drawing.Size(786, 171);
            this.rtbContext.TabIndex = 2;
            this.rtbContext.Text = "";
            this.rtbContext.TextChanged += new System.EventHandler(this.rtbContext_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 296);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(940, 287);
            this.dataGridView1.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 293);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(940, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtbContext);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(940, 227);
            this.panel2.TabIndex = 5;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
            "[申请识别码]",
            "[患者识别码]",
            "[申请ID]",
            "[患者ID]",
            "[用户ID]",
            "[设备ID]",
            "[科室ID]",
            "[院区编码]"});
            this.listBox1.Location = new System.Drawing.Point(786, 56);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(154, 171);
            this.listBox1.TabIndex = 3;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2);
            this.label3.Size = new System.Drawing.Size(940, 56);
            this.label3.TabIndex = 7;
            this.label3.Text = "JSON字段查询说明：\r\n    当查询中，需要对JSON字段中的数据进行查询时，需要使用如下格式构造查询字段，\r\n    查询格式为：<json:患者信息 = " +
    "姓名,性别(0-男|1-女),年龄,住院号,门诊号 /json>\r\n    患者信息表示JSON的字段名称，“=”等号之后的内容表示需要返回的JSON数据。";
            // 
            // frmReportDataConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 583);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmReportDataConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模板数据配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReportDataConfig_FormClosing);
            this.Load += new System.EventHandler(this.frmReportDataConfig_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxDBSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RichTextBox rtbContext;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbTest;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
    }
}