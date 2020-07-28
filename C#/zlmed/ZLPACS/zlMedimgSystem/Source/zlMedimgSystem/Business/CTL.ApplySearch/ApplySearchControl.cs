using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using zlMedimgSystem.Design;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using zlMedimgSystem.ExtInterface;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.HardWare;
using zlMedimgSystem.BusinessBase;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors;




namespace zlMedimgSystem.CTL.ApplySearch
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(ApplySearchControl), "Resources.funnel.ico")]
    
    public partial class ApplySearchControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        #region 公共类和枚举
        /// <summary>
        /// 数据定义
        /// </summary>
        static public class ApplySearchProviderDataDefine
        {
            public const string Query = "查询结果数据";

        }

        /// <summary>
        /// 动作定义
        /// </summary>
        static public class ApplySearchProviderActionDefine
        {
            public const string Action_Query = "查询";
            public const string Action_Clear = "全清";
            public const string Action_PriDay = "前一天";
            public const string Action_NextDay = "后一天";
            public const string Action_Today = "今天";
            public const string Action_NearOneDay = "近一天";
            public const string Action_NearThreeDay = "近三天";

        }

        /// <summary>
        /// 事件定义
        /// </summary>
        static public class ApplySearchProviderEventDefine
        {
            public const string Event_QueryDone = "完成查询";           
        }

        #endregion

        #region 私有属性
        private const string Const_Data_SearchResult = "检索结果";

        private IApply _applyHISDB = null;      //Iapply接口的实例，连接HIS数据库
        private ApplyModel __applyModel = null;  //连接PACS数据库        
        private JStationConfig _staConfig = null;   //站点信息

        private DataTable _dtHIS = null;
        private DataTable _dtPACS = null;

        private BizDataItems _bdiPacs = null;

        private string _strOrderID;      //医嘱ID
        private string _申请ID;

        private ApplyData _applyData;   //申请信息
        private PatientData _patData;   //病人信息        
        private frmApplyScan _applyScanForm; // 扫描窗口

        private bool IsPacs = true; // 是否PACS，如果不是，那就是HIS

        private HisServerModel _hisServerModel = null;
        private HisServerCfgData _hisServerCfgData = null;        

        private ApplySearchDesign _applySearchDesign = null;

        private JStationConfig StaConfig
        {
            get
            {
                if (_staConfig == null)
                {
                    StationConfigModel sfm = new StationConfigModel(_dbQuery);
                    _staConfig = sfm.GetStationInfo(Dns.GetHostName());
                }
                return _staConfig;
            }
        }

        private IApply ApplyHISDB
        {
            get
            {
                if (_applyHISDB == null)
                {
                    InitApplyHISDB();
                }
                return _applyHISDB;
            }
        }

        private ApplyModel _applyModel
        {
            get
            {
                if (__applyModel == null)
                {                    
                    __applyModel = new ApplyModel(_dbQuery);
                }
                return __applyModel;
            }
        }

        private const string APPLYSEARCH_EVENT_TABLECLICK = "数据列表单击事件";
        #endregion

        #region 构造函数
        public ApplySearchControl()
        {
            InitializeComponent();

            _applySearchDesign = new ApplySearchDesign();
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
            _moduleName = "申请检索模块";

            ////_moduleStyles = new string[] { "样式一", "样式二" };

            _provideActionDesc.Add(ApplySearchProviderActionDefine.Action_Clear , "清空录入的检索条件");
            _provideActionDesc.Add(ApplySearchProviderActionDefine.Action_Query , "开始检索数据，会触发“查询完成”动作");
            _provideActionDesc.Add(ApplySearchProviderActionDefine.Action_PriDay, "前一天");
            _provideActionDesc.Add(ApplySearchProviderActionDefine.Action_NextDay, "后一天");
            _provideActionDesc.Add(ApplySearchProviderActionDefine.Action_Today, "今天");
            _provideActionDesc.Add(ApplySearchProviderActionDefine.Action_NearOneDay, "最近一天");
            _provideActionDesc.Add(ApplySearchProviderActionDefine.Action_NearThreeDay, "最近三天");

            _provideDataDesc.AddDataDescription(_moduleName, ApplySearchProviderDataDefine.Query, "从检查申请和三方HIS中检索到的结果数据.");           

            _designEvents.Add(ApplySearchProviderEventDefine.Event_QueryDone, new EventActionReleation(ApplySearchProviderEventDefine.Event_QueryDone, ActionType.atSysFixedEvent));           
        }

        /// <summary>
        /// 模块刷新操作
        /// </summary>
        public override void RefreshModule()
        {
            //base.RefreshModule();
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
                    case ApplySearchProviderDataDefine.Query:                        
                        DataTable dt =  QueryApplyDatas(dataIdentificationName);                                               
                        BizDataItem bi = new BizDataItem();
                        bi.Add("查询结果", dt);
                        if(_hisServerCfgData !=null)
                        {
                            bi.Add("HIS服务配置", _hisServerCfgData);
                        }                            
                        bdis.Add(bi);
                                                                                         
                        break;
                    default:
                        break; ;
                }
                return bdis;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return null;
            }
        }
       
        /// <summary>
        /// 执行动作
        /// 根据配置执行对应的方法
        /// </summary>
        /// <param name="callModuleName"></param>
        /// <param name="actName"></param>
        /// <param name="tag"></param>
        /// <param name="dataName"></param>
        /// <returns></returns>        
        public override bool ExecuteAction(string callModuleName, ISysDesign callModuleInstance, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {
                switch (actName)
                {
                    case ApplySearchProviderActionDefine.Action_Query:
                        //申请检索的查询不需要做什么操作，直接触发Event_QueryDone事件，这个事件对应的动作中，再去查数据
                        DoActions(_designEvents[ApplySearchProviderEventDefine.Event_QueryDone], sender);
                        break;
                    case ApplySearchProviderActionDefine.Action_Clear:      //全清
                        ClearControls();
                        break;
                    case ApplySearchProviderActionDefine.Action_PriDay:     //前一天
                    case ApplySearchProviderActionDefine.Action_NextDay:    //后一天
                    case ApplySearchProviderActionDefine.Action_Today:      //今天
                    case ApplySearchProviderActionDefine.Action_NearOneDay: //近一天
                    case ApplySearchProviderActionDefine.Action_NearThreeDay: //近三天
                        ChangeDateControl(actName, tag);
                        break;                                            
                    default:
                        break;
                }
                return true;

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        /// <summary>
        /// 判断数据是否存在
        /// </summary>
        /// <param name="dataIdentificationName"></param>
        /// <returns></returns>
        public override bool HasData(string dataIdentificationName)
        {            
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case ApplySearchProviderDataDefine.Query:
                    return true;                

                default:
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


        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _applySearchDesign = JsonHelper.DeserializeObject<ApplySearchDesign>(customContext);            

            if (_applySearchDesign.ApplySearchCfg != null)
            {
                InitUserApplySearch(_applySearchDesign);
            }

            SyncDesignEventsByButtons();
        }

        /// <summary>
        /// 显示自定义窗口
        /// </summary>
        /// <returns></returns>
        public override string ShowCustomDesign()
        {
            frmApplySearchDesign design = new frmApplySearchDesign();
            if (design.ShowDesign(_applySearchDesign, this,_dbQuery)==true )
            {            
                _customDesignFmt = JsonHelper.SerializeObject(_applySearchDesign);
            
                if (_applySearchDesign.ApplySearchCfg != null)
                {
                    InitUserApplySearch(_applySearchDesign);
                }

                SyncDesignEventsByButtons();
            }
            return _customDesignFmt;
        }


        private void SyncDesignEventsByButtons()
        {
            foreach (ApplySearchItemConfig  asic in _applySearchDesign.ApplySearchCfg)
            {
                if ((asic.控件类型 == ASControlType.asct功能按钮  || asic.控件类型== ASControlType.asct条件按钮 )&& _designEvents.ContainsKey(asic.控件名称) == false)
                {
                    _designEvents.Add(asic.控件名称, new EventActionReleation(asic.控件名称, ActionType.atSysCustomEvent));
                }
            }

            List<string> keys = new List<string>(_designEvents.Keys);

            for (int i = keys.Count - 1; i >= 0; i--)
            {
                //固定事件不允许删除
                if (_designEvents[keys[i]].ActType == ActionType.atSysFixedEvent) continue;

                if (_applySearchDesign.ApplySearchCfg.FindIndex(T => (T.控件名称 == keys[i] && (T.控件类型==ASControlType.asct功能按钮 || T.控件类型 == ASControlType.asct条件按钮))) < 0)
                {
                    //未找到对应按钮
                    _designEvents.Remove(keys[i]);
                }
            }
        }

        //***********************************************************************************************
        #endregion

        #region 控件方法            

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryClick();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            //dtDate.Text = DateTime.Now.ToShortDateString();
        }

        private void btnNearlyOne_Click(object sender, EventArgs e)
        {
            //dtDate.Text = DateTime.Now.AddDays(-1).ToShortDateString();
        }

        private void btnNearlyThree_Click(object sender, EventArgs e)
        {
            //dtDate.Text = DateTime.Now.AddDays(-3).ToShortDateString();
        }


        #endregion

        
        #region 私有方法

        /// <summary>
        /// 改变日期时间控件的时间
        /// </summary>
        /// <param name="actName"></param>
        /// <param name="strTag"></param>
        private void ChangeDateControl(string actName,string strTag)
        {
            try
            {
                foreach (LayoutGroup aItem in layoutControl.Root.Items)
                {
                    foreach (LayoutControlItem aaItem in aItem.Items)
                    {
                        if (aaItem.Control.Name == "dp" + strTag)
                        {
                            if (actName == ApplySearchProviderActionDefine.Action_NextDay)
                            {
                                aaItem.Control.Text = Convert.ToDateTime(aaItem.Control.Text).AddDays(1).ToShortDateString();
                            }
                            else if (actName == ApplySearchProviderActionDefine.Action_PriDay)
                            {
                                aaItem.Control.Text = Convert.ToDateTime(aaItem.Control.Text).AddDays(-1).ToShortDateString();
                            }
                            else if (actName == ApplySearchProviderActionDefine.Action_Today)
                            {
                                aaItem.Control.Text = DateTime.Now.ToShortDateString();
                            }
                            else if (actName == ApplySearchProviderActionDefine.Action_NearOneDay)
                            {
                                aaItem.Control.Text = DateTime.Now.AddDays(-1).ToShortDateString();
                            }
                            else if (actName == ApplySearchProviderActionDefine.Action_NearThreeDay)
                            {
                                aaItem.Control.Text = DateTime.Now.AddDays(-3).ToShortDateString();
                            }
                        }
                    }                                                
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void ClearControls()
        {
            CheckBox cb;
            try
            {
                foreach (LayoutGroup aItem in layoutControl.Root.Items)
                {
                    foreach (LayoutControlItem aaItem in aItem.Items)
                    {
                        if(aaItem.Control is TextBox ||( aaItem.Control is TextEdit && aaItem.Control is ComboBoxEdit ==false )
                            || ( aaItem.Control is ComboBoxEdit && aaItem.TextVisible ==true )
                            || (aaItem.Control.Name == "cbx医生VAL"))
                        {
                            aaItem.Control.Text = "";
                        }   
                        if(aaItem.Control is CheckBox )
                        {
                            cb = aaItem.Control as CheckBox;
                            cb.Checked = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private   DataTable QueryApplyDatas(string dataIdentificationName)
        {
            try
            {
                Dictionary<string, object> dicKeys = new Dictionary<string, object>();

                foreach (LayoutGroup aItem in layoutControl.Root.Items)
                {
                    foreach (LayoutControlItem aaItem in aItem.Items)
                    {       
                        if(aaItem.Control.Text !="")
                        { 
                            switch (aaItem.Text)
                            {
                                //单项条件
                                case "姓名":
                                case "姓名拼音":
                                case "性别":
                                case "联系电话":
                                case "身份证号":
                                case "检查室":
                                case "检查设备":
                                case "检查项目":
                                case "检查状态":
                                case "报告状态":
                                case "诊断":
                                case "学组":
                                case "报告等级":
                                case "类型":
                                case "患者类型":
                                case "费用类型":
                                case "患者来源":
                                case "收费状态":
                                case "录入员":
                                case "申请医生":
                                case "报告医生":
                                case "审核医生":
                                    dicKeys.Add(aaItem.Text, aaItem.Control.Text);
                                    break;

                                case "登记日期":
                                case "检查日期":
                                case "申请日期":
                                    dicKeys.Add(aaItem.Text, Convert.ToDateTime(aaItem.Control.Text));
                                    break;

                                //复合条件    
                                case "号别":                                
                                case "时间":                                                                
                                case "医生":
                                    AddCompositVal(aaItem.Control, aaItem.Text, dicKeys);
                                    break;                                
                                //勾选项
                                case "扫描申请单":
                                case "打印条码":
                                case "危急值":
                                case "随访":
                                case "阳性":
                                case "已接收":
                                    dicKeys.Add(aaItem.Text,(aaItem.Control as CheckBox).Checked ? 1:0 );
                                    break;
                                //条件按钮
                                case "我的患者":
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                }

                //整理复合条件，如果条件为空，则删除
                ClearCompositVal(dicKeys);

                if (dicKeys.Count ==0)
                {
                    MessageBox.Show("请先选择一个查询条件后，再点击“查询”按钮。");
                    return null;
                }
                else
                {
                    DataTable dt;
                    if (_applySearchDesign.查PACS库 == true)
                    {
                        dt = _applyModel.GetPacsApply(dicKeys);
                        dt = FormatPACSDatatTable(dt);
                    }
                    else
                    {
                        dt = ApplyHISDB.GetApply(dicKeys);
                    }
                    
                    return dt;
                }
                
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return null;
            }
        }

        private void ClearCompositVal(Dictionary<string, object> dicKeys)
        {
            try
            {
                if (dicKeys.ContainsValue("号别VAL"))
                {
                    string kk = dicKeys.FirstOrDefault(x => (string)x.Value.ToString() == "号别VAL").Key;
                    dicKeys.Remove(kk);
                    
                }
                if (dicKeys.ContainsValue("医生VAL"))
                {
                    string kk = dicKeys.FirstOrDefault(x => (string)x.Value.ToString() == "医生VAL").Key;
                    dicKeys.Remove(kk);

                }
                if (dicKeys.ContainsValue(""))
                {
                    string kk = dicKeys.FirstOrDefault(x => (string)x.Value.ToString() == "").Key;
                    dicKeys.Remove(kk);

                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void AddCompositVal(Control aControl ,string strKey , Dictionary<string,object> dicKeys)
        {
            try
            {                
                if (aControl is ComboBoxEdit && aControl.Name !="cbx医生VAL")
                {
                    if (dicKeys.ContainsKey(strKey))
                    {
                        dicKeys.Add(aControl.Text, dicKeys[strKey].ToString());
                        dicKeys.Remove(strKey);
                    }
                    else
                    {
                        dicKeys.Add(aControl.Text, strKey+"VAL");
                    }
                }
                else
                {
                    if (dicKeys.ContainsValue(strKey+"VAL"))
                    {
                        string kk = dicKeys.FirstOrDefault(x => (string)x.Value.ToString() == strKey+"VAL").Key;
                        dicKeys[kk] = aControl.Text;
                    }
                    else
                    {
                        if (strKey == "时间")
                        {

                            dicKeys.Add(strKey, Convert.ToDateTime(aControl.Text));
                        }
                        else
                        {
                            dicKeys.Add(strKey, aControl.Text);
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void QueryClick()
        {
            try
            {
                if (IsPacs ==true)
                {
                    _dtPACS = GetPacsStudy();                                       
                }
                else
                {
                    _dtHIS = GetHisApply();                    
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
        
        private DataTable GetPacsStudy()
        {
            //DataTable dt = null;

            //try
            //{

            //    if (txtNumber.Text != "")
            //    {
            //        dicKeys.Add(cboNumber.Text, txtNumber.Text);
            //    }
            //    if (txtName.Text != "")
            //    {
            //        dicKeys.Add("姓名", txtName.Text);
            //    }
            //    if (dtDate.Text != "")
            //    {
            //        dicKeys.Add("申请日期", Convert.ToDateTime(dtDate.Text));
            //    }
            //    if (dicKeys.Count == 0)
            //    {
            //        MessageBox.Show("请先选择一个查询条件后，再点击“查询”按钮。");
            //        return null;
            //    }
            //    dt = ApplyPACSDB.GetPacsApply(dicKeys);
            //    dt = FormatDatatTable(dt);
            //    return dt;
            //}
            //catch (Exception ex)
            //{
            //    MsgBox.ShowException(ex, this);
            //    return null;
            //}

            return null;
        }

        private DataTable FormatPACSDatatTable(DataTable dt)
        {
            if (dt == null) return dt;

            //增加需要单独查询的列            
            //隐藏列 ：医嘱ID 等

            dt.Columns["申请ID"].ColumnMapping = MappingType.Hidden;
            dt.Columns["患者id"].ColumnMapping = MappingType.Hidden;
            dt.Columns["执行科室id"].ColumnMapping = MappingType.Hidden;
            dt.Columns["申请信息"].ColumnMapping = MappingType.Hidden;
            dt.Columns["申请关联id"].ColumnMapping = MappingType.Hidden;
            dt.Columns["申请识别码"].ColumnMapping = MappingType.Hidden;
            dt.Columns["患者信息"].ColumnMapping = MappingType.Hidden;
            dt.Columns["患者关联id"].ColumnMapping = MappingType.Hidden;
            dt.Columns["患者识别码"].ColumnMapping = MappingType.Hidden;                        

            return dt;
        }        

        /// <summary>
        /// 从HIS数据库查询申请信息
        /// </summary>
        /// <returns></returns>
        private DataTable GetHisApply()
        {
            //DataTable dt =null;
            //Dictionary<string, object> dicKeys = new Dictionary<string, object>();           
            //string strOrderIDs;
            //string strOutOrderIDs = "";

            //try
            //{              
            //    if (txtNumber.Text != "")
            //    {
            //        dicKeys.Add(cboNumber.Text, txtNumber.Text);                   
            //    }
            //    if (txtName.Text != "")
            //    {
            //        dicKeys.Add("姓名", txtName.Text);                    
            //    }
            //    if (dtDate.Text != "")
            //    {
            //        dicKeys.Add("开嘱时间",Convert.ToDateTime( dtDate.Text));                   
            //    }
            //    if (dicKeys.Count  == 0)
            //    {
            //        MessageBox.Show("请先选择一个查询条件后，再点击“查询”按钮。");
            //        return null;
            //    }

            //    dt = ApplyHISDB.GetApply(dicKeys);

            //    if (chkRev.Checked == false && dt != null)
            //    {
            //        //获取到HIS返回的数据集后，需要跟PACS的数据比对，只显示PACS没有接收的数据
            //        //每次查询的记录数量在1000条以下，oracle in（）的限制
            //        //循环dt，获取医嘱ID串
            //        strOrderIDs = "";
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            strOrderIDs = strOrderIDs + "," + dt.Rows[i]["医嘱ID"].ToString();
            //            if (i % 1000 == 0 && i != 0)
            //            {
            //                //查询一次PACS数据库
            //                strOrderIDs = strOrderIDs.Substring(2);
            //                strOutOrderIDs = strOutOrderIDs + "," + ApplyPACSDB.GetPacsApplyByOrderID(strOrderIDs);
            //                strOrderIDs = "";
            //            }
            //        }
            //        if (strOrderIDs.Length > 0)
            //        {
            //            //再查询一次数据库
            //            strOrderIDs = strOrderIDs.Substring(2);
            //            strOutOrderIDs = strOutOrderIDs + "," + ApplyPACSDB.GetPacsApplyByOrderID(strOrderIDs);
            //        }
            //        if (strOutOrderIDs.Length > 1)
            //        {
            //            foreach (DataRow dtRow in dt.Rows)
            //            {
            //                if (strOutOrderIDs.IndexOf("," + dtRow["医嘱ID"].ToString()) > 0)
            //                {
            //                    dt.Rows.Remove(dtRow);
            //                }
            //            }
            //        }
            //    }
            //    return dt;
            //}
            //catch (Exception ex)
            //{
            //    MsgBox.ShowException(ex, this);
            //    return null;
            //}

            return null;
        }

        private void InitApplyHISDB()
        {
            DataTable dt;
            
            try
            {
                //查找对应的HIS数据库配置
                if (_hisServerModel == null)
                {
                    _hisServerModel = new HisServerModel(_dbQuery);
                }

                dt = _hisServerModel.GetAllHisServer();

                DataRow[] drs = dt.Select("服务名称 = '" + _applySearchDesign.HIS库名称 + "'");

                _hisServerCfgData = new HisServerCfgData();

                _hisServerCfgData.BindRowData(drs[0]);

                ApplyEnum _ae = new ApplyEnum();
                _applyHISDB = _ae.CreateInstance(_hisServerCfgData.服务配置.HIS接口名称) as IApply;
                _applyHISDB.ConfigString = _hisServerCfgData.服务配置.接口配置.ToString();
                _applyHISDB.UserName = _userData.Name;
                _applyHISDB.Init(_dbQuery);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }    

        /// <summary>
        /// 重新设置控件布局
        /// </summary>
        private void ResizeControls()
        {
            panelSearch.Left = 0;
            panelSearch.Top = 0;            
        }

        protected void InitUserApplySearch(ApplySearchDesign appSearchDesign)
        {
            int rowCount;
            int colCount;
            LayoutControlItem conItem;
            ComboBoxEdit cbxE;
            TextEdit textE;

            try
            {
                //清空控件
                layoutControl.Root.Clear();
                LayoutControlGroup tableGroup = layoutControl.Root.AddGroup();
                tableGroup.Name = "layoutControlGroup1";
                tableGroup.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
                tableGroup.OptionsTableLayoutGroup.ColumnDefinitions.Clear();
                tableGroup.OptionsTableLayoutGroup.RowDefinitions.Clear();
                tableGroup.TextVisible = false;
                //计算最大行数和列数  
                appSearchDesign.GetControlRC(out rowCount, out colCount);
                tableGroup.BeginUpdate();
                for (int n = 0; n < colCount; n++)
                {
                    tableGroup.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition(layoutControl.Root, 100 / colCount, SizeType.Percent));
                }

                for (int m = 0; m < rowCount; m++)
                {
                    tableGroup.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition(layoutControl.Root, 100 / rowCount, SizeType.Percent));
                }

                tableGroup.EndUpdate();


                //添加控件
                foreach (ApplySearchItemConfig asic in appSearchDesign.ApplySearchCfg)
                {
                    switch (asic.控件类型)
                    {
                        case ASControlType.asct单项条件:
                            switch (asic.控件名称)
                            {
                                case "姓名":
                                    textE = new TextEdit();
                                    textE.Name = "txt" + asic.控件名称;
                                    textE.ToolTip = "*表示模糊查询";
                                    textE.ShowToolTips = true;
                                    conItem = tableGroup.AddItem(asic.控件名称, textE);
                                    conItem.OptionsTableLayoutItem.RowIndex = asic.起始行 - 1;
                                    conItem.OptionsTableLayoutItem.ColumnIndex = asic.起始列 - 1;
                                    conItem.OptionsTableLayoutItem.RowSpan = asic.占用行数;
                                    conItem.OptionsTableLayoutItem.ColumnSpan = asic.占用列数;
                                    break;
                                case "姓名拼音":
                                case "联系电话":
                                case "身份证号":                                
                                case "诊断":
                                    conItem = tableGroup.AddItem(asic.控件名称, new TextBox { Name = "txt" + asic.控件名称 });
                                    conItem.OptionsTableLayoutItem.RowIndex = asic.起始行 - 1;
                                    conItem.OptionsTableLayoutItem.ColumnIndex = asic.起始列 - 1;
                                    conItem.OptionsTableLayoutItem.RowSpan = asic.占用行数;
                                    conItem.OptionsTableLayoutItem.ColumnSpan = asic.占用列数;
                                    break;                                
                                case "登记日期":
                                case "检查日期":
                                case "申请日期":
                                    conItem = tableGroup.AddItem(asic.控件名称, new DateTimePicker { Name = "dp" + asic.控件名称 });
                                    conItem.OptionsTableLayoutItem.RowIndex = asic.起始行 - 1;
                                    conItem.OptionsTableLayoutItem.ColumnIndex = asic.起始列 - 1;
                                    conItem.OptionsTableLayoutItem.RowSpan = asic.占用行数;
                                    conItem.OptionsTableLayoutItem.ColumnSpan = asic.占用列数;
                                    break;
                                case "录入员":
                                case "申请医生":
                                case "报告医生":
                                case "审核医生":
                                case "检查项目":
                                case "性别":
                                case "学组":
                                case "报告等级":
                                case "类型":
                                case "患者类型":
                                case "费用类型":
                                case "患者来源":
                                case "收费状态":
                                case "检查室":
                                case "检查设备":
                                case "检查状态":
                                case "报告状态":                                                                        
                                    cbxE = NewComboxEdit("cbx" + asic.控件名称);                                                                        
                                    conItem = tableGroup.AddItem(asic.控件名称, cbxE);
                                    conItem.OptionsTableLayoutItem.RowIndex = asic.起始行 - 1;
                                    conItem.OptionsTableLayoutItem.ColumnIndex = asic.起始列 - 1;
                                    conItem.OptionsTableLayoutItem.RowSpan = asic.占用行数;
                                    conItem.OptionsTableLayoutItem.ColumnSpan = asic.占用列数;                                   
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case ASControlType.asct复合条件:
                            cbxE = NewComboxEdit("cbx" + asic.控件名称);
                            cbxE.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;                                                        
                            conItem = tableGroup.AddItem(asic.控件名称, cbxE);
                            conItem.OptionsTableLayoutItem.RowIndex = asic.起始行 - 1;
                            conItem.OptionsTableLayoutItem.ColumnIndex = asic.起始列 - 1;
                            conItem.OptionsTableLayoutItem.RowSpan = asic.占用行数;
                            conItem.OptionsTableLayoutItem.ColumnSpan = asic.占用列数 / 2;
                            conItem.TextVisible = false;

                            switch (asic.控件名称)
                            {
                                case "号别":
                                    conItem = tableGroup.AddItem(asic.控件名称, new TextBox { Name = "txt" + asic.控件名称 });
                                    conItem.OptionsTableLayoutItem.RowIndex = asic.起始行 - 1;
                                    conItem.OptionsTableLayoutItem.ColumnIndex = asic.起始列 - 1 + asic.占用列数 / 2;
                                    conItem.OptionsTableLayoutItem.RowSpan = asic.占用行数;
                                    conItem.OptionsTableLayoutItem.ColumnSpan = asic.占用列数 / 2;
                                    conItem.TextVisible = false;
                                    break;
                                case "单个日期":
                                    //单个日期 ，占用2列
                                    conItem = tableGroup.AddItem(asic.控件名称, new DateTimePicker { Name = "dp" + asic.控件名称 });
                                    conItem.OptionsTableLayoutItem.RowIndex = asic.起始行 - 1;
                                    conItem.OptionsTableLayoutItem.ColumnIndex = asic.起始列 - 1 + asic.占用列数 / 2;
                                    conItem.OptionsTableLayoutItem.RowSpan = asic.占用行数;
                                    conItem.OptionsTableLayoutItem.ColumnSpan = asic.占用列数 / 2;
                                    conItem.TextVisible = false;
                                    break;

                                case "两个日期":
                                    //两个日期，占用3列
                                    conItem = tableGroup.AddItem(asic.控件名称, new DateTimePicker { Name = "dp" + asic.控件名称+"1" });
                                    conItem.OptionsTableLayoutItem.RowIndex = asic.起始行 - 1;
                                    conItem.OptionsTableLayoutItem.ColumnIndex = asic.起始列 - 1 + asic.占用行数 / 3;
                                    conItem.OptionsTableLayoutItem.RowSpan = asic.占用行数;
                                    conItem.OptionsTableLayoutItem.ColumnSpan =asic.占用行数/3;
                                    conItem.TextVisible = false;

                                    conItem = tableGroup.AddItem("至", new DateTimePicker { Name = "dp" + asic.控件名称+"2" });
                                    conItem.OptionsTableLayoutItem.RowIndex = asic.起始行 - 1;
                                    conItem.OptionsTableLayoutItem.ColumnIndex = asic.起始列 - 1 + asic.占用行数 / 3 *2;
                                    conItem.OptionsTableLayoutItem.RowSpan = asic.占用行数;
                                    conItem.OptionsTableLayoutItem.ColumnSpan = asic.占用行数 / 3;                                    

                                    break;
                                case "医生":                                    
                                    cbxE = NewComboxEdit("cbx" + asic.控件名称 + "VAL");
                                    conItem = tableGroup.AddItem(asic.控件名称, cbxE);
                                    conItem.OptionsTableLayoutItem.RowIndex = asic.起始行 - 1;
                                    conItem.OptionsTableLayoutItem.ColumnIndex = asic.起始列 - 1 + asic.占用列数 / 2;
                                    conItem.OptionsTableLayoutItem.RowSpan = asic.占用行数;
                                    conItem.OptionsTableLayoutItem.ColumnSpan = asic.占用列数 / 2;
                                    conItem.TextVisible = false;
                                    break;
                                default:
                                    break;
                            }
                            break;

                        case ASControlType.asct勾选项:
                            switch (asic.控件名称)
                            {
                                case "扫描申请单":
                                case "打印条码":
                                case "危急值":
                                case "随访":
                                case "阳性":
                                case "已接收":
                                    CheckBox chkb = new CheckBox();
                                    chkb.Name = "chk" + asic.控件名称;
                                    chkb.Text = asic.控件名称;                                    
                                    conItem = tableGroup.AddItem(asic.控件名称, chkb);
                                    conItem.OptionsTableLayoutItem.RowIndex = asic.起始行 - 1;
                                    conItem.OptionsTableLayoutItem.ColumnIndex = asic.起始列 - 1;
                                    conItem.OptionsTableLayoutItem.RowSpan = asic.占用行数;
                                    conItem.OptionsTableLayoutItem.ColumnSpan = asic.占用列数;
                                    conItem.Text = asic.控件名称;
                                    conItem.TextVisible = false;
                                    break;
                                default:
                                    break;
                            }
                            break;

                        case ASControlType.asct条件按钮:
                            switch (asic.控件名称)
                            {
                                case "我的患者":
                                case "前一天":
                                case "后一天":
                                case "今天":
                                case "近一天":
                                case "近三天":
                                    Button butB = new Button();
                                    butB.Name = "btn" + asic.控件名称;
                                    butB.Text = asic.控件名称;
                                    butB.Click += DoUserApplySearchEvent_Button;
                                    conItem = tableGroup.AddItem(asic.控件名称, butB);
                                    conItem.OptionsTableLayoutItem.RowIndex = asic.起始行 - 1;
                                    conItem.OptionsTableLayoutItem.ColumnIndex = asic.起始列 - 1;
                                    conItem.OptionsTableLayoutItem.RowSpan = asic.占用行数;
                                    conItem.OptionsTableLayoutItem.ColumnSpan = asic.占用列数;
                                    conItem.Text = asic.控件名称;                                   
                                    break;
                                default:
                                    break;
                            }
                            break;

                        case ASControlType.asct功能按钮:
                            switch (asic.控件名称)
                            {
                                case "查询":
                                case "全清":
                                case "其他条件设置":
                                    Button butB = new Button();
                                    butB.Name = "btn" + asic.控件名称;
                                    butB.Text = asic.控件名称;
                                    butB.Click += DoUserApplySearchEvent_Button;
                                    conItem = tableGroup.AddItem(asic.控件名称, butB);
                                    conItem.OptionsTableLayoutItem.RowIndex = asic.起始行 - 1;
                                    conItem.OptionsTableLayoutItem.ColumnIndex = asic.起始列 - 1;
                                    conItem.OptionsTableLayoutItem.RowSpan = asic.占用行数;
                                    conItem.OptionsTableLayoutItem.ColumnSpan = asic.占用列数;
                                    conItem.Text = asic.控件名称;

                                    break;
                                default:
                                    break;
                            }
                            break;

                        default:
                            break;
                    }


                }





                ////先移除用户控件
                //toolStrip1.Items.Clear();


                //if (toolsCfg.Count <= 0)
                //{
                //    if (toolStrip1.Items.Count <= 0) toolStrip1.Visible = false;

                //    return;
                //}

                //Font bFont = new Font(this.Font.FontFamily, (float)10.5, FontStyle.Bold);

                ////添加用户工具按钮
                //foreach (ToolItemConfig toolItem in toolsCfg)
                //{
                //    //创建快捷按钮
                //    ToolStripItem tsBut = null;
                //    switch (toolItem.按钮类型)
                //    {
                //        case ToolType.ttLabel:
                //            tsBut = new ToolStripLabel();
                //            break;

                //        case ToolType.ttButton:
                //            tsBut = new ToolStripButton();
                //            break;

                //        case ToolType.ttDrowDownButton:
                //            tsBut = new ToolStripDropDownButton();
                //            break;

                //        case ToolType.ttSeparator:
                //            tsBut = new ToolStripSeparator();
                //            break;

                //        default:
                //            break;
                //    }

                //    switch (toolItem.显示样式)
                //    {
                //        case ToolDisplayStyle.tdsText:
                //            tsBut.DisplayStyle = ToolStripItemDisplayStyle.Text;
                //            break;

                //        case ToolDisplayStyle.tdsImage:
                //            tsBut.DisplayStyle = ToolStripItemDisplayStyle.Image;
                //            break;

                //        case ToolDisplayStyle.tdsTextAndImage:
                //            tsBut.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                //            break;

                //        default:
                //            break;
                //    }

                //    if (toolItem.右对齐) tsBut.Alignment = ToolStripItemAlignment.Right;
                //    //tsBut.Image = null;

                //    tsBut.Name = toolItem.名称;
                //    tsBut.Text = toolItem.名称;
                //    tsBut.Tag = toolItem.标记;
                //    tsBut.ForeColor = _toolsDesign.ForceColor;
                //    tsBut.Click += DoUserToolEvent_StripItem;

                //    if (string.IsNullOrEmpty(toolItem.父级名称))
                //    {
                //        toolStrip1.Items.Add(tsBut);
                //    }
                //    else
                //    {
                //        ToolStripItem[] tsiParent = toolStrip1.Items.Find(toolItem.父级名称, true);

                //        ToolStripDropDownButton dropDownButton = tsiParent[0] as ToolStripDropDownButton;

                //        if (dropDownButton != null)
                //        {
                //            dropDownButton.DropDownItems.Add(tsBut);
                //        }
                //    }

                //    toolItem.LinkObj = tsBut;
                //}


                //if (this.DesignMode == false)
                //{
                //    toolStrip1.Visible = (toolStrip1.Items.Count <= 0) ? false : true;
                //}

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 创建一个ComboxEdit
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private ComboBoxEdit NewComboxEdit(string name)
        {
            try
            {
                ComboBoxEdit cbxE = new ComboBoxEdit();
                cbxE.Name = name;
                AddCbxValue(cbxE);
                cbxE.SelectedIndexChanged += DoUserApplySearchEvent_ComboBoxEdit;
                return cbxE;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return new ComboBoxEdit();
            }
        }
        private void ButB_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 往下拉框中添加基础数据
        /// </summary>
        /// <param name="cbxE"></param>
        private void AddCbxValue(ComboBoxEdit cbxE)
        {
            try
            {
                switch(cbxE.Name)
                {
                    case "cbx性别":
                        LoadDictionary(cbxE, "性别");
                        break;
                    case "cbx学组":
                        LoadDictionary(cbxE, "学组");
                        break;
                    case "cbx报告等级":
                        LoadDictionary(cbxE, "报告等级");
                        break;
                    case "cbx类型":
                        cbxE.Properties.Items.Add("VIP");
                        cbxE.Properties.Items.Add("急诊");
                        cbxE.Properties.Items.Add("疑难");
                        break;
                    case "cbx患者类型":
                        cbxE.Properties.Items.Add("工人");
                        cbxE.Properties.Items.Add("农民");
                        break;
                    case "cbx费用类型":
                        LoadDictionary(cbxE, "费用类型");
                        break;
                    case "cbx患者来源":
                        cbxE.Properties.Items.Add("门诊");
                        cbxE.Properties.Items.Add("住院");
                        cbxE.Properties.Items.Add("外诊");
                        cbxE.Properties.Items.Add("体检");
                        break;
                    case "cbx收费状态":
                        cbxE.Properties.Items.Add("收费状态1");
                        cbxE.Properties.Items.Add("收费状态2");
                        break;
                    case "cbx检查室":                        
                    case "cbx检查设备":
                    case "cbx检查项目":
                    case "cbx录入员":
                    case "cbx申请医生":
                    case "cbx报告医生":
                    case "cbx审核医生":
                    case "cbx医生VAL":
                        BindDatas(cbxE);
                        break;
                    case "cbx检查状态":
                        cbxE.Properties.Items.Add("检查状态1");
                        cbxE.Properties.Items.Add("检查状态2");
                        break;
                    case "cbx报告状态":
                        cbxE.Properties.Items.Add("报告状态1");
                        cbxE.Properties.Items.Add("报告状态2");
                        break;                                                                                                                               
                    case "cbx号别":
                        cbxE.Properties.Items.Add("门诊号");
                        cbxE.Properties.Items.Add("住院号");
                        cbxE.Properties.Items.Add("体检号");
                        cbxE.Properties.Items.Add("检查号");
                        cbxE.Properties.Items.Add("病人编号");
                        break;                    
                    case "cbx单个日期":
                    case "cbx两个日期":
                        cbxE.Properties.Items.Add("登记日期");
                        cbxE.Properties.Items.Add("检查日期");
                        cbxE.Properties.Items.Add("申请日期");
                        break;                    
                    case "cbx医生":
                        cbxE.Properties.Items.Add("申请医生");
                        cbxE.Properties.Items.Add("报告医生");
                        cbxE.Properties.Items.Add("审核医生");
                        cbxE.Properties.Items.Add("录入员");
                        break;                                          
                    default:
                        break;
                }
                if (cbxE.Properties.Items.Count > 0)
                {
                    cbxE.SelectedIndex = 0;
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void BindDatas(ComboBoxEdit cbx)
        {
            string str站点所属科室="";
            DataTable dt=null;
            string DataName="";
            string DataID="";
            string SearchVal="";

            try
            {
                if (StaConfig is null)
                {
                    MsgBox.ShowInf("获取不到站点信息，请先设置站点信息。");
                }
                else
                {
                    str站点所属科室 = StaConfig.站点所属科室;
                }
                switch (cbx.Name)
                {
                    case "cbx检查室":                        
                        dt = _applyModel.GetRoomInfo(str站点所属科室);
                        DataName = "房间名称";
                        DataID = "房间ID";
                        break;
                    case "cbx检查设备":
                        //查找是否存在检查房间控件
                        foreach (LayoutGroup aItem in layoutControl.Root.Items)
                        {
                            foreach (LayoutControlItem aaItem in aItem.Items)
                            {
                                if (aaItem.Control.Name == "cbx检查室")
                                {
                                    if ((aaItem.Control as ComboBoxEdit).SelectedItem.ToString() !="")
                                    {
                                        SearchVal = ((aaItem.Control as ComboBoxEdit).SelectedItem as ItemBind).Value;
                                    }
                                }
                            }
                        }
                        dt = _applyModel.GetDeviceInfo(SearchVal);
                        DataName = "设备名称";
                        DataID = "设备ID";                        
                        break;
                    case "cbx录入员":
                    case "cbx申请医生":
                    case "cbx报告医生":
                    case "cbx审核医生":
                    case "cbx医生VAL":
                        UserModel um = new UserModel(_dbQuery);
                        dt = um.GetDepartmentUsers(str站点所属科室);
                        DataName = "用户名称";
                        DataID = "用户ID";
                        break;
                    case "cbx检查项目":
                        dt = _applyModel.GetStudyItems();
                        DataName = "项目名称";
                        DataID = "项目id";
                        break;
                    default:
                        break;
                }
                
                //将数据加入ComboxEdit
                cbx.Properties.Items.Clear();
                if (dt != null)
                {
                    DevExpress.XtraEditors.Controls.ComboBoxItemCollection coll = cbx.Properties.Items;
                    coll.BeginUpdate();
                    try
                    {
                        foreach (DataRow dr in dt.Rows)
                        {                            
                            coll.Add(new ItemBind(dr[DataName].ToString(), dr[DataID].ToString()));
                        }
                    }
                    finally
                    {
                        coll.EndUpdate();
                    }
                }
                if(cbx.Properties.Items.Count >0)
                {
                    cbx.SelectedIndex = 0;
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 从字典表读取数据并添加到控件中
        /// </summary>
        /// <param name="cbxControl"></param>
        /// <param name="dicName"></param>
        private void LoadDictionary(ComboBoxEdit cbxControl, string dicName)
        {
            DictManageModel dmm = new DictManageModel(_dbQuery);
            JDictionary jdic = dmm.GetDictionary(dicName);
            cbxControl.Properties.Items.Clear();
            if (jdic == null) return;
            foreach (var oneDic in jdic.项目内容)
            {
                cbxControl.Properties.Items.Add(oneDic.项目名称);
            }
            if (cbxControl.Properties.Items.Count > 0)
            {
                cbxControl.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 处理button类型的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoUserApplySearchEvent_Button(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            if (btn == null) return;
            
            //没有对应的事件配置
            if (_designEvents.ContainsKey(btn.Text) == false) return;

            EventActionReleation ea = _designEvents[btn.Text];

            DoActions(ea, sender);
        }

        private void DoUserApplySearchEvent_ComboBoxEdit(object sender, EventArgs e)
        {
            ComboBoxEdit cbx = (sender as ComboBoxEdit);
            if (cbx == null) return;

            //先处理内部事件
            if (cbx.Name == "cbx检查室")
            {                
                AddDevice(cbx.Text);
            }

            //更换检查房间

            //没有对应的事件配置
            if (_designEvents.ContainsKey(cbx.Name) == false) return;

            EventActionReleation ea = _designEvents[cbx.Name];

            DoActions(ea, sender);
        }

        private void AddDevice(string RoomID)
        {
            try
            {
                //查找是否存在检查设备控件
                foreach (LayoutGroup aItem in layoutControl.Root.Items)
                {
                    foreach (LayoutControlItem aaItem in aItem.Items)
                    {
                        if (aaItem.Control.Name  == "cbx检查设备")
                        {                            
                            BindDatas(aaItem.Control as ComboBoxEdit);
                        }
                    }
                }
            }
            catch(Exception ex)
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
        #endregion

    }
}
