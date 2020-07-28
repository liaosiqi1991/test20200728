using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using static System.Windows.Forms.Control;

namespace zlMedimgSystem.QueryDesign
{

    /// <summary>
    /// 请求系统参数事件声明
    /// </summary>
    /// <param name="parName"></param>
    /// <returns></returns>
    public delegate object RequestSystemPar(string parName);

    public interface ILinkLayout
    {
        ControlCollection Items { get; }

        Control FindControl(string controlName);
        void RemoveControl(string controlName);

        Control AddInputControl(InputItem ii, string controlName);

        void BeginLayout();

        void EndLayout();
    }

    public class QueryCore
    {
        public const string CONST_USER_CONTROL_TAG = "User_";

        private string _sourceSqlFmt = "";
        private WhereItems _whereItems = null; 


        public event RequestSystemPar OnRequestSystemPar;

        public QueryCore()
        {
            _whereItems = new WhereItems(); 
        }

        public string SourceSqlFmt
        {
            get { return _sourceSqlFmt; }
        }
        public ILinkLayout LinkControl { get; set; }

        public void Clear()
        {
            _whereItems.Clear(); 
        }


        public bool HasInputWhere(string sqlFormat)
        {
            MatchInfos items = QueryHelper.GetMinMatchData(sqlFormat, "[", "]");

            foreach (MatchInfo input in items)
            {
                if (input.MatchContext.Contains(QueryConstDefine.SystemTag) == false) return true;
            }

            return false;
        }

        /// <summary>
        /// 载入sql格式内容
        /// </summary>
        /// <param name="sqlFormatContext"></param>
        public void LoadFromString(string sqlFormatContext)
        {
            Clear();

            if (string.IsNullOrEmpty(sqlFormatContext)) return;

            _sourceSqlFmt = sqlFormatContext;

            MatchInfos whereItems = QueryHelper.GetMinMatchData(sqlFormatContext, "<wi=", "/wi>");

            if (whereItems.Count <= 0)  return;

            

            foreach (MatchInfo whereitem in whereItems)
            {
                WhereItem wi = new WhereItem();
                wi.LoadWhereFromString("<wi=" + whereitem.MatchContext + "/wi>");
                 
                _whereItems.Add(wi.Name, wi, whereitem.StartIndex);
                
            }            
        }

        /// <summary>
        /// 获取录入控件数量
        /// </summary>
        /// <returns></returns>
        public int GetInputCount()
        {
            if (LinkControl == null) return 0;

            int count = 0;
            foreach(Control ctl in LinkControl.Items)
            {
                if (ctl.Name.Contains(CONST_USER_CONTROL_TAG))
                {
                    count = count + 1;
                }
            }

            return count;
        }

        /// <summary>
        /// 同步关联控件
        /// </summary>
        public void SyncLinkControl()
        {
            if (LinkControl == null) return;

            LinkControl.BeginLayout();
            try
            {

                //清理不存在的控件
                for (int i = LinkControl.Items.Count - 1; i >= 0; i--)
                {
                    Control ctl = LinkControl.Items[i];
                    if (ctl.Name.Contains(CONST_USER_CONTROL_TAG) == false) continue;

                    string ctlName = ctl.Name.Replace(CONST_USER_CONTROL_TAG, "");

                    InputItem ii = FindInput(ctlName);

                    if (ii == null)
                    {
                        LinkControl.RemoveControl(ctl.Name);
                    }
                    else
                    {
                        ii.LinkControl = ctl;
                    }
                }

                //新增录入控件
                foreach (WhereItem wi in _whereItems.Values)
                {
                    foreach (InputItem ii in wi.InputItems.Values)
                    {
                        //非系统参数控件创建
                        if (ii.LinkControl == null && ii.Name.Contains(QueryConstDefine.SystemTag) == false)
                        {
                            //判断控件是否存在
                            Control ctlInput = LinkControl.FindControl(CONST_USER_CONTROL_TAG + ii.Name);

                            if (ctlInput != null)
                            {
                                ii.LinkControl = ctlInput;
                                continue;
                            }

                            ctlInput = LinkControl.AddInputControl(ii, CONST_USER_CONTROL_TAG + ii.Name);
                            ii.LinkControl = ctlInput;
                        }
                    }
                }
            }
            finally
            {
                LinkControl.EndLayout();
            }
        }



        /// <summary>
        /// 查找录入项信息
        /// </summary>
        /// <param name="controlName"></param>
        /// <returns></returns>
        private InputItem FindInput(string controlName)
        {
            foreach(WhereItem wi in _whereItems.Values)
            {
                if (wi.InputItems.ContainsKey(controlName) == true) return wi.InputItems[controlName];
            }

            return null;
        }

