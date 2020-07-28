using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.Capture
{

    public enum MediaType
    {
        /// <summary>
        /// 图像
        /// </summary>
        图像,

        /// <summary>
        /// 视频
        /// </summary>
        视频,

        /// <summary>
        /// 音频
        /// </summary>
        音频


    }

    public class MediaData
    {
        public MediaType MediaType { get; set; }

        public string MediaFile { get; set; }

        public string MediaId { get; set; }
        public string SerialId { get; set; }

        public string Order { get; set; }

        public Bitmap Bmp { get; set; }

    }
}
