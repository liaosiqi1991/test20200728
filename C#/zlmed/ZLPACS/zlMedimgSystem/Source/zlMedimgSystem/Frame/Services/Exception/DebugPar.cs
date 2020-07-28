using System;
using System.Data.Common;


namespace zlMedimgSystem.Services
{
    public static class DebugPar
    {
        //private static List<BugData> _DebugPars = null; //保存参数信息
        //private static bool _isRead = false;                        //保存读取状态，为true表示已经读取
        //private static Exception lastException = null;          //记录上一次调用的异常对象
        private static bool _isEnterDebug =true;// false;   //判断是否进入调试

        #region 属性定义

        public static bool IsEnterDebug
        {
            get { return _isEnterDebug; }
            set { _isEnterDebug = value; }
        }


        //public static List<BugData> BugDatas
        //{
        //    get
        //    {
        //        return _DebugPars;
        //    }
        //}

        #endregion


        /// <summary>
        /// 写入参数
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="pars"></param>
        public static void WriteBugParWithName(string methodName, params string[] pars)
        {
            //if (_isEnterDebug == false) return;

            //if (_DebugPars == null)
            //{
            //    _DebugPars = new List<BugData>();
            //}

            ////清除数据
            //if (_isRead == true)
            //{
            //    ClearBugPar();
            //}

            //BugData exPar = new BugData(methodName);

            //for (int i = 0; i <= pars.Length - 1; i = i + 2)
            //{
            //    if (i >= pars.Length) break;

            //    exPar.Add(pars[i], pars[i + 1]);
            //}

            //lock (_DebugPars)
            //{
            //    _DebugPars.Add(exPar);
            //}
        }

        /// <summary>
        /// 写入参数信息
        /// </summary>
        /// <param name="sqlParams"></param>
        public static void WriteBugParWithSql(string sqlText, DbParameter[] sqlParams)
        {
            //if (_isEnterDebug == false) return;

            //if (_DebugPars == null)
            //{
            //    _DebugPars = new List<BugData>();
            //}

            ////清除数据
            //if (_isRead == true)
            //{
            //    ClearBugPar();
            //}

            //BugData exPar = new BugData(Logger.GetSource(2));
            //exPar.Add("sqlText", sqlText);

            //if (sqlParams != null)
            //{
            //    foreach (OracleParameter op in sqlParams)
            //    {
            //        if (op == null) continue;
            //        if (op.Direction == System.Data.ParameterDirection.Output) break;
            //        exPar.Add(op.ParameterName, ((op.Value == null) || (op.Value == DBNull.Value)) ? null : op.Value.ToString());
            //    }
            //}

            //lock (_DebugPars)
            //{
            //    _DebugPars.Add(exPar);
            //}
        }

        /// <summary>
        /// 写入参数信息
        /// </summary>
        /// <param name="pars"></param>
        public static void WriteBugPar(params string[] pars)
        {
            //if (_isEnterDebug == false) return;

            //if (_DebugPars == null)
            //{
            //    _DebugPars = new List<BugData>();
            //}

            ////清除数据
            //if (_isRead == true)
            //{
            //    ClearBugPar();
            //}

            //BugData exPar = new BugData(Logger.GetSource(2));

            //for (int i = 0; i <= pars.Length - 1; i = i + 2)
            //{
            //    if (i >= pars.Length) break;

            //    exPar.Add(pars[i], pars[i + 1]);
            //}

            //lock (_DebugPars)
            //{
            //    _DebugPars.Add(exPar);
            //}

        }
            
        /// <summary>
        /// 写入参数
        /// </summary>
        /// <param name="exPar"></param>
        public static void WriteBugPar(BugData exPar)
        {
            //if (_isEnterDebug == false) return;

            //if (_DebugPars == null)
            //{
            //    _DebugPars = new List<BugData>();
            //}

            ////清除数据
            //if (_isRead == true)
            //{
            //    ClearBugPar();
            //}

            //lock (_DebugPars)
            //{
            //    _DebugPars.Add(exPar);
            //}
        }

        /// <summary>
        /// 清除异常参数信息
        /// </summary>
        public static void ClearBugPar()
        {
            return;
            //if (_DebugPars == null) return;

            //lock (_DebugPars)   //锁定访问
            //{
            //    _DebugPars.Clear();

            //    _isRead = false;
            //    lastException = null;
            //}
        }

        /// <summary>
        /// 获取所有参数信息
        /// </summary>
        /// <returns></returns>
        public static string GetAllParInf(Exception ex)
        {
            return "";
            //if (_DebugPars == null) return "";

            //if (lastException != null)
            //{
            //    //如果异常与上一次调用该方法的异常对象不同，则清除调试参数信息
            //    if (ex.Equals(lastException) != true) ClearBugPar();
            //}

            //string msg = "\r\n";

            //lock (_DebugPars)   //锁定访问
            //{
            //    int i = 0;
            //    foreach (BugData bd in _DebugPars)
            //    {
            //        msg = msg + "     (" + i.ToString() + ")" + bd.GetBugParInf() + "\r\n";
            //        i = i + 1;
            //    }
            //}

            ////_isRead设置为true后，使用wirte方法时，将清除之前的参数信息
            //_isRead = true;
            //lastException = ex;

            //return msg;
        }

        /// <summary>
        /// 获取最后的异常参数信息
        /// </summary>
        /// <returns></returns>
        public static BugData GetLastBugPar()
        {
            return null;
            //if (_DebugPars == null) return null;

            //lock (_DebugPars)   //锁定访问
            //{
            //    return _DebugPars[_DebugPars.Count - 1];
            //}
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public static void Dispose()
        {
            //if (_DebugPars == null) return;

            //_DebugPars.Clear();
            //_DebugPars = null;

            //lastException = null;
        }

    }
}
