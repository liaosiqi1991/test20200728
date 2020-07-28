namespace zlMedimgSystem.CTL.ReportView
{
    partial class ReportViewControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportViewControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbxReports = new System.Windows.Forms.ToolStripComboBox();
            this.tsbPreview = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLabCritical = new System.Windows.Forms.ToolStripLabel();
            this.tsLabNP = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLabState = new System.Windows.Forms.ToolStripLabel();
            this.panelReport = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Gray;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbxReports,
            this.tsbPreview,
            this.tsbPrint,
            this.toolStripSeparator1,
            this.tsbRefresh,
            this.toolStripSeparator2,
            this.tsLabCritical,
            this.tsLabNP,
            this.toolStripSeparator3,
            this.tsLabState});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(718, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cbxReports
            // 
            this.cbxReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxReports.Name = "cbxReports";
            this.cbxReports.Size = new System.Drawing.Size(130, 31);
            this.cbxReports.SelectedIndexChanged += new System.EventHandler(this.cbxReports_SelectedIndexChanged);
            // 
            // tsbPreview
            // 
            this.tsbPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPreview.Image = global::zlMedimgSystem.CTL.ReportView.Properties.Resources.preview;
            this.tsbPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPreview.Name = "tsbPreview";
            this.tsbPreview.Size = new System.Drawing.Size(28, 28);
            this.tsbPreview.Text = "预览";
            this.tsbPreview.Click += new System.EventHandler(this.tsbPreview_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Image = global::zlMedimgSystem.CTL.ReportView.Properties.Resources.print;
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(28, 28);
            this.tsbPrint.Text = "打印";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = global::zlMedimgSystem.CTL.ReportView.Properties.Resources.refresh;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(28, 28);
            this.tsbRefresh.Text = "刷新";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsLabCritical
            // 
            this.tsLabCritical.BackColor = System.Drawing.Color.Gray;
            this.tsLabCritical.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsLabCritical.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tsLabCritical.Image = global::zlMedimgSystem.CTL.ReportView.Properties.Resources.unchecked2;
            this.tsLabCritical.Name = "tsLabCritical";
            this.tsLabCritical.Size = new System.Drawing.Size(75, 28);
            this.tsLabCritical.Text = "危急重";
            // 
            // tsLabNP
            // 
            this.tsLabNP.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsLabNP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tsLabNP.Image = global::zlMedimgSystem.CTL.ReportView.Properties.Resources.unchecked2;
            this.tsLabNP.Name = "tsLabNP";
            this.tsLabNP.Size = new System.Drawing.Size(61, 28);
            this.tsLabNP.Text = "阳性";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // tsLabState
            // 
            this.tsLabState.ForeColor = System.Drawing.Color.White;
            this.tsLabState.Name = "tsLabState";
            this.tsLabState.Size = new System.Drawing.Size(158, 28);
            this.tsLabState.Text = "报告人：        ×打印 ×发放";
            // 
            // panelReport
            // 
            this.panelReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReport.Location = new System.Drawing.Point(0, 31);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(718, 458);
            this.panelReport.TabIndex = 16;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "unchecked.ico");
            this.imageList1.Images.SetKeyName(1, "checked.ico");
            // 
            // ReportViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelReport);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ReportViewControl";
            this.Size = new System.Drawing.Size(718, 489);
            this.Load += new System.EventHandler(this.ReportViewControl_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cbxReports;
        private System.Windows.Forms.ToolStripButton tsbPreview;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.Panel panelReport;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel tsLabCritical;
        private System.Windows.Forms.ToolStripLabel tsLabNP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel tsLabState;
        private System.Windows.Forms.ImageList imageList1;
    }
}
