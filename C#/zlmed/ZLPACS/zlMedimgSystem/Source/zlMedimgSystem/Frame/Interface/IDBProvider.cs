using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.Interface
{
    public interface IDBProvider:IDBQuery, IInterfaceName
    {
        /// <summary>
        /// 提供则名称
        /// </summary>
        string ProviderName { get; }

        /// <summary>
        /// 根据本地服务器配置初始化
        /// </summary>
        /// <param name="serverName"></param>
        void Init(string serverName, string user, string pwd);

        /// <summary>
        /// 根据ip端口初始化
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="Instance"></param>
        void Init(string ip, int port, string Instance, string user, string pwd);

        /// <summary>
        /// 打开连接
        /// </summary>
        /// <returns></returns>
        IDbConnection Open(ref string strError);

        /// <summary>
        /// 关闭连接
        /// </summary>
        void Close();



        ///// <summary>
        ///// 登录数据库
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <param name="pwd"></param>
        ///// <returns></returns>
        //bool Login(string userName, string pwd);
    }
}
