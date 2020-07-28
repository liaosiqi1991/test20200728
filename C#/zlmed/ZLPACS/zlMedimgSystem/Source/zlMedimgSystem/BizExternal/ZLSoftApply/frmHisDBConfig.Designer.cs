namespace zlMedimgSystem.APPLY.ZLSoftApply
{
    partial class frmHisDBConfig
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAssembly = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxServerType = new System.Windows.Forms.ComboBox();
            this.txtUserPwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserAccount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInstance = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.butVerify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "服务器类型  ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(21, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 16;
            this.label3.Text = "服务器IP  ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAssembly
            // 
            this.txtAssembly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(217)))));
            this.txtAssembly.Location = new System.Drawing.Point(123, 41);
            this.txtAssembly.Name = "txtAssembly";
            this.txtAssembly.ReadOnly = true;
            this.txtAssembly.Size = new System.Drawing.Size(218, 21);
            this.txtAssembly.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(21, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 19;
            this.label4.Text = "服务器端口  ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(21, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 20;
            this.label5.Text = "服务器实例  ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxServerType
            // 
            this.cbxServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerType.FormattingEnabled = true;
            this.cbxServerType.Location = new System.Drawing.Point(123, 15);
            this.cbxServerType.Name = "cbxServerType";
            this.cbxServerType.Size = new System.Drawing.Size(218, 20);
            this.cbxServerType.TabIndex = 17;
            this.cbxServerType.SelectedIndexChanged += new System.EventHandler(this.cbxServerType_SelectedIndexChanged);
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Location = new System.Drawing.Point(123, 176);
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.PasswordChar = '*';
            this.txtUserPwd.Size = new System.Drawing.Size(218, 21);
            this.txtUserPwd.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(21, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 23);
            this.label6.TabIndex = 22;
            this.label6.Text = "授权账号  ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserAccount
            // 
            this.txtUserAccount.Location = new System.Drawing.Point(123, 149);
            this.txtUserAccount.Name = "txtUserAccount";
            this.txtUserAccount.Size = new System.Drawing.Size(218, 21);
            this.txtUserAccount.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(21, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 23);
            this.label7.TabIndex = 24;
            this.label7.Text = "授权密码  ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(21, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 23);
            this.label8.TabIndex = 28;
            this.label8.Text = "服务接口文件  ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInstance
            // 
            this.txtInstance.Location = new System.Drawing.Point(123, 122);
            this.txtInstance.Name = "txtInstance";
            this.txtInstance.Size = new System.Drawing.Size(218, 21);
            this.txtInstance.TabIndex = 25;
            this.txtInstance.Text = "orcl";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(123, 95);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(218, 21);
            this.txtPort.TabIndex = 23;
            this.txtPort.Text = "1521";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(123, 68);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(218, 21);
            this.txtIp.TabIndex = 21;
            this.txtIp.Text = "192.168.0.1";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(266, 214);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 36);
            this.butCancel.TabIndex = 30;
            this.butCancel.Text = "取 消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(185, 214);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 36);
            this.butSure.TabIndex = 29;
            this.butSure.Text = "确 定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // butVerify
            // 
            this.butVerify.Location = new System.Drawing.Point(12, 214);
            this.butVerify.Name = "butVerify";
            this.butVerify.Size = new System.Drawing.Size(75, 36);
            this.butVerify.TabIndex = 31;
            this.butVerify.Text = "验 证(&V)";
            this.butVerify.UseVisualStyleBackColor = true;
            this.butVerify.Click += new System.EventHandler(this.butVerify_Click);
            // 
            // frmHisDBConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 271);
            this.Controls.Add(this.butVerify);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAssembly);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxServerType);
            this.Controls.Add(this.txtUserPwd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUserAccount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtInstance);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHisDBConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HIS服务配置";
            this.Load += new System.EventHandler(this.frmHisDBConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAssembly;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxServerType;
        private System.Windows.Forms.TextBox txtUserPwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUserAccount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInstance;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.Button butVerify;
    }
}