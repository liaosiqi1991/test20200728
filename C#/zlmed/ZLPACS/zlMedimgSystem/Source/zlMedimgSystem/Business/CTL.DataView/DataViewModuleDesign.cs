using DevExpress.Utils;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.CTL.DataView
{

    public static class ViewControlType
    {
        public const string Lab = "标签";
        public const string Txt = "文本框";
        public const string Cbx = "下拉框";
        public const string Dtp = "日期框";
        public const string List = "列表框";
        public const string Checkbox = "复选框";
        public const string ChkCombobox = "下拉勾选框";
        public const string ChkListbox = "列表勾选框";
                
        //public const string SystemTag = "系统_";

    }

    public class ViewItem
    {
        /// <summary>
        /// 项目标签
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// 控件类型
        /// </summary>
        public string ControlType { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 数据源别名
        /// </summary>
        public string DBAlias { get; set; }

        /// <summary>
        /// 数据来源
        /// </summary>
        public string DataFrom { get; set; }

        /// <summary>
        /// 绑定数据名称
        /// </summary>
        public string BindDataName { get; set; }

        /// <summary>
        /// 实例名称
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        /// 关联实例
        /// </summary>
        public Control ReleationInstance { get; set; }

        /// <summary>
        /// 只读
        /// </summary>
        public bool ReadOnly { get; set; }

        public ViewItem Clone()
        {
            ViewItem viClone = new ViewItem();

            viClone.Caption = Caption;
            viClone.ControlType = ControlType;
            viClone.DefaultValue = DefaultValue;
            viClone.DBAlias = DBAlias;
            viClone.DataFrom = DataFrom;
            viClone.BindDataName = BindDataName;
            viClone.InstanceName = InstanceName;
            viClone.ReleationInstance = ReleationInstance;
            viClone.ReadOnly = ReadOnly;

            return viClone;
        }


    }
    public class DataViewModuleDesign
    {
        public string DBSourceAlias { get; set; }        
        public string DataFrom { get; set; }
        public List<ViewItem> Items { get; set; }
        public string LayoutFmt { get; set; }

        public DataViewModuleDesign()
        {
            Items = new List<ViewItem>();
        }
    }

    public class ViewItemWrapper
    {
        private LayoutControlItem _lci { get; set; }
        public ViewItemWrapper(LayoutControlItem lci)
        {
            _lci = lci;
        }

        public Control Parent
        {
            get { return _lci.Owner.Parent; }
        }

        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BaseLayoutItem Warper
        {
            get { return _lci; }
        }

        //[Category("DESIGN")]
        //[DisplayName("文本显示")]
        //public bool TextVisible
        //{
        //    get { return _lci.TextVisible; }
        //    set { _lci.TextVisible = value; }
        //}

        [Category("DESIGN")]
        [DisplayName("标签内容")]
        public string Caption
        {
            get { return _lci.Text; }
            set
            {
                _lci.Text = value;

                if (_lci.Control == null) return;
                if (_lci.Control.Tag == null) return;

                ViewItem vi = _lci.Control.Tag as ViewItem;
                if (vi == null) return;

                vi.Caption = value;

                if (_lci.Control is Label)
                {
                    Label lab = _lci.Control as Label;
                    if (lab != null) lab.Text = value;
                }
            }
        }

        [Category("DESIGN")]
        [DisplayName("文本位置")]
        public Locations TextLocation
        {
            get { return _lci.TextLocation; }
            set { _lci.TextLocation = value; }
        }

        //[Category("DESIGN")]
        //[DisplayName("布局项名称")]
        //public string Name
        //{
        //    get { return _lci.Name; }
        //}

        [Category("DESIGN")]
        [DisplayName("边距")]
        public DevExpress.XtraLayout.Utils.Padding Padding
        {
            get { return _lci.Padding; }
            set { _lci.Padding = value; }
        }

        [Category("DESIGN")]
        [DisplayName("间距")]
        public DevExpress.XtraLayout.Utils.Padding Spacing
        {
            get { return _lci.Spacing; }
            set { _lci.Spacing = value; }
        }

        [Localizable(true)]
        [Category("DESIGN")]
        [DisplayName("组件类型")]
        public string ControlType
        {
            get
            {
                if(_lci.Control is Label)
                {
                    return ViewControlType.Lab;
                }
                else if (_lci.Control is TextBox)
                {
                    return ViewControlType.Txt;
                }
                else if (_lci.Control is ComboBox)
                {
                    return ViewControlType.Cbx;
                }
                else if (_lci.Control is DateTimePicker)
                {
                    return ViewControlType.Txt;
                }
                else if (_lci.Control is CheckBox)
                {
                    return ViewControlType.Checkbox;
                }
                else
                {
                    return "未知类型";
                }

            }

        }

        [Localizable(true)]
        [Category("DESIGN")]
        [DisplayName("默认值")]
        [Description("设置组件的默认值。")]
        public string DefaultValue
        {
            get
            {
                if (_lci == null || _lci.Control == null) return "";
                if (_lci.Control.Tag == null) return "";

                ViewItem vi = _lci.Control.Tag as ViewItem;
                if (vi == null) return "";

                return vi.DefaultValue;
            }
            set
            {
                if (_lci == null || _lci.Control == null) return;
                if (_lci.Control.Tag == null) return;

                ViewItem vi = _lci.Control.Tag as ViewItem;
                if (vi == null) return;

                vi.DefaultValue = value;

                try
                {
                    if (string.IsNullOrEmpty(vi.DefaultValue) == false)
                    {
                        TextBox TxtItem = _lci.Control as TextBox;
                        if (TxtItem != null) TxtItem.Text = vi.DefaultValue;

                        ComboBox cbxItem = _lci.Control as ComboBox;
                        if (cbxItem != null) cbxItem.Text = vi.DefaultValue;

                        DateTimePicker dtpItem = _lci.Control as DateTimePicker;
                        if (dtpItem != null) dtpItem.Value = Convert.ToDateTime(vi.DefaultValue);

                        CheckBox chkItem = _lci.Control as CheckBox;
                        if (chkItem != null) chkItem.Checked = Convert.ToBoolean(vi.DefaultValue);
                    }
                }
                catch { }
            }
        }


        [Localizable(true)]
        [Category("DESIGN")]
        [DisplayName("只读")]
        [Description("设置组件的默认值。")]
        public bool ReadOnly
        {
            get
            {
                if (_lci == null || _lci.Control == null) return false;
                if (_lci.Control.Tag == null) return false;

                ViewItem vi = _lci.Control.Tag as ViewItem;
                if (vi == null) return false;

                return vi.ReadOnly;
            }
            set
            {
                if (_lci == null || _lci.Control == null) return;
                if (_lci.Control.Tag == null) return;

                ViewItem vi = _lci.Control.Tag as ViewItem;
                if (vi == null) return;

                vi.ReadOnly = value;

                try
                {
                    if (string.IsNullOrEmpty(vi.DefaultValue) == false)
                    {
                        if (_lci.Control is TextBox)
                        {
                            TextBox TxtItem = _lci.Control as TextBox;
                            if (TxtItem != null) TxtItem.ReadOnly = vi.ReadOnly;
                        }
                        else if (_lci.Control is ComboBox)
                        {
                            ComboBox cbxItem = _lci.Control as ComboBox;
                            if (cbxItem != null) cbxItem.Enabled = !vi.ReadOnly;
                        }
                        else if (_lci.Control is DateTimePicker)
                        {
                            DateTimePicker dtpItem = _lci.Control as DateTimePicker;
                            if (dtpItem != null) dtpItem.Enabled = !vi.ReadOnly;
                        }
                        else if (_lci.Control is CheckBox)
                        {
                            CheckBox chkItem = _lci.Control as CheckBox;
                            if (chkItem != null) chkItem.Enabled = !vi.ReadOnly;
                        }
                        else if (_lci.Control is Label)
                        {
                        }
                    }
                }
                catch { }
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Editor(typeof(DataFieldEditor), typeof(UITypeEditor))]
        [Localizable(true)]
        [Category("DESIGN")]
        [DisplayName("绑定数据")]
        [Description("设置编定数据显示的数据名称。")]
        public string BindDataName
        {
            get {
                if (_lci == null || _lci.Control == null) return "";
                if (_lci.Control.Tag == null) return "";

                ViewItem vi = _lci.Control.Tag as ViewItem;
                if (vi == null) return "";

                return vi.BindDataName;
            }
            set
            {
                if (_lci == null || _lci.Control == null) return;
                if (_lci.Control.Tag == null) return;

                ViewItem vi = _lci.Control.Tag as ViewItem;
                if (vi == null) return;

                vi.BindDataName = value;

            }
        }

        [Localizable(true)]
        [Category("DESIGN")]
        [DisplayName("实例名称")]
        [Description("设置控件唯一的识别名称。")]
        public string InstanceName
        {
            get
            {
                if (_lci == null || _lci.Control == null) return "";
                if (_lci.Control.Tag == null) return "";

                ViewItem vi = _lci.Control.Tag as ViewItem;
                if (vi == null) return "";

                return vi.InstanceName;
            }
            set
            {
                if (_lci == null || _lci.Control == null) return;
                if (_lci.Control.Tag == null) return;

                ViewItem vi = _lci.Control.Tag as ViewItem;
                if (vi == null) return;
 
                
                vi.InstanceName = value;
                _lci.Control.Name = value;
                _lci.ControlName = value;


            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Editor(typeof(DataFromEditor), typeof(UITypeEditor))]
        [Localizable(true)]
        [Category("DESIGN")]
        [DisplayName("数据来源")]
        [Description("")]
        public string DataForm
        {
            get
            {
                if (_lci == null || _lci.Control == null) return "";
                if (_lci.Control.Tag == null) return "";

                ViewItem vi = _lci.Control.Tag as ViewItem;
                if (vi == null) return "";

                return vi.DBAlias + "|" + vi.DataFrom;
            }
            set
            {
                if (_lci == null || _lci.Control == null) return;
                if (_lci.Control.Tag == null) return;

                ViewItem vi = _lci.Control.Tag as ViewItem;
                if (vi == null) return;

                string[] tmp = value.Split('|');
                if (tmp.Length > 1)
                {
                    vi.DBAlias = tmp[0];
                    vi.DataFrom = tmp[1];
                }
                else
                {
                    vi.DBAlias = "";
                    vi.DataFrom = tmp[0];
                }

            }
        }




        //[Category("DESIGN")]
        //[DisplayName("嵌入模块")]
        //[Description("设置嵌入模块相关的属性和事件。")]
        //public DesignControl Control
        //{
        //    get { return _lci.Control as DesignControl; }
        //}

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
    }
}
