﻿namespace zlMedimgSystem.CTL.QueueManager
{
    partial class frmIntoQueue
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.cbxQueueName = new System.Windows.Forms.ComboBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtQueueNo = new System.Windows.Forms.TextBox();
            this.dtpIntoQueue = new System.Windows.Forms.DateTimePicker();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.cbxMemo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "性别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "年龄：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "检查项目：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "队列名称：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "排队日期：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "排队号码：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(91, 21);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(216, 21);
            this.txtName.TabIndex = 7;
            // 
            // txtSex
            // 
            this.txtSex.Location = new System.Drawing.Point(91, 51);
            this.txtSex.Name = "txtSex";
            this.txtSex.ReadOnly = true;
            this.txtSex.Size = new System.Drawing.Size(216, 21);
            this.txtSex.TabIndex = 8;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(91, 81);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(216, 21);
            this.txtAge.TabIndex = 9;
            // 
            // cbxQueueName
            // 
            this.cbxQueueName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQueueName.FormattingEnabled = true;
            this.cbxQueueName.Location = new System.Drawing.Point(91, 141);
            this.cbxQueueName.Name = "cbxQueueName";
            this.cbxQueueName.Size = new System.Drawing.Size(216, 20);
            this.cbxQueueName.TabIndex = 10;
            this.cbxQueueName.SelectedIndexChanged += new System.EventHandler(this.cbxQueueName_SelectedIndexChanged);
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(91, 111);
            this.txtItem.Name = "txtItem";
            this.txtItem.ReadOnly = true;
            this.txtItem.Size = new System.Drawing.Size(216, 21);
            this.txtItem.TabIndex = 11;
            // 
            // txtQueueNo
            // 
            this.txtQueueNo.BackColor = System.Drawing.Color.White;
            this.txtQueueNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtQueueNo.ForeColor = System.Drawing.Color.Red;
            this.txtQueueNo.Location = new System.Drawing.Point(91, 201);
            this.txtQueueNo.Name = "txtQueueNo";
            this.txtQueueNo.ReadOnly = true;
            this.txtQueueNo.Size = new System.Drawing.Size(216, 21);
            this.txtQueueNo.TabIndex = 12;
            // 
            // dtpIntoQueue
            // 
            this.dtpIntoQueue.CustomFormat = "yyyy-MM-dd";
            this.dtpIntoQueue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIntoQueue.Location = new System.Drawing.Point(91, 168);
            this.dtpIntoQueue.Name = "dtpIntoQueue";
            this.dtpIntoQueue.Size = new System.Drawing.Size(216, 21);
            this.dtpIntoQueue.TabIndex = 13;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(232, 254);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 14;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(151, 254);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 15;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // cbxMemo
            // 
            this.cbxMemo.FormattingEnabled = true;
            this.cbxMemo.Location = new System.Drawing.Point(91, 228);
            this.cbxMemo.Name = "cbxMemo";
            this.cbxMemo.Size = new System.Drawing.Size(216, 20);
            this.cbxMemo.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "备注：";
            // 
            // frmIntoQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 296);
            this.Controls.Add(this.cbxMemo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.dtpIntoQueue);
            this.Controls.Add(this.txtQueueNo);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.cbxQueueName);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtSex);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIntoQueue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "患者入队";
            this.Load += new System.EventHandler(this.frmIntoQueue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.ComboBox cbxQueueName;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.TextBox txtQueueNo;
        private System.Windows.Forms.DateTimePicker dtpIntoQueue;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.ComboBox cbxMemo;
        private System.Windows.Forms.Label label8;
    }
}