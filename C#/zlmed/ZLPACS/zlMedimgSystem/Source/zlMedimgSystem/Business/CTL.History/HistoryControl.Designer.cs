namespace zlMedimgSystem.CTL.History
{
    partial class HistoryControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.cMenuStripCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new BusinessBase.Controls.ToolStripEx();
            this.tscbxReports = new System.Windows.Forms.ToolStripComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tsbPreview = new System.Windows.Forms.ToolStripButton();
            this.tsbImages = new System.Windows.Forms.ToolStripButton();
            this.tsbWriteReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmDateRange1m = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDateRange2m = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDateRange3m = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDateRange6m = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDateRange1y = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDateRange2y = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDateRange3y = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDateRangeAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 150);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(323, 412);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuStripCopy});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 26);
            // 
            // cMenuStripCopy
            // 
            this.cMenuStripCopy.Name = "cMenuStripCopy";
            this.cMenuStripCopy.Size = new System.Drawing.Size(116, 22);
            this.cMenuStripCopy.Text = "复制(C)";
            this.cMenuStripCopy.Click += new System.EventHandler(this.cMenuStripCopy_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Gray;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbxReports,
            this.tsbPreview,
            this.tsbImages,
            this.tsbWriteReport,
            this.toolStripDropDownButton1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 562);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(323, 31);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tscbxReports
            // 
            this.tscbxReports.AutoSize = false;
            this.tscbxReports.BackColor = System.Drawing.Color.Gray;
            this.tscbxReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbxReports.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tscbxReports.ForeColor = System.Drawing.Color.White;
            this.tscbxReports.Items.AddRange(new object[] {
            "(1/1主报告)"});
            this.tscbxReports.Name = "tscbxReports";
            this.tscbxReports.Size = new System.Drawing.Size(130, 31);
            this.tscbxReports.SelectedIndexChanged += new System.EventHandler(this.tscbxReports_SelectedIndexChanged);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(323, 147);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 147);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(323, 3);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // tsbPreview
            // 
            this.tsbPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPreview.Image = global::zlMedimgSystem.CTL.History.Properties.Resources.preview;
            this.tsbPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPreview.Name = "tsbPreview";
            this.tsbPreview.Size = new System.Drawing.Size(28, 28);
            this.tsbPreview.Text = "报告预览";
            this.tsbPreview.Click += new System.EventHandler(this.tsbPreview_Click);
            // 
            // tsbImages
            // 
            this.tsbImages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbImages.Image = global::zlMedimgSystem.CTL.History.Properties.Resources.imagesview;
            this.tsbImages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImages.Name = "tsbImages";
            this.tsbImages.Size = new System.Drawing.Size(28, 28);
            this.tsbImages.Text = "图像查看";
            this.tsbImages.Click += new System.EventHandler(this.tsbImages_Click);
            // 
            // tsbWriteReport
            // 
            this.tsbWriteReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbWriteReport.Image = global::zlMedimgSystem.CTL.History.Properties.Resources.Symbol_Pencil_2;
            this.tsbWriteReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWriteReport.Name = "tsbWriteReport";
            this.tsbWriteReport.Size = new System.Drawing.Size(28, 28);
            this.tsbWriteReport.Text = "文本发送";
            this.tsbWriteReport.Click += new System.EventHandler(this.tsbWriteReport_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDateRange1m,
            this.tsmDateRange2m,
            this.tsmDateRange3m,
            this.tsmDateRange6m,
            this.tsmDateRange1y,
            this.tsmDateRange2y,
            this.tsmDateRange3y,
            this.tsmDateRangeAll});
            this.toolStripDropDownButton1.Image = global::zlMedimgSystem.CTL.History.Properties.Resources.calendar;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(37, 28);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // tsmDateRange1m
            // 
            this.tsmDateRange1m.Name = "tsmDateRange1m";
            this.tsmDateRange1m.Size = new System.Drawing.Size(180, 22);
            this.tsmDateRange1m.Tag = "30";
            this.tsmDateRange1m.Text = "近一月(&A)";
            this.tsmDateRange1m.Click += new System.EventHandler(this.tsmDateRangeAll_Click);
            // 
            // tsmDateRange2m
            // 
            this.tsmDateRange2m.Name = "tsmDateRange2m";
            this.tsmDateRange2m.Size = new System.Drawing.Size(180, 22);
            this.tsmDateRange2m.Tag = "60";
            this.tsmDateRange2m.Text = "近二月(&B)";
            this.tsmDateRange2m.Click += new System.EventHandler(this.tsmDateRangeAll_Click);
            // 
            // tsmDateRange3m
            // 
            this.tsmDateRange3m.Name = "tsmDateRange3m";
            this.tsmDateRange3m.Size = new System.Drawing.Size(180, 22);
            this.tsmDateRange3m.Tag = "90";
            this.tsmDateRange3m.Text = "近三月(&C)";
            this.tsmDateRange3m.Click += new System.EventHandler(this.tsmDateRangeAll_Click);
            // 
            // tsmDateRange6m
            // 
            this.tsmDateRange6m.Name = "tsmDateRange6m";
            this.tsmDateRange6m.Size = new System.Drawing.Size(180, 22);
            this.tsmDateRange6m.Tag = "180";
            this.tsmDateRange6m.Text = "近半年(&D)";
            this.tsmDateRange6m.Click += new System.EventHandler(this.tsmDateRangeAll_Click);
            // 
            // tsmDateRange1y
            // 
            this.tsmDateRange1y.Name = "tsmDateRange1y";
            this.tsmDateRange1y.Size = new System.Drawing.Size(180, 22);
            this.tsmDateRange1y.Tag = "365";
            this.tsmDateRange1y.Text = "近一年(&E)";
            this.tsmDateRange1y.Click += new System.EventHandler(this.tsmDateRangeAll_Click);
            // 
            // tsmDateRange2y
            // 
            this.tsmDateRange2y.Name = "tsmDateRange2y";
            this.tsmDateRange2y.Size = new System.Drawing.Size(180, 22);
            this.tsmDateRange2y.Tag = "730";
            this.tsmDateRange2y.Text = "近二年(&F)";
            this.tsmDateRange2y.Click += new System.EventHandler(this.tsmDateRangeAll_Click);
            // 
            // tsmDateRange3y
            // 
            this.tsmDateRange3y.Name = "tsmDateRange3y";
            this.tsmDateRange3y.Size = new System.Drawing.Size(180, 22);
            this.tsmDateRange3y.Tag = "1095";
            this.tsmDateRange3y.Text = "近三年(&G)";
            this.tsmDateRange3y.Click += new System.EventHandler(this.tsmDateRangeAll_Click);
            // 
            // tsmDateRangeAll
            // 
            this.tsmDateRangeAll.Name = "tsmDateRangeAll";
            this.tsmDateRangeAll.Size = new System.Drawing.Size(180, 22);
            this.tsmDateRangeAll.Tag = "0";
            this.tsmDateRangeAll.Text = "所有(&H)";
            this.tsmDateRangeAll.Click += new System.EventHandler(this.tsmDateRangeAll_Click);
            // 
            // HistoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.listView1);
            this.Name = "HistoryControl";
            this.Size = new System.Drawing.Size(323, 593);
            this.Load += new System.EventHandler(this.HistoryControl_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BusinessBase.Controls.ToolStripEx toolStrip2;
        private System.Windows.Forms.ToolStripComboBox tscbxReports;
        private System.Windows.Forms.ToolStripButton tsbPreview;
        private System.Windows.Forms.ToolStripButton tsbImages;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripButton tsbWriteReport;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cMenuStripCopy;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tsmDateRange1m;
        private System.Windows.Forms.ToolStripMenuItem tsmDateRange2m;
        private System.Windows.Forms.ToolStripMenuItem tsmDateRange3m;
        private System.Windows.Forms.ToolStripMenuItem tsmDateRange6m;
        private System.Windows.Forms.ToolStripMenuItem tsmDateRange1y;
        private System.Windows.Forms.ToolStripMenuItem tsmDateRange2y;
        private System.Windows.Forms.ToolStripMenuItem tsmDateRange3y;
        private System.Windows.Forms.ToolStripMenuItem tsmDateRangeAll;
    }
}
