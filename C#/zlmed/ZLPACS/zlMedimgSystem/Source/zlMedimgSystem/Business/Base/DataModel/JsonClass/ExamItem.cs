using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
    /// <summary>
    /// 检查分类行基础数据
    /// </summary>
    public class ExamClassBase:DataBase 
    {
        public string 项目分类ID { get; set; }
        public string 上级分类ID { get; set; }
        public string 影像类别 { get; set; }
        public string 分类名称 { get; set; }
    }

    /// <summary>
    /// JSON数据，项目分类信息
    /// </summary>
    public class JExamClassInfo: ExamClassBase, IJsonField
    {
        public string 分类描述 { get; set; }
        public DateTime 创建日期 { get; set; }

        public string 适用性别 { get; set; }

        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}

        public void CopyBasePro(ExamClassBase examClassBase)
        {
            base.CopyFrom<ExamClassBase>(examClassBase); 
        }

    }

    public class ExamItemBase: DataBase
    {
        public string 项目ID { get; set; }
        public string 项目分类ID { get; set; }
        public string 项目名称 { get; set; }
    }

    public class JExamBodypartWaySetting
    {
        public string 方法名称 { get; set; }
        public IList<string> 附加方法 { get; set; }

        public JExamBodypartWaySetting()
        {
            附加方法 = new List<string>();
        }

        public JExamBodypartWaySetting(string bodypartWay)
        {
            方法名称 = bodypartWay;
            附加方法 = new List<string>();
        }
    }

    public class JExamBodypartSetting
    {
        public string 部位ID { get; set; }

        public string 部位名称 { get; set; }
        public bool 默认选择 { get; set; }

        public IList<JExamBodypartWaySetting> 默认方法 { get; set; }


        public JExamBodypartSetting()
        {
            默认方法 = new List<JExamBodypartWaySetting>();
        }

        public JExamBodypartSetting(string bodypartId, string bodypartName)
        {
            部位ID = bodypartId;
            部位名称 = bodypartName;
            默认方法 = new List<JExamBodypartWaySetting>();
        }
    }

    /// <summary>
    /// 项目信息
    /// </summary>
    public class JExamItemInfo: ExamItemBase, IJsonField
    {
        public string 诊疗分类 { get; set; }
        public string 对照编码 { get; set; }

        //public string 适用性别 { get; set; }
        public string 注意事项 { get; set; }
        public string 参考说明 { get; set; }
        public string 项目备注 { get; set; }
        public DateTime 创建日期 { get; set; }

        public IList<JExamBodypartSetting> 可选部位 { get; set; }

        public JExamItemInfo()
        {
            可选部位 = new List<JExamBodypartSetting>();
        }


        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}


        public void CopyBasePro(ExamItemBase examItemBase)
        {
            base.CopyFrom<ExamItemBase>(examItemBase); 
        }
    }

    public class JExamBindExpense : IJsonField
    {
        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}
    }
}
