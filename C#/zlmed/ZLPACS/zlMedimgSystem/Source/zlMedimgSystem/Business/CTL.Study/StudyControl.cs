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
using zlMedimgSystem.DB.OraServices;
using zlMedimgSystem.Services;
using zlMedimgSystem.DataModel;

namespace zlMedimgSystem.CTL.Study
{
    [ToolboxItem(false)]
    public partial class StudyControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        private const string Const_Event_SelChange = "选择行改变事件";
        private const string Const_Event_RowClick = "行单击事件";
        private const string Const_Event_RowDBClick = "行双击事件";

        private const string Const_Data_SelStudyData = "选择行的检查数据";



        private frmFilter _frmFilter;
        private frmRequest _frmRequest;
        private DataTable _dataTable = null;
        private OraServices _rsHis = null;
        List<StudyInfo> mstudyInfos = new List<StudyInfo>();
        
        private Dictionary<long, string> _DictJson = new Dictionary<long, string>();
        private StudyBizData _studyData = new StudyBizData(); 

        public StudyControl()
        {
            InitializeComponent();
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "检查模块";
            
            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideActionDesc.Add("更新行", "更新行的功能描述");
            _provideActionDesc.Add("定位行", "定位行的功能描述");

            _provideDataDesc.Add(ModuleName + "." + Const_Data_SelStudyData,  "当前列表选择行对应的检查数据");


            //_designTools.Add("登记", new ToolVisible("登记", true));
            //_designTools.Add("报道", new ToolVisible("报道", true));
            //_designTools.Add("完成", true);
            //_designTools.Add("刷新", true);
            //_designTools.Add("过滤", true);
            //_designTools.Add("绿色通道", true);

            _designEvents.Add(Const_Event_SelChange, new EventActionReleation(Const_Event_SelChange, ActionType.atSysFixedEvent));
            _designEvents.Add(Const_Event_RowClick, new EventActionReleation(Const_Event_RowClick, ActionType.atSysFixedEvent));
            _designEvents.Add(Const_Event_RowDBClick, new EventActionReleation(Const_Event_RowDBClick, ActionType.atSysFixedEvent));
        }
  
  
        /// <summary>
        /// 刷新
        /// </summary>
        public override void RefreshModule()
        {
            if (DesignMode) return;
            RefreshList("Select * from 影像检查信息 WHERE 报到日期>SYSDATE-100");
        }

        private void RefreshList(string strSQL)
        {
            _DictJson.Clear();
            string strJson;
            StudyInfo studyInfo = new StudyInfo();
            List<StudyInfo> studyInfos = new List<StudyInfo>();
            studyInfos = new List<StudyInfo>();

            System.Diagnostics.Debug.WriteLine("进入RefreshList");
            _dataTable = _dbQuery.ExecuteSQL(strSQL);
            System.Diagnostics.Debug.WriteLine("查询OK");
            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                strJson = _dataTable.Rows[i]["患者信息"].ToString();
                try
                {
                    studyInfo = JsonHelper.DeserializeObject<StudyInfo>(strJson);
                    studyInfo.部位方法 = null;
                    if (studyInfo.姓名 == null)
                        continue;
                    _DictJson.Add(studyInfo.ID, strJson);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("出错！");
                    continue;
                }

                studyInfos.Add(studyInfo);


            }

            System.Diagnostics.Debug.WriteLine("循环解析json类型ok");
            gridCtl.DataSource = studyInfos;

            gridView.PopulateColumns();
            gridView.BestFitColumns();

            gridView.Columns["ID"].Visible = false;
            gridView.Columns["患者ID"].Visible = false;
            gridView.Columns["执行科室ID"].Visible = false;
            gridView.Columns["检查项目ID"].Visible = false;
            gridView.Columns["主页ID"].Visible = false;
            gridView.Columns["就诊ID"].Visible = false;

            for (int i = 0; i < gridView.RowCount; i++)
            {
                string strTmp = "";
                strTmp = gridView.GetRowCellValue(i, "患者来源").ToString();

                if (strTmp == "1")
                    strTmp = "门诊病人";

                if (strTmp == "2")
                    strTmp = "住院病人";


                gridView.SetRowCellValue(i, "患者来源", strTmp);

            }

