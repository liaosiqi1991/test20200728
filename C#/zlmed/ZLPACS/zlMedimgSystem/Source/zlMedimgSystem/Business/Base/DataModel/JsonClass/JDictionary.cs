using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{

    public class DictionaryBase: DataBase
    {
        /// <summary>
        /// 字典ID
        /// </summary>
        public int 字典ID { set; get; }
        /// <summary>
        /// 字典名称
        /// </summary>
        public string 字典名称 { set; get; }



    }

    public class JDictionaryItem
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string 项目名称 { set; get; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string 项目编码 { set; get; }
      
        /// <summary>
        /// 项目说明
        /// </summary>
        public string 项目说明 { set; get; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime 创建日期 { set; get; }
        /// <summary>
        /// 缺省
        /// </summary>
        public bool 缺省 { set; get; }

        public JDictionaryItem() { }

        public JDictionaryItem(string Name,string Code,string Description, DateTime Cdate, bool isDefault)
        {
            项目名称 = Name;
            项目编码 = Code;
            项目说明 = Description;
            创建日期 = Cdate;
            缺省 = isDefault;
        }

        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //} 
    } 
     
    public class JDictionary: DictionaryBase, IJsonField
    {
        //public string 字典描述 { get; set; }

        public IList<JDictionaryItem> 项目内容 { get; set; }

        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}

        public void CopyBasePro(DictionaryBase dictionaryBase)
        {
            base.CopyFrom<DictionaryBase>(dictionaryBase);
        }
    }
}
