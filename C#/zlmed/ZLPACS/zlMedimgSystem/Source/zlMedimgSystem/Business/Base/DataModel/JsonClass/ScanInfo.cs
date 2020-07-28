using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
    public class ScanBase:DataBase
    {
        public string 扫描ID { get; set; }

        public string 申请ID { get; set; }

        public int 删除标记 { get; set; }
    }


    public class JScan :ScanBase, IJsonField
    {      
        /// <summary>
        /// 存储ID
        /// </summary>
        public string 存储ID { get; set; }

        /// <summary>
        /// 冗余存储 申请日期，“//申请日期//申请ID//”构成扫描文件的存储路径
        /// </summary>
        public DateTime 申请日期 { get; set; }

        /// <summary>
        /// 扫描文件名
        /// </summary>
        public string 文件名 { get; set; }

        /// <summary>
        /// 扫描人
        /// </summary>
        public string 扫描人 { get; set; }

        /// <summary>
        /// 扫描时间
        /// </summary>
        public DateTime 扫描时间 { get; set; }              

        public void CopyBasePro(ScanBase scanBase)
        {
            base.CopyFrom<ScanBase>(scanBase);
        }
    }

    
}