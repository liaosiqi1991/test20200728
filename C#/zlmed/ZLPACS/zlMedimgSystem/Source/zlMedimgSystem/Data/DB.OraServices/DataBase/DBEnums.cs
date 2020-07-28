using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.DB.OraServices
{
    /// <summary>
    /// 数据源类型
    /// </summary>
    public enum DBSourceType
    {
        /// <summary>
        /// Oracle 
        /// </summary>
        Oracle=1,
        /// <summary>
        /// SqlServer
        /// </summary>
        SqlServer=2
    }

    /// <summary>
    /// 数据操作类型
    /// </summary>
    public enum DBOperationType
    {
        /// <summary>
        /// 新增
        /// </summary>
        otAdd,

        /// <summary>
        /// 更新
        /// </summary>
        otUpdate,

        /// <summary>
        /// 删除
        /// </summary>
        otDel
    }

    /// <summary>
    /// SQL类型
    /// </summary>
    public enum SQLType
    {
        /// <summary>
        /// 普通SQL
        /// </summary>
        CommonSQL=1,
        /// <summary>
        /// 存储过程
        /// </summary>
        Procedure=2
    }
}
