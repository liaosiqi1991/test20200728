using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.QueueVoice
{
    static public class GlobalProcess
    {
        /// <summary>
        /// 是否已经启动语音
        /// </summary>
        static public bool IsStartedVoice { get; set; }

        /// <summary>
        /// 启动模块描述
        /// </summary>
        static public string StartModuleDescription { get; set; }
    }
}
