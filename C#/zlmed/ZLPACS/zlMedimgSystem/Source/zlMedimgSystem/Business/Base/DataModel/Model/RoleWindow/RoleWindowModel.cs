using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
    public class WindowInfoData: WindowInfoBase
    { 
        public JRoleWindowInfo 窗体信息 { get; set; }

        protected override void InitJsonInstance()
        {
            窗体信息 = new JRoleWindowInfo();
        }
         
        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JRoleWindowInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JRoleWindowInfo>(jsonData);
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

    public class RoleWindowModel:DBModel
    {
        public RoleWindowModel(IDBQuery dbHelper) : base(dbHelper) { }

        /// <summary>
        /// 获取窗体科室
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepartment()
        {
            SQL sql = SqlHelper.Statement.科室信息查询;
 
            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 获取科室角色
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public DataTable GetRoleInfo(string departmentId)
        {
            SQL sql = SqlHelper.Statement.角色信息查询;
            sql.AddParameter("科室ID", DbType.String, departmentId);

            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 获取窗体信息
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public DataTable GetWindowInfo(string departmentId)
        {
            SQL sql = SqlHelper.Statement.窗体信息查询;
            sql.AddParameter("科室ID", DbType.String, departmentId);

            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 获取窗体分组
        /// </summary>
        /// <param name="imageKind"></param>
        /// <returns></returns>
        public DataTable GetWindowGroups(string departmentId)
        {
            SQL sql = SqlHelper.CreateSQL("查询窗体分组", "select Distinct 分组标记 from 影像窗体信息 where 科室ID=:科室ID");
            sql.AddParameter("科室ID", DbType.String, departmentId);

            return _dbHelper.ExecuteSQL(sql);
        }


        /// <summary>
        /// 获取窗体ID
        /// </summary>
        /// <param name="serverAlias"></param>
        /// <returns></returns>
        public string GetWindowId(string windowName, string departmentId)
        {
            SQL sql = SqlHelper.CreateSQL("根据姓名查询窗体ID", "Select 窗体ID From 影像窗体信息 where 窗体名称=:窗体名称 and 科室ID=:科室ID ");
            sql.AddParameter("窗体名称", DbType.String, windowName);
            sql.AddParameter("科室ID", DbType.String, departmentId);

            object result = _dbHelper.ExecuteSQLOneOutput(sql);

            return (result == null ? "" : result.ToString());
        }

        /// <summary>
        /// 获取角色关联主窗体
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public string GetRoleMainWindowID(string roleId)
        {
            SQL sql = SqlHelper.CreateSQL("查询角色关联主窗体ID", "Select 窗体ID From 影像角色信息 where 角色ID=:角色ID ");
            sql.AddParameter("角色ID", DbType.String, roleId); 

            object result = _dbHelper.ExecuteSQLOneOutput(sql);

            return (result == null ? "" : result.ToString());
        }

        public WindowInfoData GetRoleMainWindowInfo(string roleId)
        {
            SQL sql = SqlHelper.CreateSQL("查询角色主窗体信息", "select b.窗体ID,b.窗体名称,b.分组标记,b.版本,b.窗体信息 " +
                                            " from 影像角色信息 a, 影像窗体信息 b " +
                                            " where a.窗体id = b.窗体id and a.角色id =:角色ID");
            sql.AddParameter("角色ID", DbType.String, roleId);

            DataTable dtWindow = _dbHelper.ExecuteSQL(sql);

            if (dtWindow == null || dtWindow.Rows.Count <= 0) return null;

            WindowInfoData windowInfo = new WindowInfoData();
            windowInfo.BindRowData(dtWindow.Rows[0]);

            return windowInfo;

        }

        /// <summary>
        /// 根据名称获取窗体信息
        /// </summary>
        /// <param name="windowName"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public WindowInfoData GetWindowInfoByName(string windowName, string departmentId)
        {
            SQL sql = SqlHelper.CreateSQL("根据窗体名称查询窗体信息", "select 窗体ID,窗体名称,分组标记,版本,窗体信息 " +
                                " from 影像窗体信息" +
                                " where 科室id =:科室ID and 窗体名称=:窗体名称");

            sql.AddParameter("科室id", DbType.String, departmentId);
            sql.AddParameter("窗体名称", DbType.String, windowName);

            DataTable dtWindow = _dbHelper.ExecuteSQL(sql);

            if (dtWindow == null || dtWindow.Rows.Count <= 0) return null;

            WindowInfoData windowInfo = new WindowInfoData();
            windowInfo.BindRowData(dtWindow.Rows[0]);

            return windowInfo;
        }

        /// <summary>
        /// 新增窗体信息
        /// </summary>
        /// <param name="hisServerData"></param>
        /// <returns></returns>
        public bool NewWindow(WindowInfoData roleWindowInfo)
        {
            SQL sql =SqlHelper.CreateSQL("插入窗体信息",  "insert into " +
                  " 影像窗体信息(窗体ID,科室ID,窗体名称, 分组标记, 窗体信息) " +
                  " values " +
                  " (:窗体ID,:科室ID,:窗体名称, :分组标记, :窗体信息)"); 

            SqlParamInfo[] sqlPars = GetWindowInfoPars(roleWindowInfo);
            sql.AddParameterRange(sqlPars);

            DataTable dtResult = _dbHelper.ExecuteSQL(sql);

            return true;
        }


        /// <summary>
        /// 更新窗体
        /// </summary>
        /// <param name="hisServerData"></param>
        public void UpdateWindowInfo(WindowInfoData roleWindowInfo)
        {
            SQL sql = SqlHelper.CreateSQL("更新窗体信息", "Update 影像窗体信息 " +
                    " Set 窗体名称=:窗体名称, 分组标记=:分组标记, 版本=:版本, 窗体信息=:窗体信息 where 窗体ID=:窗体ID"); 

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("窗体名称", DbType.String, roleWindowInfo.窗体名称),
                                                            new SqlParamInfo("分组标记", DbType.String, roleWindowInfo.分组标记),
                                                            new SqlParamInfo("版本", DbType.Int32, roleWindowInfo.版本),
                                                            new SqlParamInfo("窗体信息", DbType.String, roleWindowInfo.窗体信息.ToString()),
                                                            new SqlParamInfo("窗体ID", DbType.String, roleWindowInfo.窗体ID)};
            sql.AddParameterRange(sqlPars);

            _dbHelper.ExecuteSQL(sql);
        }
         

        /// <summary>
        /// 删除窗体
        /// </summary>
        /// <param name="serverID"></param>
        /// <returns></returns>
        public bool DelWindowInfo(string windowId)
        {
            SQL sql = SqlHelper.CreateSQL("删除窗体信息", "Delete 影像窗体信息 Where 窗体ID=:窗体ID");
            sql.AddParameter("窗体ID", DbType.String, windowId);

            _dbHelper.ExecuteSQL(sql);

            return true;

        }
        /// <summary>
        /// 将角色的窗体ID设置为空
        /// </summary>
        /// <param name="windowId"></param>
        /// <returns></returns>
        public bool UpdateRowWindowID(string windowId)
        {
            SQL sql = SqlHelper.CreateSQL("更新窗体ID", "update 影像角色信息 set 窗体ID ='' Where 窗体ID=:窗体ID");
            sql.AddParameter("窗体ID", DbType.String, windowId);
            _dbHelper.ExecuteSQL(sql);
            return true;

        }

        /// <summary>
        /// 设置主窗体
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="windowId"></param>
        public void SetMainWindow(string roleId, string windowId)
        {
            SQL sql = SqlHelper.CreateSQL("设置角色窗体", "Update 影像角色信息 Set 窗体ID=:窗体ID where 角色ID=:角色ID");
            sql.AddParameter("窗体ID", DbType.String, windowId);
            sql.AddParameter("角色ID", DbType.String, roleId);

            _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 查找角色是否应用窗体，如果应用返回true
        /// </summary>
        /// <param name="serverAlias"></param>
        /// <returns></returns>
        public bool GetRowName(string windowId)
        {
            SQL sql = SqlHelper.CreateSQL("根据窗体ID查询角色", "Select 角色名称 From 影像角色信息 where 窗体ID=:窗体ID ");
            sql.AddParameter("窗体ID", DbType.String, windowId);

            object result = _dbHelper.ExecuteSQLOneOutput(sql);

            return (result == null ? false : true);
        }

        private SqlParamInfo[] GetWindowInfoPars(WindowInfoData roleWindowInfo)
        {
            return new SqlParamInfo[] {
                        new SqlParamInfo("窗体ID", DbType.String, roleWindowInfo.窗体ID),
                        new SqlParamInfo("科室ID", DbType.String, roleWindowInfo.科室ID),
                        new SqlParamInfo("窗体名称", DbType.String, roleWindowInfo.窗体名称),
                        new SqlParamInfo("分组标记", DbType.String, roleWindowInfo.分组标记),
                        new SqlParamInfo("窗体信息", DbType.String, roleWindowInfo.窗体信息.ToString()) };
        }
    }
}
