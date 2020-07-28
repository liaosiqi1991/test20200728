namespace zlMedimgSystem.BaseSettings
{
    partial class frmStorageManager
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
            this.dgvStorage = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.butModify = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStorageName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCatalogue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labStorageExplain = new System.Windows.Forms.Label();
            this.chkStopUse = new System.Windows.Forms.CheckBox();
            this.cbxMirrorImage = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStorage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvStorage
            // 
            this.dgvStorage.AllowUserToAddRows = false;
            this.dgvStorage.AllowUserToDeleteRows = false;
            this.dgvStorage.BackgroundColor = System.Drawing.Color.White;
            this.dgvStorage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStorage.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvStorage.Location = new System.Drawing.Point(0, 0);
            this.dgvStorage.MultiSelect = false;
            this.dgvStorage.Name = "dgvStorage";
            this.dgvStorage.RowTemplate.Height = 23;
            this.dgvStorage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStorage.Size = new System.Drawing.Size(420, 450);
            this.dgvStorage.TabIndex = 4;
            this.dgvStorage.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvStorage_RowPostPaint);
            this.dgvStorage.SelectionChanged += new System.EventHandler(this.dgvStorage_SelectionChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(41, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备类型";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butModify
            // 
            this.butModify.Location = new System.Drawing.Point(288, 346);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(75, 36);
            this.butModify.TabIndex = 12;
            this.butModify.Text = "保存";
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(207, 346);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(75, 36);
            this.butDel.TabIndex = 11;
            this.butDel.Text = "删除";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(126, 346);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(75, 36);
            this.butNew.TabIndex = 10;
            this.butNew.Text = "添加";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxMirrorImage);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Controls.Add(this.cbxType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtStorageName);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtCatalogue);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtIp);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.labStorageExplain);
            this.panel1.Controls.Add(this.chkStopUse);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.butModify);
            this.panel1.Controls.Add(this.butDel);
            this.panel1.Controls.Add(this.butNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(420, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 450);
            this.panel1.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(52, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 54;
            this.label7.Text = "*";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(44, 346);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 36);
            this.btnTest.TabIndex = 53;
            this.btnTest.Text = "连接测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "FTP"});
            this.cbxType.Location = new System.Drawing.Point(126, 116);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(234, 20);
            this.cbxType.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(53, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 51;
            this.label4.Text = "*";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(41, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 23);
            this.label2.TabIndex = 49;
            this.label2.Text = "存储名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStorageName
            // 
            this.txtStorageName.Location = new System.Drawing.Point(126, 88);
            this.txtStorageName.Name = "txtStorageName";
            this.txtStorageName.Size = new System.Drawing.Size(234, 21);
            this.txtStorageName.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(41, 253);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 23);
            this.label12.TabIndex = 44;
            this.label12.Text = "密码";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(126, 255);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(234, 21);
            this.txtPassword.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(41, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 23);
            this.label10.TabIndex = 41;
            this.label10.Text = "用户名";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(126, 227);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(234, 21);
            this.txtUserName.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(41, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 23);
            this.label8.TabIndex = 38;
            this.label8.Text = "分类目录";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCatalogue
            // 
            this.txtCatalogue.Location = new System.Drawing.Point(126, 199);
            this.txtCatalogue.Name = "txtCatalogue";
            this.txtCatalogue.Size = new System.Drawing.Size(234, 21);
            this.txtCatalogue.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(41, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 23);
            this.label5.TabIndex = 35;
            this.label5.Text = "端口";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(126, 171);
            this.txtPort.MaxLength = 6;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(234, 21);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "21";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(41, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 23);
            this.label3.TabIndex = 32;
            this.label3.Text = "IP地址";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(126, 143);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(234, 21);
            this.txtIp.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(53, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "*";
            // 
            // labStorageExplain
            // 
            this.labStorageExplain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labStorageExplain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labStorageExplain.Dock = System.Windows.Forms.DockStyle.Top;
            this.labStorageExplain.Location = new System.Drawing.Point(0, 0);
            this.labStorageExplain.Name = "labStorageExplain";
            this.labStorageExplain.Padding = new System.Windows.Forms.Padding(3);
            this.labStorageExplain.Size = new System.Drawing.Size(380, 71);
            this.labStorageExplain.TabIndex = 18;
            this.labStorageExplain.Text = "存储设备管理：\r\n\r\n配置存储图像，文件的目录路径。";
            this.labStorageExplain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkStopUse
            // 
            this.chkStopUse.AutoSize = true;
            this.chkStopUse.Location = new System.Drawing.Point(127, 318);
            this.chkStopUse.Name = "chkStopUse";
            this.chkStopUse.Size = new System.Drawing.Size(72, 16);
            this.chkStopUse.TabIndex = 9;
            this.chkStopUse.Text = "是否停用";
            this.chkStopUse.UseVisualStyleBackColor = true;
            // 
            // cbxMirrorImage
            // 
            this.cbxMirrorImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMirrorImage.FormattingEnabled = true;
            this.cbxMirrorImage.Items.AddRange(new object[] {
            "FTP"});
            this.cbxMirrorImage.Location = new System.Drawing.Point(126, 282);
            this.cbxMirrorImage.Name = "cbxMirrorImage";
            this.cbxMirrorImage.Size = new System.Drawing.Size(234, 20);
            this.cbxMirrorImage.TabIndex = 56;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(41, 280);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 23);
            this.label9.TabIndex = 55;
            this.label9.Text = "镜像存储";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmStorageManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvStorage);
            this.Controls.Add(this.panel1);
            this.Name = "frmStorageManager";
            this.Text = "存储设备管理";
            this.Load += new System.EventHandler(this.frmStorageManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStorage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStorage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butModify;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labStorageExplain;
        private System.Windows.Forms.CheckBox chkStopUse;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCatalogue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStorageName;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxMirrorImage;
        private System.Windows.Forms.Label label9;
    }
}