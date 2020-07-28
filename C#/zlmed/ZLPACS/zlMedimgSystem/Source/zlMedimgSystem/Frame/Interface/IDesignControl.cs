using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.Interface
{
    public interface IControlSerializable
    {
        /// <summary>
        /// 获取序列化属性串
        /// </summary>
        /// <returns></returns>
        string GetProSerializableStr();

        /// <summary>
        /// 根据序列串设置属性
        /// </summary>
        /// <param name="jsonPros"></param>
        void SetSerializablePros(string jsonPros);


        ///// <summary>
        ///// 绑定事件
        ///// </summary>
        //void BindEvent();

    }
}
