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

namespace zlMedimgSystem.CTL.DataConvert
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(DataConvertControl), "Resources.dataconvert.ico")]
    public partial class DataConvertControl : DesignComponent, ISysBizModule, ISysDesign, IBizDataQuery
    {

        static public class DataConvertActionDefine
        {
            public const string RunConvert = "执行转换";
        }

        static public class DataConvertDataDefine
        {
            public const string ConvertData = "转换后数据";
        }

        private DataConvertModuleDesign _dataConvertDesign = null;

        public DataConvertControl()
        {
            InitializeComponent();

            _dataConvertDesign = new DataConvertModuleDesign();
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "数据转换";
            _description = "将数据项名称转换为所需的项目名称。";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideDataDesc.AddDataDescription(_moduleName, DataConvertDataDefine.ConvertData, "获取执行转换后的数据内容。");
            _provideActionDesc.Add(DataConvertActionDefine.RunConvert, "根据配置进行对应的数据项目转换。");
            //_provideActionDesc.Add(BehindCodeActionDefine.BehindRun, "动态执行后台函数调用,如果设置了执行标记，则根据执行标记执行对应的方法。");

            //_designEvents.Add(TimerEventDefine.Interval, new EventActionReleation(TimerEventDefine.Interval, ActionType.atSysFixedEvent));

        }


        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case DataConvertDataDefine.ConvertData:
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
                case DataConvertDataDefine.ConvertData:
                    return _curBizDatas;
                    
                default:
                    return null;
            }
        }


        private BizDataItems _curBizDatas = null;
        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {

                _curBizDatas = null;

                switch (actName)
                {
                    case DataConvertActionDefine.RunConvert:
                        if (bizDatas == null || bizDatas.Count <= 0) return false;

                        _curBizDatas = bizDatas as BizDataItems;

                        BizDataItem curbizData = _curBizDatas[0] as BizDataItem;

                        foreach (DataConvertItem dci in _dataConvertDesign.ConvertItems)
                        {
                            if (curbizData.ContainsKey(dci.SourceName))
                            {
                                object value = curbizData[dci.SourceName];
                                object convertValue = null;

                                curbizData.Remove(dci.SourceName);

                                switch(dci.ConvertType)
                                {
                                    case "Int16":
                                        if (value != null) convertValue = Convert.ToInt16(value);
                                        curbizData.Add(dci.ConvertName, convertValue);
                                        break;

                                    case "Int32":
                                        if (value != null) convertValue = Convert.ToInt32(value);
                                        curbizData.Add(dci.ConvertName, convertValue);
                                        break;

                                    case "Int64":
                                        if (value != null) convertValue = Convert.ToInt64(value);
                                        curbizData.Add(dci.ConvertName, convertValue);
                                        break;

                                    case "Double":
                                        if (value != null) convertValue = Convert.ToDouble(value);
                                        curbizData.Add(dci.ConvertName, convertValue);
                                        break;

                                    case "Single":
                                        if (value != null) convertValue = Convert.ToSingle(value);
                                        curbizData.Add(dci.ConvertName, convertValue);
                                        break;

                                    case "Decimal":
                                        if (value != null) convertValue = Convert.ToDecimal(value);
                                        curbizData.Add(dci.ConvertName, convertValue);
                                        break;

                                    case "String":
                                        if (value != null) convertValue = Convert.ToString(value);
                                        curbizData.Add(dci.ConvertName, convertValue);
                                        break;

                                    case "DateTime":
                                        if (value != null) convertValue = Convert.ToDateTime(value);
                                        curbizData.Add(dci.ConvertName, convertValue);
                                        break;
                                                      
                                    case "Boolean":
                                        if (value != null) convertValue = Convert.ToBoolean(value);
                                        curbizData.Add(dci.ConvertName, convertValue);
                                        break;

                                    case "Byte":
                                        if (value != null) convertValue = Convert.ToByte(value);
                                        curbizData.Add(dci.ConvertName, convertValue);
                                        break;

                                    case "Char":
                                        if (value != null) convertValue = Convert.ToChar(value);
                                        curbizData.Add(dci.ConvertName, convertValue);
                                        break;


                                    default:
                                        break;

                                }
                            }

                        }

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
 

        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _dataConvertDesign = JsonHelper.DeserializeObject<DataConvertModuleDesign>(customContext);
 
        }
 

        public override string ShowCustomDesign()
        {
            using (frmDataConvertModuleDesign design = new frmDataConvertModuleDesign())
            {
                if (design.ShowDataConvertModuleDesign(_dataConvertDesign, this) == false) return _customDesignFmt;
            }

            _customDesignFmt = JsonHelper.SerializeObject(_dataConvertDesign);
             

            return _customDesignFmt;
        }
    }
}
