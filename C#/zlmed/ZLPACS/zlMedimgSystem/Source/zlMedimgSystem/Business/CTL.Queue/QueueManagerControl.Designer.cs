namespace zlMedimgSystem.CTL.QueueManager
{
    partial class QueueManagerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueueManagerControl));
            this.listCall = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.listQueue = new System.Windows.Forms.ListView();
            this.labCallTitle = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.chkAllState = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labQueueTitle = new System.Windows.Forms.Label();
            this.toolStripEx2 = new zlMedimgSystem.BusinessBase.Controls.ToolStripEx();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsCbxQueue = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripEx1 = new zlMedimgSystem.BusinessBase.Controls.ToolStripEx();
            this.tsbOrderCall = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmDirectCall = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPause = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAbandon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRecept = new System.Windows.Forms.ToolStripButton();
            this.tsbRestore = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbMore = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmModify = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFind = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.toolStripEx2.SuspendLayout();
            this.toolStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listCall
            // 
            this.listCall.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listCall.FullRowSelect = true;
            this.listCall.HideSelection = false;
            this.listCall.LargeImageList = this.imageList1;
            this.listCall.Location = new System.Drawing.Point(0, 318);
            this.listCall.MultiSelect = false;
            this.listCall.Name = "listCall";
            this.listCall.Size = new System.Drawing.Size(588, 173);
            this.listCall.SmallImageList = this.imageList1;
            this.listCall.TabIndex = 4;
            this.listCall.UseCompatibleStateImageBehavior = false;
            this.listCall.Enter += new System.EventHandler(this.listCall_Enter);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pawn.ico");
            this.imageList1.Images.SetKeyName(1, "pawn_glass_yellow.ico");
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 299);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(588, 3);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // listQueue
            // 
            this.listQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listQueue.FullRowSelect = true;
            this.listQueue.HideSelection = false;
            this.listQueue.LargeImageList = this.imageList1;
            this.listQueue.Location = new System.Drawing.Point(0, 51);
            this.listQueue.MultiSelect = false;
            this.listQueue.Name = "listQueue";
            this.listQueue.Size = new System.Drawing.Size(588, 248);
            this.listQueue.SmallImageList = this.imageList1;
            this.listQueue.TabIndex = 6;
            this.listQueue.UseCompatibleStateImageBehavior = false;
            this.listQueue.Enter += new System.EventHandler(this.listQueue_Enter);
            // 
            // labCallTitle
            // 
            this.labCallTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labCallTitle.Location = new System.Drawing.Point(0, 302);
            this.labCallTitle.Name = "labCallTitle";
            this.labCallTitle.Padding = new System.Windows.Forms.Padding(2);
            this.labCallTitle.Size = new System.Drawing.Size(588, 16);
            this.labCallTitle.TabIndex = 7;
            this.labCallTitle.Text = "呼叫列表：0";
            this.labCallTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "ddd dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(175, 493);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(79, 23);
            this.dateTimePicker1.TabIndex = 9;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // chkAllState
            // 
            this.chkAllState.AutoSize = true;
            this.chkAllState.BackColor = System.Drawing.Color.Transparent;
            this.chkAllState.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkAllState.Location = new System.Drawing.Point(516, 0);
            this.chkAllState.Name = "chkAllState";
            this.chkAllState.Size = new System.Drawing.Size(72, 20);
            this.chkAllState.TabIndex = 10;
            this.chkAllState.Text = "所有状态";
            this.chkAllState.UseVisualStyleBackColor = false;
            this.chkAllState.CheckedChanged += new System.EventHandler(this.chkAllState_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.chkAllState);
            this.panel1.Controls.Add(this.labQueueTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 20);
            this.panel1.TabIndex = 11;
            // 
            // labQueueTitle
            // 
            this.labQueueTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.labQueueTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labQueueTitle.Location = new System.Drawing.Point(0, 0);
            this.labQueueTitle.Name = "labQueueTitle";
            this.labQueueTitle.Padding = new System.Windows.Forms.Padding(2);
            this.labQueueTitle.Size = new System.Drawing.Size(588, 20);
            this.labQueueTitle.TabIndex = 9;
            this.labQueueTitle.Text = "排队列表：0";
            this.labQueueTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripEx2
            // 
            this.toolStripEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripEx2.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStripEx2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripEx2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsCbxQueue});
            this.toolStripEx2.Location = new System.Drawing.Point(0, 491);
            this.toolStripEx2.Name = "toolStripEx2";
            this.toolStripEx2.Size = new System.Drawing.Size(588, 25);
            this.toolStripEx2.TabIndex = 3;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel1.Text = "队列";
            // 
            // tsCbxQueue
            // 
            this.tsCbxQueue.AutoSize = false;
            this.tsCbxQueue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCbxQueue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tsCbxQueue.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsCbxQueue.Name = "tsCbxQueue";
            this.tsCbxQueue.Size = new System.Drawing.Size(140, 25);
            this.tsCbxQueue.SelectedIndexChanged += new System.EventHandler(this.tsCbxQueue_SelectedIndexChanged);
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStripEx1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOrderCall,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripSeparator3,
            this.tsbRecept,
            this.tsbRestore,
            this.toolStripSeparator2,
            this.tsbPrint,
            this.tsbRefresh,
            this.tsbMore});
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Size = new System.Drawing.Size(588, 31);
            this.toolStripEx1.TabIndex = 1;
            // 
            // tsbOrderCall
            // 
            this.tsbOrderCall.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDirectCall});
            this.tsbOrderCall.Image = global::zlMedimgSystem.CTL.QueueManager.Properties.Resources.ordercall;
            this.tsbOrderCall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOrderCall.Name = "tsbOrderCall";
            this.tsbOrderCall.Size = new System.Drawing.Size(72, 28);
            this.tsbOrderCall.Text = "顺呼";
            this.tsbOrderCall.ButtonClick += new System.EventHandler(this.tsbOrderCall_ButtonClick);
            // 
            // tsmDirectCall
            // 
            this.tsmDirectCall.Image = global::zlMedimgSystem.CTL.QueueManager.Properties.Resources.dicrectcall;
            this.tsmDirectCall.Name = "tsmDirectCall";
            this.tsmDirectCall.Size = new System.Drawing.Size(100, 22);
            this.tsmDirectCall.Text = "直呼";
            this.tsmDirectCall.Click += new System.EventHandler(this.tsmDirectCall_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmInsert,
            this.tsmReQueue,
            this.tsmPause,
            this.tsmAbandon});
            this.toolStripDropDownButton1.Image = global::zlMedimgSystem.CTL.QueueManager.Properties.Resources.queue;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(37, 28);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // tsmInsert
            // 
            this.tsmInsert.Image = global::zlMedimgSystem.CTL.QueueManager.Properties.Resources.insertqueue;
            this.tsmInsert.Name = "tsmInsert";
            this.tsmInsert.Size = new System.Drawing.Size(100, 22);
            this.tsmInsert.Text = "插队";
            this.tsmInsert.Click += new System.EventHandler(this.tsmInsert_Click);
            // 
            // tsmReQueue
            // 
            this.tsmReQueue.Image = global::zlMedimgSystem.CTL.QueueManager.Properties.Resources.restorequeue;
            this.tsmReQueue.Name = "tsmReQueue";
            this.tsmReQueue.Size = new System.Drawing.Size(100, 22);
            this.tsmReQueue.Text = "重排";
            this.tsmReQueue.Click += new System.EventHandler(this.tsmReQueue_Click);
            // 
            // tsmPause
            // 
            this.tsmPause.Image = global::zlMedimgSystem.CTL.QueueManager.Properties.Resources.pausequeue;
            this.tsmPause.Name = "tsmPause";
            this.tsmPause.Size = new System.Drawing.Size(100, 22);
            this.tsmPause.Text = "暂停";
            this.tsmPause.Click += new System.EventHandler(this.tsmPause_Click);
            // 
            // tsmAbandon
            // 
            this.tsmAbandon.Image = global::zlMedimgSystem.CTL.QueueManager.Properties.Resources.abandonqueue;
            this.tsmAbandon.Name = "tsmAbandon";
            this.tsmAbandon.Size = new System.Drawing.Size(100, 22);
            this.tsmAbandon.Text = "弃呼";
            this.tsmAbandon.Click += new System.EventHandler(this.tsmAbandon_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbRecept
            // 
            this.tsbRecept.Image = global::zlMedimgSystem.CTL.QueueManager.Properties.Resources.check;
            this.tsbRecept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRecept.Name = "tsbRecept";
            this.tsbRecept.Size = new System.Drawing.Size(60, 28);
            this.tsbRecept.Text = "接诊";
            this.tsbRecept.Click += new System.EventHandler(this.tsbRecept_Click);
            // 
            // tsbRestore
            // 
            this.tsbRestore.Image = global::zlMedimgSystem.CTL.QueueManager.Properties.Resources.undo;
            this.tsbRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRestore.Name = "tsbRestore";
            this.tsbRestore.Size = new System.Drawing.Size(60, 28);
            this.tsbRestore.Text = "恢复";
            this.tsbRestore.Click += new System.EventHandler(this.tsbRestore_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbPrint
            // 
            this.tsbPrint.Image = global::zlMedimgSystem.CTL.QueueManager.Properties.Resources.print;
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(60, 28);
            this.tsbPrint.Text = "打号";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = global::zlMedimgSystem.CTL.QueueManager.Properties.Resources.refresh;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(60, 28);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbMore
            // 
            this.tsbMore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMore.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmModify,
            this.tsmFind});
            this.tsbMore.Image = global::zlMedimgSystem.CTL.QueueManager.Properties.Resources.Menu1;
            this.tsbMore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMore.Name = "tsbMore";
            this.tsbMore.Size = new System.Drawing.Size(37, 28);
            this.tsbMore.Text = "更多";
            // 
            // tsmModify
            // 
            this.tsmModify.Image = global::zlMedimgSystem.CTL.QueueManager.Properties.Resources.user_recored;
            this.tsmModify.Name = "tsmModify";
            this.tsmModify.Size = new System.Drawing.Size(100, 22);
            this.tsmModify.Text = "修改";
            this.tsmModify.Click += new System.EventHandler(this.tsmModify_Click);
            // 
            // tsmFind
            // 
            this.tsmFind.Image = global::zlMedimgSystem.CTL.QueueManager.Properties.Resources.find;
            this.tsmFind.Name = "tsmFind";
            this.tsmFind.Size = new System.Drawing.Size(100, 22);
            this.tsmFind.Text = "查找";
            this.tsmFind.Click += new System.EventHandler(this.tsmFind_Click);
            // 
            // QueueManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.listQueue);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.labCallTitle);
            this.Controls.Add(this.listCall);
            this.Controls.Add(this.toolStripEx2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStripEx1);
            this.Name = "QueueManagerControl";
            this.Size = new System.Drawing.Size(588, 516);
            this.Load += new System.EventHandler(this.QueueControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStripEx2.ResumeLayout(false);
            this.toolStripEx2.PerformLayout();
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BusinessBase.Controls.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbRecept;
        private System.Windows.Forms.ToolStripButton tsbRestore;
        private BusinessBase.Controls.ToolStripEx toolStripEx2;
        private System.Windows.Forms.ToolStripComboBox tsCbxQueue;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tsmInsert;
        private System.Windows.Forms.ToolStripMenuItem tsmReQueue;
        private System.Windows.Forms.ToolStripMenuItem tsmPause;
        private System.Windows.Forms.ToolStripMenuItem tsmAbandon;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripSplitButton tsbOrderCall;
        private System.Windows.Forms.ToolStripMenuItem tsmDirectCall;
        private System.Windows.Forms.ListView listCall;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListView listQueue;
        private System.Windows.Forms.Label labCallTitle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton tsbMore;
        private System.Windows.Forms.ToolStripMenuItem tsmModify;
        private System.Windows.Forms.ToolStripMenuItem tsmFind;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox chkAllState;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labQueueTitle;
    }
}
