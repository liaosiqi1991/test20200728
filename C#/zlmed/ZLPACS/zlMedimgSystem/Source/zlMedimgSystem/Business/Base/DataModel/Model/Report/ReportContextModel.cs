using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{

    public class ReportContextData: ReportContextBase
    {
        public JReportContextInfo 报告信息 { get; set; }

        public JReportStateInfo 状态信息 { get; set; }

        public JReportSignInfo 签名信息 { get; set; }
        public JReportMeasureInfo 测量信息 { get; set; }

        public JReportBackInfo 回退信息 { get; set; }
        public JReportRejectInfo 驳回信息 { get; set; }

        public JReportPrintInfo 打印信息 { get; set; }

        public JReportAnnexInfo 附件信息 { get; set; }
        public int 删除标记 { get; set; }


        protected override void InitJsonInstance()
        {
            报告信息 = new JReportContextInfo();
            状态信息 = new JReportStateInfo();
            签名信息 = new JReportSignInfo();
            回退信息 = new JReportBackInfo();
            测量信息 = new JReportMeasureInfo();
            驳回信息 = new JReportRejectInfo();
            打印信息 = new JReportPrintInfo();
            附件信息 = new JReportAnnexInfo();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JReportContextInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JReportContextInfo>(jsonData);
                }
                else if (jsonTypeName == typeof(JReportMeasureInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JReportMeasureInfo>(jsonData);
                }
                else if (jsonTypeName == typeof(JReportRejectInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JReportRejectInfo>(jsonData);
                }
                else if (jsonTypeName == typeof(JReportAnnexInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JReportAnnexInfo>(jsonData);
                }
                else if (jsonTypeName == typeof(JReportSignInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JReportSignInfo>(jsonData);
                }
                else if (jsonTypeName == typeof(JReportBackInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JReportBackInfo>(jsonData);
                }
                else if (jsonTypeName == typeof(JReportStateInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JReportStateInfo>(jsonData);
                }
                else if (jsonTypeName == typeof(JReportPrintInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JReportPrintInfo>(jsonData);
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

    public class ReportContextModel:DBModel
    {
        public ReportContextModel(IDBQuery dbHelper) : base(dbHelper) { }

        /// <summary>
        /// 获取检查申请的项目ID
        /// </summary>
        /// <param name="applyId"></param>
        /// <returns></returns>
        public string GetExamIdByApply(string applyId)
        {
            SQL sql = SqlHelper.CreateSQL("根据检查申请ID获取检查项目ID", "select 申请项目ID from 影像检查申请 where 申请ID=:申请ID");

            sql.AddParameter("申请ID", DbType.String, applyId);

            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null) ? "" : value.ToString();
        }

        /// <summary>
        /// 获取报告申请
        /// </summary>
        /// <param name="applyId"></param>
        /// <returns></returns>
        public ApplyData GetReportApply(string applyId)
        {
            SQL sql = CreateSQL("查询报告申请信息", "select * from 影像检查申请 where 申请ID=:申请ID");

            sql.AddParameter("申请ID", applyId);

            DataTable dtApply = sql.ExecuteSql();

            if (dtApply == null || dtApply.Rows.Count <= 0) return null;

            ApplyData applyData = new ApplyData();
            applyData.BindRowData(dtApply.Rows[0]);

            return applyData;
        }

        public string GetTemplateIdByExamItem(string examItemId)
        {
            SQL sql = SqlHelper.CreateSQL("获取项目模板ID", "Select 模板ID from 影像项目模板 where 项目ID=:项目ID");

            sql.AddParameter("项目ID", DbType.String, examItemId);

            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null) ? "" : value.ToString();
        }

        /// <summary>
        /// 获取对应的模板和格式
        /// </summary>
        /// <param name="examItemId"></param>
        /// <returns></returns>
        public DataTable GetReportTemplateFormats(string templateId)
        {
            SQL sql = SqlHelper.CreateSQL("获取项目模板及格式", "select 模板ID as ID, 模板名称 as 名称, 0 as 类别,版本 from 影像模板信息 where 模板ID=:模板ID" +
                                                                " union all " +
                                                                " select 格式ID as ID, 格式名称 as 名称, 1 as 类别,版本 from 影像模板格式 where 模板ID=:模板ID");

            sql.AddParameter("模板ID", DbType.String, templateId);

            return _dbHelper.ExecuteSQL(sql);
        }

        public string GetReportTemplateImageKind(string templateClassId)
        {
            SQL sql = CreateSQL("查询模板影像类别", "select 影像类别 from 影像模板分类 where 模板分类ID=:模板分类ID");
            sql.AddParameter("模板分类ID", templateClassId);

            object value = sql.ExecuteSqlOneOutput();
            return (value == null) ? "" : value.ToString();
        }

        /// <summary>
        /// 获取申请报告
        /// </summary>
        /// <param name="applyId"></param>
        /// <returns></returns>
        public DataTable GetApplyReport(string applyId)
        {
            SQL sql = SqlHelper.CreateSQL("获取申请报告", "Select 报告ID, 申请ID, 报告名称, 部位名称,状态信息, 测量信息, 报告信息, 签名信息, 驳回信息, 打印信息, 附件信息, 删除标记 "  +
                                                            " From 影像检查报告 where 申请ID=:申请ID and nvl(删除标记, 0) = 0");

            sql.AddParameter("申请ID", DbType.String, applyId);

            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 获取报告模板数据
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public ReportTemplateItemData GetReportTemplateData(string templateId)
        {
            SQL sql = SqlHelper.CreateSQL("获取报告模板信息", "select 模板ID,模板分类ID, 模板名称, 模板信息,数据来源,版本,关联段落 From 影像模板信息 where 模板ID=:模板ID");

            sql.AddParameter("模板ID", DbType.String , templateId);

            DataTable dtTemplate = _dbHelper.ExecuteSQL(sql);

            if (dtTemplate == null || dtTemplate.Rows.Count <= 0) return null;

            ReportTemplateItemData templateData = new ReportTemplateItemData();
            templateData.BindRowData(dtTemplate.Rows[0]);

            return templateData;
        }

        public ReportTemplateFormatData GetReportFormatData(string formatId)
        {
            SQL sql = SqlHelper.CreateSQL("获取报告模板格式", "select 格式ID, 模板ID,格式名称, 格式信息, 版本 From 影像模板格式 where 格式ID=:格式ID");

            sql.AddParameter("格式ID", DbType.String, formatId);

            DataTable dtFormats = _dbHelper.ExecuteSQL(sql);

            if (dtFormats == null || dtFormats.Rows.Count <= 0) return null;

            ReportTemplateFormatData formatsData = new ReportTemplateFormatData();
            formatsData.BindRowData(dtFormats.Rows[0]);

            return formatsData;
        }

        /// <summary>
        /// 新增报告
        /// </summary>
        /// <param name="reportData"></param>
        public void NewReport(ReportContextData reportData)
        {
            SQL sql = SqlHelper.CreateSQL("新增报告", "Insert into 影像检查报告(报告ID,申请ID,报告名称,部位名称,测量信息,状态信息,报告信息,签名信息,驳回信息,打印信息,附件信息)" +
                                                                     " Values(:报告ID,:申请ID,:报告名称,:部位名称,:测量信息,:状态信息,:报告信息,:签名信息,:驳回信息,:打印信息,:附件信息)");

            sql.AddParameter("报告ID", DbType.String, reportData.报告ID);
            sql.AddParameter("申请ID", DbType.String, reportData.申请ID);
            sql.AddParameter("报告名称", DbType.String, reportData.报告名称);            
            sql.AddParameter("部位名称", DbType.String, reportData.部位名称);
            sql.AddParameter("测量信息", DbType.String, reportData.测量信息.ToString());
            sql.AddParameter("状态信息", DbType.String, reportData.状态信息.ToString());
            sql.AddParameter("报告信息", DbType.String, reportData.报告信息.ToString());
            sql.AddParameter("签名信息", DbType.String, reportData.签名信息.ToString());
            sql.AddParameter("驳回信息", DbType.String, reportData.驳回信息.ToString());
            sql.AddParameter("打印信息", DbType.String, reportData.打印信息.ToString());
            sql.AddParameter("附件信息", DbType.String, reportData.附件信息.ToString());

            _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 保存报告内容
        /// </summary>
        /// <param name="reportData"></param>
        public void SaveReportContext(ReportContextData reportData)
        {
            SQL sql = SqlHelper.CreateSQL("保存报告内容", "update 影像检查报告 set 报告信息=:报告信息 where 报告ID=:报告ID");

            sql.AddParameter("报告ID", DbType.String, reportData.报告ID); 
            sql.AddParameter("报告信息", DbType.String, reportData.报告信息.ToString()); 

            _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 保存报告签名
        /// </summary>
        /// <param name="reportData"></param>
        public void SaveReportSign(ReportContextData reportData)
        {
            SQL sql = SqlHelper.CreateSQL("保存报告内容", "update 影像检查报告 set 状态信息=:状态信息, 报告信息=:报告信息, 签名信息=:签名信息, 驳回信息=:驳回信息 where 报告ID=:报告ID");

            sql.AddParameter("报告ID", DbType.String, reportData.报告ID);
            sql.AddParameter("状态信息", DbType.String, reportData.状态信息.ToString());
            sql.AddParameter("报告信息", DbType.String, reportData.报告信息.ToString());
            sql.AddParameter("签名信息", DbType.String, reportData.签名信息.ToString());
            sql.AddParameter("驳回信息", DbType.String, reportData.驳回信息.ToString());

            _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 保存报告打印信息
        /// </summary>
        /// <param name="reportData"></param>
        public void SaveReportPrint(ReportContextData reportData)
        {
            SQL sql = SqlHelper.CreateSQL("保存报告附件信息", "update 影像检查报告 set 附件信息=:附件信息 where 报告ID=:报告ID");

            sql.AddParameter("报告ID", DbType.String, reportData.报告ID);
            sql.AddParameter("附件信息", DbType.String, reportData.附件信息.ToString());
 

            _dbHelper.ExecuteSQL(sql);
        }

        public void SaveReportAnnex(ReportContextData reportData)
        {
            SQL sql = SqlHelper.CreateSQL("保存报告打印信息", "update 影像检查报告 set 附件信息=:附件信息,状态信息=:状态信息 where 报告ID=:报告ID");

            sql.AddParameter("报告ID", DbType.String, reportData.报告ID);
            sql.AddParameter("附件信息", DbType.String, reportData.附件信息.ToString());
            sql.AddParameter("状态信息", DbType.String, reportData.状态信息.ToString());


            _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 驳回报告
        /// </summary>
        /// <param name="reportData"></param>
        public void RejectReport(ReportContextData reportData)
        {
            SQL sql = SqlHelper.CreateSQL("驳回报告", "update 影像检查报告 set 状态信息=:状态信息, 驳回信息=:驳回信息 where 报告ID=:报告ID");

            sql.AddParameter("报告ID", DbType.String, reportData.报告ID);
            sql.AddParameter("状态信息", DbType.String, reportData.状态信息.ToString());
            sql.AddParameter("驳回信息", DbType.String, reportData.驳回信息.ToString()); 

            _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 回退报告签名
        /// </summary>
        /// <param name="reportData"></param>
        public void BackReportSign(ReportContextData reportData)
        {
            SQL sql = SqlHelper.CreateSQL("保存报告内容", "update 影像检查报告 set 状态信息=:状态信息, 报告信息=:报告信息, 签名信息=:签名信息, 回退信息=:回退信息 where 报告ID=:报告ID");

            sql.AddParameter("报告ID", DbType.String, reportData.报告ID);
            sql.AddParameter("状态信息", DbType.String, reportData.状态信息.ToString());
            sql.AddParameter("报告信息", DbType.String, reportData.报告信息.ToString());
            sql.AddParameter("签名信息", DbType.String, reportData.签名信息.ToString());
            sql.AddParameter("回退信息", DbType.String, reportData.回退信息.ToString());

            _dbHelper.ExecuteSQL(sql);
        }

        public void DelReport(string reportId)
        {
            SQL sql = SqlHelper.CreateSQL("删除报告", "update 影像检查报告 set 删除标记=1 where 报告ID=:报告ID");

            sql.AddParameter("报告ID", DbType.String, reportId);

            _dbHelper.ExecuteSQL(sql);
        }


        /// <summary>
        /// 获取申请锁定状态，为空表示没有锁定
        /// </summary>
        /// <param name="applyId"></param>
        /// <returns></returns>
        public JApplyLockInfo GetCurrentApplyLockInfo(string applyId)
        {
            SQL sql = SqlHelper.CreateSQL("查询申请锁定状态", "Select 锁定状态,锁定信息 from 影像检查申请 where 申请ID=:申请ID");

            sql.AddParameter("申请ID", DbType.String, applyId);

            DataTable dtLockInfo = _dbHelper.ExecuteSQL(sql);

            if (dtLockInfo == null || dtLockInfo.Rows.Count <= 0) return null;

            if (Convert.ToBoolean(SqlHelper.Nvl(dtLockInfo.Rows[0]["锁定状态"], 0)) == false) return null;

            return JsonHelper.DeserializeObject<JApplyLockInfo>(dtLockInfo.Rows[0]["锁定信息"].ToString());
        }

        /// <summary>
        /// 锁定申请
        /// </summary>
        /// <param name="lockInfo"></param>
        public void LockApply(string applyId, JApplyLockInfo lockInfo)
        {
            SQL sql = SqlHelper.CreateSQL("写入申请锁定信息", "Update 影像检查申请 Set 锁定状态=1, 锁定信息=:锁定信息 where 申请ID=:申请ID and nvl(锁定状态,0) = 0");
            sql.AddParameter("申请ID", DbType.String, applyId);
            sql.AddParameter("锁定信息", DbType.String, lockInfo.ToString());

            _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 解锁申请
        /// </summary>
        /// <param name="applyId"></param> 
        public void UnLockApply(string applyId)
        {
            SQL sql = SqlHelper.CreateSQL("解除申请锁定信息", "Update 影像检查申请 Set 锁定状态=0, 锁定信息=null where 申请ID=:申请ID and nvl(锁定状态,0) = 1");
            sql.AddParameter("申请ID", DbType.String, applyId); 

            _dbHelper.ExecuteSQL(sql);
        }

        ///// <summary>
        ///// 更新修订状态
        ///// </summary>
        ///// <param name="reportId"></param>
        ///// <param name="state"></param>
        //public void UpdateReviseState(string reportId, int state)
        //{
        //    SQL sql = SqlHelper.CreateSQL("更新报告修订状态", "Update 影像检查报告 Set 状态信息=:状态信息 where 报告ID=:报告ID ");
        //    sql.AddParameter("报告ID", DbType.String, reportId);
        //    sql.AddParameter("状态信息", DbType.String, state);

        //    _dbHelper.ExecuteSQL(sql);
        //}

        /// <summary>
        /// 更新报告状态信息
        /// </summary>
        /// <param name="reportData"></param>
        public void UpdateReportStateInfo(ReportContextData reportData)
        {
            SQL sql = SqlHelper.CreateSQL("更新报告状态信息", "Update 影像检查报告 Set 报告信息=:报告信息,状态信息=:状态信息 where 报告ID=:报告ID ");
            sql.AddParameter("报告ID", DbType.String, reportData.报告ID);
            sql.AddParameter("报告信息", DbType.String, reportData.报告信息.ToString());
            sql.AddParameter("状态信息", DbType.String, reportData.状态信息.ToString());

            _dbHelper.ExecuteSQL(sql);

        }

        /// <summary>
        /// 获取报告状态信息
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public JReportStateInfo GetReportStateInfo(string reportId)
        {
            SQL sql = SqlHelper.CreateSQL("获取报告状态信息", "Select 状态信息 From 影像检查报告  where 报告ID=:报告ID ");
            sql.AddParameter("报告ID", DbType.String, reportId);

            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            if (value != null)
            {
                return JsonHelper.DeserializeObject<JReportStateInfo>(value.ToString());
            }

            return null;
        }

        /// <summary>
        /// 读取检查历史
        /// </summary>
        /// <returns></returns>
        public DataTable ReadHistory(string applyId, int dayRange=30)
        {
            SQL sql = SqlHelper.CreateSQL("查询关联ID", "Select a.患者ID, a.执行科室ID, b.患者关联ID " +
                                        "From 影像检查申请 a, 影像患者信息 b Where a.患者ID=b.患者ID and 申请ID=:申请ID");

            sql.AddParameter("申请ID", DbType.String, applyId);

            DataTable dtPatients = _dbHelper.ExecuteSQL(sql);
            if (dtPatients == null || dtPatients.Rows.Count <= 0)
            {
                return null;
            }

            string patientId = dtPatients.Rows[0]["患者ID"].ToString();
            string patientReleationId = dtPatients.Rows[0]["患者关联ID"].ToString();
            string departmentId = dtPatients.Rows[0]["执行科室ID"].ToString();


            SQL sqlHistory = SqlHelper.CreateSQL("查询检查历史", "select * from 影像检查申请 a, " +
                                                "     (select 申请ID,申请关联ID from 影像检查申请 " +
                                                "     where 患者ID in (select 患者ID from 影像患者信息 where 患者关联ID=:患者关联ID " +
                                                "                       Union all " +
                                                "                       select :患者ID as 患者ID from dual) " +
                                                " ) b where 执行科室ID=:执行科室ID and 申请日期>=sysdate-:日期范围 and  (a.申请ID=b.申请ID or a.申请关联ID=b.申请关联ID) order by 申请日期");

            sqlHistory.AddParameter("患者ID", DbType.String, patientId);
            sqlHistory.AddParameter("患者关联ID", DbType.String, patientReleationId);
            sqlHistory.AddParameter("执行科室ID", DbType.String, departmentId);
            sqlHistory.AddParameter("日期范围", DbType.Int32, dayRange);

            return _dbHelper.ExecuteSQL(sqlHistory);
        }

        public void UpdateSectionContext(string reportId, string applyId, Dictionary<string, string> sectionContext)
        {
            SQL sql = CreateSQL("查询报告段落信息", "Select count(1) as 数量 from 影像报告段落 where 报告ID=:报告ID");

            sql.AddParameter("报告ID", reportId);

            object count = sql.ExecuteSqlOneOutput();
             
            SQL sqlNew = null;
            if (count == null || Convert.ToInt32(count) <= 0)
            {
                sqlNew = CreateSQL("插入报告段落信息", "Insert Into 影像报告段落(报告ID,申请ID) values(:报告ID,:申请ID)");

                sqlNew.AddParameter("报告ID", reportId);
                sqlNew.AddParameter("申请ID", applyId);
            }

            SQL sqlUpdate = CreateSQL("更新段落信息", "");
            string update = "";
            foreach(KeyValuePair<string, string> kv in sectionContext)
            {
                if (string.IsNullOrEmpty(update) == false) update = update + ",";
                update = update + kv.Key + "=:" + kv.Key;

                sqlUpdate.AddParameter(kv.Key , kv.Value);
            }


            if (string.IsNullOrEmpty(update)) return;
            sqlUpdate.Sql = "update 影像报告段落 Set " + update + " where 报告ID=:报告ID";

            sqlUpdate.AddParameter("报告ID", reportId);


            TransactionBegin();
            try
            {
                if (sqlNew != null) sqlNew.ExecuteSql();
                sqlUpdate.ExecuteSql();

                TransactionCommit();
            }
            catch(Exception ex)
            {
                TransactionRollback();
                throw ex;
            }

        }
    }
}
