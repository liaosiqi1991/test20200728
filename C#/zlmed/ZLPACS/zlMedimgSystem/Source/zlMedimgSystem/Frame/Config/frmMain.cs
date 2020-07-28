using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;
using zlMedimgSystem.Interface;
using System.Reflection;

namespace zlMedimgSystem.DBConfig
{
    public partial class frmMain : Form
    {

        private ServerManager _sm = new ServerManager();
        private ServerEnum _se = null;
        private VerifyEnum _ve = null;

        private bool _isModify = false;
        private bool _isBinding = false;
        public frmMain()
        {
            InitializeComponent(); 
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _se = new ServerEnum();
            foreach (string key in _se.Keys)
            {
                cbxServerType.Items.Add(key);
                txtAssembly.Text = _se[key];
            }
            if (cbxServerType.Items.Count > 0) cbxServerType.SelectedIndex = 0;


            cbxVerifyWay.Items.Add("");

            _ve = new VerifyEnum();
            foreach (string key in _ve.Keys)
            {
                cbxVerifyWay.Items.Add(key);
                //txtVerifyAssembly.Text = _ve[key];
            }
            if (cbxVerifyWay.Items.Count > 0) cbxVerifyWay.SelectedIndex = 0;


            _sm.LoadFromFile();

            
            ReindData();

            SyncSelRowData();
        }

        private void CopyCfgElement(ref ServerInfo si)
        {
            si.ServerAlias = textAlias.Text;
            si.ServerType = cbxServerType.Text;
            si.ServerIP = txtIp.Text;
            si.ServerPort = int.Parse(txtPort.Text);
            si.ServerInstance = txtInstance.Text;
            si.GrantAccount = txtUserAccount.Text;
            si.GrantPwd = txtUserPwd.Text;
            si.ServerDriverFile = txtAssembly.Text;
            si.AuthenticationWay = cbxVerifyWay.Text;
            si.AuthenticationDirverFile = txtVerifyAssembly.Text; 
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (Verify() == false) return;

                ServerInfo si = new ServerInfo();

                CopyCfgElement(ref si);

                _sm.Add(si);

                _isModify = true;

                ReindData();

                _sm.SaveToFile();

                LocateRow(si);

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }

        private void LocateRow(ServerInfo si)
        {
            int oldSelIndex = -1;
            int newSelIndex = -1;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                oldSelIndex = dataGridView1.SelectedRows[0].Index;
            }

            foreach (DataGridViewRow dvr in dataGridView1.Rows)
            {
                if (dvr.Cells["ServerAlias"].Value.ToString() == si.ServerAlias)
                {
                    dvr.Selected = true;
                    newSelIndex = dvr.Index;

                    break;
                }
            }

            if (oldSelIndex == newSelIndex) SyncSelRowData();
        }

      
        private bool Verify(bool isModify = false)
        {
            if (string.IsNullOrEmpty(textAlias.Text))
            { 
                MessageBox.Show("别名不允许为空。", "提示");
                return false;
            }


            ServerInfo si = _sm.FindAlias(textAlias.Text);
            if (si != null )                
            {
                if (isModify )
                {
                    if (si.Key.Equals(textAlias.Tag) == false)
                    {
                        MessageBox.Show("别名不允许重复。", "提示");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("别名不允许重复。", "提示");
                    return false;
                }

            }

            if (string.IsNullOrEmpty(txtIp.Text))
            {
                MessageBox.Show("服务器IP不允许为空。", "提示");
                return false;
            }

            if (string.IsNullOrEmpty(txtInstance.Text))
            {
                MessageBox.Show("服务器实例不允许为空。", "提示");
                return false;
            }

            if (string.IsNullOrEmpty(txtUserAccount.Text))
            {
                MessageBox.Show("授权账号不允许为空。", "提示");
                return false;
            }

            return true;
        }

        private void butModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (textAlias.Tag == null) return;

                if (Verify(true) == false) return;

                ServerInfo si = _sm.FindKey(textAlias.Tag.ToString());
                if (si == null)
                {
                    MessageBox.Show("未找到需要修改的数据。", "提示");
                }

                CopyCfgElement(ref si); 

                _isModify = true;

                ReindData();

                _sm.SaveToFile();

                LocateRow(si);
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
                string modulePath = System.Windows.Forms.Application.StartupPath + @"\" +  txtAssembly.Text;

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
                    dbProvide.Init(txtIp.Text, int.Parse( txtPort.Text), txtInstance.Text, txtUserAccount.Text, txtUserPwd.Text);

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

        private void butDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("请选择需要删除的数据。", "提示");
                    return;
                }

                int rowIndex = -1;

