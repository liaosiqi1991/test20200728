using FormPart;
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
    public partial class frmSignManager : Form
    {
        private bool _IsOk = false;

        private ReportContextModel _reportModel = null;
        private ReportContextData _reportData = null;
        private IDBQuery _dbHelper = null;
        private ILoginUser _userData = null;
        private ReportPars _reportPars = new ReportPars();

        private bool _isBinding = false;

        private PreviewControl previewControl1 = null;
        public bool IsOk
        {
            get { return _IsOk; }
        }

        public frmSignManager()
        {
            InitializeComponent();
        }

        public void ShowSignBack(ReportContextModel reportModel,
                            ReportContextData reportData, 
                            IDBQuery dbHelper, 
                            ILoginUser user, 
                            ReportPars reportPars,
                            IWin32Window owner)
        {
            _IsOk = false;

            _reportModel = reportModel;
            _reportData = reportData;
            _dbHelper = dbHelper;
            _userData = user;
            _reportPars = reportPars;

            this.ShowDialog(owner);
        }

        private void frmBackSign_Load(object sender, EventArgs e)
        {
            try
            {
                previewControl1 = new PreviewControl();
                panlReportView.Controls.Add(previewControl1);

                previewControl1.Dock = DockStyle.Fill;

                LoadSignInfo();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void LoadSignInfo()
        {
            _isBinding = true;
            
            try
            {
                previewControl1.ImportByXml("");

                dataGridView1.DataSource = null;

                if (_reportData == null) return;
                if (_reportData.签名信息 == null) return;
                if (_reportData.签名信息.签名明细.Count <= 0) return;

                List<JReportSignItem> signs = _reportData.签名信息.签名明细.OrderByDescending(T=>T.签名时间).ToList();
 

                dataGridView1.DataSource = signs;// _reportData.签名信息.签名明细;

                
         
                dataGridView1.Columns["Key"].Visible = false;
                dataGridView1.Columns["用户ID"].Visible = false;
                dataGridView1.Columns["用户级别"].Visible = false;
                //dataGridView1.Columns["是否修订"].Visible = false;
                dataGridView1.Columns["是否审核"].Visible = false;
                dataGridView1.Columns["证书信息"].Visible = false;
                dataGridView1.Columns["签名结果"].Visible = false;
                dataGridView1.Columns["签名报告"].Visible = false;
                dataGridView1.Columns["签名时状态"].Visible = false;
                dataGridView1.Columns["签名时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isBinding) return;

                previewControl1.ImportByXml("");

                if (dataGridView1.DataSource == null) return;
                if (dataGridView1.SelectedRows.Count <= 0) return;

                DataGridViewRow dvr = dataGridView1.SelectedRows[0];


                string signKey = dvr.Cells["Key"].Value.ToString();

                JReportSignItem signItem = _reportData.签名信息.签名明细.Find(T => T.Key == signKey);

                if (signItem != null)
                {
                    previewControl1.ImportByXml(signItem.签名报告);
                    previewControl1.ReadOnly = true;
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

            JReportStateInfo newState = _reportModel.GetReportStateInfo(reportData.报告ID);
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

        private void tsbBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.DataSource == null || dataGridView1.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("请选择需要回退到的报告签名。","提示");
                    return;
                }

                if (_reportData.签名信息 == null || _reportData.签名信息.签名明细.Count <= 0)
                {
                    MessageBox.Show("报告尚未进行签名，不能进行回退处理。", "提示");
                    return;
                }

                if (_reportData.状态信息.是否已完结)
                {
                    MessageBox.Show("报告已完结，不能进行回退处理。", "提示");
                    return;
                }

                JReportSignInfo signInfo = _reportData.签名信息;

                JReportSignItem signLast = signInfo.签名明细[signInfo.签名明细.Count - 1];

                if (signLast.用户名称 != _userData.Name)
                {
                    if (_userData.Level < signLast.用户级别)
                    {
                        MessageBox.Show("报告最后已由 [" + signLast.用户名称 + "] 处理，无权进行回退。", "提示");
                        return;
                    }

                    if (_userData.Level == signLast.用户级别)
                    {
                        if (!(_reportPars.EqualAdutingLevel > -1 && _userData.Level >= _reportPars.EqualAdutingLevel))
                        {
                            MessageBox.Show("报告最后已由 [" + signLast.用户名称 + "] 处理，无权进行回退。", "提示");
                            return;
                        }
                    } 
                }


                DataGridViewRow dvr = dataGridView1.SelectedRows[0];

                string signKey = dvr.Cells["Key"].Value.ToString();

                int backIndex = signInfo.签名明细.FindIndex(T => T.Key == signKey);
                if (backIndex < 0)
                {
                    MessageBox.Show("未找到对应签名信息，不能进行回退。", "提示");
                    return;
                }

                JReportSignItem signback = signInfo.签名明细[backIndex]; 
                if (signback == null )
                {
                    MessageBox.Show("当前所选签名无效，不能进行回退。", "提示");
                    return;
                }

                if (CheckStateChange(_reportData) == false) return;


                string reason = "";

                using (frmReason backReason = new frmReason())
                {
                    reason = backReason.ShowReason(this);
                }

                if (string.IsNullOrEmpty(reason)) return;

                //报告回退处理


                _reportData.状态信息.签名状态 = signback.签名时状态;
                _reportData.状态信息.最后更新时间 = _reportModel.GetServerDate();

                _reportData.报告信息.最后审签人 = "";
                _reportData.报告信息.最后审签时间 = default(DateTime);

                JReportBackItem backItem = new JReportBackItem();
                backItem.回退人 = _userData.Name;
                backItem.回退原因 = reason;
                backItem.回退时间 = _reportModel.GetServerDate();
                backItem.终签状态 = signLast.CloneTo();

                _reportData.回退信息.回退明细.Add(backItem);


                //配置回退签名后的报告
                if (backIndex > 0)
                {
                    JReportSignItem signNext = signInfo.签名明细[backIndex - 1];
                    if (string.IsNullOrEmpty(signNext.签名报告) == false)
                    {
                        previewControl1.ImportByXml(signNext.签名报告);

                    }
                    else
                    {
                        //获取上次签名的内容
                        for (int i = backIndex - 1; i >= 0; i--)
                        {
                            JReportSignItem signItem = signInfo.签名明细[backIndex];

                            if (string.IsNullOrEmpty(signItem.签名报告)) continue;

                            previewControl1.ImportByXml(signItem.签名报告);
                            break;
                        }
                    }
                }
                else
                {
                    previewControl1.ImportByXml(signback.签名报告);
                }

                previewControl1.ReadOnly = true;


                for (int i = signInfo.签名明细.Count - 1; i >= backIndex; i --)
                {
                    signInfo.签名明细.RemoveAt(i);
                }

                //调整审核签名状态
                int auditCount = ReportPublic.GetAuditingCount(_reportData);

                if (auditCount > 0 )
                {
                    //写入最后审核人
                    _reportData.报告信息.最后审签人 = signInfo.签名明细[signInfo.签名明细.Count - 1].用户名称;
                    _reportData.报告信息.最后审签时间 = signInfo.签名明细[signInfo.签名明细.Count - 1].签名时间;
                }

                if (auditCount < 3)
                {
                    previewControl1.SetItemValue(SignElementNameDefine.三级审签, "");
                    previewControl1.setImage("[图片]" +SignElementNameDefine.三级审签, null, new Size(0,0));

                    previewControl1.SetItemReMark(SignElementNameDefine.三级审签, "");
                    previewControl1.SetItemReMark("[图片]" + SignElementNameDefine.三级审签, "");
                }

                if (auditCount < 2)
                {
                    previewControl1.SetItemValue(SignElementNameDefine.二级审签, "");
                    previewControl1.setImage("[图片]" + SignElementNameDefine.二级审签, null, new Size(0, 0));

                    previewControl1.SetItemReMark(SignElementNameDefine.二级审签, "");
                    previewControl1.SetItemReMark("[图片]" + SignElementNameDefine.二级审签, "");
                }

                if (auditCount < 1)
                {
                    previewControl1.SetItemValue(SignElementNameDefine.一级审签, "");
                    previewControl1.setImage("[图片]" + SignElementNameDefine.一级审签, null, new Size(0, 0));

                    previewControl1.SetItemReMark(SignElementNameDefine.一级审签, "");
                    previewControl1.SetItemReMark("[图片]" + SignElementNameDefine.一级审签, "");
                }

                if (signInfo.签名明细.Count <= 0)
                {
                    previewControl1.SetItemValue(SignElementNameDefine.记录签名, "");
                    previewControl1.setImage("[图片]" + SignElementNameDefine.记录签名, null, new Size(0, 0));
                    previewControl1.SetItemReMark(SignElementNameDefine.记录签名, "");
                    previewControl1.SetItemReMark("[图片]" + SignElementNameDefine.记录签名, "");

                    previewControl1.SetItemValue(SignElementNameDefine.诊断签名, "");
                    previewControl1.setImage("[图片]" + SignElementNameDefine.诊断签名, null, new Size(0, 0));
                    previewControl1.SetItemReMark(SignElementNameDefine.诊断签名, "");
                    previewControl1.SetItemReMark("[图片]" + SignElementNameDefine.诊断签名, "");

                    _reportData.报告信息.报告医生 = "";
                    _reportData.报告信息.报告时间 = default(DateTime);
                }

                _reportData.报告信息.报告内容 = previewControl1.ExportXmlf();

                _reportData.报告信息.CopyBasePro(_reportData);

                _reportModel.BackReportSign(_reportData);


                _IsOk = true;

                LoadSignInfo();
            }
            catch(Exception ex)
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
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbVerify_Click(object sender, EventArgs e)
        {
            try
            {
                //TOOD:报告签名验证
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbCompare_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO:报告内容对比
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}