        /// <summary>
        /// 预览测试SQL
        /// </summary>
        /// <returns></returns>
        public string TestSql()
        {
            string result = _sourceSqlFmt;

            foreach (WhereItem wi in _whereItems.Values)
            {
                string curWhere = wi.Condition;

                MatchInfos inputs = QueryHelper.GetMinMatchData(curWhere, "[", "]");

                foreach (MatchInfo input in inputs)
                {
                    curWhere = curWhere.Replace("[" + input.MatchContext + "]", "null");
                }

                result = result.Replace(wi.SourceFmt, " " + wi.LinkType + " " + curWhere);
            }


            return result;

        }

        public void CreateQuerySql(out string sql, out Dictionary<string, object> pars)
        {
            CreateQuerySql(null, out sql,out pars);
        }

        /// <summary>
        /// 获取查询Sql
        /// </summary>
        /// <param name="sourceSqlFmt"></param>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        public void CreateQuerySql(Dictionary<string, object> attachData, out string sql, out Dictionary<string, object> pars)
        {
            sql = "";
            pars = new Dictionary<string, object>();

            string result = _sourceSqlFmt;
            foreach (WhereItem wi in _whereItems.Values)
            {
                string curWhere = wi.Condition;


                foreach(InputItem ii in wi.InputItems.Values)
                {
                    //获取对应参数
                    string parName = "";
                    object par = null;

                    if (ii.Name.Contains(QueryConstDefine.SystemTag))
                    {
                        //系统参数
                        parName = ii.Name.Replace(QueryConstDefine.SystemTag, "");
                        curWhere = curWhere.Replace("[" + ii.Name + "]", ":" + parName);

                        //优先从指定数据中读取参数
                        if (attachData != null)
                        {
                            if (attachData.ContainsKey(ii.Name)) par = attachData[ii.Name];
                        }

                        if (par == null && OnRequestSystemPar!= null)
                        {
                            par = OnRequestSystemPar(ii.Name);
                        }
                    }
                    else
                    {
                        parName = ii.Name;

                        //优先从指定数据中读取参数
                        if (attachData != null)
                        {
                            if (attachData.ContainsKey(ii.Name)) par = attachData[ii.Name];
                        }

                        if (par == null && ii.LinkControl != null)
                        {
                            par = GetLinkContrlValue(ii);
                        }


                        if (ii.IsWhereReplace)
                        {
                            //[日期类型] between [开始日期] and [结束日期] 替换为如下：
                            //申请日期 between [开始日期] and [结束日期]

                            curWhere = curWhere.Replace("[" + parName + "]", par.ToString());
                        }
                        else
                        {                            
                            curWhere = curWhere.Replace("[" + parName + "]", ":" + parName);
                        }
                    }

                    if (par == null)
                    {
                        curWhere = "";
                        break;
                    }
                    else
                    {
                        if (pars.ContainsKey(parName) == false) pars.Add(parName, par);
                    }
                }

                if (string.IsNullOrEmpty(curWhere))
                {
                    result = result.Replace(wi.SourceFmt, "");
                }
                else
                {
                    result = result.Replace(wi.SourceFmt, " " + wi.LinkType + " " + curWhere);
                }
            }

            sql = FormatQuerySql(result);
        }

        /// <summary>
        /// 获取链接控件的值
        /// </summary>
        /// <param name="ii"></param>
        /// <returns></returns>
        private object GetLinkContrlValue(InputItem ii)
        {

            switch (ii.ControlType)
            {
                case QueryConstDefine.Txt:
                    string textvalue = (ii.LinkControl as TextBox).Text;
                    if (string.IsNullOrEmpty(textvalue)) return null;
                    

                    return textvalue.Split('-')[0];

                case QueryConstDefine.Cbx:
                    string cbxvalue = "";

                    object value = (ii.LinkControl as ComboBox).SelectedValue;
                    if (value != null && value is string)
                    {
                        cbxvalue = value.ToString();
                    }

                    if (string.IsNullOrEmpty(cbxvalue))
                    {
                        cbxvalue = (ii.LinkControl as ComboBox).Text;
                    }

                    if (string.IsNullOrEmpty(cbxvalue)) return null;

                    return cbxvalue.Split('-')[0];

                case QueryConstDefine.Dtp:
                    return (ii.LinkControl as DateTimePicker).Value;

                default:
                    return null;
            }
        }

        /// <summary>
        /// 格式化sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private string FormatQuerySql(string sql)
        {
            //格式化sql语句
            string result = sql;

            Dictionary<string, string> quotes = FormatQuote(ref result);

            result = FormatSpace(result);


            result = FormatWhere(result);


            return RestoreQuote(result, quotes);
                       
        }

