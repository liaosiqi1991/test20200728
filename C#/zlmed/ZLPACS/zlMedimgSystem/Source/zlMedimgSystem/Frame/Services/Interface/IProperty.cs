

namespace zlMedimgSystem.Services
{
    interface IProperty
    {
        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="proName"></param>
        /// <param name="proValue"></param>
        void SetProperty(string proName, object proValue);

        /// <summary>
        /// 获取属性
        /// </summary>
        /// <param name="proName"></param>
        /// <returns></returns>
        object GetProperty(string proName);
    }
}
