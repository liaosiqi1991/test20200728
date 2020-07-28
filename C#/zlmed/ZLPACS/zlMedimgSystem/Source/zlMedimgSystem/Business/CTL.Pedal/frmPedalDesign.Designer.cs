namespace zlMedimgSystem.CTL.Pedal
{
    partial class frmPedalDesign
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxSignCount = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxInterval = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxTouchWay = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxPedal = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.butSure = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxSignCount);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbxInterval);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbxTouchWay);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbxPedal);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 132);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "脚踏设置";
            // 
            // cbxSignCount
            // 
            this.cbxSignCount.FormattingEnabled = true;
            this.cbxSignCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbxSignCount.Location = new System.Drawing.Point(121, 97);
            this.cbxSignCount.Name = "cbxSignCount";
            this.cbxSignCount.Size = new System.Drawing.Size(215, 20);
            this.cbxSignCount.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "信号数量";
            // 
            // cbxInterval
            // 
            this.cbxInterval.FormattingEnabled = true;
            this.cbxInterval.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "500"});
            this.cbxInterval.Location = new System.Drawing.Point(121, 71);
            this.cbxInterval.Name = "cbxInterval";
            this.cbxInterval.Size = new System.Drawing.Size(215, 20);
            this.cbxInterval.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "触发间隔";
            // 
            // cbxTouchWay
            // 
            this.cbxTouchWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTouchWay.FormattingEnabled = true;
            this.cbxTouchWay.Location = new System.Drawing.Point(121, 46);
            this.cbxTouchWay.Name = "cbxTouchWay";
            this.cbxTouchWay.Size = new System.Drawing.Size(215, 20);
            this.cbxTouchWay.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "触发方式";
            // 
            // cbxPedal
            // 
            this.cbxPedal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPedal.FormattingEnabled = true;
            this.cbxPedal.Location = new System.Drawing.Point(121, 20);
            this.cbxPedal.Name = "cbxPedal";
            this.cbxPedal.Size = new System.Drawing.Size(215, 20);
            this.cbxPedal.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "脚踏设备";
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(192, 150);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 27;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(273, 150);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 28;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // frmPedalDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 182);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPedalDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "脚踏设置";
            this.Load += new System.EventHandler(this.frmPedalDesign_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxSignCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxInterval;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxTouchWay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxPedal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.Button butCancel;
    }
}