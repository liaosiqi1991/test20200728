using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
    public class BodypartBase:DataBase
    {
        public string 部位ID { get; set; }
        public string 影像类别 { get; set; }
        public string 部位名称 { get; set; }
        public string 分组标记 { get; set; }
    }

    /// <summary>
    /// 部位方法
    /// </summary>
    public class JBodypartWay
    {
        public string 方法名称 { get; set; }
        public IList<string> 附加方法 { get; set; }

        public JBodypartWay()
        {
            附加方法 = new List<string>();
        }

        public JBodypartWay(string name)
        {
            方法名称 = name;
            附加方法 = new List<string>();
        }

        public JBodypartWay Clone()
        {
            JBodypartWay obj = new JBodypartWay();

            obj.方法名称 = this.方法名称;

            foreach(string attach in 附加方法)
            {
                obj.附加方法.Add(attach);
            }

            return obj;
        }
    }

    public class JBodypartInfo: BodypartBase, IJsonField
    {
        public string 适用性别 { get; set; }
        public string 备注描述 { get; set; }
        public DateTime 创建日期 { get; set; }

        public IList<JBodypartWay> 互斥方法 { get; set; }
        public IList<JBodypartWay> 共用方法 { get; set; }

        public JBodypartInfo()
        {
            互斥方法 = new List<JBodypartWay>();
            共用方法 = new List<JBodypartWay>();
        }


        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}

        public void CopyBasePro(BodypartBase bodypartBase)
        {
            base.CopyFrom<BodypartBase>(bodypartBase);
        }

    }
}
