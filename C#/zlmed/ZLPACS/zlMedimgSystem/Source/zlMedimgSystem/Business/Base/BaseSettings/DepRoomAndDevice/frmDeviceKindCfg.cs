using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Services;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmDeviceKindCfg : Form, ISetting
    {
        private IDBQuery _dbHelper = null;
        private DeviceKindModel _dkm = null;
        private ILoginUser _loginUser = null;

        public frmDeviceKindCfg()
            : this(null, null)
        {
        }


        public frmDeviceKindCfg(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            Init(dbHelper, loginUser);
        }


        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {

            _dbHelper = dbHelper;
            _loginUser = loginUser;
            _dkm = new DeviceKindModel(_dbHelper);
        }

        public void RefreshSetting()
        {
            BindDeviceKind();

            SyncSelRowData();
        }

        private void BindDeviceKind()
        {
            DataTable dtResult = _dkm.GetAllDeviceKind();

            dataGridView1.DataSource = dtResult;

            if (dataGridView1.Columns.Count > 0)
            {
                //a.科室ID,a.科室名称,a.附加数据, b.科室对照ID,b.对照来源,b.对照编码
                dataGridView1.Columns["类别ID"].Visible = false;
                dataGridView1.Columns["类别信息"].Visible = false;
                dataGridView1.Columns["影像类别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dataGridView1.Columns["附加数据"].Visible = false;
                //dataGridView1.Columns["对照编码"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }


        private void ClearData()
        {
            txtKindName.Text = "";
            txtKindName.Tag = null;

            txtImageKind.Text = ""; 
            rtbDescription.Text = "";
             
        }


        private void SyncSelRowData()
        {
            try
            {
                ClearData();

                if (dataGridView1.DataSource == null) return;
                if (dataGridView1.SelectedRows.Count <= 0) return;

                DataGridViewRow dvr = dataGridView1.SelectedRows[0];


                string departmentID = dvr.Cells["类别ID"].Value.ToString();

                DataRow[] drs = (dataGridView1.DataSource as DataTable).Select("类别ID='" + departmentID + "'");

                if (drs.Length > 0)
                {
                    DeviceKindData kindData = new DeviceKindData();
                    kindData.BindRowData(drs[0]);

                    txtKindName.Text = kindData.类别名称;
                    txtKindName.Tag = kindData.类别ID;

                    txtImageKind.Text = kindData.影像类别;
                    //影像类别Tag赋值为类别ID，否则保存时会一直提示影像类别已存在。
                    txtImageKind.Tag = kindData.类别ID;


                    if (kindData.类别信息 != null)
                    {
                        rtbDescription.Text = kindData.类别信息.类别描述;
                    }                     
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmDeviceKindCfg_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshSetting();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private bool Verify(bool isModify = false)
        {
            if (string.IsNullOrEmpty(txtKindName.Text))
            {
                MessageBox.Show("类别名称不允许为空。", "提示");
                txtKindName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtImageKind.Text))
            {
                MessageBox.Show("影像类别不允许为空。", "提示");
                txtKindName.Focus();
                return false;
            }

            //类别名称判断
            string Id = _dkm.GetDeviceKindIdByName(txtKindName.Text);
            if (string.IsNullOrEmpty(Id) == false)
            {
                if (isModify)
                {
                    if (Id.Equals(txtKindName.Tag) == false)
                    {
                        MessageBox.Show("类别名称不允许重复。", "提示");
                        txtKindName.Focus();

                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("类别名称不允许重复。", "提示");
                    txtKindName.Focus();

                    return false;
                }
            }

            //影像类别判断
            Id = _dkm.GetDeviceKindIdByImgKind(txtImageKind.Text);
            if (string.IsNullOrEmpty(Id) == false)
            {
                if (isModify)
                {
                    if (Id.Equals(txtImageKind.Tag) == false)
                    {
                        MessageBox.Show("影像类别不允许重复。", "提示");
                        txtImageKind.Focus();

                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("影像类别不允许重复。", "提示");
                    txtImageKind.Focus();

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

                DeviceKindData kindInfo = new DeviceKindData();

                kindInfo.类别ID = SqlHelper.GetNumGuid();
                kindInfo.类别名称 = txtKindName.Text;
                kindInfo.影像类别 = txtImageKind.Text;
                kindInfo.类别信息.类别描述 = rtbDescription.Text;
                kindInfo.类别信息.创建日期 = _dkm.GetServerDate();

                kindInfo.类别信息.CopyBasePro(kindInfo);

                _dkm.NewDeviceKindInfo(kindInfo);

                DataTable dtBind = dataGridView1.DataSource as DataTable;

                DataRow drNew = dtBind.NewRow();

                drNew["类别ID"] = kindInfo.类别ID;
                drNew["类别名称"] = kindInfo.类别名称;
                drNew["影像类别"] = kindInfo.影像类别;
                drNew["类别信息"] = kindInfo.类别信息.ToString();

                dtBind.Rows.Add(drNew);

                ButtonHint.Start(sender as Button, "OK");
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
                if (txtKindName.Tag == null)
                {
                    MessageBox.Show("请选择需要删除的设备类别。", "提示");
                    return;
                }

                if (MessageBox.Show("是否删除影像类别："+txtImageKind.Text+"?","提示",MessageBoxButtons.YesNo)==DialogResult.No)
                {
                    return;
                }
                _dkm.DelDeviceKindInfo(txtKindName.Tag.ToString());

                int rowIndex = 0;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    rowIndex = dataGridView1.SelectedRows[0].Index;
                }


                DataTable dtBind = (dataGridView1.DataSource as DataTable);

                if (dtBind.Rows.Count > 0)
                {
                    DataRow[] drs = dtBind.Select("类别ID='" + txtKindName.Tag.ToString() + "'");

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


        public DeviceKindData GetSelectDeviceKind()
        {

            if (dataGridView1.SelectedRows.Count <= 0) return null;

            DataGridViewRow dvr = dataGridView1.SelectedRows[0];

            string serverID = dvr.Cells["类别ID"].Value.ToString();

            DataRow[] drs = (dataGridView1.DataSource as DataTable).Select("类别ID='" + serverID + "'");

            if (drs.Length > 0)
            {
                DeviceKindData kindInfo = new DeviceKindData();
                kindInfo.BindRowData(drs[0]);

                return kindInfo;
            }

            return null;
        }

        private void butModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKindName.Tag == null)
                {
                    MessageBox.Show("请选择需要修改的设备类别。", "提示");
                    return;
                }


                DeviceKindData kindInfo = GetSelectDeviceKind();
                if (kindInfo == null)
                {
                    MessageBox.Show("未获取到有效的设备类别信息。", "提示");
                    return;
                }

                if (Verify(true) == false) return;


                kindInfo.类别名称 = txtKindName.Text;
                kindInfo.影像类别 = txtImageKind.Text;
                kindInfo.类别信息.类别描述 = rtbDescription.Text;

                kindInfo.类别信息.CopyBasePro(kindInfo);

                _dkm.UpdateDeviceKindInfo(kindInfo);

                DataRow dr = kindInfo.GetBindRow();

                dr["类别名称"] = txtKindName.Text;
                dr["影像类别"] = txtImageKind.Text;
                dr["类别信息"] = kindInfo.类别信息.ToString();

                ButtonHint.Start(sender as Button, "OK");

            }
            catch (Exception ex)
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
    }
}
