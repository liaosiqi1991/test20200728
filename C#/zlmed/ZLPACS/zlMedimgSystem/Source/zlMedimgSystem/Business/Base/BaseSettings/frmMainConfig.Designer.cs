namespace zlMedimgSystem.BaseSettings
{
    partial class frmMainConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainConfig));
            this.toolStrip1 = new zlMedimgSystem.BusinessBase.Controls.ToolStripEx();
            this.tsbHisServer = new System.Windows.Forms.ToolStripButton();
            this.tsbDBSourceConfig = new System.Windows.Forms.ToolStripButton();
            this.tsbImageKind = new System.Windows.Forms.ToolStripButton();
            this.tsbStorageSetting = new System.Windows.Forms.ToolStripButton();
            this.tsbDictionary = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new zlMedimgSystem.BusinessBase.Controls.ToolStripEx();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.tsbQueueManager = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton18 = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.toolStrip3 = new zlMedimgSystem.BusinessBase.Controls.ToolStripEx();
            this.toolStripButton29 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton30 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton31 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton32 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton36 = new System.Windows.Forms.ToolStripButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.toolStrip4 = new zlMedimgSystem.BusinessBase.Controls.ToolStripEx();
            this.toolStripButton51 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton52 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton53 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton54 = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tsbDbServerName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHisServer,
            this.tsbDBSourceConfig,
            this.tsbImageKind,
            this.tsbStorageSetting,
            this.tsbDictionary,
            this.toolStripSeparator1,
            this.tsbRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1127, 50);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbHisServer
            // 
            this.tsbHisServer.BackColor = System.Drawing.SystemColors.Control;
            this.tsbHisServer.ForeColor = System.Drawing.Color.Black;
            this.tsbHisServer.Image = ((System.Drawing.Image)(resources.GetObject("tsbHisServer.Image")));
            this.tsbHisServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHisServer.Name = "tsbHisServer";
            this.tsbHisServer.Size = new System.Drawing.Size(80, 47);
            this.tsbHisServer.Text = "HIS接口设置";
            this.tsbHisServer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbHisServer.Click += new System.EventHandler(this.tsbHisServer_Click);
            // 
            // tsbDBSourceConfig
            // 
            this.tsbDBSourceConfig.Image = global::zlMedimgSystem.BaseSettings.Properties.Resources.data_copy;
            this.tsbDBSourceConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDBSourceConfig.Name = "tsbDBSourceConfig";
            this.tsbDBSourceConfig.Size = new System.Drawing.Size(72, 47);
            this.tsbDBSourceConfig.Text = "数据源设置";
            this.tsbDBSourceConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDBSourceConfig.Click += new System.EventHandler(this.tsbDBSourceConfig_Click);
            // 
            // tsbImageKind
            // 
            this.tsbImageKind.Image = ((System.Drawing.Image)(resources.GetObject("tsbImageKind.Image")));
            this.tsbImageKind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImageKind.Name = "tsbImageKind";
            this.tsbImageKind.Size = new System.Drawing.Size(60, 47);
            this.tsbImageKind.Text = "影像类别";
            this.tsbImageKind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbImageKind.Click += new System.EventHandler(this.tsbImageKind_Click);
            // 
            // tsbStorageSetting
            // 
            this.tsbStorageSetting.BackColor = System.Drawing.SystemColors.Control;
            this.tsbStorageSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsbStorageSetting.Image")));
            this.tsbStorageSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStorageSetting.Name = "tsbStorageSetting";
            this.tsbStorageSetting.Size = new System.Drawing.Size(60, 47);
            this.tsbStorageSetting.Text = "存储设置";
            this.tsbStorageSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbStorageSetting.Click += new System.EventHandler(this.tsbStorageSetting_Click);
            // 
            // tsbDictionary
            // 
            this.tsbDictionary.BackColor = System.Drawing.SystemColors.Control;
            this.tsbDictionary.Image = ((System.Drawing.Image)(resources.GetObject("tsbDictionary.Image")));
            this.tsbDictionary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDictionary.Name = "tsbDictionary";
            this.tsbDictionary.Size = new System.Drawing.Size(60, 47);
            this.tsbDictionary.Text = "字典设置";
            this.tsbDictionary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDictionary.Click += new System.EventHandler(this.tsbDictionary_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.Aqua;
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.Aqua;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(36, 47);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 91);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(1141, 568);
            this.panel1.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDbServerName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1141, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1141, 91);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1133, 56);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "⑴字典&存储…";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.toolStrip2);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1133, 56);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "⑵科室&角色…";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton6,
            this.toolStripButton10,
            this.tsbQueueManager,
            this.toolStripButton7,
            this.toolStripButton9,
            this.toolStripButton8,
            this.toolStripSeparator6,
            this.toolStripButton18});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1127, 50);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(60, 47);
            this.toolStripButton6.Text = "科室对照";
            this.toolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton6.Click += new System.EventHandler(this.tsbDepartmentMatch_Click);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(60, 47);
            this.toolStripButton10.Text = "房间设备";
            this.toolStripButton10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton10.Click += new System.EventHandler(this.tsbRoom_Click);
            // 
            // tsbQueueManager
            // 
            this.tsbQueueManager.Image = global::zlMedimgSystem.BaseSettings.Properties.Resources.queue;
            this.tsbQueueManager.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQueueManager.Name = "tsbQueueManager";
            this.tsbQueueManager.Size = new System.Drawing.Size(60, 47);
            this.tsbQueueManager.Text = "队列管理";
            this.tsbQueueManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbQueueManager.Click += new System.EventHandler(this.tsbQueueManager_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(60, 47);
            this.toolStripButton7.Text = "角色管理";
            this.toolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton7.Click += new System.EventHandler(this.tsbRoleConfig_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(60, 47);
            this.toolStripButton9.Text = "窗体管理";
            this.toolStripButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton9.Click += new System.EventHandler(this.tsbWindowManager_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(60, 47);
            this.toolStripButton8.Text = "用户管理";
            this.toolStripButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton8.Click += new System.EventHandler(this.tsbUserConfig_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 50);
            // 
            // toolStripButton18
            // 
            this.toolStripButton18.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButton18.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton18.Image")));
            this.toolStripButton18.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton18.Name = "toolStripButton18";
            this.toolStripButton18.Size = new System.Drawing.Size(36, 47);
            this.toolStripButton18.Text = "刷新";
            this.toolStripButton18.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton18.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.toolStrip3);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1133, 56);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "⑶项目&报告…";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton29,
            this.toolStripButton30,
            this.toolStripButton31,
            this.toolStripButton32,
            this.toolStripSeparator11,
            this.toolStripButton36});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1127, 50);
            this.toolStrip3.TabIndex = 5;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton29
            // 
            this.toolStripButton29.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton29.Image")));
            this.toolStripButton29.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton29.Name = "toolStripButton29";
            this.toolStripButton29.Size = new System.Drawing.Size(60, 47);
            this.toolStripButton29.Text = "部位设置";
            this.toolStripButton29.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton29.Click += new System.EventHandler(this.tsbBodypartSet_Click);
            // 
            // toolStripButton30
            // 
            this.toolStripButton30.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton30.Image")));
            this.toolStripButton30.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton30.Name = "toolStripButton30";
            this.toolStripButton30.Size = new System.Drawing.Size(60, 47);
            this.toolStripButton30.Text = "项目设置";
            this.toolStripButton30.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton30.Click += new System.EventHandler(this.tsbExamItemSet_Click);
            // 
            // toolStripButton31
            // 
            this.toolStripButton31.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton31.Image")));
            this.toolStripButton31.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton31.Name = "toolStripButton31";
            this.toolStripButton31.Size = new System.Drawing.Size(60, 47);
            this.toolStripButton31.Text = "报告词句";
            this.toolStripButton31.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton31.Click += new System.EventHandler(this.tsbReportWords_Click);
            // 
            // toolStripButton32
            // 
            this.toolStripButton32.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton32.Image")));
            this.toolStripButton32.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton32.Name = "toolStripButton32";
            this.toolStripButton32.Size = new System.Drawing.Size(60, 47);
            this.toolStripButton32.Text = "报告模板";
            this.toolStripButton32.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton32.Click += new System.EventHandler(this.tsbReportTempleate_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 50);
            // 
            // toolStripButton36
            // 
            this.toolStripButton36.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButton36.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton36.Image")));
            this.toolStripButton36.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton36.Name = "toolStripButton36";
            this.toolStripButton36.Size = new System.Drawing.Size(36, 47);
            this.toolStripButton36.Text = "刷新";
            this.toolStripButton36.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton36.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.toolStrip4);
            this.tabPage4.ImageIndex = 3;
            this.tabPage4.Location = new System.Drawing.Point(4, 31);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1133, 56);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "⑷站点&规则...";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton51,
            this.toolStripButton52,
            this.toolStripButton53,
            this.toolStripSeparator16,
            this.toolStripButton54});
            this.toolStrip4.Location = new System.Drawing.Point(3, 3);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(1127, 50);
            this.toolStrip4.TabIndex = 5;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripButton51
            // 
            this.toolStripButton51.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton51.Image")));
            this.toolStripButton51.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton51.Name = "toolStripButton51";
            this.toolStripButton51.Size = new System.Drawing.Size(60, 47);
            this.toolStripButton51.Text = "号码规则";
            this.toolStripButton51.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton51.Click += new System.EventHandler(this.tsbNoRule_Click);
            // 
            // toolStripButton52
            // 
            this.toolStripButton52.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton52.Image")));
            this.toolStripButton52.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton52.Name = "toolStripButton52";
            this.toolStripButton52.Size = new System.Drawing.Size(60, 47);
            this.toolStripButton52.Text = "站点信息";
            this.toolStripButton52.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton52.Click += new System.EventHandler(this.tsbStationInfo_Click);
            // 
            // toolStripButton53
            // 
            this.toolStripButton53.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton53.Image")));
            this.toolStripButton53.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton53.Name = "toolStripButton53";
            this.toolStripButton53.Size = new System.Drawing.Size(72, 47);
            this.toolStripButton53.Text = "管理员设置";
            this.toolStripButton53.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton53.Click += new System.EventHandler(this.tsbSysPwd_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 50);
            // 
            // toolStripButton54
            // 
            this.toolStripButton54.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButton54.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton54.Image")));
            this.toolStripButton54.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton54.Name = "toolStripButton54";
            this.toolStripButton54.Size = new System.Drawing.Size(36, 47);
            this.toolStripButton54.Text = "刷新";
            this.toolStripButton54.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton54.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "book.ico");
            this.imageList1.Images.SetKeyName(1, "businessmen.ico");
            this.imageList1.Images.SetKeyName(2, "document_notebook.ico");
            this.imageList1.Images.SetKeyName(3, "computer.ico");
            // 
            // tsbDbServerName
            // 
            this.tsbDbServerName.Name = "tsbDbServerName";
            this.tsbDbServerName.Size = new System.Drawing.Size(47, 17);
            this.tsbDbServerName.Text = "服务器:";
            // 
            // frmMainConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmMainConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.frmMainConfig_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BusinessBase.Controls.ToolStripEx toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbHisServer;
        private System.Windows.Forms.ToolStripButton tsbDictionary;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbStorageSetting;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbImageKind;
        private System.Windows.Forms.ToolStripButton tsbDBSourceConfig;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private BusinessBase.Controls.ToolStripEx toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton18;
        private System.Windows.Forms.TabPage tabPage3;
        private BusinessBase.Controls.ToolStripEx toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton29;
        private System.Windows.Forms.ToolStripButton toolStripButton30;
        private System.Windows.Forms.ToolStripButton toolStripButton31;
        private System.Windows.Forms.ToolStripButton toolStripButton32;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton toolStripButton36;
        private System.Windows.Forms.TabPage tabPage4;
        private BusinessBase.Controls.ToolStripEx toolStrip4;
        private System.Windows.Forms.ToolStripButton toolStripButton51;
        private System.Windows.Forms.ToolStripButton toolStripButton52;
        private System.Windows.Forms.ToolStripButton toolStripButton53;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripButton toolStripButton54;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton tsbQueueManager;
        private System.Windows.Forms.ToolStripStatusLabel tsbDbServerName;
    }
}