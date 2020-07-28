using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace zlMedimgSystem.QueryDesign
{
    public struct MatchInfo
    {
        public string MatchContext;
        public int StartIndex;

        public MatchInfo(string matchContext, int startIndex)
        {
            MatchContext = matchContext;
            StartIndex = startIndex;
        }

    }


    public class MatchInfos: List<MatchInfo>
    {
        public bool Contains(string context)
        {
            foreach(MatchInfo mi in this)
            {
                if (mi.MatchContext.Equals(context)) return true;
            }

            return false;
        }
    }

    public static class QueryHelper
    { 
        /// <summary>
        /// 获取匹配数据,获取最小匹配项数据，如[xxx[aaa111[222]333]bbb],则仅匹配[222]
        /// </summary>
        /// <param name="source"></param>
        /// <param name="startMatch"></param>
        /// <param name="endMatch"></param>
        /// <returns></returns>
        static public MatchInfos GetMinMatchData(string source, string startMatch, string endMatch)
        {           
            return GetMinMatchData(source, startMatch, endMatch, '\0', '\0');

        }


        static public MatchInfos GetMinMatchData(string source, string startMatch, string endMatch,
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


    }
}
