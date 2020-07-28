using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.DB.OraServices
{
    public class DBXmlHelper
    {
        /// <summary>
        /// 判断是否空xml内容
        /// </summary>
        /// <param name="strXml"></param>
        /// <returns></returns>
        public static bool IsNullXml(string strXml)
        {
            if (string.IsNullOrEmpty(strXml)==true) return false;
            if (strXml.Length > 30) return true;
            if (strXml.ToUpper().Replace(" ", "") == "<NULL/>") return false;

            return true;
        }
    }
}
