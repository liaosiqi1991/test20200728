namespace zlMedimgSystem.BusinessBase.Controls
{
    partial class FontEditor
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxFontName = new System.Windows.Forms.ComboBox();
            this.labView = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nuSize = new System.Windows.Forms.NumericUpDown();
            this.chkItalic = new System.Windows.Forms.CheckBox();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuSize)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labView);
            this.panel1.Controls.Add(this.cbxFontName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 56);
            this.panel1.TabIndex = 10;
            // 
            // cbxFontName
            // 
            this.cbxFontName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbxFontName.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFontName.FormattingEnabled = true;
            this.cbxFontName.Location = new System.Drawing.Point(0, 0);
            this.cbxFontName.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.cbxFontName.Name = "cbxFontName";
            this.cbxFontName.Size = new System.Drawing.Size(175, 20);
            this.cbxFontName.TabIndex = 0;
            this.cbxFontName.SelectedIndexChanged += new System.EventHandler(this.cbxFontName_SelectedIndexChanged);
            // 
            // labView
            // 
            this.labView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labView.Location = new System.Drawing.Point(0, 20);
            this.labView.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labView.Name = "labView";
            this.labView.Size = new System.Drawing.Size(175, 36);
            this.labView.TabIndex = 1;
            this.labView.Text = "演示文本";
            this.labView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.chkBold);
            this.panel2.Controls.Add(this.chkItalic);
            this.panel2.Controls.Add(this.nuSize);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(175, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(41, 56);
            this.panel2.TabIndex = 11;
            // 
            // nuSize
            // 
            this.nuSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nuSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nuSize.DecimalPlaces = 1;
            this.nuSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuSize.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nuSize.Location = new System.Drawing.Point(0, 0);
            this.nuSize.Margin = new System.Windows.Forms.Padding(0);
            this.nuSize.Name = "nuSize";
            this.nuSize.Size = new System.Drawing.Size(41, 17);
            this.nuSize.TabIndex = 6;
            this.nuSize.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nuSize.ValueChanged += new System.EventHandler(this.nuSize_ValueChanged);
            // 
            // chkItalic
            // 
            this.chkItalic.AutoSize = true;
            this.chkItalic.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkItalic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkItalic.Location = new System.Drawing.Point(0, 38);
            this.chkItalic.Margin = new System.Windows.Forms.Padding(0);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.chkItalic.Size = new System.Drawing.Size(41, 18);
            this.chkItalic.TabIndex = 8;
            this.chkItalic.Text = "斜";
            this.chkItalic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkItalic.UseVisualStyleBackColor = true;
            this.chkItalic.CheckedChanged += new System.EventHandler(this.chkItalic_CheckedChanged);
            // 
            // chkBold
            // 
            this.chkBold.AutoSize = true;
            this.chkBold.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBold.Location = new System.Drawing.Point(0, 20);
            this.chkBold.Margin = new System.Windows.Forms.Padding(0);
            this.chkBold.Name = "chkBold";
            this.chkBold.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.chkBold.Size = new System.Drawing.Size(41, 18);
            this.chkBold.TabIndex = 9;
            this.chkBold.Text = "粗";
            this.chkBold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBold.UseVisualStyleBackColor = true;
            this.chkBold.CheckedChanged += new System.EventHandler(this.chkBold_CheckedChanged);
            // 
            // FontEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FontEditor";
            this.Size = new System.Drawing.Size(216, 56);
            this.Load += new System.EventHandler(this.FontEditor_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labView;
        private System.Windows.Forms.ComboBox cbxFontName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.CheckBox chkItalic;
        private System.Windows.Forms.NumericUpDown nuSize;
    }
}
