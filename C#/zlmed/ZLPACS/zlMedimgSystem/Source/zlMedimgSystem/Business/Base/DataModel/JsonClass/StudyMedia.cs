using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.DataModel
{
    public class StudySerialBase: DataBase
    {
        public string 序列ID { get; set; }

        /// <summary>
        /// DicomUID
        /// </summary>
        public string DcmUID { get; set; }
        public string 申请ID { get; set; }
        public string 存储ID { get; set; }
        public string 房间ID { get; set; }
        public string 设备ID { get; set; }
        public int 序号 { get; set; }
        public int 删除标记 { get; set; } 
    }

    public class JStudySerialInfo: StudySerialBase, IJsonField 
    {
        public DateTime 创建日期 { get; set; } 
        public string 序列描述 { get; set; }
        public string 创建人 { get; set; }

        public DateTime 申请日期 { get; set; }

        public void CopyBasePro(StudySerialBase serialBase)
        {
            base.CopyFrom<StudySerialBase>(serialBase);
        }
    }



    public class StudyMediaBase: DataBase 
    {
        public string 媒体ID { get; set; }

        /// <summary>
        /// DicomUID
        /// </summary>
        public string DcmUID { get; set; }

        public string 序列ID { get; set; }
        public string 申请ID { get; set; }

        public int 序号 { get; set; }
        public bool 删除标记 { get; set; }
    }
     
    public class JStudyMediaInfo: StudyMediaBase, IJsonField
    {  
        public string 创建人 { get; set; }
        public DateTime 创建日期 { get; set; }
        public bool 是否报告图 { get; set; }
        public bool 是否关键图 { get; set; }

        public string 媒体名称 { get; set; }
        public string 媒体描述 { get; set; }
         
        public string 媒体类型 { get; set; }

        //只有处理过的图像才包含来源媒体和版本等信息
        public string 来源媒体ID { get; set; }
        public string 最后处理人 { get; set; }
        public DateTime 最后处理时间 { get; set; }
        public int 最后版本 { get; set; }

        public void CopyBasePro(StudyMediaBase mediaBase)
        {
            base.CopyFrom<StudyMediaBase>(mediaBase);
        }

    }
}
