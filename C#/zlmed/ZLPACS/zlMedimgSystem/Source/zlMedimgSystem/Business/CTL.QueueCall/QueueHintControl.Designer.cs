namespace zlMedimgSystem.CTL.QueueHint
{
    partial class QueueHintControl
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
            this.labCallContext = new System.Windows.Forms.Label();
            this.labHead = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labCallContext
            // 
            this.labCallContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labCallContext.Location = new System.Drawing.Point(35, 0);
            this.labCallContext.Name = "labCallContext";
            this.labCallContext.Size = new System.Drawing.Size(190, 150);
            this.labCallContext.TabIndex = 2;
            this.labCallContext.Text = "label2";
            this.labCallContext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labHead
            // 
            this.labHead.BackColor = System.Drawing.Color.Gray;
            this.labHead.Dock = System.Windows.Forms.DockStyle.Left;
            this.labHead.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labHead.ForeColor = System.Drawing.Color.White;
            this.labHead.Image = global::zlMedimgSystem.CTL.QueueHint.Properties.Resources.calling;
            this.labHead.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labHead.Location = new System.Drawing.Point(0, 0);
            this.labHead.Name = "labHead";
            this.labHead.Padding = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.labHead.Size = new System.Drawing.Size(35, 150);
            this.labHead.TabIndex = 1;
            this.labHead.Text = "\r\n当\r\n前\r\n呼\r\n叫";
            this.labHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QueueCallControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labCallContext);
            this.Controls.Add(this.labHead);
            this.Name = "QueueCallControl";
            this.Size = new System.Drawing.Size(225, 150);
            this.Load += new System.EventHandler(this.QueueCallControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labHead;
        private System.Windows.Forms.Label labCallContext;
    }
}
