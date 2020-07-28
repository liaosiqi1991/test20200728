using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.SqlManager
{
    [Serializable]
    public class SqlInfo
    {
        [XmlAttribute]
        public string SqlKey { get; set; }

        [XmlAttribute]
        public string SqlContext { get; set; }

        public SqlInfo()
        {

        }

        public SqlInfo(string sqlKey, string sqlContext )
        {
            SqlKey = sqlKey;
            SqlContext = sqlContext;
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected SqlInfo(SerializationInfo info, StreamingContext context)
        {
            SqlKey = info.GetString("SqlKey");
            SqlContext = info.GetString("SqlContext"); 
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SqlKey", SqlKey);
            info.AddValue("SqlContext", SqlContext); 
        }

    }

    [Serializable]
    public class SqlBiz:DataTable 
    {
        private const string CONST_ENCRYPT_KEY = "21F36BE130844DFAB03355F1C2A7D2B9";
        public SqlBiz()
        {

        }

        

        public SqlBiz(string name)
        {
            this.TableName = name;

            DataColumn SqlKey = Columns.Add("SqlKey", typeof(System.String));
            
            Constraints.Add("SqlKey", SqlKey, true);


            DataColumn sqlContext = Columns.Add("sqlContext", typeof(System.String));


        }

        public string KeyName { get { return "SqlKey"; } }

        public string BizName { get { return TableName; } }
         

        /// <summary>
        /// 获取sql查询内容
        /// </summary>
        /// <param name="sqlKey"></param>
        /// <returns></returns>
        public string GetSqlContext(string sqlKey)
        {
            return GetSqlContext(sqlKey, "");
        }

        public string GetSqlContext(string sqlKey, string defaultSql)
        {
            if (Rows.Count <= 0) return defaultSql;

            string result = this.Rows.Find(sqlKey)["SqlContext"] as string;

            return (string.IsNullOrEmpty(result) ? defaultSql: result);
        }

        public SqlInfo GetSqlInfo(string sqlKey)
        {
            if (Rows.Count <= 0) return null;

            DataRow dr = this.Rows.Find(sqlKey);
            if (dr == null) return null;

            return new SqlInfo(dr["SqlKey"].ToString(), dr["SqlContext"].ToString());
        }

        public void UpdateSql(SqlInfo sqlInfo)
        {
            UpdateSql(sqlInfo.SqlKey, sqlInfo.SqlContext);           
        }

        /// <summary>
        /// 更新Sql
        /// </summary>
        /// <param name="sqlKey"></param>
        /// <param name="sqlContext"></param>
        public void UpdateSql(string sqlKey, string sqlContext)
        {
            DataRow dr = this.Rows.Find(sqlKey);

            if (dr != null)
            {
                dr["SqlContext"] = sqlContext;
            }
            else
            {
                DataRow drNew = this.NewRow();

                drNew["SqlKey"] = sqlKey;
                drNew["SqlContext"] = sqlContext;

                this.Rows.Add(drNew);
            }

        }

        public bool HasSql(string sqlKey)
        {
            return (Rows.Find(sqlKey) == null ? false : true);
        }

        /// <summary>
        /// 移除sql
        /// </summary>
        /// <param name="sqlKey"></param>
        public void RemoveSql(string sqlKey)
        {
            if (Rows.Count <= 0) return;

            DataRow dr = this.Rows.Find(sqlKey);

            if (dr == null) return;

            this.Rows.Remove(dr);
        }

        public void SaveToFile(string fileName)
        {
            //WriteXml(fileName, XmlWriteMode.WriteSchema);

            MemoryStream ms = new MemoryStream();
            WriteXml(ms, XmlWriteMode.WriteSchema);
            ms.Position = 0;

            Encrypt ept = new Encrypt(CONST_ENCRYPT_KEY, false);
            ept.EncryptToFile(ms, fileName);
        }

        public void LoadFromFile(string fileName)
        {
            //ReadXml(fileName);
            Encrypt cpt = new Encrypt(CONST_ENCRYPT_KEY, false);
            MemoryStream ms = cpt.DecryptFromFile(fileName);

            ms.Position = 0;

            ReadXml(ms); 
        }
    }

    public class SqlTabs
    {
        private const string CONST_ENCRYPT_KEY = "21F36BE130844DFAB03355F1C2A7D2B9";


        private DataSet  _sqlDs = null;
        private string _file = "";

        public SqlTabs()
        {
            _sqlDs = new DataSet();

            _file = System.Windows.Forms.Application.StartupPath + @"\sql";
        }

        public DataSet SqlBizs { get { return _sqlDs; } }

        public void LoadFromFile()
        {
            LoadFromFile(_file);
        }

        public void LoadFromFile(string fileName)
        {

            if (File.Exists(fileName + "_list.dat") == false) return;

            DataTable dtList = new DataTable("sqlbizs");


            Encrypt cpt = new Encrypt(CONST_ENCRYPT_KEY, false);
            MemoryStream ms = cpt.DecryptFromFile(fileName + "_list.dat");

            ms.Position = 0;

            dtList.ReadXml(ms); 


            if (dtList.Rows.Count <= 0) return;

            foreach(DataRow dr in dtList.Rows)
            {
                SqlBiz sb = new SqlBiz(dr["业务名称"].ToString());
                sb.LoadFromFile(fileName + "_" + sb.BizName + ".dat");
                _sqlDs.Tables.Add(sb);
            }

        }

        public bool HasBiz(string bizName)
        {
            return (_sqlDs.Tables.IndexOf(bizName) < 0 ? false : true);
        }

        public SqlBiz GetBiz(string bizName)
        {
            if (HasBiz(bizName) == false)
            {
                SqlBiz sb = new SqlBiz(bizName);

                _sqlDs.Tables.Add(sb);
            }

            return _sqlDs.Tables[bizName] as SqlBiz;
        }

        public void RemoveBiz(string bizName)
        {
            _sqlDs.Tables.Remove(bizName);
        }

        public void SaveToFile()
        {
            SaveToFile(_file);
        }

        public void SaveToFile(string fileName)
        {
            DataTable dtList = new DataTable("sqlbizs");
            dtList.Columns.Add("业务名称", typeof(System.String));

            

            foreach (DataTable dtBiz in _sqlDs.Tables)
            {
                SqlBiz sb = dtBiz as SqlBiz;

                sb.SaveToFile(fileName + "_" + sb.BizName + ".dat");

                DataRow drNew = dtList.NewRow();
                drNew["业务名称"] = sb.BizName;
                dtList.Rows.Add(drNew);
            }

            //using (FileStream fs = new FileStream(fileName + "_list.xml", FileMode.Create))
            //{
                MemoryStream ms = new MemoryStream();
                dtList.WriteXml(ms, XmlWriteMode.WriteSchema);
                ms.Position = 0;

                Encrypt ept = new Encrypt(CONST_ENCRYPT_KEY, false);
                ept.EncryptToFile(ms, fileName + "_list.dat");
            //}
        }

        public void ShowManager(IWin32Window owner)
        {
            frmSqlManager sm = new frmSqlManager();
            sm.ShowManager(this, owner);
        }

    }
}
