using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
    /// <summary>
    /// 模板分类相关定义
    /// </summary>
    public class ReportTemplateClassBase : DataBase
    {
        public string 模板分类ID { get; set; }

        public string 上级分类ID { get; set; }
        public string 影像类别 { get; set; }
        public string 分类名称 { get; set; }
    }

    public class JReportTemplateClassInfo : ReportTemplateClassBase, IJsonField
    {
        public string 创建人 { get; set; }
        public DateTime 创建日期 { get; set; }
        public string 备注说明 { get; set; }

        public void CopyBasePro(ReportTemplateClassBase classBase)
        {
            base.CopyFrom<ReportTemplateClassBase>(classBase);
        }
    }

    public class ReportTemplateWordBase: DataBase
    {
        public string 关联ID { get; set; }
        public string 模板ID { get; set; }
        public string 格式ID { get; set; }
        public string 词句分类ID { get; set; }
    }

    /// <summary>
    /// 模板信息相关定义
    /// </summary>
    public class ReportTemplateItemBase : DataBase
    {
        public string 模板ID { get; set; }

        public string 模板分类ID { get; set; }
        public string 模板名称 { get; set; }
        public int 版本 { get; set; }
    }

    /// <summary>
    /// 模板信息
    /// </summary>
    public class JReportTemplateItemInfo : ReportTemplateItemBase, IJsonField
    {
        public string 创建人 { get; set; }
        public DateTime 创建日期 { get; set; }
        public string 备注说明 { get; set; }

        public string 模板内容 { get; set; }

        public void CopyBasePro(ReportTemplateItemBase itemBase)
        {
            base.CopyFrom<ReportTemplateItemBase>(itemBase);
        }
    }
 

    /// <summary>
    /// 模板查询语句
    /// </summary>
    public class JReportTemplateQuery
    {
        public string 查询ID { get; set; }
        public string 数据源别名 { get; set; }

        public string 查询名称 { get; set; }

        public string 查询内容 { get; set; }

    }

    /// <summary>
    /// 模板数据源
    /// </summary>
    public class JReportTemplateDataInfo : ReportTemplateItemBase, IJsonField
    {

        public string 创建人 { get; set; }
        public DateTime 创建日期 { get; set; }
        public string 备注说明 { get; set; }

        public List<JReportTemplateQuery> 查询信息 { get; set; }

        public JReportTemplateDataInfo()
        {
            查询信息 = new List<JReportTemplateQuery>();
        }

        public void CopyBasePro(ReportTemplateItemBase itemBase)
        {
            base.CopyFrom<ReportTemplateItemBase>(itemBase);
        }
    }

    ///// <summary>
    ///// 模板对应词句
    ///// </summary>
    //public class JReportTemplateWords : ReportTemplateItemBase, IJsonField
    //{


    //    public List<string> 词句分类ID信息 { get; set; }

    //    public JReportTemplateWords()
    //    {
    //        词句分类ID信息 = new List<string>();
    //    }

    //    public void CopyBasePro(ReportTemplateItemBase itemBase)
    //    {
    //        base.CopyFrom<ReportTemplateItemBase>(itemBase);
    //    }

    //}

    public class JReportSectionItem
    {
        /// <summary>
        /// 段落名称
        /// </summary>
        public string 报告段落名 { get; set; }

        /// <summary>
        /// 段落对应的显示名称
        /// </summary>
        public string 段落显示名 { get; set; }

        /// <summary>
        /// 报告设计时的元素名称
        /// </summary>
        public string 模板元素名 { get; set; }

        /// <summary>
        /// 同步存储到表的字段中
        /// </summary>
        public bool 关联存储 { get; set; }

        public JReportSectionItem()
        {

        }

        public JReportSectionItem(string secName, string elementName)
        {
            报告段落名 = secName;
            模板元素名 = elementName;
        }
    }

    public class JReportTemplateSection : ReportTemplateItemBase, IJsonField
    {
        public List<JReportSectionItem> 段落关联信息 { get; set; }

        public JReportTemplateSection()
        {
            段落关联信息 = new List<JReportSectionItem>();
        }

        public void CopyBasePro(ReportTemplateItemBase itemBase)
        {
            base.CopyFrom<ReportTemplateItemBase>(itemBase);
        }
    }

    /// <summary>
    /// 模板格式
    /// </summary>
    public class ReportTemplateFormtBase : DataBase
    {
        public string 格式ID { get; set; }
        public string 模板ID { get; set; }
        public string 格式名称 { get; set; }
        public int 版本 { get; set; }

    }

    /// <summary>
    /// 模板格式信息
    /// </summary>
    public class JReportTemplateFormatInfo : ReportTemplateFormtBase, IJsonField
    {
        public string 创建人 { get; set; }
        public DateTime 创建日期 { get; set; }
        public string 备注说明 { get; set; }

        public string 适用性别 { get; set; }
        public string 适用部位 { get; set; }
        public string 患者来源 { get; set; }

        public string 格式内容 { get; set; }

        public void CopyBasePro(ReportTemplateFormtBase formatBase)
        {
            base.CopyFrom<ReportTemplateFormtBase>(formatBase);
        }
    }


}
