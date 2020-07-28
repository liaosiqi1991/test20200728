using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using zlMedimgSystem.BusinessBase;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmThridDBConfig : Form, ISetting
    {
        private IDBQuery _dbHelper = null;
        private ThridDBSourceModel _dbSourceModel = null;
        private ILoginUser _loginUser = null;

        private ServerEnum _se = null;
        public frmThridDBConfig()
            : this(null, null)
        {
        }


        public frmThridDBConfig(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            Init(dbHelper, loginUser);
        }


        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {

            _dbHelper = dbHelper;
            _loginUser = loginUser;
            _dbSourceModel = new ThridDBSourceModel(_dbHelper);
        }

        public void RefreshSetting()
        {
            BindThridDbSource();

            SyncSelRowData();
        }

        private void BindThridDbSource()
        {
            DataTable dtResult = _dbSourceModel.GetAllThridDBSource();

            dataGridView1.DataSource = dtResult;

            if (dataGridView1.Columns.Count > 0)
            {
                //a.科室ID,a.科室名称,a.附加数据, b.科室对照ID,b.对照来源,b.对照编码
                dataGridView1.Columns["数据源ID"].Visible = false;
                dataGridView1.Columns["数据源信息"].Visible = false;
                dataGridView1.Columns["数据源别名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 
            }
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
        }


        private void SyncSelRowData()
        {
            try
            {
                ClearData();

                if (dataGridView1.DataSource == null) return;
                if (dataGridView1.SelectedRows.Count <= 0) return;

                DataGridViewRow dvr = dataGridView1.SelectedRows[0];


                string departmentID = dvr.Cells["数据源ID"].Value.ToString();

                DataRow[] drs = (dataGridView1.DataSource as DataTable).Select("数据源ID='" + departmentID + "'");

                if (drs.Length > 0)
                {
                    ThridDBSourceData thridDBSourceData = new ThridDBSourceData();
                    thridDBSourceData.BindRowData(drs[0]);

                    LoadServerInfo(thridDBSourceData);
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private bool _isLoadServerInfo = false;
        private void LoadServerInfo(ThridDBSourceData thridDbSource)
        {
            _isLoadServerInfo = true;

            try
            {
                textAlias.Text = thridDbSource.数据源别名;
                textAlias.Tag = thridDbSource.数据源ID;

                if (thridDbSource.数据源信息 != null)
                {
                    txtIp.Text = thridDbSource.数据源信息.服务器IP;
                    txtPort.Text = thridDbSource.数据源信息.端口.ToString();
                    txtInstance.Text = thridDbSource.数据源信息.数据实例;

                    txtUserAccount.Text = thridDbSource.数据源信息.授权账号;
                    txtUserPwd.Text = ThridDBSourceModel.DecryPwd(thridDbSource.数据源信息.授权密码);

                    cbxServerType.Text = thridDbSource.数据源信息.服务器类型;
                    txtAssembly.Text = thridDbSource.数据源信息.驱动文件;

                    rtbDescription.Text = thridDbSource.数据源信息.备注描述;
                }
            }
            finally
            {
                _isLoadServerInfo = false;
            }
             
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                SyncSelRowData();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private bool Verify(bool isModify = false)
        {
            if (string.IsNullOrEmpty(textAlias.Text))
            {
                MessageBox.Show("别名不允许为空。", "提示");
                textAlias.Focus();
                return false;
            }

            //IP地址不能为空，需要验证IP地址格式
            if (string.IsNullOrEmpty(txtIp.Text) == false)
            {
                string strPattern = @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$";
                if (Regex.IsMatch(txtIp.Text.Trim(), strPattern) == false)
                {
                    MessageBox.Show("IP地址格式不正确。", "提示");
                    txtIp.Focus();
                    txtIp.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("服务器IP不允许为空。", "提示");
                txtIp.Focus();
                return false;
            }
            //端口不为空，只能是数字
            if (string.IsNullOrEmpty(txtPort.Text) == false)
            {
                string strPattern = @"^[0-9]+$";
                Regex reg = new Regex(strPattern);
                if (reg.Match(txtPort.Text.Trim()).Success == false)
                {
                    MessageBox.Show("服务端口只能是数字，格式不正确。", "提示");
                    txtPort.Focus();
                    txtPort.SelectAll();
                    return false;
                }
            }else
            {
                MessageBox.Show("服务端口不允许为空。", "提示");
                txtPort.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtInstance.Text))
            {
                MessageBox.Show("服务器实例不允许为空。", "提示");
                txtInstance.Focus();
                return false;
            }

            //类别名称判断
            string Id = _dbSourceModel.GetThridDbSourceIdByName(textAlias.Text);
            if (string.IsNullOrEmpty(Id) == false)
            {
                if (isModify)
                {
                    if (Id.Equals(textAlias.Tag) == false)
                    {
                        MessageBox.Show("别名不允许重复。", "提示");
                        textAlias.Focus();

                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("别名不允许重复。", "提示");
                    textAlias.Focus();

                    return false;
                }
            }
             
            return true;
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (Verify() == false) return;

                ThridDBSourceData thridDBSource = new ThridDBSourceData();

                thridDBSource.数据源ID = SqlHelper.GetNumGuid();

                WriteDBSourceInfo(ref thridDBSource);

                //thridDBSource.数据源别名 = textAlias.Text;
                //thridDBSource.数据源信息.服务器类型 = cbxServerType.Text;
                //thridDBSource.数据源信息.驱动文件 = txtAssembly.Text;
                //thridDBSource.数据源信息.服务器IP = txtPort.Text;
                //thridDBSource.数据源信息.端口 = Convert.ToInt32(txtPort.Text);
                //thridDBSource.数据源信息.数据实例 = txtInstance.Text;
                //thridDBSource.数据源信息.授权账号 = txtUserAccount.Text; 
                //thridDBSource.数据源信息.授权密码 = _dbSourceModel.EncryPwd(txtUserPwd.Text);
                //thridDBSource.数据源信息.备注描述 = rtbDescription.Text;

                //thridDBSource.数据源信息.CopyBasePro(thridDBSource);

                _dbSourceModel.NewThridDBSource(thridDBSource);

                DataTable dtBind = dataGridView1.DataSource as DataTable;

                DataRow drNew = dtBind.NewRow();

                drNew["数据源ID"] = thridDBSource.数据源ID;
                drNew["数据源别名"] = thridDBSource.数据源别名; 
                drNew["数据源信息"] = thridDBSource.数据源信息.ToString();

                dtBind.Rows.Add(drNew);

                ButtonHint.Start(sender as Button, "OK");
                //添加数据后，焦点定位到最后一行（选中新增的行）
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;

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
                if (textAlias.Tag == null)
                {
                    MessageBox.Show("请选择需要删除的数据源。", "提示");
                    return;
                }

                //删除前弹出提示对话框确认是否删除

                if (MessageBox.Show("是否删除数据库别名：" + textAlias.Text, "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }


                _dbSourceModel.DelThridDBSource(textAlias.Tag.ToString());

                int rowIndex = 0;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    rowIndex = dataGridView1.SelectedRows[0].Index;
                }


                DataTable dtBind = (dataGridView1.DataSource as DataTable);

                if (dtBind.Rows.Count > 0)
                {
                    DataRow[] drs = dtBind.Select("数据源ID='" + textAlias.Tag.ToString() + "'");

                    foreach (DataRow dr in drs)
                    {
                        dtBind.Rows.Remove(dr);
                    }
                }

                ButtonHint.Start(sender as Button, "OK");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        public ThridDBSourceData GetSelectThridDBSource()
        {

            if (dataGridView1.SelectedRows.Count <= 0) return null;

            DataGridViewRow dvr = dataGridView1.SelectedRows[0];

            string serverID = dvr.Cells["数据源ID"].Value.ToString();

            DataRow[] drs = (dataGridView1.DataSource as DataTable).Select("数据源ID='" + serverID + "'");

            if (drs.Length > 0)
            {
                ThridDBSourceData thridDBSource = new ThridDBSourceData();
                thridDBSource.BindRowData(drs[0]);

                return thridDBSource;
            }

            return null;
        }

        private void butModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (textAlias.Tag == null)
                {
                    MessageBox.Show("请选择需要修改的数据源。", "提示");
                    return;
                }


                ThridDBSourceData thridDBSource = GetSelectThridDBSource();
                if (thridDBSource == null)
                {
                    MessageBox.Show("未获取到有效的数据源信息。", "提示");
                    return;
                }

                if (Verify(true) == false) return;

                WriteDBSourceInfo(ref thridDBSource);

                //thridDBSource.数据源别名 = textAlias.Text;

                //thridDBSource.数据源信息.服务器类型 = cbxServerType.Text;
                //thridDBSource.数据源信息.驱动文件 = txtAssembly.Text;
                //thridDBSource.数据源信息.服务器IP = txtPort.Text;
                //thridDBSource.数据源信息.端口 = Convert.ToInt32(txtPort.Text);
                //thridDBSource.数据源信息.数据实例 = txtInstance.Text;
                //thridDBSource.数据源信息.授权账号 = txtUserAccount.Text;
                //thridDBSource.数据源信息.授权密码 = _dbSourceModel.EncryPwd(txtUserPwd.Text);
                //thridDBSource.数据源信息.备注描述 = rtbDescription.Text;

                //thridDBSource.数据源信息.CopyBasePro(thridDBSource);

                _dbSourceModel.UpdateThridDBSource(thridDBSource);

                DataRow dr = thridDBSource.GetBindRow();

                dr["数据源别名"] = textAlias.Text; 
                dr["数据源信息"] = thridDBSource.数据源信息.ToString();

                ButtonHint.Start(sender as Button, "OK");

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmThridDBConfig_Load(object sender, EventArgs e)
        {
            try
            {
                _se = new ServerEnum();
                foreach (string key in _se.Keys)
                {
                    cbxServerType.Items.Add(key);
                    txtAssembly.Text = _se[key];
                }
                if (cbxServerType.Items.Count > 0) cbxServerType.SelectedIndex = 0;


                RefreshSetting();

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

        private void WriteDBSourceInfo(ref ThridDBSourceData dbSource)
        {
            dbSource.数据源别名 = textAlias.Text;
            dbSource.数据源信息.服务器类型 = cbxServerType.Text;
            dbSource.数据源信息.服务器IP = txtIp.Text;
            dbSource.数据源信息.端口 = int.Parse(txtPort.Text);
            dbSource.数据源信息.数据实例 = txtInstance.Text;
            dbSource.数据源信息.授权账号 = txtUserAccount.Text;
            dbSource.数据源信息.授权密码 = ThridDBSourceModel.EncryPwd(txtUserPwd.Text);
            dbSource.数据源信息.驱动文件 = txtAssembly.Text;
            dbSource.数据源信息.备注描述 = rtbDescription.Text;

            dbSource.数据源信息.CopyBasePro(dbSource);
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

                IDBProvider dbProvide = ServerEnum.GetDBProvider(txtAssembly.Text);

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
    }
}
