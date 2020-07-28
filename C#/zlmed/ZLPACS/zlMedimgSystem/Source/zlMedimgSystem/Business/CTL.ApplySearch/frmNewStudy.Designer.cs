namespace zlMedimgSystem.CTL.ApplySearch
{
    partial class frmNewStudy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewStudy));
            this.panel1 = new System.Windows.Forms.Panel();
            this.trvItems = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbxModality = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblBodypart = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lstWays = new System.Windows.Forms.ListView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lstBodyPart = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trvItems);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 329);
            this.panel1.TabIndex = 10;
            // 
            // trvItems
            // 
            this.trvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvItems.FullRowSelect = true;
            this.trvItems.HideSelection = false;
            this.trvItems.ImageIndex = 0;
            this.trvItems.ImageList = this.imgList;
            this.trvItems.Location = new System.Drawing.Point(0, 41);
            this.trvItems.Margin = new System.Windows.Forms.Padding(6);
            this.trvItems.Name = "trvItems";
            this.trvItems.SelectedImageIndex = 0;
            this.trvItems.Size = new System.Drawing.Size(923, 288);
            this.trvItems.TabIndex = 12;
            this.trvItems.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvItems_BeforeExpand);
            this.trvItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvItems_AfterSelect);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "folder_closed.png");
            this.imgList.Images.SetKeyName(1, "document_plain.png");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbxModality);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(923, 41);
            this.panel2.TabIndex = 11;
            // 
            // cbxModality
            // 
            this.cbxModality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxModality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxModality.FormattingEnabled = true;
            this.cbxModality.Location = new System.Drawing.Point(177, 0);
            this.cbxModality.Margin = new System.Windows.Forms.Padding(7);
            this.cbxModality.Name = "cbxModality";
            this.cbxModality.Size = new System.Drawing.Size(746, 22);
            this.cbxModality.TabIndex = 2;
            this.cbxModality.SelectedIndexChanged += new System.EventHandler(this.cbxModality_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(7);
            this.label1.Size = new System.Drawing.Size(177, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "影像类别：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblBodypart);
            this.panel4.Controls.Add(this.lblItem);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnOK);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 616);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(923, 166);
            this.panel4.TabIndex = 38;
            // 
            // lblBodypart
            // 
            this.lblBodypart.AutoSize = true;
            this.lblBodypart.Location = new System.Drawing.Point(172, 78);
            this.lblBodypart.Name = "lblBodypart";
            this.lblBodypart.Size = new System.Drawing.Size(0, 14);
            this.lblBodypart.TabIndex = 41;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(172, 30);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(0, 14);
            this.lblItem.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 39;
            this.label3.Text = "部位方法";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 38;
            this.label2.Text = "检查项目";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(668, 121);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 38);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(505, 121);
            this.btnOK.Margin = new System.Windows.Forms.Padding(6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 38);
            this.btnOK.TabIndex = 36;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 329);
            this.splitter2.Margin = new System.Windows.Forms.Padding(6);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(923, 11);
            this.splitter2.TabIndex = 40;
            this.splitter2.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lstWays);
            this.panel5.Controls.Add(this.splitter1);
            this.panel5.Controls.Add(this.lstBodyPart);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 340);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(923, 276);
            this.panel5.TabIndex = 41;
            // 
            // lstWays
            // 
            this.lstWays.CheckBoxes = true;
            this.lstWays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstWays.Enabled = false;
            this.lstWays.FullRowSelect = true;
            this.lstWays.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstWays.HideSelection = false;
            this.lstWays.Location = new System.Drawing.Point(386, 0);
            this.lstWays.Margin = new System.Windows.Forms.Padding(6);
            this.lstWays.MultiSelect = false;
            this.lstWays.Name = "lstWays";
            this.lstWays.Size = new System.Drawing.Size(537, 276);
            this.lstWays.TabIndex = 19;
            this.lstWays.UseCompatibleStateImageBehavior = false;
            this.lstWays.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstWays_ItemChecked);
            this.lstWays.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstWays_MouseClick);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(376, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(6);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 276);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            // 
            // lstBodyPart
            // 
            this.lstBodyPart.CheckBoxes = true;
            this.lstBodyPart.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstBodyPart.Enabled = false;
            this.lstBodyPart.FullRowSelect = true;
            this.lstBodyPart.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstBodyPart.HideSelection = false;
            this.lstBodyPart.Location = new System.Drawing.Point(0, 0);
            this.lstBodyPart.Margin = new System.Windows.Forms.Padding(6);
            this.lstBodyPart.MultiSelect = false;
            this.lstBodyPart.Name = "lstBodyPart";
            this.lstBodyPart.Size = new System.Drawing.Size(376, 276);
            this.lstBodyPart.TabIndex = 17;
            this.lstBodyPart.UseCompatibleStateImageBehavior = false;
            this.lstBodyPart.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstBodyPart_ItemChecked);
            this.lstBodyPart.SelectedIndexChanged += new System.EventHandler(this.lstBodyPart_SelectedIndexChanged);
            // 
            // frmNewStudy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 782);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmNewStudy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增检查申请";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxModality;
        private System.Windows.Forms.TreeView trvItems;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblBodypart;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListView lstWays;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListView lstBodyPart;
    }
}