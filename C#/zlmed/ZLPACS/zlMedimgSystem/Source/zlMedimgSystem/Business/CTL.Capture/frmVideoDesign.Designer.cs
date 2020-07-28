namespace zlMedimgSystem.CTL.Capture
{
    partial class frmVideoDesign
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
            this.cbxDockWay = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.chkCapture = new System.Windows.Forms.CheckBox();
            this.chkRecord = new System.Windows.Forms.CheckBox();
            this.chkRestart = new System.Windows.Forms.CheckBox();
            this.chkExit = new System.Windows.Forms.CheckBox();
            this.chkSetting = new System.Windows.Forms.CheckBox();
            this.toolsConfig1 = new zlMedimgSystem.BusinessBase.Controls.ToolsConfig();
            this.SuspendLayout();
            // 
            // cbxDockWay
            // 
            this.cbxDockWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDockWay.FormattingEnabled = true;
            this.cbxDockWay.Items.AddRange(new object[] {
            "顶部",
            "左侧",
            "右侧",
            "底部"});
            this.cbxDockWay.Location = new System.Drawing.Point(75, 289);
            this.cbxDockWay.Name = "cbxDockWay";
            this.cbxDockWay.Size = new System.Drawing.Size(104, 20);
            this.cbxDockWay.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "停靠位置";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(724, 286);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 23;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(643, 286);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 22;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // chkCapture
            // 
            this.chkCapture.AutoSize = true;
            this.chkCapture.Checked = true;
            this.chkCapture.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCapture.Location = new System.Drawing.Point(185, 291);
            this.chkCapture.Name = "chkCapture";
            this.chkCapture.Size = new System.Drawing.Size(72, 16);
            this.chkCapture.TabIndex = 28;
            this.chkCapture.Text = "采集按钮";
            this.chkCapture.UseVisualStyleBackColor = true;
            // 
            // chkRecord
            // 
            this.chkRecord.AutoSize = true;
            this.chkRecord.Checked = true;
            this.chkRecord.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecord.Location = new System.Drawing.Point(263, 291);
            this.chkRecord.Name = "chkRecord";
            this.chkRecord.Size = new System.Drawing.Size(72, 16);
            this.chkRecord.TabIndex = 29;
            this.chkRecord.Text = "录像按钮";
            this.chkRecord.UseVisualStyleBackColor = true;
            // 
            // chkRestart
            // 
            this.chkRestart.AutoSize = true;
            this.chkRestart.Checked = true;
            this.chkRestart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRestart.Location = new System.Drawing.Point(341, 291);
            this.chkRestart.Name = "chkRestart";
            this.chkRestart.Size = new System.Drawing.Size(72, 16);
            this.chkRestart.TabIndex = 30;
            this.chkRestart.Text = "重启按钮";
            this.chkRestart.UseVisualStyleBackColor = true;
            // 
            // chkExit
            // 
            this.chkExit.AutoSize = true;
            this.chkExit.Checked = true;
            this.chkExit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExit.Location = new System.Drawing.Point(419, 290);
            this.chkExit.Name = "chkExit";
            this.chkExit.Size = new System.Drawing.Size(72, 16);
            this.chkExit.TabIndex = 31;
            this.chkExit.Text = "退出按钮";
            this.chkExit.UseVisualStyleBackColor = true;
            // 
            // chkSetting
            // 
            this.chkSetting.AutoSize = true;
            this.chkSetting.Checked = true;
            this.chkSetting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSetting.Location = new System.Drawing.Point(497, 291);
            this.chkSetting.Name = "chkSetting";
            this.chkSetting.Size = new System.Drawing.Size(72, 16);
            this.chkSetting.TabIndex = 32;
            this.chkSetting.Text = "设置按钮";
            this.chkSetting.UseVisualStyleBackColor = true;
            // 
            // toolsConfig1
            // 
            this.toolsConfig1.Location = new System.Drawing.Point(12, 12);
            this.toolsConfig1.Name = "toolsConfig1";
            this.toolsConfig1.Size = new System.Drawing.Size(790, 268);
            this.toolsConfig1.TabIndex = 33;
            this.toolsConfig1.ToolsDesign = null;
            // 
            // frmVideoDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 320);
            this.Controls.Add(this.toolsConfig1);
            this.Controls.Add(this.chkSetting);
            this.Controls.Add(this.chkExit);
            this.Controls.Add(this.chkRestart);
            this.Controls.Add(this.chkRecord);
            this.Controls.Add(this.chkCapture);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxDockWay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVideoDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmVideoDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxDockWay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox chkCapture;
        private System.Windows.Forms.CheckBox chkRecord;
        private System.Windows.Forms.CheckBox chkRestart;
        private System.Windows.Forms.CheckBox chkExit;
        private System.Windows.Forms.CheckBox chkSetting;
        private BusinessBase.Controls.ToolsConfig toolsConfig1;
    }
}