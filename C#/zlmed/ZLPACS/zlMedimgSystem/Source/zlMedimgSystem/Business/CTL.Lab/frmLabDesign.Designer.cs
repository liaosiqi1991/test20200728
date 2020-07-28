namespace zlMedimgSystem.CTL.Lab
{
    partial class frmLabDesign
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
            this.label10 = new System.Windows.Forms.Label();
            this.cbxImagePostion = new System.Windows.Forms.ComboBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbDisplayText = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIconName = new System.Windows.Forms.TextBox();
            this.butLoadImg = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxTextPostion = new System.Windows.Forms.ComboBox();
            this.txtBackgroundImage = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxBkgroundLayout = new System.Windows.Forms.ComboBox();
            this.chkDrag = new System.Windows.Forms.CheckBox();
            this.feSetting = new zlMedimgSystem.BusinessBase.Controls.FontEditor();
            this.ceForeColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.ceBackColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 108;
            this.label10.Text = "图标位置";
            // 
            // cbxImagePostion
            // 
            this.cbxImagePostion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxImagePostion.FormattingEnabled = true;
            this.cbxImagePostion.Items.AddRange(new object[] {
            "顶端",
            "左侧",
            "右侧",
            "底部",
            "居中"});
            this.cbxImagePostion.Location = new System.Drawing.Point(71, 92);
            this.cbxImagePostion.Name = "cbxImagePostion";
            this.cbxImagePostion.Size = new System.Drawing.Size(282, 20);
            this.cbxImagePostion.TabIndex = 107;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(278, 395);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 100;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(197, 395);
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
            this.label3.Location = new System.Drawing.Point(11, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 95;
            this.label3.Text = "字体设置";
            // 
            // rtbDisplayText
            // 
            this.rtbDisplayText.Location = new System.Drawing.Point(71, 244);
            this.rtbDisplayText.Name = "rtbDisplayText";
            this.rtbDisplayText.Size = new System.Drawing.Size(282, 89);
            this.rtbDisplayText.TabIndex = 94;
            this.rtbDisplayText.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 93;
            this.label2.Text = "标签内容";
            // 
            // txtIconName
            // 
            this.txtIconName.Location = new System.Drawing.Point(71, 65);
            this.txtIconName.Name = "txtIconName";
            this.txtIconName.Size = new System.Drawing.Size(282, 21);
            this.txtIconName.TabIndex = 85;
            // 
            // butLoadImg
            // 
            this.butLoadImg.Location = new System.Drawing.Point(359, 64);
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
            this.label7.Location = new System.Drawing.Point(24, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 88;
            this.label7.Text = "前景色";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 87;
            this.label6.Text = "背景色";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 84;
            this.label1.Text = "文本图标";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 111;
            this.label4.Text = "文本位置";
            // 
            // cbxTextPostion
            // 
            this.cbxTextPostion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTextPostion.FormattingEnabled = true;
            this.cbxTextPostion.Items.AddRange(new object[] {
            "顶端",
            "左侧",
            "右侧",
            "底部",
            "居中"});
            this.cbxTextPostion.Location = new System.Drawing.Point(71, 339);
            this.cbxTextPostion.Name = "cbxTextPostion";
            this.cbxTextPostion.Size = new System.Drawing.Size(282, 20);
            this.cbxTextPostion.TabIndex = 110;
            // 
            // txtBackgroundImage
            // 
            this.txtBackgroundImage.Location = new System.Drawing.Point(71, 12);
            this.txtBackgroundImage.Name = "txtBackgroundImage";
            this.txtBackgroundImage.Size = new System.Drawing.Size(282, 21);
            this.txtBackgroundImage.TabIndex = 113;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 114;
            this.button1.Text = "…";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 112;
            this.label5.Text = "背景图片";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 116;
            this.label8.Text = "背景样式";
            // 
            // cbxBkgroundLayout
            // 
            this.cbxBkgroundLayout.FormattingEnabled = true;
            this.cbxBkgroundLayout.Items.AddRange(new object[] {
            "正常",
            "贴图",
            "居中",
            "填充",
            "缩放"});
            this.cbxBkgroundLayout.Location = new System.Drawing.Point(71, 39);
            this.cbxBkgroundLayout.Name = "cbxBkgroundLayout";
            this.cbxBkgroundLayout.Size = new System.Drawing.Size(282, 20);
            this.cbxBkgroundLayout.TabIndex = 115;
            // 
            // chkDrag
            // 
            this.chkDrag.AutoSize = true;
            this.chkDrag.Location = new System.Drawing.Point(71, 365);
            this.chkDrag.Name = "chkDrag";
            this.chkDrag.Size = new System.Drawing.Size(72, 16);
            this.chkDrag.TabIndex = 117;
            this.chkDrag.Text = "启用拖拽";
            this.chkDrag.UseVisualStyleBackColor = true;
            // 
            // feSetting
            // 
            this.feSetting.BackColor = System.Drawing.Color.White;
            this.feSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.feSetting.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.feSetting.Location = new System.Drawing.Point(71, 167);
            this.feSetting.Name = "feSetting";
            this.feSetting.Size = new System.Drawing.Size(280, 71);
            this.feSetting.TabIndex = 124;
            this.feSetting.Value = new System.Drawing.Font("宋体", 9F);
            // 
            // ceForeColor
            // 
            this.ceForeColor.BackColor = System.Drawing.Color.White;
            this.ceForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceForeColor.Color = System.Drawing.Color.Empty;
            this.ceForeColor.Location = new System.Drawing.Point(70, 143);
            this.ceForeColor.Name = "ceForeColor";
            this.ceForeColor.Size = new System.Drawing.Size(281, 18);
            this.ceForeColor.TabIndex = 123;
            // 
            // ceBackColor
            // 
            this.ceBackColor.BackColor = System.Drawing.Color.White;
            this.ceBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceBackColor.Color = System.Drawing.Color.Empty;
            this.ceBackColor.Location = new System.Drawing.Point(71, 118);
            this.ceBackColor.Name = "ceBackColor";
            this.ceBackColor.Size = new System.Drawing.Size(281, 18);
            this.ceBackColor.TabIndex = 122;
            // 
            // frmLabDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 434);
            this.Controls.Add(this.feSetting);
            this.Controls.Add(this.ceForeColor);
            this.Controls.Add(this.ceBackColor);
            this.Controls.Add(this.chkDrag);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbxBkgroundLayout);
            this.Controls.Add(this.txtBackgroundImage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxTextPostion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbxImagePostion);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbDisplayText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIconName);
            this.Controls.Add(this.butLoadImg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLabDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmLabDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxImagePostion;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbDisplayText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIconName;
        private System.Windows.Forms.Button butLoadImg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxTextPostion;
        private System.Windows.Forms.TextBox txtBackgroundImage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxBkgroundLayout;
        private System.Windows.Forms.CheckBox chkDrag;
        private BusinessBase.Controls.ColorEditor ceBackColor;
        private BusinessBase.Controls.ColorEditor ceForeColor;
        private BusinessBase.Controls.FontEditor feSetting;
    }
}