        private string FormatWhere(string sql)
        {
            if (string.IsNullOrEmpty(sql)) return "";

            StringBuilder result = new StringBuilder("(" + sql.ToUpper() + ")");
            

            int sourLen = result.Length;
            int newLen = 0;

            result = result.Replace(System.Environment.NewLine, " ");
            result = result.Replace("\r\n", " ");
            result = result.Replace("\n", " ");

            while (sourLen != newLen)
            {
                sourLen = result.Length;

                result = result.Replace("WHERE AND", "WHERE");
                result = result.Replace("WHERE OR", "WHERE");

                result = result.Replace("WHERE )", ")");
                result = result.Replace("WHERE)", ")");

                //group
                result = result.Replace("WHERE GROUP", "GROUP");
                result = result.Replace("OR GROUP", "GROUP");
                result = result.Replace("AND GROUP", "GROUP");

                //order 
                result = result.Replace("WHERE ORDER", "ORDER");
                result = result.Replace("OR ORDER", "ORDER");
                result = result.Replace("AND ORDER", "ORDER");

                //union
                result = result.Replace("WHERE UNION", "UNION");
                result = result.Replace("OR UNION", "UNION");
                result = result.Replace("AND UNION", "UNION");

                //minus
                result = result.Replace("WHERE MINUS", "MINUS");
                result = result.Replace("OR MINUS", "MINUS");
                result = result.Replace("AND MINUS", "MINUS");


                result = result.Replace("( )", " ");
                result = result.Replace("()", " ");

                result = result.Replace("AND )", ")");
                result = result.Replace("OR )", ")");
                result = result.Replace("AND)", ")");
                result = result.Replace("OR)", ")");

                //result = result.Replace(") AND", ")");
                //result = result.Replace(") OR", ")");
                //result = result.Replace(")AND", ")");
                //result = result.Replace(")OR", ")");

                result = result.Replace("( AND", "(");
                result = result.Replace("( OR", "(");
                result = result.Replace("(AND", "(");
                result = result.Replace("(OR", "(");

                //result = result.Replace("AND (", "(");
                //result = result.Replace("OR (", "(");
                //result = result.Replace("AND(", "(");
                //result = result.Replace("OR(", "(");

                result = result.Replace("AND OR", "OR");
                result = result.Replace("OR OR", "OR");
                result = result.Replace("OR AND", "OR");
                result = result.Replace("AND AND", "AND");
                
                result = result.Replace("  ", " ");
                newLen = result.Length;
            }


            return result.ToString().Substring(1, result.Length - 2);
        }

        /// <summary>
        /// 格式化多余的空格
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private string FormatSpace(string sql)
        {
            if (string.IsNullOrEmpty(sql)) return "";

            StringBuilder result = new StringBuilder(sql);

            int sourLen = result.Length;
            int newLen = 0;

            //快速减少空格数量
            while (sourLen != newLen)
            {
                sourLen = result.Length;

                result = result.Replace("        ", " "); 

                newLen = result.Length;
            }

            sourLen = result.Length;
            newLen = 0;

            while (sourLen != newLen)
            {
                sourLen = result.Length; 

                result = result.Replace("  ", " ");

                newLen = result.Length;
            }

            return result.ToString();
        }

        private Dictionary<string, string> FormatQuote(ref string sql)
        {
            if (string.IsNullOrEmpty(sql)) return null;

            Dictionary<string, string> result = new Dictionary<string, string>();

            MatchInfos mis = QueryHelper.GetMinMatchData(sql, "'", "'");

            if (mis.Count <= 0) return null;

            int i = 0;
            StringBuilder sb = new StringBuilder(sql);
            foreach(MatchInfo mi in mis)
            {
                string replace = "?QUOTE" + i.ToString();
                //sql = sql.Replace(mi.MatchContext, replace);
                sb = sb.Replace(mi.MatchContext, replace);
                result.Add(mi.MatchContext, replace);

                i = i + 1;
            }

            sql = sb.ToString();

            return result;
        }
        
        /// <summary>
        /// 恢复查询中的单引号
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="quotes"></param>
        /// <returns></returns>
        private string RestoreQuote(string sql, Dictionary<string, string> quotes)
        {
            if (string.IsNullOrEmpty(sql)) return "";
            if (quotes == null || quotes.Count <= 0) return sql;

            StringBuilder result = new StringBuilder(sql);

            foreach(string key in quotes.Keys)
            {
                result = result.Replace(quotes[key], key);
            }

            return result.ToString();
        }
        
    }
}
