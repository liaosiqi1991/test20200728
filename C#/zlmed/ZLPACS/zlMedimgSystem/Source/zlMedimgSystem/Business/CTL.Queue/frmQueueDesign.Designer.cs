namespace zlMedimgSystem.CTL.QueueManager
{
    partial class frmQueueDesign
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
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolsConfig1 = new zlMedimgSystem.BusinessBase.Controls.ToolsConfig();
            this.chkPauseQueue = new System.Windows.Forms.CheckBox();
            this.chkResetQueue = new System.Windows.Forms.CheckBox();
            this.chkInsertQueue = new System.Windows.Forms.CheckBox();
            this.chkDirectCall = new System.Windows.Forms.CheckBox();
            this.chkOrderCall = new System.Windows.Forms.CheckBox();
            this.chkRefresh = new System.Windows.Forms.CheckBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.chkRestore = new System.Windows.Forms.CheckBox();
            this.chkRecept = new System.Windows.Forms.CheckBox();
            this.chkAbandon = new System.Windows.Forms.CheckBox();
            this.chkFind = new System.Windows.Forms.CheckBox();
            this.chkModify = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(735, 286);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 37;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(654, 286);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 36;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // toolsConfig1
            // 
            this.toolsConfig1.Location = new System.Drawing.Point(12, 12);
            this.toolsConfig1.Name = "toolsConfig1";
            this.toolsConfig1.Size = new System.Drawing.Size(798, 268);
            this.toolsConfig1.TabIndex = 43;
            this.toolsConfig1.ToolsDesign = null;
            // 
            // chkPauseQueue
            // 
            this.chkPauseQueue.AutoSize = true;
            this.chkPauseQueue.Checked = true;
            this.chkPauseQueue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPauseQueue.Location = new System.Drawing.Point(228, 286);
            this.chkPauseQueue.Name = "chkPauseQueue";
            this.chkPauseQueue.Size = new System.Drawing.Size(48, 16);
            this.chkPauseQueue.TabIndex = 42;
            this.chkPauseQueue.Text = "暂停";
            this.chkPauseQueue.UseVisualStyleBackColor = true;
            // 
            // chkResetQueue
            // 
            this.chkResetQueue.AutoSize = true;
            this.chkResetQueue.Checked = true;
            this.chkResetQueue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkResetQueue.Location = new System.Drawing.Point(174, 286);
            this.chkResetQueue.Name = "chkResetQueue";
            this.chkResetQueue.Size = new System.Drawing.Size(48, 16);
            this.chkResetQueue.TabIndex = 41;
            this.chkResetQueue.Text = "重排";
            this.chkResetQueue.UseVisualStyleBackColor = true;
            // 
            // chkInsertQueue
            // 
            this.chkInsertQueue.AutoSize = true;
            this.chkInsertQueue.Checked = true;
            this.chkInsertQueue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInsertQueue.Location = new System.Drawing.Point(120, 286);
            this.chkInsertQueue.Name = "chkInsertQueue";
            this.chkInsertQueue.Size = new System.Drawing.Size(48, 16);
            this.chkInsertQueue.TabIndex = 40;
            this.chkInsertQueue.Text = "插队";
            this.chkInsertQueue.UseVisualStyleBackColor = true;
            // 
            // chkDirectCall
            // 
            this.chkDirectCall.AutoSize = true;
            this.chkDirectCall.Checked = true;
            this.chkDirectCall.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDirectCall.Location = new System.Drawing.Point(66, 286);
            this.chkDirectCall.Name = "chkDirectCall";
            this.chkDirectCall.Size = new System.Drawing.Size(48, 16);
            this.chkDirectCall.TabIndex = 39;
            this.chkDirectCall.Text = "直呼";
            this.chkDirectCall.UseVisualStyleBackColor = true;
            // 
            // chkOrderCall
            // 
            this.chkOrderCall.AutoSize = true;
            this.chkOrderCall.Checked = true;
            this.chkOrderCall.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOrderCall.Location = new System.Drawing.Point(12, 286);
            this.chkOrderCall.Name = "chkOrderCall";
            this.chkOrderCall.Size = new System.Drawing.Size(48, 16);
            this.chkOrderCall.TabIndex = 38;
            this.chkOrderCall.Text = "顺呼";
            this.chkOrderCall.UseVisualStyleBackColor = true;
            // 
            // chkRefresh
            // 
            this.chkRefresh.AutoSize = true;
            this.chkRefresh.Checked = true;
            this.chkRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRefresh.Location = new System.Drawing.Point(174, 308);
            this.chkRefresh.Name = "chkRefresh";
            this.chkRefresh.Size = new System.Drawing.Size(48, 16);
            this.chkRefresh.TabIndex = 48;
            this.chkRefresh.Text = "刷新";
            this.chkRefresh.UseVisualStyleBackColor = true;
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Checked = true;
            this.chkPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrint.Location = new System.Drawing.Point(120, 308);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(48, 16);
            this.chkPrint.TabIndex = 47;
            this.chkPrint.Text = "打号";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // chkRestore
            // 
            this.chkRestore.AutoSize = true;
            this.chkRestore.Checked = true;
            this.chkRestore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRestore.Location = new System.Drawing.Point(66, 308);
            this.chkRestore.Name = "chkRestore";
            this.chkRestore.Size = new System.Drawing.Size(48, 16);
            this.chkRestore.TabIndex = 46;
            this.chkRestore.Text = "恢复";
            this.chkRestore.UseVisualStyleBackColor = true;
            // 
            // chkRecept
            // 
            this.chkRecept.AutoSize = true;
            this.chkRecept.Checked = true;
            this.chkRecept.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecept.Location = new System.Drawing.Point(12, 308);
            this.chkRecept.Name = "chkRecept";
            this.chkRecept.Size = new System.Drawing.Size(48, 16);
            this.chkRecept.TabIndex = 45;
            this.chkRecept.Text = "接诊";
            this.chkRecept.UseVisualStyleBackColor = true;
            // 
            // chkAbandon
            // 
            this.chkAbandon.AutoSize = true;
            this.chkAbandon.Checked = true;
            this.chkAbandon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAbandon.Location = new System.Drawing.Point(282, 286);
            this.chkAbandon.Name = "chkAbandon";
            this.chkAbandon.Size = new System.Drawing.Size(48, 16);
            this.chkAbandon.TabIndex = 44;
            this.chkAbandon.Text = "弃呼";
            this.chkAbandon.UseVisualStyleBackColor = true;
            // 
            // chkFind
            // 
            this.chkFind.AutoSize = true;
            this.chkFind.Checked = true;
            this.chkFind.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFind.Location = new System.Drawing.Point(282, 308);
            this.chkFind.Name = "chkFind";
            this.chkFind.Size = new System.Drawing.Size(48, 16);
            this.chkFind.TabIndex = 50;
            this.chkFind.Text = "查找";
            this.chkFind.UseVisualStyleBackColor = true;
            // 
            // chkModify
            // 
            this.chkModify.AutoSize = true;
            this.chkModify.Checked = true;
            this.chkModify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkModify.Location = new System.Drawing.Point(228, 308);
            this.chkModify.Name = "chkModify";
            this.chkModify.Size = new System.Drawing.Size(48, 16);
            this.chkModify.TabIndex = 49;
            this.chkModify.Text = "修改";
            this.chkModify.UseVisualStyleBackColor = true;
            // 
            // frmQueueDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 339);
            this.Controls.Add(this.chkFind);
            this.Controls.Add(this.chkModify);
            this.Controls.Add(this.chkRefresh);
            this.Controls.Add(this.chkPrint);
            this.Controls.Add(this.chkRestore);
            this.Controls.Add(this.chkRecept);
            this.Controls.Add(this.chkAbandon);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.toolsConfig1);
            this.Controls.Add(this.chkPauseQueue);
            this.Controls.Add(this.chkResetQueue);
            this.Controls.Add(this.chkInsertQueue);
            this.Controls.Add(this.chkDirectCall);
            this.Controls.Add(this.chkOrderCall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQueueDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmQueueDesign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private BusinessBase.Controls.ToolsConfig toolsConfig1;
        private System.Windows.Forms.CheckBox chkPauseQueue;
        private System.Windows.Forms.CheckBox chkResetQueue;
        private System.Windows.Forms.CheckBox chkInsertQueue;
        private System.Windows.Forms.CheckBox chkDirectCall;
        private System.Windows.Forms.CheckBox chkOrderCall;
        private System.Windows.Forms.CheckBox chkRefresh;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.CheckBox chkRestore;
        private System.Windows.Forms.CheckBox chkRecept;
        private System.Windows.Forms.CheckBox chkAbandon;
        private System.Windows.Forms.CheckBox chkFind;
        private System.Windows.Forms.CheckBox chkModify;
    }
}