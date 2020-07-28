namespace zlMedimgSystem.CTL.Image
{
    partial class ImageControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageControl));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.自带菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.内部菜单测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new zlMedimgSystem.BusinessBase.Controls.ToolStripEx();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbSetting = new System.Windows.Forms.ToolStripButton();
            this.splitPage1 = new zlMedimgSystem.BusinessBase.Controls.SplitPage();
            this.imageView1 = new zlMedimgSystem.BusinessBase.Controls.ImageView();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "unselected4.ico");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Symbol Error 3.ico");
            this.imageList2.Images.SetKeyName(1, "keylock.ico");
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "video.bmp");
            this.imageList3.Images.SetKeyName(1, "audio.bmp");
            // 
            // 自带菜单ToolStripMenuItem
            // 
            this.自带菜单ToolStripMenuItem.Name = "自带菜单ToolStripMenuItem";
            this.自带菜单ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 测试ToolStripMenuItem
            // 
            this.测试ToolStripMenuItem.Name = "测试ToolStripMenuItem";
            this.测试ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 内部菜单测试ToolStripMenuItem
            // 
            this.内部菜单测试ToolStripMenuItem.Name = "内部菜单测试ToolStripMenuItem";
            this.内部菜单测试ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Controls.Add(this.splitPage1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 260);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 33);
            this.panel1.TabIndex = 3;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Gray;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh,
            this.tsbSetting});
            this.toolStrip2.Location = new System.Drawing.Point(120, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip2.Size = new System.Drawing.Size(635, 33);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = global::zlMedimgSystem.CTL.Image.Properties.Resources.refresh;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(28, 30);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbSetting
            // 
            this.tsbSetting.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSetting.Image = global::zlMedimgSystem.CTL.Image.Properties.Resources.wrench;
            this.tsbSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetting.Name = "tsbSetting";
            this.tsbSetting.Size = new System.Drawing.Size(28, 30);
            this.tsbSetting.Text = "设置";
            this.tsbSetting.Click += new System.EventHandler(this.tsbSetting_Click);
            // 
            // splitPage1
            // 
            this.splitPage1.BackColor = System.Drawing.Color.Gray;
            this.splitPage1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitPage1.Location = new System.Drawing.Point(0, 0);
            this.splitPage1.Name = "splitPage1";
            this.splitPage1.Size = new System.Drawing.Size(120, 33);
            this.splitPage1.TabIndex = 3;
            // 
            // imageView1
            // 
            this.imageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageView1.Location = new System.Drawing.Point(0, 0);
            this.imageView1.Name = "imageView1";
            this.imageView1.Size = new System.Drawing.Size(755, 260);
            this.imageView1.TabIndex = 4;
            this.imageView1.ViewCount = 8;
            this.imageView1.OnItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.imageView1_OnItemClick);
            this.imageView1.OnItemDblClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.imageView1_OnItemDblClick);
            this.imageView1.OnItemMouseEnter += new zlMedimgSystem.BusinessBase.Controls.TileItemMouseEnter(this.imageView1_OnItemMouseEnter);
            this.imageView1.OnItemMouseLeave += new System.EventHandler(this.imageView1_OnItemMouseLeave);
            this.imageView1.OnViewerMouseLeave += new System.EventHandler(this.imageView1_OnViewerMouseLeave);
            // 
            // ImageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageView1);
            this.Controls.Add(this.panel1);
            this.Name = "ImageControl";
            this.Size = new System.Drawing.Size(755, 293);
            this.Leave += new System.EventHandler(this.ImageControl_Leave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private BusinessBase.Controls.ToolStripEx toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolStripButton tsbSetting;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.ToolStripMenuItem 自带菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 内部菜单测试ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private BusinessBase.Controls.SplitPage splitPage1;
        private BusinessBase.Controls.ImageView imageView1;
    }
}
