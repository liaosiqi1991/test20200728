using DevExpress.XtraBars.Docking;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.Layout
{

    /// <summary>
    /// 模块dock状态
    /// </summary>
    public class ModuleDockState
    {
        public DevExpress.XtraBars.Docking.DockVisibility Visibility { get; set; }
        public DockPanel CurDockPanel { get; set; }

        public ModuleDockState(DevExpress.XtraBars.Docking.DockVisibility visibility)
        {
            Visibility = visibility;
        }

        public ModuleDockState(DevExpress.XtraBars.Docking.DockVisibility visibility, DockPanel curDkp)
        {
            Visibility = visibility;
            CurDockPanel = curDkp;
        }

    }

    /// <summary>
    /// 动态控件类型
    /// </summary>
    public enum DynamicControlType
    {
        /// <summary>
        /// 控件类型
        /// </summary>
        dctControl = 0,

        /// <summary>
        /// 组件类型
        /// </summary>
        dctComponent = 1
    }

    /// <summary>
    /// 设计控件元素信息
    /// </summary>
    [Serializable]
    public class DesignControlElementInfo : ISerializable
    {
        public DynamicControlType ControlType { get; set; }

        /// <summary>
        /// 是否多实例
        /// </summary>
        public bool MultiInstance { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// 原始模块名称
        /// </summary>
        public string OriginalModule { get; set; }

        /// <summary>
        /// 模块分组
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 模块描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 模块文件
        /// </summary>
        public string ModuleFile { get; set; }

        /// <summary>
        /// 类型全名
        /// </summary>
        public string TypeFullName { get; set; }

        /// <summary>
        /// 程序集名称
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// 组件名称
        /// </summary>
        public string ControlName { get; set; }

        /// <summary>
        /// 工具类图像
        /// </summary>
        public Image ToolImg { get; set; }


        /// <summary>
        /// 预留标记
        /// </summary>
        public string Tag { get; set; }


        public Assembly assembly { get; set; }


        //public LayoutControlItem LinkElementItem { get; set; }
        public NavBarItem LinkElementItem { get; set; }

        public DesignControlElementInfo()
        {

        }

        public DesignControlElementInfo CloneTo()
        {
            DesignControlElementInfo newDce = new DesignControlElementInfo();

            CopyTo(newDce);

            return newDce;
        }

        public void CopyTo(DesignControlElementInfo dce)
        {
            dce.AssemblyName = this.AssemblyName;
            dce.ControlName = this.ControlName;
            dce.ControlType = this.ControlType;
            dce.LinkElementItem = this.LinkElementItem;
            dce.ModuleFile = this.ModuleFile;
            dce.ModuleName = this.ModuleName;
            dce.OriginalModule = this.OriginalModule;
            dce.Category = this.Category;
            dce.Description = this.Description;
            dce.MultiInstance = this.MultiInstance;
            dce.Tag = this.Tag;
            dce.TypeFullName = this.TypeFullName;
            dce.ToolImg = this.ToolImg;
        }


        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected DesignControlElementInfo(SerializationInfo info, StreamingContext context)
        {
            try { ControlType = (DynamicControlType)info.GetInt16("ControlType"); } catch { }
            try { MultiInstance = info.GetBoolean("MultiInstance"); } catch { }
            try { ModuleName = info.GetString("ModuleName"); } catch { }
            try { OriginalModule = info.GetString("OriginalModule"); } catch { }
            try { Category = info.GetString("Category"); } catch { }
            try { Description = info.GetString("Description"); } catch { }
            try { ModuleFile = info.GetString("ModuleFile"); } catch { }
            try { TypeFullName = info.GetString("TypeFullName"); } catch { }
            try { AssemblyName = info.GetString("AssemblyName"); } catch { }
            try { ControlName = info.GetString("ControlName"); } catch { }
            try { Tag = info.GetString("Tag"); } catch { }

        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ControlType", (int)ControlType);
            info.AddValue("MultiInstance", MultiInstance);
            info.AddValue("ModuleName", ModuleName);
            info.AddValue("OriginalModule", OriginalModule);
            info.AddValue("Category", Category);
            info.AddValue("Description", Description);
            info.AddValue("ModuleFile", ModuleFile);
            info.AddValue("TypeFullName", TypeFullName);
            info.AddValue("AssemblyName", AssemblyName);
            info.AddValue("ControlName", ControlName);
            info.AddValue("Tag", Tag);
        }
    }

    /// <summary>
    /// 动态加载的控件信息
    /// </summary>
    [Serializable]
    public class DesignControlInstanceInfo : DesignControlElementInfo, ISerializable
    {

        /// <summary>
        /// 是否系统创建
        /// </summary>
        public bool IsSystemCreate { get; set; }


        /// <summary>
        /// 实例对象
        /// </summary>
        public object Instance { get; set; }

        /// <summary>
        /// 实例名称
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        /// 实例状态，
        /// </summary>
        public string InstanceState { get; set; }


        /// <summary>
        /// 是否允许加载
        /// </summary>
        public bool AllowUse { get; set; }

        /// <summary>
        /// 载入状态
        /// </summary>
        public bool LoadState { get; set; }
        
        /// <summary>
        /// 载入信息
        /// </summary>
        public string LoadInfo { get; set; }

        public DesignControlInstanceInfo()
        {
            IsSystemCreate = false;
            AllowUse = true;
            LoadState = false;
        }

        public new DesignControlInstanceInfo CloneTo()
        {
            DesignControlInstanceInfo newDci = new DesignControlInstanceInfo();

            CopyTo(newDci);

            return newDci;
        }

        public void CopyTo(DesignControlInstanceInfo dci)
        {
            base.CopyTo(dci);

            dci.Instance = this.Instance;
            dci.InstanceName = this.InstanceName;
            dci.InstanceState = this.InstanceState;
            dci.IsSystemCreate = this.IsSystemCreate;
            dci.AllowUse = this.AllowUse;
            dci.LoadState = this.LoadState;
        }


        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected DesignControlInstanceInfo(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            try { InstanceName = info.GetString("InstanceName"); } catch { }
            try { InstanceState = info.GetString("InstanceState"); } catch { }
            try { IsSystemCreate = info.GetBoolean("IsSystemCreate"); } catch { }
            try { AllowUse = info.GetBoolean("AllowUse"); } catch { }

        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("InstanceName", InstanceName);
            info.AddValue("InstanceState", InstanceState);
            info.AddValue("IsSystemCreate", IsSystemCreate);
            info.AddValue("AllowUse", AllowUse);
        }
    }


    [Serializable]
    public class WindowStateInfo : ISerializable
    {
        public Int32 NavigateHeight { get; set; }
        public FormBorderStyle FormBorderStyle { get; set; }
        public bool ControlBox { get; set; }
        public string Title { get; set; }
        public string Skin { get; set; }
        public Icon Icon { get; set; }
        public FormWindowState WindowState { get; set; }
        public FormStartPosition StartPosition { get; set; }
        public ImeMode ImeMode { get; set; }
        public double Opacity { get; set; }
        public bool ShowInTaskbar { get; set; }
        public bool ShowIcon { get; set; }
        public bool TopMost { get; set; }
        public bool MaximizeBox { get; set; }
        public bool MinimizeBox { get; set; }
        public string DesignEventSerialFmt { get; set; }

        public bool AllowChangeRecordUser { get; set; }

        public bool AllowChangeCaptureUser { get; set; }

        public bool UserStateBar { get; set; }

        public Size StartSize { get; set; }
        public Size MinSize { get; set; }
        public Size MaxSize { get; set; }
        public string ParentWindowName { get; set; }

        public bool LeftFace { get; set; }

        public bool RightFace { get; set; }

        public bool TopFace { get; set; }

        public bool BottomFace { get; set; }

        public WindowStateInfo()
        {

        }

        private void SetIcon(Icon icon)
        {

        }

        private Icon GetIcon()
        {
            return null;
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected WindowStateInfo(SerializationInfo info, StreamingContext context)
        {
            try { NavigateHeight = info.GetInt32("NavigateHeight"); } catch { }
            try { FormBorderStyle = (FormBorderStyle)info.GetInt32("FormBorderStyle"); } catch { }
            try { ControlBox = info.GetBoolean("ControlBox"); } catch { }
            try { Title = info.GetString("Title"); } catch { }
            try { Skin = info.GetString("Skin"); } catch { }
            try { WindowState = (FormWindowState)info.GetInt32("WindowState"); } catch { }
            try { StartPosition = (FormStartPosition)info.GetInt32("StartPosition"); } catch { }
            try { ImeMode = (ImeMode)info.GetInt32("ImeMode"); } catch { }

            try { Opacity = info.GetDouble("Opacity"); } catch { Opacity = 100; }
            try { ShowInTaskbar = info.GetBoolean("ShowInTaskbar"); } catch { ShowInTaskbar = true; }
            try { ShowIcon = info.GetBoolean("ShowIcon"); } catch { }
            try { TopMost = info.GetBoolean("TopMost"); } catch { }
            try { MaximizeBox = info.GetBoolean("MaximizeBox"); } catch { MaximizeBox = true; }
            try { MinimizeBox = info.GetBoolean("MinimizeBox"); } catch { MinimizeBox = true; }
            try { DesignEventSerialFmt = info.GetString("DesignEventSerialFmt"); } catch { }

            try { AllowChangeRecordUser = info.GetBoolean("AllowChangeRecordUser"); } catch { }
            try { AllowChangeCaptureUser = info.GetBoolean("AllowChangeCaptureUser"); } catch { }
            try { UserStateBar = info.GetBoolean("UserStateBar"); } catch { UserStateBar = true; }

            try { ParentWindowName = info.GetString("ParentWindowName"); } catch { }

            try { LeftFace = info.GetBoolean("LeftFace"); } catch { LeftFace = true; }
            try { RightFace = info.GetBoolean("RightFace"); } catch { RightFace = true; }
            try { TopFace = info.GetBoolean("TopFace"); } catch { TopFace = true; }
            try { BottomFace = info.GetBoolean("BottomFace"); } catch { BottomFace = true; }

            int w = 0, h = 0;

            try { w = info.GetInt32("startwidth"); } catch { }
            try { h = info.GetInt32("startheight"); } catch { }
            StartSize = new Size(w, h);

            try { w = info.GetInt32("minwidth"); } catch { }
            try { h = info.GetInt32("minheight"); } catch { }
            MinSize = new Size(w, h);

            try { w = info.GetInt32("maxwidth"); } catch { }
            try { h = info.GetInt32("maxheight"); } catch { }
            MaxSize = new Size(w, h);


            string iconB64 = info.GetString("Icon");
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(iconB64)))
            {
                ms.Position = 0;
                Icon = new Icon(ms);
            }

        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("NavigateHeight", NavigateHeight);
            info.AddValue("FormBorderStyle", (int)FormBorderStyle);
            info.AddValue("ControlBox", ControlBox);
            info.AddValue("Title", Title);
            info.AddValue("Skin", Skin);
            info.AddValue("WindowState", WindowState);
            info.AddValue("StartPosition", StartPosition);
            info.AddValue("ImeMode", ImeMode);

            info.AddValue("Opacity", Opacity);
            info.AddValue("ShowInTaskbar", ShowInTaskbar);
            info.AddValue("ShowIcon", ShowIcon);
            info.AddValue("TopMost", TopMost);
            info.AddValue("MaximizeBox", MaximizeBox);
            info.AddValue("MinimizeBox", MinimizeBox);
            info.AddValue("DesignEventSerialFmt", DesignEventSerialFmt);

            info.AddValue("AllowChangeRecordUser", AllowChangeRecordUser);
            info.AddValue("AllowChangeCaptureUser", AllowChangeCaptureUser);
            info.AddValue("UserStateBar", UserStateBar);

            info.AddValue("ParentWindowName", ParentWindowName);

            info.AddValue("startwidth", StartSize.Width);
            info.AddValue("startheight", StartSize.Height);

            info.AddValue("minwidth", MinSize.Width);
            info.AddValue("minheight", MinSize.Height);

            info.AddValue("maxwidth", MaxSize.Width);
            info.AddValue("maxheight", MaxSize.Height);

            info.AddValue("LeftFace", LeftFace);
            info.AddValue("RightFace", RightFace);
            info.AddValue("TopFace", TopFace);
            info.AddValue("BottomFace", BottomFace);

            using (MemoryStream ms = new MemoryStream())
            {
                Icon.Save(ms);
                ms.Position = 0;

                info.AddValue("Icon", Convert.ToBase64String(ms.ToArray()));
            }
        }
    }

    /// <summary>
    /// 窗体配置信息类
    /// </summary>
    [Serializable]
    public class WindowConfiguration : ISerializable
    {
        /// <summary>
        /// 动态控件状态信息
        /// </summary>
        public string DynamicControl { get; set; }

        /// <summary>
        /// 动态组件状态信息
        /// </summary>
        public string DynamicComponents { get; set; }

        /// <summary>
        /// left区域布局配置信息
        /// </summary>
        public string LayoutLeft { get; set; }

        /// <summary>
        /// right区域布局配置信息
        /// </summary>
        public string LayoutRight { get; set; }

        /// <summary>
        /// bottom区域布局配置信息
        /// </summary>
        public string LayoutBottom { get; set; }

        /// <summary>
        /// navigate区域布局配置信息
        /// </summary>
        public string LayoutNavigate { get; set; }

        /// <summary>
        /// work区域布局配置信息
        /// </summary>
        public string LayoutWork { get; set; }

        /// <summary>
        /// dockmanager配置
        /// </summary>
        public string DockManager { get; set; }

        /// <summary>
        /// 窗体状态配置信息
        /// </summary>
        public string WindowState { get; set; }



        public WindowConfiguration()
        {

        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected WindowConfiguration(SerializationInfo info, StreamingContext context)
        {
            try { DynamicControl = info.GetString("DynamicControl"); } catch { }
            try { DynamicComponents = info.GetString("DynamicComponents"); } catch { }

            try { LayoutLeft = info.GetString("LayoutLeft"); } catch { }
            try { LayoutRight = info.GetString("LayoutRight"); } catch { }
            try { LayoutBottom = info.GetString("LayoutBottom"); } catch { }
            try { LayoutNavigate = info.GetString("LayoutNavigate"); } catch { }
            try { LayoutWork = info.GetString("LayoutWork"); } catch { }
            try { DockManager = info.GetString("DockManager"); } catch { }

            try { WindowState = info.GetString("WindowState"); } catch { }
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DynamicControl", DynamicControl);
            info.AddValue("DynamicComponents", DynamicComponents);

            info.AddValue("LayoutLeft", LayoutLeft);
            info.AddValue("LayoutRight", LayoutRight);
            info.AddValue("LayoutBottom", LayoutBottom);
            info.AddValue("LayoutNavigate", LayoutNavigate);
            info.AddValue("LayoutWork", LayoutWork);
            info.AddValue("DockManager", DockManager);

            info.AddValue("WindowState", WindowState);

        }
    }


    /// <summary>
    /// 控件的实例集合
    /// </summary>
    public class DesignControlInstances : Dictionary<string, DesignControlInstanceInfo>
    {
        public bool HasModuleInstance(string moduleName)
        {
            foreach (DesignControlInstanceInfo dci in Values)
            {
                if (dci.ModuleName.Equals(moduleName)) return true;
            }

            return false;
        }
    }

}
