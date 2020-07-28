namespace zlMedimgSystem.CTL.Chars
{
    partial class frmCharDesign
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
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.chkSetting = new System.Windows.Forms.CheckBox();
            this.toolsConfig1 = new zlMedimgSystem.BusinessBase.Controls.ToolsConfig();
            this.SuspendLayout();
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(725, 286);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 13;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(644, 286);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 12;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // chkSetting
            // 
            this.chkSetting.AutoSize = true;
            this.chkSetting.Checked = true;
            this.chkSetting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSetting.Location = new System.Drawing.Point(12, 290);
            this.chkSetting.Name = "chkSetting";
            this.chkSetting.Size = new System.Drawing.Size(72, 16);
            this.chkSetting.TabIndex = 15;
            this.chkSetting.Text = "参数设置";
            this.chkSetting.UseVisualStyleBackColor = true;
            // 
            // toolsConfig1
            // 
            this.toolsConfig1.Location = new System.Drawing.Point(12, 12);
            this.toolsConfig1.Name = "toolsConfig1";
            this.toolsConfig1.Size = new System.Drawing.Size(788, 268);
            this.toolsConfig1.TabIndex = 14;
            this.toolsConfig1.ToolsDesign = null;
            // 
            // frmCharDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 320);
            this.Controls.Add(this.chkSetting);
            this.Controls.Add(this.toolsConfig1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCharDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmCharDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private BusinessBase.Controls.ToolsConfig toolsConfig1;
        private System.Windows.Forms.CheckBox chkSetting;
    }
}