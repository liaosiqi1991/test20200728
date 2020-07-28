namespace zlMedimgSystem.BaseSettings
{
    partial class frmNoRule
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxIdentWay = new System.Windows.Forms.ComboBox();
            this.labFixContext = new System.Windows.Forms.Label();
            this.txtPrefixContext = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxPrefixType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxNumLen = new System.Windows.Forms.ComboBox();
            this.cbxDateSplit = new System.Windows.Forms.ComboBox();
            this.chkUseDays = new System.Windows.Forms.CheckBox();
            this.chkUseMonth = new System.Windows.Forms.CheckBox();
            this.cbxYearFmt = new System.Windows.Forms.ComboBox();
            this.cbxPrefixSplit = new System.Windows.Forms.ComboBox();
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxNoType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labDemo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.butApply = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chkKeep = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labFixContext);
            this.groupBox1.Controls.Add(this.cbxIdentWay);
            this.groupBox1.Controls.Add(this.txtPrefixContext);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbxPrefixType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxNumLen);
            this.groupBox1.Controls.Add(this.cbxDateSplit);
            this.groupBox1.Controls.Add(this.chkUseDays);
            this.groupBox1.Controls.Add(this.chkUseMonth);
            this.groupBox1.Controls.Add(this.cbxYearFmt);
            this.groupBox1.Controls.Add(this.cbxPrefixSplit);
            this.groupBox1.Controls.Add(this.chkKeep);
            this.groupBox1.Location = new System.Drawing.Point(34, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 270);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cbxIdentWay
            // 
            this.cbxIdentWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIdentWay.FormattingEnabled = true;
            this.cbxIdentWay.Items.AddRange(new object[] {
            "检查科室",
            "影像类别"});
            this.cbxIdentWay.Location = new System.Drawing.Point(106, 18);
            this.cbxIdentWay.Name = "cbxIdentWay";
            this.cbxIdentWay.Size = new System.Drawing.Size(76, 20);
            this.cbxIdentWay.TabIndex = 27;
            // 
            // labFixContext
            // 
            this.labFixContext.AutoSize = true;
            this.labFixContext.Location = new System.Drawing.Point(87, 84);
            this.labFixContext.Name = "labFixContext";
            this.labFixContext.Size = new System.Drawing.Size(53, 12);
            this.labFixContext.TabIndex = 25;
            this.labFixContext.Text = "固定文本";
            // 
            // txtPrefixContext
            // 
            this.txtPrefixContext.Location = new System.Drawing.Point(146, 81);
            this.txtPrefixContext.Name = "txtPrefixContext";
            this.txtPrefixContext.Size = new System.Drawing.Size(161, 21);
            this.txtPrefixContext.TabIndex = 2;
            this.txtPrefixContext.Text = "STU";
            this.txtPrefixContext.TextChanged += new System.EventHandler(this.cbxNoType_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "前缀类型";
            // 
            // cbxPrefixType
            // 
            this.cbxPrefixType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPrefixType.FormattingEnabled = true;
            this.cbxPrefixType.Items.AddRange(new object[] {
            "影像类别编码",
            "固定文本前缀",
            "不使用前缀"});
            this.cbxPrefixType.Location = new System.Drawing.Point(89, 55);
            this.cbxPrefixType.Name = "cbxPrefixType";
            this.cbxPrefixType.Size = new System.Drawing.Size(218, 20);
            this.cbxPrefixType.TabIndex = 23;
            this.cbxPrefixType.SelectedIndexChanged += new System.EventHandler(this.cbxPrefixType_SelectedIndexChanged);
            this.cbxPrefixType.TextChanged += new System.EventHandler(this.cbxNoType_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "年份格式";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "日期分隔符";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "前缀分隔符";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "序号位数";
            // 
            // cbxNumLen
            // 
            this.cbxNumLen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNumLen.FormattingEnabled = true;
            this.cbxNumLen.Items.AddRange(new object[] {
            "4位",
            "5位",
            "6位",
            "7位",
            "8位",
            "9位"});
            this.cbxNumLen.Location = new System.Drawing.Point(110, 235);
            this.cbxNumLen.Name = "cbxNumLen";
            this.cbxNumLen.Size = new System.Drawing.Size(197, 20);
            this.cbxNumLen.TabIndex = 18;
            this.cbxNumLen.SelectedIndexChanged += new System.EventHandler(this.cbxNumLen_SelectedIndexChanged);
            this.cbxNumLen.TextChanged += new System.EventHandler(this.cbxNoType_TextChanged);
            // 
            // cbxDateSplit
            // 
            this.cbxDateSplit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDateSplit.FormattingEnabled = true;
            this.cbxDateSplit.Items.AddRange(new object[] {
            "-",
            "_",
            "/",
            "\\",
            ".",
            " "});
            this.cbxDateSplit.Location = new System.Drawing.Point(110, 209);
            this.cbxDateSplit.Name = "cbxDateSplit";
            this.cbxDateSplit.Size = new System.Drawing.Size(197, 20);
            this.cbxDateSplit.TabIndex = 16;
            this.cbxDateSplit.SelectedIndexChanged += new System.EventHandler(this.cbxDateSplit_SelectedIndexChanged);
            this.cbxDateSplit.TextChanged += new System.EventHandler(this.cbxNoType_TextChanged);
            // 
            // chkUseDays
            // 
            this.chkUseDays.AutoSize = true;
            this.chkUseDays.Location = new System.Drawing.Point(110, 187);
            this.chkUseDays.Name = "chkUseDays";
            this.chkUseDays.Size = new System.Drawing.Size(72, 16);
            this.chkUseDays.TabIndex = 15;
            this.chkUseDays.Text = "使用天数";
            this.chkUseDays.UseVisualStyleBackColor = true;
            this.chkUseDays.CheckedChanged += new System.EventHandler(this.cbxNoType_TextChanged);
            // 
            // chkUseMonth
            // 
            this.chkUseMonth.AutoSize = true;
            this.chkUseMonth.Location = new System.Drawing.Point(110, 165);
            this.chkUseMonth.Name = "chkUseMonth";
            this.chkUseMonth.Size = new System.Drawing.Size(72, 16);
            this.chkUseMonth.TabIndex = 14;
            this.chkUseMonth.Text = "使用月份";
            this.chkUseMonth.UseVisualStyleBackColor = true;
            this.chkUseMonth.CheckedChanged += new System.EventHandler(this.cbxNoType_TextChanged);
            // 
            // cbxYearFmt
            // 
            this.cbxYearFmt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxYearFmt.FormattingEnabled = true;
            this.cbxYearFmt.Items.AddRange(new object[] {
            "YYYY",
            "YY",
            " "});
            this.cbxYearFmt.Location = new System.Drawing.Point(110, 139);
            this.cbxYearFmt.Name = "cbxYearFmt";
            this.cbxYearFmt.Size = new System.Drawing.Size(197, 20);
            this.cbxYearFmt.TabIndex = 13;
            this.cbxYearFmt.SelectedIndexChanged += new System.EventHandler(this.cbxYearFmt_SelectedIndexChanged);
            this.cbxYearFmt.TextChanged += new System.EventHandler(this.cbxNoType_TextChanged);
            // 
            // cbxPrefixSplit
            // 
            this.cbxPrefixSplit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPrefixSplit.FormattingEnabled = true;
            this.cbxPrefixSplit.Items.AddRange(new object[] {
            "-",
            "_",
            "/",
            "\\",
            ".",
            " "});
            this.cbxPrefixSplit.Location = new System.Drawing.Point(110, 108);
            this.cbxPrefixSplit.Name = "cbxPrefixSplit";
            this.cbxPrefixSplit.Size = new System.Drawing.Size(197, 20);
            this.cbxPrefixSplit.TabIndex = 9;
            this.cbxPrefixSplit.SelectedIndexChanged += new System.EventHandler(this.cbxPrefixSplit_SelectedIndexChanged);
            this.cbxPrefixSplit.TextChanged += new System.EventHandler(this.cbxNoType_TextChanged);
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Location = new System.Drawing.Point(98, 11);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(265, 20);
            this.cbxDepartment.TabIndex = 3;
            this.cbxDepartment.SelectedIndexChanged += new System.EventHandler(this.cbxDepartment_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "科室名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxNoType
            // 
            this.cbxNoType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNoType.FormattingEnabled = true;
            this.cbxNoType.Items.AddRange(new object[] {
            "医嘱号",
            "患者号",
            "住院号",
            "门诊号",
            "就诊卡号",
            "社保卡号",
            "自定义号"});
            this.cbxNoType.Location = new System.Drawing.Point(66, 47);
            this.cbxNoType.Name = "cbxNoType";
            this.cbxNoType.Size = new System.Drawing.Size(133, 20);
            this.cbxNoType.TabIndex = 5;
            this.cbxNoType.SelectedIndexChanged += new System.EventHandler(this.cbxNoType_SelectedIndexChanged);
            this.cbxNoType.TextChanged += new System.EventHandler(this.cbxNoType_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.labDemo);
            this.panel1.Controls.Add(this.cbxNoType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.butApply);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbxDepartment);
            this.panel1.Location = new System.Drawing.Point(219, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 408);
            this.panel1.TabIndex = 6;
            // 
            // labDemo
            // 
            this.labDemo.AutoSize = true;
            this.labDemo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labDemo.Location = new System.Drawing.Point(32, 368);
            this.labDemo.Name = "labDemo";
            this.labDemo.Size = new System.Drawing.Size(64, 12);
            this.labDemo.TabIndex = 8;
            this.labDemo.Text = "号码示例:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "使用                        作为检查号 ";
            // 
            // butApply
            // 
            this.butApply.Location = new System.Drawing.Point(288, 363);
            this.butApply.Name = "butApply";
            this.butApply.Size = new System.Drawing.Size(75, 23);
            this.butApply.TabIndex = 6;
            this.butApply.Text = "应用(&A)";
            this.butApply.UseVisualStyleBackColor = true;
            this.butApply.Click += new System.EventHandler(this.butApply_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(661, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkKeep
            // 
            this.chkKeep.AutoSize = true;
            this.chkKeep.Location = new System.Drawing.Point(32, 20);
            this.chkKeep.Name = "chkKeep";
            this.chkKeep.Size = new System.Drawing.Size(186, 16);
            this.chkKeep.TabIndex = 26;
            this.chkKeep.Text = "检查号按               统一";
            this.chkKeep.UseVisualStyleBackColor = true;
            // 
            // frmNoRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 523);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "frmNoRule";
            this.Text = "号码规则";
            this.Load += new System.EventHandler(this.frmNoRule_Load);
            this.Resize += new System.EventHandler(this.frmNoRule_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxNoType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butApply;
        private System.Windows.Forms.TextBox txtPrefixContext;
        private System.Windows.Forms.ComboBox cbxPrefixSplit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxNumLen;
        private System.Windows.Forms.ComboBox cbxDateSplit;
        private System.Windows.Forms.CheckBox chkUseDays;
        private System.Windows.Forms.CheckBox chkUseMonth;
        private System.Windows.Forms.ComboBox cbxYearFmt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labFixContext;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxPrefixType;
        private System.Windows.Forms.ComboBox cbxIdentWay;
        private System.Windows.Forms.Label labDemo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkKeep;
    }
}