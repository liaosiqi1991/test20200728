namespace zlMedimgSystem.CTL.QueueShow
{
    partial class frmQueueShowDesign
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
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImgName = new System.Windows.Forms.TextBox();
            this.butLoadImg = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWaitCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtC1Width = new System.Windows.Forms.TextBox();
            this.txtC2Width = new System.Windows.Forms.TextBox();
            this.txtC3Width = new System.Windows.Forms.TextBox();
            this.chkShowMemo = new System.Windows.Forms.CheckBox();
            this.chkShowLastCall = new System.Windows.Forms.CheckBox();
            this.chkCallIcon = new System.Windows.Forms.CheckBox();
            this.chkQueueIcon = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxReleationQueue = new System.Windows.Forms.CheckedListBox();
            this.chkUseRoomReleation = new System.Windows.Forms.CheckBox();
            this.ceBackColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.ceForeColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.feHeadFont = new zlMedimgSystem.BusinessBase.Controls.FontEditor();
            this.feQueueFont = new zlMedimgSystem.BusinessBase.Controls.FontEditor();
            this.SuspendLayout();
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(278, 491);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 100;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(197, 491);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 99;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 95;
            this.label3.Text = "行头字体";
            // 
            // txtImgName
            // 
            this.txtImgName.Location = new System.Drawing.Point(71, 6);
            this.txtImgName.Name = "txtImgName";
            this.txtImgName.Size = new System.Drawing.Size(282, 21);
            this.txtImgName.TabIndex = 85;
            // 
            // butLoadImg
            // 
            this.butLoadImg.Location = new System.Drawing.Point(359, 5);
            this.butLoadImg.Name = "butLoadImg";
            this.butLoadImg.Size = new System.Drawing.Size(24, 23);
            this.butLoadImg.TabIndex = 86;
            this.butLoadImg.Text = "…";
            this.butLoadImg.UseVisualStyleBackColor = true;
            this.butLoadImg.Click += new System.EventHandler(this.butLoadImg_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 88;
            this.label7.Text = "前景色";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 87;
            this.label6.Text = "背景色";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 84;
            this.label1.Text = "背景图片";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 110;
            this.label2.Text = "候诊人数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 112;
            this.label4.Text = "队列字体";
            // 
            // txtWaitCount
            // 
            this.txtWaitCount.Location = new System.Drawing.Point(71, 237);
            this.txtWaitCount.MaxLength = 1;
            this.txtWaitCount.Name = "txtWaitCount";
            this.txtWaitCount.Size = new System.Drawing.Size(282, 21);
            this.txtWaitCount.TabIndex = 115;
            this.txtWaitCount.Text = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 408);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 116;
            this.label5.Text = "列1宽度";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 408);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 117;
            this.label8.Text = "列2宽度";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(265, 408);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 118;
            this.label9.Text = "列3宽度";
            // 
            // txtC1Width
            // 
            this.txtC1Width.Location = new System.Drawing.Point(122, 405);
            this.txtC1Width.MaxLength = 4;
            this.txtC1Width.Name = "txtC1Width";
            this.txtC1Width.Size = new System.Drawing.Size(35, 21);
            this.txtC1Width.TabIndex = 119;
            this.txtC1Width.Tag = " ";
            this.txtC1Width.Text = "200";
            // 
            // txtC2Width
            // 
            this.txtC2Width.Location = new System.Drawing.Point(220, 405);
            this.txtC2Width.MaxLength = 4;
            this.txtC2Width.Name = "txtC2Width";
            this.txtC2Width.Size = new System.Drawing.Size(35, 21);
            this.txtC2Width.TabIndex = 120;
            this.txtC2Width.Tag = " ";
            this.txtC2Width.Text = "200";
            // 
            // txtC3Width
            // 
            this.txtC3Width.Location = new System.Drawing.Point(318, 405);
            this.txtC3Width.MaxLength = 4;
            this.txtC3Width.Name = "txtC3Width";
            this.txtC3Width.Size = new System.Drawing.Size(35, 21);
            this.txtC3Width.TabIndex = 121;
            this.txtC3Width.Tag = " ";
            this.txtC3Width.Text = "0";
            // 
            // chkShowMemo
            // 
            this.chkShowMemo.AutoSize = true;
            this.chkShowMemo.Location = new System.Drawing.Point(71, 438);
            this.chkShowMemo.Name = "chkShowMemo";
            this.chkShowMemo.Size = new System.Drawing.Size(72, 16);
            this.chkShowMemo.TabIndex = 122;
            this.chkShowMemo.Text = "显示备注";
            this.chkShowMemo.UseVisualStyleBackColor = true;
            // 
            // chkShowLastCall
            // 
            this.chkShowLastCall.AutoSize = true;
            this.chkShowLastCall.Location = new System.Drawing.Point(185, 438);
            this.chkShowLastCall.Name = "chkShowLastCall";
            this.chkShowLastCall.Size = new System.Drawing.Size(96, 16);
            this.chkShowLastCall.TabIndex = 123;
            this.chkShowLastCall.Text = "显示最后呼叫";
            this.chkShowLastCall.UseVisualStyleBackColor = true;
            // 
            // chkCallIcon
            // 
            this.chkCallIcon.AutoSize = true;
            this.chkCallIcon.Location = new System.Drawing.Point(71, 460);
            this.chkCallIcon.Name = "chkCallIcon";
            this.chkCallIcon.Size = new System.Drawing.Size(96, 16);
            this.chkCallIcon.TabIndex = 124;
            this.chkCallIcon.Text = "显示呼叫图标";
            this.chkCallIcon.UseVisualStyleBackColor = true;
            // 
            // chkQueueIcon
            // 
            this.chkQueueIcon.AutoSize = true;
            this.chkQueueIcon.Location = new System.Drawing.Point(185, 460);
            this.chkQueueIcon.Name = "chkQueueIcon";
            this.chkQueueIcon.Size = new System.Drawing.Size(96, 16);
            this.chkQueueIcon.TabIndex = 125;
            this.chkQueueIcon.Text = "显示排队图标";
            this.chkQueueIcon.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 264);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 130;
            this.label10.Text = "关联队列";
            // 
            // cbxReleationQueue
            // 
            this.cbxReleationQueue.FormattingEnabled = true;
            this.cbxReleationQueue.Location = new System.Drawing.Point(72, 264);
            this.cbxReleationQueue.Name = "cbxReleationQueue";
            this.cbxReleationQueue.Size = new System.Drawing.Size(281, 116);
            this.cbxReleationQueue.TabIndex = 129;
            // 
            // chkUseRoomReleation
            // 
            this.chkUseRoomReleation.AutoSize = true;
            this.chkUseRoomReleation.Location = new System.Drawing.Point(72, 382);
            this.chkUseRoomReleation.Name = "chkUseRoomReleation";
            this.chkUseRoomReleation.Size = new System.Drawing.Size(144, 16);
            this.chkUseRoomReleation.TabIndex = 128;
            this.chkUseRoomReleation.Text = "队列根据房间自动关联";
            this.chkUseRoomReleation.UseVisualStyleBackColor = true;
            // 
            // ceBackColor
            // 
            this.ceBackColor.BackColor = System.Drawing.Color.White;
            this.ceBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceBackColor.Color = System.Drawing.Color.Empty;
            this.ceBackColor.Location = new System.Drawing.Point(71, 33);
            this.ceBackColor.Name = "ceBackColor";
            this.ceBackColor.Size = new System.Drawing.Size(282, 18);
            this.ceBackColor.TabIndex = 131;
            // 
            // ceForeColor
            // 
            this.ceForeColor.BackColor = System.Drawing.Color.White;
            this.ceForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceForeColor.Color = System.Drawing.Color.Empty;
            this.ceForeColor.Location = new System.Drawing.Point(71, 59);
            this.ceForeColor.Name = "ceForeColor";
            this.ceForeColor.Size = new System.Drawing.Size(282, 18);
            this.ceForeColor.TabIndex = 132;
            // 
            // feHeadFont
            // 
            this.feHeadFont.BackColor = System.Drawing.Color.White;
            this.feHeadFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.feHeadFont.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.feHeadFont.Location = new System.Drawing.Point(71, 83);
            this.feHeadFont.Name = "feHeadFont";
            this.feHeadFont.Size = new System.Drawing.Size(282, 71);
            this.feHeadFont.TabIndex = 133;
            this.feHeadFont.Value = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // feQueueFont
            // 
            this.feQueueFont.BackColor = System.Drawing.Color.White;
            this.feQueueFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.feQueueFont.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.feQueueFont.Location = new System.Drawing.Point(72, 160);
            this.feQueueFont.Name = "feQueueFont";
            this.feQueueFont.Size = new System.Drawing.Size(282, 71);
            this.feQueueFont.TabIndex = 134;
            this.feQueueFont.Value = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // frmQueueShowDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 530);
            this.Controls.Add(this.feQueueFont);
            this.Controls.Add(this.feHeadFont);
            this.Controls.Add(this.ceForeColor);
            this.Controls.Add(this.ceBackColor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbxReleationQueue);
            this.Controls.Add(this.chkUseRoomReleation);
            this.Controls.Add(this.chkQueueIcon);
            this.Controls.Add(this.chkCallIcon);
            this.Controls.Add(this.chkShowLastCall);
            this.Controls.Add(this.chkShowMemo);
            this.Controls.Add(this.txtC3Width);
            this.Controls.Add(this.txtC2Width);
            this.Controls.Add(this.txtC1Width);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWaitCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtImgName);
            this.Controls.Add(this.butLoadImg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQueueShowDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmQueueShowDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImgName;
        private System.Windows.Forms.Button butLoadImg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWaitCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtC1Width;
        private System.Windows.Forms.TextBox txtC2Width;
        private System.Windows.Forms.TextBox txtC3Width;
        private System.Windows.Forms.CheckBox chkShowMemo;
        private System.Windows.Forms.CheckBox chkShowLastCall;
        private System.Windows.Forms.CheckBox chkCallIcon;
        private System.Windows.Forms.CheckBox chkQueueIcon;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox cbxReleationQueue;
        private System.Windows.Forms.CheckBox chkUseRoomReleation;
        private BusinessBase.Controls.ColorEditor ceBackColor;
        private BusinessBase.Controls.ColorEditor ceForeColor;
        private BusinessBase.Controls.FontEditor feHeadFont;
        private BusinessBase.Controls.FontEditor feQueueFont;
    }
}