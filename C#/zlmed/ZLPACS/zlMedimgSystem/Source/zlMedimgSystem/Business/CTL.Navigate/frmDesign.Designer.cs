namespace zlMedimgSystem.CTL.Navigate
{
    partial class frmDesign
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
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.chkCbxMenu = new System.Windows.Forms.CheckBox();
            this.chkShowExit = new System.Windows.Forms.CheckBox();
            this.cbxButType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtButTag = new System.Windows.Forms.TextBox();
            this.butLoadImg = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImgName = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.butDel = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.butModify = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labBkColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.labForeColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Checked = true;
            this.chkLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLog.Location = new System.Drawing.Point(12, 12);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(48, 16);
            this.chkLog.TabIndex = 2;
            this.chkLog.Text = "图标";
            this.chkLog.UseVisualStyleBackColor = true;
            this.chkLog.CheckedChanged += new System.EventHandler(this.chkLog_CheckedChanged);
            // 
            // chkCbxMenu
            // 
            this.chkCbxMenu.AutoSize = true;
            this.chkCbxMenu.Checked = true;
            this.chkCbxMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCbxMenu.Location = new System.Drawing.Point(66, 12);
            this.chkCbxMenu.Name = "chkCbxMenu";
            this.chkCbxMenu.Size = new System.Drawing.Size(72, 16);
            this.chkCbxMenu.TabIndex = 3;
            this.chkCbxMenu.Text = "附加菜单";
            this.chkCbxMenu.UseVisualStyleBackColor = true;
            this.chkCbxMenu.CheckedChanged += new System.EventHandler(this.chkCbxMenu_CheckedChanged);
            // 
            // chkShowExit
            // 
            this.chkShowExit.AutoSize = true;
            this.chkShowExit.Checked = true;
            this.chkShowExit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowExit.Location = new System.Drawing.Point(144, 12);
            this.chkShowExit.Name = "chkShowExit";
            this.chkShowExit.Size = new System.Drawing.Size(72, 16);
            this.chkShowExit.TabIndex = 4;
            this.chkShowExit.Text = "退出按钮";
            this.chkShowExit.UseVisualStyleBackColor = true;
            this.chkShowExit.CheckedChanged += new System.EventHandler(this.chkShowExit_CheckedChanged);
            // 
            // cbxButType
            // 
            this.cbxButType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxButType.FormattingEnabled = true;
            this.cbxButType.Items.AddRange(new object[] {
            "主按钮样式",
            "辅按钮样式",
            "附加按钮样式"});
            this.cbxButType.Location = new System.Drawing.Point(65, 42);
            this.cbxButType.Name = "cbxButType";
            this.cbxButType.Size = new System.Drawing.Size(142, 20);
            this.cbxButType.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "按钮标记";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "按钮类型";
            // 
            // txtButTag
            // 
            this.txtButTag.Location = new System.Drawing.Point(281, 41);
            this.txtButTag.Name = "txtButTag";
            this.txtButTag.Size = new System.Drawing.Size(153, 21);
            this.txtButTag.TabIndex = 8;
            // 
            // butLoadImg
            // 
            this.butLoadImg.Location = new System.Drawing.Point(410, 12);
            this.butLoadImg.Name = "butLoadImg";
            this.butLoadImg.Size = new System.Drawing.Size(24, 23);
            this.butLoadImg.TabIndex = 6;
            this.butLoadImg.Text = "…";
            this.butLoadImg.UseVisualStyleBackColor = true;
            this.butLoadImg.Click += new System.EventHandler(this.butLoadImg_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "图标名称";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "按钮名称";
            // 
            // txtImgName
            // 
            this.txtImgName.Location = new System.Drawing.Point(281, 14);
            this.txtImgName.Name = "txtImgName";
            this.txtImgName.Size = new System.Drawing.Size(123, 21);
            this.txtImgName.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(65, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(142, 21);
            this.txtName.TabIndex = 2;
            // 
            // butDel
            // 
            this.butDel.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butDel.Location = new System.Drawing.Point(525, 40);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(27, 23);
            this.butDel.TabIndex = 1;
            this.butDel.Text = "─";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butAdd
            // 
            this.butAdd.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butAdd.Location = new System.Drawing.Point(492, 40);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(27, 23);
            this.butAdd.TabIndex = 0;
            this.butAdd.Text = "┼";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.butModify);
            this.groupBox1.Controls.Add(this.cbxButType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.butAdd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.butDel);
            this.groupBox1.Controls.Add(this.txtButTag);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.butLoadImg);
            this.groupBox1.Controls.Add(this.txtImgName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 348);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(8, 68);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(576, 274);
            this.listView1.TabIndex = 25;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // butModify
            // 
            this.butModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butModify.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butModify.Image = global::zlMedimgSystem.CTL.Navigate.Properties.Resources.blackwrite24x24;
            this.butModify.Location = new System.Drawing.Point(557, 40);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(27, 23);
            this.butModify.TabIndex = 24;
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(521, 397);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 11;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(440, 397);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 10;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(372, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 59;
            this.label7.Text = "前景色";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 58;
            this.label6.Text = "背景色";
            // 
            // labBkColor
            // 
            this.labBkColor.BackColor = System.Drawing.Color.White;
            this.labBkColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labBkColor.Color = System.Drawing.Color.Empty;
            this.labBkColor.Location = new System.Drawing.Point(269, 10);
            this.labBkColor.Name = "labBkColor";
            this.labBkColor.Size = new System.Drawing.Size(97, 18);
            this.labBkColor.TabIndex = 64;
            // 
            // labForeColor
            // 
            this.labForeColor.BackColor = System.Drawing.Color.White;
            this.labForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labForeColor.Color = System.Drawing.Color.Empty;
            this.labForeColor.Location = new System.Drawing.Point(419, 10);
            this.labForeColor.Name = "labForeColor";
            this.labForeColor.Size = new System.Drawing.Size(97, 18);
            this.labForeColor.TabIndex = 65;
            // 
            // frmDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 441);
            this.Controls.Add(this.labForeColor);
            this.Controls.Add(this.labBkColor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkShowExit);
            this.Controls.Add(this.chkCbxMenu);
            this.Controls.Add(this.chkLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmDesign_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.CheckBox chkCbxMenu;
        private System.Windows.Forms.CheckBox chkShowExit;
        private System.Windows.Forms.ComboBox cbxButType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtButTag;
        private System.Windows.Forms.Button butLoadImg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImgName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butModify;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private BusinessBase.Controls.ColorEditor labBkColor;
        private BusinessBase.Controls.ColorEditor labForeColor;
    }
}