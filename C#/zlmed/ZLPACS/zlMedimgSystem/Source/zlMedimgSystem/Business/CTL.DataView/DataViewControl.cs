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
using System.Net;

namespace zlMedimgSystem.CTL.DataView
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(DataViewControl), "Resources.dataview.ico")]
    public partial class DataViewControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        static public class DataViewActionDefine
        {
            public const string LoadData = "载入数据";
        }

        static public class DataViewDataDefine
        {
            public const string FormData = "界面数据";
        }

        static public class DataViewEventDefine
        {
            public const string DataChnage = "数据改变";
        }


        private DataViewModuleDesign _dataViewDesign = null;
        public DataViewControl()
        {
            InitializeComponent();

            _dataViewDesign = new DataViewModuleDesign();

            dataViewLayout1.OnRequestPar += QueryPar;
        }


        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "数据预览";
            _description = "根据查询的数据结果进行显示。";

            //_provideActionDesc.Add(DataListActionDefine.LoadData, "执行DataTable数据进行显示，请求数据项如下："
            //                                                        + System.Environment.NewLine
            //                                                        + "querydbalias,querycfgformat,queryresult(DataTable对象)");
            _provideActionDesc.Add(DataViewActionDefine.LoadData, "载入数据显示。");

            _provideDataDesc.AddDataDescription(_moduleName, DataViewDataDefine.FormData, "返回当前界面数据，返回数据项根据模块配置时的元素实例名称进行返回。");
                                                                                            //,其中固定返回的数据如下：
                                                                                            //+ System.Environment.NewLine
                                                                                            //+ "seldatarow(DataRow对象),[applyid,patientid,applycode,patientcode,patientname,imagekind,executedepartmentid,examid]");

            //_designEvents.Add(DataListEventDefine.RowClick, new EventActionReleation(DataListEventDefine.RowClick, ActionType.atSysFixedEvent));
            //_designEvents.Add(DataListEventDefine.CellClick, new EventActionReleation(DataListEventDefine.CellClick, ActionType.atSysFixedEvent));
            //_designEvents.Add(DataListEventDefine.CellDblClick, new EventActionReleation(DataListEventDefine.CellDblClick, ActionType.atSysFixedEvent));
            //_designEvents.Add(DataListEventDefine.FocusedRowChanged, new EventActionReleation(DataListEventDefine.FocusedRowChanged, ActionType.atSysFixedEvent));
        }


        private IBizDataItems _curBizDatas = null;
        public object QueryPar(string parName)
        {
            //"申请识别码,患者识别码,申请ID,患者ID,患者姓名,用户ID,用户名称,设备ID,设备名称,
            //房间ID,房间名称,科室ID,科室名称,院区编码,本地日期,服务器日期,本机IP,本机名称";


            switch (parName)
            {
                case "系统_申请ID":
                    if (_curBizDatas == null || _curBizDatas.Count <= 0) return null;
                    return DataHelper.GetItemValueByApplyId(_curBizDatas[0]);

                case "系统_患者ID":
                    if (_curBizDatas == null || _curBizDatas.Count <= 0) return null;
                    return DataHelper.GetItemValueByPatientId(_curBizDatas[0]);

                case "系统_申请识别码":
                    if (_curBizDatas == null || _curBizDatas.Count <= 0) return null;
                    return DataHelper.GetItemValueByApplyCode(_curBizDatas[0]);

                case "系统_患者识别码":
                    if (_curBizDatas == null || _curBizDatas.Count <= 0) return null;
                    return DataHelper.GetItemValueByPatientCode(_curBizDatas[0]);

                case "系统_患者姓名":
                    if (_curBizDatas == null || _curBizDatas.Count <= 0) return null;
                    return DataHelper.GetItemValueByPatientName(_curBizDatas[0]);

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
                    if (_curBizDatas != null && _curBizDatas.Count > 0)
                    {
                        parName = parName.Replace("系统_", "");
                        if (_curBizDatas[0].ContainsKey(parName)) return _curBizDatas[0][parName];
                    }
                    return null;
            }
        }

        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case DataViewDataDefine.FormData:
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
                case DataViewDataDefine.FormData://方法当前查询到的数据结果

                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();

                    foreach (ViewItem vi in dataViewLayout1.LayoutControls)
                    {
                        if (vi.ReleationInstance == null) continue;

                        object value = null;
                        switch(vi.ControlType)
                        {
                            case ViewControlType.Lab:
                                value = (vi.ReleationInstance as Label).Text;

                                value = (value + "-").Split('-')[0];

                                break;

                            case ViewControlType.Txt:
                                value = (vi.ReleationInstance as TextBox).Text;

                                value = (value + "-").Split('-')[0];

                                break;

                            case ViewControlType.Cbx:
                                
                                value = (vi.ReleationInstance as ComboBox).SelectedValue;
                                if (value == null) value = (vi.ReleationInstance as ComboBox).Text;

                                value = (value + "-").Split('-')[0];

                                break;

                            case ViewControlType.Dtp:
                                value = (vi.ReleationInstance as DateTimePicker).Value;                                 

                                break;

                            case ViewControlType.Checkbox:
                                value = (vi.ReleationInstance as CheckBox).Checked; 

                                break;

                            default:
                                break;

                        }
                        

                        dataItem.Add(vi.InstanceName, value);
                    } 
                     
                    if (dataViewLayout1.HideBindDatas != null)
                    {
                        foreach(KeyValuePair<string, object> kv in dataViewLayout1.HideBindDatas)
                        {
                            dataItem.Add(kv.Key, kv.Value);
                        }
                    }

                    resultDatas.Add(dataItem);

                    return resultDatas;

                default:
                    return null;
            }
        }


        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {
                switch (actName)
                {
                    case DataViewActionDefine.LoadData:
                        if (bizDatas == null) return false;

                        _curBizDatas = bizDatas;
                                    
                        dataViewLayout1.BindDataView(_dbQuery, _dataViewDesign.DataFrom, _dataViewDesign.DBSourceAlias);

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


        //public override void ModuleLoaded()
        //{
        //    base.ModuleLoaded();


        //    DataTable dtBind = SqlHelper.GetDataSource(_dataViewDesign.DataFrom, _dataViewDesign.DBSourceAlias, _dbQuery, QueryPar);

        //    dataViewLayout1.BindDataView(dtBind);
        //}


        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _dataViewDesign = JsonHelper.DeserializeObject<DataViewModuleDesign>(customContext);
            
            LoadDesign();
        }

        private void LoadDesign()
        {
            this.BackColor = Color.Transparent;

            if (_dataViewDesign != null)
            {
                IDBQuery curDBQuery = _dbQuery;

                if (string.IsNullOrEmpty(_dataViewDesign.DBSourceAlias) == false)
                {
                    string strErr = "";
                    curDBQuery = SqlHelper.GetThridDBHelper(_dataViewDesign.DBSourceAlias, _dbQuery, ref strErr);

                    if (curDBQuery == null)
                    {
                        MessageBox.Show("获取数据访问接口产生错误：" + strErr, "提示");
                        return;
                    }
                }

                dataViewLayout1.DBHelper = _dbQuery;
                dataViewLayout1.ThridDBHelper = curDBQuery;

                dataViewLayout1.LoadLayout(_dataViewDesign.Items, _dataViewDesign.LayoutFmt);
            }
        }

        public override string ShowCustomDesign()
        {
            using (frmDataViewModuleDesign design = new frmDataViewModuleDesign())
            {
                design.OnRequestPar += QueryPar;
                if (design.ShowDataViewModuleDesign(_dbQuery, _dataViewDesign, this) == false) return _customDesignFmt;
            }

            _customDesignFmt = JsonHelper.SerializeObject(_dataViewDesign);
            
            LoadDesign();

            return _customDesignFmt;
        }

    }
}
