using System;
using System.Collections.Generic;
using System.Linq;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;

namespace zlMedimgSystem.DataModel
{

    /// <summary>
    /// 设备类别数据
    /// </summary>
    public class DeviceKindData : DeviceKindBase, IBizBindRow
    {
        public JDeviceKindInfo 类别信息 { get; set; }

        protected override void InitJsonInstance()
        {
            类别信息 = new JDeviceKindInfo();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JDeviceKindInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JDeviceKindInfo>(jsonData);
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

    public class DepRoomData : DepRoomBase, IBizBindRow
    { 
        public JRoomInfo 房间信息 { get; set; }



        protected override void InitJsonInstance()
        {
            房间信息 = new JRoomInfo();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            //LSQTest
            try
            {
                if (jsonTypeName == typeof(JRoomInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JRoomInfo>(jsonData);
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

    public class DepDeviceData : DeviceBase, IBizBindRow
    { 
        public JRoomDeviceInfo 设备信息 { get; set; }

        protected override void InitJsonInstance()
        {
            设备信息 = new JRoomDeviceInfo();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JRoomDeviceInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JRoomDeviceInfo>(jsonData);
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
    /// 设备类别模型
    /// </summary>
    public class DeviceKindModel:DBModel
    {
        public DeviceKindModel(IDBQuery dbHelper) : base(dbHelper) { }

        public DataTable GetAllDeviceKind()
        {
            SQL sql = SqlHelper.CreateSQL("获取所有影像类别", "Select 类别ID,类别名称,影像类别,类别信息 From 影像设备类别 order by 类别名称 ");
 
            return _dbHelper.ExecuteSQL(sql);

        }

        public string GetDeviceKindIdByName(string kindName)
        {
            SQL sql = SqlHelper.CreateSQL("获取设备类别ID", "Select 类别ID From 影像设备类别 where 类别名称=:类别名称");
            sql.AddParameter("类别名称", DbType.String, kindName);

            object result = _dbHelper.ExecuteSQLOneOutput(sql);

            return (result == null ? "" : result.ToString());
        }

        public string GetDeviceKindIdByImgKind(string imageKind)
        {
            SQL sql = SqlHelper.CreateSQL("获取设备类别ID", "Select 类别ID From 影像设备类别 where 影像类别=:影像类别");
            sql.AddParameter("影像类别", DbType.String, imageKind);

            object result = _dbHelper.ExecuteSQLOneOutput(sql);

            return (result == null ? "" : result.ToString());
        }


        public void NewDeviceKindInfo(DeviceKindData deviceKind)
        {
            SQL sql = SqlHelper.CreateSQL("插入设备类别信息", "insert into 影像设备类别(类别ID, 类别名称, 影像类别, 类别信息)" +
                        " values(:类别ID, :类别名称, :影像类别, :类别信息)");
     

            sql.AddParameter("类别ID", DbType.String, deviceKind.类别ID);
            sql.AddParameter("类别名称", DbType.String, deviceKind.类别名称);
            sql.AddParameter("影像类别", DbType.String, deviceKind.影像类别);
            sql.AddParameter("类别信息", DbType.String, deviceKind.类别信息.ToString());
             
            DataTable dtResult = _dbHelper.ExecuteSQL(sql); 
        }


        public void UpdateDeviceKindInfo(DeviceKindData deviceKind)
        {
            SQL sql =SqlHelper.CreateSQL("更新设备类别信息",  "Update 影像设备类别 " +
                    " Set 类别名称=:类别名称, 影像类别=:影像类别,类别信息=:类别信息 where 类别ID=:类别ID");

            sql.AddParameter("类别ID", DbType.String, deviceKind.类别ID);
            sql.AddParameter("类别名称", DbType.String, deviceKind.类别名称);
            sql.AddParameter("影像类别", DbType.String, deviceKind.影像类别);
            sql.AddParameter("类别信息", DbType.String, deviceKind.类别信息.ToString());
             
            _dbHelper.ExecuteSQL(sql);

        }

        public void DelDeviceKindInfo(string deviceKindID)
        {
            SQL sql = SqlHelper.CreateSQL("删除设备类别信息", "Delete 影像设备类别 Where 类别ID=:类别ID");

            sql.AddParameter("类别ID", DbType.String, deviceKindID);

            _dbHelper.ExecuteSQL(sql);
             
        }

    }

    /// <summary>
    /// 科室房间模型
    /// </summary>
    public class DepRoomModel : DBModel
    {

        public DepRoomModel(IDBQuery dbHelper) : base(dbHelper) { }

        /// <summary>
        /// 获取所有科室信息
        /// </summary>
        /// <returns>DataTable 科室ID 科室名称</returns>
        public DataTable GetDepts()
        {
            string sql = "Select 科室ID,科室名称 From 影像科室信息 order by 科室名称 ";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询科室信息", sql);

            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 根据科室ID获取科室信息
        /// </summary>
        /// <returns>DataTable 房间ID,科室ID,房间名称</returns>
        public DataTable GetDeptInfo(string strName)
        {
            string sql = "Select 房间ID,科室ID,房间名称 From 影像房间信息 where 科室ID=:科室ID ";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询房间信息", sql);

            return _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("科室ID", DbType.String, strName) });
        }

        /// <summary>
        /// 根据科室ID获取房间信息
        /// </summary>
        /// <returns></returns>
        public string GetRoomInfo(string strID)
        {
            string sql = "Select 房间信息 From 影像房间信息 where 房间ID=:房间ID ";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询房间信息", sql);

            object objRetrue = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] { new SqlParamInfo("房间信息", DbType.String, strID) });
            return (objRetrue == null ? "" : objRetrue.ToString());
        }

        /// <summary>
        /// 新增房间
        /// </summary>
        /// <returns></returns>
        public bool NewRoom(DepRoomData roominfo)
        {
            string sql = "insert into " +
                  " 影像房间信息(房间ID,科室ID,房间名称, 房间信息) " +
                  " values " +
                  " (:房间ID,:科室ID,:房间名称, :房间信息)";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("插入房间信息", sql);

            SqlParamInfo[] sqlPars = GetRoomInfoPars(roominfo);

            DataTable dtResult = _dbHelper.ExecuteSQL(sql, sqlPars);

            return true;
        }

        private SqlParamInfo[] GetRoomInfoPars(DepRoomData roominfo)
        {
            return new SqlParamInfo[] {
                        new SqlParamInfo("房间ID", DbType.String, roominfo.房间ID),
                        new SqlParamInfo("科室ID", DbType.String, roominfo.科室ID),
                        new SqlParamInfo("房间名称", DbType.String, roominfo.房间名称),
                        new SqlParamInfo("房间信息", DbType.String, roominfo.房间信息.ToString()) };
        }

        /// <summary>
        /// 获取房间ID
        /// </summary>
        /// <returns></returns>
        public string GetRoomID(string roomName,string deptID)
        {
            string sql = "Select 房间ID From 影像房间信息 where 房间名称=:房间名称 and 科室ID=:科室ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("获取房间ID", sql);

            object result = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] { new SqlParamInfo("房间名称", DbType.String, roomName),
                                                                                    new SqlParamInfo("科室ID", DbType.String, deptID)});

            return (result == null ? "" : result.ToString());
        }

        /// <summary>
        /// 更新房间
        /// </summary>
        /// <param name="hisServerData"></param>
        public void UpdateRoomInfo(DepRoomData roomInfo)
        {
            string sql = "Update 影像房间信息 " +
                    " Set 房间名称=:房间名称, 房间信息=:房间信息 where 房间ID=:房间ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("更新科室角色信息", sql);

            SqlParamInfo[] sqlPars = new SqlParamInfo[] { new SqlParamInfo("房间名称", DbType.String, roomInfo.房间名称),
                                                            new SqlParamInfo("房间信息", DbType.String, roomInfo.房间信息.ToString()),
                                                            new SqlParamInfo("房间ID", DbType.String, roomInfo.房间ID)};

            _dbHelper.ExecuteSQL(sql, sqlPars);
        }

        /// <summary>
        /// 删除房间
        /// </summary>
        /// <param name="serverID"></param>
        /// <returns></returns>
        public bool DelRoomInfo(string roomID)
        {
            string sql = "Delete 影像房间信息 Where 房间ID=:房间ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("删除科室房间信息", sql);

            _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("房间ID", DbType.String, roomID) });

            return true;

        }

        /// <summary>
        /// 是否存在设备
        /// </summary>
        /// <returns>DataTable 科室ID 科室名称</returns>
        public bool ExistDevice(string roomID)
        {
            string sql = "Select count(设备ID) as 数量 From 影像设备信息 where 房间ID=:房间ID order by 设备名称";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("影像设备信息", sql);
            int count = int.Parse(_dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] { new SqlParamInfo("房间ID", DbType.String, roomID) }).ToString());
            return count > 0;
        }
    }

