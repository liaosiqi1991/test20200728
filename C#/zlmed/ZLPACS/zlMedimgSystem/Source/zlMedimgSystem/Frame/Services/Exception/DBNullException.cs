using System;

namespace zlMedimgSystem.Services
{
    //数据库空异常
    public class DBNullException: UserException
    {
        private const string EXCEPTION_MSG = "无效的数据库对象，数据库对象不能为空。";

        public DBNullException()
            : base(EXCEPTION_MSG, null)
        {

        }

        public DBNullException(Exception innerException)
            : base(EXCEPTION_MSG, innerException)
        {
        }
    }
}
