namespace zlMedimgSystem.SqlManager
{
    partial class frmSqlManager
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
            this.tvSqls = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtbSqlContext = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.butUpdate = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxBizName = new System.Windows.Forms.ComboBox();
            this.txtSqlName = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tvSqls);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 608);
            this.panel1.TabIndex = 0;
            // 
            // tvSqls
            // 
            this.tvSqls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSqls.Location = new System.Drawing.Point(0, 0);
            this.tvSqls.Name = "tvSqls";
            this.tvSqls.Size = new System.Drawing.Size(247, 608);
            this.tvSqls.TabIndex = 0;
            this.tvSqls.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSqls_AfterSelect);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(247, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 608);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtbSqlContext);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(250, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(774, 608);
            this.panel2.TabIndex = 2;
            // 
            // rtbSqlContext
            // 
            this.rtbSqlContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSqlContext.Location = new System.Drawing.Point(0, 68);
            this.rtbSqlContext.Name = "rtbSqlContext";
            this.rtbSqlContext.Size = new System.Drawing.Size(774, 540);
            this.rtbSqlContext.TabIndex = 2;
            this.rtbSqlContext.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.butUpdate);
            this.panel3.Controls.Add(this.butDel);
            this.panel3.Controls.Add(this.butNew);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbxBizName);
            this.panel3.Controls.Add(this.txtSqlName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(774, 68);
            this.panel3.TabIndex = 3;
            // 
            // butUpdate
            // 
            this.butUpdate.Location = new System.Drawing.Point(603, 26);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(75, 23);
            this.butUpdate.TabIndex = 11;
            this.butUpdate.Text = "更新";
            this.butUpdate.UseVisualStyleBackColor = true;
            this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click);
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(522, 26);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(75, 23);
            this.butDel.TabIndex = 10;
            this.butDel.Text = "删除";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(441, 26);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(75, 23);
            this.butNew.TabIndex = 9;
            this.butNew.Text = "添加";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "查询名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "业务标记";
            // 
            // cbxBizName
            // 
            this.cbxBizName.FormattingEnabled = true;
            this.cbxBizName.Location = new System.Drawing.Point(69, 28);
            this.cbxBizName.Name = "cbxBizName";
            this.cbxBizName.Size = new System.Drawing.Size(121, 20);
            this.cbxBizName.TabIndex = 6;
            // 
            // txtSqlName
            // 
            this.txtSqlName.Location = new System.Drawing.Point(270, 28);
            this.txtSqlName.Name = "txtSqlName";
            this.txtSqlName.Size = new System.Drawing.Size(161, 21);
            this.txtSqlName.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 608);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1024, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // frmSqlManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 630);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmSqlManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询配置管理";
            this.Load += new System.EventHandler(this.frmSqlManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox rtbSqlContext;
        private System.Windows.Forms.Button butUpdate;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxBizName;
        private System.Windows.Forms.TextBox txtSqlName;
        private System.Windows.Forms.TreeView tvSqls;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}