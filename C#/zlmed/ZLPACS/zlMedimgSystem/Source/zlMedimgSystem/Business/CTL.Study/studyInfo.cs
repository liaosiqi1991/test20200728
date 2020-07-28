using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.Study
{
    public class StudyInfo
    {
        public long ID { get; set; }
        public long 患者ID { get; set; }
        public string 就诊ID { get; set; }
        public string 姓名 { get; set; }
        public string 性别 { get; set; }
        public string 年龄 { get; set; }
        public string 身高 { get; set; }
        public string 体重 { get; set; }
        public string 患者来源 { get; set; }

        public string 住院号 { get; set; }
        public string 门诊号 { get; set; }
        public string 检查号 { get; set; }
        public string 影像类别 { get; set; }

        public long   执行科室ID { get; set; }
        public string 执行科室 { get; set; }
        public string 检查设备 { get; set; }
        public string 符合情况 { get; set; }
        public DateTime 报到时间 { get; set; }

        public string 登记人 { get; set; }
        public string 报到人 { get; set; }
        public string 完成人 { get; set; }

        public string 绿色通道 { get; set; }
        public long   检查项目ID { get; set; }
        public long   主页ID { get; set; }
        public string 项目摘要 { get; set; }
        public string 患者科室 { get; set; }
        public DateTime 出生日期 { get; set; }
        public string 身份证号 { get; set; }
        public string 联系人电话 { get; set; }
        public List<PartAndMethod> 部位方法 { get ; set; }
    }

    public class PartAndMethod
    {
        public string 部位 { get; set; }
        public string 检查方法 { get; set; }
    }

}
