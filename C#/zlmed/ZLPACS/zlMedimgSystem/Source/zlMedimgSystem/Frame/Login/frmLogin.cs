using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using zlMedimgSystem.Services;
using System.Configuration;
using zlMedimgSystem.Interface;
using System.Reflection;

namespace zlMedimgSystem.Login
{
    public partial class frmLogin : Form
    { 
        private ILoginUser _loginUser;
        private string _password;
        private string _serverName; 

        private IDBProvider _dbProvider = null;

        private IVerify _verifyDefault = null;
        private bool _allowThridVerify = true;
        private DelegateBusinessVerify _businessVerify = null;

        private ServerManager _sm = null; 
        public frmLogin(IVerify sysDefaultVerify, bool allowThridVerify, DelegateBusinessVerify businessVerify)
        {
            InitializeComponent();

            _verifyDefault = sysDefaultVerify;
            _allowThridVerify = allowThridVerify;
            _businessVerify = businessVerify;
        }

        public ILoginUser LoginUser
        {
            get
            {
                return _loginUser;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

        }

        public string ServerName
        {
            get
            {
                return _serverName;
            }
        }


        public IDBProvider DBProvider
        {
            get { return _dbProvider; }
        }
 
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
 

                int i;
                _sm = new ServerManager();
                _sm.LoadFromFile();
                 
                foreach (ServerInfo si in _sm)
                { 
                    if (si.IsThridDBSource == false)
                    {
                        cbxServer.Items.Add(si.ServerAlias);
                    }
                }

                if (cbxServer.Items.Count <= 0) return;

                string loginServer = AppSetting.ReadSetting("loginserver");

                if (string.IsNullOrEmpty(loginServer) == false)
                {
                    i = cbxServer.Items.IndexOf(loginServer);

                    if (i >= 0) cbxServer.SelectedIndex = i;
                }
                else
                {
                    cbxServer.SelectedIndex = 0;
                }

                txtUser.Text = AppSetting.ReadSetting("loginuser"); 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

 

        private void sbutCancel_Click(object sender, EventArgs e)
        {
            _dbProvider = null;

            Close();
        }

        private void sbutLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ServerInfo si = _sm.FindAlias(cbxServer.Text);



                if (si == null)
                {
                    MessageBox.Show("未找到对应的服务器配置信息。", "提示");
                    return;
                }

                if (string.IsNullOrEmpty(si.ServerDriverFile))
                {
                    MessageBox.Show("未配置数据访问程序集。", "提示");
                    return;
                }

                IDBProvider dbProvider = null;


                string modulePath = System.Windows.Forms.Application.StartupPath + @"\" + si.ServerDriverFile;

                if (File.Exists(modulePath) == true)
                {
                    FileInfo fi = new FileInfo(modulePath);

                    string assemblyName = fi.Name.Replace(fi.Extension, "");
                    string[] tmp = ("..." + assemblyName).Split('.');
                    string objName = tmp[tmp.Length - 1];

                    dbProvider = (IDBProvider)Assembly.LoadFile(modulePath).CreateInstance(assemblyName + "." + objName);
                }

                if (dbProvider == null)
                {
                    MessageBox.Show("数据访问实例创建失败。", "提示");
                    return;
                }


                dbProvider.Init(si.ServerIP, si.ServerPort, si.ServerInstance, si.GrantAccount, si.GrantPwd);

                string strErr = "";
                IDbConnection dc = dbProvider.Open(ref strErr);

                if (dc == null)
                {
                    MessageBox.Show("数据服务访问失败：" + strErr, "提示");
                    return;
                }


                //身份验证...
                IVerify verify = null;
                if (string.IsNullOrEmpty(si.AuthenticationWay.Trim()) || _allowThridVerify == false)
                {
                    //未配置认证或不允许三方认证时，使用系统默认认证方式
                    if (_verifyDefault != null) verify = _verifyDefault;
                }
                else
                {
                    modulePath = System.Windows.Forms.Application.StartupPath + @"\" + si.AuthenticationDirverFile;
                    if (File.Exists(modulePath) == true)
                    {
                        FileInfo fiVerify = new FileInfo(modulePath);

                        string assemblyName = fiVerify.Name.Replace(fiVerify.Extension, "");
                        string[] tmp = ("..." + assemblyName).Split('.');
                        string objName = tmp[tmp.Length - 1];

                        verify = (IVerify)Assembly.LoadFile(modulePath).CreateInstance(assemblyName + "." + objName);

                    }
                    else
                    {
                        MessageBox.Show("认证驱动文件不存在，暂不能登录。", "提示");
                        return;
                    }
                }

                if (verify == null)
                {
                    MessageBox.Show("认证对象不能实例化。", "提示");
                    return;
                }

                string attachInfo = "";

                verify.Init(dbProvider);
                _loginUser = verify.StartVerify(txtUser.Text, txtPwd.Text, out attachInfo, out strErr);

                if (_loginUser == null)
                {
                    if (string.IsNullOrEmpty(strErr) == false) MessageBox.Show("认证失败：" + strErr, "提示");
                    return;
                }

                _serverName = cbxServer.Text; 
                _password = txtPwd.Text;

                _dbProvider = dbProvider;

                if (_businessVerify?.Invoke(_dbProvider, _loginUser) == false)
                {
                    _dbProvider = null;
                    _loginUser = null;
                    _password = "";
                    _serverName = "";

                    return;
                }

                try
                {
                    AppSetting.BatchBegin();
                    try
                    {
                        AppSetting.WriteSetting("loginserver", cbxServer.Text);
                        AppSetting.WriteSetting("loginuser", txtUser.Text);
                    }
                    finally
                    {
                        AppSetting.BatchCommit();
                    }
                }
                catch (Exception ex)
                {
                    MsgBox.ShowException(ex, this);
                }

                Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //try
            //{
            //    _ca.AppSettings.Settings["loginserver"].Value = cbxServer.Text;
            //    _ca.AppSettings.Settings["loginuser"].Value = txtUser.Text;

            //    _ca.Save(ConfigurationSaveMode.Modified);
            //}
            //catch (Exception ex)
            //{
            //    MsgBox.ShowException(ex, this);
            //}
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if ((sender as Form).ActiveControl.Equals(txtPwd))
                {
                    sbutLogin_Click(sender, e);
                }
                else
                {
                    SendKeys.Send("{tab}");
                }
            }
        }
    }
}
