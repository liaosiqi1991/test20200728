using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{

    public class ApplyBase : DataBase
    {
        public string 申请ID { get; set; }

        /// <summary>
        /// DicomUID
        /// </summary>
        public string DcmUID { get; set; }
        public string 患者ID { get; set; }
        public string 执行院区 { get; set; }
        public string 执行科室ID { get; set; }
        public string 检查号 { get; set; }
        public string 就诊卡号 { get; set; }
        public string 门诊号 { get; set; }
        public string 住院号 { get; set; }
        public string 影像类别 { get; set; }

        public string 申请项目ID { get; set; }
        public DateTime 申请日期 { get; set; }
        public DateTime 报到日期 { get; set; }
        public int 申请状态 { get; set; }

        public int 锁定状态 { get; set; }

        /// <summary>
        /// 几个申请直接关联的ID
        /// </summary>
        public string 申请关联ID { get; set; }
        public int 删除标记 { get; set; }

        /// <summary>
        /// 如对应HIS中的医嘱ID
        /// </summary>
        public string 申请识别码 { get; set; }
    }

    public class JOutside
    {
        /// <summary>
        /// 送检单位
        /// </summary>
        public string 送检单位 { get; set; }

        /// <summary>
        /// 送检人
        /// </summary>
        public string 送检人 { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string 联系电话 { get; set; }

        /// <summary>
        /// 送检理由
        /// </summary>
        public string 送检理由 { get; set; }

        /// <summary>
        /// 初步诊断
        /// </summary>
        public string 初步诊断 { get; set; }

        /// <summary>
        /// 其他描述
        /// </summary>
        public string 其他描述 { get; set; }
    }

    /// <summary>
    /// 检查部位
    /// </summary>
    public class JApplyExamBodypart
    {
        /// <summary>
        /// 部位名称
        /// </summary>
        public string 部位名称 { get; set; }

        /// <summary>
        /// 检查方法描述
        /// </summary>
        public string 方法 { get; set; }

        public JApplyExamBodypart()
        {

        }

        public JApplyExamBodypart(string bodypart, string method)
        {
            部位名称 = bodypart;
            方法 = method;
        }
    }

    /// <summary>
    /// 检查项目
    /// </summary>
    public class JApplyExamItem
    {
        public string 项目名称 { get; set; }

        public IList<JApplyExamBodypart> 部位方法 { get; set; }

        public JApplyExamItem()
        {
            部位方法 = new List<JApplyExamBodypart>();
        }

    }

    /// <summary>
    /// 申请锁定项目
    /// </summary>
    public class JApplyLockInfo :DataBase, IJsonField
    { 
        public string 锁定人 { get; set; }
        public DateTime 锁定日期 { get; set; }

        public string 锁定原因 { get; set; } 
    }

 
    public class JApply : ApplyBase, IJsonField
    {       
        /// <summary>
        /// 申请时的姓名
        /// </summary>
        public string 姓名 { get; set; }

        /// <summary>
        /// 申请时的英文名，拼音名
        /// </summary>
        public string 英文名 { get; set; }

        /// <summary>
        /// 申请时的性别
        /// </summary>
        public string 性别 { get; set; }

        /// <summary>
        /// 申请时的年龄
        /// </summary>
        public string 年龄 { get; set; }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string 婚姻状况 { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        public string 身高 { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public string 体重 { get; set; }
        /// <summary>
        /// 主页ID
        /// </summary>
        public string 主页ID { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        public string 床号 { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public int 来源 { get; set; }

        /// <summary>
        /// 申请院区编码
        /// </summary>
        public string 申请院区编码 { get; set; }
        /// <summary>
        /// 申请科室
        /// </summary>
        public string 申请科室 { get; set; }

        /// <summary>
        /// 申请医生
        /// </summary>
        public string 申请医生 { get; set; }

        /// <summary>
        /// 申请内容
        /// </summary>
        public string 申请内容 { get; set; }
        
        /// <summary>
        /// 是否急诊
        /// </summary>
        public bool 是否急诊 { get; set; }

        /// <summary>
        /// 是否危重
        /// </summary>
        public bool 是否危重 { get; set; }

        /// <summary>
        /// 是否绿色通道
        /// </summary>
        public bool 是否绿色通道 { get; set; }

        /// <summary>
        /// 临床诊断
        /// </summary>
        public string 临床诊断 { get; set; }

        /// <summary>
        /// 是否婴儿
        /// </summary>
        public bool 是否婴儿 { get; set; }

        /// <summary>
        /// 医生嘱托
        /// </summary>
        public string 医生嘱托 { get; set; }
       
        /// <summary>
        /// 是否允许查看报告
        /// </summary>
        public bool 是否允许查看报告 { get; set; }

        /// <summary>
        /// 是否传染病
        /// </summary>
        public bool 是否传染病 { get; set; }

        /// <summary>
        /// 附加内容
        /// </summary>
        public string 附加内容 { get; set; }

        /// <summary>
        /// 送检信息
        /// </summary>
        public JOutside 送检信息 { get; set; }

        public JApplyExamItem 检查项目 { get; set; }

        public JApply()
        {
            送检信息 = new JOutside();
            检查项目 = new JApplyExamItem();
        }

        public void CopyBasePro(ApplyBase aplyBase)
        {
            base.CopyFrom<ApplyBase>(aplyBase);
        }
        
    }

}
