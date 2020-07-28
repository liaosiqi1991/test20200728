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
    public partial class frmQueueManager : Form, ISetting
    {

        private IDBQuery _dbHelper = null;
        private ILoginUser _loginUser = null;

        private QueueModel _qm = null;
        private DepartmentMatchModel _departmentMatchModel = null;
        public frmQueueManager()
        : this(null, null)
        {
        }

        public frmQueueManager(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            Init(dbHelper, loginUser);
        }

        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {
            _dbHelper = dbHelper;
            _qm = new QueueModel(_dbHelper);
            _loginUser = loginUser;
            _departmentMatchModel = new DepartmentMatchModel(dbHelper);
        }


        public void RefreshSetting()
        {

            DataTable dtDepartment = _departmentMatchModel.GetAllDepartment();

            cbxDepartment.DataSource = null;

            cbxDepartment.DisplayMember = "科室名称";
            cbxDepartment.ValueMember = "科室ID";

            cbxDepartment.DataSource = dtDepartment;

            if (cbxDepartment.Items.Count > 0) cbxDepartment.SelectedIndex = 0;
        }

        private void frmQueueManager_Load(object sender, EventArgs e)
        {
            try
            {
                InitQueueList();
                InitRoomList();

                RefreshSetting();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void ClearData()
        { 
            listView2.Items.Clear();

            txtQueueName.Text = "";
            txtQueueName.Tag = null;

            txtPrefix.Text = "";
            txtNoLen.Text = "3";

            txtCallStation.Text = "";
                     
            txtDes.Text = "";

            chkStopUse.Checked = false;
        }

        private void cbxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bool allowOper = !string.IsNullOrEmpty(cbxDepartment.Text);

                butNew.Enabled = allowOper;
                butDel.Enabled = allowOper;
                butModify.Enabled = allowOper;
                butReleationRoom.Enabled = allowOper;

                if (allowOper == false) return;
                //切换科室时，删除编辑区。否则切换科室后仍可以操作之前科室的角色
                ClearData();
                BindQueueData();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void InitQueueList()
        {
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "队列名称";
            columnHeader.Name = "队列名称";
            columnHeader.Width = 120;
            listView1.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "队列描述";
            columnHeader.Name = "队列描述";
            columnHeader.Width = 200;
            listView1.Columns.Add(columnHeader);

        }

        private void InitRoomList()
        {
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "房间名称";
            columnHeader.Name = "房间名称";
            columnHeader.Width = 200;
            listView2.Columns.Add(columnHeader);

        }

        //private DataTable _rooms = null;
        private void BindRoomData(QueueData queueInfo)
        {
            listView2.Items.Clear();

            //if (_rooms == null)
            //{
            //    _rooms = _qm.GetDeptRooms(cbxDepartment.SelectedValue.ToString());
            //}

            //if (queueInfo.包含房间.房间明细.Count <= 0) return;

            foreach (JQueueRoomItem queueRoomItem in queueInfo.包含房间.房间明细)
            {
                ListViewItem lvi = listView2.Items.Add(queueRoomItem.房间名称, 1);                
            }

            listView2.View = View.LargeIcon;
        }

        private void BindQueueData()
        {
            //点击刷新，重复加载list列表情况,先清空数据，列名
            listView1.Items.Clear(); 
            DataTable dtQueueInfos = _qm.GetQueueInfoByDeptId(cbxDepartment.SelectedValue.ToString());
 
            foreach (DataRow drItem in dtQueueInfos.Rows)
            {
                QueueData queueData = new QueueData();
                queueData.BindRowData(drItem);

                ListViewItem itemNew = new ListViewItem(new string[] { queueData.队列名称, queueData.队列信息.备注 }, 0);
                //添加Name属性赋值，否则listView1.Items.Find无法查找
                itemNew.Name = queueData.队列ID;
                itemNew.Tag = queueData;

               
                listView1.Items.Add(itemNew);
            }

            listView1.View = View.Details;
        }


        private bool Verify(bool isModify = false)
        {
            if (string.IsNullOrEmpty(txtQueueName.Text))
            {
                MessageBox.Show("队列名称不允许为空。", "提示");
                txtQueueName.Focus();
                return false;
            }

            if (Convert.ToInt32(txtNoLen.Text) <= 0)
            {
                MessageBox.Show("号码长度必须大于0。", "提示");
                txtNoLen.Focus();
                return false;
            }

            //修改GetRoleID，添加科室ID作为条件，不同科室允许角色名称相同
            string queueId = _qm.GetQueueIdByName(txtQueueName.Text, cbxDepartment.SelectedValue.ToString());
            if (string.IsNullOrEmpty(queueId) == false)
            {
                if (isModify)
                {
                    if (queueId.Equals(txtQueueName.Tag) == false)
                    {
                        MessageBox.Show("队列名不允许重复。", "提示");
                        txtQueueName.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("队列名不允许重复。", "提示");
                    txtQueueName.Focus();
                    return false;
                }
            }

            return true;
        }


        private void NewView(QueueData queueData)
        {

            ListViewItem itemNew = new ListViewItem(new string[] { queueData.队列名称, queueData.队列信息.备注 }, 0);
            //添加Name属性赋值，否则listView1.Items.Find无法查找
            itemNew.Name = queueData.队列ID;
            itemNew.Tag = queueData;
            
            listView1.Items.Add(itemNew);

            itemNew.Selected = true;

        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (Verify() == false) return;

                QueueData queueData = new QueueData();

                queueData.科室ID = cbxDepartment.SelectedValue.ToString();
                queueData.队列ID = SqlHelper.GetCmpUID();
                queueData.队列名称 = txtQueueName.Text;

                queueData.队列信息.号码前缀 = txtPrefix.Text;
                queueData.队列信息.号码长度 = Convert.ToInt32(txtNoLen.Text);
                queueData.队列信息.播放站点 = txtCallStation.Text;
                queueData.队列信息.呼叫格式 = rtbCallFormat.Text;
                queueData.队列信息.备注 = txtDes.Text;
                queueData.队列信息.是否禁用 = chkStopUse.Checked;
                queueData.队列信息.创建日期 = _qm.GetServerDate();
            
                 

                queueData.队列信息.CopyBasePro(queueData);

                _qm.NewQueue(queueData);

                NewView(queueData);
                 

                ButtonHint.Start(sender as Button, "OK");
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
                if (txtQueueName.Tag == null)
                {
                    MessageBox.Show("请选择需要删除的队列信息。", "提示");
                    return;
                }
                //弹出删除确认窗口
                if (MessageBox.Show("是否删除队列：" + txtQueueName.Text + "?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
                { return; }

                _qm.DelQueueInfo(txtQueueName.Tag.ToString());

                //int rowIndex = 0;
                if (listView1.SelectedItems.Count > 0)
                {
                    //rowIndex = listView1.SelectedItems[0].Index;
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                }

                ButtonHint.Start(sender as Button, "OK");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 获取选中行的队列信息
        /// </summary>
        /// <returns></returns>
        public QueueData GetSelectQueueData()
        {
            if (listView1.SelectedItems.Count <= 0) return null;


            return listView1.SelectedItems[0].Tag as QueueData;
        }

        private void butModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQueueName.Tag == null)
                {
                    MessageBox.Show("请选择需要修改的队列信息。", "提示");
                    return;
                }


                QueueData queueData = GetSelectQueueData();
                if (queueData == null)
                {
                    MessageBox.Show("未获取到有效的队列信息。", "提示");
                    return;
                }

                if (Verify(true) == false) return;

                 
                queueData.队列名称 = txtQueueName.Text;

                queueData.队列信息.号码前缀 = txtPrefix.Text;
                queueData.队列信息.号码长度 = Convert.ToInt32(txtNoLen.Text);
                queueData.队列信息.播放站点 = txtCallStation.Text;
                queueData.队列信息.呼叫格式 = rtbCallFormat.Text;
                queueData.队列信息.是否禁用 = chkStopUse.Checked;
                queueData.队列信息.备注 = txtDes.Text;
                 

                queueData.队列信息.CopyBasePro(queueData);

                _qm.UpdateQueueInfo(queueData);

    
                listView1.SelectedItems[0].SubItems[0].Text = txtQueueName.Text;
                listView1.SelectedItems[0].SubItems[1].Text = txtDes.Text;
 

                ButtonHint.Start(sender as Button, "OK");
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

                ClearData();

                if (listView1.SelectedItems.Count <= 0) return;

                QueueData queueData = listView1.SelectedItems[0].Tag as QueueData;
                if (queueData == null)
                {
                    MessageBox.Show("未获取到对应的队列信息。", "提示");
                    return;
                }



                txtQueueName.Text = queueData.队列名称;
                txtQueueName.Tag = queueData.队列ID;



                if (queueData.队列信息 != null)
                {
                    txtPrefix.Text = queueData.队列信息.号码前缀;
                    txtNoLen.Text = queueData.队列信息.号码长度.ToString();
                    txtCallStation.Text = queueData.队列信息.播放站点;
                    rtbCallFormat.Text = queueData.队列信息.呼叫格式;
                    txtDes.Text = queueData.队列信息.备注;
                    chkStopUse.Checked = queueData.队列信息.是否禁用;
                }


                BindRoomData(queueData);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void butReleationRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count <= 0) return;

                QueueData queueData = listView1.SelectedItems[0].Tag as QueueData;
                if (queueData == null)
                {
                    MessageBox.Show("未获取到对应的队列信息。", "提示");
                    return;
                }

                frmReleationRooms queueRooms = new frmReleationRooms();

                if (queueRooms.ShowReleationRoom(_qm, queueData, this))
                {
                    BindRoomData(queueData);
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmCallPars callPar = new frmCallPars();

                string par = callPar.ShowCallPar(this);

                if (string.IsNullOrEmpty(par)) return;

                rtbCallFormat.SelectedText = par;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}
