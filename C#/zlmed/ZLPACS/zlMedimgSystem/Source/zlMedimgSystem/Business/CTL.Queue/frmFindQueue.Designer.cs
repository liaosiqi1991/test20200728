namespace zlMedimgSystem.CTL.QueueManager
{
    partial class frmFindQueue
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
            this.cbxFindType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxValue = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.dtpValue = new System.Windows.Forms.DateTimePicker();
            this.butSure = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "查找类型";
            // 
            // cbxFindType
            // 
            this.cbxFindType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFindType.FormattingEnabled = true;
            this.cbxFindType.Items.AddRange(new object[] {
            "患者姓名",
            "排队号码"});
            this.cbxFindType.Location = new System.Drawing.Point(87, 20);
            this.cbxFindType.Name = "cbxFindType";
            this.cbxFindType.Size = new System.Drawing.Size(258, 20);
            this.cbxFindType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "条件取值";
            // 
            // cbxValue
            // 
            this.cbxValue.FormattingEnabled = true;
            this.cbxValue.Location = new System.Drawing.Point(68, 184);
            this.cbxValue.Name = "cbxValue";
            this.cbxValue.Size = new System.Drawing.Size(258, 20);
            this.cbxValue.TabIndex = 3;
            this.cbxValue.Visible = false;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(87, 50);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(258, 21);
            this.txtValue.TabIndex = 4;
            // 
            // dtpValue
            // 
            this.dtpValue.CustomFormat = "yyyy-MM-dd";
            this.dtpValue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpValue.Location = new System.Drawing.Point(68, 157);
            this.dtpValue.Name = "dtpValue";
            this.dtpValue.Size = new System.Drawing.Size(258, 21);
            this.dtpValue.TabIndex = 5;
            this.dtpValue.Visible = false;
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(189, 77);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 19;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(270, 77);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 18;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // frmFindQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 118);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.dtpValue);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.cbxValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxFindType);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindQueue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找";
            this.Load += new System.EventHandler(this.frmFindQueue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxFindType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.DateTimePicker dtpValue;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.Button butCancel;
    }
}