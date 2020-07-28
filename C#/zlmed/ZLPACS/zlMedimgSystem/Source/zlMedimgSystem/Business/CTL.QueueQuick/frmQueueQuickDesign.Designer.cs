namespace zlMedimgSystem.CTL.QueueQuick
{
    partial class frmQueueQuickDesign
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
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.ceBackColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.ceForeColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.ceCallColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.feModuleFont = new zlMedimgSystem.BusinessBase.Controls.FontEditor();
            this.feWaitFont = new zlMedimgSystem.BusinessBase.Controls.FontEditor();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 153;
            this.label5.Text = "待呼叫排队字体";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 147;
            this.label1.Text = "呼叫中颜色";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 144;
            this.label7.Text = "前景色";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 143;
            this.label6.Text = "背景色";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 156;
            this.label2.Text = "模块字体";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(313, 230);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 160;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(232, 230);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 159;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // ceBackColor
            // 
            this.ceBackColor.BackColor = System.Drawing.Color.White;
            this.ceBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceBackColor.Color = System.Drawing.Color.Empty;
            this.ceBackColor.Location = new System.Drawing.Point(107, 12);
            this.ceBackColor.Name = "ceBackColor";
            this.ceBackColor.Size = new System.Drawing.Size(281, 18);
            this.ceBackColor.TabIndex = 161;
            // 
            // ceForeColor
            // 
            this.ceForeColor.BackColor = System.Drawing.Color.White;
            this.ceForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceForeColor.Color = System.Drawing.Color.Empty;
            this.ceForeColor.Location = new System.Drawing.Point(107, 36);
            this.ceForeColor.Name = "ceForeColor";
            this.ceForeColor.Size = new System.Drawing.Size(281, 18);
            this.ceForeColor.TabIndex = 162;
            // 
            // ceCallColor
            // 
            this.ceCallColor.BackColor = System.Drawing.Color.White;
            this.ceCallColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceCallColor.Color = System.Drawing.Color.Empty;
            this.ceCallColor.Location = new System.Drawing.Point(107, 60);
            this.ceCallColor.Name = "ceCallColor";
            this.ceCallColor.Size = new System.Drawing.Size(281, 18);
            this.ceCallColor.TabIndex = 163;
            // 
            // feModuleFont
            // 
            this.feModuleFont.BackColor = System.Drawing.Color.White;
            this.feModuleFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.feModuleFont.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.feModuleFont.Location = new System.Drawing.Point(107, 84);
            this.feModuleFont.Name = "feModuleFont";
            this.feModuleFont.Size = new System.Drawing.Size(281, 68);
            this.feModuleFont.TabIndex = 164;
            this.feModuleFont.Value = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // feWaitFont
            // 
            this.feWaitFont.BackColor = System.Drawing.Color.White;
            this.feWaitFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.feWaitFont.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.feWaitFont.Location = new System.Drawing.Point(107, 158);
            this.feWaitFont.Name = "feWaitFont";
            this.feWaitFont.Size = new System.Drawing.Size(281, 68);
            this.feWaitFont.TabIndex = 165;
            this.feWaitFont.Value = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // frmQueueQuickDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 271);
            this.Controls.Add(this.feWaitFont);
            this.Controls.Add(this.feModuleFont);
            this.Controls.Add(this.ceCallColor);
            this.Controls.Add(this.ceForeColor);
            this.Controls.Add(this.ceBackColor);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQueueQuickDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmQueueQuickDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.FontDialog fontDialog1;
        private BusinessBase.Controls.ColorEditor ceBackColor;
        private BusinessBase.Controls.ColorEditor ceForeColor;
        private BusinessBase.Controls.ColorEditor ceCallColor;
        private BusinessBase.Controls.FontEditor feModuleFont;
        private BusinessBase.Controls.FontEditor feWaitFont;
    }
}