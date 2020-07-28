namespace zlMedimgSystem.CTL.Tools
{
    partial class frmToolsDesign
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
            this.butSure = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.toolsConfig1 = new zlMedimgSystem.BusinessBase.Controls.ToolsConfig();
            this.SuspendLayout();
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(644, 394);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 15;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(725, 394);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 16;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // toolsConfig1
            // 
            this.toolsConfig1.Location = new System.Drawing.Point(12, 12);
            this.toolsConfig1.Name = "toolsConfig1";
            this.toolsConfig1.Size = new System.Drawing.Size(788, 376);
            this.toolsConfig1.TabIndex = 17;
            this.toolsConfig1.ToolsDesign = null;
            // 
            // frmToolsDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 429);
            this.Controls.Add(this.toolsConfig1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmToolsDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmToolsDesign_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.Button butCancel;
        private BusinessBase.Controls.ToolsConfig toolsConfig1;
    }
}