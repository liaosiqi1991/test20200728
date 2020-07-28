namespace zlMedimgSystem.CTL.Query
{
    partial class QueryControl
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
            this.queryFace1 = new zlMedimgSystem.QueryDesign.QueryFace();
            this.SuspendLayout();
            // 
            // queryFace1
            // 
            this.queryFace1.AutoSize = true;
            this.queryFace1.DBHelper = null;
            this.queryFace1.IsDesignModel = false;
            this.queryFace1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryFace1.Location = new System.Drawing.Point(0, 0);
            this.queryFace1.Name = "queryFace1";
            this.queryFace1.SimpleState = false;
            this.queryFace1.Size = new System.Drawing.Size(182, 150);
            this.queryFace1.TabIndex = 1;
            // 
            // QueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.queryFace1);
            this.Name = "QueryControl";
            this.Load += new System.EventHandler(this.QueryControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QueryDesign.QueryFace queryFace1;
    }
}
