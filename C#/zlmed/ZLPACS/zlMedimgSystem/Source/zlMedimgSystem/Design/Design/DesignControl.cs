using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Design;
using zlMedimgSystem.Services;
using zlMedimgSystem.Interface;
using System.Drawing;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Permissions;
using DevExpress.XtraEditors;
using System.Drawing.Drawing2D;

namespace zlMedimgSystem.Design
{

    [ToolboxItem(false)]
    public partial class DesignControl : UserControl, ISysDesign, ISysBizModule, IBizDataQuery
    //public partial class DesignControl : XtraUserControl, ISysDesign, ISysBizModule, IBizDataQuery
    {
        public class ModuleDataDescription : Dictionary<string, string>
        {
 
            public ModuleDataDescription()
            { 
            }

 
            public void AddDataDescription(string moduleName, string dataItemName, string dataDescription)
            {
                this.Add(moduleName + "." + dataItemName, dataDescription);
            } 

            public string FormatDataName(string moduleName, string identification)
            {
                return identification.Replace(moduleName + ".", "");
            }

            public void UpdateModuleName(string sourceModuel, string newModuleName)
            {
                string key = "";
                string desc = "";

                for(int i = Count -1; i >= 0; i --)
                {
                    var Item = this.ElementAt(i);

                    key = Item.Key;
                    desc = Item.Value;

                    this.Remove(key);

                    string tmp = (key).Split('.')[0];

                    key = key.Replace(sourceModuel, newModuleName);
                    this.Add(key, desc);
                }
            }
        }

        protected string _winKey = "";
        protected string _moduleName = "";
        protected string _category = "";
        protected string _description = "";
        protected bool _multiInstance = false;
        protected bool _isLoaded = false;

        protected CoordinationBizModules  _relateBizModules = null;


        /// <summary>
        /// 模块支持功能描述
        /// </summary>
        protected Dictionary<string, string> _provideActionDesc = null;

        /// <summary>
        /// 模块数据支持描述
        /// </summary>
        protected ModuleDataDescription _provideDataDesc = null; 

        /// <summary>
        /// 模块事件设计
        /// </summary>
        protected Dictionary<string, EventActionReleation> _designEvents = null;

        protected string _designEventSerialFmt = ""; 
        protected string _customDesignFmt = "";
        protected string _rclickMenuDesignFmt = "";

        protected IDBQuery _dbQuery = null;
        protected ILoginUser _userData = null;
        protected IStationInfo _stationInfo = null;
        protected IBizDataTransferCenter _dataTransCenter = null;
        protected IParameters _parameters = null;
        protected ISysLog _sysLog = null;
        private bool _isDesigning = false;


  
        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsLoaded
        {
            get { return _isLoaded; }
            set { _isLoaded = value; }
        }


        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new  bool DesignMode
        {
            get { return base.DesignMode || _isDesigning; }
            set { _isDesigning = value; }
        }


        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CoordinationBizModules RelateModules
        {
            get { return _relateBizModules; }
            set { _relateBizModules = value; }
        }
                
        private string _OriginalName = "";

        [Bindable(false), Browsable(false)]
        public string OriginalModule
        {
            get { return _OriginalName; }
        }

        public DesignControl()
        {
            InitializeComponent();

            _relateBizModules = new CoordinationBizModules();

            _provideActionDesc = new Dictionary<string, string>();
            _provideDataDesc = new ModuleDataDescription();
             
            _designEvents = new Dictionary<string, EventActionReleation>();

            _rclickMenus = new ModuleMenus();

            //Load -= DesignControl_Load;
            //Load += DesignControl_Load;
            try
            {
                InitBaseInfo();
            }
            catch(Exception ex)
            {
                throw new Exception("[InitBaseInfo] 模块信息初始化错误", ex);
            }

            _OriginalName = _moduleName;

            HandleDestroyed += EventHandlerProcess;
        }


        private void EventHandlerProcess(object sender, EventArgs e)
        {
            Terminated();

            HandleDestroyed -= EventHandlerProcess;
        }

        public virtual void Init(string winKey, IDBQuery dbHelper, IBizDataTransferCenter dataTransCenter, IStationInfo stationInfo, ILoginUser userData, IParameters parameters, ISysLog sysLog)
        {
            _winKey = winKey;
            _dbQuery = dbHelper;
            _userData = userData;
            _dataTransCenter = dataTransCenter;
            _stationInfo = stationInfo;
            _parameters = parameters;
            _sysLog = sysLog;

            _dataTransCenter.RegBizDataQuery(ModuleName, this);
        }


        public string GetSerializableFmt()
        {

            Dictionary<string, object> serial = new Dictionary<string, object>();

            serial.Add("MaxWidth", MaximumSize.Width);
            serial.Add("MaxHeight", MaximumSize.Height);
            serial.Add("MinWidth", MinimumSize.Width);
            serial.Add("MinHeight", MinimumSize.Height);
            serial.Add("SizeWidth", Size.Width);
            serial.Add("SizeHeight", Size.Height);

            serial.Add("BackColor", BackColor.ToArgb());
            //serial.Add("BackColor2", BackColor2.ToArgb());
            serial.Add("BorderStyle", BorderStyle);
            //serial.Add("GradientMode", GradientMode);
            serial.Add("DesignEventSerialFmt", DesignEventSerialFmt);

            serial.Add("CustomDesignFmt", CustomDesignFmt);
            serial.Add("RClickMenuDesignFmt", RClickMenuDesignFmt);
            serial.Add("ForeColor", ForeColor.ToArgb());
            serial.Add("ImeMode", ImeMode);

            serial.Add("TabIndex", TabIndex);

            return DictionaryJsonHelper.SerializeDictionaryToJsonString<string, object>(serial);
        }

        public void SetSerializableFmt(string fmt)
        {
            if (string.IsNullOrEmpty(fmt)) return;

            Dictionary<string, object> serial = DictionaryJsonHelper.DeserializeStringToDictionary<string, object>(fmt);

            if (serial.Count <= 0) return;

            try { if (serial.ContainsKey("MaxWidth") && serial.ContainsKey("MaxHeight")) MaximumSize =new Size( Convert.ToInt32(serial["MaxWidth"]), Convert.ToInt32(serial["MaxHeight"])); } catch (Exception ex) { MsgBox.ShowException(ex); }
            try { if (serial.ContainsKey("MinWidth") && serial.ContainsKey("MinHeight")) MinimumSize = new Size(Convert.ToInt32(serial["MinWidth"]), Convert.ToInt32(serial["MinHeight"])); } catch (Exception ex) { MsgBox.ShowException(ex); }
            try { if (serial.ContainsKey("SizeWidth") && serial.ContainsKey("SizeHeight")) Size = new Size(Convert.ToInt32(serial["SizeWidth"]), Convert.ToInt32(serial["SizeHeight"])); } catch (Exception ex) { MsgBox.ShowException(ex); }

            try {if (serial.ContainsKey("BackColor")) BackColor = Color.FromArgb(Convert.ToInt32(serial["BackColor"])); } catch (Exception ex) { MsgBox.ShowException(ex); }
            //try { if (serial.ContainsKey("BackColor2")) BackColor2 = Color.FromArgb(Convert.ToInt32(serial["BackColor2"])); } catch (Exception ex) { MsgBox.ShowException(ex); }
            try { if (serial.ContainsKey("BorderStyle")) BorderStyle = (BorderStyle)(Convert.ToInt32(serial["BorderStyle"])); } catch (Exception ex) { MsgBox.ShowException(ex); }
            //try { if (serial.ContainsKey("GradientMode")) GradientMode = (LinearGradientMode)(Convert.ToInt32(serial["GradientMode"])); } catch (Exception ex) { MsgBox.ShowException(ex); }

            try { if (serial.ContainsKey("DesignEventSerialFmt")) DesignEventSerialFmt = (string)serial["DesignEventSerialFmt"]; } catch (Exception ex) { MsgBox.ShowException(ex); }
            try { if (serial.ContainsKey("CustomDesignFmt")) CustomDesignFmt = (string)serial["CustomDesignFmt"]; } catch (Exception ex) { MsgBox.ShowException(ex); }
            try { if (serial.ContainsKey("RClickMenuDesignFmt")) RClickMenuDesignFmt = (string)serial["RClickMenuDesignFmt"]; } catch (Exception ex) { MsgBox.ShowException(ex); }
            try { if (serial.ContainsKey("ForeColor")) ForeColor = Color.FromArgb(Convert.ToInt32(serial["ForeColor"])); } catch (Exception ex) { MsgBox.ShowException(ex); }
            try { if (serial.ContainsKey("ImeMode")) ImeMode = (ImeMode)(Convert.ToInt32(serial["ImeMode"])); } catch (Exception ex) { MsgBox.ShowException(ex); }

            try { if (serial.ContainsKey("TabIndex")) TabIndex = Convert.ToInt32(serial["TabIndex"]); } catch (Exception ex) { MsgBox.ShowException(ex); }
        }


        public virtual IBizDataItems QueryDatas(string dataIdentificationName)
        {
            return null;
        }

        public virtual bool HasData(string dataIdentificationName)
        {

            return false;
        }

        /// <summary>
        /// 刷新模块
        /// </summary>
        public virtual void RefreshModule()
        {

        }

        protected virtual void InitBaseInfo()
        {

        }

        public virtual bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            return false; 
        }


