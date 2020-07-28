using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.QueryDesign
{
 
    public static class QueryConstDefine
    {
        public const string Txt = "文本框";
        public const string Cbx = "下拉框";
        public const string Dtp = "日期框";
        public const string List = "列表框";
        public const string ChkBox = "下拉勾选框";
        public const string ChkList = "列表勾选框";



        public const string SystemTag = "系统_";

    }
    /// <summary>
    /// 录入项
    /// </summary>
    public class InputItem
    {
        /// <summary>
        /// 录入项名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 控件类型
        /// </summary>
        public string ControlType { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 数据源别名
        /// </summary>
        public string DBAlias { get; set; }

        /// <summary>
        /// 数据来源
        /// </summary>
        public string DataFrom { get; set; }

        /// <summary>
        /// 扩展属性
        /// </summary>
        public string ExtPro { get; set; }

        public bool IsWhereReplace { get; set; }


        /// <summary>
        /// 保留标记
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// 链接控件
        /// </summary>
        public Control LinkControl { get; set; }

        public WhereItem Parent { get; set; }

        public int StartIndex { get; set; }

        public InputItem()
        {

        }

        public InputItem(string name)
        {
            Name = name;
        }

        public void CopyFrom(InputItem liSource)
        {
            Name = liSource.Name;
            ControlType = liSource.ControlType;
            DefaultValue = liSource.DefaultValue;
            DBAlias = liSource.DBAlias;
            DataFrom = liSource.DataFrom;
            ExtPro = liSource.ExtPro;
            IsWhereReplace = liSource.IsWhereReplace;
            LinkControl = liSource.LinkControl;
            Tag = liSource.Tag;
            Parent = liSource.Parent;
            StartIndex = liSource.StartIndex;
        }
    }

    public class InputItems: Dictionary<string, InputItem>
    {
        public void Add(string key, InputItem value, int index)
        {
            value.StartIndex = index;

            base.Add(key, value);
        }

        public InputItem FindItemByStartIndex(int startIndex)
        {
            foreach (InputItem wi in this.Values)
            {
                if (wi.StartIndex == startIndex) return wi;
            }

            return null;
        }
    }

    /// <summary>
    /// 条件项
    /// </summary>
    public class WhereItem
    {
        /// <summary>
        /// 条件项
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 链接类型
        /// </summary>
        public string LinkType { get; set; }

        /// <summary>
        /// 条件内容
        /// </summary>
        public string Condition  { get; set; }

        public string SourceFmt { get; set; }
         

        public InputItems InputItems { get; set; }

        /// <summary>
        /// 保留标记
        /// </summary>
        public object Tag { get; set; }

        public int StartIndex { get; set; }

        public WhereItem()
        {
            InputItems = new InputItems();
        }

        public void AddInputItem(InputItem ii, int startIndex)
        {
            ii.Parent = this;

            InputItems.Add(ii.Name, ii, startIndex);
        }

        public string SaveWhereToString()
        {
            string fmt = "";

            fmt = "<wi=" + Name + ":" + @"连接类型=""" + LinkType + @"""," +  Condition + "/wi>";

            foreach(InputItem ii in InputItems.Values)
            {
                string inputfmt = "[" + ii.Name + "," + @"类型=""" + ii.ControlType + @""",数据源=""" + ii.DBAlias + @""",数据来源=""" + ii.DataFrom + @""",扩展属性=""" + ii.ExtPro + @""",默认值=""" + ii.DefaultValue + @""",条件替换=""" + (ii.IsWhereReplace?1:0).ToString() + @"""]";
                fmt = fmt.Replace("[" + ii.Name + "]", inputfmt);
            }

            return fmt;
        }

        public void LoadWhereFromString(string whereitem)
        {

            if (string.IsNullOrEmpty(whereitem)) return;

            SourceFmt = whereitem;

            string tmp = whereitem;

            int indexStart = tmp.IndexOf("<wi=");
            if (indexStart < 0)
            {
                return;
            }

            indexStart = indexStart + 4;
            int indexEnd = tmp.IndexOf(":", indexStart + 1);

            Name = tmp.Substring(indexStart , indexEnd - indexStart );

            tmp = tmp.Substring(indexEnd + 1);

            indexStart = tmp.IndexOf(@"连接类型=""");
            if (indexStart < 0)
            {
                LinkType = "";
                indexEnd = -1;
            }
            else
            {
                indexStart = indexStart + 5;
                indexEnd = tmp.IndexOf(",", indexStart + 1);

                LinkType = tmp.Substring(indexStart, indexEnd - indexStart).Replace(@"""", "");
            }

            tmp = tmp.Substring(indexEnd + 1).Replace("/wi>", "") ;

            string curCondation = tmp;

            //配置录入项
            MatchInfos inputs = QueryHelper.GetMinMatchData(tmp, "[", "]", '"', '"');
             
            foreach(MatchInfo input in inputs)
            {  
                string[] pros = input.MatchContext.Split(',');

                InputItem ii = new InputItem();
                ii.Name = pros[0];
                
                curCondation = curCondation.Replace(input.MatchContext, ii.Name);

                ii.ControlType = FindPro(pros, "类型", "文本框");
                ii.DBAlias = FindPro(pros, "数据源");
                ii.DataFrom = FindPro(pros, "数据来源");
                ii.ExtPro = FindPro(pros, "扩展属性");
                ii.DefaultValue = FindPro(pros, "默认值");
                ii.IsWhereReplace = (FindPro(pros, "条件替换") == "1" ? true : false);
                //ii.StartIndex = input.StartIndex;

                ii.Parent = this;

                InputItems.Add(ii.Name, ii, input.StartIndex);
                 
            }

            Condition = curCondation;

        }

        public void CopyFrom(WhereItem wi)
        {
            Name = wi.Name;
            LinkType = wi.LinkType;
            Condition = wi.Condition;
            Tag = wi.Tag;
            SourceFmt = wi.SourceFmt;
            StartIndex = wi.StartIndex;

            InputItems.Clear();

            foreach (InputItem ii in wi.InputItems.Values)
            {
                InputItem curNew = new InputItem();
                curNew.CopyFrom(ii);

                InputItems.Add(ii.Name, curNew);
            }

        }

        private string FindPro(string[] pros, string proName, string defaultValue = "")
        {
            if (pros.Length <= 0) return defaultValue;

            foreach(string pro in pros)
            {
                if (pro.IndexOf(proName + "=") >= 0)
                {
                    return pro.Replace(proName + "=", "").Replace(@"""", "");
                }
            }

            return defaultValue;
        }
    }

    public class WhereItems: Dictionary<string, WhereItem>
    {
        public void Add(string key, WhereItem value, int index)
        {
            value.StartIndex = index;

            base.Add(key, value);
        }

        public WhereItem FindItemByStartIndex(int startIndex)
        {
            foreach(WhereItem wi in this.Values)
            {
                if (wi.StartIndex == startIndex) return wi;
            }

            return null;
        }
    }
}
