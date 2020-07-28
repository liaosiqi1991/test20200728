using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Design;

namespace zlMedimgSystem.BusinessBase
{
    public enum ToolDockWay
    {
        /// <summary>
        /// 顶部
        /// </summary>
        tdwTop = 0,

        /// <summary>
        /// 左侧
        /// </summary>
        tdwLeft = 1,

        /// <summary>
        /// 右侧
        /// </summary>
        tdwRight = 2,

        /// <summary>
        /// 底部
        /// </summary>
        tdwBottom = 3
    }

    public enum ToolType
    {
        ttLabel = 0,
        ttButton = 1,
        ttDrowDownButton = 2,
        ttSeparator = 3
    }

    public enum ToolDisplayStyle
    {
        tdsText = 0,
        tdsImage = 1,
        tdsTextAndImage = 2,
    }

    public enum ToolLayout
    {
        tlHorizontal = 0,
        tlVertical = 1,
    }

    public enum ToolIconStyle
    {
        tisImageAboveText =0,
        tisTextAboveImage = 1,
        tisImageBeforeText = 2,
        tisTextBeforeImage = 3
    }

    [Serializable]
    public class ToolItemConfig : ISerializable
    {
        public string 名称 { get; set; }

        public string 图标 { get; set; }

        public ToolIconStyle 图标位置 { get; set; }

        public bool 右对齐 { get; set; }

        public string 父级名称 { get; set; }

        public ToolType 按钮类型 { get; set; }

        public ToolDisplayStyle 显示样式 { get; set; }

        public string 标记 { get; set; }

        /// <summary>
        /// 运行时设置此链接对象
        /// </summary>
        public object LinkObj { get; set; }



        public ToolItemConfig()
        {
        }

        public ToolItemConfig(string name)
            : this(name, "", "")
        {

        }


        public ToolItemConfig(string name, string tag)
            : this(name, tag, "")
        {

        }

        public ToolItemConfig(string name, string tag, string iconName)
        {
            按钮类型 = ToolType.ttButton;
            显示样式 = ToolDisplayStyle.tdsText;
            右对齐 = false;

            名称 = name;
            标记 = tag;
            图标 = iconName;
        }


        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected ToolItemConfig(SerializationInfo info, StreamingContext context)
        {
            名称 = info.GetString("名称");
            图标 = info.GetString("图标");
            右对齐 = info.GetBoolean("右对齐");
            按钮类型 = (ToolType)info.GetInt32("按钮类型");
            显示样式 = (ToolDisplayStyle)info.GetInt32("显示样式");
            父级名称 = info.GetString("父级名称");
            标记 = info.GetString("标记");
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("名称", 名称);
            info.AddValue("图标", 图标);
            info.AddValue("右对齐", 右对齐);
            info.AddValue("按钮类型", (int)按钮类型);
            info.AddValue("显示样式", (int)显示样式);
            info.AddValue("父级名称", 父级名称);
            info.AddValue("标记", 标记);
        }
    }



    public class ToolsDesign
    {
        public bool Visible { get; set; }
        public int Size { get; set; }
        public Color BackColor { get; set; }

        public Color ForceColor { get; set; }
        public ToolLayout LayoutStyle { get; set; }
        public List<ToolItemConfig> ToolsCfg { get; set; }

        public ToolsDesign()
        {
            ToolsCfg = new List<ToolItemConfig>();
        }
    }

    static public class ToolsHelper
    {         
        static public void ConfigButtons(ToolStrip toolStrip, ToolsDesign toolDesign, EventHandler itemClick)
        {
            toolStrip.ImageList = Img24Resource.Imgs; 

            //添加用户工具按钮
            foreach (ToolItemConfig toolItem in toolDesign.ToolsCfg)
            {
                //创建快捷按钮
                ToolStripItem tsBut = null;

                switch (toolItem.按钮类型)
                {
                    case ToolType.ttLabel:
                        tsBut = new ToolStripLabel();
                        break;

                    case ToolType.ttButton:
                        tsBut = new ToolStripButton();
                        break;

                    case ToolType.ttDrowDownButton:
                        tsBut = new ToolStripDropDownButton();
                        break;

                    case ToolType.ttSeparator:
                        tsBut = new ToolStripSeparator();
                        break;

                    default:
                        break;
                }

                switch (toolItem.显示样式)
                {
                    case ToolDisplayStyle.tdsText:
                        tsBut.DisplayStyle = ToolStripItemDisplayStyle.Text;
                        break;

                    case ToolDisplayStyle.tdsImage:
                        tsBut.DisplayStyle = ToolStripItemDisplayStyle.Image;
                        break;

                    case ToolDisplayStyle.tdsTextAndImage:
                        tsBut.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                        break;

                    default:
                        break;
                }

                switch (toolItem.图标位置)
                {
                    case ToolIconStyle.tisImageAboveText:
                        tsBut.TextImageRelation = TextImageRelation.ImageAboveText;
                        break;

                    case ToolIconStyle.tisTextAboveImage:
                        tsBut.TextImageRelation = TextImageRelation.TextAboveImage;
                        break;

                    case ToolIconStyle.tisImageBeforeText:
                        tsBut.TextImageRelation = TextImageRelation.ImageBeforeText;
                        break;

                    default:
                        tsBut.TextImageRelation = TextImageRelation.TextBeforeImage;
                        break;
                }

                if (toolItem.右对齐) tsBut.Alignment = ToolStripItemAlignment.Right;
      
                tsBut.Name = toolItem.名称;
                tsBut.Text = toolItem.名称;
                tsBut.Tag = toolItem.标记;

                Img24Resource.LoadImg(toolItem.图标);
                tsBut.ImageKey = toolItem.图标;
                 

                tsBut.ForeColor = toolDesign.ForceColor;
                tsBut.Click += itemClick;

                if (string.IsNullOrEmpty(toolItem.父级名称))
                {
                    toolStrip.Items.Add(tsBut);
                }
                else
                {
                    ToolStripItem[] tsiParent = toolStrip.Items.Find(toolItem.父级名称, true);

                    ToolStripDropDownButton dropDownButton = tsiParent[0] as ToolStripDropDownButton;

                    if (dropDownButton != null)
                    {
                        dropDownButton.DropDownItems.Add(tsBut);
                    }
                }

                toolItem.LinkObj = tsBut;
            }
        }

        static public void SyncDesignEventsByButtons(ToolsDesign toolDesign, Dictionary<string, EventActionReleation> designEvents)
        {
            foreach (ToolItemConfig tic in toolDesign.ToolsCfg)
            {
                if (designEvents.ContainsKey(tic.名称) == false)
                {
                    designEvents.Add(tic.名称, new EventActionReleation(tic.名称, ActionType.atSysCustomEvent));
                }
            }

            List<string> keys = new List<string>(designEvents.Keys);

            for (int i = keys.Count - 1; i >= 0; i--)
            {
                //固定事件不允许删除
                if (designEvents[keys[i]].ActType == ActionType.atSysFixedEvent) continue;

                if (toolDesign.ToolsCfg.FindIndex(T => T.名称 == keys[i]) < 0)
                {
                    //未找到对应按钮
                    designEvents.Remove(keys[i]);
                }
            }
        }
    }
}
