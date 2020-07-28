using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.Interface
{
    public interface IStationInfo
    {
        /// <summary>
        /// 数据服务名称
        /// </summary>
        string DBServerName { get; set; }
        /// <summary>
        /// 院区编码
        /// </summary>
        string DistrictCode { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        string DepartmentId { get; set; }
         
        /// <summary>
        /// 部门名称
        /// </summary>
        string DepartmentName { get; set; }

        string RoomId { get; set; }
        string RoomName { get; set; }

        string DeviceId { get; set; }
        string DeviceName { get; set; }
        
        string StorageId { get; set; }
        string StorageName { get; set; }

        /// <summary>
        /// 站点名称
        /// </summary>
        string StationName { get; set; }
    }
}
