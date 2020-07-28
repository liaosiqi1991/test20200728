namespace zlMedimgSystem.BaseSettings
{
    partial class frmDepartmentMatch
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
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsbMatchs = new System.Windows.Forms.ListBox();
            this.butDelMatch = new System.Windows.Forms.Button();
            this.txtMatchCode = new System.Windows.Forms.TextBox();
            this.butNewMatch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatchSource = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbAttachInfo = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDepartName = new System.Windows.Forms.TextBox();
            this.butModify = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rtbAttachInfo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDepartName);
            this.panel1.Controls.Add(this.butModify);
            this.panel1.Controls.Add(this.butDel);
            this.panel1.Controls.Add(this.butNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(420, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 540);
            this.panel1.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "对照设置";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel2.Controls.Add(this.lsbMatchs);
            this.panel2.Controls.Add(this.butDelMatch);
            this.panel2.Controls.Add(this.txtMatchCode);
            this.panel2.Controls.Add(this.butNewMatch);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtMatchSource);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(87, 155);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 100);
            this.panel2.TabIndex = 37;
            // 
            // lsbMatchs
            // 
            this.lsbMatchs.FormattingEnabled = true;
            this.lsbMatchs.ItemHeight = 12;
            this.lsbMatchs.Location = new System.Drawing.Point(3, 30);
            this.lsbMatchs.Name = "lsbMatchs";
            this.lsbMatchs.Size = new System.Drawing.Size(246, 64);
            this.lsbMatchs.TabIndex = 34;
            // 
            // butDelMatch
            // 
            this.butDelMatch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butDelMatch.Location = new System.Drawing.Point(254, 59);
            this.butDelMatch.Name = "butDelMatch";
            this.butDelMatch.Size = new System.Drawing.Size(22, 23);
            this.butDelMatch.TabIndex = 36;
            this.butDelMatch.Text = "-";
            this.butDelMatch.UseVisualStyleBackColor = true;
            this.butDelMatch.Click += new System.EventHandler(this.butDelMatch_Click);
            // 
            // txtMatchCode
            // 
            this.txtMatchCode.Location = new System.Drawing.Point(176, 3);
            this.txtMatchCode.MaxLength = 50;
            this.txtMatchCode.Name = "txtMatchCode";
            this.txtMatchCode.Size = new System.Drawing.Size(100, 21);
            this.txtMatchCode.TabIndex = 16;
            // 
            // butNewMatch
            // 
            this.butNewMatch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butNewMatch.Location = new System.Drawing.Point(254, 30);
            this.butNewMatch.Name = "butNewMatch";
            this.butNewMatch.Size = new System.Drawing.Size(22, 23);
            this.butNewMatch.TabIndex = 35;
            this.butNewMatch.Text = "+";
            this.butNewMatch.UseVisualStyleBackColor = true;
            this.butNewMatch.Click += new System.EventHandler(this.butNewMatch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "编码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMatchSource
            // 
            this.txtMatchSource.Location = new System.Drawing.Point(35, 3);
            this.txtMatchSource.MaxLength = 100;
            this.txtMatchSource.Name = "txtMatchSource";
            this.txtMatchSource.Size = new System.Drawing.Size(100, 21);
            this.txtMatchSource.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 32;
            this.label5.Text = "来源";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(11, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "*";
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
            this.label4.TabIndex = 19;
            this.label4.Text = "科室对照设置：\r\n\r\n用于设置当前系统中各科室与三方系统中的科室的对应关系。\r\n当需要从多个系统中进行科室对照时，则需要录入对照来源。";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "备注描述";
            // 
            // rtbAttachInfo
            // 
            this.rtbAttachInfo.Location = new System.Drawing.Point(86, 261);
            this.rtbAttachInfo.Name = "rtbAttachInfo";
            this.rtbAttachInfo.Size = new System.Drawing.Size(282, 70);
            this.rtbAttachInfo.TabIndex = 17;
            this.rtbAttachInfo.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDepartName
            // 
            this.txtDepartName.Location = new System.Drawing.Point(87, 128);
            this.txtDepartName.MaxLength = 100;
            this.txtDepartName.Name = "txtDepartName";
            this.txtDepartName.Size = new System.Drawing.Size(281, 21);
            this.txtDepartName.TabIndex = 1;
            // 
            // butModify
            // 
            this.butModify.Location = new System.Drawing.Point(292, 344);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(75, 36);
            this.butModify.TabIndex = 14;
            this.butModify.Text = "保存";
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(192, 344);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(75, 36);
            this.butDel.TabIndex = 13;
            this.butDel.Text = "删除";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(85, 344);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(75, 36);
            this.butNew.TabIndex = 12;
            this.butNew.Text = "添加";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(420, 540);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // frmDepartmentMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 540);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "frmDepartmentMatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "科室对照设置";
            this.Load += new System.EventHandler(this.frmDepartmentMatch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDepartName;
        private System.Windows.Forms.Button butModify;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMatchCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbAttachInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMatchSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lsbMatchs;
        private System.Windows.Forms.Button butDelMatch;
        private System.Windows.Forms.Button butNewMatch;
    }
}