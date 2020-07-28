namespace zlMedimgSystem.CTL.QueueQuick
{
    partial class QueueQuickControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueueQuickControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxQueueNames = new System.Windows.Forms.ComboBox();
            this.labQueueCount = new System.Windows.Forms.Label();
            this.butMiss = new System.Windows.Forms.Button();
            this.labWaitCall = new System.Windows.Forms.Label();
            this.labNext = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butOrderCall = new System.Windows.Forms.Button();
            this.butRestartCall = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.butDiagnose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbxQueueNames);
            this.panel1.Controls.Add(this.labQueueCount);
            this.panel1.Controls.Add(this.butMiss);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 22);
            this.panel1.TabIndex = 1;
            // 
            // cbxQueueNames
            // 
            this.cbxQueueNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxQueueNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQueueNames.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxQueueNames.FormattingEnabled = true;
            this.cbxQueueNames.Location = new System.Drawing.Point(0, 0);
            this.cbxQueueNames.Name = "cbxQueueNames";
            this.cbxQueueNames.Size = new System.Drawing.Size(158, 20);
            this.cbxQueueNames.TabIndex = 0;
            this.cbxQueueNames.SelectedIndexChanged += new System.EventHandler(this.cbxQueueNames_SelectedIndexChanged);
            // 
            // labQueueCount
            // 
            this.labQueueCount.BackColor = System.Drawing.Color.Transparent;
            this.labQueueCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.labQueueCount.Location = new System.Drawing.Point(158, 0);
            this.labQueueCount.Name = "labQueueCount";
            this.labQueueCount.Size = new System.Drawing.Size(72, 20);
            this.labQueueCount.TabIndex = 1;
            this.labQueueCount.Text = "余：000人";
            this.labQueueCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butMiss
            // 
            this.butMiss.BackColor = System.Drawing.Color.Transparent;
            this.butMiss.Dock = System.Windows.Forms.DockStyle.Right;
            this.butMiss.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butMiss.Location = new System.Drawing.Point(230, 0);
            this.butMiss.Name = "butMiss";
            this.butMiss.Size = new System.Drawing.Size(50, 20);
            this.butMiss.TabIndex = 2;
            this.butMiss.Text = "过号▼";
            this.butMiss.UseVisualStyleBackColor = false;
            this.butMiss.Visible = false;
            // 
            // labWaitCall
            // 
            this.labWaitCall.BackColor = System.Drawing.Color.Transparent;
            this.labWaitCall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labWaitCall.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labWaitCall.ForeColor = System.Drawing.Color.Green;
            this.labWaitCall.Location = new System.Drawing.Point(0, 22);
            this.labWaitCall.Name = "labWaitCall";
            this.labWaitCall.Padding = new System.Windows.Forms.Padding(2);
            this.labWaitCall.Size = new System.Drawing.Size(282, 45);
            this.labWaitCall.TabIndex = 2;
            this.labWaitCall.Text = "(XXXXX)XXX 女 XX岁\r\nB超检查";
            this.labWaitCall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labNext
            // 
            this.labNext.BackColor = System.Drawing.Color.Transparent;
            this.labNext.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labNext.Location = new System.Drawing.Point(0, 67);
            this.labNext.Name = "labNext";
            this.labNext.Padding = new System.Windows.Forms.Padding(2);
            this.labNext.Size = new System.Drawing.Size(282, 29);
            this.labNext.TabIndex = 3;
            this.labNext.Text = "(CS239)阿古力.买买提 男 38岁 新增超声检查";
            this.labNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.butOrderCall);
            this.panel2.Controls.Add(this.butRestartCall);
            this.panel2.Controls.Add(this.butDiagnose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(282, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(54, 96);
            this.panel2.TabIndex = 4;
            // 
            // butOrderCall
            // 
            this.butOrderCall.BackColor = System.Drawing.Color.Transparent;
            this.butOrderCall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butOrderCall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butOrderCall.Image = global::zlMedimgSystem.CTL.QueueQuick.Properties.Resources.ordercall1;
            this.butOrderCall.Location = new System.Drawing.Point(0, 0);
            this.butOrderCall.MinimumSize = new System.Drawing.Size(0, 38);
            this.butOrderCall.Name = "butOrderCall";
            this.butOrderCall.Size = new System.Drawing.Size(54, 48);
            this.butOrderCall.TabIndex = 0;
            this.butOrderCall.Text = "顺呼";
            this.butOrderCall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butOrderCall.UseVisualStyleBackColor = false;
            this.butOrderCall.Click += new System.EventHandler(this.butOrderCall_Click);
            // 
            // butRestartCall
            // 
            this.butRestartCall.BackColor = System.Drawing.Color.Transparent;
            this.butRestartCall.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.butRestartCall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butRestartCall.ImageIndex = 0;
            this.butRestartCall.ImageList = this.imageList1;
            this.butRestartCall.Location = new System.Drawing.Point(0, 48);
            this.butRestartCall.MinimumSize = new System.Drawing.Size(0, 22);
            this.butRestartCall.Name = "butRestartCall";
            this.butRestartCall.Size = new System.Drawing.Size(54, 24);
            this.butRestartCall.TabIndex = 1;
            this.butRestartCall.Text = "重呼";
            this.butRestartCall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butRestartCall.UseVisualStyleBackColor = false;
            this.butRestartCall.Click += new System.EventHandler(this.butRestartCall_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "dicrectcall.ico");
            this.imageList1.Images.SetKeyName(1, "queuediagnose.ico");
            this.imageList1.Images.SetKeyName(2, "queue.ico");
            this.imageList1.Images.SetKeyName(3, "diagnose1.ico");
            // 
            // butDiagnose
            // 
            this.butDiagnose.BackColor = System.Drawing.Color.Transparent;
            this.butDiagnose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.butDiagnose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butDiagnose.ImageIndex = 3;
            this.butDiagnose.ImageList = this.imageList1;
            this.butDiagnose.Location = new System.Drawing.Point(0, 72);
            this.butDiagnose.MinimumSize = new System.Drawing.Size(0, 22);
            this.butDiagnose.Name = "butDiagnose";
            this.butDiagnose.Size = new System.Drawing.Size(54, 24);
            this.butDiagnose.TabIndex = 2;
            this.butDiagnose.Text = "接诊";
            this.butDiagnose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butDiagnose.UseVisualStyleBackColor = false;
            this.butDiagnose.Click += new System.EventHandler(this.butDiagnose_Click);
            // 
            // QueueQuickControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.labWaitCall);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labNext);
            this.Controls.Add(this.panel2);
            this.Name = "QueueQuickControl";
            this.Size = new System.Drawing.Size(336, 96);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxQueueNames;
        private System.Windows.Forms.Label labQueueCount;
        private System.Windows.Forms.Label labWaitCall;
        private System.Windows.Forms.Label labNext;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butOrderCall;
        private System.Windows.Forms.Button butRestartCall;
        private System.Windows.Forms.Button butDiagnose;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button butMiss;
    }
}
