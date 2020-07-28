using DevExpress.XtraBars.Docking;
using DevExpress.XtraLayout;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Design;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.Layout
{
    public delegate void SaveWindowLayout(BizMainLayout bizWindow, string designWinKey, string layoutFmt);
    public delegate void ReadWindowLayout(BizMainLayout bizWindow, ref string designWinKey, out string layoutFmt);
    public delegate void QueryParentWindowName(string designWinKey, out List<string> names);
    public delegate void MdiWindowChange(string designWinKey, bool isToMdiWindow);

    public delegate void ProcessStateSync(string stateMsg, bool isFinal = false);
    public partial class BizMainLayout : BizDesignBase, ISysDesign, ISysMainModule, IBizDataQuery
    {




        //*******************************************************************************************************************

        public event SaveWindowLayout OnSaveWindowLayout;
        public event ReadWindowLayout OnReadWindowLayout;
        public event QueryParentWindowName OnQueryParentWindowName;
        public event MdiWindowChange OnMdiWindowChange;
        public event ProcessStateSync OnStateSync;

        private bool _isCustomerShowing = false;//判断layout是否正在处理showcustom事件

        private bool _isLayoutLoading = false;//判断layout配置是否正在载入
        private bool _isLoadComplete = false;
        private bool _isItemAdding = false;

        private ModuleDockState _dockState = null;
        private Type _dragType = null;
        private bool _isLayoutCustomer = false;//是否进入layout的custom状态

        /// <summary>
        /// 状态变量，判断是否已经载入了对应的程序集
        /// </summary>
        private bool _isLoadedAssemblyControls = false;

        private DesignControlInstances _dynCreateControl = null;//Dictionary<模块名称,DynamicControlInfo>
        private List<Control> _designCtls = null;


        private WindowConfiguration _windowConfiguration = null;

        private DesignMiddleWare _middleWare = null;
        private bool _allowDelElement = false;
        private bool _isModifyDesign = false;

        public BizMainLayout()
               : this(true, "")
        {

        }

        public BizMainLayout(bool isDesignMode)
            : this(isDesignMode, "")
        {

        }
        public BizMainLayout(bool isDesignMode, string layoutFmt)
            : base(isDesignMode)
        {
            InitializeComponent();

            CloseDesignFace();

            if (_isDesignMode)
            {
                dmLayout.DockingOptions.ShowCloseButton = true;
            }
            else
            {
                dmLayout.DockingOptions.ShowCloseButton = false;
            }

            pgWindow.SelectedObject = this;

            _windowConfiguration = new WindowConfiguration();

            if (string.IsNullOrEmpty(layoutFmt) == false)
            {
                _windowConfiguration = JsonHelper.DeserializeObject<WindowConfiguration>(layoutFmt);
            }

            layoutLeft.Visible = false;
            layoutRight.Visible = false;
            layoutBottom.Visible = false;
            layoutNavigate.Visible = false;
            layoutWork.Visible = false;


            this.FormClosing -= DoCloseingEvent;
            this.FormClosing += DoCloseingEvent;

            this.FormClosed -= DoCloseedEvent;
            this.FormClosed += DoCloseedEvent;

        }

        private string _designWinKey = "";
        private string _designWinName = "";
        private Panel _parentMdiLeftPanel = null;
        private Panel _parentMdiRightPanel = null; 
         
        public void SetDesignText(string designWindowKey, string designName, Panel leftPanel, Panel rightPanel)
        {
            _parentMdiLeftPanel = leftPanel;
            _parentMdiRightPanel = rightPanel; 

            _designWinKey = designWindowKey;
            _designWinName = designName;
            labTitle.Text = "●  " + _designWinName;
        }

        public string DesignWindowName
        {
            get { return _designWinName; }
        }

        private void DoCloseingEvent(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (DoBindActions(_designEvents["系统退出前事件"], sender) == false)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void DoCloseedEvent(object sender, EventArgs e)
        {
            try
            {
                DoBindActions(_designEvents["系统退出事件"], sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 打开设计面板
        /// </summary>
        private void OpenDesignFace()
        {
            if (this.MdiParent == null)
            {
                
                dockDesignFace.Show();
                dockDesignFace.Dock = DockingStyle.Float;

                dockMove.Show();
                dockMove.Dock = DockingStyle.Float;
                
            }

            panelHide.Visible = true;
            listView1.Visible = true;
        }

        /// <summary>
        /// 关闭设计面板
        /// </summary>
        private void CloseDesignFace()
        {            
            panelHide.Visible = false;
            listView1.Visible = false;

            if (this.MdiParent == null)
            {
                try
                {
                    dockMove.Close();
                }
                catch { }
                try
                {
                    dockDesignFace.Close();
                }
                catch { }
            }
        }

        /// <summary>
        /// 预先加载程序集
        /// </summary>
        public virtual void BeforeLoadAssembly()
        {
            if (_isDesignMode == false)
            {
                //非界面设计模式时，才需要进行隐藏
                CloseDesignFace();
            }

            if (this.DesignMode) return;
            if (_isLoadedAssemblyControls) return;

            ProcessStateHint("从数据库读取窗体配置。");

            //从数据库载入配置
            ResetWindowConfigurationFromDB();

            ProcessStateHint("恢复窗体状态。");

            RestoreDockManager();
            RestoreWindowState();

            ProcessStateHint("初始化界面布局。");
            RegFixedItem(layoutNavigate);
            RegFixedItem(layoutLeft);
            RegFixedItem(layoutRight);
            RegFixedItem(layoutBottom);
            RegFixedItem(layoutWork);
            //RegFixedItem(layoutHide);

            InitLayout(layoutNavigate);
            InitLayout(layoutLeft);
            InitLayout(layoutRight);
            InitLayout(layoutBottom);
            InitLayout(layoutWork);
            //InitLayout(layoutHide);


            //dockPanelLeft.Close();
            //dockPanelRight.Close();
            //dockPanelBottom.Close();

            ProcessStateHint("读取动态组件。");
            //初始化需要动态创建的控件
            RestoreDynamicControls();

            ProcessStateHint("更新动态组件状态。");
            UpdateDynamicControls();

            ProcessStateHint("初始化窗体设计元素。");
            InitDesignControlElement(OnStateSync);

            _isLoadedAssemblyControls = true;
        }

        private void SelDesignControlProcess(object selControl)
        {
            if (_middleWare != null) _middleWare.Visible = false;


            _designCtls = DesignHelper.GetDesignControls(this);
            ResetRelateModules(_designCtls);

            if (selControl is LayoutControlItem)
            {
                pgDesign.SelectedObject = new LayoutControlItemProWrapper(selControl as LayoutControlItem);
            }
            else if (selControl is LayoutControlGroup)
            {
                pgDesign.SelectedObject = new LayoutControlGroupProWrapper(selControl as LayoutControlGroup);
            }
            else if (selControl is TabbedControlGroup)
            {
                pgDesign.SelectedObject = new TabbedControlGroupProWrapper(selControl as TabbedControlGroup);
            }
            else
            {
                pgDesign.SelectedObject = selControl;
            }

            pgDesign.ExpandAllGridItems();
        }


        private static System.Type toolboxBitmapAttributeType = typeof(ToolboxBitmapAttribute);
        private Image GetControlIcon(object control)
        {
            ToolboxBitmapAttribute attribute = TypeDescriptor.GetAttributes(control)[toolboxBitmapAttributeType] as ToolboxBitmapAttribute;
            if (attribute != null)
            {
                //img里取到的即是控件textBox1在工具箱中的图标 
                return attribute.GetImage(control, true);
            }

            return null;

        }


        protected void ReinitModule(List<Control> ctls)
        {
            if (this.DesignMode) return;

            foreach (Control ctl in ctls)
            {
                ISysBizModule dc = ctl as ISysBizModule;

                if (dc != null && ((dc as Control).Name != this.Name))
                {
                    DesignControl uc = dc as DesignControl;
                    uc.DesignMode = _isDesignMode;

                    if (uc != null)
                    {
                        uc.Load -= ControlLoadEvent;
                        uc.Load += ControlLoadEvent;
                    }

                    ProcessStateHint("初始化界面组件：" + uc.ModuleName);

                    try
                    {
                        dc.Init(_designWinKey, _dbHelper, _dataTransCenter, _stationInfo, _userData, _parameters, _sysLog);
                    }
                    catch (Exception ex)
                    {
                        MsgBox.ShowException(ex, this);
                    }
                }
            }
        }


        /// <summary>
        /// 重设关联模块
        /// </summary>
        protected void ResetRelateModules(List<Control> ctls)
        {
            _regBizModules.Clear();

            foreach (Control ctl in ctls)
            {
                ISysDesign dc = ctl as ISysDesign;

                string pName = "";
                if (dc != null && (dc as Control).Parent != null)
                {
                    pName = (dc as Control).Parent.Name;
                }


                if (dc != null && (pName != nbDesignElementsList.Name))
                {
                    LayoutControl lcFind = (ctl.Parent as LayoutControl);

                    if (lcFind != null)
                    {
                        LayoutControlItem findItem = lcFind.GetItemByControl(ctl);

                        if (findItem == null) continue;
                        //if (findItem.Visible == false) continue;
                    }

                    if (_regBizModules.ContainsKey(dc.ModuleName) == false)
                    {
                        _regBizModules.Add(dc.ModuleName, dc);
                    }

                    dc.RelateModules = _regBizModules;
                }
            }
        }

        protected override void InitBaseInfo()
        {
            _moduleName = "系统模块";

            _provideActionDesc.Add("测试", "模块之间进行测试使用的方法");
            _provideActionDesc.Add("退出系统", "退出当前系统");
            _provideActionDesc.Add("全屏窗口", "根据执行标记切换对应模块到满屏窗口，只有模块在DockPanel窗口中才有效。");
            _provideActionDesc.Add("退出全屏", "退出进入全屏模式的窗口");
            _provideActionDesc.Add("切换模块", "根据执行标记切换指定的模块，只有模块加入到分组后才有效。");
            _provideActionDesc.Add("布局调整", "调整界面布局方式。");
            _provideActionDesc.Add("打开网页", "根据执行标记打开指定的网页。");
            _provideActionDesc.Add("打开程序", "根据执行标记打开指定的程序。");
            _provideActionDesc.Add("打开子窗体(模态)", "根据执行标记打开指定的子窗体,窗体名称必须在窗口管理配置中存在。");
            _provideActionDesc.Add("打开子窗体(非模态)", "根据执行标记打开指定的子窗体,窗体名称必须在窗口管理配置中存在。");
            _provideActionDesc.Add("打开提示框", "根据执行标记进行对应的内容显示。");
            _provideActionDesc.Add("打开确认框", "根据执行标记进行确认提示。");

            _provideActionDesc.Add("锁定系统", "将系统进入锁定状态");



            //_designTools.Add("", true); 

            _designEvents.Add("系统加载事件", new EventActionReleation("系统加载事件", ActionType.atSysFixedEvent));
            _designEvents.Add("系统退出事件", new EventActionReleation("系统退出事件", ActionType.atSysFixedEvent));
            _designEvents.Add("系统退出前事件", new EventActionReleation("系统退出前事件", ActionType.atSysFixedEvent));
        }

        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {
                switch (actName)
                {
                    case "测试":
                        if (bizDatas == null) return false;

                        MessageBox.Show("接收到模块" + callModuleName + "对方法" + actName + "的调用请求。" + System.Environment.NewLine + "(执行标记： " + tag + "  请求数据：" + bizDatas.DataName + ")");


                        break;

                    case "退出系统":
                        this.Close();
                        return true;

                    case "全屏窗口":
                        if (string.IsNullOrEmpty(tag)) return true;

                        Control mc = (_regBizModules[tag] as Control);
                        if (mc == null) return true;

                        DockPanel dp = GetParentPanel(mc);
                        if (dp == null) return true;

                        if (_dockState != null)
                        {
                            //先退出全屏
                            if (_dockState.CurDockPanel.Equals(dp)) return true; //如果进入的是相同的模块，则不需要执行后续处理
                            DockEmbed(_dockState.CurDockPanel);
                        }

                        //进入全屏
                        DockFull(dp);

                        return true;
                    case "退出全屏":
                        if (_dockState != null)
                        {
                            DockEmbed(_dockState.CurDockPanel);
                        }

                        break;

                    case "切换模块":
                        if (string.IsNullOrEmpty(tag)) return true;

                        Control mc1 = (_regBizModules[tag] as Control);
                        if (mc1 == null) return true;

                        LayoutControlGroup lcg = (layoutLeft.GetItemByControl(mc1).Parent as LayoutControlGroup);
                        if (lcg == null) return true;
                        //模块切换处理
                        TabbedControlGroup tcg = (lcg.ParentTabbedGroup as TabbedControlGroup);

                        if (tcg != null) tcg.SelectedTabPage = lcg;


                        break;

                    case "布局调整":
                        layoutWork.ShowCustomizationForm();
                        break;


                    case "打开网页":
                        string urlAddres = ParseExecuteTag(tag, bizDatas);
                        System.Diagnostics.Process.Start(urlAddres);

                        break;

                    case "打开程序":
                        string program = ParseExecuteTag(tag, bizDatas);

                        program = program + "?";

                        string[] progInfo = program.Split('?');

                        System.Diagnostics.Process.Start(progInfo[0], progInfo[1]);
                        break;

                    case "打开子窗体(模态)":
                        OpenSubWindow(tag, true);

                        break;

                    case "打开子窗体(非模态)":
                        OpenSubWindow(tag, false);

                        break;

                    case "打开提示框":
                        string hint = ParseExecuteTag(tag, bizDatas);

                        MessageBox.Show(hint, "提示");

                        break;

                    case "打开确认框":
                        string sureInfo = ParseExecuteTag(tag, bizDatas);

                        DialogResult dr = MessageBox.Show(sureInfo, "提示", MessageBoxButtons.YesNo);

                        if (dr == DialogResult.No)
                        {
                            return false;
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

        private RoleWindowModel _rwm = null;

        private RoleWindowModel RoleWindowModel
        {
            get
            {
                if (_rwm == null ) _rwm = new RoleWindowModel(_dbHelper);
                return _rwm;
            }
        }


        public void _Link_ResetModules()
        {
            _regBizModules.Clear();

            _regBizModules.Add(this.ModuleName, this as ISysDesign);

            foreach (DesignControlInstanceInfo ctl in _dynCreateControl.Values)
            {
                _regBizModules.Add(ctl.ModuleName, ctl.Instance as ISysDesign);
            }
        }


        public void _Link_RestoreControls()
        {
            //初始化需要动态创建的控件
            //_dynCreateControl包含用户拖拽时添加的控件信息和程序设计界面固定添加的控件信息
            //系统首次启动时，由于没有_windowConfiguration配置信息，因此不会创建_dynCreateControl的数据项

            _dynCreateControl = new DesignControlInstances();// Dictionary<string, DesignControlInstanceInfo>();

            if (_windowConfiguration == null) return;

            string dynamicControlData = _windowConfiguration.DynamicControl;

            if (string.IsNullOrEmpty(dynamicControlData)) return;

            //读取动态配置的模块
            _dynCreateControl = JsonHelper.DeserializeObject<DesignControlInstances>(dynamicControlData);// DictionaryJsonHelper.DeserializeStringToDictionary<string, DesignControlInstanceInfo>(dynamicControlData) as DesignControlInstances;

            if (_dynCreateControl.Count <= 0) return;

            List<Control> systemControls = DesignHelper.GetDesignControls(this);

            foreach (string moduleName in _dynCreateControl.Keys)
            {
                DesignControlInstanceInfo moduleInfo = _dynCreateControl[moduleName];

                if (moduleInfo.IsSystemCreate)
                {
                    //根据模块对应的实例名称，设置关联信息
                    foreach (Control ctlSystem in systemControls)
                    {
                        if ((ctlSystem as ISysDesign).ModuleName == moduleInfo.ModuleName)
                        {
                            moduleInfo.Instance = ctlSystem;
                            if (string.IsNullOrEmpty(moduleInfo.InstanceName) == false)
                            {
                                ctlSystem.Name = moduleInfo.InstanceName;
                            }
                            else
                            {
                                moduleInfo.InstanceName = ctlSystem.Name;
                            }

                            if (string.IsNullOrEmpty(moduleInfo.InstanceState) == false)
                            {
                                (ctlSystem as ISysDesign).SetSerializableFmt(moduleInfo.InstanceState);
                            }
                            else
                            {
                                moduleInfo.InstanceState = (ctlSystem as ISysDesign).GetSerializableFmt();
                            }

                            break;
                        }
                    }

                    if (moduleInfo.Instance != null) continue;
                }

                DesignControl Instance = null;

                try
                {

                    DesignAssemblyInfo assemblyInfo = InstanceAssembly(System.Windows.Forms.Application.StartupPath + @"\" + moduleInfo.ModuleFile,
                                                        moduleInfo.AssemblyName + "." + moduleInfo.ControlName, moduleInfo.assembly);

                    Instance = assemblyInfo.DesignInstance;
                    if (Instance != null)
                    {
                        Instance.DesignMode = _isDesignMode;

                        moduleInfo.Instance = Instance;
                    } 

                    if (moduleInfo.assembly == null) moduleInfo.assembly = assemblyInfo.DesignAssembly;
                }
                catch (Exception ex)
                {
                    MsgBox.ShowException(ex, "模块[" + moduleName + ":" + moduleInfo.ModuleFile + "] 创建失败，系统将不能加载此模块。", this);
                }
            }
        }

        public BizMainLayout _Link_GetDesignWindow(string windowName)
        {
            WindowInfoData windowInfo = RoleWindowModel.GetWindowInfoByName(windowName, _stationInfo.DepartmentId);
            if (windowInfo == null)
            {
                MessageBox.Show("未找到对应的窗体信息，操作终止。", "提示");
                return null;
            }

            BizMainLayout bml = new BizMainLayout(false, windowInfo.窗体信息.布局配置);

            bml.Init(_dbHelper, _userData, _stationInfo, _dataTransCenter);

            bml.ResetWindowConfigurationFromDB();

            bml._Link_RestoreControls();
            bml._Link_ResetModules();
             
            return bml;

        }

       
        
        private void OpenSubWindow(string windowName, bool isModal)
        {
            if (string.IsNullOrEmpty(_userData.DepartmentId))
            {
                MessageBox.Show("用户科室信息无效，不能打开对应窗体。", "提示");
                return;
            }
             
            WindowInfoData windowInfo = RoleWindowModel.GetWindowInfoByName(windowName, _userData.DepartmentId);
            if (windowInfo == null)
            {
                MessageBox.Show("未找到对应的窗体信息，操作终止。", "提示");
                return;
            }

            BizMainLayout bml = new BizMainLayout(false, windowInfo.窗体信息.布局配置);

            //bml.Visible = false;

            bml.Init(_dbHelper, _userData, _stationInfo, _dataTransCenter);

            bml.BeforeLoadAssembly();

            bml.RelateModules.ParentWindowBizModules = _regBizModules;

            if (isModal)
            {
                bml.ShowDialog(this);
            }
            else
            {
                bml.Show(this);
            }
        }



        /// <summary>
        /// 解析执行标记内容
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="dataIdentificationName"></param>
        /// <returns></returns>
        private string ParseExecuteTag(string tag, IBizDataItems bizDatas)
        {
            string context = tag;

            if (bizDatas != null)
            {
                IList<string> pars = GetParsName(context);
                 
                if (bizDatas.Count > 0)
                {
                    foreach (string par in pars)
                    {
                        context = context.Replace("[@" + par + "]", bizDatas[0][par].ToString());
                    }
                }
                else
                {
                    foreach (string par in pars)
                    {
                        context = context.Replace("[@" + par + "]", "null");
                    }
                }
            }

            return context;
        }

        /// <summary>
        /// 获取执行标记中配置的参数名称
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private IList<string> GetParsName(string source)
        {
            int index = source.IndexOf("[@");
            if (index <= 0) return null;

            string pars = source;
            string parName = "";

            List<string> result = new List<string>();

            while (index > 0)
            {
                pars = source.Substring(index);

                parName = pars.Substring(2, pars.IndexOf("]") - 2);
                result.Add(parName);

                pars = pars.Substring(pars.IndexOf("]") + 1);
                index = pars.IndexOf("[@");
            }

            return result;
        }

        private void DockEmbed(DockPanel dp)
        {
            if (_dockState != null)
            {
                dmLayout.BeginUpdate();

                dmLayout.DockController.Dock(dp);
                dp.Visibility = _dockState.Visibility;


                dmLayout.EndUpdate();

                _dockState = null;
            }

        }

        private void DockFull(DockPanel dp)
        {
            dmLayout.BeginUpdate();

            if (_dockState == null)
            {
                _dockState = new ModuleDockState(dp.Visibility);
                _dockState.CurDockPanel = dp;
            }

            dp.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;

            dp.MakeFloat();


            dp.FloatForm.Left = this.Left + 6;
            dp.FloatForm.Top = this.Top + layoutNavigate.Height + 6;
            dp.FloatForm.Width = this.Width - 12;
            dp.FloatForm.Height = this.Height - layoutNavigate.Height - statusStrip1.Height - 12;


            dmLayout.EndUpdate();
        }

        private DockPanel GetParentPanel(Control module)
        {
            Control mp = module.Parent;

            while (mp != null)
            {
                if ((mp as DockPanel) != null) return (mp as DockPanel);

                mp = mp.Parent;
            }

            return null;
        }

        private void frmLayout_Load(object sender, EventArgs e)
        {
            if (_isDesignMode)
            {
                if (this.MdiParent == null)
                {
                    Screen screenWindow = Screen.FromControl(this);

                    dockDesignFace.FloatLocation = new Point(screenWindow.WorkingArea.Left, 0);
                    dockDesignFace.FloatSize = new Size(dockDesignFace.Width, Screen.FromControl(this).WorkingArea.Height);

                    if (this.Left < screenWindow.WorkingArea.Left + dockDesignFace.Width)
                    {
                        this.Left = screenWindow.WorkingArea.Left + dockDesignFace.Width;
                    }

                    dockMove.FloatLocation = new Point(this.Left + this.Width, this.Top);
                    dockMove.FloatSize = new Size(dockMove.Width, this.Height);
                }
                else
                {
                    if (_parentMdiLeftPanel != null)
                    {
                        panelHide.Parent = _parentMdiLeftPanel;
                        panelHide.Dock = DockStyle.Fill;
                    }
                    else
                    {
                        panelHide.Parent = this.MdiParent;
                        panelHide.Dock = DockStyle.Left;
                    }

                    if (_parentMdiRightPanel != null)
                    {
                        listView1.Parent = _parentMdiRightPanel;
                        listView1.Dock = DockStyle.Fill;
                    }
                    else
                    {
                        listView1.Parent = this.MdiParent;
                        listView1.Dock = DockStyle.Right;
                    }


                    dockDesignFace.Close();
                    dockMove.Close();
                }
            }
            else
            {
                DesignHelper.RestoreWindowPostion(this);
                DesignHelper.RestoreDockManager(this, dmLayout);

                dmLayout.DockingOptions.ShowCloseButton = false;
            }

            //ResetWindowConfigurationFromDB();
            HandleDestroyed += EventHandlerProcess;

            pgDesign.BrowsableAttributes = new AttributeCollection(new CategoryAttribute("DESIGN"));
            pgWindow.BrowsableAttributes = new AttributeCollection(new CategoryAttribute("DESIGN"));

            //RestoreWindowState();

            InitUserInfo();

            tsbDBServerName.Text = "服务器:" + _stationInfo.DBServerName;

            //Reload();
            //if (base.DesignMode == false)
            timerLoad.Enabled = true;


        }


        private void EventHandlerProcess(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                HandleDestroyed -= EventHandlerProcess;
                return;
            }

            foreach (KeyValuePair<string, ISysDesign> kv in _regBizModules)
            {
                if (kv.Value == null) continue;

                try
                {
                    kv.Value.Terminated();
                    Control dc = kv.Value as Control;

                    if (dc != null && dc != this)
                    {
                        dc.Dispose();
                        this.Controls.Remove(dc);
                    }
                }
                catch(Exception ex)
                {
                    MsgBox.ShowException(ex, this);
                }
            }

            _regBizModules.Clear();
            _dynCreateControl.Clear();
             
            HandleDestroyed -= EventHandlerProcess;
        }

        private void InitUserInfo()
        {
            if (_userData == null) return;

            tsbLogin.Text = _userData.Name;
            tsbLogin.Enabled = false;

            tsbRecored.Text = _userData.AssistUserInfo1.Name;
            tsbCapture.Text = _userData.AssistUserInfo2.Name;

            if (_isDesignMode == false)
            {
                UserModel um = new UserModel(_dbHelper);

                DataTable dtUser = um.GetDepartmentUsers(_stationInfo.DepartmentId);

                foreach (DataRow dr in dtUser.Rows)
                {
                    ToolStripItem tsbWriteUser = tsbRecored.DropDownItems.Add(dr["用户名称"].ToString());
                    tsbWriteUser.Tag = dr["用户ID"].ToString();
                    tsbWriteUser.Click += ChangeRecordUser;

                    ToolStripItem tsbCaptureUser = tsbCapture.DropDownItems.Add(dr["用户名称"].ToString());
                    tsbCaptureUser.Tag = dr["用户ID"].ToString();
                    tsbCaptureUser.Click += ChangeCaptureUser;
                }
            }
        }

        private void ChangeRecordUser(object sender, EventArgs e)
        {
            ToolStripItem tsi = sender as ToolStripItem;

            if (tsi == null) return;

            string userId = tsi.Tag.ToString();

            UserModel um = new UserModel(_dbHelper);
            UserInfoData userInfo = um.GetUserInfoByUserID(userId);

            if (userInfo == null) return;

            _userData.AssistUserInfo1.UserId = userId;
            _userData.AssistUserInfo1.Account = userInfo.系统账号;
            _userData.AssistUserInfo1.Name = userInfo.用户名称;
            _userData.AssistUserInfo1.SignImg = userInfo.签名图片;

            tsbRecored.Text = userInfo.用户名称;
        }

        private void ChangeCaptureUser(object sender, EventArgs e)
        {
            ToolStripItem tsi = sender as ToolStripItem;

            if (tsi == null) return;

            string userId = tsi.Tag.ToString();

            UserModel um = new UserModel(_dbHelper);
            UserInfoData userInfo = um.GetUserInfoByUserID(userId);

            if (userInfo == null) return;

            _userData.AssistUserInfo2.UserId = userId;
            _userData.AssistUserInfo2.Account = userInfo.系统账号;
            _userData.AssistUserInfo2.Name = userInfo.用户名称;
            _userData.AssistUserInfo2.SignImg = userInfo.签名图片;

            tsbCapture.Text = userInfo.用户名称;
        }

        /// <summary>
        /// 重置CTL组件布局
        /// </summary>
        private void ResetModuleLayout()
        {
            //注册模块
            if (this.DesignMode == false)
            {

                RestoreLayout();

                Application.DoEvents();

                if (LeftFace)
                {
                    if (layoutLeft.Root.Count <= 0)
                    {
                        dockPanelLeft.Show();
                        dockPanelLeft.Close();
                    }
                    else
                    {
                        try
                        {
                            dockPanelLeft.Show();
                            layoutLeft.Visible = true;

                            if (!layoutLeft.Root.Name.Equals(layoutLeft.Root.Text))
                            {
                                dockPanelLeft.Text = layoutLeft.Root.Text;
                            }
                        }
                        catch (Exception ex)
                        {
                            MsgBox.ShowException(ex, this);
                        }
                    }
                }
                else
                {
                    dockPanelLeft.Show();
                    dockPanelLeft.Close();
                }

                if (RightFace)
                {
                    if (layoutRight.Root.Count <= 0)
                    {
                        dockPanelRight.Show();
                        dockPanelRight.Close();
                    }
                    else
                    {
                        try
                        {
                            dockPanelRight.Show();
                            layoutRight.Visible = true;

                            if (!layoutRight.Root.Name.Equals(layoutRight.Root.Text))
                            {
                                dockPanelRight.Text = layoutRight.Root.Text;
                            }
                        }
                        catch (Exception ex)
                        {
                            MsgBox.ShowException(ex, this);
                        }
                    }
                }
                else
                {
                    dockPanelRight.Show();
                    dockPanelRight.Close();
                }

                if (BottomFace)
                {
                    if (layoutBottom.Root.Count <= 0)
                    {
                        dockPanelBottom.Show();
                        dockPanelBottom.Close();
                    }
                    else
                    {
                        try
                        {
                            dockPanelBottom.Show();
                            layoutBottom.Visible = true;

                            if (!layoutBottom.Root.Name.Equals(layoutBottom.Root.Text))
                            {
                                dockPanelBottom.Text = layoutBottom.Root.Text;
                            }
                        }
                        catch (Exception ex)
                        {
                            MsgBox.ShowException(ex, this);
                        }
                    }
                }
                else
                {
                    dockPanelBottom.Show();
                    dockPanelBottom.Close();
                }

                try
                {
                    if (TopFace) layoutNavigate.Visible = (layoutNavigate.Root.Count <= 0 ? false : true);
                }
                catch (Exception ex)
                {
                    MsgBox.ShowException(ex, this);
                }

                try
                {
                    layoutWork.Visible = (layoutWork.Root.Count <= 0 ? false : true);
                }
                catch (Exception ex)
                {
                    MsgBox.ShowException(ex, this);
                }

            }
        }



        private void layouttWork_HideCustomization(object sender, EventArgs e)
        {
            try
            {
                if (_isDesignMode) return;
                //if (base.DesignMode) return; 
                if (_isCustomerShowing) return;

                //if (sender.Equals(layoutHide))
                //{
                //    return;
                //}


                ////调用各业务模块进行重新配置
                //foreach (ISysDesign sd in _relateBizModules.Values)
                //{
                //    sd.ReloadLayout();
                //}

                ReInitLayout(false);

                if (this.DesignMode == false)
                {
                    if (layoutLeft.Root.Count <= 0) dockPanelLeft.Close();
                    if (layoutRight.Root.Count <= 0) dockPanelRight.Close();
                    if (layoutBottom.Root.Count <= 0) dockPanelBottom.Close();

                    if (layoutNavigate.Root.Count <= 0) layoutNavigate.Visible = false;
                    if (layoutWork.Root.Count <= 0) layoutWork.Visible = false;
                }

                //layoutLeft.BackColor = this.BackColor;
                //layoutRight.BackColor = this.BackColor;
                //layoutBottom.BackColor = this.BackColor;
                //layoutNavigate.BackColor = this.BackColor;
                //layoutWork.BackColor = this.BackColor;

                //layoutControlGroupLeft.Padding = new DevExpress.XtraLayout.Utils.Padding(1);
                //layoutControlGroupRight.Padding = new DevExpress.XtraLayout.Utils.Padding(1);
                //layoutControlGroupBottom.Padding = new DevExpress.XtraLayout.Utils.Padding(1);
                //layoutControlGroupNavigate.Padding = new DevExpress.XtraLayout.Utils.Padding(1);
                //layoutControlGroupWork.Padding = new DevExpress.XtraLayout.Utils.Padding(1);

                CloseDesignFace();

                sptLayoutNavigate.Visible = false;

                try
                {

                    timerDesign.Enabled = false;

                    UpdateInstanceState();

                    ClearInvalidItem();

                    if (_isModifyDesign)
                    {
                        if (MessageBox.Show("配置已经更改，是否进行保存？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;

                        SaveWindowConfiguration();
                    }


                }
                catch (Exception ex)
                {
                    MsgBox.ShowException(ex, this);
                }
                finally
                {
                    _isLayoutCustomer = false;
                }
            }
            catch (Exception ex)
            {
                _isLayoutCustomer = false;

                MsgBox.ShowException(ex, this);
            }
        }

        private void ClearInvalidItem()
        {
            void StartClear(LayoutControl lc)
            {
                for (int i = lc.HiddenItems.Count - 1; i >= 0; i--)
                {
                    if (lc.HiddenItems[i].Parent == null)
                    {
                        LayoutControlItem lci = lc.HiddenItems[i] as LayoutControlItem;
                        if (lci != null)
                        {
                            if (lci.Control != null)
                            {
                                if (_dynCreateControl.ContainsKey((lci.Control as ISysDesign).ModuleName))
                                {
                                    DesignControlInstanceInfo dci = _dynCreateControl[(lci.Control as ISysDesign).ModuleName];

                                    if (dci.LoadState == false) lci.Control.Parent = null;
                                }
                                else
                                {
                                    lci.Control.Parent = null;
                                }
                            }
                        }
                        //else
                        //{
                        lc.HiddenItems.RemoveAt(i);
                        //}

                    }
                }
            }


            StartClear(layoutLeft);
            StartClear(layoutRight);
            StartClear(layoutBottom);
            StartClear(layoutNavigate);
            StartClear(layoutWork);
        }

        /// <summary>
        /// 更新实例状态
        /// </summary>
        private void UpdateInstanceState()
        {
            //在vs设计模式下_dynCreateControl对象未空
            if (_dynCreateControl == null) return;

            foreach (DesignControlInstanceInfo dci in _dynCreateControl.Values)
            {
                if (dci.Instance == null) continue;

                dci.ModuleName = (dci.Instance as ISysDesign).ModuleName;
                dci.InstanceState = (dci.Instance as ISysDesign).GetSerializableFmt();
            }
        }

        private void layoutWork_ShowCustomization(object sender, EventArgs e)
        {
            try
            {
                //if (sender.Equals(layoutHide))
                //{
                //    //layoutHide.CustomizationForm.Visible = false;
                //    return;
                //}

                _isLayoutCustomer = true;
                _isCustomerShowing = true;

                if (sender.Equals(layoutLeft) == false) layoutLeft.HideCustomizationForm();
                if (sender.Equals(layoutRight) == false) layoutRight.HideCustomizationForm();
                if (sender.Equals(layoutBottom) == false) layoutBottom.HideCustomizationForm();
                if (sender.Equals(layoutNavigate) == false) layoutNavigate.HideCustomizationForm();
                if (sender.Equals(layoutWork) == false) layoutWork.HideCustomizationForm();
                //if (sender.Equals(layoutHide) == false) layoutHide.HideCustomizationForm();



                if (dockPanelLeft.Visibility == DockVisibility.Hidden)
                {
                    if (LeftFace)
                    {
                        dockPanelLeft.Show();
                        layoutLeft.Visible = true;
                    }
                }

                if (dockPanelRight.Visibility == DockVisibility.Hidden)
                {
                    if (RightFace)
                    {
                        dockPanelRight.Show();
                        layoutRight.Visible = true;
                    }
                }

                if (dockPanelBottom.Visibility == DockVisibility.Hidden)
                {
                    if (BottomFace)
                    {
                        dockPanelBottom.Show();
                        layoutBottom.Visible = true;
                    }
                }

                if (TopFace) layoutNavigate.Visible = true;
                layoutWork.Visible = true;


                //layoutLeft.BackColor = Color.FromArgb(248, 228, 228);
                //layoutRight.BackColor = Color.FromArgb(224, 254, 231);
                //layoutBottom.BackColor = Color.FromArgb(221, 234, 255);
                //layoutNavigate.BackColor = Color.FromArgb(252, 254, 228);
                //layoutWork.BackColor = Color.FromArgb(249, 226, 250);

                //layoutControlGroupLeft.Padding = new DevExpress.XtraLayout.Utils.Padding(10);
                //layoutControlGroupRight.Padding = new DevExpress.XtraLayout.Utils.Padding(10);
                //layoutControlGroupBottom.Padding = new DevExpress.XtraLayout.Utils.Padding(10);
                //layoutControlGroupNavigate.Padding = new DevExpress.XtraLayout.Utils.Padding(10);
                //layoutControlGroupWork.Padding = new DevExpress.XtraLayout.Utils.Padding(10);


                OpenDesignFace();

                sptLayoutNavigate.Visible = true;
                sptLayoutNavigate.BringToFront();

                dockContainer1.BringToFront();

                try
                {
                    timerDesign.Enabled = true;

                    _middleWare = ((DevExpress.XtraLayout.LayoutControl)sender).CustomizationForm as DesignMiddleWare;

                    if (_middleWare == null) return;

                    _middleWare.OnSelDesign -= SelDesignControlProcess;
                    _middleWare.OnSelDesign += SelDesignControlProcess;

                    _middleWare.Visible = false;
                }
                catch (Exception ex)
                {
                    MsgBox.ShowException(ex, this);
                }

                _isCustomerShowing = false;


            }
            catch (Exception ex)
            {
                _isLayoutCustomer = false;

                MsgBox.ShowException(ex, this);

            }
            finally
            {
                _isCustomerShowing = false;
            }
        }

        private void frmBizLayout_Resize(object sender, EventArgs e)
        {
            try
            {
                if (this.MdiParent == null)
                {
                    this.dockMove.FloatLocation = new Point(this.Left + this.Width, this.Top);
                    this.dockMove.FloatSize = new Size(dockMove.Width, this.Height);
                }

                AdjustFullDock();
            }
            catch
            {

            }
        }


        private void AdjustFullDock()
        {
            if (_dockState == null) return;

            DockPanel dp = _dockState.CurDockPanel;

            if (dp.FloatForm == null) return;

            dp.FloatForm.Left = this.Left + 11;
            dp.FloatForm.Top = this.Top + layoutNavigate.Height + 6;
            dp.FloatForm.Width = this.Width - 22;
            dp.FloatForm.Height = this.Height - layoutNavigate.Height - statusStrip1.Height - 12;

        }

        private void frmBizLayout_Move(object sender, EventArgs e)
        {
            try
            {
                //_isMoving = true;

                if (this.MdiParent == null)
                {
                    this.dockMove.FloatLocation = new Point(this.Left + this.Width, this.Top);
                } 

                AdjustFullDock();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        private void dockManager1_StartDocking(object sender, DockPanelCancelEventArgs e)
        {
            if (_dockState == null) return;

            e.Cancel = true;
        }

        private void dockManager1_StartSizing(object sender, StartSizingEventArgs e)
        {
            if (_dockState == null) return;

            e.Cancel = true;
        }



        private void layoutWork_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                DoDrag(sender, e);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void layoutWork_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                EndDragDrop(sender, e);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void layoutWork_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                object dragData = e.Data.GetData(typeof(NavBarItemLink));

                //针对从navbarcontrol工具箱拖动的情况
                if (dragData != null)
                {

                    DesignControlElementInfo dragElementInfo = (dragData as NavBarItemLink).Item.Tag as DesignControlElementInfo;

                    if (dragElementInfo.ControlType == DynamicControlType.dctComponent)
                    {
                        e.Effect = DragDropEffects.None;
                        return;
                    }

                    if (this.MdiParent == null)
                    {
                        if (dragElementInfo.LinkElementItem.NavBar.TopLevelControl != this.dockDesignFace.FloatForm)
                        {
                            e.Effect = DragDropEffects.None;
                            return;
                        }
                    }
                    else
                    {
                        if (dragElementInfo.LinkElementItem.NavBar.TopLevelControl != this.MdiParent)
                        {
                            e.Effect = DragDropEffects.None;
                            return;
                        }
                    }
                }
                else
                {
                    if (_dragType == null) return;

                    DesignControl dc = e.Data.GetData(_dragType) as DesignControl;

                    if (dc != null)
                    {
                        if (this.MdiParent == null)
                        {
                            if (dc.TopLevelControl != this)
                            {
                                e.Effect = DragDropEffects.None;
                                return;
                            }
                        }
                        else
                        {
                            if (dc.TopLevelControl != this.MdiParent)
                            {
                                e.Effect = DragDropEffects.None;
                                return;
                            }
                        }

                    }
                }

                e.Effect = DragDropEffects.Move;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void layoutWork_Click(object sender, EventArgs e)
        {
            if ((_isDesignMode == false) || (_isLayoutCustomer == false)) return;

            try
            {
                if (this.DesignMode == true) return;
                (sender as LayoutControl).ShowCustomizationForm();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        private void layoutWork_ItemAdded(object sender, EventArgs e)
        {
            DoItemAdd(sender, e);

            //if (_isLayoutDesigning == false) return;

            //List<Control> ctls = DesignHelper.GetDesignControls(this);
            //ResetRelateModules(ctls);
        }

        private void layoutWork_ItemRemoved(object sender, EventArgs e)
        {
            try
            {
                if (_allowDelElement)
                {
                    LayoutControlItem curDelItem = sender as LayoutControlItem;
                    if (curDelItem == null)
                    {
                        //删除group等组件类型
                        //判断如果分组存在Items则不允许删除
                        TabbedControlGroup tcg = sender as TabbedControlGroup;

                        sender = null;

                        return;
                    }


                    if (curDelItem.Control == null) return;


                    string moduleName = (curDelItem.Control as DesignControl).ModuleName;

                    if (_regBizModules.ContainsKey(moduleName))
                    {
                        DesignControlInstanceInfo dci = _dynCreateControl[moduleName];
                        if (dci != null)
                        {
                            if (dci.MultiInstance == false && dci.LinkElementItem != null) dci.LinkElementItem.Enabled = true;

                            _dynCreateControl.Remove(moduleName);

                            //if (dci.IsSystemCreate == false)
                            //{
                            DesignControl dcRemove = curDelItem.Control as DesignControl;
                            Control dcParent = dcRemove.Parent;

                            try
                            {
                                if (this.DesignMode == false) dcRemove.Terminated();
                            }
                            catch { }

                            dcParent.Controls.Remove(dcRemove);
                            dcRemove = null;

                            curDelItem.Control = null;
                            //}
                        }

                        _regBizModules.Remove(moduleName);
                    }

                    _isModifyDesign = true;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        protected virtual void ControlLoadEvent(object sender, EventArgs e)
        {

            if (_isLayoutCustomer) return;
            if (_isLoadComplete) return;

            ISysDesign sd = (sender as ISysDesign);

            if (sd != null)
            {
                ProcessStateHint("正在加载模块：" + sd.ModuleName);
            }
            else
            {
                ProcessStateHint("正在加载模块：" + (sender as Control).Name);
            }

        }


        public override void ModuleLoaded()
        {

            timerLoad.Enabled = true;
        }

        //public virtual void ResetUserTool()
        //{

        //}

        public virtual void BindEvents()
        {

        }

        private void ProcessStateHint(string stateMsg, bool isFinal = false)
        {
            if (OnStateSync != null)
            {
                OnStateSync.Invoke(stateMsg, isFinal);
            }
            else
            {

            }
        }

        private void ReInitLayout(bool isLoading = true)
        {
            //预先载入程序集                
            BeforeLoadAssembly();

            _designCtls = DesignHelper.GetDesignControls(this);
             
            //初始化CTL模块
            ReinitModule(_designCtls);


            //重置CTL模块布局
            if (isLoading)
            {
                ProcessStateHint("重置界面布局。");
                ResetModuleLayout();
            }

            //重设关联模块
            ProcessStateHint("重置关联模块元素。");
            ResetRelateModules(_designCtls);
 

            ReloadControls();
 
            //ResetUserTool();
            BindEvents();

            ProcessStateHint("更新模块元素可用状态。");
            UpdateDesignElementAvailable();

            ProcessStateHint("", true);

            _isLoadComplete = true;
 
            //this.Visible = true;
        }

        private void timerLoad_Tick(object sender, EventArgs e)
        {
            try
            {
                timerLoad.Enabled = false;

                ReInitLayout();

                if (_isDesignMode)
                {
                    layoutWork.ShowCustomizationForm();
                }
                else
                {
                    DoBindActions(_designEvents["系统加载事件"], this);
                }
            }
            catch (Exception ex)
            {
                timerLoad.Enabled = false;
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 更新设计元素的可用状态
        /// </summary>
        private void UpdateDesignElementAvailable()
        {           
            if (this.DesignMode || _isDesignMode == false) return;

            bool loadState = false;
            foreach (DesignControlInstanceInfo dci in _dynCreateControl.Values)
            {
                dci.LoadState = false;
                if (dci.MultiInstance == false && dci.LinkElementItem != null) dci.LinkElementItem.Enabled = false;

                if (dci.Instance == null) continue;

                Control dc = dci.Instance as Control;
                if (dc == null) continue;

                if (dc.Parent == null) continue;

                LayoutControl lc = dc.Parent as LayoutControl;
                if (lc == null) continue;

                if (lc.GetItemByControl(dc) != null)
                {
                    loadState = !lc.GetItemByControl(dc).IsHidden;
                }

                dci.LoadState = loadState;
                if (dci.MultiInstance == false && dci.LinkElementItem != null) dci.LinkElementItem.Enabled = !loadState;
            }
        }

        private void ReloadControls()
        {
            foreach (ISysDesign sd in _regBizModules.Values)
            {
                if ((sd as Control).Name == this.Name) continue;

                ProcessStateHint("载入组件布局： " + sd.ModuleName + "。");

                try
                {
                    sd.ModuleLoaded();
                }
                catch (Exception ex)
                {
                    MsgBox.ShowException(ex, this);
                }
            }
        }

        private void timerDesign_Tick(object sender, EventArgs e)
        {

            bool InFormCursor(Form lform, Point cursorPoint)
            {
                if (lform == null) return false;
                if (lform.IsHandleCreated == false) return false;

                Rectangle rectWindow = lform.Bounds;// lform.DesktopBounds; 相对于客户端桌面区域位置，不包含任务栏

                if (cursorPoint.X >= rectWindow.Left
                    && cursorPoint.X <= rectWindow.Right
                    && cursorPoint.Y >= rectWindow.Top
                    && rectWindow.Y <= rectWindow.Bottom)
                {
                    return true;
                }

                return false;
            }


            try
            {
                if (_isLayoutCustomer == false) return;

                string butState = MouseButtons.ToString();

                Form af = null;
                if (this.MdiParent != null)
                {
                    af = this;
                }
                else
                {
                    af = ActiveForm;
                }

                if (butState == "Left" && af == this)
                {
                    Form lastForm = Application.OpenForms[Application.OpenForms.Count -1];

                    int fCount = 2;
                    //获取最后的可见窗体
                    while (lastForm.Visible == false)
                    {
                        if (fCount > Application.OpenForms.Count) break;

                        lastForm = Application.OpenForms[Application.OpenForms.Count - fCount];

                        fCount = fCount + 1;
                    }

                    //模态方式打开窗口，则不执行后续操作
                    if (lastForm != this)
                    {
                        if (lastForm.Modal) return;


                        Point curMousePos = MousePosition;
                        if (InFormCursor(lastForm, curMousePos)) return;

                        if (lastForm.Owner != null)
                        {
                            while (lastForm.Owner != this && lastForm.Owner != this.MdiParent)
                            {
                                lastForm = lastForm.Owner;

                                if (InFormCursor(lastForm, curMousePos)) return;
                            }

                            if (lastForm.Modal && lastForm != this) return;
                        }
                        else
                        {
                            //return;
                        }                       
                    }

                    if (_isActived == false) return;
                    
                    EnterLayoutDesign();
                }
            }
            catch
            {

            }
        }

        public void ItemDoubleClick(object sender, EventArgs e)
        {
            try
            {
                LayoutControlItem lci = sender as LayoutControlItem;
                if (lci == null || lci.Control == null) return;

                DesignControl dc = lci.Control as DesignControl;
                if (dc == null) return;

                if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
                {
                    //打开事件配置
                    DesignHelper.OpenEventEditor(this, dc, dc.DesignEventSerialFmt);
                    _dynCreateControl[dc.ModuleName].InstanceState = dc.GetSerializableFmt();
                }
                else
                {
                    //打开模块配置
                    dc.ShowCustomDesign();
                    _dynCreateControl[dc.ModuleName].InstanceState = dc.GetSerializableFmt();
                }

                pgDesign.SelectedObject = new LayoutControlItemProWrapper(lci as LayoutControlItem);
                pgDesign.ExpandAllGridItems();

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void EnterLayoutDesign()
        {
            Point mPos = MousePosition;

            Control ctl = GetChildAtPoint(this.PointToClient(mPos));
            if (ctl == null) return;

            LayoutControl cur = ctl as LayoutControl;

            //if (cur.Equals(layoutHide)) return;

            while (cur == null && ctl != null)
            {
                ctl = ctl.GetChildAtPoint(ctl.PointToClient(mPos), GetChildAtPointSkip.Invisible);
                cur = ctl as LayoutControl;
            }

            if (ctl == null) return;
            if (cur.CustomizationForm != null && cur.CustomizationForm.Visible) return;

            Control layoutCtl = cur.GetChildAtPoint(cur.PointToClient(mPos), GetChildAtPointSkip.Invisible);

            //LayoutGroup lg = null;
            LayoutControlItem lciBind = null;
            
            if (layoutCtl != null)
            {
                lciBind = cur.GetItemByControl(layoutCtl);

                lciBind.DoubleClick -= ItemDoubleClick;
                lciBind.DoubleClick += ItemDoubleClick;
            }
            //else
            //{
            //    lg = cur.GetGroupAtPoint(cur.PointToClient(mPos)); 
            //}

            //bool isInitMiddleWare = true;

            ////pgDesign.SelectedObject = null;
            //if (_middleWare != null && cur.CustomizationForm != null && _middleWare.OwnerControl != cur.CustomizationForm.OwnerControl)
            //{
            //    if (lciBind == null)
            //    {
            //        if (lg != null)
            //        {
            //            lg.Selected = true;
            //        }
            //        else
            //        {
            //            cur.Root.Selected = true;
            //        }
            //    }
            //    else
            //    { 
            //        lciBind.Selected = true;
                    
            //    }
            //}
            //else
            //{
            //    if (_middleWare == null || cur.CustomizationForm == null)
            //    {
            //        isInitMiddleWare = false;

            //        if (lciBind == null)
            //        {
            //            if (lg != null)
            //            {
            //                lg.Selected = true;
            //            }
            //            else
            //            {
            //                cur.Root.Selected = true;
            //            }
            //        }
            //        else
            //        { 
            //            lciBind.Selected = true;
                        
            //        }
            //    }
            //}
            
            cur.ShowCustomizationForm();

            //将属性对象设置为鼠标点击所选择的控件对象
            //if (isInitMiddleWare == false)
            //{
             
 
            if (lciBind != null)
            {
                lciBind.Selected = true;
            }
            //else
            //{
                //if (lg != null)
                //{
                //    lg.Selected = true;
                //}
                //else
                //{
                //    cur.Root.Selected = true;
                //}
            //}

            
            //}

        }

        private void BizMainLayout_FormClosed(object sender, FormClosedEventArgs e)
        {
            _isLayoutCustomer = false;
            _isActived = false;
        }

        private void layoutWork_LayoutUpdate(object sender, EventArgs e)
        {
            //try
            //{
            //    if (_isLayoutDesigning == false) return;

            //    _designCtls = DesignHelper.GetDesignControls(this);

            //    ResetRelateModules(_designCtls);
            //}
            //catch(Exception ex)
            //{
            //    MsgBox.ShowException(ex, this);
            //}
        }



        private void BizMainLayout_Shown(object sender, EventArgs e)
        {
            try
            {
                //if (_showDesign) layoutWork.ShowCustomizationForm();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 开始设计，按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartDesign(object sender, EventArgs e)
        {
            try
            {
                layoutWork.ShowCustomizationForm();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            try
            {
                //_middleWare.OwnerControl.HideCustomizationForm(); 

                if (this.MdiParent != null)
                {
                    this.MdiParent.Close();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveWindowConfiguration();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private List<BaseLayoutItem> GetSelectItems(LayoutControl lc)
        {

            List<BaseLayoutItem> bli = new List<BaseLayoutItem>();

            void InitSubSelectItems(LayoutGroup lcg)
            {
                if (lcg.Selected) bli.Add(lcg);

                foreach (BaseLayoutItem li in lcg.Items)
                {
                    if (li.Selected)
                    {
                        bli.Add(li);
                    }


                    if (li as LayoutControlGroup != null)
                    {
                        InitSubSelectItems(li as LayoutGroup);
                    }

                    if (li as TabbedControlGroup != null)
                    {
                        foreach (LayoutGroup lg in (li as TabbedControlGroup).TabPages)
                        {
                            InitSubSelectItems(lg as LayoutGroup);
                        }
                    }
                }
            }

            InitSubSelectItems(lc.Root);

            return bli;
        }

        public bool DelSelComponent(DesignControlInstanceInfo dciInfo)
        {
            void RemoveComponentInfo(string delModuleName)
            {
                //删除实例信息
                _regBizModules.Remove(delModuleName);
                _dynCreateControl.Remove(delModuleName);

                _designCtls = DesignHelper.GetDesignControls(this);
                ResetRelateModules(_designCtls);
            }

            string moduleName = dciInfo.ModuleName;


            if (dciInfo.Instance == null)
            {
                RemoveComponentInfo(moduleName);
            }
            else
            {
                if (dciInfo.IsSystemCreate)
                {
                    MessageBox.Show("系统固定组件，不允许删除。", "提示");
                    return false;
                }


                DesignComponent delComponent = dciInfo.Instance as DesignComponent;
                if (delComponent != null)
                {
                    if (dciInfo.LinkElementItem != null) dciInfo.LinkElementItem.Enabled = true;

                    this.Controls.Remove(dciInfo.Instance as Control);

                    RemoveComponentInfo(moduleName);

                    ListViewItem[] lviDels = listView1.Items.Find(moduleName, false);
                    if (lviDels.Length > 0) lviDels[0].Remove();

                    _isModifyDesign = true;
                }
                else
                {
                    DesignControl delControl = dciInfo.Instance as DesignControl;
                    if (delControl != null)
                    {
                        _allowDelElement = true;
                        try
                        {
                            LayoutControl lcDel = delControl.Parent as LayoutControl;
                            if (lcDel == null)
                            {
                                MessageBox.Show("未找到对应的布局组件。", "提示");
                                return false;
                            }

                            LayoutControlItem lci = lcDel.GetItemByControl(delControl);

                            //会触发itemremove事件
                            lci.ShowInCustomizationForm = false;
                            lci.Parent.Remove(lci);

                            lcDel.HideSelectedItems();

                            _designCtls = DesignHelper.GetDesignControls(this);
                            ResetRelateModules(_designCtls);
                        }
                        finally
                        {
                            _allowDelElement = false; 
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 删除设计组件
        /// </summary>
        public void DelDesignComponent()
        {
            if (pgDesign.SelectedObject != null)
            {
                if (pgDesign.SelectedObject is DesignComponent)
                {
                    //只有从listview中选中的控件才为designcomponent组件
                    if (listView1.SelectedItems.Count <= 0) return;

                    DesignControlInstanceInfo dci = listView1.SelectedItems[0].Tag as DesignControlInstanceInfo;
                    if (dci == null) return;

                    if (dci.IsSystemCreate)
                    {
                        MessageBox.Show("系统固定组件，不允许删除。", "提示");
                        return;
                    }

                    if (dci.LinkElementItem != null) dci.LinkElementItem.Enabled = true;

                    this.Controls.Remove(dci.Instance as Control);
                    _regBizModules.Remove(dci.ModuleName);
                    _dynCreateControl.Remove(dci.ModuleName);

                    listView1.SelectedItems[0].Remove();

                    _designCtls = DesignHelper.GetDesignControls(this);
                    ResetRelateModules(_designCtls);

                    _isModifyDesign = true;

                    return;
                }
            }

            if (_middleWare == null) return;
            LayoutControl layoutCur = _middleWare.OwnerControl as LayoutControl;

            List<BaseLayoutItem> selectItems = GetSelectItems(layoutCur);

            if (selectItems.Count <= 0)
            {
                MessageBox.Show("请选择需要删除的项。", "提示");
                return;
            }

            foreach (BaseLayoutItem selItem in selectItems)
            {

                if (selItem as LayoutGroup != null)
                {
                    LayoutGroup delGroup = selItem as LayoutGroup;

                    if (delGroup.Items.Count > 0)
                    {
                        MessageBox.Show("存在子项，不允许进行删除。", "提示");
                        return;
                    }
                }

                if (selItem as TabbedControlGroup != null)
                {
                    foreach (LayoutGroup lg in (selItem as TabbedControlGroup).TabPages)
                    {
                        if (lg.Items.Count > 0)
                        {
                            MessageBox.Show("存在子项，不允许进行删除。", "提示");
                            return;
                        }
                    }
                }
            }


            if (MessageBox.Show("确认删除当前所选项目吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;

            _allowDelElement = true;

            try
            {
                foreach (BaseLayoutItem selItem in selectItems)
                {
                    selItem.ShowInCustomizationForm = false;

                    if (selItem is LayoutControlItem)
                    {
                        LayoutControlItem lci = selItem as LayoutControlItem;
                        if (lci.Control != null)
                        {
                            DesignControl dc = lci.Control as DesignControl;

                            if (dc != null)
                            {
                                if (_dynCreateControl.ContainsKey(dc.ModuleName))
                                {
                                    DesignControlInstanceInfo dci = _dynCreateControl[dc.ModuleName];

                                    if (dci.IsSystemCreate)
                                    {
                                        MessageBox.Show("系统固定部件，不允许删除。", "提示");
                                        return;
                                    }
                                }
                            }
                        }
                    }

                    selItem.Parent.Remove(selItem);

                }

                layoutCur.HideSelectedItems();


                _designCtls = DesignHelper.GetDesignControls(this);
                ResetRelateModules(_designCtls);
            }
            finally
            {
                _allowDelElement = false;
            }
        }
        private void tsbDel_Click(object sender, EventArgs e)
        {
            try
            {
                DelDesignComponent(); 

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void pgDesign_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            try
            {
                _isModifyDesign = true;

                if (e.ChangedItem.PropertyDescriptor.Name == "ModuleName")
                {
                    string oldModuleName = e.OldValue.ToString();
                    string newModuleName = e.ChangedItem.Value.ToString();

                    if (oldModuleName == newModuleName) return;

                    ILayoutWrapper warperProperty = pgDesign.SelectedObject as ILayoutWrapper;

                    if (_regBizModules.ContainsKey(newModuleName))
                    {
                        if (warperProperty != null)
                        {
                            LayoutControlItem lciChanged = warperProperty.Warper as LayoutControlItem;
                            if (lciChanged != null)
                            {
                                e.ChangedItem.PropertyDescriptor.SetValue(lciChanged.Control, e.OldValue);
                            }
                        }
                        else
                        {
                            //直接从ListView选择的对象属性
                            e.ChangedItem.PropertyDescriptor.SetValue(pgDesign.SelectedObject, e.OldValue);
                        }

                        MessageBox.Show("模块名称已经存在。", "提示");
                        return;
                    }

                
                    if (_regBizModules.ContainsKey(oldModuleName))
                    {
                        _regBizModules.Add(newModuleName, _regBizModules[oldModuleName]);
                        _regBizModules.Remove(oldModuleName);
                    }


                    if (_dynCreateControl.ContainsKey(oldModuleName))
                    {
                        DesignControlInstanceInfo dci = _dynCreateControl[oldModuleName];

                        (dci.Instance as DesignControl).ModuleName = newModuleName;

                        _dynCreateControl.Add(newModuleName, dci);
                        _dynCreateControl[newModuleName].ModuleName = e.ChangedItem.Value.ToString();

                        _dynCreateControl.Remove(oldModuleName);
                    }

                    int cmpIndex = listView1.Items.IndexOfKey(oldModuleName);
                    if (cmpIndex >= 0)
                    {
                        ListViewItem lvi = listView1.Items[cmpIndex];

                        lvi.Name = e.ChangedItem.Value.ToString();
                        lvi.Text = e.ChangedItem.Value.ToString();
                    }
                }

                //将修改的属性同步到_dynCreateControl的元素中，便于后续保存
                LayoutControlItemProWrapper lciwarper = (s as PropertyGrid).SelectedObject as LayoutControlItemProWrapper; //LayoutControlItem

                ISysDesign sysDesign = null;

                if (lciwarper == null)
                {
                    //如果为空，则可能是从Listview中选取的对象
                    sysDesign = (s as PropertyGrid).SelectedObject as ISysDesign;
                }
                else
                {
                    LayoutControlItem lci = lciwarper.Warper as LayoutControlItem;

                    if (lci != null && lci.Control != null)
                    {
                        sysDesign = lci.Control as ISysDesign;
                    }
                }

                if (sysDesign == null) return;

                if (_dynCreateControl.ContainsKey(sysDesign.ModuleName))
                {
                    _dynCreateControl[sysDesign.ModuleName].InstanceState = sysDesign.GetSerializableFmt();
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbTest_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("测试前请确认该窗体是否已经设置为对应登录用户的主窗口。", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;

                string testProgram = "zlMedimgSystem.Main.exe";

                //启动测试程序
                try
                {
                    testProgram = AppSetting.ReadSetting("testprogram");
                }
                catch { }

                if (string.IsNullOrEmpty(testProgram) || File.Exists(System.Windows.Forms.Application.StartupPath + @"\" + testProgram) == false)
                {
                    MessageBox.Show("未找到对应测试程序。", "提示");
                    return;
                }


                System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + @"\" + testProgram);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count <= 0) return;

                ListViewItem lvi = listView1.SelectedItems[0];

                DesignControlInstanceInfo dci = lvi.Tag as DesignControlInstanceInfo;

                if (dci == null) return;

                pgDesign.SelectedObject = dci.Instance;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                object dragData = e.Data.GetData(typeof(NavBarItemLink));

                //如果不是从navbarcontrol工具箱拖动组件，则直接退出
                if (dragData == null)
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }

                DesignControlElementInfo dragElementInfo = (dragData as NavBarItemLink).Item.Tag as DesignControlElementInfo;

                if (dragElementInfo == null || dragElementInfo.ControlType == DynamicControlType.dctControl)
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }

                if (this.MdiParent == null)
                {
                    if (dragElementInfo.LinkElementItem.NavBar.TopLevelControl != this.dockDesignFace.FloatForm)
                    {
                        e.Effect = DragDropEffects.None;
                        return;
                    }
                }
                else
                {
                    if (dragElementInfo.LinkElementItem.NavBar.TopLevelControl != this.MdiParent)
                    {
                        e.Effect = DragDropEffects.None;
                        return;
                    }
                }

                e.Effect = DragDropEffects.Move;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private int GetComponentNo(string moduleName)
        {
            int maxNo = 0;

            foreach (ListViewItem lvi in listView1.Items)
            {
                int curNo = 0;

                try
                {
                    curNo = Convert.ToInt32(lvi.Text.Replace(moduleName + "_", ""));
                }
                catch
                {
                    curNo = 0;
                }

                if (curNo > maxNo) maxNo = curNo;
            }

            return maxNo;
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                object dragData = e.Data.GetData(typeof(NavBarItemLink));

                //如果不是从navbarcontrol工具箱拖动组件，则直接退出
                if (dragData == null) return;

                DesignControlElementInfo dragElementInfo = (dragData as NavBarItemLink).Item.Tag as DesignControlElementInfo;

                if (dragElementInfo == null || dragElementInfo.ControlType == DynamicControlType.dctControl) return;

                string name = dragElementInfo.ModuleName;
                if (_dynCreateControl.ContainsKey(dragElementInfo.ModuleName))
                {
                    DialogResult dr = MessageBox.Show("已经存在相同模块，是否继续添加", "提示", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No) return;

                    name = dragElementInfo.ModuleName + "_" + (GetComponentNo(dragElementInfo.ModuleName) + 1);
                }

                DesignControlInstanceInfo dci = new DesignControlInstanceInfo();
                dragElementInfo.CopyTo(dci);
                dci.ModuleName = name;

                //创建元素实例
                DesignAssemblyInfo assemblyInfo = CreateInstanceFromElement(dragElementInfo);

                DesignControl instance = assemblyInfo.DesignInstance;

                instance.Name = name;
                instance.ModuleName = name;
                instance.DesignMode = _isDesignMode;

                dci.Instance = instance;

                dragElementInfo.assembly = assemblyInfo.DesignAssembly;

                dci.LinkElementItem = (dragData as NavBarItemLink).Item;

                if (dragElementInfo.MultiInstance == false)
                {
                    dci.LinkElementItem.Enabled = false;
                }

                //注册关联模块
                if (_regBizModules.ContainsKey(dci.ModuleName) == false)
                {
                    _regBizModules.Add(dci.ModuleName, instance);
                }

                //加入动态控件
                if (_dynCreateControl.ContainsKey(dci.ModuleName) == false)
                {
                    _dynCreateControl.Add(dci.ModuleName, dci);
                }
                

                ListViewItem lviNew = new ListViewItem();

                lviNew.Name = name;
                lviNew.Text = name;
                lviNew.Tag = dci;

                string imgKey = dragElementInfo.OriginalModule;
                if (imageList1.Images.ContainsKey(imgKey) == false)
                {
                    imageList1.Images.Add(imgKey, dragElementInfo.ToolImg);
                }
                lviNew.ImageKey = imgKey;

                listView1.Items.Add(lviNew);


                this.Controls.Add(instance);

                _designCtls = DesignHelper.GetDesignControls(this);
                ResetRelateModules(_designCtls);

                _isModifyDesign = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void layoutWork_Leave(object sender, EventArgs e)
        {
            try
            {
                //LayoutControl curLayout = sender as LayoutControl;
                
                //ILayoutWarper bli = pgDesign.SelectedObject as ILayoutWarper;

                //if (bli != null)
                //{
                //    bli.Warper.Selected = false;
                //}

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void listView1_Leave(object sender, EventArgs e)
        {
            try
            {
                //foreach (ListViewItem lvi in listView1.Items)
                //{
                //    lvi.Selected = false;
                //}
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void BizMainLayout_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.MdiParent != null)
                {
                    if (e.CloseReason == CloseReason.UserClosing)
                    {
                        //mdi模式下不允许关闭
                        e.Cancel = true;
                        return;
                    }
                }


                if (_isDesignMode)
                {
                    if (_isModifyDesign)
                    {
                        if (MessageBox.Show("配置已经更改，是否进行保存？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }

                        SaveWindowConfiguration();
                    }
                }
                else
                {
                    DesignHelper.SaveWindowPostion(this);
                    DesignHelper.SaveDockManager(this, dmLayout);
           
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbExportFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.DefaultExt = ".layout";

                    sfd.Filter = "(*.layout)|*.layout|(*.*)|*.*";

                    if (sfd.ShowDialog(this) == DialogResult.OK)
                    {
                        SaveWindowConfigurationToFile(sfd.FileName);
                    }

                  
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbMDI_Click(object sender, EventArgs e)
        {
            try
            {
                bool isMdiWindow = (this.MdiParent == null) ? true : false;
                tsbClose_Click(sender, e);


                OnMdiWindowChange?.Invoke(_designWinKey, isMdiWindow);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbImportFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.DefaultExt = ".layout";

                    ofd.Filter = "(*.layout)|*.layout|(*.*)|*.*";

                    if (ofd.ShowDialog(this) == DialogResult.OK)
                    {
                        List<string> keys = new List<string>(_regBizModules.Keys);

                        for(int i = keys.Count -1; i >=0; i--)
                        {
                            if (_regBizModules[keys[i]] == this) continue;

                            DesignControl dcRemove = _regBizModules[keys[i]] as DesignControl;
                            if (dcRemove == null) continue;

                            Control dcParent = dcRemove.Parent;

                            dcParent.Controls.Remove(dcRemove);
                        }

                        _regBizModules.Clear();
                        _dynCreateControl.Clear();
                        
                        ResetWindowConfigurationFromFile(ofd.FileName);

                        RestoreWindowState();

                        RestoreDynamicControls();

                        UpdateDynamicControls();

                        InitDesignControlElement();


                        ReInitLayout(true);

                        layoutWork_ShowCustomization(layoutWork, null);
                    }


                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void layoutWork_Enter(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem lvi in listView1.Items)
                {
                    lvi.Selected = false;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void listView1_Enter(object sender, EventArgs e)
        {
            try
            {
                if (layoutWork.CustomizationForm != null)
                {
                    layoutWork.Root.ClearSelection();
                    layoutWork.Refresh();
                }

                if (layoutNavigate.CustomizationForm != null)
                {
                    layoutNavigate.Root.ClearSelection();
                    layoutNavigate.Refresh();
                }

                if (layoutLeft.CustomizationForm != null)
                {
                    layoutLeft.Root.ClearSelection();
                    layoutLeft.Refresh();
                }

                if (layoutRight.CustomizationForm != null)
                {
                    layoutRight.Root.ClearSelection();
                    layoutRight.Refresh();
                }

                if (layoutBottom.CustomizationForm != null)
                {
                    layoutBottom.Root.ClearSelection();
                    layoutBottom.Refresh();
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private bool isStartMoving = false;
        private Point oldMousePosition;
        private void picMove_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.MdiParent != null) return;
                if (this.WindowState == FormWindowState.Maximized)
                {
                    return;
                }

                oldMousePosition = e.Location;
                isStartMoving = true;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void picMove_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.MdiParent != null) return;
                if (e.Button == MouseButtons.Left && isStartMoving)
                {
                    Point newPosition = new Point(e.Location.X - oldMousePosition.X, e.Location.Y - oldMousePosition.Y);

                    
                    dockMove.FloatForm.Location += new Size(newPosition);

                    this.Left = dockMove.FloatForm.Left - this.Width;
                    this.Top = dockMove.FloatForm.Top;

                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void picMove_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.MdiParent != null) return;

                oldMousePosition = e.Location;
                isStartMoving = false;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void dockPanel1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            try
            {
                if (e.Button.Properties.Caption == "X ") this.Close(); 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        private void tsbControlManager_Click(object sender, EventArgs e)
        {
            try
            {
                frmControlManager.ShowControlManager(this, _dynCreateControl);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void nbDesignElementsList_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                rtbDescript.Text = "";

                if (e.Link.Item == null) return;
                if (e.Link.Item.Tag == null) return;

                DesignControlElementInfo dei = e.Link.Item.Tag as DesignControlElementInfo;

                if (dei == null) return;

                rtbDescript.Font = this.Font;
                rtbDescript.Text =dei.ModuleName + ":" + System.Environment.NewLine + dei.Description;
                rtbDescript.SelectionStart = 0;
                rtbDescript.SelectionLength = dei.ModuleName.Length + 1;
                rtbDescript.SelectionFont = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold);
            }
            catch(Exception ex)
            {
                rtbDescript.Text = ex.Message;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count <= 0) return;

                ListViewItem lvi = listView1.SelectedItems[0];

                DesignControlInstanceInfo dci = lvi.Tag as DesignControlInstanceInfo;

                if (dci == null || dci.Instance == null) return;

                DesignControl dc = dci.Instance as DesignControl;
                if (dc == null) return;

                if ((ModifierKeys & Keys.Alt) == Keys.Alt)
                {
                    DesignHelper.OpenEventEditor(this, dc, dc.DesignEventSerialFmt);
                    //if (value != null)
                    //{
                    //    dc.DesignEventSerialFmt = value.ToString();

                        _dynCreateControl[dc.ModuleName].InstanceState = dc.GetSerializableFmt();
                    //} 
                }
                else
                {
                    dc.ShowCustomDesign();
                    //if (string.IsNullOrEmpty(customDesign) == false)
                    //{
                    //    dc.CustomDesignFmt = customDesign;

                        _dynCreateControl[dc.ModuleName].InstanceState = dc.GetSerializableFmt();
                    //}
                }

                pgDesign.SelectedObject = null;
                pgDesign.SelectedObject = dci.Instance;
            }
            catch (Exception ex)
            {
                rtbDescript.Text = ex.Message;
            }
        }

        //private bool _isMoving = false;
        private void BizMainLayout_MouseDown(object sender, MouseEventArgs e)
        {
            //try
            //{ 
            //}
            //catch (Exception ex)
            //{
            //    MsgBox.ShowException(ex, this);
            //}
        }

        private void BizMainLayout_MouseUp(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    _isMoving = false;
            //}
            //catch (Exception ex)
            //{
            //    MsgBox.ShowException(ex, this);
            //}
        }

        private bool _isActived = false;
        private void BizMainLayout_Activated(object sender, EventArgs e)
        {
            try
            {
                _isActived = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void BizMainLayout_Enter(object sender, EventArgs e)
        {
            try
            {
                _isActived = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void BizMainLayout_Leave(object sender, EventArgs e)
        {
            try
            {
                _isActived = false;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void BizMainLayout_Deactivate(object sender, EventArgs e)
        {
            try
            {
                _isActived = false;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        protected override void WndProc(ref Message msg)
        {
            try
            {
                if (_isLayoutCustomer)
                {
                    //WM_PARENTNOTIFY = $0210 当MDI子窗口被创建或被销毁，或用户按了一下鼠标键而光标在子窗口上时发送此消息给它的父窗口 
                    //WM_MOUSEACTIVATE = $0021 //当光标在某个非激活的窗口中而用户正按着鼠标的某个键发送此消息给当前窗口
                    if (msg.Msg == 0xA1 || msg.Msg == 0x21)
                    {
                        _isActived = true;
                    }
                }
            }
            catch
            {
            }
            finally
            {
                base.WndProc(ref msg);
            }
        }

        private void dmLayout_EndDocking(object sender, EndDockingEventArgs e)
        {
            if (e.Panel.Dock == DevExpress.XtraBars.Docking.DockingStyle.Float)
            {
                e.Panel.Options.ResizeDirection = DevExpress.XtraBars.Docking.Helpers.ResizeDirection.All;
            }
            else
            {
                e.Panel.Options.ResizeDirection = DevExpress.XtraBars.Docking.Helpers.ResizeDirection.None;
            }
        }

        private void BizMainLayout_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                object active = null;

                try
                {
                    active = ((System.Windows.Forms.ContainerControl)sender).ActiveControl;
                }
                catch
                {
                    active = sender;
                }


                while (active != null)
                {
                    try
                    {
                        active = ((System.Windows.Forms.ContainerControl)active).ActiveControl;
                    }
                    catch { break; }
                }

                if (active == null) return;
                if (active is TextBox
                    || active is ComboBox
                    || active is DateTimePicker
                    || active is RichTextBox
                    || active is CheckBox
                    || active is RadioButton
                    || active is ListBox
                    || active is CheckedListBox
                    || active is ListView
                    || active is TreeView)
                {
                    if (active is Control)
                    {
                        DesignControl dc = GetDesignRoot(active as Control);

                        if (dc != null)
                        {
                            Control nextCtl = dc.GetNextControl(active as Control, true);
                            if (nextCtl != null && nextCtl != active)
                            {
                                //dc.SelectNextControl(active as Control, true, false, true, false);
                                dc.ActiveControl = nextCtl;
                                return;
                            }
                        }

                    }

                    SendKeys.Send("{tab}");
                }
            }
        }

        private DesignControl GetDesignRoot(Control ctlElement)
        {
            if (ctlElement == null) return null;

            while (ctlElement != null)
            {
                if (ctlElement is DesignControl)
                {
                    return ctlElement as DesignControl;
                }
                else
                {
                    ctlElement = ctlElement.Parent;
                }
            }
            return null;
        }

        private void tsbElementExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (pgDesign.SelectedObject != null)
                {
                    DesignControl dcCur = null;
                    if (pgDesign.SelectedObject is LayoutControlItemProWrapper)
                    {
                        dcCur = (pgDesign.SelectedObject as LayoutControlItemProWrapper).Control;
                    }
                    else if (pgDesign.SelectedObject is DesignControl)
                    {

                        dcCur = pgDesign.SelectedObject as DesignControl;
                    }

                    if (dcCur != null)
                    {
                        using (frmElementExport fe = new frmElementExport())
                        {
                            fe.ShowTemplateExport(dcCur, this);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbElementImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (pgDesign.SelectedObject != null)
                {
                    DesignControl dcCur = null;
                    if (pgDesign.SelectedObject is LayoutControlItemProWrapper)
                    {
                        dcCur = (pgDesign.SelectedObject as LayoutControlItemProWrapper).Control;
                    }
                    else if (pgDesign.SelectedObject is DesignControl)
                    {

                        dcCur = pgDesign.SelectedObject as DesignControl;
                    }

                    if (dcCur != null)
                    {
                        using (frmElementImport fi = new frmElementImport())
                        {
                            fi.Init(_designWinKey, _dbHelper, _dataTransCenter, _stationInfo, _userData, _parameters, _sysLog);
                            string fullName = fi.ShowTemplateImport(dcCur, this);

                            if (string.IsNullOrEmpty(fullName) == false)
                            {
                                if (File.Exists(fullName))
                                {
                                    using (StreamReader sr = new StreamReader(fullName))
                                    {
                                        dcCur.CustomDesignFmt = sr.ReadToEnd();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams paras = base.CreateParams;

        //        //使背景加载时不闪烁
        //        paras.ExStyle |= 0x02000000;
        //        return paras;
        //    }
        //}


    }


}
