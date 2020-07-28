using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
 



    public class HisServerCfgData : HisServerBase, IBizBindRow
    { 
        public JHisServerCfg 服务配置 { get; set; }

        protected override void InitJsonInstance()
        {
            服务配置 = new JHisServerCfg();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JHisServerCfg).FullName)
                {
                    return JsonHelper.DeserializeObject<JHisServerCfg>(jsonData);
                }

                return null;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, null);
                return null;
            }
        }
    }

    public class HisServerModel:DBModel
    {
        public HisServerModel(IDBQuery dbHelper) : base(dbHelper) { }

        public DataTable GetAllHisServer()
        {
            string sql = "Select HIS服务ID,服务名称,服务配置 From HIS服务配置 order by 服务名称";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询HIS服务配置", sql);

            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 新增HIS服务配置
        /// </summary>
        /// <param name="hisServerData"></param>
        /// <returns></returns>
        public bool NewHisServerCfg(HisServerCfgData hisServerData)
        {
            string sql = "insert into " +
                  " HIS服务配置(HIS服务ID, 服务名称, 服务配置) " +
                  " values " +
                  " (:HIS服务ID,:服务名称,:服务配置)";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("插入HIS服务配置", sql);

            SqlParamInfo[] sqlPars = GetHisServerCfgPars(hisServerData);

            DataTable dtResult = _dbHelper.ExecuteSQL(sql, sqlPars); 

            return true;
        }

        /// <summary>
        /// 更新HIS服务配置
        /// </summary>
        /// <param name="hisServerData"></param>
        public void UpdateHisServerCfg(HisServerCfgData hisServerData)
        {
            string sql = "Update HIS服务配置 " +
                    " Set 服务名称=:服务名称, 服务配置=:服务配置 where HIS服务ID=:HIS服务ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("更新HIS服务配置", sql);

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("服务名称", DbType.String, hisServerData.服务名称),
                                                            new SqlParamInfo("服务配置", DbType.String, hisServerData.服务配置.ToString()),
                                                            new SqlParamInfo("HIS服务ID", DbType.String, hisServerData.HIS服务ID)};

            _dbHelper.ExecuteSQL(sql, sqlPars);
        }

        /// <summary>
        /// 删除HIS服务配置
        /// </summary>
        /// <param name="hisServerID"></param>
        /// <returns></returns>
        public bool DelHisServerCfg(string hisServerID)
        {
            string sql = "Delete HIS服务配置 Where HIS服务ID=:HIS服务ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("删除HIS服务配置", sql);

            _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("HIS服务ID", DbType.String, hisServerID) });

            return true;

        }

        /// <summary>
        /// 获取his服务配置ID
        /// </summary>
        /// <param name="serverAlias"></param>
        /// <returns></returns>
        public string GetHisServerCfgID(string hisServerName)
        {
            string sql = "Select HIS服务ID From HIS服务配置 where 服务名称=:服务名称 ";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("获取HIS服务配置ID", sql);

            object result = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] { new SqlParamInfo("服务名称", DbType.String, hisServerName) });

            return (result == null ? "" : result.ToString());
        }

        private SqlParamInfo[] GetHisServerCfgPars(HisServerCfgData hisServerData)
        {
            return new SqlParamInfo[] {
                        new SqlParamInfo("HIS服务ID", DbType.String, hisServerData.HIS服务ID),
                        new SqlParamInfo("服务名称", DbType.String, hisServerData.服务名称),
                        new SqlParamInfo("服务配置", DbType.String, hisServerData.服务配置.ToString()) }; 
        }
    }
}
