using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using zlMedimgSystem.Design;
using zlMedimgSystem.Interface;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Services;
using zlMedimgSystem.ExtInterface;


namespace zlMedimgSystem.CTL.Apply
{
    
    [ToolboxBitmap(typeof(ApplyControl), "Resources.ApplyControl.ico")]
    public partial class ApplyControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        #region 公共类和枚举
        /// <summary>
        /// 数据定义
        /// </summary>
        static public class ApplyProviderDataDefine
        {            
            public const string ApplyInfo = "申请单信息";
        }

        /// <summary>
        /// 动作定义
        /// </summary>
        static public class ApplyProviderActionDefine
        {            
            //public const string Action_Read = "申请读取";
            //public const string Action_New = "申请下达";
            //public const string Action_Save = "申请保存";
            //public const string Action_Recive = "申请接收";
            public const string Action_LoadData = "加载数据";
        }

        /// <summary>
        /// 事件定义
        /// </summary>
        static public class ApplyProviderEventDefine
        {              
            public const string Event_AfterReceive = "接收申请后事件";
            public const string Event_AfterScan = "扫描申请单后事件";
            public const string Event_AfterNew = "新增申请后事件";
            public const string Event_AfterReject = "拒绝申请后事件";
        }        

        public enum ApplyStateTag
        {
            /// <summary>
            /// 危急
            /// </summary>
            asEmergent,

            /// <summary>
            /// 门诊
            /// </summary>
            asOutPatient,

            /// <summary>
            /// 住院
            /// </summary>
            asInPatient,

            /// <summary>
            /// 体检
            /// </summary>
            asPhysicalExam,

            /// <summary>
            /// 外来
            /// </summary>
            asOutSide,

            /// <summary>
            /// 传染病
            /// </summary>
            asInfect,

            /// <summary>
            /// 绿色通道
            /// </summary>
            asGreen
        }        

        public enum ApplyAction
        {
            /// <summary>
            /// 接收申请
            /// </summary>
            aaReceive,

            /// <summary>
            /// 新增申请
            /// </summary>
            aaNew,

            /// <summary>
            /// 更新申请
            /// </summary>
            aaUpdate,

            /// <summary>
            /// 显示申请，显示PACS中已有的申请信息
            /// </summary>
            aaShow
        }

        #endregion

        #region 公共数据

        public ApplyAction ApplyActionState
        {
            get { return _applyAction; }
            set
            {
                _applyAction = value;
                //设置界面控件的可用性
                SetControlsEnable(_applyAction);
                if (_applyAction == ApplyAction.aaNew )
                {
                    //清空控件
                    ClearData();
                    //创建新的数据结构
                    _applyData = new ApplyData();
                    _patData = new PatientData();
                    _studyExecuteDatas = new List<StudyExecuteData>();
                    _applyData.申请ID = SqlHelper.GetNumGuid();
                    _patData.患者ID = SqlHelper.GetNumGuid();
                }
            }
        }

        #endregion

        #region 私有数据        
        private string _patientId = "";
        private ApplyData _applyData = null;
        private PatientData _patData = null;
        private ApplyModel _applyModel = null;
        private PatientModel _patModel = null;
        private JStationConfig _staConfig = null;
        private ApplyAction _applyAction = ApplyAction.aaShow;
        private List<StudyExecuteData> _studyExecuteDatas = null;
        private StudyExecuteModel _studyExecuteModel = null;
        private IApply _applyHISModel = null;        //Iapply接口的实例，连接HIS数据库
        private HisServerCfgData _hisServerCfgData = null;  //HIS服务配置        
        private frmApplyScan _applyScanForm; // 扫描窗口        

        private enum ButtonState
        {
            //新增
            bsNew,

            //修改
            bsUpdate,

            //正常
            bsNormal
        }
        private StudyExecuteModel StudyExecuteModel
        {
            get
            {
                if(_studyExecuteModel == null)
                {                   
                    _studyExecuteModel = new StudyExecuteModel(_dbQuery);
                }
                return _studyExecuteModel;
            }
        }

        private PatientModel  PatModel
        {
            get
            {
                if(_patModel ==null)
                {
                   _patModel = new PatientModel(_dbQuery);
                }
                return _patModel;
            }
        }

        private ApplyModel ApplyModel
        {
            get
            {
                if (_applyModel == null)
                {
                    _applyModel = new ApplyModel(_dbQuery);
                }
                return _applyModel;
            }
        }

        private IApply ApplyHISModle
        {
            get
            {
                if (_applyHISModel == null)
                {
                    InitApplyHISModel();
                }
                return _applyHISModel;
            }
        }

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
        #endregion

        #region 构造函数
        public ApplyControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 重写基类的方法

