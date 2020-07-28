using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Report
{
    public partial class frmReportReject : Form
    {
        private bool _isOk = false;

        private ReportContextModel _reportDbModel = null;
        private ReportContextData _reportData = null;
        private ILoginUser _userData = null;

        public bool IsOk
        {
            get { return _isOk; }
        }
        public frmReportReject()
        {
            InitializeComponent();
        }

        public void ShowReject(ReportContextModel reportDbModel, ReportContextData reportData, ILoginUser userData, IWin32Window owner)
        {
            _isOk = false;

            _reportDbModel = reportDbModel;
            _reportData = reportData;
            _userData = userData;

            this.ShowDialog(owner);

        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                _isOk = false;

                this.Close();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(rtbRejectReason.Text))
                {
                    MessageBox.Show("驳回理由不能为空。", "提示");
                    return;
                }

                JReportRejectItem reportReject = new JReportRejectItem();

                reportReject.驳回人 = _userData.Name;
                reportReject.驳回理由 = rtbRejectReason.Text;
                reportReject.驳回时间 = _reportDbModel.GetServerDate();
                reportReject.驳回状态 = (int)ReportRejectState.rrsRejecting;

                _reportData.驳回信息.驳回明细.Add(reportReject);

                _reportData.状态信息.是否驳回中 = true;
                _reportData.状态信息.最后更新时间 = _reportDbModel.GetServerDate();

                _reportDbModel.RejectReport(_reportData);

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
