using DevExpress.XtraLayout;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Design;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.Layout
{
    public partial class BizMainLayout : BizDesignBase,ISysDesign, ISysMainModule, IBizDataQuery
    {
        const string SPLITTER_CONTRL_NAME = "分割控件";

        /// <summary>
        /// 载入控件模块
        /// </summary>
        /// <returns></returns>
        private void LoadCanDesignAssembly(out IList<DesignControlElementInfo> designComponents, ProcessStateSync stateSync = null)
        {
            designComponents = new List<DesignControlElementInfo>();

            DirectoryInfo di = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);

            FileInfo[] fis = di.GetFiles("*.CTL.*", SearchOption.TopDirectoryOnly);

            if (fis.Length <= 0) return;
             
            //遍历带ctl的dll控件模块文件
            foreach (FileInfo fi in fis)
            {
                if (fi.Extension.ToUpper().Equals(".DLL") == false) continue;

                Assembly asmby = null;
                string assmeblyName = "";
                string objName = "";

                stateSync?.Invoke("载入模块:" + fi.FullName + "。");

                object Instance = CreateInstanceFromFile(fi, out asmby, out assmeblyName, out objName);
                DesignControl instanceDc = null;

                if (Instance != null) instanceDc = (Instance as DesignControl);

                //判断控件模块审核继承于designcontrol，如果不继承designcontrol则instancedc为null
                if (instanceDc != null)
                {
                    stateSync?.Invoke("配置模块属性:" + instanceDc.ModuleName + "。");

                    //需要判断界面中是否已经加载此类型组件 
                    DesignControlElementInfo dce = new DesignControlElementInfo();
                     
                    dce.ModuleName = instanceDc.ModuleName;
                    dce.OriginalModule = instanceDc.OriginalModule;
                    dce.Category = instanceDc.Category;
                    dce.Description = instanceDc.Description;
                    dce.ModuleFile = fi.Name;
                    dce.assembly = asmby;
                                        
                    dce.MultiInstance = instanceDc.MultiInstance;
                    dce.TypeFullName = Instance.GetType().FullName;
                    dce.AssemblyName = assmeblyName;
                    dce.ControlName = objName;
                    dce.ToolImg = GetControlIcon(Instance);

                    if ((Instance as DesignComponent) != null)
                    {
                        dce.ControlType = DynamicControlType.dctComponent;
                        
                    }
                    else
                    {
                        dce.ControlType = DynamicControlType.dctControl;
                    }

                    designComponents.Add(dce);
                }

            } 
        }

        /// <summary>
        /// 根据设计元素信息创建实例控件
        /// </summary>
        /// <param name="dce"></param>
        /// <returns></returns>
        private DesignAssemblyInfo CreateInstanceFromElement(DesignControlElementInfo dce)
        {
            try
            {
                DesignAssemblyInfo assemblyInfo = InstanceAssembly(System.Windows.Forms.Application.StartupPath + @"\" + dce.ModuleFile,
                                                    dce.AssemblyName + "." + dce.ControlName,
                                                    dce.assembly);
   

                assemblyInfo.DesignInstance.Name = assemblyInfo.GetType().ToString() + "_" + CreateControlId();

                return assemblyInfo;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, "模块[" + dce.ModuleName + ":" + System.Windows.Forms.Application.StartupPath + @"\"  +  dce.ModuleFile + "] 创建失败，系统将不能加载此模块。", this);
                return null;
            }
        }

        public class DesignAssemblyInfo
        {
            public DesignControl DesignInstance { get; set; }
            public Assembly DesignAssembly { get; set; }
        }

        /// <summary>
        /// 实例化程序集对象
        /// </summary>
        /// <param name="assemblyFile"></param>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private DesignAssemblyInfo InstanceAssembly(string assemblyFile, string assemblyControlName, Assembly assembly = null)
        {
            DesignAssemblyInfo assemblyInfo = new DesignAssemblyInfo();

            Assembly asmb = assembly;

            if (asmb == null)
            {
                asmb = Assembly.LoadFile(assemblyFile);
            }

            DesignControl dc = asmb.CreateInstance(assemblyControlName) as DesignControl;

            if (dc != null) dc.Init(_designWinKey, _dbHelper, _dataTransCenter, _stationInfo, _userData, _parameters, _sysLog);

            assemblyInfo.DesignAssembly = asmb;
            assemblyInfo.DesignInstance = dc;

            return assemblyInfo;
        }

        /// <summary>
        /// 注册模块项
        /// </summary>
        /// <param name="ly"></param>
        /// <param name="regItems"></param>
        public void RegFixedItem(LayoutControl ly)
        {
            //if (regItems != null)
            //{
            //    ly.HiddenItems.BeginRegistration();
            //    foreach (Type reg in regItems)
            //    {
            //        ly.RegisterFixedItemType(reg);
            //        ly.RegisterCustomPropertyGridWrapper(reg, typeof(DesignControlPropertiesWrapper));
            //    }
            //    ly.HiddenItems.EndRegistration();
            //}

            ly.RegisterUserCustomizationForm(typeof(DesignMiddleWare));

            ly.RegisterCustomPropertyGridWrapper(typeof(LayoutControlItem), typeof(DesignItemPropertiesWrapper));

        }

        public void InitLayout(LayoutControl ly)
        {
            //事件关联设置
            //ly.Click 
            //ly.ShowCustomization
            //ly.HideCustomization
            //ly.MouseDown
            //ly.ItemAdded
            //ly.ItemRemoved
            //ly.LayoutUpdate
            //ly.DragEnter
            //ly.DragDrop
            //ly.Enter

            ly.OptionsSerialization.RestoreAppearanceItemCaption = true;
            ly.OptionsSerialization.RestoreAppearanceTabPage = true;
            ly.OptionsSerialization.RestoreGroupPadding = true;
            ly.OptionsSerialization.RestoreGroupSpacing = true;
            ly.OptionsSerialization.RestoreLayoutGroupAppearanceGroup = true;
            ly.OptionsSerialization.RestoreLayoutItemCustomizationFormText = true;
            ly.OptionsSerialization.RestoreLayoutItemPadding = true;
            ly.OptionsSerialization.RestoreLayoutItemSpacing = true;
            ly.OptionsSerialization.RestoreLayoutItemText = true;
            ly.OptionsSerialization.RestoreRootGroupPadding = true;
            ly.OptionsSerialization.RestoreRootGroupSpacing = true;
            ly.OptionsSerialization.RestoreTabbedGroupPadding = true;
            ly.OptionsSerialization.RestoreTabbedGroupSpacing = true;
            ly.OptionsSerialization.RestoreTextToControlDistance = true; 

            ly.OptionsCustomizationForm.AllowHandleDeleteKey = false;
            ly.OptionsCustomizationForm.ShowPropertyGrid = false;// true;
            ly.OptionsCustomizationForm.ShowRedoButton = false;
            ly.OptionsCustomizationForm.ShowSaveButton = false;
            ly.OptionsCustomizationForm.ShowUndoButton = false;
            ly.OptionsCustomizationForm.ShowLoadButton = false;
            ly.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(0, 0, 0, 0);


            ly.AllowCustomization = _isDesignMode;

            ly.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(1);
        }

        private string GetLayoutFile()
        {
            return System.Windows.Forms.Application.StartupPath +  @"\" + this.Title + "_layout.dat";
        }



        /// <summary>
        /// 载入CTL程序集组件
        /// </summary>
        private void InitDesignControlElement(ProcessStateSync _stateSync = null)
        {
            if (this.DesignMode || _isDesignMode == false) return;

            nbDesignElementsList.Items.Clear();
            nbDesignElementsList.BeginUpdate();
            try
            {
                IList<DesignControlElementInfo> regDesignComponents = null;

                ProcessStateHint("模块元素载入。");
                LoadCanDesignAssembly(out regDesignComponents, _stateSync);

                //添加界面控件
                ProcessStateHint("配置模块元素列表。");
                foreach (DesignControlElementInfo elementInfo in regDesignComponents)
                {                    
                    if (elementInfo.ControlType == DynamicControlType.dctComponent)
                    {
                        if (string.IsNullOrEmpty(elementInfo.Category))
                        {
                            elementInfo.Category = "后台组件";
                        }
                        else
                        {
                            elementInfo.Category = "后台" + elementInfo.Category.Replace("后台", "");
                        } 
                    }

                    NavBarItem nbi = new NavBarItem(elementInfo.ModuleName);
                    nbi.SmallImage = elementInfo.ToolImg;
                    nbi.LargeImage = elementInfo.ToolImg;

                    elementInfo.LinkElementItem = nbi;

                    nbi.Tag = elementInfo;

                    string category = elementInfo.Category;
                    if (string.IsNullOrEmpty(category))
                    {
                        category = "业务控件";
                    }

                    //判断分组是否存在，如果不存在，则添加
                    if (nbDesignElementsList.Groups[category] == null)
                    {
                        NavBarGroup nbg = nbDesignElementsList.Groups.Add();

                        nbg.Name = category;
                        nbg.Caption = category;
                    } 
                    
                    nbDesignElementsList.Groups[category].ItemLinks.Add(nbi);
                                        
                    
                    if (_dynCreateControl != null && _dynCreateControl.HasModuleInstance(elementInfo.ModuleName))
                    {
                        DesignControlInstanceInfo dciComponent = _dynCreateControl[elementInfo.ModuleName];

                        dciComponent.LinkElementItem = nbi;
                        dciComponent.ToolImg = elementInfo.ToolImg;

                        //不允许多实例，则直接禁用设计元素
                        nbi.Enabled = elementInfo.MultiInstance;

                        //加入ListView
                        if (elementInfo.ControlType == DynamicControlType.dctComponent)
                        {
                            AddComponentInstanceToList(dciComponent);
                        }
                    }
                }

                AddSpliterControl();
              
                foreach (NavBarGroup group in nbDesignElementsList.Groups)
                {
                    group.Expanded = true;
                }

            }
            finally
            {
                nbDesignElementsList.EndUpdate(); 
            }
        }

        /// <summary>
        /// 添加component类型的实例信息到listview
        /// </summary>
        /// <param name="instanceInfo"></param>
        private void AddComponentInstanceToList(DesignControlInstanceInfo instanceInfo)
        {

            void AddComponentImage(string key, Image img)
            {
                if (string.IsNullOrEmpty(key) || img == null) return;

                if (imageList1.Images.ContainsKey(key) == false)
                {
                    imageList1.Images.Add(key, img);
                }
            }

            Image toolImg = instanceInfo.ToolImg;

            //添加组件图标
            if (toolImg == null) toolImg = GetControlIcon(instanceInfo.Instance);
            AddComponentImage(instanceInfo.OriginalModule, toolImg);

            if (listView1.Items.IndexOfKey(instanceInfo.ModuleName) < 0)
            {
                ListViewItem lviElement = new ListViewItem();
                lviElement.Text = instanceInfo.ModuleName;
                lviElement.Name = instanceInfo.ModuleName;
                lviElement.Tag = instanceInfo;
                lviElement.ImageKey = instanceInfo.OriginalModule;

                listView1.Items.Add(lviElement);
            }
        }

        private void AddSpliterControl()
        {

            string category = "基础控件";
            if (nbDesignElementsList.Groups[category] == null)
            {
                NavBarGroup nbg = nbDesignElementsList.Groups.Add();

                nbg.Name = category;
                nbg.Caption = category;
            }

            NavBarItem nbi = new NavBarItem(SPLITTER_CONTRL_NAME);
            nbi.SmallImage = Properties.Resources.splitter;
            nbi.LargeImage = Properties.Resources.splitter;

            DesignControlElementInfo elementInfo = new DesignControlElementInfo();
            elementInfo.ModuleName = SPLITTER_CONTRL_NAME;
            elementInfo.OriginalModule = SPLITTER_CONTRL_NAME;
            elementInfo.MultiInstance = true;
            elementInfo.ToolImg = Properties.Resources.splitter;
            elementInfo.LinkElementItem = nbi;
             
            nbi.Tag = elementInfo;

            nbDesignElementsList.Groups[category].ItemLinks.Add(nbi);
        }



        /// <summary>
        /// 更新已经加载的动态控件到_dynCreateControl中
        /// </summary>
        private void UpdateDynamicControls()
        {
            //再次验证是否将所有的isysdesign控件添加到_dynCreateControl中
            //系统首次启动时，resotredynamiccontrol方法不会写入信息到_dynCreateControl中，需要遍历窗体界面的已加载控件写入_dynCreateControl
            void GetAlreadyDesignControls(Control ctlParent)
            {
                string curModuleName = "";

                if (ctlParent as ISysDesign != null && ctlParent.Equals(this) == false)
                {
                    curModuleName = (ctlParent as ISysDesign).ModuleName;

                    if (_dynCreateControl.ContainsKey(curModuleName) == false)
                    {
                        DesignControlInstanceInfo dci = GetDesignControlInfo(ctlParent as ISysDesign);
                        _dynCreateControl.Add(dci.ModuleName, dci);
                    }

                    return;
                }

                foreach (Control ctl in ctlParent.Controls)
                {
                    if (ctl.Controls.Count > 0)
                    {
                        if ((ctl as ISysDesign) == null)
                        {
                            GetAlreadyDesignControls(ctl);

                            continue;
                        }
                    }

                    if ((ctl as ISysDesign) != null)
                    {
                        curModuleName = (ctl as ISysDesign).ModuleName;

                        if (_dynCreateControl.ContainsKey(curModuleName) == false)
                        {
                            DesignControlInstanceInfo dci = GetDesignControlInfo(ctl as ISysDesign);
                            _dynCreateControl.Add(dci.ModuleName, dci);
                        }
                    }
                }
            }

            GetAlreadyDesignControls(this);
        }

        /// <summary>
        /// 获取设计控件的组件信息
        /// </summary>
        /// <param name="designControl"></param>
        /// <returns></returns>
        private DesignControlInstanceInfo GetDesignControlInfo(ISysDesign designControl)
        {
            if (designControl == null) return null;

            DesignControlInstanceInfo dci = new DesignControlInstanceInfo();
             
            dci.MultiInstance = designControl.MultiInstance;
            dci.ModuleName = designControl.ModuleName;
            dci.OriginalModule = designControl.OriginalModule;
            dci.Category = designControl.Category;
            dci.Description = designControl.Description;
            dci.ModuleFile = designControl.GetType().Assembly.Location;
            dci.Instance = designControl;
            dci.InstanceName = (designControl as Control).Name;
            dci.InstanceState = designControl.GetSerializableFmt();
            dci.IsSystemCreate = true;
            dci.TypeFullName = designControl.GetType().FullName;
            dci.AssemblyName = designControl.GetType().Namespace;
            dci.ControlName = designControl.GetType().Name;


            if (designControl as DesignComponent != null)
            {
                dci.ControlType = DynamicControlType.dctComponent;
            }
            else
            {
                dci.ControlType = DynamicControlType.dctControl;
            }


            return dci;
        }


        public void SaveWindowConfiguration()
        {
            //SaveWindowConfigurationToFile(GetLayoutFile());
            SaveWindowConfigurationToDB(); 
        }

        /// <summary>
        /// 保存布局到文件
        /// </summary>
        /// <param name="fileName"></param>
        private void SaveWindowConfigurationToFile(string fileName)
        {
            //保存配置
            string saveContext = GetLayoutFmt();

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(saveContext);
                sw.Flush();

                fs.Position = 0;
            }

            _isModifyDesign = false;
        }

        private void SaveWindowConfigurationToDB()
        {
            if (OnSaveWindowLayout == null) return;

            string saveContext = GetLayoutFmt();

            OnSaveWindowLayout(this, _designWinKey, saveContext);

            _isModifyDesign = false;
        }

        /// <summary>
        /// 获取界面布局格式
        /// </summary>
        /// <returns></returns>
        private string GetLayoutFmt()
        {
            //获取单个layout的布局配置
            string GetLayoutString(LayoutControl layout)
            {
                //删除隐藏的item，避免数据库中存储无效的item
                layout.HiddenItems.Clear();

                using (MemoryStream ms = new MemoryStream())
                using (StreamReader sr = new StreamReader(ms))
                {
                    layout.SaveLayoutToStream(ms);
                    ms.Position = 0;

                    return sr.ReadToEnd();
                }
            }

            string GetDockManagerString()
            {
                using (MemoryStream ms = new MemoryStream())
                using (StreamReader sr = new StreamReader(ms))
                {
                    dmLayout.SaveLayoutToStream(ms);
                    ms.Position = 0;

                    return sr.ReadToEnd();
                }
            }
            //string GetDockManagerString()
            //{
            //    using (MemoryStream ms = new MemoryStream())
            //    using (StreamReader sr = new StreamReader(ms))
            //    {
            //        dockManager1.SaveLayoutToStream(ms);
            //        ms.Position = 0;

            //        return sr.ReadToEnd();
            //    }
            //}


            //获取窗体状态信息
            string GetWindowState()
            {
                WindowStateInfo wsi = new WindowStateInfo();

                wsi.ControlBox = ControlBox;
                wsi.DesignEventSerialFmt = DesignEventSerialFmt;
                wsi.FormBorderStyle = FormBorderStyle;
                wsi.Icon = Icon;
                wsi.ImeMode = ImeMode;
                wsi.MaximizeBox = MaximizeBox;
                wsi.MinimizeBox = MinimizeBox;
                wsi.NavigateHeight = layoutNavigate.Height;
                wsi.Opacity = Opacity;
                wsi.ShowIcon = ShowIcon;
                wsi.ShowInTaskbar = ShowInTaskbar;
                wsi.StartPosition = StartPosition;
                wsi.Title = Title;
                wsi.Skin = Skin;
                wsi.TopMost = TopMost;
                wsi.WindowState = this.WindowState;

                wsi.AllowChangeRecordUser = AllowChangeRecordUser;
                wsi.AllowChangeCaptureUser = AllowChangeCaptureUser;
                wsi.UserStateBar = UserStateBar;
                wsi.StartSize = StartSize;
                wsi.MinSize = MinimumSize;
                wsi.MaxSize = MaximumSize;

                wsi.ParentWindowName = ParentWindowName;

                wsi.LeftFace = LeftFace;
                wsi.RightFace = RightFace;
                wsi.TopFace = TopFace;
                wsi.BottomFace = BottomFace;
                //窗口位置信息及dockmanager状态信息由用户运行状态保存，设计时不进行处理
                //windowPostion.Add("left", Left);
                //windowPostion.Add("top", Top);
                //windowPostion.Add("width", Width);
                //windowPostion.Add("height", Height);
                //windowPostion.Add("dockmanager", GetDockManagerString());

                return JsonHelper.SerializeObject(wsi); 

            }

            //获取窗口配置串
            string GetWindowConfigurationString()
            {
                if (_windowConfiguration == null) return "";

                ////清理无效的对象
                //List<string> keys = new List<string>(_dynCreateControl.Keys);
                //for(int i = keys.Count -1; i >=0; i--)
                //{
                //    if (_dynCreateControl[keys[i]].Instance == null) _dynCreateControl.Remove(keys[i]);
                //}

                _windowConfiguration.DynamicControl = JsonHelper.SerializeObject(_dynCreateControl);


                _windowConfiguration.LayoutLeft = GetLayoutString(layoutLeft);
                _windowConfiguration.LayoutRight = GetLayoutString(layoutRight);
                _windowConfiguration.LayoutBottom = GetLayoutString(layoutBottom);
                _windowConfiguration.LayoutNavigate = GetLayoutString(layoutNavigate);
                
                _windowConfiguration.LayoutWork = GetLayoutString(layoutWork);
                _windowConfiguration.DockManager = GetDockManagerString();
                _windowConfiguration.WindowState = GetWindowState();


                return JsonHelper.SerializeObject(_windowConfiguration);

            }

            return GetWindowConfigurationString();
        }

        public void DoQueryParentWindowNamesEvent(out List<string> names)
        {
            names = null;
            OnQueryParentWindowName?.Invoke(_designWinKey, out names);
        }

        private void RestoreDockManager()
        {
            if (_windowConfiguration == null || string.IsNullOrEmpty(_windowConfiguration.DockManager)) return;

            using (MemoryStream ms = new MemoryStream())
            using (StreamWriter sw = new StreamWriter(ms))
            {
                sw.Write(_windowConfiguration.DockManager);
                sw.Flush();

                ms.Position = 0;

                dmLayout.RestoreLayoutFromStream(ms);
            }
        }


        private void RestoreWindowState()
        {
            //void ResotreDockManager(string fmt)
            //{
            //    using (MemoryStream ms = new MemoryStream())
            //    using (StreamWriter sw = new StreamWriter(ms))
            //    {
            //        sw.Write(fmt);
            //        sw.Flush();

            //        ms.Position = 0;

            //        dockManager1.RestoreLayoutFromStream(ms);
            //    }
            //}

            if (_windowConfiguration == null || string.IsNullOrEmpty(_windowConfiguration.WindowState)) return;

            WindowStateInfo wsi = JsonHelper.DeserializeObject<WindowStateInfo>(_windowConfiguration.WindowState);// Dictionary<string, object> windowPostion = DictionaryJsonHelper.DeserializeStringToDictionary<string, object>(_windowConfiguration.WindowState);

            //窗口位置信息及dockmanager状态信息由用户运行状态读取，设计时不进行处理
            //if (windowPostion["left"] != null) this.Left = Convert.ToInt32(windowPostion["left"]);
            //if (windowPostion["top"] != null) this.Top = Convert.ToInt32(windowPostion["top"]);
            //if (windowPostion["height"] != null) this.Height = Convert.ToInt32(windowPostion["height"]);
            //if (windowPostion["width"] != null) this.Width = Convert.ToInt32(windowPostion["width"]);
            //if (windowPostion["dockmanager"] != null) ResotreDockManager(windowPostion["dockmanager"].ToString());

            //if (windowPostion["layoutnavigate_height"] != null) this.layoutNavigate.Height = Convert.ToInt32(windowPostion["layoutnavigate_height"]);

            if (wsi != null)
            {
                if (wsi.NavigateHeight > 0) this.layoutNavigate.Height = wsi.NavigateHeight;

                this.ControlBox = wsi.ControlBox;
                this.DesignEventSerialFmt = wsi.DesignEventSerialFmt;
                this.FormBorderStyle = wsi.FormBorderStyle;
                this.Icon = wsi.Icon;
                this.ImeMode = wsi.ImeMode;
                this.MaximizeBox = wsi.MaximizeBox;
                this.MinimizeBox = wsi.MinimizeBox;
                this.Opacity = wsi.Opacity;
                this.ShowIcon = wsi.ShowIcon;
                this.ShowInTaskbar = wsi.ShowInTaskbar;
                
                this.Title = wsi.Title;
                this.Skin = wsi.Skin;
                this.TopMost = wsi.TopMost;
                
                this.AllowChangeRecordUser = wsi.AllowChangeRecordUser;
                this.AllowChangeCaptureUser = wsi.AllowChangeCaptureUser;
                this.UserStateBar = wsi.UserStateBar;

                if (wsi.StartSize.Width > 0 && wsi.StartSize.Height > 0)
                {
                    this.StartSize = wsi.StartSize;
                    //this.Size = wsi.StartSize;
                }

                this.MinimumSize = wsi.MinSize;
                this.MaximumSize = wsi.MaxSize;

                this.ParentWindowName = wsi.ParentWindowName;

                this.WindowState = wsi.WindowState;
                this.StartPosition = wsi.StartPosition;

                this.LeftFace = wsi.LeftFace;
                this.RightFace = wsi.RightFace;
                this.TopFace = wsi.TopFace;
                this.BottomFace = wsi.BottomFace;
            }

            
        }

        /// <summary>
        /// 重置窗体配置
        /// </summary>
        /// <param name="fileName"></param>
        private void  ResetWindowConfigurationFromFile(string fileName)
        {
            if (File.Exists(fileName) == false) return;

            string context = ""; 

            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                fs.Position = 0;
                context = sr.ReadToEnd(); 
            }

            if (context.Length <= 0) return;

            _windowConfiguration = JsonHelper.DeserializeObject<WindowConfiguration>(context); 
        }

        /// <summary>
        /// 从数据库读取窗体配置对象
        /// </summary>
        private void ResetWindowConfigurationFromDB()
        {
            if (OnReadWindowLayout == null) return;

            string layoutFmt = "";
            OnReadWindowLayout?.Invoke(this, ref _designWinKey, out layoutFmt);

            if (string.IsNullOrEmpty(layoutFmt)) return;

            _windowConfiguration = JsonHelper.DeserializeObject<WindowConfiguration>(layoutFmt);
        }

        /// <summary>
        /// 恢复动态控件
        /// </summary>
        private void RestoreDynamicControls()
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

            List<string> moduleKeys = new List<string>(_dynCreateControl.Keys);

            foreach (string moduleName in moduleKeys)
            {

                ProcessStateHint("创建动态组件：" + moduleName + "。");
                DesignControlInstanceInfo moduleInfo = _dynCreateControl[moduleName];

                if (moduleInfo.IsSystemCreate)
                {
                    //根据模块对应的实例名称，设置关联信息
                    foreach(Control ctlSystem in systemControls)
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

                    moduleInfo.LoadInfo = "";
                    if (moduleInfo.assembly == null) moduleInfo.assembly = assemblyInfo.DesignAssembly;
                }
                catch (Exception ex)
                {
                    moduleInfo.LoadInfo = ex.Message;
                    MsgBox.ShowException(ex, "模块[" + moduleName + ":" + moduleInfo.ModuleFile + "] 创建失败，系统将不能加载此模块。", this);

                    //_dynCreateControl.Remove(moduleName);
                }

                if (Instance != null)
                {
                    moduleInfo.Instance = Instance;

                    Instance.DesignMode = _isDesignMode;

                    if (Instance.ModuleName.Equals(moduleInfo.ModuleName) == false) Instance.ModuleName = moduleInfo.ModuleName;
                    if (string.IsNullOrEmpty(moduleInfo.InstanceName) == false) Instance.Name = moduleInfo.InstanceName;
                    if (string.IsNullOrEmpty(moduleInfo.InstanceState) == false) Instance.SetSerializableFmt(moduleInfo.InstanceState);

                    Instance.Load -= ControlLoadEvent;
                    Instance.Load += ControlLoadEvent;

                    this.Controls.Add(Instance);


                    if (moduleInfo.ControlType == DynamicControlType.dctComponent && _isDesignMode)
                    {
                        AddComponentInstanceToList(moduleInfo); 
                    }
                }
            }
        }


        /// <summary>
        /// 恢复布局
        /// </summary>
        /// <param name="fileName"></param>
        public void RestoreLayout()
        {

            //获取单个layout的布局配置
            void SetLayoutString(LayoutControl layout, string config)
            {
                using (MemoryStream ms = new MemoryStream())
                using (StreamWriter sw = new StreamWriter(ms))
                {
                    sw.Write(config);
                    sw.Flush();

                    ms.Position = 0;

                    layout.RestoreLayoutFromStream(ms); 
                }
            }


            _isLayoutLoading = true;

            if (LeftFace && string.IsNullOrEmpty(_windowConfiguration.LayoutLeft) == false) SetLayoutString(layoutLeft, _windowConfiguration.LayoutLeft);
            if (RightFace && string.IsNullOrEmpty(_windowConfiguration.LayoutRight) == false) SetLayoutString(layoutRight, _windowConfiguration.LayoutRight);
            if (BottomFace && string.IsNullOrEmpty(_windowConfiguration.LayoutBottom) == false) SetLayoutString(layoutBottom, _windowConfiguration.LayoutBottom);

            if (TopFace && string.IsNullOrEmpty(_windowConfiguration.LayoutNavigate) == false) SetLayoutString(layoutNavigate, _windowConfiguration.LayoutNavigate);
            
            try
            {
                if (string.IsNullOrEmpty(_windowConfiguration.LayoutWork) == false) SetLayoutString(layoutWork, _windowConfiguration.LayoutWork);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, "工作区模块加载异常.", this);
            }

            _isLayoutLoading = false;
        }

        /// <summary>
        /// 根据名称查找动态创建的控件
        /// </summary>
        /// <param name="controlName"></param>
        /// <returns></returns>
        private Control FindDynamicControl(string controlName)
        {
            Control result = null;
            foreach (DesignControlInstanceInfo dci in _dynCreateControl.Values)
            {
                result = dci.Instance as Control;
                if (result != null && result.Name.Equals(controlName))
                {
                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// 添加控件关联
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoItemAdd(object sender, EventArgs e)
        {
            if (sender is BaseLayoutItem)
            {
                (sender as BaseLayoutItem).AllowHide = false;
            }
            if (_isItemAdding) return;
             
            if (_isLayoutLoading == false) return;
             
            LayoutControlItem ctlItem = sender as LayoutControlItem;
            if (ctlItem == null) return;

            LayoutControl source = ctlItem.Owner as LayoutControl;
            if (source == null) return;

            try
            {
                _isItemAdding = true;

                if (string.IsNullOrEmpty( ctlItem.ControlName)) return;

                Control layoutCtl = FindDynamicControl(ctlItem.ControlName);
                if (layoutCtl == null) return;                 

                LayoutControlItem sourceItem = ctlItem.Owner.GetItemByControl(layoutCtl);
                if (sourceItem != null)
                {
                    if (sourceItem.Equals(ctlItem)) return;
                }

                LayoutControl oldLayoutControl = (layoutCtl.Parent as LayoutControl);

                //同时为空，说明是用户拖拽的控件
                if (sourceItem == null && oldLayoutControl == null && layoutCtl.Parent.Equals(this))
                {
                    ctlItem.Owner.Control.Controls.Add(layoutCtl);
                    ctlItem.Control = layoutCtl;

                    ctlItem.Enabled = true;
                    layoutCtl.Visible = true;

                    return;
                }

                if (oldLayoutControl == null) return;

                LayoutControlItem oldItem = oldLayoutControl.GetItemByControl(layoutCtl);
                if (oldItem == null) return;

                //layoutCtl.Parent = null;

                //不允许对item隐藏
                ctlItem.AllowHide = false;

                ctlItem.Owner.Control.Controls.Add(layoutCtl);

                ctlItem.Control = layoutCtl;

                ctlItem.Enabled = true;
                layoutCtl.Visible = true;

                oldItem.Control = null;
                oldItem.ControlName = "";

                if (oldItem.Parent != null) oldItem.Parent.Remove(oldItem);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, source.Text + "模块加载错误.", this);
            }
            finally
            {
                _isItemAdding = false;
            }
        }

        private void ParseDesignAssembly(string assemblyFile, out string assemblyName, out string controlName)
        {
            ParseDesignAssembly(new FileInfo(assemblyFile), out assemblyName, out controlName);
        }

        private void ParseDesignAssembly(FileInfo fi, out string assemblyName, out string controlName)
        {
            //FileInfo fi = new FileInfo(assemblyFile);

            //程序集名称与文件名称相同
            assemblyName = fi.Name.Replace(fi.Extension, "");

            string[] tmp = ("..." + assemblyName).Split('.');

            //control名称为程序集名的最后一段加上Control
            controlName = tmp[tmp.Length - 1] + "Control";
        }

        private object CreateInstanceFromFile(string fileName, out Assembly asmby, out string assemblyName, out string controlName)
        {
            return CreateInstanceFromFile(new FileInfo(fileName), out asmby, out assemblyName, out controlName);
        }

        private object CreateInstanceFromFile(FileInfo fi,out Assembly asmby, out string assemblyName, out string controlName)
        {
            asmby = null; 

            ParseDesignAssembly(fi, out assemblyName, out controlName);

            if (string.IsNullOrEmpty(assemblyName))
            {
                MessageBox.Show("程序集名称无效。", "提示");
                return null;
            }

            try
            {
                DesignAssemblyInfo assemblyInfo = InstanceAssembly(fi.FullName, assemblyName + "." + controlName);

                if (assemblyInfo.DesignInstance == null) return null;

                asmby = assemblyInfo.DesignAssembly;

                return assemblyInfo.DesignInstance;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, "模块[" + assemblyName + ":" + fi.FullName + "] 载入失败，不能创建对应实例。", this);

                return null;
            }                
        }

       private DesignControlInstanceInfo GetDesignInstance(DesignControlElementInfo elementInfo)
        {
            if (elementInfo.ModuleName == SPLITTER_CONTRL_NAME)
            {
                DesignControlInstanceInfo dci = new DesignControlInstanceInfo();

                //_dragType = dci.GetType();

                dci.Instance = new SplitterItem();
                dci.InstanceName = "SplitterItem_" + CreateControlId();

                this.DoDragDrop(dci, DragDropEffects.Move);

                return dci;
            }
            else
            {
                //从工具箱拖动设计组件
                //if (elementInfo.assembly == null) elementInfo.assembly = Assembly.LoadFile(System.Windows.Forms.Application.StartupPath + @"\" + elementInfo.ModuleFile);

                DesignAssemblyInfo assemblyInfo = CreateInstanceFromElement(elementInfo);

                if (assemblyInfo == null) return null;
                if (elementInfo.assembly == null) elementInfo.assembly = assemblyInfo.DesignAssembly;

                DesignControl dc = assemblyInfo.DesignInstance;                
                if (dc == null) return null;

                DesignControlInstanceInfo dci = new DesignControlInstanceInfo();
                elementInfo.CopyTo(dci);

                dci.Instance = dc;
                dci.InstanceName = dc.Name;


                //_dragType = dci.GetType();

                return dci;
            }
        }

        /// <summary>
        /// 获取唯一模块名称
        /// </summary>
        /// <param name="originalModule"></param>
        /// <returns></returns>
        private string GetUniqueModuleName(string originalModule)
        {
            int count = -1;
            string rep = originalModule + "_";
            foreach (ISysDesign designModule in _regBizModules.Values)
            {
                if (designModule.OriginalModule == originalModule)
                {
                    string order = designModule.ModuleName.Replace(rep, "");
                  
                    int c = 0;
                    int.TryParse(order, out c);

                    if (c > count)
                    {
                        count = c;
                    }
                }
            }

            if (count <= -1) return originalModule;

            while (true)
            {
                count = count + 1;
                string moduleName = originalModule + "_" + count;

                if (_regBizModules.ContainsKey(moduleName) == false) return moduleName;
            }
        }

        /// <summary>
        /// 结束拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndDragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (_isDesignMode == false) return;
                
                 
                LayoutControl lc = sender as LayoutControl;

                if (lc == null) return;

                DesignControlInstanceInfo dragDci = null;
                object dragData = e.Data.GetData(typeof(NavBarItemLink));

                if (dragData != null)
                {
                    //针对使用navbarcontrol作为工具箱的情况
                    DesignControlElementInfo dragElementInfo = (dragData as NavBarItemLink).Item.Tag as DesignControlElementInfo;
                    dragDci = GetDesignInstance(dragElementInfo);

                    _dragType = dragDci.GetType();
                }
                else
                {
                    dragDci = e.Data.GetData(_dragType) as DesignControlInstanceInfo;
                }

                if (_dragType == null) return;

                string designModuleName = "";
                DesignControl dc = null;
                if (dragDci == null)
                {
                    //dragDci为空表示从已有的layout布局中进行的拖动
                    dc = e.Data.GetData(_dragType) as DesignControl;

                    if (dc != null) designModuleName = dc.ModuleName;
                }
                else
                {
                    //dragDci不为空，表示从navbarcontrol中进行拖动
                    if (dragDci.Instance is SplitterItem)
                    {
                        //特定组件splitteritem的处理
                        lc.Root.AddItem(dragDci.Instance as SplitterItem);
                        return;
                    }
                    else
                    {
                        dc = dragDci.Instance as DesignControl;
                    }

                    designModuleName = GetUniqueModuleName(dragDci.OriginalModule);
                }


                if (dc == null) return;

                LayoutControl sourceLayout = null;
                LayoutControlItem sourceItem = null;

                if (dc.Parent != null && (dc.MultiInstance == false || dragDci == null) )
                {
                    //不允许多实例或者是从已有布局拖动时才执行
                    if (dc.Parent.Equals(sender))
                    {
                        BaseLayoutItem bli = lc.GetItemByControl(dc);
                        if (bli != null && bli.IsHidden == true)
                        {

                            bli.Parent = lc.Root;
                            lc.Root.RestoreFromCustomization(bli, DevExpress.XtraLayout.Utils.InsertType.Top);

                            string layoutModuleName = (dc as ISysDesign).ModuleName;

                            if (_dynCreateControl.ContainsKey(layoutModuleName))
                            {
                                DesignControlInstanceInfo hideDci = _dynCreateControl[layoutModuleName];
                                if (hideDci.MultiInstance == false && hideDci.LinkElementItem != null) hideDci.LinkElementItem.Enabled = false;
                            }
                        }

                        return;
                    }
                    
                    sourceLayout = dc.Parent as LayoutControl;
                    sourceItem = sourceLayout.GetItemByControl(dc);
                }
                 
                string assemblyFile = "";
                string assemblyName = "";
                string controlName = "";

                string oldControlName = dc.Name;

                Type instanceType = dc.GetType();

                assemblyFile = instanceType.Assembly.Location;

                ParseDesignAssembly(assemblyFile, out assemblyName, out controlName);

                DesignAssemblyInfo assemblyInfo = InstanceAssembly(assemblyFile, assemblyName + "." + controlName, instanceType.Assembly);


                DesignControl newDesign = assemblyInfo.DesignInstance; 
                if (newDesign == null) return;
               
                newDesign.Name = newDesign.Name + "_" + CreateControlId();
                
                CopyDesignPros(dc, newDesign);

                newDesign.ModuleName = designModuleName;

                lc.BeginUpdate();

                LayoutControlItem newItem = null;
                try
                {
                    newDesign.DesignMode = true;
                    newItem = lc.Root.AddItem("Item" + CreateControlId(), newDesign);
                    //不允许item隐藏
                    newItem.AllowHide = false;

                }
                catch (Exception ex)
                {
                    MsgBox.ShowException(ex, this);

                    
                    return;
                }
                finally
                {
                    if (newItem != null)
                    {
                        newItem.TextVisible = false;
                        newItem.Text = newDesign.ModuleName;

                        if (sourceItem != null) CopyLayoutItemPros(sourceItem, newItem);

                        //if (dragDci != null)
                        {
                            newItem.ShowInCustomizationForm = false;
                        }
                    }

                    lc.EndUpdate();

                    //newDesign.DesignMode = false;
                }
                 

                if (sourceItem != null)
                {
                    //移除源layout中的item布局
                    sourceItem.ShowInCustomizationForm = false;
                    sourceItem.Control.Dispose();

                    if (sourceItem.Parent != null) sourceItem.Parent.Remove(sourceItem); 
                }
                 

                if (_regBizModules.ContainsKey(newDesign.ModuleName) == false)
                {
                    _regBizModules.Add(newDesign.ModuleName, newDesign);
                }
                else
                {
                    _regBizModules[newDesign.ModuleName] = newDesign;
                }
                 
                DesignControlInstanceInfo newDci = null;

                if (dragDci != null)
                {
                    newDci = dragDci.CloneTo();

                    newDci.Instance = newDesign;
                    newDci.InstanceName = newDesign.Name;

                    newDci.ModuleName = newDesign.ModuleName;
                }
                else
                {
                    string moduleName = newDesign.ModuleName;
                    

                    if (_dynCreateControl.ContainsKey(moduleName))
                    {
                        newDci = _dynCreateControl[moduleName];
                    }
                    else
                    {
                        newDci = GetDesignControlInfo(newDesign);
                    }

                    newDci.Instance = newDesign;
                    newDci.InstanceName = newDesign.Name;

                    //根据模块名称查找时，不需要记录控件的原始名称
                    //if (string.IsNullOrEmpty(dci.Tag)) dci.Tag = oldControlName;
                     
                }
                
                if (_dynCreateControl.ContainsKey(newDci.ModuleName))
                {
                    _dynCreateControl[newDci.ModuleName] = newDci;
                }
                else
                {
                    _dynCreateControl.Add(newDci.ModuleName, newDci);
                }

                if (newDci.MultiInstance == false && newDci.LinkElementItem != null) newDci.LinkElementItem.Enabled = false;


                _isModifyDesign = true;

            }
            finally
            {
                _dragType = null;
            }
        }

        private void CopyLayoutItemPros(LayoutControlItem layoutitemSource, LayoutControlItem layoutitemTarget)
        {
            //layoutitemTarget.Text = layoutitemSource.Text;
            layoutitemTarget.TextVisible = layoutitemSource.TextVisible;            
            layoutitemTarget.ContentVisible = layoutitemSource.ContentVisible;
            layoutitemTarget.ControlAlignment = layoutitemSource.ControlAlignment;
            layoutitemTarget.Enabled = layoutitemSource.Enabled; 
        }

        private void CopyDesignPros(DesignControl designSource, DesignControl designTarget)
        {
            designTarget.DesignEventSerialFmt = designSource.DesignEventSerialFmt;
            designTarget.CustomDesignFmt = designSource.CustomDesignFmt;

            designTarget.ModuleName = designSource.ModuleName;
            designTarget.BackColor = designSource.BackColor;
            designTarget.BorderStyle = designSource.BorderStyle;
            designTarget.ContextMenuStrip = designSource.ContextMenuStrip;
            designTarget.ForeColor = designSource.ForeColor;
            //designTarget.ModuleStyle = designSource.ModuleStyle;
            designTarget.Padding = designSource.Padding;
            designTarget.ImeMode = designSource.ImeMode;
        }



        /// <summary>
        /// 创建控件ID
        /// </summary>
        /// <returns></returns>
        private string CreateControlId()
        {
            byte[] byts = BitConverter.GetBytes(DateTime.Now.Ticks);

            return Convert.ToBase64String(byts).Replace("=", "").Replace("/", "_").Replace("+","0").Replace("-", "_");
        }

        /// <summary>
        /// 开始拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoDrag(object sender, MouseEventArgs e)
        {
            _dragType = null;

            if (_isDesignMode == false) return;
            if (e.Button != MouseButtons.Left) return;

            if (sender is NavBarControl)
            {
                //从navbarcontrol的工具箱中拖动设计元素时触发 
                return;
            }

            Label dragLabItem = sender as Label;

            DesignControl dc = null;

            if (dragLabItem == null)
            {
                //从已有布局区域拖动组件
                LayoutControl lc = sender as LayoutControl;

                if (lc == null) return;

                Point curMouse = MousePosition;

                Control dragCtl = lc.GetChildAtPoint(lc.PointToClient(curMouse), GetChildAtPointSkip.Invisible);

                if (lc.Root.SelectedItems.Count <= 0 && dragCtl == null) return;

                LayoutControlItem selLci = null;

                if (lc.Root.SelectedItems.Count > 0)
                {
                    selLci = lc.Root.SelectedItems[0] as LayoutControlItem;
                }
                else
                {
                    selLci = lc.GetItemByControl(dragCtl);
                }

                if (selLci == null || selLci.Control == null) return;

                dc = selLci.Control as DesignControl;


                if (ModifierKeys == Keys.Control)
                {
                    //按下ctrl键后，可以拖动到其他layout布局中
                    _dragType = dc.GetType();
                    this.DoDragDrop(dc, DragDropEffects.Move);
                }

            }
            else
            {
                //从layoutcontrol的工具箱拖动设计组件
                DesignControlElementInfo dce  = dragLabItem.Tag as DesignControlElementInfo;    
                DesignControlInstanceInfo dci = GetDesignInstance(dce);

                _dragType = dci.GetType();

                this.DoDragDrop(dci, DragDropEffects.Move);
            }

        }

        [Category("DESIGN")]
        [TypeConverter(typeof(SkinListConverter))]
        [Description("设置窗体的窗口主题样式。")]
        [DisplayName("主题样式")]
        public string Skin
        {
            get { return defaultLookAndFeel1.LookAndFeel.SkinName; }
            set
            {
                defaultLookAndFeel1.LookAndFeel.SkinName = value; 
            }        
        } 

        [Category("DESIGN")]
        [Description("设置窗体的标题文本。")]
        [DisplayName("窗体标题")]
        public new string Title
        {
            get { return base.Title; }
            set { base.Title = value; }
        }

        [Category("DESIGN")]
        [Description("设置窗体的显示状态。")]
        [DisplayName("窗体状态")]
        public new FormWindowState WindowState
        {
            get { return base.WindowState; }
            set { base.WindowState = value; }
        }

        [Category("DESIGN")]
        [Description("设置窗体是否显示到最顶层。")]
        [DisplayName("置顶显示")]
        public new bool TopMost
        {
            get { return base.TopMost; }
            set { base.TopMost = value; }
        }

        [Category("DESIGN")]
        [Description("设置窗体默认显示的坐标位置。")]
        [DisplayName("起始位置")]
        public new FormStartPosition StartPosition
        {
            get { return base.StartPosition; }
            set { base.StartPosition = value; }
        }

        [Category("DESIGN")]
        [Description("设置窗体是否在任务栏显示对应状态。")]
        [DisplayName("显示到任务栏")]
        public new bool ShowInTaskbar
        {
            get { return base.ShowInTaskbar; }
            set { base.ShowInTaskbar = value; }
        }

        [Category("DESIGN")]
        [Description("设置窗体是否允许显示标题栏图标。")]
        [DisplayName("显示窗体图标")]
        public new bool ShowIcon
        {
            get { return base.ShowIcon; }
            set { base.ShowIcon = value; }
        }

        [Category("DESIGN")]
        [Description("设置窗体的透明度。")]
        [DisplayName("透明度")]
        public new double Opacity
        {
            get { return base.Opacity; }
            set { base.Opacity = value; }
        }

        [Category("DESIGN")]
        [Description("设置窗体是否允许显示最小化按钮。")]
        [DisplayName("允许最小化")]
        public new bool MinimizeBox
        {
            get { return base.MinimizeBox; }
            set { base.MinimizeBox = value; }
        }

        [Category("DESIGN")]
        [Description("设置窗体是否允许显示最大化按钮。")]
        [DisplayName("允许最大化")]
        public new bool MaximizeBox
        {
            get { return base.MaximizeBox; }
            set { base.MaximizeBox = value; }
        }

        [Category("DESIGN")]
        [Description("设置窗体的输入法模式。")]
        [DisplayName("输入法模式")]
        public new ImeMode ImeMode
        {
            get { return base.ImeMode; }
            set { base.ImeMode = value; }
        }

        [Category("DESIGN")]
        [Description("设置窗体的标题栏图标。")]
        [DisplayName("窗体图标")]
        public new Icon Icon
        {
            get { return base.Icon; }
            set { base.Icon = value; }
        }

        [Category("DESIGN")]
        [Description("设置窗体的边框显示样式。")]
        [DisplayName("边框样式")]
        public new FormBorderStyle FormBorderStyle
        {
            get { return base.FormBorderStyle; }
            set { base.FormBorderStyle = value; }
        }

        [Category("DESIGN")]
        [Description("设置窗体的事件调用。")]
        [DisplayName("窗体事件")]
        public new string DesignEventSerialFmt
        {
            get { return base.DesignEventSerialFmt; }
            set { base.DesignEventSerialFmt = value; }
        }

        [Category("DESIGN")]
        [Description("设置窗体是否允许显示标题栏。")]
        [DisplayName("显示标题栏")]
        public new bool ControlBox
        {
            get { return base.ControlBox; }
            set { base.ControlBox = value; }
        }

        [Category("DESIGN")]
        [Description("设置是否允许对记录员用户进行切换，如果禁用，则记录员用户和系统登录用户相同。")]
        [DisplayName("允许记录员切换")]
        public bool AllowChangeRecordUser
        {
            get { return tsbRecored.Visible; }
            set { tsbRecored.Visible = value; }
        }


        [Category("DESIGN")]
        [Description("设置是否允许对记采集用户进行切换，如果禁用，则采集用户和系统登录用户相同。")]
        [DisplayName("允许采集用户切换")]
        public bool AllowChangeCaptureUser
        {
            get { return tsbCapture.Visible; }
            set { tsbCapture.Visible = value; }
        }


        private bool _leftFace = true;
        [Category("DESIGN")]
        [Description("设置左侧面板区域是否显示。")]
        [DisplayName("左侧面板")]        
        public bool LeftFace
        {
            get { return _leftFace; }
            set
            {
                _leftFace = value;
                if (value)
                {
                    layoutLeft.Visible = true;
                    dockPanelLeft.Show();
                }
                else
                {
                    layoutLeft.HideCustomizationForm();

                    dockPanelLeft.Show();
                    dockPanelLeft.Close();
                }
            }
        }

        private bool _rightFace = true;
        [Category("DESIGN")]
        [Description("设置右侧面板区域是否显示。")]
        [DisplayName("右侧面板")]
        public bool RightFace
        {
            get { return _rightFace; }
            set
            {
                _rightFace = value;
                if (value)
                {
                    layoutRight.Visible = true;
                    dockPanelRight.Show();
                }
                else
                {
                    layoutRight.HideCustomizationForm();
                    dockPanelRight.Close();
                }
            }
        }


        private bool _topFace = true;
        [Category("DESIGN")]
        [Description("设置顶部面板区域是否显示。")]
        [DisplayName("顶部面板")]
        public bool TopFace
        {
            get { return _topFace; }
            set
            {
                _topFace = value;

                if (value == false)layoutNavigate.HideCustomizationForm();
                layoutNavigate.Visible = value;
            }
        }

        private bool _bottomFace = true;
        [Category("DESIGN")]
        [Description("设置底部面板区域是否显示。")]
        [DisplayName("底部面板")]
        public bool BottomFace
        {
            get { return _bottomFace; }
            set
            {
                _bottomFace = value;
                if (value)
                {
                    layoutBottom.Visible = true;
                    dockPanelBottom.Show();
                }
                else
                {
                    layoutBottom.HideCustomizationForm();
                    dockPanelBottom.Close();
                }
            }
        }

        [Category("DESIGN")]
        [Description("设置用户状态栏是否显示。")]
        [DisplayName("用户状态栏")]
        public bool UserStateBar
        {
            get { return statusStrip1.Visible; }
            set { statusStrip1.Visible = value; }

        }

        //private Size _startSize = new Size(0, 0);

        [Category("DESIGN")]
        [Description("设置窗体加载后的默认显示大小。")]
        [DisplayName("起始大小")]
        public Size StartSize
        {
            get { return this.Size; }
            set
            {
                //_startSize = value;
                this.Size = value;
            }
        }



        [Category("DESIGN")]
        [Description("设置窗体最小显示范围。")]
        [DisplayName("最小范围")]
        public new Size MinimumSize
        {
            get { return base.MinimumSize; }
            set { base.MinimumSize = value; }
        }


        [Category("DESIGN")]
        [Description("设置窗体最大显示范围。")]
        [DisplayName("最大范围")]
        public new Size MaximumSize
        {
            get { return base.MaximumSize; }
            set { base.MaximumSize = value; }
        }


        private string _parentWindowName = "";
               
        private BizMainLayout _bizMain = null;

        [Category("DESIGN")]
        [TypeConverter(typeof(ParentWindowNameConverter))]
        [Description("设置当前窗口关联的父窗口名称。")]
        [DisplayName("父级关联窗口")]
        public string ParentWindowName
        {
            get { return _parentWindowName; }
            set
            {
                _parentWindowName = value;

                if (_isDesignMode == false) return;

                _regBizModules.ParentWindowBizModules = null;

                if (this.DesignMode) return;

                if (_bizMain != null)
                {
                    _bizMain.Dispose();
                    _bizMain = null;
                }


                if (string.IsNullOrEmpty(_parentWindowName)) return;

                _bizMain = _Link_GetDesignWindow(_parentWindowName);

                if (_bizMain == null)
                {
                    _parentWindowName = "";
                    MessageBox.Show("父窗口无效，请重新配置。", "提示");                    
                }
                else
                {
                    _regBizModules.ParentWindowBizModules = _bizMain.RelateModules;
                }
            }
        }




        ////隐藏相关属性
        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new ControlBindingsCollection DataBindings
        //{
        //    get { return base.DataBindings; } 
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new IButtonControl AcceptButton
        //{
        //    get { return base.AcceptButton; }
        //    set { base.AcceptButton = value; }
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
        //public new Size MaximumSize
        //{
        //    get { return base.MaximumSize; }
        //    set { base.MaximumSize = value; }
        //}



        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Size MinimumSize
        //{
        //    get { return base.MinimumSize; }
        //    set { base.MinimumSize = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Size Size
        //{
        //    get { return base.Size; }
        //    set { base.Size = value; }
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
        //public new string Text
        //{
        //    get { return base.Text; }
        //    set { base.Text = value; }
        //}

        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new IButtonControl CancelButton
        //{
        //    get { return base.CancelButton; }
        //    set { base.CancelButton = value; }
        //}

        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new bool HelpButton
        //{
        //    get { return base.HelpButton; }
        //    set { base.HelpButton = value; }
        //}

        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new bool IsMdiContainer
        //{
        //    get { return base.IsMdiContainer; }
        //    set { base.IsMdiContainer = value; }
        //}

        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new bool KeyPreview
        //{
        //    get { return base.KeyPreview; }
        //    set { base.KeyPreview = value; }
        //}

        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Color BackColor
        //{
        //    get { return base.BackColor; }
        //    set { base.BackColor = value; }
        //}

        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Color ForeColor
        //{
        //    get { return base.ForeColor; }
        //    set { base.ForeColor = value; }
        //}


        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Color TransparencyKey
        //{
        //    get { return base.TransparencyKey; }
        //    set { base.TransparencyKey = value; }
        //}

        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new string ModuleName
        //{
        //    get { return base.ModuleName; }
        //    set { base.ModuleName = value; }
        //}




        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new bool RightToLeftLayout
        //{
        //    get { return base.RightToLeftLayout; }
        //    set { base.RightToLeftLayout = value; }
        //}

        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new SizeGripStyle SizeGripStyle
        //{
        //    get { return base.SizeGripStyle; }
        //    set { base.SizeGripStyle = value; }
        //}

        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new bool MultiInstance
        //{
        //    get { return base.MultiInstance; } 
        //}

        //[Bindable(false), Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new MenuStrip MainMenuStrip
        //{
        //    get { return base.MainMenuStrip; }
        //    set { base.MainMenuStrip = value; }
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
