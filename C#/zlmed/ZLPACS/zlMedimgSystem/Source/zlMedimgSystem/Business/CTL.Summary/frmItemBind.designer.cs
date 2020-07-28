namespace zlMedimgSystem.CTL.Summary
{
    partial class frmSelectField
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
            this.cbxDbName = new System.Windows.Forms.ComboBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.butSure = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDisplayValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.butModify = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.butAdd = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.butLoadImg = new System.Windows.Forms.Button();
            this.txtImgName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labBkColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.labForeColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxDbName
            // 
            this.cbxDbName.FormattingEnabled = true;
            this.cbxDbName.Location = new System.Drawing.Point(83, 12);
            this.cbxDbName.Name = "cbxDbName";
            this.cbxDbName.Size = new System.Drawing.Size(614, 20);
            this.cbxDbName.TabIndex = 0;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(622, 403);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "数据项名称";
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(541, 403);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 3;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labForeColor);
            this.groupBox1.Controls.Add(this.labBkColor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDisplayValue);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.butModify);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.butAdd);
            this.groupBox1.Controls.Add(this.butDel);
            this.groupBox1.Controls.Add(this.txtValue);
            this.groupBox1.Controls.Add(this.butLoadImg);
            this.groupBox1.Controls.Add(this.txtImgName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(14, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(683, 359);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 65;
            this.label2.Text = "显示值";
            // 
            // txtDisplayValue
            // 
            this.txtDisplayValue.Location = new System.Drawing.Point(57, 41);
            this.txtDisplayValue.Name = "txtDisplayValue";
            this.txtDisplayValue.Size = new System.Drawing.Size(160, 21);
            this.txtDisplayValue.TabIndex = 64;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(373, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 59;
            this.label7.Text = "前景色";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 58;
            this.label6.Text = "背景色";
            // 
            // butModify
            // 
            this.butModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butModify.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butModify.Image = global::zlMedimgSystem.CTL.Summary.Properties.Resources.blackwrite24x24;
            this.butModify.Location = new System.Drawing.Point(650, 39);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(27, 23);
            this.butModify.TabIndex = 24;
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 68);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(672, 285);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "数据值";
            // 
            // butAdd
            // 
            this.butAdd.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butAdd.Location = new System.Drawing.Point(585, 39);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(27, 23);
            this.butAdd.TabIndex = 0;
            this.butAdd.Text = "┼";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butDel
            // 
            this.butDel.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butDel.Location = new System.Drawing.Point(618, 39);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(27, 23);
            this.butDel.TabIndex = 1;
            this.butDel.Text = "─";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(57, 14);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(160, 21);
            this.txtValue.TabIndex = 2;
            // 
            // butLoadImg
            // 
            this.butLoadImg.Location = new System.Drawing.Point(481, 12);
            this.butLoadImg.Name = "butLoadImg";
            this.butLoadImg.Size = new System.Drawing.Size(24, 23);
            this.butLoadImg.TabIndex = 6;
            this.butLoadImg.Text = "…";
            this.butLoadImg.UseVisualStyleBackColor = true;
            this.butLoadImg.Click += new System.EventHandler(this.butLoadImg_Click);
            // 
            // txtImgName
            // 
            this.txtImgName.Location = new System.Drawing.Point(282, 14);
            this.txtImgName.Name = "txtImgName";
            this.txtImgName.Size = new System.Drawing.Size(193, 21);
            this.txtImgName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "图标名称";
            // 
            // labBkColor
            // 
            this.labBkColor.BackColor = System.Drawing.Color.White;
            this.labBkColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labBkColor.Color = System.Drawing.Color.Empty;
            this.labBkColor.Location = new System.Drawing.Point(282, 42);
            this.labBkColor.Name = "labBkColor";
            this.labBkColor.Size = new System.Drawing.Size(85, 18);
            this.labBkColor.TabIndex = 19;
            // 
            // labForeColor
            // 
            this.labForeColor.BackColor = System.Drawing.Color.White;
            this.labForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labForeColor.Color = System.Drawing.Color.Empty;
            this.labForeColor.Location = new System.Drawing.Point(420, 42);
            this.labForeColor.Name = "labForeColor";
            this.labForeColor.Size = new System.Drawing.Size(85, 18);
            this.labForeColor.TabIndex = 66;
            // 
            // frmSelectField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 441);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.cbxDbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectField";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据项名称";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSelectField_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxDbName;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butModify;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button butLoadImg;
        private System.Windows.Forms.TextBox txtImgName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDisplayValue;
        private BusinessBase.Controls.ColorEditor labForeColor;
        private BusinessBase.Controls.ColorEditor labBkColor;
    }
}