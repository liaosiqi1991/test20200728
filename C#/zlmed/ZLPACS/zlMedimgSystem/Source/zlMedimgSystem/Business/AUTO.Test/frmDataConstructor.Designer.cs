namespace zlMedimgSystem.CTL.TestData
{
    partial class frmDataConstructor
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
            this.butSure = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butDicts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.butModify = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.butAdd = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(674, 377);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 25;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butDicts);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxType);
            this.groupBox1.Controls.Add(this.butModify);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.butAdd);
            this.groupBox1.Controls.Add(this.butDel);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtValue);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(818, 359);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // butDicts
            // 
            this.butDicts.Location = new System.Drawing.Point(586, 13);
            this.butDicts.Name = "butDicts";
            this.butDicts.Size = new System.Drawing.Size(55, 23);
            this.butDicts.TabIndex = 19;
            this.butDicts.Text = "构造…";
            this.butDicts.UseVisualStyleBackColor = true;
            this.butDicts.Click += new System.EventHandler(this.butDicts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "类型";
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "字符串",
            "字典"});
            this.cbxType.Location = new System.Drawing.Point(236, 14);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(121, 20);
            this.cbxType.TabIndex = 17;
            this.cbxType.SelectedIndexChanged += new System.EventHandler(this.cbxType_SelectedIndexChanged);
            // 
            // butModify
            // 
            this.butModify.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butModify.Image = global::zlMedimgSystem.CTL.TestData.Properties.Resources.blackwrite24x24;
            this.butModify.Location = new System.Drawing.Point(785, 14);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(27, 23);
            this.butModify.TabIndex = 16;
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 42);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(806, 311);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "数据项名称";
            // 
            // butAdd
            // 
            this.butAdd.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butAdd.Location = new System.Drawing.Point(719, 14);
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
            this.butDel.Location = new System.Drawing.Point(752, 14);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(27, 23);
            this.butDel.TabIndex = 1;
            this.butDel.Text = "─";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(77, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(118, 21);
            this.txtName.TabIndex = 2;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(434, 14);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(146, 21);
            this.txtValue.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "模拟数据值";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(755, 377);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 26;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // frmDataConstructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 414);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataConstructor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据模拟设计";
            this.Load += new System.EventHandler(this.frmDataConstructor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butModify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Button butDicts;
    }
}