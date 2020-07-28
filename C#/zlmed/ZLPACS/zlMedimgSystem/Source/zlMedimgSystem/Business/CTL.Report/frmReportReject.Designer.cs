namespace zlMedimgSystem.CTL.Report
{
    partial class frmReportReject
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
            this.rtbRejectReason = new System.Windows.Forms.RichTextBox();
            this.butSure = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbRejectReason
            // 
            this.rtbRejectReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbRejectReason.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbRejectReason.Location = new System.Drawing.Point(0, 0);
            this.rtbRejectReason.Name = "rtbRejectReason";
            this.rtbRejectReason.Size = new System.Drawing.Size(629, 268);
            this.rtbRejectReason.TabIndex = 0;
            this.rtbRejectReason.Text = "";
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(461, 283);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 28);
            this.butSure.TabIndex = 1;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(542, 283);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 28);
            this.butCancel.TabIndex = 2;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // frmReportReject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 327);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.rtbRejectReason);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportReject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报告驳回";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbRejectReason;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.Button butCancel;
    }
}