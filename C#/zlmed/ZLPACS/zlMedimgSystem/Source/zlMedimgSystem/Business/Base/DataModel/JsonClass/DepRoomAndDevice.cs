using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
    /// <summary>
    /// 设备类别
    /// </summary>
    public class DeviceKindBase:DataBase
    {
        public string 类别ID { get; set; }
        public string 类别名称 { get; set; }
        public string 影像类别 { get; set; } 
    }

    public class JDeviceKindInfo: DeviceKindBase, IJsonField
    {
        public string 类别描述 { get; set; }
        public DateTime 创建日期 { set; get; }

        public void CopyBasePro(DeviceKindBase deviceKindBase)
        {
            base.CopyFrom<DeviceKindBase>(deviceKindBase);
        }
    }

    public class DepRoomBase : DataBase
    {
        public string 房间ID { set; get; }
        public string 科室ID { set; get; }
        public string 房间名称 { set; get; }


    }

    public class JRoomInfo : DepRoomBase, IJsonField
    {
        public string 备注描述 { set; get; }
        public string 位置 { set; get; }
        public string 负责人 { set; get; }
        public string 创建日期 { set; get; }
        public void CopyBasePro(DepRoomBase roomBase)
        {
            base.CopyFrom<DepRoomBase>(roomBase);
        }
    }

    public class DeviceBase : DataBase
    {
        public string 设备ID { set; get; }
        public string 房间ID { set; get; }
        public string 影像类别 { set; get; }
        public string 设备名称 { set; get; }

    }

    public class JRoomDeviceInfo : DeviceBase, IJsonField
    {
        public string 负责人 { set; get; }
        public bool 是否启用 { set; get; }
        public string 设备说明 { set; get; }
        public string 创建日期 { set; get; }
        public void CopyBasePro(DeviceBase deviceBase)
        {
            base.CopyFrom<DeviceBase>(deviceBase);
        }
    }

    public class JDicomCommCfgInfo : IJsonField
    {
        public string 设备AE { set; get; }
        public string 设备IP { set; get; }
        public string 设备端口 { set; get; }

    }
}
