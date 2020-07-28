namespace zlMedimgSystem.Design
{
    partial class DesignControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BaseMenu = new System.Windows.Forms.ContextMenuStrip();
            this.SuspendLayout();
            // 
            // BaseMenu
            // 
            this.BaseMenu.Name = "menuRClick";
            this.BaseMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // DesignControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.BaseMenu;
            this.Name = "DesignControl";
            this.Size = new System.Drawing.Size(182, 150);
            this.Load += new System.EventHandler(this.DesignControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ContextMenuStrip BaseMenu;
    }
}
