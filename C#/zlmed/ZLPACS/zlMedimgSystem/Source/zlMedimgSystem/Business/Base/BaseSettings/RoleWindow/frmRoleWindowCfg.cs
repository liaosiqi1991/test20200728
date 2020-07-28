using DevExpress.XtraSplashScreen;
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
using zlMedimgSystem.Layout;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmRoleWindowCfg : Form, ISetting
    {
        private IDBQuery _dbHelper = null;
        private RoleWindowModel _rwm = null;
        private ILoginUser _loginUser = null;
        private DepartmentMatchModel _departmentMatchModel = null;//科室模型
        public frmRoleWindowCfg()
        : this(null, null)
        {
        }

        public frmRoleWindowCfg(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            Init(dbHelper, loginUser);
        }

        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {
            _dbHelper = dbHelper;
            _rwm = new RoleWindowModel(_dbHelper);
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

        private void frmRoleWindowCfg_Load(object sender, EventArgs e)
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

        private void cbxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bool allowOper = !string.IsNullOrEmpty(cbxDepartment.Text);

                butNew.Enabled = allowOper;
                butDel.Enabled = allowOper;
                butModify.Enabled = allowOper;
                butDesign.Enabled = allowOper;

                if (allowOper == false) return;
                
                BindRoleData();
                BindWindowData();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        /// <summary>
        /// 绑定角色数据
        /// </summary>
        private void BindRoleData()
        {
            lstRoles.Items.Clear();

            DataTable dtRol = _rwm.GetRoleInfo(cbxDepartment.SelectedValue.ToString());

            foreach(DataRow dr in dtRol.Rows)
            {
                RoleInfoData rid = new RoleInfoData();
                rid.BindRowData(dr);

                ListViewItem lvi = lstRoles.Items.Add(rid.角色名称);
                lvi.Tag = rid.角色ID;
                lvi.ImageIndex = 0;
            } 
        }

        /// <summary>
        /// 绑定窗体信息数据
        /// </summary>
        private void BindWindowData()
        {
            //_isLoadBodypart = true;
            try
            {
                listView1.Clear();
                cbxWindowGroup.Items.Clear();


                DataTable dtWindows = _rwm.GetWindowInfo(cbxDepartment.SelectedValue.ToString()); 

                foreach (DataColumn dc in dtWindows.Columns)
                {
                    if (("窗体名称,版本").IndexOf(dc.Caption) >= 0)
                    {
                        ColumnHeader columnHeader = new ColumnHeader();
                        columnHeader.Text = dc.Caption;
                        columnHeader.Name = dc.Caption;
                        columnHeader.Width = 120;
                        listView1.Columns.Add(columnHeader);
                    }
                    //默认隐藏分组标记,版本列
                    if (("分组标记").IndexOf(dc.Caption) >= 0)
                    {
                        ColumnHeader columnHeader = new ColumnHeader();
                        columnHeader.Text = dc.Caption;
                        columnHeader.Name = dc.Caption;
                        columnHeader.Width = 0;
                        listView1.Columns.Add(columnHeader);
                    }
                }
                //添加固定列最后更新日期
                ColumnHeader columnHeaderDate = new ColumnHeader();
                columnHeaderDate.Text = "最后更新日期";
                columnHeaderDate.Name = "最后更新日期";
                columnHeaderDate.Width = 120;
                listView1.Columns.Add(columnHeaderDate);

                DataTable dtGroup = _rwm.GetWindowGroups(cbxDepartment.SelectedValue.ToString());

                foreach (DataRow dr in dtGroup.Rows)
                {
                    string groupTag = dr["分组标记"].ToString();
                    string groupName = SqlHelper.Nvl(groupTag, "未分组"); 
                    

                    ListViewGroup lvg = new ListViewGroup(groupName);
                    listView1.Groups.Add(lvg);

                     
                    if (cbxWindowGroup.Items.IndexOf(groupTag) < 0)
                    {
                        cbxWindowGroup.Items.Add(groupTag);
                    }
                }


                foreach (DataRow drItem in dtWindows.Rows)
                {
                    WindowInfoData windowInfo = new WindowInfoData();
                    windowInfo.BindRowData(drItem);

                    string gn = SqlHelper.Nvl(windowInfo.分组标记, "未分组");
                    ListViewGroup lvgCur = GetCurGroup(gn);
                    string sdate = windowInfo.窗体信息.最后更新日期.Year == 1 ? "" : windowInfo.窗体信息.最后更新日期.ToString("yyyy-MM-dd hh:mm");
                    ListViewItem itemNew = new ListViewItem(new string[] { windowInfo.窗体名称, gn, windowInfo.版本.ToString(), sdate }, 0, lvgCur);

                    itemNew.Name = windowInfo.窗体ID; 

                    itemNew.Tag = windowInfo;

                    listView1.Items.Add(itemNew);
                }

                listView1.View = View.Details;
            }
            finally
            {
                //_isLoadBodypart = false;
            }
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

        private bool Verify(bool isModify = false)
        {
            if (string.IsNullOrEmpty(txtWindowName.Text))
            {
                MessageBox.Show("窗体名称不允许为空。", "提示");
                txtWindowName.Focus();
                return false;
            }

            string windowId = _rwm.GetWindowId(txtWindowName.Text, cbxDepartment.SelectedValue.ToString());
            if (string.IsNullOrEmpty(windowId) == false)
            {
                if (isModify)
                {
                    if (windowId.Equals(txtWindowName.Tag) == false)
                    {
                        MessageBox.Show("窗体名称不允许重复。", "提示");
                        txtWindowName.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("窗体名称不允许重复。", "提示");
                    txtWindowName.Focus();
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

                WindowInfoData windowInfo = new WindowInfoData();
                windowInfo.窗体ID = SqlHelper.GetCmpUID();
                windowInfo.科室ID = cbxDepartment.SelectedValue.ToString();
                windowInfo.窗体名称 = txtWindowName.Text;
                windowInfo.分组标记 = cbxWindowGroup.Text;
                windowInfo.窗体信息.窗体描述 = rtbWindowDescription.Text;
                windowInfo.窗体信息.创建日期 = _rwm.GetServerDate();

                windowInfo.窗体信息.CopyBasePro(windowInfo);

                _rwm.NewWindow(windowInfo);

                NewView(windowInfo);

                UpdateWindowGroup();

                ButtonHint.Start(sender as Button, "OK");
                //添加后定位焦点
                listView1.Items.Find(windowInfo.窗体ID, false)[0].Selected = true;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void NewView(WindowInfoData windowInfo)
        {
            string groupName = SqlHelper.Nvl(windowInfo.分组标记, "未分组");

            ListViewGroup lvgCur = GetCurGroup(groupName);

            if (lvgCur == null)
            {
                lvgCur = new ListViewGroup(groupName);
                listView1.Groups.Add(lvgCur);
            }
            //新增的窗体，最后更新时间为空
            ListViewItem itemNew = new ListViewItem(new string[] { windowInfo.窗体名称, groupName, windowInfo.版本.ToString(), "" }, 0, lvgCur);

            //添加ID赋值，listview定位使用find查找会用到
            itemNew.Name= itemNew.Name = windowInfo.窗体ID;
            itemNew.Tag = windowInfo;

            listView1.Items.Add(itemNew);

            listView1.View = View.Details;
        }

        private void UpdateWindowGroup()
        {
            if (string.IsNullOrEmpty(cbxWindowGroup.Text)) return;
            if (cbxWindowGroup.Items.IndexOf(cbxWindowGroup.Text) < 0)
            {
                cbxWindowGroup.Items.Add(cbxWindowGroup.Text);
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

        private void ClearData()
        {
            txtWindowName.Text = "";
            txtWindowName.Tag = null;

            cbxWindowGroup.Text = "";
             
            rtbWindowDescription.Text = ""; 
        }



        private void SyncSelRowData()
        {
            try
            {

                ClearData();

                if (listView1.SelectedItems.Count <= 0) return;

                WindowInfoData windowInfo = listView1.SelectedItems[0].Tag as WindowInfoData;
                if (windowInfo == null)
                {
                    MessageBox.Show("未获取到对应的窗体信息。", "提示");
                    return;
                }

                txtWindowName.Text = windowInfo.窗体名称;
                txtWindowName.Tag = windowInfo.窗体ID;

                cbxWindowGroup.Text = windowInfo.分组标记;

                if (windowInfo.窗体信息 != null)
                { 
                    rtbWindowDescription.Text = windowInfo.窗体信息.窗体描述;
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
                if (txtWindowName.Tag == null)
                {
                    MessageBox.Show("请选择需要删除的窗体信息。", "提示");
                    return;
                }
                //如果窗体已经并角色应用，提示删除窗体会删除角色对窗体的应用。否则提示是否删除窗口
                //添加事务处理
                _rwm.TransactionBegin();
                if (_rwm.GetRowName(txtWindowName.Tag.ToString()))
                {
                    if (MessageBox.Show("窗体：" + txtWindowName.Text + "已经使用，强制删除窗体会自动删除角色对窗体的应用，是否强制删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _rwm.UpdateRowWindowID(txtWindowName.Tag.ToString());
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (MessageBox.Show("是否删除窗体：" + txtWindowName.Text + "?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
                _rwm.DelWindowInfo(txtWindowName.Tag.ToString());
                _rwm.TransactionCommit();
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
                _rwm.TransactionRollback();
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 获取选择的部位信息
        /// </summary>
        /// <returns></returns>
        public WindowInfoData GetSelectWindowInfo()
        {

            if (listView1.SelectedItems.Count <= 0) return null;


            return listView1.SelectedItems[0].Tag as WindowInfoData;
        }

        private void butModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtWindowName.Tag == null)
                {
                    MessageBox.Show("请选择需要修改的窗体信息。", "提示");
                    return;
                }


                WindowInfoData windowInfo = GetSelectWindowInfo();
                if (windowInfo == null)
                {
                    MessageBox.Show("未获取到有效的窗体信息。", "提示");
                    return;
                }

                if (Verify(true) == false) return;


                bool isNewGroup = false;
                if (cbxWindowGroup.Text.Equals(windowInfo.分组标记) == false)
                {
                    isNewGroup = true;

                }

                windowInfo.窗体名称 = txtWindowName.Text;
                windowInfo.分组标记 = cbxWindowGroup.Text; 
                windowInfo.窗体信息.窗体描述 = rtbWindowDescription.Text;

                windowInfo.窗体信息.CopyBasePro(windowInfo);

                _rwm.UpdateWindowInfo(windowInfo);

                if (isNewGroup)
                {
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                    NewView(windowInfo);
                }
                else
                {
                    listView1.SelectedItems[0].SubItems[0].Text = txtWindowName.Text;
                    listView1.SelectedItems[0].SubItems[1].Text = SqlHelper.Nvl(windowInfo.分组标记, "未分组");
                }
                 
                UpdateWindowGroup();

                ButtonHint.Start(sender as Button, "OK");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butSetMainWindow_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstRoles.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("请选择需要配置的角色信息。", "提示");
                    return;
                }

                if (listView1.Items.Count <= 0)
                {
                    MessageBox.Show("请创建对应的窗体配置。", "提示");
                    return;
                }

                string roleId = lstRoles.SelectedItems[0].Tag.ToString();

                string windowId = "";
                foreach (ListViewItem lvi in listView1.Items)
                {
                    if (lvi.Checked)
                    {
                        windowId = (lvi.Tag as WindowInfoData).窗体ID;
                        break;
                    }
                }

                _rwm.SetMainWindow(roleId, windowId);


                ButtonHint.Start(sender as Button, "OK");

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                if (e.Item.Checked)
                {
                    foreach (ListViewItem lvi in listView1.Items)
                    {
                        if (e.Item.Equals(lvi)) continue;

                        lvi.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void ClearWindowChecked()
        {
            foreach (ListViewItem lvi in listView1.Items)
            {
                lvi.Checked = false;
            }
        }

        private void lstRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearWindowChecked();

                if (lstRoles.SelectedItems.Count <= 0) return;

                string windowId = _rwm.GetRoleMainWindowID(lstRoles.SelectedItems[0].Tag.ToString());
                if (string.IsNullOrEmpty(windowId)) return;

                foreach (ListViewItem lvi in listView1.Items)
                {
                    WindowInfoData windowInfo = lvi.Tag as WindowInfoData;

                    if (windowInfo.窗体ID.Equals(windowId))
                    {
                        lvi.Checked = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butDesign_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("请选择需要进行设计的窗体。", "提示");
                    return;
                }

                WindowInfoData wid = listView1.SelectedItems[0].Tag as WindowInfoData;
                if(wid == null)
                {
                    MessageBox.Show("窗体信息对象转换无效。", "提示");
                    return;
                }

                bool isMdi = AppSetting.ReadBool("IsMdiWindow", true);


                OpenWindowDesign(wid.窗体ID, isMdi);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void OpenWindowDesign(string designKey, bool isMdiStyle)
        {
            ListViewItem[] lvis = listView1.Items.Find(designKey, false);
            if (lvis.Length <= 0)
            {
                MessageBox.Show("未选择需要进行设计的窗体，不能读取布局配置。", "提示");
                return;
            }

            WindowInfoData wid = (lvis[0].Tag as WindowInfoData);
            if (wid == null)
            {
                MessageBox.Show("窗体信息无效，不能读取布局配置。", "提示");
                return;
            }

            StationInfo stationInfo = new StationInfo();

            stationInfo.DBServerName = (this.Parent.TopLevelControl as frmMainConfig).ServerName;
            stationInfo.DepartmentId = cbxDepartment.SelectedValue.ToString();
            stationInfo.DepartmentName = cbxDepartment.Text;

            if (isMdiStyle)
            {
                frmDesignParent bmlMdi = new frmDesignParent();


                bmlMdi.SetDesignText(wid.窗体ID, wid.窗体名称);

                //配置事件
                bmlMdi.OnSaveWindowLayout += SaveLayout;
                bmlMdi.OnReadWindowLayout += ReadLayout;
                bmlMdi.OnQueryParentWindowName += QueryLinkWindow;
                bmlMdi.OnMdiWindowChange += MdiWindowChange;

                bmlMdi.Init(_dbHelper, _loginUser, stationInfo, null);

                bmlMdi.Show(this);
            }
            else
            {
                BizMainLayout bmlPopup = new BizMainLayout(true);

                bmlPopup.SetDesignText(wid.窗体ID, wid.窗体名称, null, null);

                //配置事件
                bmlPopup.OnStateSync += StateSync;
                bmlPopup.OnSaveWindowLayout += SaveLayout;
                bmlPopup.OnReadWindowLayout += ReadLayout;
                bmlPopup.OnQueryParentWindowName += QueryLinkWindow;
                bmlPopup.OnMdiWindowChange += MdiWindowChange;

                bmlPopup.Init(_dbHelper, _loginUser, stationInfo, null);
                

                bmlPopup.BeforeLoadAssembly();


                bmlPopup.Show(this);
            }

        }

        private void StateSync(string stateMsg, bool isFinal = false)
        {            
            if (isFinal)
            {
                SplashScreenManager.CloseForm();
                return;
            }

            if (SplashScreenManager.Default == null)
            {
                SplashScreenManager.ShowForm(typeof(frmSplash));
            }

            SplashScreenManager.Default.SetWaitFormDescription(stateMsg);
        }

        private void MdiWindowChange(string designWinKey, bool isToMdiWindow)
        {
            OpenWindowDesign(designWinKey, isToMdiWindow);

            AppSetting.WriteBool("IsMdiWindow", isToMdiWindow);
        }

        private void QueryLinkWindow(string designKey, out List<string> names)
        {
            names = new List<string>();

            foreach(ListViewItem lvi in listView1.Items)
            {
                if (lvi.Tag == null) continue;

                WindowInfoData windowInfo = lvi.Tag as WindowInfoData;
                if (windowInfo == null) continue;

                names.Add(windowInfo.窗体名称);
            }

        }

        private void SaveLayout(BizMainLayout bizWindow, string designKey, string layoutFmt)
        {
            //if (listView1.SelectedItems.Count <= 0)
            //{
            //    MessageBox.Show("未选择需要进行设计的窗体，不能保存布局配置。", "提示");
            //    return;
            //}

            ListViewItem[] lvis = listView1.Items.Find(designKey, false);
            if (lvis.Length <= 0)
            {
                MessageBox.Show("未选择需要进行设计的窗体，不能保存布局配置。", "提示");
                return;
            }

            WindowInfoData windowInfo = (lvis[0].Tag as WindowInfoData);
            if (windowInfo == null)
            {
                MessageBox.Show("窗体信息无效，不能保存布局配置。", "提示");
                return;
            }

            windowInfo.版本 = windowInfo.版本 + 1;
            windowInfo.窗体信息.布局配置 = layoutFmt;
            windowInfo.窗体信息.最后更新日期 = DateTime.Now;

            _rwm.UpdateWindowInfo(windowInfo);

            lvis[0].SubItems[2].Text = windowInfo.版本.ToString();
            lvis[0].SubItems[3].Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm") ;
        }

        private void ReadLayout(BizMainLayout bizWindow, ref string designKey, out string layoutFmt)
        {
            layoutFmt = "";

            //if (listView1.SelectedItems.Count <= 0)
            //{
            //    MessageBox.Show("未选择需要进行设计的窗体，不能读取布局配置。", "提示");
            //    return;
            //}

            ListViewItem[] lvis = listView1.Items.Find(designKey, false);
            if (lvis.Length <= 0)
            {
                MessageBox.Show("未选择需要进行设计的窗体，不能读取布局配置。", "提示");
                return;
            }

            WindowInfoData windowInfo = (lvis[0].Tag as WindowInfoData);
            if (windowInfo == null)
            {
                MessageBox.Show("窗体信息无效，不能读取布局配置。", "提示");
                return;
            }

            layoutFmt = windowInfo.窗体信息.布局配置;

        }
    }
}
