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
    /// 报告词句分类
    /// </summary>
    public class ReportWordsClassData: ReportWordClassBase, IBizBindRow
    {
        public JReportWordClassInfo 分类信息 { get; set; }

        public ReportWordsClassData(){ } 

        protected override void InitJsonInstance()
        {
            分类信息 = new JReportWordClassInfo();
        }

        protected override  IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JReportWordClassInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JReportWordClassInfo>(jsonData);
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
    /// 报告词句信息
    /// </summary>
    public class ReportWordsInfoData : ReportWordInfoBase, IBizBindRow
    { 
        public JReportWordsInfo 词句信息 { get; set; }

        public ReportWordsInfoData(){ }
         

        protected override void InitJsonInstance()
        {
            词句信息 = new JReportWordsInfo();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JReportWordsInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JReportWordsInfo>(jsonData);
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

    public class ReportWordsModel: DBModel
    {
        public ReportWordsModel(IDBQuery dbHelper) : base(dbHelper) { }


        public DataTable GetSectionNames()
        {
            SQL sql = SqlHelper.CreateSQL("提取词句关联段落名称", "SELECT T.COLUMN_NAME FROM USER_TAB_COLUMNS T WHERE T.TABLE_NAME='影像报告段落' and T.COLUMN_NAME not in ('报告ID','申请ID','删除标记')");

            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 获取影像类别
        /// </summary>
        /// <returns></returns>
        public DataTable GetImageKind()
        {
            SQL sql = SqlHelper.CreateSQL("获取影像类别", "select 影像类别 from 影像设备类别 "); 
             
            return _dbHelper.ExecuteSQL(sql); 
        }

        /// <summary>
        /// 获取词句分类信息
        /// </summary>
        /// <param name="imgKind"></param>
        /// <returns></returns>
        public DataTable GetWordsClass(string imgKind)
        {
            SQL sql = SqlHelper.CreateSQL("获取词句分类", "select 词句分类ID, 上级分类ID, 影像类别, 分类名称, 分类信息 from 影像词句分类 where 影像类别=:影像类别");

            sql.AddParameter("影像类别", DbType.String, imgKind); 

            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 获取分类下的词句
        /// </summary>
        /// <param name="wordClassId"></param>
        /// <returns></returns>
        public DataTable GetWordItemByClass(string wordClassId)
        {
            SQL sql = SqlHelper.CreateSQL("根据分类查询词句项", "select 词句ID, 词句分类ID, 词句名称, 词句信息 from 影像词句信息 where 词句分类ID=:词句分类ID");

            sql.AddParameter("词句分类ID", DbType.String, wordClassId); 

            return _dbHelper.ExecuteSQL(sql);
        }


        /// <summary>
        /// 根据词句分类名称获取ID
        /// </summary>
        /// <param name="className"></param>
        /// <param name="imageKind"></param>
        /// <returns></returns>
        public string GetWordClassIdByName(string className, string imageKind)
        {
            SQL sql =SqlHelper.CreateSQL("根据名称查询词句分类", "select 词句分类ID from 影像词句分类 where 分类名称=:分类名称 and 影像类别=:影像类别");

            sql.AddParameter("分类名称", DbType.String, className);
            sql.AddParameter("影像类别", DbType.String, imageKind); 

            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null ? "" : value.ToString());
        }

        public ReportWordsInfoData GetWordInfoById(string wordId)
        {
            SQL sql = SqlHelper.CreateSQL("根据ID查询词句信息","select 词句ID,词句分类ID,词句名称,词句信息 from 影像词句信息 where 词句DI=:词句ID");

            sql.AddParameter("词句ID", wordId);

            DataTable dtWord = _dbHelper.ExecuteSQL(sql);

            if (dtWord == null || dtWord.Rows.Count <= 0) return null;

            ReportWordsInfoData wordData = new ReportWordsInfoData();
            wordData.BindRowData(dtWord.Rows[0]);

            return wordData;
        }

        /// <summary>
        /// 根据词句名称查询词句ID
        /// </summary>
        /// <param name="wordName"></param>
        /// <returns></returns>
        public string GetWordItemIdByName(string wordName)
        {
            SQL sql = SqlHelper.CreateSQL("根据名称查询词句ID", "select 词句ID from 影像词句信息 where 词句名称=:词句名称");

            sql.AddParameter("词句名称", DbType.String, wordName); 

            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null ? "" : value.ToString());
        }

        /// <summary>
        /// 获取格式关联词句分类
        /// </summary>
        /// <param name="formatId"></param>
        /// <returns></returns>
        public DataTable GetFormatWordClass(string formatId)
        {
            SQL sql = CreateSQL("查询格式关联词句", "Select 关联ID,模板ID,格式ID,词句分类ID from 影像模板词句 where 格式ID=:格式ID");

            sql.AddParameter("格式ID", formatId);

            return sql.ExecuteSql();
        }

        /// <summary>
        /// 获取模板段落
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public JReportTemplateSection GetTemplateSection(string templateId)
        {
            SQL sql = CreateSQL("查询模板关联段落", "Select 关联段落 From 影像模板信息 where 模板ID=:模板ID");
            sql.AddParameter("模板ID", templateId);

            object value = sql.ExecuteSqlOneOutput();

            return (value == null) ? null : JsonHelper.DeserializeObject<JReportTemplateSection>(value.ToString());
        }

        /// <summary>
        /// 获取模板关联词句分类
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public DataTable GetTemplateWordClass(string templateId)
        {
            SQL sql = CreateSQL("查询格式关联词句", "Select 关联ID,模板ID,格式ID,词句分类ID from 影像模板词句 where 模板ID=:模板ID");

            sql.AddParameter("模板ID", templateId);

            return sql.ExecuteSql();
        }

        //public DataTable GetWordsByClass(string wordClassId)
        //{

        //}

        /// <summary>
        /// 新增词句分类
        /// </summary>
        /// <param name="wordClass"></param>
        /// <returns></returns>
        public bool NewWordClass(ReportWordsClassData wordClass)
        {
            SQL sql = SqlHelper.CreateSQL("插入报告词句分类", "insert into 影像词句分类(词句分类ID, 上级分类ID, 影像类别, 分类名称, 分类信息)" +
            "values(:词句分类ID, :上级分类ID, :影像类别, :分类名称, :分类信息)");

            sql.AddParameter("词句分类ID", DbType.String, wordClass.词句分类ID);
            sql.AddParameter("上级分类ID", DbType.String, wordClass.上级分类ID);
            sql.AddParameter("影像类别", DbType.String, wordClass.影像类别);
            sql.AddParameter("分类名称", DbType.String, wordClass.分类名称);
            sql.AddParameter("分类信息", DbType.String, wordClass.分类信息.ToString());

            _dbHelper.ExecuteSQL(sql);

            return true;
        }

        /// <summary>
        /// 删除报告词句分类
        /// </summary>
        /// <param name="wordClassId"></param>
        /// <returns></returns>
        public bool DelWordClass(string wordClassId)
        {
            SQL sql = SqlHelper.CreateSQL("删除报告词句分类", "delete 影像词句分类 where 词句分类ID=:词句分类ID");
            sql.AddParameter("词句分类ID", DbType.String, wordClassId);

            _dbHelper.ExecuteSQL(sql);

            return true;
        }



        /// <summary>
        /// 更新报告词句分类
        /// </summary>
        /// <param name="wordClass"></param>
        /// <returns></returns>
        public bool UpdateWordClass(ReportWordsClassData wordClass)
        {
            SQL sql = SqlHelper.CreateSQL("更新报告词句分类", "update 影像词句分类 set 分类名称=:分类名称, 上级分类ID=:上级分类ID, 分类信息=:分类信息 where 词句分类ID=:词句分类ID");


            sql.AddParameter("分类名称", DbType.String, wordClass.分类名称);
            sql.AddParameter("上级分类ID", DbType.String, wordClass.上级分类ID);
            sql.AddParameter("分类信息", DbType.String, wordClass.分类信息.ToString());
            sql.AddParameter("词句分类ID", DbType.String, wordClass.词句分类ID);

            _dbHelper.ExecuteSQL(sql);

            return true;

        }



        /// <summary>
        /// 新增报告词句
        /// </summary>
        /// <param name="wordItem"></param>
        /// <returns></returns>
        public bool NewWordItem(ReportWordsInfoData wordItem)
        {
            SQL sql =SqlHelper.CreateSQL("插入报告词句信息", "insert into 影像词句信息(词句ID, 词句分类ID, 词句名称, 词句信息)" +
                        "values(:词句ID, :词句分类ID, :词句名称, :词句信息)");

            sql.AddParameter("词句ID", DbType.String, wordItem.词句ID);
            sql.AddParameter("词句分类ID", DbType.String, wordItem.词句分类ID);
            sql.AddParameter("词句名称", DbType.String, wordItem.词句名称);
            sql.AddParameter("词句信息", DbType.String, wordItem.词句信息.ToString()); 

            _dbHelper.ExecuteSQL(sql);

            return true;
        }

        /// <summary>
        /// 删除报告词句
        /// </summary>
        /// <param name="wordItemId"></param>
        public bool DelWordItem(string wordItemId)
        {
            SQL sql =SqlHelper.CreateSQL("删除报告词句信息", "delete 影像词句信息 where 词句ID=:词句ID");
            sql.AddParameter("词句ID", DbType.String, wordItemId);

            _dbHelper.ExecuteSQL(sql);

            return true;
        }

        /// <summary>
        /// 更新报告词句
        /// </summary>
        /// <param name="wordItem"></param>
        /// <returns></returns>
        public bool UpdateWordItem(ReportWordsInfoData wordItem)
        {
            SQL sql =SqlHelper.CreateSQL("更新报告词句信息", "update 影像词句信息 set 词句名称=:词句名称, 词句分类ID=:词句分类ID, 词句信息=:词句信息 where 词句ID=:词句ID");

            sql.AddParameter("词句名称", DbType.String, wordItem.词句名称);
            sql.AddParameter("词句分类ID", DbType.String, wordItem.词句分类ID);
            sql.AddParameter("词句信息", DbType.String, wordItem.词句信息.ToString());
            sql.AddParameter("词句ID", DbType.String, wordItem.词句ID);

            _dbHelper.ExecuteSQL(sql);

            return true;

        }
    }
}
