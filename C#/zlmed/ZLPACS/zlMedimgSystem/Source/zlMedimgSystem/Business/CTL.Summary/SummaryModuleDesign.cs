using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.CTL.Summary
{
    public class DesignLabelFormatItem
    {
        public string 数据值 { get; set; }
        public string 显示内容 { get; set; }
        public string 图标名称 { get; set; }
        public Color 背景色 { get; set; }
        public Color 前景色 { get; set; }


    }

    public class DesignLabelFormats
    {
        public string 数据项名称 { get; set; }

        public Color 默认背景色 { get; set; }
        public Color 默认前景色 { get; set; }


        public List<DesignLabelFormatItem> 文本格式 { get; set; }

        public DesignLabelFormats()
        {
            文本格式 = new List<DesignLabelFormatItem>();
        }
    }

    public class BindDataSource
    {
        public string 查询语句 { get; set; }

        public string 数据源别名 { get; set; }

        public BindDataSource()
        {
        }
    }

    
    public class ItemFormat
    {
        public string ItemName { get; set; }
        public DesignLabelFormats Formats { get; set; }

        public ItemFormat()
        {
            Formats = new DesignLabelFormats();
        }
    }

    public class SummaryModuleDesign
    {
        public string LayoutFormats { get; set; }
        public List<ItemFormat> ItemFormats { get; set; }

        public BindDataSource DBSource { get; set; }

        public SummaryModuleDesign()
        {
            ItemFormats = new List<ItemFormat>();
            DBSource = new BindDataSource();
        }
    }

    static public class GlobalDB
    {
        static private BindDataSource _dbSource = null;
        static public BindDataSource DBSource
        {
            get
            {
                if (_dbSource == null) _dbSource = new BindDataSource();

                return _dbSource;
            }
            set
            {
                _dbSource = value;
            }
        }

        static public IDBQuery DBHelper
        {
            get;set;
        }
    }



}
