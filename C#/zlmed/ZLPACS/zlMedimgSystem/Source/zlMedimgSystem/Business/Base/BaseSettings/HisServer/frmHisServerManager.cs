using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.ExtInterface;
using zlMedimgSystem.Interface;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Services;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmHisServerManager : Form, ISetting
    {
        private IDBQuery _dbHelper = null;
        private ApplyEnum _ae = null;
        private HisServerModel _hsm = null;
        private ILoginUser _loginUser = null;

        private bool _isBinding = false;

        public frmHisServerManager()
            :this(null, null)
        { 
        }

        public frmHisServerManager(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            Init(dbHelper, loginUser);
        }

        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {
            _dbHelper = dbHelper;
            _loginUser = loginUser;

            _hsm = new HisServerModel(_dbHelper);
        }

        public void RefreshSetting()
        {
            _isBinding = true;

            try
            {
                _ae = new ApplyEnum();
                //点击刷新按钮重新刷新时，先清除下拉框内容，再加载
                cbxInterfaceName.Items.Clear();

                foreach (string key in _ae.Keys)
                {
                    cbxInterfaceName.Items.Add(key);
                    txtAssemblyFile.Text = _ae[key];
                }


                if (cbxInterfaceName.Items.Count > 0)
                {
                    cbxInterfaceName.SelectedIndex = 0;
                    txtAssemblyFile.Text = _ae[cbxInterfaceName.Text];
                }


                BindHisServer();
            }
            finally
            {
                _isBinding = false;
            }

            SyncSelRowData();
        }

        private void HisServerManager_Load(object sender, EventArgs e)
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

        private void BindHisServer()
        {
            DataTable dtResult = _hsm.GetAllHisServer();

            dataGridView1.DataSource = dtResult;

            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["HIS服务ID"].Visible = false;
                dataGridView1.Columns["服务配置"].Visible = false;                
                dataGridView1.Columns["服务名称"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }


        private bool Verify(bool isModify = false)
        {
            if (string.IsNullOrEmpty(textAlias.Text))
            {
                MessageBox.Show("名称不允许为空。", "提示");
                textAlias.Focus();
                return false;
            }

            string cfgId = _hsm.GetHisServerCfgID(textAlias.Text);
            if (string.IsNullOrEmpty(cfgId) == false)
            {
                if (isModify)
                {
                    if (cfgId.Equals(textAlias.Tag) == false)
                    {
                        MessageBox.Show("名称不允许重复。", "提示");
                        textAlias.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("名称不允许重复。", "提示");
                    textAlias.Focus();
                    return false;
                }
            }


            if (string.IsNullOrEmpty(cbxInterfaceName.Text))
            {
                MessageBox.Show("HIS接口名称不允许为空。", "提示");
                cbxInterfaceName.Focus();
                return false;
            }

            if (cbxInterfaceName.Tag == null)
            {
                if (MessageBox.Show("接口尚未进行配置，是否继续？。", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    cbxInterfaceName.Focus();

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

                HisServerCfgData cfgData = new HisServerCfgData();

                cfgData.HIS服务ID = SqlHelper.GetCmpUID();
                cfgData.服务名称 = textAlias.Text;
                cfgData.服务配置.HIS接口名称 = cbxInterfaceName.Text;
                cfgData.服务配置.HIS接口文件 = txtAssemblyFile.Text;
                cfgData.服务配置.是否停用 = chkStopUse.Checked;
                //如果接口信息未进行配置，cbxInterfaceName.Tag的返回值未null，.toString()时会提示错误，需要单独处理
                if (cbxInterfaceName.Tag ==null)
                {
                    cfgData.服务配置.接口配置 = "";
                }
                else
                {
                    cfgData.服务配置.接口配置 = cbxInterfaceName.Tag.ToString();
                }

                cfgData.服务配置.CopyBasePro(cfgData);

                _hsm.NewHisServerCfg(cfgData);

                DataTable dtBind = dataGridView1.DataSource as DataTable;

                DataRow drNew = dtBind.NewRow();

                drNew["HIS服务ID"] = cfgData.HIS服务ID;
                drNew["服务名称"] = cfgData.服务名称;
                drNew["服务配置"] = cfgData.服务配置.ToString();

                dtBind.Rows.Add(drNew);

                ButtonHint.Start(sender as Button, "OK");
                //添加数据后，焦点定位到最后一行（选中新增的行）
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butVerfiyCfg_Click(object sender, EventArgs e)
        {
            try
            {
                //必须要选选择接口名称，才能对接口进行配置
                if (string.IsNullOrEmpty(cbxInterfaceName.Text))
                {
                    MessageBox.Show("请先选择HIS接口名称，再进行接口配置。", "提示");
                    cbxInterfaceName.Focus();
                    return;
                }
                IApply applyInstance = _ae.CreateInstance(cbxInterfaceName.Text) as IApply;

                if (applyInstance == null)
                {
                    MessageBox.Show("实例化失败，不能进行配置。", "提示");
                    return;
                }
                if (cbxInterfaceName.Tag != null)
                {
                    applyInstance.ConfigString = cbxInterfaceName.Tag.ToString();
                }

                if (applyInstance.ShowCfg(this))
                { 
                    cbxInterfaceName.Tag = applyInstance.ConfigString;

                    if (textAlias.Tag != null)
                    {
                        HisServerCfgData cfgData = GetSelectServerCfgData();

                        cfgData.服务配置.接口配置 = cbxInterfaceName.Tag.ToString();

                        _hsm.UpdateHisServerCfg(cfgData);

                        DataRow dr = cfgData.GetBindRow();

                        dr["服务配置"] = cfgData.服务配置.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
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



        private void SyncSelRowData()
        {
            try
            {
                if (_isBinding) return;

                ClearData();

                if (dataGridView1.DataSource == null) return;
                if (dataGridView1.SelectedRows.Count <= 0) return;

                DataGridViewRow dvr = dataGridView1.SelectedRows[0];

                
                string serverID = dvr.Cells["HIS服务ID"].Value.ToString();

                DataRow[] drs = (dataGridView1.DataSource as DataTable).Select("HIS服务ID='" + serverID + "'");

                if (drs.Length > 0)
                {
                    HisServerCfgData cfgData = new HisServerCfgData();
                    cfgData.BindRowData(drs[0]);

                    textAlias.Text = cfgData.服务名称;
                    textAlias.Tag = cfgData.HIS服务ID;

                    if (cfgData.服务配置 != null)
                    {
                        cbxInterfaceName.Text = cfgData.服务配置.HIS接口名称;
                        cbxInterfaceName.Tag = cfgData.服务配置.接口配置;
                        txtAssemblyFile.Text = cfgData.服务配置.HIS接口文件;
                        chkStopUse.Checked = cfgData.服务配置.是否停用;
                    }
                }
                 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        private void ClearData()
        {
            textAlias.Text = "";
            textAlias.Tag = null;

            cbxInterfaceName.SelectedIndex = -1;
            cbxInterfaceName.Tag = null;

            txtAssemblyFile.Text = "";

            chkStopUse.Checked = false;
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (textAlias.Tag == null)
                {
                    MessageBox.Show("请选择需要删除的配置项目。", "提示");
                    return;
                }
                 //删除配置项目前弹出提示对话框
                if (MessageBox.Show("是否删除配置项目：" + textAlias.Text,"提示",MessageBoxButtons.YesNo)==DialogResult.No)
                {
                    return;
                }

                _hsm.DelHisServerCfg(textAlias.Tag.ToString());

                int rowIndex = 0;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    rowIndex = dataGridView1.SelectedRows[0].Index;
                }


                DataTable dtBind = (dataGridView1.DataSource as DataTable);

                if (dtBind.Rows.Count > 0)
                {
                    DataRow[] drs = dtBind.Select("HIS服务ID='" + textAlias.Tag.ToString() + "'");

                    foreach(DataRow dr in drs)
                    {
                        dtBind.Rows.Remove(dr);
                    }
                }

                //if (dataGridView1.Rows.Count >= rowIndex )
                //{
                //    dataGridView1.Rows[rowIndex].Selected = true;
                //}
                //else
                //{
                //    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                //}

                ButtonHint.Start(sender as Button, "OK");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxInterfaceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_ae.ContainsKey(cbxInterfaceName.Text))
                {
                    txtAssemblyFile.Text = _ae[cbxInterfaceName.Text];
                }
                else
                {
                    txtAssemblyFile.Text = "";
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (textAlias.Tag == null)
                {
                    MessageBox.Show("请选择需要修改的配置项目。", "提示");
                    return;
                }


                HisServerCfgData cfgData = GetSelectServerCfgData();
                if (cfgData == null)
                {
                    MessageBox.Show("未获取到有效的配置数据。", "提示");
                    return;
                }

                if (Verify(true) == false) return;

                
                cfgData.服务名称 = textAlias.Text;
                cfgData.服务配置.HIS接口名称 = cbxInterfaceName.Text;
                cfgData.服务配置.HIS接口文件 = txtAssemblyFile.Text;
                cfgData.服务配置.是否停用 = chkStopUse.Checked;

                if (cbxInterfaceName.Tag != null)
                {
                    cfgData.服务配置.接口配置 = cbxInterfaceName.Tag.ToString();
                }

                cfgData.服务配置.CopyBasePro(cfgData);

                _hsm.UpdateHisServerCfg(cfgData);

                DataRow dr = cfgData.GetBindRow();

                dr["服务名称"] = textAlias.Text;
                dr["服务配置"] = cfgData.服务配置.ToString();

                ButtonHint.Start(sender as Button, "OK");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        public HisServerCfgData GetSelectServerCfgData()
        {

            if (dataGridView1.SelectedRows.Count <= 0) return null;

            DataGridViewRow dvr = dataGridView1.SelectedRows[0];
             
            string serverID = dvr.Cells["HIS服务ID"].Value.ToString();

            DataRow[] drs = (dataGridView1.DataSource as DataTable).Select("HIS服务ID='" + serverID + "'");

            if (drs.Length > 0)
            {
                HisServerCfgData cfgData = new HisServerCfgData();
                cfgData.BindRowData(drs[0]);

                return cfgData;
            }

            return null;
        }
    }
}
