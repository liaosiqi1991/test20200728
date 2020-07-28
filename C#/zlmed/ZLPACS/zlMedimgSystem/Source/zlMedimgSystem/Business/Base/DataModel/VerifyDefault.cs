using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.DataModel
{
    public class VerifyDefault : IVerify
    {
        private const string _name = "System";

        private bool _isSettingTools = false;
        public string InterfaceName { get { return _name; } }


        private IDBQuery _dbQuery = null;

        public VerifyDefault()
        {

        }

        public VerifyDefault(bool isSettingTools)
            :this(null, isSettingTools)
        { 
        }

        public VerifyDefault(IDBQuery dbQuery)
            :this(dbQuery, false)
        {
           
        }

        public VerifyDefault(IDBQuery dbQuery, bool isSettingTools)
        {
            _isSettingTools = isSettingTools;
            _dbQuery = dbQuery;
        }


        /// <summary>
        /// 方式名称
        /// </summary>
        public string VerifyName { get { return _name; } }


        public void Init(IDBQuery sysDB)
        {
            _dbQuery = sysDB;
        }

        /// <summary>
        /// 认证配置
        /// </summary>
        public void VerifyConfig()
        {
            return;
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

            //验证用户是否有效
            UserModel um = new UserModel(_dbQuery); 
            UserInfoData userData = um.GetUserInfoByAccountName(userAccount);

            if (userData == null)
            {
                if (_isSettingTools == false)
                {
                    MessageBox.Show("未检索到对应用户信息,不能进行登录。", "提示");
                    return null;
                }
                else
                {
                    //登录系统配置设置
                    if (userAccount.Equals(UserModel.ADMIN_NAME))
                    {
                        UserData adminUser = new UserData();

                        adminUser.UserId = UserModel.ADMIN_ID;
                        adminUser.Name = "管理员";
                        adminUser.Account = userAccount;
                        adminUser.Level = 0;
                    
                        return adminUser;
                    }
                    else
                    {
                        MessageBox.Show("不能识别的账号,不能进行登录。", "提示");
                        return null;
                    }
                }
            }

            if (_isSettingTools == true)
            {
                if (userData.用户ID.Equals(UserModel.ADMIN_ID) == false)
                {
                    MessageBox.Show("非管理员账号,不能进行登录。", "提示");
                    return null;
                }
            }

            //用户密码判断
            if (UserModel.DecryPwd(userData.账号信息.密码).Equals(pwd) == false)
            {
                MessageBox.Show("密码输入错误,不能进行登录。", "提示");
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
            loginUser.Pwd = pwd;

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
            return;
        }
    }
}
