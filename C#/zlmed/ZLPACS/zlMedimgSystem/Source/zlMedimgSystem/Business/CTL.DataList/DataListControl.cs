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
using System.IO;
using zlMedimgSystem.BusinessBase;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.QueryDesign;
using System.Net;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace zlMedimgSystem.CTL.DataList
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(DataListControl), "Resources.datalist.ico")]
    public partial class DataListControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        private const string GridLayoutName = "_Layout.xml";
        static public class DataListActionDefine
        {
            public const string LoadData = "载入数据";
            public const string UpdateData = "更新数据";
            public const string UpdateSelRow = "更新选择行";
            public const string RemoveSelRow = "移除选择行";
            public const string RefreshData = "刷新数据";
        }

        static public class DataListDataDefine
        {
            public const string SelRow = "选择行数据";
        }

        static public class DataListEventDefine
        {
            public const string RowClick = "行单击事件";
            public const string CellClick = "单元格单击事件";
            public const string CellDblClick = "单元格双击事件";
            public const string FocusedRowChanged = "焦点行改变事件";
        }

        private DataListModuleDesign _dataListDesign = null;

        public DataListControl()
        {
            InitializeComponent();

            _dataListDesign = new DataListModuleDesign();
            _dataListDesign.AllowGroup = true;
            _dataListDesign.AllowRowNo = true;
            _dataListDesign.AllowFixColCfg = true;
            _dataListDesign.AllowShowColTitle = true;
            _dataListDesign.AllowFilter = true;
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "数据列表";
            _description = "根据DataTable中的数据进行列表显示。";

            _provideActionDesc.Add(DataListActionDefine.LoadData, "执行DataTable数据进行显示，请求数据项如下：" 
                                                                    + System.Environment.NewLine 
                                                                    + "querydbalias,querycfgformat,queryresult(DataTable对象)");
            _provideActionDesc.Add(DataListActionDefine.UpdateData, "更新数据显示。");
            _provideActionDesc.Add(DataListActionDefine.UpdateSelRow, "更新选择行的数据信息。");

            _provideDataDesc.AddDataDescription(_moduleName, DataListDataDefine.SelRow, "返回当前选择的行数据信息，返回数据项如下："
                                                                                            + System.Environment.NewLine
                                                                                            + "seldatarow(DataRow对象)");

            _designEvents.Add(DataListEventDefine.RowClick, new EventActionReleation(DataListEventDefine.RowClick, ActionType.atSysFixedEvent));
            _designEvents.Add(DataListEventDefine.CellClick, new EventActionReleation(DataListEventDefine.CellClick, ActionType.atSysFixedEvent));
            _designEvents.Add(DataListEventDefine.CellDblClick, new EventActionReleation(DataListEventDefine.CellDblClick, ActionType.atSysFixedEvent));
            _designEvents.Add(DataListEventDefine.FocusedRowChanged, new EventActionReleation(DataListEventDefine.FocusedRowChanged, ActionType.atSysFixedEvent));
        }

        private string _queryDbAlias = "";
        private string _queryCfgFormat = "";
        private DataTable _queryTable = null;


        private QueryCore _queryCore = null;

        private object RequestSystemPar(string parName)
        {
            return GetSystemParValue(parName, _curBizData);
        }



        private object GetSystemParValue(string parName, BizDataItem bizData)
        {
            //"申请识别码,患者识别码,申请ID,患者ID,患者姓名,用户ID,用户名称,设备ID,设备名称,
            //房间ID,房间名称,科室ID,科室名称,院区编码,本地日期,服务器日期,本机IP,本机名称";


            switch (parName)
            {
                case "系统_申请ID":
                    if (bizData == null) return null;
                    return DataHelper.GetItemValueByApplyId(bizData);

                case "系统_患者ID":
                    if (bizData == null) return null;
                    return DataHelper.GetItemValueByPatientId(bizData);

                case "系统_申请识别码":
                    if (bizData == null) return null;
                    return DataHelper.GetItemValueByApplyCode(bizData);

                case "系统_患者识别码":
                    if (bizData == null) return null;
                    return DataHelper.GetItemValueByPatientCode(bizData);

                case "系统_患者姓名":
                    if (bizData == null) return null;
                    return DataHelper.GetItemValueByPatientName(bizData);

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
                    if (bizData != null && bizData.Count > 0)
                    {
                        parName = parName.Replace("系统_", "");
                        if (bizData.ContainsKey(parName)) return bizData[parName];
                    }
                    return null;
            }
        }

        /// <summary>
        /// 更新数据列表
        /// </summary>
        /// <param name="dbAlias"></param>
        /// <param name="sourceSqlFmt"></param>
        /// <returns></returns>
        private bool UpdateDataList(string dbAlias, string sourceSqlFmt)
        {

            if (_queryCore == null)
            {
                _queryCore = new QueryCore();
     
                _queryCore.LoadFromString(sourceSqlFmt);

                _queryCore.OnRequestSystemPar -= RequestSystemPar;
                _queryCore.OnRequestSystemPar += RequestSystemPar;
            }

            string sql = "";
            Dictionary<string, object> pars = null;

            _queryCore.CreateQuerySql(out sql, out pars);

            if (string.IsNullOrEmpty(sql)) return false;



            IDBQuery curDBQuery = _dbQuery;

            if (string.IsNullOrEmpty(dbAlias) == false)
            {
                string strErr = "";
                curDBQuery = SqlHelper.GetThridDBHelper(dbAlias, _dbQuery, ref strErr);
                if (curDBQuery == null)
                {
                    MessageBox.Show("获取数据访问接口产生错误：" + strErr, "提示");
                    return false;
                }
            }
                         
            DataTable dtUpdate = curDBQuery.ExecuteSQL(sql, pars);
            if (dtUpdate == null || dtUpdate.Rows.Count <= 0) return true;

            string identifyName = "";

            if (dtUpdate.Columns.IndexOf("ROWID") >= 0)
            {
                identifyName = "ROWID";
            }
            else if (dtUpdate.Columns.IndexOf("KEY") >= 0)
            {
                identifyName = "KEY";
            }
            else if (dtUpdate.Columns.IndexOf("ID") >= 0)
            {
                identifyName = "ID";
            }


            if (string.IsNullOrEmpty(identifyName))
            {
                MessageBox.Show("查询结果尚未包含唯一标识字段（如ROWID,KEY,ID）。", "提示");
                return false;
            }

            DataTable dtSource = gridControl1.DataSource as DataTable;
            if (dtSource == null || dtSource.Rows.Count <= 0) return true;
         
            //更新列表信息
            foreach (DataRow drUpdate in dtUpdate.Rows)
            {
                DataRow[] drSelect = dtSource.Select(identifyName + "='" + SqlHelper.Nvl(drUpdate[identifyName], "") + "'");

                if (drSelect.Length > 0)
                {
                    foreach (DataRow drSource in drSelect)
                    {
                        foreach (DataColumn dc in dtSource.Columns)
                        {
                            if (dc.ColumnName == identifyName) continue;

                            if (dtUpdate.Columns.IndexOf(dc.ColumnName) < 0) continue;

                            drSource[dc.ColumnName] = drUpdate[dc.ColumnName];
                        }
                    }
                }
                else
                {
                    //增加数据...
                }
            }

            return true;
        }

        /// <summary>
        /// 更新选择行数据
        /// </summary>
        /// <returns></returns>
        private bool UpdateSelRow(string dbAlias, string sourceSqlFmt)
        {
            //如果列表没有或者没有选中数据，则直接退出
            if (gridView1.RowCount <= 0) return true;

            if (gridView1.FocusedRowHandle < 0) return true;


            if (_queryCore == null)
            {
                _queryCore = new QueryCore();

                _queryCore.LoadFromString(sourceSqlFmt);

                _queryCore.OnRequestSystemPar -= RequestSystemPar;
                _queryCore.OnRequestSystemPar += RequestSystemPar;
            }

            string sql = "";
            Dictionary<string, object> pars = null;

            _queryCore.CreateQuerySql(out sql, out pars);

            if (string.IsNullOrEmpty(sql)) return false;


            IDBQuery curDBQuery = _dbQuery;

            if (string.IsNullOrEmpty(dbAlias) == false)
            {
                string strErr = "";
                curDBQuery = SqlHelper.GetThridDBHelper(dbAlias, _dbQuery, ref strErr);
                if (curDBQuery == null)
                {
                    MessageBox.Show("获取数据访问接口产生错误：" + strErr, "提示");
                    return false;
                }
            }

            DataTable dtUpdate = curDBQuery.ExecuteSQL(sql, pars);
            if (dtUpdate == null || dtUpdate.Rows.Count <= 0) return true;

            string identifyName = "";

            if (dtUpdate.Columns.IndexOf("ROWID") >= 0)
            {
                identifyName = "ROWID";
            }
            else if (dtUpdate.Columns.IndexOf("KEY") >= 0)
            {
                identifyName = "KEY";
            }
            else if (dtUpdate.Columns.IndexOf("ID") >= 0)
            {
                identifyName = "ID";
            }


            if (string.IsNullOrEmpty(identifyName))
            {
                MessageBox.Show("查询结果尚未包含唯一标识字段（如ROWID,KEY,ID）。", "提示");
                return false;
            }

            DataTable dtSource = gridControl1.DataSource as DataTable;
            if (dtSource == null || dtSource.Rows.Count <= 0) return true;

            //更新列表信息
            DataRow selRow = gridView1.GetFocusedDataRow();
            if (SqlHelper.Nvl(selRow[identifyName], "") != SqlHelper.Nvl(dtUpdate.Rows[0][identifyName], "")) return true;
            

            foreach (DataColumn dc in dtSource.Columns)
            {
                if (dc.ColumnName == identifyName) continue;

                if (dtUpdate.Columns.IndexOf(dc.ColumnName) < 0) continue;

                selRow[dc.ColumnName] = dtUpdate.Rows[0][dc.ColumnName];
            }

            return true;
        }

        




        private BizDataItem _curBizData = null;
        private Dictionary<string, JsonFieldMapItem> _jsonFieldMap = null;
        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {
                switch (actName)
                {
                    case DataListActionDefine.LoadData:
                        if (bizDatas == null) return false;

                        _queryDbAlias = DataHelper.GetItemValueByQueryDBAlias(bizDatas[0]);
                        _queryCfgFormat = DataHelper.GetItemValueByQueryCfgFormat(bizDatas[0]);
                        _queryTable = DataHelper.GetItemValueByQueryResult(bizDatas[0]);

                        if (_queryTable == null) return false;

                        if (_jsonFieldMap == null)
                        {
                            SqlHelper.FmtJsonDb(_queryCfgFormat, out _jsonFieldMap);
                        }

                        // FmtJsonDb(strSql, out jsonFieldMap);

                        SqlHelper.JsonTableDataConvert(_queryTable, 0, _jsonFieldMap, 1);

                        gridControl1.DataSource = _queryTable;

                        RestoreGridLayout();

                        timerConvert.Enabled = true;
                        //DoJsonConvert();//后台转换时会产生异常

                        return true;

                    case DataListActionDefine.UpdateData://更新数据
                        if (string.IsNullOrEmpty(_queryCfgFormat)) return false;

                        if (bizDatas != null && bizDatas.Count > 0)
                        {
                            _curBizData = bizDatas[0] as BizDataItem;
                        }


                        UpdateDataList(_queryDbAlias, _queryCfgFormat);

                        break;

                    case DataListActionDefine.UpdateSelRow: //更新选择行
                        if (string.IsNullOrEmpty(_queryCfgFormat)) return false;

                        if (bizDatas != null && bizDatas.Count > 0)
                        {
                            _curBizData = bizDatas[0] as BizDataItem;
                        }

                        UpdateSelRow(_queryDbAlias, _queryCfgFormat);


                        break;

                    case DataListActionDefine.RefreshData://刷新数据

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


        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _dataListDesign = JsonHelper.DeserializeObject<DataListModuleDesign>(customContext);

            LoadDesign();
        }

        private void LoadDesign()
        {
            butFix.Visible = _dataListDesign.AllowFixColCfg;

            gridView1.OptionsView.ShowGroupPanel = _dataListDesign.AllowGroup;
            gridView1.OptionsView.ShowIndicator = _dataListDesign.AllowRowNo;
            gridView1.OptionsView.ShowAutoFilterRow = _dataListDesign.AllowFilter;
            gridView1.OptionsView.ShowColumnHeaders = _dataListDesign.AllowShowColTitle;
        }

        public override string ShowCustomDesign()
        {
            using (frmDataListModuleDesign design = new frmDataListModuleDesign())
            {
                if (design.ShowDataListModuleDesign(_dataListDesign, this) == false) return _customDesignFmt;
            }

            _customDesignFmt = JsonHelper.SerializeObject(_dataListDesign);

            LoadDesign();

            return _customDesignFmt;
        }


        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case DataListDataDefine.SelRow:
                    return true;

                default:
                    return false;
            }
        }

        private void ConfigBizData(BizDataItem bizData, DataRow dr)
        {
            //string applyId = "";
            //string patientId = "";
            //string applyCode = "";
            //string patientCode = "";
            //string patientName = "";
            //string imgKind = "";
            //string executeDeptId = "";
            //string examId = "";

            if (dr == null) return;

            //object value = null;

            //value = GetItemValue(dr, DataHelper.StdPar_ApplyId + ",申请ID");
            //applyId = (value == null) ? "" : value.ToString();
            //bizData.Add(DataHelper.StdPar_ApplyId, applyId);

            //value = GetItemValue(dr, DataHelper.StdPar_PatientId + ",患者ID,病人ID");
            //patientId = (value == null) ? "" : value.ToString();
            //bizData.Add(DataHelper.StdPar_PatientId, patientId);

            //value = GetItemValue(dr, DataHelper.StdPar_ApplyCode+ ",申请识别码"); 
            //applyCode = (value == null) ? "" : value.ToString();
            //bizData.Add(DataHelper.StdPar_ApplyCode, applyCode);

            //value = GetItemValue(dr, DataHelper.StdPar_PatientCode+ ",患者识别码,病人识别码"); 
            //patientCode = (value == null) ? "" : value.ToString();
            //bizData.Add(DataHelper.StdPar_PatientCode, patientCode);
            
            //value = GetItemValue(dr, DataHelper.StdPar_PatiName+ ",患者姓名,病人姓名"); 
            //patientName = (value == null) ? "" : value.ToString();
            //bizData.Add(DataHelper.StdPar_PatiName, patientName);

            //value = GetItemValue(dr, DataHelper.StdPar_ImageKind+ ",影像类别,检查类别"); 
            //imgKind = (value == null) ? "" : value.ToString();
            //bizData.Add(DataHelper.StdPar_ImageKind, imgKind);


            //value = GetItemValue(dr, DataHelper.StdPar_ExecuteDeptId+ ",执行科室ID,检查科室ID"); 
            //executeDeptId = (value == null) ? "" : value.ToString();
            //bizData.Add(DataHelper.StdPar_ExecuteDeptId, executeDeptId);


            //value = GetItemValue(dr, DataHelper.StdPar_ExamId+ ",执行项目ID,检查项目ID"); 
            //examId = (value == null) ? "" : value.ToString();
            //bizData.Add(DataHelper.StdPar_ExamId, examId);


            foreach(DataColumn dc in dr.Table.Columns)
            {
                if (bizData.ContainsKey(dc.ColumnName)) continue;

                bizData.Add(dc.ColumnName, dr[dc]);
            }

        }

        private object GetItemValue(DataRow dr, string columnName)
        {
            string[] columns = (columnName + ",").Split(',');
            foreach (string column in columns)
            {
                if (string.IsNullOrEmpty(column)) continue;

                if (dr.Table.Columns.IndexOf(column) >= 0)
                {
                    return dr[column];
                }
            }

            return null;
        }

        public override IBizDataItems QueryDatas(string dataIdentificationName)
        {
            BizDataItems resultDatas = null;
            BizDataItem dataItem = null;

            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case DataListDataDefine.SelRow://方法当前查询到的数据结果
                    if (gridView1.RowCount <= 0) return null;

                    DataRow drSel = gridView1.GetFocusedDataRow();

                    if (drSel == null) return null;

                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();
                                        
                    dataItem.Add(DataHelper.StdPar_SelDataRow, drSel);

                    ConfigBizData(dataItem, drSel);
                     
                    resultDatas.Add(dataItem);

                    return resultDatas;

                default:
                    return null;
            }
        }


        //public override void ModuleLoaded()
        //{
        //    base.ModuleLoaded();

        //    //恢复grid配置
        //    RestoreGridLayout();
        //}

        private void RestoreGridLayout()
        { 
            string gridLayoutFile = GetGridLayoutFile();

            if (File.Exists(gridLayoutFile))
            {
                //gridControl1.MainView.RestoreLayoutFromXml(gridLayoutFile);
                Personal.RestoreGridView(gridControl1.MainView as GridView, GetGridLayoutFile());
            }

            gridView1.OptionsView.ColumnAutoWidth = false;
        }

        private string GetGridLayoutFile()
        {
            return Dir.GetAppTempDir() + @"\" + Parent.TopLevelControl.Name + "_" + _moduleName + GridLayoutName;
        }
        public override void Terminated()
        {
            if (gridControl1.MainView != null)
            {

                //gridControl1.MainView.SaveLayoutToXml(GetGridLayoutFile());
                Personal.SaveGridView(gridControl1.MainView as GridView, GetGridLayoutFile());

            }

            base.Terminated();
        }

        //private void gridView1_DragObjectOver(object sender, DevExpress.XtraGrid.Views.Base.DragObjectOverEventArgs e)
        //{
        //    try
        //    {
        //        this.Text = (e.DropInfo.Index.ToString());

        //        if (e.DropInfo.Index == -1)
        //        {
        //            GridColumn gc = e.DragObject as GridColumn;
        //            if (gc != null) gc.Fixed = FixedStyle.Left;
        //        }

        //        if (e.DropInfo.Index <= -100)
        //        {
        //            GridColumn gc = e.DragObject as GridColumn;

        //            if (gc.GroupIndex >= 0) return;

        //            if (gc != null && gc.Fixed != FixedStyle.None)
        //            {
        //                gc.Fixed = FixedStyle.None;
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MsgBox.ShowException(ex, this);
        //    }
        //}


        private bool DoActions(string actionName, object sender, object eventArgs = null)
        {
            try
            {
                if (_designEvents.ContainsKey(actionName))
                {
                    return base.DoBindActions(_designEvents[actionName], sender, eventArgs);
                }

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }



        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridView1.RowCount <= 0) return;
                if (gridView1.FocusedRowHandle < 0) return;

                DoActions(DataListEventDefine.FocusedRowChanged, sender, e);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            { 
                DoActions(DataListEventDefine.RowClick, sender, e);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (_designEvents.ContainsKey(DataListEventDefine.CellClick) == false) return;
                
                DoActions(DataListEventDefine.CellClick, sender, e);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private GridHitInfo _hintInfo = null;
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                _hintInfo = gridView1.CalcHitInfo(e.X, e.Y);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_hintInfo == null) return;

                if (_designEvents.ContainsKey(DataListEventDefine.CellDblClick) == false) return;

                DoActions(DataListEventDefine.CellDblClick, sender, _hintInfo);

                _hintInfo = null;
            }
            catch (Exception ex)
            {
                _hintInfo = null;
                MsgBox.ShowException(ex, this);
            }
        }

        private void gridView1_TopRowChanged(object sender, EventArgs e)
        {
            try
            {
                ////SqlHelper.JsonTableDataConvert(gridControl1.DataSource as DataTable, gridView1.TopRowIndex, _jsonFieldMap);

                //for(int i = gridView1.TopRowIndex; i < gridView1.TopRowIndex + 100; i ++ )
                //{
                //    DataRow dr = gridView1.GetDataRow(i);

                //    if (dr == null) return;

                //    SqlHelper.JsonRowDataConvert(dr, _jsonFieldMap);
                //}
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                if (_dataListDesign == null || _dataListDesign.AllowRowNo == false) return;
                if (e.Info.IsRowIndicator && e.RowHandle > -1)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
            }
            catch
            {
                e.Info.DisplayText = "ERR";
            }
        }

        private void DataListControl_Resize(object sender, EventArgs e)
        {
            try
            {
                butFix.Top = 2;
                butFix.Left = this.Width - butFix.Width - 2;
            }
            catch{ }
        }

        private void butFix_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmFixedConfig fc = new frmFixedConfig())
                {
                    fc.ShowFixedConfig(gridControl1, this);
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void timerConvert_Tick(object sender, EventArgs e)
        {
            try
            {
                timerConvert.Enabled = false;

                //for (int i = 0; i < 100; i++)
                //{
                //    DataRow dr = gridView1.GetDataRow(i);

                //    if (dr == null) return;

                //    SqlHelper.JsonRowDataConvert(dr, _jsonFieldMap);
                //}
                DataTable dtConvert = gridControl1.DataSource as DataTable;
                SqlHelper.JsonTableDataConvert(dtConvert, 0, _jsonFieldMap, dtConvert.Rows.Count);

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

       
        //public class JsonConvertPar
        //{
        //    public DataTable Table = null;
        //    public Dictionary<string, List<JsonFieldPro>> JsonFieldMap = null;
        //}

        #region<后台json转换>
        //private void DoJsonConvert()
        //{

        //    JsonConvertPar jcp = new JsonConvertPar();
        //    jcp.Table = gridControl1.DataSource as DataTable;
        //    jcp.JsonFieldMap = _jsonFieldMap;

        //    BackgroundWorker bgWork = new BackgroundWorker();

        //    bgWork.DoWork += DoWork;
        //    bgWork.ProgressChanged += ProgessChanged;
        //    bgWork.RunWorkerCompleted += WorkerCompleted;

        //    bgWork.WorkerReportsProgress = false;
        //    bgWork.WorkerSupportsCancellation = true;

        //    bgWork.RunWorkerAsync(jcp);
        //}

        //private object objLockWork = new object();
        //private void DoWork(object sender, DoWorkEventArgs e)
        //{
        //    if (e.Argument == null)
        //    {
        //        return;
        //    }


        //    JsonConvertPar jcp = e.Argument as JsonConvertPar;
        //    if (jcp == null) return;

        //    try
        //    {
        //        lock (objLockWork)
        //        {
        //            SqlHelper.JsonTableDataConvert(jcp.Table, 101, jcp.JsonFieldMap, jcp.Table.Rows.Count);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("JSON转换失败", ex);
        //    }


        //}


        //private void ProgessChanged(object sender, ProgressChangedEventArgs e)
        //{

        //}

        //delegate void DelegateDoWorkMsg(Exception msg);
        //private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (e.Error != null)
        //    {
        //        //增加失败声音提示
        //        DoWorkMsg(e.Error);

        //        return;
        //    }

        //}

        //public void DoWorkMsg(Exception ex)
        //{
        //    if (this.InvokeRequired)//如果是在非创建控件的线程访问，即InvokeRequired=true
        //    {
        //        DelegateDoWorkMsg workMsg = new DelegateDoWorkMsg(DoWorkMsg);
        //        this.Invoke(workMsg, new object[] { ex });
        //    }
        //    else
        //    {
        //        MsgBox.ShowException(ex, this);
        //    }
        //}
        #endregion
    }
}
