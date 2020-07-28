namespace zlMedimgSystem.BaseSettings
{
    partial class frmDesignParent
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsLabState = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerDesign = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsbServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSplit1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(302, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 707);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbServer,
            this.tssSplit1,
            this.tsLabState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 707);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsLabState
            // 
            this.tsLabState.Name = "tsLabState";
            this.tsLabState.Size = new System.Drawing.Size(935, 17);
            this.tsLabState.Spring = true;
            this.tsLabState.Text = "窗体设计";
            this.tsLabState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerDesign
            // 
            this.timerDesign.Interval = 300;
            this.timerDesign.Tick += new System.EventHandler(this.timerDesign_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BackgroundImage = global::zlMedimgSystem.BaseSettings.Properties.Resources.element2;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(916, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(92, 707);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImage = global::zlMedimgSystem.BaseSettings.Properties.Resources.element2;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 707);
            this.panel1.TabIndex = 1;
            // 
            // tsbServer
            // 
            this.tsbServer.Name = "tsbServer";
            this.tsbServer.Size = new System.Drawing.Size(47, 17);
            this.tsbServer.Text = "服务器:";
            // 
            // tssSplit1
            // 
            this.tssSplit1.Enabled = false;
            this.tssSplit1.Name = "tssSplit1";
            this.tssSplit1.Size = new System.Drawing.Size(11, 17);
            this.tssSplit1.Text = "|";
            // 
            // frmDesignParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.Name = "frmDesignParent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "窗体设计器";
            this.Load += new System.EventHandler(this.frmDesignParent_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timerDesign;
        private System.Windows.Forms.ToolStripStatusLabel tsLabState;
        private System.Windows.Forms.ToolStripStatusLabel tsbServer;
        private System.Windows.Forms.ToolStripStatusLabel tssSplit1;
    }
}