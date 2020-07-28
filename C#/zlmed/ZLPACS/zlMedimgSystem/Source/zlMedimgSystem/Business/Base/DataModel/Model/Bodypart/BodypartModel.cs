using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
    /// <summary>
    /// 部位信息数据
    /// </summary>
    public class BodypartInfoData: BodypartBase, IBizBindRow
    { 
        public JBodypartInfo 部位信息 { get; set; }
                 
        protected override void InitJsonInstance()
        {
            部位信息 = new JBodypartInfo();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JBodypartInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JBodypartInfo>(jsonData);
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
    /// 部位数据操作模型
    /// </summary>
    public class BodypartModel: DBModel
    {
        public BodypartModel(IDBQuery dbHelper) : base(dbHelper) { }

        /// <summary>
        /// 获取影像类别
        /// </summary>
        /// <returns></returns>
        public DataTable GetImageKind()
        {
            SQL sql = SqlHelper.CreateSQL("查询影像类别", "select 影像类别 from 影像设备类别 order by 影像类别");

            DataTable dtResult = _dbHelper.ExecuteSQL(sql);
 
            return dtResult;
        }
        /// <summary>
        /// 获取性别
        /// </summary>
        /// <returns></returns>
        public JDictionary GetSex()
        {
            SQL sql = SqlHelper.CreateSQL("查询字典性别信息", "select 字典信息 from 影像字典信息 where 字典名称='性别'");

            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null) ? null : JsonHelper.DeserializeObject<JDictionary>(value.ToString());
            
        }

        /// <summary>
        /// 获取影像类别下所有部位信息
        /// </summary>
        /// <param name="imageKind"></param>
        /// <returns></returns>
        public DataTable GetAllBodypartInfo(string imageKind)
        {
            string sql = "select 部位ID,影像类别,部位名称,分组标记,部位信息" +
                        " from 影像部位信息 " +
                        " where 影像类别=:影像类别 order by 分组标记,部位名称";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询检查部位信息", sql);

            return _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("影像类别", DbType.String, imageKind)});

        }

        /// <summary>
        /// 新增部位信息
        /// </summary>
        /// <param name="bodypartData"></param>
        /// <returns></returns>
        public bool NewBodypartInfo(BodypartInfoData bodypartData)
        {
            string sql = "insert into 影像部位信息(部位ID, 影像类别, 部位名称, 分组标记, 部位信息)" +
                        "values(:部位ID, :影像类别, :部位名称, :分组标记, :部位信息)";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("插入检查部位信息", sql);

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("部位ID", DbType.String, bodypartData.部位ID),
                                                        new SqlParamInfo("影像类别", DbType.String, bodypartData.影像类别),
                                                        new SqlParamInfo("部位名称", DbType.String, bodypartData.部位名称),
                                                        new SqlParamInfo("分组标记", DbType.String, bodypartData.分组标记),
                                                        new SqlParamInfo("部位信息", DbType.String, bodypartData.部位信息.ToString())};

            _dbHelper.ExecuteSQL(sql, sqlPars);

            return true;
        }

        /// <summary>
        /// 删除部位信息
        /// </summary>
        /// <param name="bodypartInfoId"></param>
        public bool DelBodypartInfo(string bodypartInfoId)
        {
            string sql = "delete 影像部位信息 where 部位ID=:部位ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("删除检查部位信息", sql);

            _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("部位ID", DbType.String, bodypartInfoId)});

            return true;
        }

        /// <summary>
        /// 更新部位信息
        /// </summary>
        /// <param name="bodypartData"></param>
        /// <returns></returns>
        public bool UpdateBodypartInfo(BodypartInfoData bodypartData)
        {
            string sql = "update 影像部位信息 set 部位名称=:部位名称, 分组标记=:分组标记, 部位信息=:部位信息 where 部位ID=:部位ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("更新检查部位信息", sql);

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("部位名称", DbType.String, bodypartData.部位名称),
                                                            new SqlParamInfo("分组标记", DbType.String, bodypartData.分组标记),
                                                            new SqlParamInfo("部位信息", DbType.String, bodypartData.部位信息.ToString()),
                                                            new SqlParamInfo("部位ID", DbType.String, bodypartData.部位ID)};

            _dbHelper.ExecuteSQL(sql, sqlPars);

            return true;

        }

        /// <summary>
        /// 更新部位方法
        /// </summary>
        /// <param name="bodypartData"></param>
        /// <returns></returns>
        public bool UpdateBodypartWay(BodypartInfoData bodypartData)
        {
            string sql = "update 影像部位信息 set 部位信息=:部位信息 where 部位ID=:部位ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("更新检查部位方法", sql);

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("部位信息", DbType.String, bodypartData.部位信息.ToString()),
                                                            new SqlParamInfo("部位ID", DbType.String, bodypartData.部位ID)};

            _dbHelper.ExecuteSQL(sql, sqlPars);

            return true;
        }


        /// <summary>
        /// 获取部位信息ID
        /// </summary>
        /// <param name="imageKind"></param>
        /// <param name="bodypartName"></param>
        /// <returns></returns>
        public string GetBodypartInfoId(string imageKind, string bodypartName)
        {
            string sql = "select 部位ID from 影像部位信息 where 影像类别=:影像类别 and 部位名称=:部位名称";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("获取检查部位ID", sql);

            object value = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] {new SqlParamInfo("影像类别", DbType.String, imageKind),
                                                                                new SqlParamInfo("部位名称", DbType.String, bodypartName) });
            return (value == null ? "" : value.ToString());

        }

        public DataTable GetBodypartGroups(string imageKind)
        {
            string sql = "select Distinct 分组标记 from 影像部位信息 where 影像类别=:影像类别";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("获取检查部位分组", sql);

            return _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("影像类别", DbType.String, imageKind) });
        }

        /// <summary>
        /// 根据部位ID，查询部位信息
        /// </summary>
        /// <param name="bodypartID"></param>
        /// <returns></returns>
        public DataTable GetBodypartInfoByID(string bodypartID)
        {
            SQL sql = SqlHelper.CreateSQL("根据部位ID提取部位信息", "select a.部位id,a.影像类别,a.部位名称,a.分组标记,a.部位信息 from 影像部位信息 a where a.部位id = :部位id");

            sql.AddParameter("部位id", DbType.String, bodypartID);
            return _dbHelper.ExecuteSQL(sql);
        }

    }
}
