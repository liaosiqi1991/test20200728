using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{

    public enum NoType
    {
        /// <summary>
        /// 医嘱号
        /// </summary>
        fiAdviceNo,
        /// <summary>
        /// 患者号
        /// </summary>
        fiPatientNo,
        /// <summary>
        /// 住院号
        /// </summary>
        fiInHspNo,
        /// <summary>
        /// 门诊号
        /// </summary>
        fiOutHspNo,
        /// <summary>
        /// 就诊卡号
        /// </summary>
        fiCardNo,
        /// <summary>
        /// 社保号
        /// </summary>
        fiInsureNo,
        /// <summary>
        /// 自定义
        /// </summary>
        fiCustom


    }

    /// <summary>
    /// 号码前缀生成方式
    /// </summary>
    public enum NoPrefixWay
    {
        /// <summary>
        /// 影像类别编码
        /// </summary>
        noImageKindCode,
        /// <summary>
        /// 固定文本前缀
        /// </summary>
        noFixText,
        /// <summary>
        /// 不使用前缀
        /// </summary>
        noNone

    }

    /// <summary>
    /// 号码识别方式
    /// </summary>
    public enum NoIdentWay
    {
        /// <summary>
        /// 科室方式
        /// </summary>
        niwDepartment,
        /// <summary>
        /// 影像类别方式
        /// </summary>
        niwImageKind
    }


    /// <summary>
    /// 号码规则
    /// </summary>
    public class JNoRuleInfo:DataBase, IJsonField
    {
        public NoType 检查号类型 { get; set; }

        public NoPrefixWay 前缀方式 { get; set; }
        public string 前缀文本 { get; set; }

        public string 前缀分隔符 { get; set; }//为空表示无分割

        public string 年份格式 { get; set; }    //为空表示不使用

        public bool 使用月份 { get; set; }
        public bool 使用天数 { get; set; }
        public string 日期分隔符 { get; set; }//为空表示无分割

        public int 序号长度 { get; set; }

        public NoIdentWay 号码识别方式 { get; set; }

        public bool 号码保持统一 { get; set; }

        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}
    }
}
