namespace zlMedimgSystem.BaseSettings
{
    partial class frmWordConstruct
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWordConstruct));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsCbxType = new System.Windows.Forms.ToolStripComboBox();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpFree = new System.Windows.Forms.TabPage();
            this.rtbFreeContext = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lvFreeList = new System.Windows.Forms.ListView();
            this.tpStruct = new System.Windows.Forms.TabPage();
            this.tpModule = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpFree.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsCbxType,
            this.toolStripSeparator1,
            this.tsbSave,
            this.tsbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(831, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 28);
            this.toolStripLabel1.Text = "构造类型";
            // 
            // tsCbxType
            // 
            this.tsCbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCbxType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tsCbxType.Items.AddRange(new object[] {
            "文本录入",
            "结构录入",
            "模板录入"});
            this.tsCbxType.Name = "tsCbxType";
            this.tsCbxType.Size = new System.Drawing.Size(121, 31);
            this.tsCbxType.SelectedIndexChanged += new System.EventHandler(this.tsCbxType_SelectedIndexChanged);
            // 
            // tsbSave
            // 
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = global::zlMedimgSystem.BaseSettings.Properties.Resources.disk_blue1;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(60, 28);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::zlMedimgSystem.BaseSettings.Properties.Resources.exit1;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(60, 28);
            this.tsbExit.Text = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpFree);
            this.tabControl1.Controls.Add(this.tpStruct);
            this.tabControl1.Controls.Add(this.tpModule);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(80, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(831, 470);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tpFree
            // 
            this.tpFree.Controls.Add(this.rtbFreeContext);
            this.tpFree.Controls.Add(this.splitter1);
            this.tpFree.Controls.Add(this.lvFreeList);
            this.tpFree.Location = new System.Drawing.Point(4, 22);
            this.tpFree.Name = "tpFree";
            this.tpFree.Padding = new System.Windows.Forms.Padding(3);
            this.tpFree.Size = new System.Drawing.Size(823, 444);
            this.tpFree.TabIndex = 0;
            this.tpFree.Text = "文本录入";
            this.tpFree.UseVisualStyleBackColor = true;
            // 
            // rtbFreeContext
            // 
            this.rtbFreeContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbFreeContext.Location = new System.Drawing.Point(261, 3);
            this.rtbFreeContext.Name = "rtbFreeContext";
            this.rtbFreeContext.Size = new System.Drawing.Size(559, 438);
            this.rtbFreeContext.TabIndex = 2;
            this.rtbFreeContext.Text = "";
            this.rtbFreeContext.TextChanged += new System.EventHandler(this.rtbFreeContext_TextChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(258, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 438);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // lvFreeList
            // 
            this.lvFreeList.CheckBoxes = true;
            this.lvFreeList.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvFreeList.FullRowSelect = true;
            this.lvFreeList.HideSelection = false;
            this.lvFreeList.Location = new System.Drawing.Point(3, 3);
            this.lvFreeList.MultiSelect = false;
            this.lvFreeList.Name = "lvFreeList";
            this.lvFreeList.Size = new System.Drawing.Size(255, 438);
            this.lvFreeList.SmallImageList = this.imageList1;
            this.lvFreeList.TabIndex = 0;
            this.lvFreeList.UseCompatibleStateImageBehavior = false;
            this.lvFreeList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvFreeList_ItemChecked);
            this.lvFreeList.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // tpStruct
            // 
            this.tpStruct.Location = new System.Drawing.Point(4, 22);
            this.tpStruct.Name = "tpStruct";
            this.tpStruct.Padding = new System.Windows.Forms.Padding(3);
            this.tpStruct.Size = new System.Drawing.Size(823, 444);
            this.tpStruct.TabIndex = 1;
            this.tpStruct.Text = "结构录入";
            this.tpStruct.UseVisualStyleBackColor = true;
            // 
            // tpModule
            // 
            this.tpModule.Location = new System.Drawing.Point(4, 22);
            this.tpModule.Name = "tpModule";
            this.tpModule.Padding = new System.Windows.Forms.Padding(3);
            this.tpModule.Size = new System.Drawing.Size(823, 444);
            this.tpModule.TabIndex = 2;
            this.tpModule.Text = "模板录入";
            this.tpModule.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 501);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(831, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "text_normal.ico");
            this.imageList1.Images.SetKeyName(1, "text.ico");
            // 
            // frmWordConstruct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 523);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmWordConstruct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "词句构造";
            this.Load += new System.EventHandler(this.frmWordConstruct_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpFree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tsCbxType;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpFree;
        private System.Windows.Forms.TabPage tpStruct;
        private System.Windows.Forms.TabPage tpModule;
        private System.Windows.Forms.RichTextBox rtbFreeContext;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListView lvFreeList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ImageList imageList1;
    }
}