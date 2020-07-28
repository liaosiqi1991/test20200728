namespace zlMedimgSystem.BusinessBase.Controls
{
    partial class ToolsConfig
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxParentName = new System.Windows.Forms.ComboBox();
            this.butModify = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.butAdd = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.chkRight = new System.Windows.Forms.CheckBox();
            this.cbxIconPostion = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtButTag = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbxDisplyStyle = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxButType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtImgName = new System.Windows.Forms.TextBox();
            this.butLoadImg = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtToolSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxToolsStyle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkShowTools = new System.Windows.Forms.CheckBox();
            this.labBkColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.labForeColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxParentName);
            this.groupBox1.Controls.Add(this.butModify);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.butAdd);
            this.groupBox1.Controls.Add(this.butDel);
            this.groupBox1.Controls.Add(this.chkRight);
            this.groupBox1.Controls.Add(this.cbxIconPostion);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtButTag);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.cbxDisplyStyle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxButType);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtImgName);
            this.groupBox1.Controls.Add(this.butLoadImg);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 233);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自定按钮项";
            // 
            // cbxParentName
            // 
            this.cbxParentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxParentName.FormattingEnabled = true;
            this.cbxParentName.Location = new System.Drawing.Point(69, 185);
            this.cbxParentName.Name = "cbxParentName";
            this.cbxParentName.Size = new System.Drawing.Size(141, 20);
            this.cbxParentName.TabIndex = 17;
            // 
            // butModify
            // 
            this.butModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butModify.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butModify.Image = global::zlMedimgSystem.BusinessBase.Properties.Resources.blackwrite;
            this.butModify.Location = new System.Drawing.Point(654, -1);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(27, 23);
            this.butModify.TabIndex = 23;
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(217, 24);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(464, 202);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // butAdd
            // 
            this.butAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butAdd.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butAdd.Location = new System.Drawing.Point(588, -1);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(27, 23);
            this.butAdd.TabIndex = 0;
            this.butAdd.Text = "┼";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butDel
            // 
            this.butDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDel.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butDel.Location = new System.Drawing.Point(621, -1);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(27, 23);
            this.butDel.TabIndex = 1;
            this.butDel.Text = "─";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // chkRight
            // 
            this.chkRight.AutoSize = true;
            this.chkRight.Location = new System.Drawing.Point(103, 211);
            this.chkRight.Name = "chkRight";
            this.chkRight.Size = new System.Drawing.Size(72, 16);
            this.chkRight.TabIndex = 14;
            this.chkRight.Text = "靠右显示";
            this.chkRight.UseVisualStyleBackColor = true;
            // 
            // cbxIconPostion
            // 
            this.cbxIconPostion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIconPostion.FormattingEnabled = true;
            this.cbxIconPostion.Items.AddRange(new object[] {
            "文本上部",
            "文本下部",
            "文本左侧",
            "文本右侧"});
            this.cbxIconPostion.Location = new System.Drawing.Point(69, 105);
            this.cbxIconPostion.Name = "cbxIconPostion";
            this.cbxIconPostion.Size = new System.Drawing.Size(141, 20);
            this.cbxIconPostion.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "父级名称";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "按钮名称";
            // 
            // txtButTag
            // 
            this.txtButTag.Location = new System.Drawing.Point(69, 78);
            this.txtButTag.Name = "txtButTag";
            this.txtButTag.Size = new System.Drawing.Size(141, 21);
            this.txtButTag.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "图标位置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "按钮类型";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(69, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(141, 21);
            this.txtName.TabIndex = 2;
            // 
            // cbxDisplyStyle
            // 
            this.cbxDisplyStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDisplyStyle.FormattingEnabled = true;
            this.cbxDisplyStyle.Items.AddRange(new object[] {
            "文本",
            "图像",
            "文本和图像"});
            this.cbxDisplyStyle.Location = new System.Drawing.Point(69, 159);
            this.cbxDisplyStyle.Name = "cbxDisplyStyle";
            this.cbxDisplyStyle.Size = new System.Drawing.Size(141, 20);
            this.cbxDisplyStyle.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "按钮标记";
            // 
            // cbxButType
            // 
            this.cbxButType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxButType.FormattingEnabled = true;
            this.cbxButType.Items.AddRange(new object[] {
            "文本类型",
            "按钮类型",
            "下拉类型",
            "分割类型"});
            this.cbxButType.Location = new System.Drawing.Point(69, 52);
            this.cbxButType.Name = "cbxButType";
            this.cbxButType.Size = new System.Drawing.Size(141, 20);
            this.cbxButType.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "显示样式";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "图标名称";
            // 
            // txtImgName
            // 
            this.txtImgName.Location = new System.Drawing.Point(69, 131);
            this.txtImgName.Name = "txtImgName";
            this.txtImgName.Size = new System.Drawing.Size(116, 21);
            this.txtImgName.TabIndex = 3;
            // 
            // butLoadImg
            // 
            this.butLoadImg.Location = new System.Drawing.Point(187, 130);
            this.butLoadImg.Name = "butLoadImg";
            this.butLoadImg.Size = new System.Drawing.Size(24, 23);
            this.butLoadImg.TabIndex = 6;
            this.butLoadImg.Text = "…";
            this.butLoadImg.UseVisualStyleBackColor = true;
            this.butLoadImg.Click += new System.EventHandler(this.butLoadImg_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labForeColor);
            this.panel1.Controls.Add(this.labBkColor);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtToolSize);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbxToolsStyle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkShowTools);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 35);
            this.panel1.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(547, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 59;
            this.label12.Text = "工具栏大小";
            // 
            // txtToolSize
            // 
            this.txtToolSize.Location = new System.Drawing.Point(618, 8);
            this.txtToolSize.Name = "txtToolSize";
            this.txtToolSize.Size = new System.Drawing.Size(64, 21);
            this.txtToolSize.TabIndex = 58;
            this.txtToolSize.Text = "34";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(397, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 53;
            this.label7.Text = "前景色";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 52;
            this.label6.Text = "背景色";
            // 
            // cbxToolsStyle
            // 
            this.cbxToolsStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToolsStyle.FormattingEnabled = true;
            this.cbxToolsStyle.Items.AddRange(new object[] {
            "横向",
            "纵向"});
            this.cbxToolsStyle.Location = new System.Drawing.Point(134, 8);
            this.cbxToolsStyle.Name = "cbxToolsStyle";
            this.cbxToolsStyle.Size = new System.Drawing.Size(107, 20);
            this.cbxToolsStyle.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 50;
            this.label2.Text = "样式";
            // 
            // chkShowTools
            // 
            this.chkShowTools.AutoSize = true;
            this.chkShowTools.Checked = true;
            this.chkShowTools.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowTools.Location = new System.Drawing.Point(9, 12);
            this.chkShowTools.Name = "chkShowTools";
            this.chkShowTools.Size = new System.Drawing.Size(84, 16);
            this.chkShowTools.TabIndex = 49;
            this.chkShowTools.Text = "显示工具栏";
            this.chkShowTools.UseVisualStyleBackColor = true;
            // 
            // labBkColor
            // 
            this.labBkColor.BackColor = System.Drawing.Color.White;
            this.labBkColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labBkColor.Color = System.Drawing.Color.Empty;
            this.labBkColor.Location = new System.Drawing.Point(294, 9);
            this.labBkColor.Name = "labBkColor";
            this.labBkColor.Size = new System.Drawing.Size(97, 20);
            this.labBkColor.TabIndex = 60;
            // 
            // labForeColor
            // 
            this.labForeColor.BackColor = System.Drawing.Color.White;
            this.labForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labForeColor.Color = System.Drawing.Color.Empty;
            this.labForeColor.Location = new System.Drawing.Point(444, 8);
            this.labForeColor.Name = "labForeColor";
            this.labForeColor.Size = new System.Drawing.Size(97, 20);
            this.labForeColor.TabIndex = 61;
            // 
            // ToolsConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "ToolsConfig";
            this.Size = new System.Drawing.Size(688, 268);
            this.Load += new System.EventHandler(this.ToolsConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxIconPostion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxParentName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.CheckBox chkRight;
        private System.Windows.Forms.ComboBox cbxDisplyStyle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxButType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.TextBox txtButTag;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button butLoadImg;
        private System.Windows.Forms.TextBox txtImgName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button butModify;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtToolSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxToolsStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkShowTools;
        private ColorEditor labBkColor;
        private ColorEditor labForeColor;
    }
}
