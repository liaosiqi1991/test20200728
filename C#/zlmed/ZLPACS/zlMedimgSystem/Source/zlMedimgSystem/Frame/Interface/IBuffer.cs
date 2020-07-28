using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.Interface
{
    public interface IBuffer
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sysPath"></param>
        void Init(string sysPath);

        /// <summary>
        /// 添加本地缓存区域
        /// </summary>
        /// <param name="areaName"></param>
        void AddLocalArea(string areaName);
        void DelLocalArea(string areaName);

        /// <summary>
        /// 读取在线缓存
        /// </summary>
        /// <param name="bufName"></param>
        /// <returns></returns>
        object ReadLineBuf(string bufName);

        /// <summary>
        /// 写入在线缓存
        /// </summary>
        /// <param name="bufName"></param>
        /// <param name="bufData"></param>
        void WriteLineBuf(string bufName, object bufData);

        /// <summary>
        /// 读取本地缓存
        /// </summary>
        /// <param name="bufName"></param>
        /// <returns></returns>
        object ReadLocalBuf(string bufName);

        object ReadLocalBuf(string bufName, string areaName);

        /// <summary>
        /// 写入本地缓存
        /// </summary>
        /// <param name="bufName"></param>
        /// <param name="bufData"></param>
        void WriteLocalBuf(string bufName, object bufData);

        void WriteLocalBuf(string bufName, object bufData, string areaName);
    }
}
