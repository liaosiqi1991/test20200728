using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.ViewTable
{

    [Serializable]
    public class ViewTableItemConfig
    {
        public string 列名称;
        public string 列标题;
        public bool 是否显示;        

        public ViewTableItemConfig()
        {
            
        }
    }

    public class ViewTableDesign
    {
        public bool 查PACS库;

        public List<ViewTableItemConfig> ViewTableCfg { get; set; }


        public ViewTableDesign()
        {
            ViewTableCfg = new List<ViewTableItemConfig>();
        }
    }
}
