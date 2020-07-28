using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using ZLSoft.HIS.Library;

namespace zlMedimgSystem.VERI.His
{
    public class His : IVerify
    {

        private const string _name = "HIS认证";

        private IDBQuery _dbLocal = null;

        public string InterfaceName { get { return _name; } }

        /// <summary>
        /// 方式名称
        /// </summary>
        public string VerifyName { get { return _name; } }

        public void Init(IDBQuery sysDB)
        {
            _dbLocal = sysDB;
        }

        /// <summary>
        /// 认证配置
        /// </summary>
        public void VerifyConfig()
        {
            using (frmCfg objCfg = new frmCfg())
            {
                objCfg.ShowDialog();
            }

        }

        /// <summary>
        /// 开始认证
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <param name="attachInfo"></param>
        /// <param name="strErr"></param>
        /// <returns></returns>
        public ILoginUser StartVerify(string userAccount, string pwd, out string attachInfo, out string strErr)
        {

            attachInfo = "";
            strErr = "";

            string verifyHint = "(" + _name + ")";

            string strCfgFile = ConfigHelper.CreateConfig(ConfigHelper.GetCfgName());
            Configuration ca = ConfigurationManager.OpenExeConfiguration(strCfgFile);

            bool hasKey = ca.AppSettings.Settings.AllKeys.Contains("HIS认证服务名称");


            if (hasKey == false)
            {
                MessageBox.Show(verifyHint + "未找到HIS认证的服务名称。", "提示");
                return null;
            }

            //开始进行认证
            string serverName = ca.AppSettings.Settings["HIS认证服务名称"].Value;

            object dbCon = null;

            try
            {
                dbCon = Helper.GetConnection(serverName, pwd, userAccount);
            }
            catch(Exception ex)
            {
                if (ex.Message.ToUpper().IndexOf("ORA-01017") >= 0)
                {
                    MessageBox.Show(verifyHint + "无效的用户或密码，拒绝登录。", "提示");
                    return null;
                }
                else
                {
                    throw new Exception(verifyHint + "用户认证异常", ex);
                }
            }

            if (dbCon == null)
            {
                MessageBox.Show(verifyHint + "用户认证失败，请联系管理员。", "提示");
                return null;
            }

            //判断是否绑定本地系统账号
            UserModel um = new UserModel(_dbLocal);
            UserInfoData userData = um.GetUserInfoByAccountName(userAccount);
            if (userData == null)
            {
                MessageBox.Show(verifyHint + "当前系统未绑定此用户账号，请联系管理员。", "提示");
                return null;
            }

            if (userData.用户ID.Equals(UserModel.ADMIN_ID))
            {
                MessageBox.Show(verifyHint + "不能使用管理员账号登录此系统。", "提示");
                return null;
            }
             
            UserInfoData userInfo = um.GetUserInfoByAccountName(userAccount);

            if (userInfo == null)
            {
                MessageBox.Show("未获取到对应的用户信息。", "提示");
                return null;
            }

            UserData loginUser = new UserData();

            loginUser.UserId = userInfo.用户ID;
            loginUser.Account = userInfo.系统账号;
            loginUser.Name = userInfo.用户名称;
            loginUser.Level = userInfo.职称级别;
            loginUser.SignImg = userInfo.签名图片;
            loginUser.Pwd =pwd;

            loginUser.AssistUserInfo1.Account = userInfo.系统账号;
            loginUser.AssistUserInfo1.Name = userInfo.用户名称;
            loginUser.AssistUserInfo1.UserId = userInfo.用户ID;
            loginUser.AssistUserInfo1.SignImg = userInfo.签名图片;

            loginUser.AssistUserInfo2.Account = userInfo.系统账号;
            loginUser.AssistUserInfo2.Name = userInfo.用户名称;
            loginUser.AssistUserInfo2.UserId = userInfo.用户ID;
            loginUser.AssistUserInfo2.SignImg = userInfo.签名图片;

            loginUser.AssistUserInfo3.Account = userInfo.系统账号;
            loginUser.AssistUserInfo3.Name = userInfo.用户名称;
            loginUser.AssistUserInfo3.UserId = userInfo.用户ID;
            loginUser.AssistUserInfo3.SignImg = userInfo.签名图片;

            //同步认证密码
            userData.账号信息.密码 = UserModel.EncryPwd(pwd);
            um.UpdateUserInfo(userData, null);

            return loginUser;
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
