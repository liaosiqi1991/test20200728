namespace WindowsFormsApp2
{
    partial class ucImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucImage));
            this.snapDockManager1 = new DevExpress.Snap.Extensions.SnapDockManager(this.components);
            this.picImg = new System.Windows.Forms.PictureBox();
            this.picCheck = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.snapDockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // snapDockManager1
            // 
            this.snapDockManager1.Form = this;
            this.snapDockManager1.SnapControl = null;
            this.snapDockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // picImg
            // 
            this.picImg.BackColor = System.Drawing.Color.Black;
            this.picImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImg.Image = ((System.Drawing.Image)(resources.GetObject("picImg.Image")));
            this.picImg.Location = new System.Drawing.Point(4, 4);
            this.picImg.Name = "picImg";
            this.picImg.Padding = new System.Windows.Forms.Padding(2);
            this.picImg.Size = new System.Drawing.Size(408, 535);
            this.picImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImg.TabIndex = 6;
            this.picImg.TabStop = false;
            this.picImg.Click += new System.EventHandler(this.ucImage_Enter);
            this.picImg.Resize += new System.EventHandler(this.picImg_Resize);
            // 
            // picCheck
            // 
            this.picCheck.BackColor = System.Drawing.Color.White;
            this.picCheck.Location = new System.Drawing.Point(7, 7);
            this.picCheck.Name = "picCheck";
            this.picCheck.Size = new System.Drawing.Size(20, 20);
            this.picCheck.TabIndex = 7;
            this.picCheck.TabStop = false;
            this.picCheck.Click += new System.EventHandler(this.picCheck_Click);
            // 
            // ucImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.picCheck);
            this.Controls.Add(this.picImg);
            this.Name = "ucImage";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(416, 543);
            this.Enter += new System.EventHandler(this.ucImage_Enter);
            this.Leave += new System.EventHandler(this.ucImage_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.snapDockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Snap.Extensions.SnapDockManager snapDockManager1;
        private System.Windows.Forms.PictureBox picImg;
        private System.Windows.Forms.PictureBox picCheck;
    }
}
