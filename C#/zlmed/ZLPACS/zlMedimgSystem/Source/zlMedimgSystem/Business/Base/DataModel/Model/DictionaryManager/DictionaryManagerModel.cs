using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using System.Data;

namespace zlMedimgSystem.DataModel
{
    public class DictManageData: DictionaryBase, IBizBindRow
    { 
        public JDictionary 字典信息 { get; set; }

        protected override void InitJsonInstance()
        {
            字典信息 = new JDictionary();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JDictionary).FullName)
                {
                    return JsonHelper.DeserializeObject<JDictionary>(jsonData);
                }

                return null;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, null);
                return null;
            }
        }
    }

    public class DictManageModel : DBModel
    {
        public DictManageModel(IDBQuery dbHelper) : base(dbHelper) { }

        /// <summary>
        /// 获取字典信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDictInfo()
        {
            SQL sql = SqlHelper.CreateSQL("查询影像字典项目", "Select 字典名称 From 影像字典信息 order by 字典名称 "); 

            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 获取对应字典
        /// </summary>
        /// <param name="dictionaryName"></param>
        /// <returns></returns>
        public JDictionary GetDictionary(string dictionaryName)
        {
            SQL sql = SqlHelper.CreateSQL("查询影像字典内容信息", "Select 字典信息 From 影像字典信息 Where 字典名称=:字典名称 ");
            sql.AddParameter("字典名称", DbType.String, dictionaryName);

            object objDictionary = _dbHelper.ExecuteSQLOneOutput(sql);

            if (objDictionary == null) return null;

            return JsonHelper.DeserializeObject<JDictionary>(objDictionary.ToString());
        }

        /// <summary>
        /// 获取字典项目
        /// </summary>
        /// <param name="dictionaryName"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public JDictionaryItem GetDictionaryItemInfo(string dictionaryName, string itemName)
        {
            JDictionary dict = GetDictionary(dictionaryName);

            if (dict == null) return null;

            if (dict.项目内容.Count <= 0) return null;

            int dictIndex = (dict.项目内容 as List<JDictionaryItem>).FindIndex(T=>T.项目名称==itemName);
            if (dictIndex < 0) return null;

            return dict.项目内容[dictIndex];

        }

        /// <summary>
        /// 获取字典内容信息（单行string版本）
        /// </summary>
        /// <returns></returns>
        public string GetDictContentInfoOneOutput(string sDicName)
        {
            JDictionary dict = GetDictionary(sDicName);

            if (dict == null) return "";

            return dict.ToString();

        }

        /// <summary>
        /// 获取字典内容信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDictContentInfo(string sDicName)
        {
            SQL sql = SqlHelper.CreateSQL("查询影像字典内容", "Select 字典信息 From 影像字典信息 Where 字典名称=:字典名称 ");
            sql.AddParameter("字典名称", DbType.String, sDicName);

            return _dbHelper.ExecuteSQL(sql);

        }

        /// <summary>
        /// 更新字典内容
        /// </summary>
        /// <returns></returns>
        public void UpdateDictContent(DictManageData  dictData)
        {
            string sj字典信息 = JsonHelper.SerializeObject(dictData.字典信息);

            SQL sql = SqlHelper.CreateSQL("更新字典内容", "Update 影像字典信息 " +
                    " Set 字典信息=:字典信息 where 字典名称=:字典名称");

            sql.AddParameter("字典名称", DbType.String, dictData.字典名称);
            sql.AddParameter("字典信息", DbType.String, sj字典信息);
             
            _dbHelper.ExecuteSQL(sql);
        }

 
    }
}
