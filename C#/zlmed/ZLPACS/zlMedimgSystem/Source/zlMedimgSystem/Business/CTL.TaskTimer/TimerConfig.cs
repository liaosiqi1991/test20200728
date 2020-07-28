using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.TaskTimer
{
    public class TimerConfig
    {
        public DateTime LastTime1 { get; set; }
        public DateTime LastTime2 { get; set; }
        public DateTime LastTime3 { get; set; }
        public DateTime LastTime4 { get; set; }
        public DateTime LastTime5 { get; set; }

        public void CopyFrom(TimerConfig sourcePar)
        {
            this.LastTime1 = sourcePar.LastTime1;
            this.LastTime2 = sourcePar.LastTime2;
            this.LastTime3 = sourcePar.LastTime3;
            this.LastTime4 = sourcePar.LastTime4;
            this.LastTime5 = sourcePar.LastTime5;
        }

        static public TimerConfig GetConfig(string sectionName)
        {
            TimerConfig tc = new TimerConfig();

            try
            {
                SettingItem timerSetting = AppSettingHelper.GetSpecifySection(sectionName);

                tc.LastTime1 = timerSetting.ReadDatetime("LastTime1");
                tc.LastTime1 = timerSetting.ReadDatetime("LastTime2"); 
                tc.LastTime1 = timerSetting.ReadDatetime("LastTime3"); 
                tc.LastTime1 = timerSetting.ReadDatetime("LastTime4"); 
                tc.LastTime5 = timerSetting.ReadDatetime("LastTime5");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);
            }

            return tc;
        }

        static public void SetConfig(TimerConfig tc, string sectionName)
        {
            SettingItem timerSetting = AppSettingHelper.GetSpecifySection(sectionName);

            timerSetting.BatchBegin();
            try
            {
                timerSetting.WriteDateTime("LastTime1", tc.LastTime1);
                timerSetting.WriteDateTime("LastTime2", tc.LastTime2);
                timerSetting.WriteDateTime("LastTime3", tc.LastTime3);
                timerSetting.WriteDateTime("LastTime4", tc.LastTime4);
                timerSetting.WriteDateTime("LastTime5", tc.LastTime5);

                timerSetting.BatchCommit();
            }
            catch (Exception ex)
            {
                timerSetting.BatchCancel();

                MsgBox.ShowException(ex);
            }

        }
    }
}
