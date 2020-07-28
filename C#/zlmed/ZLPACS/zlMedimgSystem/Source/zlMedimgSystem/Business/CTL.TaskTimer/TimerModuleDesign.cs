using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.TaskTimer
{

    public enum TimerRepeatType
    {
        /// <summary>
        /// 分
        /// </summary>
        trtMinute = 0,

        /// <summary>
        /// 时
        /// </summary>
        trtHour = 1,

        /// <summary>
        /// 天
        /// </summary>
        trtDay = 2,

        /// <summary>
        /// 周
        /// </summary>
        trtWeek = 3,

        /// <summary>
        /// 月
        /// </summary>
        trtMonth = 4
    }

    public class TimerItem
    {
        /// <summary>
        /// 启用状态
        /// </summary>
        public bool UseState{ get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 重复周期
        /// </summary>
        public int RepeatPeriod { get; set; }

        /// <summary>
        /// 重复类型
        /// </summary>
        public TimerRepeatType RepeatType { get; set; }
    }

    public class TimerModuleDesign
    {
        /// <summary>
        /// 执行间隔
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// 定时器1
        /// </summary>
        public TimerItem Timing1 { get; set; }

        /// <summary>
        /// 定时器2
        /// </summary>
        public TimerItem Timing2 { get; set; }

        /// <summary>
        /// 定时器3
        /// </summary>
        public TimerItem Timing3 { get; set; }

        /// <summary>
        /// 定时器4
        /// </summary>
        public TimerItem Timing4 { get; set; }

        /// <summary>
        /// 定时器5
        /// </summary>
        public TimerItem Timing5 { get; set; }

        public TimerModuleDesign()
        {
            Timing1 = new TimerItem();
            Timing2 = new TimerItem();
            Timing3 = new TimerItem();
            Timing4 = new TimerItem();
            Timing5 = new TimerItem();
        }
    }
}
