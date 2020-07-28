namespace zlMedimgSystem.CTL.Query
{
    partial class frmQueryDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryDesign));
            this.queryDesigner1 = new zlMedimgSystem.QueryDesign.QueryDesigner();
            this.toolStripEx1 = new zlMedimgSystem.BusinessBase.Controls.ToolStripEx();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsCbxDataSource = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbInsertWhere = new System.Windows.Forms.ToolStripButton();
            this.tsbLayout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbTest = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // queryDesigner1
            // 
            this.queryDesigner1.DesignState = false;
            this.queryDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryDesigner1.Location = new System.Drawing.Point(0, 31);
            this.queryDesigner1.Name = "queryDesigner1";
            this.queryDesigner1.Size = new System.Drawing.Size(856, 487);
            this.queryDesigner1.SysParList = ((System.Collections.Generic.List<string>)(resources.GetObject("queryDesigner1.SysParList")));
            this.queryDesigner1.TabIndex = 0;
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsCbxDataSource,
            this.toolStripSeparator1,
            this.tsbInsertWhere,
            this.tsbLayout,
            this.toolStripSeparator2,
            this.tsbTest,
            this.tsbRefresh,
            this.toolStripSeparator3,
            this.tsbSave,
            this.tsbExit});
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Size = new System.Drawing.Size(856, 31);
            this.toolStripEx1.TabIndex = 1;
            this.toolStripEx1.Text = "toolStripEx1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 28);
            this.toolStripLabel1.Text = "数据源";
            // 
            // tsCbxDataSource
            // 
            this.tsCbxDataSource.AutoSize = false;
            this.tsCbxDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCbxDataSource.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tsCbxDataSource.Name = "tsCbxDataSource";
            this.tsCbxDataSource.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbInsertWhere
            // 
            this.tsbInsertWhere.Image = global::zlMedimgSystem.CTL.Query.Properties.Resources.element_add;
            this.tsbInsertWhere.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsertWhere.Name = "tsbInsertWhere";
            this.tsbInsertWhere.Size = new System.Drawing.Size(60, 28);
            this.tsbInsertWhere.Text = "条件";
            this.tsbInsertWhere.Click += new System.EventHandler(this.tsbInsertWhere_Click);
            // 
            // tsbLayout
            // 
            this.tsbLayout.Image = global::zlMedimgSystem.CTL.Query.Properties.Resources.elements_selection;
            this.tsbLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLayout.Name = "tsbLayout";
            this.tsbLayout.Size = new System.Drawing.Size(60, 28);
            this.tsbLayout.Text = "布局";
            this.tsbLayout.Visible = false;
            this.tsbLayout.Click += new System.EventHandler(this.tsbLayout_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbTest
            // 
            this.tsbTest.Image = global::zlMedimgSystem.CTL.Query.Properties.Resources.debug_view;
            this.tsbTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTest.Name = "tsbTest";
            this.tsbTest.Size = new System.Drawing.Size(60, 28);
            this.tsbTest.Text = "测试";
            this.tsbTest.Click += new System.EventHandler(this.tsbTest_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = global::zlMedimgSystem.CTL.Query.Properties.Resources.refresh;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(60, 28);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = global::zlMedimgSystem.CTL.Query.Properties.Resources.disk_blue;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(60, 28);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::zlMedimgSystem.CTL.Query.Properties.Resources.exit;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(60, 28);
            this.tsbExit.Text = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 518);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(856, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // frmQueryDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 540);
            this.Controls.Add(this.queryDesigner1);
            this.Controls.Add(this.toolStripEx1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmQueryDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmQueryDesign_Load);
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QueryDesign.QueryDesigner queryDesigner1;
        private BusinessBase.Controls.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tsCbxDataSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbInsertWhere;
        private System.Windows.Forms.ToolStripButton tsbLayout;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}