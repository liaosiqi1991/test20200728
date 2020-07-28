using DevExpress.XtraSplashScreen;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Layout;
using zlMedimgSystem.Services;



namespace zlMedimgSystem.Main
{
    static class Program
    {
        static private string _serverName = "";
        static private IDBQuery _dbHelper = null;
        static private ILoginUser _loginUser = null;
        static private IStationInfo _stationInfo = null;

        static public string _appTitle = "";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RegAppExceptionProcess();

            //LoadAppTitle();

            //SplashScreenManager.ShowForm(typeof(frmSplash));
            //SplashScreenManager.Default.SetWaitFormDescription("开始加载程序集文件...");
            
            //LoadAssembaly();
            
            //SplashScreenManager.Default.SetWaitFormDescription("加载登录模块...");

            //登录验证 
            ILogin login = Login();

            if (login == null) return;

            _dbHelper = login.DBProvider;
            _loginUser = login.LoginUser;
            _serverName = login.ServerName;

            _stationInfo.DBServerName = _serverName;

            //StartTestWindow();
            StartWindow();
        }

        static private void StartTestWindow()
        {
            //这里可直接创建需要测试的窗体内容，而不需要关联角色及窗体界面配置...
        }

        static private void StartWindow()
        {
            SplashScreenManager.ShowForm(typeof(frmSplash));
            SplashScreenManager.Default.SetWaitFormDescription("开始加载程序集文件...");

            LoadAssembaly();

            //SplashScreenManager.Default.SetWaitFormDescription("加载登录模块...");

            //SplashScreenManager.ShowForm(typeof(frmSplash));
            SplashScreenManager.Default.SetWaitFormDescription("创建主窗口程序...");

            BizMainLayout AppMain = new BizMainLayout(false);

            AppMain.OnStateSync += StateSync;
            AppMain.OnReadWindowLayout += ReadLayout;

            SplashScreenManager.Default.SetWaitFormDescription("初始化主窗口程序...");
            AppMain.Init(_dbHelper, _loginUser, _stationInfo, null);

            SplashScreenManager.Default.SetWaitFormDescription("预加载主窗口程序...");
            AppMain.BeforeLoadAssembly();
                   

            Application.Run(AppMain);
        }

        static private void StateSync(string stateMsg, bool isFinal = false)
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

        //static private void LoadAppTitle()
        //{
        //    try
        //    {
        //        Configuration ca = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //        bool hasKey = ca.AppSettings.Settings.AllKeys.Contains("apptitle");

        //        if (hasKey)
        //        {
        //            _appTitle = ca.AppSettings.Settings["apptitle"].Value;
        //        }
        //    }
        //    catch { }
        //}


        static private void ReadLayout(BizMainLayout bizWindow, ref string designKey, out string layoutFmt)
        {
            layoutFmt = "";

            if (_loginUser == null || _dbHelper == null) return;

            RoleWindowModel rwm = new RoleWindowModel(_dbHelper);

            WindowInfoData windowInfo = rwm.GetRoleMainWindowInfo(_loginUser.RoleId);

            if (windowInfo == null)
            {
                MessageBox.Show("窗体配置信息读取失败。", "提示");
                return;
            }

            designKey = windowInfo.窗体ID;
            bizWindow.Name = "Win_" + windowInfo.窗体ID;
            layoutFmt = windowInfo.窗体信息.布局配置;

        }

        static public bool BusinessVerify(IDBProvider dBProvider, ILoginUser userData)
        {

            _stationInfo = StationInfo.GetLocateStationInfo(_serverName, dBProvider);
            if (_stationInfo == null)
            {
                MessageBox.Show("当前站点信息尚未配置，请联系管理员。", "提示");
                return false;
            }
                       
            //判断当前用户是否能够登录当前科室的系统
            UserModel um = new UserModel(dBProvider);
            List<UserReleationData> urds = um.GetUserDepartmentRoleInfos(userData.UserId);

            if (urds == null)
            {
                MessageBox.Show("未找到对应科室信息不能进行登录，请联系管理员。", "提示");
                return false;
            }

            string departmentId = _stationInfo.DepartmentId;

            int index = urds.FindIndex(T => T.科室ID == departmentId);
            if (index < 0)
            {
                MessageBox.Show("当前科室 [" + _stationInfo.DepartmentName + "] 未配置该用户不能进行登录，请联系管理员。", "提示");
                return false;
            }

            UserReleationData urd = urds[index];
            
            if (string.IsNullOrEmpty(urd.角色ID))
            {
                MessageBox.Show("当前用户尚未分配角色不能进行登录，请联系管理员。", "提示");
                return false;
            }

            userData.RoleId = urd.角色ID;
            userData.DepartmentId = urd.科室ID;

            return true;
        }

        /// <summary>
        /// 系统登录
        /// </summary>
        /// <param name="si"></param>
        /// <returns></returns>
        static public ILogin Login()
        {
            try
            {
                string loginLibaryFile = System.Windows.Forms.Application.StartupPath + @"\zlMedimgSystem.Login.dll";
                if (System.IO.File.Exists(loginLibaryFile) == false)
                {
                    MessageBox.Show("未检测到登录部件，系统不能运行。", "提示");
                }

                ILogin login = (ILogin)Assembly.LoadFile(loginLibaryFile).CreateInstance("zlMedimgSystem.Login.Login");

                SplashScreenManager.CloseForm(false, 0, null);

                IVerify defaultVerify = new zlMedimgSystem.DataModel.VerifyDefault();

                login.SetLoginTitle(((string.IsNullOrEmpty(_appTitle)) ? "" : _appTitle + "-") + "用户登录");
                if (login.ShowLogin("", defaultVerify, BusinessVerify) == false) return null;

                if (login.DBProvider == null)
                {
                    return null;
                }

                return login;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
                return null;
            }

        }

        static public void LoadAssembaly()
        {
            DirectoryInfo di = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);

            FileInfo[] fis = di.GetFiles("DevExpress.*", SearchOption.TopDirectoryOnly);

            if (fis.Length <= 0) return;

            foreach (FileInfo fi in fis)
            {
                if (fi.Extension.ToUpper().Equals(".DLL") == false) continue;

                Assembly.LoadFrom(fi.FullName); 
            }

            fis = di.GetFiles("zlMedimgSystem.*", SearchOption.TopDirectoryOnly);

            if (fis.Length <= 0) return;

            foreach (FileInfo fi in fis)
            {
                if (fi.Extension.ToUpper().Equals(".DLL") == false) continue;

                Assembly.LoadFrom(fi.FullName);
            }


            //Assembly.LoadFrom(System.Windows.Forms.Application.StartupPath + @"\ZLSoft.Newtonsoft.Json.dll");
            //Assembly.LoadFrom(System.Windows.Forms.Application.StartupPath + @"\ZLApplet.FormPart.dll");
            //Assembly.LoadFrom(System.Windows.Forms.Application.StartupPath + @"\Oracle.ManagedDataAccess.dll");
            //Assembly.LoadFrom(System.Windows.Forms.Application.StartupPath + @"\zlHisLibrary.dll");
        }


        /// <summary>
        /// 注册应用程序异常处理
        /// </summary>
        public static void RegAppExceptionProcess()
        {
            //注册异常
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MsgBox.ShowException(e.Exception);

        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        { 
            Exception ex = e.ExceptionObject as Exception;
            MsgBox.ShowException(ex);
        }
    }
}
