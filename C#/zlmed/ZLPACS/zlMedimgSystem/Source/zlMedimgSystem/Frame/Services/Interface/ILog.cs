

using System;

namespace zlMedimgSystem.Services
{
    public interface ILog: IBaseInterface
    {
        void WriteTrace(string traceMsg);

        void WriteLog(string log);

        void WriteLog(string module, string log);

        void WriteLog(LogType logType, string log);

        void WriteLog(LogType logType, string log, string source);

        void WriteLog(string module, LogType logType, string log);

        void WriteLog(string module, string log, string source);

        void WriteLog(string module, LogType logType, string log, string source);

        void WriteError(Exception ex);

        void WriteError(Exception ex,string module);

        void WriteError(Exception ex,string module, string hint);

        void WriteError(Exception ex,string module, string hint, string source);
    }
}
