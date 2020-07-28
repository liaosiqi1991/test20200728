using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.DataModel
{

    public enum StudyExecuteState
    {
        /// <summary>
        /// 等待执行
        /// </summary>
        sesWaiting = 0,

        /// <summary>
        /// 正在执行
        /// </summary>
        sesDoing = 1,

        /// <summary>
        /// 完全执行
        /// </summary>
        sesDone = 2,

        /// <summary>
        /// 取消执行
        /// </summary>
        sesCancel = 3

    }
    public class StudyExecuteBase:DataBase
    {
        public string 执行ID { get; set; }

        public string 申请ID { get; set; }

        public string 部位序号 { get; set; }

        public string 部位名称 { get; set; }

        public string 房间ID { get; set; }

        public string 设备ID { get; set; }

        public StudyExecuteState 执行状态 { get; set; }

        public int 删除标记 { get; set; }
    }

    public class JStudyExecute : StudyExecuteBase, IJsonField
    {
        public DateTime 报到时间 { get; set; }

        public string 报到人 { get; set; }

        public string 执行人 { get; set; }

        public DateTime 首次执行时间 { get; set; }

        public string 辅助技师 { get; set; }

        public string 检查方法 { get; set; } 
        public void CopyBasePro(StudyExecuteBase studyExecuteBase)
        {
            base.CopyFrom<StudyExecuteBase>(studyExecuteBase);
        }

    }
}
