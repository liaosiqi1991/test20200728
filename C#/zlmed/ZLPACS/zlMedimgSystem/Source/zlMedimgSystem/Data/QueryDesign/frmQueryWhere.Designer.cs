namespace zlMedimgSystem.QueryDesign
{
    partial class frmQueryWhere
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
            this.txtWhereItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbWhereContext = new System.Windows.Forms.RichTextBox();
            this.tabItems = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.butInsertParToDataFrom = new System.Windows.Forms.Button();
            this.chkReplace = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDefaultValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExtPros = new System.Windows.Forms.TextBox();
            this.rtbDataFrom = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxControlType = new System.Windows.Forms.ComboBox();
            this.butSure = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxLinkType = new System.Windows.Forms.ComboBox();
            this.butInsertPars = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxDBAlias = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtWhereItemName
            // 
            this.txtWhereItemName.Location = new System.Drawing.Point(105, 19);
            this.txtWhereItemName.Name = "txtWhereItemName";
            this.txtWhereItemName.Size = new System.Drawing.Size(227, 21);
            this.txtWhereItemName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "条件项名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "条件判断内容";
            // 
            // rtbWhereContext
            // 
            this.rtbWhereContext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbWhereContext.Location = new System.Drawing.Point(105, 46);
            this.rtbWhereContext.Name = "rtbWhereContext";
            this.rtbWhereContext.Size = new System.Drawing.Size(353, 75);
            this.rtbWhereContext.TabIndex = 4;
            this.rtbWhereContext.Text = "";
            this.rtbWhereContext.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // tabItems
            // 
            this.tabItems.Location = new System.Drawing.Point(37, 170);
            this.tabItems.Name = "tabItems";
            this.tabItems.SelectedIndex = 0;
            this.tabItems.Size = new System.Drawing.Size(469, 22);
            this.tabItems.TabIndex = 5;
            this.tabItems.SelectedIndexChanged += new System.EventHandler(this.tabItems_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbxDBAlias);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.butInsertParToDataFrom);
            this.panel1.Controls.Add(this.chkReplace);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtDefaultValue);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtExtPros);
            this.panel1.Controls.Add(this.rtbDataFrom);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbxControlType);
            this.panel1.Location = new System.Drawing.Point(37, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 365);
            this.panel1.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(67, 336);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(2);
            this.label10.Size = new System.Drawing.Size(268, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "将检索查询界面选择的录入数据作为查询条件项";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(67, 143);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(2);
            this.label8.Size = new System.Drawing.Size(354, 116);
            this.label8.TabIndex = 22;
            this.label8.Text = "    数据来源支持sql查询和普通文本，不同方式使用的配置方式分别如下：\r\n\r\n    1.如果是sql查询，则返回字段需要包含数据值，数据描述，进行数据检索时" +
    "将使用数据值作为查询条件；\r\n\r\n    2.如果是普通文本，则使用“-”符号分割数据值和数据描述，如“0-男”,当要返回多值时，使用“;”分号分离，如“0-男" +
    ";1-女;2-未明”；";
            // 
            // butInsertParToDataFrom
            // 
            this.butInsertParToDataFrom.Location = new System.Drawing.Point(427, 58);
            this.butInsertParToDataFrom.Name = "butInsertParToDataFrom";
            this.butInsertParToDataFrom.Size = new System.Drawing.Size(37, 39);
            this.butInsertParToDataFrom.TabIndex = 21;
            this.butInsertParToDataFrom.Text = "系统参数";
            this.butInsertParToDataFrom.UseVisualStyleBackColor = true;
            this.butInsertParToDataFrom.Click += new System.EventHandler(this.butInsertParToDataFrom_Click);
            // 
            // chkReplace
            // 
            this.chkReplace.AutoSize = true;
            this.chkReplace.Location = new System.Drawing.Point(67, 317);
            this.chkReplace.Name = "chkReplace";
            this.chkReplace.Size = new System.Drawing.Size(72, 16);
            this.chkReplace.TabIndex = 20;
            this.chkReplace.Text = "条件替换";
            this.chkReplace.UseVisualStyleBackColor = true;
            this.chkReplace.CheckedChanged += new System.EventHandler(this.chkReplace_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "默认取值";
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Location = new System.Drawing.Point(67, 289);
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(397, 21);
            this.txtDefaultValue.TabIndex = 18;
            this.txtDefaultValue.TextChanged += new System.EventHandler(this.cbxControlType_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "扩展属性";
            // 
            // txtExtPros
            // 
            this.txtExtPros.Location = new System.Drawing.Point(67, 262);
            this.txtExtPros.Name = "txtExtPros";
            this.txtExtPros.Size = new System.Drawing.Size(397, 21);
            this.txtExtPros.TabIndex = 16;
            this.txtExtPros.TextChanged += new System.EventHandler(this.cbxControlType_TextChanged);
            // 
            // rtbDataFrom
            // 
            this.rtbDataFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbDataFrom.Location = new System.Drawing.Point(67, 58);
            this.rtbDataFrom.Name = "rtbDataFrom";
            this.rtbDataFrom.Size = new System.Drawing.Size(354, 82);
            this.rtbDataFrom.TabIndex = 13;
            this.rtbDataFrom.Text = "";
            this.rtbDataFrom.TextChanged += new System.EventHandler(this.cbxControlType_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "数据来源";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "录入类型";
            // 
            // cbxControlType
            // 
            this.cbxControlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxControlType.FormattingEnabled = true;
            this.cbxControlType.Items.AddRange(new object[] {
            "文本框",
            "下拉框",
            "日期框"});
            this.cbxControlType.Location = new System.Drawing.Point(67, 6);
            this.cbxControlType.Name = "cbxControlType";
            this.cbxControlType.Size = new System.Drawing.Size(397, 20);
            this.cbxControlType.TabIndex = 10;
            this.cbxControlType.SelectedIndexChanged += new System.EventHandler(this.cbxControlType_SelectedIndexChanged);
            this.cbxControlType.TextChanged += new System.EventHandler(this.cbxControlType_TextChanged);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(337, 563);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 29);
            this.butSure.TabIndex = 11;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(427, 563);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 29);
            this.butCancel.TabIndex = 12;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(338, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "链接类型";
            // 
            // cbxLinkType
            // 
            this.cbxLinkType.FormattingEnabled = true;
            this.cbxLinkType.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.cbxLinkType.Location = new System.Drawing.Point(397, 20);
            this.cbxLinkType.Name = "cbxLinkType";
            this.cbxLinkType.Size = new System.Drawing.Size(61, 20);
            this.cbxLinkType.TabIndex = 13;
            this.cbxLinkType.Text = "AND";
            // 
            // butInsertPars
            // 
            this.butInsertPars.Location = new System.Drawing.Point(464, 46);
            this.butInsertPars.Name = "butInsertPars";
            this.butInsertPars.Size = new System.Drawing.Size(37, 39);
            this.butInsertPars.TabIndex = 15;
            this.butInsertPars.Text = "系统参数";
            this.butInsertPars.UseVisualStyleBackColor = true;
            this.butInsertPars.Click += new System.EventHandler(this.butInsertPars_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(105, 124);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(2);
            this.label9.Size = new System.Drawing.Size(353, 43);
            this.label9.TabIndex = 23;
            this.label9.Text = "    配置SQL查询的WHERE部分的条件项，每个条件项对应一句判断表达式，如 性别=[性别]  或者 申请日期 between [开始日期] and [结束日" +
    "期]";
            // 
            // cbxDBAlias
            // 
            this.cbxDBAlias.FormattingEnabled = true;
            this.cbxDBAlias.Location = new System.Drawing.Point(67, 32);
            this.cbxDBAlias.Name = "cbxDBAlias";
            this.cbxDBAlias.Size = new System.Drawing.Size(397, 20);
            this.cbxDBAlias.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 25;
            this.label11.Text = "数据源";
            // 
            // frmQueryWhere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 611);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.butInsertPars);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbxLinkType);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabItems);
            this.Controls.Add(this.rtbWhereContext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWhereItemName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQueryWhere";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询条件项配置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQueryWhere_FormClosed);
            this.Load += new System.EventHandler(this.frmWhereItem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWhereItemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbWhereContext;
        private System.Windows.Forms.TabControl tabItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkReplace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDefaultValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExtPros;
        private System.Windows.Forms.RichTextBox rtbDataFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxControlType;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxLinkType;
        private System.Windows.Forms.Button butInsertPars;
        private System.Windows.Forms.Button butInsertParToDataFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxDBAlias;
        private System.Windows.Forms.Label label11;
    }
}