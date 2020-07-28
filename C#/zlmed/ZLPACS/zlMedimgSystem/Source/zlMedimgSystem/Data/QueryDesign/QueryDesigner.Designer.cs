namespace zlMedimgSystem.QueryDesign
{
    partial class QueryDesigner
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
            this.pgDesign = new System.Windows.Forms.PropertyGrid();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.rtbSql = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbPreview = new System.Windows.Forms.RichTextBox();
            this.qcReview = new zlMedimgSystem.QueryDesign.QueryFace();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.timer1 = new System.Windows.Forms.Timer();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgDesign
            // 
            this.pgDesign.Dock = System.Windows.Forms.DockStyle.Right;
            this.pgDesign.HelpVisible = false;
            this.pgDesign.Location = new System.Drawing.Point(622, 0);
            this.pgDesign.Name = "pgDesign";
            this.pgDesign.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.pgDesign.Size = new System.Drawing.Size(186, 523);
            this.pgDesign.TabIndex = 2;
            this.pgDesign.ToolbarVisible = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(619, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 523);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitter3);
            this.panel3.Controls.Add(this.rtbSql);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.rtbPreview);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(268, 523);
            this.panel3.TabIndex = 6;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter3.Location = new System.Drawing.Point(0, 314);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(268, 3);
            this.splitter3.TabIndex = 7;
            this.splitter3.TabStop = false;
            // 
            // rtbSql
            // 
            this.rtbSql.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSql.Location = new System.Drawing.Point(0, 22);
            this.rtbSql.Name = "rtbSql";
            this.rtbSql.Size = new System.Drawing.Size(268, 295);
            this.rtbSql.TabIndex = 0;
            this.rtbSql.Text = "";
            this.rtbSql.DoubleClick += new System.EventHandler(this.rtbSql_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 22);
            this.panel1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2);
            this.label3.Size = new System.Drawing.Size(268, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "SQL配置格式";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rtbPreview
            // 
            this.rtbPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(217)))));
            this.rtbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbPreview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbPreview.Location = new System.Drawing.Point(0, 317);
            this.rtbPreview.Name = "rtbPreview";
            this.rtbPreview.ReadOnly = true;
            this.rtbPreview.Size = new System.Drawing.Size(268, 206);
            this.rtbPreview.TabIndex = 10;
            this.rtbPreview.Text = "";
            // 
            // qcReview
            // 
            this.qcReview.AutoSize = true;
            this.qcReview.DBHelper = null;
            this.qcReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qcReview.IsDesignModel = false;
            this.qcReview.Location = new System.Drawing.Point(268, 0);
            this.qcReview.Name = "qcReview";
            this.qcReview.SimpleState = false;
            this.qcReview.Size = new System.Drawing.Size(351, 523);
            this.qcReview.TabIndex = 6;
            this.qcReview.OnSelDesign += new zlMedimgSystem.QueryDesign.SelDesignControl(this.qcReview_OnSelDesign);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(268, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 523);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // QueryDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.qcReview);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.pgDesign);
            this.Name = "QueryDesigner";
            this.Size = new System.Drawing.Size(808, 523);
            this.Load += new System.EventHandler(this.QueryDesigner_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgDesign;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel3;
        private QueryFace qcReview;
        private System.Windows.Forms.RichTextBox rtbPreview;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.RichTextBox rtbSql;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Timer timer1;
    }
}
