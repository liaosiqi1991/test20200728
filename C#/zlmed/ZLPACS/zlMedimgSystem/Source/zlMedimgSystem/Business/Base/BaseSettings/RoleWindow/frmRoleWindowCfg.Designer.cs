namespace zlMedimgSystem.BaseSettings
{
    partial class frmRoleWindowCfg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoleWindowCfg));
            this.panel2 = new System.Windows.Forms.Panel();
            this.butDesign = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.butModify = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbWindowDescription = new System.Windows.Forms.RichTextBox();
            this.cbxWindowGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWindowName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lstRoles = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.butSetMainWindow = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.butDesign);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.butModify);
            this.panel2.Controls.Add(this.butDel);
            this.panel2.Controls.Add(this.butNew);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.rtbWindowDescription);
            this.panel2.Controls.Add(this.cbxWindowGroup);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtWindowName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(530, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 550);
            this.panel2.TabIndex = 2;
            // 
            // butDesign
            // 
            this.butDesign.Location = new System.Drawing.Point(8, 336);
            this.butDesign.Name = "butDesign";
            this.butDesign.Size = new System.Drawing.Size(75, 36);
            this.butDesign.TabIndex = 31;
            this.butDesign.Text = "界面设计";
            this.butDesign.UseVisualStyleBackColor = true;
            this.butDesign.Click += new System.EventHandler(this.butDesign_Click);
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
            this.butDel.Location = new System.Drawing.Point(212, 336);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(75, 36);
            this.butDel.TabIndex = 28;
            this.butDel.Text = "删除";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(131, 336);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(75, 36);
            this.butNew.TabIndex = 27;
            this.butNew.Text = "添加";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "窗体描述";
            // 
            // rtbWindowDescription
            // 
            this.rtbWindowDescription.Location = new System.Drawing.Point(75, 169);
            this.rtbWindowDescription.Name = "rtbWindowDescription";
            this.rtbWindowDescription.Size = new System.Drawing.Size(293, 129);
            this.rtbWindowDescription.TabIndex = 24;
            this.rtbWindowDescription.Text = "";
            // 
            // cbxWindowGroup
            // 
            this.cbxWindowGroup.FormattingEnabled = true;
            this.cbxWindowGroup.Location = new System.Drawing.Point(75, 143);
            this.cbxWindowGroup.Name = "cbxWindowGroup";
            this.cbxWindowGroup.Size = new System.Drawing.Size(293, 20);
            this.cbxWindowGroup.TabIndex = 23;
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
            this.label4.Text = "窗体名称";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWindowName
            // 
            this.txtWindowName.Location = new System.Drawing.Point(75, 116);
            this.txtWindowName.Name = "txtWindowName";
            this.txtWindowName.Size = new System.Drawing.Size(293, 21);
            this.txtWindowName.TabIndex = 21;
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
            this.label3.Text = "角色窗体配置：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 550);
            this.panel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.splitter1);
            this.panel4.Controls.Add(this.listView1);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(530, 527);
            this.panel4.TabIndex = 12;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 403);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(530, 3);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(530, 406);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lstRoles);
            this.panel5.Controls.Add(this.butSetMainWindow);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 406);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(530, 121);
            this.panel5.TabIndex = 11;
            // 
            // lstRoles
            // 
            this.lstRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRoles.FullRowSelect = true;
            this.lstRoles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstRoles.HideSelection = false;
            this.lstRoles.LargeImageList = this.imageList1;
            this.lstRoles.Location = new System.Drawing.Point(0, 0);
            this.lstRoles.MultiSelect = false;
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.ShowGroups = false;
            this.lstRoles.Size = new System.Drawing.Size(431, 121);
            this.lstRoles.TabIndex = 13;
            this.lstRoles.UseCompatibleStateImageBehavior = false;
            this.lstRoles.SelectedIndexChanged += new System.EventHandler(this.lstRoles_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "businessmen.ico");
            // 
            // butSetMainWindow
            // 
            this.butSetMainWindow.Dock = System.Windows.Forms.DockStyle.Right;
            this.butSetMainWindow.Image = global::zlMedimgSystem.BaseSettings.Properties.Resources.mainform;
            this.butSetMainWindow.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butSetMainWindow.Location = new System.Drawing.Point(431, 0);
            this.butSetMainWindow.Name = "butSetMainWindow";
            this.butSetMainWindow.Size = new System.Drawing.Size(99, 121);
            this.butSetMainWindow.TabIndex = 32;
            this.butSetMainWindow.Text = "应用主窗体设置";
            this.butSetMainWindow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.butSetMainWindow.UseVisualStyleBackColor = true;
            this.butSetMainWindow.Click += new System.EventHandler(this.butSetMainWindow_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbxDepartment);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(530, 23);
            this.panel3.TabIndex = 4;
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Location = new System.Drawing.Point(65, 0);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(465, 20);
            this.cbxDepartment.TabIndex = 1;
            this.cbxDepartment.SelectedIndexChanged += new System.EventHandler(this.cbxDepartment_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(65, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmRoleWindowCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 550);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmRoleWindowCfg";
            this.Text = "角色窗体配置";
            this.Load += new System.EventHandler(this.frmRoleWindowCfg_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butModify;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbWindowDescription;
        private System.Windows.Forms.ComboBox cbxWindowGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWindowName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butDesign;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butSetMainWindow;
        private System.Windows.Forms.ListView lstRoles;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Splitter splitter1;
    }
}