using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{ 

    public class DepartmentMatchData: DepartmentMatchBase, IBizBindRow
    {         
    }

    public class DepartmentInfoData : DepartmentInfoBase, IBizBindRow
    {
        public JDepartmentAttachInfo 附加数据 { get; set; }


        protected override void InitJsonInstance()
        {
            附加数据 = new JDepartmentAttachInfo();
        }
         
        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JDepartmentAttachInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JDepartmentAttachInfo>(jsonData);
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


    public class DepartmentMatchModel : DBModel
    {
        public DepartmentMatchModel(IDBQuery dbHelper) : base(dbHelper) { }

        public DataTable GetAllDepartment()
        {
            string sql = "Select a.科室ID,a.科室名称,a.附加数据 " + 
                        " From 影像科室信息 a " + 
                        " order by 科室名称";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询影像科室信息", sql);

            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 根据his科室编码获取科室ID
        /// </summary>
        /// <param name="hisAlias"></param>
        /// <param name="hisDepartmentCode"></param>
        /// <returns></returns>
        public string GetDepartmentIdByHis(string hisAlias, string hisDepartmentCode)
        {
            SQL sql = SqlHelper.CreateSQL("根据编码获取对照科室ID", "Select 科室ID From 影像科室对照 Where 对照编码=:对照编码");
            sql.AddParameter("对照编码", DbType.String, hisDepartmentCode);

            DataTable dtMatch = _dbHelper.ExecuteSQL(sql);
            if (dtMatch == null || dtMatch.Rows.Count <= 0) return "";

            DataRow[] drCodes = dtMatch.Select("对照来源='" + hisAlias + "'");
            if (drCodes.Length > 0)
            {
                return drCodes[0]["科室ID"].ToString();
            }
            else
            {
                drCodes = dtMatch.Select("对照来源='' or 对照来源 is null");

                if (drCodes.Length > 0)
                {
                    return drCodes[0]["科室ID"].ToString();
                }
                else
                {
                    return "";
                }
            }
             
        }

        /// <summary>
        /// 根据科室ID获取HIS对应科室的对照编码
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="hisAlias"></param>
        /// <returns></returns>
        public string GetHisDepartmentCodeByDepartmentId(string departmentId, string hisAlias)
        {
            SQL sql = SqlHelper.CreateSQL("根据科室ID获取HIS对照科室编码", "Select 科室ID,对照编码 From 影像科室对照 Where 科室ID=:科室ID");
            sql.AddParameter("科室ID", DbType.String, departmentId);

            DataTable dtMatch = _dbHelper.ExecuteSQL(sql);
            if (dtMatch == null || dtMatch.Rows.Count <= 0) return "";

            DataRow[] drCodes = dtMatch.Select("对照来源='" + hisAlias + "'");
            if (drCodes.Length > 0)
            {
                return drCodes[0]["对照编码"].ToString();
            }
            else
            {
                drCodes = dtMatch.Select("对照来源='' or 对照来源 is null");

                if (drCodes.Length > 0)
                {
                    return drCodes[0]["对照编码"].ToString();
                }
                else
                {
                    return "";
                }
            }

        }

        public DataTable GetDepartmentMatch(string departmentInfoId)
        {
            string sql = "select 科室对照ID,科室ID,对照来源,对照编码 from 影像科室对照 where 科室ID=:科室ID order by 对照来源,对照编码";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询影像科室对照", sql);


            return _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("科室ID", DbType.String, departmentInfoId)});
        }

        /// <summary>
        /// 新增科室信息
        /// </summary>
        /// <param name="departmentInfo"></param>
        /// <returns></returns>
        public bool NewDepartmentInfo(DepartmentInfoData departmentInfo)
        {
            string sql = "insert into " +
                  " 影像科室信息(科室ID, 科室名称, 附加数据) " +
                  " values " +
                  " (:科室ID,:科室名称, :附加数据)";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("插入影像科室信息", sql);

            SqlParamInfo[] sqlPars = GetDepartmentInfoPars(departmentInfo);
            DataTable dtResult = _dbHelper.ExecuteSQL(sql, sqlPars);
             
            return true;
        }

        /// <summary>
        /// 新增科室对照
        /// </summary>
        /// <param name="departmentMatch"></param>
        /// <returns></returns>
        public bool NewDepartmentMatch(DepartmentMatchData departmentMatch)
        {
            string sql = "insert into 影像科室对照(科室对照ID, 科室ID, 对照来源, 对照编码)" +
                        " values(:科室对照ID, :科室ID, :对照来源, :对照编码)";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("插入影像科室对照", sql);

            SqlParamInfo[]  sqlPars = GetDepartmentMatchPars(departmentMatch);
            DataTable dtResult = _dbHelper.ExecuteSQL(sql, sqlPars);

            return true;
        }

        /// <summary>
        /// 更新科室信息
        /// </summary>
        /// <param name="departmentInfo"></param>
        public void UpdateDepartmentInfo(DepartmentInfoData departmentInfo)
        {
            string sql = "Update 影像科室信息 " +
                    " Set 科室名称=:科室名称, 附加数据=:附加数据 where 科室ID=:科室ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("更新影像科室信息", sql);

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("科室名称", DbType.String, departmentInfo.科室名称),
                                                            new SqlParamInfo("附加数据", DbType.String, departmentInfo.附加数据.ToString()),
                                                            new SqlParamInfo("科室ID", DbType.String, departmentInfo.科室ID)};

            _dbHelper.ExecuteSQL(sql, sqlPars);

        }

        /// <summary>
        /// 删除影像科室信息
        /// </summary>
        /// <param name="serverID"></param>
        /// <returns></returns>
        public bool DelDepartmentInfo(string departmentInfoID)
        {
            string sql = "Delete 影像科室信息 Where 科室ID=:科室ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("删除影像科室信息", sql);
            _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("科室ID", DbType.String, departmentInfoID) });
        
            return true;

        }

        /// <summary>
        /// 删除科室对照
        /// </summary>
        /// <param name="departmentInfoID"></param>
        /// <returns></returns>
        public bool DelDepartmentMatch(string departmentInfoID)
        {
            string sql = "Delete 影像科室对照 Where 科室ID=:科室ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("删除影像科室对照", sql);

            _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("科室ID", DbType.String, departmentInfoID) });

            return true;
        }
         

        /// <summary>
        /// 获取影像对照科室ID
        /// </summary>
        /// <param name="serverAlias"></param>
        /// <returns></returns>
        public string GetDepartmenID(string matchSource, string matchCode)
        {
            string sql = "Select 科室ID From 影像科室对照 where 对照来源=:对照来源, 对照编码=:对照编码";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("获取影像科室对照ID", sql);

            object result = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] {new SqlParamInfo("对照来源", DbType.String, matchSource),
                                                                                new SqlParamInfo("对照编码", DbType.String, matchCode) });

            return (result == null ? "" : result.ToString());
        }

        /// <summary>
        /// 根据名称获取科室ID
        /// </summary>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public string GetDepartmentIdByName(string departmentName)
        {
            string sql = "Select 科室ID From 影像科室信息 where 科室名称=:科室名称";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("获取影像科室信息ID", sql);

            object result = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] {new SqlParamInfo("科室名称", DbType.String, departmentName)});

            return (result == null ? "" : result.ToString());
        }

        private SqlParamInfo[] GetDepartmentInfoPars(DepartmentInfoData departmentInfo)
        {
            return new SqlParamInfo[] {
                        new SqlParamInfo("科室ID", DbType.String, departmentInfo.科室ID),
                        new SqlParamInfo("科室名称", DbType.String, departmentInfo.科室名称),
                        new SqlParamInfo("附加数据", DbType.String, departmentInfo.附加数据.ToString()) };
        }


        private SqlParamInfo[] GetDepartmentMatchPars(DepartmentMatchData departmentMatch)
        {
            return new SqlParamInfo[] {
                        new SqlParamInfo("科室对照ID", DbType.String, departmentMatch.科室对照ID),
                        new SqlParamInfo("科室ID", DbType.String, departmentMatch.科室ID),
                        new SqlParamInfo("对照来源", DbType.String, departmentMatch.对照来源),
                        new SqlParamInfo("对照编码", DbType.String, departmentMatch.对照编码) };
        }
    }

}
