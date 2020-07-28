namespace zlMedimgSystem.CTL.DataList
{
    partial class frmDataListModuleDesign
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
            this.chkAllowGroup = new System.Windows.Forms.CheckBox();
            this.chkAllowRowNo = new System.Windows.Forms.CheckBox();
            this.chkAllowFixColCfg = new System.Windows.Forms.CheckBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkShowCol = new System.Windows.Forms.CheckBox();
            this.chkAllowFilter = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAllowGroup
            // 
            this.chkAllowGroup.AutoSize = true;
            this.chkAllowGroup.Location = new System.Drawing.Point(27, 29);
            this.chkAllowGroup.Name = "chkAllowGroup";
            this.chkAllowGroup.Size = new System.Drawing.Size(96, 16);
            this.chkAllowGroup.TabIndex = 0;
            this.chkAllowGroup.Text = "允许列表分组";
            this.chkAllowGroup.UseVisualStyleBackColor = true;
            // 
            // chkAllowRowNo
            // 
            this.chkAllowRowNo.AutoSize = true;
            this.chkAllowRowNo.Location = new System.Drawing.Point(27, 51);
            this.chkAllowRowNo.Name = "chkAllowRowNo";
            this.chkAllowRowNo.Size = new System.Drawing.Size(72, 16);
            this.chkAllowRowNo.TabIndex = 1;
            this.chkAllowRowNo.Text = "显示行号";
            this.chkAllowRowNo.UseVisualStyleBackColor = true;
            // 
            // chkAllowFixColCfg
            // 
            this.chkAllowFixColCfg.AutoSize = true;
            this.chkAllowFixColCfg.Location = new System.Drawing.Point(27, 73);
            this.chkAllowFixColCfg.Name = "chkAllowFixColCfg";
            this.chkAllowFixColCfg.Size = new System.Drawing.Size(108, 16);
            this.chkAllowFixColCfg.TabIndex = 2;
            this.chkAllowFixColCfg.Text = "显示固定列配置";
            this.chkAllowFixColCfg.UseVisualStyleBackColor = true;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(141, 147);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(60, 147);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 4;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAllowFilter);
            this.groupBox1.Controls.Add(this.chkShowCol);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 129);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // chkShowCol
            // 
            this.chkShowCol.AutoSize = true;
            this.chkShowCol.Location = new System.Drawing.Point(11, 83);
            this.chkShowCol.Name = "chkShowCol";
            this.chkShowCol.Size = new System.Drawing.Size(72, 16);
            this.chkShowCol.TabIndex = 3;
            this.chkShowCol.Text = "显示列头";
            this.chkShowCol.UseVisualStyleBackColor = true;
            // 
            // chkAllowFilter
            // 
            this.chkAllowFilter.AutoSize = true;
            this.chkAllowFilter.Location = new System.Drawing.Point(11, 105);
            this.chkAllowFilter.Name = "chkAllowFilter";
            this.chkAllowFilter.Size = new System.Drawing.Size(72, 16);
            this.chkAllowFilter.TabIndex = 4;
            this.chkAllowFilter.Text = "允许过滤";
            this.chkAllowFilter.UseVisualStyleBackColor = true;
            // 
            // frmDataListModuleDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 182);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.chkAllowFixColCfg);
            this.Controls.Add(this.chkAllowRowNo);
            this.Controls.Add(this.chkAllowGroup);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataListModuleDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmDataListModuleDesign_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAllowGroup;
        private System.Windows.Forms.CheckBox chkAllowRowNo;
        private System.Windows.Forms.CheckBox chkAllowFixColCfg;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAllowFilter;
        private System.Windows.Forms.CheckBox chkShowCol;
    }
}