using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.QueueShow
{
    public class QueueItem
    {
        public string QueueId { get; set; }
        public string QueueName { get; set; }
    }

    public class QueueShowConfig
    {
        public List<QueueItem> QueueNames { get; set; }


        public QueueShowConfig()
        {
            QueueNames = new List<QueueItem>();
        }

        static public QueueShowConfig GetConfig(string userAccount, string sectionName)
        {
            QueueShowConfig qsc = new QueueShowConfig();

            try
            {

                SettingItem queueShowSetting = AppSettingHelper.GetSpecifySection(userAccount + "_" +  sectionName);

                qsc.QueueNames = JsonHelper.DeserializeObject<List<QueueItem>>(queueShowSetting.ReadSetting("QueueNames"));
                //qsc.WaitCount = queueShowSetting.ReadInt("WaitCount");
                //qsc.BackgroundImage = queueShowSetting.ReadSetting("BackgroundImage");

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);
            }

            return qsc;
        }

        static public void SetConfig(QueueShowConfig qsc, string userAccount, string sectionName)
        {
            SettingItem queueShowSetting = AppSettingHelper.GetSpecifySection(userAccount + "_" + sectionName);

            queueShowSetting.BatchBegin();
            try
            {
                queueShowSetting.WriteSetting("QueueNames", JsonHelper.SerializeObject(qsc.QueueNames));
                //queueShowSetting.WriteInt("WaitCount", qsc.WaitCount);
                //queueShowSetting.WriteSetting("BackgroundImage", qsc.BackgroundImage);

                queueShowSetting.BatchCommit();
            }
            catch (Exception ex)
            {
                queueShowSetting.BatchCancel();
                MsgBox.ShowException(ex);
            }

        }
    }
}
