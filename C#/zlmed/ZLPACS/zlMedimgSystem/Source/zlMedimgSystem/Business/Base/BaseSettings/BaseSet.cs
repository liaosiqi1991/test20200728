using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.BaseSettings;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.BaseSettings
{

    public interface ISetting
    {
        void Init(IDBQuery dbHelper, ILoginUser loginUser);

        void RefreshSetting();
    }
    public class BaseSet
    {
        private IDBProvider _dbHelper = null;
        private ILoginUser _loginUser = null;
        private string _serverName = "";
        public BaseSet(string serverName, IDBProvider dbHelper, ILoginUser loginUser)
        {
            _serverName = serverName;
            _dbHelper = dbHelper;
            _loginUser = loginUser;
        }

        public void ShowConfigCenter(IWin32Window owner)
        {
            frmMainConfig fmc = new frmMainConfig(_serverName, _dbHelper, _loginUser);
            fmc.ShowDialog(owner);
        }

        /// <summary>
        /// 显示功能设计
        /// </summary>
        public void ShowFuncDesign(IWin32Window owner)
        {
            //frmFuncDesign ffd = new frmFuncDesign(_dbHelper);
            //ffd.ShowDialog(owner);
        }

        /// <summary>
        /// 显示字典管理
        /// </summary>
        public void ShowDictionaryManager(IWin32Window owner)
        {
            frmDictionaryManager dictManager = new frmDictionaryManager(_dbHelper, _loginUser);
            dictManager.ShowDialog(owner);
        }

        public void ShowHisServer(IWin32Window owner)
        {
            frmHisServerManager hsm = new frmHisServerManager(_dbHelper, _loginUser);
            hsm.ShowDialog(owner);
        }

        public void ShowDepartmentMatch(IWin32Window owner )
        {
            frmDepartmentMatch fdm = new frmDepartmentMatch(_dbHelper, _loginUser);
            fdm.ShowDialog(owner);
        }
    }
}
