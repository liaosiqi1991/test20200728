using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Design;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using zlMedimgSystem.BusinessBase;
using zlMedimgSystem.DataModel;
using System.Net;
using zlMedimgSystem.CTL.Report;

namespace zlMedimgSystem.CTL.ReportView
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(ReportViewControl), "Resources.preview.ico")]
    public partial class ReportViewControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        static public class ReportProviderActionDefine
        { 
            public const string Action_PreviewReport = "预览报告";
            public const string Action_PrintReport = "打印报告";
            public const string Action_RefreshReport = "刷新报告";
            public const string Action_ViewReport = "查看报告";
        }

        static public class ReportEventDefine
        {
            public const string PrintBeforeEvent = "报告打印前事件";
            public const string PrintAfterEvent = "报告打印后事件";
             
        }


        private string _applyId = "";
        private ReportContextModel _rcm = null;
        private FormPart.PreviewControl _reportEdit = null;

        private ReportPars _reportPars = new ReportPars();

        public ReportViewControl()
        {
            InitializeComponent();
        }

        protected ReportContextModel ReportContextModel
        {
            get
            {
                if (_rcm == null) _rcm = new ReportContextModel(_dbQuery);
                return _rcm;
            }
        }

        protected override void InitBaseInfo()
        {
            _moduleName = "报告查看模块";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideActionDesc.Add(ReportProviderActionDefine.Action_PrintReport, "");
            _provideActionDesc.Add(ReportProviderActionDefine.Action_PreviewReport, "");
            _provideActionDesc.Add(ReportProviderActionDefine.Action_RefreshReport, "");
            _provideActionDesc.Add(ReportProviderActionDefine.Action_ViewReport, "");

            //_provideDataDesc.Add(Const_Data_CurReportStudyData, "");
            //_provideDataDesc.Add(Const_Data_CurReportEditData, "");

            //_designEvents.Add(ReportEventDefine.GetReportImgEvent, new EventActionReleation(ReportEventDefine.GetReportImgEvent, ActionType.atSysFixedEvent));

            //_designEvents.Add("报告保存后事件", new EventActionReleation("报告保存后事件", ActionType.atSysFixedEvent));
            //_designEvents.Add("报告签名后事件", new EventActionReleation("报告签名后事件", ActionType.atSysFixedEvent));
            //_designEvents.Add("报告审核后事件", new EventActionReleation("报告审核后事件", ActionType.atSysFixedEvent));
        }

        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {

                switch (actName)
                {
                    case ReportProviderActionDefine.Action_ViewReport:

                        ReclearApplyData(); 

                        if (bizDatas == null) return false; 
                         
                        string applyId = DataHelper.GetItemValueByApplyId(bizDatas[0]);

                        if (string.IsNullOrEmpty(applyId))
                        {
                            MessageBox.Show("未检索到对应的申请ID，请求数据项名称为 [" + bizDatas.DataName + "]。", "提示");
                            return false;
                        }

                        _applyId = applyId;

                        EnterView(_applyId);

                        break; 
 

                    case ReportProviderActionDefine.Action_PrintReport:
                        //打印报告
                        ActionOutputToPrint();
                        break;
 

                    case ReportProviderActionDefine.Action_PreviewReport:
                        //预览报告
                        ActionReportPreview();
                        break;
                         

                    default:
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        private void ActionReportPreview()
        {
            ReportContextData reportData = SelectReport();
            if (reportData == null) return;

            _reportEdit.preview();
        }

        private void ReportPrint(ReportContextData reportData)
        {
            _reportEdit.Print();

            JReportPrintItem printItem = new JReportPrintItem();

            printItem.打印人 = _userData.Name;
            printItem.打印时间 = ReportContextModel.GetServerDate();

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            printItem.打印站点 = host.HostName;
            if (host.AddressList.Length > 0)
            {
                printItem.打印IP地址 = host.AddressList[0].ToString();
            }

            reportData.打印信息.打印明细.Add(printItem);

            reportData.状态信息.是否已打印 = true;


            ReportContextModel.SaveReportPrint(reportData);
        }

        private void ActionOutputToPrint()
        {
            ReportContextData reportData = SelectReport();
            if (reportData == null) return;

            //检查报告签名
            if (CheckReportSign(reportData) == false) return;

            //检查报告是否被驳回
            if (CheckReportReject(reportData) == false) return;

            //TODO:打印限制判断，如普通患者是否终审

            //执行报告打印
            ReportPrint(reportData);
        }


        private ReportContextData SelectReport()
        {
            if (cbxReports.SelectedItem == null)
            {
                MessageBox.Show("请选择对应的报告项目。", "提示");
                return null;
            }

            ItemBind ibReport = cbxReports.SelectedItem as ItemBind;
            if (ibReport == null)
            {
                MessageBox.Show("无效的报告项目数据。", "提示");
                return null;
            }

            if (ibReport.Data == null)
            {
                MessageBox.Show("报告尚未生成，不能进行此操作。", "提示");
                return null;
            }

            ReportContextData reportData = ibReport.Data as ReportContextData;

            if (reportData == null)
            {
                MessageBox.Show("当前报告信息对象无效，不能进行此操作。", "提示");
                return null;
            }

            return reportData;
        }

        private bool CheckReportSign(ReportContextData reportData)
        {
            if (string.IsNullOrEmpty(reportData.报告信息.报告医生))
            {
                MessageBox.Show("未签名报告不允许进行此操作。", "提示");
                return false;
            }

            return true;
        }

        private bool CheckReportReject(ReportContextData reportData)
        {
            if (reportData.状态信息.是否驳回中)
            {
                MessageBox.Show("报告已被驳回不允许进行此操作。", "提示");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 初始化申请报告
        /// </summary>
        /// <param name="applyId"></param>
        private void InitApplyReport(string applyId)
        {
            cbxReports.Items.Clear();

            cbxReports.ComboBox.DisplayMember = "DisplayName";
            cbxReports.ComboBox.ValueMember = "Value";

            DataTable dtReports = ReportContextModel.GetApplyReport(applyId);

            ItemBind ib = null;

            if (dtReports == null || dtReports.Rows.Count <= 0)
            {
                return;
            }

            foreach (DataRow dr in dtReports.Rows)
            {
                ReportContextData reportData = new ReportContextData();
                reportData.BindRowData(dr);

                ib = new ItemBind(reportData.报告名称, reportData.报告ID);

                ib.DisplayName = "(" + (dtReports.Rows.IndexOf(dr) + 1) + "/" + dtReports.Rows.Count + ")" + reportData.报告名称;
                ib.Tag = reportData.部位名称;
                ib.Data = reportData;

                cbxReports.Items.Add(ib);
            }


            cbxReports.SelectedIndex = 0;
        }

        private void ReclearApplyData()
        {
 
            _applyId = ""; 

            _reportEdit.ReadOnly = true;
        }

        public void EnterView(string applyId)
        {
            InitApplyReport(applyId); 
        }


        /// <summary>
        /// 刷新
        /// </summary>
        public override void RefreshModule()
        {

        }

        private void cbxReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
                ItemBind ib = cbxReports.SelectedItem as ItemBind;

                ReportContextData reportData = null;

                if (ib.Data == null)
                {
                    return;
                }

                reportData = ib.Data as ReportContextData;

                LoadReport(reportData);
                 

                ResetReportState(reportData);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            } 
        }

        private void LoadReport(ReportContextData reportData)
        {
            tsLabCritical.Image = (reportData.报告信息.是否危急重) ? imageList1.Images[1] : imageList1.Images[0];
            tsLabCritical.ForeColor = (reportData.报告信息.是否危急重) ? Color.FromArgb(255, 150, 150) : Color.FromArgb(224, 224, 224);

            tsLabNP.Image = (reportData.报告信息.是否阳性) ? imageList1.Images[1] : imageList1.Images[0];
            tsLabNP.ForeColor = (reportData.报告信息.是否阳性) ? Color.Yellow : Color.FromArgb(224, 224, 224);

            _reportEdit.ImportByXml(reportData.报告信息.报告内容);
            _reportEdit.ReadOnly = true;

        }
 
        private void ResetReportState(ReportContextData reportData)
        { 
            DrawReportWater(reportData);

            DrawLabelInfo(reportData);
        }

        /// <summary>
        /// 绘制报告水印
        /// </summary>
        /// <param name="reportData"></param>
        public void DrawReportWater(ReportContextData reportData)
        {
            Font wfont = new Font("宋体", 30, FontStyle.Bold);

            _reportEdit.RemoveWaterMark();

            if (reportData == null) return;
            if (reportData.签名信息 == null) return;

            if (reportData.状态信息.是否驳回中)
            {
                _reportEdit.DrawWatermark("已驳回", wfont, Color.FromArgb(255, 230, 230));
                return;
            }

            string waterContext = "";
            int auditCount = ReportPublic.GetAuditingCount(reportData);

            if (auditCount > 0)
            {
                if (auditCount >= _reportPars.ReportAuditLevel)
                {
                    waterContext = "已终审";
                }
                else
                {
                    if (auditCount == 1)
                    {
                        waterContext = "已一审";
                    }
                    else if (auditCount == 2)
                    {
                        waterContext = "已二审";
                    }
                    else if (auditCount == 3)
                    {
                        waterContext = "已三审";
                    }
                }

            }
            else
            {
                if (reportData.签名信息.签名明细.Count == 1)
                {
                    waterContext = "已报告";
                }
                else if (reportData.签名信息.签名明细.Count > 1)
                {
                    waterContext = "已修订";
                }
            }

            if (string.IsNullOrEmpty(waterContext)) return;


            _reportEdit.DrawWatermark(waterContext, wfont, Color.FromArgb(255, 230, 230));
        }

        private void DrawLabelInfo(ReportContextData reportData)
        {
            string stateInfo = "";

            if (reportData == null)
            {
                stateInfo = "报告人:          ×查阅 ×打印 ×发放 ×PDF";//×完结 
            }
            else
            {

                stateInfo = "报告人:" + reportData.报告信息.报告医生 + "  ";

                if (reportData.状态信息.是否可查阅)
                {
                    stateInfo = stateInfo + "√查阅 ";
                }
                else
                {
                    stateInfo = stateInfo + "×查阅 ";
                }

                if (reportData.状态信息.是否已打印)
                {
                    stateInfo = stateInfo + "√打印 ";
                }
                else
                {
                    stateInfo = stateInfo + "×打印 ";
                }

                if (reportData.状态信息.是否已发放)
                {
                    stateInfo = stateInfo + "√发放 ";
                }
                else
                {
                    stateInfo = stateInfo + "×发放 ";
                }

                //if (reportData.状态信息.是否已完结)
                //{
                //    stateInfo = stateInfo + "√完结 ";
                //}
                //else
                //{
                //    stateInfo = stateInfo + "×完结 ";
                //}

                if (reportData.状态信息.是否转PDF)
                {
                    stateInfo = stateInfo + "√PDF ";
                }
                else
                {
                    stateInfo = stateInfo + "×PDF ";
                }


            }

            tsLabState.Text = stateInfo;
        }

        private void ReportViewControl_Load(object sender, EventArgs e)
        {
            try
            {
                _reportEdit = new FormPart.PreviewControl();
                panelReport.Controls.Add(_reportEdit);

                _reportEdit.Dock = DockStyle.Fill;
                
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbPreview_Click(object sender, EventArgs e)
        {
            try
            {
                ActionReportPreview();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ActionOutputToPrint();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}
