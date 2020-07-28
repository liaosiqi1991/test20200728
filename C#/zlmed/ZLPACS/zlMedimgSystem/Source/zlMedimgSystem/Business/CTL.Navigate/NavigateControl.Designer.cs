namespace zlMedimgSystem.CTL.Navigate
{
    partial class NavigateControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigateControl));
            this.tileNavPane = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.navButLog = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButtonSplit2 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navCbx = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButtonSplit3 = new DevExpress.XtraBars.Navigation.NavButton();
            this.nButClose = new DevExpress.XtraBars.Navigation.NavButton();
            this.menuPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // tileNavPane
            // 
            this.tileNavPane.Appearance.BackColor = System.Drawing.Color.Gray;
            this.tileNavPane.Appearance.Options.UseBackColor = true;
            this.tileNavPane.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tileNavPane.ButtonPadding = new System.Windows.Forms.Padding(12);
            this.tileNavPane.Buttons.Add(this.navButLog);
            this.tileNavPane.Buttons.Add(this.navButtonSplit2);
            this.tileNavPane.Buttons.Add(this.navCbx);
            this.tileNavPane.Buttons.Add(this.navButtonSplit3);
            this.tileNavPane.Buttons.Add(this.nButClose);
            // 
            // tileNavCategory1
            // 
            this.tileNavPane.DefaultCategory.Name = "tileNavCategory1";
            this.tileNavPane.DefaultCategory.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane.DefaultCategory.OwnerCollection = null;
            // 
            // 
            // 
            this.tileNavPane.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavPane.DefaultCategory.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileNavPane.Location = new System.Drawing.Point(0, 0);
            this.tileNavPane.Name = "tileNavPane";
            this.tileNavPane.OptionsPrimaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane.OptionsSecondaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane.Size = new System.Drawing.Size(969, 45);
            this.tileNavPane.TabIndex = 12;
            this.tileNavPane.Text = "tileNavPane1";
            this.tileNavPane.DoubleClick += new System.EventHandler(this.tileNavPane_DoubleClick);
            this.tileNavPane.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tileNavPane1_MouseDown);
            this.tileNavPane.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tileNavPane1_MouseMove);
            this.tileNavPane.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tileNavPane1_MouseUp);
            // 
            // navButLog
            // 
            this.navButLog.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.navButLog.Caption = "";
            this.navButLog.Enabled = false;
            this.navButLog.Glyph = ((System.Drawing.Image)(resources.GetObject("navButLog.Glyph")));
            this.navButLog.Name = "navButLog";
            this.navButLog.Padding = new System.Windows.Forms.Padding(2);
            this.navButLog.Tag = "Navigate";
            // 
            // navButtonSplit2
            // 
            this.navButtonSplit2.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButtonSplit2.Caption = "";
            this.navButtonSplit2.Enabled = false;
            this.navButtonSplit2.Name = "navButtonSplit2";
            this.navButtonSplit2.Tag = "Navigate";
            // 
            // navCbx
            // 
            this.navCbx.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navCbx.Caption = "";
            this.navCbx.Glyph = ((System.Drawing.Image)(resources.GetObject("navCbx.Glyph")));
            this.navCbx.Name = "navCbx";
            this.navCbx.Tag = "Navigate";
            this.navCbx.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.navCbx_ElementClick);
            // 
            // navButtonSplit3
            // 
            this.navButtonSplit3.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButtonSplit3.Caption = "";
            this.navButtonSplit3.Enabled = false;
            this.navButtonSplit3.Name = "navButtonSplit3";
            this.navButtonSplit3.Tag = "Navigate";
            // 
            // nButClose
            // 
            this.nButClose.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.nButClose.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.nButClose.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nButClose.Appearance.Options.UseBackColor = true;
            this.nButClose.Appearance.Options.UseFont = true;
            this.nButClose.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.nButClose.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nButClose.AppearanceHovered.Options.UseBackColor = true;
            this.nButClose.AppearanceHovered.Options.UseFont = true;
            this.nButClose.AppearanceSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.nButClose.AppearanceSelected.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nButClose.AppearanceSelected.Options.UseBackColor = true;
            this.nButClose.AppearanceSelected.Options.UseFont = true;
            this.nButClose.Caption = "╳";
            this.nButClose.Name = "nButClose";
            this.nButClose.Tag = "Navigate";
            this.nButClose.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.nButClose_ElementClick);
            // 
            // menuPopup
            // 
            this.menuPopup.Name = "menuPopup";
            this.menuPopup.Size = new System.Drawing.Size(61, 4);
            // 
            // NavigateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tileNavPane);
            this.Name = "NavigateControl";
            this.Size = new System.Drawing.Size(969, 45);
            this.Load += new System.EventHandler(this.NavigateControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane;
        private DevExpress.XtraBars.Navigation.NavButton navButLog;
        private DevExpress.XtraBars.Navigation.NavButton navButtonSplit2;
        private DevExpress.XtraBars.Navigation.NavButton navCbx;
        private DevExpress.XtraBars.Navigation.NavButton navButtonSplit3;
        private DevExpress.XtraBars.Navigation.NavButton nButClose;
        private System.Windows.Forms.ContextMenuStrip menuPopup;
    }
}
