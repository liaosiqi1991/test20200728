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
    /// datarow对应类的 项目分类数据定义
    /// </summary>
    public class ExamClassData : ExamClassBase
    {
        public JExamClassInfo 分类信息 { get; set; }

        public ExamClassData() { }

        protected override void InitJsonInstance()
        {
            分类信息 = new JExamClassInfo();
        }


        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JExamClassInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JExamClassInfo>(jsonData);
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
    /// 检查项目数据
    /// </summary>
    public class ExamItemData: ExamItemBase, IBizBindRow
    {
        public JExamItemInfo 项目信息 { get; set; }

        public JExamBindExpense 绑费信息 { get; set; }

        public ExamItemData() 
        {
        }         
        protected override void InitJsonInstance()
        {
            项目信息 = new JExamItemInfo();
            绑费信息 = new JExamBindExpense();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            IJsonField deaultJsonObj = null;
            try
            {
                if (jsonTypeName == typeof(JExamItemInfo).FullName)
                {
                    deaultJsonObj = new JExamItemInfo();
                    return JsonHelper.DeserializeObject<JExamItemInfo>(jsonData);
                }
                else if (jsonTypeName == typeof(JExamBindExpense).FullName)
                {
                    deaultJsonObj = new JExamBindExpense();
                    return JsonHelper.DeserializeObject<JExamBindExpense>(jsonData);
                }

                return null;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, null);
                return deaultJsonObj;
            }
        }
    }


    /// <summary>
    /// 检查项目模型
    /// </summary>
    public class ExamItemModel : DBModel
    {

        public ExamItemModel(IDBQuery dbHelper) : base(dbHelper) { }


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

            return _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("影像类别", DbType.String, imageKind) });

        }

        /// <summary>
        /// 获取部位分组
        /// </summary>
        /// <param name="imageKind"></param>
        /// <returns></returns>
        public DataTable GetBodypartGroups(string imageKind)
        {
            string sql = "select Distinct 分组标记 from 影像部位信息 where 影像类别=:影像类别";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("获取检查部位分组", sql);

            return _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("影像类别", DbType.String, imageKind) });
        }

        /// <summary>
        /// 根据分类名称获取ID
        /// </summary>
        /// <param name="className"></param>
        /// <param name="imageKind"></param>
        /// <returns></returns>
        public string GetExamClassIdByName(string className, string imageKind)
        {
            string sql = "select 项目分类ID from 影像项目分类 where 分类名称=:分类名称 and 影像类别=:影像类别";

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("分类名称", DbType.String, className),
                                                            new SqlParamInfo("影像类别", DbType.String, imageKind)};
            sql = SqlHelper.GetSqlBiz().GetSqlContext("根据名称查询影像分类", sql);

            object value = _dbHelper.ExecuteSQLOneOutput(sql, sqlPars);

            return (value == null ? "" : value.ToString()); 
        }

        /// <summary>
        /// 根据项目名称查询项目ID
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public string GetExamItemIdByName(string itemName)
        {
            string sql = "select 项目ID from 影像项目信息 where 项目名称=:项目名称";

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("项目名称", DbType.String, itemName) };
            sql = SqlHelper.GetSqlBiz().GetSqlContext("根据名称查询影像项目", sql);

            object value = _dbHelper.ExecuteSQLOneOutput(sql, sqlPars);

            return (value == null ? "" : value.ToString());
        }

        /// <summary>
        /// 获取影像分类信息
        /// </summary>
        /// <param name="imgKind"></param>
        /// <returns></returns>
        public DataTable GetExamClass(string imgKind)
        {
            string sql = "select 项目分类ID, 上级分类ID, 影像类别, 分类名称, 分类信息 from 影像项目分类 where 影像类别=:影像类别";

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("影像类别", DbType.String, imgKind) };
            sql = SqlHelper.GetSqlBiz().GetSqlContext("根据类别查询影像分类", sql);

            return _dbHelper.ExecuteSQL(sql, sqlPars);
        }

        /// <summary>
        /// 获取分类下的项目
        /// </summary>
        /// <param name="examClassId"></param>
        /// <returns></returns>
        public DataTable GetExamItemByClass(string examClassId)
        {
            string sql = "select 项目ID, 项目分类ID, 项目名称, 项目信息, 绑费信息 from 影像项目信息 where 项目分类ID=:项目分类ID";

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("项目分类ID", DbType.String, examClassId) };
            sql = SqlHelper.GetSqlBiz().GetSqlContext("根据分类查询影像项目", sql);

            return _dbHelper.ExecuteSQL(sql, sqlPars);
        }

        /// <summary>
        /// 新增项目分类
        /// </summary>
        /// <param name="examClass"></param>
        /// <returns></returns>
        public bool NewExamClass(ExamClassData examClass)
        {
            string sql = "insert into 影像项目分类(项目分类ID, 上级分类ID, 影像类别, 分类名称, 分类信息)" +
            "values(:项目分类ID, :上级分类ID, :影像类别, :分类名称, :分类信息)";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("插入检查项目分类", sql);

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("项目分类ID", DbType.String, examClass.项目分类ID),
                                                        new SqlParamInfo("上级分类ID", DbType.String, examClass.上级分类ID),
                                                        new SqlParamInfo("影像类别", DbType.String, examClass.影像类别),
                                                        new SqlParamInfo("分类名称", DbType.String, examClass.分类名称),
                                                        new SqlParamInfo("分类信息", DbType.String, examClass.分类信息.ToString())};

            _dbHelper.ExecuteSQL(sql, sqlPars);

            return true;
        }

        /// <summary>
        /// 删除检查项目分类
        /// </summary>
        /// <param name="examClassId"></param>
        /// <returns></returns>
        public bool DelExamClass(string examClassId)
        {
            string sql = "delete 影像项目分类 where 项目分类ID=:项目分类ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("删除检查项目分类", sql);

            _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("项目分类ID", DbType.String, examClassId) });

            return true;
        }



        /// <summary>
        /// 更新检查项目分类
        /// </summary>
        /// <param name="examClass"></param>
        /// <returns></returns>
        public bool UpdateExamClass(ExamClassData examClass)
        {
            string sql = "update 影像项目分类 set 分类名称=:分类名称, 项目分类ID=:项目分类ID, 分类信息=:分类信息 where 项目分类ID=:项目分类ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("更新检查项目分类", sql);

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("分类名称", DbType.String, examClass.分类名称),
                                                            new SqlParamInfo("项目分类ID", DbType.String, examClass.项目分类ID),
                                                            new SqlParamInfo("分类信息", DbType.String, examClass.分类信息.ToString()),
                                                            new SqlParamInfo("项目分类ID", DbType.String, examClass.项目分类ID)};

            _dbHelper.ExecuteSQL(sql, sqlPars);

            return true;

        }




        /// <summary>
        /// 新增检查项目
        /// </summary>
        /// <param name="examItem"></param>
        /// <returns></returns>
        public bool NewExamItem(ExamItemData examItem)
        {
            //暂时没有绑费信息，绑费信息固定插入空
            string sql = "insert into 影像项目信息(项目ID, 项目分类ID, 项目名称, 项目信息, 绑费信息)" +
                        "values(:项目ID, :项目分类ID, :项目名称, :项目信息, null)";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("插入检查项目信息", sql);

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("项目ID", DbType.String, examItem.项目ID),
                                                        new SqlParamInfo("项目分类ID", DbType.String, examItem.项目分类ID),
                                                        new SqlParamInfo("项目名称", DbType.String, examItem.项目名称),
                                                        new SqlParamInfo("项目信息", DbType.String, examItem.项目信息.ToString()) };
                                                        //new SqlParamInfo("绑费信息", DbType.String, examItem.绑费信息.ToString())};

            _dbHelper.ExecuteSQL(sql, sqlPars);

            return true;
        }

        /// <summary>
        /// 删除检查项目
        /// </summary>
        /// <param name="examItemId"></param>
        public bool DelExamItem(string examItemId)
        {
            string sql = "delete 影像项目信息 where 项目ID=:项目ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("删除检查项目信息", sql);

            _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("项目ID", DbType.String, examItemId) });

            return true;
        }

        /// <summary>
        /// 更新检查项目
        /// </summary>
        /// <param name="examItem"></param>
        /// <returns></returns>
        public bool UpdateExamItem(ExamItemData examItem)
        {
            string sql = "update 影像项目信息 set 项目名称=:项目名称, 项目分类ID=:项目分类ID, 项目信息=:项目信息 where 项目ID=:项目ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("更新检查项目信息", sql);

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("项目名称", DbType.String, examItem.项目名称),
                                                            new SqlParamInfo("项目分类ID", DbType.String, examItem.项目分类ID),
                                                            new SqlParamInfo("项目信息", DbType.String, examItem.项目信息.ToString()),
                                                            new SqlParamInfo("项目ID", DbType.String, examItem.项目ID)};

            _dbHelper.ExecuteSQL(sql, sqlPars);

            return true;

        }
    }
}
