using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace zlMedimgSystem.DB.OraServices
{
    public class DBTypeConvert
    {
        /// <summary>
        /// 文档数据类型字符串转为对应的数据库类型
        /// </summary>
        /// <param name="typeInDoc"></param>
        /// <returns></returns>
        public static DbType ToDbType(string typeInDoc)
        {
            if (!string.IsNullOrEmpty(typeInDoc))
            {
                switch (typeInDoc.Trim().ToUpper())
                {
                    case "S": //字符型(string)
                        return DbType.String;
                    case "N": //数值型(number)
                        return DbType.Double;
                    case "L": //布尔型(boolean)
                        return DbType.Boolean;
                    case "DT": //日期时间型(datetime)
                        return DbType.DateTime;
                    case "D": //日期型(date)
                        return DbType.Date;
                    case "T": //时间型(time)
                        return DbType.Time;
                    case "BY": //二进制(binary)
                        return DbType.Binary;
                    default:
                        break;
                }
            }
            return DbType.String;
        }

        /// <summary>
        /// 转为DbType
        /// http://docs.oracle.com/html/B14164_01/featOraCommand.htm
        /// Table 3-3 Inference of System.Data.DbType from OracleDbType
        /// </summary>
        /// <param name="oraDbType"></param>
        /// <returns></returns>
        internal static DbType OraDbType2DbType(OracleDbType oraDbType)
        {
            switch (oraDbType)
            {
                //case OracleDbType.Array:
                case OracleDbType.BFile:
                    return DbType.Object;
                case OracleDbType.Blob:
                case OracleDbType.Byte:
                    return DbType.Byte;
                case OracleDbType.Char:
                case OracleDbType.NChar:
                    return DbType.StringFixedLength;
                case OracleDbType.Long:
                case OracleDbType.Clob:
                case OracleDbType.NClob:
                case OracleDbType.NVarchar2:
                case OracleDbType.Varchar2:
                case OracleDbType.XmlType:
                    return DbType.String;
                case OracleDbType.Date:
                    return DbType.Date;
                case OracleDbType.Decimal:
                    return DbType.Decimal;
                case OracleDbType.Double:
                    return DbType.Double;
                case OracleDbType.Int16:
                    return DbType.Int16;
                case OracleDbType.Int32:
                    return DbType.Int32;
                case OracleDbType.Int64:
                    return DbType.Int64;
                case OracleDbType.IntervalDS:
                    return DbType.Time;
                case OracleDbType.IntervalYM:
                    return DbType.Int64;
                case OracleDbType.LongRaw:
                case OracleDbType.Raw:
                    return DbType.Binary;
                //case OracleDbType.Object:
                //case OracleDbType.Ref:
                case OracleDbType.RefCursor:
                    return DbType.Object;
                case OracleDbType.Single:
                    return DbType.Single;
                case OracleDbType.TimeStamp:
                case OracleDbType.TimeStampLTZ:
                case OracleDbType.TimeStampTZ:
                    return DbType.DateTime;
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// 转为OracleDbType
        /// http://docs.oracle.com/html/B14164_01/featOraCommand.htm
        /// Table 3-4 Inference of OracleDbType from DbType 
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        internal static OracleDbType DbType2OraDbType(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.AnsiString:
                case DbType.String:
                    return OracleDbType.Varchar2;
                case DbType.AnsiStringFixedLength:
                case DbType.StringFixedLength:
                    return OracleDbType.Char;
                case DbType.Binary:
                    return OracleDbType.Raw;
                case DbType.Byte:
                    return OracleDbType.Byte;
                case DbType.Date:
                    return OracleDbType.Date;
                case DbType.DateTime:
                case DbType.Time:
                    return OracleDbType.TimeStamp;
                case DbType.Decimal:
                    return OracleDbType.Decimal;
                case DbType.Double:
                    return OracleDbType.Double;
                case DbType.Guid:
                    return OracleDbType.Raw;
                case DbType.Int16:
                case DbType.SByte: //Not Supported 
                    return OracleDbType.Int16;
                case DbType.Int32:
                    return OracleDbType.Int32;
                case DbType.Int64:
                    return OracleDbType.Int64;
                //case DbType.Object:
                //    return OracleDbType.Object;
                case DbType.Single:
                    return OracleDbType.Single;
                case DbType.Xml:
                    return OracleDbType.XmlType;
                case DbType.Boolean:
                case DbType.Currency:
                case DbType.UInt16:
                case DbType.UInt32:
                case DbType.UInt64:
                case DbType.VarNumeric:
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
