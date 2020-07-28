using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.Design
{
    public interface IControlSerializable
    {
        /// <summary>
        /// 获取序列化属性串
        /// </summary>
        /// <returns></returns>
        string GetProSerializableStr();

        /// <summary>
        /// 根据序列串设置属性
        /// </summary>
        /// <param name="jsonPros"></param>
        void SetSerializablePros(string jsonPros);

    }

    /// <summary>
    /// 模块菜单信息
    /// </summary>
    [Serializable]
    public class ModuleMenuInfo : ISerializable
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
        //public string Caption { get; set; }
        public string Shortcutkey { get; set; }

        public string Icon { get; set; }
        public string Tag { get; set; }
        public object LinkMenu { get; set; }

        public ModuleMenuInfo()
        {
            Key = Guid.NewGuid().ToString("N");
        }


        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected ModuleMenuInfo(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            ParentName = info.GetString("ParentName");
            Shortcutkey = info.GetString("Shortcutkey");
            Icon = info.GetString("Icon");
            Tag = info.GetString("Tag");
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("ParentName", ParentName);
            info.AddValue("Shortcutkey", Shortcutkey);
            info.AddValue("Icon", Icon);
            info.AddValue("Tag", Tag);
        }
    }

    /// <summary>
    /// 模块菜单
    /// </summary>
    public class ModuleMenus
    {
        public List<ModuleMenuInfo> Menus { get; set; }

        public ModuleMenus()
        {
            Menus = new List<ModuleMenuInfo>();
        }
    }




    [Serializable]
    public class DataProviderItemDesc : ISerializable
    {
        /// <summary>
        /// 说明模块名称
        /// </summary>
        public string DataModuleName { get; set; }

        /// <summary>
        /// 数据项名称
        /// </summary>
        public string DataItemName { get; set; }

        /// <summary>
        /// 数据项描述
        /// </summary>
        public string DataItemDescription { get; set; }

        public DataProviderItemDesc()
        {

        }

        public DataProviderItemDesc(string moduleName, string dataItemName, string Description)
        {
            DataModuleName = moduleName;
            DataItemName = dataItemName;
            DataItemDescription = Description;
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected DataProviderItemDesc(SerializationInfo info, StreamingContext context)
        {
            DataModuleName = info.GetString("DataModuleName");
            DataItemName = info.GetString("DataItemName");
            DataItemDescription = info.GetString("DataItemDescription"); 
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DataModuleName", DataModuleName);
            info.AddValue("DataItemName", DataItemName);
            info.AddValue("DataItemDescription", DataItemDescription); 
        }
    }
     


    public interface IAutoControl:IInterfaceName { }
    public interface IAutoComponent : IInterfaceName { }

    /// <summary>
    /// 协同模块集合类定义
    /// </summary>
    public class CoordinationBizModules : Dictionary<string, ISysDesign>
    {
        /// <summary>
        /// 关联窗体业务模块
        /// </summary>
        public CoordinationBizModules ParentWindowBizModules { get; set; }
    }
 

    public interface ISysDesign
    {
        /// <summary>
        /// 模块名
        /// </summary>
        string ModuleName { get; set; }

        /// <summary>
        /// 模块原始名称
        /// </summary>
        string OriginalModule { get; }

        /// <summary>
        /// 分类
        /// </summary>
        string Category { get; }

        /// <summary>
        /// 描述
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 是否允许多实例
        /// </summary>
        bool MultiInstance { get; }


        

        /// <summary>
        /// 关联模块
        /// </summary>
        CoordinationBizModules RelateModules { get; set; }


        /// <summary>
        /// 提供的事务项目《事务名称，事务说明》
        /// </summary>
        Dictionary<string, string> ProvideActions { get; }

        /// <summary>
        /// 提供的数据项目《数据名称，数据说明》
        /// </summary>
        Dictionary<string, string> ProvideDatas { get; }

        /// <summary>
        /// 《事件名称，事件关联》
        /// </summary>
        Dictionary<string, EventActionReleation> DesignEvents { get; set; } 
         

        /// <summary>
        /// 显示自定义设计
        /// </summary>
        /// <param name="customFmt"></param>
        /// <returns></returns>
        string ShowCustomDesign();


        /// <summary>
        /// 自定义设计格式串
        /// </summary>
        string CustomDesignFmt { get; set; }


        string ShowRClickMenuDesign();

        string RClickMenuDesignFmt { get; set; }
        
        bool ExecuteAction(string callModuleName, ISysDesign callModule,  object sender, 
            string actName, string tag, IBizDataItems bizDatas, object eventArgs = null);

        /// <summary>
        /// 显示帮助
        /// </summary>
        void ShowDesignHelper();

        /// <summary>
        /// 重载
        /// </summary>
        void ModuleLoaded();
         
        string GetSerializableFmt();

        void SetSerializableFmt(string fmt);

        void Terminated();
    }


    public enum ActionType
    {
        /// <summary>
        /// 系统固定事件
        /// </summary>
        atSysFixedEvent,

        /// <summary>
        /// 自定义配置事件
        /// </summary>
        atSysCustomEvent

        ///// <summary>
        ///// 系统按钮事件
        ///// </summary>
        //atSysToolEvent,

        ///// <summary>
        ///// 用户按钮事件
        ///// </summary>
        //atUserToolEvent
    }

    [Serializable]
    public class ActionItem : ISerializable
    {
        /// <summary>
        /// 是否执行父级模块
        /// </summary>
        public bool IsParentModule { get; set; }

        /// <summary>
        /// 是否父级模块数据
        /// </summary>
        public bool IsParentModuleData { get; set; }
        public string ActName { get; set; }
        public string ActTag { get; set; }
        public string RequestDataName { get; set; }

        /// <summary>
        /// 请求数据项集合
        /// </summary>
        public List<string> RequestAttachDataNames { get; set; }

        public ActionItem()
        {
            IsParentModule = false;

            RequestAttachDataNames = new List<string>();
        }

        public ActionItem(string actName, string actTag, string requestDataName)
            : this(actName, actTag, requestDataName, false, false)
        {
        }


        public ActionItem(string actName, string actTag, string requestDataName, bool isParentWindow, bool isParentModuleData)
        {
            IsParentModule = isParentWindow;
            IsParentModuleData = isParentModuleData;
            ActName = actName;
            ActTag = actTag;
            RequestDataName = requestDataName;

            RequestAttachDataNames = new List<string>();
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected ActionItem(SerializationInfo info, StreamingContext context)
        {
            try { ActName = info.GetString("ActName"); } catch { }
            try { ActTag = info.GetString("ActTag"); } catch { }
            try { RequestDataName = info.GetString("RequestDataName"); } catch { }
            try { IsParentModule = info.GetBoolean("IsParentModule"); } catch { }
            try { IsParentModuleData = info.GetBoolean("IsParentModuleData"); } catch { }
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ActName", ActName);
            info.AddValue("ActTag", ActTag);
            info.AddValue("RequestDataName", RequestDataName);
            info.AddValue("IsParentModule", IsParentModule);
            info.AddValue("IsParentModuleData", IsParentModuleData);
        }
    }


    [Serializable]
    public class EventActionReleation : ISerializable
    {
        public string EventName { get; set; }
        public ActionType ActType { get; set; }
        public string Tag { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Dictionary<string, ActionItem> Actions { get; set; }

        public EventActionReleation()
        {
            //模块方法，请求数据名称
            Actions = new Dictionary<string, ActionItem>();
        }

        public EventActionReleation(string eventName, ActionType actType)
            : this(eventName, actType, "")
        {

        }

        public EventActionReleation(string eventName, ActionType actType, string tag)
        {
            EventName = eventName;
            ActType = actType;
            Tag = tag;
            Actions = new Dictionary<string, ActionItem>();
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected EventActionReleation(SerializationInfo info, StreamingContext context)
        {
            EventName = info.GetString("EventName");
            ActType = (ActionType)(info.GetInt32("ActType"));
            Tag = info.GetString("Tag");

            Actions = DictionaryJsonHelper.DeserializeStringToDictionary<string, ActionItem>(info.GetString("Actions"));

        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EventName", EventName);
            info.AddValue("ActType", (int)ActType);
            info.AddValue("Tag", Tag);

            info.AddValue("Actions", DictionaryJsonHelper.SerializeDictionaryToJsonString<string, ActionItem>(Actions));
        }
    }


    public delegate void DoModuleAction(EventActionReleation ea);


}
