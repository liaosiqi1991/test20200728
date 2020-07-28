using System.Collections.Generic;
using System.Text;

namespace zlMedimgSystem.Services
{
    public class BugData: Dictionary<string, string>
    {
        private string _methodName = "";

        public BugData(string methodName)
        {
            _methodName = methodName;
        }

        /// <summary>
        /// 方法名称
        /// </summary>
        public string MethodName
        {
            get
            {
                return _methodName;
            }
        }

        /// <summary>
        /// 获取调试的参数信息
        /// </summary>
        /// <returns></returns>
        public string GetBugParInf()
        {
            if (this.Count <= 0) return "";

            StringBuilder result = new StringBuilder("过程名>>" + _methodName + "  过程数据>>");
            foreach (KeyValuePair<string, string> par in this)
            {
                result.Append("[");
                result.Append(par.Key);
                result.Append(":");
                result.Append(par.Value );
                result.Append("]");
                result.Append(" ");
            }
            
            return result.ToString();
        }
    }
}
