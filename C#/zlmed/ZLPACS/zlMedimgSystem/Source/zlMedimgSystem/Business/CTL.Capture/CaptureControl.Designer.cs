namespace zlMedimgSystem.CTL.Capture
{
    partial class CaptureControl
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
            this.videoCamera = new AForge.Controls.VideoSourcePlayer();
            this.panlVideoBack = new System.Windows.Forms.Panel();
            this.toolStrip1 = new zlMedimgSystem.BusinessBase.Controls.ToolStripEx();
            this.tsbCapture = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsbVideo = new System.Windows.Forms.ToolStripButton();
            this.tsbSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRestart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panlVideoBack.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoCamera
            // 
            this.videoCamera.BackColor = System.Drawing.Color.Black;
            this.videoCamera.Location = new System.Drawing.Point(103, 50);
            this.videoCamera.Name = "videoCamera";
            this.videoCamera.Size = new System.Drawing.Size(201, 165);
            this.videoCamera.TabIndex = 0;
            this.videoCamera.Text = "videoSourcePlayer1";
            this.videoCamera.VideoSource = null;
            this.videoCamera.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoCamera_NewFrame);
            // 
            // panlVideoBack
            // 
            this.panlVideoBack.BackColor = System.Drawing.Color.Black;
            this.panlVideoBack.Controls.Add(this.videoCamera);
            this.panlVideoBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panlVideoBack.Location = new System.Drawing.Point(0, 29);
            this.panlVideoBack.Name = "panlVideoBack";
            this.panlVideoBack.Size = new System.Drawing.Size(409, 294);
            this.panlVideoBack.TabIndex = 6;
            this.panlVideoBack.Resize += new System.EventHandler(this.panlVideoBack_Resize);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Gray;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCapture,
            this.toolStripLabel1,
            this.tsbVideo,
            this.tsbSetting,
            this.toolStripSeparator2,
            this.tsbRestart,
            this.toolStripSeparator1,
            this.tsbClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 323);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(409, 34);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbCapture
            // 
            this.tsbCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCapture.Image = global::zlMedimgSystem.CTL.Capture.Properties.Resources.Pictures;
            this.tsbCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCapture.Name = "tsbCapture";
            this.tsbCapture.Size = new System.Drawing.Size(28, 31);
            this.tsbCapture.Text = "采图";
            this.tsbCapture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCapture.Click += new System.EventHandler(this.tsbCapture_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Enabled = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(16, 31);
            this.toolStripLabel1.Text = "  ";
            // 
            // tsbVideo
            // 
            this.tsbVideo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbVideo.Image = global::zlMedimgSystem.CTL.Capture.Properties.Resources.videocamera_run;
            this.tsbVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVideo.Name = "tsbVideo";
            this.tsbVideo.Size = new System.Drawing.Size(28, 31);
            this.tsbVideo.Text = "录像";
            this.tsbVideo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbVideo.Click += new System.EventHandler(this.tsbVideo_Click);
            // 
            // tsbSetting
            // 
            this.tsbSetting.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSetting.Image = global::zlMedimgSystem.CTL.Capture.Properties.Resources.wrench;
            this.tsbSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetting.Name = "tsbSetting";
            this.tsbSetting.Size = new System.Drawing.Size(28, 31);
            this.tsbSetting.Text = "设置";
            this.tsbSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSetting.Click += new System.EventHandler(this.tsbSetting_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // tsbRestart
            // 
            this.tsbRestart.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbRestart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRestart.Image = global::zlMedimgSystem.CTL.Capture.Properties.Resources.restart15;
            this.tsbRestart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRestart.Name = "tsbRestart";
            this.tsbRestart.Size = new System.Drawing.Size(28, 31);
            this.tsbRestart.Text = "重启";
            this.tsbRestart.Click += new System.EventHandler(this.tsbRestart_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.BackColor = System.Drawing.Color.Black;
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.Black;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // tsbClear
            // 
            this.tsbClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClear.Image = global::zlMedimgSystem.CTL.Capture.Properties.Resources.selection_recycle1;
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbClear.Size = new System.Drawing.Size(28, 31);
            this.tsbClear.Text = "取消";
            this.tsbClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.MaximumSize = new System.Drawing.Size(0, 29);
            this.label1.MinimumSize = new System.Drawing.Size(0, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 29);
            this.label1.TabIndex = 6;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CaptureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panlVideoBack);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Name = "CaptureControl";
            this.Size = new System.Drawing.Size(409, 357);
            this.panlVideoBack.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoCamera;
        private BusinessBase.Controls.ToolStripEx toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbCapture;
        private System.Windows.Forms.ToolStripButton tsbVideo;
        private System.Windows.Forms.ToolStripButton tsbSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsbRestart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panlVideoBack;
        private System.Windows.Forms.Label label1;
    }
}