        public virtual string ShowCustomDesign()
        {
            MessageBox.Show("尚不支持该功能。", "提示");

            return _customDesignFmt;
        }

        private ModuleMenus _rclickMenus = null;
        public virtual string ShowRClickMenuDesign()
        {
            frmRClickMenuEditor design = new frmRClickMenuEditor();
            design.ShowDesign(_rclickMenus, this);

            _rclickMenuDesignFmt = JsonHelper.SerializeObject(_rclickMenus);

            ClearCustomRClickMenu();
            if (_rclickMenus.Menus != null)
            {
                InitRClickMenu(_rclickMenus);
            }

            SyncDesignEventsByRClickMenu();
            
            return _rclickMenuDesignFmt;
        }
         
        public virtual void ModuleLoaded()
        { 
        }

        public virtual void ShowDesignHelper()
        {

        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Localizable(true)]
        [Category("DESIGN")]
        [DisplayName("模块名称")]
        [Description("模块名称")]
        public string ModuleName
        {
            get { return _moduleName; }
            set
            {
                if (MultiInstance == false)
                {
                    //MessageBox.Show("模块名称禁止修改。", "提示");
                    return;
                }
                
                if (_provideDataDesc.Count > 0)
                {
                    _provideDataDesc.UpdateModuleName(_moduleName, value);
                }

                _moduleName = value;


            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Localizable(true)]
        [Category("DESIGN")]
        [DisplayName("模块分类")]
        [Description("模块分类名称")]
        public string Category
        {
            get { return _category; } 
        }

        //[DisplayName("模块描述")]
        //[Description("模块的简要说明")]
        public string Description
        {
            get { return _description; }
        }


        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool MultiInstance
        {
            get { return _multiInstance; }
        }

        public virtual void ChangeModuleStyle(string styleName)
        {

        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Editor(typeof(CustomDesignEditor), typeof(UITypeEditor))]
        [Localizable(true)]
        [Category("DESIGN")]
        [DisplayName("模块配置")]
        [Description("设置模块的自定义配置。")]
        public string CustomDesignFmt
        {
            get { return _customDesignFmt; }
            set
            {
                _customDesignFmt = value;
                ReloadCustomDesign(_customDesignFmt);
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Editor(typeof(RClickMenuEditor), typeof(UITypeEditor))]
        [Localizable(true)]
        [Category("DESIGN")]
        [DisplayName("右键菜单")]
        [Description("设置模块的右键菜单。")]
        public string RClickMenuDesignFmt
        {
            get { return _rclickMenuDesignFmt; }
            set
            {
                _rclickMenuDesignFmt = value;
                ReloadRClickMenu(_rclickMenuDesignFmt);
            }
        }


        /// <summary>
        /// action功能集合
        /// </summary>
        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Localizable(true)]
        [Description("Actions")]
        public Dictionary<string, string> ProvideActions
        {
            get
            {
                return _provideActionDesc;
            }
        }

        /// <summary>
        /// 数据项集合
        /// </summary>
        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Localizable(true)]
        [Description("Datas")]
        public Dictionary<string, string> ProvideDatas
        {
            get
            {
                return _provideDataDesc;
            }
        }

