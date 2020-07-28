using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.IO;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.DB.OraServices
{
    public interface IDBService : IDBProvider
    {
        /// <summary>
        /// 解析连接项
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string ParseConnectionItem(string item);

    }
    /// <summary>

    /// </summary>
    public class OraServices : DBDispose, IDBService
    {

        private const string _name = "Oracle";

        public string InterfaceName { get { return _name; } }


        #region 内部属性

        //连接串常量，设置本连接使用参数
        //"Cache Size"= 缓存大小，默认是0，不使用缓存。使用缓存，对于带参数的SQL，可以避免对SQL的多次解析。
        //              cache是跟connection相关的，每个connection管理自己的cache。
        //"Self Tuning"=自动调节缓存大小，默认值是True。如果启用了self tuning那么会自动启用Cache，不需要设置cache size
        private const string ORA_CONN_STRING = ";Self Tuning=true";
        private OracleConnection _conn;

        public OracleConnection Conn
        {
            get { return _conn; }
        }

        private OracleTransaction _trans;
        private string _instanceId = "";

        #endregion

        #region 公共属性


        private bool _connected;
        /// <summary>
        /// 数据库是否连接
        /// </summary>
        public bool Connected
        {
            get { return this._connected; }
        }

        private string _dbConnString;
        /// <summary>
        /// 数据库连接串
        /// </summary>
        public string DBConnString
        {
            get { return this._dbConnString; }
            private set { this._dbConnString = value; }
        }

        public string ProviderName { get { return _name; } }

        #endregion

        #region 构造函数

        //public OraService(string userName, string passWord, string ServerName)
        //    : this("User Id=" + userName + ";Password=" + passWord + ";Data Source=" + ServerName)// + ORA_CONN_STRING)
        //{
        //    //配置oracle_home环境变量
        //    //ConfigOracleEnvironment();
        //}

        public OraServices()
        {
            //设置类实例ID
            _instanceId = Guid.NewGuid().ToString();
        }


        static public string[] GetDatabases()
        {
            string output = "";
            string fileLine;
            string oracle_home;
            Stack parens = new Stack();

            // open tnsnames.ora
            StreamReader sr;
            try
            {
                oracle_home = Environment.GetEnvironmentVariable("oracle_home");
                sr = new StreamReader(oracle_home + @"\network\ADMIN\TNSNAMES.ORA");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw ex;
            }

            // Read the first line of the file
            fileLine = sr.ReadLine();

            // loop through, reading each line of the file
            while (fileLine != null)
            {
                // if the first non whitespace character is a #, ignore the line
                // and go to the next line in the file
                if (fileLine.Length > 0 && fileLine.Trim().Substring(0, 1) != "#")
                {
                    // Read through the input line character by character
                    char lineChar;
                    for (int i = 0; i < fileLine.Length; i++)
                    {
                        lineChar = fileLine[i];

                        if (lineChar == '(')
                        {
                            // if the char is a ( push it onto the stack
                            parens.Push(lineChar);
                        }
                        else if (lineChar == ')')
                        {
                            // if the char is a ), pop the stack
                            parens.Pop();
                        }
                        else
                        {
                            // if there is nothing in the stack, add the character to the

                            if (parens.Count == 0)
                            {
                                output += lineChar;
                            }
                        }
                    }
                }

                // Read the next line of the file
                fileLine = sr.ReadLine();
            }

            // Close the stream reader
            sr.Close();

            // Split the output string into a string[]
            string[] split = output.Split('=');

            // trim each string in the array
            for (int i = 0; i < split.Length; i++)
            {
                split[i] = split[i].Trim();
            }

            Array.Sort(split);

            return split;
        }


        public void Init(string serverName, string user, string pwd)
        {
            _dbConnString = "User Id=" + user + ";Password=" + pwd + ";Data Source=" + serverName;

        }

        public void Init(string ip, int port, string Instance, string user, string pwd)
        {
            _dbConnString = "User ID=" + user + ";Password=" + pwd + ";Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = " + ip + ")(PORT = " + port + "))) (CONNECT_DATA = (SERVICE_NAME = " + Instance + ")))";
        }
        #endregion

        #region 内部方法


        //todo  增加数据库超时处理

        /// <summary>
        /// 转为OracleDbType
        /// http://docs.oracle.com/html/B14164_01/featOraCommand.htm
        /// Table 3-4 Inference of OracleDbType from DbType 
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        private OracleDbType DbType2OraDbType(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.AnsiString:
                case DbType.String:
                    return OracleDbType.Varchar2;
                case DbType.AnsiStringFixedLength:
                case DbType.StringFixedLength:
                    return OracleDbType.Char;
                case DbType.Binary:
                    return OracleDbType.Blob;
                case DbType.Byte:
                    return OracleDbType.Byte;
                case DbType.Date:
                    return OracleDbType.Date;
                case DbType.DateTime:
                case DbType.Time:
                    return OracleDbType.TimeStamp;
                case DbType.Decimal:
                    return OracleDbType.Decimal;
                case DbType.Double:
                    return OracleDbType.Double;
                case DbType.Guid:
                    return OracleDbType.Raw;
                case DbType.Int16:
                case DbType.SByte: //Not Supported 
                    return OracleDbType.Int16;
                case DbType.Int32:
                    return OracleDbType.Int32;
                case DbType.Int64:
                    return OracleDbType.Int64;
                case DbType.Object:
                    throw new NotSupportedException("不支持的ORACLE数据类型。");
                //return OracleDbType.Object;
                case DbType.Single:
                    return OracleDbType.Single;
                case DbType.Xml:
                    return OracleDbType.XmlType;
                case DbType.Boolean:
                //return OracleDbType.Boolean;
                case DbType.Currency:
                case DbType.UInt16:
                    return OracleDbType.Int16;
                case DbType.UInt32:
                    return OracleDbType.Int32;
                case DbType.UInt64:
                    return OracleDbType.Int64;
                case DbType.VarNumeric:
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// 清理数据库值（对值做合法性处理）
        /// </summary>
        /// <param name="val"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private object ClearDbValue(object val, DbType type)
        {
            if (val == null)
                return DBNull.Value;

            switch (type)
            {
                case DbType.Xml:
                    if (val != null && val.ToString().Trim().Length == 0)
                        return DBNull.Value;
                    break;
                default:
                    break;
            }
            return val;
        }

        /// <summary>
        /// 将SQL语句中的参数串，转变成OracleParameter格式
        /// 参数串的格式是：参数名1，参数值1，参数名2，参数值2，......
        /// </summary>
        /// <param name="text">参数串</param>
        /// <returns></returns>
        private OracleParameter[] CreateParameters(bool isStandardOut, object[] text)
        {
            if (text == null && isStandardOut == false) return null;

            List<OracleParameter> list = new List<OracleParameter>();

            if (text != null)
            {
                for (int i = 0; i < text.Length; i += 2)
                {
                    OracleParameter p = null;

                    if (text[i + 1] == null)
                    {
                        if (text[i] != null)
                        {
                            p = new OracleParameter(text[i].ToString(), null);
                        }
                    }
                    else
                    {
                        //这里是解决一个比较奇怪的问题，如果参数的类型是char，新建的OracleParameter的OracleType会变成byte，执行时会出错，只好在这里进行特殊处理
                        //但是，编写一个小程序的里面，char类型的转换是正确，转换成OracleType.VarChar，执行结果正确。
                        if (text[i + 1].GetType() == typeof(char))
                        {
                            p = new OracleParameter(text[i].ToString(), OracleDbType.Char);
                            p.Value = text[i + 1];
                        }
                        else
                        {
                            p = new OracleParameter(text[i].ToString(), text[i + 1]);
                        }
                    }
                    if (p != null)
                    {
                        p.Direction = ParameterDirection.Input;
                        list.Add(p);
                    }
                }
            }
            if (isStandardOut == true)
            {
                //增加标准的返回值
                OracleParameter pOut = null;
                pOut = new OracleParameter("VAL", OracleDbType.RefCursor);
                pOut.Direction = ParameterDirection.Output;
                list.Add(pOut);
            }
            return list.ToArray();
        }

        private OracleParameter[] CreateDicParameters(bool isStandardOut, Dictionary<string, object> sqlParams)
        {
            if (sqlParams == null && isStandardOut == false) return null;

            List<OracleParameter> list = new List<OracleParameter>();

            if (sqlParams != null)
            {

                foreach (string key in sqlParams.Keys)
                {
                    OracleParameter p = null;

                    if (sqlParams[key] == null)
                    {
                        p = new OracleParameter(key, sqlParams[key]);
                    }
                    else
                    {
                        //这里是解决一个比较奇怪的问题，如果参数的类型是char，新建的OracleParameter的OracleType会变成byte，执行时会出错，只好在这里进行特殊处理
                        //但是，编写一个小程序的里面，char类型的转换是正确，转换成OracleType.VarChar，执行结果正确。
                        if (sqlParams[key].GetType() == typeof(char))
                        {
                            p = new OracleParameter(key, OracleDbType.Char);
                            p.Value = sqlParams[key];
                        }
                        else
                        {
                            p = new OracleParameter(key, sqlParams[key]);
                        }
                    }
                    p.Direction = ParameterDirection.Input;
                    list.Add(p);
                }

            }
            if (isStandardOut == true)
            {
                //增加标准的返回值
                OracleParameter pOut = null;
                pOut = new OracleParameter("VAL", OracleDbType.RefCursor);
                pOut.Direction = ParameterDirection.Output;
                list.Add(pOut);
            }
            return list.ToArray();
        }

        private OracleParameter[] CreateSqlPInfoParameters(bool isStandardOut, SqlParamInfo[] sqlParams)
        {
            if (sqlParams == null && isStandardOut == false) return null;

            List<OracleParameter> oraParamList = new List<OracleParameter>();

            if (sqlParams != null && sqlParams.Length > 0)
            {
                foreach (SqlParamInfo var in sqlParams)
                {
                    OracleParameter p = new OracleParameter(var.Name, DbType2OraDbType(var.Type));
                    p.Value = ClearDbValue(var.Value, var.Type);
                    //如果为游标则指定OracleDBType为RefCursor
                    if (var.IsRefCursor)
                    {
                        p.OracleDbType = OracleDbType.RefCursor;
                    }
                    p.Direction = var.Direction;
                    if (p.Direction != ParameterDirection.Input && var.Size > 0)
                    {
                        p.Size = var.Size;
                    }
                    oraParamList.Add(p);
                }
            }

            if (isStandardOut == true)
            {
                //增加标准的返回值
                OracleParameter pOut = null;
                pOut = new OracleParameter("VAL", OracleDbType.RefCursor);
                pOut.Direction = ParameterDirection.Output;
                oraParamList.Add(pOut);

            }
            return oraParamList.ToArray();
        }

        ///// <summary>
        ///// 配置oracle_home环境变量
        ///// </summary>
        //private void ConfigOracleEnvironment()
        //{
        //    string path = "";
        //    string orcHome = "";
        //    string key = "";
        //    string tnsPath = @"NETWORK\ADMIN\";
        //    string tnsFile = "tnsnames.ora";
        //    string tnsAdmin = "";
        //    string fmtPaht = "";

        //    foreach (DictionaryEntry de in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process))
        //    {
        //        key = de.Key.ToString().ToUpper();
        //        if (key == "PATH")
        //        {
        //            path = de.Value.ToString();
        //        }

        //        if (key == "ORACLE_HOME")
        //        {
        //            orcHome = de.Value.ToString() + @"\";
        //            orcHome = orcHome.Replace(@"\\", @"\");
        //        }

        //        if (key == "TNS_ADMIN")
        //        {
        //            tnsAdmin = de.Value.ToString();
        //        }
        //    }

        //    //如果已经配置了有效的tns_admin，则退出
        //    if (Directory.Exists(tnsAdmin) == true) return;

        //    //存在tns配置目录，则直接退出
        //    if (Directory.Exists(orcHome + tnsPath) == true) return;

        //    foreach (string curPath in path.Split(';'))
        //    {
        //        fmtPaht = curPath + @"\";
        //        fmtPaht = fmtPaht.Replace(@"\\", @"\");

        //        if (File.Exists(fmtPaht + tnsPath + tnsFile) == true)
        //        {
        //            //配置oracle_home环境变量
        //            Environment.SetEnvironmentVariable("ORACLE_HOME", curPath, EnvironmentVariableTarget.Process);
        //            return;
        //        }
        //    }
        //}

        #endregion

        #region 公共方法

        /// <summary>
        /// 获取类实例ID
        /// </summary>
        /// <returns></returns>
        public string InstanceId()
        {
            return _instanceId;
        }

        /// <summary>
        /// 解析连接项
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string ParseConnectionItem(string item)
        {
            string curItem = item + "=";

            if (string.IsNullOrEmpty(curItem)) return "";
            if (string.IsNullOrEmpty(_dbConnString)) return "";

            int keyIndex = _dbConnString.IndexOf(curItem);

            if (keyIndex < 0) return "";

            string temp = _dbConnString.Substring(keyIndex + curItem.Length) + ";";

            temp = temp.Substring(0, temp.IndexOf(";"));

            return temp;
        }

        private void ConnectDB()
        {
            try
            {
                // 判断当前数据库是否已经连接，如果未连接，则连接数据库；如果数据库已连接，则直接返回
                if ((_conn == null) || string.IsNullOrEmpty(_conn.ServiceName) == true)
                {
                    _conn = new OracleConnection(_dbConnString);

                    _conn.Open();
                }
                else
                {
                    if (_conn.State != ConnectionState.Open)
                    {
                        //先关闭，再打开数据库连接
                        _conn.Close();
                        _conn.Open();
                    }
                }
                _connected = true;
            }
            catch (Exception ex)
            {
                throw new DBException("数据库连接错误：" + _dbConnString + "\r\n\r\n 错误信息：" + ex.Message, ex);
            }
        }


        #region 事务处理

        /// <summary>
        /// 开始事务处理
        /// </summary>
        public void TransactionBegin()
        {
            if (_trans == null)
            {
                ConnectDB();
                _trans = _conn.BeginTransaction();
            }
            else
            {
                //已经在事务中，先提交之前的事务，再开启新事务
                _trans.Commit();
                _trans = _conn.BeginTransaction();
            }
        }

        /// <summary>
        /// 提交事务处理
        /// </summary>
        public void TransactionCommit()
        {
            if (_trans != null)
            {
                _trans.Commit();
                _trans = null;
            }
            else
            {
                _trans = null;
                throw new DBException("提交数据库事务失败。当前操作不在事务中，无法提交事务。");
            }
        }

        /// <summary>
        /// 回滚事务处理
        /// </summary>
        public void TransactionRollback()
        {
            if (_trans != null)
            {
                _trans.Rollback();
                _trans = null;
            }
            else
            {
                _trans = null;
                throw new DBException("回滚数据库事务失败。当前数据库操作不在事务中，无法回滚事务。");
            }
        }

        #endregion

        #endregion

        #region 实现接口
        //todo 实现接口

        //public void Init(string serverName)
        //{

        //}

        //public void Init(string ip, int port, string instance)
        //{

        //}

        //public bool Login(string user, string pwd)
        //{
        //    return false;
        //}

        public IDbConnection Open(ref string strError)
        {
            ReconnectDB(ref strError);
            return _conn;
        }
        public void Close()
        {
            if (_conn != null) _conn.Close();
        }

        public DataTable ExecuteSQL(SQL sql)
        {
            return ExecuteSQL(sql.Sql, sql.SqlPars);
        }

        public DataTable ExecuteSQL(string sqlText)
        {
            return ExecuteSQL(sqlText, null, null);
        }

        public DataTable ExecuteSQL(string sqlText, params object[] sqlParams)
        {

            return ExecuteDatatable(sqlText, CreateParameters(false, sqlParams), CommandType.Text);
        }

        public DataTable ExecuteSQL(string sqlText, Dictionary<string, object> sqlParams)
        {
            return ExecuteDatatable(sqlText, CreateDicParameters(false, sqlParams), CommandType.Text);
        }

        public DataTable ExecuteSQL(string sqlText, SqlParamInfo[] sqlParams)
        {
            return ExecuteDatatable(sqlText, CreateSqlPInfoParameters(false, sqlParams), CommandType.Text);
        }

        public DataTable ExecuteSQL(string sqlText, DbParameter[] sqlParams)
        {
            return ExecuteDatatable(sqlText, sqlParams, CommandType.Text);
        }

        public object ExecuteSQLOneOutput(SQL sql)
        {
            return ExecuteSQLOneOutput(sql.Sql, sql.SqlPars);
        }
        public object ExecuteSQLOneOutput(string sqlText)
        {
            return ExecuteSQLOneOutput(sqlText, null, null);
        }

        public object ExecuteSQLOneOutput(string sqlText, params object[] sqlParams)
        {
            return ExecuteSQLOneOutput(sqlText, CreateParameters(false, sqlParams));
        }

        public object ExecuteSQLOneOutput(string sqlText, Dictionary<string, object> sqlParams)
        {
            return ExecuteSQLOneOutput(sqlText, CreateDicParameters(false, sqlParams));
        }

        public object ExecuteSQLOneOutput(string sqlText, SqlParamInfo[] sqlParams)
        {
            return ExecuteSQLOneOutput(sqlText, CreateSqlPInfoParameters(false, sqlParams));
        }

        public object ExecuteSQLOneOutput(string sqlText, DbParameter[] sqlParams)
        {
            try
            {
                object oOutput = null;
                //todo 实现 ExcuteSQL
                //确保数据库已经连接
                ConnectDB();


                using (OracleCommand cmd = new OracleCommand(sqlText, _conn))
                {
                    if (sqlParams != null)
                    {
                        foreach (OracleParameter p in sqlParams)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    try
                    {
                        oOutput = cmd.ExecuteScalar();
                    }
                    catch(Exception ex) 
                    {
                        //调用数据库重连    
                        if (_conn.State != ConnectionState.Open)
                        {
                            ReconnectDB();
                            oOutput = cmd.ExecuteScalar();
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                }
                return oOutput;
            }
            catch (Exception ex)
            {
                throw new DBException("语句执行错误：" + sqlText + "\r\n\r\n 参数信息：" + GetExecuteParameterInfo(sqlParams) +  "\r\n\r\n 错误信息：" +ex.Message, ex);
            }            
        }

        public DataTable ExecuteProcedure(SQL sql)
        {
            return ExecuteProcedure(sql.Sql, sql.SqlPars);
        }

        public DataTable ExecuteProcedure(SQL sql, out Dictionary<string, object> outValue)
        {
            return ExecuteProcedure(sql.Sql, out outValue, sql.SqlPars);
        }

        public DataTable ExecuteProcedure(string sqlText)
        {
            return ExecuteProcedure(sqlText, null, null);
        }

        public DataTable ExecuteProcedure(string sqlText, params object[] sqlParams)
        {
            return ExecuteDatatable(sqlText, CreateParameters(false, sqlParams), CommandType.StoredProcedure);
        }
         
        public DataTable ExecuteProcedure(string sqlText, out Dictionary<string, object> outValue, params object[] sqlParams)
        {
            OracleParameter[] oraPars = CreateParameters(false, sqlParams);
            DataTable dtResult = ExecuteDatatable(sqlText, oraPars, CommandType.StoredProcedure);

            outValue = new Dictionary<string, object>();
            for (int i = 0; i < oraPars.Length; i++)
            {
                if (oraPars[i].Direction == ParameterDirection.Input) continue;

                outValue.Add(oraPars[i].ParameterName, oraPars[i].Value);
            }

            return dtResult;
        }

        public DataTable ExecuteProcedure(string sqlText, Dictionary<string, object> sqlParams)
        {
             return ExecuteDatatable(sqlText, CreateDicParameters(false, sqlParams), CommandType.StoredProcedure);
        }

        public DataTable ExecuteProcedure(string sqlText, out Dictionary<string, object> outValue, Dictionary<string, object> sqlParams)
        {
            OracleParameter[] oraPars = CreateDicParameters(false, sqlParams);
            DataTable dtResult = ExecuteDatatable(sqlText, oraPars, CommandType.StoredProcedure);

            outValue = new Dictionary<string, object>();
            for (int i = 0; i < oraPars.Length; i++)
            {
                if (oraPars[i].Direction == ParameterDirection.Input) continue;

                outValue.Add(oraPars[i].ParameterName, oraPars[i].Value);
            }

            return dtResult;
        }

        public DataTable ExecuteProcedure(string sqlText, SqlParamInfo[] sqlParams)
        {
            return ExecuteDatatable(sqlText, CreateSqlPInfoParameters(false, sqlParams), CommandType.StoredProcedure);
        }

        public DataTable ExecuteProcedure(string sqlText, out Dictionary<string, object> outValue, SqlParamInfo[] sqlParams)
        {
            OracleParameter[] oraPars = CreateSqlPInfoParameters(false, sqlParams);
            DataTable dtResult = ExecuteDatatable(sqlText, oraPars, CommandType.StoredProcedure);

            outValue = new Dictionary<string, object>();
            for (int i = 0; i < oraPars.Length; i++)
            {
                if (oraPars[i].Direction == ParameterDirection.Input) continue;

                outValue.Add(oraPars[i].ParameterName, oraPars[i].Value);
            }

            return dtResult;


        }

        public DataTable ExecuteProcedure(string sqlText, DbParameter[] sqlParams)
        {
            return  ExecuteDatatable(sqlText, sqlParams, CommandType.StoredProcedure);
        }

        public DataTable ExecuteProcedure(string sqlText, out Dictionary<string, object> outValue, DbParameter[] sqlParams)
        {
            List<OracleParameter> oraParamList = new List<OracleParameter>();
            if (sqlParams != null && sqlParams.Length > 0)
            {
                foreach (OracleParameter var in sqlParams)
                {
                    oraParamList.Add(var);
                }
            }
            //增加标准的返回值
            OracleParameter pOut = null;
            pOut = new OracleParameter("VAL", OracleDbType.RefCursor);
            pOut.Direction = ParameterDirection.Output;
            oraParamList.Add(pOut);

            DataTable dtResult = ExecuteDatatable(sqlText, oraParamList.ToArray(), CommandType.StoredProcedure);

            outValue = new Dictionary<string, object>();
            for (int i = 0; i < sqlParams.Length; i++)
            {
                if (sqlParams[i].Direction == ParameterDirection.Input) continue;

                outValue.Add(sqlParams[i].ParameterName, sqlParams[i].Value);
            }

            return dtResult;
        }

        public DataTable ExecuteProcedureOneOutput(SQL sql)
        {
            return ExecuteProcedureOneOutput(sql.Sql, sql.SqlPars);
        }

        public DataTable ExecuteProcedureOneOutput(string sqlText)
        {
            return ExecuteProcedureOneOutput(sqlText, null, null);
        }

        public DataTable ExecuteProcedureOneOutput(string sqlText, params object[] sqlParams)
        {
            return ExecuteDatatable(sqlText, CreateParameters(true, sqlParams), CommandType.StoredProcedure);
        }

        public DataTable ExecuteProcedureOneOutput(string sqlText, Dictionary<string, object> sqlParams)
        {
            return ExecuteDatatable(sqlText, CreateDicParameters(true, sqlParams), CommandType.StoredProcedure);
        }

        public DataTable ExecuteProcedureOneOutput(string sqlText, SqlParamInfo[] sqlParams)
        {
            return ExecuteDatatable(sqlText, CreateSqlPInfoParameters(true, sqlParams), CommandType.StoredProcedure);
        }

        public DataTable ExecuteProcedureOneOutput(string sqlText, DbParameter[] sqlParams)
        {
            List<OracleParameter> oraParamList = new List<OracleParameter>();
            if (sqlParams != null && sqlParams.Length > 0)
            {
                foreach (OracleParameter var in sqlParams)
                {
                    oraParamList.Add(var);
                }
            }
            //增加标准的返回值
            OracleParameter pOut = null;
            pOut = new OracleParameter("VAL", OracleDbType.RefCursor);
            pOut.Direction = ParameterDirection.Output;
            oraParamList.Add(pOut);

            return ExecuteDatatable(sqlText, oraParamList.ToArray(), CommandType.StoredProcedure);
        }


        public DataTable ExecuteOracleParmerterDatatable(string sqlText, DbParameter[] sqlParams, CommandType sqlType)
        {
            return ExecuteDatatable(sqlText, sqlParams, sqlType);
        }

        public string XmlToString(object dbXmlData)
        {
            if (dbXmlData == null) return "";

            OracleXmlType oxt = dbXmlData as OracleXmlType;
            if (oxt == null) return "";

            return oxt.Value;
        }

        private object ExecuteFunction(string sqlText)
        {
            return ExecuteFunctionCore(sqlText, null);
        }

        private object ExecuteFunction(string sqlText, params object[] sqlParams)
        {
            return ExecuteFunctionCore(sqlText, CreateParameters(false, sqlParams));
        }

        private object ExecuteFunction(string sqlText, Dictionary<string, object> sqlParams)
        {
            return ExecuteFunctionCore(sqlText, CreateDicParameters(false, sqlParams));
        }

        private object ExecuteFunctionCore(string sqlText, DbParameter[] sqlParams)
        {
            try
            {
                //记录当前的参数调用状态，编译异常时明确问题原因
                //DebugPar.WriteBugParWithSql(sqlText, sqlParams);

                //调用时必须要自己设置正确的返回值类型，才能正确使用，使用不方便。
                //改用select的方式查询函数，可以直接用object类型接收返回值。

                string strResult = null;

                //确保数据库已经连接
                ConnectDB();

                //处理参数，执行SQL，返回结果
                using (OracleCommand cmd = new OracleCommand(sqlText, _conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.BindByName = true;
                    cmd.AddToStatementCache = true;
                    //增加参数
                    if (sqlParams != null)
                    {
                        cmd.Parameters.AddRange(sqlParams);
                    }
                    //增加返回值

                    //增加标准的返回值
                    OracleParameter pOut = null;
                    pOut = new OracleParameter("retVAL", OracleDbType.Double);
                    pOut.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(pOut);

                    //执行函数
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        //调用数据库重连    
                        if (_conn.State != ConnectionState.Open)
                        {
                            ReconnectDB();
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            throw ex;
                        }
                    }

                    //提取函数执行返回值
                    foreach (OracleParameter var in cmd.Parameters)
                    {
                        if (var.Direction == ParameterDirection.ReturnValue)
                        {
                            if (var.Value == null || (var.Value is INullable && (var.Value as INullable).IsNull))
                            {
                                strResult = null;
                            }
                            else if (var.Value is OracleXmlType)
                            {
                                OracleXmlType valXMLType = (var.Value as OracleXmlType);
                                if (!valXMLType.IsEmpty)
                                {
                                    strResult = valXMLType.Value.ToString();
                                }
                            }
                            else
                            {
                                strResult = var.Value.ToString();
                            }
                            break;
                        }
                    }
                }
                return strResult;
            }
            catch (Exception ex)
            {
                throw new DBException("语句执行错误：" + sqlText + "\r\n\r\n 参数信息：" + GetExecuteParameterInfo(sqlParams) + "\r\n\r\n 错误信息：" + ex.Message, ex);
            }
        }

        private DataTable ExecuteDatatable(string sqlText, DbParameter[] sqlParams, CommandType sqlType)
        {
            try
            {
                //记录当前的参数调用状态，编译异常时明确问题原因
                //DebugPar.WriteBugParWithSql(sqlText, sqlParams);

                //todo 实现 ExcuteSQL
                //确保数据库已经连接
                ConnectDB();

                //处理参数,执行SQL，返回结果
                DataTable dt = new DataTable();

                using (OracleCommand cmd = new OracleCommand(sqlText, _conn))
                {
                    cmd.CommandType = sqlType;
                    cmd.BindByName = true;
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        if (sqlParams != null)
                        {
                            int parItemCount = 0;

                            foreach (OracleParameter p in sqlParams)
                            {
                                adapter.SelectCommand.Parameters.Add(p);

                                //判断参数是否为批量数组参数
                                if (parItemCount == 0 && p.Value != null && (p.Value is byte[]) == false && p.Value is IList)
                                {
                                    parItemCount = (p.Value as IList).Count;
                                }
                            }

                            adapter.SelectCommand.ArrayBindCount = parItemCount;
                        }

                        try
                        {                 
                            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                            //lock (_conn)
                            {
                                adapter.Fill(dt);
                            }
                        }
                        catch(Exception ex)
                        {
                            if (_conn.State != ConnectionState.Open)
                            {
                                //调用数据库重连                              
                                ReconnectDB();

                                //lock (_conn)
                                {
                                    adapter.Fill(dt);
                                }
                            }
                            else
                            {
                                throw ex;
                            }
                        }
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new DBException("语句执行错误：" + sqlText + "\r\n\r\n 参数信息：" + GetExecuteParameterInfo(sqlParams) + "\r\n\r\n 错误信息：" + ex.Message, ex);
            }
        }

        public string GetExecuteParameterInfo(DbParameter[] sqlParams)
        {
            string result = "";

            if (sqlParams == null) return "无参数";

            foreach (OracleParameter p in sqlParams)
            {
                result = result + "\r\n    " + p.ParameterName + ":" + Convert.ToString(p.Value);
            }

            if (string.IsNullOrEmpty(result)) result = "无参数";

            return result;
        }

        public OracleDataReader ExecReader(string sqlText, params object[] sqlParams)
        {

            OracleDataReader oReader = null;
            OracleParameter[] op = null;

            try
            {
                //确保数据库已经连接
                ConnectDB();

                op = CreateParameters(false, sqlParams);

                using (OracleCommand cmd = new OracleCommand(sqlText, _conn))
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (op != null)
                    {
                        foreach (OracleParameter p in op)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }

                    try
                    {
                        oReader = cmd.ExecuteReader();
                    }
                    catch(Exception ex) 
                    {
                        //调用数据库重连  
                        if (_conn.State != ConnectionState.Open)
                        {
                            ReconnectDB();
                            oReader = cmd.ExecuteReader();
                        }
                        else
                        {
                            throw ex;
                        }
                    }

                    return oReader;
                }
            }
            catch (Exception ex)
            {
                throw new DBException("语句执行错误：" + sqlText + "\r\n\r\n 参数信息：" + GetExecuteParameterInfo(op) + "\r\n\r\n 错误信息：" + ex.Message, ex);
            }
        }

        public void ReconnectDB()
        {
            string strErr = "";

            ReconnectDB(ref strErr);

            if (string.IsNullOrEmpty(strErr) == false)
            {
                throw new DBException("数据库链接异常，" + strErr);
            }
        }
        public void ReconnectDB(ref string strError)
        {
            try
            {
                strError = "";

                // 判断当前数据库是否已经连接，如果未连接，则连接数据库；如果数据库已连接，则直接返回
                if (_conn == null)
                {
                    _conn = new OracleConnection(_dbConnString);

                    _conn.Open();
                }
                else
                {
                    //先关闭，再打开数据库连接
                    _conn.Close();
                    _conn.Open();
                }
                _connected = true;
            }
            catch(Exception ex)
            {
                _connected = false;
                _conn = null;

                strError = ex.Message;
            }
        }

        #endregion

        #region 资源回收
        protected override void DisposeHostedRes()
        {
            //todo 清空托管资源
            if (_trans != null)
            {
                _trans.Commit();
                _trans.Dispose();
            }

            if (_conn != null)
            {
                _conn.Dispose();
            }
        }

        protected override void DisposeNotHostedRes()
        {
            //todo DisposeNotHostedRes

        }
        #endregion
    }
}
