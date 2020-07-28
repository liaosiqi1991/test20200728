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
using System.Transactions;
using System.Net;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.DataOper
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(DataOperControl), "Resources.dataoper.ico")]
    public partial class DataOperControl : DesignComponent, ISysBizModule, ISysDesign, IBizDataQuery
    {
        static public class DataOperActionDefine
        {
            public const string RunProcess = "执行处理项"; 
        }

        static public class DataOperDataDefine
        {
            public const string ProcessData = "处理后数据";
        }

        private DataOperModuleDesign _dataOperDesign = null;

        public DataOperControl()
        {
            InitializeComponent();

            _dataOperDesign = new DataOperModuleDesign();
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "数据处理";
            _description = "配置SQL操作语句，对数据进行相应处理。";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideDataDesc.AddDataDescription(_moduleName, DataOperDataDefine.ProcessData, "获取执行后的数据返回。");
            _provideActionDesc.Add(DataOperActionDefine.RunProcess, "执行数据处理项,如果指定了执行标记，则根据执行标记执行对应的处理项。"); 
            //_provideActionDesc.Add(BehindCodeActionDefine.BehindRun, "动态执行后台函数调用,如果设置了执行标记，则根据执行标记执行对应的方法。");

            //_designEvents.Add(TimerEventDefine.Interval, new EventActionReleation(TimerEventDefine.Interval, ActionType.atSysFixedEvent));

        }

        private BizDataItems _returnData = null;

        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case DataOperDataDefine.ProcessData:
                    return true;


                default:
                    return false;
            }
        }


        public override IBizDataItems QueryDatas(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case DataOperDataDefine.ProcessData:
                    return _returnData;

                default:
                    return null;
            }
        }


        private Dictionary<string, IDBQuery> _dbHelpers = null;
        private BizDataItem _curBizData = null;
        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {
                _returnData = null;

                if (_dbHelpers == null)
                {
                    _dbHelpers = new Dictionary<string, IDBQuery>();

                    foreach (DataOperItem doi in _dataOperDesign.DataOperItems)
                    {
                        if (_dbHelpers.ContainsKey(doi.DBAlias)) continue;

                        string strErr = "";
                        IDBQuery thridDbHelper = null;

                        thridDbHelper = SqlHelper.GetThridDBHelper(doi.DBAlias, _dbQuery, ref strErr);

                        if (thridDbHelper == null)
                        {
                            MessageBox.Show("数据处理项 [" + doi.ItemName + "] 对应数据源实例化失败:" + strErr, "提示");
                            return false;
                        }

                        _dbHelpers.Add(doi.DBAlias, thridDbHelper);
                    }
                }

                _curBizData = null;
                if (bizDatas != null)
                {
                    _curBizData = bizDatas[0] as BizDataItem;
                }

                IDBQuery curDBHelper = null;

                switch (actName)
                {
                    case DataOperActionDefine.RunProcess:

                        _returnData = new BizDataItems();

                        BizDataItem returnItem = new BizDataItem();

                        if (string.IsNullOrEmpty(tag))
                        {
                            using (TransactionScope ts = new TransactionScope())
                            {
                                foreach (DataOperItem doi in _dataOperDesign.DataOperItems)
                                {
                                    if (string.IsNullOrEmpty(doi.DBAlias))
                                    {
                                        curDBHelper = _dbQuery;
                                    }
                                    else
                                    {
                                        curDBHelper = _dbHelpers[doi.DBAlias];
                                    }

                                    DataTable dtResult = SqlHelper.GetDataSource(doi.ProcessContext, curDBHelper, QueryParValueEvent);

                                    returnItem.Add(doi.ReturnName, dtResult);
                                }

                                ts.Complete();
                            }
                        }
                        else
                        {
                            int index = _dataOperDesign.DataOperItems.FindIndex(T => T.ItemName == tag);
                            if (index < 0)
                            {
                                MessageBox.Show("未找到指定处理项的配置信息。", "提示");
                                return false;
                            }

                            DataOperItem doiProcess = _dataOperDesign.DataOperItems[index];

                            if (string.IsNullOrEmpty(doiProcess.DBAlias))
                            {
                                curDBHelper = _dbQuery;
                            }
                            else
                            {
                                curDBHelper = _dbHelpers[doiProcess.DBAlias];
                            }

                            DataTable dtResult = SqlHelper.GetDataSource(doiProcess.ProcessContext, curDBHelper, QueryParValueEvent);

                            returnItem.Add(doiProcess.ReturnName, dtResult);
                        }

                        _returnData.Add(returnItem);
                        
                        return true; 

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

        private object QueryParValueEvent(string parName)
        {
            switch (parName)
            {
                case "系统_申请ID":
                    if (_curBizData == null) return null;
                    return DataHelper.GetItemValueByApplyId(_curBizData);

                case "系统_患者ID":
                    if (_curBizData == null) return null;
                    return DataHelper.GetItemValueByPatientId(_curBizData);

                case "系统_申请识别码":
                    if (_curBizData == null) return null;
                    return DataHelper.GetItemValueByApplyCode(_curBizData);

                case "系统_患者识别码":
                    if (_curBizData == null) return null;
                    return DataHelper.GetItemValueByPatientCode(_curBizData);

                case "系统_患者姓名":
                    if (_curBizData == null) return null;
                    return DataHelper.GetItemValueByPatientName(_curBizData);

                case "系统_用户ID":
                    return _userData.UserId;

                case "系统_用户名称":
                    return _userData.Name;

                case "系统_用户账号":
                    return _userData.Account;

                case "系统_设备ID":
                    return _stationInfo.DeviceId;

                case "系统_设备名称":
                    return _stationInfo.DeviceName;

                case "系统_房间ID":
                    return _stationInfo.RoomId;

                case "系统_房间名称":
                    return _stationInfo.RoomName;

                case "系统_科室ID":
                    return _stationInfo.DepartmentId;

                case "系统_科室名称":
                    return _stationInfo.DepartmentName;

                case "系统_院区编码":
                    return _stationInfo.DistrictCode;

                case "系统_本地日期":
                    return DateTime.Now;

                case "系统_服务器日期":
                    DBModel dmDate = new DBModel(_dbQuery);
                    return dmDate.GetServerDate();

                case "系统_本机IP":
                    return Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();

                case "系统_本机名称":
                    return Dns.GetHostName();

                default:
                    if (_curBizData != null && _curBizData.Count > 0)
                    {
                        parName = parName.Replace("系统_", "");
                        if (_curBizData.ContainsKey(parName)) return _curBizData[parName];
                    }
                    return null;
            }
        }

        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _dataOperDesign = JsonHelper.DeserializeObject<DataOperModuleDesign>(customContext);

            LoadDesign();
        }

        private void LoadDesign()
        {
 
        }

        public override string ShowCustomDesign()
        {
            using (frmDataOperModuleDesign design = new frmDataOperModuleDesign())
            { 
                if (design.ShowDataOperModuleDesign(_dbQuery, _dataOperDesign, this) == false) return _customDesignFmt;
            }

            _customDesignFmt = JsonHelper.SerializeObject(_dataOperDesign);

            LoadDesign();

            return _customDesignFmt;
        }


    }
}
