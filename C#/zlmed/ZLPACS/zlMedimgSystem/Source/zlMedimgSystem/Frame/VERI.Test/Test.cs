using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.VERI.Test
{
    

 
    public class Test: IVerify
    {
        private const string _name = "测试认证";

        public string InterfaceName { get { return _name; } }
        /// <summary>
        /// 方式名称
        /// </summary>
        public string VerifyName { get { return _name; } }


        public void Init(IDBQuery sysDB)
        {

        }

        /// <summary>
        /// 认证配置
        /// </summary>
        public void VerifyConfig()
        {
            MessageBox.Show("测试模块不需要配置");
        }

        /// <summary>
        /// 开始认证
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <param name="attachInfo"></param>
        /// <param name="strErr"></param>
        /// <returns></returns>
        public ILoginUser StartVerify(string user, string pwd, out string attachInfo, out string strErr)
        {
            attachInfo = "";
            strErr = "";

            MessageBox.Show("尚未进行验证实现。");

            return null;
        }

        /// <summary>
        /// 获取验证的参数配置
        /// </summary>
        /// <returns></returns>
        public string GetParContext()
        {
            return "";
        }

        /// <summary>
        /// 设置参数配置
        /// </summary>
        /// <param name="pars"></param>
        public void SetParContext(string pars)
        {

        }
    }
  




}
