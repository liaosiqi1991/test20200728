namespace zlMedimgSystem.BaseSettings
{
    partial class frmUserManager
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.butImport = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cbxLevel = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.butClearSignPic = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.picSignImage = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbAccountDescription = new System.Windows.Forms.RichTextBox();
            this.chkStopUse = new System.Windows.Forms.CheckBox();
            this.butLoadSignPic = new System.Windows.Forms.Button();
            this.cbxRoleGroup = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSurePwd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.butClearUserPhoto = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.rtbUserDescription = new System.Windows.Forms.RichTextBox();
            this.butLoadPhoto = new System.Windows.Forms.Button();
            this.picUserPhoto = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtOfficePhone = new System.Windows.Forms.TextBox();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.cbxSex = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTelePhone = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.butModify = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignImage)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.butImport);
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.butModify);
            this.panel2.Controls.Add(this.butDel);
            this.panel2.Controls.Add(this.butNew);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(420, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 630);
            this.panel2.TabIndex = 4;
            // 
            // butImport
            // 
            this.butImport.Location = new System.Drawing.Point(4, 477);
            this.butImport.Name = "butImport";
            this.butImport.Size = new System.Drawing.Size(80, 36);
            this.butImport.TabIndex = 31;
            this.butImport.Text = "导入用户(&I)";
            this.butImport.UseVisualStyleBackColor = true;
            this.butImport.Click += new System.EventHandler(this.butImport_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 101);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(376, 370);
            this.tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.cbxLevel);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.butClearSignPic);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.picSignImage);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.rtbAccountDescription);
            this.tabPage1.Controls.Add(this.chkStopUse);
            this.tabPage1.Controls.Add(this.butLoadSignPic);
            this.tabPage1.Controls.Add(this.cbxRoleGroup);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtSurePwd);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtPwd);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtUserName);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtAccountName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(368, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "账号信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(149, 113);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(11, 12);
            this.label23.TabIndex = 62;
            this.label23.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(149, 87);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 12);
            this.label22.TabIndex = 61;
            this.label22.Text = "*";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(149, 61);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(11, 12);
            this.label21.TabIndex = 60;
            this.label21.Text = "*";
            // 
            // cbxLevel
            // 
            this.cbxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLevel.FormattingEnabled = true;
            this.cbxLevel.Items.AddRange(new object[] {
            "实习医师",
            "住院医师",
            "主治医师",
            "副主任医师",
            "主任医师"});
            this.cbxLevel.Location = new System.Drawing.Point(213, 110);
            this.cbxLevel.Name = "cbxLevel";
            this.cbxLevel.Size = new System.Drawing.Size(149, 20);
            this.cbxLevel.TabIndex = 59;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(157, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 58;
            this.label8.Text = "职称级别";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butClearSignPic
            // 
            this.butClearSignPic.Location = new System.Drawing.Point(104, 139);
            this.butClearSignPic.Name = "butClearSignPic";
            this.butClearSignPic.Size = new System.Drawing.Size(44, 23);
            this.butClearSignPic.TabIndex = 57;
            this.butClearSignPic.Text = "清除";
            this.butClearSignPic.UseVisualStyleBackColor = true;
            this.butClearSignPic.Click += new System.EventHandler(this.butClearSignPic_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(149, 36);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(11, 12);
            this.label20.TabIndex = 32;
            this.label20.Text = "*";
            // 
            // picSignImage
            // 
            this.picSignImage.BackColor = System.Drawing.Color.White;
            this.picSignImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSignImage.Location = new System.Drawing.Point(6, 6);
            this.picSignImage.Name = "picSignImage";
            this.picSignImage.Size = new System.Drawing.Size(142, 128);
            this.picSignImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignImage.TabIndex = 54;
            this.picSignImage.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 39;
            this.label5.Text = "备注描述";
            // 
            // rtbAccountDescription
            // 
            this.rtbAccountDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbAccountDescription.Location = new System.Drawing.Point(65, 168);
            this.rtbAccountDescription.Name = "rtbAccountDescription";
            this.rtbAccountDescription.Size = new System.Drawing.Size(297, 117);
            this.rtbAccountDescription.TabIndex = 38;
            this.rtbAccountDescription.Text = "";
            // 
            // chkStopUse
            // 
            this.chkStopUse.AutoSize = true;
            this.chkStopUse.Location = new System.Drawing.Point(289, 291);
            this.chkStopUse.Name = "chkStopUse";
            this.chkStopUse.Size = new System.Drawing.Size(72, 16);
            this.chkStopUse.TabIndex = 37;
            this.chkStopUse.Text = "是否停用";
            this.chkStopUse.UseVisualStyleBackColor = true;
            // 
            // butLoadSignPic
            // 
            this.butLoadSignPic.Location = new System.Drawing.Point(6, 139);
            this.butLoadSignPic.Name = "butLoadSignPic";
            this.butLoadSignPic.Size = new System.Drawing.Size(92, 23);
            this.butLoadSignPic.TabIndex = 36;
            this.butLoadSignPic.Text = "载入签名图(&S)";
            this.butLoadSignPic.UseVisualStyleBackColor = true;
            this.butLoadSignPic.Click += new System.EventHandler(this.butLoadSignPic_Click);
            // 
            // cbxRoleGroup
            // 
            this.cbxRoleGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRoleGroup.FormattingEnabled = true;
            this.cbxRoleGroup.Location = new System.Drawing.Point(213, 135);
            this.cbxRoleGroup.Name = "cbxRoleGroup";
            this.cbxRoleGroup.Size = new System.Drawing.Size(149, 20);
            this.cbxRoleGroup.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(157, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 32;
            this.label11.Text = "所属角色";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(157, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "确认密码";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSurePwd
            // 
            this.txtSurePwd.Location = new System.Drawing.Point(213, 84);
            this.txtSurePwd.Name = "txtSurePwd";
            this.txtSurePwd.PasswordChar = '*';
            this.txtSurePwd.Size = new System.Drawing.Size(149, 21);
            this.txtSurePwd.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(157, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "登录密码";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(213, 58);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(149, 21);
            this.txtPwd.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(157, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "用户名称";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(213, 32);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(149, 21);
            this.txtUserName.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "系统账号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(213, 6);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(149, 21);
            this.txtAccountName.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(149, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "*";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.butClearUserPhoto);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.rtbUserDescription);
            this.tabPage2.Controls.Add(this.butLoadPhoto);
            this.tabPage2.Controls.Add(this.picUserPhoto);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.txtCardNo);
            this.tabPage2.Controls.Add(this.txtEmail);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.txtOfficePhone);
            this.tabPage2.Controls.Add(this.dtpBirth);
            this.tabPage2.Controls.Add(this.cbxSex);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.txtAddress);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.txtTelePhone);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.txtName);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(368, 344);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "人员信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // butClearUserPhoto
            // 
            this.butClearUserPhoto.Location = new System.Drawing.Point(104, 140);
            this.butClearUserPhoto.Name = "butClearUserPhoto";
            this.butClearUserPhoto.Size = new System.Drawing.Size(44, 23);
            this.butClearUserPhoto.TabIndex = 56;
            this.butClearUserPhoto.Text = "清除";
            this.butClearUserPhoto.UseVisualStyleBackColor = true;
            this.butClearUserPhoto.Click += new System.EventHandler(this.butClearUserPhoto_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 221);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 56;
            this.label19.Text = "备注描述";
            // 
            // rtbUserDescription
            // 
            this.rtbUserDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbUserDescription.Location = new System.Drawing.Point(65, 221);
            this.rtbUserDescription.Name = "rtbUserDescription";
            this.rtbUserDescription.Size = new System.Drawing.Size(297, 117);
            this.rtbUserDescription.TabIndex = 55;
            this.rtbUserDescription.Text = "";
            // 
            // butLoadPhoto
            // 
            this.butLoadPhoto.Location = new System.Drawing.Point(6, 140);
            this.butLoadPhoto.Name = "butLoadPhoto";
            this.butLoadPhoto.Size = new System.Drawing.Size(92, 23);
            this.butLoadPhoto.TabIndex = 54;
            this.butLoadPhoto.Text = "载入人员照片(&P)";
            this.butLoadPhoto.UseVisualStyleBackColor = true;
            this.butLoadPhoto.Click += new System.EventHandler(this.butLoadPhoto_Click);
            // 
            // picUserPhoto
            // 
            this.picUserPhoto.BackColor = System.Drawing.Color.White;
            this.picUserPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picUserPhoto.Location = new System.Drawing.Point(6, 6);
            this.picUserPhoto.Name = "picUserPhoto";
            this.picUserPhoto.Size = new System.Drawing.Size(142, 128);
            this.picUserPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUserPhoto.TabIndex = 53;
            this.picUserPhoto.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(154, 89);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 51;
            this.label18.Text = "身份证号";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(213, 86);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(149, 21);
            this.txtCardNo.TabIndex = 52;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(65, 194);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(297, 21);
            this.txtEmail.TabIndex = 50;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 198);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 49;
            this.label17.Text = "电子邮件";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOfficePhone
            // 
            this.txtOfficePhone.Location = new System.Drawing.Point(213, 113);
            this.txtOfficePhone.Name = "txtOfficePhone";
            this.txtOfficePhone.Size = new System.Drawing.Size(149, 21);
            this.txtOfficePhone.TabIndex = 48;
            // 
            // dtpBirth
            // 
            this.dtpBirth.Location = new System.Drawing.Point(213, 59);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(149, 21);
            this.dtpBirth.TabIndex = 47;
            // 
            // cbxSex
            // 
            this.cbxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSex.FormattingEnabled = true;
            this.cbxSex.Items.AddRange(new object[] {
            "男",
            "女",
            "未明",
            "未知",
            "女变男",
            "男变女"});
            this.cbxSex.Location = new System.Drawing.Point(213, 33);
            this.cbxSex.Name = "cbxSex";
            this.cbxSex.Size = new System.Drawing.Size(149, 20);
            this.cbxSex.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 44;
            this.label4.Text = "办公电话";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 42;
            this.label12.Text = "联系地址";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(65, 167);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(297, 21);
            this.txtAddress.TabIndex = 43;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(154, 143);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 40;
            this.label13.Text = "手机电话";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTelePhone
            // 
            this.txtTelePhone.Location = new System.Drawing.Point(213, 140);
            this.txtTelePhone.Name = "txtTelePhone";
            this.txtTelePhone.Size = new System.Drawing.Size(149, 21);
            this.txtTelePhone.TabIndex = 41;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(154, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 38;
            this.label14.Text = "出生日期";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(154, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 36;
            this.label15.Text = "人员性别";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(154, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 34;
            this.label16.Text = "人员姓名";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(213, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(149, 21);
            this.txtName.TabIndex = 35;
            // 
            // butModify
            // 
            this.butModify.Location = new System.Drawing.Point(301, 477);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(75, 36);
            this.butModify.TabIndex = 29;
            this.butModify.Text = "保存(&M)";
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(220, 477);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(75, 36);
            this.butDel.TabIndex = 28;
            this.butDel.Text = "删除(&D)";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(139, 477);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(75, 36);
            this.butNew.TabIndex = 27;
            this.butNew.Text = "添加(&N)";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3);
            this.label3.Size = new System.Drawing.Size(380, 98);
            this.label3.TabIndex = 19;
            this.label3.Text = "用户管理：\r\n\r\n设置科室人员的人员信息，登录产品的账户信息。\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 23);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(420, 607);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxDepartment);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.panel1.Size = new System.Drawing.Size(420, 23);
            this.panel1.TabIndex = 6;
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Location = new System.Drawing.Point(71, 0);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(346, 20);
            this.cbxDepartment.TabIndex = 1;
            this.cbxDepartment.SelectedIndexChanged += new System.EventHandler(this.cbxDepartment_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "*.*|*.*";
            // 
            // frmUserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 630);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmUserManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.frmUserManager_Load);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignImage)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butModify;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSurePwd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbAccountDescription;
        private System.Windows.Forms.CheckBox chkStopUse;
        private System.Windows.Forms.Button butLoadSignPic;
        private System.Windows.Forms.ComboBox cbxRoleGroup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtOfficePhone;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.ComboBox cbxSex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTelePhone;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button butLoadPhoto;
        private System.Windows.Forms.PictureBox picUserPhoto;
        private System.Windows.Forms.PictureBox picSignImage;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RichTextBox rtbUserDescription;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button butClearUserPhoto;
        private System.Windows.Forms.Button butClearSignPic;
        private System.Windows.Forms.ComboBox cbxLevel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
    }
}