using DevExpress.Utils;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Design;

namespace zlMedimgSystem.Layout
{

    public interface IDesignWrapper<T> 
    {
        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        T Warper { get; }
    }

    public interface ILayoutWrapper//<T>where T : BaseLayoutItem
    {
        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        BaseLayoutItem Warper { get; }
    }


    public class SystemPropertyWrapper:IDesignWrapper<BizMainLayout>
    {
        private string _title = "医学影像系统";
        public BizMainLayout AppControl { get; set; }
        public string Title
        {
            get
            {
                if (AppControl != null) _title = AppControl.Title;
                return _title;
            }
            set
            {
                _title = value;
                if (AppControl != null) AppControl.Title = _title;
            }
        }

        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BizMainLayout Warper
        {
            get { return AppControl; }
        }

        public SystemPropertyWrapper()
        {

        }

        public SystemPropertyWrapper(object system)
        {
            AppControl = system as BizMainLayout;
            _title = AppControl.Title;
        }

    }

    public class LayoutControlItemProWrapper : ILayoutWrapper//<LayoutControlItem>
    {
        private LayoutControlItem _lci = null;

        public LayoutControlItemProWrapper(LayoutControlItem lci)
        {
            _lci = lci;
        }

        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BaseLayoutItem Warper
        {
            get { return _lci; }
        }

        [Category("DESIGN")]
        [DisplayName("文本显示")]
        public bool TextVisible
        {
            get { return _lci.TextVisible; }
            set { _lci.TextVisible = value; }
        }

        [Category("DESIGN")]
        [DisplayName("文本对齐样式")]
        public TextAlignModeItem TextAlignMode
        {
            get { return _lci.TextAlignMode; }
            set { _lci.TextAlignMode = value; }
        }


        [Category("DESIGN")]
        [DisplayName("文本间距")]
        public int TextToControlDistance
        {
            get { return _lci.TextToControlDistance; }
            set { _lci.TextToControlDistance = value; }
        }


        [Category("DESIGN")]
        [DisplayName("文本内容")]
        public string Text
        {
            get { return _lci.Text; }
            set { _lci.Text = value; }
        }

        [Category("DESIGN")]
        [DisplayName("文本位置")]
        public Locations TextLocation
        {
            get { return _lci.TextLocation; }
            set { _lci.TextLocation = value; }
        }

        [Category("DESIGN")]
        [DisplayName("布局项名称")]
        public string Name
        {
            get { return _lci.Name; } 
        }

        [Category("DESIGN")]
        [DisplayName("布局项边距")]
        public DevExpress.XtraLayout.Utils.Padding Padding
        {
            get { return _lci.Padding; }
            set { _lci.Padding = value; }
        }

        [Category("DESIGN")]
        [DisplayName("布局项间距")]
        public DevExpress.XtraLayout.Utils.Padding Spacing
        {
            get { return _lci.Spacing; }
            set { _lci.Spacing = value; }
        }

        [Category("DESIGN")]
        [DisplayName("嵌入模块")]
        [Description("设置嵌入模块相关的属性和事件。")]
        public DesignControl Control
        {
            get { return _lci.Control as DesignControl; }
        }

        [Category("DESIGN")]
        [DisplayName("最小区域")]
        [Description("设置当前布局项的最小显示区域大小，为0则不限制。")]
        public Size MinSize
        {
            get { return _lci.MinSize; }
            set { _lci.MinSize = value; }
        }

        [Category("DESIGN")]
        [DisplayName("最大区域")]
        [Description("设置当前布局项的最大显示区域大小，为0则不限制")]
        public Size MaxSize
        {
            get { return _lci.MaxSize; }
            set { _lci.MaxSize = value; }
        }

        [Category("DESIGN")]
        [DisplayName("当前区域")]
        public Size Size
        {
            get { return _lci.Size; }
            set { _lci.Size = value; }
        }


        [Category("DESIGN")]
        [DisplayName("区域类型")]
        [Description("设置当前布局项的区域类型")]
        public SizeConstraintsType SizeConstraintsType
        {
            get { return _lci.SizeConstraintsType; }
            set { _lci.SizeConstraintsType = value; }
        }

