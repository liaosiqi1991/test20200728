using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using System.Data;
using System.Data.SqlClient;

namespace zlMedimgSystem.DataModel
{
    /// <summary>
    /// 报告模板分类
    /// </summary>
    public class ReportTemplateClassData : ReportTemplateClassBase, IBizBindRow
    {
        public JReportTemplateClassInfo 分类信息 { get; set; }

        public ReportTemplateClassData() { }

        protected override void InitJsonInstance()
        {
            分类信息 = new JReportTemplateClassInfo();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JReportTemplateClassInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JReportTemplateClassInfo>(jsonData);
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

    public class ReportTemplateWordData: ReportTemplateWordBase, IBizBindRow
    {

    }

    /// <summary>
    /// 报告模板信息
    /// </summary>
    public class ReportTemplateItemData : ReportTemplateItemBase, IBizBindRow
    {
        public JReportTemplateItemInfo 模板信息 { get; set; }
        public JReportTemplateDataInfo 数据来源 { get; set; }
        //public JReportTemplateWords 关联词句 { get; set; }

        public JReportTemplateSection 关联段落 { get; set; }

        public ReportTemplateItemData() { }


        protected override void InitJsonInstance()
        {
            模板信息 = new JReportTemplateItemInfo();
            数据来源 = new JReportTemplateDataInfo();
            //关联词句 = new JReportTemplateWords();
            关联段落 = new JReportTemplateSection();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JReportTemplateItemInfo).FullName)
                {
                    //模板信息
                    return JsonHelper.DeserializeObject<JReportTemplateItemInfo>(jsonData);
                }
                else if (jsonTypeName == typeof(JReportTemplateDataInfo).FullName)
                {
                    //数据来源
                    return JsonHelper.DeserializeObject<JReportTemplateDataInfo>(jsonData);
                }
                //else if (jsonTypeName == typeof(JReportTemplateWords).FullName)
                //{
                //    //关联词句
                //    return JsonHelper.DeserializeObject<JReportTemplateWords>(jsonData);
                //}
                else if (jsonTypeName == typeof(JReportTemplateSection).FullName)
                {
                    //关联段落
                    return JsonHelper.DeserializeObject<JReportTemplateSection>(jsonData);
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
    /// 报告格式信息
    /// </summary>
    public class ReportTemplateFormatData : ReportTemplateFormtBase, IBizBindRow
    {
        public JReportTemplateFormatInfo 格式信息 { get; set; }
        //public JReportTemplateWords 关联词句 { get; set; }

        public ReportTemplateFormatData() { }


        protected override void InitJsonInstance()
        {
            格式信息 = new JReportTemplateFormatInfo();
            //关联词句 = new JReportTemplateWords();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JReportTemplateFormatInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JReportTemplateFormatInfo>(jsonData);
                }
                //else if (jsonTypeName == typeof(JReportTemplateWords).FullName)
                //{
                //    return JsonHelper.DeserializeObject<JReportTemplateWords>(jsonData);
                //}

                return null;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, null);
                return null;
            }
        }
    }


    public class ReportTemplateModel : DBModel
    {
        public ReportTemplateModel(IDBQuery dbHelper) : base(dbHelper) { }

        /// <summary>
        /// 获取影像类别
        /// </summary>
        /// <returns></returns>
        public DataTable GetImageKind()
        {
            SQL sql = SqlHelper.CreateSQL("获取影像类别", "select 影像类别 from 影像设备类别 ");

            return _dbHelper.ExecuteSQL(sql);
        }

