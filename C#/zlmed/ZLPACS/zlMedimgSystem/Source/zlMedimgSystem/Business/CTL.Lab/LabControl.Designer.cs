namespace zlMedimgSystem.CTL.Lab
{
    partial class LabControl
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
            this.labContext = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // labContext
            // 
            this.labContext.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labContext.Location = new System.Drawing.Point(0, 0);
            this.labContext.Name = "labContext";
            this.labContext.Size = new System.Drawing.Size(93, 51);
            this.labContext.TabIndex = 1;
            this.labContext.Text = "Label";
            this.labContext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labContext_MouseDown);
            this.labContext.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labContext_MouseMove);
            this.labContext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labContext_MouseUp);
            // 
            // LabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labContext);
            this.Name = "LabControl";
            this.Size = new System.Drawing.Size(93, 51);
            this.Load += new System.EventHandler(this.LabControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labContext;
    }
}
