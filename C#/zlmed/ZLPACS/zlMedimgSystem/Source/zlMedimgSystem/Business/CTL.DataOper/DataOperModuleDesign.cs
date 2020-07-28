using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.DataOper
{

    public class DataOperItem
    {
        /// <summary>
        /// 处理项名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 数据源别名
        /// </summary>
        public string DBAlias { get; set; }

        /// <summary>
        /// 处理内容
        /// </summary>
        public string ProcessContext { get; set; }

        /// <summary>
        /// 返回项名称
        /// </summary>
        public string ReturnName { get; set; }

    }
    public class DataOperModuleDesign
    {
        public List<DataOperItem> DataOperItems { get; set; }

        public DataOperModuleDesign()
        {
            DataOperItems = new List<DataOperItem>();
        }
    }
}
