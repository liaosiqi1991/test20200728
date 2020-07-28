using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.DataList
{
    public class DataListModuleDesign
    {
        /// <summary>
        /// 允许列表分组
        /// </summary>
        public bool AllowGroup { get; set; }

        /// <summary>
        /// 允许行号显示
        /// </summary>
        public bool AllowRowNo { get; set; }

        //允许固定列设置
        public bool AllowFixColCfg { get; set; }
        
        /// <summary>
        /// 允许显示列头
        /// </summary>
        public bool AllowShowColTitle { get; set; }

        /// <summary>
        /// 允许过滤
        /// </summary>
        public bool AllowFilter { get; set; }
    }
}
