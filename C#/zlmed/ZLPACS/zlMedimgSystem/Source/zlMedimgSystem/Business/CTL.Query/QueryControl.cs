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
using System.Net;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.Query
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(QueryControl), "Resources.query.ico")]
    public partial class QueryControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {

        static public class QueryActionDefine
        {
            public const string Query = "执行查询";
            public const string PopupQuery = "弹窗查询";
        }

        static public class QueryDataDefine
        {
            public const string QueryResult = "当前查询结果";
        }

        static public class QueryEventDefine
        {
            public const string QueryBefore = "查询前事件";
            public const string QueryAfter = "查询后事件";
        }

        private QueryModuleDesign _queryDesign = null;

        public QueryControl()
        {
            InitializeComponent();

            queryFace1.SimpleState = false;
            queryFace1.OnRequestSystemPar += RequestSystemPar;

            _queryDesign = new QueryModuleDesign();

        }

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "数据查询";
            _description = "根据不同数据来源，配置相应的查询内容及对应查询条件。";

            _provideActionDesc.Add(QueryActionDefine.Query, "执行数据查询。");
            _provideActionDesc.Add(QueryActionDefine.PopupQuery, "弹窗独立查询条件录入窗口。");

            _provideDataDesc.AddDataDescription(_moduleName, QueryDataDefine.QueryResult, "返回当前查询的结果数据，返回数据项如下："
                                                                                            + System.Environment.NewLine
                                                                                            + "querydbalias,querycfgformat,queryresult(Datatable对象)");

            _designEvents.Add(QueryEventDefine.QueryBefore, new EventActionReleation(QueryEventDefine.QueryBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueryEventDefine.QueryAfter, new EventActionReleation(QueryEventDefine.QueryAfter, ActionType.atSysFixedEvent)); 
        }

        public object RequestSystemPar(string parName)
        {
            //申请识别码,患者识别码,申请ID,患者ID,患者姓名,
            //用户ID,用户名称,设备ID,设备名称,房间ID,房间名称,科室ID,科室名称,院区编码,本地日期,服务器日期,本机IP,本机名称

            return SqlHelper.GetGeneralParValue(parName, _dbQuery, _userData, _stationInfo);
        }

        private string _queryDbAlias = "";
        private string _queryCfgFormat = "";
        private DataTable _queryTable = null;
        private bool ExecuteQuery(bool isPopupWindow = false)
        {
            if (DoActions(QueryEventDefine.QueryBefore, null) == false) return false;

            string strSql = "";
            Dictionary<string, object> pars = new Dictionary<string, object>();

            IDBQuery curDBQuery = _dbQuery;

            if (string.IsNullOrEmpty(_queryDesign.DBSourceAlias) == false)
            {
                string strErr = "";
                curDBQuery = SqlHelper.GetThridDBHelper(_queryDesign.DBSourceAlias, _dbQuery, ref strErr);
                if (curDBQuery == null)
                {
                    MessageBox.Show("获取数据访问接口产生错误：" + strErr, "提示");
                    return false;
                }
            }

            queryFace1.DBHelper = curDBQuery;
            
            if (isPopupWindow)
            {
                queryFace1.PopupFilter(out strSql, out pars);
            }
            else
            {
                queryFace1.Query.CreateQuerySql(out strSql, out pars);
            }

            if (string.IsNullOrEmpty(strSql)) return false;

            Dictionary<string, List<JsonFieldPro>> jsonFieldMap = null;
            strSql = SqlHelper.FmtJsonDb(strSql, out jsonFieldMap);

            _queryDbAlias = _queryDesign.DBSourceAlias;
            _queryCfgFormat = queryFace1.Query.SourceSqlFmt;
                       
            _queryTable = curDBQuery.ExecuteSQL(strSql, pars);
            
            DoActions(QueryEventDefine.QueryAfter, null);

            return true;
        }

 


        private bool DoActions(string actionName, object sender)
        {
            try
            {
                if (_designEvents.ContainsKey(actionName))
                {
                    return base.DoBindActions(_designEvents[actionName], sender);
                }

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }


        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {
                switch (actName)
                {
                    case QueryActionDefine.Query:  
                        return ExecuteQuery();

                    case QueryActionDefine.PopupQuery:
                        return ExecuteQuery(true);

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


        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case QueryDataDefine.QueryResult:
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
                case QueryDataDefine.QueryResult://方法当前查询到的数据结果
                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();

                    dataItem.Add(DataHelper.StdPar_QueryResult, _queryTable);
                    dataItem.Add(DataHelper.StdPar_QueryCfgFormat, _queryCfgFormat);
                    dataItem.Add(DataHelper.StdPar_QueryDbAlias, _queryDbAlias);

                    resultDatas.Add(dataItem);

                    return resultDatas;

                default:
                    return null;
            }
        }



        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _queryDesign = JsonHelper.DeserializeObject<QueryModuleDesign>(customContext);


            LoadDesign();
        }

        private void LoadDesign()
        {
            this.BackColor = Color.Transparent;

            if (_queryDesign != null)
            {
                queryFace1.DBHelper = _dbQuery;
                queryFace1.LoadSchemeFromString(_queryDesign.QueryConfig);

                this.BackColor = queryFace1.LayoutCore.Root.AppearanceGroup.BackColor;
            }
        }

        public override string ShowCustomDesign()
        {
            using (frmQueryDesign design = new frmQueryDesign())
            {
                if (design.ShowDesign(_queryDesign, _dbQuery, this) == false) return _customDesignFmt;
            }

            _customDesignFmt = JsonHelper.SerializeObject(_queryDesign);


            LoadDesign();

            return _customDesignFmt;
        }

        private void QueryControl_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}
