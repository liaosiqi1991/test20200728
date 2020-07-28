namespace zlMedimgSystem.CTL.Btn
{
    partial class frmBtnDesign
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
            this.txtDesplay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxIconPostion = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtImgName = new System.Windows.Forms.TextBox();
            this.butLoadImg = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.cbxStyle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkReponse = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.feFontStyle = new zlMedimgSystem.BusinessBase.Controls.FontEditor();
            this.labForeColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.labBkColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.txtButTag = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "显示文本";
            // 
            // txtDesplay
            // 
            this.txtDesplay.Location = new System.Drawing.Point(88, 15);
            this.txtDesplay.Name = "txtDesplay";
            this.txtDesplay.Size = new System.Drawing.Size(193, 21);
            this.txtDesplay.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 68;
            this.label7.Text = "前景色";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 67;
            this.label6.Text = "背景色";
            // 
            // cbxIconPostion
            // 
            this.cbxIconPostion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIconPostion.FormattingEnabled = true;
            this.cbxIconPostion.Items.AddRange(new object[] {
            "文本上部",
            "文本下部",
            "文本左侧",
            "文本右侧"});
            this.cbxIconPostion.Location = new System.Drawing.Point(88, 95);
            this.cbxIconPostion.Name = "cbxIconPostion";
            this.cbxIconPostion.Size = new System.Drawing.Size(193, 20);
            this.cbxIconPostion.TabIndex = 66;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 65;
            this.label11.Text = "图标位置";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 59;
            this.label10.Text = "图标名称";
            // 
            // txtImgName
            // 
            this.txtImgName.Location = new System.Drawing.Point(88, 42);
            this.txtImgName.Name = "txtImgName";
            this.txtImgName.Size = new System.Drawing.Size(171, 21);
            this.txtImgName.TabIndex = 58;
            // 
            // butLoadImg
            // 
            this.butLoadImg.Location = new System.Drawing.Point(257, 41);
            this.butLoadImg.Name = "butLoadImg";
            this.butLoadImg.Size = new System.Drawing.Size(24, 23);
            this.butLoadImg.TabIndex = 60;
            this.butLoadImg.Text = "…";
            this.butLoadImg.UseVisualStyleBackColor = true;
            this.butLoadImg.Click += new System.EventHandler(this.butLoadImg_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(206, 310);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 74;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(125, 310);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 73;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // cbxStyle
            // 
            this.cbxStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStyle.FormattingEnabled = true;
            this.cbxStyle.Items.AddRange(new object[] {
            "默认样式",
            "简单样式",
            "平面样式"});
            this.cbxStyle.Location = new System.Drawing.Point(88, 69);
            this.cbxStyle.Name = "cbxStyle";
            this.cbxStyle.Size = new System.Drawing.Size(193, 20);
            this.cbxStyle.TabIndex = 76;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 75;
            this.label2.Text = "按钮样式";
            // 
            // chkReponse
            // 
            this.chkReponse.AutoSize = true;
            this.chkReponse.Location = new System.Drawing.Point(88, 283);
            this.chkReponse.Name = "chkReponse";
            this.chkReponse.Size = new System.Drawing.Size(72, 16);
            this.chkReponse.TabIndex = 79;
            this.chkReponse.Text = "点击反馈";
            this.chkReponse.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 159;
            this.label3.Text = "字体样式";
            // 
            // feFontStyle
            // 
            this.feFontStyle.BackColor = System.Drawing.Color.White;
            this.feFontStyle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.feFontStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.feFontStyle.Location = new System.Drawing.Point(88, 177);
            this.feFontStyle.Name = "feFontStyle";
            this.feFontStyle.Size = new System.Drawing.Size(193, 73);
            this.feFontStyle.TabIndex = 158;
            this.feFontStyle.Value = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // labForeColor
            // 
            this.labForeColor.BackColor = System.Drawing.Color.White;
            this.labForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labForeColor.Color = System.Drawing.Color.Empty;
            this.labForeColor.Location = new System.Drawing.Point(88, 149);
            this.labForeColor.Name = "labForeColor";
            this.labForeColor.Size = new System.Drawing.Size(193, 22);
            this.labForeColor.TabIndex = 78;
            // 
            // labBkColor
            // 
            this.labBkColor.BackColor = System.Drawing.Color.White;
            this.labBkColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labBkColor.Color = System.Drawing.Color.Empty;
            this.labBkColor.Location = new System.Drawing.Point(88, 121);
            this.labBkColor.Name = "labBkColor";
            this.labBkColor.Size = new System.Drawing.Size(193, 22);
            this.labBkColor.TabIndex = 77;
            // 
            // txtButTag
            // 
            this.txtButTag.Location = new System.Drawing.Point(88, 256);
            this.txtButTag.Name = "txtButTag";
            this.txtButTag.Size = new System.Drawing.Size(193, 21);
            this.txtButTag.TabIndex = 161;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 160;
            this.label4.Text = "按钮标记";
            // 
            // frmBtnDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 361);
            this.Controls.Add(this.txtButTag);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.feFontStyle);
            this.Controls.Add(this.chkReponse);
            this.Controls.Add(this.labForeColor);
            this.Controls.Add(this.labBkColor);
            this.Controls.Add(this.cbxStyle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxIconPostion);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtImgName);
            this.Controls.Add(this.butLoadImg);
            this.Controls.Add(this.txtDesplay);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBtnDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmBtnDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesplay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxIconPostion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtImgName;
        private System.Windows.Forms.Button butLoadImg;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.ComboBox cbxStyle;
        private System.Windows.Forms.Label label2;
        private BusinessBase.Controls.ColorEditor labBkColor;
        private BusinessBase.Controls.ColorEditor labForeColor;
        private System.Windows.Forms.CheckBox chkReponse;
        private BusinessBase.Controls.FontEditor feFontStyle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtButTag;
        private System.Windows.Forms.Label label4;
    }
}