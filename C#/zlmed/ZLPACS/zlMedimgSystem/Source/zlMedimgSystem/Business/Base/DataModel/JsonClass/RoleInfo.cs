using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{

    public class RoleBase: DataBase
    {
        public string 角色ID { get; set; }
        public string 科室ID { get; set; }

        public string 窗体ID { get; set; }
        public string 角色名称 { get; set; }
        public string 分组标记 { get; set; }

    }

    public class JRoleInfo : RoleBase, IJsonField
    {
        public string 角色描述 { get; set; }

        public DateTime 创建日期 { get; set; }

        public bool 是否停用 { get; set; }

        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}

        public void CopyBasePro(RoleBase roleBase)
        {
            base.CopyFrom<RoleBase>(roleBase);
        }
    }
}