            System.Diagnostics.Debug.WriteLine("主列表显示数据ok");
        }

        /// <summary>
        /// 行数据选中
        /// </summary>
        private void ListSelChanged()
        {
            string strjson;

            //首先根据选中行构造_studyData对象
            if (gridView.RowCount == 0)
                return;

            int intSelRow = gridView.GetSelectedRows()[0];
            if (intSelRow < 0)
                return;

            _studyData.StudyId = Convert.ToInt16(gridView.GetRowCellValue(intSelRow, "ID").ToString());
            _studyData.Name = gridView.GetRowCellValue(intSelRow, "姓名").ToString();
            _studyData.Sex = gridView.GetRowCellValue(intSelRow, "性别").ToString();
            _studyData.PatientId = Convert.ToInt16(gridView.GetRowCellValue(intSelRow, "患者ID").ToString());
            _studyData.StudyNo = gridView.GetRowCellValue(intSelRow, "检查号").ToString();
            _studyData.InHospitalNo = gridView.GetRowCellValue(intSelRow, "住院号").ToString();
            _studyData.OutHospitalNo = gridView.GetRowCellValue(intSelRow, "门诊号").ToString();
            _studyData.ItemContext = gridView.GetRowCellValue(intSelRow, "项目摘要").ToString();
            _studyData.FmtRecDate = gridView.GetRowCellValue(intSelRow, "报到时间").ToString();
            _studyData.FmtRecDate = Convert.ToDateTime(_studyData.FmtRecDate).ToString("yyyyMMdd");

            long longID = Convert.ToInt16(gridView.GetRowCellValue(intSelRow, "ID").ToString());

            _DictJson.TryGetValue(longID, out strjson);
            _studyData.JSonInfos = (Newtonsoft.Json.Linq.JObject)(JsonHelper.DeserializeObject<Newtonsoft.Json.Linq.JObject>(strjson));

            //List<BizData> datas = new List<BizData>();

            //BizData bd = new BizData();
            //bd.DataModuleName = Const_Data_SelStudyData;
            //bd.ObjData = _studyData;
            //bd.AttachDataList.Add("ID", _studyData.StudyId);
            //bd.AttachDataList.Add("姓名", _studyData.Name);

            //datas.Add(bd);

            //_dataTransCenter.RegBizDataQuery(Const_Data_SelStudyData, this);
        }

        public override BizDataItems QueryDatas(string dataIdentificationName)
        {
            BizDataItems resultDatas = null;
            BizDataItem bdi = null;

            switch (dataIdentificationName)
            {
                case Const_Data_SelStudyData:
                    resultDatas = new BizDataItems(); 
                    bdi = new BizDataItem();

                    bdi.Add("ID", _studyData.StudyId);
                    bdi.Add("姓名", _studyData.Name);

                    resultDatas.Add(bdi);

                    return resultDatas;
                default:
                    return null;
            }

            //switch (dataItemName)
            //{
            //    case "ID":
            //        return _studyData.StudyId; 
            //    case "姓名":
            //        return _studyData.Name;
            //    default:
            //        return null;
            //}
        }

        //protected override void BindEvents()
        //{
            //foreach (EventAction ea in _designEvents.Values)
            //{
            //    if (ea.Actions.Count <= 0) continue;

            //    switch (ea.EventName)
            //    {
            //        case Const_Event_SelChange:
            //            button1.Click += BindSelChnage;
            //            button3.Click += BindSelChnage;
            //            break;

            //        case Const_Event_RowClick:
            //            break;
            //        case Const_Event_RowDBClick:
            //            button2.Click += BindDbClick;
            //            button4.Click += BindDbClick;
            //            break;
            //        default:
            //            break;

            //    }
            //}
        //}

        public override void ChangeModuleStyle(string styleName)
        {
            //if (styleName == "样式一")
            //{
            //    tabControl1.SelectedIndex = 0;
            //}
            //else
            //{
            //    tabControl1.SelectedIndex = 1;
            //}
        }

        protected void InitUserTool()
        {
            //foreach (string butName in _userTools.Keys)
            //{
            //    ToolStripItem tsi = toolStrip1.Items.Add(butName);

            //    tsi.DisplayStyle = ToolStripItemDisplayStyle.Text;

            //    if (_designEvents.ContainsKey(butName))
            //    {
            //        tsi.Click += BindUserToolClick;
            //    }
            //}
        }

        public void BindUserToolClick(object sender, EventArgs e)
        {
            DoActions(_designEvents[((ToolStripItem)sender).Text], sender);
        }
        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, string dataName)
        {
            return true;
        }

        public void BindSelChnage(object sender, EventArgs e)
        {
            DoActions(_designEvents[Const_Event_SelChange], sender);
        }

        public void BindDbClick(object sender, EventArgs e)
        {
            DoActions(_designEvents[Const_Event_RowDBClick], sender);
        }

        private void DoActions(EventActionReleation ea, object sender)
        {
            try
            {
                base.DoBindActions(ea, sender); 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void StudyControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == true) return;

            try
            {
                RefreshModule();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ListSelChanged();
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            BindDbClick(sender, e);
        }
    }
}
