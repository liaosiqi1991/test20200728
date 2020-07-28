namespace zlMedimgSystem.CTL.Summary
{
    partial class SummaryControl
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.AutoScroll = false;
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsSerialization.DiscardOldItems = true;
            this.layoutControl1.OptionsSerialization.RestoreAppearanceItemCaption = true;
            this.layoutControl1.OptionsSerialization.RestoreAppearanceTabPage = true;
            this.layoutControl1.OptionsSerialization.RestoreGroupPadding = true;
            this.layoutControl1.OptionsSerialization.RestoreGroupSpacing = true;
            this.layoutControl1.OptionsSerialization.RestoreLayoutGroupAppearanceGroup = true;
            this.layoutControl1.OptionsSerialization.RestoreLayoutItemPadding = true;
            this.layoutControl1.OptionsSerialization.RestoreLayoutItemSpacing = true;
            this.layoutControl1.OptionsSerialization.RestoreRootGroupPadding = true;
            this.layoutControl1.OptionsSerialization.RestoreRootGroupSpacing = true;
            this.layoutControl1.OptionsSerialization.RestoreTabbedGroupPadding = true;
            this.layoutControl1.OptionsSerialization.RestoreTabbedGroupSpacing = true;
            this.layoutControl1.OptionsSerialization.RestoreTextToControlDistance = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(285, 76);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(285, 76);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // SummaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "SummaryControl";
            this.Size = new System.Drawing.Size(285, 76);
            this.Load += new System.EventHandler(this.SummaryControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
    }
}
