using System;
using System.Collections.Generic;
using System.Linq;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using System.Data;
using System.Collections;
using System.Reflection;

namespace zlMedimgSystem.DataModel
{
    public class DepRoomData : DepRoomBase, IBizBindRow
    {
        private DataRow _bindRow = null;
        private BizRow _DepRoomInfoRow = null;

        public DepRoomBase 房间 { get; set; }

        public DataRow GetBindRow()
        {
            return _bindRow;
        }

        public DepRoomData()
            : this(null)
        {
            房间ID = "";
            科室ID = "";
            房间名称 = "";
            房间信息 = new RoomJInfo();
        }

        public DepRoomData(DataRow r)
        {
            _bindRow = r;

            if (_DepRoomInfoRow == null)
            {
                _DepRoomInfoRow = new BizRow();

                _DepRoomInfoRow.OnJsonConvert += ConvertJson;
            }

            if (r != null)
            {
                _DepRoomInfoRow.RowConvert(r, this, true);
            }
            else
            {
                房间 = new DepRoomBase();
            }
        }

        private IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(DepRoomBase).FullName)
                {
                    return JsonHelper.DeserializeObject<DepRoomBase>(jsonData);
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
        private DataRow _bindRow = null;
        private BizRow _DepRoomInfoRow = null;

        public DeviceBase 设备 { get; set; }

        public DataRow GetBindRow()
        {
            return _bindRow;
        }

        public DepDeviceData()
            : this(null)
        {
            设备ID = "";
            房间ID = "";
            影像类别 = "";
            设备名称 = "";
            设备信息 = new DeviceJInfo();

            设备信息.创建日期 = System.DateTime.Now.ToString();
            设备信息.是否禁用 = false.ToString();
            设备信息.设备说明 = "";
            设备信息.负责人 = "";
            
        }

        public DepDeviceData(DataRow r)
        {
            _bindRow = r;

            if (_DepRoomInfoRow == null)
            {
                _DepRoomInfoRow = new BizRow();

                _DepRoomInfoRow.OnJsonConvert += ConvertJson;
            }

            if (r != null)
            {
                _DepRoomInfoRow.RowConvert(r, this, true);
            }
            else
            {
                设备 = new DeviceBase();
            }
        }

        private IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(DeviceBase).FullName)
                {
                    return JsonHelper.DeserializeObject<DeviceBase>(jsonData);
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
        public string GetDoomInfo(string strID)
        {
            object objRetrue = null;
            string sql = "Select 房间信息 From 影像房间信息 where 房间ID=:房间ID ";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("查询房间信息", sql);

            objRetrue = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] { new SqlParamInfo("房间信息", DbType.String, strID) });
            if (objRetrue == null)
            {
                return "";
            }
            return objRetrue.ToString();
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
        public string GetRoomID(string roomName)
        {
            string sql = "Select 房间ID From 影像房间信息 where 房间名称=:房间名称";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("获取房间ID", sql);

            object result = _dbHelper.ExecuteSQLOneOutput(sql, new SqlParamInfo[] { new SqlParamInfo("房间名称", DbType.String, roomName) });

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
        public bool SaveDevice(DepDeviceData devInfo)
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

        private SqlParamInfo[] GetDevicePars(DepDeviceData devInfo)
        {
            return new SqlParamInfo[] {
                        new SqlParamInfo("设备ID", DbType.String, devInfo.设备ID),
                        new SqlParamInfo("房间ID", DbType.String, devInfo.房间ID),
                        new SqlParamInfo("影像类别", DbType.String, devInfo.影像类别),
                        new SqlParamInfo("设备名称", DbType.String, devInfo.设备名称),
                        new SqlParamInfo("设备信息", DbType.String, devInfo.设备信息.ToString()) };
        }

        public bool DelAllDevices(string roomID)
        {
            _dbHelper.TransactionBegin();
            string sql = "delete from " +
                  " 影像设备信息 " +
                  " where " +
                  " 房间ID=:房间ID";
            sql = SqlHelper.GetSqlBiz().GetSqlContext("删除设备信息", sql);

            DataTable dtResult = _dbHelper.ExecuteSQL(sql, new SqlParamInfo[] { new SqlParamInfo("房间ID", DbType.String, roomID) });

            _dbHelper.TransactionCommit();
            return true;
        }

    }

    

}


