
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text; 
using zlMedimgSystem.Design;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Navigate
{
    /// <summary>
    /// 导航按钮类型
    /// </summary>
    public enum NavigateType
    {
        /// <summary>
        /// 主导航
        /// </summary>
        ntMain,

        /// <summary>
        /// 附加导航
        /// </summary>
        ntAttach,

        /// <summary>
        /// 下拉导航
        /// </summary>
        ntDropdown
    }

    //涉及Object对象属性时，需要实现虚拟化接口处理
    [Serializable]
    public class NavItemConfig : ISerializable
    {
        public string Name { get; set; }
        public string IconName { get; set; }

        public NavigateType Style { get; set; }

        public string Tag { get; set; }

        /// <summary>
        /// 运行时设置此链接对象
        /// </summary>
        public object LinkObj { get; set; }


        //public IList<string> SubItems { get; set; }

        public NavItemConfig()
        {
            //SubItems = new List<string>();
        }

        public NavItemConfig(string name)
            : this(name, NavigateType.ntMain, "", "")
        {

        }

        public NavItemConfig(string name, NavigateType style)
            : this(name, style, "", "")
        {

        }

        public NavItemConfig(string name, NavigateType style, string tag)
            : this(name, style, tag, "")
        {

        }

        public NavItemConfig(string name, NavigateType style, string tag, string iconName)
        {
            Name = name;
            Style = style;
            Tag = tag;
            IconName = iconName;
        }


        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected NavItemConfig(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            IconName = info.GetString("IconName");
            Style = ((NavigateType)(info.GetInt32("Style")));
            Tag = info.GetString("Tag");
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("IconName", IconName);
            info.AddValue("Style", (int)Style);
            info.AddValue("Tag", Tag);
        }
    }

     
    public class NavButVisible  
    {
        public bool 图标 { get; set; }
        public bool 附加菜单 { get; set; }
        public bool 退出按钮 { get; set; }

        public NavButVisible()
        {

        } 
    } 

    public class NavModuleDesign 
    {
        public Color BackColor { get; set; }
        public Color ForceColor { get; set; }
        public NavButVisible ButVisible { get; set; } 
        public List<NavItemConfig> NavItems { get; set; }
        public NavModuleDesign()
        {
            ButVisible = new NavButVisible();
            NavItems = new List<NavItemConfig>();
        }
         
    }
}
