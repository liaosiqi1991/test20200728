using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Info
{
    public class InfoConfig
    {
        public float ZoomFactor { get; set; }

        static public InfoConfig GetConfig(string sectionName)
        {
            InfoConfig ic = new InfoConfig();

            try
            {
                SettingItem imageSetting = AppSettingHelper.GetSpecifySection(sectionName);

                ic.ZoomFactor = (float)imageSetting.ReadDouble("ZoomFactor");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);
            }

            return ic;
        }

        static public void SetConfig(InfoConfig ic, string sectionName)
        {
            SettingItem imageSetting = AppSettingHelper.GetSpecifySection(sectionName);

            imageSetting.BatchBegin();
            try
            {
                imageSetting.WriteDouble("ZoomFactor", ic.ZoomFactor);

                imageSetting.BatchCommit();
            }
            catch (Exception ex)
            {
                imageSetting.BatchCancel();
                MsgBox.ShowException(ex);
            }

        }
    }
}
