using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.QueueVoice
{
    public class QueueVoiceModuleDesign
    {
        /// <summary>
        /// 播放次数
        /// </summary>
        public int PlayCount { get; set; }
        /// <summary>
        /// 语音名称
        /// </summary>
        public string VoiceName { get; set; }
        /// <summary>
        /// 播放语速
        /// </summary>
        public int PlayRate { get; set; }

        /// <summary>
        /// 轮询间隔
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// 播放提示音
        /// </summary>
        public bool PlayHintSound { get; set; }
    }
}
