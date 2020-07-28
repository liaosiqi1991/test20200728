using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
    public class JStationConfig: DataBase, IJsonField
    {
        public string 当前院区编码 { get; set; }
        public string 站点所属科室 { get; set; }
        public string 站点所属房间 { get; set; }
        public string 当前检查设备 { get; set; }
        public string 当前存储设备 { get; set; }

        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}
    }
}
