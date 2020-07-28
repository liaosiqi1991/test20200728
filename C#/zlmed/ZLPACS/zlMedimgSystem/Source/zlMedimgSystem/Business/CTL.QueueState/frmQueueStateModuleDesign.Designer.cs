namespace zlMedimgSystem.CTL.QueueState
{
    partial class frmQueueStateModuleDesign
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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDefaultBusyCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQueueBusyCount = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.chkUseRoomReleation = new System.Windows.Forms.CheckBox();
            this.ceBackColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.ceForeColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.ceBusyColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.ceWorkColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.ceFreeColor = new zlMedimgSystem.BusinessBase.Controls.ColorEditor();
            this.feFontStyle = new zlMedimgSystem.BusinessBase.Controls.FontEditor();
            this.txtFixRow = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFixColumn = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 129;
            this.label7.Text = "前景色";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 128;
            this.label6.Text = "背景色";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 132;
            this.label1.Text = "繁忙中颜色";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 134;
            this.label2.Text = "进行中颜色";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 136;
            this.label3.Text = "空闲中颜色";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 138;
            this.label4.Text = "通用繁忙人数";
            // 
            // txtDefaultBusyCount
            // 
            this.txtDefaultBusyCount.Location = new System.Drawing.Point(95, 212);
            this.txtDefaultBusyCount.Name = "txtDefaultBusyCount";
            this.txtDefaultBusyCount.Size = new System.Drawing.Size(104, 21);
            this.txtDefaultBusyCount.TabIndex = 139;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 140;
            this.label5.Text = "字体样式";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 145;
            this.label8.Text = "关联队列";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(301, 379);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 147;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(220, 379);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 146;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(93, 347);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 148;
            this.label9.Text = "当前队列繁忙人数设置";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtQueueBusyCount
            // 
            this.txtQueueBusyCount.Location = new System.Drawing.Point(224, 343);
            this.txtQueueBusyCount.MaxLength = 3;
            this.txtQueueBusyCount.Name = "txtQueueBusyCount";
            this.txtQueueBusyCount.Size = new System.Drawing.Size(152, 21);
            this.txtQueueBusyCount.TabIndex = 149;
            this.txtQueueBusyCount.TextChanged += new System.EventHandler(this.txtQueueBusyCount_TextChanged);
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(95, 240);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(281, 97);
            this.listView1.TabIndex = 150;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // chkUseRoomReleation
            // 
            this.chkUseRoomReleation.Location = new System.Drawing.Point(26, 270);
            this.chkUseRoomReleation.Name = "chkUseRoomReleation";
            this.chkUseRoomReleation.Size = new System.Drawing.Size(63, 67);
            this.chkUseRoomReleation.TabIndex = 151;
            this.chkUseRoomReleation.Text = "队列根据房间自动关联";
            this.chkUseRoomReleation.UseVisualStyleBackColor = true;
            // 
            // ceBackColor
            // 
            this.ceBackColor.BackColor = System.Drawing.Color.White;
            this.ceBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceBackColor.Color = System.Drawing.Color.Empty;
            this.ceBackColor.Location = new System.Drawing.Point(95, 12);
            this.ceBackColor.Name = "ceBackColor";
            this.ceBackColor.Size = new System.Drawing.Size(281, 18);
            this.ceBackColor.TabIndex = 152;
            // 
            // ceForeColor
            // 
            this.ceForeColor.BackColor = System.Drawing.Color.White;
            this.ceForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceForeColor.Color = System.Drawing.Color.Empty;
            this.ceForeColor.Location = new System.Drawing.Point(95, 36);
            this.ceForeColor.Name = "ceForeColor";
            this.ceForeColor.Size = new System.Drawing.Size(281, 18);
            this.ceForeColor.TabIndex = 153;
            // 
            // ceBusyColor
            // 
            this.ceBusyColor.BackColor = System.Drawing.Color.White;
            this.ceBusyColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceBusyColor.Color = System.Drawing.Color.Empty;
            this.ceBusyColor.Location = new System.Drawing.Point(95, 60);
            this.ceBusyColor.Name = "ceBusyColor";
            this.ceBusyColor.Size = new System.Drawing.Size(281, 18);
            this.ceBusyColor.TabIndex = 154;
            // 
            // ceWorkColor
            // 
            this.ceWorkColor.BackColor = System.Drawing.Color.White;
            this.ceWorkColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceWorkColor.Color = System.Drawing.Color.Empty;
            this.ceWorkColor.Location = new System.Drawing.Point(95, 84);
            this.ceWorkColor.Name = "ceWorkColor";
            this.ceWorkColor.Size = new System.Drawing.Size(281, 18);
            this.ceWorkColor.TabIndex = 155;
            // 
            // ceFreeColor
            // 
            this.ceFreeColor.BackColor = System.Drawing.Color.White;
            this.ceFreeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ceFreeColor.Color = System.Drawing.Color.Empty;
            this.ceFreeColor.Location = new System.Drawing.Point(95, 108);
            this.ceFreeColor.Name = "ceFreeColor";
            this.ceFreeColor.Size = new System.Drawing.Size(281, 18);
            this.ceFreeColor.TabIndex = 156;
            // 
            // feFontStyle
            // 
            this.feFontStyle.BackColor = System.Drawing.Color.White;
            this.feFontStyle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.feFontStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.feFontStyle.Location = new System.Drawing.Point(95, 133);
            this.feFontStyle.Name = "feFontStyle";
            this.feFontStyle.Size = new System.Drawing.Size(281, 73);
            this.feFontStyle.TabIndex = 157;
            this.feFontStyle.Value = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // txtFixRow
            // 
            this.txtFixRow.Location = new System.Drawing.Point(252, 212);
            this.txtFixRow.Name = "txtFixRow";
            this.txtFixRow.Size = new System.Drawing.Size(34, 21);
            this.txtFixRow.TabIndex = 159;
            this.txtFixRow.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(205, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 158;
            this.label10.Text = "固定行";
            // 
            // txtFixColumn
            // 
            this.txtFixColumn.Location = new System.Drawing.Point(342, 212);
            this.txtFixColumn.Name = "txtFixColumn";
            this.txtFixColumn.Size = new System.Drawing.Size(34, 21);
            this.txtFixColumn.TabIndex = 161;
            this.txtFixColumn.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(295, 215);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 160;
            this.label11.Text = "固定列";
            // 
            // frmQueueStateModuleDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 416);
            this.Controls.Add(this.txtFixColumn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtFixRow);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.feFontStyle);
            this.Controls.Add(this.ceFreeColor);
            this.Controls.Add(this.ceWorkColor);
            this.Controls.Add(this.ceBusyColor);
            this.Controls.Add(this.ceForeColor);
            this.Controls.Add(this.ceBackColor);
            this.Controls.Add(this.chkUseRoomReleation);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtQueueBusyCount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDefaultBusyCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQueueStateModuleDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmQueueStateModuleDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDefaultBusyCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtQueueBusyCount;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.CheckBox chkUseRoomReleation;
        private BusinessBase.Controls.ColorEditor ceBackColor;
        private BusinessBase.Controls.ColorEditor ceForeColor;
        private BusinessBase.Controls.ColorEditor ceBusyColor;
        private BusinessBase.Controls.ColorEditor ceWorkColor;
        private BusinessBase.Controls.ColorEditor ceFreeColor;
        private BusinessBase.Controls.FontEditor feFontStyle;
        private System.Windows.Forms.TextBox txtFixRow;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFixColumn;
        private System.Windows.Forms.Label label11;
    }
}