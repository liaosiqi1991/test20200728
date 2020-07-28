namespace zlMedimgSystem.BaseSettings
{
    partial class frmAdminUserSetting
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSurePwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtAdminName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butApply = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtSurePwd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.txtAdminName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.butApply);
            this.panel1.Location = new System.Drawing.Point(213, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 140);
            this.panel1.TabIndex = 8;
            // 
            // txtSurePwd
            // 
            this.txtSurePwd.Location = new System.Drawing.Point(107, 77);
            this.txtSurePwd.Name = "txtSurePwd";
            this.txtSurePwd.Size = new System.Drawing.Size(249, 21);
            this.txtSurePwd.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "系统确认密码";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(107, 50);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(249, 21);
            this.txtPwd.TabIndex = 19;
            // 
            // txtAdminName
            // 
            this.txtAdminName.Location = new System.Drawing.Point(107, 23);
            this.txtAdminName.Name = "txtAdminName";
            this.txtAdminName.Size = new System.Drawing.Size(249, 21);
            this.txtAdminName.TabIndex = 18;
            this.txtAdminName.Text = "ADMIN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "系统管理账号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "系统管理密码";
            // 
            // butApply
            // 
            this.butApply.Location = new System.Drawing.Point(281, 106);
            this.butApply.Name = "butApply";
            this.butApply.Size = new System.Drawing.Size(75, 23);
            this.butApply.TabIndex = 6;
            this.butApply.Text = "应用(&A)";
            this.butApply.UseVisualStyleBackColor = true;
            this.butApply.Click += new System.EventHandler(this.butApply_Click);
            // 
            // frmAdminUserSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "frmAdminUserSetting";
            this.Text = "管理员设置";
            this.Load += new System.EventHandler(this.frmAdminUserSetting_Load);
            this.Resize += new System.EventHandler(this.frmAdminUserSetting_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butApply;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtAdminName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSurePwd;
        private System.Windows.Forms.Label label2;
    }
}