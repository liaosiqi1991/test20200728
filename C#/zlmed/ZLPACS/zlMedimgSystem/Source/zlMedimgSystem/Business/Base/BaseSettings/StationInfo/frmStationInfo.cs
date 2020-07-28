using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.BusinessBase;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmStationInfo : Form, ISetting
    {
        private IDBQuery _dbHelper = null; 
        private StationConfigModel _scm = null;
        private ParameterModel _pm = null;
        private DictManageModel _dmm = null;
        private ILoginUser _loginUser = null;
        private DepartmentMatchModel _departmentMatchModel = null;//科室模型
        private DepRoomModel _depRoomModel = null; //房间模型
        private DepDeviceModel _depDeviceModel = null;//设备模型
        private StorageModel _storageModel = null;//存储设备模型


        //private bool _isBinding = false;
        private string _computerName = "";

        public frmStationInfo()
            : this(null, null)
        {
        }

        public frmStationInfo(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            Init(dbHelper, loginUser);
        }

        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {
            _dbHelper = dbHelper;
            _loginUser = loginUser;

            _pm = new ParameterModel(dbHelper);
            _scm = new StationConfigModel(_dbHelper);
            _dmm = new DictManageModel(dbHelper);
            _departmentMatchModel = new DepartmentMatchModel(dbHelper);
            _depRoomModel = new DepRoomModel(dbHelper);
            _depDeviceModel = new DepDeviceModel(dbHelper);
            _storageModel = new StorageModel(dbHelper);
        }

        private void frmStationInfo_Resize(object sender, EventArgs e)
        {
            try
            {
                panel1.Left = (this.Width - panel1.Width) / 2;
                panel1.Top = (this.Height - panel1.Height) / 2;

                if (panel1.Left <= 0) panel1.Left = 0;
                if (panel1.Top <= 0) panel1.Top = 0;
            }
            catch
            { }
        }

        public void RefreshSetting()
        {
            _computerName = Dns.GetHostName(); // System.Environment.MachineName;

            txtComputerName.Text = _computerName;

            BindHSP();
            BindDepartment();
            BindStorage();
 
            JStationConfig stationConfig = _scm.GetStationInfo(_computerName);
            if (stationConfig == null) return;

            if (stationConfig.当前院区编码 != null) cbxHspCode.SelectedValue = stationConfig.当前院区编码;
            if (stationConfig.站点所属科室 != null) cbxDepartment.SelectedValue = stationConfig.站点所属科室;
            if (stationConfig.站点所属房间 != null) cbxRoom.SelectedValue = stationConfig.站点所属房间;
            if (stationConfig.当前检查设备 != null) cbxDevice.SelectedValue = stationConfig.当前检查设备;
            if (stationConfig.当前存储设备 != null) cbxStorage.SelectedValue = stationConfig.当前存储设备;
        }

        private void frmStationInfo_Load(object sender, EventArgs e)
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



        /// <summary>
        /// 绑定院区
        /// </summary>
        private void BindHSP()
        {
            //不是有clear（）方法清空下拉框，点刷新会提示：设置 DataSource 属性后无法修改项集合错误。
            cbxHspCode.DataSource = null;

             //获取对应字典内容
             JDictionary hspAreaDict = _dmm.GetDictionary("院区");
            if (hspAreaDict == null)
            {
                return;
            }

            List<ItemBind> listBind = new List<ItemBind>();
            
            foreach(JDictionaryItem dictInfo in hspAreaDict.项目内容)
            {
                ItemBind lb = new ItemBind(dictInfo.项目编码 + "-" + dictInfo.项目名称, dictInfo.项目编码);
                listBind.Add(lb);
            }

            cbxHspCode.DisplayMember = "Name";
            cbxHspCode.ValueMember = "Value";

            cbxHspCode.DataSource = listBind;
        }

        private void BindStorage()
        {
            //DataTable dtStorage = _scm.GetStorageInfo();
            DataTable dtStorage = _storageModel.GetAllStorage();
            //复制表结构
            DataTable dtFilter = dtStorage.Clone();
            cbxStorage.DisplayMember = "存储名称";
            cbxStorage.ValueMember = "存储ID";
            string sFilter = "存储信息 like '%\"是否停用\":false%'";
            DataRow[] dRows = dtStorage.Select(sFilter);
            foreach (DataRow item in dRows)
            {
                dtFilter.ImportRow(item);
            }
            cbxStorage.DataSource = dtFilter;

            if (cbxStorage.Items.Count > 0) cbxStorage.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定设备
        /// </summary>
        /// <param name="roomId"></param>
        private void BindDevice(string roomId)
        {
            //DataTable dtDevice = _scm.GetDeviceInfo(roomId);
            DataTable dtDevice = _depDeviceModel.GetDeviceInfo(roomId);
            DataTable dtFilter = dtDevice.Clone();

            cbxDevice.DisplayMember = "设备名称";
            cbxDevice.ValueMember = "设备ID";
            string sFilter = "设备信息 like '%\"是否启用\":true%'";
            DataRow[]dRows= dtDevice.Select(sFilter);

            foreach (DataRow item in dRows)
            {
                dtFilter.ImportRow(item);
            }
            cbxDevice.DataSource = dtFilter;

            if (cbxDevice.Items.Count > 0) cbxDevice.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定房间
        /// </summary>
        /// <param name="departmentId"></param>
        private void BindRoom(string departmentId)
        {
            //DataTable dtRoom = _scm.GetRoomInfo(departmentId);
            DataTable dtRoom = _depRoomModel.GetDeptInfo(departmentId);

            cbxRoom.DisplayMember = "房间名称";
            cbxRoom.ValueMember = "房间ID";

            cbxRoom.DataSource = dtRoom;

            if (cbxRoom.Items.Count > 0) { cbxRoom.SelectedIndex = 0; }
            else
            {
                //如果房间没有选中，情况设备下拉列表。
                cbxDevice.Items.Clear();
            }
        }

        /// <summary>
        /// 绑定科室
        /// </summary>
        private void BindDepartment()
        {
            //DataTable dtDepartment = _scm.GetDepartment();
            DataTable dtDepartment = _departmentMatchModel.GetAllDepartment();
            cbxDepartment.DisplayMember = "科室名称";
            cbxDepartment.ValueMember = "科室ID";

            cbxDepartment.DataSource = dtDepartment;

            if (cbxDepartment.Items.Count > 0) cbxDepartment.SelectedIndex = 0;

        }

        private void cbxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxDepartment.SelectedValue == null) return;

                BindRoom(cbxDepartment.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxRoom.SelectedValue == null) return;

                BindDevice(cbxRoom.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butApply_Click(object sender, EventArgs e)
        {
            try
            {
                JStationConfig stationConfig = new JStationConfig();

                if (cbxHspCode.SelectedValue != null) stationConfig.当前院区编码 = cbxHspCode.SelectedValue.ToString();
                if (cbxDepartment.SelectedValue != null) stationConfig.站点所属科室 = cbxDepartment.SelectedValue.ToString();
                if (cbxRoom.SelectedValue != null) stationConfig.站点所属房间 = cbxRoom.SelectedValue.ToString();
                if (cbxDevice.SelectedValue != null) stationConfig.当前检查设备 = cbxDevice.SelectedValue.ToString();
                if (cbxStorage.SelectedValue != null) stationConfig.当前存储设备 = cbxStorage.SelectedValue.ToString();

                _scm.SetStationInfo(stationConfig, _computerName);

                ButtonHint.Start(butApply, "OK");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}