        /// <summary>
        /// 事件调用集合
        /// </summary>
        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, EventActionReleation> DesignEvents
        {
            get
            {
                return _designEvents;
            }
            set
            {
                _designEvents = value;


            }
        }

        /// <summary>
        /// 事件调用配置
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Editor(typeof(EventProEditor), typeof(UITypeEditor))]
        [Localizable(true)]
        [Category("DESIGN")]
        [DisplayName("事件关联")]
        [Description("设置模块的事件调用。")]
        public string DesignEventSerialFmt
        {
            get
            {
                return _designEventSerialFmt;
            }
            set
            {
                _designEventSerialFmt = value;

                if (string.IsNullOrEmpty(value)) return;

                _designEvents = DictionaryJsonHelper.DeserializeStringToDictionary<string, EventActionReleation>(_designEventSerialFmt);// JsonConvert.DeserializeObject<Dictionary<string, EventActionReleation>>(_designEventSerialFmt);

            }

        }


        protected virtual void  ReloadCustomDesign(string customContext)
        {

        }


        protected virtual void ReloadRClickMenu(string rclickMenuFmt)
        {
            ClearCustomRClickMenu();

            if (string.IsNullOrEmpty(rclickMenuFmt)) return;

            _rclickMenus = JsonHelper.DeserializeObject<ModuleMenus>(rclickMenuFmt);

            if (_rclickMenus.Menus.Count <= 0) return;

            InitRClickMenu(_rclickMenus);
            
            SyncDesignEventsByRClickMenu();
        }

        private void ClearCustomRClickMenu()
        {
            if (this.ContextMenuStrip == null) return;

            for(int i = this.ContextMenuStrip.Items.Count -1; i >= 0; i --)
            {
                ToolStripItem tsi = this.ContextMenuStrip.Items[i];
                if (tsi.Tag != null && tsi.Tag is ModuleMenuInfo)
                {
                    this.ContextMenuStrip.Items.RemoveAt(i);
                }
            }
        }

        private void InitRClickMenu(ModuleMenus rclickMenu)
        {
            try
            {
                if (this.ContextMenuStrip == null) return;

                Font bFont = new Font(this.Font.FontFamily, (float)10.5, FontStyle.Bold);

                //添加用户工具按钮
                foreach (ModuleMenuInfo menuItem in rclickMenu.Menus)
                {
                    //创建快捷按钮
                    ToolStripItem rClickMenu = null;
                     
                    if (menuItem.Name == "-")
                    {
                        rClickMenu = new ToolStripSeparator();
                    }
                    else
                    {
                        ToolStripMenuItem curMenu = new ToolStripMenuItem();

                        curMenu.Name = menuItem.Name;
                        curMenu.Image = Img24Resource.LoadImg(menuItem.Icon);
                        curMenu.Text = menuItem.Name + ((string.IsNullOrEmpty(menuItem.Shortcutkey)) ? "" : "(&" + menuItem.Shortcutkey + ")");
                        curMenu.Click += DoRClickMenuEvent;

                        rClickMenu = curMenu;
                    }

                    rClickMenu.Tag = menuItem;

                    if (string.IsNullOrEmpty(menuItem.ParentName))
                    {
                        this.ContextMenuStrip.Items.Add(rClickMenu);
                    }
                    else
                    {
                        ToolStripItem[] tsiParent = this.ContextMenuStrip.Items.Find(menuItem.ParentName, true);

                        ToolStripMenuItem dropDownMenu = tsiParent[0] as ToolStripMenuItem;

                        if (dropDownMenu != null)
                        {
                            dropDownMenu.DropDownItems.Add(rClickMenu);
                        }
                    }

                    menuItem.LinkMenu = rClickMenu;
                }
 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void SyncDesignEventsByRClickMenu()
        {
            foreach (ModuleMenuInfo menuInfo in _rclickMenus.Menus)
            {
                if (_designEvents.ContainsKey(menuInfo.Name) == false)
                {
                    _designEvents.Add(menuInfo.Name, new EventActionReleation(menuInfo.Name, ActionType.atSysFixedEvent));
                }
            }
        }

        private void DoRClickMenuEvent(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem menu = sender as ToolStripMenuItem;

                if (menu == null) return;

                DoBindActions(_designEvents[menu.Name], sender);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        protected void SetDataToAttach(IBizDataItems attachDatas)
        {
            //检索当前模块所提供的数据，并附加到attachdatas属性中
            foreach(string dataNmae in _provideDataDesc.Keys)
            {
                IBizDataItems bizAttachDatas = QueryDatas(dataNmae);

                attachDatas.AttachDatas.Add(bizAttachDatas);
            }
        }


        protected bool DoBindActions(EventActionReleation ea, object sender, object eventArgs = null)
        {
            if (_relateBizModules.Count <= 0) return true ;

            string moduleName = "";
            string methodName = "";

            foreach(KeyValuePair<string, ActionItem> act in ea.Actions)
            {
                moduleName = act.Key.Split('.')[0];
                methodName = act.Key.Split('.')[1];

                ISysDesign exeModule = null;
                if (act.Value.IsParentModule)
                {
                    if (_relateBizModules.ParentWindowBizModules == null)
                    {
                        exeModule = null;
                    }
                    else
                    {
                        if (_relateBizModules.ParentWindowBizModules.ContainsKey(moduleName))
                        {
                            exeModule = _relateBizModules.ParentWindowBizModules[moduleName];
                        }
                    }
                }
                else
                {
                    if (_relateBizModules.ContainsKey(moduleName))
                    {
                        exeModule = _relateBizModules[moduleName];
                    }
                }

                if (exeModule == null)
                {
                    if (MessageBox.Show("[" + moduleName + "] 未能加载，不能执行该模块方法， 是否继续后续执行？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }

                ActionItem ai = act.Value;

                IBizDataItems bizDatas = null;
                if (string.IsNullOrEmpty(ai.RequestDataName) == false)
                {
                    bizDatas = GetDataItem(_moduleName, ai, ai.RequestDataName);
                    if (bizDatas == null) return false;

                    bizDatas.DataName = ai.RequestDataName;
                }

                //SetDataToAttach(bizDatas);

                if (bizDatas != null && ai.RequestAttachDataNames != null)
                {
                    foreach (string requestDataName in ai.RequestAttachDataNames)
                    {
                        IBizDataItems curRequestData = GetDataItem(_moduleName, ai, requestDataName);

                        curRequestData.DataName = requestDataName;

                        bizDatas.AttachDatas.Add(curRequestData);
                    }
                }


                //如果返回False则终止后续执行
                if (exeModule.ExecuteAction(_moduleName, this, sender, act.Value.ActName, act.Value.ActTag, bizDatas, eventArgs) == false) return false;
            }

            return true;
        }

        private IBizDataItems GetDataItem(string moduleName, ActionItem ai, string requestDataItem)
        {
            IBizDataItems dataItems = null;
            if (ai.IsParentModuleData)
            {
                if (_dataTransCenter.ParentDataCenter == null) return null;
                //查询父级窗口中的数据
                dataItems = _dataTransCenter.ParentDataCenter.GetBizDataQuery(requestDataItem);
            }
            else
            {
                dataItems = _dataTransCenter.GetBizDataQuery(requestDataItem);
            }

            if (dataItems == null)
            {
                MessageBox.Show("(" + moduleName + "." + ai.ActName + ")未找到所请求的数据，请求数据为 [" + requestDataItem + "]。", "提示");
                return null;
            }

            if (dataItems.Count <= 0)
            {
                MessageBox.Show("(" + moduleName + "." + ai.ActName + ")未找到对应的数据项，请求数据为 [" + requestDataItem + "]。", "提示");
                return null;
            }

            return dataItems;
        }

        private void DesignControl_Load(object sender, EventArgs e)
        {
            _isLoaded = true;
        }


        public virtual void Terminated()
        {

        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                Terminated();
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        BasePropertyWrapper _bpw = null;
        public Control BaseControl
        {
            get
            {              
                if (base.DesignMode)
                {          
                    if (_bpw == null) _bpw = new BasePropertyWrapper(this);
                    return _bpw;
                }

                return null;
            }
        }

         
        [Category("DESIGN")]
        [Description("设置模块的初始默认宽度和高度。")]
        [DisplayName("默认范围")]
        public new Size Size
        {
            get { return base.Size; }
            set
            {                

                base.Size = value;
            }
        }

         
        [Category("DESIGN")]
        [Description("设置模块的最大宽度和高度，如果为0，则不进行限制。")]
        [DisplayName("最大范围限定")]
        public new Size MaximumSize
        {
            get { return base.MaximumSize; }
            set { base.MaximumSize = value; }
        }


         
        [Category("DESIGN")]
        [Description("设置模块的最小宽度和高度，如果为0，则不进行限制。")]
        [DisplayName("最小范围限定")]
        public new Size MinimumSize
        {
            get { return base.MinimumSize; }
            set { base.MinimumSize = value; }
        }

        [Category("DESIGN")]
        [Description("设置模块的背景颜色。")]
        [DisplayName("背景色")]
        public new Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        //private Color _backColor2 = default(Color);

        //[Category("DESIGN")]
        //[Description("设置模块的渐变颜色。")]
        //[DisplayName("渐变色")]        
        //public Color BackColor2
        //{
        //    get { return _backColor2; }
        //    set { _backColor2 = value; }
        //}

        //private LinearGradientMode _gradientMode = LinearGradientMode.Horizontal;

        //[Category("DESIGN")]
        //[Description("设置模块的渐变样式。")]
        //[DisplayName("渐变样式")]
        //public LinearGradientMode GradientMode
        //{
        //    get { return _gradientMode; }
        //    set { _gradientMode = value; }
        //}


        [Category("DESIGN")]
        [Description("设置模块的前景颜色，如可能显示的字体颜色。")]
        [DisplayName("前景色")]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        [Category("DESIGN")]
        [Description("设置模块的输入法模式。")]
        [DisplayName("输入法模式")]
        public new ImeMode ImeMode
        {
            get { return base.ImeMode; }
            set { base.ImeMode = value; }
        }

        [Category("DESIGN")]
        [Description("设置模块的边框显示样式。")]
        [DisplayName("边框样式")]
        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set { base.BorderStyle = value; }
        }

        [Category("DESIGN")]
        [Description("设置模块的顺序。")]
        [DisplayName("模块顺序")]
        public new int TabIndex
        {
            get { return base.TabIndex; }
            set { base.TabIndex = value; }
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);

        //}

        //protected virtual void PaintGradient()
        //{
        //    if (BackColor2 != default(Color))
        //    {
        //        LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
        //                                            this.BackColor,
        //                                            this.BackColor2,
        //                                            this.GradientMode);

        //        Graphics g = this.CreateGraphics();
        //        g.FillRectangle(brush, this.ClientRectangle);
        //    }
        //}

        //private void DesignControl_Paint(object sender, PaintEventArgs e)
        //{
        //    //PaintGradient();
        //}


        //public virtual void ReleationModules(CoordinationBizModules bizModules)
        //{
        //    _relateBizModules = bizModules;
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new DockStyle Dock
        //{
        //    get { return base.Dock; }
        //    set { base.Dock = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new bool AllowDrop
        //{
        //    get { return base.AllowDrop; }
        //    set { base.AllowDrop = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new AnchorStyles Anchor
        //{
        //    get { return base.Anchor; }
        //    set { base.Anchor = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new bool AutoScroll
        //{
        //    get { return base.AutoScroll; }
        //    set { base.AutoScroll = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new bool AutoSize
        //{
        //    get { return base.AutoSize; }
        //    set { base.AutoSize = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Size AutoScrollMargin
        //{
        //    get { return base.AutoScrollMargin; }
        //    set { base.AutoScrollMargin = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Size AutoScrollMinSize
        //{
        //    get { return base.AutoScrollMinSize; }
        //    set { base.AutoScrollMinSize = value; }
        //}



        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new AutoSizeMode AutoSizeMode
        //{
        //    get { return base.AutoSizeMode; }
        //    set { base.AutoSizeMode = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Image BackgroundImage
        //{
        //    get { return base.BackgroundImage; }
        //    set { base.BackgroundImage = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new ImageLayout BackgroundImageLayout
        //{
        //    get { return base.BackgroundImageLayout; }
        //    set { base.BackgroundImageLayout = value; }
        //}



        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new bool CausesValidation
        //{
        //    get { return base.CausesValidation; }
        //    set { base.CausesValidation = value; }
        //}



        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Cursor Cursor
        //{
        //    get { return base.Cursor; }
        //    set { base.Cursor = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Point Location
        //{
        //    get { return base.Location; }
        //    set { base.Location = value; }
        //}





        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new RightToLeft RightToLeft
        //{
        //    get { return base.RightToLeft; }
        //    set { base.RightToLeft = value; }
        //}



        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new object Tag
        //{
        //    get { return base.Tag; }
        //    set { base.Tag = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new bool UseWaitCursor
        //{
        //    get { return base.UseWaitCursor; }
        //    set { base.UseWaitCursor = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new string AccessibleDescription
        //{
        //    get { return base.AccessibleDescription; }
        //    set { base.AccessibleDescription = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new string AccessibleName
        //{
        //    get { return base.AccessibleName; }
        //    set { base.AccessibleName = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new AccessibleRole AccessibleRole
        //{
        //    get { return base.AccessibleRole; }
        //    set { base.AccessibleRole = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new AutoValidate AutoValidate
        //{
        //    get { return base.AutoValidate; }
        //    set { base.AutoValidate = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new bool TabStop
        //{
        //    get { return base.TabStop; }
        //    set { base.TabStop = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new bool Visible
        //{
        //    get { return base.Visible; }
        //    set { base.Visible = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new bool Enabled
        //{
        //    get { return base.Enabled; }
        //    set { base.Enabled = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Font Font
        //{
        //    get { return base.Font; }
        //    set { base.Font = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Padding Margin
        //{
        //    get { return base.Margin; }
        //    set { base.Margin = value; }
        //}

        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Padding Padding
        //{
        //    get { return base.Padding; }
        //    set { base.Padding = value; }
        //}



        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new ControlBindingsCollection DataBindings
        //{
        //    get { return base.DataBindings; } 
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new ContextMenuStrip ContextMenuStrip
        //{
        //    get { return base.ContextMenuStrip; }
        //    set { base.ContextMenuStrip = value; }
        //}


    }

}
