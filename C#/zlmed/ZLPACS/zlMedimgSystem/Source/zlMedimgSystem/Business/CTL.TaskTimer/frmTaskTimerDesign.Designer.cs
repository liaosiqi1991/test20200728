namespace zlMedimgSystem.CTL.TaskTimer
{
    partial class frmTaskTimerDesign
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInerval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartTime1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxUnit1 = new System.Windows.Forms.ComboBox();
            this.txtRepeat1 = new System.Windows.Forms.TextBox();
            this.chkT1 = new System.Windows.Forms.CheckBox();
            this.chkT2 = new System.Windows.Forms.CheckBox();
            this.txtRepeat2 = new System.Windows.Forms.TextBox();
            this.cbxUnit2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStartTime2 = new System.Windows.Forms.DateTimePicker();
            this.chkT3 = new System.Windows.Forms.CheckBox();
            this.txtRepeat3 = new System.Windows.Forms.TextBox();
            this.cbxUnit3 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpStartTime3 = new System.Windows.Forms.DateTimePicker();
            this.chkT4 = new System.Windows.Forms.CheckBox();
            this.txtRepeat4 = new System.Windows.Forms.TextBox();
            this.cbxUnit4 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpStartTime4 = new System.Windows.Forms.DateTimePicker();
            this.chkT5 = new System.Windows.Forms.CheckBox();
            this.txtRepeat5 = new System.Windows.Forms.TextBox();
            this.cbxUnit5 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpStartTime5 = new System.Windows.Forms.DateTimePicker();
            this.butSure = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "执行间隔";
            // 
            // txtInerval
            // 
            this.txtInerval.Location = new System.Drawing.Point(84, 12);
            this.txtInerval.Name = "txtInerval";
            this.txtInerval.Size = new System.Drawing.Size(100, 21);
            this.txtInerval.TabIndex = 1;
            this.txtInerval.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "秒";
            // 
            // dtpStartTime1
            // 
            this.dtpStartTime1.CustomFormat = "yyyy-MM-dd hh:mm";
            this.dtpStartTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime1.Location = new System.Drawing.Point(84, 53);
            this.dtpStartTime1.Name = "dtpStartTime1";
            this.dtpStartTime1.Size = new System.Drawing.Size(270, 21);
            this.dtpStartTime1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "重复周期";
            // 
            // cbxUnit1
            // 
            this.cbxUnit1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnit1.FormattingEnabled = true;
            this.cbxUnit1.Items.AddRange(new object[] {
            "分",
            "时",
            "天",
            "周",
            "月"});
            this.cbxUnit1.Location = new System.Drawing.Point(493, 53);
            this.cbxUnit1.Name = "cbxUnit1";
            this.cbxUnit1.Size = new System.Drawing.Size(55, 20);
            this.cbxUnit1.TabIndex = 6;
            // 
            // txtRepeat1
            // 
            this.txtRepeat1.Location = new System.Drawing.Point(419, 53);
            this.txtRepeat1.MaxLength = 5;
            this.txtRepeat1.Name = "txtRepeat1";
            this.txtRepeat1.Size = new System.Drawing.Size(68, 21);
            this.txtRepeat1.TabIndex = 7;
            this.txtRepeat1.Text = "0";
            // 
            // chkT1
            // 
            this.chkT1.AutoSize = true;
            this.chkT1.Location = new System.Drawing.Point(12, 57);
            this.chkT1.Name = "chkT1";
            this.chkT1.Size = new System.Drawing.Size(66, 16);
            this.chkT1.TabIndex = 8;
            this.chkT1.Text = "定时器1";
            this.chkT1.UseVisualStyleBackColor = true;
            // 
            // chkT2
            // 
            this.chkT2.AutoSize = true;
            this.chkT2.Location = new System.Drawing.Point(12, 84);
            this.chkT2.Name = "chkT2";
            this.chkT2.Size = new System.Drawing.Size(66, 16);
            this.chkT2.TabIndex = 13;
            this.chkT2.Text = "定时器2";
            this.chkT2.UseVisualStyleBackColor = true;
            // 
            // txtRepeat2
            // 
            this.txtRepeat2.Location = new System.Drawing.Point(419, 80);
            this.txtRepeat2.MaxLength = 5;
            this.txtRepeat2.Name = "txtRepeat2";
            this.txtRepeat2.Size = new System.Drawing.Size(68, 21);
            this.txtRepeat2.TabIndex = 12;
            this.txtRepeat2.Text = "0";
            // 
            // cbxUnit2
            // 
            this.cbxUnit2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnit2.FormattingEnabled = true;
            this.cbxUnit2.Items.AddRange(new object[] {
            "分",
            "时",
            "天",
            "周",
            "月"});
            this.cbxUnit2.Location = new System.Drawing.Point(493, 80);
            this.cbxUnit2.Name = "cbxUnit2";
            this.cbxUnit2.Size = new System.Drawing.Size(55, 20);
            this.cbxUnit2.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "重复周期";
            // 
            // dtpStartTime2
            // 
            this.dtpStartTime2.CustomFormat = "yyyy-MM-dd hh:mm";
            this.dtpStartTime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime2.Location = new System.Drawing.Point(84, 80);
            this.dtpStartTime2.Name = "dtpStartTime2";
            this.dtpStartTime2.Size = new System.Drawing.Size(270, 21);
            this.dtpStartTime2.TabIndex = 9;
            // 
            // chkT3
            // 
            this.chkT3.AutoSize = true;
            this.chkT3.Location = new System.Drawing.Point(12, 111);
            this.chkT3.Name = "chkT3";
            this.chkT3.Size = new System.Drawing.Size(66, 16);
            this.chkT3.TabIndex = 18;
            this.chkT3.Text = "定时器3";
            this.chkT3.UseVisualStyleBackColor = true;
            // 
            // txtRepeat3
            // 
            this.txtRepeat3.Location = new System.Drawing.Point(419, 107);
            this.txtRepeat3.MaxLength = 5;
            this.txtRepeat3.Name = "txtRepeat3";
            this.txtRepeat3.Size = new System.Drawing.Size(68, 21);
            this.txtRepeat3.TabIndex = 17;
            this.txtRepeat3.Text = "0";
            // 
            // cbxUnit3
            // 
            this.cbxUnit3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnit3.FormattingEnabled = true;
            this.cbxUnit3.Items.AddRange(new object[] {
            "分",
            "时",
            "天",
            "周",
            "月"});
            this.cbxUnit3.Location = new System.Drawing.Point(493, 107);
            this.cbxUnit3.Name = "cbxUnit3";
            this.cbxUnit3.Size = new System.Drawing.Size(55, 20);
            this.cbxUnit3.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(360, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "重复周期";
            // 
            // dtpStartTime3
            // 
            this.dtpStartTime3.CustomFormat = "yyyy-MM-dd hh:mm";
            this.dtpStartTime3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime3.Location = new System.Drawing.Point(84, 107);
            this.dtpStartTime3.Name = "dtpStartTime3";
            this.dtpStartTime3.Size = new System.Drawing.Size(270, 21);
            this.dtpStartTime3.TabIndex = 14;
            // 
            // chkT4
            // 
            this.chkT4.AutoSize = true;
            this.chkT4.Location = new System.Drawing.Point(12, 138);
            this.chkT4.Name = "chkT4";
            this.chkT4.Size = new System.Drawing.Size(66, 16);
            this.chkT4.TabIndex = 23;
            this.chkT4.Text = "定时器4";
            this.chkT4.UseVisualStyleBackColor = true;
            // 
            // txtRepeat4
            // 
            this.txtRepeat4.Location = new System.Drawing.Point(419, 134);
            this.txtRepeat4.MaxLength = 5;
            this.txtRepeat4.Name = "txtRepeat4";
            this.txtRepeat4.Size = new System.Drawing.Size(68, 21);
            this.txtRepeat4.TabIndex = 22;
            this.txtRepeat4.Text = "0";
            // 
            // cbxUnit4
            // 
            this.cbxUnit4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnit4.FormattingEnabled = true;
            this.cbxUnit4.Items.AddRange(new object[] {
            "分",
            "时",
            "天",
            "周",
            "月"});
            this.cbxUnit4.Location = new System.Drawing.Point(493, 134);
            this.cbxUnit4.Name = "cbxUnit4";
            this.cbxUnit4.Size = new System.Drawing.Size(55, 20);
            this.cbxUnit4.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "重复周期";
            // 
            // dtpStartTime4
            // 
            this.dtpStartTime4.CustomFormat = "yyyy-MM-dd hh:mm";
            this.dtpStartTime4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime4.Location = new System.Drawing.Point(84, 134);
            this.dtpStartTime4.Name = "dtpStartTime4";
            this.dtpStartTime4.Size = new System.Drawing.Size(270, 21);
            this.dtpStartTime4.TabIndex = 19;
            // 
            // chkT5
            // 
            this.chkT5.AutoSize = true;
            this.chkT5.Location = new System.Drawing.Point(12, 165);
            this.chkT5.Name = "chkT5";
            this.chkT5.Size = new System.Drawing.Size(66, 16);
            this.chkT5.TabIndex = 28;
            this.chkT5.Text = "定时器5";
            this.chkT5.UseVisualStyleBackColor = true;
            // 
            // txtRepeat5
            // 
            this.txtRepeat5.Location = new System.Drawing.Point(419, 161);
            this.txtRepeat5.MaxLength = 5;
            this.txtRepeat5.Name = "txtRepeat5";
            this.txtRepeat5.Size = new System.Drawing.Size(68, 21);
            this.txtRepeat5.TabIndex = 27;
            this.txtRepeat5.Text = "0";
            // 
            // cbxUnit5
            // 
            this.cbxUnit5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnit5.FormattingEnabled = true;
            this.cbxUnit5.Items.AddRange(new object[] {
            "分",
            "时",
            "天",
            "周",
            "月"});
            this.cbxUnit5.Location = new System.Drawing.Point(493, 161);
            this.cbxUnit5.Name = "cbxUnit5";
            this.cbxUnit5.Size = new System.Drawing.Size(55, 20);
            this.cbxUnit5.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "重复周期";
            // 
            // dtpStartTime5
            // 
            this.dtpStartTime5.CustomFormat = "yyyy-MM-dd hh:mm";
            this.dtpStartTime5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime5.Location = new System.Drawing.Point(84, 161);
            this.dtpStartTime5.Name = "dtpStartTime5";
            this.dtpStartTime5.Size = new System.Drawing.Size(270, 21);
            this.dtpStartTime5.TabIndex = 24;
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(392, 198);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 29;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(473, 198);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 30;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // frmTaskTimerDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 235);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.chkT5);
            this.Controls.Add(this.txtRepeat5);
            this.Controls.Add(this.cbxUnit5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpStartTime5);
            this.Controls.Add(this.chkT4);
            this.Controls.Add(this.txtRepeat4);
            this.Controls.Add(this.cbxUnit4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpStartTime4);
            this.Controls.Add(this.chkT3);
            this.Controls.Add(this.txtRepeat3);
            this.Controls.Add(this.cbxUnit3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpStartTime3);
            this.Controls.Add(this.chkT2);
            this.Controls.Add(this.txtRepeat2);
            this.Controls.Add(this.cbxUnit2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpStartTime2);
            this.Controls.Add(this.chkT1);
            this.Controls.Add(this.txtRepeat1);
            this.Controls.Add(this.cbxUnit1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpStartTime1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInerval);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTaskTimerDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmTaskTimerDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInerval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStartTime1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxUnit1;
        private System.Windows.Forms.TextBox txtRepeat1;
        private System.Windows.Forms.CheckBox chkT1;
        private System.Windows.Forms.CheckBox chkT2;
        private System.Windows.Forms.TextBox txtRepeat2;
        private System.Windows.Forms.ComboBox cbxUnit2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStartTime2;
        private System.Windows.Forms.CheckBox chkT3;
        private System.Windows.Forms.TextBox txtRepeat3;
        private System.Windows.Forms.ComboBox cbxUnit3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpStartTime3;
        private System.Windows.Forms.CheckBox chkT4;
        private System.Windows.Forms.TextBox txtRepeat4;
        private System.Windows.Forms.ComboBox cbxUnit4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpStartTime4;
        private System.Windows.Forms.CheckBox chkT5;
        private System.Windows.Forms.TextBox txtRepeat5;
        private System.Windows.Forms.ComboBox cbxUnit5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpStartTime5;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.Button butCancel;
    }
}