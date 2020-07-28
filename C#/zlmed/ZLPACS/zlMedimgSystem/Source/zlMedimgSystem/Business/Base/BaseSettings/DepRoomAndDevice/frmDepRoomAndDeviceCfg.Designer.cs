namespace zlMedimgSystem.BaseSettings
{
    partial class frmDepRoomAndDeviceCfg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepRoomAndDeviceCfg));
            this.dgvDept = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLeader = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDevice = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDeviceAdd = new System.Windows.Forms.Button();
            this.btnDeviceRemove = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDept)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDept
            // 
            this.dgvDept.AllowUserToAddRows = false;
            this.dgvDept.AllowUserToDeleteRows = false;
            this.dgvDept.BackgroundColor = System.Drawing.Color.White;
            this.dgvDept.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDept.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDept.Location = new System.Drawing.Point(0, 0);
            this.dgvDept.MultiSelect = false;
            this.dgvDept.Name = "dgvDept";
            this.dgvDept.ReadOnly = true;
            this.dgvDept.RowTemplate.Height = 23;
            this.dgvDept.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDept.Size = new System.Drawing.Size(607, 240);
            this.dgvDept.TabIndex = 2;
            this.dgvDept.SelectionChanged += new System.EventHandler(this.dgvDept_SelectionChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "科室名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboDept
            // 
            this.cboDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(71, 0);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(536, 20);
            this.cboDept.TabIndex = 1;
            this.cboDept.SelectedIndexChanged += new System.EventHandler(this.cboDept_SelectedIndexChanged);
            this.cboDept.Click += new System.EventHandler(this.cboDept_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtLeader);
            this.panel1.Controls.Add(this.txtPosition);
            this.panel1.Controls.Add(this.txtTag);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtRoomName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(607, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 521);
            this.panel1.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(3, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 31;
            this.label8.Text = "*";
            // 
            // txtLeader
            // 
            this.txtLeader.Location = new System.Drawing.Point(74, 200);
            this.txtLeader.Name = "txtLeader";
            this.txtLeader.Size = new System.Drawing.Size(294, 21);
            this.txtLeader.TabIndex = 10;
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(74, 170);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(294, 21);
            this.txtPosition.TabIndex = 9;
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(74, 140);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(294, 21);
            this.txtTag.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "负责人";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "位置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "备注描述";
            // 
            // txtRoomName
            // 
            this.txtRoomName.Location = new System.Drawing.Point(74, 110);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(294, 21);
            this.txtRoomName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "房间名称";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 98);
            this.label2.TabIndex = 6;
            this.label2.Text = "\r\n科室设备设置：\r\n\r\n\r\n设置各科室包含的房间，设置各检查房间包含的检查设备。\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(293, 227);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 36);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "保存";
            this.toolTip1.SetToolTip(this.btnUpdate, "保存修改内容");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(184, 227);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 36);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "删除";
            this.toolTip1.SetToolTip(this.btnRemove, "删除房间");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(74, 227);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 36);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "添加";
            this.toolTip1.SetToolTip(this.btnAdd, "添加房间");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(547, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 24);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "应用";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboDept);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(607, 23);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvDevice);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.dgvDept);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(607, 498);
            this.panel3.TabIndex = 12;
            // 
            // dgvDevice
            // 
            this.dgvDevice.AllowUserToAddRows = false;
            this.dgvDevice.AllowUserToDeleteRows = false;
            this.dgvDevice.BackgroundColor = System.Drawing.Color.White;
            this.dgvDevice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDevice.Location = new System.Drawing.Point(0, 270);
            this.dgvDevice.MultiSelect = false;
            this.dgvDevice.Name = "dgvDevice";
            this.dgvDevice.RowTemplate.Height = 23;
            this.dgvDevice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDevice.Size = new System.Drawing.Size(607, 228);
            this.dgvDevice.TabIndex = 6;
            this.dgvDevice.ColumnHeadersHeightChanged += new System.EventHandler(this.dgvDevice_ColumnHeadersHeightChanged);
            this.dgvDevice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDevice_CellClick);
            this.dgvDevice.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDevice_CellValueChanged);
            this.dgvDevice.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvDevice_ColumnWidthChanged);
            this.dgvDevice.CurrentCellChanged += new System.EventHandler(this.dgvDevice_CurrentCellChanged);
            this.dgvDevice.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvDevice_RowPrePaint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Controls.Add(this.btnDeviceAdd);
            this.panel4.Controls.Add(this.btnDeviceRemove);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 240);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(607, 30);
            this.panel4.TabIndex = 15;
            // 
            // btnDeviceAdd
            // 
            this.btnDeviceAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeviceAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnDeviceAdd.Image")));
            this.btnDeviceAdd.Location = new System.Drawing.Point(491, 3);
            this.btnDeviceAdd.Name = "btnDeviceAdd";
            this.btnDeviceAdd.Size = new System.Drawing.Size(24, 24);
            this.btnDeviceAdd.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnDeviceAdd, "添加设备");
            this.btnDeviceAdd.UseVisualStyleBackColor = true;
            this.btnDeviceAdd.Click += new System.EventHandler(this.btnDeviceAdd_Click);
            // 
            // btnDeviceRemove
            // 
            this.btnDeviceRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeviceRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnDeviceRemove.Image")));
            this.btnDeviceRemove.Location = new System.Drawing.Point(517, 3);
            this.btnDeviceRemove.Name = "btnDeviceRemove";
            this.btnDeviceRemove.Size = new System.Drawing.Size(24, 24);
            this.btnDeviceRemove.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnDeviceRemove, "删除设备");
            this.btnDeviceRemove.UseVisualStyleBackColor = true;
            this.btnDeviceRemove.Click += new System.EventHandler(this.btnDeviceRemove_Click);
            // 
            // frmDepRoomAndDeviceCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 521);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmDepRoomAndDeviceCfg";
            this.Text = "科室房间设备设置";
            this.Load += new System.EventHandler(this.frmDepRoomAndDeviceCfg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDept)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDeviceAdd;
        private System.Windows.Forms.Button btnDeviceRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLeader;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvDevice;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label8;
    }
}