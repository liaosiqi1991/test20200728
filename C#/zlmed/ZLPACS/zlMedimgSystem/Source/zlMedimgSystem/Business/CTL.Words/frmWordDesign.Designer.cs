namespace zlMedimgSystem.CTL.Words
{
    partial class frmWordDesign
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
            this.chkWordWrite = new System.Windows.Forms.CheckBox();
            this.chkWordLocate = new System.Windows.Forms.CheckBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.toolsConfig1 = new zlMedimgSystem.BusinessBase.Controls.ToolsConfig();
            this.SuspendLayout();
            // 
            // chkWordWrite
            // 
            this.chkWordWrite.AutoSize = true;
            this.chkWordWrite.Checked = true;
            this.chkWordWrite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWordWrite.Location = new System.Drawing.Point(90, 290);
            this.chkWordWrite.Name = "chkWordWrite";
            this.chkWordWrite.Size = new System.Drawing.Size(72, 16);
            this.chkWordWrite.TabIndex = 32;
            this.chkWordWrite.Text = "词句写入";
            this.chkWordWrite.UseVisualStyleBackColor = true;
            // 
            // chkWordLocate
            // 
            this.chkWordLocate.AutoSize = true;
            this.chkWordLocate.Checked = true;
            this.chkWordLocate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWordLocate.Location = new System.Drawing.Point(12, 290);
            this.chkWordLocate.Name = "chkWordLocate";
            this.chkWordLocate.Size = new System.Drawing.Size(72, 16);
            this.chkWordLocate.TabIndex = 31;
            this.chkWordLocate.Text = "词句定位";
            this.chkWordLocate.UseVisualStyleBackColor = true;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(735, 286);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 30;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(654, 286);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 29;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // toolsConfig1
            // 
            this.toolsConfig1.Location = new System.Drawing.Point(12, 12);
            this.toolsConfig1.Name = "toolsConfig1";
            this.toolsConfig1.Size = new System.Drawing.Size(798, 268);
            this.toolsConfig1.TabIndex = 33;
            this.toolsConfig1.ToolsDesign = null;
            // 
            // frmWordDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 322);
            this.Controls.Add(this.toolsConfig1);
            this.Controls.Add(this.chkWordWrite);
            this.Controls.Add(this.chkWordLocate);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWordDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmWordDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkWordWrite;
        private System.Windows.Forms.CheckBox chkWordLocate;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private BusinessBase.Controls.ToolsConfig toolsConfig1;
    }
}