namespace zlMedimgSystem.CTL.Words
{
    partial class WordsControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordsControl));
            this.menuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sMenuWriteReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.sMenuNewWord = new System.Windows.Forms.ToolStripMenuItem();
            this.sMenuEditWord = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sMenuDelWord = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.tsbFind = new System.Windows.Forms.ToolStripButton();
            this.tsbWrite = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpFree = new System.Windows.Forms.TabPage();
            this.wordContext1 = new zlMedimgSystem.CTL.Words.WordContext();
            this.tpStruct = new System.Windows.Forms.TabPage();
            this.tpModule = new System.Windows.Forms.TabPage();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.menuTree.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpFree.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuTree
            // 
            this.menuTree.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sMenuWriteReport,
            this.toolStripMenuItem3,
            this.sMenuNewWord,
            this.sMenuEditWord,
            this.toolStripMenuItem1,
            this.sMenuDelWord});
            this.menuTree.Name = "menuTree";
            this.menuTree.Size = new System.Drawing.Size(145, 104);
            // 
            // sMenuWriteReport
            // 
            this.sMenuWriteReport.Name = "sMenuWriteReport";
            this.sMenuWriteReport.Size = new System.Drawing.Size(144, 22);
            this.sMenuWriteReport.Text = "写入报告(&W)";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(141, 6);
            // 
            // sMenuNewWord
            // 
            this.sMenuNewWord.Name = "sMenuNewWord";
            this.sMenuNewWord.Size = new System.Drawing.Size(144, 22);
            this.sMenuNewWord.Text = "新增词句(&N)";
            this.sMenuNewWord.Click += new System.EventHandler(this.sMenuNewWord_Click);
            // 
            // sMenuEditWord
            // 
            this.sMenuEditWord.Name = "sMenuEditWord";
            this.sMenuEditWord.Size = new System.Drawing.Size(144, 22);
            this.sMenuEditWord.Text = "编辑词句(&E)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(141, 6);
            // 
            // sMenuDelWord
            // 
            this.sMenuDelWord.Name = "sMenuDelWord";
            this.sMenuDelWord.Size = new System.Drawing.Size(144, 22);
            this.sMenuDelWord.Text = "删除词句(&D)";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 31);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(368, 236);
            this.treeView1.TabIndex = 8;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder_closed.png");
            this.imageList1.Images.SetKeyName(1, "document_plain.png");
            this.imageList1.Images.SetKeyName(2, "blackwrite16x16.ico");
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Gray;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.tsbFind,
            this.tsbWrite});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(368, 31);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "写入词句";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.BackColor = System.Drawing.Color.White;
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.toolStripTextBox1.Size = new System.Drawing.Size(120, 31);
            // 
            // tsbFind
            // 
            this.tsbFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFind.Image = global::zlMedimgSystem.CTL.Words.Properties.Resources.local24x24;
            this.tsbFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFind.Name = "tsbFind";
            this.tsbFind.Size = new System.Drawing.Size(28, 28);
            this.tsbFind.Text = "定位词句";
            // 
            // tsbWrite
            // 
            this.tsbWrite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbWrite.Image = global::zlMedimgSystem.CTL.Words.Properties.Resources.write24x241;
            this.tsbWrite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWrite.Name = "tsbWrite";
            this.tsbWrite.Size = new System.Drawing.Size(28, 28);
            this.tsbWrite.Text = "toolStripButton1";
            this.tsbWrite.Click += new System.EventHandler(this.tsbWrite_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpFree);
            this.tabControl1.Controls.Add(this.tpStruct);
            this.tabControl1.Controls.Add(this.tpModule);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(0, 270);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(368, 258);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 3;
            // 
            // tpFree
            // 
            this.tpFree.Controls.Add(this.wordContext1);
            this.tpFree.Location = new System.Drawing.Point(4, 5);
            this.tpFree.Name = "tpFree";
            this.tpFree.Padding = new System.Windows.Forms.Padding(3);
            this.tpFree.Size = new System.Drawing.Size(360, 249);
            this.tpFree.TabIndex = 0;
            this.tpFree.Text = "文本录入";
            this.tpFree.UseVisualStyleBackColor = true;
            // 
            // wordContext1
            // 
            this.wordContext1.BackColor = System.Drawing.Color.White;
            this.wordContext1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wordContext1.HeadBgColor = System.Drawing.Color.Transparent;
            this.wordContext1.HeadForceColor = System.Drawing.Color.Black;
            this.wordContext1.HeadImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.wordContext1.HeadImageIndex = -1;
            this.wordContext1.HeadWidth = 60;
            this.wordContext1.ImageList = this.imageList1;
            this.wordContext1.ItemBackColor = System.Drawing.Color.Transparent;
            this.wordContext1.ItemCount = 0;
            this.wordContext1.Location = new System.Drawing.Point(3, 3);
            this.wordContext1.Margin = new System.Windows.Forms.Padding(4);
            this.wordContext1.Name = "wordContext1";
            this.wordContext1.SelColor = System.Drawing.Color.Yellow;
            this.wordContext1.Size = new System.Drawing.Size(354, 243);
            this.wordContext1.TabIndex = 0;
            this.wordContext1.OnHeadClick += new System.EventHandler(this.WordContext_Click);
            // 
            // tpStruct
            // 
            this.tpStruct.Location = new System.Drawing.Point(4, 5);
            this.tpStruct.Name = "tpStruct";
            this.tpStruct.Padding = new System.Windows.Forms.Padding(3);
            this.tpStruct.Size = new System.Drawing.Size(360, 249);
            this.tpStruct.TabIndex = 1;
            this.tpStruct.Text = "结构录入";
            this.tpStruct.UseVisualStyleBackColor = true;
            // 
            // tpModule
            // 
            this.tpModule.Location = new System.Drawing.Point(4, 5);
            this.tpModule.Name = "tpModule";
            this.tpModule.Padding = new System.Windows.Forms.Padding(3);
            this.tpModule.Size = new System.Drawing.Size(360, 249);
            this.tpModule.TabIndex = 2;
            this.tpModule.Text = "模板录入";
            this.tpModule.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 267);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(368, 3);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // WordsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WordsControl";
            this.Size = new System.Drawing.Size(368, 528);
            this.menuTree.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpFree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip menuTree;
        private System.Windows.Forms.ToolStripMenuItem sMenuNewWord;
        private System.Windows.Forms.ToolStripMenuItem sMenuEditWord;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sMenuDelWord;
        private System.Windows.Forms.ToolStripMenuItem sMenuWriteReport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton tsbFind;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpFree;
        private System.Windows.Forms.TabPage tpStruct;
        private System.Windows.Forms.TabPage tpModule;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView treeView1;
        private WordContext wordContext1;
        private System.Windows.Forms.ToolStripButton tsbWrite;
        private System.Windows.Forms.Splitter splitter1;
    }
}
