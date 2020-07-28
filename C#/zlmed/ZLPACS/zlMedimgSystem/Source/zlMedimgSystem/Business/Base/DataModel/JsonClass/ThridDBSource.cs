using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.DataModel
{
    public class ThridDBSourceBase: DataBase
    {
        public string 数据源ID { get; set; }
        public string 数据源别名 { get; set; } 
    }

    public class JThridDbSourceInfo : ThridDBSourceBase, IJsonField
    {  
        public string 服务器类型 { get; set; }

        public string 驱动文件 { get; set; }

        public string 服务器IP { get; set; }

        public int 端口 { get; set; }

        public string 数据实例 { get; set; }

        public string 授权账号 { get; set; }

        public string 授权密码 { get; set; }

        public string 备注描述 { get; set; }

        public void CopyBasePro(ThridDBSourceBase dbSource)
        {
            base.CopyFrom<ThridDBSourceBase>(dbSource);
        }

    }
}
