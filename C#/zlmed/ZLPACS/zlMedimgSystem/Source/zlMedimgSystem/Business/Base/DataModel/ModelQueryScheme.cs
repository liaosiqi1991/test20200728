using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services; 

namespace zlMedimgSystem.DataModel
{
    public class QuerySchemeRowData : BizRow
    {
        public QuerySchemeRowData(DataRow r)
            : base(r)
        {

        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            if (jsonTypeName == typeof(SchemeContext).FullName)
            {
                return JsonHelper.DeserializeObject<SchemeContext>(jsonData);
            }

            return null;
        }

        public string 查询方案ID { get; set; }
        public string 角色ID { get; set; }
        public string 方案名称 { get; set; }

        public SchemeContext 方案内容 { get; set; }


    }

    public class SchemeContext:IJsonField
    {
        public string 查询语句 { get; set; }

        public string 布局配置 { get; set; }

        public SchemeContext()
        {

        }
    }

    public class ModelQueryScheme
    {

    }
}
