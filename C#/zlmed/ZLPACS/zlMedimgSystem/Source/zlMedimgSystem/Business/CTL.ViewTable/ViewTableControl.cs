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

namespace zlMedimgSystem.CTL.ViewTable
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(ViewTableControl), "Resources.ViewTableControl.ico")]
    
    public partial class ViewTableControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        #region 公共类和枚举        

        static public class ViewTableProviderEventDefine
        {
            public const string Event_AfterShow = "显示信息后事件";
            public const string Event_AfterChangeRow = "切换选择行事件";
        }

        static public class ViewTableProviderDataDefine
        {
            public const string Data_Table = "表格数据";
            public const string Data_SelectedRow = "当前选择行";
        }

        static public class ViewTableProviderActionDefine
        {
            public const string Action_LoadData = "加载数据";
            
        }

        public static class ViewTableDataNameDefi
        {
            public const string ViewTable = "表格显示";
        }

        #endregion

        #region 控件事件
        public delegate void FocusedRowChangedHandle(string strOrderID);

        public event FocusedRowChangedHandle UserControlFocusedRowChanged;

        #endregion

        #region 私有变量
        
        private ViewTableDesign _viewTableDesign = null;
        private DataTable _dtSource = null;        
        private Dictionary<string, string> _dicApplyID = new Dictionary<string, string>();

        private object _hisServerCfgData = null;    //仅仅是传递用

        bool isRefreshing = false;
        #endregion

        #region 构造函数
        public ViewTableControl()
        {
            InitializeComponent();
            _viewTableDesign = new ViewTableDesign();
        }
        #endregion

        #region 业务模块需要实现的方法
        //***********************************************************************************************
        //业务模块需要实现的方法
        //***********************************************************************************************

        /// <summary>
        /// 初始化模块基本信息，如模块名称，提供的action，支持哪些按钮的可见性配置，包含哪些事件等
        /// </summary>
        protected override void InitBaseInfo()
        {
            _multiInstance = true;            
            _moduleName = "表格数据显示";            
            
            _provideActionDesc.Add(ViewTableProviderActionDefine.Action_LoadData, "加载查询结果数据");           

            //申请单预览打印后面考虑
            //_provideActions.Add("检查报到", "定位行的功能描述");

            _provideDataDesc.Add(_moduleName + "." + ViewTableProviderDataDefine.Data_Table, "列表中的数据");
            _provideDataDesc.Add(_moduleName + "." + ViewTableProviderDataDefine.Data_SelectedRow, "当前选中行");


            _designEvents.Add(ViewTableProviderEventDefine.Event_AfterShow, new EventActionReleation(ViewTableProviderEventDefine.Event_AfterShow, ActionType.atSysFixedEvent));
            _designEvents.Add(ViewTableProviderEventDefine.Event_AfterChangeRow, new EventActionReleation(ViewTableProviderEventDefine.Event_AfterChangeRow, ActionType.atSysFixedEvent));
            
            //_staConfig = new JStationConfig();
            //StationConfigModel scm = new StationConfigModel(_dbQuery);
            //_staConfig = scm.GetStationInfo(Dns.GetHostName());

        }

        /// <summary>
        /// 模块刷新操作
        /// </summary>
        public override void RefreshModule()
        {
            //RefreshList("Select * from 影像检查信息 WHERE 报到日期>SYSDATE-100");
        }

        /// <summary>
        /// 获取多个数据
        /// 提供数据检索处理，返回bizdataitems给其他业务模块
        /// </summary>
        /// <param name="dataIdentificationName"></param>
        /// <returns></returns>
        public override IBizDataItems QueryDatas(string dataIdentificationName)
        {
            BizDataItems bdis = new BizDataItems();
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            try
            {
                switch (dataName)
                {
                    case ViewTableProviderDataDefine.Data_SelectedRow:

                        if(_dtSource is null)
                        {
                            bdis = null;
                        }
                        else
                        {
                            BizDataItem bi = new BizDataItem();
                            bi.Add("数据表格", _dtSource);
                            KeyValuePair<string, string> kvp = _dicApplyID.FirstOrDefault();
                            bi.Add(kvp.Key, kvp.Value);
                            if(_hisServerCfgData !=null)
                            {
                                bi.Add("HIS服务配置", _hisServerCfgData);
                            }
                            bdis.Add(bi);
                        }                        
                        break;
                    case ViewTableProviderDataDefine.Data_Table:
                        break;
                    default:
                        break; ;
                }
                return bdis;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return null;
            }
        }
         

        /// <summary>
        /// 判断数据是否存在
        /// </summary>
        /// <param name="dataIdentificationName"></param>
        /// <returns></returns>
        public override bool HasData(string dataIdentificationName)
        {           
            try
            {
                string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

                switch (dataName)
                {
                    case ViewTableProviderDataDefine.Data_Table:                       
                    case ViewTableProviderDataDefine.Data_SelectedRow:
                        return true;

                    default:
                        return false;
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
            
        }

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

        public override bool ExecuteAction(string callModuleName, ISysDesign callModuleInstance, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {
                switch (actName)
                {
                    case ViewTableProviderActionDefine.Action_LoadData:
                        if (bizDatas == null) return false;

                        if(bizDatas.Count ==1)
                        {
                            IBizDataItem bd = bizDatas[0];
                            //先提取HIS服务配置，然后再做其他事情，避免_hisServerCfgData为空
                            if (bd.ContainsKey("HIS服务配置"))
                            {
                                _hisServerCfgData = bd["HIS服务配置"];
                            }
                            else
                            {
                                _hisServerCfgData = null;
                            }
                            if (bd.ContainsKey("查询结果"))
                            {
                                DataTable dt = bd["查询结果"] as DataTable;
                                DataTable  rdt = CustomizeDT(dt);
                                RefreshTable(rdt);                                
                            }                            
                        }
                        
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

            _viewTableDesign = JsonHelper.DeserializeObject<ViewTableDesign>(customContext);

            if (_viewTableDesign.ViewTableCfg != null)
            {
                InitUserApplySearch(_viewTableDesign);
            }

            SyncDesignEventsByButtons();
        }

        /// <summary>
        /// 显示自定义窗口
        /// </summary>
        /// <returns></returns>
        public override string ShowCustomDesign()
        {
            frmViewTableDesign design = new frmViewTableDesign();
            if (design.ShowDesign(_viewTableDesign, this) == true)
            {           
                _customDesignFmt = JsonHelper.SerializeObject(_viewTableDesign);

                if (_viewTableDesign.ViewTableCfg != null)
                {
                    InitUserApplySearch(_viewTableDesign);
                }

                SyncDesignEventsByButtons();
            }
            return _customDesignFmt;
        }
        #endregion

        #region 公共方法
        public void RefreshTable(DataTable dt)
        {
            isRefreshing = true;
            try
            {
                _dtSource = dt;
                gridTable.DataSource = null;
                gridView.Columns.Clear();
                
                gridTable.DataSource = dt;

                gridView.BestFitColumns();
                ShowTableImage();                
            }
            finally
            {
                isRefreshing = false;                
            }
            //gridView.RestoreLayoutFromXml("D:\\AAA");  //绑定数据的，无法记录表格布局？
        }

        #endregion

        #region 私有方法
        private void ShowTableImage()
        {
                                       
            for(int i =0;i<gridView.Columns.Count;i++)
            {
                if (gridView.Columns[i].ColumnType == typeof(byte[]))
                {
                    gridView.Columns[i].Width = 20;
                }
            }
            return;
        }

        private void ViewTableControl_Resize(object sender, EventArgs e)
        {
            panelTable.Left = 0;
            panelTable.Top = 0;
            panelTable.Width = this.Width ;
            panelTable.Height = this.Height ;
            gridTable.Left = 0;
            gridTable.Top = 0;
            gridTable.Width = panelTable.Width;
            gridTable.Height = panelTable.Height;
        }
        #endregion

        private  DataTable CustomizeDT(DataTable dt)
        {

            if (dt == null) return dt;

            DataTable rdt = new DataTable();
            rdt = dt;
            int iColCount=0;
            try
            {                
                for(int i =0; i<_viewTableDesign.ViewTableCfg.Count;i++)
                {
                    if (rdt.Columns.Contains(_viewTableDesign.ViewTableCfg[i].列名称))
                    {
                        rdt.Columns[_viewTableDesign.ViewTableCfg[i].列名称].SetOrdinal(iColCount);                        
                        rdt.Columns[_viewTableDesign.ViewTableCfg[i].列名称].ColumnMapping =( _viewTableDesign.ViewTableCfg[i].是否显示 == false)? MappingType.Hidden:MappingType.Element;
                       
                        if(_viewTableDesign.ViewTableCfg[i].列名称 != _viewTableDesign.ViewTableCfg[i].列标题)
                        {
                            rdt.Columns[_viewTableDesign.ViewTableCfg[i].列名称].Caption = _viewTableDesign.ViewTableCfg[i].列标题;                           
                        }
                        rdt.Columns[_viewTableDesign.ViewTableCfg[i].列名称].ExtendedProperties.Add(1, 1);
                        iColCount++;
                    }                    
                }

                for (int i=0;i<rdt.Columns.Count ;i++)
                {
                    if(rdt.Columns[i].ExtendedProperties.Contains(1)==false && rdt.Columns[i].ColumnMapping == MappingType.Hidden)
                    {
                        rdt.Columns[i].SetOrdinal(iColCount);
                        iColCount++;
                    }                    
                }

                for(int i=rdt.Columns.Count -1;i>=iColCount; i--)
                {
                    rdt.Columns.RemoveAt(i);                    
                }
                                        
                return rdt;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return rdt;
            }
        }
        private void SyncDesignEventsByButtons()
        {
            //foreach (ViewTableItemConfig asic in _viewTableDesign.ViewTableCfg)
            //{
            //    if (_designEvents.ContainsKey(asic.列名称) == false)
            //    {
            //        _designEvents.Add(asic.列名称, new EventActionReleation(asic.列名称, ActionType.atSysCustomEvent));
            //    }
            //}

            List<string> keys = new List<string>(_designEvents.Keys);

            for (int i = keys.Count - 1; i >= 0; i--)
            {
                //固定事件不允许删除
                if (_designEvents[keys[i]].ActType == ActionType.atSysFixedEvent) continue;

                
                    //未找到对应按钮
                    _designEvents.Remove(keys[i]);
               
            }
        }

        protected void InitUserApplySearch(ViewTableDesign viewTableDesign)
        {
            DataTable dt =  new DataTable();
            try
            {
                //根据条件，创建一个空的datatable
                for(int i = 0;i<_viewTableDesign.ViewTableCfg.Count;i++)
                {
                    dt.Columns.Add(_viewTableDesign.ViewTableCfg[i].列标题);
                }
                RefreshTable(dt);               
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void ViewTableControl_Load(object sender, EventArgs e)
        {           
            
            gridTable.DataSource = null;
            gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void gridView_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {            
            if (this.gridView.RowCount == 0)
            {
                string str = "无数据，请调整检索条件后重新查询。";
                Font f = new Font("宋体", 10, FontStyle.Bold);
                Rectangle r = new Rectangle(e.Bounds.Left + 5, e.Bounds.Top + 5, e.Bounds.Width - 5, e.Bounds.Height - 5);
                e.Graphics.DrawString(str, f, Brushes.Black, r);
            }
            
        }

        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            return;
        }

        private void ViewTableControl_Layout(object sender, LayoutEventArgs e)
        {
            //gridView.SaveLayoutToXml("D:\\AAA");
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string strApplyID;            

            if (gridView.GetSelectedRows().Length == 0 ) return;
            try
            {
                int intSelRow = gridView.GetSelectedRows()[0];
                if (intSelRow < 0)
                    return;
                DevExpress.XtraGrid.Columns.GridColumn gc = new DevExpress.XtraGrid.Columns.GridColumn();
                _dicApplyID.Clear();
                if (gridView.GetRowCellValue(intSelRow, "申请ID") is null)
                {
                    _dicApplyID.Add("医嘱ID", gridView.GetRowCellValue(intSelRow, "医嘱ID").ToString());
                }
                else
                {
                    _dicApplyID.Add("申请ID", gridView.GetRowCellValue(intSelRow, "申请ID").ToString());
                }
              
                //触发内部事件
                if (UserControlFocusedRowChanged != null)
                {
                    KeyValuePair<string, string> kvp = _dicApplyID.FirstOrDefault();
                    UserControlFocusedRowChanged(kvp.Value);
                }

                //没有对应的自定义事件配置
                if (_designEvents.ContainsKey(ViewTableProviderEventDefine.Event_AfterChangeRow) == false) return;
                EventActionReleation ea = _designEvents[ViewTableProviderEventDefine.Event_AfterChangeRow];
                DoActions(_designEvents[ViewTableProviderEventDefine.Event_AfterChangeRow], sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
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

        private void gridTable_Click(object sender, EventArgs e)
        {

        }
    }
}
