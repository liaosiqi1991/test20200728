namespace zlMedimgSystem.CTL.DataOper
{
    partial class frmDataOperModuleDesign
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
            this.rtbContext = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxDBAlias = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lbMethodName = new System.Windows.Forms.ListBox();
            this.lbPars = new System.Windows.Forms.ListBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.toolStripEx1 = new zlMedimgSystem.BusinessBase.Controls.ToolStripEx();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDebug = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.txtReturnName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.toolStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbContext
            // 
            this.rtbContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContext.Location = new System.Drawing.Point(225, 74);
            this.rtbContext.Name = "rtbContext";
            this.rtbContext.Size = new System.Drawing.Size(518, 376);
            this.rtbContext.TabIndex = 8;
            this.rtbContext.Text = "/*这里输入SQL数据处理语句*/\n";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtReturnName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbxDBAlias);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(225, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(672, 43);
            this.panel1.TabIndex = 9;
            // 
            // cbxDBAlias
            // 
            this.cbxDBAlias.FormattingEnabled = true;
            this.cbxDBAlias.Location = new System.Drawing.Point(278, 11);
            this.cbxDBAlias.Name = "cbxDBAlias";
            this.cbxDBAlias.Size = new System.Drawing.Size(150, 20);
            this.cbxDBAlias.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据源";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(75, 11);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(150, 21);
            this.tbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "处理项名称";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(222, 31);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 419);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // lbMethodName
            // 
            this.lbMethodName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbMethodName.FormattingEnabled = true;
            this.lbMethodName.ItemHeight = 12;
            this.lbMethodName.Location = new System.Drawing.Point(0, 31);
            this.lbMethodName.Name = "lbMethodName";
            this.lbMethodName.Size = new System.Drawing.Size(222, 419);
            this.lbMethodName.TabIndex = 6;
            this.lbMethodName.SelectedIndexChanged += new System.EventHandler(this.lbMethodName_SelectedIndexChanged);
            // 
            // lbPars
            // 
            this.lbPars.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbPars.FormattingEnabled = true;
            this.lbPars.ItemHeight = 12;
            this.lbPars.Location = new System.Drawing.Point(743, 74);
            this.lbPars.Name = "lbPars";
            this.lbPars.Size = new System.Drawing.Size(154, 376);
            this.lbPars.TabIndex = 10;
            this.lbPars.DoubleClick += new System.EventHandler(this.lbPars_DoubleClick);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(740, 74);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 376);
            this.splitter2.TabIndex = 11;
            this.splitter2.TabStop = false;
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
            this.tsbDebug,
            this.toolStripSeparator2,
            this.tsbSave,
            this.tsbExit});
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Size = new System.Drawing.Size(897, 31);
            this.toolStripEx1.TabIndex = 5;
            this.toolStripEx1.Text = "toolStripEx1";
            // 
            // tsbNew
            // 
            this.tsbNew.Image = global::zlMedimgSystem.CTL.DataOper.Properties.Resources.newcode;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(60, 28);
            this.tsbNew.Text = "新增";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = global::zlMedimgSystem.CTL.DataOper.Properties.Resources.delcode;
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(60, 28);
            this.tsbDel.Text = "删除";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.Image = global::zlMedimgSystem.CTL.DataOper.Properties.Resources.updatecode;
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
            // tsbDebug
            // 
            this.tsbDebug.Image = global::zlMedimgSystem.CTL.DataOper.Properties.Resources.debug_view;
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
            this.tsbSave.Image = global::zlMedimgSystem.CTL.DataOper.Properties.Resources.disk_blue;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(60, 28);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::zlMedimgSystem.CTL.DataOper.Properties.Resources.exit;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(60, 28);
            this.tsbExit.Text = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // txtReturnName
            // 
            this.txtReturnName.Location = new System.Drawing.Point(505, 11);
            this.txtReturnName.Name = "txtReturnName";
            this.txtReturnName.Size = new System.Drawing.Size(150, 21);
            this.txtReturnName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(434, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "返回项名称";
            // 
            // frmDataOperModuleDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 450);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.rtbContext);
            this.Controls.Add(this.lbPars);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lbMethodName);
            this.Controls.Add(this.toolStripEx1);
            this.Name = "frmDataOperModuleDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmDataOperModuleDesign_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbContext;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListBox lbMethodName;
        private BusinessBase.Controls.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripButton tsbUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDebug;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ComboBox cbxDBAlias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbPars;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.TextBox txtReturnName;
        private System.Windows.Forms.Label label3;
    }
}