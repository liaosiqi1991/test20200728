using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{

    public class RoleInfoData: RoleBase, IBizBindRow
    { 
        public JRoleInfo 角色信息 { get; set; }

        protected override void InitJsonInstance()
        {
            角色信息 = new JRoleInfo();
        } 

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JRoleInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JRoleInfo>(jsonData);
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


    /// <summary>
    /// 角色数据模型
    /// </summary>
    public class RoleModel : DBModel
    {
        public RoleModel(IDBQuery dbHelper) : base(dbHelper) { }


        /// <summary>
        /// 获取角色科室
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepartment()
        {
            SQL sql = SqlHelper.Statement.科室信息查询;

            return _dbHelper.ExecuteSQL(sql);
        }


        public DataTable GetRoleInfo(string departmentId)
        {
            SQL sql = SqlHelper.Statement.角色信息查询;
            sql.AddParameter("科室ID", DbType.String, departmentId);

            return _dbHelper.ExecuteSQL(sql);
        }


        /// <summary>
        /// 获取角色分组
        /// </summary>
        /// <param name="imageKind"></param>
        /// <returns></returns>
        public DataTable GetRoleGroups(string departmentId)
        {
            string sql = "select Distinct 分组标记 from 影像角色信息 where 科室ID=:科室ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("获取角色分组信息", sql);

            return _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("科室ID", DbType.String, departmentId) });
        }


        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="hisServerData"></param>
        /// <returns></returns>
        public bool NewRole(RoleInfoData roleInfo)
        {
            string sql = "insert into " +
                  " 影像角色信息(角色ID,科室ID,角色名称, 分组标记, 角色信息) " +
                  " values " +
                  " (:角色ID,:科室ID,:角色名称, :分组标记, :角色信息)";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("插入科室角色信息", sql);

            SqlParamInfo[] sqlPars = GetRoleInfoPars(roleInfo);

            DataTable dtResult = _dbHelper.ExecuteSQL(sql, sqlPars);

            return true;
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="hisServerData"></param>
        public void UpdateRoleInfo(RoleInfoData roleInfo)
        {
            string sql = "Update 影像角色信息 " +
                    " Set 角色名称=:角色名称, 分组标记=:分组标记, 角色信息=:角色信息 where 角色ID=:角色ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("更新科室角色信息", sql);

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("角色名称", DbType.String, roleInfo.角色名称),
                                                            new SqlParamInfo("分组标记", DbType.String, roleInfo.分组标记),
                                                            new SqlParamInfo("角色信息", DbType.String, roleInfo.角色信息.ToString()),
                                                            new SqlParamInfo("角色ID", DbType.String, roleInfo.角色ID)};

            _dbHelper.ExecuteSQL(sql, sqlPars);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="serverID"></param>
        /// <returns></returns>
        public bool DelRoleInfo(string roleID)
        {
            string sql = "Delete 影像角色信息 Where 角色ID=:角色ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("删除科室角色信息", sql);

            _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("角色ID", DbType.String, roleID) });

            return true;

        }
        /// <summary>
        /// 获取角色ID
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <param name="roomId">科室ID</param>
        /// <returns></returns>
        public string GetRoleID(string roleName,string roomId)
        {
            //TODO:需要结合科室ID进行判断
            string sql = "Select 角色ID From 影像角色信息 where 角色名称=:角色名称 and 科室ID=:科室ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("获取科室角色ID", sql);

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("角色名称", DbType.String, roleName),
                                                            new SqlParamInfo("科室ID", DbType.String, roomId)};

            _dbHelper.ExecuteSQL(sql, sqlPars);
            object result = _dbHelper.ExecuteSQLOneOutput(sql, sqlPars);

            //object result = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] { new SqlParamInfo("角色名称", DbType.String, roleName) });

            return (result == null ? "" : result.ToString());
        }

        private SqlParamInfo[] GetRoleInfoPars(RoleInfoData roleInfo)
        {
            return new SqlParamInfo[] {
                        new SqlParamInfo("角色ID", DbType.String, roleInfo.角色ID),
                        new SqlParamInfo("科室ID", DbType.String, roleInfo.科室ID),
                        new SqlParamInfo("角色名称", DbType.String, roleInfo.角色名称),
                        new SqlParamInfo("分组标记", DbType.String, roleInfo.分组标记),
                        new SqlParamInfo("角色信息", DbType.String, roleInfo.角色信息.ToString()) };
        }
    }
}
