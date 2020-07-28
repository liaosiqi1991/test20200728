namespace zlMedimgSystem.BaseSettings
{
    partial class frmThridDBConfig
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.butModify = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butVerify = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAssembly = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textAlias = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxServerType = new System.Windows.Forms.ComboBox();
            this.txtUserPwd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUserAccount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtInstance = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(420, 653);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(28, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "*";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(3);
            this.label4.Size = new System.Drawing.Size(380, 98);
            this.label4.TabIndex = 19;
            this.label4.Text = "三方数据源设置：\r\n\r\n配置系统与三方HIS服务的接口方式，当配置了多个接口方式时，获取报告检查内容时，将会从多个HIS服务接口中进行查询获取。";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "备注描述";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(80, 317);
            this.rtbDescription.MaxLength = 200;
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(282, 132);
            this.rtbDescription.TabIndex = 17;
            this.rtbDescription.Text = "";
            // 
            // butModify
            // 
            this.butModify.Location = new System.Drawing.Point(287, 469);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(75, 36);
            this.butModify.TabIndex = 14;
            this.butModify.Text = "保存";
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(206, 469);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(75, 36);
            this.butDel.TabIndex = 13;
            this.butDel.Text = "删除";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(125, 469);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(75, 36);
            this.butNew.TabIndex = 12;
            this.butNew.Text = "添加";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.butVerify);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtAssembly);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textAlias);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbxServerType);
            this.panel1.Controls.Add(this.txtUserPwd);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtUserAccount);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtInstance);
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Controls.Add(this.txtIp);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rtbDescription);
            this.panel1.Controls.Add(this.butModify);
            this.panel1.Controls.Add(this.butDel);
            this.panel1.Controls.Add(this.butNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(420, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 653);
            this.panel1.TabIndex = 9;
            // 
            // butVerify
            // 
            this.butVerify.Location = new System.Drawing.Point(11, 469);
            this.butVerify.Name = "butVerify";
            this.butVerify.Size = new System.Drawing.Size(75, 36);
            this.butVerify.TabIndex = 50;
            this.butVerify.Text = "验证";
            this.butVerify.UseVisualStyleBackColor = true;
            this.butVerify.Click += new System.EventHandler(this.butVerify_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(6, 239);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 49;
            this.label13.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(6, 185);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 48;
            this.label12.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "别名";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "服务器类型";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "服务器IP";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAssembly
            // 
            this.txtAssembly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(217)))));
            this.txtAssembly.Location = new System.Drawing.Point(80, 155);
            this.txtAssembly.Name = "txtAssembly";
            this.txtAssembly.ReadOnly = true;
            this.txtAssembly.Size = new System.Drawing.Size(282, 21);
            this.txtAssembly.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "服务端口";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textAlias
            // 
            this.textAlias.Location = new System.Drawing.Point(80, 101);
            this.textAlias.Name = "textAlias";
            this.textAlias.Size = new System.Drawing.Size(282, 21);
            this.textAlias.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 39;
            this.label8.Text = "数据实例";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxServerType
            // 
            this.cbxServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerType.FormattingEnabled = true;
            this.cbxServerType.Location = new System.Drawing.Point(80, 129);
            this.cbxServerType.Name = "cbxServerType";
            this.cbxServerType.Size = new System.Drawing.Size(282, 20);
            this.cbxServerType.TabIndex = 36;
            this.cbxServerType.SelectedIndexChanged += new System.EventHandler(this.cbxServerType_SelectedIndexChanged);
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Location = new System.Drawing.Point(80, 290);
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.PasswordChar = '*';
            this.txtUserPwd.Size = new System.Drawing.Size(282, 21);
            this.txtUserPwd.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 41;
            this.label9.Text = "授权账号";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserAccount
            // 
            this.txtUserAccount.Location = new System.Drawing.Point(80, 263);
            this.txtUserAccount.Name = "txtUserAccount";
            this.txtUserAccount.Size = new System.Drawing.Size(282, 21);
            this.txtUserAccount.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 43;
            this.label10.Text = "授权密码";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 47;
            this.label11.Text = "驱动文件";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInstance
            // 
            this.txtInstance.Location = new System.Drawing.Point(80, 236);
            this.txtInstance.Name = "txtInstance";
            this.txtInstance.Size = new System.Drawing.Size(282, 21);
            this.txtInstance.TabIndex = 44;
            this.txtInstance.Text = "orcl";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(80, 209);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(282, 21);
            this.txtPort.TabIndex = 42;
            this.txtPort.Text = "1521";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(80, 182);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(282, 21);
            this.txtIp.TabIndex = 40;
            this.txtIp.Text = "192.168.0.1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(6, 212);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 51;
            this.label14.Text = "*";
            // 
            // frmThridDBConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 653);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "frmThridDBConfig";
            this.Text = "数据源设置";
            this.Load += new System.EventHandler(this.frmThridDBConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button butModify;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAssembly;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textAlias;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxServerType;
        private System.Windows.Forms.TextBox txtUserPwd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUserAccount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtInstance;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Button butVerify;
        private System.Windows.Forms.Label label14;
    }
}