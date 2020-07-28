using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.Services
{
    /// <summary>
    /// 自定义的异常类
    /// </summary>
    public class UserException: ApplicationException
    {
        private const string EXCEPTION_MSG = "未知的自定义异常。";


        #region 构造方法

        public UserException()
            : this(EXCEPTION_MSG, null)
        {
        }

        public UserException(string message)
            :this(message, null)
        {
        }

        public UserException(string message, Exception innerException)
            : base((SysConst.EXCEPTION_TAG + message).Replace("[APP][APP]", "[APP]"), innerException)   //直接抛出子异常时，不需要每次在异常前面增加[App]
        {
        }

        #endregion


        /// <summary>
        /// 获取异常消息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetExceptionMsg(Exception ex)
        {
            string msg = ex.Message;

            if (ex.InnerException != null)
            {
                msg = msg + "\r\n" + GetExceptionMsg(ex.InnerException);
            }

            return msg;
        }

        /// <summary>
        /// 清除参数缓冲
        /// </summary>
        public static void ClaerParameterBuf()
        {
            DebugPar.ClearBugPar();
        }

        /// <summary>
        /// 获取异常的调用堆栈信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetExceptionStackTrace(Exception ex)
        {
            return GetExceptionStackTrace(ex, true);
        }

        /// <summary>
        /// 获取调用堆栈
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetExceptionStackTrace(Exception ex, bool blnUseBugPar)
        {
            string msg = "";

            if (blnUseBugPar == true)
            {
                msg = DebugPar.GetAllParInf(ex);
            }

            //组织消息格式
            if (msg.Trim() != "")
            {
                msg = "    参数信息：" + msg + "------------------------------------------------------------" + "\r\n";
            }

            msg = ((msg.Trim() == "") ? "" : msg) + "    异常描述：\r\n    " + ex.Message + "\r\n\r\n    调用流程：\r\n    " + (string.IsNullOrEmpty(ex.StackTrace)?"未识别...":ex.StackTrace);

            if (ex.InnerException != null)
            {
                msg = msg + 
                    "    \r\n\r\n    .................................................................................................................................\r\n\r\n" + 
                    GetExceptionStackTrace(ex.InnerException, false);
            }

            return msg;
        }
       
    }
}
