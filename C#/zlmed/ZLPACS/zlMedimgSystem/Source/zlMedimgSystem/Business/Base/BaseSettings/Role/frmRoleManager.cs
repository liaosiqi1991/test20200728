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
    public partial class frmRoleManager : Form, ISetting
    {

        //private bool _isBinding = false;

        private IDBQuery _dbHelper = null;
        private RoleModel _rm = null;
        private ILoginUser _loginUser = null;
        private DepartmentMatchModel _departmentMatchModel = null;//科室模型
        public frmRoleManager()
        : this(null,null)
        {
        }

        public frmRoleManager(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            Init(dbHelper, loginUser);
        }

        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {
            _dbHelper = dbHelper;
            _loginUser = loginUser;

            _rm = new RoleModel(_dbHelper);
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


        private void frmRoleManager_Load(object sender, EventArgs e)
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

        private void cbxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bool allowOper = !string.IsNullOrEmpty(cbxDepartment.Text);

                butNew.Enabled = allowOper;
                butDel.Enabled = allowOper;
                butModify.Enabled = allowOper;

                if (allowOper == false)     return;
                //切换科室时，删除编辑区。否则切换科室后仍可以操作之前科室的角色
                ClearData();
                BindRoleData(); 

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
  

        private void BindRoleData()
        {
            //点击刷新，重复加载list列表情况,先清空数据，列名
            listView1.Items.Clear();
            listView1.Columns.Clear();
            DataTable dtBodypart = _rm.GetRoleInfo(cbxDepartment.SelectedValue.ToString());

            foreach (DataColumn dc in dtBodypart.Columns)
            {
                if (("角色名称").IndexOf(dc.Caption) >= 0)
                {
                    ColumnHeader columnHeader = new ColumnHeader();
                    columnHeader.Text = dc.Caption;
                    columnHeader.Name = dc.Caption;
                    columnHeader.Width = 200;
                    listView1.Columns.Add(columnHeader);
                }
                //分组标记列宽度设为0，隐藏
                if (("分组标记").IndexOf(dc.Caption) >= 0)
                {
                    ColumnHeader columnHeader = new ColumnHeader();
                    columnHeader.Text = dc.Caption;
                    columnHeader.Name = dc.Caption;
                    columnHeader.Width = 0;
                    listView1.Columns.Add(columnHeader);
                }
            }


            DataTable dtGroup = _rm.GetRoleGroups(cbxDepartment.SelectedValue.ToString());

            foreach (DataRow dr in dtGroup.Rows)
            {
                string groupTag = dr["分组标记"].ToString();
                string groupName = (string.IsNullOrEmpty(groupTag)) ? "未分组" : groupTag;
               
                ListViewGroup lvg = new ListViewGroup(groupName);
                listView1.Groups.Add(lvg);


                if (cbxRoleGroup.Items.IndexOf(groupTag) < 0)
                {
                    cbxRoleGroup.Items.Add(groupTag);
                }
            }


            foreach (DataRow drItem in dtBodypart.Rows)
            {
                RoleInfoData roleData = new RoleInfoData();
                roleData.BindRowData(drItem);

                string gn = (string.IsNullOrEmpty(roleData.分组标记)) ? "未分组" : roleData.分组标记; 

                ListViewGroup lvgCur = GetCurGroup(gn);
                                
                
                ListViewItem itemNew = new ListViewItem(new string[] { roleData.角色名称, gn }, 0, lvgCur);
                //添加Name属性赋值，否则listView1.Items.Find无法查找
                itemNew.Name = roleData.角色ID;
                itemNew.Tag = roleData;
                
                listView1.Items.Add(itemNew);
            }

            listView1.View = View.Details;
        }


        private ListViewGroup GetCurGroup(string groupName)
        {
            if (string.IsNullOrEmpty(groupName)) return null;

            foreach (ListViewGroup lvg in listView1.Groups)
            {
                if (lvg.Header.Equals(groupName))
                {
                    return lvg;
                }
            }

            return null;
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

        private void ClearData()
        {
            txtRoleName.Text = "";
            txtRoleName.Tag = null;

            cbxRoleGroup.SelectedIndex = -1;
            cbxRoleGroup.Text = "";

            rtbRoleDescription.Text = "";

            chkStopUse.Checked = false;
        }

        private void SyncSelRowData()
        {
            try
            {

                ClearData();

                if (listView1.SelectedItems.Count <= 0) return;

                RoleInfoData roleData = listView1.SelectedItems[0].Tag as RoleInfoData;
                if (roleData == null)
                {
                    MessageBox.Show("未获取到对应的角色信息。", "提示");
                    return;
                }



                txtRoleName.Text = roleData.角色名称;
                txtRoleName.Tag = roleData.角色ID;

                cbxRoleGroup.Text = roleData.分组标记;

                if (roleData.角色信息 != null)
                {
                    rtbRoleDescription.Text = roleData.角色信息.角色描述;
                    chkStopUse.Checked = roleData.角色信息.是否停用;
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private bool Verify(bool isModify = false)
        {
            if (string.IsNullOrEmpty(txtRoleName.Text))
            {
                MessageBox.Show("角色名称不允许为空。", "提示");
                txtRoleName.Focus();
                return false;
            }
            //修改GetRoleID，添加科室ID作为条件，不同科室允许角色名称相同
            string roleId = _rm.GetRoleID(txtRoleName.Text,cbxDepartment.SelectedValue.ToString());
            if (string.IsNullOrEmpty(roleId) == false)
            {
                if (isModify)
                {
                    if (roleId.Equals(txtRoleName.Tag) == false)
                    {
                        MessageBox.Show("角色名不允许重复。", "提示");
                        txtRoleName.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("角色名不允许重复。", "提示");
                    txtRoleName.Focus();
                    return false;
                }
            }

            return true;
        }

        private void NewView(RoleInfoData roleInfoData)
        {
            string groupName = (string.IsNullOrEmpty(roleInfoData.分组标记)) ? "未分组" : roleInfoData.分组标记;

            ListViewGroup lvgCur = GetCurGroup(groupName);

            if (lvgCur == null)
            {
                lvgCur = new ListViewGroup(groupName);
                listView1.Groups.Add(lvgCur);
            }

            ListViewItem itemNew = new ListViewItem(new string[] { roleInfoData.角色名称, groupName }, 0, lvgCur);
            //添加Name属性赋值，否则listView1.Items.Find无法查找
            itemNew.Name = roleInfoData.角色ID;
            itemNew.Tag = roleInfoData;

            listView1.Items.Add(itemNew);

            listView1.View = View.Details;
        }


        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (Verify() == false) return;

                RoleInfoData roleData = new RoleInfoData();

                roleData.科室ID = cbxDepartment.SelectedValue.ToString();
                roleData.角色ID = SqlHelper.GetCmpUID();
                roleData.角色名称 = txtRoleName.Text;
                roleData.分组标记 = cbxRoleGroup.Text;

                roleData.角色信息.角色描述 = rtbRoleDescription.Text;
                roleData.角色信息.是否停用 = chkStopUse.Checked;
                roleData.角色信息.创建日期 = DateTime.Now;

                roleData.角色信息.CopyBasePro(roleData);

                _rm.NewRole(roleData);

                NewView(roleData);

                UpdateRoleGroup();

                ButtonHint.Start(sender as Button, "OK"); 

                //添加成功后，需要定位到添加 的角色
                listView1.Items.Find(roleData.角色ID, false)[0].Selected = true;

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
                if (txtRoleName.Tag == null)
                {
                    MessageBox.Show("请选择需要删除的角色信息。", "提示");
                    return;
                }
                //弹出删除确认窗口
                if (MessageBox.Show("是否删除角色：" + txtRoleName.Text + "?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                { return; }

                _rm.DelRoleInfo(txtRoleName.Tag.ToString());

                int rowIndex = 0;
                if (listView1.SelectedItems.Count > 0)
                {
                    rowIndex = listView1.SelectedItems[0].Index;
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
        /// 获取选中行的角色信息
        /// </summary>
        /// <returns></returns>
        public RoleInfoData GetSelectRoleData()
        {
            if (listView1.SelectedItems.Count <= 0) return null;


            return listView1.SelectedItems[0].Tag as RoleInfoData;
        }

        private void butModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRoleName.Tag == null)
                {
                    MessageBox.Show("请选择需要修改的角色信息。", "提示");
                    return;
                }


                RoleInfoData roleData = GetSelectRoleData();
                if (roleData == null)
                {
                    MessageBox.Show("未获取到有效的角色信息。", "提示");
                    return;
                }

                if (Verify(true) == false) return;


                bool isNewGroup = false;
                if (cbxRoleGroup.Text.Equals(roleData.分组标记) == false)
                {
                    isNewGroup = true;

                }

                roleData.角色名称 = txtRoleName.Text;
                roleData.分组标记 = cbxRoleGroup.Text;
                roleData.角色信息.角色描述 = rtbRoleDescription.Text;
                roleData.角色信息.是否停用 = chkStopUse.Checked;

                roleData.角色信息.CopyBasePro(roleData);

                _rm.UpdateRoleInfo(roleData);

                if (isNewGroup)
                {
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                    NewView(roleData);
                }
                else
                {
                    listView1.SelectedItems[0].SubItems[0].Text = txtRoleName.Text;
                    listView1.SelectedItems[0].SubItems[1].Text = (string.IsNullOrEmpty(cbxRoleGroup.Text)) ? "未分组" : cbxRoleGroup.Text;
                }



                UpdateRoleGroup();

                ButtonHint.Start(sender as Button, "OK");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void UpdateRoleGroup()
        {
            if (string.IsNullOrEmpty(cbxRoleGroup.Text)) return;
            if (cbxRoleGroup.Items.IndexOf(cbxRoleGroup.Text) < 0)
            {
                cbxRoleGroup.Items.Add(cbxRoleGroup.Text);
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
    }
}
