namespace zlMedimgSystem.CTL.ImgProcess
{
    partial class frmImageProcess
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImageProcess));
            this.imageProcessControl1 = new openCV.ImageProcessControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butConfig = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.butWrite = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSaveStudy = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageView1 = new zlMedimgSystem.BusinessBase.Controls.ImageView();
            this.splitPage1 = new zlMedimgSystem.BusinessBase.Controls.SplitPage();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageProcessControl1
            // 
            this.imageProcessControl1.Alpha = 0D;
            this.imageProcessControl1.B = 0;
            this.imageProcessControl1.Beta = 0D;
            this.imageProcessControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageProcessControl1.G = 0;
            this.imageProcessControl1.Location = new System.Drawing.Point(238, 31);
            this.imageProcessControl1.Name = "imageProcessControl1";
            this.imageProcessControl1.R = 0;
            this.imageProcessControl1.Size = new System.Drawing.Size(703, 485);
            this.imageProcessControl1.TabIndex = 0;
            this.imageProcessControl1.Text = "imageProcessControl1";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(235, 31);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 528);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butConfig);
            this.panel1.Controls.Add(this.butWrite);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(238, 516);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 43);
            this.panel1.TabIndex = 3;
            // 
            // butConfig
            // 
            this.butConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butConfig.ImageIndex = 2;
            this.butConfig.ImageList = this.imageList1;
            this.butConfig.Location = new System.Drawing.Point(632, 4);
            this.butConfig.Name = "butConfig";
            this.butConfig.Size = new System.Drawing.Size(68, 30);
            this.butConfig.TabIndex = 3;
            this.butConfig.Text = "设置";
            this.butConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butConfig.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "note_edit.ico");
            this.imageList1.Images.SetKeyName(1, "gear.ico");
            this.imageList1.Images.SetKeyName(2, "text_tree.ico");
            // 
            // butWrite
            // 
            this.butWrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butWrite.ImageIndex = 0;
            this.butWrite.ImageList = this.imageList1;
            this.butWrite.Location = new System.Drawing.Point(558, 4);
            this.butWrite.Name = "butWrite";
            this.butWrite.Size = new System.Drawing.Size(72, 30);
            this.butWrite.TabIndex = 2;
            this.butWrite.Text = "写入";
            this.butWrite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butWrite.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butWrite.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(38, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(518, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "备注";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbExport,
            this.toolStripSeparator2,
            this.tsbSaveStudy,
            this.tsbSaveReport,
            this.toolStripSeparator1,
            this.tsbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(941, 31);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = global::zlMedimgSystem.CTL.ImgProcess.Properties.Resources.foldernormal;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(96, 28);
            this.tsbOpen.Text = "导入本地图";
            this.tsbOpen.Visible = false;
            // 
            // tsbExport
            // 
            this.tsbExport.Image = global::zlMedimgSystem.CTL.ImgProcess.Properties.Resources.folder_into;
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(84, 28);
            this.tsbExport.Text = "导出图像";
            this.tsbExport.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbSaveStudy
            // 
            this.tsbSaveStudy.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveStudy.Image")));
            this.tsbSaveStudy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveStudy.Name = "tsbSaveStudy";
            this.tsbSaveStudy.Size = new System.Drawing.Size(84, 28);
            this.tsbSaveStudy.Text = "保存修改";
            this.tsbSaveStudy.Click += new System.EventHandler(this.tsbSaveStudy_Click);
            // 
            // tsbSaveReport
            // 
            this.tsbSaveReport.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveReport.Image")));
            this.tsbSaveReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveReport.Name = "tsbSaveReport";
            this.tsbSaveReport.Size = new System.Drawing.Size(96, 28);
            this.tsbSaveReport.Text = "添加到报告";
            this.tsbSaveReport.Click += new System.EventHandler(this.tsbSaveReport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(60, 28);
            this.tsbExit.Text = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.imageView1);
            this.panel2.Controls.Add(this.splitPage1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 528);
            this.panel2.TabIndex = 5;
            // 
            // imageView1
            // 
            this.imageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageView1.Location = new System.Drawing.Point(0, 0);
            this.imageView1.Name = "imageView1";
            this.imageView1.Size = new System.Drawing.Size(235, 496);
            this.imageView1.TabIndex = 0;
            this.imageView1.ViewCount = 8;
            this.imageView1.OnItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.imageView1_OnItemClick);
            // 
            // splitPage1
            // 
            this.splitPage1.BackColor = System.Drawing.Color.Gray;
            this.splitPage1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitPage1.Location = new System.Drawing.Point(0, 496);
            this.splitPage1.Name = "splitPage1";
            this.splitPage1.Size = new System.Drawing.Size(235, 32);
            this.splitPage1.TabIndex = 1;
            this.splitPage1.OnPageChanged += new zlMedimgSystem.BusinessBase.Controls.SplitPage.EventPageChanged(this.splitPage1_OnPageChanged);
            // 
            // frmImageProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 559);
            this.Controls.Add(this.imageProcessControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmImageProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图像处理";
            this.Load += new System.EventHandler(this.frmImageProcess_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private openCV.ImageProcessControl imageProcessControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butConfig;
        private System.Windows.Forms.Button butWrite;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSaveStudy;
        private System.Windows.Forms.ToolStripButton tsbSaveReport;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel2;
        private BusinessBase.Controls.SplitPage splitPage1;
        private BusinessBase.Controls.ImageView imageView1;
    }
}