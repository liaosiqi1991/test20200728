using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
    public class WindowInfoBase: DataBase
    {
        public string 窗体ID { get; set; }
        public string 科室ID { get; set; }
        public string 窗体名称 { get; set; }
        public string 分组标记 { get; set; }
        public int 版本 { get; set; }
    }

    public class JRoleWindowInfo: WindowInfoBase, IJsonField
    {
        public string 窗体描述 { get; set; }
        public DateTime 创建日期 { get; set; }
        public DateTime 最后更新日期 { get; set; }
        public string 布局配置 { get; set; }

        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}

        public void CopyBasePro(WindowInfoBase windowInfoBase)
        {
            base.CopyFrom<WindowInfoBase>(windowInfoBase);
        }
    }
}
