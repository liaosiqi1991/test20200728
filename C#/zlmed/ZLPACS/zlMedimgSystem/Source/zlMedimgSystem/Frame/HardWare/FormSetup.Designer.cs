namespace zlMedimgSystem.HardWare
{
    partial class FormSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetup));
            this.m_labelUseUiSettings = new System.Windows.Forms.Label();
            this.m_buttonShowDriverUi = new System.Windows.Forms.Button();
            this.m_buttonSaveUiSettings = new System.Windows.Forms.Button();
            this.m_labelSelectDestinationFolder = new System.Windows.Forms.Label();
            this.m_textboxFolder = new System.Windows.Forms.TextBox();
            this.m_buttonSelectDestinationFolder = new System.Windows.Forms.Button();
            this.m_buttonUseUiSettings = new System.Windows.Forms.Button();
            this.m_textboxUseUiSettings = new System.Windows.Forms.TextBox();
            this.m_buttonDeleteSetting = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rbLocate = new System.Windows.Forms.RadioButton();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.rbBuffer = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // m_labelUseUiSettings
            // 
            this.m_labelUseUiSettings.AutoSize = true;
            this.m_labelUseUiSettings.Location = new System.Drawing.Point(30, 241);
            this.m_labelUseUiSettings.Name = "m_labelUseUiSettings";
            this.m_labelUseUiSettings.Size = new System.Drawing.Size(293, 12);
            this.m_labelUseUiSettings.TabIndex = 1;
            this.m_labelUseUiSettings.Text = "扫描参数配置文件选择 (如果为空则扫描时弹窗设置):";
            // 
            // m_buttonShowDriverUi
            // 
            this.m_buttonShowDriverUi.Location = new System.Drawing.Point(33, 123);
            this.m_buttonShowDriverUi.Name = "m_buttonShowDriverUi";
            this.m_buttonShowDriverUi.Size = new System.Drawing.Size(294, 21);
            this.m_buttonShowDriverUi.TabIndex = 1;
            this.m_buttonShowDriverUi.Text = "设置扫描参数...";
            this.m_buttonShowDriverUi.UseVisualStyleBackColor = true;
            this.m_buttonShowDriverUi.Click += new System.EventHandler(this.m_buttonSetup_Click);
            // 
            // m_buttonSaveUiSettings
            // 
            this.m_buttonSaveUiSettings.Location = new System.Drawing.Point(33, 158);
            this.m_buttonSaveUiSettings.Name = "m_buttonSaveUiSettings";
            this.m_buttonSaveUiSettings.Size = new System.Drawing.Size(294, 21);
            this.m_buttonSaveUiSettings.TabIndex = 2;
            this.m_buttonSaveUiSettings.Text = "保存扫描参数...";
            this.m_buttonSaveUiSettings.UseVisualStyleBackColor = true;
            this.m_buttonSaveUiSettings.Click += new System.EventHandler(this.m_buttonSaveas_Click);
            // 
            // m_labelSelectDestinationFolder
            // 
            this.m_labelSelectDestinationFolder.AutoSize = true;
            this.m_labelSelectDestinationFolder.Location = new System.Drawing.Point(30, 35);
            this.m_labelSelectDestinationFolder.Name = "m_labelSelectDestinationFolder";
            this.m_labelSelectDestinationFolder.Size = new System.Drawing.Size(197, 12);
            this.m_labelSelectDestinationFolder.TabIndex = 4;
            this.m_labelSelectDestinationFolder.Text = "设置图像保存目录(不保存则为空)：";
            // 
            // m_textboxFolder
            // 
            this.m_textboxFolder.Location = new System.Drawing.Point(33, 52);
            this.m_textboxFolder.Name = "m_textboxFolder";
            this.m_textboxFolder.Size = new System.Drawing.Size(262, 21);
            this.m_textboxFolder.TabIndex = 5;
            this.m_textboxFolder.TextChanged += new System.EventHandler(this.m_textboxFolder_TextChanged);
            // 
            // m_buttonSelectDestinationFolder
            // 
            this.m_buttonSelectDestinationFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_buttonSelectDestinationFolder.BackgroundImage")));
            this.m_buttonSelectDestinationFolder.Location = new System.Drawing.Point(301, 50);
            this.m_buttonSelectDestinationFolder.Name = "m_buttonSelectDestinationFolder";
            this.m_buttonSelectDestinationFolder.Size = new System.Drawing.Size(26, 21);
            this.m_buttonSelectDestinationFolder.TabIndex = 6;
            this.m_buttonSelectDestinationFolder.UseVisualStyleBackColor = true;
            this.m_buttonSelectDestinationFolder.Click += new System.EventHandler(this.m_buttonBrowse_Click);
            // 
            // m_buttonUseUiSettings
            // 
            this.m_buttonUseUiSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_buttonUseUiSettings.BackgroundImage")));
            this.m_buttonUseUiSettings.Location = new System.Drawing.Point(301, 256);
            this.m_buttonUseUiSettings.Name = "m_buttonUseUiSettings";
            this.m_buttonUseUiSettings.Size = new System.Drawing.Size(26, 21);
            this.m_buttonUseUiSettings.TabIndex = 8;
            this.m_buttonUseUiSettings.UseVisualStyleBackColor = true;
            this.m_buttonUseUiSettings.Click += new System.EventHandler(this.m_buttonUseUiSettings_Click);
            // 
            // m_textboxUseUiSettings
            // 
            this.m_textboxUseUiSettings.Location = new System.Drawing.Point(33, 258);
            this.m_textboxUseUiSettings.Name = "m_textboxUseUiSettings";
            this.m_textboxUseUiSettings.Size = new System.Drawing.Size(262, 21);
            this.m_textboxUseUiSettings.TabIndex = 7;
            // 
            // m_buttonDeleteSetting
            // 
            this.m_buttonDeleteSetting.Location = new System.Drawing.Point(210, 294);
            this.m_buttonDeleteSetting.Name = "m_buttonDeleteSetting";
            this.m_buttonDeleteSetting.Size = new System.Drawing.Size(117, 21);
            this.m_buttonDeleteSetting.TabIndex = 0;
            this.m_buttonDeleteSetting.Text = "删除设置...";
            this.m_buttonDeleteSetting.UseVisualStyleBackColor = true;
            this.m_buttonDeleteSetting.Click += new System.EventHandler(this.m_buttonDeleteSetting_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbLocate
            // 
            this.rbLocate.AutoSize = true;
            this.rbLocate.Checked = true;
            this.rbLocate.Location = new System.Drawing.Point(33, 88);
            this.rbLocate.Name = "rbLocate";
            this.rbLocate.Size = new System.Drawing.Size(71, 16);
            this.rbLocate.TabIndex = 10;
            this.rbLocate.TabStop = true;
            this.rbLocate.Tag = "0";
            this.rbLocate.Text = "本地模式";
            this.rbLocate.UseVisualStyleBackColor = true;
            this.rbLocate.CheckedChanged += new System.EventHandler(this.rbLocate_CheckedChanged);
            // 
            // rbFile
            // 
            this.rbFile.AutoSize = true;
            this.rbFile.Location = new System.Drawing.Point(129, 88);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(71, 16);
            this.rbFile.TabIndex = 11;
            this.rbFile.Tag = "2";
            this.rbFile.Text = "文件模式";
            this.rbFile.UseVisualStyleBackColor = true;
            this.rbFile.CheckedChanged += new System.EventHandler(this.rbLocate_CheckedChanged);
            // 
            // rbBuffer
            // 
            this.rbBuffer.AutoSize = true;
            this.rbBuffer.Location = new System.Drawing.Point(224, 88);
            this.rbBuffer.Name = "rbBuffer";
            this.rbBuffer.Size = new System.Drawing.Size(71, 16);
            this.rbBuffer.TabIndex = 12;
            this.rbBuffer.Tag = "1";
            this.rbBuffer.Text = "缓存模式";
            this.rbBuffer.UseVisualStyleBackColor = true;
            this.rbBuffer.CheckedChanged += new System.EventHandler(this.rbLocate_CheckedChanged);
            // 
            // FormSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 327);
            this.Controls.Add(this.rbBuffer);
            this.Controls.Add(this.rbFile);
            this.Controls.Add(this.rbLocate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_buttonDeleteSetting);
            this.Controls.Add(this.m_buttonUseUiSettings);
            this.Controls.Add(this.m_textboxUseUiSettings);
            this.Controls.Add(this.m_buttonSelectDestinationFolder);
            this.Controls.Add(this.m_textboxFolder);
            this.Controls.Add(this.m_labelSelectDestinationFolder);
            this.Controls.Add(this.m_buttonSaveUiSettings);
            this.Controls.Add(this.m_buttonShowDriverUi);
            this.Controls.Add(this.m_labelUseUiSettings);
            this.Name = "FormSetup";
            this.Text = "Setup TWAIN Scan";
            this.Load += new System.EventHandler(this.FormSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_labelUseUiSettings;
        private System.Windows.Forms.Button m_buttonShowDriverUi;
        private System.Windows.Forms.Button m_buttonSaveUiSettings;
        private System.Windows.Forms.Label m_labelSelectDestinationFolder;
        private System.Windows.Forms.TextBox m_textboxFolder;
        private System.Windows.Forms.Button m_buttonSelectDestinationFolder;
        private System.Windows.Forms.Button m_buttonUseUiSettings;
        private System.Windows.Forms.TextBox m_textboxUseUiSettings;
        private System.Windows.Forms.Button m_buttonDeleteSetting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbLocate;
        private System.Windows.Forms.RadioButton rbFile;
        private System.Windows.Forms.RadioButton rbBuffer;
    }
}