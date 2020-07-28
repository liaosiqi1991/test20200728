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
using zlMedimgSystem.DataModel; 
using zlMedimgSystem.Services; 
using zlMedimgSystem.BusinessBase;
using System.Net;
using System.IO;

namespace zlMedimgSystem.CTL.Report
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(ReportControl), "Resources.contract.ico")]
    public partial class ReportControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        static public class ReportDataDefine
        {
            public const string CurReportApplyData = "当前报告对应申请数据";
            public const string CurReportSaveContext = "当前保存的报告内容";
            public const string CurReportEditContext = "当前编辑的报告内容";
            public const string CurReportFormatData = "当前选择的报告模板";
        }
               

        static public class ReportActionDefine
        {
            public const string EnterEditor = "进入编辑";
            public const string RefreshReport = "刷新报告";

            public const string PreviewReport = "预览报告";
            public const string PrintReport = "打印报告";
            public const string PrintPDF = "打印PDF";

            public const string SaveReport = "保存报告";
            public const string AddReportImage = "加入报告图";
            public const string WriteText = "写入文本";
            public const string WriteWord = "写入词句";

            public const string ReportSign = "报告签名";
            public const string AllowView = "开放查阅";
            public const string AbortView = "终止查阅";
            public const string GiveOut = "报告发放";
            public const string GiveIn = "取消发放";
            public const string Finished = "完结报告";
            public const string CancelFinish = "撤销完结";
            public const string Reject = "驳回报告";
            public const string RejectManager = "驳回管理";
            public const string Unlock = "解除锁定";
            public const string SignManager = "签名管理";

            public const string NewReport = "新增报告";
            public const string DelReport = "删除报告";

            public const string ReviseReport = "报告修订";
            public const string SureRevise = "修订确认";
            public const string QuitRevise = "退出修订";


        }

        static public class ReportEventDefine
        {
            public const string EditorBefore = "进入编辑前事件";
            public const string EditorAfter = "进入编辑后事件";

            public const string PreviewBefore = "预览报告前事件";
            public const string PreviewAfter = "预览报告后事件";

            public const string PrintBefore = "打印报告前事件";
            public const string PrintAfter = "打印报告后事件";

            public const string PdfBefore = "转换PDF前事件";
            public const string PdfAfter = "转换PDF后事件";

            public const string SaveBefore ="保存报告前事件";
            public const string SaveAfter = "保存报告后事件";

            public const string ReportImgAddEvent = "加入报告图事件";
            public const string WriteTextEvent = "写入文本事件"; 
            public const string WriteWordEvent = "写入词句前事件"; 
             

            public const string SignBefore = "签名前事件";
            public const string SignAfter = "签名后事件";

            public const string AllowViewBefore = "开放查阅前事件";
            public const string AllowViewAfter = "开放查阅后事件";

            public const string AbortViewBefore = "终止查阅前事件";
            public const string AbortViewAfter = "终止查阅后事件";

            public const string GiveOutBefore = "发放报告前事件";
            public const string GiveOutAfter = "发放报告后事件";

            public const string GiveInBefore = "取消发放前事件";
            public const string GiveInAfter = "取消发放后事件";

            public const string FinishedBefore = "完结报告前事件";
            public const string FinishedAfter = "完结报告后事件";

            public const string EscFinishedBefore = "撤销完结前事件";
            public const string EscFinishedAfter = "撤销完结后事件";

            public const string RejectBefore = "驳回报告前事件";
            public const string RejectAfter = "驳回报告后事件";

            public const string UnlockBefore = "解除锁定前事件";
            public const string UnlockAfter = "解除锁定后事件";

            public const string NewBefore = "新增报告前事件";
            public const string NewAfter = "新增报告后事件";

            public const string DelBefore = "删除报告前事件";
            public const string DelAfter = "删除报告后事件";

            public const string ReviseBefore = "修订报告前事件";
            public const string ReviseAfter = "修订报告后事件";

            public const string SureReviseBefore = "确认修订前事件";
            public const string SureReviseAfter = "确认修订后事件";

            public const string QuitReviseBefore = "退出修订前事件";
            public const string QuitReviseAfter = "退出修订后事件";

        }

        //private IStudyBizData _studyData = null;

        private string _applyId = "";       //检查申请ID
        private string _examItemId = "";    //检查项目ID
        private string _templateId = "";    //报告模板ID
        private string _imageKind = "";     //影像类别

        private ApplyData _applyData = null;

        private DateTime _requestDate = default(DateTime);

        private ReportTemplateItemData _reportTemplateItem = null;
        private ReportTemplateFormatData _reportTemplateFormat = null;

        private ReportContextModel _rcm = null;

        private JApplyLockInfo _lockInfo = null;

        private ReportPars _reportPars = new ReportPars();
        private ReportModuleDesign _reportDesign = null;


        private ReportEditState _reportState = ReportEditState.resNoEditing;
        private bool _isReviseModel = false;
        private bool _isProcessing = false;

        private FormPart.PreviewControl _reportEdit = null;

        protected ReportContextModel ReportContextModel
        {
            get
            {
                if (_rcm == null) _rcm = new ReportContextModel(_dbQuery);
                return _rcm;
            }
        }

        public ReportControl()
        {
            InitializeComponent();

            ResetDefaultReportPars();

            _reportDesign = new ReportModuleDesign();

            _reportDesign.ButAbortViewVisible = true;
            _reportDesign.ButAddReportImgVisible = true;
            _reportDesign.ButAllowViewVisible = true;
            _reportDesign.ButDelVisible = true;
            _reportDesign.ButEscFinishedVisible = true;
            _reportDesign.ButFinishedVisible = true;
            _reportDesign.ButGiveInVisible = true;
            _reportDesign.ButGiveOutVisible = true;
            _reportDesign.ButMoreVisible = true;
            _reportDesign.ButNewVisible = true;
            _reportDesign.ButPDFConvertVisible = true;
            _reportDesign.ButPreviewVisible = true;
            _reportDesign.ButPrintVisible = true;
            _reportDesign.ButQuitReviseVisible = true;
            _reportDesign.ButRefreshVisible = true;
            _reportDesign.ButRejectManagerVisible = true;
            _reportDesign.ButRejectVisible = true;
            _reportDesign.ButReviseVisible = true;
            _reportDesign.ButSaveVisible = true;
            _reportDesign.ButSignManagerVisible = true;
            _reportDesign.ButSignVisible = true;
            _reportDesign.ButSureReviseVisible = true;
            _reportDesign.ButUnlockVisible = true;

            _reportDesign.Dock = ToolDockWay.tdwRight;

            _reportDesign.ToolsDesign.Visible = true;
            _reportDesign.ToolsDesign.BackColor = toolStrip1.BackColor;
            _reportDesign.ToolsDesign.ForceColor = toolStrip1.ForeColor;


        }

        public void ResetDefaultReportPars()
        {
            _reportPars.ReportAuditLevel = 2;

            _reportPars.EqualAdutingLevel = -1;
            _reportPars.DirectAuditingLevel = -1;
                        
            
            _reportPars.PrintAutoConvertPDF = true;
            _reportPars.UseESign = false;
            _reportPars.UltimateAutoFinish = true;
            _reportPars.UltimateAutoPrint = true;

            _reportPars.AutoPublicLevel = 1;

            _reportPars.NormalDiagnosePrintNeedUltimate = true;
            _reportPars.GreenDiagnoseAllowDirectPrint = true;
            _reportPars.CriticalDiagnoseAllowDirectPrint = true;
            _reportPars.NormalDiagnosePrintNeedUltimate = true;

            _reportPars.WriteSelf = false;
        }

        protected override void InitBaseInfo()
        {
            _moduleName = "报告模块";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideActionDesc.Add(ReportActionDefine.PrintReport, "打印当前选择报告");
            _provideActionDesc.Add(ReportActionDefine.PreviewReport, "预览当前选择报告");
            _provideActionDesc.Add(ReportActionDefine.SaveReport, "保存当前报告");
            _provideActionDesc.Add(ReportActionDefine.AddReportImage, "添加报告图像到当前报告");
            _provideActionDesc.Add(ReportActionDefine.WriteText, "写入文本内容到当前报告");
            _provideActionDesc.Add(ReportActionDefine.WriteWord, "写入词句内容到当前报告");
            _provideActionDesc.Add(ReportActionDefine.EnterEditor, "进入报告编辑状态，进入报告编辑时，需要请求对应的申请ID数据.");

            _provideActionDesc.Add(ReportActionDefine.RefreshReport, "刷新当前申请报告");
            _provideActionDesc.Add(ReportActionDefine.ReportSign, "对当前报告进行签名操作");
            _provideActionDesc.Add(ReportActionDefine.AllowView, "开放当前报告查阅");
            _provideActionDesc.Add(ReportActionDefine.AbortView, "终止当前报告查阅");
            _provideActionDesc.Add(ReportActionDefine.GiveOut, "发放当前报告");
            _provideActionDesc.Add(ReportActionDefine.GiveIn, "撤销当前发放");
            _provideActionDesc.Add(ReportActionDefine.Finished, "完结当前报告");
            _provideActionDesc.Add(ReportActionDefine.CancelFinish, "撤销当前报告的完结状态");
            _provideActionDesc.Add(ReportActionDefine.Reject, "驳回当前报告");
            _provideActionDesc.Add(ReportActionDefine.RejectManager, "报告驳回管理");
            _provideActionDesc.Add(ReportActionDefine.Unlock, "解除当前报告锁定");
            _provideActionDesc.Add(ReportActionDefine.SignManager, "报告签名管理");
            _provideActionDesc.Add(ReportActionDefine.NewReport, "新增报告");
            _provideActionDesc.Add(ReportActionDefine.DelReport, "删除报告");

            _provideActionDesc.Add(ReportActionDefine.ReviseReport, "修订已经签名的检查报告");
            _provideActionDesc.Add(ReportActionDefine.SureRevise, "确认修订的报告内容");
            _provideActionDesc.Add(ReportActionDefine.QuitRevise, "退出修订状态，退出后修订内容不能保存");


            _provideDataDesc.AddDataDescription(_moduleName, ReportDataDefine.CurReportApplyData, "当前报告对应的申请数据，返回数据项如下：" 
                                                                                        + System.Environment.NewLine 
                                                                                        + "applyid,applydate,imagekind,studyno,patientfrom,applydata");
            _provideDataDesc.AddDataDescription(_moduleName, ReportDataDefine.CurReportSaveContext, "当前保存后的报告书记，返回数据项如下："
                                                                                        + System.Environment.NewLine 
                                                                                        + "applyid,applydata,imagekind,templateid,templatedata,formatid,formatdata,reportid,reportdata");
            _provideDataDesc.AddDataDescription(_moduleName, ReportDataDefine.CurReportEditContext, "当前正在编辑的报告内容，返回数据项如下："
                                                                                        + System.Environment.NewLine 
                                                                                        + "applyid,applydata,imagekind,templateid,templatedata,formatid,formatdata,reportxml");
            _provideDataDesc.AddDataDescription(_moduleName, ReportDataDefine.CurReportFormatData, "当前选择的报告模板，返回数据项如下：" 
                                                                                        + System.Environment.NewLine 
                                                                                        + "applyid,applydata,imagekind,templateid,formatid,templatedata,formatdata");
                         

            _designEvents.Add(ReportEventDefine.EditorBefore, new EventActionReleation(ReportEventDefine.EditorBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.EditorAfter, new EventActionReleation(ReportEventDefine.EditorAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.PreviewBefore, new EventActionReleation(ReportEventDefine.PreviewBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.PreviewAfter, new EventActionReleation(ReportEventDefine.PreviewAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.PrintBefore, new EventActionReleation(ReportEventDefine.PrintBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.PrintAfter, new EventActionReleation(ReportEventDefine.PrintAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.PdfBefore, new EventActionReleation(ReportEventDefine.PdfBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.PdfAfter, new EventActionReleation(ReportEventDefine.PdfAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.SaveBefore, new EventActionReleation(ReportEventDefine.SaveBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.SaveAfter, new EventActionReleation(ReportEventDefine.SaveAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.ReportImgAddEvent, new EventActionReleation(ReportEventDefine.ReportImgAddEvent, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.WriteTextEvent, new EventActionReleation(ReportEventDefine.WriteTextEvent, ActionType.atSysFixedEvent)); 
            _designEvents.Add(ReportEventDefine.WriteWordEvent, new EventActionReleation(ReportEventDefine.WriteWordEvent, ActionType.atSysFixedEvent)); 
            _designEvents.Add(ReportEventDefine.SignBefore, new EventActionReleation(ReportEventDefine.SignBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.SignAfter, new EventActionReleation(ReportEventDefine.SignAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.AllowViewBefore, new EventActionReleation(ReportEventDefine.AllowViewBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.AllowViewAfter, new EventActionReleation(ReportEventDefine.AllowViewAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.AbortViewBefore, new EventActionReleation(ReportEventDefine.AbortViewBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.AbortViewAfter, new EventActionReleation(ReportEventDefine.AbortViewAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.GiveOutBefore, new EventActionReleation(ReportEventDefine.GiveOutBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.GiveOutAfter, new EventActionReleation(ReportEventDefine.GiveOutAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.GiveInBefore, new EventActionReleation(ReportEventDefine.GiveInBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.GiveInAfter, new EventActionReleation(ReportEventDefine.GiveInAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.FinishedBefore, new EventActionReleation(ReportEventDefine.FinishedBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.FinishedAfter, new EventActionReleation(ReportEventDefine.FinishedAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.EscFinishedBefore, new EventActionReleation(ReportEventDefine.EscFinishedBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.EscFinishedAfter, new EventActionReleation(ReportEventDefine.EscFinishedAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.RejectBefore, new EventActionReleation(ReportEventDefine.RejectBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.RejectAfter, new EventActionReleation(ReportEventDefine.RejectAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.UnlockBefore, new EventActionReleation(ReportEventDefine.UnlockBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.UnlockAfter, new EventActionReleation(ReportEventDefine.UnlockAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.NewBefore, new EventActionReleation(ReportEventDefine.NewBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.NewAfter, new EventActionReleation(ReportEventDefine.NewAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.DelBefore, new EventActionReleation(ReportEventDefine.DelBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.DelAfter, new EventActionReleation(ReportEventDefine.DelAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.ReviseBefore, new EventActionReleation(ReportEventDefine.ReviseBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.ReviseAfter, new EventActionReleation(ReportEventDefine.ReviseAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.SureReviseBefore, new EventActionReleation(ReportEventDefine.SureReviseBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.SureReviseAfter, new EventActionReleation(ReportEventDefine.SureReviseAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.QuitReviseBefore, new EventActionReleation(ReportEventDefine.QuitReviseBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(ReportEventDefine.QuitReviseAfter, new EventActionReleation(ReportEventDefine.QuitReviseAfter, ActionType.atSysFixedEvent)); 
        }


        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {

            void SetFocusText(string text)
            {
                string focusElementName = _reportEdit.GetFocusItemName();

                //需要先删除选中的文本...
                _reportEdit.DeleteSelectedText();

                _reportEdit.SetItemValue(focusElementName, text, 0);
            }

            void SetSectionText(string section, string text)
            {
                int sectionIndex = _reportTemplateItem.关联段落.段落关联信息.FindIndex(T => T.报告段落名 == section);

                if (sectionIndex < 0) return;

                string sectionElement = _reportTemplateItem.关联段落.段落关联信息[sectionIndex].模板元素名;

                string focusElementName = _reportEdit.GetFocusItemName();
                if (focusElementName == sectionElement)
                {
                    _reportEdit.DeleteSelectedText();
                }

                _reportEdit.SetItemValue(sectionElement, text, 0);//0光标处，1末尾，2替换
            }


            try
            {
                
                switch (actName)
                {
                    case ReportActionDefine.EnterEditor:

                        ReclearApplyData();

                        if (bizDatas == null) return false;
                         

                        string applyId = DataHelper.GetItemValueByApplyId(bizDatas[0]);
            

                        if (string.IsNullOrEmpty(applyId))
                        {
                            MessageBox.Show("获取请求数据失败，所请求的数据项不满足当前结构要求，请求数据项名称为 [" + bizDatas.DataName + "]。", "提示");
                            return false;
                        }

                        _applyId = applyId;


                        _applyData = ReportContextModel.GetReportApply(_applyId);

                        ActionEnterEdit(applyId);

                        break;

                    case ReportActionDefine.AddReportImage:
                        //添加报告图像
                        if (bizDatas == null) return false;
                                         
                        if (bizDatas.Key != _applyId)
                        {
                            MessageBox.Show("图像所属检查申请与当前检查申请不一致，不能添加。", "提示");
                            return false;
                        }
                  
                        foreach (BizDataItem bdi in bizDatas)
                        {
                            string file = DataHelper.GetItemValueByFile(bdi);
                            _reportEdit.addPictureItemImage("报告图", ImageEx.LoadFile(file) as Bitmap, new Size(300, 300), bdi["mediaid"].ToString());
                        }
                        
                        
                        break;

                    case ReportActionDefine.WriteText:
                        //写入自由文本
                        if (bizDatas == null) return false; 

                        string text = bizDatas[0]["text"].ToString();

                        SetFocusText(text);

                        DoActions(ReportEventDefine.WriteTextEvent, null);

                        break;

                    case ReportActionDefine.WriteWord:
                        //写入词句
                        if (bizDatas == null) return false;

                        bool isWrite = false;

                        if (bizDatas.Count == 1)
                        {
                            if (bizDatas[0]["sectionname"].ToString() == "共用词句")
                            {
                                SetFocusText(bizDatas[0]["text"].ToString());


                                DoActions(ReportEventDefine.WriteTextEvent, null);
                            }
                            else
                            {
                                SetSectionText(bizDatas[0]["sectionname"].ToString(), bizDatas[0]["text"].ToString());

                                isWrite = true;

                            }
                            
                        }
                        else
                        {
                            foreach(BizDataItem bi in bizDatas)
                            {
                                if (bi["sectionname"].ToString() == "共用词句") continue;

                                SetSectionText(bi["sectionname"].ToString(), bi["text"].ToString());
                                isWrite = true;
                            }
                        }

                        if (isWrite)
                        {
                            DoActions(ReportEventDefine.WriteWordEvent, null);
                        }

                        break;

                    case ReportActionDefine.PrintReport:
                        //打印报告
                        ActionOutputToPrint(null);
                        break;

                    case ReportActionDefine.PrintPDF:
                        //打印PDF
                        ActionOutputToPdf(null);
                        break;

                    case ReportActionDefine.PreviewReport:
                        //预览报告
                        ActionReportPreview(null);
                        break;

                    case ReportActionDefine.SaveReport:
                        //保存报告
                        ActionReportSave(null);
                        break;


                    case ReportActionDefine.RefreshReport:
                        //刷新报告
                        if (string.IsNullOrEmpty(_applyId))
                        {
                            _applyData = null;

                            cbxReports.Items.Clear();
                            cbxReportTemplateFormats.Items.Clear();

                            _reportEdit.ImportByXml("");
                        }
                        else
                        {
                            _applyData = ReportContextModel.GetReportApply(_applyId);

                            ActionEnterEdit(_applyId);
                        }

                        break;

                    case ReportActionDefine.ReportSign:
                        //报告签名
                        ActionReportSign(null);

                        break;

                    case ReportActionDefine.AllowView:
                        //开放查阅
                        ActionAllowViewer(null);

                        break; ;

                    case ReportActionDefine.AbortView:
                        //终止查阅
                        ActionAbortView(null);

                        break;

                    case ReportActionDefine.GiveOut:
                        //报告发放
                        ActionGiveout(null);

                        break;

                    case ReportActionDefine.GiveIn:
                        //取消发放
                        ActionGiveIn(null);

                        break;

                    case ReportActionDefine.Finished:
                        //完结报告
                        ActionFinished(null);

                        break;

                    case ReportActionDefine.CancelFinish:
                        //撤销完结
                        ActionCancelFinished(null);

                        break;

                    case ReportActionDefine.Reject:
                        //报告驳回
                        ActionReject(null);

                        break;

                    case ReportActionDefine.RejectManager:
                        //驳回管理
                        ActionRejectManager();

                        break;

                    case ReportActionDefine.Unlock:
                        //解除锁定
                        ActionUnLock(null);

                        break;

                    case ReportActionDefine.SignManager:
                        //签名管理
                        ActionSignManager();

                        break;

                    case ReportActionDefine.NewReport:
                        //新增报告
                        ActionNewReport(null);

                        break;

                    case ReportActionDefine.DelReport:
                        //删除报告
                        ActionDelReport(null);

                        break;

                    case ReportActionDefine.ReviseReport:
                        //报告修订
                        ActionReviseReport(null);

                        break;

                    case ReportActionDefine.SureRevise:
                        //确认修订
                        ActionSureRevise(null);

                        break;

                    case ReportActionDefine.QuitRevise:
                        //退出修订
                        ActionQuitRevise(null);

                        break;

                    default:
                        break;
                }

                return true;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case ReportDataDefine.CurReportFormatData:
                    return true;

                case ReportDataDefine.CurReportApplyData:
                    return true;

                case ReportDataDefine.CurReportSaveContext:
                    return true;

                case ReportDataDefine.CurReportEditContext:
                    return true;

                default:
                    return false;
            }
        }


        public override IBizDataItems QueryDatas(string dataIdentificationName)
        {
            BizDataItems resultDatas = null;
            BizDataItem dataItem = null;

            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case ReportDataDefine.CurReportFormatData://当前报告格式
                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();

                    dataItem.Add(DataHelper.StdPar_ApplyId, _applyId);
                    dataItem.Add(DataHelper.StdPar_ApplyData, _applyData);

                    dataItem.Add(DataHelper.StdPar_ImageKind, _imageKind);

                    dataItem.Add(DataHelper.StdPar_TemplateId, _reportTemplateItem.模板ID);
                    dataItem.Add(DataHelper.StdPar_TemplateData, _reportTemplateItem);

                    if (_reportTemplateFormat != null)
                    {
                        dataItem.Add(DataHelper.StdPar_FormatId, _reportTemplateFormat.格式ID);
                        dataItem.Add(DataHelper.StdPar_FormatData, _reportTemplateFormat);
                    }
                    else
                    {
                        dataItem.Add(DataHelper.StdPar_FormatId, "");
                        dataItem.Add(DataHelper.StdPar_FormatData, "");
                    }
                    
                    resultDatas.Add(dataItem);

                    return resultDatas;

                case ReportDataDefine.CurReportApplyData://当前报告对应的申请数据
                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();

                    dataItem.Add(DataHelper.StdPar_ApplyId, _applyId);
                    dataItem.Add(DataHelper.StdPar_ApplyDate, _applyData.申请日期);
                    dataItem.Add(DataHelper.StdPar_ImageKind, _applyData.影像类别);
                    dataItem.Add(DataHelper.StdPar_StudyNo, _applyData.检查号);
                    dataItem.Add(DataHelper.StdPar_PatiFrom, _applyData.申请信息.来源);

                    dataItem.Add(DataHelper.StdPar_ApplyData, _applyData);

                    return resultDatas;

                case ReportDataDefine.CurReportSaveContext://当前报告内容数据
                    if (cbxReports.Items.Count <= 0) return null;
                    ItemBind ib = cbxReports.SelectedItem as ItemBind;

                    if (ib == null) return null;
                    ReportContextData reportData = ib.Data as ReportContextData;

                    if (reportData == null) return null;

                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();

                    dataItem.Add(DataHelper.StdPar_ApplyId, _applyId);
                    dataItem.Add(DataHelper.StdPar_ApplyData, _applyData);

                    dataItem.Add(DataHelper.StdPar_ImageKind, _imageKind);

                    dataItem.Add(DataHelper.StdPar_TemplateId, _reportTemplateItem.模板ID);
                    dataItem.Add(DataHelper.StdPar_TemplateData, _reportTemplateItem);

                    if (_reportTemplateFormat != null)
                    {
                        dataItem.Add(DataHelper.StdPar_FormatId, _reportTemplateFormat.格式ID);
                        dataItem.Add(DataHelper.StdPar_FormatData, _reportTemplateFormat);
                    }
                    else
                    {
                        dataItem.Add(DataHelper.StdPar_FormatId, "");
                        dataItem.Add(DataHelper.StdPar_FormatData, "");
                    }

                    dataItem.Add(DataHelper.StdPar_ReportId, reportData.报告ID);
                    dataItem.Add(DataHelper.StdPar_ReportData, reportData);
                    
                    return resultDatas;

                case ReportDataDefine.CurReportEditContext:
                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();

                    dataItem.Add(DataHelper.StdPar_ApplyId, _applyId);
                    dataItem.Add(DataHelper.StdPar_ApplyData, _applyData);

                    dataItem.Add(DataHelper.StdPar_ImageKind, _imageKind);

                    dataItem.Add(DataHelper.StdPar_TemplateId, _reportTemplateItem.模板ID);
                    dataItem.Add(DataHelper.StdPar_TemplateData, _reportTemplateItem);

                    if (_reportTemplateFormat != null)
                    {
                        dataItem.Add(DataHelper.StdPar_FormatId, _reportTemplateFormat.格式ID);
                        dataItem.Add(DataHelper.StdPar_FormatData, _reportTemplateFormat);
                    }
                    else
                    {
                        dataItem.Add(DataHelper.StdPar_FormatId, "");
                        dataItem.Add(DataHelper.StdPar_FormatData, "");
                    }
                    

                    dataItem.Add(DataHelper.StdPar_ReportXML, _reportEdit.ExportXmlf());

                    return resultDatas;

                default:
                    return null;
            }
        }

        public override void ModuleLoaded()
        {
            ParameterModel pm = new ParameterModel(_dbQuery);

            ParameterData parData = pm.ReadParameter("报告控制", _stationInfo.DepartmentId);
            
            if (parData != null && string.IsNullOrEmpty(parData.参数取值) == false)
            {
                _reportPars = JsonHelper.DeserializeObject<ReportPars>(parData.参数取值);
            }

            base.ModuleLoaded();
        }

        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _reportDesign = JsonHelper.DeserializeObject<ReportModuleDesign>(customContext);

            LoadDesign();
        }

        private void LoadDesign()
        {
            if (_reportDesign.ToolsDesign.Visible == false)
            {
                toolStrip1.Visible = false;
                return;
            }

            toolStrip1.Visible = true;

            switch (_reportDesign.Dock)
            {
                case ToolDockWay.tdwTop:
                    toolStrip1.Dock = DockStyle.Top;
                    toolStrip1.Height = _reportDesign.ToolsDesign.Size;
                    break;

                case ToolDockWay.tdwLeft:
                    toolStrip1.Dock = DockStyle.Left;
                    toolStrip1.Width = _reportDesign.ToolsDesign.Size;
                    break;

                case ToolDockWay.tdwRight:
                    toolStrip1.Dock = DockStyle.Right;
                    toolStrip1.Width = _reportDesign.ToolsDesign.Size;
                    break;

                default:
                    toolStrip1.Dock = DockStyle.Bottom;
                    toolStrip1.Height = _reportDesign.ToolsDesign.Size;
                    break;
            }

            toolStrip1.BackColor = _reportDesign.ToolsDesign.BackColor;
            toolStrip1.ForeColor = _reportDesign.ToolsDesign.ForceColor;


            tsbSave.Visible = _reportDesign.ButSaveVisible;
            tsbPrevew.Visible = _reportDesign.ButPreviewVisible;
            tsbPrint.Visible = _reportDesign.ButPrintVisible;

            tsbReviseSign.Visible = _reportDesign.ButSureReviseVisible;
            tsbReviseCancel.Visible = _reportDesign.ButQuitReviseVisible;
            tsbRevise.Visible = _reportDesign.ButReviseVisible;

            tsbSign.Visible = _reportDesign.ButSignVisible;
            tsbReportImage.Visible = _reportDesign.ButAddReportImgVisible;

            tsbPublicReportView.Visible = _reportDesign.ButAllowViewVisible;
            tsbGiveOutReport.Visible = _reportDesign.ButGiveOutVisible;
            tsbFinish.Visible = _reportDesign.ButFinishedVisible;

            tsbRefresh.Visible = _reportDesign.ButRefreshVisible;

            tsbMove.Visible = _reportDesign.ButMoreVisible;

            tsbReject.Visible = _reportDesign.ButRejectVisible;
            tsbRejectManager.Visible = _reportDesign.ButRejectManagerVisible;

            tsbUnLock.Visible = _reportDesign.ButUnlockVisible;
            tsbConvertPDF.Visible = _reportDesign.ButPDFConvertVisible;

            tsbCancelView.Visible = _reportDesign.ButAbortViewVisible;
            tsbCancelGiveOut.Visible = _reportDesign.ButGiveInVisible;
            tsbCancelFinish.Visible = _reportDesign.ButEscFinishedVisible;

            tsbSignManager.Visible = _reportDesign.ButSignManagerVisible;
            tsbDelReport.Visible = _reportDesign.ButDelVisible;
            butNewReport.Visible = _reportDesign.ButNewVisible;


            if (_reportDesign.ToolsDesign.ToolsCfg != null)
            {
                InitUserTool(_reportDesign.ToolsDesign);
            }


            ToolsHelper.SyncDesignEventsByButtons(_reportDesign.ToolsDesign, _designEvents);
        }
               
        private void InitUserTool(ToolsDesign toolDesign)
        {
            try
            {
                for (int i = toolStrip1.Items.Count - 1; i >= 0; i--)
                {
                    //先移除用户控件
                    if (toolStrip1.Items[i].Tag == null) continue;
                    toolStrip1.Items.RemoveAt(i);
                }

                if (toolDesign.ToolsCfg.Count <= 0)
                {
                    if (toolStrip1.Items.Count <= 0) toolStrip1.Visible = false;

                    return;
                }

                ToolsHelper.ConfigButtons(toolStrip1, toolDesign, DoUserToolEvent_StripItem);

                if (this.DesignMode == false)
                {
                    toolStrip1.Visible = (toolStrip1.Items.Count <= 0) ? false : true;
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        public override string ShowCustomDesign()
        {
            using (frmReportDesign design = new frmReportDesign())
            {
                design.ShowReportDesign(_reportPars, _reportDesign, _stationInfo, _dbQuery, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_reportDesign);

            LoadDesign();

            return _customDesignFmt;
        }

        private void DoUserToolEvent_StripItem(object sender, EventArgs e)
        {
            ToolStripItem tsi = (sender as ToolStripItem);
            if (tsi == null) return;
             
            DoActions(tsi.Text, sender);
        }

        /// <summary>
        /// 初始化报告模板信息
        /// </summary>
        /// <param name="applyId"></param>
        private void InitReportTemplateItems(string applyId)
        {
            cbxReportTemplateFormats.Items.Clear();


            _examItemId = ReportContextModel.GetExamIdByApply(applyId);
            if (string.IsNullOrEmpty(_examItemId))
            {
                MessageBox.Show("检查申请对应的项目ID为空，不能载入对应模板格式。", "提示");
                return;
            }

            _templateId = ReportContextModel.GetTemplateIdByExamItem(_examItemId);
            if (string.IsNullOrEmpty(_templateId))
            {
                MessageBox.Show("当前项目对应的模板ID为空，不能载入对应模板格式。", "提示");
                return;
            }


            DataTable dtTemplateFormats = ReportContextModel.GetReportTemplateFormats(_templateId);

            cbxReportTemplateFormats.DisplayMember = "Name";
            cbxReportTemplateFormats.ValueMember = "Value";

            foreach (DataRow dr in dtTemplateFormats.Rows)
            {
                ItemBind ib = new ItemBind(dr["名称"].ToString(), dr["ID"].ToString());
                ib.Tag = Convert.ToInt32(dr["类别"].ToString());
                ib.Data = null;

                cbxReportTemplateFormats.Items.Add(ib);


            }

           // cbxReportTemplateFormats.DataSource = dtTemplateFormats;

        }

        /// <summary>
        /// 初始化申请报告
        /// </summary>
        /// <param name="applyId"></param>
        private void InitApplyReport(string applyId)
        {
            cbxReports.Items.Clear();

            cbxReports.DisplayMember = "DisplayName";
            cbxReports.ValueMember = "Value";

            DataTable dtReports = ReportContextModel.GetApplyReport(applyId);

            ItemBind ib = null;

            if (dtReports == null || dtReports.Rows.Count <= 0)
            {
                ib = new ItemBind("主报告(新)", "");

                ib.DisplayName = "(1/1)主报告(新)";
                ib.Tag = null;
                ib.Data = null;

                cbxReports.Items.Add(ib);

                cbxReportTemplateFormats.SelectedIndex = 0;
            }
            else
            {

                foreach(DataRow dr in dtReports.Rows)
                {
                    ReportContextData reportData = new ReportContextData();
                    reportData.BindRowData(dr);

                    ib = new ItemBind(reportData.报告名称, reportData.报告ID);

                    ib.DisplayName = "(" + (dtReports.Rows.IndexOf(dr) + 1) + "/" + dtReports.Rows.Count + ")" + reportData.报告名称;
                    ib.Tag = reportData.部位名称;
                    ib.Data = reportData;

                    cbxReports.Items.Add(ib);
                }
            }

            cbxReports.SelectedIndex = 0;
        }

        private void ReclearApplyData()
        {
            _lockInfo = null;
            _reportTemplateItem = null;
            _reportTemplateFormat = null;

            _applyId = "";
            _examItemId = "";
            _templateId = "";
            _imageKind = "";

            _reportState = ReportEditState.resNoEditing;

            _reportEdit.Enabled = false;
        }

        private void ReclearReportData()
        {
            _reportState = ReportEditState.resNoEditing;

            _reportEdit.Enabled = false;

            ChangeReviseButState(false);
        }

        public void ActionEnterEdit(string applyId)
        {

            DoActions(ReportEventDefine.EditorBefore, this);

            InitReportTemplateItems(applyId);

            InitApplyReport(applyId);

            DoActions(ReportEventDefine.EditorAfter, this);

        }

 
        /// <summary>
        /// 刷新
        /// </summary>
        public override void RefreshModule()
        {

        }

        private void cbxReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isProcessing = true;
            try
            {
                ReclearReportData();

                ItemBind ib = cbxReports.SelectedItem as ItemBind;

                ReportContextData reportData = null;

                if (ib.Data == null)
                {
                    LoadReport(null);
                }
                else
                {
                    reportData = ib.Data as ReportContextData;

                    LoadReport(reportData);
                }

                string reason = "";
                _reportState = GetReportState(reportData, ref reason);

               
                ResetReportState(reportData, _reportState, reason);

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            finally
            {
                _isProcessing = false;
            }
        }

        private void LoadReport(ReportContextData reportData)
        {
            if (reportData == null)
            {
                cbxReportTemplateFormats.Enabled = true;
                cbxReportTemplateFormats.SelectedIndex = 0;

                chkCritical.Checked = false;
                chkNP.Checked = false;

                //TODO:根据条件自动匹配格式...
            }
            else
            {
                //设置模板格式
                int index = FindCbxIndexByValue(cbxReportTemplateFormats.Items, reportData.报告信息.格式ID);
                if (index < 0) index = FindCbxIndexByValue(cbxReportTemplateFormats.Items, reportData.报告信息.模板ID);

                cbxReportTemplateFormats.SelectedIndex = index;
                cbxReportTemplateFormats.Enabled = false;

                chkCritical.Checked = reportData.报告信息.是否危急重;
                chkNP.Checked = reportData.报告信息.是否阳性;

                _reportEdit.ImportByXml(reportData.报告信息.报告内容);

                
            }
        }

        private void ResetReportState(ReportContextData reportData, ReportEditState reportState, string reason)
        {
            foreach (ToolStripItem tsi in toolStrip1.Items)
            {
                tsi.Enabled = true;

                if (tsi is ToolStripDropDownButton)
                {
                    foreach (ToolStripItem tsiSub in ((ToolStripDropDownButton)tsi).DropDownItems)
                    {
                        tsiSub.Enabled = true;
                    }
                }
            }

            tsbReviseSign.Enabled = false;
            tsbReviseCancel.Enabled = false;

            if (reportState == ReportEditState.resFinished)
            {
                foreach(ToolStripItem tsi in toolStrip1.Items)
                {
                    if (tsi.Name == "tsbPrint"
                        || tsi.Name == "tsbPreview" 
                        || tsi.Name == "tsbCancelFinish")
                    {
                        continue;
                    }
                    else if (tsi.Name == "tsbMove")
                    {
                        foreach(ToolStripItem tsiSub in ((ToolStripDropDownButton)tsi).DropDownItems)
                        {
                            if (tsiSub.Name == "tsbCancelFinish" 
                                || tsiSub.Name == "tsbSignManager")
                            {
                                continue;
                            }
                            else
                            {
                                tsiSub.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        tsi.Enabled = false;
                    }
                }
            }
            else if (reportState == ReportEditState.resDiagnosing)
            {
                //为空的报告不允许进行修订
                tsbRevise.Enabled = false;

                tsbSave.Enabled = true;
                tsbSign.Enabled = true;
                _reportEdit.ReadOnly = false;
            }
            else if (reportState == ReportEditState.resNoEditing)
            {
                //不允许编辑
                tsbRevise.Enabled = false;

                tsbSave.Enabled = false;
                tsbSign.Enabled = false;
                _reportEdit.ReadOnly = true;
            }
            else
            {
                tsbSave.Enabled = false;
                tsbRevise.Enabled = true;
                _reportEdit.ReadOnly = true;
            }

            if (string.IsNullOrEmpty(reason))
            {
                labReason.Text = "";
                labReason.Visible = false;
            }
            else
            {
                labReason.Text = reason;
                labReason.Visible = true;
            }

            DrawReportWater(reportData);

            DrawLabelInfo(reportData);
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

            labStateInfo.Text = stateInfo;
        }

        private int FindCbxIndexByValue(System.Collections.IList cbx, string value)
        {
            foreach(ItemBind ib in cbx)
            {
                if (ib.Value == value )
                {
                    return cbx.IndexOf(ib);
                }
            }

            return -1;
        }


        private void cbxReportTemplateFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxReportTemplateFormats.SelectedItem == null) return;

                ItemBind ib = cbxReportTemplateFormats.SelectedItem as ItemBind;
                if (ib == null) return;

                if (_reportTemplateItem == null)
                {
                    _reportTemplateItem = ReportContextModel.GetReportTemplateData(_templateId);

                    _imageKind = ReportContextModel.GetReportTemplateImageKind(_reportTemplateItem.模板分类ID);
                }

                _reportTemplateFormat = null;

                if (ib.Data == null)
                {
                    if (Convert.ToInt32(ib.Tag) == 0)
                    {
                        //为0表示模板
                        ib.Data = _reportTemplateItem; 
                    }
                    else
                    {
                        //为1表示格式
                        _reportTemplateFormat = ReportContextModel.GetReportFormatData(ib.Value);
                        ib.Data = _reportTemplateFormat; 
                    }
                }
                else
                {
                    if (Convert.ToInt32(ib.Tag) != 0)
                    {
                        _reportTemplateFormat = ib.Data as ReportTemplateFormatData;
                    }
                }


                string reportXml = "";
                JReportTemplateDataInfo reportDataSource = _reportTemplateItem.数据来源;

                if (Convert.ToInt32(ib.Tag) == 0)
                {
                    reportXml = (ib.Data as ReportTemplateItemData).模板信息.模板内容;
                }
                else
                {
                    reportXml = (ib.Data as ReportTemplateFormatData).格式信息.格式内容;
                }

                _reportEdit.ImportByXml(reportXml);

                _reportEdit.DataSet = SqlHelper.GetReportDataSource(_reportTemplateItem.数据来源.查询信息, _dbQuery, QueryParValueEvent);



            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        public object QueryParValueEvent(string parName)
        {
            //"申请识别码,患者识别码,申请ID,患者ID,用户ID,设备ID,科室ID,院区编码";
            switch (parName)
            {
                case "申请识别码":
                    return "";

                case "患者识别码":
                    return "";

                case "申请ID":
                    return _applyId;

                case "患者ID":
                    return "";

                case "用户ID":
                    return _userData.UserId;

                case "设备ID":
                    return _stationInfo.DeviceId;

                case "科室ID":
                    return _stationInfo.DepartmentId;

                case "院区编码":
                    return _stationInfo.DistrictCode;

                default:
                    return null;
            }
        }

        /// <summary>
        /// 新增报告
        /// </summary>
        private void ActionNewReport(object sender)
        {
            string reason = "";
            ReportEditState reportEditState = GetReportState(null, ref reason);
            if (reportEditState == ReportEditState.resNoEditing)
            {
                MessageBox.Show("当前报告不允许新增。" + System.Environment.NewLine + reason, "提示");
                return;
            }

            //判断该检查是否存在已签名报告
            foreach (ItemBind ib in cbxReports.Items)
            {
                if (ib.Data != null)
                {
                    ReportContextData reportData = ib.Data as ReportContextData;

                    if (reportData.报告信息 != null)
                    {
                        if (_userData.Name != reportData.报告信息.报告医生)
                        {
                            DialogResult diagResult = MessageBox.Show("此检查报告已由 [" + reportData.报告信息.报告医生 + "] 处理，是否需要继续创建？", "提示", MessageBoxButtons.YesNo);
                            if (diagResult == DialogResult.No) return;

                            break;
                        }
                    }
                }
            }

            DoActions(ReportEventDefine.NewBefore, sender);

            using (frmNewReport newReport = new frmNewReport())
            {
                newReport.OnReportNameExists += OnReportNameExists;

                newReport.ShowReportNew(this);

                if (newReport.IsOk)
                {
                    ItemBind ib = new ItemBind(newReport.ReportName + "(新)", "");

                    ib.Tag = newReport.Bodypart;
                    ib.Data = null;

                    cbxReports.Items.Add(ib);

                    UpdateReportList();

                    cbxReports.SelectedIndex = cbxReports.Items.IndexOf(ib);
                }
            }

            DoActions(ReportEventDefine.NewAfter, sender);
        }

        private void butNewReport_Click(object sender, EventArgs e)
        {
            try
            {
                ActionNewReport(sender);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void UpdateReportList()
        {
            //(x/x)增项报告(新)

            for(int i = cbxReports.Items.Count - 1; i >=0 ; i --)
            {
                ItemBind ib = cbxReports.Items[i] as ItemBind;
                
                ib.DisplayName = "(" + (i + 1) + "/" + cbxReports.Items.Count + ")" + ib.Name;

                cbxReports.Items.RemoveAt(i);
                cbxReports.Items.Insert(i, ib);
            }

         
        }

        private string FormatReportItemName(string itemName)
        {
            string name = itemName;

            name = name.Replace("(新)", "");
            name = name.Substring(name.IndexOf(')')+1);

            return name;
        }

        private void OnReportNameExists(string reportName, ref bool hasReport)
        {
            hasReport = false;

            foreach(ItemBind ib in cbxReports.Items)
            {
                string name = FormatReportItemName(ib.Name);                 

                if (name == reportName)
                {
                    hasReport = true;
                    return;
                }
            }
        }

        private void ActionReportSave(object sender)
        {
            _isProcessing = true;
            try
            {
                if (cbxReports.SelectedItem == null)
                {
                    MessageBox.Show("请选择需要进行保存的报告。", "提示");
                    return;
                }

                ItemBind ibReport = cbxReports.SelectedItem as ItemBind;
                if (ibReport == null)
                {
                    MessageBox.Show("无效的报告项目数据。", "提示");
                    return;
                }

                ReportContextData reportData = null;
                if (ibReport.Data != null) reportData = ibReport.Data as ReportContextData;

                if (reportData != null)
                {
                    //检查用户级别
                    if (CheckUserLevel(reportData) == false) return;
                }

                if (VerifyReportLockState(reportData) == false) return;


                DoActions(ReportEventDefine.SaveBefore, sender);

                SaveCurReport(ibReport);

                //数据同步存储到影像报告段落表中
                ReportContextSync(reportData, _reportTemplateItem);


                DoActions(ReportEventDefine.SaveAfter, sender);
            }
            finally
            {
                _isProcessing = false;
            }
        }


        private void ReportContextSync(ReportContextData reportData, ReportTemplateItemData reportTemplateItem)
        {

            Dictionary<string, string> sectionContext = new Dictionary<string, string>();
      
            foreach(JReportSectionItem sectionItem in reportTemplateItem.关联段落.段落关联信息)
            {
                if (sectionItem.关联存储)
                {                    
                    object itemValue = _reportEdit.GetItemValue(sectionItem.模板元素名);

                    if (itemValue == null) continue;

                    sectionContext.Add(sectionItem.报告段落名, itemValue.ToString());
                }
            }

            ReportContextModel.UpdateSectionContext(reportData.报告ID, _applyId, sectionContext);
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {   
            try
            {
                ActionReportSave(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            } 
        }



        private ReportContextData SaveCurReport(ItemBind ib)
        {
            ReportContextData reportData = null;

            if (string.IsNullOrEmpty(ib.Value))
            {
                //新增报告
                reportData = new ReportContextData();

                reportData.报告ID = SqlHelper.GetNumGuid();
                reportData.报告名称 = ib.Name.Replace("(新)", "");
                reportData.部位名称 = (ib.Tag == null) ? "" : ib.Tag.ToString();
                reportData.申请ID = _applyId;

                //保存报告时，不需要保存报告人
                //只有首次签名时，才需要保存对应的报告人
                reportData.报告信息.创建人 = _userData.AssistUserInfo1.Name;
                reportData.报告信息.创建时间 = ReportContextModel.GetServerDate();
                reportData.报告信息.是否阳性 = chkNP.Checked;
                reportData.报告信息.是否危急重 = chkCritical.Checked;
                reportData.报告信息.报告内容 = _reportEdit.ExportXmlf();
                reportData.状态信息.签名状态 = 0;
                reportData.报告信息.模板ID = _templateId;

                if (_reportTemplateFormat != null)
                {
                    reportData.报告信息.格式ID = _reportTemplateFormat.格式ID;
                }

                reportData.状态信息.最后更新时间 = ReportContextModel.GetServerDate();
                reportData.报告信息.CopyBasePro(reportData);

                ReportContextModel.NewReport(reportData);

                ib.Value = reportData.报告ID;
                ib.Data = reportData;

                ib.Name = reportData.报告名称;
                ib.DisplayName = ib.DisplayName.Replace("(新)", "");

                //更新项目显示
                int index = cbxReports.SelectedIndex;

                cbxReports.Items.Remove(ib);
                cbxReports.Items.Insert(index, ib);

                cbxReports.SelectedIndex = index;
            }
            else
            {
                //保存报告
                reportData = ib.Data as ReportContextData;

                reportData.报告信息.是否阳性 = chkNP.Checked;
                reportData.报告信息.是否危急重 = chkCritical.Checked;
                reportData.报告信息.报告内容 = _reportEdit.ExportXmlf();

                reportData.状态信息.最后更新时间 = ReportContextModel.GetServerDate(); 

                reportData.报告信息.CopyBasePro(reportData);

                ReportContextModel.SaveReportContext(reportData);

            }

            cbxReportTemplateFormats.Enabled = false;

            return reportData;
        }

        private void ActionReportPreview(object sender)
        {
            ReportContextData reportData = SelectReport();
            if (reportData == null) return;

            DoActions(ReportEventDefine.PreviewBefore, sender);

            _reportEdit.preview();

            DoActions(ReportEventDefine.PreviewAfter, sender);
        }
        private void tsbPrevew_Click(object sender, EventArgs e)
        {
            try
            {
                ActionReportPreview(sender);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
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


        private bool CheckPrintLimit(ReportContextData reportData)
        {
            //打印限制判断，如普通患者是否终审
            bool allowDirectPrint = false;
            if (_applyData != null)
            {
                if (_applyData.申请信息.是否危重 || _applyData.申请信息.是否急诊 || _applyData.申请信息.是否绿色通道)
                {
                    if (_applyData.申请信息.是否绿色通道 && _reportPars.GreenDiagnoseAllowDirectPrint)
                    {
                        allowDirectPrint = true;
                    }
                    else if ((_applyData.申请信息.是否危重 || _applyData.申请信息.是否急诊) && _reportPars.CriticalDiagnoseAllowDirectPrint)
                    {
                        allowDirectPrint = true;
                    }
                    else
                    {
                        if (_reportPars.NormalDiagnosePrintNeedUltimate)
                        {
                            //判断是否终审
                            allowDirectPrint = CheckIsUltimateAudit(reportData);
                        }
                        else
                        {
                            allowDirectPrint = true;
                        }

                    }
                }
                else
                {
                    //普通患者判断是否终审核后打印
                    if (_reportPars.NormalDiagnosePrintNeedUltimate)
                    {
                        allowDirectPrint = CheckIsUltimateAudit(reportData);
                    }
                    else
                    {
                        allowDirectPrint = true;
                    }
                }
            }

            if (allowDirectPrint == false)
            {
                MessageBox.Show("未终审报告不允许打印。", "提示");
                return false;
            }

            return true;
        }

        private bool ActionOutputToPrint(object sender)
        {
            ReportContextData reportData = SelectReport();
            if (reportData == null) return false;

            //检查报告签名
            if (CheckReportSign(reportData) == false) return false;

            //检查报告是否被驳回
            if (CheckReportReject(reportData) == false) return false;

            //打印限制判断 
            if (CheckPrintLimit(reportData) == false) return false;

            DoActions(ReportEventDefine.PrintBefore, sender);

            //执行报告打印
            ReportPrint(reportData);

            DoActions(ReportEventDefine.PrintAfter, sender);

            return true;
        }


        private void ActionOutputToPdf(object sender, bool isCheckUltimate = true)
        {
            ReportContextData reportData = SelectReport();
            if (reportData == null) return;

            //检查报告签名
            if (CheckReportSign(reportData) == false) return;

            //检查报告是否被驳回
            if (CheckReportReject(reportData) == false) return;


            //打印限制判断，如普通患者是否终审
            if (isCheckUltimate)
            {
                if (CheckPrintLimit(reportData) == false) return;
            }



            DoActions(ReportEventDefine.PdfBefore, sender);

            //pdf打印
            PrintPDFToNet(reportData);

            DoActions(ReportEventDefine.PdfAfter, sender);
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (ActionOutputToPrint(sender) == false) return;

                if (_reportPars.PrintAutoConvertPDF)
                {
                    ActionOutputToPdf(sender, false);
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 刷新锁定状态
        /// </summary>
        private JApplyLockInfo RefreshLockState()
        {

            if (_lockInfo == null)
            {
                _lockInfo = ReportContextModel.GetCurrentApplyLockInfo(_applyId);
            }

            if (_lockInfo == null)
            {
                return null;
            }

            if (_lockInfo.锁定人 != _userData.Name)
            {
                _lockInfo = ReportContextModel.GetCurrentApplyLockInfo(_applyId);
            }

            return _lockInfo;
        }

        /// <summary>
        /// 删除报告
        /// </summary>
        private void ActionDelReport(object sender)
        {
            if (cbxReports.SelectedItem == null)
            {
                MessageBox.Show("请选择当前需要删除的报告。", "提示");
                return;
            }

            ItemBind ib = cbxReports.SelectedItem as ItemBind;
            ReportContextData reportData = null;

            if (ib.Data != null)
            {
                //判断报告审核已经签名，已签名报告不允许删除
                reportData = ib.Data as ReportContextData;

                if (reportData.签名信息 != null && reportData.签名信息.签名明细.Count > 0)
                {
                    MessageBox.Show("已签名报告不允许进行删除。", "提示");
                    return;
                }
            }

            JApplyLockInfo lockInfo = RefreshLockState();

            if (lockInfo != null && _userData.Name != lockInfo.锁定人)
            {
                MessageBox.Show("检查已被 [" + lockInfo.锁定人 + "] 锁定，不能进行删除。", "提示");
                return;
            }

            DialogResult dr = MessageBox.Show("确认删除当前报告吗？", "提示", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No) return;


            DoActions(ReportEventDefine.DelBefore, sender);

            if (ib.Data != null)
            {
                //删除报告
                ReportContextModel.DelReport(ib.Value);
            }

            int index = cbxReports.Items.IndexOf(ib);

            cbxReports.Items.RemoveAt(index);
            UpdateReportList();

            if (index < cbxReports.Items.Count)
            {
                cbxReports.SelectedIndex = index;
            }
            else
            {
                cbxReports.SelectedIndex = cbxReports.Items.Count - 1;
                if (cbxReports.SelectedIndex < 0)
                {
                    cbxReportTemplateFormats.SelectedIndex = -1;
                    cbxReportTemplateFormats.Enabled = false;

                    _reportEdit.ImportByXml("");
                }
            }

            DoActions(ReportEventDefine.DelAfter, sender);
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            try
            {
                ActionDelReport(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void reportEdit_ReportContentChanged(object sender, FormPart.ContentChangedEventeArgs e)
        {
            try
            {
                if (_isProcessing) return;

                if (cbxReports.SelectedItem == null)
                {
                    MessageBox.Show("未选择需要处理的报告。", "提示");
                    _reportEdit.ReadOnly = true;
                    return;
                }

                ItemBind ibReport = cbxReports.SelectedItem as ItemBind;
                if (ibReport == null)
                {
                    MessageBox.Show("报告内容数据获取失败。", "提示");
                    _reportEdit.ReadOnly = true;
                    return;
                }

                ReportContextData reportData = null;
                if (ibReport.Data != null)
                {
                    reportData = ibReport.Data as ReportContextData;
                }


                if (VerifyReportLockState(reportData) == false)
                {
                    //判断是否高级别医生
                    _reportEdit.ReadOnly = true;
                    return;
                }


            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        /// <summary>
        /// 读取报告当前状态
        /// </summary>
        /// <param name="reportData"></param>
        /// <param name="reportReason"></param>
        /// <returns></returns>
        private ReportEditState GetReportState(ReportContextData reportData, ref string reportReason)
        {
            if (_lockInfo == null)
            {
                _lockInfo = ReportContextModel.GetCurrentApplyLockInfo(_applyId);
            }

            //是否完结
            if (reportData != null && reportData.状态信息.是否已完结)
            {
                return ReportEditState.resFinished;
            }

            ////是否驳回  被驳回的报告允许进行编辑修订处理
            //if (reportData != null && reportData.状态信息.是否驳回)
            //{
            //    return ReportEditState.resRejected;
            //}


            if (_lockInfo == null)
            {   //尚未进行锁定
                if (reportData == null)
                {
                    //尚未创建报告，则允许编辑
                    return ReportEditState.resDiagnosing;
                }
                else
                {
                    //已经创建了报告
                    if (string.IsNullOrEmpty(reportData.报告信息.报告医生))
                    {
                        //已创建，但未签名，且不处于锁定状态时，可进行编辑（诊断中）
                        return ReportEditState.resDiagnosing;
                    }
                    else
                    {
                        //已经签名的报告，需要获取最后一次签名的状态
                        JReportSignItem reportSign = null;
                        if (reportData.签名信息.签名明细.Count > 0) reportSign = reportData.签名信息.签名明细[reportData.签名信息.签名明细.Count - 1];
                        if (reportSign == null)
                        {
                            return ReportEditState.resDiagnosing; 
                        }

                        //判断当前用户和最后签名用户是否相同，如果不同，则判断是否允许同级审核
                        if (_userData.Name == reportSign.用户名称)
                        {
                            //报告修订
                            if (_userData.Name == reportData.报告信息.报告医生)
                            {
                                return ReportEditState.resRevising;
                            }
                            else
                            {
                                return ReportEditState.resAuditing;
                            }
                        }
                        else
                        {

                            if (_userData.Name == reportData.报告信息.报告医生)
                            {
                                reportReason = "报告已被 [" + reportSign.用户名称 + "] 审核，无权操作。";
                                return ReportEditState.resNoEditing; ;
                            }

                            //判断当前用户级别是否大于最后签名用户级别
                            if (_userData.Level > reportSign.用户级别)
                            {
                                return ReportEditState.resAuditing;
                            }
                            else
                            {
                                if (_reportPars.DirectAuditingLevel > -1)
                                {
                                    //允许同级审核
                                    if (_userData.Level >= _reportPars.DirectAuditingLevel && _userData.Level >= reportSign.用户级别)
                                    {
                                        //满足同级审核条件
                                        return ReportEditState.resAuditing;
                                    }
                                    else
                                    {
                                        reportReason = "报告已被 [" + reportSign.用户名称 + "] 审核，无权处理。";
                                        return ReportEditState.resNoEditing;
                                    }
                                }
                                else
                                {
                                    //不允许同级审核
                                    reportReason = "报告已被 [" + reportSign.用户名称 + "] 审核，无权处理。";
                                    return ReportEditState.resNoEditing;
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                //已进行锁定，
                //能进入锁定状态，说明能够对此报告进行对应处理
                if (_lockInfo.锁定人 != _userData.Name)
                {
                    reportReason = "检查已被 [" + _lockInfo.锁定人 + " ] 锁定,锁定原因:" + _lockInfo.锁定原因 + "，不能进行此操作。";
                    return ReportEditState.resNoEditing;
                }

                if (reportData == null)
                {
                    return ReportEditState.resDiagnosing;
                }
                else
                {
                    JReportSignItem reportSign = null;

                    if (reportData.签名信息.签名明细.Count > 0) reportSign = reportData.签名信息.签名明细[reportData.签名信息.签名明细.Count - 1];

                    if (reportSign == null)
                    {
                        return ReportEditState.resDiagnosing;
                    }
                    else
                    {
                        //判断名称与最后一次是否相同
                        if (_userData.Name == reportSign.用户名称)
                        {
                            if (_userData.Name == reportData.报告信息.报告医生)
                            {
                                return ReportEditState.resRevising;
                            }
                            else
                            {
                                return ReportEditState.resAuditing;
                            }
                        }
                        else
                        {
                            return ReportEditState.resAuditing;
                        }
                    }
                }
                 
            }
        }

        /// <summary>
        /// 验证报告锁定状态
        /// </summary>
        private bool VerifyReportLockState(ReportContextData reportData)
        {
            bool LockReport(string reason)
            {
                _lockInfo = new JApplyLockInfo();

                _lockInfo.锁定人 = _userData.Name;
                _lockInfo.锁定日期 = ReportContextModel.GetServerDate();
                _lockInfo.锁定原因 = reason;

                ReportContextModel.LockApply(_applyId, _lockInfo);

                //确认是否被锁定成功
                _lockInfo = ReportContextModel.GetCurrentApplyLockInfo(_applyId);

                if (_lockInfo == null)
                {
                    MessageBox.Show("检查锁定失败，不能进行此操作。", "提示");
                    return false;
                }

                if (_lockInfo.锁定人 != _userData.Name)
                {
                    MessageBox.Show("检查已被 [" + _lockInfo.锁定人 + "] 锁定原因:" + _lockInfo.锁定原因 + "，不能进行此操作。", "提示");
                    return false;
                }

                return true;
            }

            string stateReason = "";
            _reportState = GetReportState(reportData, ref stateReason);

            if (_reportState == ReportEditState.resNoEditing)
            {
                ResetReportState(reportData, _reportState, stateReason);

                MessageBox.Show(stateReason, "提示");
                return false; 
            }

            //检查报告最新状态
            if (CheckStateChange(reportData) == false) return false;


            switch (_reportState)
            {
                case ReportEditState.resDiagnosing:
                    return LockReport("报告编辑");

                case ReportEditState.resRevising:
                    return LockReport("报告修订");

                case ReportEditState.resAuditing:
                    return LockReport("报告审订");

                default:
                    return false;
            }
        }


        /// <summary>
        /// 解除锁定
        /// </summary>
        private void UnLockReport()
        {
            ReportContextModel.UnLockApply(_applyId);

            _lockInfo = null;
        } 
 

        private IESign _esign = null;

        /// <summary>
        /// 写入签名
        /// </summary>
        /// <param name="reportData"></param>
        /// <param name="reportState"></param>
        /// <param name="isReviseState">是否修订状态</param>
        /// <param name="isAuditSign">是否审签</param>
        private void WriteSign(ReportContextData reportData,  
            bool isReviseState, 
            bool isAuditPower)
        {
 
            JReportSignItem signItemInfo = new JReportSignItem();

            signItemInfo.用户级别 = _userData.Level;
            signItemInfo.用户ID = _userData.UserId;
            signItemInfo.用户名称 = _userData.Name;
            signItemInfo.是否修订 = isReviseState;
            signItemInfo.是否审核 = isAuditPower;
            signItemInfo.签名时状态 = reportData.状态信息.签名状态;
            signItemInfo.签名时间 = ReportContextModel.GetServerDate();

            Image signImg = _userData.SignImg as Bitmap;

            string signSource = "";

            if (_reportPars.UseESign)
            {
                if (_esign == null)
                {
                    _esign = GetEsign();

                    //电子签名处理
                    _esign.Init(_dbQuery);
                }

                ECertInfo certInfo = _esign.GetCertInfo(_userData.Name);

                if (certInfo == null)
                {
                    MessageBox.Show("当前用户签名认证信息获取失败，不能继续操作。", "提示");
                    return;
                }

                if (certInfo.SignImg != null)
                {
                    //有签名图片信息
                    signImg = certInfo.SignImg;
                }

                //如果是修订状态，则不写入报告签名到报告单上
                if (isReviseState == false)  WriteSignPostion(reportData, signItemInfo, signImg);  

                signSource = _reportEdit.ExportXmlf();

                ESignResultInfo esignInfo = _esign.Signature(certInfo, signSource);

                signItemInfo.证书信息.CopyFrom(certInfo);
                signItemInfo.签名结果.CopyFrom(esignInfo);
                 
            }
            else
            {
                //如果是修订状态，则不写入报告签名到报告单上
                if (isReviseState == false) WriteSignPostion(reportData, signItemInfo, signImg);

                signSource = _reportEdit.ExportXmlf();
            }

            if (ReportPublic.GetLastSignContext(reportData) != signSource)
            {
                //写入签名时对应的报告内容，如果最后签名内容与本次相同，则不需要进行保存
                signItemInfo.签名报告 = signSource;
            }

            if (string.IsNullOrEmpty(reportData.报告信息.报告医生))
            {
                //诊断签名时，写入报告医生
                reportData.报告信息.报告医生 = signItemInfo.用户名称;
                reportData.报告信息.报告时间 = signItemInfo.签名时间;
            }

            //保存最新的报告内容
            reportData.报告信息.报告内容 = signSource;

            if (isReviseState == false)
            {
                if (isAuditPower)
                {
                    reportData.报告信息.最后审签人 = signItemInfo.用户名称;
                    reportData.报告信息.最后审签时间 = signItemInfo.签名时间;

                    //已审签
                    reportData.状态信息.签名状态 = (int)ReportSignState.rpsAuditSign;
                }
                else
                {
                    //(已报告/已诊断)
                    reportData.状态信息.签名状态 = (int)ReportSignState.rpsDiagnosed;
                }
            }
            else
            {
                if (isAuditPower)
                {
                    //已审定
                    reportData.状态信息.签名状态 = (int)ReportSignState.rpsAudited;
                }
                else
                {
                    //已修订
                    reportData.状态信息.签名状态 = (int)ReportSignState.rpsRevised;
                }
            } 

            if (reportData.状态信息.是否驳回中)
            {
                reportData.状态信息.是否驳回中 = false;

                JReportRejectItem rejectItem = null;
                if (reportData.驳回信息.驳回明细.Count > 0)
                {
                    rejectItem = reportData.驳回信息.驳回明细[reportData.驳回信息.驳回明细.Count - 1];
                }

                rejectItem.驳回状态 = (int)ReportRejectState.rrsProcessed;
                rejectItem.处理人 = _userData.Name;
                rejectItem.处理时间 = ReportContextModel.GetServerDate();
             
            }

            //保存签名数据
            reportData.签名信息.签名明细.Add(signItemInfo);

            reportData.状态信息.最后更新时间 = ReportContextModel.GetServerDate();

            reportData.报告信息.是否阳性 = chkNP.Checked;
            reportData.报告信息.是否危急重 = chkCritical.Checked;

            reportData.报告信息.CopyBasePro(reportData);



            ReportContextModel.SaveReportSign(reportData);
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
                else if(reportData.签名信息.签名明细.Count > 1)
                {
                    waterContext = "已修订";
                }
            }

            if (string.IsNullOrEmpty(waterContext)) return;


            _reportEdit.DrawWatermark(waterContext, wfont, Color.FromArgb(255, 230, 230));
        }


        /// <summary>
        /// 修订签名
        /// </summary>
        private void ReviseSign(ReportContextData reportData)
        {
            if (reportData == null) return;

            //判断是否进行了诊断签名
            if (string.IsNullOrEmpty(reportData.报告信息.报告医生))
            {
                MessageBox.Show("报告尚未进行诊断签名，不能进行修订。", "提示");
                return;
            }
            else
            {
                //已经有了签名后的处理
                JReportSignItem reportSign = null;

                if (reportData.签名信息.签名明细.Count > 0) reportSign = reportData.签名信息.签名明细[reportData.签名信息.签名明细.Count - 1];

                if (reportSign == null)
                {
                    MessageBox.Show("签名信息获取异常，不能进行签名处理。", "提示");
                    return;
                }

                if (_userData.Name == reportSign.用户名称)
                {
                    if (_userData.Name == reportData.报告信息.报告医生)
                    {
                        if (reportSign.是否审核)
                        {
                            //具有自审权限的审核后修订
                            WriteSign(reportData, true, true);
                        }
                        else
                        {
                            //修订签名
                            WriteSign(reportData, true, false);
                        }
                    }
                    else
                    {
                        //审订签名
                        WriteSign(reportData, true, true);
                    }
                    return;
                }
                else
                {
                    //如果报告已经被他人修订或审订，则不能重新进行修改
                    if (_userData.Name == reportData.报告信息.报告医生)
                    {
                        MessageBox.Show("报告已被 [" + reportSign.用户名称 + "] 处理，不能进行此操作。", "提示");
                        return;
                    }

                    if (_userData.Level < reportSign.用户级别)
                    {
                        MessageBox.Show("用户级别不足，不能进行签名处理。", "提示");
                        return;
                    }

                    if (_userData.Level == reportSign.用户级别)
                    {
                        if (!(_reportPars.EqualAdutingLevel > -1 && _userData.Level >= _reportPars.EqualAdutingLevel))
                        {
                            MessageBox.Show("用户级别不足，不能进行签名处理。", "提示");
                            return;
                        }
                    }


                    //签名
                    WriteSign(reportData, true, true);
                }
            }
        }

        /// <summary>
        /// 报告签名
        /// </summary>
        private void ReportSign(ReportContextData reportData)
        {

            if (reportData == null) return;

            //判断是否进行了诊断签名
            if (string.IsNullOrEmpty(reportData.报告信息.报告医生))
            {
                //未进行任何签名的处理
                
                //判断是否允许直接审签
                if (_reportPars.DirectAuditingLevel <= -1)
                {
                    //先诊断签名
                    WriteSign(reportData,  false, false);
                }
                else
                {
                    //直接审核签名
                    if (_userData.Level >= _reportPars.DirectAuditingLevel)
                    {
                        //允许直接审核签名
                        WriteSign(reportData, false, false);

                        WriteSign(reportData, false, true);
                    }
                    else
                    {
                        //不允许直接审核签名
                        WriteSign(reportData, false, false);
                    }
                }
            }
            else
            {
                //已经有了签名后的处理
                JReportSignItem reportSign = null;

                if (reportData.签名信息.签名明细.Count > 0) reportSign = reportData.签名信息.签名明细[reportData.签名信息.签名明细.Count - 1];

                if (reportSign == null)
                {
                    MessageBox.Show("签名信息获取异常，不能进行签名处理。", "提示");
                    return;
                }
                 
                if (_userData.Name == reportSign.用户名称)
                {
                    if (_userData.Name == reportData.报告信息.报告医生)
                    {
                        if (reportSign.是否审核)
                        {
                            MessageBox.Show("已进行审核签名，不能重复签名。", "提示");
                        }
                        else
                        {
                            //已经进行了签名
                            MessageBox.Show("已进行诊断签名，不能重复签名。", "提示");
                        }
                    }
                    else
                    {
                        if (reportSign.是否修订)
                        {
                            //如果最后一次是修订签名，则可重复进行签名
                            WriteSign(reportData, false, true);
                        }
                        else
                        {
                            MessageBox.Show("已进行审订签名，不能重复签名。", "提示");
                        }

                    }

                    return;
                }
                else
                {
                    //如果报告已经被他人修订或审订，则不能重新进行修改
                    if (_userData.Name == reportData.报告信息.报告医生)
                    {
                        MessageBox.Show("报告已被 [" + reportSign.用户名称 + "] 处理，不能进行此操作。", "提示");
                        return;
                    }


                    if (_userData.Level < reportSign.用户级别)
                    {
                        MessageBox.Show("用户级别不足，不能进行签名处理。", "提示");
                        return;
                    }

                    if (_userData.Level == reportSign.用户级别)
                    {
                        if (!(_reportPars.EqualAdutingLevel > -1 && _userData.Level >= _reportPars.EqualAdutingLevel))
                        {
                            MessageBox.Show("用户级别不足，不能进行签名处理。", "提示");
                            return;
                        }
                    } 

                    //签名
                    WriteSign(reportData, false, true);
                }
            }

        }
 

        /// <summary>
        /// 写入报告签名位
        /// </summary>
        /// <param name="reportData"></param>
        /// <param name="curReportSign"></param>
        /// <param name="signImg"></param>
        private void WriteSignPostion(ReportContextData reportData, JReportSignItem curReportSign, Image signImg)
        {

            if (string.IsNullOrEmpty(reportData.报告信息.报告医生))
            {
                //写入记录签名
                _reportEdit.SetItemValue(SignElementNameDefine.记录签名, _userData.AssistUserInfo1.Name);//文本签名
                if (_userData.AssistUserInfo1.SignImg != null)
                {
                    _reportEdit.setImage("[图片]" + SignElementNameDefine.记录签名, _userData.AssistUserInfo1.SignImg as Bitmap, new Size(0, 0));//图片签名
                }

                _reportEdit.SetItemReMark(SignElementNameDefine.记录签名, curReportSign.Key);
                _reportEdit.SetItemReMark("[图片]" + SignElementNameDefine.记录签名, curReportSign.Key);



                //写入诊断签名
                _reportEdit.SetItemValue(SignElementNameDefine.诊断签名, curReportSign.用户名称);//文本签名
                if (signImg != null)
                {
                    _reportEdit.setImage("[图片]" + SignElementNameDefine.诊断签名, signImg as Bitmap, new Size(0, 0));//图片签名
                }

                _reportEdit.SetItemReMark(SignElementNameDefine.诊断签名, curReportSign.Key);
                _reportEdit.SetItemReMark("[图片]" + SignElementNameDefine.诊断签名, curReportSign.Key); 
            }
            else
            {
                //写入审核签名
                int auditingCount = ReportPublic.GetAuditingCount(reportData);

                if (auditingCount < 0)
                {
                    MessageBox.Show("报告签名异常，未发现对应的诊断签名信息。", "提示");
                    return;
                }

                auditingCount = auditingCount + 1;

                string signLabName = "";
                switch(auditingCount)
                {
                    case 1:
                        signLabName = SignElementNameDefine.一级审签;
                        break;

                    case 2:
                        signLabName = SignElementNameDefine.二级审签;
                        break;

                    case 3:
                        signLabName = SignElementNameDefine.三级审签;
                        break;

                    default:
                        signLabName = "";
                        break;

                }

                //写入文本或者图片签名
                _reportEdit.SetItemValue(signLabName, curReportSign.用户名称);//文本签名
                _reportEdit.setImage("[图片]" + signLabName, signImg as Bitmap, new Size(0, 0));//图片签名

                //写入签名标记
                _reportEdit.SetItemReMark(signLabName, curReportSign.Key);
                _reportEdit.SetItemReMark("[图片]" + signLabName, curReportSign.Key);
            }

        }

   
        private IESign GetEsign()
        {
            return null;
        }
          
        /// <summary>
        /// 报告修订
        /// </summary>
        private void ActionReviseReport(object sender)
        {
            ReportContextData reportData = SelectReport();
            if (reportData == null) return;

            if (VerifyReportLockState(reportData) == false) return;

            DoActions(ReportEventDefine.ReviseBefore, sender);

            ChangeReviseButState(true);

            _reportEdit.ReadOnly = false;

            DoActions(ReportEventDefine.ReviseAfter, sender);
        }

        /// <summary>
        /// 进入报告修订
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbRevise_Click(object sender, EventArgs e)
        {
            try
            {
                ActionReviseReport(sender);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void ChangeReviseButState(bool isRevise)
        {
            _reportEdit.Enabled = true;

            //tsbSave.Enabled = !isRevise;
            tsbSign.Enabled = !isRevise;
            tsbRevise.Enabled = !isRevise;
            tsbReviseSign.Enabled = isRevise;
            tsbReviseCancel.Enabled = isRevise;

            _isReviseModel = isRevise;
        }

        /// <summary>
        /// 确认修订
        /// </summary>
        private void ActionSureRevise(object sender)
        {
            if (cbxReports.SelectedItem == null)
            {
                MessageBox.Show("请选择需要进行修订确认的报告。", "提示");
                return;
            }

            ItemBind ibReport = cbxReports.SelectedItem as ItemBind;
            if (ibReport == null)
            {
                MessageBox.Show("无效的报告项目数据。", "提示");
                return;
            }

            DoActions(ReportEventDefine.SureReviseBefore, sender);

            ReportContextData reportData = null;

            if (ibReport.Data != null) reportData = ibReport.Data as ReportContextData;

            //先解除报告锁定
            UnLockReport();

            //修订签名
            ReviseSign(reportData);

            string reason = "";
            _reportState = GetReportState(reportData, ref reason);

            ResetReportState(reportData, _reportState, reason);

            ChangeReviseButState(false);

            _reportEdit.ReadOnly = true;

            DoActions(ReportEventDefine.SureReviseAfter, sender);
        }

        private void tsbReviseSign_Click(object sender, EventArgs e)
        {
            _isProcessing = true;
            try
            {
                ActionSureRevise(sender);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            finally
            {
                _isProcessing = false;
            }
        }

        /// <summary>
        /// 退出修订
        /// </summary>
        private void ActionQuitRevise(object sender)
        {
            if (cbxReports.SelectedItem == null)
            {
                MessageBox.Show("请选择需要进行修订确认的报告。", "提示");
                return;
            }

            ItemBind ibReport = cbxReports.SelectedItem as ItemBind;
            if (ibReport == null)
            {
                MessageBox.Show("无效的报告项目数据。", "提示");
                return;
            }

            DoActions(ReportEventDefine.QuitReviseBefore, sender);

            ReportContextData reportData = null;
            if (ibReport.Data != null) reportData = ibReport.Data as ReportContextData;


            UnLockReport();

            if (reportData != null)
            {
                _reportEdit.ImportByXml(reportData.报告信息.报告内容);
            }
            else
            {
                _reportEdit.ImportByXml("");
            }

            ChangeReviseButState(false);

            _reportEdit.ReadOnly = true;

            DoActions(ReportEventDefine.QuitReviseAfter, sender);
        }

        private void tsbSignCancel_Click(object sender, EventArgs e)
        {
            _isProcessing = true;
            try
            {
                ActionQuitRevise(sender);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            finally
            {
                _isProcessing = false;
            }
        }

        /// <summary>
        /// 报告终审自动打印
        /// </summary>
        /// <param name="reportData"></param>
        private void AutoPrint(ReportContextData reportData)
        {
            try
            {
                if (_reportPars.UltimateAutoPrint == false) return;

                int auditCount = ReportPublic.GetAuditingCount(reportData);

                if (auditCount > 0)
                {
                    //判断是否终审
                    if (auditCount >= _reportPars.ReportAuditLevel)
                    {
                        ReportPrint(reportData);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("报告自动打印出现错误。", ex);
            }
        }

        /// <summary>
        /// 报告终审自动完结
        /// </summary>
        /// <param name="reportData"></param>
        private void AutoFinish(ReportContextData reportData)
        {
            try
            {
                if (_reportPars.UltimateAutoFinish == false) return;

                int auditCount = ReportPublic.GetAuditingCount(reportData);

                if (auditCount > 0)
                {
                    //判断是否终审
                    if (auditCount >= _reportPars.ReportAuditLevel)
                    {
                        //执行报告完结
                        ReportFinish(reportData);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("报告自动完结出现错误。", ex);
            }
        }

        /// <summary>
        /// 报告自动发布
        /// </summary>
        /// <param name="reportData"></param>
        private void AutoPublic(ReportContextData reportData)
        {
            //不自动发布
            if (_reportPars.AutoPublicLevel <= 0) return;

            //获取最后的签名信息
            JReportSignItem signItem = ReportPublic.GetLastSignInfo(reportData);

            if (signItem.用户级别 >= _reportPars.AutoPublicLevel)
            {
                AllowReportView(reportData, null);
            }
        }



        private string PrintPDFToNet(ReportContextData reportData)
        {
            string vpath = GetImageVpath();

            string pdfFile = Dir.GetAppTempDir() + @"\" + vpath;
            if (Directory.Exists(pdfFile) == false) Directory.CreateDirectory(pdfFile);

            pdfFile = pdfFile + reportData.报告名称 + ".pdf";

            using (FileStream fs = new FileStream(pdfFile, FileMode.Create))
            {
                _reportEdit.ExportPDF().WriteTo(fs);

                fs.Position = 0;
                fs.Close();
            }

            FTPFileHelp ftp = Transfer.GetFtp(vpath, _stationInfo.StorageId, _dbQuery);

            if (ftp == null)
            {
                throw new Exception("FTP对象创建失败。");
            }

            System.IO.FileInfo fi = new System.IO.FileInfo(pdfFile);

            ftp.MakeDirectory(ftp.VPath);
            ftp.FileUpLoad(ftp.VPath + fi.Name, fi);

            int annexIndex = -1;

            if (reportData.附件信息 != null && reportData.附件信息.附件明细.Count > 0)
            {
                annexIndex = reportData.附件信息.附件明细.FindIndex(T => T.附件名称 == reportData.报告名称);
            }

            JReportAnnexItem annexItem = null;
            if (annexIndex > -1)
            {
                annexItem = reportData.附件信息.附件明细[annexIndex]; 
            }
            else
            {
                annexItem = new JReportAnnexItem(); 

                reportData.附件信息.附件明细.Add(annexItem);
            }

            string pdfUrl = ("ftp://" + ftp.FtpAddress + ftp.VPath + fi.Name).Replace(@"\", "/");

            annexItem.创建人 = _userData.Name;
            annexItem.创建时间 = ReportContextModel.GetServerDate();
            annexItem.存储ID = _stationInfo.StorageId;
            annexItem.附件名称 = reportData.报告名称;
            annexItem.访问链接 = pdfUrl;

            reportData.状态信息.是否转PDF = true;

            ReportContextModel.SaveReportAnnex(reportData);


            return ("ftp://" + ftp.FtpUser + ":" + ftp.FtpPwd + "@" + ftp.FtpAddress + ftp.VPath + fi.Name).Replace(@"\", "/");
            //if (string.IsNullOrEmpty(pdfUrl))
            //{
            //    MessageBox.Show("PDF转换处理失败：PDF路径 [" + pdfUrl + "] 无效");
            //}
            //else
            //{
            //    if (isHint)
            //    {
            //        MessageBox.Show("PDF转换处理完成：PDF路径已复制到剪贴板，详细路径为：" + System.Environment.NewLine + pdfUrl);

            //        Clipboard.SetText(pdfUrl);
            //    }
            //}
        }

        private string GetImageVpath()
        {
            string fmtRequestDate = Convert.ToDateTime(_requestDate).ToString("yyyyMMdd");

            return fmtRequestDate + @"\" + _applyId + @"\pdfs\";
        }

        
        /// <summary>
        /// 报告签名操作
        /// </summary>
         private void ActionReportSign(object sender)
        {
            if (cbxReports.SelectedItem == null)
            {
                MessageBox.Show("请选择需要进行签名的报告。", "提示");
                return;
            }

            ItemBind ibReport = cbxReports.SelectedItem as ItemBind;
            if (ibReport == null)
            {
                MessageBox.Show("无效的报告项目数据。", "提示");
                return;
            }

            if (_isReviseModel)
            {
                if (_reportState == ReportEditState.resRevising)
                {
                    MessageBox.Show("报告修订中，不能执行此操作。", "提示");
                }
                else
                {
                    MessageBox.Show("报告审订中，不能执行此操作。", "提示");
                }

                return;
            }



            ReportContextData reportData = null;
            if (ibReport.Data != null) reportData = ibReport.Data as ReportContextData;

            if (VerifyReportLockState(reportData) == false) return;

            if (reportData == null)
            {
                //先保存报告
                reportData = SaveCurReport(ibReport);
            }

            if (reportData == null)
            {
                MessageBox.Show("未获取到报告内容信息，不能进行签名操作。", "提示");
                return;
            }

            DoActions(ReportEventDefine.SignBefore, sender);


            //先解除报告锁定
            UnLockReport();

            //报告签名
            ReportSign(reportData);

            AutoPrint(reportData);

            AutoFinish(reportData);

            AutoPublic(reportData);

            string reason = "";
            _reportState = GetReportState(reportData, ref reason);

            ResetReportState(reportData, _reportState, reason);

            if (_isReviseModel)
            {
                ChangeReviseButState(false);
                _reportEdit.ReadOnly = true;
            }

            DoActions(ReportEventDefine.SignAfter, sender);
        }


        private void tsbSign_ButtonClick(object sender, EventArgs e)
        {
            _isProcessing = true;
            try
            {
                ActionReportSign(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            finally
            {
                _isProcessing = false;
            }
        }

        private void cbxReports_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 签名管理
        /// </summary>
        private void ActionSignManager()
        {
            ReportContextData reportData = SelectReport();
            if (reportData == null) return;

            if (CheckReportSign(reportData) == false) return;

            using (frmSignManager backSign = new frmSignManager())
            {
                backSign.ShowSignBack(ReportContextModel, reportData, _dbQuery, _userData, _reportPars, this);

                if (backSign.IsOk)
                {
                    _isProcessing = true;
                    try
                    {
                        _reportEdit.ImportByXml(reportData.报告信息.报告内容);

                        string reason = "";
                        _reportState = GetReportState(reportData, ref reason);


                        ResetReportState(reportData, _reportState, reason);
                    }
                    finally
                    {
                        _isProcessing = false;
                    }
                }
            }
        }

        private void tsbBack_Click(object sender, EventArgs e)
        {
            try
            {
                ActionSignManager();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                InitApplyReport(_applyId);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
        
        private void TouchReportImgAdd(object sender)
        {
            if (cbxReports.SelectedItem == null)
            {
                MessageBox.Show("请选择需要添加图像的报告。", "提示");
                return;
            }

            ItemBind ibReport = cbxReports.SelectedItem as ItemBind;
            if (ibReport == null)
            {
                MessageBox.Show("无效的报告项目数据。", "提示");
                return;
            }

            ReportContextData reportData = null;

            if (ibReport.Data != null)
            {
                reportData = ibReport.Data as ReportContextData;

                //检查用户级别
                if (CheckUserLevel(reportData) == false) return;

                //检查报告最新状态
                if (CheckStateChange(reportData) == false) return;
            }

            //如果报告为空，则需要先锁定报告后才能执行
            if (VerifyReportLockState(reportData) == false) return;

            DoActions(ReportEventDefine.ReportImgAddEvent, sender);
        }

        private void tsbReportImage_Click(object sender, EventArgs e)
        {
            try
            {
                TouchReportImgAdd(sender);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        private void DoActions(string actionName, object sender)
        {
            try
            {
                if (_designEvents.ContainsKey(actionName))
                {
                    base.DoBindActions(_designEvents[actionName], sender);
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void ReportControl_Load(object sender, EventArgs e)
        {
            try
            {
                _reportEdit = new FormPart.PreviewControl();
                panelReport.Controls.Add(_reportEdit);

                _reportEdit.Dock = DockStyle.Fill;
                _reportEdit.Visible = true;

                HandleDestroyed += EventHandlerProcess;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void EventHandlerProcess(object sender, EventArgs e)
        {
            //控件卸载事件

            HandleDestroyed -= EventHandlerProcess;
        }

        /// <summary>
        /// 允许查阅-开放查阅
        /// </summary>
        private void ActionAllowViewer(object sender)
        {
            bool CheckReportView(ReportContextData repData)
            {
                if (repData.状态信息.是否可查阅)
                {
                    MessageBox.Show("报告已开放查阅，不需重复操作。", "提示");
                    return false;
                }

                return true;
            }


            //获取报告
            ReportContextData reportData = SelectReport();
            if (reportData == null) return;

            //检查报告是否签名
            if (CheckReportSign(reportData) == false) return;

            //检查报告是否查阅
            if (CheckReportView(reportData) == false) return;

            //检查报告是否被驳回
            if (CheckReportReject(reportData) == false) return;

            //检查用户级别
            if (CheckUserLevel(reportData) == false) return;

            //检查状态改变
            if (CheckStateChange(reportData) == false) return;


            AllowReportView(reportData, sender);
        }


        private void tsbPublicReportView_Click(object sender, EventArgs e)
        {
            try
            {

                ActionAllowViewer(sender);

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 终止查阅
        /// </summary>
        private void ActionAbortView(object sender)
        {
            ReportContextData reportData = SelectReport();
            if (reportData == null) return;

            if (reportData.状态信息.是否可查阅 == false)
            {
                MessageBox.Show("报告尚未允许查阅，不能进行此操作。", "提示");
                return;
            }

            if (string.IsNullOrEmpty(reportData.报告信息.报告医生))
            {
                MessageBox.Show("未签名报告不能进行此操作。", "提示");
                return;
            }


            JReportSignItem signItem = ReportPublic.GetLastSignInfo(reportData);
            if (_userData.Name != reportData.报告信息.报告医生)
            {
                if (_userData.Level < signItem.用户级别)
                {
                    MessageBox.Show("非本人报告无权执行此操作。", "提示");
                    return;
                }
                else if (_userData.Level == signItem.用户级别)
                {
                    if (!(_reportPars.EqualAdutingLevel > -1 && _userData.Level >= _reportPars.EqualAdutingLevel))
                    {
                        MessageBox.Show("非本人报告无权执行此操作。", "提示");
                        return;
                    }
                }
            }

            DoActions(ReportEventDefine.AbortViewBefore, sender); 

            reportData.状态信息.是否可查阅 = false;

            ReportContextModel.UpdateReportStateInfo(reportData);

            string reason = "";
            _reportState = GetReportState(reportData, ref reason);

            ResetReportState(reportData, _reportState, reason);

            DoActions(ReportEventDefine.AbortViewAfter, sender);
        }

        private void tsbCancelView_Click(object sender, EventArgs e)
        {
            try
            {
                ActionAbortView(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 撤销完结
        /// </summary>
        private void ActionCancelFinished(object sender)
        {
            ReportContextData reportData = SelectReport();
            if (reportData == null) return;

            if (reportData.状态信息.是否已完结 == false)
            {
                MessageBox.Show("报告尚未完结，不能进行此操作。", "提示");
                return;
            }

            if (_userData.Name != reportData.报告信息.完结人)
            {
                if (_userData.Level < reportData.报告信息.完结人级别)
                {
                    MessageBox.Show("报告已被 [" + reportData.报告信息.完结人 + "] 完结，无权取消。", "提示");
                    return;
                }
                else if (_userData.Level == reportData.报告信息.完结人级别)
                {
                    if (!(_reportPars.EqualAdutingLevel > -1 && _userData.Level >= _reportPars.EqualAdutingLevel))
                    {
                        MessageBox.Show("报告已被 [" + reportData.报告信息.完结人 + "] 完结，无权取消。", "提示");
                        return;
                    }
                }
            }

            DoActions(ReportEventDefine.EscFinishedBefore, sender);

            reportData.报告信息.完结人 = "";
            reportData.报告信息.完结人级别 = -1;
            reportData.报告信息.完结时间 = default(DateTime);

            reportData.状态信息.是否已完结 = false;

            ReportContextModel.UpdateReportStateInfo(reportData);

            string reason = "";
            _reportState = GetReportState(reportData, ref reason);

            ResetReportState(reportData, _reportState, reason);

            DoActions(ReportEventDefine.EscFinishedAfter, sender);
        }

        private void tsbCancelFinish_Click(object sender, EventArgs e)
        {
            try
            {
                ActionCancelFinished(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
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

        /// <summary>
        /// 检查状态改变
        /// </summary>
        /// <param name="reportData"></param>
        /// <returns></returns>
        private bool CheckStateChange(ReportContextData reportData)
        {
            //验证最新报告状态是否有变化
            if (reportData == null) return true;

            JReportStateInfo newState = ReportContextModel.GetReportStateInfo(reportData.报告ID);
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

        /// <summary>
        /// 检查报告是否终审
        /// </summary>
        /// <returns></returns>
        private bool CheckIsUltimateAudit(ReportContextData reportData)
        {
            //获取审核次数
            int signCount = ReportPublic.GetAuditingCount(reportData); 

            if (_reportPars.ReportAuditLevel > 0)
            {
                if (signCount >= _reportPars.ReportAuditLevel)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 检查用户级别
        /// </summary>
        /// <param name="reportData"></param>
        /// <returns></returns>
        private bool CheckUserLevel(ReportContextData reportData)
        {

            JReportSignItem signItem = ReportPublic.GetLastSignInfo(reportData);

            if (signItem == null)
            {
                return true;
            }

            if (_userData.Name != signItem.用户名称)
            {
                if (_userData.Name == reportData.报告信息.报告医生)
                {
                    MessageBox.Show("报告已被 [" + signItem.用户名称 + "] 处理，不能进行此操作。", "提示");
                    return false;
                }

                if (_userData.Level < signItem.用户级别)
                {
                    MessageBox.Show("用户级别不足,无权执行此操作。", "提示");
                    return false;
                }
                else if (_userData.Level == signItem.用户级别)
                {
                    if (!(_reportPars.EqualAdutingLevel > -1 && _userData.Level >= _reportPars.EqualAdutingLevel))
                    {
                        MessageBox.Show("用户级别不足,无权执行此操作。", "提示");
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 检查报告签名
        /// </summary>
        /// <param name="reportData"></param>
        /// <returns></returns>
        private bool CheckReportSign(ReportContextData reportData)
        {
            if (string.IsNullOrEmpty(reportData.报告信息.报告医生))
            {
                MessageBox.Show("未签名报告不允许进行此操作。", "提示");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查报告审核完成
        /// </summary>
        /// <param name="reportData"></param>
        /// <returns></returns>
        private bool CheckReportFinish(ReportContextData reportData)
        {
            if (reportData.状态信息.是否已完结)
            {
                MessageBox.Show("报告已完结不允许进行此操作。", "提示");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查报告驳回
        /// </summary>
        /// <returns></returns>
        private bool CheckReportReject(ReportContextData reportData)
        {
            if (reportData.状态信息.是否驳回中)
            {
                MessageBox.Show("报告已被驳回不允许进行此操作。", "提示");
                return false;
            }

            return true;
        }

        private void ReportFinish(ReportContextData reportData)
        {
            reportData.报告信息.完结人 = _userData.Name;
            reportData.报告信息.完结人级别 = _userData.Level;
            reportData.报告信息.完结时间 = ReportContextModel.GetServerDate();

            reportData.状态信息.是否已完结 = true;

            ReportContextModel.UpdateReportStateInfo(reportData);
        }

        /// <summary>
        /// 允许报告查阅
        /// </summary>
        /// <param name="reportData"></param>
        /// <param name="sender"></param>
        private void AllowReportView(ReportContextData reportData, object sender)
        {
            DoActions(ReportEventDefine.AllowViewBefore, sender);


            reportData.状态信息.是否可查阅 = true;

            ReportContextModel.UpdateReportStateInfo(reportData);

            string reason = "";
            _reportState = GetReportState(reportData, ref reason);

            ResetReportState(reportData, _reportState, reason);

            DoActions(ReportEventDefine.AllowViewAfter, sender);
        }


        /// <summary>
        /// 完结报告
        /// </summary>
        private void ActionFinished(object sender)
        {
            //获取报告数据
            ReportContextData reportData = SelectReport();
            if (reportData == null) return;

            //检查报告是否签名
            if (CheckReportSign(reportData) == false) return;

            //检查报告是否完结
            if (CheckReportFinish(reportData) == false) return;

            //检查报告是否被驳回
            if (CheckReportReject(reportData) == false) return;

            //检查用户级别
            if (CheckUserLevel(reportData) == false) return;

            //检查最新报告状态
            if (CheckStateChange(reportData) == false) return;

            DoActions(ReportEventDefine.FinishedBefore, sender);

            //执行报告完结
            ReportFinish(reportData);

            string reason = "";
            _reportState = GetReportState(reportData, ref reason);

            ResetReportState(reportData, _reportState, reason);

            DoActions(ReportEventDefine.FinishedAfter, sender);
        }

        private void tsbFinish_Click(object sender, EventArgs e)
        {
            try
            {
                ActionFinished(sender);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 报告发放
        /// </summary>
        private void ActionGiveout(object sender)
        {
            bool CheckGiveOutState(ReportContextData repData)
            {
                if (repData.状态信息.是否已发放)
                {
                    MessageBox.Show("报告已发放不允许进行此操作。", "提示");
                    return false;
                }

                if (repData.状态信息.是否已打印)
                {
                    MessageBox.Show("未打印报告不允许进行此操作。", "提示");
                    return false;
                }

                return true;
            }


            //获取检查报告
            ReportContextData reportData = SelectReport();
            if (reportData == null) return;

            //检查报告签名
            if (CheckReportSign(reportData) == false) return;

            //检查报告可发放性
            if (CheckGiveOutState(reportData) == false) return;

            //检查报告是否被驳回
            if (CheckReportReject(reportData) == false) return;

            //检查报告最新状态
            if (CheckStateChange(reportData) == false) return;

            DoActions(ReportEventDefine.GiveOutBefore, sender);

            reportData.报告信息.发放人 = _userData.Name;
            reportData.报告信息.发放时间 = ReportContextModel.GetServerDate();

            reportData.状态信息.是否已发放 = true;

            ReportContextModel.UpdateReportStateInfo(reportData);

            string reason = "";
            _reportState = GetReportState(reportData, ref reason);

            ResetReportState(reportData, _reportState, reason);

            DoActions(ReportEventDefine.GiveOutAfter, sender);
        }

        private void tsbGiveOutReport_Click(object sender, EventArgs e)
        {

            try
            {
                ActionGiveout(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 取消报告发放
        /// </summary>
        private void ActionGiveIn(object sender)
        {
            ReportContextData reportData = SelectReport();
            if (reportData == null) return;

            if (reportData.状态信息.是否已发放 == false)
            {
                MessageBox.Show("报告尚未发放，不能进行此操作。", "提示");
                return;
            }

            DoActions(ReportEventDefine.GiveInBefore, sender);


            reportData.报告信息.发放人 = "";
            reportData.报告信息.发放时间 = default(DateTime);

            reportData.状态信息.是否已发放 = false;

            ReportContextModel.UpdateReportStateInfo(reportData);

            string reason = "";
            _reportState = GetReportState(reportData, ref reason);

            ResetReportState(reportData, _reportState, reason);

            DoActions(ReportEventDefine.GiveInAfter, sender);
        }

        private void tsbCancelGiveOut_Click(object sender, EventArgs e)
        {
            try
            {

                ActionGiveIn(sender);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void chkNP_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chkNP.ForeColor = (chkNP.Checked) ? Color.Yellow : Color.FromArgb(224, 224, 224);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void chkCritical_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chkCritical.ForeColor = (chkCritical.Checked) ? Color.FromArgb(255, 100, 100) : Color.FromArgb(224, 224, 224);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 报告驳回
        /// </summary>
        private void ActionReject(object sender)
        {
            //获取检查报告
            ReportContextData reportData = SelectReport();
            if (reportData == null) return;

            //检查报告签名
            if (CheckReportSign(reportData) == false) return;

            //检查报告是否已经被驳回
            if (CheckReportReject(reportData) == false) return;


            if (_userData.Name == reportData.报告信息.报告医生)
            {
                MessageBox.Show("不允许驳回自己书写的报告。", "提示");
                return;
            }

            JReportSignItem signItem = ReportPublic.GetLastSignInfo(reportData);
            if (_userData.Name == signItem.用户名称)
            {
                MessageBox.Show("不允许驳回最后处理为自己的报告。", "提示");
                return;
            }


            //检查用户级别
            if (CheckUserLevel(reportData) == false) return;

            //检查报告最新状态
            if (CheckStateChange(reportData) == false) return;


            DoActions(ReportEventDefine.RejectBefore, sender);

            using (frmReportReject reportReject = new frmReportReject())
            {
                reportReject.ShowReject(ReportContextModel, reportData, _userData, this);

                if (reportReject.IsOk)
                {
                    _isProcessing = true;
                    try
                    {
                        string reason = "";
                        _reportState = GetReportState(reportData, ref reason);

                        ResetReportState(reportData, _reportState, reason);
                    }
                    finally
                    {
                        _isProcessing = false;
                    }
                }
            }

            DoActions(ReportEventDefine.RejectAfter, sender);
        }

        private void tsbReject_Click(object sender, EventArgs e)
        {
            try
            {
                ActionReject(sender);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 驳回管理
        /// </summary>
        private void ActionRejectManager()
        {
            ReportContextData reportData = SelectReport();
            if (reportData == null) return;

            if (CheckReportSign(reportData) == false) return;

            using (frmRejectManager rejectManager = new frmRejectManager())
            {
                rejectManager.ShowManager(ReportContextModel, reportData, _userData, _reportPars, this);

                if (rejectManager.IsOk)
                {
                    _isProcessing = true;
                    try
                    {
                        string reason = "";
                        _reportState = GetReportState(reportData, ref reason);


                        ResetReportState(reportData, _reportState, reason);
                    }
                    finally
                    {
                        _isProcessing = false;
                    }
                }
            }
        }

        private void tsbRejectManager_Click(object sender, EventArgs e)
        {
            try
            {
                ActionRejectManager();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbConvertPDF_Click(object sender, EventArgs e)
        {
            try
            {
                ReportContextData reportData = SelectReport();
                if (reportData == null) return;

                //检查报告签名
                if (CheckReportSign(reportData) == false) return;

                //检查报告是否被驳回
                if (CheckReportReject(reportData) == false) return;

                string url = PrintPDFToNet(reportData);

                string reason = "";
                _reportState = GetReportState(reportData, ref reason);


                ResetReportState(reportData, _reportState, reason);

                //Clipboard.SetText(url);
                //MessageBox.Show("处理完成，PDF访问地址为：" + url, "提示");

                //System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 解除锁定
        /// </summary>
        private void ActionUnLock(object sender)
        {
            //解除锁定处理 

            JApplyLockInfo curlockInfo = new JApplyLockInfo(); 

            //获取申请锁定信息
            curlockInfo = ReportContextModel.GetCurrentApplyLockInfo(_applyId);

            if (curlockInfo == null) return;

            //判断锁定级别
            if (string.IsNullOrEmpty(curlockInfo.锁定人))
            {
                if (MessageBox.Show("检查已被 [" + curlockInfo.锁定人 + "] 在 " + curlockInfo.锁定日期.ToString("yyyy-MM-dd HH:mm") + "锁定, 锁定原因如下:" + System.Environment.NewLine
                                        + "  " + _lockInfo.锁定原因 + "。" + System.Environment.NewLine
                                        + "  " + "是否确认解除锁定？。", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            DoActions(ReportEventDefine.UnlockBefore, sender);
            
            UnLockReport();
            
            DoActions(ReportEventDefine.UnlockAfter, sender);
        }

        private void tsbUnLock_Click(object sender, EventArgs e)
        {
            try
            {
                ActionUnLock(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}
