using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.Interface
{
    /// <summary>
    /// 系统日志类型
    /// </summary>
    public enum SysLogType
    {
        Normal,
        Waring,
        Error
    }

    /// <summary>
    /// 操作日志类型
    /// </summary>
    public enum OperLogType
    {
        
    }

    public interface ISysLog
    {
        /// <summary>
        /// 日志初始化
        /// </summary>
        /// <param name="dbHelper"></param>
        /// <param name="userData"></param>
        /// <param name="sysPath"></param>
        void Init(IDBQuery dbHelper, ILoginUser userData, string sysPath);

        ///// <summary>
        ///// 写入检查操作日志
        ///// </summary>
        ///// <param name="studyData"></param>
        ///// <param name="operType"></param>
        ///// <param name="logText"></param>
        ///// <param name="createTime"></param>
        //void WriteStudyLog(IStudyData studyData, OperLogType operType, string logText, DateTime createTime );

        /// <summary>
        /// 写入系统日志
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="logText"></param>
        /// <param name="createTime"></param>
        /// <param name="releationFunc"></param>
        /// <param name="releationModule"></param>
        void WriteSysLog(SysLogType logType, string logText, DateTime createTime, string releationFunc, string releationModule);

    }
}