                foreach(DataGridViewRow selRow in dataGridView1.SelectedRows)
                {
                    ServerInfo si = _sm.FindAlias(selRow.Cells["ServerAlias"].Value.ToString());
                    
                    if (si != null)
                    {
                        _sm.Remove(si);
                        rowIndex = selRow.Index;

                        selRow.Selected = false;
                    }
                }

                _isModify = true;

                ReindData();

                _sm.SaveToFile();
                 
                if (rowIndex != -1)
                {
                    if (rowIndex < dataGridView1.Rows.Count)
                    {
                        dataGridView1.Rows[rowIndex].Selected = true;
                    }
                    else
                    {
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                    }

                }

                SyncSelRowData();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void ReindData()
        {
            _isBinding = true;
            try
            {
                dataGridView1.DataSource = null;

                if (_sm.Count <= 0) return;

                dataGridView1.DataSource = _sm;
            }
            finally
            {
                _isBinding = false;
            }
            
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isModify) _sm.SaveToFile();
        }

        private void ClearData()
        {
            textAlias.Text = "";
            textAlias.Tag = null;

            txtIp.Text = "";
            txtPort.Text = "";
            txtInstance.Text = "";
            txtUserAccount.Text = "";
            txtUserPwd.Text = "";

            txtAssembly.Text = "";

            cbxVerifyWay.Text = "";
            txtVerifyAssembly.Text = ""; 
        }

        private bool _isLoadServerInfo = false;
        private void LoadServerInfo(ServerInfo si)
        {
            _isLoadServerInfo = true;

            try
            {
                textAlias.Text = si.ServerAlias;
                textAlias.Tag = si.Key;

                txtIp.Text = si.ServerIP;
                txtPort.Text = si.ServerPort.ToString();
                txtInstance.Text = si.ServerInstance;

                txtUserAccount.Text = si.GrantAccount;
                txtUserPwd.Text = si.GrantPwd;

                txtAssembly.Text = si.ServerDriverFile;

                cbxVerifyWay.Text = si.AuthenticationWay;
                txtVerifyAssembly.Text = si.AuthenticationDirverFile;

                cbxServerType.Text = si.ServerType;
            }
            finally
            {
                _isLoadServerInfo = false;
            }
        }

        private void SyncSelRowData()
        {
            try
            {
                if (_isBinding) return;

                ClearData();

                if (dataGridView1.DataSource == null) return;
                if (dataGridView1.SelectedRows.Count <= 0) return;

                DataGridViewRow dvr = dataGridView1.SelectedRows[0];
                string alias = dvr.Cells["ServerAlias"].Value.ToString();

                ServerInfo si = _sm.FindAlias(alias);

                if (si == null) return;

                LoadServerInfo(si);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            SyncSelRowData();
        }

        private void butOpen_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath;
                DialogResult dr = openFileDialog1.ShowDialog(this);

                if (dr == DialogResult.Cancel) return;
                if (string.IsNullOrEmpty(openFileDialog1.FileName)) return;

                txtAssembly.Text = openFileDialog1.SafeFileName;
                
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                if (fi.Directory.FullName != openFileDialog1.InitialDirectory)
                {
                    MessageBox.Show("当前文件不在程序所在目录，请重新选择。", "提示");
                    e.Cancel = true;
                }
              
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
                if (_isLoadServerInfo) return;

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

        private void butVerfiyCfg_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtVerifyAssembly.Text))
                {
                    MessageBox.Show("未指定对应的认证驱动，不能进行配置。", "提示");
                    return;
                }
                string modulePath = System.Windows.Forms.Application.StartupPath + @"\" + txtVerifyAssembly.Text;

                IVerify verify = null;
                if (File.Exists(modulePath) == true)
                {
                    FileInfo fi = new FileInfo(modulePath);

                    string assemblyName = fi.Name.Replace(fi.Extension, "");
                    string[] tmp = ("..." + assemblyName).Split('.');
                    string objName = tmp[tmp.Length - 1];

                    verify = (IVerify)Assembly.LoadFile(modulePath).CreateInstance(assemblyName + "." + objName);
                }

                if (verify != null)
                {
                    verify.VerifyConfig(); 
                }
                else
                {
                    MessageBox.Show("认证实例创建失败。", "提示");
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxVerifyWay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cbxVerifyWay.Text))
                {
                    txtVerifyAssembly.Text = "";
                    return;
                }

                if (_ve.ContainsKey(cbxVerifyWay.Text))
                {
                    txtVerifyAssembly.Text = _ve[cbxVerifyWay.Text];
                }
                else
                {
                    txtVerifyAssembly.Text = "";
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}