        [Category("DESIGN")]
        [DisplayName("字体")]
        [Description("设置当前布局项的字体样式")]
        public Font Font
        {
            get { return _lci.AppearanceItemCaption.Font; }
            set
            {
                _lci.AppearanceItemCaption.Font = value;
                _lci.AppearanceItemCaption.Options.UseFont = true;
            }
        }

        [Category("DESIGN")]
        [DisplayName("背景色")]
        [Description("设置背景显示颜色")]
        public Color BackColor
        {
            get
            {
                return _lci.AppearanceItemCaption.BackColor;
            }
            set
            {
                _lci.AppearanceItemCaption.BackColor = value;
                _lci.AppearanceItemCaption.Options.UseBackColor = true;
            }
        }

        [Category("DESIGN")]
        [DisplayName("渐变色")]
        [Description("设置背景显示渐变颜色")]
        public Color BackColor2
        {
            get
            {
                return _lci.AppearanceItemCaption.BackColor2;
            }
            set
            {
                _lci.AppearanceItemCaption.BackColor2 = value;
                _lci.AppearanceItemCaption.Options.UseBackColor = true;
            }
        }

        [Category("DESIGN")]
        [DisplayName("前景色")]
        [Description("设置前景显示颜色")]
        public Color ForeColor
        {
            get
            {
                return _lci.AppearanceItemCaption.ForeColor;
            }
            set
            {
                _lci.AppearanceItemCaption.ForeColor = value;
                _lci.AppearanceItemCaption.Options.UseForeColor = true;
            }
        }

        [Category("DESIGN")]
        [DisplayName("颜色样式")]
        [Description("设置背景色显示样式")]
        public System.Drawing.Drawing2D.LinearGradientMode GradientMode
        {
            get
            {
                return _lci.AppearanceItemCaption.GradientMode;
            }
            set
            {
                _lci.AppearanceItemCaption.GradientMode = value;
            }
        }

        [Category("DESIGN")]
        [DisplayName("文本横向样式")]
        [Description("设置文本横向显示样式")]
        public HorzAlignment TextHAlignment
        {
            get
            {
                return _lci.AppearanceItemCaption.TextOptions.HAlignment;
            }
            set
            {
                _lci.AppearanceItemCaption.TextOptions.HAlignment = value;
            }
        }

        [Category("DESIGN")]
        [DisplayName("文本纵向样式")]
        [Description("设置文本纵向显示样式")]
        public VertAlignment TextVAlignment
        {
            get
            {
                return _lci.AppearanceItemCaption.TextOptions.VAlignment;
            }
            set
            {
                _lci.AppearanceItemCaption.TextOptions.VAlignment = value;
            }
        }

        [Category("DESIGN")]
        [DisplayName("文本换行")]
        [Description("设置文本是否允许自动换行")]
        public WordWrap WordWrap
        {
            get
            {
                return _lci.AppearanceItemCaption.TextOptions.WordWrap;
            }
            set
            {
                _lci.AppearanceItemCaption.TextOptions.WordWrap = value;
            }
        }


        //private DesignControl _bindControl = null;
        //private DesignControl BindControl
        //{
        //    get
        //    {
        //        if (_bindControl == null) _bindControl = _lci.Control as DesignControl;
        //        return _bindControl;

        //    }
        //}


        //[DisplayName("模块边框样式")]
        //public BorderStyle BorderStyle
        //{
        //    get
        //    {
        //        if (BindControl != null)
        //        {
        //            return BindControl.BorderStyle;
        //        }
        //        else
        //        {
        //            return  BorderStyle.None;
        //        }
        //    }
        //    set
        //    {
        //        if (BindControl != null)
        //        {
        //            BindControl.BorderStyle = value;
        //        }
        //    }
        //}

        //[DisplayName("模块名称")]
        //public string ModuleName
        //{
        //    get
        //    {
        //        if (BindControl != null)
        //        {
        //            return BindControl.ModuleName;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //    set
        //    {
        //        if (BindControl != null)
        //        {
        //            BindControl.ModuleName = value;
        //        }
        //    }
        //}

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //[Editor(typeof(EventProEditor), typeof(UITypeEditor))]
        //[DisplayName("模块事件")]
        //public string DesignEventSerialFmt
        //{
        //    get
        //    {
        //        if (BindControl != null)
        //        {
        //            return BindControl.DesignEventSerialFmt;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //    set
        //    {
        //        if (BindControl != null)
        //        {
        //            BindControl.DesignEventSerialFmt = value;
        //        }
        //    }
        //}

