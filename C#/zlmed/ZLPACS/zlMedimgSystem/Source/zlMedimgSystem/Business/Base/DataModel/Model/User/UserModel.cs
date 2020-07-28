using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{

    public class UserReleationData: UserReleationBase, IBizBindRow
    {        
      
    }


    public class UserInfoData : UserBase, IBizBindRow
    { 
        public JAccountInfo 账号信息 { get; set; }

        public JUserInfo 人员信息 { get; set; }

        public IList<JAlterLog> 变更日志 { get; set; }


        protected override void InitJsonInstance()
        {
            账号信息 = new JAccountInfo();
            人员信息 = new JUserInfo();
            变更日志 = new List<JAlterLog>();
        }

 
        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JAccountInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JAccountInfo>(jsonData);
                }
                else if(jsonTypeName == typeof(JUserInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JUserInfo>(jsonData);
                }
                else if(jsonTypeName == typeof(JAlterLog).FullName)
                {
                    return JsonHelper.DeserializeObject<JAlterLog>(jsonData);
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



    public class UserModel : DBModel
    {
        private const string Encrypt_Key = "DFF6967A-3786-4026-B412-B6D09E2DD6A0";

        public const string ADMIN_ID = "/0000000000/0000000000";
        public const string ADMIN_NAME = "ADMIN";
         
        public UserModel(IDBQuery dbHelper) : base(dbHelper)
        { 
        }


        /// <summary>
        /// 获取科室信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepartment()
        {
            SQL sql = SqlHelper.Statement.科室信息查询;

            return _dbHelper.ExecuteSQL(sql); 
        }

        /// <summary>
        /// 查询角色信息
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
        /// 获取用户信息
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public DataTable GetDepartmentUsers(string departmentId)
        {
            string sql = "Select a.用户关联ID, a.科室Id, a.用户ID, a.角色ID, b.系统账号, b.用户名称, 职称级别, c.角色名称, " +
                        " b.签名图片,b.人员照片,b.账号信息, b.人员信息, b.变更日志 " +
                        " From 影像用户关联 a, 影像用户信息 b, 影像角色信息 c " +
                        " where a.用户ID=b.用户ID and a.角色ID=c.角色ID(+) and  a.科室ID=:科室ID  order by 系统账号";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询科室用户信息", sql);

            return _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("科室ID", DbType.String, departmentId) });
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="hisServerData"></param>
        /// <returns></returns>
        public bool NewUser(UserInfoData userInfo, UserReleationData userReleation)
        {
            //添加事务处理
            _dbHelper.TransactionBegin();
            try
            {
                string sql = "insert into " +
                      " 影像用户信息(用户ID, 系统账号, 用户名称, 职称级别,账号信息, 人员信息, 签名图片, 人员照片) " +
                      " values " +
                      " (:用户ID, :系统账号,  :用户名称, :职称级别, :账号信息, :人员信息, empty_blob(), empty_blob())";
                sql = SqlHelper.GetSqlBiz().GetSqlContext("插入科室用户信息", sql);

                SqlParamInfo[] sqlPars = GetUserInfoPars(userInfo);

                DataTable dtResult = _dbHelper.ExecuteSQL(sql, sqlPars);

                if (userReleation != null)
                {
                    //创建用户关联
                    sql = "insert into " +
                        " 影像用户关联(用户关联ID, 用户ID, 科室ID, 角色ID ) " +
                        " values " +
                        " (:用户关联ID, :用户ID, :科室ID, :角色ID) ";
                    sql = SqlHelper.GetSqlBiz().GetSqlContext("插入科室用户关联", sql);

                    SqlParamInfo[] sqlReleationPars = GetUserReleationPars(userReleation);
                    dtResult = _dbHelper.ExecuteSQL(sql, sqlReleationPars);

                }

                UpdatePhoto(userInfo);
                _dbHelper.TransactionCommit();
                return true;
            }catch(Exception ex)
            {
                _dbHelper.TransactionRollback();
                throw new Exception("添加账户失败",ex);

            }
        }



        /// <summary>
        /// 更新照片(签名照片和人员照片)
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool UpdatePhoto(UserInfoData userInfo)
        {

            //sql = "update 影像用户信息 set 签名图片=empty_blob(), 人员照片=empty_blob() where 用户ID=:用户ID";
            //sql = SqlHelper.GetSqlBiz().GetSqlContext("清除科室用户图形", sql);
            //_dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("用户ID", DbType.String, userInfo.用户ID) });

            if (userInfo.签名图片 != null)
            {
                SQL sqlSignPhoto = CreateSQL("更新科室用户签名图片", "update 影像用户信息 set 签名图片=:签名图片 where 用户ID=:用户ID");

                sqlSignPhoto.AddParameter("签名图片", DbType.Binary, SqlHelper.ImageToBinary(userInfo.签名图片));
                sqlSignPhoto.AddParameter("用户ID", DbType.String, userInfo.用户ID);

                sqlSignPhoto.ExecuteSql(); 
            }
            

            if (userInfo.人员照片 != null)
            {
                SQL sqlUserPhoto = CreateSQL("更新科室用户人员照片", "update 影像用户信息 set 人员照片=:人员照片 where 用户ID=:用户ID");

                sqlUserPhoto.AddParameter("人员照片", DbType.Binary, SqlHelper.ImageToBinary(userInfo.人员照片));
                sqlUserPhoto.AddParameter("用户ID", DbType.String, userInfo.用户ID);

                sqlUserPhoto.ExecuteSql();
            }

            return true;

        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="hisServerData"></param>
        public void UpdateUserInfo(UserInfoData userInfo, UserReleationData userReleation)
        {
            //添加事务处理
            _dbHelper.TransactionBegin();
            try
            {
                string sql = "Update 影像用户信息 " +
                        " Set 系统账号=:系统账号, 用户名称=:用户名称, 职称级别=:职称级别, 账号信息=:账号信息,人员信息=:人员信息" + //,变更日志=:变更日志 " +
                        " where 用户ID=:用户ID ";
                sql = SqlHelper.GetSqlBiz().GetSqlContext("更新科室用户信息", sql);

                SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("系统账号", DbType.String, userInfo.系统账号),
                                                            new SqlParamInfo("用户名称", DbType.String, userInfo.用户名称),
                                                            new SqlParamInfo("职称级别", DbType.Int32, userInfo.职称级别),
                                                            new SqlParamInfo("账号信息", DbType.String, userInfo.账号信息.ToString()),
                                                            new SqlParamInfo("人员信息", DbType.String, userInfo.人员信息.ToString()),
                                                            //new SqlParamInfo("变更日志", DbType.String, JsonHelper.SerializeObject(userInfo.变更日志)),
                                                            new SqlParamInfo("用户ID", DbType.String, userInfo.用户ID)};

                _dbHelper.ExecuteSQL(sql, sqlPars);


                //更新角色关联
                if (userReleation != null)
                {
                    sql = "update 影像用户关联 " +
                        " set 角色ID=:角色ID " +
                        " where 用户ID=:用户ID and 科室ID=:科室ID";
                    sql = SqlHelper.GetSqlBiz().GetSqlContext("更新科室用户关联", sql);

                    sqlPars = new SqlParamInfo[] { new SqlParamInfo("角色ID", DbType.String, userReleation.角色ID),
                                                            new SqlParamInfo("用户ID", DbType.String, userInfo.用户ID),
                                                            new SqlParamInfo("科室ID", DbType.String, userReleation.科室ID)};

                    _dbHelper.ExecuteSQL(sql, sqlPars);
                }


                //更新照片
                UpdatePhoto(userInfo);
                _dbHelper.TransactionCommit();
            }
            catch (Exception ex)
            {
                _dbHelper.TransactionRollback();
                throw new Exception("保存账户信息失败", ex);
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="serverID"></param>
        /// <returns></returns>
        public bool DelUserInfo(string departmentID, string userID)
        {
            _dbHelper.TransactionBegin();

            try
            {

                string sql = "Delete 影像用户关联 Where 科室ID=:科室ID and 用户ID=:用户ID";
                sql = SqlHelper.GetSqlBiz().GetSqlContext("删除科室用户关联", sql);

                _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("科室ID", DbType.String, departmentID),
                                        new SqlParamInfo("用户ID", DbType.String, userID) });

                //查询是否还存在用户关联
                sql = "select count(1) as 数量 from 影像用户关联 where 用户ID=:用户ID";
                sql = SqlHelper.GetSqlBiz().GetSqlContext("查询科室用户关联数量", sql);

                object value = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] { new SqlParamInfo("用户ID", DbType.String, userID) });
                if (value != null)
                {
                    if (Convert.ToInt32(value) <= 0)
                    {
                        //删除用户信息
                        sql = "delete 影像用户信息 where 用户ID=:用户ID";
                        sql = SqlHelper.GetSqlBiz().GetSqlContext("删除科室用户信息", sql);

                        _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("用户ID", DbType.String, userID) });
                    }
                }

                _dbHelper.TransactionCommit();

                return true;
            }
            catch(Exception ex)
            {
                _dbHelper.TransactionRollback();

                throw new Exception("用户删除失败。", ex);

            } 

        }

        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <param name="serverAlias"></param>
        /// <returns></returns>
        public string GetUserIDWithAccountName(string accountName)
        {
            string sql = "Select 用户ID From 影像用户信息 where 系统账号=:系统账号";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("获取科室用户ID", sql);

            object result = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] { new SqlParamInfo("系统账号", DbType.String, accountName) });

            return (result == null ? "" : result.ToString());
        }

        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <param name="serverAlias"></param>
        /// <returns></returns>
        public string GetUserIDWithUserName(string userName, string departmentId)
        {
            string sql = "Select a.用户ID From 影像用户关联 a, 影像用户信息 b where a.用户ID=b.用户ID and a.科室ID=:科室ID and b.用户名称=:用户名称";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("获取科室用户ID", sql);

            object result = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] { new SqlParamInfo("科室ID", DbType.String, departmentId),
                                                                                    new SqlParamInfo("用户名称", DbType.String, userName)});

            return (result == null ? "" : result.ToString());
        }



        private SqlParamInfo[] GetUserInfoPars(UserInfoData userInfo)
        {

            return new SqlParamInfo[] {
                        new SqlParamInfo("用户ID", DbType.String, userInfo.用户ID),
                        new SqlParamInfo("系统账号", DbType.String, userInfo.系统账号),
                        new SqlParamInfo("用户名称", DbType.String, userInfo.用户名称),
                        new SqlParamInfo("职称级别", DbType.Int32, userInfo.职称级别),
                        new SqlParamInfo("账号信息", DbType.String, userInfo.账号信息.ToString()),
                        new SqlParamInfo("人员信息", DbType.String, userInfo.人员信息.ToString())};
        }

        private SqlParamInfo[] GetUserReleationPars(UserReleationData userReleation)
        {
            return new SqlParamInfo[] {
                        new SqlParamInfo(":用户关联ID", DbType.String, userReleation.用户关联ID),
                        new SqlParamInfo(":用户ID", DbType.String, userReleation.用户ID),
                        new SqlParamInfo(":科室ID", DbType.String, userReleation.科室ID),
                        new SqlParamInfo(":角色ID", DbType.String, userReleation.角色ID)};
        }

        public UserInfoData GetUserInfoByAccountName(string accountName)
        {
            SQL sql = SqlHelper.CreateSQL("根据用户账号查询影像用户信息", "select 用户ID,系统账号, 用户名称, 职称级别, 账号信息, 人员信息, 人员照片, 签名图片,变更日志 from 影像用户信息 where 系统账号=:系统账号");
            sql.AddParameter("系统账号", System.Data.DbType.String, accountName);

            DataTable dtUser = _dbHelper.ExecuteSQL(sql);

            if (dtUser == null || dtUser.Rows.Count <= 0) return null;

            UserInfoData result = new UserInfoData();
            result.BindRowData(dtUser.Rows[0]);
             
            return result;
        }

        /// <summary>
        /// 根据名称获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public UserInfoData GetUserInfoByUserName(string userName, string departmentId)
        {
            SQL sql = SqlHelper.CreateSQL("根据用户账号查询影像用户信息", "select a.用户ID,a.系统账号, a.用户名称, a.职称级别, a.账号信息, a.人员信息, a.人员照片, a.签名图片,a.变更日志 " +
                                            " from 影像用户关联 a, 影像用户信息 b where a.用户ID=b.用户ID and a.科室ID=:科室ID and b.用户名称=:用户名称");

            sql.AddParameter("用户名称", System.Data.DbType.String, userName);
            sql.AddParameter("科室ID", System.Data.DbType.String, departmentId);

            DataTable dtUser = _dbHelper.ExecuteSQL(sql);

            if (dtUser == null || dtUser.Rows.Count <= 0) return null;

            UserInfoData result = new UserInfoData();
            result.BindRowData(dtUser.Rows[0]);

            return result;
        }


        public UserInfoData GetUserInfoByUserID(string userId)
        {
            SQL sql = SqlHelper.CreateSQL("根据用户ID查询影像用户信息", "select 用户ID,系统账号, 用户名称, 职称级别, 账号信息, 人员信息, 人员照片, 签名图片,变更日志 from 影像用户信息 where 用户ID=:用户ID");
            sql.AddParameter("用户ID", System.Data.DbType.String, userId);

            DataTable dtUser = _dbHelper.ExecuteSQL(sql);

            if (dtUser == null || dtUser.Rows.Count <= 0) return null;

            UserInfoData result = new UserInfoData();
            result.BindRowData(dtUser.Rows[0]);

            return result;
        }

        /// <summary>
        /// 获取用户所属科室角色信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<UserReleationData> GetUserDepartmentRoleInfos(string userId)
        {
            SQL sql = new SQL("获取用户所属科室角色信息", "select 用户关联ID, 用户ID, 科室ID, 角色ID from 影像用户关联 where 用户Id=:用户ID");
            sql.AddParameter("用户ID", DbType.String, userId);

            DataTable dtReleation = _dbHelper.ExecuteSQL(sql);
            if (dtReleation == null || dtReleation.Rows.Count <= 0) return null;

            List<UserReleationData> urds = new List<UserReleationData>();

            foreach(DataRow dr in dtReleation.Rows)
            {
                UserReleationData urd = new UserReleationData();
                urd.BindRowData(dr);

                urds.Add(urd);
            }

            return urds;
        }

        static public string EncryPwd(string pwd)
        {
            Encrypt enc = new Encrypt(Encrypt_Key, false);
            return enc.EncryptStr(pwd);
        }

        static public string DecryPwd(string pwd)
        {
            try
            {
                Encrypt enc = new Encrypt(Encrypt_Key, false);
                return enc.DecryptStr(pwd);
            }
            catch
            {
                return pwd;
            }
        }
    }
}
