using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Image
{
    public class ImageConfig
    {
 
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int RecordCount { get; set; }

         
        static public ImageConfig GetConfig(string sectionName)
        {
            ImageConfig ic = new ImageConfig();

            try
            {
                SettingItem imageSetting = AppSettingHelper.GetSpecifySection(sectionName);

                ic.RecordCount = imageSetting.ReadInt("RecordCount"); 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);
            }

            return ic;
        }

        static public void SetConfig(ImageConfig ic, string sectionName)
        {
            SettingItem imageSetting = AppSettingHelper.GetSpecifySection(sectionName);

            imageSetting.BatchBegin();
            try
            {
                imageSetting.WriteInt("RecordCount", ic.RecordCount);

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
