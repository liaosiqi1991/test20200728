using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.Interface
{

    /// <summary>
    /// 参数类型
    /// </summary>
    public enum ParType
    {
        person,
        station,
        department,
        module,
        overall
    }
    public interface IParameters
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Init(IDBQuery dbHelper, ILoginUser userData, string stationName, string moduleName);

        /// <summary>
        /// 写入DB参数
        /// </summary>
        void WriteDBPar(string parName, object parValue, ParType parType);

        /// <summary>
        /// 读取DB参数
        /// </summary>
        /// <returns></returns>
        object ReadDBPar(string parName, object defValue, ParType parType);

        /// <summary>
        /// 写入本地参数
        /// </summary>
        /// <param name="parName"></param>
        /// <param name="parValue"></param>
        /// <param name="parType"></param>
        void WriteLocalPar(string parName, object parValue, ParType parType);

        /// <summary>
        /// 读取本地参数
        /// </summary>
        /// <param name="parName"></param>
        /// <param name="defValue"></param>
        /// <param name="parType"></param>
        /// <returns></returns>
        object ReadLocalPar(string parName, object defValue, ParType parType);
    }
}
