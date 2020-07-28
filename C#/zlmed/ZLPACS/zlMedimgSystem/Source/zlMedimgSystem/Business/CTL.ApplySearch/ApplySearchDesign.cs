using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;
using zlMedimgSystem.Services;


namespace zlMedimgSystem.CTL.ApplySearch
{

    public enum ASControlType
    {
        asct单项条件 = 0,
        asct复合条件 = 1,
        asct勾选项 = 2,
        asct条件按钮 = 3,
        asct功能按钮 = 4
    }

    [Serializable]
    public class ApplySearchItemConfig
    {
        
        public ASControlType 控件类型 { get; set; }

        public string 控件名称 { get; set; }

        public int 起始行 { get; set; }

        public int 起始列 { get; set; }

        public int 占用行数 { get; set; }

        public int 占用列数 { get; set; }

        public ApplySearchItemConfig ()
        {
        }
        
        
    }

    public class ApplySearchDesign
    {

        public bool 查PACS库;
        public string HIS库名称;

        public List<ApplySearchItemConfig> ApplySearchCfg { get; set; }


        public ApplySearchDesign()
        {
            ApplySearchCfg = new List<ApplySearchItemConfig>();
        }


        /// <summary>
        /// 获取控件列表的最大行数和列数
        /// </summary>
        /// <param name="intRow"></param>
        /// <param name="intCol"></param>
        public void GetControlRC( out int intRow, out int intCol)
        {
            intRow = 1;
            intCol = 1;

            try
            {
                foreach (ApplySearchItemConfig asic in ApplySearchCfg)
                {
                    if ((asic.起始行 + asic.占用行数-1) > intRow)
                    {
                        intRow = asic.起始行 + asic.占用行数-1;
                    }
                    if ((asic.起始列 + asic.占用列数-1) > intCol)
                    {
                        intCol = asic.起始列 + asic.占用列数-1;
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);
            }
        }

    }
}
