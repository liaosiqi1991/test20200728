namespace zlMedimgSystem.CTL.Image
{
    partial class frmImageDesign
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
            this.toolsConfig1 = new zlMedimgSystem.BusinessBase.Controls.ToolsConfig();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.chkImgRefresh = new System.Windows.Forms.CheckBox();
            this.chkImgSetting = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // toolsConfig1
            // 
            this.toolsConfig1.Location = new System.Drawing.Point(12, 12);
            this.toolsConfig1.Name = "toolsConfig1";
            this.toolsConfig1.Size = new System.Drawing.Size(798, 268);
            this.toolsConfig1.TabIndex = 0;
            this.toolsConfig1.ToolsDesign = null;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(735, 286);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 25;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(654, 286);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 24;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // chkImgRefresh
            // 
            this.chkImgRefresh.AutoSize = true;
            this.chkImgRefresh.Checked = true;
            this.chkImgRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImgRefresh.Location = new System.Drawing.Point(12, 290);
            this.chkImgRefresh.Name = "chkImgRefresh";
            this.chkImgRefresh.Size = new System.Drawing.Size(72, 16);
            this.chkImgRefresh.TabIndex = 26;
            this.chkImgRefresh.Text = "图像刷新";
            this.chkImgRefresh.UseVisualStyleBackColor = true;
            // 
            // chkImgSetting
            // 
            this.chkImgSetting.AutoSize = true;
            this.chkImgSetting.Checked = true;
            this.chkImgSetting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImgSetting.Location = new System.Drawing.Point(90, 290);
            this.chkImgSetting.Name = "chkImgSetting";
            this.chkImgSetting.Size = new System.Drawing.Size(72, 16);
            this.chkImgSetting.TabIndex = 28;
            this.chkImgSetting.Text = "图像设置";
            this.chkImgSetting.UseVisualStyleBackColor = true;
            // 
            // frmImageDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 320);
            this.Controls.Add(this.chkImgSetting);
            this.Controls.Add(this.chkImgRefresh);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.toolsConfig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImageDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmImageDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BusinessBase.Controls.ToolsConfig toolsConfig1;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.CheckBox chkImgRefresh;
        private System.Windows.Forms.CheckBox chkImgSetting;
    }
}