using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.DataConvert
{

    public class DataConvertItem
    {
        public string SourceName { get; set; }

        /// <summary>
        /// 转换后名称
        /// </summary>
        public string ConvertName { get; set; }

        /// <summary>
        /// 转换后类型名
        /// </summary>
        public string ConvertType { get; set; }

        public DataConvertItem Clone()
        {
            DataConvertItem dci = new DataConvertItem();

            dci.SourceName = SourceName;
            dci.ConvertName = ConvertName;
            dci.ConvertType = ConvertType;

            return dci;
        }
       
    }
    public class DataConvertModuleDesign
    {
        public List<DataConvertItem> ConvertItems = null;

        public DataConvertModuleDesign()
        {
            ConvertItems = new List<DataConvertItem>();
        }
    }
}
