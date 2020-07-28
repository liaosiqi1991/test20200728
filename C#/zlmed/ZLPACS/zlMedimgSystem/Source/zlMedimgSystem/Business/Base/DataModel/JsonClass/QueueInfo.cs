using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.DataModel
{
    public class QueueBase : DataBase
    {
        public string 队列ID { get; set; }
        public string 科室ID { get; set; }
        public string 队列名称 { get; set; }
        
    }

    /// <summary>
    /// 队列规则
    /// </summary>
    public class JQueueInfo: QueueBase, IJsonField
    {
        public string 号码前缀 { get; set; }
        public int 号码长度 { get; set; }
        public string 播放站点 { get; set; }
        public string 呼叫格式 { get; set; }
        public string 备注 { get; set; }
        public DateTime 创建日期 { get; set; }

        public bool 是否禁用 { get; set; }

        public void CopyBasePro(QueueBase queueBase)
        {
            base.CopyFrom<QueueBase>(queueBase);
        }

        public JQueueInfo()
        {
        }
    }

    /// <summary>
    /// 队列房间
    /// </summary>
    public class JQueueRoomItem
    {
        public string 房间ID { get; set; }
        public string 房间名称 { get; set; }
    }

    /// <summary>
    /// 关联房间
    /// </summary>
    public class JQueueReleationRoom: DataBase, IJsonField
    {
        public List<JQueueRoomItem> 房间明细 { get; set; }

        public JQueueReleationRoom()
        {
            房间明细 = new List<JQueueRoomItem>();
        }
    }

    /// <summary>
    /// 排队状态
    /// </summary>
    public enum LineUpState
    {
        /// <summary>
        /// 占位
        /// </summary>
        qsReserve = -1,

        /// <summary>
        /// 排队中
        /// </summary>
        qsQueueing = 0,

        /// <summary>
        /// 待呼叫
        /// </summary>
        qsWaitCall = 1,

        /// <summary>
        /// 呼叫中
        /// </summary>
        qsCalling = 2,

        /// <summary>
        /// 已呼叫
        /// </summary>
        qsCalled = 3,

        /// <summary>
        /// 接诊中
        /// </summary>
        qsRecepting = 4,

        /// <summary>
        /// 已接诊
        /// </summary>
        qsRecepted = 5,

        /// <summary>
        /// 已暂停
        /// </summary>
        qsPaused = 6,

        /// <summary>
        /// 已弃号
        /// </summary>
        qsAbandoned = 7,



    }


    public class LineUpBase : DataBase
    {
        public string 排队ID { get; set; }
        public string 申请ID { get; set; }
        public string 患者ID { get; set; }
        public DateTime 排队日期 { get; set; }

        public string 队列ID { get; set; }
        public string 队列名称 { get; set; }
        public string 科室ID { get; set; }
        public string 科室名称 { get; set; }
        public string 检查房间 { get; set; }
        public string 患者姓名 { get; set; }
        public string 排队号码 { get; set; }
        public string 排队序号 { get; set; }
        public string 号码前缀 { get; set; }
        public LineUpState 排队状态 { get; set; }

    }


    /// <summary>
    /// 排队信息
    /// </summary>
    public class JLineUpInfo : LineUpBase, IJsonField
    {
        public string 性别 { get; set; }
        public string 年龄 { get; set; }
        public string 检查项目 { get; set; }
        public string 备注 { get; set; }         
        public DateTime 首次呼叫时间 { get; set; }
        public DateTime 末次呼叫时间 { get; set; }
        public string 播放站点 { get; set; }
        public DateTime 最后更新日期 { get; set; }

        public void CopyBasePro(LineUpBase lineupBase)
        {
            base.CopyFrom<LineUpBase>(lineupBase);
        }
    }


    public class LineCallBase : DataBase
    {
        public string 呼叫ID { get; set; }
        public string 排队ID { get; set; }
        public string 队列ID { get; set; } 
        public DateTime 生成日期 { get; set; }
        public string 呼叫站点 { get; set; } 
    }

    public class JLineCalInfo: LineCallBase, IJsonField
    {
        public string 原始内容 { get; set; }
        public string 格式内容 { get; set; }

        public void CopyBasePro(LineCallBase lineupBase)
        {
            base.CopyFrom<LineCallBase>(lineupBase);
        }
    }




}
