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

namespace zlMedimgSystem.CTL.History
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(HistoryControl), "Resources.history.ico")]
    public partial class HistoryControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {

        static public class HistoryActionDefine
        {
            public const string ReportPreview = "预览报告";
            public const string ImagesPreview = "预览图像";
            public const string TextSend = "文本发送";           
            public const string LoadHistory = "载入历史";
        }

        static public class HistoryDataDefine
        {
            public const string SelHistoryStudy = "当前历史检查";
            public const string SelHistoryReport = "当前历史报告";
            public const string SelTextContext = "选中文本内容";
        }

        static public class HistoryEventDefine
        {
            public const string SendTextToReport = "文本发送"; 
        }





        private string _applyId = "";//申请ID
        //private DateTime _requestDate = default(DateTime);//申请日期

        private ReportContextModel _rcm = null;

        private bool _isLoading = false;
        private bool _isBinding = false;

        private int _defaultDays = 30;

        private HistoryDesign _historyDesign = null;

        protected ReportContextModel ReportContextModel
        {
            get
            {
                if (_rcm == null) _rcm = new ReportContextModel(_dbQuery);
                return _rcm;
            }
        }


        public HistoryControl()
        {
            InitializeComponent();

            _historyDesign = new HistoryDesign();

            _historyDesign.BackColor = toolStrip2.BackColor;
            _historyDesign.ForceColor = toolStrip2.ForeColor;
            _historyDesign.Size = toolStrip2.Height;
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = false;
            _moduleName = "检查历史";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideActionDesc.Add(HistoryActionDefine.ReportPreview, "预览所选历史报告");
            _provideActionDesc.Add(HistoryActionDefine.ImagesPreview, "预览所选历史图像");
            _provideActionDesc.Add(HistoryActionDefine.TextSend, "将选择的内容文本进行发送操作");
            _provideActionDesc.Add(HistoryActionDefine.LoadHistory, "载入检查历史,请求的数据项如下：" 
                                                                + System.Environment.NewLine 
                                                                + "applyid");


            _provideDataDesc.AddDataDescription(_moduleName, HistoryDataDefine.SelHistoryStudy, "返回选择的历史检查信息,返回数据项如下："
                                                                + System.Environment.NewLine 
                                                                + "applyid,studyno,historyapplyid,historyapplydate,historyapplyidentify,historypatientid");
            _provideDataDesc.AddDataDescription(_moduleName, HistoryDataDefine.SelHistoryReport, "方法选择的历史报告信息，返回数据项如下："
                                                                + System.Environment.NewLine 
                                                                + "applyid,studyno,historyapplyid,historyapplydate,historyapplyidentify,historypatientid,historyreportid,historyreportname,historyreportdoctor,historyreportcreatedate");
            _provideDataDesc.AddDataDescription(_moduleName, HistoryDataDefine.SelTextContext, "返回选择的文本内容，方法数据项如下："
                                                                + System.Environment.NewLine 
                                                                + "applyid,text");


            _designEvents.Add(HistoryEventDefine.SendTextToReport, new EventActionReleation(HistoryEventDefine.SendTextToReport, ActionType.atSysFixedEvent)); 
        }


        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _historyDesign = JsonHelper.DeserializeObject<HistoryDesign>(customContext);

            LoadDesign();
        }

        private void LoadDesign()
        {
            toolStrip2.BackColor = _historyDesign.BackColor;
            toolStrip2.ForeColor = _historyDesign.ForceColor;
            toolStrip2.Height = _historyDesign.Size;
        }



        public override string ShowCustomDesign()
        {
            using (frmHistoryDesign design = new frmHistoryDesign())
            {
                design.ShowDesign(_historyDesign, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_historyDesign);

            LoadDesign();

            return _customDesignFmt;
        }


        /// <summary>
        /// 刷新
        /// </summary>
        public override void RefreshModule()
        {
        }

        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case HistoryDataDefine.SelTextContext:
                    return true;

                case HistoryDataDefine.SelHistoryReport:
                    return true;

                case HistoryDataDefine.SelHistoryStudy:
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
                case HistoryDataDefine.SelTextContext://当前文本内容
                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();

                    dataItem.Add(DataHelper.StdPar_ApplyId, _applyId);
                    dataItem.Add(DataHelper.StdPar_Text, richTextBox1.SelectedText); 

                    resultDatas.Add(dataItem);

                    return resultDatas;

                case HistoryDataDefine.SelHistoryStudy://当前选择的历史检查信息

                    if (listView1.SelectedItems.Count <= 0)
                    {
                        return null;
                    }

                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();

                    dataItem.Add(DataHelper.StdPar_ApplyId, _applyId);

                    ListViewItem lvi = listView1.SelectedItems[0];
                    ApplyData applyData = lvi.Tag as ApplyData;

                    dataItem.Add(DataHelper.StdPar_StudyNo, applyData.检查号);
                    dataItem.Add("historyapplyid", applyData.申请ID);
                    dataItem.Add("historyapplydate", applyData.申请日期);
                    dataItem.Add("historyapplyidentify", applyData.申请识别码);
                    dataItem.Add("historypatientid", applyData.患者ID);

                    resultDatas.Add(dataItem);

                    return resultDatas;

                case HistoryDataDefine.SelHistoryReport://当前选择的历史报告
                    if (listView1.SelectedItems.Count <= 0)
                    {
                        return null;
                    }

                    if (tscbxReports.Items.Count <= 0)
                    {
                        return null;
                    }

                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();

                    dataItem.Add(DataHelper.StdPar_ApplyId, _applyId);

                    //读取历史信息
                    ListViewItem lviSel = listView1.SelectedItems[0];
                    ApplyData reportApplyData = lviSel.Tag as ApplyData;

                    dataItem.Add(DataHelper.StdPar_StudyNo, reportApplyData.检查号);
                    dataItem.Add("historyapplyid", reportApplyData.申请ID);
                    dataItem.Add("historyapplydate", reportApplyData.申请日期);
                    dataItem.Add("historyapplyidentify", reportApplyData.申请识别码);
                    dataItem.Add("historypatientid", reportApplyData.患者ID);

                    //读取报告信息
                    ItemBind ib = tscbxReports.ComboBox.SelectedItem as ItemBind;

                    if (ib.Data == null) return null;

                    ReportContextData reportData  = ib.Data as ReportContextData;

                    dataItem.Add("historyreportid", reportData.报告ID);
                    dataItem.Add("historyreportname", reportData.报告名称);
                    dataItem.Add("historyreportdoctor", reportData.报告信息.报告医生);
                    dataItem.Add("historyreportcreatedate", reportData.报告信息.创建时间); 

                    resultDatas.Add(dataItem);

                    return resultDatas;

                default:
                    return null;
            }

        }
         
        public override void ChangeModuleStyle(string styleName)
        {
        }

        public void LoadHistory(string applyId, int dayRange = 30)
        {
            _isBinding = true;
            try
            {
                InitHistoryList();

                if (string.IsNullOrEmpty(applyId))
                {
                    MessageBox.Show("申请ID无效，不能加载历史检查。", "提示");
                    return;
                }

                DataTable dtHistory = ReportContextModel.ReadHistory(applyId, dayRange);

                foreach (DataRow drItem in dtHistory.Rows)
                {
                    ApplyData applyData = new ApplyData();
                    applyData.BindRowData(drItem);


                    ListViewItem itemNew = new ListViewItem(new string[] { applyData.申请信息.姓名, applyData.检查号, applyData.申请日期.ToString("yyyy-MM-dd HH:mm"), applyData.申请信息.检查项目.项目名称 }, 0);

                    itemNew.Tag = applyData;

                    listView1.Items.Add(itemNew);
                }

                listView1.View = View.Details;
            }
            finally
            {
                _isBinding = false;
            }

        }


        private void InitHistoryList()
        {
            richTextBox1.Text = "";

            listView1.Clear();
            listView1.Columns.Clear();

            ColumnHeader columnDefault = new ColumnHeader();
            columnDefault = new ColumnHeader();
            columnDefault.Text = "姓名";
            columnDefault.Name = "姓名";
            columnDefault.Width = 80;
            listView1.Columns.Add(columnDefault); 

            columnDefault = new ColumnHeader();
            columnDefault.Text = "检查号";
            columnDefault.Name = "检查号";
            columnDefault.Width = 100;
            listView1.Columns.Add(columnDefault);


            columnDefault = new ColumnHeader();
            columnDefault.Text = "申请日期";
            columnDefault.Name = "申请日期";
            columnDefault.Width = 110; 
            listView1.Columns.Add(columnDefault);


            columnDefault = new ColumnHeader();
            columnDefault.Text = "项目名称";
            columnDefault.Name = "项目名称";
            columnDefault.Width = 200;
            listView1.Columns.Add(columnDefault);

            listView1.View = View.Details;
        }         

        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            switch (actName)
            {
                case HistoryActionDefine.LoadHistory://载入历史
                     
                    if (bizDatas == null) return false; 

                    _applyId = DataHelper.GetItemValueByApplyId(bizDatas[0]); 

                    if (string.IsNullOrEmpty(_applyId))
                    {
                        MessageBox.Show("未检索到对应的申请ID，请求数据项名称为 [" + bizDatas.DataName + "]。", "提示");
                        return false;
                    }

                    LoadHistory(_applyId);

                    break;

                case HistoryActionDefine.ReportPreview:
                    if (_preview == null)
                    {
                        MessageBox.Show("报告尚未加载，不能进行预览。", "提示");
                        return false;
                    }

                    _preview.preview();

                    break;

                case HistoryActionDefine.TextSend://执行发送选择文本事件
                    DoBindActions(_designEvents[HistoryEventDefine.SendTextToReport], sender);

                    break;

                case HistoryActionDefine.ImagesPreview:
                    //执行图像预览操作
                    PreviewImage();

                    break;

                default:
                    break;
            }

            return true;
        }

 
        private void SyncSelRowData()
        {
            try
            {

                richTextBox1.Text = "";

                if (listView1.SelectedItems.Count <= 0) return;

                ApplyData applyData = listView1.SelectedItems[0].Tag as ApplyData;
                if (applyData == null)
                {
                    MessageBox.Show("未获取到对应的申请信息。", "提示");
                    return;
                }


                InitApplyReport(applyData.申请ID);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        private void InitApplyReport(string applyId)
        {
            _isBinding = true;
            try
            {
                tscbxReports.Items.Clear();

                tscbxReports.ComboBox.DisplayMember = "DisplayName";
                tscbxReports.ComboBox.ValueMember = "Value";

                tscbxReports.ComboBox.DataSource = null;

                DataTable dtReports = ReportContextModel.GetApplyReport(applyId);



                if (dtReports == null || dtReports.Rows.Count <= 0) return;

                ItemBind ib = null;
                foreach (DataRow dr in dtReports.Rows)
                {
                    ReportContextData reportData = new ReportContextData();
                    reportData.BindRowData(dr);

                    ib = new ItemBind(reportData.报告名称, reportData.报告ID);

                    ib.DisplayName = "(" + (dtReports.Rows.IndexOf(dr) + 1) + "/" + dtReports.Rows.Count + ")" + reportData.报告名称;
                    ib.Tag = reportData.部位名称;
                    ib.Data = reportData;

                    tscbxReports.ComboBox.Items.Add(ib);
                }

            }
            finally
            {
                _isBinding = false;

                if (tscbxReports.ComboBox.Items.Count > 0) tscbxReports.ComboBox.SelectedIndex = 0;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isBinding) return;

                SyncSelRowData();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private FormPart.PreviewControl _preview = null;
        private void tscbxReports_SelectedIndexChanged(object sender, EventArgs e)
        { 
            try
            {
                if (_isBinding) return;

                if (_preview == null)
                {
                    _preview = new FormPart.PreviewControl();
                    _preview.ReadOnly = true;
                    _preview.Hide();

                    this.Controls.Add(_preview);
                }

                _preview.ImportByXml("");

                ItemBind ib = tscbxReports.ComboBox.SelectedItem as ItemBind;

                ReportContextData reportData = null;

                if (ib.Data == null)
                {
                    return;
                } 

                reportData = ib.Data as ReportContextData;

                _preview.ImportByXml(reportData.报告信息.报告内容);

                //读取对应报告模板信息
                string context = "";
                ReportTemplateItemData reportTemplate = ReportContextModel.GetReportTemplateData(reportData.报告信息.模板ID);
                foreach(JReportSectionItem si in reportTemplate.关联段落.段落关联信息)
                {
                    if (string.IsNullOrEmpty(si.模板元素名)) continue;

                    object eleContext = _preview.GetItemValue(si.模板元素名);

                    if (eleContext != null && string.IsNullOrEmpty(eleContext.ToString()) == false)
                    {
                        context = context + "■■" + ((string.IsNullOrEmpty(si.段落显示名)) ? si.报告段落名 : si.段落显示名) + ":" + System.Environment.NewLine + eleContext.ToString() + System.Environment.NewLine;
                        context = context + System.Environment.NewLine;
                    }
                }

                richTextBox1.Text = context;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            } 
        }
         

        private void HistoryControl_Load(object sender, EventArgs e)
        {
            _isLoading = true;

            try
            {
                _defaultDays = AppSetting.ReadInt("DefaultHistoryDays", 30);

                //if (this.DesignMode == false)
                //{
                //    LoadHistory(_applyId, _defaultDays);
                //}
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void tsbPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (_preview == null)
                {
                    MessageBox.Show("报告尚未加载，不能进行预览。", "提示");
                    return;
                }

                _preview.preview();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbWriteReport_Click(object sender, EventArgs e)
        {
            try
            {
                DoBindActions(_designEvents[HistoryEventDefine.SendTextToReport], sender);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cMenuStripCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void PreviewImage()
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择需要查看的历次检查。", "提示");
                return;
            }

            ListViewItem lvi = listView1.SelectedItems[0];
            ApplyData applyData = lvi.Tag as ApplyData;

            FuncHelper.ShowImgPreview(_dbQuery, applyData.申请ID, this);
        }

        private void tsbImages_Click(object sender, EventArgs e)
        {
            try
            {
                PreviewImage();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

 
        private void tsmDateRangeAll_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (_isLoading) return;

                    if (string.IsNullOrEmpty(_applyId)) return;

                    int dayRange = Convert.ToInt32((sender as ToolStripMenuItem).Tag);

                    if (dayRange <= 0) dayRange = 36500;

                    LoadHistory(_applyId, dayRange);

                    _defaultDays = dayRange;

                    AppSetting.WriteInt("DefaultHistoryDays", _defaultDays);
                }
                catch (Exception ex)
                {
                    MsgBox.ShowException(ex, this);
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}
