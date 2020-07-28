using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{

    public class HisServerBase: DataBase
    {
        public string HIS服务ID { get; set; }
        public string 服务名称 { get; set; }
    }

    /// <summary>
    /// HIS服务配置
    /// </summary>
    public class JHisServerCfg : HisServerBase, IJsonField
    {
        public string HIS接口名称 { get; set; }
        public string HIS接口文件 { get; set; }
        public bool 是否停用 { get; set; }
        public string 接口配置 { get; set; }


        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}

        public void CopyBasePro(HisServerBase serverBase)
        {
            base.CopyFrom<HisServerBase>(serverBase);
        }

    }
}
