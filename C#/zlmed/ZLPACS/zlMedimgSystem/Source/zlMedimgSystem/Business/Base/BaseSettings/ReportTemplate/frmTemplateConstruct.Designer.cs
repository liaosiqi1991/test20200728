namespace zlMedimgSystem.BaseSettings
{
    partial class frmTemplateConstruct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTemplateConstruct));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbImport = new System.Windows.Forms.ToolStripButton();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsbNewDataSource = new System.Windows.Forms.ToolStripButton();
            this.tsbEditDataSource = new System.Windows.Forms.ToolStripButton();
            this.tsbDelDataSource = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExamItemReleation = new System.Windows.Forms.ToolStripButton();
            this.tsbSectionConfig = new System.Windows.Forms.ToolStripButton();
            this.tsbWords = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.lbxExamItem = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.listDataSource = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbxSection = new System.Windows.Forms.ListView();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbImport,
            this.tsbExport,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tsbNewDataSource,
            this.tsbEditDataSource,
            this.tsbDelDataSource,
            this.toolStripSeparator2,
            this.tsbExamItemReleation,
            this.tsbSectionConfig,
            this.tsbWords,
            this.toolStripSeparator3,
            this.tsbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1039, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(60, 28);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbImport
            // 
            this.tsbImport.Image = ((System.Drawing.Image)(resources.GetObject("tsbImport.Image")));
            this.tsbImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImport.Name = "tsbImport";
            this.tsbImport.Size = new System.Drawing.Size(60, 28);
            this.tsbImport.Text = "导入";
            // 
            // tsbExport
            // 
            this.tsbExport.Image = ((System.Drawing.Image)(resources.GetObject("tsbExport.Image")));
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(60, 28);
            this.tsbExport.Text = "导出";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 28);
            this.toolStripLabel1.Text = "数据源：";
            // 
            // tsbNewDataSource
            // 
            this.tsbNewDataSource.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewDataSource.Image")));
            this.tsbNewDataSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewDataSource.Name = "tsbNewDataSource";
            this.tsbNewDataSource.Size = new System.Drawing.Size(60, 28);
            this.tsbNewDataSource.Text = "新增";
            this.tsbNewDataSource.Click += new System.EventHandler(this.tsbNewDataSource_Click);
            // 
            // tsbEditDataSource
            // 
            this.tsbEditDataSource.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditDataSource.Image")));
            this.tsbEditDataSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditDataSource.Name = "tsbEditDataSource";
            this.tsbEditDataSource.Size = new System.Drawing.Size(60, 28);
            this.tsbEditDataSource.Text = "编辑";
            this.tsbEditDataSource.Click += new System.EventHandler(this.tsbEditDataSource_Click);
            // 
            // tsbDelDataSource
            // 
            this.tsbDelDataSource.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelDataSource.Image")));
            this.tsbDelDataSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelDataSource.Name = "tsbDelDataSource";
            this.tsbDelDataSource.Size = new System.Drawing.Size(60, 28);
            this.tsbDelDataSource.Text = "删除";
            this.tsbDelDataSource.Click += new System.EventHandler(this.tsbDelDataSource_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbExamItemReleation
            // 
            this.tsbExamItemReleation.Image = global::zlMedimgSystem.BaseSettings.Properties.Resources.document_notebook;
            this.tsbExamItemReleation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExamItemReleation.Name = "tsbExamItemReleation";
            this.tsbExamItemReleation.Size = new System.Drawing.Size(84, 28);
            this.tsbExamItemReleation.Text = "项目设置";
            this.tsbExamItemReleation.Click += new System.EventHandler(this.tsbExamItemReleation_Click);
            // 
            // tsbSectionConfig
            // 
            this.tsbSectionConfig.Image = global::zlMedimgSystem.BaseSettings.Properties.Resources.text_tree;
            this.tsbSectionConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSectionConfig.Name = "tsbSectionConfig";
            this.tsbSectionConfig.Size = new System.Drawing.Size(84, 28);
            this.tsbSectionConfig.Text = "段落设置";
            this.tsbSectionConfig.Click += new System.EventHandler(this.tsbSectionConfig_Click);
            // 
            // tsbWords
            // 
            this.tsbWords.Image = ((System.Drawing.Image)(resources.GetObject("tsbWords.Image")));
            this.tsbWords.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWords.Name = "tsbWords";
            this.tsbWords.Size = new System.Drawing.Size(84, 28);
            this.tsbWords.Text = "词句设置";
            this.tsbWords.Click += new System.EventHandler(this.tsbWords_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::zlMedimgSystem.BaseSettings.Properties.Resources.exit;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(60, 28);
            this.tsbExit.Text = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.splitter3);
            this.panel1.Controls.Add(this.lbxSection);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.lbxExamItem);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.listDataSource);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 543);
            this.panel1.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder_closed.ico");
            this.imageList1.Images.SetKeyName(1, "folder_ok.ico");
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(0, 212);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(3);
            this.label4.Size = new System.Drawing.Size(289, 21);
            this.label4.TabIndex = 24;
            this.label4.Text = "    关联段落";
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 209);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(289, 3);
            this.splitter2.TabIndex = 21;
            this.splitter2.TabStop = false;
            // 
            // lbxExamItem
            // 
            this.lbxExamItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lbxExamItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbxExamItem.FormattingEnabled = true;
            this.lbxExamItem.ItemHeight = 12;
            this.lbxExamItem.Location = new System.Drawing.Point(0, 121);
            this.lbxExamItem.Name = "lbxExamItem";
            this.lbxExamItem.ScrollAlwaysVisible = true;
            this.lbxExamItem.Size = new System.Drawing.Size(289, 88);
            this.lbxExamItem.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(0, 100);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(289, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "    关联项目";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 97);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(289, 3);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            // 
            // listDataSource
            // 
            this.listDataSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.listDataSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.listDataSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listDataSource.FormattingEnabled = true;
            this.listDataSource.ItemHeight = 12;
            this.listDataSource.Location = new System.Drawing.Point(0, 21);
            this.listDataSource.Name = "listDataSource";
            this.listDataSource.Size = new System.Drawing.Size(289, 76);
            this.listDataSource.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(289, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "    模板数据定义";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 574);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1039, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(289, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(750, 543);
            this.panel2.TabIndex = 9;
            // 
            // lbxSection
            // 
            this.lbxSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lbxSection.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbxSection.FullRowSelect = true;
            this.lbxSection.Location = new System.Drawing.Point(0, 233);
            this.lbxSection.MultiSelect = false;
            this.lbxSection.Name = "lbxSection";
            this.lbxSection.Size = new System.Drawing.Size(289, 89);
            this.lbxSection.TabIndex = 25;
            this.lbxSection.UseCompatibleStateImageBehavior = false;
            this.lbxSection.View = System.Windows.Forms.View.Details;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 322);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(289, 3);
            this.splitter3.TabIndex = 26;
            this.splitter3.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 346);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(289, 197);
            this.treeView1.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(0, 325);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3);
            this.label3.Size = new System.Drawing.Size(289, 21);
            this.label3.TabIndex = 29;
            this.label3.Text = "    关联词句分类";
            // 
            // frmTemplateConstruct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 596);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmTemplateConstruct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模板构造";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTemplateConstruct_FormClosing);
            this.Load += new System.EventHandler(this.frmTemplateConstruct_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listDataSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbImport;
        private System.Windows.Forms.ToolStripButton tsbExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsbNewDataSource;
        private System.Windows.Forms.ToolStripButton tsbEditDataSource;
        private System.Windows.Forms.ToolStripButton tsbDelDataSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbWords;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton tsbSectionConfig;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ListBox lbxExamItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton tsbExamItemReleation;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.ListView lbxSection;
    }
}