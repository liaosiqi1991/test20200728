namespace zlMedimgSystem.BaseSettings
{
    partial class frmDictionaryManager
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
            this.label6 = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.chkDefaule = new System.Windows.Forms.CheckBox();
            this.dgvDictionary = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxDictionary = new System.Windows.Forms.ComboBox();
            this.txtDicName = new System.Windows.Forms.TextBox();
            this.labshow = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDicDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDicCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDictionary)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "字典名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(38, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "*";
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(286, 247);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 36);
            this.btnModify.TabIndex = 29;
            this.btnModify.Text = "保存";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(201, 247);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 36);
            this.btnDel.TabIndex = 28;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(116, 247);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 36);
            this.btnNew.TabIndex = 27;
            this.btnNew.Text = "添加";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // chkDefaule
            // 
            this.chkDefaule.AutoSize = true;
            this.chkDefaule.Location = new System.Drawing.Point(119, 223);
            this.chkDefaule.Name = "chkDefaule";
            this.chkDefaule.Size = new System.Drawing.Size(72, 16);
            this.chkDefaule.TabIndex = 26;
            this.chkDefaule.Text = "是否缺省";
            this.chkDefaule.UseVisualStyleBackColor = true;
            // 
            // dgvDictionary
            // 
            this.dgvDictionary.AllowUserToAddRows = false;
            this.dgvDictionary.AllowUserToDeleteRows = false;
            this.dgvDictionary.BackgroundColor = System.Drawing.Color.White;
            this.dgvDictionary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDictionary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDictionary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDictionary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDictionary.Location = new System.Drawing.Point(0, 23);
            this.dgvDictionary.MultiSelect = false;
            this.dgvDictionary.Name = "dgvDictionary";
            this.dgvDictionary.ReadOnly = true;
            this.dgvDictionary.RowHeadersWidth = 30;
            this.dgvDictionary.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDictionary.RowTemplate.Height = 23;
            this.dgvDictionary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDictionary.Size = new System.Drawing.Size(408, 468);
            this.dgvDictionary.TabIndex = 5;
            this.dgvDictionary.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDictionary_RowPostPaint);
            this.dgvDictionary.SelectionChanged += new System.EventHandler(this.dgvDictionary_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxDictionary);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 23);
            this.panel1.TabIndex = 6;
            // 
            // cbxDictionary
            // 
            this.cbxDictionary.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxDictionary.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxDictionary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxDictionary.FormattingEnabled = true;
            this.cbxDictionary.Location = new System.Drawing.Point(71, 0);
            this.cbxDictionary.Name = "cbxDictionary";
            this.cbxDictionary.Size = new System.Drawing.Size(337, 20);
            this.cbxDictionary.TabIndex = 1;
            this.cbxDictionary.SelectedIndexChanged += new System.EventHandler(this.cbxDictionary_SelectedIndexChanged);
            // 
            // txtDicName
            // 
            this.txtDicName.Location = new System.Drawing.Point(119, 84);
            this.txtDicName.MaxLength = 20;
            this.txtDicName.Name = "txtDicName";
            this.txtDicName.Size = new System.Drawing.Size(243, 21);
            this.txtDicName.TabIndex = 21;
            // 
            // labshow
            // 
            this.labshow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labshow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labshow.Dock = System.Windows.Forms.DockStyle.Top;
            this.labshow.Location = new System.Drawing.Point(0, 0);
            this.labshow.Name = "labshow";
            this.labshow.Padding = new System.Windows.Forms.Padding(3);
            this.labshow.Size = new System.Drawing.Size(380, 71);
            this.labshow.TabIndex = 19;
            this.labshow.Text = "字典管理：\r\n\r\n设置常用字典内容，便于在后续操作中使用\r\n";
            this.labshow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(48, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "项目名称：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtDicDescription);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtDicCode);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnModify);
            this.panel2.Controls.Add(this.btnDel);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.chkDefaule);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtDicName);
            this.panel2.Controls.Add(this.labshow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(408, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 491);
            this.panel2.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(48, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 37;
            this.label7.Text = "项目说明：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDicDescription
            // 
            this.txtDicDescription.Location = new System.Drawing.Point(119, 140);
            this.txtDicDescription.MaxLength = 200;
            this.txtDicDescription.Multiline = true;
            this.txtDicDescription.Name = "txtDicDescription";
            this.txtDicDescription.Size = new System.Drawing.Size(243, 75);
            this.txtDicDescription.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(48, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "项目编码：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDicCode
            // 
            this.txtDicCode.Location = new System.Drawing.Point(119, 112);
            this.txtDicCode.MaxLength = 20;
            this.txtDicCode.Name = "txtDicCode";
            this.txtDicCode.Size = new System.Drawing.Size(243, 21);
            this.txtDicCode.TabIndex = 32;
            // 
            // frmDictionaryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 491);
            this.Controls.Add(this.dgvDictionary);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmDictionaryManager";
            this.Text = "字典管理";
            this.Load += new System.EventHandler(this.frmDictionaryManagernew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDictionary)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.CheckBox chkDefaule;
        private System.Windows.Forms.DataGridView dgvDictionary;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxDictionary;
        private System.Windows.Forms.TextBox txtDicName;
        private System.Windows.Forms.Label labshow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDicDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDicCode;
    }
}