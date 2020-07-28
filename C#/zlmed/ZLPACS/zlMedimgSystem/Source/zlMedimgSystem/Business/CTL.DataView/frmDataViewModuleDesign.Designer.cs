namespace zlMedimgSystem.CTL.DataView
{
    partial class frmDataViewModuleDesign
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxDBAlias = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataViewLayout1 = new zlMedimgSystem.CTL.DataView.DataViewLayout();
            this.timer1 = new System.Windows.Forms.Timer();
            this.toolStripEx1 = new zlMedimgSystem.BusinessBase.Controls.ToolStripEx();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripEx2 = new zlMedimgSystem.BusinessBase.Controls.ToolStripEx();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNull = new System.Windows.Forms.ToolStripButton();
            this.tsbGroup = new System.Windows.Forms.ToolStripButton();
            this.tsbLab = new System.Windows.Forms.ToolStripButton();
            this.tsbTxt = new System.Windows.Forms.ToolStripButton();
            this.tsbCbx = new System.Windows.Forms.ToolStripButton();
            this.tsbDtp = new System.Windows.Forms.ToolStripButton();
            this.tsbChkBox = new System.Windows.Forms.ToolStripButton();
            this.tsbView = new System.Windows.Forms.ToolStripButton();
            this.tsbVerify = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStripEx1.SuspendLayout();
            this.toolStripEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGrid1.Location = new System.Drawing.Point(596, 62);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(204, 366);
            this.propertyGrid1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter3);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 366);
            this.panel1.TabIndex = 2;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter3.Location = new System.Drawing.Point(0, 239);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(302, 3);
            this.splitter3.TabIndex = 9;
            this.splitter3.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(302, 215);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(0, 242);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(302, 124);
            this.listBox1.TabIndex = 0;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbxDBAlias);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(302, 27);
            this.panel3.TabIndex = 8;
            // 
            // cbxDBAlias
            // 
            this.cbxDBAlias.FormattingEnabled = true;
            this.cbxDBAlias.Location = new System.Drawing.Point(54, 4);
            this.cbxDBAlias.Name = "cbxDBAlias";
            this.cbxDBAlias.Size = new System.Drawing.Size(241, 20);
            this.cbxDBAlias.TabIndex = 1;
            this.cbxDBAlias.SelectedIndexChanged += new System.EventHandler(this.cbxDBAlias_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据源";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(593, 62);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 366);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(302, 62);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 366);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataViewLayout1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(305, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 366);
            this.panel2.TabIndex = 6;
            // 
            // dataViewLayout1
            // 
            this.dataViewLayout1.DBHelper = null;
            this.dataViewLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewLayout1.IsDesignModel = false;
            this.dataViewLayout1.Location = new System.Drawing.Point(0, 0);
            this.dataViewLayout1.Name = "dataViewLayout1";
            this.dataViewLayout1.SimpleState = false;
            this.dataViewLayout1.Size = new System.Drawing.Size(288, 366);
            this.dataViewLayout1.TabIndex = 0;
            this.dataViewLayout1.ThridDBHelper = null;
            this.dataViewLayout1.OnSelDesign += new zlMedimgSystem.CTL.DataView.SelDesignControl(this.dataViewLayout1_OnSelDesign);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbView,
            this.tsbVerify,
            this.toolStripSeparator1,
            this.tsbDel,
            this.toolStripSeparator3,
            this.tsbSave,
            this.tsbExit});
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Size = new System.Drawing.Size(800, 31);
            this.toolStripEx1.TabIndex = 0;
            this.toolStripEx1.Text = "toolStripEx1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripEx2
            // 
            this.toolStripEx2.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStripEx2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripEx2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNull,
            this.tsbGroup,
            this.toolStripSeparator2,
            this.tsbLab,
            this.tsbTxt,
            this.tsbCbx,
            this.tsbDtp,
            this.tsbChkBox});
            this.toolStripEx2.Location = new System.Drawing.Point(0, 31);
            this.toolStripEx2.Name = "toolStripEx2";
            this.toolStripEx2.Size = new System.Drawing.Size(800, 31);
            this.toolStripEx2.TabIndex = 8;
            this.toolStripEx2.Text = "toolStripEx2";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbNull
            // 
            this.tsbNull.Image = global::zlMedimgSystem.CTL.DataView.Properties.Resources.splitrow;
            this.tsbNull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNull.Name = "tsbNull";
            this.tsbNull.Size = new System.Drawing.Size(72, 28);
            this.tsbNull.Text = "分割行";
            this.tsbNull.Click += new System.EventHandler(this.tsbNull_Click);
            // 
            // tsbGroup
            // 
            this.tsbGroup.Image = global::zlMedimgSystem.CTL.DataView.Properties.Resources.groupelement;
            this.tsbGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGroup.Name = "tsbGroup";
            this.tsbGroup.Size = new System.Drawing.Size(60, 28);
            this.tsbGroup.Text = "分组";
            this.tsbGroup.Click += new System.EventHandler(this.tsbGroup_Click);
            // 
            // tsbLab
            // 
            this.tsbLab.Image = global::zlMedimgSystem.CTL.DataView.Properties.Resources.label;
            this.tsbLab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLab.Name = "tsbLab";
            this.tsbLab.Size = new System.Drawing.Size(60, 28);
            this.tsbLab.Text = "标签";
            this.tsbLab.Click += new System.EventHandler(this.tsbLab_Click);
            // 
            // tsbTxt
            // 
            this.tsbTxt.Image = global::zlMedimgSystem.CTL.DataView.Properties.Resources.textbox1;
            this.tsbTxt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTxt.Name = "tsbTxt";
            this.tsbTxt.Size = new System.Drawing.Size(72, 28);
            this.tsbTxt.Text = "文本框";
            this.tsbTxt.Click += new System.EventHandler(this.tsbTxt_Click);
            // 
            // tsbCbx
            // 
            this.tsbCbx.Image = global::zlMedimgSystem.CTL.DataView.Properties.Resources.cbxbox1;
            this.tsbCbx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCbx.Name = "tsbCbx";
            this.tsbCbx.Size = new System.Drawing.Size(72, 28);
            this.tsbCbx.Text = "下拉框";
            this.tsbCbx.Click += new System.EventHandler(this.tsbCbx_Click);
            // 
            // tsbDtp
            // 
            this.tsbDtp.Image = global::zlMedimgSystem.CTL.DataView.Properties.Resources.dtpbox;
            this.tsbDtp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDtp.Name = "tsbDtp";
            this.tsbDtp.Size = new System.Drawing.Size(72, 28);
            this.tsbDtp.Text = "日期框";
            this.tsbDtp.Click += new System.EventHandler(this.tsbDtp_Click);
            // 
            // tsbChkBox
            // 
            this.tsbChkBox.Image = global::zlMedimgSystem.CTL.DataView.Properties.Resources._unchecked;
            this.tsbChkBox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbChkBox.Name = "tsbChkBox";
            this.tsbChkBox.Size = new System.Drawing.Size(72, 28);
            this.tsbChkBox.Text = "复选框";
            this.tsbChkBox.Click += new System.EventHandler(this.tsbChkBox_Click);
            // 
            // tsbView
            // 
            this.tsbView.Image = global::zlMedimgSystem.CTL.DataView.Properties.Resources.windowview;
            this.tsbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbView.Name = "tsbView";
            this.tsbView.Size = new System.Drawing.Size(60, 28);
            this.tsbView.Text = "预览";
            this.tsbView.Click += new System.EventHandler(this.tsbView_Click);
            // 
            // tsbVerify
            // 
            this.tsbVerify.Image = global::zlMedimgSystem.CTL.DataView.Properties.Resources.debug_view;
            this.tsbVerify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVerify.Name = "tsbVerify";
            this.tsbVerify.Size = new System.Drawing.Size(60, 28);
            this.tsbVerify.Text = "验证";
            this.tsbVerify.Click += new System.EventHandler(this.tsbVerify_Click);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = global::zlMedimgSystem.CTL.DataView.Properties.Resources.delete2;
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(60, 28);
            this.tsbDel.Text = "删除";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = global::zlMedimgSystem.CTL.DataView.Properties.Resources.disk_blue;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(60, 28);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::zlMedimgSystem.CTL.DataView.Properties.Resources.exit;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(60, 28);
            this.tsbExit.Text = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // frmDataViewModuleDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripEx2);
            this.Controls.Add(this.toolStripEx1);
            this.Name = "frmDataViewModuleDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmDataViewModuleDesign_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.toolStripEx2.ResumeLayout(false);
            this.toolStripEx2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BusinessBase.Controls.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbView;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel2;
        private DataViewLayout dataViewLayout1;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton tsbVerify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbxDBAlias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private BusinessBase.Controls.ToolStripEx toolStripEx2;
        private System.Windows.Forms.ToolStripButton tsbNull;
        private System.Windows.Forms.ToolStripButton tsbLab;
        private System.Windows.Forms.ToolStripButton tsbTxt;
        private System.Windows.Forms.ToolStripButton tsbCbx;
        private System.Windows.Forms.ToolStripButton tsbDtp;
        private System.Windows.Forms.ToolStripButton tsbChkBox;
        private System.Windows.Forms.ToolStripButton tsbGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}