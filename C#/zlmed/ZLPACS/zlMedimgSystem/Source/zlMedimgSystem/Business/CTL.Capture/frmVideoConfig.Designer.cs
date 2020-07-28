namespace zlMedimgSystem.CTL.Capture
{
    partial class frmVideoConfig
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
            this.cbxInput = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.cbxResolution = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxDevName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSoundHint = new System.Windows.Forms.CheckBox();
            this.chkPopupHint = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxFrameRate = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxEncode = new System.Windows.Forms.ComboBox();
            this.chkRecordDatetime = new System.Windows.Forms.CheckBox();
            this.butAdvice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxInput
            // 
            this.cbxInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInput.FormattingEnabled = true;
            this.cbxInput.Location = new System.Drawing.Point(81, 68);
            this.cbxInput.Name = "cbxInput";
            this.cbxInput.Size = new System.Drawing.Size(215, 20);
            this.cbxInput.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "输入端口";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(221, 187);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 7;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(140, 187);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 6;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // cbxResolution
            // 
            this.cbxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxResolution.FormattingEnabled = true;
            this.cbxResolution.Location = new System.Drawing.Point(81, 42);
            this.cbxResolution.Name = "cbxResolution";
            this.cbxResolution.Size = new System.Drawing.Size(215, 20);
            this.cbxResolution.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "分辨率";
            // 
            // cbxDevName
            // 
            this.cbxDevName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDevName.FormattingEnabled = true;
            this.cbxDevName.Location = new System.Drawing.Point(81, 16);
            this.cbxDevName.Name = "cbxDevName";
            this.cbxDevName.Size = new System.Drawing.Size(215, 20);
            this.cbxDevName.TabIndex = 1;
            this.cbxDevName.SelectedIndexChanged += new System.EventHandler(this.cbxDevName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "设备名称";
            // 
            // chkSoundHint
            // 
            this.chkSoundHint.AutoSize = true;
            this.chkSoundHint.Location = new System.Drawing.Point(78, 153);
            this.chkSoundHint.Name = "chkSoundHint";
            this.chkSoundHint.Size = new System.Drawing.Size(72, 16);
            this.chkSoundHint.TabIndex = 4;
            this.chkSoundHint.Text = "声音提示";
            this.chkSoundHint.UseVisualStyleBackColor = true;
            // 
            // chkPopupHint
            // 
            this.chkPopupHint.AutoSize = true;
            this.chkPopupHint.Location = new System.Drawing.Point(149, 153);
            this.chkPopupHint.Name = "chkPopupHint";
            this.chkPopupHint.Size = new System.Drawing.Size(72, 16);
            this.chkPopupHint.TabIndex = 5;
            this.chkPopupHint.Text = "弹窗提示";
            this.chkPopupHint.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "录制帧率";
            // 
            // cbxFrameRate
            // 
            this.cbxFrameRate.FormattingEnabled = true;
            this.cbxFrameRate.Items.AddRange(new object[] {
            "10",
            "20",
            "30"});
            this.cbxFrameRate.Location = new System.Drawing.Point(81, 120);
            this.cbxFrameRate.Name = "cbxFrameRate";
            this.cbxFrameRate.Size = new System.Drawing.Size(215, 20);
            this.cbxFrameRate.TabIndex = 17;
            this.cbxFrameRate.Text = "20";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 16;
            this.label11.Text = "视频编码";
            // 
            // cbxEncode
            // 
            this.cbxEncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEncode.FormattingEnabled = true;
            this.cbxEncode.Location = new System.Drawing.Point(81, 94);
            this.cbxEncode.Name = "cbxEncode";
            this.cbxEncode.Size = new System.Drawing.Size(215, 20);
            this.cbxEncode.TabIndex = 4;
            // 
            // chkRecordDatetime
            // 
            this.chkRecordDatetime.AutoSize = true;
            this.chkRecordDatetime.Location = new System.Drawing.Point(221, 153);
            this.chkRecordDatetime.Name = "chkRecordDatetime";
            this.chkRecordDatetime.Size = new System.Drawing.Size(72, 16);
            this.chkRecordDatetime.TabIndex = 23;
            this.chkRecordDatetime.Text = "录制日期";
            this.chkRecordDatetime.UseVisualStyleBackColor = true;
            // 
            // butAdvice
            // 
            this.butAdvice.Location = new System.Drawing.Point(12, 187);
            this.butAdvice.Name = "butAdvice";
            this.butAdvice.Size = new System.Drawing.Size(75, 23);
            this.butAdvice.TabIndex = 24;
            this.butAdvice.Text = "高级(&A)";
            this.butAdvice.UseVisualStyleBackColor = true;
            this.butAdvice.Click += new System.EventHandler(this.butAdvice_Click);
            // 
            // frmVideoConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 231);
            this.Controls.Add(this.butAdvice);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chkRecordDatetime);
            this.Controls.Add(this.cbxFrameRate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.cbxEncode);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.cbxResolution);
            this.Controls.Add(this.chkPopupHint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxDevName);
            this.Controls.Add(this.chkSoundHint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxInput);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVideoConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数设置";
            this.Load += new System.EventHandler(this.frmVideoConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.ComboBox cbxResolution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxDevName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSoundHint;
        private System.Windows.Forms.CheckBox chkPopupHint;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxEncode;
        private System.Windows.Forms.CheckBox chkRecordDatetime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbxFrameRate;
        private System.Windows.Forms.Button butAdvice;
    }
}