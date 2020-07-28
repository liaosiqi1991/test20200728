using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.Layout
{
    public class StationInfo: IStationInfo
    {
        /// <summary>
        /// 数据服务名称
        /// </summary>
        public string DBServerName { get; set; }

        /// <summary>
        /// 院区编码
        /// </summary>
        public string DistrictCode { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public string DepartmentId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 所属房间ID
        /// </summary>
        public string RoomId { get; set; }

        /// <summary>
        /// 所属房间名称
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// 当前检查设备ID
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 当前检查设备名称
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// 影像存储ID
        /// </summary>
        public string StorageId { get; set; }

        /// <summary>
        /// 当前存储名称
        /// </summary>
        public string StorageName { get; set; }

        /// <summary>
        /// 站点名称
        /// </summary>
        public string StationName { get; set; }

        public StationInfo()
        { 
        }

        /// <summary>
        /// 获取本机站点信息
        /// </summary>
        /// <param name="dbHelper"></param>
        /// <returns></returns>
        static public StationInfo GetLocateStationInfo(string serverName, IDBProvider dbHelper)
        {

            StationConfigModel scm = new StationConfigModel(dbHelper);
            if (scm == null) return null;

            JStationConfig stationConfig = scm.GetStationInfo(Dns.GetHostName());
            if (stationConfig == null) return null;

            StationInfo si = new StationInfo();

            si.DBServerName = serverName; 
            si.DistrictCode = stationConfig.当前院区编码;

            si.DepartmentId = stationConfig.站点所属科室;            
            si.DepartmentName = scm.GetDepartmentNameById(si.DepartmentId);

            si.RoomId = stationConfig.站点所属房间;
            si.RoomName = scm.GetRoomNameById(si.RoomId);

            si.DeviceId = stationConfig.当前检查设备;
            si.DeviceName = scm.GetDeviceNameById(si.DeviceId);

            si.StorageId = stationConfig.当前存储设备;
            si.StorageName = scm.GetStorageNameById(si.StorageId);

            si.StationName = Dns.GetHostName();

            return si;
        }
    }
}
