namespace zlMedimgSystem.BaseSettings
{
    partial class frmQueueManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueueManager));
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butModify = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.butReleationRoom = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butInsertPar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.rtbCallFormat = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCallStation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNoLen = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkStopUse = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDes = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQueueName = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Location = new System.Drawing.Point(71, 0);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(471, 20);
            this.cbxDepartment.TabIndex = 1;
            this.cbxDepartment.SelectedIndexChanged += new System.EventHandler(this.cbxDepartment_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butModify
            // 
            this.butModify.Location = new System.Drawing.Point(301, 477);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(75, 36);
            this.butModify.TabIndex = 29;
            this.butModify.Text = "保存(&M)";
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(220, 477);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(75, 36);
            this.butDel.TabIndex = 28;
            this.butDel.Text = "删除(&D)";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(139, 477);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(75, 36);
            this.butNew.TabIndex = 27;
            this.butNew.Text = "添加(&N)";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3);
            this.label3.Size = new System.Drawing.Size(380, 98);
            this.label3.TabIndex = 19;
            this.label3.Text = "队列管理：\r\n\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxDepartment);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.panel1.Size = new System.Drawing.Size(545, 23);
            this.panel1.TabIndex = 9;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "*.*|*.*";
            // 
            // butReleationRoom
            // 
            this.butReleationRoom.Location = new System.Drawing.Point(4, 477);
            this.butReleationRoom.Name = "butReleationRoom";
            this.butReleationRoom.Size = new System.Drawing.Size(80, 36);
            this.butReleationRoom.TabIndex = 31;
            this.butReleationRoom.Text = "关联房间(&R)";
            this.butReleationRoom.UseVisualStyleBackColor = true;
            this.butReleationRoom.Click += new System.EventHandler(this.butReleationRoom_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.butInsertPar);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.rtbCallFormat);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtCallStation);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtNoLen);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtPrefix);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.chkStopUse);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtDes);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtQueueName);
            this.panel2.Controls.Add(this.butReleationRoom);
            this.panel2.Controls.Add(this.butModify);
            this.panel2.Controls.Add(this.butDel);
            this.panel2.Controls.Add(this.butNew);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(545, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 608);
            this.panel2.TabIndex = 7;
            // 
            // butInsertPar
            // 
            this.butInsertPar.Location = new System.Drawing.Point(338, 209);
            this.butInsertPar.Name = "butInsertPar";
            this.butInsertPar.Size = new System.Drawing.Size(39, 23);
            this.butInsertPar.TabIndex = 46;
            this.butInsertPar.Text = "参数";
            this.butInsertPar.UseVisualStyleBackColor = true;
            this.butInsertPar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 45;
            this.label10.Text = "呼叫格式";
            // 
            // rtbCallFormat
            // 
            this.rtbCallFormat.Location = new System.Drawing.Point(84, 209);
            this.rtbCallFormat.Name = "rtbCallFormat";
            this.rtbCallFormat.Size = new System.Drawing.Size(248, 90);
            this.rtbCallFormat.TabIndex = 44;
            this.rtbCallFormat.Text = "请 [排队号码]  [患者姓名] [患者姓名] 到 [检查房间] 检查";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(25, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 42;
            this.label9.Text = "呼叫站点";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCallStation
            // 
            this.txtCallStation.Location = new System.Drawing.Point(84, 182);
            this.txtCallStation.Name = "txtCallStation";
            this.txtCallStation.Size = new System.Drawing.Size(293, 21);
            this.txtCallStation.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(24, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 40;
            this.label8.Text = "号码长度";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNoLen
            // 
            this.txtNoLen.Location = new System.Drawing.Point(83, 155);
            this.txtNoLen.Name = "txtNoLen";
            this.txtNoLen.Size = new System.Drawing.Size(293, 21);
            this.txtNoLen.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(24, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "号码前缀";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(83, 128);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(293, 21);
            this.txtPrefix.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(14, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "*";
            // 
            // chkStopUse
            // 
            this.chkStopUse.AutoSize = true;
            this.chkStopUse.Location = new System.Drawing.Point(83, 440);
            this.chkStopUse.Name = "chkStopUse";
            this.chkStopUse.Size = new System.Drawing.Size(72, 16);
            this.chkStopUse.TabIndex = 36;
            this.chkStopUse.Text = "是否停用";
            this.chkStopUse.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "队列描述";
            // 
            // txtDes
            // 
            this.txtDes.Location = new System.Drawing.Point(83, 305);
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(293, 129);
            this.txtDes.TabIndex = 34;
            this.txtDes.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(24, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "队列名称";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQueueName
            // 
            this.txtQueueName.Location = new System.Drawing.Point(83, 101);
            this.txtQueueName.Name = "txtQueueName";
            this.txtQueueName.Size = new System.Drawing.Size(293, 21);
            this.txtQueueName.TabIndex = 33;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 23);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(545, 585);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "queue.ico");
            this.imageList1.Images.SetKeyName(1, "house.ico");
            // 
            // listView2
            // 
            this.listView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView2.FullRowSelect = true;
            this.listView2.HideSelection = false;
            this.listView2.LargeImageList = this.imageList1;
            this.listView2.Location = new System.Drawing.Point(0, 440);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(545, 168);
            this.listView2.SmallImageList = this.imageList1;
            this.listView2.TabIndex = 11;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(0, 424);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2);
            this.label2.Size = new System.Drawing.Size(545, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "队列房间";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 421);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(545, 3);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // frmQueueManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 608);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmQueueManager";
            this.Text = "队列管理";
            this.Load += new System.EventHandler(this.frmQueueManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butModify;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button butReleationRoom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkStopUse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtDes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQueueName;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCallStation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNoLen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button butInsertPar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox rtbCallFormat;
    }
}