using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmDepartmentMatch : Form, ISetting
    {
        private IDBQuery _dbHelper = null;
        private DepartmentMatchModel _dmm = null;
        private ILoginUser _loginUser = null;

        public frmDepartmentMatch()
            :this(null, null)
        { 
        }


        public frmDepartmentMatch(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            Init(dbHelper, loginUser);
        }


        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {

            _dbHelper = dbHelper;
            _loginUser = loginUser;
            _dmm = new DepartmentMatchModel(_dbHelper);
        }


        private void BindDepartmentMatch()
        {
            DataTable dtResult = _dmm.GetAllDepartment();

            dataGridView1.DataSource = dtResult;

            if (dataGridView1.Columns.Count > 0)
            {
                //a.科室ID,a.科室名称,a.附加数据, b.科室对照ID,b.对照来源,b.对照编码
                dataGridView1.Columns["科室ID"].Visible = false;
                dataGridView1.Columns["附加数据"].Visible = false;
                dataGridView1.Columns["科室名称"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dataGridView1.Columns["附加数据"].Visible = false;
                //dataGridView1.Columns["对照编码"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }


        private bool Verify(bool isModify = false)
        {
            if (string.IsNullOrEmpty(txtDepartName.Text))
            {
                MessageBox.Show("科室名称不允许为空。", "提示");
                txtDepartName.Focus();
                return false;
            }

            string cfgId = _dmm.GetDepartmentIdByName(txtDepartName.Text);
            if (string.IsNullOrEmpty(cfgId) == false)
            {
                if (isModify)
                {
                    if (cfgId.Equals(txtDepartName.Tag) == false)
                    {
                        MessageBox.Show("科室名称不允许重复。", "提示");
                        txtDepartName.Focus();

                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("科室名称不允许重复。", "提示");
                    txtDepartName.Focus();

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
                //添加事务处理
                _dmm.TransactionBegin();
                DepartmentInfoData matchInfo = new DepartmentInfoData();

                matchInfo.科室ID = SqlHelper.GetCmpUID();
                matchInfo.科室名称 = txtDepartName.Text; 
                matchInfo.附加数据.备注 = rtbAttachInfo.Text;

                matchInfo.附加数据.CopyBasePro(matchInfo);

                _dmm.NewDepartmentInfo(matchInfo);

                DataTable dtBind = dataGridView1.DataSource as DataTable;

                DataRow drNew = dtBind.NewRow();

                drNew["科室ID"] = matchInfo.科室ID;
                drNew["科室名称"] = matchInfo.科室名称;
                drNew["附加数据"] = matchInfo.附加数据.ToString();

                dtBind.Rows.Add(drNew);

                UpdatDepartmentMatch(matchInfo);
                
                ButtonHint.Start(sender as Button, "OK");
                _dmm.TransactionCommit();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
            }
            catch (Exception ex)
            {
                _dmm.TransactionRollback();
                MsgBox.ShowException(ex,"添加科室对照信息失败，参照如下描述信息，进行检查", this);
            }
        }

        /// <summary>
        /// 更新科室对照
        /// </summary>
        /// <param name="matchInfo"></param>
        private void UpdatDepartmentMatch(DepartmentInfoData matchInfo)
        {
            if (lsbMatchs.Items.Count > 0)
            {
                foreach (string context in lsbMatchs.Items)
                {
                    string[] match = context.Split('-');

                    DepartmentMatchData matchData = new DepartmentMatchData();
                    matchData.科室对照ID = SqlHelper.GetCmpUID();
                    matchData.对照来源 = match[0];
                    matchData.对照编码 = match[1];
                    matchData.科室ID = matchInfo.科室ID;

                    _dmm.NewDepartmentMatch(matchData);
                }
            }
        }

        public void RefreshSetting()
        {
            BindDepartmentMatch();

            SyncSelRowData();
        }

        private void frmDepartmentMatch_Load(object sender, EventArgs e)
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

        private void ClearData()
        {
            txtDepartName.Text = "";
            txtDepartName.Tag = null;

            txtMatchSource.Text = "";
            txtMatchCode.Text = "";
            rtbAttachInfo.Text = "";


            lsbMatchs.Items.Clear();
        }


        private void SyncSelRowData()
        {
            try
            { 
                ClearData();

                if (dataGridView1.DataSource == null) return;
                if (dataGridView1.SelectedRows.Count <= 0) return;

                DataGridViewRow dvr = dataGridView1.SelectedRows[0];


                string departmentID = dvr.Cells["科室ID"].Value.ToString();

                DataRow[] drs = (dataGridView1.DataSource as DataTable).Select("科室ID='" + departmentID + "'");

                if (drs.Length > 0)
                {
                    DepartmentInfoData matchData = new DepartmentInfoData();
                    matchData.BindRowData(drs[0]);

                    txtDepartName.Text = matchData.科室名称;
                    txtDepartName.Tag = matchData.科室ID;
                     

                    if (matchData.附加数据 != null)
                    {
                        rtbAttachInfo.Text = matchData.附加数据.备注;
                    }

                    DataTable dtMatchs = _dmm.GetDepartmentMatch(departmentID);

                    foreach(DataRow dr in dtMatchs.Rows)
                    {
                        lsbMatchs.Items.Add(dr["对照来源"].ToString() + "-" + dr["对照编码"].ToString());
                    }
                }

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

        private void butDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDepartName.Tag == null)
                {
                    MessageBox.Show("请选择需要删除的科室对照。", "提示");
                    return;
                }
                //新增提示删除窗口
                if (MessageBox.Show("是否删除科室："+txtDepartName.Text+"的对照信息？","提示",MessageBoxButtons.YesNo)==DialogResult.No)
                { return; }
                //删除科室增加事务处理
                _dmm.TransactionBegin();
                _dmm.DelDepartmentMatch(txtDepartName.Tag.ToString());
                _dmm.DelDepartmentInfo(txtDepartName.Tag.ToString());
                _dmm.TransactionCommit();
                int rowIndex = 0;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    rowIndex = dataGridView1.SelectedRows[0].Index;
                }


                DataTable dtBind = (dataGridView1.DataSource as DataTable);

                if (dtBind.Rows.Count > 0)
                {
                    DataRow[] drs = dtBind.Select("科室ID='" + txtDepartName.Tag.ToString() + "'");

                    foreach (DataRow dr in drs)
                    {
                        dtBind.Rows.Remove(dr);
                    }
                }

                ButtonHint.Start(sender as Button, "OK");
            }
            catch (Exception ex)
            {
                _dmm.TransactionRollback();
                MsgBox.ShowException(ex, "科室信息删除失败，请检查该科室是否已经使用，已使用的科室不能删除或参照如下描述信息，进行检查", this);
            }
        }


        public DepartmentInfoData GetSelectDepartmentMatch()
        {

            if (dataGridView1.SelectedRows.Count <= 0) return null;

            DataGridViewRow dvr = dataGridView1.SelectedRows[0];

            string serverID = dvr.Cells["科室ID"].Value.ToString();

            DataRow[] drs = (dataGridView1.DataSource as DataTable).Select("科室ID='" + serverID + "'");

            if (drs.Length > 0)
            {
                DepartmentInfoData matchData = new DepartmentInfoData();
                matchData.BindRowData(drs[0]);

                return matchData;
            }

            return null;
        }


        private void butModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDepartName.Tag == null)
                {
                    MessageBox.Show("请选择需要修改的科室对照。", "提示");
                    return;
                }


                DepartmentInfoData matchData = GetSelectDepartmentMatch();
                if (matchData == null)
                {
                    MessageBox.Show("未获取到有效的科室对照数据。", "提示");
                    return;
                }

                if (Verify(true) == false) return;

                //添加事务处理
                _dmm.TransactionBegin();
                matchData.科室名称 = txtDepartName.Text; 
                matchData.附加数据.备注 = rtbAttachInfo.Text;

                matchData.附加数据.CopyBasePro(matchData);

                _dmm.UpdateDepartmentInfo(matchData);

                DataRow dr = matchData.GetBindRow();

                dr["科室名称"] = txtDepartName.Text; 
                dr["附加数据"] = matchData.附加数据.ToString();

                _dmm.DelDepartmentMatch(matchData.科室ID);

                UpdatDepartmentMatch(matchData);

                ButtonHint.Start(sender as Button, "OK");
                _dmm.TransactionCommit();
            }
            catch (Exception ex)
            {
                _dmm.TransactionRollback();
                MsgBox.ShowException(ex, "添加科室对照信息失败，参照如下描述信息，进行检查",this);
            }
        }

        private void butNewMatch_Click(object sender, EventArgs e)
        {
            try
            {

                //if (string.IsNullOrEmpty(txtMatchSource.Text))
                //{
                //    MessageBox.Show("对照来源不允许为空。", "提示");
                //    txtMatchSource.Focus();
                //    return;
                //}


                if (string.IsNullOrEmpty( txtMatchCode.Text) )
                {
                    MessageBox.Show("对照编码不允许为空。", "提示");
                    txtMatchCode.Focus();
                    return;
                }

                string context = txtMatchSource.Text + "-" + txtMatchCode.Text;

                if (lsbMatchs.Items.IndexOf(context) >=0)
                {
                    MessageBox.Show("存在相同设置项，不能进行添加。", "提示");
                    return;
                }

                lsbMatchs.Items.Add(context);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butDelMatch_Click(object sender, EventArgs e)
        {
            try
            {
                lsbMatchs.Items.Remove(lsbMatchs.SelectedItem);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}
