using System;
using System.Collections.Generic;
using System.Data;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.Services
{
    //缓冲自定义数据读取事件
    public delegate DataTable RefreshBufferEvent(string key, string statment, IDBQuery db, bool cusRead);

    /// <summary>
    /// 缓冲区类型
    /// </summary>
    public enum BufType
    {
        BufNone = -1,   //不缓冲
        BufToMem = 0,    //缓冲到内存，从本地打开后，一直保存在内存中
        BufToDisk = 1    //缓冲到磁盘文件，从本地打开后，即关闭内存数据        
    }

    /// <summary>
    /// 数据缓冲接口定义
    /// </summary>
    public interface IDataBuffer: IBaseInterface
    {
        bool RegBufferInf(string key, string statment);
        bool RegBufferInf(string key, string statment, Dictionary<string, object> pars);
        bool RegBufferInf(string key, string statment, Boolean isEncrypt);
        bool RegBufferInf(string key, string statment, Boolean isEncrypt, Dictionary<string, object> pars);
        bool RegBufferInf(string key, string statment, BufType bufType);
        bool RegBufferInf(string key, string statment, BufType bufType, Dictionary<string, object> pars);
        bool RegBufferInf(string key, string statment, BufType bufType, Boolean isEncrypt);
        bool RegBufferInf(string key, string statment, BufType bufType, Boolean isEncrypt, Dictionary<string, object> pars);

        bool HasReg(string key);

        DataTable QueryBuffer(string key);
        DataTable QueryBuffer(string key, bool hasCopy);
        DataTable QueryBuffer(string key, int bufVer);
        DataTable QueryBuffer(string key, int bufVer, bool hasCopy);
        DataTable QueryBuffer(string key, int bufVer, RefreshBufferEvent onRefreshBuffer);
        DataTable QueryBuffer(string key, int bufVer, bool hasCopy, RefreshBufferEvent onRefreshBuffer);

        void RefreshBuffer(string key);
        void RefreshBuffer(string key, int version);
        void RefreshBuffer(string key, RefreshBufferEvent onBuffer);
        void RefreshBuffer(string key, int version, RefreshBufferEvent onBuffer);

        void RemoveBufferData(string key);
        void UnRegBufferInf(string key);
    }
}
