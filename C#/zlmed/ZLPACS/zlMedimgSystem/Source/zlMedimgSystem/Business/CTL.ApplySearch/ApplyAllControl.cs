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
using zlMedimgSystem.Design;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using zlMedimgSystem.ExtInterface;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.HardWare;



namespace zlMedimgSystem.CTL.ApplySearch
{
    internal partial class ApplyAllControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        #region 公共类和枚举

        public static class ApplyDataNameDefi
        {
            public const string ApplySerach = "申请检索";
        }

        private enum ButtonState
        {
            //新增
            bsNew,

            //修改
            bsUpdate,

            //正常
            bsNormal
        }

        #endregion

        #region 私有属性
        private const string Const_Data_SearchResult = "检索结果";

        private IApply _applyHISDB = null;        //Iapply接口的实例，连接HIS数据库
        private ApplyModel _applyPACSDB = null; //连接PACS数据库        

        private DataTable _dtHIS = null;
        private DataTable _dtPACS = null;
        private string _strOrderID;      //医嘱ID
        private string _申请ID;

        private ApplyData _applyData;   //申请信息
        private PatientData _patData;   //病人信息        
        private frmApplyScan _applyScanForm; // 扫描窗口

        private zlMedimgSystem.DataModel.HisServerModel _hisServerModel = null;

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

        private ApplyModel ApplyPACSDB
        {
            get
            {
                if (_applyPACSDB == null)
                {
                    InitApplyPACSDB();
                }
                return _applyPACSDB;
            }
        }

        private const string APPLYSEARCH_EVENT_TABLECLICK = "数据列表单击事件";


        #endregion

