using System;
using System.Collections.Generic; 
using zlMedimgSystem.Interface; 

namespace zlMedimgSystem.Login
{
    public class Login: ILogin  
    {
        private IDBProvider _dbHelper = null ;
        private ILoginUser _loginUser = null;
        private string _serverName = "";

        private string _title = "";

        public Login()
        { 
        }

        public IDBProvider DBProvider 
        {
            get { return _dbHelper; }
        }

        public ILoginUser LoginUser
        {
            get { return _loginUser; }
        }

        public string ServerName
        {
            get { return _serverName; }
        }

        public void SetLoginTitle(string title)
        {
            _title = title;
        }

        public bool ShowLogin(string command, IVerify defaultVerify)
        {
            return ShowLogin(command, defaultVerify, true, null);
        }

        public bool ShowLogin(string command, IVerify defaultVerify, DelegateBusinessVerify businessVerify)
        {
            return ShowLogin(command, defaultVerify, true, businessVerify);
        }

        public bool ShowLogin(string command, IVerify defaultVerify, bool allowThirdVerify)
        {
            return ShowLogin(command, defaultVerify, allowThirdVerify, null);
        }

        public bool ShowLogin(string command, IVerify defaultVerify,  bool allowThirdVerify, DelegateBusinessVerify businessVerify)
        {
            frmLogin loginWindow = new frmLogin(defaultVerify, allowThirdVerify, businessVerify);
            //login.TopMost = true;

            if (string.IsNullOrEmpty(_title) == false) loginWindow.Text = _title;

            loginWindow.ShowDialog();

            if (loginWindow.DBProvider == null)
            {
                return false;
            } 

            _dbHelper = loginWindow.DBProvider;
            _loginUser = loginWindow.LoginUser;
            _serverName = loginWindow.ServerName;
 

            return true ;
        }
    }
}
