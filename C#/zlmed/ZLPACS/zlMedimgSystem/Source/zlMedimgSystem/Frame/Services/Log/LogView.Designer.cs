namespace zlMedimgSystem.Services
{
    partial class LogView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogView));
            this.staLog = new System.Windows.Forms.StatusStrip();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmuSaveAsFullXml = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.查看VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.字体FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmuSmallFont = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmuBigFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.日志类型TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmuError = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmuWaring = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmuNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmuDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmuOpenWeb = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.bdnPageInfo = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.tsbutFirstRecord = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.tsbutEndRecord = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbutPerv = new System.Windows.Forms.ToolStripButton();
            this.tsTxtCurPage = new System.Windows.Forms.ToolStripTextBox();
            this.tsLabPageInfo = new System.Windows.Forms.ToolStripLabel();
            this.tsbutNext = new System.Windows.Forms.ToolStripButton();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbSource = new System.Windows.Forms.RichTextBox();
            this.labSource = new System.Windows.Forms.Label();
            this.mnuMain.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdnPageInfo)).BeginInit();
            this.bdnPageInfo.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // staLog
            // 
            this.staLog.Location = new System.Drawing.Point(0, 439);
            this.staLog.Name = "staLog";
            this.staLog.Size = new System.Drawing.Size(784, 22);
            this.staLog.TabIndex = 7;
            this.staLog.Text = "statusStrip1";
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.查看VToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(784, 25);
            this.mnuMain.TabIndex = 8;
            this.mnuMain.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmuOpen,
            this.tsmuSaveAsFullXml,
            this.toolStripMenuItem1,
            this.tsmuQuit});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // tsmuOpen
            // 
            this.tsmuOpen.Name = "tsmuOpen";
            this.tsmuOpen.Size = new System.Drawing.Size(154, 22);
            this.tsmuOpen.Text = "打开(&O)";
            // 
            // tsmuSaveAsFullXml
            // 
            this.tsmuSaveAsFullXml.Name = "tsmuSaveAsFullXml";
            this.tsmuSaveAsFullXml.Size = new System.Drawing.Size(154, 22);
            this.tsmuSaveAsFullXml.Text = "另存为XML(&A)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
            // 
            // tsmuQuit
            // 
            this.tsmuQuit.Name = "tsmuQuit";
            this.tsmuQuit.Size = new System.Drawing.Size(154, 22);
            this.tsmuQuit.Text = "退出(&Q)";
            // 
            // 查看VToolStripMenuItem
            // 
            this.查看VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.字体FToolStripMenuItem,
            this.toolStripMenuItem2,
            this.日志类型TToolStripMenuItem,
            this.toolStripMenuItem3,
            this.tsmuRefresh});
            this.查看VToolStripMenuItem.Name = "查看VToolStripMenuItem";
            this.查看VToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.查看VToolStripMenuItem.Text = "查看(&V)";
            // 
            // 字体FToolStripMenuItem
            // 
            this.字体FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmuSmallFont,
            this.tsmuBigFont});
            this.字体FToolStripMenuItem.Name = "字体FToolStripMenuItem";
            this.字体FToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.字体FToolStripMenuItem.Text = "字体(&F)";
            // 
            // tsmuSmallFont
            // 
            this.tsmuSmallFont.Checked = true;
            this.tsmuSmallFont.CheckOnClick = true;
            this.tsmuSmallFont.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmuSmallFont.Name = "tsmuSmallFont";
            this.tsmuSmallFont.Size = new System.Drawing.Size(128, 22);
            this.tsmuSmallFont.Text = "小字体(&S)";
            // 
            // tsmuBigFont
            // 
            this.tsmuBigFont.CheckOnClick = true;
            this.tsmuBigFont.Name = "tsmuBigFont";
            this.tsmuBigFont.Size = new System.Drawing.Size(128, 22);
            this.tsmuBigFont.Text = "大字体(&B)";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(136, 6);
            // 
            // 日志类型TToolStripMenuItem
            // 
            this.日志类型TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmuError,
            this.tsmuWaring,
            this.tsmuNormal,
            this.tsmuDebug});
            this.日志类型TToolStripMenuItem.Name = "日志类型TToolStripMenuItem";
            this.日志类型TToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.日志类型TToolStripMenuItem.Text = "日志类型(&T)";
            // 
            // tsmuError
            // 
            this.tsmuError.CheckOnClick = true;
            this.tsmuError.Name = "tsmuError";
            this.tsmuError.Size = new System.Drawing.Size(120, 22);
            this.tsmuError.Text = "错误(&E)";
            // 
            // tsmuWaring
            // 
            this.tsmuWaring.CheckOnClick = true;
            this.tsmuWaring.Name = "tsmuWaring";
            this.tsmuWaring.Size = new System.Drawing.Size(120, 22);
            this.tsmuWaring.Text = "警告(&W)";
            // 
            // tsmuNormal
            // 
            this.tsmuNormal.CheckOnClick = true;
            this.tsmuNormal.Name = "tsmuNormal";
            this.tsmuNormal.Size = new System.Drawing.Size(120, 22);
            this.tsmuNormal.Text = "常规(&N)";
            // 
            // tsmuDebug
            // 
            this.tsmuDebug.CheckOnClick = true;
            this.tsmuDebug.Name = "tsmuDebug";
            this.tsmuDebug.Size = new System.Drawing.Size(120, 22);
            this.tsmuDebug.Text = "调试(&D)";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(136, 6);
            // 
            // tsmuRefresh
            // 
            this.tsmuRefresh.Name = "tsmuRefresh";
            this.tsmuRefresh.Size = new System.Drawing.Size(139, 22);
            this.tsmuRefresh.Text = "刷新(R)";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmuAbout,
            this.toolStripMenuItem4,
            this.tsmuOpenWeb});
            this.帮助HToolStripMenuItem.Enabled = false;
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // tsmuAbout
            // 
            this.tsmuAbout.Name = "tsmuAbout";
            this.tsmuAbout.Size = new System.Drawing.Size(152, 22);
            this.tsmuAbout.Text = "关于(&A)";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(149, 6);
            this.toolStripMenuItem4.Visible = false;
            // 
            // tsmuOpenWeb
            // 
            this.tsmuOpenWeb.Name = "tsmuOpenWeb";
            this.tsmuOpenWeb.Size = new System.Drawing.Size(152, 22);
            this.tsmuOpenWeb.Text = "公司主页(&W)";
            this.tsmuOpenWeb.Visible = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 25);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvLog);
            this.splitContainer2.Panel1.Controls.Add(this.bdnPageInfo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(784, 414);
            this.splitContainer2.SplitterDistance = 518;
            this.splitContainer2.TabIndex = 11;
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AllowUserToOrderColumns = true;
            this.dgvLog.AllowUserToResizeRows = false;
            this.dgvLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.Location = new System.Drawing.Point(0, 0);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.RowTemplate.Height = 23;
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.Size = new System.Drawing.Size(518, 389);
            this.dgvLog.TabIndex = 4;
            // 
            // bdnPageInfo
            // 
            this.bdnPageInfo.AddNewItem = null;
            this.bdnPageInfo.CountItem = this.bindingNavigatorCountItem;
            this.bdnPageInfo.DeleteItem = null;
            this.bdnPageInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bdnPageInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbutFirstRecord,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.tsbutEndRecord,
            this.bindingNavigatorSeparator2,
            this.tsbutPerv,
            this.tsTxtCurPage,
            this.tsLabPageInfo,
            this.tsbutNext});
            this.bdnPageInfo.Location = new System.Drawing.Point(0, 389);
            this.bdnPageInfo.MoveFirstItem = null;
            this.bdnPageInfo.MoveLastItem = null;
            this.bdnPageInfo.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdnPageInfo.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdnPageInfo.Name = "bdnPageInfo";
            this.bdnPageInfo.PositionItem = this.bindingNavigatorPositionItem;
            this.bdnPageInfo.Size = new System.Drawing.Size(518, 25);
            this.bdnPageInfo.TabIndex = 5;
            this.bdnPageInfo.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "当前项数";
            // 
            // tsbutFirstRecord
            // 
            this.tsbutFirstRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbutFirstRecord.Image = ((System.Drawing.Image)(resources.GetObject("tsbutFirstRecord.Image")));
            this.tsbutFirstRecord.Name = "tsbutFirstRecord";
            this.tsbutFirstRecord.RightToLeftAutoMirrorImage = true;
            this.tsbutFirstRecord.Size = new System.Drawing.Size(23, 22);
            this.tsbutFirstRecord.Text = "移到第一条记录";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(30, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            // 
            // tsbutEndRecord
            // 
            this.tsbutEndRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbutEndRecord.Image = ((System.Drawing.Image)(resources.GetObject("tsbutEndRecord.Image")));
            this.tsbutEndRecord.Name = "tsbutEndRecord";
            this.tsbutEndRecord.RightToLeftAutoMirrorImage = true;
            this.tsbutEndRecord.Size = new System.Drawing.Size(23, 22);
            this.tsbutEndRecord.Text = "移到最后一条记录";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbutPerv
            // 
            this.tsbutPerv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbutPerv.Image = ((System.Drawing.Image)(resources.GetObject("tsbutPerv.Image")));
            this.tsbutPerv.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbutPerv.Name = "tsbutPerv";
            this.tsbutPerv.Size = new System.Drawing.Size(48, 22);
            this.tsbutPerv.Text = "上一页";
            // 
            // tsTxtCurPage
            // 
            this.tsTxtCurPage.Name = "tsTxtCurPage";
            this.tsTxtCurPage.Size = new System.Drawing.Size(25, 25);
            // 
            // tsLabPageInfo
            // 
            this.tsLabPageInfo.Name = "tsLabPageInfo";
            this.tsLabPageInfo.Size = new System.Drawing.Size(20, 22);
            this.tsLabPageInfo.Text = "/0";
            // 
            // tsbutNext
            // 
            this.tsbutNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbutNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbutNext.Image")));
            this.tsbutNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbutNext.Name = "tsbutNext";
            this.tsbutNext.Size = new System.Drawing.Size(48, 22);
            this.tsbutNext.Text = "下一页";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.rtbDescription);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.rtbSource);
            this.splitContainer3.Panel2.Controls.Add(this.labSource);
            this.splitContainer3.Size = new System.Drawing.Size(262, 414);
            this.splitContainer3.SplitterDistance = 212;
            this.splitContainer3.TabIndex = 3;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDescription.Location = new System.Drawing.Point(0, 15);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ReadOnly = true;
            this.rtbDescription.Size = new System.Drawing.Size(262, 197);
            this.rtbDescription.TabIndex = 5;
            this.rtbDescription.Text = "";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "描述：";
            // 
            // rtbSource
            // 
            this.rtbSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSource.Location = new System.Drawing.Point(0, 15);
            this.rtbSource.Name = "rtbSource";
            this.rtbSource.ReadOnly = true;
            this.rtbSource.Size = new System.Drawing.Size(262, 183);
            this.rtbSource.TabIndex = 6;
            this.rtbSource.Text = "";
            // 
            // labSource
            // 
            this.labSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.labSource.Location = new System.Drawing.Point(0, 0);
            this.labSource.Name = "labSource";
            this.labSource.Size = new System.Drawing.Size(262, 15);
            this.labSource.TabIndex = 7;
            this.labSource.Text = "来源：";
            // 
            // LogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.staLog);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "LogView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日志查看";
            this.Load += new System.EventHandler(this.LogView_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdnPageInfo)).EndInit();
            this.bdnPageInfo.ResumeLayout(false);
            this.bdnPageInfo.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip staLog;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.RichTextBox rtbSource;
        private System.Windows.Forms.Label labSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem tsmuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmuQuit;
        private System.Windows.Forms.ToolStripMenuItem 字体FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmuSmallFont;
        private System.Windows.Forms.ToolStripMenuItem tsmuBigFont;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 日志类型TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmuError;
        private System.Windows.Forms.ToolStripMenuItem tsmuWaring;
        private System.Windows.Forms.ToolStripMenuItem tsmuNormal;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmuRefresh;
        private System.Windows.Forms.BindingNavigator bdnPageInfo;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton tsbutFirstRecord;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton tsbutEndRecord;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tsbutPerv;
        private System.Windows.Forms.ToolStripButton tsbutNext;
        private System.Windows.Forms.ToolStripLabel tsLabPageInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmuAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tsmuOpenWeb;
        private System.Windows.Forms.ToolStripMenuItem tsmuSaveAsFullXml;
        private System.Windows.Forms.ToolStripTextBox tsTxtCurPage;
        private System.Windows.Forms.ToolStripMenuItem tsmuDebug;

    }
}