namespace zlMedimgSystem.CTL.BehindCode
{
    partial class frmBehindCodeModuleDesign
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
            this.lbMethodName = new System.Windows.Forms.ListBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.rtbContext = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxDBAlias = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripEx1 = new zlMedimgSystem.BusinessBase.Controls.ToolStripEx();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbVs = new System.Windows.Forms.ToolStripButton();
            this.tsTemplate = new System.Windows.Forms.ToolStripButton();
            this.tsbDebug = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.txtVer = new System.Windows.Forms.TextBox();
            this.labVer = new System.Windows.Forms.Label();
            this.chkBGCompile = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.toolStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMethodName
            // 
            this.lbMethodName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbMethodName.FormattingEnabled = true;
            this.lbMethodName.ItemHeight = 12;
            this.lbMethodName.Location = new System.Drawing.Point(0, 31);
            this.lbMethodName.Name = "lbMethodName";
            this.lbMethodName.Size = new System.Drawing.Size(222, 397);
            this.lbMethodName.TabIndex = 1;
            this.lbMethodName.SelectedIndexChanged += new System.EventHandler(this.lbMethodName_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(222, 31);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 397);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // rtbContext
            // 
            this.rtbContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContext.Location = new System.Drawing.Point(225, 101);
            this.rtbContext.Name = "rtbContext";
            this.rtbContext.Size = new System.Drawing.Size(575, 327);
            this.rtbContext.TabIndex = 3;
            this.rtbContext.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkBGCompile);
            this.panel1.Controls.Add(this.txtVer);
            this.panel1.Controls.Add(this.labVer);
            this.panel1.Controls.Add(this.cbxDBAlias);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(225, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 70);
            this.panel1.TabIndex = 4;
            // 
            // cbxDBAlias
            // 
            this.cbxDBAlias.FormattingEnabled = true;
            this.cbxDBAlias.Location = new System.Drawing.Point(72, 39);
            this.cbxDBAlias.Name = "cbxDBAlias";
            this.cbxDBAlias.Size = new System.Drawing.Size(139, 20);
            this.cbxDBAlias.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "三方数据源";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(72, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(229, 21);
            this.tbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "执行名称";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbDel,
            this.tsbUpdate,
            this.toolStripSeparator1,
            this.tsbVs,
            this.tsTemplate,
            this.tsbDebug,
            this.toolStripSeparator2,
            this.tsbSave,
            this.tsbExit});
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Size = new System.Drawing.Size(800, 31);
            this.toolStripEx1.TabIndex = 0;
            this.toolStripEx1.Text = "toolStripEx1";
            // 
            // tsbNew
            // 
            this.tsbNew.Image = global::zlMedimgSystem.CTL.BehindCode.Properties.Resources.newcode;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(60, 28);
            this.tsbNew.Text = "新增";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = global::zlMedimgSystem.CTL.BehindCode.Properties.Resources.delcode;
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(60, 28);
            this.tsbDel.Text = "删除";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.Image = global::zlMedimgSystem.CTL.BehindCode.Properties.Resources.updatecode;
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(60, 28);
            this.tsbUpdate.Text = "更新";
            this.tsbUpdate.Click += new System.EventHandler(this.tsbUpdate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbVs
            // 
            this.tsbVs.Image = global::zlMedimgSystem.CTL.BehindCode.Properties.Resources.vs;
            this.tsbVs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVs.Name = "tsbVs";
            this.tsbVs.Size = new System.Drawing.Size(87, 28);
            this.tsbVs.Text = "VS中编辑";
            this.tsbVs.Click += new System.EventHandler(this.tsbVs_Click);
            // 
            // tsTemplate
            // 
            this.tsTemplate.Image = global::zlMedimgSystem.CTL.BehindCode.Properties.Resources.codetemplate;
            this.tsTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsTemplate.Name = "tsTemplate";
            this.tsTemplate.Size = new System.Drawing.Size(84, 28);
            this.tsTemplate.Text = "载入模板";
            this.tsTemplate.Click += new System.EventHandler(this.tsTemplate_Click);
            // 
            // tsbDebug
            // 
            this.tsbDebug.Image = global::zlMedimgSystem.CTL.BehindCode.Properties.Resources.debug_view;
            this.tsbDebug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDebug.Name = "tsbDebug";
            this.tsbDebug.Size = new System.Drawing.Size(60, 28);
            this.tsbDebug.Text = "验证";
            this.tsbDebug.Click += new System.EventHandler(this.tsbDebug_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = global::zlMedimgSystem.CTL.BehindCode.Properties.Resources.disk_blue;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(60, 28);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::zlMedimgSystem.CTL.BehindCode.Properties.Resources.exit;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(60, 28);
            this.tsbExit.Text = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // txtVer
            // 
            this.txtVer.Location = new System.Drawing.Point(264, 39);
            this.txtVer.Name = "txtVer";
            this.txtVer.ReadOnly = true;
            this.txtVer.Size = new System.Drawing.Size(71, 21);
            this.txtVer.TabIndex = 7;
            this.txtVer.Text = "1";
            // 
            // labVer
            // 
            this.labVer.AutoSize = true;
            this.labVer.Location = new System.Drawing.Point(217, 42);
            this.labVer.Name = "labVer";
            this.labVer.Size = new System.Drawing.Size(41, 12);
            this.labVer.TabIndex = 6;
            this.labVer.Text = "版本号";
            // 
            // chkBGCompile
            // 
            this.chkBGCompile.AutoSize = true;
            this.chkBGCompile.Location = new System.Drawing.Point(341, 41);
            this.chkBGCompile.Name = "chkBGCompile";
            this.chkBGCompile.Size = new System.Drawing.Size(72, 16);
            this.chkBGCompile.TabIndex = 8;
            this.chkBGCompile.Text = "后台编译";
            this.chkBGCompile.UseVisualStyleBackColor = true;
            // 
            // frmBehindCodeModuleDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbContext);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lbMethodName);
            this.Controls.Add(this.toolStripEx1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmBehindCodeModuleDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmBehindCodeModuleDesign_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BusinessBase.Controls.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ListBox lbMethodName;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.RichTextBox rtbContext;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripButton tsbUpdate;
        private System.Windows.Forms.ToolStripButton tsbDebug;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsTemplate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbVs;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ComboBox cbxDBAlias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVer;
        private System.Windows.Forms.Label labVer;
        private System.Windows.Forms.CheckBox chkBGCompile;
    }
}