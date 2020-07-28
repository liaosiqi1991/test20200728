namespace zlMedimgSystem.CTL.DataView
{
    partial class frmTest
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
            this.dataViewLayout1 = new zlMedimgSystem.CTL.DataView.DataViewLayout();
            this.SuspendLayout();
            // 
            // dataViewLayout1
            // 
            this.dataViewLayout1.ThridDBHelper = null;
            this.dataViewLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewLayout1.IsDesignModel = false;
            this.dataViewLayout1.Location = new System.Drawing.Point(0, 0);
            this.dataViewLayout1.Name = "dataViewLayout1";
            this.dataViewLayout1.SimpleState = false;
            this.dataViewLayout1.Size = new System.Drawing.Size(800, 450);
            this.dataViewLayout1.TabIndex = 0;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataViewLayout1);
            this.Name = "frmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试预览";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DataViewLayout dataViewLayout1;
    }
}