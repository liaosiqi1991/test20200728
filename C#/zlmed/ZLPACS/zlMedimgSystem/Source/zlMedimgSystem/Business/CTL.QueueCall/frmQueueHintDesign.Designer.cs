namespace zlMedimgSystem.CTL.QueueHint
{
    partial class frmQueueHintDesign
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtImgName = new System.Windows.Forms.TextBox();
            this.butLoadImg = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxHeadDockWay = new System.Windows.Forms.ComboBox();
            this.chkShowTitle = new System.Windows.Forms.CheckBox();
            this.chkUseRoomReleation = new System.Windows.Forms.CheckBox();
            this.cbxReleationQueue = new System.Windows.Forms.CheckedListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.ceTxtForeColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.ceHeadForeColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.ceTxtBkColor2 = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.ceHeadBkColor2 = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.ceTxtBkColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.ceHeadBkColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.feHeadFont = new zlMedimgSystem.BusinessBase.Controls.FontEditor();
            this.feTxtFont = new zlMedimgSystem.BusinessBase.Controls.FontEditor();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 107;
            this.label3.Text = "标题字体";
            // 
            // txtImgName
            // 
            this.txtImgName.Location = new System.Drawing.Point(95, 12);
            this.txtImgName.Name = "txtImgName";
            this.txtImgName.Size = new System.Drawing.Size(293, 21);
            this.txtImgName.TabIndex = 99;
            // 
            // butLoadImg
            // 
            this.butLoadImg.Location = new System.Drawing.Point(390, 12);
            this.butLoadImg.Name = "butLoadImg";
            this.butLoadImg.Size = new System.Drawing.Size(24, 23);
            this.butLoadImg.TabIndex = 100;
            this.butLoadImg.Text = "…";
            this.butLoadImg.UseVisualStyleBackColor = true;
            this.butLoadImg.Click += new System.EventHandler(this.butLoadImg_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(211, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 102;
            this.label7.Text = "标题前景色";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 101;
            this.label6.Text = "标题背景色";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 98;
            this.label1.Text = "背景图片";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(238, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 112;
            this.label8.Text = "对齐方式";
            // 
            // cbxHeadDockWay
            // 
            this.cbxHeadDockWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHeadDockWay.FormattingEnabled = true;
            this.cbxHeadDockWay.Items.AddRange(new object[] {
            "顶部对齐",
            "左对齐",
            "右对齐",
            "底部对齐"});
            this.cbxHeadDockWay.Location = new System.Drawing.Point(297, 37);
            this.cbxHeadDockWay.Name = "cbxHeadDockWay";
            this.cbxHeadDockWay.Size = new System.Drawing.Size(91, 20);
            this.cbxHeadDockWay.TabIndex = 113;
            // 
            // chkShowTitle
            // 
            this.chkShowTitle.AutoSize = true;
            this.chkShowTitle.Location = new System.Drawing.Point(17, 39);
            this.chkShowTitle.Name = "chkShowTitle";
            this.chkShowTitle.Size = new System.Drawing.Size(72, 16);
            this.chkShowTitle.TabIndex = 114;
            this.chkShowTitle.Text = "显示标题";
            this.chkShowTitle.UseVisualStyleBackColor = true;
            // 
            // chkUseRoomReleation
            // 
            this.chkUseRoomReleation.AutoSize = true;
            this.chkUseRoomReleation.Location = new System.Drawing.Point(95, 422);
            this.chkUseRoomReleation.Name = "chkUseRoomReleation";
            this.chkUseRoomReleation.Size = new System.Drawing.Size(144, 16);
            this.chkUseRoomReleation.TabIndex = 115;
            this.chkUseRoomReleation.Text = "队列根据房间自动关联";
            this.chkUseRoomReleation.UseVisualStyleBackColor = true;
            // 
            // cbxReleationQueue
            // 
            this.cbxReleationQueue.FormattingEnabled = true;
            this.cbxReleationQueue.Location = new System.Drawing.Point(95, 269);
            this.cbxReleationQueue.Name = "cbxReleationQueue";
            this.cbxReleationQueue.Size = new System.Drawing.Size(293, 148);
            this.cbxReleationQueue.TabIndex = 116;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(211, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 118;
            this.label12.Text = "文本前景色";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 117;
            this.label13.Text = "文本背景色";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 123;
            this.label5.Text = "文本字体";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(95, 36);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(110, 21);
            this.txtTitle.TabIndex = 126;
            this.txtTitle.Text = "当前呼叫";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 127;
            this.label2.Text = "关联队列";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(313, 443);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 129;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(232, 443);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 128;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // ceTxtForeColor
            // 
            this.ceTxtForeColor.BackColor = System.Drawing.Color.White;
            this.ceTxtForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceTxtForeColor.Color = System.Drawing.Color.Empty;
            this.ceTxtForeColor.Location = new System.Drawing.Point(282, 92);
            this.ceTxtForeColor.Name = "ceTxtForeColor";
            this.ceTxtForeColor.Size = new System.Drawing.Size(106, 18);
            this.ceTxtForeColor.TabIndex = 147;
            // 
            // ceHeadForeColor
            // 
            this.ceHeadForeColor.BackColor = System.Drawing.Color.White;
            this.ceHeadForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceHeadForeColor.Color = System.Drawing.Color.Empty;
            this.ceHeadForeColor.Location = new System.Drawing.Point(282, 63);
            this.ceHeadForeColor.Name = "ceHeadForeColor";
            this.ceHeadForeColor.Size = new System.Drawing.Size(106, 18);
            this.ceHeadForeColor.TabIndex = 146;
            // 
            // ceTxtBkColor2
            // 
            this.ceTxtBkColor2.BackColor = System.Drawing.Color.White;
            this.ceTxtBkColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceTxtBkColor2.Color = System.Drawing.Color.Empty;
            this.ceTxtBkColor2.Location = new System.Drawing.Point(152, 92);
            this.ceTxtBkColor2.Name = "ceTxtBkColor2";
            this.ceTxtBkColor2.Size = new System.Drawing.Size(51, 18);
            this.ceTxtBkColor2.TabIndex = 145;
            // 
            // ceHeadBkColor2
            // 
            this.ceHeadBkColor2.BackColor = System.Drawing.Color.White;
            this.ceHeadBkColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceHeadBkColor2.Color = System.Drawing.Color.Empty;
            this.ceHeadBkColor2.Location = new System.Drawing.Point(152, 63);
            this.ceHeadBkColor2.Name = "ceHeadBkColor2";
            this.ceHeadBkColor2.Size = new System.Drawing.Size(51, 18);
            this.ceHeadBkColor2.TabIndex = 144;
            // 
            // ceTxtBkColor
            // 
            this.ceTxtBkColor.BackColor = System.Drawing.Color.White;
            this.ceTxtBkColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceTxtBkColor.Color = System.Drawing.Color.Empty;
            this.ceTxtBkColor.Location = new System.Drawing.Point(95, 92);
            this.ceTxtBkColor.Name = "ceTxtBkColor";
            this.ceTxtBkColor.Size = new System.Drawing.Size(51, 18);
            this.ceTxtBkColor.TabIndex = 143;
            // 
            // ceHeadBkColor
            // 
            this.ceHeadBkColor.BackColor = System.Drawing.Color.White;
            this.ceHeadBkColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceHeadBkColor.Color = System.Drawing.Color.Empty;
            this.ceHeadBkColor.Location = new System.Drawing.Point(95, 63);
            this.ceHeadBkColor.Name = "ceHeadBkColor";
            this.ceHeadBkColor.Size = new System.Drawing.Size(51, 18);
            this.ceHeadBkColor.TabIndex = 142;
            // 
            // feHeadFont
            // 
            this.feHeadFont.BackColor = System.Drawing.Color.White;
            this.feHeadFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.feHeadFont.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.feHeadFont.Location = new System.Drawing.Point(95, 116);
            this.feHeadFont.Name = "feHeadFont";
            this.feHeadFont.Size = new System.Drawing.Size(293, 70);
            this.feHeadFont.TabIndex = 148;
            this.feHeadFont.Value = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // feTxtFont
            // 
            this.feTxtFont.BackColor = System.Drawing.Color.White;
            this.feTxtFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.feTxtFont.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.feTxtFont.Location = new System.Drawing.Point(95, 192);
            this.feTxtFont.Name = "feTxtFont";
            this.feTxtFont.Size = new System.Drawing.Size(293, 70);
            this.feTxtFont.TabIndex = 149;
            this.feTxtFont.Value = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // frmQueueHintDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 489);
            this.Controls.Add(this.feTxtFont);
            this.Controls.Add(this.feHeadFont);
            this.Controls.Add(this.ceTxtForeColor);
            this.Controls.Add(this.ceHeadForeColor);
            this.Controls.Add(this.ceTxtBkColor2);
            this.Controls.Add(this.ceHeadBkColor2);
            this.Controls.Add(this.ceTxtBkColor);
            this.Controls.Add(this.ceHeadBkColor);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbxReleationQueue);
            this.Controls.Add(this.chkUseRoomReleation);
            this.Controls.Add(this.chkShowTitle);
            this.Controls.Add(this.cbxHeadDockWay);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtImgName);
            this.Controls.Add(this.butLoadImg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQueueHintDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmQueueCallDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImgName;
        private System.Windows.Forms.Button butLoadImg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxHeadDockWay;
        private System.Windows.Forms.CheckBox chkShowTitle;
        private System.Windows.Forms.CheckBox chkUseRoomReleation;
        private System.Windows.Forms.CheckedListBox cbxReleationQueue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private BusinessBase.Controls.ColorEditor ceHeadBkColor;
        private BusinessBase.Controls.ColorEditor ceTxtBkColor;
        private BusinessBase.Controls.ColorEditor ceHeadBkColor2;
        private BusinessBase.Controls.ColorEditor ceTxtBkColor2;
        private BusinessBase.Controls.ColorEditor ceHeadForeColor;
        private BusinessBase.Controls.ColorEditor ceTxtForeColor;
        private BusinessBase.Controls.FontEditor feHeadFont;
        private BusinessBase.Controls.FontEditor feTxtFont;
    }
}