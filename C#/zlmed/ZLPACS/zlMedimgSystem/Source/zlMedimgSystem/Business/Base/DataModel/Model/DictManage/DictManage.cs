using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using System.Data;

namespace zlMedimgSystem.DataModel
{
    public class DictManageData: JDictionary, IBizBindRow
    {
        private DataRow _bindRow = null;
        private BizRow _DictInfoRow = null;
        public JDictionary 字典 { get; set; }

        public DataRow GetBindRow()
        {
            return _bindRow;
        }

        public DictManageData()
            : this(null)
        {
        }

        public DictManageData(DataRow r)
        {
            _bindRow = r;

            if (_DictInfoRow == null)
            {
                _DictInfoRow = new BizRow();

                _DictInfoRow.OnJsonConvert += ConvertJson;
            }

            if (r != null)
            {
                _DictInfoRow.RowConvert(r, this, true);
            }
            else
            {
                字典 = new JDictionary();
            }
        }

        private IJsonField ConvertJson(string jsonTypeName, string jsonData)
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
            string sql = "Select 字典ID,字典名称 From 影像字典信息 order by 字典名称 ";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询影像字典信息", sql);

            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 获取字典内容信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDictContentInfo(string sDicName)
        {
            string sql = "Select 字典信息 From 影像字典信息 Where 字典名称=:字典名称 ";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询影像字典内容信息", sql);

            return _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("字典名称", DbType.String, sDicName) });

        }

        /// <summary>
        /// 更新字典内容
        /// </summary>
        /// <returns></returns>
        public void UpdateDictContent(DictManageData  dictInfo)
        {
            string sql = "Update 影像字典信息 " +
                    " Set 字典信息=:字典信息 where 字典名称=:字典名称";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("更新科室角色信息", sql);

            //SqlParamInfo sqlPars =  new SqlParamInfo("角色信息", DbType.String, dictInfo.字典信息.ToString());
            SqlParamInfo []sqlPars = new SqlParamInfo[] { new SqlParamInfo("字典名称", DbType.String, dictInfo.字典信息.ToString()) };
            //return _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("字典名称", DbType.String, sDicName) });

            _dbHelper.ExecuteSQL(sql, sqlPars);
        }


    }
}
