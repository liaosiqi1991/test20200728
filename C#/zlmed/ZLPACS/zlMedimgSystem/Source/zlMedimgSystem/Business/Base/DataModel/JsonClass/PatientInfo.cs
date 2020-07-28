using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{

    public class PatientBase: DataBase
    {
        public string 患者ID { get; set; }
        public string 姓名 { get; set; }
        public string 患者关联ID { get; set; }
        public int 删除标记 { get; set; }
        public string 身份证号 { get; set; }
        public string 患者识别码 { get; set; }
    }

    public class JContact
    {
        public string 联系人 { get; set; }
        public string 电话 { get; set; }
        public string 地址 { get; set; }
        public string 邮编 { get; set; }
    }

    public class JPatient: PatientBase,IJsonField
    {        

        /// <summary>
        /// 证件类型
        /// </summary>
        public string 证件类型 { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string 证件号码 { get; set; }

        /// <summary>
        /// 患者性别
        /// </summary>
        public string 性别 { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string 出生日期 { get; set; }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string 婚姻状况 { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        public string 籍贯 { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string 国家 { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public string 民族 { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        public string 职业 { get; set; }

        /// <summary>
        /// 监护人
        /// </summary>
        public string 监护人 { get; set; }

        /// <summary>
        /// 常用联系方式
        /// </summary>
        public JContact OftenContact { get; set; } 

        /// <summary>
        /// 备用联系方式
        /// </summary>
        public JContact BakContact { get; set; } 


        public JPatient()
        {
            OftenContact = new JContact();
            BakContact = new JContact();
        }        

        public void CopyBasePro(PatientBase patientBase)
        {
            base.CopyFrom<PatientBase>(patientBase);
        }
    }
}
