namespace zlMedimgSystem.ExtFuncs
{
    partial class FuncControl
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
            this.lcDemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcDemo.Location = new System.Drawing.Point(0, 0);
            this.lcDemo.Name = "lcDemo";
            this.lcDemo.Root = this.layoutControlGroup1;
            this.lcDemo.Size = new System.Drawing.Size(332, 173);
            this.lcDemo.TabIndex = 0;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(332, 173);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // FuncControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcDemo);
            this.Name = "FuncControl";
            this.Size = new System.Drawing.Size(332, 173);
            ((System.ComponentModel.ISupportInitialize)(this.lcDemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcDemo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
    }
}
