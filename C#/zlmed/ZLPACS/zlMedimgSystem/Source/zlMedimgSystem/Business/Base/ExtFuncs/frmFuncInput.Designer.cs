namespace zlMedimgSystem.ExtFuncs
{
    partial class frmFuncInput
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
            this.butInsertPars = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.rtbDataFrom = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputName = new System.Windows.Forms.TextBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.txtDefaultValue = new System.Windows.Forms.TextBox();
            this.chkIsSave = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxControlType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // butInsertPars
            // 
            this.butInsertPars.Location = new System.Drawing.Point(481, 109);
            this.butInsertPars.Name = "butInsertPars";
            this.butInsertPars.Size = new System.Drawing.Size(24, 92);
            this.butInsertPars.TabIndex = 22;
            this.butInsertPars.Text = "插  入  参  数";
            this.butInsertPars.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "默认值";
            // 
            // rtbDataFrom
            // 
            this.rtbDataFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbDataFrom.Location = new System.Drawing.Point(109, 109);
            this.rtbDataFrom.Name = "rtbDataFrom";
            this.rtbDataFrom.Size = new System.Drawing.Size(375, 92);
            this.rtbDataFrom.TabIndex = 19;
            this.rtbDataFrom.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "数据来源";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "录入名称";
            // 
            // txtInputName
            // 
            this.txtInputName.Location = new System.Drawing.Point(109, 28);
            this.txtInputName.Name = "txtInputName";
            this.txtInputName.Size = new System.Drawing.Size(396, 21);
            this.txtInputName.TabIndex = 16;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(430, 228);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 24;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(340, 228);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 23;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Location = new System.Drawing.Point(109, 83);
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(396, 21);
            this.txtDefaultValue.TabIndex = 25;
            // 
            // chkIsSave
            // 
            this.chkIsSave.AutoSize = true;
            this.chkIsSave.Checked = true;
            this.chkIsSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsSave.Location = new System.Drawing.Point(109, 208);
            this.chkIsSave.Name = "chkIsSave";
            this.chkIsSave.Size = new System.Drawing.Size(72, 16);
            this.chkIsSave.TabIndex = 26;
            this.chkIsSave.Text = "允许保存";
            this.chkIsSave.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "控件类型";
            // 
            // cbxControlType
            // 
            this.cbxControlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxControlType.FormattingEnabled = true;
            this.cbxControlType.Items.AddRange(new object[] {
            "文本框",
            "富文本框",
            "下拉框",
            "日期框"});
            this.cbxControlType.Location = new System.Drawing.Point(108, 57);
            this.cbxControlType.Name = "cbxControlType";
            this.cbxControlType.Size = new System.Drawing.Size(396, 20);
            this.cbxControlType.TabIndex = 29;
            // 
            // frmFuncInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 274);
            this.Controls.Add(this.cbxControlType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkIsSave);
            this.Controls.Add(this.txtDefaultValue);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.butInsertPars);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rtbDataFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInputName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFuncInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "录入项配置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFuncInput_FormClosed);
            this.Load += new System.EventHandler(this.frmFuncInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butInsertPars;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtbDataFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputName;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.TextBox txtDefaultValue;
        private System.Windows.Forms.CheckBox chkIsSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxControlType;
    }
}