        public DataTable GetSectionNames()
        {
            SQL sql = SqlHelper.CreateSQL("提取报告预设段落名称", "SELECT T.COLUMN_NAME FROM USER_TAB_COLUMNS T WHERE T.TABLE_NAME='影像报告段落' and T.COLUMN_NAME not in ('报告ID','申请ID','删除标记')");

            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 获取模板分类信息
        /// </summary>
        /// <param name="imgKind"></param>
        /// <returns></returns>
        public DataTable GetTemplateClass(string imgKind)
        {
            SQL sql = SqlHelper.CreateSQL("获取模板分类", "select 模板分类ID, 上级分类ID, 影像类别, 分类名称, 分类信息 from 影像模板分类 where 影像类别=:影像类别");

            sql.AddParameter("影像类别", DbType.String, imgKind);

            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 获取分类下的模板
        /// </summary>
        /// <param name="templateClassId">模板分类ID</param>
        /// <returns></returns>
        public DataTable GetTemplateItemsByClass(string templateClassId)
        {
            SQL sql = SqlHelper.CreateSQL("根据分类查询模板项", "select 模板ID, 模板分类ID, 模板名称, 模板信息, 版本,数据来源,关联段落 from 影像模板信息 where 模板分类ID=:模板分类ID");//关联词句,

            sql.AddParameter("模板分类ID", DbType.String, templateClassId);

            return _dbHelper.ExecuteSQL(sql);
        }


        /// <summary>
        /// 根据模板分类名称获取ID
        /// </summary>
        /// <param name="className"></param>
        /// <param name="imageKind"></param>
        /// <returns></returns>
        public string GetTemplateClassIdByName(string className, string imageKind)
        {
            SQL sql = SqlHelper.CreateSQL("根据名称查询模板分类ID", "select 模板分类ID from 影像模板分类 where 分类名称=:分类名称 and 影像类别=:影像类别");

            sql.AddParameter("分类名称", DbType.String, className);
            sql.AddParameter("影像类别", DbType.String, imageKind);

            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null ? "" : value.ToString());
        }

        /// <summary>
        /// 根据模板名称查询模板ID
        /// </summary>
        /// <param name="templateItemName"></param>
        /// <returns></returns>
        public string GetTemplateItemIdByName(string templateItemName)
        {
            SQL sql = SqlHelper.CreateSQL("根据名称查询模板ID", "select 模板ID from 影像模板信息 where 模板名称=:模板名称");

            sql.AddParameter("模板名称", DbType.String, templateItemName);

            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null ? "" : value.ToString());
        }


        /// <summary>
        /// 获取模板下的格式
        /// </summary>
        /// <param name="templateItemId">模板分类ID</param>
        /// <returns></returns>
        public DataTable GetTemplateFormatsByTemplate(string templateItemId)
        {
            SQL sql = SqlHelper.CreateSQL("根据模板ID查询所有格式", "select 格式ID, 模板ID, 格式名称, 格式信息, 版本 from 影像模板格式 where 模板ID=:模板ID");//,关联词句

            sql.AddParameter("模板ID", DbType.String, templateItemId);

            return _dbHelper.ExecuteSQL(sql);
        }


        /// <summary>
        /// 根据格式名称获取ID
        /// </summary>
        /// <param name="formatName"></param>
        /// <param name="templateItemId"></param>
        /// <returns></returns>
        public string GetTemplateFormatIdByName(string formatName, string templateItemId)
        {
            SQL sql = SqlHelper.CreateSQL("根据名称查询模板格式ID", "select 格式ID from 影像模板格式 where 格式名称=:格式名称 and 模板ID=:模板ID");

            sql.AddParameter("格式名称", DbType.String, formatName);
            sql.AddParameter("模板ID", DbType.String, templateItemId);

            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null ? "" : value.ToString());
        }

        public DataTable GetNoReleationExamItem(string templateId, string imgKind)
        {
            SQL sql = SqlHelper.CreateSQL("获取未关联模板的检查项目", "select a.项目ID from 影像项目信息 a, 影像项目分类 b, 影像项目模板 c" +
                                                " where a.项目分类id = b.项目分类id and a.项目id = c.项目id(+)  and c.模板id <> :模板ID and b.影像类别 = :影像类别");
            sql.AddParameter("模板ID", DbType.String, templateId);
            sql.AddParameter("影像类别", DbType.String, imgKind);

            return _dbHelper.ExecuteSQL(sql);

        }

