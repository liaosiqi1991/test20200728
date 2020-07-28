namespace zlMedimgSystem.CTL.ViewTable
{
    partial class frmViewTableDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewTableDesign));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.cbxIsShow = new System.Windows.Forms.ComboBox();
            this.txtColTitle = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.lstColList = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxColName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnPACS = new System.Windows.Forms.RadioButton();
            this.rbtnHis = new System.Windows.Forms.RadioButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.simpleButton1);
            this.groupBox1.Controls.Add(this.btnUp);
            this.groupBox1.Controls.Add(this.btnDown);
            this.groupBox1.Controls.Add(this.cbxIsShow);
            this.groupBox1.Controls.Add(this.txtColTitle);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.lstColList);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxColName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(26, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1308, 572);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据列配置";
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("黑体", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUp.Location = new System.Drawing.Point(1226, 164);
            this.btnUp.Margin = new System.Windows.Forms.Padding(6);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(54, 103);
            this.btnUp.TabIndex = 29;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("黑体", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDown.Location = new System.Drawing.Point(1226, 337);
            this.btnDown.Margin = new System.Windows.Forms.Padding(6);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(54, 103);
            this.btnDown.TabIndex = 30;
            this.btnDown.Text = "↓ ";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // cbxIsShow
            // 
            this.cbxIsShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIsShow.FormattingEnabled = true;
            this.cbxIsShow.Items.AddRange(new object[] {
            "显示",
            "隐藏"});
            this.cbxIsShow.Location = new System.Drawing.Point(829, 44);
            this.cbxIsShow.Margin = new System.Windows.Forms.Padding(6);
            this.cbxIsShow.Name = "cbxIsShow";
            this.cbxIsShow.Size = new System.Drawing.Size(199, 32);
            this.cbxIsShow.TabIndex = 28;
            // 
            // txtColTitle
            // 
            this.txtColTitle.Location = new System.Drawing.Point(457, 43);
            this.txtColTitle.Margin = new System.Windows.Forms.Padding(6);
            this.txtColTitle.MaxLength = 200;
            this.txtColTitle.Name = "txtColTitle";
            this.txtColTitle.Size = new System.Drawing.Size(199, 35);
            this.txtColTitle.TabIndex = 27;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(1077, 43);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 46);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "┼";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.Location = new System.Drawing.Point(1151, 43);
            this.btnDel.Margin = new System.Windows.Forms.Padding(6);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(54, 46);
            this.btnDel.TabIndex = 26;
            this.btnDel.Text = "─";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lstColList
            // 
            this.lstColList.FullRowSelect = true;
            this.lstColList.HideSelection = false;
            this.lstColList.Location = new System.Drawing.Point(34, 116);
            this.lstColList.Margin = new System.Windows.Forms.Padding(6);
            this.lstColList.MultiSelect = false;
            this.lstColList.Name = "lstColList";
            this.lstColList.Size = new System.Drawing.Size(1179, 431);
            this.lstColList.TabIndex = 24;
            this.lstColList.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(708, 48);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "是否显示";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "列标题";
            // 
            // cbxColName
            // 
            this.cbxColName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxColName.FormattingEnabled = true;
            this.cbxColName.Location = new System.Drawing.Point(124, 44);
            this.cbxColName.Margin = new System.Windows.Forms.Padding(6);
            this.cbxColName.Name = "cbxColName";
            this.cbxColName.Size = new System.Drawing.Size(199, 32);
            this.cbxColName.TabIndex = 13;
            this.cbxColName.SelectedIndexChanged += new System.EventHandler(this.cbxColName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "列名称";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(1156, 745);
            this.butCancel.Margin = new System.Windows.Forms.Padding(6);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(150, 46);
            this.butCancel.TabIndex = 20;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(994, 745);
            this.butOK.Margin = new System.Windows.Forms.Padding(6);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(150, 46);
            this.butOK.TabIndex = 19;
            this.butOK.Text = "确定(&S)";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnPACS);
            this.groupBox2.Controls.Add(this.rbtnHis);
            this.groupBox2.Location = new System.Drawing.Point(26, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(439, 102);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据来源";
            // 
            // rbtnPACS
            // 
            this.rbtnPACS.AutoSize = true;
            this.rbtnPACS.Checked = true;
            this.rbtnPACS.Location = new System.Drawing.Point(279, 45);
            this.rbtnPACS.Name = "rbtnPACS";
            this.rbtnPACS.Size = new System.Drawing.Size(89, 28);
            this.rbtnPACS.TabIndex = 1;
            this.rbtnPACS.TabStop = true;
            this.rbtnPACS.Text = "PACS";
            this.rbtnPACS.UseVisualStyleBackColor = true;
            this.rbtnPACS.CheckedChanged += new System.EventHandler(this.rbtnPACS_CheckedChanged);
            // 
            // rbtnHis
            // 
            this.rbtnHis.AutoSize = true;
            this.rbtnHis.Location = new System.Drawing.Point(25, 45);
            this.rbtnHis.Name = "rbtnHis";
            this.rbtnHis.Size = new System.Drawing.Size(77, 28);
            this.rbtnHis.TabIndex = 0;
            this.rbtnHis.Text = "HIS";
            this.rbtnHis.UseVisualStyleBackColor = true;
            this.rbtnHis.CheckedChanged += new System.EventHandler(this.rbtnPACS_CheckedChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(1225, 43);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(54, 46);
            this.simpleButton1.TabIndex = 32;
            this.simpleButton1.Text = "X";
            this.simpleButton1.ToolTip = "清除所有列";
            // 
            // frmViewTableDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 827);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmViewTableDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自定义列表显示";
            this.Load += new System.EventHandler(this.frmViewTableDesign_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ListView lstColList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxColName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.ComboBox cbxIsShow;
        private System.Windows.Forms.TextBox txtColTitle;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnPACS;
        private System.Windows.Forms.RadioButton rbtnHis;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}