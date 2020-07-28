namespace zlMedimgSystem.BusinessBase.Controls
{
    partial class SplitPage
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
            this.toolStrip2 = new zlMedimgSystem.BusinessBase.Controls.ToolStripEx();
            this.tsbLast = new System.Windows.Forms.ToolStripButton();
            this.tsCbxPageNum = new System.Windows.Forms.ToolStripComboBox();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLast,
            this.tsCbxPageNum,
            this.tsbNext});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip2.Size = new System.Drawing.Size(122, 32);
            this.toolStrip2.TabIndex = 3;
            // 
            // tsbLast
            // 
            this.tsbLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLast.Image = global::zlMedimgSystem.BusinessBase.Properties.Resources.nav_left_green;
            this.tsbLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLast.Name = "tsbLast";
            this.tsbLast.Size = new System.Drawing.Size(28, 29);
            this.tsbLast.Click += new System.EventHandler(this.tsbLast_Click);
            // 
            // tsCbxPageNum
            // 
            this.tsCbxPageNum.AutoSize = false;
            this.tsCbxPageNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCbxPageNum.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tsCbxPageNum.Name = "tsCbxPageNum";
            this.tsCbxPageNum.Size = new System.Drawing.Size(60, 25);
            this.tsCbxPageNum.SelectedIndexChanged += new System.EventHandler(this.tsCbxPageNum_SelectedIndexChanged);
            // 
            // tsbNext
            // 
            this.tsbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNext.Image = global::zlMedimgSystem.BusinessBase.Properties.Resources.nav_right_green;
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(28, 29);
            this.tsbNext.Text = "toolStripButton3";
            this.tsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // SplitPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.toolStrip2);
            this.Name = "SplitPage";
            this.Size = new System.Drawing.Size(122, 32);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ToolStripEx toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbLast;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripComboBox tsCbxPageNum;
    }
}
