namespace zlMedimgSystem.BaseSettings
{
    partial class frmReportSectionConfig
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.cbxElementName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.chkSyncSave = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(481, 31);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = global::zlMedimgSystem.BaseSettings.Properties.Resources.check;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(75, 28);
            this.tsbSave.Text = "确定(&S)";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::zlMedimgSystem.BaseSettings.Properties.Resources.exit;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(76, 28);
            this.tsbExit.Text = "取消(&C)";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // cbxElementName
            // 
            this.cbxElementName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxElementName.FormattingEnabled = true;
            this.cbxElementName.Location = new System.Drawing.Point(260, 331);
            this.cbxElementName.Name = "cbxElementName";
            this.cbxElementName.Size = new System.Drawing.Size(140, 20);
            this.cbxElementName.TabIndex = 4;
            this.cbxElementName.SelectedIndexChanged += new System.EventHandler(this.cbxElementName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "关联元素";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(475, 82);
            this.label2.TabIndex = 6;
            this.label2.Text = "    从报告模板中选择一个对应的元素与段落名称进行关联，配置关联元素后，选择对应词句内容后将自动填入对应的段落中；\r\n\r\n    如果勾选了关联存储，在保存报告" +
    "内容时将会把该元素的内容对应存入到【影像报告段落】表的对应段落名称所表示的字段中。";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "显示名称";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(60, 330);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(135, 21);
            this.txtTitle.TabIndex = 10;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 120);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(475, 205);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // chkSyncSave
            // 
            this.chkSyncSave.AutoSize = true;
            this.chkSyncSave.Location = new System.Drawing.Point(406, 333);
            this.chkSyncSave.Name = "chkSyncSave";
            this.chkSyncSave.Size = new System.Drawing.Size(72, 16);
            this.chkSyncSave.TabIndex = 12;
            this.chkSyncSave.Text = "同步保存";
            this.chkSyncSave.UseVisualStyleBackColor = true;
            this.chkSyncSave.CheckedChanged += new System.EventHandler(this.chkSyncSave_CheckedChanged);
            // 
            // frmReportSectionConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 363);
            this.Controls.Add(this.chkSyncSave);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxElementName);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportSectionConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "段落设置";
            this.Load += new System.EventHandler(this.frmReportSectionConfig_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ComboBox cbxElementName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.CheckBox chkSyncSave;
    }
}