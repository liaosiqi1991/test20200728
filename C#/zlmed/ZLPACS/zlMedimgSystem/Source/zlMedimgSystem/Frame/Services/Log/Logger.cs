using System;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Configuration;

namespace zlMedimgSystem.Services
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// 保留 - 使默认值0有一个明确的意义
        /// </summary>
        ltReserve = 0,

        /// <summary>
        /// 错误日志
        /// </summary>
        ltError = 1,

        /// <summary>
        /// 警告日志
        /// </summary>
        ltWaring = 2,

        /// <summary>
        /// 常规
        /// </summary>
        ltNormal = 4,

        /// <summary>
        /// 调试日志
        /// </summary>
        ltDebug = 8,

        /// <summary>
        /// 所有类型
        /// </summary>
        All = ltError | ltWaring | ltNormal | ltDebug
    }

    public class Logger : DisposeImp, ILog, IProperty, IShowManager
    {
        private const string LOG_DIR = "Log";
        private const int LOG_DAYS = 30;
        private const string LOG_TAG = "[LOG]";

        private string _logSys;

        private string _logFile;
        private string _logDir;

        //避免事件的记录时间相同时，事件调用顺序显示不一致，因此需要增加事件序号
        private string _logTime="";
        private int _logTimeCount=0;

        private object _lockFileRes;
        private int _hideLogType;
        private bool _isAutoTrace;
        private bool _isOutputConsole;
        private bool _isWriteThreadId;

        private string _InstanceId = "";

        #region 构造方法

        public Logger()     
            :this("SYS")
        {
        }

        public Logger(string sysName)
        {
            _logSys = sysName;

            //配置默认目录和文件
            ConfigDefaultLogFile(ref _logDir,ref _logFile);

            InitLogger();

            WriteStartLog();
        }

        public Logger(string sysName, string file)
        {
            _logSys = sysName;

            _logDir = "";
            _logFile = file;

            InitLogger();

            WriteStartLog();
        }

        private void ConfigDefaultLogProperty()
        {
            //从注册表中获取需要隐藏的日志类型
            int hideType = 0;

            //System.AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"App.config"); 

            //string cfgPath = string.Format("{0}\\{1}", AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory, "App.config");
            //Configuration appConfig = ConfigurationManager.OpenExeConfiguration(cfgPath.Replace("\\\\", "\\"));

            Configuration cfa = null;

            //配置项内容需要在exe的app.config中进行配置
            //正常日志
            string logNormal = ConfigurationManager.AppSettings["记录常规日志"];
            if (string.IsNullOrEmpty(logNormal))
            {                
                if (logNormal == null)
                {
                    //默认隐藏
                    hideType = hideType + (int)LogType.ltNormal;

                    if (cfa == null) cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    cfa.AppSettings.Settings.Add("记录常规日志", "0");
                }
            }
            else
            {
                if (logNormal != "1") hideType = hideType + (int)LogType.ltNormal;
            }

            //调试日志
            string logDebug = ConfigurationManager.AppSettings["记录调试日志"];
            if (string.IsNullOrEmpty(logDebug) )
            {
                if (logDebug == null)
                {
                    //默认隐藏
                    hideType = hideType + (int)LogType.ltDebug;

                    if (cfa == null) cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    cfa.AppSettings.Settings.Add("记录调试日志", "0");
                }
            }
            else
            {
                if (logDebug.Trim() != "1") hideType = hideType + (int)LogType.ltDebug;
            }

            //警告日志
            string logWaring = ConfigurationManager.AppSettings["记录警告日志"];
            if (string.IsNullOrEmpty(logWaring))
            {
                if (logWaring == null)
                {
                    if (cfa == null) cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    cfa.AppSettings.Settings.Add("记录警告日志", "1");
                }
            }
            else
            {
                if (logWaring.Trim() != "1") hideType = hideType + (int)LogType.ltWaring;
            }

            _hideLogType = hideType;

            //启用日志跟踪
            string logAutoTrace = ConfigurationManager.AppSettings["日志跟踪"];
            if (string.IsNullOrEmpty(logAutoTrace))
            {
                if (logAutoTrace == null)
                {
                    //默认不跟踪
                    _isAutoTrace = false;

                    if (cfa == null) cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    cfa.AppSettings.Settings.Add("日志跟踪", "0");
                }
            }
            else
            {
                if (logAutoTrace == "1") _isAutoTrace = true;
            }

            if (cfa != null)
            {
                cfa.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitLogger()
        {
            _isAutoTrace = false;
            _isOutputConsole = false;
            _isWriteThreadId = false;

            ConfigDefaultLogProperty();
            //if (!Debugger.IsAttached)
            //{
            //    _hideLogType = GetHideLogType();
            //}
            //else
            //{
            //    _hideLogType = 0;
            //}

            _lockFileRes = new object();
            _InstanceId = Guid.NewGuid().ToString();
        }


        /// <summary>
        /// 写入启动日志
        /// </summary>
        private void WriteStartLog()
        {
            try
            {
                WriteSplit();
                WriteLog(LOG_TAG, LogType.ltNormal, "日志服务启动。", " ");
            }
            catch(Exception ex)
            {
                LogException(ex);
            }
        }

        private void WriteEndLog()
        {
            try
            {
                WriteLog("[LOG]", LogType.ltNormal, "日志服务停止。", " ");
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        /// <summary>
        /// 写入日志分隔
        /// </summary>
        public void WriteSplit()
        {
            try
            {
                //如果文件不存在，则退出
                if (!File.Exists(_logFile)) return;

                using (DataTable logData = GetLogBuf())
                {
                    DataRow dr = logData.NewRow();

                    string splitChar = "------";
                    dr["类型"] = splitChar;
                    dr["系统"] = splitChar;
                    dr["模块"] = splitChar;
                    dr["线程"] = splitChar;
                    dr["日期"] = splitChar;
                    dr["时间"] = splitChar;
                    dr["描述"] = splitChar;
                    dr["来源"] = splitChar;

                    logData.Rows.Add(dr);
                    
                    lock (_lockFileRes)
                    {
                        //使用追加方式写入文件
                        using (FileStream fs = new FileStream(_logFile, FileMode.Append))
                        {
                            logData.WriteXml(fs, XmlWriteMode.IgnoreSchema);
                            fs.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        /// <summary>
        /// 取得默认日志文件名称
        /// </summary>
        /// <returns></returns>
        private void ConfigDefaultLogFile(ref string dir, ref string file)
        {
            //dir = System.Windows.Forms.Application.StartupPath;
            dir = System.Windows.Forms.Application.StartupPath;

            dir = dir + "\\" + LOG_DIR;

            if (System.IO.Directory.Exists(dir) != true)
            {
                //创建日志目录
                System.IO.Directory.CreateDirectory(dir);
            }

            Random rdm = new Random();
            //文件名称规则“系统+LOG(日期+"_"+随机数).XML"+ "_" + rdm.Next(1000, 9999)
            file = (string.IsNullOrEmpty(_logSys) ? "" : _logSys + "_");
            file = dir + "\\" + file + "LOG(" + DateTime.Now.ToString("yyyyMMdd") + ").txt";
        }

        #endregion

        #region 析构方法

        public override void Dispose()
        {
            if (this.Disposed == false) WriteEndLog();

            base.Dispose();
        }
       
        /// <summary>
        /// 释放托管资源
        /// </summary>
        protected override void DisposeHostedRes()
        {
            //释放托管资源
        }

        /// <summary>
        /// 释放非托管资源
        /// </summary>
        protected override void DisposeNotHostedRes()
        {
            //释放非托管资源
        }


        #endregion

        /// <summary>
        /// 日志异常处理
        /// </summary>
        /// <param name="ex"></param>
        private void LogException(Exception ex)
        {
            try
            {
                string errInf = "系统:" + _logSys + ErrToStr(ex);

                OutputDebugStr(errInf);
                Console.WriteLine(errInf);
            }
            catch
            { }
        }

        #region 属性定义

        /// <summary>
        /// 需要隐藏的日志
        /// </summary>
        public int  HideLog
        {
            get
            {
                return _hideLogType;
            }
            set
            {
                _hideLogType = value;
            }
        }

        /// <summary>
        /// 是否允许被其他监视工具自动跟踪日志
        /// </summary>
        public bool IsAutoTrace
        {
            get
            {
                return _isAutoTrace;
            }
            set
            {
                _isAutoTrace = value;
            }
        }

        /// <summary>
        /// 是否输出到控制台
        /// </summary>
        public bool IsOutputConsole
        {
            get
            {
                return _isOutputConsole;
            }
            set
            {
                _isOutputConsole = value;
            }
        }

        /// <summary>
        /// 是否写入线程ID
        /// </summary>
        public bool IsWriteThreadId
        {
            get
            {
                return _isWriteThreadId;
            }
            set
            {
                _isWriteThreadId = value;
            }
        }

        #endregion

        /// <summary>
        /// 获取实例ID
        /// </summary>
        /// <returns></returns>
        public string InstanceId()
        {
            return _InstanceId;
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="proName"></param>
        /// <param name="proValue"></param>
        public void SetProperty(string proName, object proValue)
        {
            if (proValue == null) return;

            switch( proName.ToUpper())
            {
                case "HIDELOG":
                    HideLog = Convert.ToInt16(proValue);
                    break;
                case "ISAUTOTRACE":
                    IsAutoTrace = Convert.ToBoolean(proValue);
                    break;
                case "ISOUTPUTCONSOLE":
                    IsOutputConsole = Convert.ToBoolean(proValue);
                    break;
                case "ISWRITETHREADID":
                    IsWriteThreadId = Convert.ToBoolean(proValue);
                    break;
                default:
                    throw new UserException("尚未实现[" + proName + "]属性配置.");
            }            
        }

        /// <summary>
        /// 获取属性
        /// </summary>
        /// <param name="proName"></param>
        /// <returns></returns>
        public object GetProperty(string proName)
        {
            switch (proName.ToUpper())
            {
                case "HIDELOG":
                    return HideLog;
                case "ISAUTOTRACE":
                    return IsAutoTrace;                    
                case "ISOUTPUTCONSOLE":
                    return IsOutputConsole;
                case "ISWRITETHREADID":
                    return IsWriteThreadId;
                default:
                    throw new UserException("尚未实现[" + proName + "]属性配置.");
            }       
        }

        /// <summary>
        /// 清理日志文件
        /// 默认清除一个星期以前的日志文件
        /// </summary>
        public void CleanLogResource()
        {
            CleanLogResource(LOG_DAYS);
        }

        /// <summary>
        /// 清理日志文件
        /// 清除指定天数前的日志文件
        /// </summary>
        /// <param name="days"></param>
        public void CleanLogResource(int days)
        {
            if (string.IsNullOrEmpty(_logDir) == true)
            {
                return;
            }

            //判断日志目录是否存在
            if (Directory.Exists(_logDir) != true)
            {
                return;
            }

            string[] strFiles = Directory.GetFiles(_logDir);
            DateTime dtLastTime = DateTime.Now;

            foreach (string file in strFiles)
            {
                //判断文件是否属于系统的日志文件
                if (file.IndexOf(_logSys + "_LOG") >= 0)
                {
                    //判断日志文件日期是否大于指定的天数
                    dtLastTime = File.GetLastWriteTime(file);

                    TimeSpan ts = DateTime.Today - dtLastTime.Date;
                    if (ts.Days >= days)
                    {
                        //删除日志文件
                        File.Delete(file);
                    }
                }
            }
        }

        /// <summary>
        /// 清理日志文件
        /// 清除指定的文件
        /// </summary>
        /// <param name="file"></param>
        public void CleanLogResource(string file)
        {
            CleanLogResource(file, 0);
        }

        /// <summary>
        /// 清除日志中指定天数之前的记录
        /// </summary>
        /// <param name="file"></param>
        /// <param name="days"></param>
        public void CleanLogResource(string file, int days)
        {
            if (File.Exists(file) != true)
            {
                return;
            }

            //如果为0，则删除日志文件
            if (days == 0)
            {
                File.Delete(file);
                return;
            }

            using (DataTable curLog = ReadLogFileToDataTable(file))
            {
                if (curLog.Rows.Count <= 0)
                {
                    return;
                }

                for (int i = curLog.Rows.Count - 1; i >= 0; i = i - 1)
                {
                    if (Convert.ToDateTime(curLog.Rows[i]["日期"]) <= DateTime.Now.Date.AddDays(-days))
                    {
                        curLog.Rows.RemoveAt(i);
                    }
                }

                using (FileStream fs = new FileStream(file, FileMode.Create))
                {
                    curLog.WriteXml(fs, XmlWriteMode.IgnoreSchema);
                    fs.Close();
                }

                curLog.Clear();
            }

            //GC.Collect();
        }

        /// <summary>
        /// 初始化日志存储结构
        /// </summary>
        /// <param name="curLogData"></param>
        public static DataTable  GetLogBuf()
        {
            DataTable dtLog = new DataTable("LogTab");

            dtLog.Columns.Add("类型", typeof(System.String));
            dtLog.Columns.Add("系统", typeof(System.String));
            dtLog.Columns.Add("模块", typeof(System.String));
            dtLog.Columns.Add("线程", typeof(System.String));
            dtLog.Columns.Add("日期", typeof(System.String));
            dtLog.Columns.Add("时间", typeof(System.String));
            dtLog.Columns.Add("描述", typeof(System.String));
            dtLog.Columns.Add("来源", typeof(System.String));

            return dtLog;
        }

        /// <summary>
        /// 将错误内容转换为字符串
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private string ErrToStr(Exception ex)
        {
            return System.Environment.NewLine + 
                        "错误描述：" + ex.Message + System.Environment.NewLine +
                        "错误来源：" + ex.Source + System.Environment.NewLine +
                        "错误堆栈：" + ex.StackTrace;
        }

        public void WriteTrace(string traceMsg)
        {
#if MyDebug
            try
            {
                Trace.TraceInformation(traceMsg);
            }
            catch { }
#else

            if (_isAutoTrace == true)
            {
                OutputDebugStr(traceMsg);
            }
#endif
        }


        #region 日志写入

        public void WriteLog(string log)
        {
            WriteLog("", LogType.ltNormal, log, GetSource(2));
        }

        public void WriteLog(string module, string log)
        {
            WriteLog(module, LogType.ltNormal, log, GetSource(2));
        }

        public void WriteLog(LogType logType, string log)
        {
            WriteLog("", logType, log, GetSource(2));
        }

        public void WriteLog(LogType logType, string log, string source)
        {
            WriteLog("", logType, log, source);
        }

        public void WriteLog(string module, LogType logType, string log)
        {
            WriteLog(module, logType, log, GetSource(2));
        }

        public void WriteLog(string module, string log, string source)
        {
            WriteLog(module, LogType.ltNormal, log, source);
        }

        public void WriteLog(string module, LogType logType, string log, string source)
        {
            try
            {
                //如果是不需要记录的日志类型，则直接退出
                if ((_hideLogType & Convert.ToInt32(logType)) == Convert.ToInt32(LogType.ltError)
                    || (_hideLogType & Convert.ToInt32(logType)) == Convert.ToInt32(LogType.ltWaring)
                    || (_hideLogType & Convert.ToInt32(logType)) == Convert.ToInt32(LogType.ltNormal)
                    || (_hideLogType & Convert.ToInt32(logType)) == Convert.ToInt32(LogType.ltDebug))
                {
                    return;
                }

                string curLogSource = (source=="")?GetSource(2):source;
                string curDate = DateTime.Now.ToString("yy-MM-dd");                
                string logTypeAlias = GetLogTypeAlias(logType);
                string curModule = (module == "") ? SysConst.DEFAULT_LOG_MODULE : module;

                string curTime = DateTime.Now.ToString("HH:mm:ss.") + DateTime.Now.Millisecond.ToString();
                if (curTime == _logTime)
                {
                    _logTimeCount = _logTimeCount + 1;
                }
                else
                {
                    _logTimeCount = 0;
                    _logTime = curTime;
                }
                //增加相同时间下的时间序号
                curTime = curTime + "." + _logTimeCount.ToString();

                string threadId = "";                
                if (_isWriteThreadId)
                {
                    threadId = System.Threading.Thread.CurrentThread.ManagedThreadId.ToString();
                }

                using (DataTable logData = GetLogBuf()) 
                {
                    #region 写入日志信息到临时表

                    DataRow dr = logData.NewRow();
 
                    dr["类型"] = logTypeAlias;                    
                    dr["系统"] = _logSys;
                    dr["模块"] = curModule;
                    dr["线程"] = (LOG_TAG==module)?LOG_TAG: threadId;
                    dr["日期"] = curDate;
                    dr["时间"] = curTime;
                    dr["描述"] = log;
                    dr["来源"] = curLogSource;

                    logData.Rows.Add(dr);

                    #endregion 

                    lock (_lockFileRes)
                    {
                        //使用追加方式写入文件
                        using (FileStream fs = new FileStream(_logFile, FileMode.Append))
                        {
                            logData.WriteXml(fs, XmlWriteMode.IgnoreSchema);
                            fs.Close();
                        }
                    }

                    if (_isAutoTrace || _isOutputConsole)
                    {
                        StringBuilder sbLog = new StringBuilder();
                        try
                        {
                            sbLog.Append("系统");
                            sbLog.Append(_logSys);
                            sbLog.Append("【模块:");
                            sbLog.Append(curModule);
                            sbLog.Append("  线程:");
                            sbLog.Append(threadId);
                            sbLog.Append("  日期:");
                            sbLog.Append(curDate);
                            sbLog.Append("  时间:");
                            sbLog.Append(curTime);
                            sbLog.Append("  类型:");
                            sbLog.Append(logTypeAlias);
                            sbLog.Append("】\r\n");
                            sbLog.Append("  描述:");
                            sbLog.Append(log);
                            sbLog.Append("\r\n");
                            sbLog.Append("  来源:");
                            sbLog.Append(curLogSource);

                            if (_isAutoTrace)
                            {
                                //发送trace信息
                                OutputDebugStr(sbLog.ToString());//trace
                            }

                            if (_isOutputConsole)
                            {
                                Console.WriteLine(sbLog.ToString());//trace
                            }
                        }
                        finally
                        {
                            sbLog.Length = 0;
                        }
                    }
                }//using end
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        public void WriteError(Exception ex)
        {
            WriteError(ex, "", "", GetSource(2));
        }

        public void WriteError(Exception ex, string module)
        {
            WriteError( ex, module, "", GetSource(2));
        }

        public void WriteError(Exception ex, string module, string hint)
        {
            WriteError(ex, module, hint, GetSource(2));
        }


        public void WriteError(Exception ex, string module, string hint, string source)
        {

            WriteLog(module,
                            LogType.ltError,
                            hint + (string.IsNullOrEmpty(hint) ? "" : "\r\n") + ex.Message,
                            "调用方法：\r\n" + source + System.Environment.NewLine +
                            "触发模块：\r\n" + ex.Source + " 【 " + ((ex.TargetSite==null)?"---":"") + ex.TargetSite + " 】" + System.Environment.NewLine + 
                            "堆栈情况：\r\n" + UserException.GetExceptionStackTrace(ex));
        }

        private string GetLogTypeAlias(LogType logType)
        {
            switch (logType)
            {
                case LogType.ltError:
                    return "错误";
                case LogType.ltWaring:
                    return "警告";
                case LogType.ltNormal:
                    return "常规";
                case LogType.ltReserve:
                    return "预留";
                case LogType.ltDebug:
                    return "调试";
                default:
                    return "自定义";
            }
        }

        #endregion

        /// <summary>
        /// 转换为完整的XML格式
        /// </summary>
        /// <param name="logFile"></param>
        /// <param name="xmlFile"></param>
        public void ConvertXmlSchemaFormat(string xmlFile)
        {
            using (DataTable dt = ReadLogFileToDataTable(_logFile))
            {
                dt.WriteXml(xmlFile, XmlWriteMode.WriteSchema);
                dt.Clear();
            }
        }

        /// <summary>
        /// 显示日志窗口
        /// </summary>
        public bool ShowManager()
        {
            return ShowManager(null);
        }

        /// <summary>
        /// 显示日志查看窗口
        /// </summary>
        /// <param name="owner"></param>
        public bool ShowManager(IWin32Window owner)
        {
            bool result = false;

            using (LogView lvLog = new LogView())
            {
                if (owner == null)
                {
                    lvLog.ShowLogWindow(_logFile, null);
                }
                else
                {
                    lvLog.ShowLogWindow(_logFile, owner);
                }
            }

            result = true;

            return result;
        }

        #region 静态方法

        /// <summary>
        /// 输出错误信息
        /// </summary>
        /// <param name="ex"></param>
        public static void OutputError(Exception ex)
        {
            string debugStr = "错误消息：" + ex.Message + "\r\n"
                                     + "错误源：" + ex.Source + "\r\n"                                                                        
                                     + "错误触发点：" + ex.TargetSite + "\r\n"                                                                        
                                     + "错误堆栈：" + ex.StackTrace;

            OutputDebugStr(debugStr);
        }

        /// <summary>
        /// 输出Debug调试信息
        /// </summary>
        /// <param name="debugStr">调试字符串</param>
        public static void OutputDebugStr(string debugStr)
        {
            try
            {
                if (!string.IsNullOrEmpty(debugStr))
                {
                    System.Diagnostics.Trace.WriteLine(debugStr);
                }
            }
            catch { }
        }

        /// <summary>
        /// 读取日志文件到临时表
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static DataTable ReadLogFileToDataTable(string file)
        {
            DataTable dtReturn = GetLogBuf();
            string logBuf = "";

            if (File.Exists(file) != true) return dtReturn;

            //读取日志内容
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                //需要根据读取的内容增加<xml>开始和结束标记
                logBuf = "<xml>\r\n" + sr.ReadToEnd() + "\r\n</xml>";

                sr.Close();
                fs.Close();
            }

            //重新组织数据流
            using (MemoryStream ms = new MemoryStream())
            using (StreamWriter sw = new StreamWriter(ms))
            {
                sw.Write(logBuf);
                sw.Flush();

                ms.Position = 0;
                dtReturn.ReadXml(ms);

                sw.Close();
                ms.Close();
            }
            
            return dtReturn;
        }

        /// <summary>
        /// 取得上层方法的调用名称
        /// </summary>
        /// <returns></returns>
        public static string GetSource()
        {
            return GetSource(2);
        }

        /// <summary>
        /// 取得上层方法的调用名称
        /// </summary>
        /// <returns></returns>
        public static string GetSource(int level)
        {
            StringBuilder sbSource = new StringBuilder();
            try
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame stackFrame = stackTrace.GetFrame(level);

                MethodBase methodBase = stackFrame.GetMethod();

                sbSource.Append(methodBase.Name);
                sbSource.Append(" [");
                sbSource.Append(methodBase.DeclaringType.Name);
                sbSource.Append("<.cls>");
                sbSource.Append("]");

                return sbSource.ToString();
            }
            finally
            {
                sbSource.Length = 0;
            }
        }

        /// <summary>
        /// 获取参数描述
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public string GetParametersDesc(params string[] pars)
        {
            StringBuilder result = new StringBuilder();

            foreach (object par in pars)
            {
                result.Append(" ");
                result.Append(par); 
            }

            return result.ToString();
        }

        #endregion
    }
}
