namespace zlMedimgSystem.CTL.DataView
{
    partial class DataViewLayout
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
            this.lcDemo = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.lcDemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcDemo
            // 
            this.lcDemo.AutoSize = true;
            this.lcDemo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lcDemo.Location = new System.Drawing.Point(0, 0);
            this.lcDemo.Name = "lcDemo";
            this.lcDemo.OptionsCustomizationForm.ShowLayoutTreeView = false;
            this.lcDemo.OptionsCustomizationForm.ShowLoadButton = false;
            this.lcDemo.OptionsCustomizationForm.ShowRedoButton = false;
            this.lcDemo.OptionsCustomizationForm.ShowSaveButton = false;
            this.lcDemo.OptionsCustomizationForm.ShowUndoButton = false;
            this.lcDemo.OptionsSerialization.DiscardOldItems = true;
            this.lcDemo.OptionsSerialization.RestoreAppearanceItemCaption = true;
            this.lcDemo.OptionsSerialization.RestoreAppearanceTabPage = true;
            this.lcDemo.OptionsSerialization.RestoreGroupPadding = true;
            this.lcDemo.OptionsSerialization.RestoreGroupSpacing = true;
            this.lcDemo.OptionsSerialization.RestoreLayoutGroupAppearanceGroup = true;
            this.lcDemo.OptionsSerialization.RestoreLayoutItemPadding = true;
            this.lcDemo.OptionsSerialization.RestoreLayoutItemSpacing = true;
            this.lcDemo.OptionsSerialization.RestoreRootGroupPadding = true;
            this.lcDemo.OptionsSerialization.RestoreRootGroupSpacing = true;
            this.lcDemo.OptionsSerialization.RestoreTabbedGroupPadding = true;
            this.lcDemo.OptionsSerialization.RestoreTabbedGroupSpacing = true;
            this.lcDemo.OptionsSerialization.RestoreTextToControlDistance = true;
            this.lcDemo.Root = this.layoutControlGroup1;
            this.lcDemo.Size = new System.Drawing.Size(231, 20);
            this.lcDemo.TabIndex = 3;
            this.lcDemo.Text = "layoutControl1";
            this.lcDemo.ShowCustomization += new System.EventHandler(this.lcDemo_ShowCustomization);
            this.lcDemo.HideCustomization += new System.EventHandler(this.lcDemo_HideCustomization);
            this.lcDemo.Resize += new System.EventHandler(this.lcDemo_Resize);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(231, 20);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // DataViewLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcDemo);
            this.Name = "DataViewLayout";
            this.Size = new System.Drawing.Size(231, 150);
            ((System.ComponentModel.ISupportInitialize)(this.lcDemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcDemo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
    }
}
