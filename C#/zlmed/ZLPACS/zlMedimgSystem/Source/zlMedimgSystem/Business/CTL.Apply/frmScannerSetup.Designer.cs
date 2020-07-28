namespace zlMedimgSystem.CTL.Apply
{
    partial class frmScannerSetup
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboScanner = new DevExpress.XtraEditors.ComboBoxEdit();
            this.butOK = new DevExpress.XtraEditors.SimpleButton();
            this.butCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboScanner.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(48, 92);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(120, 29);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "选择扫描仪";
            // 
            // cboScanner
            // 
            this.cboScanner.Location = new System.Drawing.Point(223, 89);
            this.cboScanner.Name = "cboScanner";
            this.cboScanner.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboScanner.Size = new System.Drawing.Size(339, 36);
            this.cboScanner.TabIndex = 1;
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(134, 180);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(139, 54);
            this.butOK.TabIndex = 2;
            this.butOK.Text = "确定";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(389, 180);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(139, 54);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "取消";
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // frmScannerSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(619, 273);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.cboScanner);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.Name = "frmScannerSetup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "扫描仪设置";
            this.Load += new System.EventHandler(this.frmScannerSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboScanner.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboScanner;
        private DevExpress.XtraEditors.SimpleButton butOK;
        private DevExpress.XtraEditors.SimpleButton butCancel;
    }
}