        //[DisplayName("模块顺序")]
        //public int TabIndex
        //{
        //    get
        //    {
        //        if (BindControl != null)
        //        {
        //            return BindControl.TabIndex;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    set
        //    {
        //        if (BindControl != null)
        //        {
        //            BindControl.TabIndex = value;
        //        }
        //    }
        //}

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //[Editor(typeof(CustomDesignEditor), typeof(UITypeEditor))]
        //[DisplayName("模块自定设计")]
        //public string CustomDesignFmt
        //{
        //    get
        //    {
        //        if (BindControl != null)
        //        {
        //            return BindControl.CustomDesignFmt;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //    set
        //    {
        //        if (BindControl != null)
        //        {
        //            BindControl.CustomDesignFmt = value;
        //        }
        //    }
        //}

        //[DisplayName("模块前景色")]
        //public Color ForeColor
        //{
        //    get
        //    {
        //        if (BindControl != null)
        //        {
        //            return BindControl.ForeColor;
        //        }
        //        else
        //        {
        //            return Color.FromArgb(0,0,0);
        //        }
        //    }
        //    set
        //    {
        //        if (BindControl != null)
        //        {
        //            BindControl.ForeColor = value;
        //        }
        //    }
        //}

        //[DisplayName("模块区域大小")]
        //public Size Size
        //{
        //    get
        //    {
        //        if (BindControl != null)
        //        {
        //            return BindControl.Size;
        //        }
        //        else
        //        {
        //            return new Size(0,0);
        //        }
        //    }
        //    set
        //    {
        //        if (BindControl != null)
        //        {
        //            BindControl.Size = value;
        //        }
        //    }
        //}

        //[DisplayName("模块输入法模式")]
        //public ImeMode ImeMode
        //{
        //    get
        //    {
        //        if (BindControl != null)
        //        {
        //            return BindControl.ImeMode;
        //        }
        //        else
        //        {
        //            return ImeMode.NoControl;
        //        }
        //    }
        //    set
        //    {
        //        if (BindControl != null)
        //        {
        //            BindControl.ImeMode = value;
        //        }
        //    }
        //}

        //[DisplayName("模块最大区域范围")]
        //public Size MaximumSize
        //{
        //    get
        //    {
        //        if (BindControl != null)
        //        {
        //            return BindControl.MaximumSize;
        //        }
        //        else
        //        {
        //            return new Size(0,0);
        //        }
        //    }
        //    set
        //    {
        //        if (BindControl != null)
        //        {
        //            BindControl.MaximumSize = value;
        //        }
        //    }
        //}

        //[DisplayName("模块最小区域范围")]
        //public Size MinimumSize
        //{
        //    get
        //    {
        //        if (BindControl != null)
        //        {
        //            return BindControl.MinimumSize;
        //        }
        //        else
        //        {
        //            return new Size(0, 0);
        //        }
        //    }
        //    set
        //    {
        //        if (BindControl != null)
        //        {
        //            BindControl.MinimumSize = value;
        //        }
        //    }
        //}
    }

    public class LayoutControlGroupProWrapper : ILayoutWrapper//<LayoutControlGroup>
    {
        protected LayoutControlGroup _lcg = null;

        public LayoutControlGroupProWrapper(LayoutControlGroup lcg)
        {
            _lcg = lcg;
        }

        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BaseLayoutItem Warper
        {
            get { return _lcg; }
        }

        [Category("DESIGN")]
        [DisplayName("布局模式")]
        public LayoutMode LayoutMode
        {
            get { return _lcg.LayoutMode; }
            set { _lcg.LayoutMode = value; }
        }

        [Category("DESIGN")]
        [DisplayName("名称")]
        public string Name
        {
            get { return _lcg.Name; }
        }

        [Category("DESIGN")]
        [DisplayName("文本显示")]
        public bool TextVisible
        {
            get { return _lcg.TextVisible; }
            set { _lcg.TextVisible = value; }
        }

