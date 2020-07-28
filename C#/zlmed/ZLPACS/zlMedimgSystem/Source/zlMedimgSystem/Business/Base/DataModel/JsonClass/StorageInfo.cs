using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;
namespace zlMedimgSystem.DataModel
{
    public class StorageBase : DataBase
    {
        public string 存储ID { get; set; }
        public string 存储名称 { get; set; }

        //public StorageBase() { }
    }

    public class JStorageInfo : StorageBase, IJsonField
    {
        public string 设备类型 { get; set; }
        public string IP地址 { get; set; }
        public string 端口 { get; set; }
        public string 目录 { get; set; }
        public string 用户名 { get; set; }
        public string 密码 { get; set; }
        public bool 是否停用 { get; set; }
        public string 镜像存储ID { get; set; }
        public DateTime 创建时间 { get; set; }
        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}
        public JStorageInfo() { }
        public JStorageInfo(string storeageType,string ip,string port,string catalogue,string username,string password,bool state,DateTime createdate)
        {
            this.设备类型 = storeageType;
            this.IP地址 = ip;
            this.端口 = port;
            this.目录 = catalogue;
            this.用户名 = username;
            this.密码 = password;
            this.是否停用 = state;
            this.创建时间 = createdate;
        }

        public void CopyBasePro(StorageBase storageBase)
        {
            base.CopyFrom<StorageBase>(storageBase);
        }
    }



}
