namespace zlMedimgSystem.BaseSettings
{
    partial class frmReleationRooms
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.butSelAll = new System.Windows.Forms.Button();
            this.butClearSel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(401, 356);
            this.checkedListBox1.TabIndex = 0;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(338, 384);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(257, 384);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 2;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // butSelAll
            // 
            this.butSelAll.Location = new System.Drawing.Point(12, 384);
            this.butSelAll.Name = "butSelAll";
            this.butSelAll.Size = new System.Drawing.Size(58, 23);
            this.butSelAll.TabIndex = 3;
            this.butSelAll.Text = "全选(&A)";
            this.butSelAll.UseVisualStyleBackColor = true;
            this.butSelAll.Click += new System.EventHandler(this.butSelAll_Click);
            // 
            // butClearSel
            // 
            this.butClearSel.Location = new System.Drawing.Point(76, 384);
            this.butClearSel.Name = "butClearSel";
            this.butClearSel.Size = new System.Drawing.Size(58, 23);
            this.butClearSel.TabIndex = 4;
            this.butClearSel.Text = "全清(&L)";
            this.butClearSel.UseVisualStyleBackColor = true;
            this.butClearSel.Click += new System.EventHandler(this.butClearSel_Click);
            // 
            // frmReleationRooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 423);
            this.Controls.Add(this.butClearSel);
            this.Controls.Add(this.butSelAll);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReleationRooms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "包含房间";
            this.Load += new System.EventHandler(this.frmReleationRooms_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.Button butSelAll;
        private System.Windows.Forms.Button butClearSel;
    }
}