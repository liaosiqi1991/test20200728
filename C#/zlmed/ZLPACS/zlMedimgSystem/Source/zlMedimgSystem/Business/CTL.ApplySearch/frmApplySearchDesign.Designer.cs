namespace zlMedimgSystem.CTL.ApplySearch
{
    partial class frmApplySearchDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApplySearchDesign));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butAdd = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtColCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtColStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRowCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRowStart = new System.Windows.Forms.TextBox();
            this.cbxControlName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxControlType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxHISDB = new System.Windows.Forms.ComboBox();
            this.rbtnPACS = new System.Windows.Forms.RadioButton();
            this.rbtnHis = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butAdd);
            this.groupBox1.Controls.Add(this.butDel);
            this.groupBox1.Controls.Add(this.listView);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtColCount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtColStart);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRowCount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtRowStart);
            this.groupBox1.Controls.Add(this.cbxControlName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxControlType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(35, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1308, 551);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检索条件配置";
            // 
            // butAdd
            // 
            this.butAdd.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butAdd.Location = new System.Drawing.Point(1150, 92);
            this.butAdd.Margin = new System.Windows.Forms.Padding(6);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(54, 46);
            this.butAdd.TabIndex = 25;
            this.butAdd.Text = "┼";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butDel
            // 
            this.butDel.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butDel.Location = new System.Drawing.Point(1216, 92);
            this.butDel.Margin = new System.Windows.Forms.Padding(6);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(54, 46);
            this.butDel.TabIndex = 26;
            this.butDel.Text = "─";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // listView
            // 
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(34, 157);
            this.listView.Margin = new System.Windows.Forms.Padding(6);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(1246, 418);
            this.listView.TabIndex = 24;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(842, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 23;
            this.label3.Text = "占用列数";
            // 
            // txtColCount
            // 
            this.txtColCount.Location = new System.Drawing.Point(960, 103);
            this.txtColCount.Margin = new System.Windows.Forms.Padding(6);
            this.txtColCount.MaxLength = 2;
            this.txtColCount.Name = "txtColCount";
            this.txtColCount.Size = new System.Drawing.Size(128, 35);
            this.txtColCount.TabIndex = 22;
            this.txtColCount.Text = "1";
            this.txtColCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRowStart_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(577, 109);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 24);
            this.label6.TabIndex = 21;
            this.label6.Text = "列";
            // 
            // txtColStart
            // 
            this.txtColStart.Location = new System.Drawing.Point(623, 103);
            this.txtColStart.Margin = new System.Windows.Forms.Padding(6);
            this.txtColStart.MaxLength = 2;
            this.txtColStart.Name = "txtColStart";
            this.txtColStart.Size = new System.Drawing.Size(128, 35);
            this.txtColStart.TabIndex = 20;
            this.txtColStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRowStart_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(842, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "占用行数";
            // 
            // txtRowCount
            // 
            this.txtRowCount.Location = new System.Drawing.Point(960, 41);
            this.txtRowCount.Margin = new System.Windows.Forms.Padding(6);
            this.txtRowCount.MaxLength = 2;
            this.txtRowCount.Name = "txtRowCount";
            this.txtRowCount.Size = new System.Drawing.Size(128, 35);
            this.txtRowCount.TabIndex = 18;
            this.txtRowCount.Text = "1";
            this.txtRowCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRowStart_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(577, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "行";
            // 
            // txtRowStart
            // 
            this.txtRowStart.Location = new System.Drawing.Point(623, 41);
            this.txtRowStart.Margin = new System.Windows.Forms.Padding(6);
            this.txtRowStart.MaxLength = 2;
            this.txtRowStart.Name = "txtRowStart";
            this.txtRowStart.Size = new System.Drawing.Size(128, 35);
            this.txtRowStart.TabIndex = 16;
            this.txtRowStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRowStart_KeyPress);
            // 
            // cbxControlName
            // 
            this.cbxControlName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxControlName.FormattingEnabled = true;
            this.cbxControlName.Items.AddRange(new object[] {
            "文本类型",
            "按钮类型",
            "下拉类型",
            "分割类型"});
            this.cbxControlName.Location = new System.Drawing.Point(148, 106);
            this.cbxControlName.Margin = new System.Windows.Forms.Padding(6);
            this.cbxControlName.Name = "cbxControlName";
            this.cbxControlName.Size = new System.Drawing.Size(316, 32);
            this.cbxControlName.TabIndex = 15;
            this.cbxControlName.SelectedIndexChanged += new System.EventHandler(this.cbxControlName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "控件名称";
            // 
            // cbxControlType
            // 
            this.cbxControlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxControlType.FormattingEnabled = true;
            this.cbxControlType.Items.AddRange(new object[] {
            "单项条件",
            "复合条件",
            "勾选项",
            "条件按钮",
            "功能按钮"});
            this.cbxControlType.Location = new System.Drawing.Point(148, 37);
            this.cbxControlType.Margin = new System.Windows.Forms.Padding(6);
            this.cbxControlType.Name = "cbxControlType";
            this.cbxControlType.Size = new System.Drawing.Size(316, 32);
            this.cbxControlType.TabIndex = 13;
            this.cbxControlType.SelectedIndexChanged += new System.EventHandler(this.cbxControlType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "控件类型";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(1131, 739);
            this.butCancel.Margin = new System.Windows.Forms.Padding(6);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(150, 46);
            this.butCancel.TabIndex = 18;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(969, 739);
            this.butOK.Margin = new System.Windows.Forms.Padding(6);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(150, 46);
            this.butOK.TabIndex = 17;
            this.butOK.Text = "确定(&S)";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxHISDB);
            this.groupBox2.Controls.Add(this.rbtnPACS);
            this.groupBox2.Controls.Add(this.rbtnHis);
            this.groupBox2.Location = new System.Drawing.Point(35, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1308, 102);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据来源";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // cbxHISDB
            // 
            this.cbxHISDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHISDB.Enabled = false;
            this.cbxHISDB.FormattingEnabled = true;
            this.cbxHISDB.Items.AddRange(new object[] {
            "单项条件",
            "复合条件",
            "勾选项",
            "条件按钮",
            "功能按钮"});
            this.cbxHISDB.Location = new System.Drawing.Point(124, 45);
            this.cbxHISDB.Margin = new System.Windows.Forms.Padding(6);
            this.cbxHISDB.Name = "cbxHISDB";
            this.cbxHISDB.Size = new System.Drawing.Size(316, 32);
            this.cbxHISDB.TabIndex = 14;
            // 
            // rbtnPACS
            // 
            this.rbtnPACS.AutoSize = true;
            this.rbtnPACS.Checked = true;
            this.rbtnPACS.Location = new System.Drawing.Point(746, 45);
            this.rbtnPACS.Name = "rbtnPACS";
            this.rbtnPACS.Size = new System.Drawing.Size(89, 28);
            this.rbtnPACS.TabIndex = 1;
            this.rbtnPACS.TabStop = true;
            this.rbtnPACS.Text = "PACS";
            this.rbtnPACS.UseVisualStyleBackColor = true;
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
            this.rbtnHis.CheckedChanged += new System.EventHandler(this.rbtnHis_CheckedChanged);
            // 
            // frmApplySearchDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 813);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmApplySearchDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自定义检索设置";
            this.Load += new System.EventHandler(this.frmApplySearchDesign_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxControlType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxControlName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtColCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtColStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRowCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRowStart;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnPACS;
        private System.Windows.Forms.RadioButton rbtnHis;
        private System.Windows.Forms.ComboBox cbxHISDB;
    }
}