        [Category("DESIGN")]
        [DisplayName("文本内容")]
        public string Text
        {
            get { return _lcg.Text; }
            set { _lcg.Text = value; }
        }

        [Category("DESIGN")]
        [DisplayName("边距")]
        [Description("设置边距大小。")]
        public DevExpress.XtraLayout.Utils.Padding Padding
        {
            get { return _lcg.Padding; }
            set { _lcg.Padding = value; }
        }

        [Category("DESIGN")]
        [DisplayName("间距")]
        [Description("设置间距大小。")]
        public DevExpress.XtraLayout.Utils.Padding Spacing
        {
            get { return _lcg.Spacing; }
            set { _lcg.Spacing = value; }
        }


        [Category("DESIGN")]
        [DisplayName("背景色")]
        [Description("设置背景颜色。")]
        public Color BackColor
        {
            get { return _lcg.AppearanceGroup.BackColor; }
            set
            {
                _lcg.AppearanceGroup.BackColor = value;
                _lcg.AppearanceGroup.Options.UseBackColor = true;
            }
        }

        [Category("DESIGN")]
        [DisplayName("渐变色")]
        [Description("设置背景显示渐变颜色")]
        public Color BackColor2
        {
            get
            {
                return _lcg.AppearanceGroup.BackColor2;
            }
            set
            {
                _lcg.AppearanceGroup.BackColor2 = value;
                _lcg.AppearanceGroup.Options.UseBackColor = true;
            }
        }

        [Category("DESIGN")]
        [DisplayName("前景色")]
        [Description("设置前景显示颜色")]
        public Color ForeColor
        {
            get
            {
                return _lcg.AppearanceGroup.ForeColor;
            }
            set
            {
                _lcg.AppearanceGroup.ForeColor = value;
                _lcg.AppearanceGroup.Options.UseForeColor = true;
            }
        }

        [Category("DESIGN")]
        [DisplayName("颜色样式")]
        [Description("设置背景色显示样式")]
        public System.Drawing.Drawing2D.LinearGradientMode GradientMode
        {
            get
            {
                return _lcg.AppearanceGroup.GradientMode;
            }
            set
            {
                _lcg.AppearanceGroup.GradientMode = value;
            }
        }

 
        [Category("DESIGN")]
        [DisplayName("文本横向样式")]
        [Description("设置文本横向显示样式")]
        public HorzAlignment TextHAlignment
        {
            get
            {
                return _lcg.AppearanceGroup.TextOptions.HAlignment;
            }
            set
            {
                _lcg.AppearanceGroup.TextOptions.HAlignment = value;
            }
        }

        [Category("DESIGN")]
        [DisplayName("文本纵向样式")]
        [Description("设置文本纵向显示样式")]
        public VertAlignment TextVAlignment
        {
            get
            {
                return _lcg.AppearanceGroup.TextOptions.VAlignment;
            }
            set
            {
                _lcg.AppearanceGroup.TextOptions.VAlignment = value;
            }
        }

        [Category("DESIGN")]
        [DisplayName("文本换行")]
        [Description("设置文本是否允许自动换行")]
        public WordWrap WordWrap
        {
            get
            {
                return _lcg.AppearanceGroup.TextOptions.WordWrap;
            }
            set
            {
                _lcg.AppearanceGroup.TextOptions.WordWrap = value;
            }
        }
    }

    public class LayoutControlRootGroupWrapper: LayoutControlGroupProWrapper, ILayoutWrapper
    {
        public LayoutControlRootGroupWrapper(LayoutControlGroup lcg)
            :base(lcg)
        {

        }

        [Bindable(false), Browsable(false)]
        [Category("HIDE")]
        [DisplayName("文本内容")]
        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        [Category("DESIGN")]
        [DisplayName("数据标记")]
        public string Tag
        {
            get { return _lcg.Text; }
            set { _lcg.Text = value; }
        }
    }

    public class TabbedControlGroupProWrapper : ILayoutWrapper//<TabbedControlGroup>
    {
        private TabbedControlGroup _tcg = null;

        public TabbedControlGroupProWrapper(TabbedControlGroup tcg)
        {
            _tcg = tcg;
        }

        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BaseLayoutItem Warper
        {
            get { return _tcg; }
        }


