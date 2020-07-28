namespace zlMedimgSystem.BaseSettings
{
    partial class frmRoleManager
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
            this.label6 = new System.Windows.Forms.Label();
            this.butModify = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.chkStopUse = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbRoleDescription = new System.Windows.Forms.RichTextBox();
            this.cbxRoleGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.butModify);
            this.panel2.Controls.Add(this.butDel);
            this.panel2.Controls.Add(this.butNew);
            this.panel2.Controls.Add(this.chkStopUse);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.rtbRoleDescription);
            this.panel2.Controls.Add(this.cbxRoleGroup);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtRoleName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(491, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 540);
            this.panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(6, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "*";
            // 
            // butModify
            // 
            this.butModify.Location = new System.Drawing.Point(293, 336);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(75, 36);
            this.butModify.TabIndex = 29;
            this.butModify.Text = "保存";
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(188, 336);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(75, 36);
            this.butDel.TabIndex = 28;
            this.butDel.Text = "删除";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(75, 336);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(75, 36);
            this.butNew.TabIndex = 27;
            this.butNew.Text = "添加";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // chkStopUse
            // 
            this.chkStopUse.AutoSize = true;
            this.chkStopUse.Location = new System.Drawing.Point(75, 304);
            this.chkStopUse.Name = "chkStopUse";
            this.chkStopUse.Size = new System.Drawing.Size(72, 16);
            this.chkStopUse.TabIndex = 26;
            this.chkStopUse.Text = "是否停用";
            this.chkStopUse.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "角色描述";
            // 
            // rtbRoleDescription
            // 
            this.rtbRoleDescription.Location = new System.Drawing.Point(75, 169);
            this.rtbRoleDescription.Name = "rtbRoleDescription";
            this.rtbRoleDescription.Size = new System.Drawing.Size(293, 129);
            this.rtbRoleDescription.TabIndex = 24;
            this.rtbRoleDescription.Text = "";
            // 
            // cbxRoleGroup
            // 
            this.cbxRoleGroup.FormattingEnabled = true;
            this.cbxRoleGroup.Location = new System.Drawing.Point(75, 143);
            this.cbxRoleGroup.Name = "cbxRoleGroup";
            this.cbxRoleGroup.Size = new System.Drawing.Size(293, 20);
            this.cbxRoleGroup.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "分组标记";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(16, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "角色名称";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(75, 116);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(293, 21);
            this.txtRoleName.TabIndex = 21;
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
            this.label3.Text = "角色管理：\r\n\r\n针对科室内人员角色进行对应设置，改配置信息将用于后续的人员界面等设置。";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxDepartment);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 23);
            this.panel1.TabIndex = 3;
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Location = new System.Drawing.Point(71, 0);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(420, 20);
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
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 23);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(491, 517);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // frmRoleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 540);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmRoleManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色管理";
            this.Load += new System.EventHandler(this.frmRoleManager_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxRoleGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbRoleDescription;
        private System.Windows.Forms.CheckBox chkStopUse;
        private System.Windows.Forms.Button butModify;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listView1;
    }
}