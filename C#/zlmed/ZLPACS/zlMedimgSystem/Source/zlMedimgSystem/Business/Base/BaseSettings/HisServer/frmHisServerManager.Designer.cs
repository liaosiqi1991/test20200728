namespace zlMedimgSystem.BaseSettings
{
    partial class frmHisServerManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAssemblyFile = new System.Windows.Forms.TextBox();
            this.textAlias = new System.Windows.Forms.TextBox();
            this.cbxInterfaceName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.butModify = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkStopUse = new System.Windows.Forms.CheckBox();
            this.butVerfiyCfg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(41, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "HIS服务名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(41, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "HIS接口名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAssemblyFile
            // 
            this.txtAssemblyFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(217)))));
            this.txtAssemblyFile.Location = new System.Drawing.Point(126, 169);
            this.txtAssemblyFile.Name = "txtAssemblyFile";
            this.txtAssemblyFile.ReadOnly = true;
            this.txtAssemblyFile.Size = new System.Drawing.Size(234, 21);
            this.txtAssemblyFile.TabIndex = 3;
            // 
            // textAlias
            // 
            this.textAlias.Location = new System.Drawing.Point(126, 115);
            this.textAlias.Name = "textAlias";
            this.textAlias.Size = new System.Drawing.Size(234, 21);
            this.textAlias.TabIndex = 1;
            // 
            // cbxInterfaceName
            // 
            this.cbxInterfaceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInterfaceName.FormattingEnabled = true;
            this.cbxInterfaceName.Location = new System.Drawing.Point(126, 143);
            this.cbxInterfaceName.Name = "cbxInterfaceName";
            this.cbxInterfaceName.Size = new System.Drawing.Size(199, 20);
            this.cbxInterfaceName.TabIndex = 2;
            this.cbxInterfaceName.SelectedIndexChanged += new System.EventHandler(this.cbxInterfaceName_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "HIS接口文件";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butModify
            // 
            this.butModify.Location = new System.Drawing.Point(287, 233);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(75, 36);
            this.butModify.TabIndex = 14;
            this.butModify.Text = "保存";
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(206, 233);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(75, 36);
            this.butDel.TabIndex = 13;
            this.butDel.Text = "删除";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(125, 233);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(75, 36);
            this.butNew.TabIndex = 12;
            this.butNew.Text = "添加";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
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
            this.dataGridView1.Size = new System.Drawing.Size(527, 553);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkStopUse);
            this.panel1.Controls.Add(this.butVerfiyCfg);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtAssemblyFile);
            this.panel1.Controls.Add(this.textAlias);
            this.panel1.Controls.Add(this.cbxInterfaceName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.butModify);
            this.panel1.Controls.Add(this.butDel);
            this.panel1.Controls.Add(this.butNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(527, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 553);
            this.panel1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(41, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(41, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "*";
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
            this.label3.TabIndex = 18;
            this.label3.Text = "HIS服务接口管理：\r\n\r\n配置系统与三方HIS服务的接口方式，当配置了多个接口方式时，则获取检查申请时，将会从多个HIS服务接口中进行查询。";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkStopUse
            // 
            this.chkStopUse.AutoSize = true;
            this.chkStopUse.Location = new System.Drawing.Point(126, 196);
            this.chkStopUse.Name = "chkStopUse";
            this.chkStopUse.Size = new System.Drawing.Size(72, 16);
            this.chkStopUse.TabIndex = 17;
            this.chkStopUse.Text = "是否停用";
            this.chkStopUse.UseVisualStyleBackColor = true;
            // 
            // butVerfiyCfg
            // 
            this.butVerfiyCfg.Location = new System.Drawing.Point(326, 143);
            this.butVerfiyCfg.Name = "butVerfiyCfg";
            this.butVerfiyCfg.Size = new System.Drawing.Size(34, 20);
            this.butVerfiyCfg.TabIndex = 16;
            this.butVerfiyCfg.Text = "…";
            this.butVerfiyCfg.UseVisualStyleBackColor = true;
            this.butVerfiyCfg.Click += new System.EventHandler(this.butVerfiyCfg_Click);
            // 
            // frmHisServerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 553);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "frmHisServerManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HIS服务接口管理";
            this.Load += new System.EventHandler(this.HisServerManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAssemblyFile;
        private System.Windows.Forms.TextBox textAlias;
        private System.Windows.Forms.ComboBox cbxInterfaceName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button butModify;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butVerfiyCfg;
        private System.Windows.Forms.CheckBox chkStopUse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
    }
}