using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace zlMedimgSystem.Interface
{
    /// <summary>
    /// 数据源类型
    /// </summary>
    public enum DBSourceType
    {
        /// <summary>
        /// Oracle 
        /// </summary>
        Oracle = 1,
        /// <summary>
        /// SqlServer
        /// </summary>
        SqlServer = 2
    }

    public class DBTypeConvert
    {
        /// <summary>
        /// 文档数据类型字符串转为对应的数据库类型
        /// </summary>
        /// <param name="typeInDoc"></param>
        /// <returns></returns>
        public static DbType ToDbType(string typeInDoc)
        {
            if (!string.IsNullOrEmpty(typeInDoc))
            {
                switch (typeInDoc.Trim().ToUpper())
                {
                    case "S": //字符型(string)
                        return DbType.String;
                    case "N": //数值型(number)
                        return DbType.Double;
                    case "L": //布尔型(boolean)
                        return DbType.Boolean;
                    case "DT": //日期时间型(datetime)
                        return DbType.DateTime;
                    case "D": //日期型(date)
                        return DbType.Date;
                    case "T": //时间型(time)
                        return DbType.Time;
                    case "BY": //二进制(binary)
                        return DbType.Binary;
                    default:
                        break;
                }
            }
            return DbType.String;
        }
    }

    public class SqlParamInfo
    {
        # region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="typeInDoc">参数类型</param>
        /// <param name="val">参数值</param>
        public SqlParamInfo(string name, string typeInDoc, object val)
            : this(name, DBTypeConvert.ToDbType(typeInDoc), val, ParameterDirection.Input)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="type">参数类型</param>
        /// <param name="val">参数值</param>
        public SqlParamInfo(string name, DbType type, object val)
            : this(name, type, val, ParameterDirection.Input)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="type">参数类型</param>
        /// <param name="val">参数值</param>
        /// <param name="direction">参数类型.Direction</param>
        public SqlParamInfo(string name, DbType type, object val, ParameterDirection direction)
        {
            this.name = name;
            this.type = type;
            this.val = val;
            this.size = 0;
            this.isRefCursor = false;
            this.direction = direction;
        }

        #endregion

        #region 属性定义

        private string name;
        /// <summary>
        /// 参数名
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private object val;
        /// <summary>
        /// 参数值
        /// </summary>
        public object Value
        {
            get { return this.val; }
            set { this.val = value; }
        }

        /// <summary>
        /// 参数类型
        /// </summary>
        private DbType type;
        public DbType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }


        private int size;
        /// <summary>
        /// 参数长度
        /// </summary>
        public int Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        private bool isRefCursor;
        /// <summary>
        /// 是否RefCursor
        /// </summary>
        public bool IsRefCursor
        {
            get { return this.isRefCursor; }
            set { this.isRefCursor = value; }
        }

        private ParameterDirection direction;
        /// <summary>
        /// 参数类型，方向
        /// </summary>
        public ParameterDirection Direction
        {
            get { return this.direction; }
            set { this.direction = value; }
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 获取参数在SQL中的字符串（如:Oracle中为":参数名",Sqlserver中为"@参数名"）
        /// </summary>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public string GetParamTextInSql(DBSourceType sourceType)
        {
            return GetParamTextInSql(this.name, sourceType);
        }

        /// <summary>
        /// 获取参数在SQL中的字符串（如:Oracle中为":参数名",Sqlserver中为"@参数名"）
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public static string GetParamTextInSql(string paramName, DBSourceType sourceType)
        {
            if (string.IsNullOrEmpty(paramName))
                return null;

            switch (sourceType)
            {
                case DBSourceType.Oracle:
                    return ":" + paramName.TrimStart(':');
                case DBSourceType.SqlServer:
                    return "@" + paramName.TrimStart('@');
                default:
                    throw new NotSupportedException("尚不支持的数据库类型:" + sourceType.ToString());
            }
        }

        #endregion

        /// <summary>
        /// 清理数据库值（对值做合法性处理）
        /// </summary>
        /// <param name="val"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object ClearDbValue(object val, DbType type)
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
    }

    public struct SqlField
    {
        public DbType FieldType { get; set; }
        public string FieldName { get; set; }

        public object Value { get; set; }

        public SqlField(string fieldName, DbType fieldType, object value)
        {
            FieldName = fieldName;
            FieldType = fieldType;
            Value = value;
        }

        public new string ToString()
        {
            return FieldName;
        }

        static public implicit operator string(SqlField field)
        {
            return field.ToString();
        }

        static public implicit operator SqlField(string fieldName)
        {
            SqlField field = new SqlField();
            field.FieldType = DbType.String;
            field.FieldName = fieldName;
            field.Value = null;

            return field;
        }

    }

    public class SQL
    {
        private string _sql = "";
        private string _sqlKey = "";
        private List<SqlParamInfo> _sqlPars = null;
        private IDBQuery _dbHelper = null;

        public string Sql
        {
            get
            {
                //string  SqlHelper.GetSqlBiz().GetSqlContext(_sqlKey, sql);
                return _sql;
            }
            set
            {
                _sql = value;
            }
        }

        public string Key
        {
            get { return _sqlKey; }
        }

        public SqlParamInfo[] SqlPars
        {
            get
            {
                if (_sqlPars == null || _sqlPars.Count <= 0) return null;

                return _sqlPars.ToArray();
            }
        }

        public SQL(string sql)
            :this("", sql, null, null)
        {
        }

        public SQL(string sql, IDBQuery dbHelper)
            : this("", sql, null, dbHelper)
        {
        }

        public SQL(string key, string sql)
            : this(key, sql, null, null)
        {
        }

        public SQL(string key, string sql, IDBQuery dbHelper)
            : this(key, sql, null, dbHelper)
        {
        }

        public SQL(string key, string sql, SqlParamInfo[] sqlPars) 
            :this(key, sql, sqlPars, null)
        {

        }

        public SQL(string key, string sql, SqlParamInfo[] sqlPars, IDBQuery dbHelper)
        {
            _sql = sql;
            _sqlKey = key;

            _sqlPars = new List<SqlParamInfo>();
            _dbHelper = dbHelper;

            if (sqlPars != null) _sqlPars.AddRange(SqlPars);

        }

        public new string ToString()
        {
            return Sql;
        }

        public void AddParameter(SqlParamInfo sqlPar)
        {
            _sqlPars.Add(sqlPar);
        }

        public SqlParamInfo AddParameter(string parName, object value)
        {
            SqlParamInfo sqlpar = new SqlParamInfo(parName, DbType.String, value);
            _sqlPars.Add(sqlpar);

            return sqlpar;
        }

        public SqlParamInfo AddStringPar(string parName, object value)
        {
            SqlParamInfo sqlpar = new SqlParamInfo(parName, DbType.String, value);
            _sqlPars.Add(sqlpar);

            return sqlpar;
        }

        public SqlParamInfo AddInt32Par(string parName, object value)
        {
            SqlParamInfo sqlpar = new SqlParamInfo(parName, DbType.Int32, value);
            _sqlPars.Add(sqlpar);

            return sqlpar;
        }

        public SqlParamInfo AddDoublePar(string parName, object value)
        {
            SqlParamInfo sqlpar = new SqlParamInfo(parName, DbType.Double, value);
            _sqlPars.Add(sqlpar);

            return sqlpar;
        }

        public SqlParamInfo AddDateTimePar(string parName, object value)
        {
            SqlParamInfo sqlpar = new SqlParamInfo(parName, DbType.DateTime, value);
            _sqlPars.Add(sqlpar);

            return sqlpar;
        }

        public SqlParamInfo AddInt64Par(string parName, object value)
        {
            SqlParamInfo sqlpar = new SqlParamInfo(parName, DbType.UInt64, value);
            _sqlPars.Add(sqlpar);

            return sqlpar;
        }

        public SqlParamInfo AddParameter(string parName, DbType dbType, object value)
        {
            SqlParamInfo sqlpar = new SqlParamInfo(parName, dbType, value);
            _sqlPars.Add(sqlpar);

            return sqlpar;
        }

        public void AddParameterRange(SqlParamInfo[] sqlPars)
        {
            _sqlPars.AddRange(sqlPars);
        }

        public void ClearParameters()
        {
            _sqlPars.Clear();
        }

        public DataTable ExecuteSql()
        {
            return _dbHelper.ExecuteSQL(this);
        }

        public object ExecuteSqlOneOutput()
        {
            return _dbHelper.ExecuteSQLOneOutput(this);
        }

        public void ExecuteProc()
        {
            _dbHelper.ExecuteProcedure(this);
        }

        public DataTable ExecuteProc(out Dictionary<string, object> outputs)
        {
            return _dbHelper.ExecuteProcedure(this, out outputs);
        }

        public DataTable ExecuteProcOneOutput()
        {
            return _dbHelper.ExecuteProcedureOneOutput(this);
        }
    }

    public interface IDBQuery
    {
        #region 数据服务

        #region<ExecuteSQL>
        DataTable ExecuteSQL(SQL sql);

        /// <summary>
        /// 使用SQL语句查询数据库
        /// </summary>
        /// <param name="sqlText">在数据库中执行的SQL语句，可以是select，update，delete等</param>
        /// <returns></returns>
        DataTable ExecuteSQL(string sqlText);
        /// <summary>
        /// 使用SQL语句查询数据库
        /// </summary>
        /// <param name="sqlText">在数据库中执行的SQL语句，可以是select，update，delete等</param>
        /// <param name="sqlParams">参数串的格式是：参数名1，参数值1，参数名2，参数值2，......</param>
        /// <returns></returns>
        DataTable ExecuteSQL(string sqlText, params object[] sqlParams);
        /// <summary>
        /// 使用SQL语句查询数据库
        /// </summary>
        /// <param name="sqlText">在数据库中执行的SQL语句，可以是select，update，delete等</param>
        /// <param name="sqlParams">参数</param>
        /// <returns></returns>
        DataTable ExecuteSQL(string sqlText, Dictionary<string, object> sqlParams);
        /// <summary>
        /// 使用SQL语句查询数据库
        /// </summary>
        /// <param name="sqlText">在数据库中执行的SQL语句，可以是select，update，delete等</param>
        /// <param name="sqlParams">参数</param>
        /// <returns></returns>
        DataTable ExecuteSQL(string sqlText, SqlParamInfo[] sqlParams);
        /// <summary>
        /// 使用SQL语句查询数据库
        /// </summary>
        /// <param name="sqlText">在数据库中执行的SQL语句，可以是select，update，delete等</param>
        /// <param name="sqlParams">参数</param>
        /// <returns></returns>
        DataTable ExecuteSQL(string sqlText, DbParameter[] sqlParams);

        #endregion


        #region<ExecuteSQLOneOutput>
        object ExecuteSQLOneOutput(SQL sql);

        /// <summary>
        /// 使用SQL语句查询数据库，只返回一个值
        /// </summary>
        /// <param name="sqlText">在数据库中执行的SQL语句，可以是select，update，delete等</param>
        /// <returns></returns>
        object ExecuteSQLOneOutput(string sqlText);
        /// <summary>
        /// 使用SQL语句查询数据库，只返回一个值
        /// </summary>
        /// <param name="sqlText">在数据库中执行的SQL语句，可以是select，update，delete等</param>
        /// <param name="sqlParams">参数串的格式是：参数名1，参数值1，参数名2，参数值2，......</param>
        /// <returns></returns>
        object ExecuteSQLOneOutput(string sqlText, params object[] sqlParams);
        /// <summary>
        /// 使用SQL语句查询数据库，只返回一个值
        /// </summary>
        /// <param name="sqlText">在数据库中执行的SQL语句，可以是select，update，delete等</param>
        /// <param name="sqlParams">参数</param>
        /// <returns></returns>
        object ExecuteSQLOneOutput(string sqlText, Dictionary<string, object> sqlParams);
        /// <summary>
        /// 使用SQL语句查询数据库，只返回一个值
        /// </summary>
        /// <param name="sqlText">在数据库中执行的SQL语句，可以是select，update，delete等</param>
        /// <param name="sqlParams">参数</param>
        /// <returns></returns>
        object ExecuteSQLOneOutput(string sqlText, SqlParamInfo[] sqlParams);
        /// <summary>
        /// 使用SQL语句查询数据库，只返回一个值
        /// </summary>
        /// <param name="sqlText">在数据库中执行的SQL语句，可以是select，update，delete等</param>
        /// <param name="sqlParams">参数</param>
        /// <returns></returns>
        object ExecuteSQLOneOutput(string sqlText, DbParameter[] sqlParams);
        #endregion


        #region<ExecuteProcedure>
        DataTable ExecuteProcedure(SQL sql);
        DataTable ExecuteProcedure(SQL sql, out Dictionary<string, object> outValue);

        /// <summary>
        /// 执行存储过程，建议系统中所有的查询，数据更新操作，全部使用存储过程处理
        /// </summary>
        /// <param name="sqlText">存储过程名</param>
        DataTable ExecuteProcedure(string sqlText);
        /// <summary>
        /// 执行存储过程，建议系统中所有的查询，数据更新操作，全部使用存储过程处理
        /// </summary>
        /// <param name="sqlText">存储过程名</param>
        /// <param name="sqlParams">参数串的格式是：参数名1，参数值1，参数名2，参数值2，......</param>
        DataTable ExecuteProcedure(string sqlText, params object[] sqlParams);
        DataTable ExecuteProcedure(string sqlText, out Dictionary<string, object> outValue, params object[] sqlParams);
        /// <summary>
        ///  执行存储过程，建议系统中所有的查询，数据更新操作，全部使用存储过程处理
        /// </summary>
        /// <param name="sqlText">存储过程名</param>
        /// <param name="sqlParams">参数</param>
        DataTable ExecuteProcedure(string sqlText, Dictionary<string, object> sqlParams);
        DataTable ExecuteProcedure(string sqlText, out Dictionary<string, object> outValue, Dictionary<string, object> sqlParams);
        
        /// <summary>
        /// 执行存储过程，建议系统中所有的查询，数据更新操作，全部使用存储过程处理
        /// </summary>
        /// <param name="sqlText">存储过程名</param>
        /// <param name="sqlParams">参数</param>
        DataTable ExecuteProcedure(string sqlText, SqlParamInfo[] sqlParams);
        DataTable ExecuteProcedure(string sqlText, out Dictionary<string, object> outValue, SqlParamInfo[] sqlParams);
        /// <summary>
        /// 执行存储过程，建议系统中所有的查询，数据更新操作，全部使用存储过程处理
        /// </summary>
        /// <param name="sqlText">存储过程名</param>
        /// <param name="sqlParams">参数</param>
        DataTable ExecuteProcedure(string sqlText, DbParameter[] sqlParams);
        DataTable ExecuteProcedure(string sqlText, out Dictionary<string, object> outValue, DbParameter[] sqlParams);

        #endregion


        #region<ExecuteProcedureOneOutput>
        DataTable ExecuteProcedureOneOutput(SQL sql);

        /// <summary>
        /// 执行带一个返回值的，在存储过程中要求返回值名称是“VAL”,类型是Ref Cursor。
        /// 建议系统中所有的查询，数据更新操作，全部使用存储过程处理
        /// </summary>
        /// <param name="sqlText">存储过程名</param>
        /// <returns></returns>
        DataTable ExecuteProcedureOneOutput(string sqlText);
        /// <summary>
        /// 执行带一个返回值的，在存储过程中要求返回值名称是“VAL”,类型是Ref Cursor。
        /// 建议系统中所有的查询，数据更新操作，全部使用存储过程处理
        /// </summary>
        /// <param name="sqlText">存储过程名</param>
        /// <param name="sqlParams">参数串的格式是：参数名1，参数值1，参数名2，参数值2，......存储过程的输入参数，不需要添加“VAL”输出参数，函数内部自动添加</param>
        /// <returns></returns>
        DataTable ExecuteProcedureOneOutput(string sqlText, params object[] sqlParams);
        /// <summary>
        /// 执行带一个返回值的，在存储过程中要求返回值名称是“VAL”,类型是Ref Cursor。
        /// 建议系统中所有的查询，数据更新操作，全部使用存储过程处理
        /// </summary>
        /// <param name="sqlText">存储过程名</param>
        /// <param name="sqlParams">存储过程的输入参数，不需要添加“VAL”输出参数，函数内部自动添加</param>
        /// <returns></returns>
        DataTable ExecuteProcedureOneOutput(string sqlText, Dictionary<string, object> sqlParams);
        /// <summary>
        /// 执行带一个返回值的，在存储过程中要求返回值名称是“VAL”,类型是Ref Cursor。
        /// 建议系统中所有的查询，数据更新操作，全部使用存储过程处理
        /// </summary>
        /// <param name="sqlText">存储过程名</param>
        /// <param name="sqlParams">存储过程的输入参数，不需要添加“VAL”输出参数，函数内部自动添加</param>
        /// <returns></returns>
        DataTable ExecuteProcedureOneOutput(string sqlText, SqlParamInfo[] sqlParams);
        /// <summary>
        /// 执行带一个返回值的，在存储过程中要求返回值名称是“VAL”,类型是Ref Cursor。
        /// 建议系统中所有的查询，数据更新操作，全部使用存储过程处理
        /// </summary>
        /// <param name="sqlText">存储过程名</param>
        /// <param name="sqlParams">存储过程的输入参数，不需要添加“VAL”输出参数，函数内部自动添加</param>
        /// <returns></returns>
        DataTable ExecuteProcedureOneOutput(string sqlText, DbParameter[] sqlParams);

        #endregion

        /// <summary>
        /// 执行SQL或者存储过程，如果存储过程带返回值参数，需要在sqlParams中添加
        /// </summary>
        /// <param name="sqlText">SQL语句或存储过程名</param>
        /// <param name="sqlParams">SQL语句或存储过程的全部输入，输出参数</param>
        /// <param name="sqlType">sqlText为SQL语句时=CommandType.Text;sqlText为存储过程时=CommandType.StoredProcedure</param>
        /// <returns></returns>
        DataTable ExecuteOracleParmerterDatatable(string sqlText, DbParameter[] sqlParams, CommandType sqlType);


        string XmlToString(object dbXmlData);

        #region 事务处理

        /// <summary>
        /// 开始事务处理
        /// </summary>
        void TransactionBegin();

        /// <summary>
        /// 提交事务处理
        /// </summary>
        void TransactionCommit();

        /// <summary>
        /// 回滚事务处理
        /// </summary>
        void TransactionRollback();

        #endregion

        #endregion
    }
}
