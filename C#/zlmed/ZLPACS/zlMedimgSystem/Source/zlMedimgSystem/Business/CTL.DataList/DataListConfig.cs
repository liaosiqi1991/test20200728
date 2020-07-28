using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.DataList
{
    public class DataListConfig
    {
        //public string DefaultQueueName { get; set; }

        //public QueueQuickConfig()
        //{

        //}

        //public void CopyFrom(QueueQuickConfig sourcePar)
        //{
        //    this.DefaultQueueName = sourcePar.DefaultQueueName;
        //}

        //static public QueueQuickConfig GetConfig(string sectionName)
        //{
        //    QueueQuickConfig qc = new QueueQuickConfig();

        //    try
        //    {
        //        SettingItem queueSetting = AppSettingHelper.GetSpecifySection(sectionName);

        //        qc.DefaultQueueName = queueSetting.ReadSetting("DefaultQueueName");
        //    }
        //    catch (Exception ex)
        //    {
        //        MsgBox.ShowException(ex);
        //    }

        //    return qc;
        //}

        //static public void SetConfig(QueueQuickConfig qc, string sectionName)
        //{
        //    AppSetting.BatchBegin();
        //    try
        //    {
        //        SettingItem queueSetting = AppSettingHelper.GetSpecifySection(sectionName);

        //        queueSetting.WriteSetting("DefaultQueueName", qc.DefaultQueueName);

        //        AppSetting.BatchCommit();
        //    }
        //    catch (Exception ex)
        //    {
        //        AppSetting.BatchCancel();

        //        MsgBox.ShowException(ex);
        //    }

        //}
    }
}
