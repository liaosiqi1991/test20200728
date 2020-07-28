using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.DataModel
{
    public class StudyImplBase:DataBase
    {
        public string 执行ID { get; set; }
        public string 申请ID { get; set; }
        public string 部位序号 { get; set; }
        public string 部位名称 { get; set; }
        public string 房间ID { get; set; }
        public string 设备ID { get; set; }
        public bool 删除标记 { get; set; }
    }

    public class JStudyImplInfo : StudyImplBase, IJsonField
    {
        public DateTime 报道时间 { get; set; }
        public string 报道人 { get; set; }
        public DateTime 执行时间 { get; set; }
        public string 执行人 { get; set; }
        public string 辅助人 { get; set; }
        public string 检查方法 { get; set; }
        public bool 是否执行 { get; set; }

        public void CopyBasePro(StudyImplBase implBase)
        {
            base.CopyFrom<StudyImplBase>(implBase);
        }
    }

}
