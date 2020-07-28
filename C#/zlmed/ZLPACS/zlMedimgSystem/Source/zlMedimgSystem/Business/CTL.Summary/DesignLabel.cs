using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Summary
{
    public class DesignLabel : SimpleLabelItem, IFixedLayoutControlItem  //EmptySpaceItem, IFixedLayoutControlItem
    {
        public override string TypeName { get { return "DesignLabel"; } }//这里必须使用固定的名称并且必须和类名称相同 
        protected virtual string _customizationName { get { return "文本控件"; } }
         
        public string FormatContext
        {
            get
            {
                if (Formats == null) return "";

                return JsonHelper.SerializeObject(Formats);
            }
            set
            {
                if (string.IsNullOrEmpty(value)) Formats = null;

                Formats = JsonHelper.DeserializeObject<DesignLabelFormats>(value);
            }
        }
        public DesignLabelFormats Formats { get; set; }

        public DesignLabel()
        {
            Formats = new DesignLabelFormats();
                        
            SizeConstraintsType = SizeConstraintsType.Custom;

            TextVisible = true;
            AppearanceItemCaption.Options.UseBackColor = true;
            AppearanceItemCaption.Options.UseForeColor = true;
            AppearanceItemCaption.Options.UseFont = true;

            Formats.默认背景色 = this.AppearanceItemCaption.BackColor;
            Formats.默认前景色 = this.AppearanceItemCaption.ForeColor;
        }


        string IFixedLayoutControlItem.CustomizationName { get { return _customizationName; } }
        Image IFixedLayoutControlItem.CustomizationImage { get { return null; } }
        bool IFixedLayoutControlItem.AllowChangeTextLocation { get { return true; } }
        bool IFixedLayoutControlItem.AllowChangeTextVisibility { get { return true; } }
        bool IFixedLayoutControlItem.AllowClipText { get { return true; } }
        ILayoutControl IFixedLayoutControlItem.Owner { get { return base.Owner; } set { base.Owner = value; } }

 
    }

    public class DesignLabelPropertiesWrapper : BasePropertyGridObjectWrapper
    {
        protected DesignLabel _layoutItem
        {
            get
            {
                DesignLabel curItem = WrappedObject as DesignLabel;

                curItem.Formats.默认背景色 = curItem.AppearanceItemCaption.BackColor;
                curItem.Formats.默认前景色 = curItem.AppearanceItemCaption.ForeColor;

                return curItem;
            }
        }

        public DesignLabelPropertiesWrapper()
        { 
            
        }

        [Localizable(true)]
        [DisplayName("名称")]
        public string Name
        {
            get { return _layoutItem.Name; }
            set { _layoutItem.Name = value; }
        }

 
        [DisplayName("图像")] 
        public Image Image
        {
            get { return _layoutItem.Image; }
            set { _layoutItem.Image = value; }
        }

        [DisplayName("图像位置")] 
        public ContentAlignment ImageAlignment
        {
            get { return _layoutItem.ImageAlignment; }
            set { _layoutItem.ImageAlignment = value; }
        }

        [DisplayName("图像间距")] 
        public int ImageToTextDistance
        {
            get { return _layoutItem.ImageToTextDistance; }
            set { _layoutItem.ImageToTextDistance = value; }
        }

        [DisplayName("默认文本")] 
        public string Text
        {
            get { return _layoutItem.Text; }
            set { _layoutItem.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Editor(typeof(DesignLabelFormatEditor), typeof(UITypeEditor))]
        [DisplayName("格式")]
        public string FormatContext
        {
            get { return _layoutItem.FormatContext; }
            set
            {
                _layoutItem.FormatContext = value;
            }
        }

        [DisplayName("对齐模式")] 
        public TextAlignModeItem TextAlignMode
        {
            get { return  _layoutItem.TextAlignMode; }
            set { _layoutItem.TextAlignMode = value; }
        }

        [DisplayName("最小区域")] 
        public Size MinSize
        {
            get { return _layoutItem.MinSize; }
            set { _layoutItem.MinSize = value; }
        }

        [DisplayName("最大区域")] 
        public Size MaxSize
        {
            get { return _layoutItem.MaxSize; }
            set { _layoutItem.MaxSize = value; }
        }

        [DisplayName("当前区域")] 
        public Size Size
        {
            get { return _layoutItem.Size; }
            set { _layoutItem.Size = value; }
        }

        [DisplayName("文本区域")] 
        public Size TextSize
        {
            get { return _layoutItem.TextSize; }
            set { _layoutItem.TextSize = value; }
        }

        [DisplayName("显示文本")] 
        public bool TextVisible
        {
            get { return _layoutItem.TextVisible; }
            set { _layoutItem.TextVisible = value; }
        }

        [DisplayName("区域类型")]
        public SizeConstraintsType SizeConstraintsType
        {
            get { return _layoutItem.SizeConstraintsType; }
            set { _layoutItem.SizeConstraintsType = value; }
        }

        [DisplayName("背景色")]
        public Color BackColor
        {
            get { return _layoutItem.AppearanceItemCaption.BackColor; }
            set
            {
                _layoutItem.AppearanceItemCaption.BackColor = value;
                _layoutItem.AppearanceItemCaption.Options.UseBackColor = true;
            }
        }

        [DisplayName("前景色")]
        public Color ForeColor
        {
            get { return _layoutItem.AppearanceItemCaption.ForeColor; }
            set
            {
                _layoutItem.AppearanceItemCaption.ForeColor = value;
                _layoutItem.AppearanceItemCaption.Options.UseForeColor = true;
            }
        }

        [DisplayName("字体")]
        public Font Font
        {
            get { return _layoutItem.AppearanceItemCaption.Font; }
            set
            {
                _layoutItem.AppearanceItemCaption.Font = value;
                _layoutItem.AppearanceItemCaption.Options.UseFont = true;
            }
        }



        public override BasePropertyGridObjectWrapper Clone()
        {
            return this;
        }
    }
}
