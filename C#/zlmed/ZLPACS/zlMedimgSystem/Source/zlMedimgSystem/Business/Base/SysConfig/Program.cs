using System;
using System.Configuration;
using System.Reflection;
using System.Windows.Forms;
using zlMedimgSystem.BaseSettings;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using System.Linq;

namespace zlMedimgSystem.SysConfig
{
    static class Program
    {
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
     


            string loginLibaryFile = System.Windows.Forms.Application.StartupPath + @"\zlMedimgSystem.Login.dll";
            if (System.IO.File.Exists(loginLibaryFile) == false)
            {
                MessageBox.Show("未检测到登录部件，系统不能运行。");
            }

            ILogin login = (ILogin)Assembly.LoadFile(loginLibaryFile).CreateInstance("zlMedimgSystem.Login.Login");//new UsLogin(); //


            IVerify defaultVerify = new zlMedimgSystem.DataModel.VerifyDefault(true);

            login.SetLoginTitle("系统配置-管理员登录");
            if (login.ShowLogin("", defaultVerify, false) == false) return;

            if (login.DBProvider == null) return;

            AppSetting.WriteSetting("loginuser", "");

            ShowConfigCenter(login.ServerName, login.DBProvider, login.LoginUser);

        }

        static private void ShowConfigCenter(string serverName, IDBProvider dbHelper, ILoginUser loginUser)
        {
            BaseSet bs = new BaseSet(serverName, dbHelper, loginUser);

            //显示字典管理
            bs.ShowConfigCenter(null);
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
