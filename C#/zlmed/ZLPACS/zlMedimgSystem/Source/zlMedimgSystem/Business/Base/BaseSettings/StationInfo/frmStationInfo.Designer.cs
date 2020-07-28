namespace zlMedimgSystem.BaseSettings
{
    partial class frmStationInfo
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
            this.txtComputerName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxStorage = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxDevice = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxRoom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxHspCode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butApply = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtComputerName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbxStorage);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbxDevice);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbxRoom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbxDepartment);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbxHspCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.butApply);
            this.panel1.Location = new System.Drawing.Point(214, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 239);
            this.panel1.TabIndex = 7;
            // 
            // txtComputerName
            // 
            this.txtComputerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtComputerName.Location = new System.Drawing.Point(107, 23);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.ReadOnly = true;
            this.txtComputerName.Size = new System.Drawing.Size(249, 21);
            this.txtComputerName.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "当前计算机名";
            // 
            // cbxStorage
            // 
            this.cbxStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStorage.FormattingEnabled = true;
            this.cbxStorage.Location = new System.Drawing.Point(107, 154);
            this.cbxStorage.Name = "cbxStorage";
            this.cbxStorage.Size = new System.Drawing.Size(249, 20);
            this.cbxStorage.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "当前存储设备";
            // 
            // cbxDevice
            // 
            this.cbxDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDevice.FormattingEnabled = true;
            this.cbxDevice.Location = new System.Drawing.Point(107, 128);
            this.cbxDevice.Name = "cbxDevice";
            this.cbxDevice.Size = new System.Drawing.Size(249, 20);
            this.cbxDevice.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "当前检查设备";
            // 
            // cbxRoom
            // 
            this.cbxRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRoom.FormattingEnabled = true;
            this.cbxRoom.Location = new System.Drawing.Point(107, 102);
            this.cbxRoom.Name = "cbxRoom";
            this.cbxRoom.Size = new System.Drawing.Size(249, 20);
            this.cbxRoom.TabIndex = 12;
            this.cbxRoom.SelectedIndexChanged += new System.EventHandler(this.cbxRoom_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "站点所属房间";
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Location = new System.Drawing.Point(107, 76);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(249, 20);
            this.cbxDepartment.TabIndex = 10;
            this.cbxDepartment.SelectedIndexChanged += new System.EventHandler(this.cbxDepartment_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "站点所属科室";
            // 
            // cbxHspCode
            // 
            this.cbxHspCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHspCode.FormattingEnabled = true;
            this.cbxHspCode.Location = new System.Drawing.Point(107, 50);
            this.cbxHspCode.Name = "cbxHspCode";
            this.cbxHspCode.Size = new System.Drawing.Size(249, 20);
            this.cbxHspCode.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "当前院区编码";
            // 
            // butApply
            // 
            this.butApply.Location = new System.Drawing.Point(281, 194);
            this.butApply.Name = "butApply";
            this.butApply.Size = new System.Drawing.Size(75, 23);
            this.butApply.TabIndex = 6;
            this.butApply.Text = "应用(&A)";
            this.butApply.UseVisualStyleBackColor = true;
            this.butApply.Click += new System.EventHandler(this.butApply_Click);
            // 
            // frmStationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 602);
            this.Controls.Add(this.panel1);
            this.Name = "frmStationInfo";
            this.Text = "站点信息设置";
            this.Load += new System.EventHandler(this.frmStationInfo_Load);
            this.Resize += new System.EventHandler(this.frmStationInfo_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butApply;
        private System.Windows.Forms.ComboBox cbxHspCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxDevice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxRoom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxStorage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtComputerName;
        private System.Windows.Forms.Label label6;
    }
}