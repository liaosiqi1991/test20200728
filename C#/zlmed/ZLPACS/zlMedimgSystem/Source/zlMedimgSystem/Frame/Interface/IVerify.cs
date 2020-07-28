using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.Interface
{

    public interface IVerify: IInterfaceName
    {
        void Init(IDBQuery sysDB);

        /// <summary>
        /// 方式名称
        /// </summary>
        string VerifyName { get; }

        /// <summary>
        /// 认证配置
        /// </summary>
        void VerifyConfig();

        /// <summary>
        /// 开始认证
        /// </summary>
        /// <param name="userAccount"></param>
        /// <param name="pwd"></param>
        /// <param name="attachInfo"></param>
        /// <param name="strErr"></param>
        /// <returns></returns>
        ILoginUser StartVerify(string userAccount, string pwd, out string attachInfo, out string strErr);

        /// <summary>
        /// 获取验证的参数配置
        /// </summary>
        /// <returns></returns>
        string GetParContext();

        /// <summary>
        /// 设置参数配置
        /// </summary>
        /// <param name="pars"></param>
        void SetParContext(string pars);
    }
}
