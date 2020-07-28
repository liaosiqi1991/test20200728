using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.QueueManager
{
    public class QueueConfig
    {
        public string DefaultQueueName { get; set; }

        public QueueConfig()
        {

        }

        public void CopyFrom(QueueConfig sourcePar)
        {
            this.DefaultQueueName = sourcePar.DefaultQueueName; 
        }

        static public QueueConfig GetConfig(string sectionName)
        {
            QueueConfig qc = new QueueConfig();

            try
            {
                SettingItem queueSetting = AppSettingHelper.GetSpecifySection(sectionName);

                qc.DefaultQueueName = queueSetting.ReadSetting("DefaultQueueName"); 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);
            }

            return qc;
        }

        static public void SetConfig(QueueConfig qc, string sectionName)
        {
            AppSetting.BatchBegin();
            try
            {
                SettingItem queueSetting = AppSettingHelper.GetSpecifySection(sectionName);

                queueSetting.WriteSetting("DefaultQueueName", qc.DefaultQueueName); 

                AppSetting.BatchCommit();
            }
            catch (Exception ex)
            {
                AppSetting.BatchCancel();

                MsgBox.ShowException(ex);
            }

        }
    }
}