        public DataTable GetTemplateExamItem(string templateId)
        {
            SQL sql = SqlHelper.CreateSQL("获取模板关联的检查项目", "select a.项目ID, b.项目名称 from 影像项目模板 a, 影像项目信息 b where a.项目ID=b.项目ID and a.模板id = :模板ID");
            sql.AddParameter("模板ID", DbType.String, templateId); 

            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 获取模板关联词句
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public DataTable GetTemplateWords(string templateId)
        {
            SQL sql = SqlHelper.CreateSQL("查询模板词句关联", "Select 关联ID,模板ID,格式ID, 词句分类ID from 影像模板词句 where 模板ID=:模板ID");

            sql.AddParameter("模板ID", templateId);

            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 获取格式关联词句
        /// </summary>
        /// <param name="formatId"></param>
        /// <returns></returns>
        public DataTable GetFormatWords(string formatId)
        {
            SQL sql = SqlHelper.CreateSQL("查询格式词句关联", "Select 关联ID,模板ID,格式ID, 词句分类ID from 影像模板词句 where 格式ID=:格式ID");

            sql.AddParameter("格式ID", formatId);

            return _dbHelper.ExecuteSQL(sql);
        }

        public void ClearTemplateReleationExamItem(string templateId)
        {
            SQL sql = SqlHelper.CreateSQL("清除模板关联项目", "delete from 影像项目模板  where 模板id = :模板ID");
            sql.AddParameter("模板ID", DbType.String, templateId);

            _dbHelper.ExecuteSQL(sql);
        }

        public void NewTemplateExamItemReleation(string templateId, string itemId)
        {
            SQL sql = SqlHelper.CreateSQL("创建模板和检查项目的关联", "Insert into 影像项目模板(项目模板ID, 项目ID, 模板ID) values(:项目模板ID, :项目ID, :模板ID)");

            sql.AddParameter("项目模板ID", DbType.String, SqlHelper.GetNumGuid());
            sql.AddParameter("项目ID", DbType.String, itemId);
            sql.AddParameter("模板ID", DbType.String, templateId);

            _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 新增模板分类
        /// </summary>
        /// <param name="wordClass"></param>
        /// <returns></returns>
        public bool NewTemplateClass(ReportTemplateClassData templateClass)
        {
            SQL sql = SqlHelper.CreateSQL("插入报告模板分类", "insert into 影像模板分类(模板分类ID, 上级分类ID, 影像类别, 分类名称, 分类信息)" +
            "values(:模板分类ID, :上级分类ID, :影像类别, :分类名称, :分类信息)");

            sql.AddParameter("模板分类ID", DbType.String, templateClass.模板分类ID);
            sql.AddParameter("上级分类ID", DbType.String, templateClass.上级分类ID);
            sql.AddParameter("影像类别", DbType.String, templateClass.影像类别);
            sql.AddParameter("分类名称", DbType.String, templateClass.分类名称);
            sql.AddParameter("分类信息", DbType.String, templateClass.分类信息.ToString());

            _dbHelper.ExecuteSQL(sql);

            return true;
        }

        /// <summary>
        /// 新增模板信息
        /// </summary>
        /// <param name="wordClass"></param>
        /// <returns></returns>
        public bool NewTemplateItem(ReportTemplateItemData templateItem)
        {
            SQL sql = SqlHelper.CreateSQL("插入报告模板信息", "insert into 影像模板信息(模板ID,  模板分类ID, 模板名称, 模板信息, 数据来源,版本,关联段落)" +
            "values(:模板ID,  :模板分类ID, :模板名称, :模板信息, :数据来源, :版本, :关联段落)");

            sql.AddParameter("模板ID", DbType.String, templateItem.模板ID);
            sql.AddParameter("模板分类ID", DbType.String, templateItem.模板分类ID);
            sql.AddParameter("模板名称", DbType.String, templateItem.模板名称);
            sql.AddParameter("版本", DbType.Int32, templateItem.版本);
            sql.AddParameter("模板信息", DbType.String, templateItem.模板信息.ToString());
            sql.AddParameter("数据来源", DbType.String, templateItem.数据来源.ToString());
            //sql.AddParameter("关联词句", DbType.String, templateItem.关联词句.ToString());
            sql.AddParameter("关联段落", DbType.String, templateItem.关联段落.ToString());

            _dbHelper.ExecuteSQL(sql);

            return true;
        }


        /// <summary>
        /// 新增模板格式
        /// </summary>
        /// <param name="wordClass"></param>
        /// <returns></returns>
        public bool NewTemplateFormat(ReportTemplateFormatData templateFormat)
        {
            SQL sql = SqlHelper.CreateSQL("插入报告模板格式", "insert into 影像模板格式(格式ID,  模板ID, 格式名称, 格式信息, 版本)" +
            "values(:格式ID,  :模板ID, :格式名称, :格式信息, :版本)");

            sql.AddParameter("格式ID", DbType.String, templateFormat.格式ID);
            sql.AddParameter("模板ID", DbType.String, templateFormat.模板ID);
            sql.AddParameter("格式名称", DbType.String, templateFormat.格式名称);
            sql.AddParameter("版本", DbType.Int32, templateFormat.版本);
            sql.AddParameter("格式信息", DbType.String, templateFormat.格式信息.ToString()); 
            //sql.AddParameter("关联词句", DbType.String, templateFormat.关联词句.ToString()); 

            _dbHelper.ExecuteSQL(sql);

            return true;
        }

        /// <summary>
        /// 删除报告模板分类
        /// </summary>
        /// <param name="templateClassId"></param>
        /// <returns></returns>
        public bool DelTemplateClass(string templateClassId)
        {
            SQL sql = SqlHelper.CreateSQL("删除报告模板分类", "delete 影像模板分类 where 模板分类ID=:模板分类ID");
            sql.AddParameter("模板分类ID", DbType.String, templateClassId);

            _dbHelper.ExecuteSQL(sql);

            return true;
        }

        /// <summary>
        /// 删除报告模板
        /// </summary>
        /// <param name="templateItemId"></param>
        public bool DelTemplateItem(string templateItemId)
        {
            SQL sql = SqlHelper.CreateSQL("删除报告模板信息", "delete 影像模板信息 where 模板ID=:模板ID");
            sql.AddParameter("模板ID", DbType.String, templateItemId);

            _dbHelper.ExecuteSQL(sql);

            return true;
        }


        /// <summary>
        /// 删除模板格式
        /// </summary>
        /// <param name="templateFormatId"></param>
        public bool DelTemplateFormat(string templateFormatId)
        {
            SQL sql = SqlHelper.CreateSQL("删除报告模板格式", "delete 影像模板格式 where 格式ID=:格式ID");
            sql.AddParameter("格式ID", DbType.String, templateFormatId);

            _dbHelper.ExecuteSQL(sql);

            return true;
        }

        /// <summary>
        /// 更新报告模板分类
        /// </summary>
        /// <param name="templateClass"></param>
        /// <returns></returns>
        public bool UpdateTemplateClass(ReportTemplateClassData templateClass)
        {
            SQL sql = SqlHelper.CreateSQL("更新报告模板分类", "update 影像词句分类 set 分类名称=:分类名称, 上级分类ID=:上级分类ID, 分类信息=:分类信息 where 词句分类ID=:词句分类ID");


            sql.AddParameter("分类名称", DbType.String, templateClass.分类名称);
            sql.AddParameter("上级分类ID", DbType.String, templateClass.上级分类ID);
            sql.AddParameter("分类信息", DbType.String, templateClass.分类信息.ToString());
            sql.AddParameter("模板分类ID", DbType.String, templateClass.模板分类ID);

            _dbHelper.ExecuteSQL(sql);

            return true;

        }


        /// <summary>
        /// 更新报告模板信息
        /// </summary>
        /// <param name="templateItem"></param>
        /// <returns></returns>
        public bool UpdateTemplateItem(ReportTemplateItemData templateItem)
        {
            SQL sql = SqlHelper.CreateSQL("更新报告模板信息", "update 影像模板信息 set 模板名称=:模板名称, 模板分类ID=:模板分类ID, 版本=:版本, 模板信息=:模板信息, 数据来源=:数据来源, 关联段落=:关联段落 where 模板ID=:模板ID"); //关联词句=:关联词句,


            sql.AddParameter("模板名称", DbType.String, templateItem.模板名称);
            sql.AddParameter("模板分类ID", DbType.String, templateItem.模板分类ID);
            sql.AddParameter("版本", DbType.Int32, templateItem.版本);
            sql.AddParameter("模板信息", DbType.String, templateItem.模板信息.ToString());
            sql.AddParameter("数据来源", DbType.String, templateItem.数据来源.ToString());
            //sql.AddParameter("关联词句", DbType.String, templateItem.关联词句.ToString());
            sql.AddParameter("关联段落", DbType.String, templateItem.关联段落.ToString());
            sql.AddParameter("模板ID", DbType.String, templateItem.模板ID);

            _dbHelper.ExecuteSQL(sql);

            return true;

        }


        /// <summary>
        /// 更新报告格式信息
        /// </summary>
        /// <param name="templateItem"></param>
        /// <returns></returns>
        public bool UpdateTemplateFormat(ReportTemplateFormatData templateFormat)
        {
            SQL sql = CreateSQL("更新报告模板格式", "update 影像模板格式 set 格式名称=:格式名称, 模板ID=:模板ID, 版本=:版本, 格式信息=:格式信息 where 格式ID=:格式ID");//, 关联词句=:关联词句 


            sql.AddParameter("格式名称", DbType.String, templateFormat.格式名称);
            sql.AddParameter("模板ID", DbType.String, templateFormat.模板ID);
            sql.AddParameter("版本", DbType.Int32, templateFormat.版本);
            sql.AddParameter("格式信息", DbType.String, templateFormat.格式信息.ToString()); 
            //sql.AddParameter("关联词句", DbType.String, templateFormat.关联词句.ToString()); 
            sql.AddParameter("格式ID", DbType.String, templateFormat.格式ID);

            sql.ExecuteSql();

            return true;

        }

        /// <summary>
        /// 清除模板关联词句
        /// </summary>
        /// <param name="templateId"></param>
        public void ClearTemplateWords(string templateId)
        {
            SQL sql = CreateSQL("清除模板词句关联", "delete from 影像模板词句 where 模板ID=:模板ID");
            sql.AddParameter("模板ID", templateId);
            sql.ExecuteSql();
        }

        /// <summary>
        /// 清除格式关联词句
        /// </summary>
        /// <param name="formatId"></param>
        public void ClearFormateWords(string formatId)
        {
            SQL sql = CreateSQL("清除格式词句关联", "delete from 影像模板词句 where 格式ID=:格式ID");
            sql.AddParameter("格式ID", formatId);
            sql.ExecuteSql();
        }

        /// <summary>
        /// 更新词句关联
        /// </summary>
        /// <param name="wordReleations"></param>
        public void UpdateWordReleations(DataTable wordReleations)
        {

            if (wordReleations.Rows.Count <= 0) return;
             
            SQL sql = CreateSQL("插入词句关联", "Insert Into 影像模板词句 " +
                                        " values(:关联ID, :模板ID, :格式ID, To_Char(:词句分类ID))");

            int rowCount = wordReleations.Rows.Count;
            string[] 关联ID = new string[rowCount];
            string[] 模板ID = new string[rowCount];
            string[] 格式ID = new string[rowCount];
            string[] 词句分类ID = new string[rowCount];
             

            int i = 0;
            foreach(DataRow dr in wordReleations.Rows)
            {
                关联ID[i] = dr["关联ID"].ToString();
                模板ID[i] = dr["模板ID"].ToString();
                格式ID[i] = dr["格式ID"].ToString();
                词句分类ID[i] = dr["词句分类ID"].ToString();



                i = i + 1;
            }
            
            sql.AddParameter("关联ID", 关联ID);
            sql.AddParameter("模板ID", 模板ID);
            sql.AddParameter("格式ID", 格式ID);
            sql.AddParameter("词句分类ID", 词句分类ID);

            sql.ExecuteSql();
        }
    }
}
