using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
    public class StationConfigModel : DBModel
    {
        public const string StationConfigParName = "站点信息";
         
        private ParameterModel _pm = null;
        public StationConfigModel(IDBQuery dbHelper) : base(dbHelper)
        { 
            _pm = new ParameterModel(dbHelper);
        }
         
        /// <summary>
        /// 获取站点信息
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns></returns>
        public JStationConfig GetStationInfo(string stationName)
        {
            DataTable parInfo = _pm.GetParameterInfo(StationConfigParName, stationName);
            if (parInfo == null || parInfo.Rows.Count <= 0) return null;

            ParameterData parData = new ParameterData();
            parData.BindRowData(parInfo.Rows[0]);

            JStationConfig stationConfig = JsonHelper.DeserializeObject<JStationConfig>(parData.参数取值);
            if (stationConfig == null) return null;

            return stationConfig;
        }

        /// <summary>
        /// 设置站点信息
        /// </summary>
        /// <param name="stationConfig"></param>
        public void SetStationInfo(JStationConfig stationConfig, string stationName)
        {
            ParameterData parData = new ParameterData();
            parData.参数ID = SqlHelper.GetCmpUID();
            parData.参数名称 = "站点信息";
            parData.参数标记 = stationName;
            parData.参数取值 = stationConfig.ToString();

            _pm.WriteParameter(parData);
        }

        /// <summary>
        /// 获取科室名称
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public string GetDepartmentNameById(string departmentId)
        {
            if (string.IsNullOrEmpty(departmentId)) return "";

            SQL sql = new SQL("查询科室名称", "select 科室名称 from 影像科室信息 where 科室ID=:科室ID");
            sql.AddParameter("科室ID", DbType.String, departmentId);

            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null) ? "" : value.ToString();
        }

        /// <summary>
        /// 获取科室信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepartment()
        {
            string sql = "Select 科室ID,科室名称 From 影像科室信息 order by 科室名称 ";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询角色科室信息", sql);

            return _dbHelper.ExecuteSQL(sql);
        }


        /// <summary>
        /// 获取房间名称
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public string GetRoomNameById(string roomId)
        {
            if (string.IsNullOrEmpty(roomId)) return "";

            SQL sql = new SQL("查询房间名称", "select 房间名称 from 影像房间信息 where 房间ID=:房间ID");
            sql.AddParameter("房间ID", DbType.String, roomId);

            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null) ? "" : value.ToString();
        }

        /// <summary>
        /// 获取设备ID
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public string GetDeviceNameById(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId)) return "";

            SQL sql = new SQL("查询设备名称", "select 设备名称 from 影像设备信息 where 设备ID=:设备ID");
            sql.AddParameter("设备ID", DbType.String, deviceId);

            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null) ? "" : value.ToString();
        }

        /// <summary>
        /// 获取存储名称
        /// </summary>
        /// <param name="storageId"></param>
        /// <returns></returns>
        public string GetStorageNameById(string storageId)
        {
            if (string.IsNullOrEmpty(storageId)) return "";

            SQL sql = new SQL("查询存储名称", "select 存储名称 from 影像存储信息 where 存储ID=:存储ID");
            sql.AddParameter("存储ID", DbType.String, storageId);

            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null) ? "" : value.ToString();
        }

        /// <summary>
        /// 获取存储信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetStorageInfo()
        {
            string sql = "select 存储ID,存储名称,存储信息 from 影像存储信息";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询影像存储信息", sql);

            return _dbHelper.ExecuteSQL(sql);
        }

        /// <summary>
        /// 获取科室房间
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public DataTable GetRoomInfo(string departmentId)
        {
            string sql = "select 房间ID,房间名称,房间信息 from 影像房间信息 where 科室ID=:科室ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询影像房间信息", sql);

            return _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("科室ID", DbType.String, departmentId) });
        }

        /// <summary>
        /// 获取房间设备
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public DataTable GetDeviceInfo(string roomId)
        {
            string sql = "select 设备ID,设备名称,设备信息 from 影像设备信息 where 房间ID=:房间ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询影像设备信息", sql);

            return _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("房间ID", DbType.String, roomId) });
        }
    }
}
