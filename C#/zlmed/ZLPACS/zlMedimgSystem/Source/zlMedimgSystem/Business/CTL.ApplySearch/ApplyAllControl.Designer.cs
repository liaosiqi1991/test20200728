namespace zlMedimgSystem.CTL.ApplySearch
{
    partial class ApplyAllControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplyAllControl));
            this.split = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabHisApp = new System.Windows.Forms.TabPage();
            this.tabPacsApp = new System.Windows.Forms.TabPage();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.btnToday = new DevExpress.XtraEditors.SimpleButton();
            this.btnNearlyThree = new DevExpress.XtraEditors.SimpleButton();
            this.btnNearlyOne = new DevExpress.XtraEditors.SimpleButton();
            this.chkRev = new System.Windows.Forms.CheckBox();
            this.cboNumber = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDate = new DevExpress.XtraEditors.DateEdit();
            this.panButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnModify = new DevExpress.XtraEditors.SimpleButton();
            this.btnReject = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintSetup = new DevExpress.XtraEditors.SimpleButton();
            this.btnNewApply = new DevExpress.XtraEditors.SimpleButton();
            this.btnReceive = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnScan = new DevExpress.XtraEditors.SimpleButton();
            this.vHisTable = new zlMedimgSystem.CTL.ApplySearch.ViewTableControl();
            this.vPacsTable = new zlMedimgSystem.CTL.ApplySearch.ViewTableControl();
            this.scanner = new zlMedimgSystem.HardWare.ScanDevice();
            this.applyControl = new zlMedimgSystem.CTL.Apply.ApplyControl();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabHisApp.SuspendLayout();
            this.tabPacsApp.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panButtons)).BeginInit();
            this.panButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // split
            // 
            this.split.Location = new System.Drawing.Point(12, 12);
            this.split.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.tabControl);
            this.split.Panel1.Controls.Add(this.panelSearch);
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.panButtons);
            this.split.Panel2.Controls.Add(this.applyControl);
            this.split.Size = new System.Drawing.Size(822, 500);
            this.split.SplitterDistance = 303;
            this.split.SplitterWidth = 2;
            this.split.TabIndex = 4;
            this.split.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.split_SplitterMoved);
            this.split.Resize += new System.EventHandler(this.split_Resize);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabHisApp);
            this.tabControl.Controls.Add(this.tabPacsApp);
            this.tabControl.Location = new System.Drawing.Point(11, 152);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(288, 314);
            this.tabControl.TabIndex = 3;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabHisApp
            // 
            this.tabHisApp.Controls.Add(this.vHisTable);
            this.tabHisApp.Location = new System.Drawing.Point(4, 22);
            this.tabHisApp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabHisApp.Name = "tabHisApp";
            this.tabHisApp.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabHisApp.Size = new System.Drawing.Size(280, 288);
            this.tabHisApp.TabIndex = 0;
            this.tabHisApp.Text = "检查申请";
            this.tabHisApp.UseVisualStyleBackColor = true;
            // 
            // tabPacsApp
            // 
            this.tabPacsApp.Controls.Add(this.vPacsTable);
            this.tabPacsApp.Location = new System.Drawing.Point(4, 22);
            this.tabPacsApp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPacsApp.Name = "tabPacsApp";
            this.tabPacsApp.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPacsApp.Size = new System.Drawing.Size(280, 288);
            this.tabPacsApp.TabIndex = 1;
            this.tabPacsApp.Text = "检查记录";
            this.tabPacsApp.UseVisualStyleBackColor = true;
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.btnQuery);
            this.panelSearch.Controls.Add(this.btnToday);
            this.panelSearch.Controls.Add(this.btnNearlyThree);
            this.panelSearch.Controls.Add(this.btnNearlyOne);
            this.panelSearch.Controls.Add(this.chkRev);
            this.panelSearch.Controls.Add(this.cboNumber);
            this.panelSearch.Controls.Add(this.txtNumber);
            this.panelSearch.Controls.Add(this.button1);
            this.panelSearch.Controls.Add(this.label2);
            this.panelSearch.Controls.Add(this.txtName);
            this.panelSearch.Controls.Add(this.label3);
            this.panelSearch.Controls.Add(this.dtDate);
            this.panelSearch.Location = new System.Drawing.Point(11, 12);
            this.panelSearch.MinimumSize = new System.Drawing.Size(0, 130);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(323, 135);
            this.panelSearch.TabIndex = 1;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(241, 103);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(46, 23);
            this.btnQuery.TabIndex = 19;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(85, 103);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(46, 23);
            this.btnToday.TabIndex = 18;
            this.btnToday.Text = "今天";
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // btnNearlyThree
            // 
            this.btnNearlyThree.Location = new System.Drawing.Point(189, 103);
            this.btnNearlyThree.Name = "btnNearlyThree";
            this.btnNearlyThree.Size = new System.Drawing.Size(46, 23);
            this.btnNearlyThree.TabIndex = 17;
            this.btnNearlyThree.Text = "近三天";
            this.btnNearlyThree.Click += new System.EventHandler(this.btnNearlyThree_Click);
            // 
            // btnNearlyOne
            // 
            this.btnNearlyOne.Location = new System.Drawing.Point(137, 103);
            this.btnNearlyOne.Name = "btnNearlyOne";
            this.btnNearlyOne.Size = new System.Drawing.Size(46, 23);
            this.btnNearlyOne.TabIndex = 16;
            this.btnNearlyOne.Text = "近一天";
            this.btnNearlyOne.Click += new System.EventHandler(this.btnNearlyOne_Click);
            // 
            // chkRev
            // 
            this.chkRev.AutoSize = true;
            this.chkRev.Location = new System.Drawing.Point(18, 108);
            this.chkRev.Name = "chkRev";
            this.chkRev.Size = new System.Drawing.Size(60, 16);
            this.chkRev.TabIndex = 15;
            this.chkRev.Text = "已接收";
            this.chkRev.UseVisualStyleBackColor = true;
            // 
            // cboNumber
            // 
            this.cboNumber.EditValue = "门诊号";
            this.cboNumber.Location = new System.Drawing.Point(14, 4);
            this.cboNumber.Name = "cboNumber";
            this.cboNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNumber.Properties.Items.AddRange(new object[] {
            "门诊号",
            "住院号",
            "体检号",
            "就诊卡号",
            "医保号",
            "身份证号",
            "自动查号"});
            this.cboNumber.Size = new System.Drawing.Size(66, 20);
            this.cboNumber.TabIndex = 8;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(85, 4);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(205, 21);
            this.txtNumber.TabIndex = 13;
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(294, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 14;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "姓名";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(85, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(203, 20);
            this.txtName.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "申请开始日期";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dtDate
            // 
            this.dtDate.EditValue = null;
            this.dtDate.Location = new System.Drawing.Point(85, 58);
            this.dtDate.Name = "dtDate";
            this.dtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate.Size = new System.Drawing.Size(203, 20);
            this.dtDate.TabIndex = 11;
            // 
            // panButtons
            // 
            this.panButtons.Controls.Add(this.btnCancel);
            this.panButtons.Controls.Add(this.btnModify);
            this.panButtons.Controls.Add(this.btnReject);
            this.panButtons.Controls.Add(this.btnPrintSetup);
            this.panButtons.Controls.Add(this.scanner);
            this.panButtons.Controls.Add(this.btnNewApply);
            this.panButtons.Controls.Add(this.btnReceive);
            this.panButtons.Controls.Add(this.btnPrint);
            this.panButtons.Controls.Add(this.btnScan);
            this.panButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panButtons.Location = new System.Drawing.Point(0, 0);
            this.panButtons.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panButtons.Name = "panButtons";
            this.panButtons.Size = new System.Drawing.Size(517, 42);
            this.panButtons.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(465, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(46, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(406, 12);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(46, 23);
            this.btnModify.TabIndex = 29;
            this.btnModify.Text = "修改";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(346, 12);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(46, 23);
            this.btnReject.TabIndex = 28;
            this.btnReject.Text = "拒绝";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnPrintSetup
            // 
            this.btnPrintSetup.Location = new System.Drawing.Point(42, 12);
            this.btnPrintSetup.Name = "btnPrintSetup";
            this.btnPrintSetup.Size = new System.Drawing.Size(54, 23);
            this.btnPrintSetup.TabIndex = 27;
            this.btnPrintSetup.Text = "打印设置";
            // 
            // btnNewApply
            // 
            this.btnNewApply.Location = new System.Drawing.Point(286, 12);
            this.btnNewApply.Name = "btnNewApply";
            this.btnNewApply.Size = new System.Drawing.Size(46, 23);
            this.btnNewApply.TabIndex = 23;
            this.btnNewApply.Text = "新增";
            this.btnNewApply.Click += new System.EventHandler(this.btnNewApply_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.Location = new System.Drawing.Point(227, 12);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(46, 23);
            this.btnReceive.TabIndex = 22;
            this.btnReceive.Text = "接收";
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(108, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(46, 23);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(168, 12);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(46, 23);
            this.btnScan.TabIndex = 20;
            this.btnScan.Text = "扫描";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // vHisTable
            // 
            this.vHisTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vHisTable.Location = new System.Drawing.Point(2, 2);
            this.vHisTable.Margin = new System.Windows.Forms.Padding(1);
            this.vHisTable.Name = "vHisTable";
            this.vHisTable.Size = new System.Drawing.Size(276, 284);
            this.vHisTable.TabIndex = 1;
            this.vHisTable.UserControlFocusedRowChanged += new zlMedimgSystem.CTL.ApplySearch.ViewTableControl.FocusedRowChangedHandle(this.VHisTable_UserControlFocusedRowChanged);
            this.vHisTable.Load += new System.EventHandler(this.vHisTable_Load);
            // 
            // vPacsTable
            // 
            this.vPacsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vPacsTable.Location = new System.Drawing.Point(2, 2);
            this.vPacsTable.Margin = new System.Windows.Forms.Padding(1);
            this.vPacsTable.Name = "vPacsTable";
            this.vPacsTable.Size = new System.Drawing.Size(276, 284);
            this.vPacsTable.TabIndex = 2;
            this.vPacsTable.UserControlFocusedRowChanged += new zlMedimgSystem.CTL.ApplySearch.ViewTableControl.FocusedRowChangedHandle(this.vPacsTable_UserControlFocusedRowChanged);
            // 
            // scanner
            // 
            this.scanner.BackColor = System.Drawing.Color.Black;
            this.scanner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("scanner.BackgroundImage")));
            this.scanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.scanner.Location = new System.Drawing.Point(4, 17);
            this.scanner.Margin = new System.Windows.Forms.Padding(2);
            this.scanner.Name = "scanner";
            this.scanner.Size = new System.Drawing.Size(24, 24);
            this.scanner.TabIndex = 25;
            // 
            // applyControl
            // 
            this.applyControl.ApplyActionState = zlMedimgSystem.CTL.Apply.ApplyControl.ApplyAction.aaShow;
            this.applyControl.CustomDesignFmt = "";
            this.applyControl.DesignEventSerialFmt = "";
            this.applyControl.Location = new System.Drawing.Point(0, 0);
            this.applyControl.Margin = new System.Windows.Forms.Padding(1);
            this.applyControl.ModuleName = "检查申请模块";
            this.applyControl.Name = "applyControl";
            this.applyControl.RClickMenuDesignFmt = "";
            this.applyControl.Size = new System.Drawing.Size(512, 434);
            this.applyControl.TabIndex = 3;
            // 
            // ApplyAllControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.split);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ApplyAllControl";
            this.Size = new System.Drawing.Size(874, 536);
            this.Resize += new System.EventHandler(this.ApplySearchControl_Resize);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabHisApp.ResumeLayout(false);
            this.tabPacsApp.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panButtons)).EndInit();
            this.panButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelSearch;
        private DevExpress.XtraEditors.ComboBoxEdit cboNumber;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.DateEdit dtDate;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.SimpleButton btnToday;
        private DevExpress.XtraEditors.SimpleButton btnNearlyThree;
        private DevExpress.XtraEditors.SimpleButton btnNearlyOne;
        private System.Windows.Forms.CheckBox chkRev;
        private Apply.ApplyControl applyControl;
        private System.Windows.Forms.SplitContainer split;
        private DevExpress.XtraEditors.PanelControl panButtons;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnScan;
        private DevExpress.XtraEditors.SimpleButton btnNewApply;
        private DevExpress.XtraEditors.SimpleButton btnReceive;
        private HardWare.ScanDevice scanner;
        private DevExpress.XtraEditors.SimpleButton btnPrintSetup;
        private DevExpress.XtraEditors.SimpleButton btnReject;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabHisApp;
        private ViewTableControl vHisTable;
        private System.Windows.Forms.TabPage tabPacsApp;
        private ViewTableControl vPacsTable;
        private DevExpress.XtraEditors.SimpleButton btnModify;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
