using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.DataModel
{
    public class DBModel
    {
        protected IDBQuery _dbHelper = null;

        public IDBQuery DBQuery
        {
            get { return _dbHelper; }
        }


        public DBModel(IDBQuery dbHelper)
        {
            _dbHelper = dbHelper;
        }


        public DateTime GetServerDate()
        {
            string sql = "select sysdate from dual";
            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null ? default(DateTime) : Convert.ToDateTime(value));
        }

        public DateTime  GetServerStamp()
        {
            string sql = "select systimestamp from dual";
            object value = _dbHelper.ExecuteSQLOneOutput(sql);

            return (value == null ? default(DateTime) : Convert.ToDateTime(value));
        }

        public SQL CreateSQL(string key, string sqlSource)
        {
            return SqlHelper.CreateSQL(key, sqlSource, _dbHelper);
        }

        public SQL CreateSQL(string key, string sqlSource, SqlParamInfo[] sqlPars)
        {
            return SqlHelper.CreateSQL(key, sqlSource, sqlPars, _dbHelper);
        }

        /// <summary>
        /// 开始事务
        /// </summary>
        public void TransactionBegin()
        {
            _dbHelper.TransactionBegin();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void TransactionCommit()
        {
            _dbHelper.TransactionCommit();
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void TransactionRollback()
        {
            _dbHelper.TransactionRollback();
        }
    }
}
