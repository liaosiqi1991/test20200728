namespace zlMedimgSystem.CTL.DataView
{
    partial class DataViewControl
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
            this.dataViewLayout1 = new zlMedimgSystem.CTL.DataView.DataViewLayout();
            this.SuspendLayout();
            // 
            // dataViewLayout1
            // 
            this.dataViewLayout1.DBHelper = null;
            this.dataViewLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewLayout1.IsDesignModel = false;
            this.dataViewLayout1.Location = new System.Drawing.Point(0, 0);
            this.dataViewLayout1.Name = "dataViewLayout1";
            this.dataViewLayout1.SimpleState = false;
            this.dataViewLayout1.Size = new System.Drawing.Size(182, 150);
            this.dataViewLayout1.TabIndex = 1;
            this.dataViewLayout1.ThridDBHelper = null;
            // 
            // DataViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataViewLayout1);
            this.Name = "DataViewControl";
            this.ResumeLayout(false);

        }

        #endregion

        private DataViewLayout dataViewLayout1;
    }
}
