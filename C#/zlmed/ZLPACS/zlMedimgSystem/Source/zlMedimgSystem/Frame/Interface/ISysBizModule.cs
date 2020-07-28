using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.Interface
{

    /// <summary>
    /// 系统业务模块接口
    /// </summary>
    public interface ISysBizModule
    {

        //string ModuleName { get; }


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dbHelper"></param>
        /// <param name="stationInfo"></param>
        /// <param name="userData"></param>
        /// <param name="parameters"></param>
        /// <param name="sysLog"></param>
        void Init(string winKey, IDBQuery dbHelper, IBizDataTransferCenter dataTransCenter, IStationInfo stationInfo, ILoginUser userData, IParameters parameters, ISysLog sysLog);

        /// <summary>
        /// 刷新
        /// </summary>
        void RefreshModule();
        
    }


    public interface ISysMainModule
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dbHelper"></param>
        /// <param name="userData"></param>
        /// <param name="parentTransferCenter">父窗口的数据交换处理对象</param>
        void Init(IDBQuery dbHelper, ILoginUser userData, IStationInfo stationInfo, IBizDataTransferCenter parentTransferCenter);

        /// <summary>
        /// 刷新
        /// </summary>
        void RefreshModule();
    }

}
