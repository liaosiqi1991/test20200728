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
    /// 检查序列数据
    /// </summary>
    public class StudySerialData : StudySerialBase, IBizBindRow
    {
        public JStudySerialInfo 序列信息 { get; set; }

        protected override void InitJsonInstance()
        {
            序列信息 = new JStudySerialInfo();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JStudySerialInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JStudySerialInfo>(jsonData);
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
    /// 检查媒体数据
    /// </summary>
    public class StudyMediaData: StudyMediaBase, IBizBindRow
    {
        public JStudyMediaInfo 媒体信息 { get; set; }

        protected override void InitJsonInstance()
        {
            媒体信息 = new JStudyMediaInfo();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JStudyMediaInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JStudyMediaInfo>(jsonData);
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


    public class StudyMediaSerialModel: DBModel
    {
        public StudyMediaSerialModel(IDBQuery dbHelper) : base(dbHelper) { }

        public DataTable GetApplyBaseInfo(string applyId)
        {
            SQL sql = CreateSQL("查询检查申请基本信息", "select * from 影像检查申请 a where 申请ID=:申请ID");
            sql.AddParameter("申请ID", applyId);

            return sql.ExecuteSql();
        }

        /// <summary>
        /// 获取申请的媒体信息
        /// </summary>
        /// <param name="applyId"></param>
        /// <returns></returns>
        public DataTable GetApplyMedia(string applyId)
        {
            SQL sql = SqlHelper.CreateSQL("获取媒体信息", "select 媒体ID,DcmUID,序列ID,申请ID,序号,媒体信息,删除标记 from 影像检查媒体 where 申请ID=:申请ID and nvl(删除标记, 0)=0 ");
            sql.AddParameter("申请ID", DbType.String, applyId);

            return _dbHelper.ExecuteSQL(sql); 
        }

        public StudySerialData GetApplySerialInfoByRoom(string applyId, string roomId, string deviceId)
        {
            SQL sql = SqlHelper.CreateSQL("根据房间设备获取检查序列",
                                "select 序列ID,DcmUID,申请ID,存储ID,房间ID,设备ID, 序号,序列信息,删除标记 " +
                                " from 影像检查序列 " + 
                                " where 申请ID=:申请ID and 房间ID=:房间ID and 设备ID=:设备ID and nvl(删除标记, 0)=0 ");

            sql.AddParameter("申请ID", applyId);
            sql.AddParameter("房间ID", roomId);
            sql.AddParameter("设备ID", deviceId);

            DataTable dtSerial =  _dbHelper.ExecuteSQL(sql);

            if (dtSerial.Rows.Count <= 0) return null;

            StudySerialData ssd = new StudySerialData();
            ssd.BindRowData(dtSerial.Rows[0]);

            return ssd;

        }

        /// <summary>
        /// 根据序列ID获取序列信息
        /// </summary>
        /// <param name="serialId"></param>
        /// <returns></returns>
        public StudySerialData GetApplySerialInfoById(string serialId)
        {
            SQL sql = SqlHelper.CreateSQL("根据ID获取检查序列", "select 序列ID,DcmUID,申请ID,存储ID,房间ID,设备ID, 序号,序列信息,删除标记 from 影像检查序列 where 序列ID=:序列ID and nvl(删除标记, 0)=0 ");
            sql.AddParameter("序列ID", DbType.String, serialId); 

            DataTable dtSerial = _dbHelper.ExecuteSQL(sql);

            if (dtSerial.Rows.Count <= 0) return null;

            StudySerialData ssd = new StudySerialData();
            ssd.BindRowData(dtSerial.Rows[0]);

            return ssd;
        }
 
        /// <summary>
        /// 根据媒体ID获取媒体信息
        /// </summary>
        /// <param name="mediaId"></param>
        /// <returns></returns>
        public StudyMediaData GetMediaInfoById(string mediaId)
        {
            SQL sql = SqlHelper.CreateSQL("根据ID获取检查媒体", "select 媒体ID,序列ID,DcmUID,申请ID,序号,媒体信息,删除标记 from 影像检查媒体 where 媒体ID=:媒体ID and nvl(删除标记, 0)=0 ");
            sql.AddParameter("媒体ID", DbType.String, mediaId);

            DataTable dtMedia = _dbHelper.ExecuteSQL(sql);

            if (dtMedia.Rows.Count <= 0) return null;

            StudyMediaData smd = new StudyMediaData();
            smd.BindRowData(dtMedia.Rows[0]);

            return smd;
        }

        /// <summary>
        /// 新增序列
        /// </summary>
        /// <param name="serialData"></param>
        public void NewSerial(StudySerialData serialData)
        {
            SQL sql = SqlHelper.CreateSQL("插入检查序列", "Insert into 影像检查序列(序列ID,DcmUID,申请ID,存储ID,房间ID,设备ID,序号,序列信息) "
                                                        + "values(:序列ID,:DcmUID,:申请ID,:存储ID,:房间ID,:设备ID,:序号,:序列信息)");
            sql.AddParameter("序列ID", DbType.String, serialData.序列ID);
            sql.AddParameter("DcmUID", DbType.String, serialData.DcmUID);
            sql.AddParameter("申请ID", DbType.String, serialData.申请ID);
            sql.AddParameter("存储ID", DbType.String, serialData.存储ID);
            sql.AddParameter("房间ID", DbType.String, serialData.房间ID);
            sql.AddParameter("设备ID", DbType.String, serialData.设备ID);
            sql.AddParameter("序号", DbType.String, serialData.序号);
            sql.AddParameter("序列信息", DbType.String, serialData.序列信息.ToString());

            _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 获取最大序号
        /// </summary>
        /// <param name="applyId"></param>
        /// <returns></returns>
        public int GetMaxSerialNo(string applyId)
        {
            SQL sql = SqlHelper.CreateSQL("获取最大序列号", "Select Nvl(Max(序号),0) from 影像检查序列 where 申请ID=:申请ID ");
            sql.AddParameter("申请ID", DbType.String, applyId); 

            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null)? 0 : Convert.ToInt32(value);

        }

        /// <summary>
        /// 获取最大媒体号
        /// </summary>
        /// <param name="seriesId"></param>
        /// <returns></returns>
        public int GetMaxMediaNo(string seriesId)
        {
            SQL sql = SqlHelper.CreateSQL("获取最大媒体号", "Select Nvl(Max(序号),0) from 影像检查媒体 where 序列ID=:序列ID ");
            sql.AddParameter("序列ID", DbType.String, seriesId);

            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null) ? 0 : Convert.ToInt32(value);
        }

        public DataTable GetApplyExecuteInfo(string applyid)
        {
            SQL sql = CreateSQL("查询执行信息",
                    "select a.执行ID,a.申请ID,a.部位序号,a.部位名称,a.房间ID, b.房间名称, a.设备ID, c.设备名称, a.执行信息,a.执行状态 " + 
                    " from 影像检查执行 a, 影像房间信息 b, 影像设备信息 c " +
                    " where a.房间ID=b.房间ID(+) and a.设备ID=c.设备ID(+) and 申请ID=:申请ID and Nvl(删除标记,0)=0");

            sql.AddParameter("申请ID", applyid);

            return sql.ExecuteSql();
        }

        /// <summary>
        /// 更新执行安排
        /// </summary>
        /// <param name="executeId"></param>
        /// <param name="exeInfo"></param>
        public void UpdateExecutePlan(JStudyExecute exeInfo)
        {
            SQL sql = CreateSQL("更新执行安排", "Update 影像检查执行 set 房间ID=:房间ID, 设备ID=:设备ID, 执行信息=:执行信息, 执行状态=:执行状态 where 执行ID=:执行ID");

            sql.AddParameter("房间ID", exeInfo.房间ID);
            sql.AddParameter("设备ID", exeInfo.设备ID);
            sql.AddParameter("执行信息", JsonHelper.SerializeObject(exeInfo));
            sql.AddInt32Par("执行状态", (int)exeInfo.执行状态);
            sql.AddParameter("执行ID", exeInfo.执行ID);

            sql.ExecuteSql();
        }



        /// <summary>
        /// 更新执行信息
        /// </summary>
        /// <param name="doDoctor"></param>
        public bool UpdateExecuteState(string applyid, string roomId, string deviceid, 
            string doDoctor, string assistDoctor, StudyExecuteState exeState)
        {
            //有可能一开始报到时，就指定了设备，也可能没有指定设备
            SQL sql = CreateSQL("查询执行信息", 
                                "select 执行ID,执行信息 from 影像检查执行 " + 
                                " where 申请ID=:申请ID and (房间Id is null or 房间ID=:房间ID) and  (设备ID is null or 设备ID=:设备ID)");

            sql.AddParameter("申请ID", applyid);
            sql.AddParameter("房间ID", roomId);
            sql.AddParameter("设备ID", deviceid);

            DataTable dtExecuteInfo = sql.ExecuteSql();
            if (dtExecuteInfo == null || dtExecuteInfo.Rows.Count <= 0) return false;

            JStudyExecute studyExecuteInfo = JsonHelper.DeserializeObject<JStudyExecute>(dtExecuteInfo.Rows[0]["执行信息"].ToString());
            if (studyExecuteInfo == null) return false;

            studyExecuteInfo.执行人 = doDoctor;
            studyExecuteInfo.执行状态 = exeState;
            studyExecuteInfo.辅助技师 = assistDoctor;
            studyExecuteInfo.首次执行时间 = GetServerDate();

            SQL update = CreateSQL("更新执行信息", "update 影像检查执行 set 执行信息=:执行信息, 执行状态=:执行状态 where 执行ID=:执行ID");

            update.AddParameter("执行信息", JsonHelper.SerializeObject(studyExecuteInfo));
            update.AddInt32Par("执行状态", (int)exeState);
            update.AddParameter("执行ID", dtExecuteInfo.Rows[0]["执行ID"].ToString());

            update.ExecuteSql();

            return true;
        }

        /// <summary>
        /// 新增媒体
        /// </summary>
        /// <param name="mediaData"></param>
        public void NewMedia(StudyMediaData mediaData)
        {
            SQL sql = SqlHelper.CreateSQL("插入检查媒体", "Insert into 影像检查媒体(媒体ID,DcmUID,序列ID,申请ID,序号,媒体信息) "
                                                        + "values(:媒体ID,:DcmUID,:序列ID,:申请ID,:序号,:媒体信息)");
            sql.AddParameter("媒体ID", DbType.String, mediaData.媒体ID);
            sql.AddParameter("DcmUID", DbType.String, mediaData.DcmUID);
            sql.AddParameter("序列ID", DbType.String, mediaData.序列ID);
            sql.AddParameter("申请ID", DbType.String, mediaData.申请ID);             
            sql.AddParameter("序号", DbType.String, mediaData.序号);
            sql.AddParameter("媒体信息", DbType.String, mediaData.媒体信息.ToString());

            _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 更新媒体信息
        /// </summary>
        /// <param name="mediaData"></param>
        public void UpdateMedia(StudyMediaData mediaData)
        {
            SQL sql = CreateSQL("更新媒体信息", "update 影像检查媒体 set 媒体信息=:媒体信息 where 媒体ID=:媒体ID");

            sql.AddParameter("媒体ID", DbType.String, mediaData.媒体ID);
            sql.AddParameter("媒体信息", DbType.String, mediaData.媒体信息.ToString());

            sql.ExecuteSql();
        }

        /// <summary>
        /// 删除检查序列
        /// </summary>
        /// <param name="serialId"></param>
        public void DelStudySerial(string serialId)
        {
            SQL sql = SqlHelper.CreateSQL("更新序列删除标记", "update 影像检查序列 set 删除标记=1 where 序列ID=:序列ID");
            sql.AddParameter("序列ID", DbType.String, serialId);

            _dbHelper.ExecuteSQL(sql);

        }


        /// <summary>
        /// 删除检查媒体
        /// </summary>
        /// <param name="meidaId"></param>
        public void DelStudyMedia(string meidaId)
        {
            SQL sql = SqlHelper.CreateSQL("更新媒体删除标记", "update 影像检查媒体 set 删除标记=1 where 媒体ID=:媒体ID");
            sql.AddParameter("媒体ID", DbType.String, meidaId);

            _dbHelper.ExecuteSQL(sql);
        }

        public void UpdateKeyImageState(string mediaId, bool isKey)
        {
            StudyMediaData smd = GetMediaInfoById(mediaId);
            if (smd == null)
            {
                throw new Exception("媒体信息获取失败。");
            }

            smd.媒体信息.是否关键图 = isKey;

            SQL sql = SqlHelper.CreateSQL("更新媒体关键图标记", "update 影像检查媒体 set 媒体信息=:媒体信息 where 媒体ID=:媒体ID");
            sql.AddParameter("媒体ID", DbType.String, mediaId);
            sql.AddParameter("媒体信息", DbType.String, smd.媒体信息.ToString());

            _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 撤销删除
        /// </summary>
        /// <param name="mediaId"></param>
        public void CancelDel(string mediaId)
        {

        }
    }
}
