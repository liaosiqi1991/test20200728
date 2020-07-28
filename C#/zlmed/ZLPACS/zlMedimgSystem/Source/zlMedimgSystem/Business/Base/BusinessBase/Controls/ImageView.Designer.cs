namespace zlMedimgSystem.BusinessBase.Controls
{
    partial class ImageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageView));
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.自带菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.内部菜单测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            // 
            // tileControl1
            // 
            this.tileControl1.AllowDrag = false;
            this.tileControl1.AllowDragTilesBetweenGroups = false;
            this.tileControl1.AllowSelectedItem = true;
            this.tileControl1.AppearanceItem.Normal.BackColor = System.Drawing.Color.Black;
            this.tileControl1.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileControl1.AppearanceItem.Selected.BorderColor = System.Drawing.Color.Red;
            this.tileControl1.AppearanceItem.Selected.Options.UseBorderColor = true;
            this.tileControl1.BackColor = System.Drawing.Color.Black;
            this.tileControl1.ColumnCount = 1;
            this.tileControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileControl1.DragSize = new System.Drawing.Size(0, 0);
            this.tileControl1.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tileControl1.ItemBorderVisibility = DevExpress.XtraEditors.TileItemBorderVisibility.Always;
            this.tileControl1.ItemCheckMode = DevExpress.XtraEditors.TileItemCheckMode.Multiple;
            this.tileControl1.ItemImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileControl1.ItemImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            this.tileControl1.ItemPadding = new System.Windows.Forms.Padding(2);
            this.tileControl1.Location = new System.Drawing.Point(0, 0);
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileControl1.ScrollButtonFadeAnimationTime = 300;
            this.tileControl1.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollBar;
            this.tileControl1.Size = new System.Drawing.Size(755, 293);
            this.tileControl1.TabIndex = 1;
            this.tileControl1.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tileControl1.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileControl1_ItemClick);
            this.tileControl1.ItemDoubleClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileControl1_ItemDoubleClick);
            this.tileControl1.RightItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileControl1_RightItemClick);
            this.tileControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tileControl1_MouseMove);
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
            // ImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tileControl1);
            this.Name = "ImageView";
            this.Size = new System.Drawing.Size(755, 293);
            this.Resize += new System.EventHandler(this.ImageControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TileControl tileControl1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.ToolStripMenuItem 自带菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 内部菜单测试ToolStripMenuItem;
    }
}
