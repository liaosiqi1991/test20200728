using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.BusinessBase;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmDepRoomAndDeviceCfg : Form, ISetting
    {
        private IDBQuery _dbHelper = null;
        private DepRoomModel _DepRoomModel = null;
        private DepDeviceModel _DepDeviceModel = null;
        private DepartmentMatchModel _departmentMatchModel = null;//科室模型
        private DeviceKindModel _deviceKindModel = null;//影像类型模型
        private ILoginUser _loginUser = null;
        private bool DeviceEditState;
        private ComboBox cbo = new ComboBox();

        private DataTable _ImageType = new DataTable();

        public frmDepRoomAndDeviceCfg()
            :this(null, null)
        { 
        }private ComboBox Score_ComboBox = new ComboBox();

        public frmDepRoomAndDeviceCfg(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();
            Init(dbHelper, loginUser);
        }

        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {
            _dbHelper = dbHelper;
            _loginUser = loginUser;
            _DepRoomModel = new DepRoomModel(_dbHelper);
            _DepDeviceModel = new DepDeviceModel(_dbHelper);
            _departmentMatchModel = new DepartmentMatchModel(dbHelper);
            _deviceKindModel = new DeviceKindModel(dbHelper);

            if (_dbHelper != null)
                InitCbo();
        }

        private void InitCbo()
        {

            try
            {
                //绑定影像类别数据前先清除数据
                cbo.DataSource = null;
                cbo.DataSource = _deviceKindModel.GetAllDeviceKind();

                //判断控件是否已经初始化，已经初始化就不在执行
                if (string.IsNullOrEmpty(cbo.DisplayMember) == true)
                {
                    cbo.DisplayMember = "影像类别";
                    cbo.ValueMember = "影像类别";
                    cbo.FlatStyle = FlatStyle.Flat;
                    cbo.DropDownStyle = ComboBoxStyle.DropDownList;


                    //异常处理，添加判断dgvDevice.CurrentCell为空时不允许赋值。
                    //只有列名是影像类别的才加载
                    cbo.Leave += delegate
                    {
                        if (dgvDevice.CurrentCell != null)
                        {
                            if (dgvDevice.CurrentCell.OwningColumn.Name == "影像类别")
                            {
                                dgvDevice.CurrentCell.Value = cbo.Text;
                            }
                        }
                    };

                    cbo.SelectedValueChanged += delegate
                    {
                        if (dgvDevice.CurrentCell != null)

                        {
                            if (dgvDevice.CurrentCell.OwningColumn.Name == "影像类别")
                            {
                                dgvDevice.CurrentCell.Value = cbo.Text;
                            }
                        }
                    };

                    cbo.Visible = false;
                    dgvDevice.Controls.Add(cbo);
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex,"加载影像类别出错，请联系管理员处理", this);
            }


        }

        public void RefreshSetting()
        {
            try
            {

                //DataTable dt = _DepRoomModel.GetDepts();
                DataTable dt =_departmentMatchModel.GetAllDepartment();

                cboDept.DisplayMember = "科室名称";
                cboDept.ValueMember = "科室ID";
                cboDept.DataSource = dt;


                if (cboDept.Items.Count > 0) cboDept.SelectedIndex = 0;
                //刷新影像类别
                InitCbo();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmDepRoomAndDeviceCfg_Load(object sender, EventArgs e)
        {
            RefreshSetting();
        }

        private void cboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDept.DataSource = null;
                dgvDevice.DataSource = null;

                if (string.IsNullOrEmpty(cboDept.Text))
                {
                    return;
                }

                DataTable dt = _DepRoomModel.GetDeptInfo(cboDept.SelectedValue.ToString());
                dgvDept.DataSource = dt;
                SetDgvRoomFace();
 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private bool RoomAdd()
        {
            //按钮点击添加，列表新增一行，数据显示控件显示缺省信息。
            try
            {
                if (VerifyRoom() == false) return false;

                DepRoomData roominfo = new DepRoomData();

                roominfo.房间ID = SqlHelper.GetCmpUID();
                roominfo.科室ID = cboDept.SelectedValue.ToString();
                roominfo.房间信息 = new JRoomInfo();

                roominfo.房间信息.备注描述 = txtTag.Text ;
                roominfo.房间信息.位置 = txtPosition.Text ;
                roominfo.房间信息.负责人 = txtLeader.Text ;
                roominfo.房间信息.创建日期 = System.DateTime.Now.ToString();

                roominfo.房间名称 = txtRoomName.Text;

                roominfo.房间信息.CopyBasePro(roominfo);

                _DepRoomModel.NewRoom(roominfo);

                DataTable dtBind = dgvDept.DataSource as DataTable;

                DataRow drNew = dtBind.NewRow();

                drNew["房间ID"] = roominfo.房间ID;
                drNew["房间名称"] = roominfo.房间名称;
                dtBind.Rows.Add(drNew);
                return true;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        private bool RoomDel()
        {
            //按钮点击删除,列表删除当前焦点行，并且删除数据库信息
            try
            {
                if (txtRoomName.Tag == null)
                {
                    MessageBox.Show("请选择需要删除的房间。", "提示");
                    return false;
                }

                DataGridViewRow dvr = dgvDept.SelectedRows[0];
                string roomID = dvr.Cells["房间ID"].Value.ToString();

                if (_DepRoomModel.ExistDevice(roomID))
                {
                    MessageBox.Show("删除房间前需要先删除房间中的设备。", "提示");
                    return false;
                }

                _DepRoomModel.DelRoomInfo(txtRoomName.Tag.ToString());

                int rowIndex = 0;
                if (dgvDept.SelectedRows.Count > 0)
                {
                    rowIndex = dgvDept.SelectedRows[0].Index;
                }


                DataTable dtBind = (dgvDept.DataSource as DataTable);

                if (dtBind.Rows.Count > 0)
                {
                    DataRow[] drs = dtBind.Select("房间ID='" + txtRoomName.Tag.ToString() + "'");

                    foreach (DataRow dr in drs)
                    {
                        dtBind.Rows.Remove(dr);
                    }
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        private DepRoomData GetSelectRoomData()
        {

            if (dgvDept.SelectedRows.Count <= 0) return null;

            DataGridViewRow dvr = dgvDept.SelectedRows[0];

            string roomID = dvr.Cells["房间ID"].Value.ToString();

            DataRow[] drs = (dgvDept.DataSource as DataTable).Select("房间ID='" + roomID + "'");

            if (drs.Length > 0)
            {
                DepRoomData roomData = new DepRoomData();
                roomData.BindRowData(drs[0]);

                return roomData;
            }

            return null;
        }

        private bool RoomUpdate()
        {
            //按钮点击修改
            try
            {
                if (txtRoomName.Tag == null)
                {
                    MessageBox.Show("请选择需要修改的房间信息。", "提示");
                    return false;
                }


                DepRoomData roomData = GetSelectRoomData();
                if (roomData == null)
                {
                    MessageBox.Show("未获取到有效的房间信息。", "提示");
                    return false;
                }

                if (VerifyRoom(true) == false) return false;

                roomData.房间信息 = new JRoomInfo();

                roomData.房间信息.备注描述 = txtTag.Text;
                roomData.房间信息.位置 = txtPosition.Text;
                roomData.房间信息.负责人 = txtLeader.Text;
                roomData.房间信息.创建日期 = System.DateTime.Now.ToString();

                roomData.房间名称 = txtRoomName.Text;

                roomData.房间信息.CopyBasePro(roomData);

                _DepRoomModel.UpdateRoomInfo(roomData);

                DataRow dr = roomData.GetBindRow();

                dr["房间名称"] = txtRoomName.Text;

                return true;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex,"设备房间信息保存失败，请参看描述信息：" ,this);
                return false;
            }
        }

        private bool VerifyRoom(bool isModify = false)
        {
            //验证房间名称是否为空，是否存在相同名称

            if (string.IsNullOrEmpty(txtRoomName.Text.Trim()))
            {
                MessageBox.Show("房间名称不能为空。", "提示");
                txtRoomName.Focus();
                return false;
            }


            string roomID = _DepRoomModel.GetRoomID(txtRoomName.Text, cboDept.SelectedValue.ToString());
            if (string.IsNullOrEmpty(roomID) == false)
            {
                if (isModify)
                {
                    if (roomID.Equals(txtRoomName.Tag) == false)
                    {
                        MessageBox.Show("同一科室房间名称不允许重复。", "提示");
                        txtRoomName.Focus();

                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("房间名称不允许重复。", "提示");
                    txtRoomName.Focus();

                    return false;
                }
            }
            return true;
        }

        private bool VerifyDevice()
        {
            //验证房间中是否存在设备名称为空的情况并且提示
            for (int i = 0; i < dgvDevice.Rows.Count; i++)
            {
                DataGridViewRow dr = dgvDevice.Rows[i];

                if (dr.Cells["设备名称"].Value.ToString().Trim()  == "")
                {
                    dgvDevice.Rows[i].Cells["设备名称"].Selected = true;
                    dgvDevice.BeginEdit(false);
                    MessageBox.Show("设备名称不能为空。", "提示");
                    return false;
                }

                for (int j = 0; j < dgvDevice.Rows.Count; j++)
                {
                    DataGridViewRow drOther = dgvDevice.Rows[j];

                    if (drOther.Cells["设备名称"].Value.ToString() == dr.Cells["设备名称"].Value.ToString() && i!=j )
                    {
                        dgvDevice.Rows[i].Cells["设备名称"].Selected = true;
                        MessageBox.Show("已经存在设备名成为 "+ drOther.Cells["设备名称"].Value.ToString() + " 的设备。", "提示");
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (RoomAdd())
            {
                ButtonHint.Start(sender as Button, "OK");
                //添加成功后点击定位到最后一行
                dgvDept.Rows[dgvDept.Rows.Count - 1].Selected = true;            }
        }

        private void ClearData()
        {
            txtRoomName.Text = "";
            txtTag.Text = "";
            txtPosition.Text = "";
            txtLeader.Text = "";
        }

        private void SyncSelRowData()
        {
            try
            {
                //if (_isBinding) return;

                ClearData();

                if (dgvDept.DataSource == null) return;
                if (dgvDept.SelectedRows.Count <= 0) return;

                DataGridViewRow dvr = dgvDept.SelectedRows[0];


                string roomID = dvr.Cells["房间ID"].Value.ToString();
                txtRoomName.Tag = roomID;

                DataRow[] drs = (dgvDept.DataSource as DataTable).Select("房间ID='" + roomID + "'");

                if (drs.Length > 0)
                {
                    DepRoomData roomData = new DepRoomData();
                    roomData.BindRowData(drs[0]);

                    txtRoomName.Text = roomData.房间名称;
                  
                    string strRoomInfo = _DepRoomModel.GetRoomInfo(roomID);
                    JRoomInfo roomInfo = JsonHelper.DeserializeObject<JRoomInfo>(strRoomInfo);
                    ShowDevice(roomID);

                    if (roomInfo != null)
                    {
                        txtTag.Text = roomInfo.备注描述;
                        txtPosition.Text = roomInfo.位置;
                        txtLeader.Text = roomInfo.负责人;
                    }
                }
                dgvDevice.Tag = roomID;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void dgvDept_SelectionChanged(object sender, EventArgs e)
        {

            //MessageBox.Show("设备列表情况");

            try
            {
                if (DeviceEditState)
                {
                    if (MessageBox.Show("当前编辑了设备信息还未保存，切换房间前是否先保存", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        UpdateDevice();
                }
                DeviceEditState = false;
                SyncSelRowData();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //保存时判断，如果有修改设备信息，先保存设备信息。
            try
            {
                if (DeviceEditState)
                {
                    UpdateDevice();
                }
                DeviceEditState = false;
            }catch(Exception ex)
            {
                MsgBox.ShowException(ex, "保存失败，设备信息存在修改就来，保存设备信息时出错，请查看描述信息", this);
                return;
            }
            if (RoomUpdate())
                ButtonHint.Start(sender as Button, "OK");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string roomName = "";
                if (dgvDept.SelectedRows.Count ==1)
                {
                    DataGridViewRow dvr = dgvDept.SelectedRows[0];
                    roomName = dvr.Cells["房间名称"].Value.ToString();
                    roomName = " " + roomName + " ";
                }
                else
                {
                    //如果房间列表没有数据，不允许执行删除按钮功能。
                    MessageBox.Show("房间名称未找到，不能执行删除操作","提示");
                    return;
                }

                if (MessageBox.Show("确定要删除房间"+ roomName + "吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;

                if (RoomDel())
                    ButtonHint.Start(sender as Button, "OK");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 根据房间ID显示设备
        /// </summary>
        /// <param name="roomID"></param>
        private void ShowDevice(string roomID)
        {
            try
            {
                DataTable dt = _DepDeviceModel.GetDeviceInfo(roomID);

                dt.Columns.Add(new DataColumn("是否启用", typeof(bool)));
                dt.Columns.Add(new DataColumn("设备说明", typeof(string)));
                dt.Columns.Add(new DataColumn("负责人", typeof(string)));

                foreach (DataRow dr in dt.Rows)
                {
                    string strj = dr["设备信息"].ToString();
                    JRoomDeviceInfo DeviceInfo = JsonHelper.DeserializeObject<JRoomDeviceInfo>(strj);

                    dr["是否启用"] = bool.Parse(DeviceInfo.是否启用.ToString());
                    if (DeviceInfo.设备说明 != null)
                        dr["设备说明"] = DeviceInfo.设备说明.ToString();
                    if (DeviceInfo.负责人 != null)
                        dr["负责人"] = DeviceInfo.负责人.ToString();

                }

                dgvDevice.DataSource = dt;
                if (dgvDevice.Columns.Contains("影像类别"))
                    dgvDevice.Columns["影像类别"].ReadOnly = true;


                SetDgvDeviceFace();
            }
            catch (Exception ex)
            {

                MsgBox.ShowException(ex, this);  
            }

        }

        private void btnDeviceAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (isDevClickButton() == false)
                {
                    MessageBox.Show("没有选中的房间，不能对设备进行操作", "提示");
                    return;
                }
                if (VerifyDevice()==false) return;

                DataGridViewRow dvr = dgvDept.SelectedRows[0];

                string roomID = dvr.Cells["房间ID"].Value.ToString();

                DataTable dtBind = dgvDevice.DataSource as DataTable;

                DataRow drNew = dtBind.NewRow();
               
                drNew["设备ID"] = SqlHelper.GetCmpUID();
                drNew["是否启用"] = true;

                dtBind.Rows.Add(drNew);

                dgvDevice.CurrentCell = dgvDevice.Rows[dgvDevice.RowCount-1].Cells["设备名称"];
                dgvDevice.BeginEdit(true);


            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, "新增设备信息错误，请参看描述信息",this);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isDevClickButton() == false)
            {
                MessageBox.Show("没有选中的房间，不能对设备进行操作","提示");
                return;
            }
            
            //点击应用时，同步刷新影像类别
            InitCbo();
            dgvDevice.BeginEdit(false);
            UpdateDevice();
        }

        private void btnDeviceRemove_Click(object sender, EventArgs e)
        {
            //添加异常处理
            try
            {
                if (isDevClickButton() == false)
                {
                    MessageBox.Show("没有选中的房间，不能对设备进行操作", "提示");
                    return;
                }
                dgvDevice.BeginEdit(false);
                if (dgvDevice.Rows.Count > 0)
                {

                    if (dgvDevice.SelectedCells.Count == 0)
                    {
                        MessageBox.Show("清先选择需要删除的数据", "提示");
                        return;
                    }

                    int i = dgvDevice.SelectedCells[0].RowIndex;
                    DataGridViewRow dr = dgvDevice.Rows[i];

                    string deviceName = dr.Cells["设备名称"].Value.ToString().Trim();
                    if (deviceName != "")
                    {
                        if (MessageBox.Show("确定要删除设备" + deviceName + "吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    }

                    _DepDeviceModel.DeleteDevice(dr.Cells["设备ID"].Value.ToString());

                    DataTable dt = (DataTable)dgvDevice.DataSource;

                    foreach (DataRow drtmp in dt.Rows)
                    {
                        if (drtmp["设备ID"].ToString() == dr.Cells["设备ID"].Value.ToString())
                        {

                            drtmp.Delete();
                            break;
                        }
                    }
                    dt.AcceptChanges();
                }
            }catch(Exception ex)
            {
                MsgBox.ShowException(ex,"删除设备信息出错，可能原因：该设备已经使用。请查看描述信息：", this);
            }
        }

        private void UpdateDevice()
        {
            //先删除保存所有设备信息，然后保存所有设备信息

            if (VerifyDevice()!=true)
            {
                return;
            }

            DeviceEditState = false;
            try
            {
                DataGridViewRow dvr = dgvDept.SelectedRows[0];
                DepDeviceData devInfo = new DepDeviceData();
                DataTable dt = new DataTable();

                dt = (DataTable)dgvDevice.DataSource;
                string roomID = dvr.Cells["房间ID"].Value.ToString();

                if (dt.Rows.Count == 0)
                {
                    return;
                }

                for (int i = 0; i < dgvDevice.Rows.Count ; i++)
                {
                    DataGridViewRow dr = dgvDevice.Rows[i];
                  
                    if (dr.Cells["设备ID"].Value.ToString() == "")
                        continue;

                    devInfo.房间ID = roomID;
                    devInfo.影像类别 = dr.Cells["影像类别"].Value.ToString();
                    devInfo.设备ID = dr.Cells["设备ID"].Value.ToString();
                    devInfo.设备信息.是否启用 = (dr.Cells["是否启用"].Value.ToString()=="True");
                    devInfo.设备信息.设备说明 = dr.Cells["设备说明"].Value.ToString();
                    devInfo.设备信息.负责人 = dr.Cells["负责人"].Value.ToString();
                    devInfo.设备信息.创建日期 = DateTime.Now.ToString();
                    devInfo.设备名称 = dr.Cells["设备名称"].Value.ToString();

                    devInfo.设备信息.CopyBasePro(devInfo);

                    DataRowState drs= RowState(dr.Cells["设备ID"].Value.ToString());

                     if (drs == DataRowState.Added)
                    {
                        _DepDeviceModel.AddDevice(devInfo);
                    }
                    else if (drs == DataRowState.Modified )
                    {
                        _DepDeviceModel.UpdateDevice(devInfo);
                    }

                }
                DataTable dttmp = (DataTable)dgvDevice.DataSource;
                dttmp.AcceptChanges();


            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 根据设备ID 判断数据是否是新增
        /// </summary>
        /// <param name="strID"></param>
        /// <returns>0 异常  1 新增  2 修改</returns>
        private DataRowState RowState(string strID)
        {
            DataTable dt = new DataTable();

            dt = (DataTable)dgvDevice.DataSource;

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["设备ID"].ToString()== strID)
                {

                    return dr.RowState;
                }
            }

            return DataRowState.Deleted;
        }

        /// <summary>
        /// 房间列表界面设置
        /// </summary>
        private void SetDgvRoomFace()
        {
            try
            {
                dgvDept.Columns["房间ID"].Visible = false;
                dgvDept.Columns["科室ID"].Visible = false;
                dgvDept.Columns[dgvDept.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }
        /// <summary>
        /// 设备操作按钮是否可以操作
        /// </summary>
        /// <returns></returns>
        private bool isDevClickButton()
        {
            if (dgvDept.SelectedRows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 设备列表界面设置
        /// </summary>
        private void SetDgvDeviceFace()
        {
            try
            {
                dgvDevice.Columns["设备ID"].Visible = false;
                dgvDevice.Columns["设备信息"].Visible = false;
                dgvDevice.Columns[dgvDevice.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cboDept_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (DeviceEditState)
                {
                    if (MessageBox.Show("当前编辑了设备信息还未保存，切换科室前是否先保存", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        UpdateDevice();
                }
                DeviceEditState = false;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }

        private void dgvDevice_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DeviceEditState = true;
        }

        private void dgvDevice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDevice.BeginEdit(true);
        }

        private void dgvDevice_CurrentCellChanged(object sender, EventArgs e)
        {
            SetCboboxRect();
        }

        private void dgvDevice_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            dgvDevice.Rows[e.RowIndex].Cells["影像类别"].Style.SelectionBackColor = Color.White;

        }
        //点击下拉框时判断，是否存在未保存的设备信息，存在，提示先保存。
        private void cboDept_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeviceEditState)
                {
                    if (MessageBox.Show("当前编辑了设备信息还未保存，切换科室前是否先保存", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        UpdateDevice();
                }
                DeviceEditState = false;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, "保存设备信息出现错误，请参考描述信息检查",this);
            }
        }

        private void dgvDevice_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SetCboboxRect();
        }

        private void dgvDevice_ColumnHeadersHeightChanged(object sender, EventArgs e)
        {
            SetCboboxRect();
        }

        private void SetCboboxRect()
        {
            try
            {
                if (this.dgvDevice.CurrentCell.ColumnIndex == 2)//&& this.dgvDevice.CurrentCell.RowIndex < dgvDevice.Rows.Count
                {
                    Rectangle rect = dgvDevice.GetCellDisplayRectangle(dgvDevice.CurrentCell.ColumnIndex, dgvDevice.CurrentCell.RowIndex, false);
                    string Value = dgvDevice.CurrentCell.Value.ToString();
                    this.cbo.Text = Value;
                    this.cbo.Left = rect.Left;
                    this.cbo.Top = rect.Top;
                    this.cbo.Width = rect.Width;
                    this.cbo.Height = rect.Height;
                    this.cbo.Visible = true;
                }
                else
                {
                    this.cbo.Visible = false;
                }
            }
            catch (Exception ex)
            {
                return;
            }
            cbo.Refresh();
        }

    }
}
