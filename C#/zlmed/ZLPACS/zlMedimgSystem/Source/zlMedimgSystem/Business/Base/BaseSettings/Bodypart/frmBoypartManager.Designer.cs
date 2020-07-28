namespace zlMedimgSystem.BaseSettings
{
    partial class frmBoypartManager
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.butModify = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.cbxApplySex = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.cbxBodypartGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBodypartName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboAttachWay = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.butApplyAll = new System.Windows.Forms.Button();
            this.butApplyGroup = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cboMutex = new System.Windows.Forms.ComboBox();
            this.cbxBodypartWayName = new System.Windows.Forms.ComboBox();
            this.butNewSubWay = new System.Windows.Forms.Button();
            this.butDelWay = new System.Windows.Forms.Button();
            this.butNewWay = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxImageKind = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAttachWay.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.dataGridView1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.butModify);
            this.panel1.Controls.Add(this.butDel);
            this.panel1.Controls.Add(this.butNew);
            this.panel1.Controls.Add(this.cbxApplySex);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.rtbDescription);
            this.panel1.Controls.Add(this.cbxBodypartGroup);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtBodypartName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(598, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 673);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(3, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 37;
            this.label8.Text = "*";
            // 
            // butModify
            // 
            this.butModify.Location = new System.Drawing.Point(293, 323);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(75, 36);
            this.butModify.TabIndex = 36;
            this.butModify.Text = "保存";
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(185, 323);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(75, 36);
            this.butDel.TabIndex = 35;
            this.butDel.Text = "删除";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(75, 323);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(75, 36);
            this.butNew.TabIndex = 34;
            this.butNew.Text = "添加";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // cbxApplySex
            // 
            this.cbxApplySex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxApplySex.FormattingEnabled = true;
            this.cbxApplySex.Items.AddRange(new object[] {
            "男",
            "女",
            "未知",
            "未明",
            "女变男",
            "男变女"});
            this.cbxApplySex.Location = new System.Drawing.Point(75, 162);
            this.cbxApplySex.Name = "cbxApplySex";
            this.cbxApplySex.Size = new System.Drawing.Size(293, 20);
            this.cbxApplySex.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "适用性别";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "备注描述";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(75, 188);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(293, 129);
            this.rtbDescription.TabIndex = 30;
            this.rtbDescription.Text = "";
            // 
            // cbxBodypartGroup
            // 
            this.cbxBodypartGroup.FormattingEnabled = true;
            this.cbxBodypartGroup.Location = new System.Drawing.Point(75, 136);
            this.cbxBodypartGroup.Name = "cbxBodypartGroup";
            this.cbxBodypartGroup.Size = new System.Drawing.Size(293, 20);
            this.cbxBodypartGroup.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "分组标记";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "部位名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBodypartName
            // 
            this.txtBodypartName.Location = new System.Drawing.Point(75, 109);
            this.txtBodypartName.Name = "txtBodypartName";
            this.txtBodypartName.Size = new System.Drawing.Size(293, 21);
            this.txtBodypartName.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(3);
            this.label4.Size = new System.Drawing.Size(380, 98);
            this.label4.TabIndex = 20;
            this.label4.Text = "检查部位设置：\r\n\r\n设置不同类别下的检查部位和方法，供后续检查项目进行对应的配置。";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboAttachWay
            // 
            this.cboAttachWay.EditValue = "";
            this.cboAttachWay.Location = new System.Drawing.Point(94, 426);
            this.cboAttachWay.Name = "cboAttachWay";
            this.cboAttachWay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAttachWay.Properties.SelectAllItemVisible = false;
            this.cboAttachWay.Properties.SeparatorChar = ';';
            this.cboAttachWay.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboAttachWay.Size = new System.Drawing.Size(199, 20);
            this.cboAttachWay.TabIndex = 39;
            this.cboAttachWay.EditValueChanged += new System.EventHandler(this.cboAttachWay_EditValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(598, 673);
            this.panel2.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 23);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(598, 419);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.butApplyAll);
            this.panel4.Controls.Add(this.butApplyGroup);
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Controls.Add(this.butNewSubWay);
            this.panel4.Controls.Add(this.butDelWay);
            this.panel4.Controls.Add(this.butNewWay);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 442);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(598, 231);
            this.panel4.TabIndex = 6;
            // 
            // butApplyAll
            // 
            this.butApplyAll.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butApplyAll.Location = new System.Drawing.Point(363, 7);
            this.butApplyAll.Name = "butApplyAll";
            this.butApplyAll.Size = new System.Drawing.Size(76, 23);
            this.butApplyAll.TabIndex = 44;
            this.butApplyAll.Text = "应用到所有";
            this.butApplyAll.UseVisualStyleBackColor = true;
            this.butApplyAll.Click += new System.EventHandler(this.butApplyAll_Click);
            // 
            // butApplyGroup
            // 
            this.butApplyGroup.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butApplyGroup.Location = new System.Drawing.Point(284, 7);
            this.butApplyGroup.Name = "butApplyGroup";
            this.butApplyGroup.Size = new System.Drawing.Size(73, 23);
            this.butApplyGroup.TabIndex = 43;
            this.butApplyGroup.Text = "应用到分组";
            this.butApplyGroup.UseVisualStyleBackColor = true;
            this.butApplyGroup.Click += new System.EventHandler(this.butApplyGroup_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Controls.Add(this.cboAttachWay);
            this.dataGridView1.Controls.Add(this.cboMutex);
            this.dataGridView1.Controls.Add(this.cbxBodypartWayName);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 36);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(598, 195);
            this.dataGridView1.TabIndex = 42;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // cboMutex
            // 
            this.cboMutex.FormattingEnabled = true;
            this.cboMutex.Items.AddRange(new object[] {
            "互斥方法",
            "可选方法"});
            this.cboMutex.Location = new System.Drawing.Point(465, 22);
            this.cboMutex.Name = "cboMutex";
            this.cboMutex.Size = new System.Drawing.Size(121, 20);
            this.cboMutex.TabIndex = 45;
            this.cboMutex.SelectedIndexChanged += new System.EventHandler(this.cboMutex_SelectedIndexChanged);
            // 
            // cbxBodypartWayName
            // 
            this.cbxBodypartWayName.FormattingEnabled = true;
            this.cbxBodypartWayName.Location = new System.Drawing.Point(391, 128);
            this.cbxBodypartWayName.Name = "cbxBodypartWayName";
            this.cbxBodypartWayName.Size = new System.Drawing.Size(171, 20);
            this.cbxBodypartWayName.TabIndex = 41;
            this.cbxBodypartWayName.SelectedIndexChanged += new System.EventHandler(this.cbxBodypartWayName_SelectedIndexChanged);
            this.cbxBodypartWayName.TextUpdate += new System.EventHandler(this.cbxBodypartWayName_TextUpdate);
            // 
            // butNewSubWay
            // 
            this.butNewSubWay.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butNewSubWay.Location = new System.Drawing.Point(97, 7);
            this.butNewSubWay.Name = "butNewSubWay";
            this.butNewSubWay.Size = new System.Drawing.Size(88, 23);
            this.butNewSubWay.TabIndex = 40;
            this.butNewSubWay.Text = "保存检查方法";
            this.butNewSubWay.UseVisualStyleBackColor = true;
            this.butNewSubWay.Click += new System.EventHandler(this.butNewSubWay_Click);
            // 
            // butDelWay
            // 
            this.butDelWay.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butDelWay.Location = new System.Drawing.Point(191, 7);
            this.butDelWay.Name = "butDelWay";
            this.butDelWay.Size = new System.Drawing.Size(87, 23);
            this.butDelWay.TabIndex = 38;
            this.butDelWay.Text = "删除检查方法";
            this.butDelWay.UseVisualStyleBackColor = true;
            this.butDelWay.Click += new System.EventHandler(this.butDelWay_Click);
            // 
            // butNewWay
            // 
            this.butNewWay.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butNewWay.Location = new System.Drawing.Point(0, 7);
            this.butNewWay.Name = "butNewWay";
            this.butNewWay.Size = new System.Drawing.Size(91, 23);
            this.butNewWay.TabIndex = 37;
            this.butNewWay.Text = "新增检查方法";
            this.butNewWay.UseVisualStyleBackColor = true;
            this.butNewWay.Click += new System.EventHandler(this.butNewWay_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbxImageKind);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(598, 23);
            this.panel3.TabIndex = 4;
            // 
            // cbxImageKind
            // 
            this.cbxImageKind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxImageKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxImageKind.FormattingEnabled = true;
            this.cbxImageKind.Location = new System.Drawing.Point(71, 0);
            this.cbxImageKind.Name = "cbxImageKind";
            this.cbxImageKind.Size = new System.Drawing.Size(527, 20);
            this.cbxImageKind.TabIndex = 1;
            this.cbxImageKind.SelectedIndexChanged += new System.EventHandler(this.cbxImageKind_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "影像类别：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmBoypartManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 673);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmBoypartManager";
            this.Text = "部位设置";
            this.Load += new System.EventHandler(this.frmBoypartManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAttachWay.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.dataGridView1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbxImageKind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxApplySex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.ComboBox cbxBodypartGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBodypartName;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button butModify;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button butNewSubWay;
        private System.Windows.Forms.Button butDelWay;
        private System.Windows.Forms.Button butNewWay;
        private System.Windows.Forms.ComboBox cbxBodypartWayName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button butApplyGroup;
        private System.Windows.Forms.Button butApplyAll;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cboAttachWay;
        private System.Windows.Forms.ComboBox cboMutex;
    }
}