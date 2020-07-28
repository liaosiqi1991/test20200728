namespace zlMedimgSystem.QueryDesign
{
    partial class frmQueryFilter
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
            this.butSure = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.queryLayout1 = new zlMedimgSystem.QueryDesign.QueryFace();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butSure);
            this.panel1.Controls.Add(this.butCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(487, 41);
            this.panel1.TabIndex = 0;
            // 
            // butSure
            // 
            this.butSure.Dock = System.Windows.Forms.DockStyle.Right;
            this.butSure.Location = new System.Drawing.Point(331, 6);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 29);
            this.butSure.TabIndex = 0;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // butCancel
            // 
            this.butCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.butCancel.Location = new System.Drawing.Point(406, 6);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 29);
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // queryLayout1
            // 
            this.queryLayout1.AutoSize = true;
            this.queryLayout1.DBHelper = null;
            this.queryLayout1.Dock = System.Windows.Forms.DockStyle.Top;
            this.queryLayout1.IsDesignModel = false;
            this.queryLayout1.Location = new System.Drawing.Point(0, 0);
            this.queryLayout1.Name = "queryLayout1";
            this.queryLayout1.SimpleState = false;
            this.queryLayout1.Size = new System.Drawing.Size(487, 20);
            this.queryLayout1.TabIndex = 1;
            this.queryLayout1.Resize += new System.EventHandler(this.queryLayout1_Resize);
            // 
            // frmQueryFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(487, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.queryLayout1);
            this.Name = "frmQueryFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQueryFilter_FormClosed);
            this.Load += new System.EventHandler(this.frmQueryFilter_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private QueryFace queryLayout1;
    }
}