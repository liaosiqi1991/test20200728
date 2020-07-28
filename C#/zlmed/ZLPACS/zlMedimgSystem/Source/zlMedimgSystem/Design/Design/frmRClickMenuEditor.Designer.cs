namespace zlMedimgSystem.Design
{
    partial class frmRClickMenuEditor
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
            this.cbxParentName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.butAdd = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.txtButTag = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.butLoadImg = new System.Windows.Forms.Button();
            this.txtImgName = new System.Windows.Forms.TextBox();
            this.butSure = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butModify = new System.Windows.Forms.Button();
            this.cbxShortcutKey = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxParentName
            // 
            this.cbxParentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxParentName.FormattingEnabled = true;
            this.cbxParentName.Location = new System.Drawing.Point(303, 41);
            this.cbxParentName.Name = "cbxParentName";
            this.cbxParentName.Size = new System.Drawing.Size(160, 20);
            this.cbxParentName.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(244, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "父级名称";
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(21, 94);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(666, 259);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "按钮名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "按钮标记";
            // 
            // butAdd
            // 
            this.butAdd.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butAdd.Location = new System.Drawing.Point(594, 65);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(27, 23);
            this.butAdd.TabIndex = 0;
            this.butAdd.Text = "┼";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(624, 387);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 23;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butDel
            // 
            this.butDel.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butDel.Location = new System.Drawing.Point(627, 65);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(27, 23);
            this.butDel.TabIndex = 1;
            this.butDel.Text = "─";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // txtButTag
            // 
            this.txtButTag.Location = new System.Drawing.Point(78, 67);
            this.txtButTag.Name = "txtButTag";
            this.txtButTag.Size = new System.Drawing.Size(385, 21);
            this.txtButTag.TabIndex = 8;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(78, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 21);
            this.txtName.TabIndex = 2;
            // 
            // butLoadImg
            // 
            this.butLoadImg.Location = new System.Drawing.Point(440, 13);
            this.butLoadImg.Name = "butLoadImg";
            this.butLoadImg.Size = new System.Drawing.Size(24, 23);
            this.butLoadImg.TabIndex = 6;
            this.butLoadImg.Text = "…";
            this.butLoadImg.UseVisualStyleBackColor = true;
            this.butLoadImg.Click += new System.EventHandler(this.butLoadImg_Click);
            // 
            // txtImgName
            // 
            this.txtImgName.Location = new System.Drawing.Point(303, 14);
            this.txtImgName.Name = "txtImgName";
            this.txtImgName.Size = new System.Drawing.Size(137, 21);
            this.txtImgName.TabIndex = 3;
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(543, 387);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 22;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "图标名称";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butModify);
            this.groupBox1.Controls.Add(this.cbxShortcutKey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxParentName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.butAdd);
            this.groupBox1.Controls.Add(this.butDel);
            this.groupBox1.Controls.Add(this.txtButTag);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.butLoadImg);
            this.groupBox1.Controls.Add(this.txtImgName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(693, 359);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // butModify
            // 
            this.butModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butModify.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butModify.Image = global::zlMedimgSystem.Design.Properties.Resources.blackwrite24x24;
            this.butModify.Location = new System.Drawing.Point(660, 65);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(27, 23);
            this.butModify.TabIndex = 24;
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // cbxShortcutKey
            // 
            this.cbxShortcutKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxShortcutKey.FormattingEnabled = true;
            this.cbxShortcutKey.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbxShortcutKey.Location = new System.Drawing.Point(78, 41);
            this.cbxShortcutKey.Name = "cbxShortcutKey";
            this.cbxShortcutKey.Size = new System.Drawing.Size(160, 20);
            this.cbxShortcutKey.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "菜单热键";
            // 
            // frmRClickMenuEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 428);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRClickMenuEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "右键菜单设计";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmRClickMenuEditor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxParentName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.TextBox txtButTag;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button butLoadImg;
        private System.Windows.Forms.TextBox txtImgName;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxShortcutKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butModify;
    }
}