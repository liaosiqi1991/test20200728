using System.Windows.Forms;

namespace zlMedimgSystem.Services
{
     partial class frmMsgBox
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.plErrInfo = new System.Windows.Forms.Panel();
            this.lblErrInfo = new System.Windows.Forms.RichTextBox();
            this.picFormIcon = new System.Windows.Forms.PictureBox();
            this.plControl = new System.Windows.Forms.Panel();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnExtraNote = new System.Windows.Forms.Button();
            this.mmeErrInfo = new System.Windows.Forms.RichTextBox();
            this.tmerTopMost = new System.Windows.Forms.Timer(this.components);
            this.plErrInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFormIcon)).BeginInit();
            this.plControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // plErrInfo
            // 
            this.plErrInfo.BackColor = System.Drawing.Color.Transparent;
            this.plErrInfo.Controls.Add(this.lblErrInfo);
            this.plErrInfo.Controls.Add(this.picFormIcon);
            this.plErrInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plErrInfo.Location = new System.Drawing.Point(0, 0);
            this.plErrInfo.Name = "plErrInfo";
            this.plErrInfo.Size = new System.Drawing.Size(476, 139);
            this.plErrInfo.TabIndex = 2;
            // 
            // lblErrInfo
            // 
            this.lblErrInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblErrInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblErrInfo.Location = new System.Drawing.Point(64, 10);
            this.lblErrInfo.Name = "lblErrInfo";
            this.lblErrInfo.ReadOnly = true;
            this.lblErrInfo.Size = new System.Drawing.Size(405, 124);
            this.lblErrInfo.TabIndex = 4;
            this.lblErrInfo.Text = "应用程序异常";
            // 
            // picFormIcon
            // 
            this.picFormIcon.BackColor = System.Drawing.Color.Transparent;
            this.picFormIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFormIcon.Location = new System.Drawing.Point(17, 17);
            this.picFormIcon.Name = "picFormIcon";
            this.picFormIcon.Size = new System.Drawing.Size(34, 34);
            this.picFormIcon.TabIndex = 3;
            this.picFormIcon.TabStop = false;
            // 
            // plControl
            // 
            this.plControl.Controls.Add(this.btnContinue);
            this.plControl.Controls.Add(this.btnExtraNote);
            this.plControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plControl.Location = new System.Drawing.Point(0, 139);
            this.plControl.Name = "plControl";
            this.plControl.Size = new System.Drawing.Size(476, 32);
            this.plControl.TabIndex = 7;
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(388, 6);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(81, 21);
            this.btnContinue.TabIndex = 7;
            this.btnContinue.Text = "确定(&C)";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnExtraNote
            // 
            this.btnExtraNote.Location = new System.Drawing.Point(10, 5);
            this.btnExtraNote.Name = "btnExtraNote";
            this.btnExtraNote.Size = new System.Drawing.Size(81, 21);
            this.btnExtraNote.TabIndex = 6;
            this.btnExtraNote.Text = "△详细信息";
            this.btnExtraNote.Click += new System.EventHandler(this.btnExtraNote_Click);
            // 
            // mmeErrInfo
            // 
            this.mmeErrInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mmeErrInfo.Location = new System.Drawing.Point(0, 171);
            this.mmeErrInfo.Name = "mmeErrInfo";
            this.mmeErrInfo.Size = new System.Drawing.Size(476, 158);
            this.mmeErrInfo.TabIndex = 8;
            this.mmeErrInfo.Text = "";
            this.mmeErrInfo.Visible = false;
            // 
            // tmerTopMost
            // 
            this.tmerTopMost.Interval = 1000;
            this.tmerTopMost.Tick += new System.EventHandler(this.tmerTopMost_Tick);
            // 
            // zlMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 329);
            this.Controls.Add(this.plErrInfo);
            this.Controls.Add(this.plControl);
            this.Controls.Add(this.mmeErrInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "zlMsgBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "警告";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMsgBox_FormClosed);
            this.Load += new System.EventHandler(this.frmMsgBox_Load);
            this.Shown += new System.EventHandler(this.frmMsgBox_Shown);
            this.Resize += new System.EventHandler(this.ZlMsgBox_Resize);
            this.plErrInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFormIcon)).EndInit();
            this.plControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plErrInfo;
        private System.Windows.Forms.PictureBox picFormIcon;
        private System.Windows.Forms.Panel plControl;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnExtraNote;
        private System.Windows.Forms.RichTextBox mmeErrInfo;
        private System.Windows.Forms.RichTextBox lblErrInfo;
        private System.Windows.Forms.Timer tmerTopMost;

    }
}