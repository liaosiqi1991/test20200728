using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.BusinessBase;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Report
{
    public partial class frmReportDesign : Form
    {
        private bool _isOk = false;

        private ReportPars _reportPars = null;
        private ReportModuleDesign _reportDesign = null;
        private IStationInfo _stationInfo = null;
        private IDBQuery _dbHelper = null;
        public frmReportDesign()
        {
            InitializeComponent();
        }

        public bool ShowReportDesign(ReportPars reportPars, ReportModuleDesign reportDesign, 
            IStationInfo stationInfo, IDBQuery dbHelper, IWin32Window owner)
        {
            _isOk = false;

            _reportPars = reportPars;
            _reportDesign = reportDesign;
            _stationInfo = stationInfo;
            _dbHelper = dbHelper;

            toolsConfig1.InitToolDesign(reportDesign.ToolsDesign);

            this.ShowDialog(owner);

            return _isOk;
        }

        private string GetLevelAlias(int level)
        {
            switch(level)
            {
                case 0:
                    return "无";

                case 1:
                    return "一级";

                case 2:
                    return "二级";

                case 3:
                    return "三级";

                default:
                    return "";

            }

        }



        private void frmReportDesign_Load(object sender, EventArgs e)
        {
            try
            {
                if (_reportPars != null)
                {
                    txtDepartmentName.Text = _stationInfo.DepartmentName;
                    chkSign.Checked = _reportPars.UseESign;
                    txtSignLibName.Text = _reportPars.ESignLibName;
                    cbxAuditLevel.Text = GetLevelAlias(_reportPars.ReportAuditLevel);
                    cbxEqualAuditingLevel.SelectedIndex = (_reportPars.EqualAdutingLevel <= 0) ? 0 : _reportPars.EqualAdutingLevel;
                    cbxDirectAuditingLevel.SelectedIndex = (_reportPars.DirectAuditingLevel <= 0) ? 0 : _reportPars.DirectAuditingLevel;
                    cbxAutoPublicLevel.SelectedIndex = (_reportPars.AutoPublicLevel <= 0) ? 0 : _reportPars.AutoPublicLevel;

                    chkConvertPDF.Checked = _reportPars.PrintAutoConvertPDF;
                    chkHDiagnoseAuditPrint.Checked = _reportPars.NormalDiagnosePrintNeedUltimate;
                    chkCriticalDirectPrint.Checked = _reportPars.CriticalDiagnoseAllowDirectPrint;
                    chkGreenCriticalDirectPrint.Checked = _reportPars.GreenDiagnoseAllowDirectPrint;
                    chkUltimateAutoPrint.Checked = _reportPars.UltimateAutoPrint;
                    chkUltimateAutoFinish.Checked = _reportPars.UltimateAutoFinish;
                    chkWriteSelf.Checked = _reportPars.WriteSelf;
                }

                if (_reportDesign != null)
                {
                    chkSave.Checked = _reportDesign.ButSaveVisible;
                    chkPreview.Checked = _reportDesign.ButPreviewVisible;
                    chkPrint.Checked = _reportDesign.ButPrintVisible;
                    chkRevise.Checked = _reportDesign.ButReviseVisible;
                    chkSureRevise.Checked = _reportDesign.ButSureReviseVisible;
                    chkQuitRevise.Checked = _reportDesign.ButQuitReviseVisible;
                    chkSign.Checked = _reportDesign.ButSignVisible;
                    chkAddReportImage.Checked = _reportDesign.ButAddReportImgVisible;
                    chkAllowView.Checked = _reportDesign.ButAllowViewVisible;
                    chkGiveOut.Checked = _reportDesign.ButGiveOutVisible;
                    chkFinished.Checked = _reportDesign.ButFinishedVisible;
                    chkRefresh.Checked = _reportDesign.ButRefreshVisible;
                    chkMore.Checked = _reportDesign.ButMoreVisible;
                    chkNew.Checked = _reportDesign.ButNewVisible;
                    chkReject.Checked = _reportDesign.ButRejectVisible;
                    chkRejectManager.Checked = _reportDesign.ButRejectManagerVisible;
                    chkUnlock.Checked = _reportDesign.ButUnlockVisible;
                    chkDel.Checked = _reportDesign.ButDelVisible;
                    chkPDF.Checked = _reportDesign.ButPDFConvertVisible;
                    chkAbortView.Checked = _reportDesign.ButAbortViewVisible;
                    chkGiveIn.Checked = _reportDesign.ButGiveInVisible;
                    chkEscFinished.Checked = _reportDesign.ButEscFinishedVisible;
                    chkSignManager.Checked = _reportDesign.ButSignManagerVisible;

                    cbxDockWay.SelectedIndex = (int)_reportDesign.Dock;


                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                toolsConfig1.ApplyUpdate();

                if (_reportPars != null)
                {
                    _reportPars.UseESign = chkEsign.Checked;
                    _reportPars.ESignLibName = txtSignLibName.Text;

                    _reportPars.ReportAuditLevel = cbxAuditLevel.SelectedIndex;
                    _reportPars.EqualAdutingLevel = (cbxEqualAuditingLevel.SelectedIndex == 0) ? -1 : cbxEqualAuditingLevel.SelectedIndex;
                    _reportPars.DirectAuditingLevel = (cbxDirectAuditingLevel.SelectedIndex == 0) ? -1 : cbxDirectAuditingLevel.SelectedIndex;
                    _reportPars.AutoPublicLevel = (cbxAutoPublicLevel.SelectedIndex == 0) ? -1 : cbxAutoPublicLevel.SelectedIndex;

                    _reportPars.PrintAutoConvertPDF = chkConvertPDF.Checked;
                    _reportPars.NormalDiagnosePrintNeedUltimate = chkHDiagnoseAuditPrint.Checked;
                    _reportPars.CriticalDiagnoseAllowDirectPrint = chkCriticalDirectPrint.Checked;
                    _reportPars.GreenDiagnoseAllowDirectPrint = chkGreenCriticalDirectPrint.Checked;
                    _reportPars.UltimateAutoPrint = chkUltimateAutoPrint.Checked;
                    _reportPars.UltimateAutoFinish = chkUltimateAutoFinish.Checked;
                    _reportPars.WriteSelf = chkWriteSelf.Checked;

                    ParameterData parData = new ParameterData();

                    parData.参数ID = SqlHelper.GetNumGuid();
                    parData.参数名称 = "报告控制";
                    parData.参数标记 = _stationInfo.DepartmentId;
                    parData.参数取值 = JsonHelper.SerializeObject(_reportPars);

                    ParameterModel pm = new ParameterModel(_dbHelper);
                    pm.WriteParameter(parData);

                }

                if (_reportDesign != null)
                {
                    _reportDesign.ButAbortViewVisible = chkAbortView.Checked;
                    _reportDesign.ButAddReportImgVisible = chkAddReportImage.Checked;
                    _reportDesign.ButAllowViewVisible = chkAllowView.Checked;
                    _reportDesign.ButDelVisible = chkDel.Checked;
                    _reportDesign.ButEscFinishedVisible = chkEscFinished.Checked;
                    _reportDesign.ButFinishedVisible = chkFinished.Checked;
                    _reportDesign.ButGiveInVisible = chkGiveIn.Checked;
                    _reportDesign.ButGiveOutVisible = chkGiveOut.Checked;
                    _reportDesign.ButMoreVisible = chkMore.Checked;
                    _reportDesign.ButNewVisible = chkNew.Checked;
                    _reportDesign.ButPDFConvertVisible = chkPDF.Checked;
                    _reportDesign.ButPreviewVisible = chkPreview.Checked;
                    _reportDesign.ButPrintVisible = chkPreview.Checked;
                    _reportDesign.ButQuitReviseVisible = chkQuitRevise.Checked;
                    _reportDesign.ButRefreshVisible = chkRefresh.Checked;
                    _reportDesign.ButRejectManagerVisible = chkRejectManager.Checked;
                    _reportDesign.ButRejectVisible = chkReject.Checked;
                    _reportDesign.ButReviseVisible = chkRevise.Checked;
                    _reportDesign.ButSaveVisible = chkSave.Checked;
                    _reportDesign.ButSignManagerVisible = chkSignManager.Checked;
                    _reportDesign.ButSignVisible = chkSign.Checked;
                    _reportDesign.ButSureReviseVisible = chkSureRevise.Checked;
                    _reportDesign.ButUnlockVisible = chkUnlock.Checked;

                    _reportDesign.Dock = (ToolDockWay)(cbxDockWay.SelectedIndex);

                    _reportDesign.ToolsDesign = toolsConfig1.ToolsDesign;
                }

                _isOk = true;

                this.Close();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}
