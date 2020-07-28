using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
    public delegate string RequestNo(NoType noType);
    public class NoRuleModel :  DBModel
    {
        public const string NoRuleParName = "检查号规则";


        private JNoRuleInfo _noRule = null;
        private DateTime _lastClearDate = default(DateTime);
        private ParameterModel _pm = null;

        public event RequestNo OnRequestNo;

        public NoRuleModel(IDBQuery dbHelper) : base(dbHelper)
        {
            _pm = new ParameterModel(dbHelper);
        }
         

        public void WriteTest(string no)
        {
            string sql = "Insert Into 影像号码测试(测试ID, 号码) values(:测试ID,:号码)";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("插入影像号码测试数据", sql);

            _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("测试ID", DbType.String, SqlHelper.GetCmpUID()), new SqlParamInfo("号码", DbType.String, no) });
        }

        /// <summary>
        /// 获取科室信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepartment()
        {
            string sql = "Select 科室ID,科室名称 From 影像科室信息 order by 科室名称 ";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询号码科室信息", sql);

            return _dbHelper.ExecuteSQL(sql);
        }


        /// <summary>
        /// 获取规则信息
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public JNoRuleInfo GetNoRuleInfo(string departmentId)
        {
            DataTable parInfo = _pm.GetParameterInfo(NoRuleParName, departmentId);
            if (parInfo == null || parInfo.Rows.Count <= 0) return null;

            ParameterData parData = new ParameterData();
            parData.BindRowData(parInfo.Rows[0]);

            JNoRuleInfo noRule = JsonHelper.DeserializeObject<JNoRuleInfo>(parData.参数取值);
            if (noRule == null) return null;

            return noRule;
        }

        /// <summary>
        /// 设置规则信息
        /// </summary>
        /// <param name="noRuleInfo"></param>
        /// <param name="departmentId"></param>
        public void SetNoRuleInfo(JNoRuleInfo noRuleInfo, string departmentId)
        {
            ParameterData parData = new ParameterData();
            parData.参数ID = SqlHelper.GetCmpUID();
            parData.参数名称 = NoRuleModel.NoRuleParName;
            parData.参数标记 = departmentId;
             

            parData.参数取值 = noRuleInfo.ToString();

            _pm.WriteParameter(parData);
        }



        /// <summary>
        /// 获取号码
        /// </summary>
        /// <param name="patientIdentNo">患者识别号</param>
        /// <param name="imageKind">影像类别</param>
        /// <param name="departmentId">执行科室ID</param>
        /// <param name="isRefresh">是否刷新</param>
        /// <returns></returns>
        public string GetStudyNo(string patientIdentNo, string imageKind, string departmentId, bool isRefresh)
        {
            if (_noRule == null || isRefresh )
            {
                _noRule = GetNoRuleInfo(departmentId);                

                if (_noRule == null)
                {
                    MessageBox.Show("检查号规则尚未配置，不能自动产生检查号。", "提示");
                    return ""; 
                }
            }

            //根据不同方式创建检查号码
            if (_noRule.检查号类型 == NoType.fiCustom)
            {
                string studyNo = "";

                if (_noRule.号码保持统一)
                {
                    studyNo = GetHistoryNo(_noRule, patientIdentNo, imageKind, departmentId);
                }

                if (string.IsNullOrEmpty(studyNo))
                {
                    studyNo = CreateCustomNo(_noRule, patientIdentNo, imageKind, departmentId);
                }

                return studyNo;
            }
            else
            {
                if (OnRequestNo != null)
                {
                    return OnRequestNo(_noRule.检查号类型);
                }
            }

            return "";
        }

        private object GetCustomNoToDB(string patientIdentNo, string imageKind, string departmentId)
        {
            string sql = "Select zlCreateStudyNo(:患者识别号, :影像类别, :科室ID) as 号码 From dual";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("生成检查号码", sql);

            object value = null;
            try
            {
                value = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] { new SqlParamInfo("患者识别号", DbType.String, patientIdentNo),
                                                                                    new SqlParamInfo("影像类别", DbType.String, imageKind),
                                                                                    new SqlParamInfo("科室ID", DbType.String, departmentId)});
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.ToUpper().IndexOf("ORA-00904") >= 0) return null;

                MsgBox.ShowException(ex);
            }

            return value;
        }

        //private Dictionary<string, string> _imgKind = null;

             
        private string CreateCustomNo(JNoRuleInfo noRule, string patientIdentNo, string imageKind, string departmentId)
        {

            object value = GetCustomNoToDB(patientIdentNo, imageKind, departmentId);

            if (value != null) return value.ToString();

            string result = "";

            //生成检查号
            if (noRule.前缀方式 == NoPrefixWay.noFixText)
            {
                result = result + noRule.前缀文本;
            }
            else if(noRule.前缀方式 == NoPrefixWay.noImageKindCode)
            {
                //获取类别前缀
                result = result +  imageKind;
            }

            if (string.IsNullOrEmpty(noRule.前缀分隔符.Trim()) == false)
            {
                result = result + noRule.前缀分隔符;
            }

            if (string.IsNullOrEmpty(noRule.年份格式) == false)
            {
                result = result + noRule.年份格式.Replace("YYYY", DateTime.Now.Year.ToString()).Replace("YY", DateTime.Now.Year.ToString().Substring(2, 2));
            }

            if (noRule.使用月份)
            {
                result = result + DateTime.Now.Month.ToString().PadLeft(2, '0');
            }

            if (noRule.使用天数)
            {
                if (noRule.使用月份)
                {
                    result = result + DateTime.Now.Day.ToString().PadLeft(2, '0');
                }
                else
                {
                    result = result + DateTime.Now.DayOfYear.ToString().PadLeft(3, '0');
                }
            }

            if (string.IsNullOrEmpty(noRule.日期分隔符.Trim()) == false)
            {
                result = result + noRule.日期分隔符;
            }

            //获取序号
            result = result + GetOrder(noRule, patientIdentNo, imageKind, departmentId).PadLeft(noRule.序号长度, '0'); 

            return result;
        }

        private int ResetOrder(string noTag, int curOrder)
        {
            try
            {
                string sql = "Insert Into 影像号码信息(号码ID, 号码标记,当前序号) values(:号码ID, :号码标记, :当前序号)";
                sql = SqlHelper.GetSqlBiz().GetSqlContext("插入影像号码信息", sql);

                _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("号码ID", DbType.String, SqlHelper.GetCmpUID()),
                                                                new SqlParamInfo("号码标记", DbType.String, noTag),
                                                                new SqlParamInfo("当前序号", DbType.Int32, curOrder)});

                return curOrder;
            }
            catch
            {
                return ResetOrder(noTag, curOrder + 1);
            }

        }

        private void ClearInvalidOrder(JNoRuleInfo noRule, string noTag)
        {
            
            if (_lastClearDate.ToString("yyyyMMdd").Equals(DateTime.Now.ToString("yyyyMMdd")))
            {
                //如果日期没有变化，则不执行清除
                return;
            } 

            string sql = "delete 影像号码信息 where 号码标记=:号码标记 and 最后日期<:最后日期";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("删除影像号码信息", sql);

            DateTime dtLast = GetServerDate();
  
            bool useDate = true;
            if (noRule.使用天数)
            {
                //清除当天之前的号码
                dtLast = Convert.ToDateTime(dtLast.ToString("yyyy-MM-dd 00:00:00"));
            }
            else
            {
                if (noRule.使用月份)
                {
                    //清除当有之前的号码
                    dtLast = Convert.ToDateTime(dtLast.ToString("yyyy-MM-01 00:00:00"));
                }
                else
                {
                    if (string.IsNullOrEmpty(noRule.年份格式.TrimEnd()) == false)
                    {
                        //清除当年之前 号码
                        dtLast = Convert.ToDateTime(dtLast.ToString("yyyy-01-01 00:00:00"));
                    }
                    else
                    {
                        useDate = false;
                    }
                }
            }

            if (useDate)
            {
                _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] {new SqlParamInfo("号码标记", DbType.String, noTag),
                                                                new SqlParamInfo("最后日期", DbType.Date, dtLast)});
            }

            _lastClearDate = DateTime.Now;

        }

        /// <summary>
        /// 获取历史号码
        /// </summary>
        /// <param name="noRule"></param>
        /// <param name="patientIdentNo"></param>
        /// <returns></returns>
        private string GetHistoryNo(JNoRuleInfo noRule, string patientIdentNo, string imageKind, string departmentId)
        {
            string sql = "";
            object value = null;

            sql = "select 患者ID from 影像患者信息 where 患者识别码=:患者识别码 and rownum <=1";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询患者ID", sql);

            value = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] { new SqlParamInfo("患者识别码", DbType.String, patientIdentNo) });

            if (value == null) return "";

            //统一号码
            if (noRule.号码识别方式 == NoIdentWay.niwDepartment)
            {
                //科室统一
                sql = "select 检查号 from 影像检查申请 where 患者ID=:患者ID and 执行科室ID=:执行科室ID and nvl(检查号,' ')<>' ' order by 申请日期 Desc";
                sql = SqlHelper.GetSqlBiz().GetSqlContext("根据科室查询检查号", sql);

                DataTable dtNo = _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("患者ID", DbType.String, value.ToString()),
                                                                                new SqlParamInfo("执行科室ID", DbType.String, departmentId)});
                if (dtNo == null || dtNo.Rows.Count <= 0) return "";

                return dtNo.Rows[0]["检查号"].ToString();
            }
            else
            {
                //类别统一
                sql = "select 检查号 from 影像检查申请 where 患者ID=:患者ID and 影像类别=:影像类别 and nvl(检查号,' ')<>' ' order by 申请日期 Desc";
                sql = SqlHelper.GetSqlBiz().GetSqlContext("根据类别查询检查号", sql);

                DataTable dtNo = _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("患者ID", DbType.String, value.ToString()),
                                                                                new SqlParamInfo("影像类别", DbType.String, imageKind)});
                if (dtNo == null || dtNo.Rows.Count <= 0) return "";

                return dtNo.Rows[0]["检查号"].ToString();
            }
        }

        private string GetOrder(JNoRuleInfo noRule, string patientIdentNo, string imageKind, string departmentId)
        {
            string sql = "";
            int order = 0;

            object value = null;

            string noTag = "";
            if (noRule.号码识别方式 == NoIdentWay.niwDepartment)
            {
                noTag = departmentId;
            }
            else
            {
                noTag = imageKind;
            }

            //清除无效的序号
            ClearInvalidOrder(noRule, noTag);

            sql = "select max(当前序号) from 影像号码信息 where 号码标记=:号码标记";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("获取检查最大序号", sql);

            value = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] { new SqlParamInfo("号码标记", DbType.String, noTag) });

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                //没有获取到对应的检查序号
                value = ResetOrder(noTag, 0);
            }

            order = Convert.ToInt32(value);

            //验证序号
            order = ValidOrder(noRule, order, noTag); 

            return order.ToString();
        }

        private int ValidOrder(JNoRuleInfo noRule, int order, string noTag)
        {
            try
            {
                string sql = "Insert Into 影像号码信息(号码ID,号码标记,当前序号,最后日期) values(:号码ID,:号码标记,:当前序号,sysdate)";
                sql = SqlHelper.GetSqlBiz().GetSqlContext("插入特定号码信息", sql);

                _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("号码ID", DbType.String,SqlHelper.GetCmpUID()),
                                                                 new SqlParamInfo("号码标记", DbType.String, noTag),
                                                                 new SqlParamInfo("当前序号", DbType.Int32, order)});

                //如果插入成功，则清除比当前序号小的其他号码
                sql = "delete 影像号码信息 where 号码标记=:号码标记 and 当前序号<:当前序号";
                sql = SqlHelper.GetSqlBiz().GetSqlContext("删除特定号码信息", sql);

                _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("号码标记", DbType.String, noTag),
                                                                 new SqlParamInfo("当前序号", DbType.Int32, order - 30)});

                return order;
            }
            catch
            {
                return ValidOrder(noRule, order + 1, noTag);
            }
        }


    }
}
