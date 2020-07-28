using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using zlMedimgSystem.SqlManager;

namespace zlMedimgSystem.DataModel
{
    public delegate object QueryParValueEvent(string parName);


    public class JsonFieldPro
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName = "";

        /// <summary>
        /// 数据转换项配置
        /// </summary>
        public Dictionary<string, string> ConvertItems = null;

        /// <summary>
        /// 当在ConvertItems中未找到且othervalue不为空时，则使用othervalue的值，
        /// </summary>
        public string OtherValue = "";

        public JsonFieldPro()
        {
            ConvertItems = new Dictionary<string, string>();
        }
    }

    public class JsonFieldMapItem:List<JsonFieldPro>
    {
        /// <summary>
        /// 节点路径,如果节点为空，说明表示直接读取该层下的数据
        /// </summary>
        public string NodePath = "";

        public string JsonField = "";
    }

    static public class SqlHelper
    {
        struct MatchInfo
        {
            public string MatchContext;
            public int StartIndex;

            public MatchInfo(string matchContext, int startIndex)
            {
                MatchContext = matchContext;
                StartIndex = startIndex;
            }

        }

        class MatchInfos : List<MatchInfo>
        {
            public bool Contains(string context)
            {
                foreach (MatchInfo mi in this)
                {
                    if (mi.MatchContext.Equals(context)) return true;
                }

                return false;
            }
        }

        static private ServerManager _sm = null;

        static public class Statement
        {
            /// <summary>
            /// sql:Select 角色ID,科室ID,窗体ID,角色名称,分组标记,角色信息 From 影像角色信息 where 科室ID=:科室ID  order by 分组标记, 角色名称
            /// </summary>
            static public SQL 角色信息查询
            {
                get
                {
                    return CreateSQL("角色信息查询",
                        "Select 角色ID,科室ID,窗体ID,角色名称,分组标记,角色信息 From 影像角色信息 where 科室ID=:科室ID  order by 分组标记, 角色名称");
                }
            }

            /// <summary>
            /// sql:Select 科室ID,科室名称 From 影像科室信息 order by 科室名称
            /// </summary>
            static public SQL 科室信息查询
            {
                get
                {
                    return CreateSQL("科室信息查询",
                        "Select 科室ID,科室名称 From 影像科室信息 order by 科室名称");
                }
            }

            /// <summary>
            /// sql:Select 窗体ID,科室ID,窗体名称,分组标记,窗体信息 From 影像窗体信息 order by 窗体名称
            /// </summary>
            static public SQL 窗体信息查询
            {
                get
                {
                    return CreateSQL("窗体信息查询",
                        "Select 窗体ID,科室ID,窗体名称,分组标记,版本, 窗体信息 From 影像窗体信息 where 科室ID=:科室ID order by 窗体名称");
                }
            }

            static public SQL 字典信息查询
            {
                get
                {
                    return CreateSQL("影像类别查询", "select 字典信息 from 影像字典信息 where 字典名称=:字典名称");
                }

            }
        }

        static private SqlTabs _sqlManager = null;

        static SqlHelper()
        {
            _sqlManager = new SqlTabs();
            _sqlManager.LoadFromFile();
        }

        static public object Nvl(object value, object defaultValue)
        {
            return (value == null) ? defaultValue : value;
        }

        static public int Nvl(object value, int defaultValue)
        {
            return (value == null || string.IsNullOrEmpty(value.ToString().Trim())) ? defaultValue : Convert.ToInt32(value);
        }

        static public string Nvl(object value, string defaultValue)
        {
            return (value == null || string.IsNullOrEmpty(value.ToString().Trim())) ? defaultValue : Convert.ToString(value);
        }

        static public bool Nvl(object value, bool defaultValue)
        {
            return (value == null || string.IsNullOrEmpty(value.ToString().Trim())) ? defaultValue : Convert.ToBoolean(value);
        }

        static public double Nvl(object value, double defaultValue)
        {
            return (value == null || string.IsNullOrEmpty(value.ToString().Trim())) ? defaultValue : Convert.ToDouble(value);
        }

        static public SqlBiz GetSqlBiz(string bizName)
        {
            return _sqlManager.GetBiz(bizName);
        }

        static public SqlBiz GetSqlBiz()
        {
            return _sqlManager.GetBiz(AppDomain.CurrentDomain.FriendlyName);
        }

        static public string CreateSQLStr(string key, string sqlSource)
        {
            return GetSqlBiz().GetSqlContext(key, sqlSource);
        }

        #region<CreateSql>

        static public SQL CreateSql(string sqlSource)
        {
            return CreateSQL("", sqlSource, null, null);
        }

        static public SQL CreateSql(string sqlSource, IDBQuery dbHelper)
        {
            return CreateSQL("", sqlSource, null, dbHelper);
        }

        static public SQL CreateSql(string sqlSource, SqlParamInfo[] sqlPars, IDBQuery dbHelper)
        {
            return CreateSQL("", sqlSource, sqlPars, dbHelper);
        }

        static public SQL CreateSql(string sqlSource, SqlParamInfo[] sqlPars)
        {
            return CreateSQL("", sqlSource, sqlPars, null);
        }

        /// <summary>
        /// 创建SQL
        /// </summary>
        /// <param name="key"></param>
        /// <param name="sqlSource"></param>
        /// <returns></returns>
        static public SQL CreateSQL(string key, string sqlSource)
        {
            return CreateSQL(key, sqlSource, null, null);
        }

        static public SQL CreateSQL(string key, string sqlSource, IDBQuery dbHelper)
        {
            return CreateSQL(key, sqlSource, null, dbHelper);
        }

        /// <summary>
        /// 创建SQL
        /// </summary>
        /// <param name="key"></param>
        /// <param name="sqlSource"></param>
        /// <param name="sqlPars"></param>
        /// <returns></returns>
        static public SQL CreateSQL(string key, string sqlSource, SqlParamInfo[] sqlPars)
        {
            return CreateSQL(key, sqlSource, sqlPars, null) ;
        }

        static public SQL CreateSQL(string key, string sqlSource, SqlParamInfo[] sqlPars, IDBQuery dbHelper)
        {
            SQL sql = null;

            if (string.IsNullOrEmpty(key))
            {
                sql = new SQL(key, sqlSource, sqlPars, dbHelper);
            }
            else
            {
                string sqlStatement = GetSqlBiz().GetSqlContext(key, sqlSource);
                sql = new SQL(key, sqlStatement, sqlPars, dbHelper);
            }

            return sql;
        }

        #endregion

        /// <summary>
        /// 获取格式化后的UID
        /// </summary>
        /// <returns></returns>
        static public string GetFmtUID()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 获取压缩后的UID
        /// </summary>
        /// <returns></returns>
        static public string GetCmpUID()
        {
            string b64 = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            while(!Char.IsLetterOrDigit(b64[0]))
            {
                //首字母如果是特殊字符，则需要重新获取
                b64 = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            }
            //如果用cuid作为目录名称，在linux下需要将"/"替换为"_",为保证名称容易识别，需要将"l"替换为"."，"O"替换为"="
            return b64.Replace("=", "").Replace("/", "_").Replace("l", ".").Replace("O","=");
        }

        /// <summary>
        /// 获取数字型uid
        /// </summary>
        /// <returns></returns>
        static public string GetNumGuid()
        {
            //long result = 0;

            //byte[] bytUid = Guid.NewGuid().ToByteArray();

            //for (int i = 15; i >= 0; i--)
            //{
            //    long pow = (long)(bytUid[i] + 1000) * (long)Math.Pow(10, i+1);
            //    result = result + pow;
            //}

            //return result.ToString();

            return Guid.NewGuid().ToString("N").ToUpper();
        }

        /// <summary>
        /// 获取dicom标准的UID形式,如1.2.840.xxx
        /// </summary>
        /// <returns></returns>
        static public string GetDcmUID(string classTag = "1")
        {
            DateTime dtNow = DateTime.Now;

            byte[] byteUid = Guid.NewGuid().ToByteArray();

            return "1.2.840."   //+"023.81398839."
                    + classTag + "."
                    + dtNow.ToString("yy") + dtNow.DayOfYear.ToString() + "."
                    + BitConverter.ToUInt64(byteUid, 8).ToString() + "."
                    + BitConverter.ToUInt64(byteUid, 0).ToString();

        }

        public const string SysFixPars = "申请识别码,患者识别码,申请ID,患者ID,患者姓名,用户ID,用户名称,设备ID,设备名称,房间ID,房间名称,科室ID,科室对照编码,科室名称,院区编码,本地日期,服务器日期,本机IP,本机名称";

        static public string SqlParsToNull(string sourceSql, string pars, char splitChar = ',')
        {
            StringBuilder result = new StringBuilder(sourceSql);

            string[] aryPars = pars.Split(splitChar);

            foreach(string par in aryPars)
            {
                result = result.Replace("[" + par + "]", "null").Replace("[系统_" + par + "]", "null");
            }


            return result.ToString();
        }

        static public string SqlParsToReplaceParName(string sourceSql, string pars, char splitChar = ',')
        {
            StringBuilder result = new StringBuilder(sourceSql);

            string[] aryPars = pars.Split(splitChar);

            foreach (string par in aryPars)
            {
                result = result.Replace("[" + par + "]", ":" + par).Replace("[系统_" + par + "]", ":" + par);
            }


            return result.ToString();
        }

        static public Dictionary<string, IDBQuery> _thridDbBuffer = null;
        static public IDBQuery GetThridDBHelper(string dbServerAlias, IDBQuery dbSys, ref string strErr, bool blnForceRefresh = false)
        {
            strErr = "";

            if (string.IsNullOrEmpty(dbServerAlias))
            {
                return dbSys;
            }

            if (_thridDbBuffer == null)
            {
                _thridDbBuffer = new Dictionary<string, IDBQuery>();
            }

            if (blnForceRefresh)
            {
                //如果是强制刷新，则先移除缓存对象
                if (_thridDbBuffer.ContainsKey(dbServerAlias)) _thridDbBuffer.Remove(dbServerAlias);
            }

            if (_thridDbBuffer.ContainsKey(dbServerAlias))
            {
                return _thridDbBuffer[dbServerAlias];
            }
            else
            {

                SQL sql = CreateSQL("查询三方数据源信息", "Select 数据源ID, 数据源别名,数据源信息 From 影像数据源信息 where 数据源别名=:数据源别名");
                sql.AddParameter("数据源别名", DbType.String, dbServerAlias);

                DataTable dtThridDb = dbSys.ExecuteSQL(sql);
                if (dtThridDb == null || dtThridDb.Rows.Count <= 0) return dbSys;

                ThridDBSourceData thridDbSource = new ThridDBSourceData();
                thridDbSource.BindRowData(dtThridDb.Rows[0]);


                IDBProvider dbProvider = ServerEnum.GetDBProvider(thridDbSource.数据源信息.驱动文件);
                if (dbProvider == null)
                {
                    strErr = "数据访问实例 [" + thridDbSource.数据源信息.驱动文件 + "] 创建失败，将返回默认数据提供对象。";
                    return null;
                }


                dbProvider.Init(thridDbSource.数据源信息.服务器IP, thridDbSource.数据源信息.端口, thridDbSource.数据源信息.数据实例,
                                thridDbSource.数据源信息.授权账号, ThridDBSourceModel.DecryPwd(thridDbSource.数据源信息.授权密码));

                IDbConnection dc = dbProvider.Open(ref strErr);

                if (dc == null)
                {
                    strErr = "数据服务访问失败：" + strErr;
                    return null;
                }

                //缓存有效的数据源链接对象
                if (dbProvider != null) _thridDbBuffer.Add(dbServerAlias, dbProvider);

                return dbProvider;
            }
        }

        static public IDBQuery GetLocalDBHelper(string dbServerAlias, IDBQuery dbSys, ref string strErr)
        {
            strErr = "";

            if (string.IsNullOrEmpty(dbServerAlias))
            {
                return dbSys;
            }
            
            if (_sm == null)
            {
                _sm = new ServerManager();
                _sm.LoadFromFile();
            }

            ServerInfo si = _sm.FindAlias(dbServerAlias);


            if (si == null)
            {
                strErr = "未找到对应的服务器配置信息。";
                return null;
            }

            if (string.IsNullOrEmpty(si.ServerDriverFile))
            {
                strErr = "未配置数据访问程序集。";
                return null;
            }

            IDBProvider dbProvider = ServerEnum.GetDBProvider(si.ServerDriverFile);
            if (dbProvider == null) 
            {
                strErr = "数据访问实例 [" + si.ServerDriverFile + "] 创建失败。";
                return null;
            }


            dbProvider.Init(si.ServerIP, si.ServerPort, si.ServerInstance, si.GrantAccount, si.GrantPwd);

            IDbConnection dc = dbProvider.Open(ref strErr);

            if (dc == null)
            {
                strErr = "数据服务访问失败：" + strErr;
                return null;
            }

            return dbProvider;
        }

        static private MatchInfos GetMinMatchData(string source, string startMatch, string endMatch,
            char exceptSChr, char exceptEChr)
        {

            MatchInfos result = new MatchInfos();

            string rStart = "<";
            string rEnd = ">";

            if (rStart == startMatch) rStart = "(";
            if (rEnd == endMatch) rEnd = ")";

            MatchCollection mc = null;
            if ((exceptSChr != '\0') && (exceptEChr != '\0'))
            {
                mc = Regex.Matches(source, "[\\" + exceptSChr + "](.*?)[\\" + exceptEChr + "]");

                for (int i = 0; i <= mc.Count - 1; i++)
                {
                    source = source.Replace(mc[i].Value, rStart + "@" + i + "/" + rEnd);
                }
            }

            string tmp = source;

            int startMatchLen = startMatch.Length;
            int endMatchLen = endMatch.Length;

            int indexStart = tmp.IndexOf(startMatch);
            if (indexStart < 0) return result;//没有匹配项，则直接退出

            int indexEnd = tmp.IndexOf(endMatch);
            int indexNext = tmp.IndexOf(startMatch, indexStart + startMatchLen);

            if (indexNext <= 0) indexNext = tmp.Length;

            while (indexStart >= 0)
            {
                if (indexStart >= 0 && indexEnd > 0 && indexEnd > indexStart && indexEnd < indexNext)//满足[xxx]这种形式，过滤[xxx[bbb]这种形式
                {
                    string context = tmp.Substring(indexStart + startMatchLen, indexEnd - indexStart - startMatchLen);

                    if (mc != null && context.IndexOf("<@") >= 0)
                    {
                        for (int i = 0; i <= mc.Count - 1; i++)
                        {
                            context = context.Replace(rStart + "@" + i + "/" + rEnd, mc[i].Value);
                        }
                    }

                    result.Add(new MatchInfo(context, indexStart));

                    tmp = tmp.Substring(indexEnd + endMatchLen);

                }
                else
                {
                    tmp = tmp.Substring(indexStart + startMatchLen);
                }

                if (tmp.Length <= 0) break;

                indexStart = tmp.IndexOf(startMatch);
                indexEnd = tmp.IndexOf(endMatch);

                indexNext = tmp.IndexOf(startMatch, (indexStart < 0) ? 0 : indexStart + startMatchLen);

                if (indexNext <= 0) indexNext = tmp.Length;
            }

            return result;

        }


        /// <summary>
        /// 获取sql中包含的参数，sql中的参数形式为[xxx]样式
        /// </summary>
        /// <param name="sourceSql"></param>
        /// <param name="splitChar"></param>
        /// <returns>返回获取到的参数字符串，返回形式为:参数1,参数2,参数3...</returns>
        static public string GetSqlPars(string sourceSql, string splitChar = ",")
        {
            MatchInfos matchs = GetMinMatchData(sourceSql, "[", "]", '\'', '\'');

            string result = "";

            foreach(MatchInfo mi in matchs)
            {
                if (string.IsNullOrEmpty(result) == false) result = result + splitChar;
                result = result + mi.MatchContext;
            }
            return result;
        }

        /// <summary>
        /// 测试查询
        /// </summary>
        static public DataTable TestSql(IDBQuery sysDB, string strTestSql, string pars, string dbAlias, IWin32Window owner)
        {
            try
            {
                string strSql = strTestSql;//.ToUpper();

                strSql = SqlParsToNull(strSql, pars);

                int jsonTagIndex = strSql.IndexOf("<json", StringComparison.CurrentCultureIgnoreCase);
                if (jsonTagIndex > 0)
                {
                    //<JSON:患者信息 = 姓名,性别,年龄,住院号,门诊号 />
                    string jsonContext = "";
                    int jsonTagEnd = strSql.IndexOf("/json>", jsonTagIndex);

                    while (jsonTagEnd > jsonTagIndex)
                    {
                        jsonContext = strSql.Substring(jsonTagIndex, jsonTagEnd - jsonTagIndex + 6);

                        int curEqusIndex = jsonContext.IndexOf("=");
                        int curColonIndex = jsonContext.IndexOf(":");
                        int curEndIndex = jsonContext.IndexOf("/json>");

                        string fieldName = jsonContext.Substring(curColonIndex + 1, curEqusIndex - curColonIndex - 1);

                        if (fieldName.IndexOf(@"/") >= 0)
                        {
                            fieldName = fieldName.Split('/')[0]; 
                        }

                        string fields = jsonContext.Substring(curEqusIndex + 1, curEndIndex - curEqusIndex - 1);

                        fields = fields.Replace(",", ",'' as ");
                        fields = "'' as " + fields;


                        //strSql = strSql.Replace(jsonContext, fieldName);
                        strSql = strSql.Replace(jsonContext, fields);

                        jsonTagEnd = -1;
                        jsonTagIndex = strSql.IndexOf("<json", StringComparison.CurrentCultureIgnoreCase);
                        if (jsonTagIndex > 0)
                        {
                            jsonTagEnd = strSql.IndexOf("/json>", jsonTagIndex);
                        }
                    }
                }

                string strErr = "";
                //获取三方数据源提供程序
                IDBQuery curHelper = null;

                if (string.IsNullOrEmpty(dbAlias))
                {
                    curHelper = sysDB;
                }
                else
                {
                    curHelper = SqlHelper.GetThridDBHelper(dbAlias, sysDB, ref strErr);
                }


                if (curHelper == null)
                {
                    MessageBox.Show(strErr, "提示");
                    return null;
                }

                curHelper.TransactionBegin();

                try
                {
                    return curHelper.ExecuteSQL(strSql);
                }
                finally
                {
                    curHelper.TransactionRollback();
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, owner);
                return null;
            }
        }



        static public void JsonTableDataConvert(DataTable dtBind, int startRow, Dictionary<string, JsonFieldMapItem> jsonFieldMap, int batSize = 100)
        {

            if (jsonFieldMap == null || jsonFieldMap.Count <= 0) return;

            if (dtBind.Columns.Contains("#CONV#") == false)
            {
                foreach (JsonFieldMapItem curJsonField in jsonFieldMap.Values)
                {
                    DataColumn dc = null;

                    if (string.IsNullOrEmpty(curJsonField.NodePath))
                    {
                        dc = dtBind.Columns[curJsonField.JsonField];
                    }
                    else
                    {
                        dc = dtBind.Columns[curJsonField.NodePath.Replace("/", "_")];
                    }


                    foreach (JsonFieldPro jsonField in curJsonField)
                    {
                        DataColumn dcJF = dtBind.Columns.Add(jsonField.FieldName, typeof(string));

                        dcJF.SetOrdinal(dc.Ordinal - 1);
                    }

                    dc.ColumnMapping = MappingType.Hidden;

                }

                DataColumn dcNew = new DataColumn("#CONV#", typeof(byte));
                dcNew.ColumnMapping = MappingType.Hidden;
                dcNew.DefaultValue = 0;

                dtBind.Columns.Add(dcNew);
            }

            int endRow = startRow + batSize;


            JsonLoadSettings jsLoadSet = new JsonLoadSettings();
            jsLoadSet.CommentHandling = CommentHandling.Ignore;
            //jsLoadSet.LineInfoHandling = LineInfoHandling.Ignore;

            for (int i = startRow; i < endRow; i++)
            {
                if (i >= dtBind.Rows.Count) return;

                DataRow dr = dtBind.Rows[i];

                if (SqlHelper.Nvl(dr["#CONV#"], 0) != 0) continue;

                foreach ( JsonFieldMapItem kv in jsonFieldMap.Values)
                {
                    JObject jData = JObject.Parse(dr[kv.JsonField].ToString(), jsLoadSet);
         

                    if (string.IsNullOrEmpty(kv.NodePath) == false && kv.NodePath.IndexOf('/') >= 0)
                    {
                        string[] paths = kv.NodePath.Split('/');
                        for (int pindex = 1; pindex < paths.Length; pindex++)
                        {
                            jData = jData[paths[pindex]] as JObject;
                        }
                    }

                    foreach (JsonFieldPro jsonF in kv)
                    {
                        if (jsonF.ConvertItems.Count <= 0)
                        {
                            dr[jsonF.FieldName] = jData[jsonF.FieldName].ToString();
                        }
                        else
                        {
                            string value = Convert.ToString(jData[jsonF.FieldName]);
                            if (jsonF.ConvertItems.ContainsKey(value))
                            {
                                dr[jsonF.FieldName] = jsonF.ConvertItems[value];
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(jsonF.OtherValue))
                                {
                                    dr[jsonF.FieldName] = value;
                                }
                                else
                                {
                                    dr[jsonF.FieldName] = jsonF.OtherValue;
                                }
                            }
                        }

                    }
                }

                dr["#CONV#"] = 1;
            }
        }

        static public void JsonRowDataConvert(DataRow drConvert, Dictionary<string, JsonFieldMapItem> jsonFieldMap)
        {
            DataTable dtBind = drConvert.Table;
            if (drConvert.Table.Columns.Contains("#CONV#") == false)
            {       
                foreach (JsonFieldMapItem curJsonField in jsonFieldMap.Values)
                {
                    DataColumn dc = null;

                    if (string.IsNullOrEmpty(curJsonField.NodePath))
                    {
                        dc = dtBind.Columns[curJsonField.JsonField];
                    }
                    else
                    {
                        dc = dtBind.Columns[curJsonField.NodePath.Replace("/", "_")];
                    }


                    foreach (JsonFieldPro jsonField in curJsonField)
                    {
                        DataColumn dcJF = dtBind.Columns.Add(jsonField.FieldName, typeof(string));

                        dcJF.SetOrdinal(dc.Ordinal - 1);
                    }

                    dc.ColumnMapping = MappingType.Hidden;

                }

                DataColumn dcNew = new DataColumn("#CONV#", typeof(byte));
                dcNew.ColumnMapping = MappingType.Hidden;
                dcNew.DefaultValue = 0;

                dtBind.Columns.Add(dcNew);
            }

            if (SqlHelper.Nvl(drConvert["#CONV#"], 0) != 0) return;

            JsonLoadSettings jsLoadSet = new JsonLoadSettings();
            jsLoadSet.CommentHandling = CommentHandling.Ignore;

            foreach (JsonFieldMapItem  kv in jsonFieldMap.Values)
            {
                JObject jData = JObject.Parse(drConvert[kv.JsonField].ToString(), jsLoadSet);
                
                if (string.IsNullOrEmpty(kv.NodePath) == false && kv.NodePath.IndexOf('/') >= 0)
                {
                    string[] paths = kv.NodePath.Split('/');
                    for (int pindex = 1; pindex < paths.Length; pindex++)
                    {
                        jData = jData[paths[pindex]] as JObject;
                    }
                }

                foreach (JsonFieldPro jsonF in kv)
                {
                    if (jsonF.ConvertItems.Count <= 0)
                    {
                        drConvert[jsonF.FieldName] = jData[jsonF.FieldName].ToString();
                    }
                    else
                    {
                        string value = Convert.ToString(jData[jsonF.FieldName]);
                        if (jsonF.ConvertItems.ContainsKey(value))
                        {
                            drConvert[jsonF.FieldName] = jsonF.ConvertItems[value];
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(jsonF.OtherValue))
                            {
                                drConvert[jsonF.FieldName] = value;
                            }
                            else
                            {
                                drConvert[jsonF.FieldName] = jsonF.OtherValue;
                            }
                        }
                    }

                }
            }

            drConvert["#CONV#"] = 1;
        }

        static public string FmtJsonDb(string strSourceSql, out Dictionary<string, JsonFieldMapItem> jsonFileds)
        {
            //< JSON:患者信息 = 姓名,性别,年龄,住院号,门诊号 />
            jsonFileds = new Dictionary<string, JsonFieldMapItem>();

            string strSql = strSourceSql;

            int jsonTagIndex = strSql.IndexOf("<json", StringComparison.CurrentCultureIgnoreCase);

            if (jsonTagIndex <= 0) return strSql;

            string jsonContext = "";

            int jsonTagEnd = strSql.IndexOf("/json>", jsonTagIndex, StringComparison.CurrentCultureIgnoreCase);
             
            while (jsonTagEnd > jsonTagIndex)
            {
                jsonContext = strSql.Substring(jsonTagIndex, jsonTagEnd - jsonTagIndex + 6);
                string sourceFieldName = jsonContext.Substring(jsonContext.IndexOf(":") + 1, jsonContext.IndexOf("=") - jsonContext.IndexOf(":") - 1);

                string key = sourceFieldName;//取消a.申请信息中的a.字符
                if (key.IndexOf(".") >= 0)
                {
                    key = key.Split('.')[1];
                }

                string path = key;

                key = key.Replace("/", "_");

                string jsonFieldName = sourceFieldName;
                

                if (jsonFieldName.IndexOf(@"/") >= 0)
                {
                    jsonFieldName = jsonFieldName.Split('/')[0];

                    strSql = strSql.Replace(jsonContext, "Null as " + key);
                }
                else
                {
                    path = "";//如果不含“/”字符，则路径为空
                    strSql = strSql.Replace(jsonContext, jsonFieldName);
                }
                 

                string fields = jsonContext.Substring(jsonContext.IndexOf("=") + 1, jsonContext.IndexOf("/json>",StringComparison.CurrentCultureIgnoreCase) - jsonContext.IndexOf("=") - 1);

                string[] field = fields.Split(',');

                if (field.Length > 0)
                {
                    JsonFieldMapItem jfields = new JsonFieldMapItem();
                    jfields.NodePath = path;

                    if (jsonFieldName.IndexOf(".") >= 0)
                    {
                        jsonFieldName = jsonFieldName.Split('.')[1];
                    }

                    jfields.JsonField = jsonFieldName;

                    foreach (string fName in field)
                    {
                        //性别(0-男|1-女|2-未知|-未明)
                        int proIndex = fName.IndexOf("(");

                        JsonFieldPro jfp = new JsonFieldPro(); 

                        if (proIndex >= 0)
                        {
                            string fPro = fName.Substring(proIndex + 1, fName.IndexOf(")") - proIndex - 1);

                            jfp.FieldName = fName.Substring(0, proIndex);

                            foreach (string conv in (fPro + "|").Split('|'))
                            {
                                if (string.IsNullOrEmpty(conv)) continue;

                                string[] convalue = (conv + "-").Split('-');

                                if (string.IsNullOrEmpty(convalue[0]))
                                {
                                    jfp.OtherValue = convalue[1];
                                }
                                else
                                {
                                    jfp.ConvertItems.Add(convalue[0], convalue[1]);
                                }

                            }
                        }
                        else
                        {
                            jfp.FieldName = fName;
                        }

                        jfields.Add(jfp);
                    }


                    jsonFileds.Add(key, jfields);
                }

                jsonTagEnd = -1;
                jsonTagIndex = strSql.IndexOf("<json", StringComparison.CurrentCultureIgnoreCase);
                if (jsonTagIndex > 0)
                {
                    jsonTagEnd = strSql.IndexOf("/json>", jsonTagIndex, StringComparison.CurrentCultureIgnoreCase);
                }
            }             

            return strSql;
        }

        static public object GetGeneralParValue(string parName, IDBQuery dbQuery, ILoginUser userData, IStationInfo stationinfo)
        {

            //申请识别码,患者识别码,申请ID,患者ID,患者姓名,
            //用户ID,用户名称,设备ID,设备名称,房间ID,房间名称,科室ID,科室名称,院区编码,本地日期,服务器日期,本机IP,本机名称

            switch (parName)
            {
                case "系统_科室ID": return stationinfo.DepartmentId;
                case "系统_科室名称": return stationinfo.DepartmentName;
                case "系统_房间ID": return stationinfo.RoomId;
                case "系统_房间名称": return stationinfo.RoomName;
                case "系统_设备ID": return stationinfo.DeviceId;
                case "系统_设备名称": return stationinfo.DeviceName;
                case "系统_用户ID": return userData.UserId;
                case "系统_用户名称": return userData.Name;
                case "系统_用户账号": return userData.Account;
                case "系统_院区编码": return stationinfo.DistrictCode;
                case "系统_本地日期": return DateTime.Now;
                case "系统_本机名称": return Dns.GetHostName();
                case "系统_本机IP": return System.Net.Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
                case "系统_服务器日期":
                    {
                        DBModel dmDate = new DBModel(dbQuery);
                        return dmDate.GetServerDate();
                    }

                default:
                    return null;
            }


        }
        


        static public  DataSet GetReportDataSource(IList<JReportTemplateQuery> dataSource, IDBQuery dbSys, QueryParValueEvent queryEvent = null)
        {
            if (dataSource == null) return null;
            if (dataSource.Count <= 0) return null;

            DataSet dsReport = new DataSet("报告数据集");

            foreach (JReportTemplateQuery ds in dataSource)
            {
                DataTable dt = GetDataSource(ds.查询内容, ds.数据源别名, dbSys, queryEvent);

                dt.TableName = ds.查询名称;

                DataTable dtBind = new DataTable(ds.查询名称);
                dtBind.Columns.Add("ID", typeof(string));
                dtBind.Columns.Add("DisplayName", typeof(string));
                dtBind.Columns.Add("Value", typeof(string));

                foreach (DataColumn dc in dt.Columns)
                {
                    DataRow drNew = dtBind.NewRow();
                    drNew["DisplayName"] = dc.ColumnName;

                    if (dt.Rows.Count > 0) drNew["Value"] = dt.Rows[0][dc.ColumnName].ToString();

                    dtBind.Rows.Add(drNew);                                        
                }

                dsReport.Tables.Add(dtBind);
            }

            return dsReport;
        }


        static public DataTable GetDataSource(string sql, IDBQuery dbHelper, QueryParValueEvent queryEvent = null)
        {
            if (string.IsNullOrEmpty(sql)) return null;
            if (dbHelper == null) return null;

            

            string pars = GetSqlPars(sql);

            string strSql = "";
            if (queryEvent == null)
            {
                strSql = SqlHelper.SqlParsToNull(sql, pars);
            }
            else
            {
                strSql = SqlHelper.SqlParsToReplaceParName(sql, pars);
            }

            Dictionary<string, JsonFieldMapItem> jsonField = null;

            strSql = FmtJsonDb(strSql, out jsonField);

            DataTable dt = new DataTable();


            List<SqlParamInfo> sqlPars = null;
            if (queryEvent != null)
            {
                sqlPars = new List<SqlParamInfo>();
                //配置查询参数
                foreach (string curPar in pars.Split(','))
                {
                    object parValue = queryEvent(curPar);

                    if (parValue != null)
                    {
                        if (parValue is DateTime)
                        {
                            sqlPars.Add(new SqlParamInfo(curPar, DbType.DateTime, parValue));
                        }
                        else if (parValue is int)
                        {
                            sqlPars.Add(new SqlParamInfo(curPar, DbType.Int64, parValue));
                        }
                        else if (parValue is double)
                        {
                            sqlPars.Add(new SqlParamInfo(curPar, DbType.Double, parValue));
                        }
                        else if (parValue is string)
                        {
                            sqlPars.Add(new SqlParamInfo(curPar, DbType.String, parValue));
                        }
                        else
                        {
                            sqlPars.Add(new SqlParamInfo(curPar, DbType.String, parValue));
                        }
                    }
                    else
                    {
                        sqlPars.Add(new SqlParamInfo(curPar, DbType.String, null));
                    }
                }
            }

            if (sqlPars != null)
            {
                dt = dbHelper.ExecuteSQL(strSql, sqlPars.ToArray());
            }
            else
            {
                dt = dbHelper.ExecuteSQL(strSql);
            }

            if (jsonField.Count <= 0) return dt;
            
            SqlHelper.JsonTableDataConvert(dt, 0, jsonField, dt.Rows.Count); 

            return dt;
        }

        static public DataTable GetDataSource(string sql, string dbAlias, IDBQuery dbSys, QueryParValueEvent queryEvent = null)
        {
            if (string.IsNullOrEmpty(sql)) return null;

            string strErr = "";
            IDBQuery curHelper = SqlHelper.GetThridDBHelper(dbAlias, dbSys, ref strErr);

            if (curHelper != null)
            {
                return GetDataSource(sql, curHelper, queryEvent); 
            }
            else
            {
                DialogResult dr = MessageBox.Show("数据源 [ " + dbAlias + "] 链接失败，失败信息：" + System.Environment.NewLine
                    + "    " + strErr, "提示");

                return null;
            } 
        }


        static public DataTable GetDataSource(string sql, string dbAlias, IDBQuery dbSys, List<SqlParamInfo> parValues)
        {
            if (string.IsNullOrEmpty(sql)) return null;

            string strSql = "";
            if (parValues == null)
            {
                string pars = GetSqlPars(sql);
                strSql = SqlHelper.SqlParsToNull(sql, pars);
            }
            else
            {
                strSql = sql;
                foreach (SqlParamInfo spi in parValues)
                {
                    string sqlParName = spi.Name;
                    sqlParName = "[" + sqlParName + "]";

                    strSql = strSql.Replace(sqlParName, ":" + spi.Name);                     
                }
            }

            Dictionary<string, JsonFieldMapItem> jsonField = null;

            strSql = FmtJsonDb(strSql, out jsonField);

            DataTable dt = new DataTable();

            string strErr = "";
            IDBQuery curHelper = SqlHelper.GetThridDBHelper(dbAlias, dbSys, ref strErr);
            if (curHelper != null)
            {
                if (parValues != null)
                {
                    dt = curHelper.ExecuteSQL(strSql, parValues.ToArray());
                }
                else
                {
                    dt = curHelper.ExecuteSQL(strSql);
                }

                if (jsonField.Count <= 0) return dt;
                
                SqlHelper.JsonTableDataConvert(dt, 0, jsonField, dt.Rows.Count);
                
                return dt;
            }
            else
            {
                DialogResult dr = MessageBox.Show("数据源 [ " + dbAlias + "] 链接失败，失败信息：" + System.Environment.NewLine
                    + "    " + strErr, "提示");

                return null;
            }
        }

        /// <summary>
        /// 图像转二进制
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        static public byte[] ImageToBinary(Image img)
        {
            if (img == null) return null;

            //将Image转换成流数据，并保存为byte[] 
            using (MemoryStream mstream = new MemoryStream())
            {
                img.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);

                byte[] byData = new Byte[mstream.Length];
                mstream.Position = 0;
                mstream.Read(byData, 0, byData.Length);
                mstream.Close();

                return byData;
            }

        }

        /// <summary>
        /// 二进制转图像
        /// </summary>
        /// <param name="imgBytes"></param>
        /// <returns></returns>
        static public Image BinaryToImage(byte[] imgBytes)
        {
            if (imgBytes == null || imgBytes.Length <= 0) return null;

            //using (MemoryStream ms = new MemoryStream(imgBytes)) //ms释放后，会造成image.save产生gdi错误
            using (MemoryStream ms = new MemoryStream(imgBytes))
            {
                ms.Position = 0;

                using (Image newImg = Image.FromStream(ms))
                {
                    return new Bitmap(newImg);
                }
            }
        }
    }
}
