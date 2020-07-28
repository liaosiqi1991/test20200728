using System;
using System.Data;

namespace zlMedimgSystem.Services
{
    /// <summary>
    /// 对象缓冲接口
    /// </summary>
    public interface IDiskBuf
    {
        bool HasKey(string key);

        void WriteObjectToDiskBuf(string key, object objSeriallzable);
        void WriteObjectToDiskBuf(string key, object objSeriallzable, bool isEncrypt);

        void WriteTableToDiskBuf(string key, DataTable  dtData);
        void WriteTableToDiskBuf(string key, DataTable dtData, bool isEncrypt);

        object ReadObjectFormDiskBuf(string key);
        object ReadObjectFormDiskBuf(string key, bool isEncrypt);

        DataTable ReadTableFormDiskBuf(string key);
        DataTable ReadTableFormDiskBuf(string key, bool isEncrypt);

        DateTime GetLastBufTime(string key);

        string GetBufFile(string key);
    }
}
