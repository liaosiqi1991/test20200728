using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.DataModel
{
    public interface IStudyBizData
    {
        /// <summary>
        /// 检查ID
        /// </summary>
        int StudyId
        {
            get;
            set;
        }

        int PatientId
        {
            get;
            set;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 性别
        /// </summary>
        string Sex
        {
            get;
            set;
        }

        /// <summary>
        /// 检查号
        /// </summary>
        string StudyNo
        {
            get;
            set;
        }

        /// <summary>
        /// 住院号
        /// </summary>
        string InHospitalNo
        {
            get;
            set;
        }

        /// <summary>
        /// 门诊号
        /// </summary>
        string OutHospitalNo
        {
            get;
            set;
        }

        

        /// <summary>
        /// 项目内容
        /// </summary>
        string ItemContext
        {
            get;
            set;
        }


        /// <summary>
        /// 格式化接受日期
        /// </summary>
        string FmtRecDate
        {
            get;
            set;
        }


        /// <summary>
        /// 信息对象Jobject类
        /// </summary>
        object JSonInfos
        {
            get;
            set;
        }

    }
}
