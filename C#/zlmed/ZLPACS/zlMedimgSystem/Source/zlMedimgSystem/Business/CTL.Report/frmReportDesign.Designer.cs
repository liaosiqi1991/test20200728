namespace zlMedimgSystem.CTL.Report
{
    partial class frmReportDesign
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
            this.cbxDirectAuditingLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkConvertPDF = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxEqualAuditingLevel = new System.Windows.Forms.ComboBox();
            this.chkEsign = new System.Windows.Forms.CheckBox();
            this.txtSignLibName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkCriticalDirectPrint = new System.Windows.Forms.CheckBox();
            this.chkGreenCriticalDirectPrint = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxAuditLevel = new System.Windows.Forms.ComboBox();
            this.chkUltimateAutoPrint = new System.Windows.Forms.CheckBox();
            this.chkUltimateAutoFinish = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkHDiagnoseAuditPrint = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkWriteSelf = new System.Windows.Forms.CheckBox();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxDockWay = new System.Windows.Forms.ComboBox();
            this.chkSignManager = new System.Windows.Forms.CheckBox();
            this.chkEscFinished = new System.Windows.Forms.CheckBox();
            this.chkGiveIn = new System.Windows.Forms.CheckBox();
            this.chkAbortView = new System.Windows.Forms.CheckBox();
            this.chkPDF = new System.Windows.Forms.CheckBox();
            this.chkDel = new System.Windows.Forms.CheckBox();
            this.chkUnlock = new System.Windows.Forms.CheckBox();
            this.chkRejectManager = new System.Windows.Forms.CheckBox();
            this.chkReject = new System.Windows.Forms.CheckBox();
            this.chkNew = new System.Windows.Forms.CheckBox();
            this.chkMore = new System.Windows.Forms.CheckBox();
            this.chkRefresh = new System.Windows.Forms.CheckBox();
            this.chkFinished = new System.Windows.Forms.CheckBox();
            this.chkGiveOut = new System.Windows.Forms.CheckBox();
            this.chkAllowView = new System.Windows.Forms.CheckBox();
            this.chkAddReportImage = new System.Windows.Forms.CheckBox();
            this.chkSign = new System.Windows.Forms.CheckBox();
            this.chkQuitRevise = new System.Windows.Forms.CheckBox();
            this.chkSureRevise = new System.Windows.Forms.CheckBox();
            this.chkRevise = new System.Windows.Forms.CheckBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.chkPreview = new System.Windows.Forms.CheckBox();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSure = new System.Windows.Forms.Button();
            this.toolsConfig1 = new zlMedimgSystem.BusinessBase.Controls.ToolsConfig();
            this.cbxAutoPublicLevel = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxDirectAuditingLevel
            // 
            this.cbxDirectAuditingLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDirectAuditingLevel.FormattingEnabled = true;
            this.cbxDirectAuditingLevel.Items.AddRange(new object[] {
            "不允许",
            "住院医师及以上",
            "主治医师及以上",
            "副主任医师及以上",
            "主任医师"});
            this.cbxDirectAuditingLevel.Location = new System.Drawing.Point(288, 193);
            this.cbxDirectAuditingLevel.Name = "cbxDirectAuditingLevel";
            this.cbxDirectAuditingLevel.Size = new System.Drawing.Size(261, 20);
            this.cbxDirectAuditingLevel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "直接审核签名";
            // 
            // chkConvertPDF
            // 
            this.chkConvertPDF.AutoSize = true;
            this.chkConvertPDF.Location = new System.Drawing.Point(578, 87);
            this.chkConvertPDF.Name = "chkConvertPDF";
            this.chkConvertPDF.Size = new System.Drawing.Size(114, 16);
            this.chkConvertPDF.TabIndex = 3;
            this.chkConvertPDF.Text = "打印时自动转PDF";
            this.chkConvertPDF.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "平级审核";
            // 
            // cbxEqualAuditingLevel
            // 
            this.cbxEqualAuditingLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEqualAuditingLevel.FormattingEnabled = true;
            this.cbxEqualAuditingLevel.Items.AddRange(new object[] {
            "不允许",
            "住院医师及以上",
            "主治医师及以上",
            "副主任医师及以上",
            "主任医师"});
            this.cbxEqualAuditingLevel.Location = new System.Drawing.Point(288, 167);
            this.cbxEqualAuditingLevel.Name = "cbxEqualAuditingLevel";
            this.cbxEqualAuditingLevel.Size = new System.Drawing.Size(261, 20);
            this.cbxEqualAuditingLevel.TabIndex = 4;
            // 
            // chkEsign
            // 
            this.chkEsign.AutoSize = true;
            this.chkEsign.Location = new System.Drawing.Point(186, 116);
            this.chkEsign.Name = "chkEsign";
            this.chkEsign.Size = new System.Drawing.Size(96, 16);
            this.chkEsign.TabIndex = 6;
            this.chkEsign.Text = "启用电子签名";
            this.chkEsign.UseVisualStyleBackColor = true;
            // 
            // txtSignLibName
            // 
            this.txtSignLibName.Location = new System.Drawing.Point(288, 114);
            this.txtSignLibName.Name = "txtSignLibName";
            this.txtSignLibName.Size = new System.Drawing.Size(235, 21);
            this.txtSignLibName.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(526, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "…";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // chkCriticalDirectPrint
            // 
            this.chkCriticalDirectPrint.AutoSize = true;
            this.chkCriticalDirectPrint.Location = new System.Drawing.Point(578, 131);
            this.chkCriticalDirectPrint.Name = "chkCriticalDirectPrint";
            this.chkCriticalDirectPrint.Size = new System.Drawing.Size(144, 16);
            this.chkCriticalDirectPrint.TabIndex = 10;
            this.chkCriticalDirectPrint.Text = "危急重患者可直接打印";
            this.chkCriticalDirectPrint.UseVisualStyleBackColor = true;
            // 
            // chkGreenCriticalDirectPrint
            // 
            this.chkGreenCriticalDirectPrint.AutoSize = true;
            this.chkGreenCriticalDirectPrint.Location = new System.Drawing.Point(578, 153);
            this.chkGreenCriticalDirectPrint.Name = "chkGreenCriticalDirectPrint";
            this.chkGreenCriticalDirectPrint.Size = new System.Drawing.Size(144, 16);
            this.chkGreenCriticalDirectPrint.TabIndex = 11;
            this.chkGreenCriticalDirectPrint.Text = "绿色通道患者直接打印";
            this.chkGreenCriticalDirectPrint.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "报告审核级数";
            // 
            // cbxAuditLevel
            // 
            this.cbxAuditLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAuditLevel.FormattingEnabled = true;
            this.cbxAuditLevel.Items.AddRange(new object[] {
            "无",
            "一级",
            "二级",
            "三级"});
            this.cbxAuditLevel.Location = new System.Drawing.Point(288, 141);
            this.cbxAuditLevel.Name = "cbxAuditLevel";
            this.cbxAuditLevel.Size = new System.Drawing.Size(261, 20);
            this.cbxAuditLevel.TabIndex = 13;
            // 
            // chkUltimateAutoPrint
            // 
            this.chkUltimateAutoPrint.AutoSize = true;
            this.chkUltimateAutoPrint.Location = new System.Drawing.Point(578, 175);
            this.chkUltimateAutoPrint.Name = "chkUltimateAutoPrint";
            this.chkUltimateAutoPrint.Size = new System.Drawing.Size(108, 16);
            this.chkUltimateAutoPrint.TabIndex = 14;
            this.chkUltimateAutoPrint.Text = "终审后自动打印";
            this.chkUltimateAutoPrint.UseVisualStyleBackColor = true;
            // 
            // chkUltimateAutoFinish
            // 
            this.chkUltimateAutoFinish.AutoSize = true;
            this.chkUltimateAutoFinish.Location = new System.Drawing.Point(578, 197);
            this.chkUltimateAutoFinish.Name = "chkUltimateAutoFinish";
            this.chkUltimateAutoFinish.Size = new System.Drawing.Size(108, 16);
            this.chkUltimateAutoFinish.TabIndex = 15;
            this.chkUltimateAutoFinish.Text = "终审后自动完成";
            this.chkUltimateAutoFinish.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "自动发布报告";
            // 
            // chkHDiagnoseAuditPrint
            // 
            this.chkHDiagnoseAuditPrint.AutoSize = true;
            this.chkHDiagnoseAuditPrint.Location = new System.Drawing.Point(578, 109);
            this.chkHDiagnoseAuditPrint.Name = "chkHDiagnoseAuditPrint";
            this.chkHDiagnoseAuditPrint.Size = new System.Drawing.Size(144, 16);
            this.chkHDiagnoseAuditPrint.TabIndex = 18;
            this.chkHDiagnoseAuditPrint.Text = "平诊患者需终审后打印";
            this.chkHDiagnoseAuditPrint.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "检查科室";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(886, 381);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbxAutoPublicLevel);
            this.tabPage1.Controls.Add(this.chkWriteSelf);
            this.tabPage1.Controls.Add(this.chkUltimateAutoFinish);
            this.tabPage1.Controls.Add(this.chkHDiagnoseAuditPrint);
            this.tabPage1.Controls.Add(this.chkUltimateAutoPrint);
            this.tabPage1.Controls.Add(this.chkGreenCriticalDirectPrint);
            this.tabPage1.Controls.Add(this.txtDepartmentName);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cbxEqualAuditingLevel);
            this.tabPage1.Controls.Add(this.cbxDirectAuditingLevel);
            this.tabPage1.Controls.Add(this.chkCriticalDirectPrint);
            this.tabPage1.Controls.Add(this.chkConvertPDF);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cbxAuditLevel);
            this.tabPage1.Controls.Add(this.txtSignLibName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.chkEsign);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(878, 355);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "报告控制";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkWriteSelf
            // 
            this.chkWriteSelf.AutoSize = true;
            this.chkWriteSelf.Location = new System.Drawing.Point(578, 219);
            this.chkWriteSelf.Name = "chkWriteSelf";
            this.chkWriteSelf.Size = new System.Drawing.Size(156, 16);
            this.chkWriteSelf.TabIndex = 21;
            this.chkWriteSelf.Text = "只能书写自己检查的报告";
            this.chkWriteSelf.UseVisualStyleBackColor = true;
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Enabled = false;
            this.txtDepartmentName.Location = new System.Drawing.Point(288, 87);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(261, 21);
            this.txtDepartmentName.TabIndex = 20;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.cbxDockWay);
            this.tabPage2.Controls.Add(this.chkSignManager);
            this.tabPage2.Controls.Add(this.chkEscFinished);
            this.tabPage2.Controls.Add(this.chkGiveIn);
            this.tabPage2.Controls.Add(this.chkAbortView);
            this.tabPage2.Controls.Add(this.chkPDF);
            this.tabPage2.Controls.Add(this.chkDel);
            this.tabPage2.Controls.Add(this.chkUnlock);
            this.tabPage2.Controls.Add(this.chkRejectManager);
            this.tabPage2.Controls.Add(this.chkReject);
            this.tabPage2.Controls.Add(this.chkNew);
            this.tabPage2.Controls.Add(this.chkMore);
            this.tabPage2.Controls.Add(this.chkRefresh);
            this.tabPage2.Controls.Add(this.chkFinished);
            this.tabPage2.Controls.Add(this.chkGiveOut);
            this.tabPage2.Controls.Add(this.chkAllowView);
            this.tabPage2.Controls.Add(this.chkAddReportImage);
            this.tabPage2.Controls.Add(this.chkSign);
            this.tabPage2.Controls.Add(this.chkQuitRevise);
            this.tabPage2.Controls.Add(this.chkSureRevise);
            this.tabPage2.Controls.Add(this.chkRevise);
            this.tabPage2.Controls.Add(this.chkPrint);
            this.tabPage2.Controls.Add(this.chkPreview);
            this.tabPage2.Controls.Add(this.chkSave);
            this.tabPage2.Controls.Add(this.toolsConfig1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(878, 355);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "界面设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "停靠位置";
            // 
            // cbxDockWay
            // 
            this.cbxDockWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDockWay.FormattingEnabled = true;
            this.cbxDockWay.Items.AddRange(new object[] {
            "顶部",
            "左侧",
            "右侧",
            "底部"});
            this.cbxDockWay.Location = new System.Drawing.Point(68, 326);
            this.cbxDockWay.Name = "cbxDockWay";
            this.cbxDockWay.Size = new System.Drawing.Size(104, 20);
            this.cbxDockWay.TabIndex = 24;
            // 
            // chkSignManager
            // 
            this.chkSignManager.AutoSize = true;
            this.chkSignManager.Location = new System.Drawing.Point(796, 299);
            this.chkSignManager.Name = "chkSignManager";
            this.chkSignManager.Size = new System.Drawing.Size(72, 16);
            this.chkSignManager.TabIndex = 23;
            this.chkSignManager.Text = "签名管理";
            this.chkSignManager.UseVisualStyleBackColor = true;
            // 
            // chkEscFinished
            // 
            this.chkEscFinished.AutoSize = true;
            this.chkEscFinished.Location = new System.Drawing.Point(718, 299);
            this.chkEscFinished.Name = "chkEscFinished";
            this.chkEscFinished.Size = new System.Drawing.Size(72, 16);
            this.chkEscFinished.TabIndex = 22;
            this.chkEscFinished.Text = "取消完结";
            this.chkEscFinished.UseVisualStyleBackColor = true;
            // 
            // chkGiveIn
            // 
            this.chkGiveIn.AutoSize = true;
            this.chkGiveIn.Location = new System.Drawing.Point(640, 299);
            this.chkGiveIn.Name = "chkGiveIn";
            this.chkGiveIn.Size = new System.Drawing.Size(72, 16);
            this.chkGiveIn.TabIndex = 21;
            this.chkGiveIn.Text = "取消发放";
            this.chkGiveIn.UseVisualStyleBackColor = true;
            // 
            // chkAbortView
            // 
            this.chkAbortView.AutoSize = true;
            this.chkAbortView.Location = new System.Drawing.Point(562, 299);
            this.chkAbortView.Name = "chkAbortView";
            this.chkAbortView.Size = new System.Drawing.Size(72, 16);
            this.chkAbortView.TabIndex = 20;
            this.chkAbortView.Text = "终止查阅";
            this.chkAbortView.UseVisualStyleBackColor = true;
            // 
            // chkPDF
            // 
            this.chkPDF.AutoSize = true;
            this.chkPDF.Location = new System.Drawing.Point(472, 299);
            this.chkPDF.Name = "chkPDF";
            this.chkPDF.Size = new System.Drawing.Size(66, 16);
            this.chkPDF.TabIndex = 19;
            this.chkPDF.Text = "PDF转换";
            this.chkPDF.UseVisualStyleBackColor = true;
            // 
            // chkDel
            // 
            this.chkDel.AutoSize = true;
            this.chkDel.Location = new System.Drawing.Point(418, 299);
            this.chkDel.Name = "chkDel";
            this.chkDel.Size = new System.Drawing.Size(48, 16);
            this.chkDel.TabIndex = 18;
            this.chkDel.Text = "删除";
            this.chkDel.UseVisualStyleBackColor = true;
            // 
            // chkUnlock
            // 
            this.chkUnlock.AutoSize = true;
            this.chkUnlock.Location = new System.Drawing.Point(322, 299);
            this.chkUnlock.Name = "chkUnlock";
            this.chkUnlock.Size = new System.Drawing.Size(72, 16);
            this.chkUnlock.TabIndex = 17;
            this.chkUnlock.Text = "解除锁定";
            this.chkUnlock.UseVisualStyleBackColor = true;
            // 
            // chkRejectManager
            // 
            this.chkRejectManager.AutoSize = true;
            this.chkRejectManager.Location = new System.Drawing.Point(244, 299);
            this.chkRejectManager.Name = "chkRejectManager";
            this.chkRejectManager.Size = new System.Drawing.Size(72, 16);
            this.chkRejectManager.TabIndex = 16;
            this.chkRejectManager.Text = "驳回管理";
            this.chkRejectManager.UseVisualStyleBackColor = true;
            // 
            // chkReject
            // 
            this.chkReject.AutoSize = true;
            this.chkReject.Location = new System.Drawing.Point(190, 299);
            this.chkReject.Name = "chkReject";
            this.chkReject.Size = new System.Drawing.Size(48, 16);
            this.chkReject.TabIndex = 15;
            this.chkReject.Text = "驳回";
            this.chkReject.UseVisualStyleBackColor = true;
            // 
            // chkNew
            // 
            this.chkNew.AutoSize = true;
            this.chkNew.Location = new System.Drawing.Point(114, 299);
            this.chkNew.Name = "chkNew";
            this.chkNew.Size = new System.Drawing.Size(48, 16);
            this.chkNew.TabIndex = 14;
            this.chkNew.Text = "新增";
            this.chkNew.UseVisualStyleBackColor = true;
            // 
            // chkMore
            // 
            this.chkMore.AutoSize = true;
            this.chkMore.Location = new System.Drawing.Point(60, 299);
            this.chkMore.Name = "chkMore";
            this.chkMore.Size = new System.Drawing.Size(48, 16);
            this.chkMore.TabIndex = 13;
            this.chkMore.Text = "更多";
            this.chkMore.UseVisualStyleBackColor = true;
            // 
            // chkRefresh
            // 
            this.chkRefresh.AutoSize = true;
            this.chkRefresh.Location = new System.Drawing.Point(6, 299);
            this.chkRefresh.Name = "chkRefresh";
            this.chkRefresh.Size = new System.Drawing.Size(48, 16);
            this.chkRefresh.TabIndex = 12;
            this.chkRefresh.Text = "刷新";
            this.chkRefresh.UseVisualStyleBackColor = true;
            // 
            // chkFinished
            // 
            this.chkFinished.AutoSize = true;
            this.chkFinished.Location = new System.Drawing.Point(718, 277);
            this.chkFinished.Name = "chkFinished";
            this.chkFinished.Size = new System.Drawing.Size(72, 16);
            this.chkFinished.TabIndex = 11;
            this.chkFinished.Text = "完结报告";
            this.chkFinished.UseVisualStyleBackColor = true;
            // 
            // chkGiveOut
            // 
            this.chkGiveOut.AutoSize = true;
            this.chkGiveOut.Location = new System.Drawing.Point(640, 277);
            this.chkGiveOut.Name = "chkGiveOut";
            this.chkGiveOut.Size = new System.Drawing.Size(72, 16);
            this.chkGiveOut.TabIndex = 10;
            this.chkGiveOut.Text = "发放报告";
            this.chkGiveOut.UseVisualStyleBackColor = true;
            // 
            // chkAllowView
            // 
            this.chkAllowView.AutoSize = true;
            this.chkAllowView.Location = new System.Drawing.Point(562, 277);
            this.chkAllowView.Name = "chkAllowView";
            this.chkAllowView.Size = new System.Drawing.Size(72, 16);
            this.chkAllowView.TabIndex = 9;
            this.chkAllowView.Text = "开放查阅";
            this.chkAllowView.UseVisualStyleBackColor = true;
            // 
            // chkAddReportImage
            // 
            this.chkAddReportImage.AutoSize = true;
            this.chkAddReportImage.Location = new System.Drawing.Point(472, 277);
            this.chkAddReportImage.Name = "chkAddReportImage";
            this.chkAddReportImage.Size = new System.Drawing.Size(84, 16);
            this.chkAddReportImage.TabIndex = 8;
            this.chkAddReportImage.Text = "加入报告图";
            this.chkAddReportImage.UseVisualStyleBackColor = true;
            // 
            // chkSign
            // 
            this.chkSign.AutoSize = true;
            this.chkSign.Location = new System.Drawing.Point(418, 277);
            this.chkSign.Name = "chkSign";
            this.chkSign.Size = new System.Drawing.Size(48, 16);
            this.chkSign.TabIndex = 7;
            this.chkSign.Text = "签名";
            this.chkSign.UseVisualStyleBackColor = true;
            // 
            // chkQuitRevise
            // 
            this.chkQuitRevise.AutoSize = true;
            this.chkQuitRevise.Location = new System.Drawing.Point(322, 277);
            this.chkQuitRevise.Name = "chkQuitRevise";
            this.chkQuitRevise.Size = new System.Drawing.Size(72, 16);
            this.chkQuitRevise.TabIndex = 6;
            this.chkQuitRevise.Text = "退出修订";
            this.chkQuitRevise.UseVisualStyleBackColor = true;
            // 
            // chkSureRevise
            // 
            this.chkSureRevise.AutoSize = true;
            this.chkSureRevise.Location = new System.Drawing.Point(244, 277);
            this.chkSureRevise.Name = "chkSureRevise";
            this.chkSureRevise.Size = new System.Drawing.Size(72, 16);
            this.chkSureRevise.TabIndex = 5;
            this.chkSureRevise.Text = "确认修订";
            this.chkSureRevise.UseVisualStyleBackColor = true;
            // 
            // chkRevise
            // 
            this.chkRevise.AutoSize = true;
            this.chkRevise.Location = new System.Drawing.Point(190, 277);
            this.chkRevise.Name = "chkRevise";
            this.chkRevise.Size = new System.Drawing.Size(48, 16);
            this.chkRevise.TabIndex = 4;
            this.chkRevise.Text = "修订";
            this.chkRevise.UseVisualStyleBackColor = true;
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Location = new System.Drawing.Point(114, 277);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(48, 16);
            this.chkPrint.TabIndex = 3;
            this.chkPrint.Text = "打印";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // chkPreview
            // 
            this.chkPreview.AutoSize = true;
            this.chkPreview.Location = new System.Drawing.Point(60, 277);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Size = new System.Drawing.Size(48, 16);
            this.chkPreview.TabIndex = 2;
            this.chkPreview.Text = "预览";
            this.chkPreview.UseVisualStyleBackColor = true;
            // 
            // chkSave
            // 
            this.chkSave.AutoSize = true;
            this.chkSave.Location = new System.Drawing.Point(6, 277);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(48, 16);
            this.chkSave.TabIndex = 1;
            this.chkSave.Text = "保存";
            this.chkSave.UseVisualStyleBackColor = true;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(819, 399);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 25;
            this.butCancel.Text = "取消(&C)";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSure
            // 
            this.butSure.Location = new System.Drawing.Point(738, 399);
            this.butSure.Name = "butSure";
            this.butSure.Size = new System.Drawing.Size(75, 23);
            this.butSure.TabIndex = 24;
            this.butSure.Text = "确定(&S)";
            this.butSure.UseVisualStyleBackColor = true;
            this.butSure.Click += new System.EventHandler(this.butSure_Click);
            // 
            // toolsConfig1
            // 
            this.toolsConfig1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolsConfig1.Location = new System.Drawing.Point(3, 3);
            this.toolsConfig1.Name = "toolsConfig1";
            this.toolsConfig1.Size = new System.Drawing.Size(872, 268);
            this.toolsConfig1.TabIndex = 0;
            this.toolsConfig1.ToolsDesign = null;
            // 
            // cbxAutoPublicLevel
            // 
            this.cbxAutoPublicLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAutoPublicLevel.FormattingEnabled = true;
            this.cbxAutoPublicLevel.Items.AddRange(new object[] {
            "不允许",
            "住院医师及以上",
            "主治医师及以上",
            "副主任医师及以上",
            "主任医师"});
            this.cbxAutoPublicLevel.Location = new System.Drawing.Point(288, 219);
            this.cbxAutoPublicLevel.Name = "cbxAutoPublicLevel";
            this.cbxAutoPublicLevel.Size = new System.Drawing.Size(261, 20);
            this.cbxAutoPublicLevel.TabIndex = 22;
            // 
            // frmReportDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 432);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSure);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.frmReportDesign_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxDirectAuditingLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkConvertPDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxEqualAuditingLevel;
        private System.Windows.Forms.CheckBox chkEsign;
        private System.Windows.Forms.TextBox txtSignLibName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkCriticalDirectPrint;
        private System.Windows.Forms.CheckBox chkGreenCriticalDirectPrint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxAuditLevel;
        private System.Windows.Forms.CheckBox chkUltimateAutoPrint;
        private System.Windows.Forms.CheckBox chkUltimateAutoFinish;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkHDiagnoseAuditPrint;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chkPreview;
        private System.Windows.Forms.CheckBox chkSave;
        private BusinessBase.Controls.ToolsConfig toolsConfig1;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.CheckBox chkQuitRevise;
        private System.Windows.Forms.CheckBox chkSureRevise;
        private System.Windows.Forms.CheckBox chkRevise;
        private System.Windows.Forms.CheckBox chkAllowView;
        private System.Windows.Forms.CheckBox chkAddReportImage;
        private System.Windows.Forms.CheckBox chkSign;
        private System.Windows.Forms.CheckBox chkNew;
        private System.Windows.Forms.CheckBox chkMore;
        private System.Windows.Forms.CheckBox chkRefresh;
        private System.Windows.Forms.CheckBox chkFinished;
        private System.Windows.Forms.CheckBox chkGiveOut;
        private System.Windows.Forms.CheckBox chkRejectManager;
        private System.Windows.Forms.CheckBox chkReject;
        private System.Windows.Forms.CheckBox chkDel;
        private System.Windows.Forms.CheckBox chkUnlock;
        private System.Windows.Forms.CheckBox chkEscFinished;
        private System.Windows.Forms.CheckBox chkGiveIn;
        private System.Windows.Forms.CheckBox chkAbortView;
        private System.Windows.Forms.CheckBox chkPDF;
        private System.Windows.Forms.CheckBox chkSignManager;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxDockWay;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSure;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.CheckBox chkWriteSelf;
        private System.Windows.Forms.ComboBox cbxAutoPublicLevel;
    }
}