        public override void Init(string winKey, IDBQuery dbHelper, IBizDataTransferCenter dataTransCenter, IStationInfo stationInfo, ILoginUser userData, IParameters parameters, ISysLog sysLog)
        {
            base.Init(winKey, dbHelper, dataTransCenter, stationInfo, userData, parameters, sysLog);
            RefreshControls();
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
            _moduleName = "检查申请模块";

            //_provideActionDesc.Add(ApplyProviderActionDefine.Action_Read, "读取HIS等下达的检查申请");
            //_provideActionDesc.Add(ApplyProviderActionDefine.Action_New, "科室内下达需要检查的申请");
            //_provideActionDesc.Add(ApplyProviderActionDefine.Action_Save, "保存检查申请信息");
            //_provideActionDesc.Add(ApplyProviderActionDefine.Action_Recive, "接收提取的检查申请");
            _provideActionDesc.Add(ApplyProviderActionDefine.Action_LoadData, "加载数据");

            _provideDataDesc.AddDataDescription(_moduleName, ApplyProviderDataDefine.ApplyInfo, "当前申请或新增申请后所包含的关键信息数据");        

            _designEvents.Add(ApplyProviderEventDefine.Event_AfterReceive , new EventActionReleation(ApplyProviderEventDefine.Event_AfterReceive , ActionType.atSysFixedEvent));
            _designEvents.Add(ApplyProviderEventDefine.Event_AfterScan, new EventActionReleation(ApplyProviderEventDefine.Event_AfterScan, ActionType.atSysFixedEvent));
            _designEvents.Add(ApplyProviderEventDefine.Event_AfterNew, new EventActionReleation(ApplyProviderEventDefine.Event_AfterNew, ActionType.atSysFixedEvent));
            _designEvents.Add(ApplyProviderEventDefine.Event_AfterReject, new EventActionReleation(ApplyProviderEventDefine.Event_AfterReject, ActionType.atSysFixedEvent));
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
            return null;
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
        /// 
        //public override bool ExecuteAction(string callModuleName, string actName, string tag, string dataName)
        //{
        //    switch (actName)
        //    {
        //        case ApplyFuncDefi.ApplyNew:
        //            NewApply();
        //            break;
        //        case ApplyFuncDefi.ApplySave:
        //            return SaveApply(ApplyAction.aaUpdate);

        //        default:
        //            break;
        //    }
        //    return true;
        //}

        public override bool ExecuteAction(string callModuleName, ISysDesign callModuleInstance, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {
                switch (actName)
                {
                    case ApplyProviderActionDefine.Action_LoadData:
                        if (bizDatas == null) return false;
                       
                        DataTable dt = null;
                        string strApplyID = "";
                        if (bizDatas.Count == 1)
                        {
                            IBizDataItem bd = bizDatas[0];
                            if(bd.ContainsKey("HIS服务配置"))
                            {
                                _hisServerCfgData = bd["HIS服务配置"] as HisServerCfgData;
                            }
                            if (bd.ContainsKey("数据表格"))
                            {
                                dt = bd["数据表格"] as DataTable;     
                                if(bd.ContainsKey("申请ID"))
                                {
                                    strApplyID = bd["申请ID"].ToString();
                                    ShowOneStudy(dt, strApplyID);
                                }
                                else
                                {
                                    strApplyID = bd["医嘱ID"].ToString();
                                    ShowOneApply(dt, strApplyID);
                                }
                            }                            
                        }
                        break;

                    //case ApplyProviderActionDefine.Action_Save:
                    //    ModifyApply();
                    //    break;
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
                case ApplyProviderDataDefine.ApplyInfo :
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


        #endregion

        #region 公共方法
        /// <summary>
        /// 新申请
        /// </summary>
        public void NewApply()
        {
            ClearApply();

            ResetApplyState(new ApplyStateTag[] { ApplyStateTag.asOutSide });

            try
            {
                txtApplyDoctor.Text = _userData.Name;
                txtApplyDepart.Text = _stationInfo.DepartmentName;
                deApplyDate.Text = DateTime.Now.ToString();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        public bool SetNewExamItem(ApplyData appNewExamItem)
        {
            if (_applyData == null) _applyData = new ApplyData();
            if (_patData == null) _patData = new PatientData();

            NoRuleModel noRoleModel = new NoRuleModel(_dbQuery);

            //先更新数据结构
            _applyData.影像类别 = appNewExamItem.影像类别;
            _applyData.申请项目ID = appNewExamItem.申请项目ID;
            _applyData.申请信息.检查项目 = appNewExamItem.申请信息.检查项目;
            _applyData.执行科室ID = txtStudyDepart.Tag as string ;
            _applyData.检查号 = noRoleModel.GetStudyNo(_patData.患者识别码, _applyData.影像类别, _applyData.执行科室ID, true);

            //再更新控件显示
            txtExamItemName.Text = _applyData.申请信息.检查项目.项目名称;
            txtStudyNo.Text = _applyData.检查号;

            return true;
        }

        public bool SaveOneApply(ApplyAction aAction)
        {
            try
            {
                //存储数据
                if (aAction == ApplyAction.aaUpdate)
                {
                    ApplyModel.UpdateApply(_applyData);
                    PatModel.UpdatePatient(_patData);
                    StudyExecuteModel.UpdateStudyExecute(_studyExecuteDatas);
                }
                else
                {
                    ApplyModel.NewApply(_applyData);
                    PatModel.NewPatient(_patData);
                    StudyExecuteModel.NewStudyExecute(_studyExecuteDatas);
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
        /// 保存申请
        /// </summary>
        public bool SaveApply(ApplyAction aAction )
        {
            //判断数据有效性
            if (ValidApply() == false) return false;

            try
            {                       
                if (aAction == ApplyAction.aaNew)
                {
                    //从界面读取患者信息，新建ID                    
                    GetPatientFromControl(_patData.患者ID);                    
                    GetApplyFromControl(_patData.患者ID);
                    GetStudyExecuteFromControl();                   
                }
                else if (aAction == ApplyAction.aaReceive)
                {
                    //从界面读取检查执行信息
                    GetStudyExecuteFromControl();                    
                }
                else if (aAction == ApplyAction.aaUpdate)
                {
                    //从界面读取部分信息，ID不变                   
                    GetPatientFromControl( _patData.患者ID);                    
                    GetApplyFromControl( _patData.患者ID);
                    GetStudyExecuteFromControl();                    
                }
                
                if (_patData == null)
                {
                    //新患者
                    _patData = new PatientData();
                    _patData.患者ID = SqlHelper.GetNumGuid();
                    GetPatientFromControl( _patData.患者ID);
                }
                if (_applyData == null)
                {
                    //新增申请   
                    _applyData = new ApplyData();
                    _applyData.申请ID = SqlHelper.GetNumGuid();
                    GetApplyFromControl( _patData.患者ID);
                }
                if (_studyExecuteDatas == null)
                {
                    //新增检查执行信息
                    _studyExecuteDatas = new List<StudyExecuteData>();
                    GetStudyExecuteFromControl( );
                }

                SaveOneApply(aAction);

                return true;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }
        

        /// <summary>
        /// 验证申请
        /// </summary>
        /// <returns></returns>
        public bool ValidApply()
        {
            if (txtPatientName.Text.Trim().Length <= 0)
            {
                ShowValidMessage("患者姓名", txtPatientName);
                return false;
            }

            if (cbxSex.Text.Trim().Length <= 0)
            {
                ShowValidMessage("患者性别", cbxSex);
                return false;
            }

            if (txtAge.Text.Trim().Length <= 0)
            {
                ShowValidMessage("患者年龄", txtAge);
                return false;
            }

            if(cbxRoom.Text.Trim().Length <=0 )
            {      
                ShowValidMessage("患者执行房间", cbxRoom);
                return false;
            }

            if (cbxDevice.Text.Trim().Length <= 0)
            {              
                ShowValidMessage("检查设备", cbxDevice);
                return false;
            }            

            return true;
        }


        /// <summary>
        /// 显示ApplyData和PatientData结构里面的信息
        /// </summary>
        /// <param name="apply"></param>
        /// <param name="patData"></param>
        /// <returns></returns>
        public bool RefreshApplyData(ApplyData apply,PatientData patData,List<StudyExecuteData> studyExecuteDatas, ApplyAction aaAction)
        {           
            try
            {                                               
                _applyData = apply;
                _patData = patData;
                _studyExecuteDatas = studyExecuteDatas;
                if (_studyExecuteDatas == null)
                {
                    _studyExecuteDatas = new List<StudyExecuteData>();
                }                                

                ClearData();

                ShowApplyData(apply);
                ShowPatientData(patData);
                ShowStudyExecuteData(studyExecuteDatas);
                ApplyActionState = aaAction;                
                return true;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex);
                return false;
            }
        }

        #endregion

        #region 私有方法

        private void InitApplyHISModel()
        {          
            try
            {               
                if (_hisServerCfgData != null)
                {
                    ApplyEnum _ae = new ApplyEnum();
                    _applyHISModel = _ae.CreateInstance(_hisServerCfgData.服务配置.HIS接口名称) as IApply;
                    _applyHISModel.ConfigString = _hisServerCfgData.服务配置.接口配置.ToString();
                    _applyHISModel.UserName = _userData.Name;
                    _applyHISModel.Init(_dbQuery);
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private bool ShowOneApply(DataTable dt, string strOrderID)
        {
            try
            {              
                DataRow[] drs1 = dt.Select("医嘱ID = " + strOrderID);

                if (drs1.Length >= 1)
                {
                    //将医嘱的其他信息，附加到datarow中
                    DataTable dt1 = ApplyHISModle.GetOrderInfo(strOrderID);
                    drs1[0]["附加内容"] = dt1.Rows[0]["附加内容"];
                    drs1[0]["临床诊断"] = dt1.Rows[0]["临床诊断"];
                    GetHISDataFromDataRow(drs1[0], out _applyData, out _patData);
                    RefreshApplyData(_applyData, _patData, null, Apply.ApplyControl.ApplyAction.aaReceive);
                }
                return true;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        private bool GetHISDataFromDataRow(DataRow dw, out ApplyData apply, out PatientData patData)
        {
            apply = new ApplyData();
            patData = new PatientData();
            NoRuleModel noRoleModel = new NoRuleModel(_dbQuery);

            try
            {
                apply.住院号 =dw.Table.Columns.Contains("住院号")? dw["住院号"].ToString():"";
                apply.删除标记 = 0;
                apply.就诊卡号 = dw.Table.Columns.Contains("就诊卡号") ? dw["就诊卡号"].ToString() : "";
                apply.影像类别 = dw.Table.Columns.Contains("影像类别") ? dw["影像类别"].ToString() : ""; ;
                apply.患者ID = SqlHelper.GetNumGuid();    //从HIS传过来的病人，暂时新建一个患者ID
                apply.执行科室ID = dw.Table.Columns.Contains("执行科室ID") ? dw["执行科室ID"].ToString() : "";
                apply.执行院区 = "";
                apply.申请ID = SqlHelper.GetNumGuid();    //从HIS传过来的病人，新建申请ID
                apply.申请关联ID = "";
                apply.申请日期 = dw.Table.Columns.Contains("申请日期") ? Convert.ToDateTime(dw["申请日期"].ToString()) : DateTime.Now;
                apply.申请状态 = (int)ApplyState.asRegister;
                apply.申请识别码 = dw["医嘱ID"].ToString();    //对应HIS的医嘱ID
                apply.门诊号 = dw.Table.Columns.Contains("门诊号") ?  dw["门诊号"].ToString() : "";

                apply.申请信息.临床诊断 = dw.Table.Columns.Contains("临床诊断") ? dw["临床诊断"].ToString() : ""; //单独查询的数据
                apply.申请信息.主页ID = dw.Table.Columns.Contains("主页ID") ? dw["主页ID"].ToString() : "";
                apply.申请信息.体重 = "";
                apply.申请信息.医生嘱托 = dw.Table.Columns.Contains("申请嘱托") ? dw["申请嘱托"].ToString() : "";
                apply.申请信息.姓名 = dw.Table.Columns.Contains("姓名") ? dw["姓名"].ToString() : "";
                apply.申请信息.婚姻状况 = dw.Table.Columns.Contains("婚姻状况") ? dw["婚姻状况"].ToString() : "";
                apply.申请信息.年龄 = dw.Table.Columns.Contains("年龄") ? dw["年龄"].ToString() : "";
                apply.申请信息.床号 = dw.Table.Columns.Contains("床号") ? dw["床号"].ToString() : "";
                apply.申请信息.性别 = dw.Table.Columns.Contains("性别") ? dw["性别"].ToString() : "";
                apply.申请信息.是否允许查看报告 = false;
                apply.申请信息.是否危重 = false;
                apply.申请信息.是否婴儿 = dw.Table.Columns.Contains("婴儿") ? (dw["婴儿"].ToString() == "1" ? true : false) : false;
                apply.申请信息.是否急诊 = dw.Table.Columns.Contains("紧急") ? (dw["紧急"].ToString() == "1" ? true : false) : false;
                apply.申请信息.是否绿色通道 = false;
                apply.申请信息.来源 = dw.Table.Columns.Contains("病人来源") ? Int32.Parse(dw["病人来源"].ToString()) : 1;
                apply.申请信息.申请医生 = dw.Table.Columns.Contains("申请医生") ? dw["申请医生"].ToString() : "";
                apply.申请信息.申请科室 = dw.Table.Columns.Contains("申请科室") ? dw["申请科室"].ToString() : "";
                apply.申请信息.英文名 = PYConvert.ConvertPy(apply.申请信息.姓名);
                apply.申请信息.身高 = "";
                apply.申请信息.附加内容 = dw.Table.Columns.Contains("附加内容") ? dw["附加内容"].ToString() : "";        //单独查询的数据          
                apply.申请信息.检查项目.项目名称 = dw.Table.Columns.Contains("项目名称") ? dw["项目名称"].ToString() : "";
                apply.申请信息.CopyBasePro(apply);

                //患者信息
                patData.删除标记 = 0;
                patData.姓名 = apply.申请信息.姓名;
                patData.患者ID = apply.患者ID;
                patData.患者关联ID = "";
                patData.患者识别码 = dw.Table.Columns.Contains("病人ID") ? dw["病人ID"].ToString() : "";
                patData.身份证号 = dw.Table.Columns.Contains("身份证号") ? dw["身份证号"].ToString() : "";

                patData.患者信息.出生日期 = DateTime.Now.ToString();
                patData.患者信息.国家 = dw.Table.Columns.Contains("国籍") ? dw["国籍"].ToString() : "";
                patData.患者信息.婚姻状况 = dw.Table.Columns.Contains("婚姻状况") ? dw["婚姻状况"].ToString() : "";
                patData.患者信息.性别 = dw.Table.Columns.Contains("性别") ? dw["性别"].ToString() : "";
                patData.患者信息.民族 = dw.Table.Columns.Contains("民族") ? dw["民族"].ToString() : "";
                patData.患者信息.监护人 = "";
                patData.患者信息.籍贯 = dw.Table.Columns.Contains("籍贯") ? dw["籍贯"].ToString() : "";
                patData.患者信息.职业 = dw.Table.Columns.Contains("职业") ? dw["职业"].ToString() : "";
                patData.患者信息.证件号码 = dw.Table.Columns.Contains("身份证号") ? dw["身份证号"].ToString() : "";
                patData.患者信息.证件类型 = "身份证";
                patData.患者信息.OftenContact.地址 = dw.Table.Columns.Contains("常用联系地址") ? dw["常用联系地址"].ToString() : "";
                patData.患者信息.OftenContact.电话 = dw.Table.Columns.Contains("常用联系电话") ? dw["常用联系电话"].ToString() : "";
                patData.患者信息.OftenContact.邮编 = dw.Table.Columns.Contains("常用邮编") ? dw["常用邮编"].ToString() : "";
                patData.患者信息.BakContact.地址 = dw.Table.Columns.Contains("备用联系地址") ? dw["备用联系地址"].ToString() : "";
                patData.患者信息.BakContact.电话 = dw.Table.Columns.Contains("备用联系电话") ? dw["备用联系电话"].ToString() : "";
                patData.患者信息.BakContact.邮编 = dw.Table.Columns.Contains("备用邮编") ? dw["备用邮编"].ToString() : "";
                patData.患者信息.CopyBasePro(patData);

                //根据上述信息，产生新的检查号
                apply.检查号 = noRoleModel.GetStudyNo(patData.患者识别码, apply.影像类别, "6LfuLw/NyEabUbskclSyiQ", true);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
            return true;
        }

        private bool ModifyApply()
        {
            try
            {
                SaveApply(ApplyAction.aaUpdate);
                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        private bool ShowOneStudy(DataTable dt,string strApplyID)
        {
            try
            {                
                DataRow[] drs1 = dt.Select("申请ID = '" + strApplyID + "'");
                if (drs1.Length >= 1)
                {
                    GetPacsDataFromDataRow(drs1[0], out _applyData, out _patData);
                    List<StudyExecuteData> studyExecuteDatas = new List<StudyExecuteData>();
                    StudyExecuteModel seModel = new StudyExecuteModel(_dbQuery);
                    studyExecuteDatas = seModel.GetStudyExecuteData(_applyData.申请ID);
                    RefreshApplyData(_applyData, _patData, studyExecuteDatas, Apply.ApplyControl.ApplyAction.aaShow);
                }
                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }


        /// <summary>
        /// 将数据库的数据转换成ApplyData和PatientData
        /// </summary>
        /// <param name="dw"></param>
        /// <param name="apply"></param>
        /// <param name="patData"></param>
        /// <returns></returns>
        private bool GetPacsDataFromDataRow(DataRow dw, out ApplyData apply, out PatientData patData)
        {
            apply = new ApplyData();
            patData = new PatientData();

            try
            {
                apply.BindRowData(dw);
                patData.BindRowData(dw);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 设置界面录入控件的可用性
        /// </summary>
        /// <param name="aaAction"></param>
        private void SetControlsEnable(ApplyAction aaAction)
        {
            if (aaAction == ApplyAction.aaReceive)
            {
                layoutPatient.Enabled = false;
                layoutApply.Enabled = false;
                //layoutBase.Enabled = false;
                layoutSide.Enabled = false;
                layoutStudy.Enabled = true;
            }
            else if(aaAction == ApplyAction.aaShow)
            {
                layoutPatient.Enabled = false;
                layoutApply.Enabled = false;
                //layoutBase.Enabled = false;
                layoutSide.Enabled = false;
                layoutStudy.Enabled = false;
            }
            else if (aaAction == ApplyAction.aaNew || aaAction == ApplyAction.aaUpdate)
            {
                layoutPatient.Enabled = true;
                layoutApply.Enabled = true;
                //layoutBase.Enabled = true;
                layoutSide.Enabled = true;
                layoutStudy.Enabled = true;
            }            
        }

        private void ShowValidMessage(string strItem, Control ctlControl)
        {
            MessageBox.Show(strItem + "不允许为空。", "提示");
            ctlControl.Focus();
        }

        /// <summary>
        /// 绑定房间
        /// </summary>
        /// <param name="departmentId"></param>
        private void BindRoom(string departmentId)
        {            
            DataTable dtRoom = _applyModel.GetRoomInfo(departmentId);
            DataTable dtRoom1 = _applyModel.GetApplyKeyData1(departmentId);
            

            cbxRoom.DisplayMember = "房间名称";
            cbxRoom.ValueMember = "房间ID";

            cbxRoom.DataSource = dtRoom;

            if (cbxRoom.Items.Count > 0) cbxRoom.SelectedIndex = 0;
        }

        private void LoadDictionary(DevExpress.XtraEditors.ComboBoxEdit cbxControl ,string dicName)
        {
            int iDefault = 0;
            try
            {
                DictManageModel dmm = new DictManageModel(_dbQuery);
                JDictionary jdic = dmm.GetDictionary(dicName);
                cbxControl.Properties.Items.Clear();
                if (jdic == null) return;
                foreach (var oneDic in jdic.项目内容)
                {
                    cbxControl.Properties.Items.Add(oneDic.项目名称);
                    if (oneDic.缺省==true)
                    {
                        iDefault = cbxControl.Properties.Items.Count - 1;
                    }
                }
                if (cbxControl.Properties.Items.Count > 0)
                {
                    cbxControl.SelectedIndex = iDefault;
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void RefreshControls()
        {
            ToolTip tpHint;
            string str站点所属科室 = "";

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
                txtStudyDepart.Text = ApplyModel.GetDepartmentName(str站点所属科室);
                txtStudyDepart.Tag = str站点所属科室;
                BindRoom(str站点所属科室);

                cbxNative.Text = "";
                cbxNation.Text = "";
                cbxWork.Text = "";
                cbxCountry.Text = "";

                LoadDictionary(cbxSex, "性别");
                LoadDictionary(cbxAgeUnit, "年龄单位");
                LoadDictionary(cbxMarital, "婚姻状况");
                LoadDictionary(cbxCardType, "证件类型");
                LoadDictionary(cbxCountry, "国籍");
                LoadDictionary(cbxNative, "籍贯");
                LoadDictionary(cbxNation, "民族");
                LoadDictionary(cbxWork, "职业");
                
                picEmergent.Visible = false;
                picGreen.Visible = false;
                picInfect.Visible = false;
                picInPatient.Visible = false;
                picOutPatient.Visible = false;
                picOutside.Visible = false;
                picPhyExam.Visible = false;

                //状态图标的提示
                tpHint = new ToolTip();
                tpHint.ShowAlways = true;
                tpHint.SetToolTip(picEmergent, "紧急");

                tpHint = new ToolTip();
                tpHint.ShowAlways = true;
                tpHint.SetToolTip(picGreen, "绿色通道");

                tpHint = new ToolTip();
                tpHint.ShowAlways = true;
                tpHint.SetToolTip(picInPatient, "住院");

                tpHint = new ToolTip();
                tpHint.ShowAlways = true;
                tpHint.SetToolTip(picOutPatient, "门诊");

                tpHint = new ToolTip();
                tpHint.ShowAlways = true;
                tpHint.SetToolTip(picOutside, "外诊");

                tpHint = new ToolTip();
                tpHint.ShowAlways = true;
                tpHint.SetToolTip(picPhyExam, "体检");

                tpHint = new ToolTip();
                tpHint.ShowAlways = true;
                tpHint.SetToolTip(picInfect, "传染病");
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }                      

        /// <summary>
        /// 将窗体显示的信息加入到数据结构中
        /// </summary>
        /// <param name="apply"></param>
        /// <param name="patData"></param>
        /// <param name="patientId"></param>
        private void GetAllFromControl(ApplyData apply, PatientData patData, string patientId)
        {
            //是否需要清空原有数据？
            //从界面读取不到的数据，不处理
            apply.患者ID = patientId;
            //apply.执行院区 = "";
            apply.执行科室ID = StaConfig.站点所属科室;
            apply.检查号 = txtStudyNo.Text;          
            apply.门诊号 = txtOutPatientNo.Text;
            apply.住院号 = txtInPatientNo.Text;
            //apply.影像类别 = "US";
            apply.申请日期 = deApplyDate.DateTime;
            apply.申请状态 = (int)ApplyState.asRegister;
            //apply.申请关联ID = "";
            apply.删除标记 = 0;

            apply.申请信息.申请科室 = txtApplyDepart.Text;
            apply.申请信息.申请医生 = txtApplyDoctor.Text;
            apply.申请信息.申请院区编码 = txtHospitalNo.Text;            
            apply.申请信息.姓名 = txtPatientName.Text;
            apply.申请信息.英文名 = txtEnglishName.Text;
            apply.申请信息.性别 = cbxSex.Text;
            apply.申请信息.年龄 = txtAge.Text + ((cbxAgeUnit.ReadOnly) ? "" : cbxAgeUnit.Text);
            apply.申请信息.婚姻状况 = cbxMarital.Text;
            apply.申请信息.床号 = txtBedNo.Text;
            apply.申请信息.临床诊断 = txtClinicalDiagnose.Text;
            apply.申请信息.医生嘱托 = mtxtEntrust.Text;           
            apply.申请信息.来源 = (int)ApplySourceFrom.asfOutside;
            //apply.申请信息.主页ID = "";
            apply.申请信息.是否绿色通道 = chkGreen.Checked;
            apply.申请信息.是否急诊 = chkEmergency.Checked;
            apply.申请信息.是否危重 = false;            
            //apply.申请信息.是否允许查看报告 = false;
            apply.申请信息.体重 = txtWeight.Text;
            //apply.申请信息.是否婴儿 = false;            
            apply.申请信息.身高 = txtHeight.Text;
            apply.申请信息.附加内容 = mtxtAttach.Text;            

            apply.申请信息.送检信息.送检单位 = txtOutsideUnit.Text;
            apply.申请信息.送检信息.送检人 = txtOutsideMan.Text;
            apply.申请信息.送检信息.联系电话 = txtOutsidePhone.Text;
            apply.申请信息.送检信息.送检理由 = txtOutsideReason.Text;
            apply.申请信息.送检信息.初步诊断 = txtOutsideDiagnose.Text;
            apply.申请信息.送检信息.其他描述 = txtOutsideDescription.Text;

            apply.申请信息.检查项目.项目名称 = "腹部超声检查";
            apply.申请信息.检查项目.部位方法.Add(new JApplyExamBodypart("腹部", "常规 "));
            apply.申请信息.CopyBasePro(apply);

            patData.患者ID = patientId;
            patData.身份证号=  txtCardNo.Text;
            patData.姓名 = txtPatientName.Text;
            patData.患者信息.职业 = cbxWork.Text;
            patData.患者信息.籍贯 = cbxNative.Text;
            patData.患者信息.民族 = cbxNation.Text;
            patData.患者信息.出生日期 = DateTime.Now.ToLongDateString();
            patData.患者信息.国家 = cbxCountry.Text;
            patData.患者信息.婚姻状况 = cbxMarital.Text;
            patData.患者信息.性别 = cbxSex.Text;
            patData.患者信息.证件号码 = txtCardNo.Text;
            patData.患者信息.OftenContact.地址 = txtOftenAddress.Text;
            patData.患者信息.OftenContact.电话 = txtOftenPhone.Text;
            patData.患者信息.OftenContact.邮编 = txtOftenPostal.Text;
            patData.患者信息.BakContact.地址 = txtBakAddress.Text;
            patData.患者信息.BakContact.电话 = txtBakPhone.Text;
            patData.患者信息.BakContact.邮编 = txtBakPostal.Text;
            patData.患者信息.CopyBasePro(patData);


           
        }

        /// <summary>
        /// 从界面提取PatientData
        /// </summary>        
        /// <param name="patData"></param>
        /// <param name="patientId"></param>
        private void GetPatientFromControl (string patientId)
        {
            try
            {                
                _patData.患者ID = patientId;
                _patData.身份证号 = txtCardNo.Text;
                _patData.姓名 = txtPatientName.Text;
                _patData.患者信息.职业 = cbxWork.Text;
                _patData.患者信息.籍贯 = cbxNative.Text;
                _patData.患者信息.民族 = cbxNation.Text;
                _patData.患者信息.出生日期 = DateTime.Now.ToLongDateString();
                _patData.患者信息.国家 = cbxCountry.Text;
                _patData.患者信息.婚姻状况 = cbxMarital.Text;
                _patData.患者信息.性别 = cbxSex.Text;
                _patData.患者信息.证件号码 = txtCardNo.Text;
                _patData.患者信息.OftenContact.地址 = txtOftenAddress.Text;
                _patData.患者信息.OftenContact.电话 = txtOftenPhone.Text;
                _patData.患者信息.OftenContact.邮编 = txtOftenPostal.Text;
                _patData.患者信息.BakContact.地址 = txtBakAddress.Text;
                _patData.患者信息.BakContact.电话 = txtBakPhone.Text;
                _patData.患者信息.BakContact.邮编 = txtBakPostal.Text;
                _patData.患者信息.CopyBasePro(_patData);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);                
            }
        }
        /// <summary>
        /// 从界面中提取当前的ApplyData
        /// </summary>
        /// <param name="apply"></param>           
        /// <param name="patientId"></param>
        private void GetApplyFromControl(string patientId)
        {
            try
            {                            
                //从界面读取不到的数据，不处理
                _applyData.患者ID = patientId;
                //apply.执行院区 = "";
                _applyData.执行科室ID = StaConfig.站点所属科室;
                _applyData.检查号 = txtStudyNo.Text;
                _applyData.门诊号 = txtOutPatientNo.Text;
                _applyData.住院号 = txtInPatientNo.Text;
                //apply.影像类别 = "US";
                _applyData.申请日期 = deApplyDate.DateTime;
                _applyData.申请状态 = (int)ApplyState.asRegister;
                //apply.申请关联ID = "";
                _applyData.删除标记 = 0;

                _applyData.申请信息.申请科室 = txtApplyDepart.Text;
                _applyData.申请信息.申请医生 = txtApplyDoctor.Text;
                _applyData.申请信息.申请院区编码 = txtHospitalNo.Text;
                _applyData.申请信息.姓名 = txtPatientName.Text;
                _applyData.申请信息.英文名 = txtEnglishName.Text;
                _applyData.申请信息.性别 = cbxSex.Text;
                _applyData.申请信息.年龄 = txtAge.Text + ((cbxAgeUnit.ReadOnly) ? "" : cbxAgeUnit.Text);
                _applyData.申请信息.婚姻状况 = cbxMarital.Text;
                _applyData.申请信息.床号 = txtBedNo.Text;
                _applyData.申请信息.临床诊断 = txtClinicalDiagnose.Text;
                _applyData.申请信息.医生嘱托 = mtxtEntrust.Text;
                _applyData.申请信息.来源 = (int)ApplySourceFrom.asfOutside;
                //apply.申请信息.主页ID = "";
                _applyData.申请信息.是否绿色通道 = chkGreen.Checked;
                _applyData.申请信息.是否急诊 = chkEmergency.Checked;
                _applyData.申请信息.是否危重 = false;
                //apply.申请信息.是否允许查看报告 = false;
                _applyData.申请信息.体重 = txtWeight.Text;
                //apply.申请信息.是否婴儿 = false;            
                _applyData.申请信息.身高 = txtHeight.Text;
                _applyData.申请信息.附加内容 = mtxtAttach.Text;

                _applyData.申请信息.送检信息.送检单位 = txtOutsideUnit.Text;
                _applyData.申请信息.送检信息.送检人 = txtOutsideMan.Text;
                _applyData.申请信息.送检信息.联系电话 = txtOutsidePhone.Text;
                _applyData.申请信息.送检信息.送检理由 = txtOutsideReason.Text;
                _applyData.申请信息.送检信息.初步诊断 = txtOutsideDiagnose.Text;
                _applyData.申请信息.送检信息.其他描述 = txtOutsideDescription.Text;

                _applyData.申请信息.检查项目.项目名称 = txtExamItemName.Text;
                _applyData.申请信息.CopyBasePro(_applyData);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);                
            }
        }

        /// <summary>
        /// 从界面中提取当前显示的检查执行信息
        /// </summary>        
        private void GetStudyExecuteFromControl()
        {            
            try
            {
                StudyExecuteData oneStudyExecute;               
                
                int i = 1;
                foreach (var onePart in _applyData.申请信息.检查项目.部位方法)
                {
                    oneStudyExecute = new StudyExecuteData();
                    oneStudyExecute.删除标记 = 0;
                    oneStudyExecute.房间ID = cbxRoom.SelectedValue.ToString();
                    oneStudyExecute.执行ID = SqlHelper.GetNumGuid().ToString();
                    oneStudyExecute.申请ID = _applyData.申请ID;
                    oneStudyExecute.设备ID = cbxDevice.SelectedValue.ToString() ;
                    oneStudyExecute.部位名称 = onePart.部位名称;
                    oneStudyExecute.部位序号 = i.ToString();
                    i = i + 1;
                    oneStudyExecute.执行状态 = StudyExecuteState.sesWaiting;
                    oneStudyExecute.执行信息.报到人 = _userData.Name;
                    oneStudyExecute.执行信息.报到时间 = StudyExecuteModel.GetServerDate();
                    oneStudyExecute.执行信息.检查方法 = onePart.方法;
                    oneStudyExecute.执行信息.CopyBasePro(oneStudyExecute);
                    _studyExecuteDatas.Add(oneStudyExecute);
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);                
            }
        }
      
        /// <summary>
        /// 清空申请数据
        /// </summary>
        private void ClearApply()
        {
            _patientId = "";
            _applyData = null;

            foreach (Control ctl in layoutBase.Controls)
            {
                if (ctl is CheckBox) continue;

                ctl.Text = "";
            }

            foreach (Control ctl in layoutPatient.Controls)
            {
                ctl.Text = "";
            }

            foreach (Control ctl in layoutApply.Controls)
            {
                ctl.Text = "";
            }

            foreach (Control ctl in layoutSide.Controls)
            {
                ctl.Text = "";
            }

            foreach (Control ctl in layoutStudy.Controls)
            {
                ctl.Text = "";
            }
        }

        /// <summary>
        /// 重置申请状态
        /// </summary>
        /// <param name="stats"></param>
        private void ResetApplyState(ApplyStateTag[] stats)
        {
            picGreen.Visible = false;
            picInfect.Visible = false;

            picOutside.Visible = false;
            picPhyExam.Visible = false;
            picInPatient.Visible = false;
            picOutPatient.Visible = false;

            picEmergent.Visible = false;

            foreach(ApplyStateTag state in stats )
            {
                switch(state)
                {
                    case ApplyStateTag.asEmergent:
                        picEmergent.Visible = true;
                        break;
                    case ApplyStateTag.asOutPatient:
                        picOutPatient.Visible = true;
                        break;
                    case ApplyStateTag.asInPatient:
                        picInPatient.Visible = true;
                        break;
                    case ApplyStateTag.asPhysicalExam:
                        picPhyExam.Visible = true;
                        break;
                    case ApplyStateTag.asOutSide:
                        picOutside.Visible = true;
                        break;
                    case ApplyStateTag.asInfect:
                        picInfect.Visible = true;
                        break;
                    case ApplyStateTag.asGreen:
                        picGreen.Visible = true;
                        break;
                    default:
                        break;
                }
            }
        }
        
        //private void DoActions(EventActionReleation ea)
        //{
        //    try
        //    {
        //        base.DoBindActions(ea);
        //    }
        //    catch (Exception ex)
        //    {
        //        MsgBox.ShowException(ex, this);
        //    }
        //}
        
        private void ClearData()
        {
            //Base
            chkEmergency.Checked = false;
            chkGreen.Checked = false;
            txtPatientName.Text = "";
            cbxSex.Text = "";
            txtAge.Text = "";            
            cbxMarital.Text = "";

            //Apply
            txtEnglishName.Text = "";
            cbxCardType.Text = "";
            txtCardNo.Text = "";
            cbxCountry.Text = "";
            cbxNative.Text = "";
            cbxNation.Text = "";
            cbxWork.Text = "";
            txtHeight.Text = "";
            txtWeight.Text = "";
            txtOftenAddress.Text = "";
            txtOftenPhone.Text = "";
            txtOftenPostal.Text = "";
            txtBakAddress.Text = "";
            txtBakPhone.Text = "";
            txtBakPostal.Text = "";

            //Patient
            txtOutPatientNo.Text = "";
            txtInPatientNo.Text = "";
            txtBedNo.Text = "";
            txtHospitalNo.Text = "";
            txtApplyDoctor.Text = "";
            txtApplyDepart.Text = "";
            deApplyDate.Text = DateTime.Now.ToShortDateString();
            txtClinicalDiagnose.Text = "";
            mtxtEntrust.Text = "";
            mtxtAttach.Text = "";

            //Outside
            txtOutsideUnit.Text = "";
            txtOutsideMan.Text = "";
            txtOutsidePhone.Text = "";
            txtOutsideReason.Text = "";
            txtOutsideDiagnose.Text = "";
            txtOutsideDescription.Text = "";

            //Study
            txtExamItemName.Text = "";
            txtStudyNo.Text = "";            
            //txtStudyDepart.Text = "";
            //cbxRoom.DataSource = null;
            //cbxRoom.Text = "";
            //cbxDevice.DataSource = null;
            //cbxDevice.Text = "";
            labMoney.Text = "";
        }

        /// <summary>
        /// 显示申请信息
        /// </summary>
        /// <param name="apply">申请信息对象</param>
        private void ShowApplyData(ApplyData apply)
        {
            if (apply == null) return;

            txtStudyNo.Text = apply.检查号;                       
            txtOutPatientNo.Text = apply.门诊号;
            txtInPatientNo.Text = apply.住院号;           
            deApplyDate.DateTime = apply.申请日期;
            
            txtApplyDepart.Text = apply.申请信息.申请科室;
            txtApplyDoctor.Text = apply.申请信息.申请医生;
            txtHospitalNo.Text = apply.申请信息.申请院区编码;
            
            txtPatientName.Text = apply.申请信息.姓名;
            txtEnglishName.Text = apply.申请信息.英文名;
            cbxSex.Text = apply.申请信息.性别;

            txtAge.Text = Regex.Replace(apply.申请信息.年龄, "[0-9]","", RegexOptions.IgnoreCase);
            cbxAgeUnit.Text = Regex.Replace(apply.申请信息.年龄, txtAge.Text, "", RegexOptions.IgnoreCase);            

            cbxMarital.Text = apply.申请信息.婚姻状况;
            txtBedNo.Text = apply.申请信息.床号;
            txtClinicalDiagnose.Text = apply.申请信息.临床诊断;
            mtxtEntrust.Text = apply.申请信息.医生嘱托;
                      
            chkGreen.Checked = apply.申请信息.是否绿色通道;

            txtExamItemName.Text = apply.申请信息.检查项目.项目名称;
           
            txtOutsideUnit.Text = apply.申请信息.送检信息.送检单位;
            txtOutsideMan.Text = apply.申请信息.送检信息.送检人;
            txtOutsidePhone.Text = apply.申请信息.送检信息.联系电话;
            txtOutsideReason.Text = apply.申请信息.送检信息.送检理由;
            txtOutsideDiagnose.Text = apply.申请信息.送检信息.初步诊断;
            txtOutsideDescription.Text = apply.申请信息.送检信息.其他描述;
            mtxtAttach.Text = apply.申请信息.附加内容;
            
            chkGreen.Checked = apply.申请信息.是否绿色通道;
            chkEmergency.Checked = apply.申请信息.是否急诊;
            if (chkEmergency.Checked == true)
            {
                chkGreen.Checked = true;              
            }
            
            //更新状态图标
            picEmergent.Visible = chkEmergency.Checked;
            picGreen.Visible = chkGreen.Checked;
            picInPatient.Visible = false;
            picOutPatient.Visible = false;
            picOutside.Visible = false;
            picPhyExam.Visible = false;
            picInfect.Visible = false;
            switch (apply.申请信息.来源)
            {
                case (int)ApplySourceFrom.asfInPatient:
                    picInPatient.Visible = true;
                     break ;
                case (int)ApplySourceFrom.asfOutPatient:
                    picOutPatient.Visible = true;
                    break;
                case (int)ApplySourceFrom.asfOutside:
                    picOutside.Visible = true;
                    break;
                case (int)ApplySourceFrom.asfPhyExam:
                    picPhyExam.Visible = true;
                    break;
                default:
                    break;
            }            
            
        }

        private void ShowStudyExecuteData(List<StudyExecuteData> studyExecuteDatas)
        {
            if (studyExecuteDatas == null || studyExecuteDatas.Count ==0 ) return;

            try
            {                
                cbxRoom.SelectedValue = (studyExecuteDatas[0].房间ID == null) ? "-1" : studyExecuteDatas[0].房间ID;
                cbxDevice.SelectedValue = (studyExecuteDatas[0].设备ID == null) ? "-1" : studyExecuteDatas[0].设备ID;                
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }

        /// <summary>
        /// 显示患者信息
        /// </summary>
        /// <param name="patData">患者信息对象</param>
        private void ShowPatientData(PatientData patData)
        {
            if (patData == null) return;

            if (patData.身份证号 != "")
            {
                cbxCardType.Text = "身份证号";
                txtCardNo.Text = patData.身份证号;
            }
            cbxCountry.Text = patData.患者信息.国家;
            cbxNative.Text = patData.患者信息.籍贯;
            cbxNation.Text = patData.患者信息.民族;
            cbxWork.Text = patData.患者信息.职业;
            txtOftenAddress.Text = patData.患者信息.OftenContact.地址;
            txtOftenPhone.Text = patData.患者信息.OftenContact.电话;
            txtOftenPostal.Text = patData.患者信息.OftenContact.邮编;
            txtBakAddress.Text = patData.患者信息.BakContact.地址;
            txtBakPhone.Text = patData.患者信息.BakContact.电话;
            txtBakPostal.Text = patData.患者信息.BakContact.邮编;
            _patientId = patData.患者ID;
        }

        /// <summary>
        /// 绑定设备
        /// </summary>
        /// <param name="roomId"></param>
        private void BindDevice(string roomId)
        {
            try
            {
                DataTable dtDevice = _applyModel.GetDeviceInfo(roomId);

                cbxDevice.DisplayMember = "设备名称";
                cbxDevice.ValueMember = "设备ID";

                cbxDevice.DataSource = dtDevice;

                if (cbxDevice.Items.Count > 0) cbxDevice.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        #endregion

        #region 控件事件
        private void ApplyControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == true) return; 
        }

        private void chkGreen_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                picGreen.Visible = chkGreen.Checked;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
        #endregion

        private void cbxRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxRoom.SelectedValue == null) return;

                BindDevice(cbxRoom.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void chkEmergency_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                picEmergent.Visible = chkEmergency.Checked;
                chkGreen.Checked = chkEmergency.Checked;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void ApplyControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
                
            }
        }

        private void ApplyControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
          
            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{TAB}");

            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            ScanData scanData = new ScanData();

            if (_applyData == null) return;

            scanData.申请ID = _applyData.申请ID;
            scanData.扫描ID = SqlHelper.GetNumGuid().ToString();

            if (_applyScanForm == null || _applyScanForm.IsDisposed == true)
            {
                _applyScanForm = new frmApplyScan(_dbQuery);
            }

            _applyScanForm.申请ID = scanData.申请ID;
            _applyScanForm.扫描人 = _userData.Name;
            _applyScanForm.申请日期 = _applyData.申请日期;
            _applyScanForm.存储ID = _stationInfo.StorageId;
            _applyScanForm.ShowScanImage();
            _applyScanForm.Show();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if(_applyData != null)
            {
                if(ReceiveHisApply(_applyData.申请识别码)==true)
                {
                    DoActions(_designEvents[ApplyProviderEventDefine.Event_AfterReceive], sender);
                }                
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

        private bool ReceiveHisApply(string strOrderID)
        {
            try
            {
                //将数据提取到PACS表中
                if (SaveApply(ApplyAction.aaReceive) == true)
                {
                    //通知HIS
                    ApplyHISModle.ReceiveApply(strOrderID);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        private void SetNormalButtonState(bool isNormal)
        {
            //btnPrintSetup.Enabled = isNormal;
            //btnPrint.Enabled = isNormal;
            btnScan.Enabled = isNormal;
            btnReceive.Enabled = isNormal;
            btnNewApply.Enabled = isNormal;
            btnNewApply.Text = "新增";
            btnModify.Enabled = isNormal;
            btnModify.Text = "修改";
            btnReject.Enabled = isNormal;
            btnCancel.Visible = (isNormal == false);
        }

        private void SetButtonState(ButtonState butState)
        {
            switch (butState)
            {
                case ButtonState.bsNew:
                    SetNormalButtonState(false);
                    btnNewApply.Text = "保存";
                    btnNewApply.Enabled = true;
                    break;
                case ButtonState.bsUpdate:
                    SetNormalButtonState(false);
                    btnModify.Text = "保存";
                    btnModify.Enabled = true;
                    break;
                case ButtonState.bsNormal:
                    SetNormalButtonState(true);
                    break;
            }
        }

        private void btnNewApply_Click(object sender, EventArgs e)
        {
            if (btnNewApply.Text == "新增")
            {
                ApplyActionState = ApplyAction.aaNew;
                SetButtonState(ButtonState.bsNew);
                //显示检查项目录入窗口
                frmNewStudy newStudyForm = new frmNewStudy(_dbQuery);

                newStudyForm.ShowDialog();
                if (newStudyForm.DialogResult == DialogResult.OK)
                {
                    //添加检查项目信息                   
                    ApplyData appExamItem = new ApplyData();

                    appExamItem.影像类别 = newStudyForm.Modality;
                    appExamItem.申请项目ID = newStudyForm.ItemID; ;
                    appExamItem.申请信息.检查项目 = new JApplyExamItem();
                    appExamItem.申请信息.检查项目.项目名称 = newStudyForm.OrderContent;
                    appExamItem.申请信息.检查项目 = newStudyForm.oneExamItem;
                    SetNewExamItem(appExamItem);

                }
            }
            else
            {
                if (SaveApply(Apply.ApplyControl.ApplyAction.aaNew) == true)
                {
                    //保存成功了才改变状态
                    SetButtonState(ButtonState.bsNormal);
                    ApplyActionState = ApplyAction.aaShow;
                }

            }
        }

        private bool RejectApply()
        {
            try
            {
                if (_applyData != null)
                {
                    if (_applyData.申请关联ID == null)
                    {
                        MsgBox.ShowInf("申请关联ID为空，无法拒绝申请。");
                        return false;
                    }
                    else
                    {
                        ApplyHISModle.RejectApply(_applyData.申请关联ID);
                        ApplyModel.DelApply(_applyData);
                    }                    
                }
                return true;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if( RejectApply() == true)
            {
                DoActions(_designEvents[ApplyProviderEventDefine.Event_AfterReject], sender);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (btnModify.Text == "修改")
            {
                ApplyActionState = ApplyAction.aaUpdate;
                SetButtonState(ButtonState.bsUpdate);
            }
            else
            {
                if (ModifyApply() == true)
                {
                    //修改成功了，才改变状态
                    SetButtonState(ButtonState.bsNormal);
                    ApplyActionState = ApplyAction.aaShow;
                    //QueryClick();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetButtonState(ButtonState.bsNormal);
            ApplyActionState = ApplyAction.aaShow;
        }
               
    }
}
