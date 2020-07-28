namespace zlMedimgSystem.CTL.Apply
{
    partial class frmApplyScan
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
            this.btnScan = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnScanSetup = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panelPicImage = new System.Windows.Forms.Panel();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelPicImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(146, 23);
            this.btnScan.Margin = new System.Windows.Forms.Padding(6);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(112, 46);
            this.btnScan.TabIndex = 21;
            this.btnScan.Text = "扫描";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(442, 23);
            this.btnDel.Margin = new System.Windows.Forms.Padding(6);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(112, 46);
            this.btnDel.TabIndex = 22;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1034, 23);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 46);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "退出";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnScanSetup
            // 
            this.btnScanSetup.Location = new System.Drawing.Point(738, 23);
            this.btnScanSetup.Margin = new System.Windows.Forms.Padding(6);
            this.btnScanSetup.Name = "btnScanSetup";
            this.btnScanSetup.Size = new System.Drawing.Size(112, 46);
            this.btnScanSetup.TabIndex = 26;
            this.btnScanSetup.Text = "扫描设置";
            this.btnScanSetup.Click += new System.EventHandler(this.btnScanSetup_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(251, 775);
            this.flowLayoutPanel.TabIndex = 0;
            this.flowLayoutPanel.Resize += new System.EventHandler(this.flowLayoutPanel_Resize);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnScan);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnScanSetup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 775);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1333, 98);
            this.panel1.TabIndex = 28;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.flowLayoutPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelPicImage);
            this.splitContainer.Size = new System.Drawing.Size(1333, 775);
            this.splitContainer.SplitterDistance = 251;
            this.splitContainer.TabIndex = 29;
            // 
            // panelPicImage
            // 
            this.panelPicImage.AutoScroll = true;
            this.panelPicImage.Controls.Add(this.picImage);
            this.panelPicImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPicImage.Location = new System.Drawing.Point(0, 0);
            this.panelPicImage.Name = "panelPicImage";
            this.panelPicImage.Size = new System.Drawing.Size(1078, 775);
            this.panelPicImage.TabIndex = 0;
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(6, 3);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(1060, 766);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // frmApplyScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 873);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panel1);
            this.Name = "frmApplyScan";
            this.Text = "扫描申请单";
            this.panel1.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelPicImage.ResumeLayout(false);
            this.panelPicImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnScan;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnScanSetup;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panelPicImage;
        private System.Windows.Forms.PictureBox picImage;
    }
}