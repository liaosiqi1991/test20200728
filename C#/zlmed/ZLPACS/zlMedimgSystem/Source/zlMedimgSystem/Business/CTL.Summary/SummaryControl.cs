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
using zlMedimgSystem.DataModel;
using zlMedimgSystem.BusinessBase;
using DevExpress.XtraLayout;

namespace zlMedimgSystem.CTL.Summary
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(SummaryControl), "Resources.summary.ico")]
    public partial class SummaryControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        static private class InfoActionDefine
        {
            public const string LoadInfo = "概要信息载入";
            //public const string LoadSpedifyContext = "载入指定内容";
            //public const string Setting = "信息设置";
        }
         

        private SummaryModuleDesign _summaryDesign = null;
        //private InfoConfig _ic = null;
        public SummaryControl()
        {
            InitializeComponent();

            InitLayoutControl();

            _summaryDesign = new SummaryModuleDesign();

            //_ic = new InfoConfig();

            //_ic.ZoomFactor = 1;
        }

        private void InitLayoutControl()
        {
            layoutControl1.UnRegisterFixedItemType(typeof(SimpleLabelItem));
            layoutControl1.UnRegisterFixedItemType(typeof(SimpleSeparator));
            layoutControl1.UnRegisterFixedItemType(typeof(EmptySpaceItem));
            layoutControl1.UnRegisterFixedItemType(typeof(SplitterItem));



            layoutControl1.RegisterFixedItemType(typeof(DesignEmpty));
            layoutControl1.RegisterCustomPropertyGridWrapper(typeof(DesignEmpty), typeof(DesignEmptyPropertiesWrapper));

            layoutControl1.RegisterFixedItemType(typeof(DesignLabel));
            layoutControl1.RegisterCustomPropertyGridWrapper(typeof(DesignLabel), typeof(DesignLabelPropertiesWrapper));

            layoutControl1.RegisterFixedItemType(typeof(DesignSplitter));
            layoutControl1.RegisterCustomPropertyGridWrapper(typeof(DesignSplitter), typeof(DesignSplitterPropertiesWrapper));
        }

        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _summaryDesign = JsonHelper.DeserializeObject<SummaryModuleDesign>(customContext);

            if (_summaryDesign != null)
            {

                LayoutControlEx.SetLayoutString(layoutControl1, _summaryDesign.LayoutFormats);

                FillFormats(_summaryDesign.ItemFormats);

                if (this.DesignMode == false)
                {
                    _curBizData = new BizDataItem();

                    ReloadData();
                }
            }

        }

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "概要信息";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideActionDesc.Add(InfoActionDefine.LoadInfo, "载入对应的概要信息显示，可根传递的数据项进行检索，使用数据项作为条件时，需要查询条件语句中使用[xxx]参数形式。");

            //_provideActionDesc.Add(InfoActionDefine.LoadSpedifyContext, "载入指定对象的内容并进行显示(可直接支持对象为DataRow和Dictionary类型，改类型必须存入infodata项目中)。");

            //_provideActionDesc.Add(InfoActionDefine.Setting, "设置信息显示的字体缩放比率。");

            //_designEvents.Add("", new EventAction("", ActionType.atFixed)); 
        }


        /// <summary>
        /// 刷新
        /// </summary>
        public override void RefreshModule()
        {

        }

        private void FillFormats(List<ItemFormat> ItemFormats)
        {
            foreach (ItemFormat itemFmt in ItemFormats)
            {
                BaseLayoutItem bli = layoutControl1.Items.FindByName(itemFmt.ItemName);

                DesignLabel dl = bli as DesignLabel;
                if (dl != null)
                {
                    dl.Formats = itemFmt.Formats;

                    dl.Formats.默认背景色 = dl.AppearanceItemCaption.BackColor;
                    dl.Formats.默认前景色 = dl.AppearanceItemCaption.ForeColor;
                }
            }
        }

        public override string ShowCustomDesign()
        {
            using (frmSummaryDesign design = new frmSummaryDesign())
            {
                design.ShowDesign(_summaryDesign, _dbQuery, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_summaryDesign);

            
            LayoutControlEx.SetLayoutString(layoutControl1, _summaryDesign.LayoutFormats);
            
            FillFormats(_summaryDesign.ItemFormats);

            _curBizData = new BizDataItem();

            ReloadData();

            return _customDesignFmt;
        }


        private void ReloadDictionary(Dictionary<string, object> dicts)
        {
            foreach (BaseLayoutItem bli in layoutControl1.Items)
            {
                DesignLabel dl = bli as DesignLabel;

                if (dl == null) continue;
                if (string.IsNullOrEmpty(dl.Formats.数据项名称)) continue;

                dl.Image = null;
                dl.AppearanceItemCaption.BackColor = dl.Formats.默认背景色;
                dl.AppearanceItemCaption.ForeColor = dl.Formats.默认前景色;

                if (dicts == null)
                {
                    dl.Text = " ";
                  
                    continue;
                }

                string showDisplay = "";

                bool isDataItem = dicts.ContainsKey(dl.Formats.数据项名称);
                if (isDataItem)
                {
                    string value = Convert.ToString(dicts[dl.Formats.数据项名称]);
                    showDisplay = value;

                    if (dl.Formats.文本格式.Count > 0)
                    {
                        int vIndex = dl.Formats.文本格式.FindIndex(T => T.数据值 == value);

                        if (vIndex >= 0)
                        {
                            DesignLabelFormatItem formatItem = dl.Formats.文本格式[vIndex];

                            dl.Image = Img24Resource.LoadImg(formatItem.图标名称);
                            showDisplay = formatItem.显示内容;

                            if (formatItem.背景色.Name != "0")
                            {
                                dl.AppearanceItemCaption.BackColor = formatItem.背景色;
                            }

                            if (formatItem.前景色.Name != "0")
                            {
                                dl.AppearanceItemCaption.ForeColor = formatItem.前景色;
                            }
                        }
                    }
                }

                if (string.IsNullOrEmpty(showDisplay)) showDisplay = " ";
                dl.Text = showDisplay;
            }
        }


        private IBizDataItem _curBizData = null;
        private void ReloadData()
        {
            //先判断_curBizData中是否含有Dictionary和DataRow类型的数据，如果有，则直接提取到_curBizData中

            foreach (KeyValuePair<string, object> kvSource in _curBizData)
            {
                Dictionary<string, object> dicData = kvSource.Value as Dictionary<string, object>;

                if (dicData != null)
                {
                    foreach (KeyValuePair<string, object> kv in dicData)
                    {
                        if (_curBizData.ContainsKey(kv.Key)) continue;
                        _curBizData.Add(kv.Key, kv.Value);
                    }
                }

                DataRow dr = kvSource.Value as DataRow;

                if (dr != null)
                {
                    foreach (DataColumn dc in dr.Table.Columns)
                    {
                        if (_curBizData.ContainsKey(dc.ColumnName)) continue;
                        _curBizData.Add(dc.ColumnName, dr[dc]);
                    }
                }

            }

            //如果配置了查询，则先重查询中获取数据
            if (string.IsNullOrEmpty(_summaryDesign.DBSource.查询语句) == false)
            {
                DataTable dtInfo = SqlHelper.GetDataSource(_summaryDesign.DBSource.查询语句, _summaryDesign.DBSource.数据源别名, _dbQuery, QueryParValueEvent);

                if (dtInfo != null && dtInfo.Rows.Count > 0)
                {
                    foreach (DataColumn dc in dtInfo.Columns)
                    {
                        if (_curBizData.ContainsKey(dc.ColumnName))
                        {
                            _curBizData[dc.ColumnName] = dtInfo.Rows[0][dc];
                        }
                        else
                        {
                            _curBizData.Add(dc.ColumnName, dtInfo.Rows[0][dc]);
                        }
                    }
                }
            }


            ReloadDictionary(_curBizData as Dictionary<string, object>);
        }
        
        
        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {
                switch (actName)
                {
                    case InfoActionDefine.LoadInfo:
                        if (bizDatas != null)
                        {
                            _curBizData = bizDatas[0];
                        }
                        else
                        {
                            _curBizData = new BizDataItem();
                        }
                        
                        //重载数据
                        ReloadData(); 

                        return true;

                        
                    default:
                        return false;
                }
                 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }
         
        
        public object QueryParValueEvent(string parName)
        {           
 
            //"申请识别码,患者识别码,申请ID,患者ID,用户ID,设备ID,科室ID,院区编码";
            switch (parName)
            {

                case "系统_用户ID":
                    return _userData.UserId;

                case "系统_用户账号":
                    return _userData.Account;

                case "系统_用户名称":
                    return _userData.Name;

                case "系统_设备ID":
                    return _stationInfo.DeviceId;

                case "系统_设备名称":
                    return _stationInfo.DeviceName;

                case "系统_科室ID":
                    return _stationInfo.DepartmentId;

                case "系统_科室名称":
                    return _stationInfo.DepartmentName;

                case "系统_房间ID":
                    return _stationInfo.RoomId;

                case "系统_房间名称":
                    return _stationInfo.RoomName;

                case "系统_院区编码":
                    return _stationInfo.DistrictCode;

                default:
                    if (_curBizData == null || _curBizData.Count <= 0) return null;

                    if (_curBizData.ContainsKey(parName))
                    {
                        return _curBizData[parName];
                    }

                    return null;
            }
        }


        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                //case WordProviderDataDefine.SelWordContext:
                //    return true;

                //case CaptureProviderDataDefine.Data_StudyData:
                //    return true;

                default:
                    return false;
            }
        }


        public override IBizDataItems QueryDatas(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                //case WordProviderDataDefine.SelWordContext://当前选择词句
                //    return _selWordDatas;

                default:
                    return null;
            }
        }

        private void SummaryControl_Load(object sender, EventArgs e)
        {

        }
    }
}
