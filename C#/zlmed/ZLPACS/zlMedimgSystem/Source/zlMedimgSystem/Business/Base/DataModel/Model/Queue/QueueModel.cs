using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{

    public class QueueData:QueueBase, IBizBindRow
    {
        public JQueueInfo 队列信息 { get; set; }
        public JQueueReleationRoom 包含房间 { get; set; }

        protected override void InitJsonInstance()
        {
            队列信息 = new JQueueInfo();
            包含房间 = new JQueueReleationRoom();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JQueueInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JQueueInfo>(jsonData);
                }
                else if (jsonTypeName == typeof(JQueueReleationRoom).FullName)
                {
                    return JsonHelper.DeserializeObject<JQueueReleationRoom>(jsonData);
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
    public class LineUpData : LineUpBase, IBizBindRow
    {
        public JLineUpInfo 附加信息 { get; set; }

        protected override void InitJsonInstance()
        {
            附加信息 = new JLineUpInfo();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JLineUpInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JLineUpInfo>(jsonData);
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
    
    public class LineCallData : LineCallBase, IBizBindRow
    {
        public JLineCalInfo 呼叫信息 { get; set; }

        protected override void InitJsonInstance()
        {
            呼叫信息 = new JLineCalInfo();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JLineCalInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JLineCalInfo>(jsonData);
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

    public class QueueModel: DBModel
    {
        public QueueModel(IDBQuery dbHelper) : base(dbHelper) { }


        /// <summary>
        /// 根据科室ID获取队列信息
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public DataTable GetQueueInfoByDeptId(string departmentId)
        {
            SQL sql = CreateSQL("查询科室队列信息", "select 队列ID, 科室id, 队列名称, 队列信息, 包含房间 " 
                                                + " from 影像队列管理 where 科室ID=:科室ID");

            sql.AddParameter("科室ID", departmentId);

            return sql.ExecuteSql();
        }

        public string GetQueueIdByName(string queueName, string departmentId)
        {
            SQL sql = CreateSQL("根据名称查询队列ID", "select 队列ID from 影像队列管理 where 科室ID=:科室ID and 队列名称=:队列名称");

            sql.AddParameter("科室ID", departmentId);
            sql.AddParameter("队列名称", queueName);

            object value = sql.ExecuteSqlOneOutput();

            return (value == null) ? "" : value.ToString();
        }

        /// <summary>
        /// 根据ID获取队列信息
        /// </summary>
        /// <param name="queueId"></param>
        /// <returns></returns>
        public QueueData GetQueueInfoByQueueId(string queueId)
        {
            SQL sql = CreateSQL("根据队列ID查询队列信息", "select 队列ID, 科室ID,队列名称,队列信息,包含房间 "
                                                            + " from 影像队列管理 " 
                                                            + " where 队列ID=:队列ID");

            sql.AddParameter("队列ID", queueId);

            DataTable dtQueueInfo = sql.ExecuteSql();

            if (dtQueueInfo == null || dtQueueInfo.Rows.Count <= 0) return null;

            QueueData queData = new QueueData();
            queData.BindRowData(dtQueueInfo.Rows[0]);
            
            return queData;
        }

        /// <summary>
        /// 新增队列
        /// </summary>
        /// <param name="queueInfo"></param>
        /// <returns></returns>
        public bool NewQueue(QueueData queueInfo)
        {
            SQL sql =CreateSQL("新增队列信息", "insert into " +
                  " 影像队列管理(队列ID,科室ID,队列名称, 队列信息, 包含房间) " +
                  " values " +
                  " (:队列ID,:科室ID,:队列名称, :队列信息, :包含房间)");


            sql.AddParameter("队列ID", queueInfo.队列ID);
            sql.AddParameter("科室ID", queueInfo.科室ID);
            sql.AddParameter("队列名称", queueInfo.队列名称);
            sql.AddParameter("队列信息", queueInfo.队列信息.ToString());
            sql.AddParameter("包含房间", queueInfo.包含房间.ToString());


            sql.ExecuteSql(); 

            return true;
        }


        /// <summary>
        /// 新增排队
        /// </summary>
        /// <param name="lineupInfo"></param>
        /// <returns></returns>
        public bool NewLinuUp(LineUpData lineupInfo)
        {
            SQL sql = CreateSQL("新增排队信息", "insert into " +
                  " 影像排队信息(排队ID,申请ID,患者ID, 队列ID,科室ID, 排队日期, 队列名称, 科室名称,检查房间,患者姓名,排队号码,排队序号,号码前缀,附加信息,排队状态) " +
                  " values " +
                  " (:排队ID, :申请ID, :患者ID, :队列ID,:科室ID,:排队日期, :队列名称, :科室名称, :检查房间, :患者姓名, :排队号码, :排队序号, :号码前缀, :附加信息, :排队状态)");

            lineupInfo.附加信息.最后更新日期 = GetServerDate();

            sql.AddParameter("排队ID", lineupInfo.排队ID);
            sql.AddParameter("申请ID", lineupInfo.申请ID);
            sql.AddParameter("患者ID", lineupInfo.患者ID);
            sql.AddParameter("队列ID", lineupInfo.队列ID);
            sql.AddParameter("科室ID", lineupInfo.科室ID);
            sql.AddDateTimePar("排队日期", lineupInfo.排队日期);
            sql.AddParameter("队列名称", lineupInfo.队列名称);
            sql.AddParameter("科室名称", lineupInfo.科室名称);
            sql.AddParameter("检查房间", lineupInfo.检查房间);
            sql.AddParameter("患者姓名", lineupInfo.患者姓名);
            sql.AddParameter("排队号码", lineupInfo.排队号码);
            sql.AddParameter("排队序号", lineupInfo.排队序号);
            sql.AddParameter("号码前缀", lineupInfo.号码前缀);
            sql.AddInt32Par("排队状态", (int)lineupInfo.排队状态);
            sql.AddParameter("附加信息", lineupInfo.附加信息.ToString());

            sql.ExecuteSql();

            return true;
        }


        /// <summary>
        /// 新增呼叫
        /// </summary>
        /// <param name="callInfo"></param>
        /// <returns></returns>
        public bool NewCall(LineCallData callInfo)
        {
            SQL sql = CreateSQL("新增呼叫信息", "insert into " +
                  " 影像排队呼叫(呼叫ID,排队ID,队列ID,生成日期, 呼叫站点, 呼叫信息) " +
                  " values " +
                  " (:呼叫ID,:排队ID,:队列ID,:生成日期, :呼叫站点, :呼叫信息)");


            sql.AddParameter("呼叫ID", callInfo.呼叫ID);
            sql.AddParameter("排队ID", callInfo.排队ID);
            sql.AddParameter("队列ID", callInfo.队列ID);             
            sql.AddDateTimePar("生成日期", callInfo.生成日期);
            sql.AddParameter("呼叫站点", callInfo.呼叫站点);
            sql.AddParameter("呼叫信息", callInfo.呼叫信息.ToString());


            sql.ExecuteSql();

            return true;
        }


        /// <summary>
        /// 删除呼叫信息
        /// </summary>
        /// <param name="callId"></param>
        /// <returns></returns>
        public bool DelCallInfoByCallId(string callId)
        {

            SQL sql = CreateSQL("删除呼叫信息", "delete 影像排队呼叫 where 呼叫ID=:呼叫ID");

            sql.AddParameter("呼叫ID", callId);

            sql.ExecuteSql();

            return true;

        }

        /// <summary>
        /// 根据排队ID删除呼叫信息
        /// </summary>
        /// <param name="LineupId"></param>
        /// <returns></returns>
        public bool DelCallInfoByLineupId(string LineupId)
        {

            SQL sql = CreateSQL("删除呼叫信息", "delete 影像排队呼叫 where 排队ID=:排队ID");

            sql.AddParameter("排队ID", LineupId);

            sql.ExecuteSql();

            return true;

        }

        public bool UpdateLineupInfo(LineUpData lineupInfo)
        {
            SQL sql = CreateSQL("更新排队信息", "Update 影像排队信息 " +
                                                " Set 排队日期=:排队日期, 检查房间=:检查房间, 患者姓名=:患者姓名, 排队状态=:排队状态, 排队号码=:排队号码, 排队序号=:排队序号,附加信息=:附加信息 where 排队ID=:排队ID");

            lineupInfo.附加信息.最后更新日期 = GetServerDate();

            sql.AddDateTimePar("排队日期", lineupInfo.排队日期);
            sql.AddParameter("检查房间", lineupInfo.检查房间);
            sql.AddParameter("患者姓名", lineupInfo.患者姓名);
            sql.AddInt32Par("排队状态", (int)lineupInfo.排队状态);
            sql.AddParameter("排队号码", lineupInfo.排队号码);
            sql.AddParameter("排队序号", lineupInfo.排队序号);
            sql.AddParameter("附加信息", lineupInfo.附加信息.ToString());
            sql.AddParameter("排队ID", lineupInfo.排队ID);

            sql.ExecuteSql();

            return true;
        }


        ///// <summary>
        ///// 更新呼叫状态
        ///// </summary>
        ///// <param name="callId"></param>
        ///// <returns></returns>
        //public bool UpdateLineupState(string lineupId, LineUpState state)
        //{
        //    LineUpData lineupInfo = GetLineupInfo(lineupId);

        //    if (lineupInfo == null) return false;

        //    lineupInfo.排队状态 = state;

        //    lineupInfo.附加信息.CopyBasePro(lineupInfo);

        //    if (state == LineUpState.qsCalling)
        //    {
        //        if (lineupInfo.附加信息.首次呼叫时间 == default(DateTime))
        //        {
        //            lineupInfo.附加信息.首次呼叫时间 = GetServerDate();
        //        }

        //        lineupInfo.附加信息.末次呼叫时间 = GetServerDate();
        //    }
             

        //    SQL sql = CreateSQL("更新呼叫状态", "update 影像排队信息 set 附加信息=:附加信息 , 排队状态=:排队状态 where 排队ID=:排队ID");

        //    sql.AddParameter("排队ID", lineupId);

        //    sql.ExecuteSql();

        //    return true;

        //}



        /// <summary>
        /// 更新队列
        /// </summary>
        /// <param name="queueInfo"></param>
        public void UpdateQueueInfo(QueueData queueInfo)
        {
            SQL sql =CreateSQL("更新队列信息", "Update 影像队列管理 " +
                    " Set 队列名称=:队列名称, 队列信息=:队列信息, 包含房间=:包含房间 where 队列ID=:队列ID");

            sql.AddParameter("队列ID", queueInfo.队列ID); 
            sql.AddParameter("队列名称", queueInfo.队列名称);
            sql.AddParameter("队列信息", queueInfo.队列信息.ToString());
            sql.AddParameter("包含房间", queueInfo.包含房间.ToString());

            sql.ExecuteSql();
        }


        /// <summary>
        /// 更新队列包含房间
        /// </summary>
        /// <param name="queueInfo"></param>
        public void UpdateQueueRooms(QueueData queueInfo)
        {
            SQL sql = CreateSQL("更新队列房间", "Update 影像队列管理 " +
                    " Set 包含房间=:包含房间 where 队列ID=:队列ID");

            sql.AddParameter("队列ID", queueInfo.队列ID); 
            sql.AddParameter("包含房间", queueInfo.包含房间.ToString());

            sql.ExecuteSql();
        }


        public DataTable GetApplyRoomId(string applyId)
        {
            SQL sql = CreateSQL("查询未执行部位房间", "Select 房间ID from 影像检查执行 where 申请ID=:申请ID and 执行状态=0");

            sql.AddParameter("申请ID", applyId);


            return sql.ExecuteSql();
        }


        /// <summary>
        /// 删除队列
        /// </summary>
        /// <param name="queueID"></param>
        /// <returns></returns>
        public bool DelQueueInfo(string queueID)
        {

            SQL sql = CreateSQL("删除队列信息", "delete 影像队列管理 where 队列ID=:队列ID");

            sql.AddParameter("队列ID", queueID);

            sql.ExecuteSql();
            
            return true;

        }


        /// <summary>
        /// 获取报告申请
        /// </summary>
        /// <param name="applyId"></param>
        /// <returns></returns>
        public ApplyData GetApplyByID(string applyId)
        {
            SQL sql = CreateSQL("查询排队患者申请信息", "select * from 影像检查申请 where 申请ID=:申请ID");

            sql.AddParameter("申请ID", applyId);

            DataTable dtApply = sql.ExecuteSql();

            if (dtApply == null || dtApply.Rows.Count <= 0) return null;

            ApplyData applyData = new ApplyData();
            applyData.BindRowData(dtApply.Rows[0]);

            return applyData;
        }

        /// <summary>
        /// 根据科室ID获取科室名称
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public string GetDepartmentName(string departmentId)
        {
            SQL sql = CreateSQL("查询排队科室名称", "select 科室名称 from 影像科室信息 where 科室ID=:科室ID");

            sql.AddParameter("科室ID", departmentId);

            object value = sql.ExecuteSqlOneOutput();

            return (value == null) ? "" : value.ToString();
        }

        /// <summary>
        /// 获取队列房间信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDeptRooms(string departmentId)
        {
            SQL sql = CreateSQL("查询排队房间信息", "select 房间ID, 房间名称 from 影像房间信息 where 科室ID=:科室ID");

            sql.AddParameter("科室ID", departmentId);

            return sql.ExecuteSql();

        }

        /// <summary>
        /// 获取检查项目名称
        /// </summary>
        /// <param name="examItemId"></param>
        /// <returns></returns>
        public string GetExamItemName(string examItemId)
        {
            if (string.IsNullOrEmpty(examItemId)) return "";

            SQL sql = CreateSQL("查询检查项目信息", "select 项目名称 From 影像项目信息 where 项目ID=:项目ID");

            sql.AddParameter("项目ID", examItemId);

            object value = sql.ExecuteSqlOneOutput();

            return (value == null) ? "" : value.ToString();
        }

        public LineUpData HasApply(string applyId, string departmentId)
        {
            SQL sql = CreateSQL("查询申请是否已经存在", "Select 排队ID,申请ID,患者ID,队列ID,科室ID,排队日期,队列名称,科室名称,检查房间,患者姓名,排队号码,排队序号,号码前缀,附加信息,排队状态 "
                                                        + " From 影像排队信息 Where 申请ID=:申请ID And 科室ID=:科室ID");

            sql.AddParameter("申请ID", applyId);
            sql.AddParameter("科室ID", departmentId);

            DataTable dtData = sql.ExecuteSql();

            if (dtData == null || dtData.Rows.Count <= 0) return null;

            LineUpData lineupInfo = new LineUpData();
            lineupInfo.BindRowData(dtData.Rows[0]);

            return lineupInfo;
        }

        /// <summary>
        /// 判断号码是否存在
        /// </summary>
        /// <param name="queueNo"></param>
        /// <param name="queueName"></param>
        /// <param name="queueDate"></param>
        /// <returns></returns>
        public bool HasNo(int queueNo, string queueID, DateTime queueDate)
        {
            SQL sql = CreateSQL("查询排队号是否存在", "select 排队号码 from 影像排队信息 "
                                                + " where 队列ID=:队列ID and 排队日期=:排队日期 and 排队号码=:排队号码");

            sql.AddParameter("队列ID", queueID);
            sql.AddDateTimePar("排队日期", queueDate);
            sql.AddInt32Par("排队号码", queueNo);

            DataTable dtNo = sql.ExecuteSql();

            return (dtNo.Rows.Count > 0) ? true : false;
        }


        public string GetMaxQueueNo(string queueID, DateTime queueDate)
        {
            SQL sql = CreateSQL("查询排队最大号码" , "select nvl(max(排队号码), 0) as 号码 " 
                                    + " from 影像排队信息 " 
                                    + " where 队列ID=:队列ID and 排队日期=trunc(:排队日期)");

            sql.AddParameter("队列ID", queueID);
            sql.AddDateTimePar("排队日期", queueDate);

            object value = sql.ExecuteSqlOneOutput();

            return (value == null) ? "" : value.ToString();
        }

        /// <summary>
        /// 获取排队中的数量
        /// </summary>
        /// <param name="queueId"></param>
        /// <param name="queueDate"></param>
        /// <returns></returns>
        public int GetLineupCount(string queueId, DateTime queueDate)
        {
            SQL sql = CreateSQL("查询排队数量", "select count(1) as 数量 from 影像排队信息 where 队列ID=:队列ID and 排队日期=trunc(:排队日期) and 排队状态=0");

            sql.AddParameter("队列ID", queueId);
            sql.AddDateTimePar("排队日期", queueDate);

            DataTable dtCount = sql.ExecuteSql();

            if (dtCount == null || dtCount.Rows.Count <= 0) return 0;

            return Convert.ToInt32(dtCount.Rows[0]["数量"]);
        }

        public DataTable GetLineupInfos(string queueID, bool isQueueing, DateTime dtQueue = default(DateTime))
        {
            DateTime filterDatetime = dtQueue;
            if (filterDatetime == default(DateTime))
            {
                filterDatetime = GetServerDate();
            }

            SQL sql = CreateSQL("查询队列排队信息", "select 排队ID,申请ID,患者ID,队列ID,科室ID,排队日期,队列名称,科室名称,检查房间,患者姓名,排队号码,排队序号,号码前缀,附加信息,排队状态"
                                + " from 影像排队信息 "
                                + " where 队列ID=:队列ID and 排队日期=TRUNC(:排队日期) " +((isQueueing)?" and 排队状态=0": "") 
                                + " order by 排队序号 ");

            sql.AddParameter("队列ID", queueID);
            sql.AddDateTimePar("排队日期", filterDatetime);

            return sql.ExecuteSql();

        }

        public DataTable FindLineupInfos(string departmentId, string customFilter, string customValue)
        {
            SQL sql = CreateSQL("查找队列信息", "select 排队ID,申请ID,患者ID,队列ID,科室ID,排队日期,队列名称,科室名称,检查房间,患者姓名,排队号码,排队序号,号码前缀,附加信息,排队状态"
                                    + " From 影像排队信息 "
                                    + " Where 科室ID=:科室ID and " + customFilter + "=:" + customFilter);

            sql.AddParameter("科室ID", departmentId);
            sql.AddParameter(customFilter, customValue);

            return sql.ExecuteSql();
        }


        public DataTable GeCalledInfos(string queueID)
        {
            SQL sql = CreateSQL("查询队列排队信息", "select 排队ID,申请ID,患者ID,队列ID,科室ID,排队日期,队列名称,科室名称,检查房间,患者姓名,排队号码,排队序号,号码前缀,附加信息,排队状态"
                                + " from 影像排队信息 "
                                + " where 队列ID=:队列ID and 排队日期=TRUNC(sysdate) and 排队状态>= 1 and 排队状态 <= 4"
                                + " order by 排队序号 ");

            sql.AddParameter("队列ID", queueID);

            return sql.ExecuteSql();

        }

        /// <summary>
        /// 返回顺呼的排队信息
        /// </summary>
        /// <param name="queueID"></param>
        /// <returns></returns>
        public LineUpData GetOrderCallLineup(string queueID)
        {
            SQL sql = CreateSQL("查询待呼叫排队信息", "select 排队ID,申请ID,患者ID,队列ID,科室ID,排队日期,队列名称,科室名称,检查房间,患者姓名,排队号码,排队序号,号码前缀,附加信息,排队状态"
                                + " from 影像排队信息 a, "
                                + " (select nvl(min(排队序号), 0) as 最小序号 from 影像排队信息 where 队列ID=:队列ID and 排队日期=Trunc(sysdate) and 排队状态=0) b"
                                + " where a.队列ID=:队列ID and a.排队日期=TRUNC(sysdate) and a.排队状态= 0 and a.排队序号=b.最小序号 ");

            sql.AddParameter("队列ID", queueID);

            DataTable dtLinuup = sql.ExecuteSql();

            if (dtLinuup == null || dtLinuup.Rows.Count <= 0) return null;

            LineUpData lineupInfo = new LineUpData();
            lineupInfo.BindRowData(dtLinuup.Rows[0]);

            return lineupInfo;

        }


        /// <summary>
        /// 返回排队信息
        /// </summary>
        /// <param name="queueID"></param>
        /// <returns></returns>
        public LineUpData GetLineupInfo(string lineupId)
        {
            SQL sql = CreateSQL("查询排队信息", "select 排队ID,申请ID,患者ID,队列ID,科室ID,排队日期,队列名称,科室名称,检查房间,患者姓名,排队号码,排队序号,号码前缀,附加信息,排队状态"
                                + " from 影像排队信息"                               
                                + " where 排队ID=:排队ID ");

            sql.AddParameter("排队ID", lineupId);

            DataTable dtLinuup = sql.ExecuteSql();

            if (dtLinuup == null || dtLinuup.Rows.Count <= 0) return null;

            LineUpData lineupInfo = new LineUpData();
            lineupInfo.BindRowData(dtLinuup.Rows[0]);

            return lineupInfo;

        }

        /// <summary>
        /// 获取待呼叫的文本信息
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns></returns>
        public DataTable GetCallTextInfo(string stationName)
        {
            SQL sql = CreateSQL("获取待呼叫的文本信息", "select 呼叫ID, 排队ID, 队列ID, 生成日期, 呼叫站点, 呼叫信息" 
                                                        + " From 影像排队呼叫 " 
                                                        + " Where 呼叫站点=:呼叫站点 and 生成日期 >= trunc(sysdate) order by 生成日期 ");

            sql.AddParameter("呼叫站点", stationName);

            return sql.ExecuteSql();
        }



        /// <summary>
        /// 获取最后呼叫的排队信息
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="stationName"></param>
        /// <returns></returns>
        public DataTable GetLastCallInfoByDepartmentId(string departmentId, bool hasWaitCall = false)
        {
            SQL sql = CreateSQL("根据科室ID获取最后呼叫的排队信息", "select 排队ID,申请ID,患者ID,队列ID,科室ID,排队日期,队列名称,科室名称,检查房间,患者姓名,排队号码,排队序号,号码前缀,附加信息,排队状态"
                                                        + " From 影像排队信息 "
                                                        + " Where 科室ID=:科室ID and 排队日期=trunc(sysdate) and 排队状态 > " + ((hasWaitCall) ? "0" : "1") +  " and 排队状态 < 4 ");

            sql.AddParameter("科室ID", departmentId);

            return sql.ExecuteSql();
            //if (dtLineupInfo == null || dtLineupInfo.Rows.Count <= 0) return null;

            //LineUpData lastCall = null;
            //DateTime lastTime = default(DateTime);

            //foreach(DataRow dr in dtLineupInfo.Rows)
            //{
            //    LineUpData curLineup = new LineUpData();
            //    curLineup.BindRowData(dr);

            //    if (curLineup.附加信息.末次呼叫时间 > lastTime && curLineup.附加信息.播放站点 == stationName)
            //    {
            //        lastTime = curLineup.附加信息.末次呼叫时间;
            //        lastCall = curLineup;
            //    }
            //}

            //return lastCall;
        }

        public DataTable GetLastCallInfoByQueueId(string queueId, bool hasWaitCall = false)
        {
            SQL sql = CreateSQL("根据队列ID获取最后呼叫的排队信息", "select 排队ID,申请ID,患者ID,队列ID,科室ID,排队日期,队列名称,科室名称,检查房间,患者姓名,排队号码,排队序号,号码前缀,附加信息,排队状态"
                                            + " From 影像排队信息 "
                                            + " Where 队列ID=:队列ID and 排队日期=trunc(sysdate) and 排队状态 >" + ((hasWaitCall) ? "0" : "1") + " and 排队状态 < 4 ");

            sql.AddParameter("队列ID", queueId);

            return sql.ExecuteSql();
        }

        /// <summary>
        /// 查询科室下的所有队列的排队状态信息
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="queueDate"></param>
        /// <returns></returns>
        public DataTable GetLineupCountByDepartmentId(string departmentId, DateTime queueDate = default(DateTime))
        {
            DateTime curQueueDate = queueDate;
            if (curQueueDate == default(DateTime))
            {
                curQueueDate = GetServerDate();
            }

            SQL sql = CreateSQL("获取指定科室中的排队状态", "Select a.队列ID,a.队列名称, sum(decode(b.排队状态, 0, 1, 0)) as 数量" 
                                                            + " From 影像队列管理 a, 影像排队信息 b " 
                                                            + " Where a.队列ID=b.队列ID(+) and a.科室ID=:科室ID and b.排队日期(+)=trunc(:排队日期)"
                                                            + " Group By a.队列ID, a.队列名称");

            sql.AddParameter("科室ID", departmentId);
            sql.AddDateTimePar("排队日期", curQueueDate);


            return sql.ExecuteSql();
        }
 
    }



}
