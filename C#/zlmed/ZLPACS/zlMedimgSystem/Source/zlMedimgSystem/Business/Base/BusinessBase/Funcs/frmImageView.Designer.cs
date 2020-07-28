namespace zlMedimgSystem.BusinessBase
{
    partial class frmImageView
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRestore = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCursor = new System.Windows.Forms.ToolStripButton();
            this.tsbDrage = new System.Windows.Forms.ToolStripButton();
            this.tsbZoom = new System.Windows.Forms.ToolStripButton();
            this.tsbLight = new System.Windows.Forms.ToolStripButton();
            this.tsbContrast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageView1 = new zlMedimgSystem.BusinessBase.Controls.ImageView();
            this.splitPage1 = new zlMedimgSystem.BusinessBase.Controls.SplitPage();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.imageEditor1 = new zlMedimgSystem.BusinessBase.ImageEditor();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRestore,
            this.toolStripSeparator1,
            this.tsbCursor,
            this.tsbDrage,
            this.tsbZoom,
            this.tsbLight,
            this.tsbContrast,
            this.toolStripSeparator2,
            this.tsbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(890, 48);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbRestore
            // 
            this.tsbRestore.Image = global::zlMedimgSystem.BusinessBase.Properties.Resources.redo;
            this.tsbRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRestore.Name = "tsbRestore";
            this.tsbRestore.Size = new System.Drawing.Size(36, 45);
            this.tsbRestore.Text = "恢复";
            this.tsbRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbRestore.Click += new System.EventHandler(this.tsbRestore_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbCursor
            // 
            this.tsbCursor.Checked = true;
            this.tsbCursor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbCursor.Image = global::zlMedimgSystem.BusinessBase.Properties.Resources.cursor;
            this.tsbCursor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCursor.Name = "tsbCursor";
            this.tsbCursor.Size = new System.Drawing.Size(36, 45);
            this.tsbCursor.Tag = "0";
            this.tsbCursor.Text = "光标";
            this.tsbCursor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCursor.Click += new System.EventHandler(this.tsbCursor_Click);
            // 
            // tsbDrage
            // 
            this.tsbDrage.Image = global::zlMedimgSystem.BusinessBase.Properties.Resources.drag;
            this.tsbDrage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDrage.Name = "tsbDrage";
            this.tsbDrage.Size = new System.Drawing.Size(36, 45);
            this.tsbDrage.Tag = "1";
            this.tsbDrage.Text = "拖动";
            this.tsbDrage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDrage.Click += new System.EventHandler(this.tsbCursor_Click);
            // 
            // tsbZoom
            // 
            this.tsbZoom.Image = global::zlMedimgSystem.BusinessBase.Properties.Resources.view;
            this.tsbZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoom.Name = "tsbZoom";
            this.tsbZoom.Size = new System.Drawing.Size(36, 45);
            this.tsbZoom.Tag = "2";
            this.tsbZoom.Text = "缩放";
            this.tsbZoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbZoom.Click += new System.EventHandler(this.tsbCursor_Click);
            // 
            // tsbLight
            // 
            this.tsbLight.Image = global::zlMedimgSystem.BusinessBase.Properties.Resources.lightbulb_on;
            this.tsbLight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLight.Name = "tsbLight";
            this.tsbLight.Size = new System.Drawing.Size(36, 45);
            this.tsbLight.Tag = "3";
            this.tsbLight.Text = "亮度";
            this.tsbLight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLight.Click += new System.EventHandler(this.tsbCursor_Click);
            // 
            // tsbContrast
            // 
            this.tsbContrast.Image = global::zlMedimgSystem.BusinessBase.Properties.Resources.Contrast;
            this.tsbContrast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbContrast.Name = "tsbContrast";
            this.tsbContrast.Size = new System.Drawing.Size(48, 45);
            this.tsbContrast.Tag = "4";
            this.tsbContrast.Text = "对比度";
            this.tsbContrast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbContrast.Click += new System.EventHandler(this.tsbCursor_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::zlMedimgSystem.BusinessBase.Properties.Resources.exit;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(36, 45);
            this.tsbExit.Text = "退出";
            this.tsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.imageView1);
            this.panel2.Controls.Add(this.splitPage1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 485);
            this.panel2.TabIndex = 6;
            // 
            // imageView1
            // 
            this.imageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageView1.Location = new System.Drawing.Point(0, 0);
            this.imageView1.Name = "imageView1";
            this.imageView1.Size = new System.Drawing.Size(235, 453);
            this.imageView1.TabIndex = 0;
            this.imageView1.ViewCount = 8;
            this.imageView1.OnItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.imageView1_OnItemClick);
            // 
            // splitPage1
            // 
            this.splitPage1.BackColor = System.Drawing.Color.Gray;
            this.splitPage1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitPage1.Location = new System.Drawing.Point(0, 453);
            this.splitPage1.Name = "splitPage1";
            this.splitPage1.Size = new System.Drawing.Size(235, 32);
            this.splitPage1.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(235, 48);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 485);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // imageEditor1
            // 
            this.imageEditor1.BackColor = System.Drawing.Color.Black;
            this.imageEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageEditor1.Image = null;
            this.imageEditor1.Location = new System.Drawing.Point(238, 48);
            this.imageEditor1.Name = "imageEditor1";
            this.imageEditor1.OperType = zlMedimgSystem.BusinessBase.ImageOperType.iotCursor;
            this.imageEditor1.Size = new System.Drawing.Size(652, 485);
            this.imageEditor1.TabIndex = 8;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 533);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(890, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // frmImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 555);
            this.Controls.Add(this.imageEditor1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmImageView";
            this.Text = "图像预览";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmImageView_FormClosed);
            this.Load += new System.EventHandler(this.frmImageView_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbZoom;
        private System.Windows.Forms.ToolStripButton tsbRestore;
        private Controls.ImageView imageView1;
        private Controls.SplitPage splitPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripButton tsbLight;
        private System.Windows.Forms.ToolStripButton tsbContrast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripButton tsbDrage;
        private ImageEditor imageEditor1;
        private System.Windows.Forms.ToolStripButton tsbCursor;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}