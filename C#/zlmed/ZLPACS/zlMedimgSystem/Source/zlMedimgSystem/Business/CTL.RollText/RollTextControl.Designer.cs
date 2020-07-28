namespace zlMedimgSystem.CTL.RollText
{
    partial class RollTextControl
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
            this.components = new System.ComponentModel.Container();
            this.labRoll = new System.Windows.Forms.Label();
            this.timerRoll = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labRoll
            // 
            this.labRoll.AutoSize = true;
            this.labRoll.Location = new System.Drawing.Point(39, 53);
            this.labRoll.Name = "labRoll";
            this.labRoll.Size = new System.Drawing.Size(35, 12);
            this.labRoll.TabIndex = 0;
            this.labRoll.Text = "     ";
            // 
            // timerRoll
            // 
            this.timerRoll.Interval = 50;
            this.timerRoll.Tick += new System.EventHandler(this.timerRoll_Tick);
            // 
            // RollTextControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labRoll);
            this.Name = "RollTextControl";
            this.Size = new System.Drawing.Size(324, 150);
            this.Resize += new System.EventHandler(this.RollTextControl_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labRoll;
        private System.Windows.Forms.Timer timerRoll;
    }
}
