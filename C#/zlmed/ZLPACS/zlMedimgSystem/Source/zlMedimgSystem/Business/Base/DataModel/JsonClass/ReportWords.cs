using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{

    public class JReportCharItem
    {
        public string 字符内容 { get; set; }
        public int 使用次数 { get; set; }

        public JReportCharItem()
        {

        }

        public JReportCharItem(string chr)
            :this(chr, 0)
        { 
        }

        public JReportCharItem(string chr, int count)
        {
            字符内容 = chr;
            使用次数 = count;
        }
    }
    public class JReportChars : DataBase, IJsonField
    {
        public List<JReportCharItem> 字符明细 { get; set; }

        public JReportChars()
        {
            字符明细 = new List<JReportCharItem>();
        }
    }

    public class ReportWordClassBase: DataBase
    {
        public string 词句分类ID { get; set; }

        public string 上级分类ID { get; set; }
        public string 影像类别 { get; set; }
        public string 分类名称 { get; set; }


    }

    public class JReportWordClassInfo: ReportWordClassBase, IJsonField
    {
        public string 创建人 { get; set; }
        public DateTime 创建日期 { get; set; }
        public string 备注说明 { get; set; }

        public string 适用性别 { get; set; }

        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}

        public void CopyBasePro(ReportWordClassBase classBase)
        {
            base.CopyFrom<ReportWordClassBase>(classBase);
        }
    }

    public class ReportWordInfoBase : DataBase
    {
        public string 词句ID { get; set; }

        public string 词句分类ID { get; set; }
        public string 词句名称 { get; set; }
    }

    public class JReportWordSection
    {
        public string 段落名称 { get; set; }
        public string 段落内容 { get; set; }

        public string 段落格式 { get; set; }

        public JReportWordSection()
        {

        }

        public JReportWordSection(string name, string context)
        {
            段落名称 = name;
            段落内容 = context;
        }

        public JReportWordSection(string name, string context, string formatContext)
        {
            段落名称 = name;
            段落内容 = context;
            段落格式 = formatContext;
        }

        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}

    }

    public enum ReportWordType
    {
        rwtFree = 0,
        rwtStruct = 1,
        rwtModule = 2
    }

    public class JReportWordsInfo: ReportWordInfoBase, IJsonField
    { 
        public string 创建人 { get; set; }
        public DateTime 创建日期 { get; set; }

        public string 备注说明 { get; set; }

        public int 词句类型 { get; set; }

        public List<JReportWordSection> 词句明细 { get; set; }

        public JReportWordsInfo()
        {
            词句明细 = new List<JReportWordSection>();
        } 

        public void CopyBasePro(ReportWordInfoBase wodInfoBase)
        {
            base.CopyFrom<ReportWordInfoBase>(wodInfoBase);
        }
    }
}
