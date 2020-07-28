namespace zlMedimgSystem.DBConfig
{
    partial class frmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butVerfiyCfg = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVerifyAssembly = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxVerifyWay = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAssembly = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textAlias = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxServerType = new System.Windows.Forms.ComboBox();
            this.txtUserPwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserAccount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInstance = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.butVerify = new System.Windows.Forms.Button();
            this.butModify = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(702, 575);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butVerfiyCfg);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtVerifyAssembly);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbxVerifyWay);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtAssembly);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textAlias);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbxServerType);
            this.panel1.Controls.Add(this.txtUserPwd);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtUserAccount);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtInstance);
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtIp);
            this.panel1.Controls.Add(this.butVerify);
            this.panel1.Controls.Add(this.butModify);
            this.panel1.Controls.Add(this.butDel);
            this.panel1.Controls.Add(this.butNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(702, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 575);
            this.panel1.TabIndex = 1;
            // 
            // butVerfiyCfg
            // 
            this.butVerfiyCfg.Location = new System.Drawing.Point(295, 226);
            this.butVerfiyCfg.Name = "butVerfiyCfg";
            this.butVerfiyCfg.Size = new System.Drawing.Size(34, 20);
            this.butVerfiyCfg.TabIndex = 10;
            this.butVerfiyCfg.Text = "…";
            this.butVerfiyCfg.UseVisualStyleBackColor = true;
            this.butVerfiyCfg.Click += new System.EventHandler(this.butVerfiyCfg_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(5, 252);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 24;
            this.label10.Text = "认证驱动文件  ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "别名  ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVerifyAssembly
            // 
            this.txtVerifyAssembly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(217)))));
            this.txtVerifyAssembly.Location = new System.Drawing.Point(111, 252);
            this.txtVerifyAssembly.Name = "txtVerifyAssembly";
            this.txtVerifyAssembly.ReadOnly = true;
            this.txtVerifyAssembly.Size = new System.Drawing.Size(218, 21);
            this.txtVerifyAssembly.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "服务器类型  ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxVerifyWay
            // 
            this.cbxVerifyWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVerifyWay.FormattingEnabled = true;
            this.cbxVerifyWay.Location = new System.Drawing.Point(111, 226);
            this.cbxVerifyWay.Name = "cbxVerifyWay";
            this.cbxVerifyWay.Size = new System.Drawing.Size(178, 20);
            this.cbxVerifyWay.TabIndex = 9;
            this.cbxVerifyWay.SelectedIndexChanged += new System.EventHandler(this.cbxVerifyWay_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "服务器IP  ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAssembly
            // 
            this.txtAssembly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(217)))));
            this.txtAssembly.Location = new System.Drawing.Point(111, 64);
            this.txtAssembly.Name = "txtAssembly";
            this.txtAssembly.ReadOnly = true;
            this.txtAssembly.Size = new System.Drawing.Size(218, 21);
            this.txtAssembly.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "服务器端口  ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textAlias
            // 
            this.textAlias.Location = new System.Drawing.Point(111, 10);
            this.textAlias.Name = "textAlias";
            this.textAlias.Size = new System.Drawing.Size(218, 21);
            this.textAlias.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "服务器实例  ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxServerType
            // 
            this.cbxServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerType.FormattingEnabled = true;
            this.cbxServerType.Location = new System.Drawing.Point(111, 38);
            this.cbxServerType.Name = "cbxServerType";
            this.cbxServerType.Size = new System.Drawing.Size(218, 20);
            this.cbxServerType.TabIndex = 2;
            this.cbxServerType.SelectedIndexChanged += new System.EventHandler(this.cbxServerType_SelectedIndexChanged);
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Location = new System.Drawing.Point(111, 199);
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.PasswordChar = '*';
            this.txtUserPwd.Size = new System.Drawing.Size(218, 21);
            this.txtUserPwd.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "授权账号  ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserAccount
            // 
            this.txtUserAccount.Location = new System.Drawing.Point(111, 172);
            this.txtUserAccount.Name = "txtUserAccount";
            this.txtUserAccount.Size = new System.Drawing.Size(218, 21);
            this.txtUserAccount.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(9, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "授权密码  ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(9, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "服务驱动文件  ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInstance
            // 
            this.txtInstance.Location = new System.Drawing.Point(111, 145);
            this.txtInstance.Name = "txtInstance";
            this.txtInstance.Size = new System.Drawing.Size(218, 21);
            this.txtInstance.TabIndex = 6;
            this.txtInstance.Text = "orcl";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(111, 118);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(218, 21);
            this.txtPort.TabIndex = 5;
            this.txtPort.Text = "1521";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(5, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 15;
            this.label9.Text = "统一认证方式  ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(111, 91);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(218, 21);
            this.txtIp.TabIndex = 4;
            this.txtIp.Text = "192.168.0.1";
            // 
            // butVerify
            // 
            this.butVerify.Location = new System.Drawing.Point(254, 294);
            this.butVerify.Name = "butVerify";
            this.butVerify.Size = new System.Drawing.Size(75, 36);
            this.butVerify.TabIndex = 15;
            this.butVerify.Text = "验证";
            this.butVerify.UseVisualStyleBackColor = true;
            this.butVerify.Click += new System.EventHandler(this.butVerify_Click);
            // 
            // butModify
            // 
            this.butModify.Location = new System.Drawing.Point(173, 294);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(75, 36);
            this.butModify.TabIndex = 14;
            this.butModify.Text = "修改";
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(92, 294);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(75, 36);
            this.butDel.TabIndex = 13;
            this.butDel.Text = "删除";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(11, 294);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(75, 36);
            this.butNew.TabIndex = 12;
            this.butNew.Text = "添加";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "DLL文件|*.dll|所有文件|*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 575);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据链接配置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button butVerify;
        private System.Windows.Forms.Button butModify;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxVerifyWay;
        private System.Windows.Forms.TextBox txtAssembly;
        private System.Windows.Forms.TextBox textAlias;
        private System.Windows.Forms.ComboBox cbxServerType;
        private System.Windows.Forms.TextBox txtUserPwd;
        private System.Windows.Forms.TextBox txtUserAccount;
        private System.Windows.Forms.TextBox txtInstance;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtVerifyAssembly;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button butVerfiyCfg;
    }
}

