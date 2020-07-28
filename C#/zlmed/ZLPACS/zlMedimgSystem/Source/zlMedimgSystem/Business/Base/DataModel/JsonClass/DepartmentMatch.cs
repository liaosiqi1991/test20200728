using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{

    public class DepartmentMatchBase:DataBase
    {
        public string 科室对照ID { get; set; }
        public string 对照来源 { get; set; }
        public string 对照编码 { get; set; }
        public string 科室ID { get; set; }
    }
    public class DepartmentInfoBase: DataBase
    {
        public string 科室ID { get; set; }
        public string 科室名称 { get; set; }
        //public string 对照编码 { get; set; }
    }


    public class JDepartmentAttachInfo : DepartmentInfoBase, IJsonField
    {
        public string 备注 { get; set; }

        public string 其他 { get; set; }

        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}

        public void CopyBasePro(DepartmentInfoBase departmentInfoBase)
        {
            base.CopyFrom<DepartmentInfoBase>(departmentInfoBase);
        }

    }
}
