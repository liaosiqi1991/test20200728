using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;
using zlMedimgSystem.Interface;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace zlMedimgSystem.APPLY.ZLSoftApply
{
    public partial class frmHisDBConfig : Form
    { 
        private InterfaceCfg _cfg = null;
        private bool _isOk = false;
        private ServerEnum _se = null;
        public frmHisDBConfig()
        {
            InitializeComponent();

            _se = new ServerEnum();
        }

        public bool ShowCfg(InterfaceCfg cfg, IWin32Window owner)
        {
            _isOk = false;
            _cfg = cfg;

            this.ShowDialog(owner);

            return _isOk;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                _isOk = false;
                this.Close();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cbxServerType.Text))
                {
                    MessageBox.Show("服务器类型不允许为空。", "提示");
                    cbxServerType.Focus();
                    return;
                }
                

                //IP地址不能为空，需要验证IP地址格式
                if (string.IsNullOrEmpty(txtIp.Text) == false)
                {
                    string strPattern = @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$";
                    if (Regex.IsMatch(txtIp.Text.Trim(), strPattern) == false)
                    {
                        txtIp.Focus();
                        txtIp.SelectAll();
                        MessageBox.Show("服务器IP地址格式不正确。", "提示");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("服务器IP不允许为空。", "提示");
                    txtIp.Focus();
                    return;
                }
                //端口不为空时，只能是数字
                if (string.IsNullOrEmpty(txtPort.Text) == false)
                {
                    string strPattern = @"^[0-9]+$";
                    Regex reg = new Regex(strPattern);
                    if (reg.Match(txtPort.Text.Trim()).Success == false)
                    {
                        txtPort.Focus();
                        txtPort.SelectAll();
                        MessageBox.Show("端口只能是数字，格式不正确。", "提示");
                        return ;
                    }
                }
                else
                {
                    MessageBox.Show("服务器端口不允许为空。", "提示");
                    txtPort.Focus();
                    txtPort.SelectAll();
                    return;
                }


                if (string.IsNullOrEmpty(txtInstance.Text))
                {
                    MessageBox.Show("服务器实例不允许为空。", "提示");
                    txtInstance.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtUserAccount.Text))
                {
                    MessageBox.Show("授权账号不允许为空。", "提示");
                    txtUserAccount.Focus();
                    return;
                }

                _cfg.ServerType = cbxServerType.Text;
                _cfg.InterfaceFile = txtAssembly.Text;
                _cfg.Ip = txtIp.Text;
                _cfg.Port = Convert.ToInt32(txtPort.Text);
                _cfg.Instance = txtInstance.Text;
                _cfg.Account = txtUserAccount.Text;
                _cfg.Pwd = txtUserPwd.Text;


                _isOk = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butVerify_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAssembly.Text))
                {
                    MessageBox.Show("未指定对应的服务驱动文件，不能进行验证。", "提示");
                    return;
                }
                string modulePath = System.Windows.Forms.Application.StartupPath + @"\" + txtAssembly.Text;

                IDBProvider dbProvide = null;
                if (File.Exists(modulePath) == true)
                {
                    FileInfo fi = new FileInfo(modulePath);

                    string assemblyName = fi.Name.Replace(fi.Extension, "");
                    string[] tmp = ("..." + assemblyName).Split('.');
                    string objName = tmp[tmp.Length - 1];

                    dbProvide = (IDBProvider)Assembly.LoadFile(modulePath).CreateInstance(assemblyName + "." + objName);
                }

                if (dbProvide != null)
                {
                    dbProvide.Init(txtIp.Text, int.Parse(txtPort.Text), txtInstance.Text, txtUserAccount.Text, txtUserPwd.Text);

                    string strError = "";
                    IDbConnection dc = dbProvide.Open(ref strError);

                    if (dc == null)
                    {
                        MessageBox.Show("验证失败：" + strError, "提示");
                    }
                    else
                    {
                        MessageBox.Show("验证成功。", "提示");
                    }

                    return;
                }
                else
                {
                    MessageBox.Show("数据访问实例创建失败。", "提示");
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmHisDBConfig_Load(object sender, EventArgs e)
        {
            try
            { 
                foreach (string key in _se.Keys)
                {
                    cbxServerType.Items.Add(key);
                    txtAssembly.Text = _se[key];
                }
                if (cbxServerType.Items.Count > 0) cbxServerType.SelectedIndex = 0;


                if (_cfg == null) return;

                cbxServerType.Text = _cfg.ServerType;
                txtAssembly.Text = _cfg.InterfaceFile;
                txtIp.Text = _cfg.Ip;
                if (_cfg.Port == 0)
                {
                    txtPort.Text = "1521";
                }
                else
                {
                    txtPort.Text = _cfg.Port.ToString();
                }
                 
                txtInstance.Text = _cfg.Instance;
                txtUserAccount.Text = _cfg.Account;
                txtUserPwd.Text = _cfg.Pwd;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxServerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_se.ContainsKey(cbxServerType.Text))
                {
                    txtAssembly.Text = _se[cbxServerType.Text];
                }
                else
                {
                    txtAssembly.Text = "";
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}
