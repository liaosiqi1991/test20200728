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

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmMainConfig : Form
    {
        private string _serverName = "";

        private IDBProvider _dbHelper = null;
        private ILoginUser _loginUser = null;
        
        private ISetting _setting = null;

        public string ServerName
        {
            get { return _serverName; }
        }
        public frmMainConfig(string serverName, IDBProvider dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            _serverName = serverName;
            _dbHelper = dbHelper;
            _loginUser = loginUser;
        }

        /// <summary>
        /// 嵌入配置窗口
        /// </summary>
        /// <param name="cfg"></param>
        private void EmbedCfgWindow(Form cfg)
        {
            _setting = cfg as ISetting;

            if (_setting == null)
            {
                throw new Exception("该配置未实现ISetting接口。");
            }

            cfg.TopLevel = false;
            cfg.TopMost = false;
            cfg.FormBorderStyle = FormBorderStyle.None;
            cfg.Parent = panel1;
            cfg.Dock = DockStyle.Fill;
            cfg.Show();

            this.Text = "系统设置 - " + cfg.Text;

            cfg.BringToFront();
        }

        /// <summary>
        /// 创建配置界面实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private object  CreateCfgWindow<T>()where T:Form, ISetting, new()
        {
            string name = typeof(T).Name;

            Control[] ctls = panel1.Controls.Find(name, false);
            if (ctls.Length > 0)
            {
                return ctls[0];
            }

            T instance = new T();

            instance.Name = name;            

            instance.Init(_dbHelper, _loginUser); 

            return instance;

        }

        private void tsbHisServer_Click(object sender, EventArgs e)
        {
            ShowConfig<frmHisServerManager>(sender, e);
        }



        private void tsbDepartmentMatch_Click(object sender, EventArgs e)
        {
            ShowConfig<frmDepartmentMatch>(sender, e);
        }

        private void tsbRoleConfig_Click(object sender, EventArgs e)
        {
            ShowConfig<frmRoleManager>(sender, e);
        }

        private void tsbUserConfig_Click(object sender, EventArgs e)
        {
            ShowConfig<frmUserManager>(sender, e);
        }

        private void tsbBodypartSet_Click(object sender, EventArgs e)
        {
            ShowConfig<frmBoypartManager>(sender, e);
        }

        private void tsbExamItemSet_Click(object sender, EventArgs e)
        {
            ShowConfig<frmExamManager>(sender, e);
        }

        private void tsbNoRule_Click(object sender, EventArgs e)
        {
            ShowConfig<frmNoRule>(sender, e);
        }

        private void tsbStationInfo_Click(object sender, EventArgs e)
        {
            ShowConfig<frmStationInfo>(sender, e);
        }

        private void SetButState(object sender)
        {
            foreach(ToolStripItem tsi in toolStrip1.Items)
            {
                tsi.BackColor = SystemColors.Control;
            }

            foreach (ToolStripItem tsi in toolStrip2.Items)
            {
                tsi.BackColor = SystemColors.Control;
            }

            foreach (ToolStripItem tsi in toolStrip3.Items)
            {
                tsi.BackColor = SystemColors.Control;
            }

            foreach (ToolStripItem tsi in toolStrip4.Items)
            {
                tsi.BackColor = SystemColors.Control;
            }

            (sender as ToolStripButton).BackColor = Color.FromArgb(185, 222, 255);
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_setting == null) return;

                _setting.RefreshSetting();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbDictionary_Click(object sender, EventArgs e)
        {
            ShowConfig<frmDictionaryManager>(sender, e);
        }

        private void tsbSysPwd_Click(object sender, EventArgs e)
        {

            ShowConfig<frmAdminUserSetting>(sender, e); 
        }

        private void tsbWindowManager_Click(object sender, EventArgs e)
        {
            ShowConfig<frmRoleWindowCfg>(sender, e);
        }

        private void tsbRoom_Click(object sender, EventArgs e)
        {
            ShowConfig<frmDepRoomAndDeviceCfg>(sender, e); 
        }

        private void tsbStorageSetting_Click(object sender, EventArgs e)
        {
            ShowConfig<frmStorageManager>(sender, e); 
        }

        private void frmMainConfig_Load(object sender, EventArgs e)
        {
            try
            {
                tsbDbServerName.Text = "服务器:" + _serverName;
                tsbHisServer_Click(tsbHisServer, e);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbReportWords_Click(object sender, EventArgs e)
        {
            ShowConfig<frmReportWords>(sender, e);
        }

        private void ShowConfig<T>(object sender, EventArgs e) where T : Form, ISetting, new()
        {
            try
            {
                object cfg = CreateCfgWindow<T>();

                EmbedCfgWindow(cfg as Form);

                SetButState(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbReportTempleate_Click(object sender, EventArgs e)
        {
            ShowConfig<frmReportTemplate>(sender, e);
        }

        private void tsbImageKind_Click(object sender, EventArgs e)
        {
            ShowConfig<frmDeviceKindCfg>(sender, e);
        }

        private void tsbDBSourceConfig_Click(object sender, EventArgs e)
        {
            ShowConfig<frmThridDBConfig>(sender, e);
        }

        private void tsbQueueManager_Click(object sender, EventArgs e)
        {
            ShowConfig<frmQueueManager>(sender, e);
        }
    }
}
