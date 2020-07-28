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

namespace zlMedimgSystem.CTL.Info
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(InfoControl), "Resources.info.ico")]
    public partial class InfoControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {

        static private class InfoActionDefine
        {
            public const string LoadInfo = "载入数据信息";
            //public const string LoadSpedifyContext = "载入指定内容";
            public const string Setting = "信息设置";
        }


        private string _applyId = "";

        private InfoModuleDesign _infoDesign = null;
        private InfoConfig _ic = null;
        public InfoControl()
        {
            InitializeComponent();
            _infoDesign = new InfoModuleDesign();

            _ic = new InfoConfig();

            _ic.ZoomFactor = 1;
        }

        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _infoDesign = JsonHelper.DeserializeObject<InfoModuleDesign>(customContext);

            if (_infoDesign != null)
            {
                if (this.DesignMode)
                {
                    _curBizData = new BizDataItem();

                    ReloadData();
                }
            }
             
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "信息模块"; 

            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideActionDesc.Add(InfoActionDefine.LoadInfo, "载入对应的数据信息显示，可根传递的数据项进行检索，使用数据项作为条件时，需要查询条件语句中使用[xxx]参数形式。");
            //_provideActionDesc.Add(InfoActionDefine.LoadSpedifyContext, "载入指定对象的内容并进行显示(支持对象为:DataRow,Dictionary)，请求数据项如下："
            //                                        + System.Environment.NewLine
            //                                        + "infodata");

            _provideActionDesc.Add(InfoActionDefine.Setting, "设置信息显示的字体缩放比率。");

            //_designEvents.Add("", new EventAction("", ActionType.atFixed)); 
        }


        /// <summary>
        /// 刷新
        /// </summary>
        public override void RefreshModule()
        {

        }


        public override string ShowCustomDesign()
        {
            using (frmInfoDesign design = new frmInfoDesign())
            {
                design.ShowDesign(_infoDesign, _dbQuery, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_infoDesign);

            richTextBox1.Text = "";
            if (string.IsNullOrEmpty(_infoDesign.查询语句) == false)
            {
                _curBizData = new BizDataItem();

                ReloadData();
            }

            return _customDesignFmt;
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
            if (string.IsNullOrEmpty(_infoDesign.查询语句) == false)
            {
                DataTable dtInfo = SqlHelper.GetDataSource(_infoDesign.查询语句, _infoDesign.数据源别名, _dbQuery, QueryParValueEvent);

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
            
            int strSize = 18;
            string strFormatContext = @"{\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052{\fonttbl{\f0\fnil\fcharset134 \'cb\'ce\'cc\'e5;}}" +
                                       @"{\colortbl ;\red255\green104\blue104;\red19\green164\blue160;}" +
                                       @"{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\sl276\slmult1\lang2052\b\f0\fs" + strSize + " ";

            if (string.IsNullOrEmpty(_infoDesign.显示项目) == false)
            {
                foreach(string dItem in _infoDesign.显示项目.Split(','))
                {
                    if (string.IsNullOrEmpty(dItem)) continue;

                    if (_curBizData.ContainsKey(dItem))
                    {
                        string dataContext = SqlHelper.Nvl(_curBizData[dItem], "").Replace("\n", @" \par\cf0\fs" + strSize + " ");

                        strFormatContext = strFormatContext + @"\b\cf0\fs" + strSize + " " + dItem + ":" + @" \b0\cf0\fs" + strSize + " " + dataContext + @"\par";
                    }
                    else
                    {
                        strFormatContext = strFormatContext + @"\b\cf0\fs" + strSize + " " + dItem + ":" + @" \b0\cf0\fs" + strSize + " " + @"\par";
                    }
                }
            }
            else
            {

                foreach (KeyValuePair<string, object> item in _curBizData)
                {
                    string dataContext = SqlHelper.Nvl(item.Value, "").Replace("\n", @" \par\cf0\fs" + strSize + " ");

                    strFormatContext = strFormatContext + @"\b\cf0\fs" + strSize + " " + item.Key + ":" + @" \b0\cf0\fs" + strSize + " " + dataContext + @"\par";
                }
            }


            richTextBox1.Rtf = strFormatContext;
            richTextBox1.ZoomFactor = _ic.ZoomFactor;
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

                        ReloadData(); 

                        return true;

                    case InfoActionDefine.Setting:
                        ShowInfoConfig();

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

        private void ShowInfoConfig()
        {
            using (frmInfoConfig videoCfg = new frmInfoConfig())
            {
                if (videoCfg.ShowImageConfig(_ic, _moduleName, this))
                {
                    richTextBox1.ZoomFactor = _ic.ZoomFactor;
                }
            }
        }

        public override void ModuleLoaded()
        {
            _ic = InfoConfig.GetConfig(_moduleName);

            if (_ic.ZoomFactor <= 0) _ic.ZoomFactor = 1;

            richTextBox1.ZoomFactor = _ic.ZoomFactor;

            base.ModuleLoaded();
        }

    }
}
