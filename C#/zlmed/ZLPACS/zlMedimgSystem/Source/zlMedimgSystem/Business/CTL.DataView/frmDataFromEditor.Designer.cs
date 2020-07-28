namespace zlMedimgSystem.CTL.DataView
{
    partial class frmDataFromEditor
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butCancel = new System.Windows.Forms.Button();
            this.butTest = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxPars = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbxDBAlias = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 135);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(436, 209);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butCancel);
            this.panel1.Controls.Add(this.butTest);
            this.panel1.Controls.Add(this.butSure);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 344);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 46);
            this.panel1.TabIndex = 1;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(517, 11);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 2;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butTest
            // 
            this.butTest.Location = new System.Drawing.Point(12, 11);
            this.butTest.Name = "butTest";
            this.butTest.Size = new System.Drawing.Size(75, 23);
            this.butTest.TabIndex = 1;
            this.butTest.Text = "SQL测试(&T)";
            this.butTest.UseVisualStyleBackColor = true;
            this.butTest.Click += new System.EventHandler(this.butTest_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(436, 11);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 0;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(595, 106);
            this.label1.TabIndex = 2;
            this.label1.Text = "    数据来源支持sql查询和普通文本，不同方式使用的配置方式分别如下：\r\n\r\n    1.如果是sql查询，则返回字段需要包含数据值，数据描述，进行数据检索时" +
    "将使用数据值作为查询条件；\r\n\r\n    2.如果是普通文本，则使用“-”符号分割数据值和数据描述，如“0-男”,当要返回多值时，使用“;”分号分离，如“0-男" +
    ";1-女;2-未明”；\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBoxPars
            // 
            this.listBoxPars.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxPars.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxPars.FormattingEnabled = true;
            this.listBoxPars.ItemHeight = 12;
            this.listBoxPars.Location = new System.Drawing.Point(436, 135);
            this.listBoxPars.Name = "listBoxPars";
            this.listBoxPars.Size = new System.Drawing.Size(159, 209);
            this.listBoxPars.TabIndex = 3;
            this.listBoxPars.DoubleClick += new System.EventHandler(this.listBoxPars_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbxDBAlias);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(595, 29);
            this.panel2.TabIndex = 4;
            // 
            // cbxDBAlias
            // 
            this.cbxDBAlias.FormattingEnabled = true;
            this.cbxDBAlias.Location = new System.Drawing.Point(52, 4);
            this.cbxDBAlias.Name = "cbxDBAlias";
            this.cbxDBAlias.Size = new System.Drawing.Size(241, 20);
            this.cbxDBAlias.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据源";
            // 
            // frmDataFromEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 390);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.listBoxPars);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataFromEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据源配置";
            this.Load += new System.EventHandler(this.frmDataFromEditor_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butTest;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.ListBox listBoxPars;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbxDBAlias;
        private System.Windows.Forms.Label label2;
    }
}