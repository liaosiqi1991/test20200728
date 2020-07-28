using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
    public class ParameterData:ParsInfoBase, IBizBindRow
    { 
        public string 参数取值 { get; set; }

    }

    public class ParameterModel : DBModel
    {
        public ParameterModel(IDBQuery dbHelper) : base(dbHelper) { }


        /// <summary>
        /// 清除参数
        /// </summary>
        /// <param name="parName"></param>
        public void ClearParameter(string parName, string parTag)
        {
            string sql = "delete 影像参数信息 where 参数名称=:参数名称 and 参数标记=:参数标记";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("删除影像参数信息", sql);

            _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("参数名称", DbType.String, parName),
                                                            new SqlParamInfo("参数标记", DbType.String, parTag)});
        }

        /// <summary>
        /// 获取参数ID
        /// </summary>
        /// <param name="parName"></param>
        /// <returns></returns>
        public string GetParameterId(string parName, string parTag)
        {
            string sql = "select 参数ID from 影像参数信息 where 参数名称=:参数名称 and 参数标记=:参数标记";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询影像参数ID", sql);

            object value = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] { new SqlParamInfo("参数名称", DbType.String, parName),
                                                                new SqlParamInfo("参数标记", DbType.String, parTag)});

            return (value == null ? "" : value.ToString());
        }

        /// <summary>
        /// 获取参数信息
        /// </summary>
        /// <param name="parName"></param>
        /// <param name="parTag">参数标记，如站点名称，科室ID，用户名称等</param>
        /// <returns></returns>
        public DataTable GetParameterInfo(string parName, string parTag)
        {
            string sql = "select 参数ID,参数名称,参数标记,参数取值 from 影像参数信息 where 参数名称=:参数名称 and 参数标记=:参数标记";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询影像参数信息", sql);

            return _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("参数名称", DbType.String, parName),
                                                                    new SqlParamInfo("参数标记", DbType.String, parTag)});
        }

        public ParameterData ReadParameter(string parName, string parTag)
        {
            SQL sql = CreateSQL("读取参数配置", "select 参数ID,参数名称,参数标记,参数取值 from 影像参数信息 where 参数名称=:参数名称 and 参数标记=:参数标记");

            sql.AddParameter("参数名称", parName);
            sql.AddParameter("参数标记", parTag);

            DataTable dtPar = sql.ExecuteSql();

            if (dtPar == null || dtPar.Rows.Count <= 0) return null;

            ParameterData parData = new ParameterData();
            parData.BindRowData(dtPar.Rows[0]);

            return parData;
        }



        /// <summary>
        /// 更新参数
        /// </summary>
        /// <param name="parData"></param>
        public void WriteParameter(ParameterData parData)
        {
            string parId = GetParameterId(parData.参数名称, parData.参数标记);

            string sql = "";
            if (string.IsNullOrEmpty(parId))
            {
                parId = parData.参数ID;

                sql = "insert into 影像参数信息(参数ID,参数名称,参数标记,参数取值) values(:参数ID, :参数名称, :参数标记, :参数取值)";
                sql = SqlHelper.GetSqlBiz().GetSqlContext("插入影像参数信息", sql);
            }
            else
            {
                sql = "update 影像参数信息 set 参数取值=:参数取值 where 参数ID=:参数ID";
                sql = SqlHelper.GetSqlBiz().GetSqlContext("更新影像参数信息", sql);
            }

            _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("参数名称", DbType.String, parData.参数名称),
                                                        new SqlParamInfo("参数标记", DbType.String, parData.参数标记),
                                                        new SqlParamInfo("参数取值", DbType.String, parData.参数取值),
                                                        new SqlParamInfo("参数ID", DbType.String, parId)});
        }


    }
}
