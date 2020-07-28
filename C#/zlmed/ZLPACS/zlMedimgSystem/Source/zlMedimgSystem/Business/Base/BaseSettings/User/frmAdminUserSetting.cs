using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.BusinessBase;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmAdminUserSetting : Form, ISetting
    {
        private IDBQuery _dbHelper = null;
        private UserModel _um = null;
        private ILoginUser _loginUser = null;
        public frmAdminUserSetting()
            :this(null, null)
        { 
        }

        public frmAdminUserSetting(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            Init(dbHelper, loginUser);
        }

        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {
            _dbHelper = dbHelper;
            _loginUser = loginUser;
            _um = new UserModel(dbHelper);
        }

        public void RefreshSetting()
        {
            UserInfoData adminUser = _um.GetUserInfoByUserID(UserModel.ADMIN_ID);
            if (adminUser == null) return;

            txtAdminName.Text = adminUser.系统账号;
            txtAdminName.Tag = adminUser;

            txtPwd.Text = UserModel.DecryPwd(adminUser.账号信息.密码); 
        }

        private void butApply_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfoData adminUser = null;

                if (txtSurePwd.Text != txtPwd.Text)
                {
                    MessageBox.Show("确认密码录入不一致，请重新录入。", "提示");
                    txtSurePwd.Focus();
                    return;
                }

                if (txtAdminName.Tag == null)
                {
                    string userId = _um.GetUserIDWithAccountName(txtAdminName.Text);
                    if (string.IsNullOrEmpty(userId) == false)
                    {
                        MessageBox.Show("账号名称已经存在。", "提示");
                        txtAdminName.Focus();
                        return;
                    }

                    adminUser = new UserInfoData();
                    adminUser.用户ID = UserModel.ADMIN_ID;
                    adminUser.系统账号 = txtAdminName.Text;
                    adminUser.用户名称 = "管理员";
                    adminUser.账号信息.密码 = UserModel.EncryPwd(txtPwd.Text);
                    adminUser.账号信息.创建日期 = _um.GetServerDate();

                    _um.NewUser(adminUser, null);
                }
                else
                {
                    string userId = _um.GetUserIDWithAccountName(txtAdminName.Text);
                    if (string.IsNullOrEmpty(userId) == false && userId.Equals(UserModel.ADMIN_ID) == false)
                    {
                        MessageBox.Show("账号名称已经存在。", "提示");
                        txtAdminName.Focus();
                        return;
                    }

                    adminUser = txtAdminName.Tag as UserInfoData;

                    adminUser.系统账号 = txtAdminName.Text;
                    adminUser.账号信息.密码 = UserModel.EncryPwd(txtPwd.Text);

                    _um.UpdateUserInfo(adminUser, null);
                }

                ButtonHint.Start(butApply, "OK");
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }

        private void frmAdminUserSetting_Resize(object sender, EventArgs e)
        {
            try
            {
                panel1.Left = (this.Width - panel1.Width) / 2;
                panel1.Top = (this.Height - panel1.Height) / 2;

                if (panel1.Left <= 0) panel1.Left = 0;
                if (panel1.Top <= 0) panel1.Top = 0;
            }
            catch
            { }
        }

        private void frmAdminUserSetting_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshSetting();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}