        [Category("DESIGN")]
        [DisplayName("名称")]
        public string Name
        {
            get { return _tcg.Name; }
        }

        [Category("DESIGN")]
        [DisplayName("多行显示")]
        public DefaultBoolean MultiLine
        {
            get { return _tcg.MultiLine; }
            set { _tcg.MultiLine = value; }
        }

        [Category("DESIGN")]
        [DisplayName("文本方向")]
        public TabOrientation HeaderOrientation
        {
            get { return _tcg.HeaderOrientation; }
            set { _tcg.HeaderOrientation = value; }
        }

        [Category("DESIGN")]
        [DisplayName("文本填充")] 
        public DefaultBoolean HeaderAutoFill
        {
            get { return _tcg.HeaderAutoFill; }
            set { _tcg.HeaderAutoFill = value; }
        }

        [Category("DESIGN")]
        [DisplayName("文本位置")] 
        public Locations TextLocation
        {
            get { return _tcg.TextLocation; }
            set { _tcg.TextLocation = value; }
        }

        [Category("DESIGN")]
        [DisplayName("边距")]
        [Description("设置边距大小。")]
        public DevExpress.XtraLayout.Utils.Padding Padding
        {
            get { return _tcg.Padding; }
            set { _tcg.Padding = value; }
        }

        [Category("DESIGN")]
        [Description("设置间距大小。")]
        [DisplayName("间距")]
        public DevExpress.XtraLayout.Utils.Padding Spacing
        {
            get { return _tcg.Spacing; }
            set { _tcg.Spacing = value; }
        }


        [Category("DESIGN")]
        [DisplayName("背景色")]
        [Description("设置背景颜色。")]
        public Color BackColor
        {
            get { return _tcg.AppearanceGroup.BackColor; }
            set
            {
                _tcg.AppearanceGroup.BackColor = value;
                _tcg.AppearanceGroup.Options.UseBackColor = true;
            }
        }

        [Category("DESIGN")]
        [DisplayName("渐变色")]
        [Description("设置背景显示渐变颜色")]
        public Color BackColor2
        {
            get
            {
                return _tcg.AppearanceGroup.BackColor2;
            }
            set
            {
                _tcg.AppearanceGroup.BackColor2 = value;
                _tcg.AppearanceGroup.Options.UseBackColor = true;
            }
        }

        [Category("DESIGN")]
        [DisplayName("前景色")]
        [Description("设置前景显示颜色")]
        public Color ForeColor
        {
            get
            {
                return _tcg.AppearanceGroup.ForeColor;
            }
            set
            {
                _tcg.AppearanceGroup.ForeColor = value;
                _tcg.AppearanceGroup.Options.UseForeColor = true;
            }
        }

        [Category("DESIGN")]
        [DisplayName("颜色样式")]
        [Description("设置背景色显示样式")]
        public System.Drawing.Drawing2D.LinearGradientMode GradientMode
        {
            get
            {
                return _tcg.AppearanceGroup.GradientMode;
            }
            set
            {
                _tcg.AppearanceGroup.GradientMode = value; 
            }
        }

        [Category("DESIGN")]
        [DisplayName("文本横向样式")]
        [Description("设置文本横向显示样式")]
        public HorzAlignment TextHAlignment
        {
            get
            {
                return _tcg.AppearanceGroup.TextOptions.HAlignment;
            }
            set
            {
                _tcg.AppearanceGroup.TextOptions.HAlignment = value;
            }
        }

        [Category("DESIGN")]
        [DisplayName("文本纵向样式")]
        [Description("设置文本纵向显示样式")]
        public VertAlignment TextVAlignment
        {
            get
            {
                return _tcg.AppearanceGroup.TextOptions.VAlignment;
            }
            set
            {
                _tcg.AppearanceGroup.TextOptions.VAlignment = value;
            }
        }

        [Category("DESIGN")]
        [DisplayName("文本换行")]
        [Description("设置文本是否允许自动换行")]
        public WordWrap WordWrap
        {
            get
            {
                return _tcg.AppearanceGroup.TextOptions.WordWrap;
            }
            set
            {
                _tcg.AppearanceGroup.TextOptions.WordWrap = value;
            }
        }
    }
}