        #region 构造函数
        public ApplyAllControl()
        {
            InitializeComponent();
            vHisTable.UserControlFocusedRowChanged += VHisTable_UserControlFocusedRowChanged;

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
            _moduleName = "申请检索模块";

            ////_moduleStyles = new string[] { "样式一", "样式二" };

            _provideActionDesc.Add("清空录入", "清空录入的检索条件.");
            _provideActionDesc.Add("检索", "开始检索数据.");

            _provideDataDesc.Add(ModuleName + "." + Const_Data_SearchResult, "从检查申请和三方HIS中检索到的结果数据.");


            //_designTools.Add("登记", new ToolVisible("登记", true));
            //_designTools.Add("报道", new ToolVisible("报道", true));
            ////_designTools.Add("完成", true);
            ////_designTools.Add("刷新", true);
            ////_designTools.Add("过滤", true);
            ////_designTools.Add("绿色通道", true);

            _designEvents.Add(APPLYSEARCH_EVENT_TABLECLICK, new EventActionReleation(APPLYSEARCH_EVENT_TABLECLICK, ActionType.atSysFixedEvent));
            //_designEvents.Add(Const_Event_SelChange, new EventActionReleation(Const_Event_SelChange, ActionType.atSysFixedEvent));
            //_designEvents.Add(Const_Event_RowClick, new EventActionReleation(Const_Event_RowClick, ActionType.atSysFixedEvent));
            //_designEvents.Add(Const_Event_RowDBClick, new EventActionReleation(Const_Event_RowDBClick, ActionType.atSysFixedEvent));
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
            //return base.QueryDatas(dataIdentificationName);
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
        //public override bool ExecuteAction(string callModuleName, string actName, string tag, string dataName)
        //{
        //    //switch (actName)
        //    //{
        //    //    case ApplyFuncDefi.ApplyNew:
        //    //        NewApply();
        //    //        break;
        //    //    case ApplyFuncDefi.ApplySave:
        //    //        return SaveApply();

        //    //    default:
        //    //        break;
        //    //}
        //    return true;
        //    //return base.ExecuteAction(callModuleName, actName, tag, dataName);
        //}

        /// <summary>
        /// 判断数据是否存在
        /// </summary>
        /// <param name="dataIdentificationName"></param>
        /// <returns></returns>
        public override bool HasData(string dataIdentificationName)
        {
            if (dataIdentificationName == _moduleName + "." + ApplyDataNameDefi.ApplySerach) return true;

            return false;
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
        //***********************************************************************************************
        #endregion

        #region 重写基类的方法

        public override void Init(IDBQuery dbHelper, IBizDataTransferCenter dataTransCenter, IStationInfo stationInfo, ILoginUser userData, IParameters parameters, ISysLog sysLog)
        {
            base.Init(dbHelper, dataTransCenter, stationInfo, userData, parameters, sysLog);
            //初始化ApplyControl
            applyControl.Init(_dbQuery, _dataTransCenter, _stationInfo, _userData, _parameters, _sysLog);
            SetButtonState(ButtonState.bsNormal);
        }

        #endregion

        #region 控件方法

        private void scanner_OnScanComplete(Bitmap bmp)
        {                    
         
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            ScanData scanData = new ScanData();            

            if (_applyData == null) return;

            scanData.申请ID = _applyData.申请ID;
            scanData.扫描ID = SqlHelper.GetNumGuid().ToString();

            if (_applyScanForm == null || _applyScanForm.IsDisposed ==true )
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

        private void btnScanSetup_Click(object sender, EventArgs e)
        {
            //ShowScanSetup();
        }

        private void VHisTable_UserControlFocusedRowChanged(string strOrderID)
        {
            _strOrderID = strOrderID;
            ShowOneApply(_strOrderID);
        }

        private void ApplySearchControl_Resize(object sender, EventArgs e)
        {
            try
            {

                split.Left = 0;
                split.Top = 0;
                split.Width = this.Width;
                split.Height = this.Height;
            }
            catch
            {
                // do nothing
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryClick();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtDate.Text = DateTime.Now.ToShortDateString();
        }

        private void btnNearlyOne_Click(object sender, EventArgs e)
        {
            dtDate.Text = DateTime.Now.AddDays(-1).ToShortDateString();
        }

        private void btnNearlyThree_Click(object sender, EventArgs e)
        {
            dtDate.Text = DateTime.Now.AddDays(-3).ToShortDateString();
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnQuery_Click(null, null);
            }
        }      

        private void split_SplitterMoved(object sender, SplitterEventArgs e)
        {
            ResizeControls();
        }

        private void split_Resize(object sender, EventArgs e)
        {
            ResizeControls();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (_strOrderID != "")
            {
                if(ReceiveHisApply(_strOrderID)==true)
                {
                    QueryClick();
                }
            }
        }

        #endregion

        #region 私有方法

        private void QueryClick()
        {
            try
            {
                if (tabControl.SelectedTab == tabHisApp)
                {
                    _dtHIS = GetHisApply();
                    vHisTable.Refresh(_dtHIS);
                    if (_dtHIS == null)
                    {
                        applyControl.RefreshApplyData(null, null, null, Apply.ApplyControl.ApplyAction.aaShow);
                    }
                }
                else
                {
                    _dtPACS = GetPacsStudy();
                    vPacsTable.Refresh(_dtPACS);
                    if (_dtPACS == null)
                    {
                        applyControl.RefreshApplyData(null, null, null, Apply.ApplyControl.ApplyAction.aaShow);
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
        private bool GetHISDataFromDataRow(DataRow dw, out ApplyData apply, out PatientData patData)
        {
            apply = new ApplyData();
            patData = new PatientData();
            NoRuleModel noRoleModel = new NoRuleModel(_dbQuery);

            try
            {
                apply.住院号 = dw["住院号"].ToString();
                apply.删除标记 = 0;
                apply.就诊卡号 = dw["就诊卡号"].ToString();
                apply.影像类别 = dw["影像类别"].ToString(); ; 
                apply.患者ID = SqlHelper.GetNumGuid();    //从HIS传过来的病人，暂时新建一个患者ID
                apply.执行科室ID = dw["执行科室ID"].ToString();
                apply.执行院区 = "";                
                apply.申请ID = SqlHelper.GetNumGuid();    //从HIS传过来的病人，新建申请ID
                apply.申请关联ID = "";
                apply.申请日期 = Convert.ToDateTime(dw["申请日期"].ToString());
                apply.申请状态 = (int)ApplyState.asRegister;
                apply.申请识别码 = dw["医嘱ID"].ToString();    //对应HIS的医嘱ID
                apply.门诊号 = dw["门诊号"].ToString();
                
                apply.申请信息.临床诊断 = dw["临床诊断"].ToString(); //单独查询的数据
                apply.申请信息.主页ID = dw["主页ID"].ToString();
                apply.申请信息.体重 = "";
                apply.申请信息.医生嘱托 = dw["申请嘱托"].ToString();
                apply.申请信息.姓名 = dw["姓名"].ToString();
                apply.申请信息.婚姻状况 = dw["婚姻状况"].ToString();
                apply.申请信息.年龄 = dw["年龄"].ToString();
                apply.申请信息.床号 = dw["床号"].ToString();
                apply.申请信息.性别 = dw["性别"].ToString();
                apply.申请信息.是否允许查看报告 = false;
                apply.申请信息.是否危重 = false;
                apply.申请信息.是否婴儿 = dw["婴儿"].ToString() == "1" ? true : false;
                apply.申请信息.是否急诊 = dw["紧急"].ToString() == "1" ? true : false;
                apply.申请信息.是否绿色通道 = false;
                apply.申请信息.来源 = Int32.Parse(dw["病人来源"].ToString());
                apply.申请信息.申请医生 = dw["申请医生"].ToString();
                apply.申请信息.申请科室 = dw["申请科室"].ToString();                                                                           
                apply.申请信息.英文名 = PYConvert.ConvertPy(apply.申请信息.姓名);
                apply.申请信息.身高 = "";
                apply.申请信息.附加内容 = dw["附加内容"].ToString();        //单独查询的数据          
                apply.申请信息.检查项目.项目名称 = dw["项目名称"].ToString();
                apply.申请信息.CopyBasePro(apply);
                
                //患者信息
                patData.删除标记 = 0;
                patData.姓名 = dw["姓名"].ToString();
                patData.患者ID = apply.患者ID;
                patData.患者关联ID = "";
                patData.患者识别码 = dw["病人ID"].ToString();
                patData.身份证号 = dw["身份证号"].ToString();

                patData.患者信息.出生日期 = DateTime.Now.ToString();
                patData.患者信息.国家 = dw["国籍"].ToString();
                patData.患者信息.婚姻状况 = dw["婚姻状况"].ToString();
                patData.患者信息.性别 = dw["性别"].ToString();
                patData.患者信息.民族 = dw["民族"].ToString();
                patData.患者信息.监护人 = "";
                patData.患者信息.籍贯 = dw["籍贯"].ToString();
                patData.患者信息.职业 = dw["职业"].ToString();
                patData.患者信息.证件号码 = dw["身份证号"].ToString();
                patData.患者信息.证件类型 = "身份证";
                patData.患者信息.OftenContact.地址 = dw["常用联系地址"].ToString();
                patData.患者信息.OftenContact.电话 = dw["常用联系电话"].ToString();
                patData.患者信息.OftenContact.邮编 = dw["常用邮编"].ToString();
                patData.患者信息.BakContact.地址 = dw["备用联系地址"].ToString();
                patData.患者信息.BakContact.电话 = dw["备用联系电话"].ToString();
                patData.患者信息.BakContact.邮编 = dw["备用邮编"].ToString();                                                                
                patData.患者信息.CopyBasePro(patData);

                //根据上述信息，产生新的检查号
                apply.检查号 = noRoleModel.GetStudyNo(patData.患者识别码,apply.影像类别, "6LfuLw/NyEabUbskclSyiQ", true);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
            return true;
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

        private DataTable GetPacsStudy()
        {
            DataTable dt = null;
            Dictionary<string, object> dicKeys = new Dictionary<string, object>();           

            try
            {
                if (txtNumber.Text != "")
                {
                    dicKeys.Add(cboNumber.Text, txtNumber.Text);
                }
                if (txtName.Text != "")
                {
                    dicKeys.Add("姓名", txtName.Text);
                }
                if (dtDate.Text != "")
                {
                    dicKeys.Add("申请日期", Convert.ToDateTime(dtDate.Text));
                }
                if (dicKeys.Count == 0)
                {
                    MessageBox.Show("请先选择一个查询条件后，再点击“查询”按钮。");
                    return null;
                }
                dt = ApplyPACSDB.GetPacsApply(dicKeys);
                dt = FormatDatatTable(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return null;
            }
        }


        private DataTable FormatDatatTable(DataTable dt)
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


        //将image转换成byte[]数据
        private byte[] imageToByte(System.Drawing.Image _image)
        {
            MemoryStream ms = new MemoryStream();
            _image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        //将byte[]数据转换成image
        private Image byteToImage(byte[] myByte)
        {
            MemoryStream ms = new MemoryStream(myByte);
            Image _Image = Image.FromStream(ms);
            return _Image;
        }


        /// <summary>
        /// 从HIS数据库查询申请信息
        /// </summary>
        /// <returns></returns>
        private DataTable GetHisApply()
        {
            DataTable dt =null;
            Dictionary<string, object> dicKeys = new Dictionary<string, object>();           
            string strOrderIDs;
            string strOutOrderIDs = "";

            try
            {              
                if (txtNumber.Text != "")
                {
                    dicKeys.Add(cboNumber.Text, txtNumber.Text);                   
                }
                if (txtName.Text != "")
                {
                    dicKeys.Add("姓名", txtName.Text);                    
                }
                if (dtDate.Text != "")
                {
                    dicKeys.Add("开嘱时间",Convert.ToDateTime( dtDate.Text));                   
                }
                if (dicKeys.Count  == 0)
                {
                    MessageBox.Show("请先选择一个查询条件后，再点击“查询”按钮。");
                    return null;
                }
               
                dt = ApplyHISDB.GetApply(dicKeys);

                if (chkRev.Checked == false && dt != null)
                {
                    //获取到HIS返回的数据集后，需要跟PACS的数据比对，只显示PACS没有接收的数据
                    //每次查询的记录数量在1000条以下，oracle in（）的限制
                    //循环dt，获取医嘱ID串
                    strOrderIDs = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strOrderIDs = strOrderIDs + "," + dt.Rows[i]["医嘱ID"].ToString();
                        if (i % 1000 == 0 && i != 0)
                        {
                            //查询一次PACS数据库
                            strOrderIDs = strOrderIDs.Substring(2);
                            strOutOrderIDs = strOutOrderIDs + "," + ApplyPACSDB.GetPacsApplyByOrderID(strOrderIDs);
                            strOrderIDs = "";
                        }
                    }
                    if (strOrderIDs.Length > 0)
                    {
                        //再查询一次数据库
                        strOrderIDs = strOrderIDs.Substring(2);
                        strOutOrderIDs = strOutOrderIDs + "," + ApplyPACSDB.GetPacsApplyByOrderID(strOrderIDs);
                    }
                    if (strOutOrderIDs.Length > 1)
                    {
                        foreach (DataRow dtRow in dt.Rows)
                        {
                            if (strOutOrderIDs.IndexOf("," + dtRow["医嘱ID"].ToString()) > 0)
                            {
                                dt.Rows.Remove(dtRow);
                            }
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return null;
            }
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

                //现在版本，先支持一个HIS库，下次迭代修改，再增加同时连接多个HIS库的方式
                HisServerCfgData cfgData = new HisServerCfgData();
                cfgData.BindRowData(dt.Rows[0]);

                ApplyEnum _ae = new ApplyEnum();
                _applyHISDB = _ae.CreateInstance(cfgData.服务配置.HIS接口名称) as IApply;
                _applyHISDB.ConfigString = cfgData.服务配置.接口配置.ToString();
                _applyHISDB.UserName = _userData.Name;
                _applyHISDB.Init(_dbQuery);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void InitApplyPACSDB()
        {
            if (_applyPACSDB == null) _applyPACSDB = new ApplyModel(_dbQuery);
        }      

        /// <summary>
        /// 重新设置控件布局
        /// </summary>
        private void ResizeControls()
        {
            panelSearch.Left = 0;
            panelSearch.Top = 0;

            tabControl.Left = 0;
            tabControl.Top = panelSearch.Top + panelSearch.Height + 10;
            tabControl.Height = split.Panel1.Height - panelSearch.Height - 10;
            tabControl.Width = split.Panel1.Width;

            //vTable.Left = 0;
            //vTable.Top = 0;
            //vTable.Width = panelTable.Width;
            //vTable.Height = panelTable.Height;

            applyControl.Left = 0;        
            applyControl.Top = panButtons.Height;
            applyControl.Width = split.Panel2.Width;
            applyControl.Height = split.Panel2.Height - panButtons.Height ;
        }

        /// <summary>
        /// 显示一个检查申请
        /// </summary>
        /// <param name="strOrderID">HIS的医嘱ID</param>
        private void ShowOneApply(string strOrderID)
        {
            SetButtonState(ButtonState.bsNormal);
            DataRow[] drs1 = _dtHIS.Select("医嘱ID = " + strOrderID);        
            
            if (drs1.Length >=1)
            {
                //将医嘱的其他信息，附加到datarow中
                DataTable dt = ApplyHISDB.GetOrderInfo(strOrderID);                
                drs1[0]["附加内容"] = dt.Rows[0]["附加内容"];
                drs1[0]["临床诊断"] = dt.Rows[0]["临床诊断"];
                GetHISDataFromDataRow(drs1[0], out _applyData, out _patData);
                applyControl.RefreshApplyData(_applyData, _patData, null, Apply.ApplyControl.ApplyAction.aaReceive);
            }
        }

        /// <summary>
        /// 显示PACS的检查信息
        /// </summary>
        /// <param name="strStudyID"></param>
        private void ShowOneStudy(string strStudyID)
        {
            SetButtonState(ButtonState.bsNormal);
            DataRow[] drs1 = _dtPACS.Select("申请ID = '" + strStudyID + "'");
            if (drs1.Length >= 1)
            {
                GetPacsDataFromDataRow(drs1[0], out _applyData, out _patData);
                List<StudyExecuteData> studyExecuteDatas = new List<StudyExecuteData>();
                StudyExecuteModel seModel = new StudyExecuteModel(_dbQuery);
                studyExecuteDatas = seModel.GetStudyExecuteData(_applyData.申请ID);
                applyControl.RefreshApplyData(_applyData, _patData, studyExecuteDatas, Apply.ApplyControl.ApplyAction.aaShow);
            }
        }

        private bool ReceiveHisApply(string strOrderID)
        {
            try
            {
                //将数据提取到PACS表中
                if (applyControl.SaveApply( Apply.ApplyControl.ApplyAction.aaReceive) == true)
                {
                    //通知HIS
                    ApplyHISDB.ReceiveApply(strOrderID);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        private bool NewApply()
        {
            Dictionary<string, string> applyInfo = new Dictionary<string, string>();
            Dictionary<string, string> patientInfo = new Dictionary<string, string>();                       

            try
            {
                frmNewStudy newStudyForm = new frmNewStudy(_dbQuery);

                newStudyForm.ShowDialog();
                if (newStudyForm.DialogResult == DialogResult.OK)
                {         
                    //从界面提取申请信息
                    

                    //添加检查项目信息
                    string strItemID = newStudyForm.ItemID;
                    string strOrderContent = newStudyForm.OrderContent;
                    JApplyExamItem oneExamItem = newStudyForm.oneExamItem;
                    string strBodyparts = newStudyForm.Bodyparts;
                    string strModality = newStudyForm.Modality;
                    ApplyData appExamItem = new ApplyData();

                    appExamItem.影像类别 = strModality;
                    appExamItem.申请项目ID = strItemID;
                    appExamItem.申请信息.检查项目 = new JApplyExamItem();
                    appExamItem.申请信息.检查项目.项目名称 = strOrderContent;
                    appExamItem.申请信息.检查项目 = oneExamItem;
                    applyControl.SetNewExamItem(appExamItem);

                    ApplyPACSDB.NewApply(_applyData);

                    //设置传给HIS的信息
                    applyInfo.Add("Order_ID", "0");//传空
                    applyInfo.Add("Patient_ID", "0");
                    applyInfo.Add("Patient_Source", "3");//外诊
                    applyInfo.Add("Page_ID", "0");
                    applyInfo.Add("Reg_NO", "");
                    applyInfo.Add("App_Dept_ID", "0");//必填
                    applyInfo.Add("App_Doctor", "Doc");//必填
                    applyInfo.Add("App_Date", DateTime.Now.ToString());
                    applyInfo.Add("Clinic_Item_ID", "758");//strItemID
                    applyInfo.Add("Body_Part_Method", strBodyparts);
                    applyInfo.Add("Order_Content", strOrderContent);
                    applyInfo.Add("Emergency", "0");

                    patientInfo.Add("Patient_ID", "0");//传空
                    patientInfo.Add("Patient_Name", _patData.姓名);
                    patientInfo.Add("Patient_Sex", _patData.患者信息.性别);
                    patientInfo.Add("Birthday", _patData.患者信息.出生日期);
                    patientInfo.Add("Patient_Age", "");
                    patientInfo.Add("Patient_Race", _patData.患者信息.民族);
                    patientInfo.Add("Marital_Status", _patData.患者信息.婚姻状况);
                    patientInfo.Add("Patient_Career", _patData.患者信息.职业);
                    patientInfo.Add("ID_Card", _patData.身份证号);
                    patientInfo.Add("Address", _patData.患者信息.OftenContact.地址);
                    patientInfo.Add("Phone_Num", _patData.患者信息.OftenContact.电话);
                    patientInfo.Add("Zip_Code", _patData.患者信息.OftenContact.邮编);
                    patientInfo.Add("Fee_Type", "");    //费别
                    patientInfo.Add("Payment_Type", ""); //医疗付款方式
                    patientInfo.Add("Patient_Nation", _patData.患者信息.国家);

                    ApplyHISDB.NewApply(applyInfo, patientInfo);
                }
                return true;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }
        

        private bool ValidateAppData(string strItemID,string strOrderContent)
        {
            if (strItemID == "")
            {
                MsgBox.ShowInf("诊疗项目ID为空，请重新选择诊疗项目后，再登记。");
                return false;
            }

            if (strOrderContent == "")
            {
                MsgBox.ShowInf("医嘱内容为空，请重新选择诊疗项目后，再登记。");
                return false;
            }

            if (_applyData == null)
            {
                MsgBox.ShowInf("申请信息为空，请重新填写。");
                return false;
            }
            if(_patData == null)
            {
                MsgBox.ShowInf("患者信息为空，请重新填写。");
                return false;
            }

            return true;
        }

        private void RejectApply()
        {
            if (_applyData != null)
            {
                ApplyHISDB.RejectApply(_applyData.申请关联ID);
            }
        }

        #endregion

        private void btnNewApply_Click(object sender, EventArgs e)
        {
            if (btnNewApply.Text == "新增")
            {
                applyControl.ApplyActionState = Apply.ApplyControl.ApplyAction.aaNew;
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
                    applyControl.SetNewExamItem(appExamItem);

                }
            }
            else
            {                
                if (applyControl.SaveApply(Apply.ApplyControl.ApplyAction.aaNew)==true )
                {
                    //保存成功了才改变状态
                    SetButtonState(ButtonState.bsNormal);
                    applyControl.ApplyActionState = Apply.ApplyControl.ApplyAction.aaShow;
                }
                
            }                      
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

        private void SetNormalButtonState(bool isNormal)
        {
            btnPrintSetup.Enabled = isNormal;
            btnPrint.Enabled = isNormal;
            btnScan.Enabled = isNormal;
            btnReceive.Enabled = isNormal;
            btnNewApply.Enabled = isNormal;
            btnNewApply.Text = "新增";
            btnModify.Enabled = isNormal;
            btnModify.Text = "修改";
            btnReject.Enabled = isNormal;
            btnCancel.Visible = ( isNormal==false);
        }
        private void btnReject_Click(object sender, EventArgs e)
        {
            RejectApply();
        }

        private void vPacsTable_UserControlFocusedRowChanged(string strOrderID)
        {
            _申请ID = strOrderID;
            ShowOneStudy(_申请ID);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (btnModify.Text == "修改")
            {
                applyControl.ApplyActionState = Apply.ApplyControl.ApplyAction.aaUpdate;
                SetButtonState(ButtonState.bsUpdate);
            }
            else
            {                
                if( ModifyApply()==true)
                {
                    //修改成功了，才改变状态
                    SetButtonState(ButtonState.bsNormal);
                    applyControl.ApplyActionState = Apply.ApplyControl.ApplyAction.aaShow;
                    QueryClick();
                }                
            }            
        }

        private bool ModifyApply()
        {
            try
            {
                applyControl.SaveApply(Apply.ApplyControl.ApplyAction.aaUpdate);                               
                return true;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        private void vHisTable_Load(object sender, EventArgs e)
        {

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                applyControl.ApplyActionState = Apply.ApplyControl.ApplyAction.aaReceive;
            }
            else
            {
                applyControl.ApplyActionState = Apply.ApplyControl.ApplyAction.aaShow;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetButtonState(ButtonState.bsNormal);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
