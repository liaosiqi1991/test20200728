namespace zlMedimgSystem.BaseSettings
{
    partial class frmFuncDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFuncDesign));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbInsertWhere = new System.Windows.Forms.ToolStripButton();
            this.tsbRefreshLayout = new System.Windows.Forms.ToolStripButton();
            this.tsbAdjustLayout = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.funcDesigner1 = new zlMedimgSystem.ExtFuncs.FuncDesigner();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.checkedListBox1);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(272, 533);
            this.panel1.TabIndex = 9;
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.Location = new System.Drawing.Point(2, 380);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(268, 3);
            this.splitter4.TabIndex = 4;
            this.splitter4.TabStop = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(2, 383);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2);
            this.label2.Size = new System.Drawing.Size(268, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "关联角色";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(2, 399);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(268, 132);
            this.checkedListBox1.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(2, 18);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(268, 513);
            this.treeView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2);
            this.label1.Size = new System.Drawing.Size(268, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "扩展功能定义";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(272, 40);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 533);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(944, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbInsertWhere,
            this.tsbRefreshLayout,
            this.tsbAdjustLayout,
            this.tsbSave,
            this.tsbLoad,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(944, 40);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbInsertWhere
            // 
            this.tsbInsertWhere.Image = ((System.Drawing.Image)(resources.GetObject("tsbInsertWhere.Image")));
            this.tsbInsertWhere.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsertWhere.Name = "tsbInsertWhere";
            this.tsbInsertWhere.Size = new System.Drawing.Size(60, 37);
            this.tsbInsertWhere.Text = "插入条件";
            this.tsbInsertWhere.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbRefreshLayout
            // 
            this.tsbRefreshLayout.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefreshLayout.Image")));
            this.tsbRefreshLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefreshLayout.Name = "tsbRefreshLayout";
            this.tsbRefreshLayout.Size = new System.Drawing.Size(60, 37);
            this.tsbRefreshLayout.Text = "刷新布局";
            this.tsbRefreshLayout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbAdjustLayout
            // 
            this.tsbAdjustLayout.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdjustLayout.Image")));
            this.tsbAdjustLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdjustLayout.Name = "tsbAdjustLayout";
            this.tsbAdjustLayout.Size = new System.Drawing.Size(60, 37);
            this.tsbAdjustLayout.Text = "调整布局";
            this.tsbAdjustLayout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAdjustLayout.Click += new System.EventHandler(this.tsbAdjustLayout_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(60, 37);
            this.tsbSave.Text = "保存配置";
            this.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbLoad
            // 
            this.tsbLoad.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoad.Image")));
            this.tsbLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoad.Name = "tsbLoad";
            this.tsbLoad.Size = new System.Drawing.Size(60, 37);
            this.tsbLoad.Text = "载入配置";
            this.tsbLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(76, 37);
            this.toolStripButton4.Text = "功能测试";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // funcDesigner1
            // 
            this.funcDesigner1.DesignState = false;
            this.funcDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funcDesigner1.Location = new System.Drawing.Point(275, 40);
            this.funcDesigner1.Name = "funcDesigner1";
            this.funcDesigner1.Size = new System.Drawing.Size(669, 533);
            this.funcDesigner1.TabIndex = 13;
            // 
            // frmFuncDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 595);
            this.Controls.Add(this.funcDesigner1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmFuncDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扩展功能设置";
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbInsertWhere;
        private System.Windows.Forms.ToolStripButton tsbRefreshLayout;
        private System.Windows.Forms.ToolStripButton tsbAdjustLayout;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbLoad;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private zlMedimgSystem.ExtFuncs.FuncDesigner funcDesigner1;
    }
}