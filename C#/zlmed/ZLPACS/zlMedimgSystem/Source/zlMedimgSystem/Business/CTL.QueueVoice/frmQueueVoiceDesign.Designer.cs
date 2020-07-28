namespace zlMedimgSystem.CTL.QueueVoice
{
    partial class frmQueueVoiceDesign
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbxVoiceName = new System.Windows.Forms.ComboBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlayCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.chkPlayHintSound = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "播放语速";
            // 
            // cbxVoiceName
            // 
            this.cbxVoiceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVoiceName.FormattingEnabled = true;
            this.cbxVoiceName.Location = new System.Drawing.Point(71, 22);
            this.cbxVoiceName.Name = "cbxVoiceName";
            this.cbxVoiceName.Size = new System.Drawing.Size(318, 20);
            this.cbxVoiceName.TabIndex = 7;
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(71, 48);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(54, 21);
            this.txtRate.TabIndex = 8;
            this.txtRate.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "语音名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "播放次数";
            // 
            // txtPlayCount
            // 
            this.txtPlayCount.Location = new System.Drawing.Point(190, 48);
            this.txtPlayCount.Name = "txtPlayCount";
            this.txtPlayCount.Size = new System.Drawing.Size(54, 21);
            this.txtPlayCount.TabIndex = 10;
            this.txtPlayCount.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "轮询间隔";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(314, 48);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(54, 21);
            this.txtInterval.TabIndex = 12;
            this.txtInterval.Text = "5";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(314, 93);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 102;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(233, 93);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 101;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(372, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 103;
            this.label5.Text = "秒";
            // 
            // chkPlayHintSound
            // 
            this.chkPlayHintSound.AutoSize = true;
            this.chkPlayHintSound.Location = new System.Drawing.Point(71, 75);
            this.chkPlayHintSound.Name = "chkPlayHintSound";
            this.chkPlayHintSound.Size = new System.Drawing.Size(84, 16);
            this.chkPlayHintSound.TabIndex = 104;
            this.chkPlayHintSound.Text = "播放提示音";
            this.chkPlayHintSound.UseVisualStyleBackColor = true;
            // 
            // frmQueueVoiceDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 128);
            this.Controls.Add(this.chkPlayHintSound);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPlayCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxVoiceName);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQueueVoiceDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmQueueVoiceDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxVoiceName;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlayCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkPlayHintSound;
    }
}