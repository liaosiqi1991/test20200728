using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Pedal
{

    public enum SerialTouchWay
    {
        /// <summary>
        /// 直接触发
        /// </summary>
        stwDirect,

        /// <summary>
        /// 持续触发
        /// </summary>
        stwKeep,

        /// <summary>
        /// 信号量触发
        /// </summary>
        stwSemaphore

    }

    public class PedalConfig
    {

        /// <summary>
        /// 脚踏设备名称
        /// </summary>
        public string PealDeviceName { get; set; }

        /// <summary>
        /// 触发方式
        /// </summary>
        public SerialTouchWay TouchWay { get; set; }

        /// <summary>
        /// 触发间隔
        /// </summary>
        public int TouchInterval { get; set; }

        /// <summary>
        /// 信号数量
        /// </summary>
        public int SignCount { get; set; }

        public PedalConfig()
        {

        }

        public void CopyFrom(PedalConfig sourcePar)
        {
            this.PealDeviceName = sourcePar.PealDeviceName;
            this.SignCount = sourcePar.SignCount;
            this.TouchInterval = sourcePar.TouchInterval;
            this.TouchWay = sourcePar.TouchWay;
        }

        static public PedalConfig GetConfig()
        {
            PedalConfig cc = new PedalConfig();
             
            try
            {
                cc.PealDeviceName = AppSetting.ReadSetting("PealDeviceName");
                cc.TouchWay = (SerialTouchWay)Enum.Parse(typeof(SerialTouchWay), AppSetting.ReadSetting("TouchWay", SerialTouchWay.stwDirect.ToString()));
                cc.TouchInterval = AppSetting.ReadInt("TouchInterval");
                cc.SignCount = AppSetting.ReadInt("SignCount");

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);
            }

            return cc;
        }

        static public void SetConfig(PedalConfig cc)
        {
            AppSetting.BatchBegin();
            try
            {
                AppSetting.WriteSetting("PealDeviceName", cc.PealDeviceName);
                AppSetting.WriteSetting("TouchWay", cc.TouchWay.ToString());
                AppSetting.WriteInt("TouchInterval", cc.TouchInterval);
                AppSetting.WriteInt("SignCount", cc.SignCount);

                AppSetting.BatchCommit();
            }
            catch(Exception ex)
            {
                AppSetting.BatchCancel();

                MsgBox.ShowException(ex);
            }
  
        }
    }
}
