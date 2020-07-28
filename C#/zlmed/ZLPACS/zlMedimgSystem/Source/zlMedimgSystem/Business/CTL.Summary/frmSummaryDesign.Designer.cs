namespace zlMedimgSystem.CTL.Summary
{
    partial class frmSummaryDesign
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.toolStripEx1 = new zlMedimgSystem.BusinessBase.Controls.ToolStripEx();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            this.toolStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 31);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.ShowLayoutTreeView = false;
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowPropertyGrid = true;
            this.layoutControl1.OptionsCustomizationForm.ShowRedoButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowUndoButton = false;
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
            this.layoutControl1.Size = new System.Drawing.Size(474, 261);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(474, 261);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbData,
            this.toolStripSeparator1,
            this.tsbExit});
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Size = new System.Drawing.Size(474, 31);
            this.toolStripEx1.TabIndex = 1;
            this.toolStripEx1.Text = "toolStripEx1";
            // 
            // tsbSave
            // 
            this.tsbSave.Image = global::zlMedimgSystem.CTL.Summary.Properties.Resources.disk_blue;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(60, 28);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbData
            // 
            this.tsbData.Image = global::zlMedimgSystem.CTL.Summary.Properties.Resources.data_table;
            this.tsbData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbData.Name = "tsbData";
            this.tsbData.Size = new System.Drawing.Size(60, 28);
            this.tsbData.Text = "数据";
            this.tsbData.Click += new System.EventHandler(this.tsbData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::zlMedimgSystem.CTL.Summary.Properties.Resources.exit1;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(60, 28);
            this.tsbExit.Text = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // frmSummaryDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 292);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.toolStripEx1);
            this.Name = "frmSummaryDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块设计";
            this.Load += new System.EventHandler(this.frmSummaryDesign_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private BusinessBase.Controls.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbData;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}