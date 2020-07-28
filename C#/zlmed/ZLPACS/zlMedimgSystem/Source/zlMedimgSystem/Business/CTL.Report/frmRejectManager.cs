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
    public partial class frmRejectManager : Form
    {
        private bool _isOk = false;

        private ReportContextModel _reportDbModel = null;
        private ReportContextData _reportData = null;
        private ILoginUser _userData = null;
        private ReportPars _reportPars = new ReportPars();

        private bool _isBinding = false;

        public bool IsOk
        {
            get { return _isOk; }
        }

        public frmRejectManager()
        {
            InitializeComponent();
        }

        public void ShowManager(ReportContextModel reportDbModel, ReportContextData reportData, ILoginUser userData, ReportPars reportPars, IWin32Window owner)
        {
            _isOk = false;

            _reportDbModel = reportDbModel;
            _reportData = reportData;
            _userData = userData;
            _reportPars = reportPars;

            this.ShowDialog(owner);

        }

        private void frmRejectManager_Load(object sender, EventArgs e)
        {
            try
            { 
                LoadRejectData();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void LoadRejectData()
        {
            _isBinding = true;

            try
            {
                rtbRejectReason.Text = "";

                dataGridView1.DataSource = null;

                if (_reportData == null) return;
                if (_reportData.驳回信息 == null) return;
                if (_reportData.驳回信息.驳回明细.Count <= 0) return;

                List<JReportRejectItem> rejects = _reportData.驳回信息.驳回明细.OrderByDescending(T => T.驳回时间).ToList();


                dataGridView1.DataSource = rejects;// _reportData.签名信息.签名明细;



                dataGridView1.Columns["Key"].Visible = false; 
                dataGridView1.Columns["驳回理由"].Visible = false;
                dataGridView1.Columns["驳回状态"].Visible = false;
                dataGridView1.Columns["处理人"].Visible = false;
                dataGridView1.Columns["处理时间"].Visible = false;
                dataGridView1.Columns["处理描述"].Visible = false;
                dataGridView1.Columns["驳回时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //dataGridView1.Sort(dataGridView1.Columns["签名时间"], ListSortDirection.Descending); 
            }
            finally
            {
                _isBinding = false;

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = true;
                    dataGridView1_SelectionChanged(dataGridView1, null);
                }
            }


        }

        private void ClearData()
        {
            txtRejectUser.Text = "";
            txtRejectTime.Text = "";
            txtRejectState.Text = "";
            rtbRejectReason.Text = "";
            txtProcessTime.Text = "";
            txtProcessUserName.Text = "";
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isBinding) return;

                ClearData();

                if (dataGridView1.DataSource == null) return;
                if (dataGridView1.SelectedRows.Count <= 0) return;

                DataGridViewRow dvr = dataGridView1.SelectedRows[0];


                string signKey = dvr.Cells["Key"].Value.ToString();

                JReportRejectItem rejectItem = _reportData.驳回信息.驳回明细.Find(T => T.Key == signKey);

                if (rejectItem != null)
                {
                    txtRejectUser.Text = rejectItem.驳回人;
                    txtRejectTime.Text = rejectItem.驳回时间.ToString("yyyy-MM-dd HH:mm");
                    txtRejectState.Text = ((rejectItem.驳回状态 == 0) ? "驳回中" : ((rejectItem.驳回状态 == 1) ? "已处理" : "已撤销"));
                    rtbRejectReason.Text = rejectItem.驳回理由;

                    if (string.IsNullOrEmpty(rejectItem.处理人) == false)
                    {
                        txtProcessUserName.Text = rejectItem.处理人;
                        txtProcessTime.Text = rejectItem.处理时间.ToString("yyyy-MM-dd HH:mm");
                    }
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 检查状态改变
        /// </summary>
        /// <param name="reportData"></param>
        /// <returns></returns>
        private bool CheckStateChange(ReportContextData reportData)
        {
            //验证最新报告状态是否有变化
            if (reportData == null) return true;

            JReportStateInfo newState = _reportDbModel.GetReportStateInfo(reportData.报告ID);
            if (reportData.状态信息.是否已完结)
            {
                MessageBox.Show("报告已被他人完结，请刷新后重设。", "提示");
                return false;
            }

            if (reportData.状态信息.最后更新时间 != newState.最后更新时间)
            {
                MessageBox.Show("报告最后更新日期与当前不匹配，请刷新后重设。", "提示");
                return false;
            }

            return true;
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.DataSource == null || dataGridView1.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("请选择需要撤销的驳回信息。", "提示");
                    return;
                }

                if (dataGridView1.SelectedRows[0] != dataGridView1.Rows[0])
                {
                    MessageBox.Show("只能撤销最后一次驳回信息。", "提示");
                    return;
                }

                //验证用户级别
                JReportSignInfo signInfo = _reportData.签名信息;

                JReportSignItem signLast = signInfo.签名明细[signInfo.签名明细.Count - 1];

                if (signLast.用户名称 != _userData.Name)
                {
                    if (_userData.Level < signLast.用户级别)
                    {
                        MessageBox.Show("报告最后已由 [" + signLast.用户名称 + "] 处理，无权进行撤销。", "提示");
                        return;
                    }

                    if (_userData.Level == signLast.用户级别)
                    {
                        if (!(_reportPars.EqualAdutingLevel > -1 && _userData.Level >= _reportPars.EqualAdutingLevel))
                        {
                            MessageBox.Show("报告最后已由 [" + signLast.用户名称 + "] 处理，无权进行撤销。", "提示");
                            return;
                        }
                    }
                }


                //检查状态是否改变
                if (CheckStateChange(_reportData) == false) return;

                DataGridViewRow dvr = dataGridView1.SelectedRows[0];

                string rejectKey = dvr.Cells["Key"].Value.ToString();

                JReportRejectInfo rejectInfo = _reportData.驳回信息;
                int backIndex = rejectInfo.驳回明细.FindIndex(T => T.Key == rejectKey);
                if (backIndex < 0)
                {
                    MessageBox.Show("未找到对应驳回信息，不能进行撤销。", "提示");
                    return;
                }

                JReportRejectItem rejectItem = rejectInfo.驳回明细[backIndex];
                if (rejectItem == null)
                {
                    MessageBox.Show("当前所选驳回信息无效，不能进行撤销。", "提示");
                    return;
                }

                if (rejectItem.驳回状态 != 0)
                {
                    MessageBox.Show("当前驳回已被处理，不能进行撤销。", "提示");
                    return; 
                }


                rejectItem.驳回状态 = (int)ReportRejectState.rrsCanceled;

                _reportData.状态信息.是否驳回中 = false;
                _reportData.状态信息.最后更新时间 = _reportDbModel.GetServerDate();

                _reportDbModel.RejectReport(_reportData);

                _isOk = true;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
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
    }
}
