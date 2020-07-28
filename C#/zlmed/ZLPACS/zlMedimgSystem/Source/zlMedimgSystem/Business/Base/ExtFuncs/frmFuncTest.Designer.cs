namespace zlMedimgSystem.ExtFuncs
{
    partial class frmFuncTest
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.butSure = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.fcDemo = new zlMedimgSystem.ExtFuncs.FuncControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butSure);
            this.panel1.Controls.Add(this.butCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 409);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(800, 41);
            this.panel1.TabIndex = 0;
            // 
            // butSure
            // 
            this.butSure.Dock = System.Windows.Forms.DockStyle.Right;
            this.butSure.Location = new System.Drawing.Point(644, 6);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 29);
            this.butSure.TabIndex = 1;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // butCancel
            // 
            this.butCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.butCancel.Location = new System.Drawing.Point(719, 6);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 29);
            this.butCancel.TabIndex = 0;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // fcDemo
            // 
            this.fcDemo.DesignState = false;
            this.fcDemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fcDemo.Location = new System.Drawing.Point(0, 0);
            this.fcDemo.Name = "fcDemo";
            this.fcDemo.Size = new System.Drawing.Size(800, 409);
            this.fcDemo.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmFuncTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fcDemo);
            this.Controls.Add(this.panel1);
            this.Name = "frmFuncTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "功能测试";
            this.Load += new System.EventHandler(this.frmFuncTest_Load);
            this.Shown += new System.EventHandler(this.frmFuncTest_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FuncControl fcDemo;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Timer timer1;
    }
}