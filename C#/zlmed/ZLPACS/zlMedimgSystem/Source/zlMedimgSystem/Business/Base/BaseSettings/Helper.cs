using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.BaseSettings
{
    public static class Helper
    {
        /// <summary>
        /// 获取匹配数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="startMatch"></param>
        /// <param name="endMatch"></param>
        /// <returns></returns>
        static public List<string> GetMatchData(string source, string startMatch, string endMatch)
        {

            List<string> result = new List<string>();

            string tmp = source;

            int startMatchLen = startMatch.Length;           
            int endMatchLen = endMatch.Length;

            int indexStart = tmp.IndexOf(startMatch);
            if (indexStart <0) return result;//没有匹配项，则直接退出

            int indexEnd = tmp.IndexOf(endMatch);
            int indexNext = tmp.IndexOf(startMatch, indexStart + startMatchLen);

            if (indexNext <= 0) indexNext = tmp.Length;

            while (indexStart >= 0)
            {
                if (indexStart >= 0 && indexEnd > 0 && indexEnd > indexStart && indexEnd < indexNext)//满足[xxx]这种形式，过滤[xxx[bbb]这种形式
                {
                    string context = tmp.Substring(indexStart + startMatchLen, indexEnd - indexStart - startMatchLen);

                    result.Add(context);

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