    public class DepDeviceModel : DBModel
    {

        public DepDeviceModel(IDBQuery dbHelper) : base(dbHelper) { }

        /// <summary>
        /// 根据房间获取设备
        /// </summary>
        /// <returns>DataTable 科室ID 科室名称</returns>
        public DataTable GetDeviceInfo(string roomID)
        {
            string sql = "Select 设备ID,设备名称,影像类别,设备信息 From 影像设备信息 where 房间ID=:房间ID order by 设备名称";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("影像设备信息", sql);

            return _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("房间ID", DbType.String, roomID) });
        }

        /// <summary>
        /// 新增房间
        /// </summary>
        /// <returns></returns>
        public bool AddDevice(DepDeviceData devInfo)
        {
            string sql = "insert into " +
                  " 影像设备信息(设备ID,房间ID,影像类别,设备名称,设备信息) " +
                  " values " +
                  " (:设备ID,:房间ID,:影像类别,:设备名称,:设备信息)";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("插入设备信息", sql);

            SqlParamInfo[] sqlPars = GetDevicePars(devInfo);

            DataTable dtResult = _dbHelper.ExecuteSQL(sql, sqlPars);

            return true;
        }

        /// <summary>
        /// 修改设备
        /// </summary>
        /// <returns></returns>
        public bool UpdateDevice(DepDeviceData devInfo)
        {
            string sql = "update " +
                  " 影像设备信息 set 影像类别=:影像类别,设备名称=:设备名称,设备信息=:设备信息 " +
                  " where 设备ID=:设备ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("修改设备信息", sql);

            SqlParamInfo[] sqlPars = GetDevicePars(devInfo);

            DataTable dtResult = _dbHelper.ExecuteSQL(sql, sqlPars);

            return true;
        }

        /// <summary>
        /// 删除设备
        /// </summary>
        /// <returns></returns>
        public bool DeleteDevice(string deviceID)
        {
            string sql = "delete " +
                  " 影像设备信息  " +
                  " where 设备ID=:设备ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("删除设备", sql);

            DataTable dtResult = _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("设备ID", DbType.String, deviceID) });

            return true;
        }

        private SqlParamInfo[] GetDevicePars(DepDeviceData devInfo)
        {
            return new SqlParamInfo[] {
                        new SqlParamInfo("设备ID", DbType.String, devInfo.设备ID),
                        new SqlParamInfo("房间ID", DbType.String, devInfo.房间ID),
                        new SqlParamInfo("影像类别", DbType.String, devInfo.影像类别),
                        new SqlParamInfo("设备名称", DbType.String, devInfo.设备名称),
                        new SqlParamInfo("设备信息", DbType.String, devInfo.设备信息.ToString()) };
        }

        public DataTable GetImageType()
        {
            string sql = "select 影像类别 from 影像设备类别";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("删除设备信息", sql);

            DataTable dtResult = _dbHelper.ExecuteSQL(sql);
            if (dtResult.Rows.Count == 0)
                MessageBox.Show("请先设置影像类别"); 
            return dtResult;
        }

    }

    

}


