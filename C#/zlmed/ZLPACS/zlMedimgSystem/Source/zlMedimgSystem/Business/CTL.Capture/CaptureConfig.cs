using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using AForge.Video.FFMPEG; 
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Capture
{
    public class CaptureConfig
    {
        /// <summary>
        /// 视频设备名称
        /// </summary>
        public string VideoDeviceName { get; set; }

        /// <summary>
        /// 分辨率索引
        /// </summary>
        public int ResolutionIndex { get; set; }

        /// <summary>
        /// 输入端口
        /// </summary>
        public int InputPort { get; set; }

        /// <summary>
        /// 视频编码
        /// </summary>
        public VideoCodec VideoEncode { get; set; }


        /// <summary>
        /// 声音提示
        /// </summary>
        public bool SoundHint { get; set; }

        /// <summary>
        /// 弹窗提示
        /// </summary>
        public bool PopupHint { get; set; }
        
        /// <summary>
        /// 默认贞率
        /// </summary>
        public int FrameRate { get; set; }

        /// <summary>
        /// 录制日期
        /// </summary>
        public bool RecordDate { get; set; }

        static public CaptureConfig GetConfig(string sectionName)
        {
            CaptureConfig cc = new CaptureConfig();
            
            try
            {

                SettingItem imageSetting = AppSettingHelper.GetSpecifySection(sectionName);

                cc.VideoDeviceName = imageSetting.ReadSetting("VideoDeviceName");
                cc.ResolutionIndex = imageSetting.ReadInt("ResolutionIndex");
                cc.InputPort = imageSetting.ReadInt("InputPort");
                cc.VideoEncode = (VideoCodec)Enum.Parse(typeof(VideoCodec), imageSetting.ReadSetting("VideoEncode", VideoCodec.MPEG4.ToString()));

                cc.SoundHint = imageSetting.ReadBool("SoundHint");
                cc.PopupHint = imageSetting.ReadBool("PopupHint");
                cc.FrameRate = imageSetting.ReadInt("FrameRate");
                cc.RecordDate = imageSetting.ReadBool("RecordDate");

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);
            }

            return cc;
        }

        static public void SetConfig(CaptureConfig cc, string sectionName)
        {
            SettingItem imageSetting = AppSettingHelper.GetSpecifySection(sectionName);

            imageSetting.BatchBegin();
            try
            {
                imageSetting.WriteSetting("VideoDeviceName", cc.VideoDeviceName);
                imageSetting.WriteInt("ResolutionIndex", cc.ResolutionIndex);
                imageSetting.WriteInt("InputPort", cc.InputPort);
                imageSetting.WriteSetting("VideoEncode", cc.VideoEncode.ToString());

                imageSetting.WriteBool("SoundHint", cc.SoundHint);
                imageSetting.WriteBool("PopupHint", cc.PopupHint);
                imageSetting.WriteInt("FrameRate", cc.FrameRate);
                imageSetting.WriteBool("RecordDate", cc.RecordDate);

                imageSetting.BatchCommit();
            }
            catch(Exception ex)
            {
                imageSetting.BatchCancel();
                MsgBox.ShowException(ex);
            }
 
        }

    }
}
