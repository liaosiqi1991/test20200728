namespace zlMedimgSystem.CTL.RollText
{
    partial class frmRollTextDesign
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
            this.txtImgName = new System.Windows.Forms.TextBox();
            this.butLoadImg = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbDisplayText = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cbxLayout = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.feFontDetail = new zlMedimgSystem.BusinessBase.Controls.FontEditor();
            this.labForeColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.labBkColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "背景图片";
            // 
            // txtImgName
            // 
            this.txtImgName.Location = new System.Drawing.Point(71, 21);
            this.txtImgName.Name = "txtImgName";
            this.txtImgName.Size = new System.Drawing.Size(282, 21);
            this.txtImgName.TabIndex = 58;
            // 
            // butLoadImg
            // 
            this.butLoadImg.Location = new System.Drawing.Point(359, 20);
            this.butLoadImg.Name = "butLoadImg";
            this.butLoadImg.Size = new System.Drawing.Size(24, 23);
            this.butLoadImg.TabIndex = 59;
            this.butLoadImg.Text = "…";
            this.butLoadImg.UseVisualStyleBackColor = true;
            this.butLoadImg.Click += new System.EventHandler(this.butLoadImg_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 61;
            this.label7.Text = "前景色";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 60;
            this.label6.Text = "背景色";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 66;
            this.label2.Text = "显示文本";
            // 
            // rtbDisplayText
            // 
            this.rtbDisplayText.Location = new System.Drawing.Point(71, 254);
            this.rtbDisplayText.Name = "rtbDisplayText";
            this.rtbDisplayText.Size = new System.Drawing.Size(282, 96);
            this.rtbDisplayText.TabIndex = 67;
            this.rtbDisplayText.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 68;
            this.label3.Text = "字体设置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 71;
            this.label4.Text = "滚动速度";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(278, 356);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 74;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(197, 356);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 73;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(72, 200);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(281, 21);
            this.txtSpeed.TabIndex = 75;
            this.txtSpeed.Text = "50";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(357, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 76;
            this.label5.Text = "毫秒";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(356, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 79;
            this.label8.Text = "像素";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(71, 227);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(281, 21);
            this.txtDistance.TabIndex = 78;
            this.txtDistance.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 77;
            this.label9.Text = "滚动距离";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(358, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 23);
            this.button2.TabIndex = 80;
            this.button2.Text = "…";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbxLayout
            // 
            this.cbxLayout.FormattingEnabled = true;
            this.cbxLayout.Items.AddRange(new object[] {
            "正常",
            "贴图",
            "居中",
            "填充",
            "缩放"});
            this.cbxLayout.Location = new System.Drawing.Point(71, 48);
            this.cbxLayout.Name = "cbxLayout";
            this.cbxLayout.Size = new System.Drawing.Size(282, 20);
            this.cbxLayout.TabIndex = 81;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 82;
            this.label10.Text = "背景样式";
            // 
            // feFontDetail
            // 
            this.feFontDetail.BackColor = System.Drawing.Color.White;
            this.feFontDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.feFontDetail.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.feFontDetail.Location = new System.Drawing.Point(71, 123);
            this.feFontDetail.Name = "feFontDetail";
            this.feFontDetail.Size = new System.Drawing.Size(281, 71);
            this.feFontDetail.TabIndex = 86;
            this.feFontDetail.Value = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // labForeColor
            // 
            this.labForeColor.BackColor = System.Drawing.Color.White;
            this.labForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labForeColor.Color = System.Drawing.Color.Empty;
            this.labForeColor.Location = new System.Drawing.Point(71, 99);
            this.labForeColor.Name = "labForeColor";
            this.labForeColor.Size = new System.Drawing.Size(282, 18);
            this.labForeColor.TabIndex = 85;
            // 
            // labBkColor
            // 
            this.labBkColor.BackColor = System.Drawing.Color.White;
            this.labBkColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labBkColor.Color = System.Drawing.Color.Empty;
            this.labBkColor.Location = new System.Drawing.Point(71, 74);
            this.labBkColor.Name = "labBkColor";
            this.labBkColor.Size = new System.Drawing.Size(282, 18);
            this.labBkColor.TabIndex = 84;
            // 
            // frmRollTextDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 400);
            this.Controls.Add(this.feFontDetail);
            this.Controls.Add(this.labForeColor);
            this.Controls.Add(this.labBkColor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbxLayout);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbDisplayText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtImgName);
            this.Controls.Add(this.butLoadImg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRollTextDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmRollTextDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImgName;
        private System.Windows.Forms.Button butLoadImg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbDisplayText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbxLayout;
        private System.Windows.Forms.Label label10;
        private BusinessBase.Controls.ColorEditor labBkColor;
        private BusinessBase.Controls.ColorEditor labForeColor;
        private BusinessBase.Controls.FontEditor feFontDetail;
    }
}