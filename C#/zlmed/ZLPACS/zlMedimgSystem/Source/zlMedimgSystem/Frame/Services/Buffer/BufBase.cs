using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace zlMedimgSystem.Services
{
    public class BufBase : DisposeImp, IBaseInterface, IProperty
    {
        public const string BUF_DEFAULT_DIR = "BaseCache";
        public const string BUF_DEFAULT_SUFFIX = ".buf";       //缓冲区后缀

        protected const string BUF_DEFAULT_ENCRYPT_KEY = "E9F9EE3FDC18490B8222B47952CD5018";

        private string _bufDir = "";
        private string _bufName = "";

        private string _instanceId = "";

        #region 构造方法

        public BufBase(string bufName)
            : this("", bufName)
        {
        }

        public BufBase(string bufDir, string bufName)
        {
            _instanceId = Guid.NewGuid().ToString();

            _bufDir = bufDir;
            _bufName = bufName;

            //如果未指定缓冲区存储目录，则使用默认的缓冲目录
            if (string.IsNullOrEmpty(_bufDir))
            {
                _bufDir = GetDefaultBufDir();
            }
            _bufDir = (_bufDir + @"\").Replace(@"\\", @"\");
        }

        /// <summary>
        /// 获取默认缓冲目录
        /// </summary>
        /// <returns></returns>
        private string GetDefaultBufDir()
        {
            string bufDir = System.Windows.Forms.Application.StartupPath;

            bufDir = bufDir + "\\" + BUF_DEFAULT_DIR + "\\";

            if (System.IO.Directory.Exists(bufDir) != true)
            {
                //创建缓存目录
                System.IO.Directory.CreateDirectory(bufDir);
            }

            return bufDir;
        }

        #endregion

        #region 属性定义

        /// <summary>
        /// 缓冲目录
        /// </summary>
        public string BufDir
        {
            get { return _bufDir; }
            set { _bufDir = value; }
        }

        /// <summary>
        /// 缓冲区名称
        /// </summary>
        public string BufName
        {
            get { return _bufName; }
            set { _bufName = value; }
        }

        #endregion

        /// <summary>
        /// 将字符串转换为对象
        /// </summary>
        /// <param name="strSerial"></param>
        /// <returns></returns>
        protected object StringToSerialObject(string strSerial)
        {
            if (string.IsNullOrEmpty(strSerial) == true) return null;

            using (MemoryStream ms = new MemoryStream())
            {
                byte[] data = Convert.FromBase64String(strSerial);
                //byte[] data = Encoding.UTF8.GetBytes(strSerial);

                ms.Write(data, 0, data.Length);
                ms.Position = 0;

                //SoapFormatter sf = new SoapFormatter();
                //return sf.Deserialize(ms);

                BinaryFormatter bf = new BinaryFormatter();
                return bf.Deserialize(ms);
            }
        }

        /// <summary>
        /// 将对象序列化为字符串
        /// </summary>
        /// <param name="objSerial"></param>
        /// <returns></returns>
        protected string SerialObjectToString(object objSerial)
        {
            if (objSerial == null) return "";

            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, objSerial);

                //SoapFormatter sf = new SoapFormatter();
                //sf.Serialize(ms, objSerial);

                ms.Position = 0;
                byte[] data = ms.ToArray();

                return Convert.ToBase64String(data);
                //return Encoding.UTF8.GetString(data);
            }
        }

        /// <summary>
        /// 获取缓冲文件路径
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetBufFilePath(string key)
        {
            return _bufDir + "[" + _bufName + "]" + key + BUF_DEFAULT_SUFFIX;
        }

        /// <summary>
        /// 释放托管资源
        /// </summary>
        protected override void DisposeHostedRes()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 释放非托管资源
        /// </summary>
        protected  override  void DisposeNotHostedRes()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 获取实例ID
        /// </summary>
        /// <returns></returns>
        public string InstanceId()
        {
            return _instanceId;
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="proName"></param>
        /// <param name="proValue"></param>
        public virtual void SetProperty(string proName, object proValue)
        {
            if (proValue == null) return;

            switch (proName.ToUpper())
            {
                case "BUFDIR":
                    BufDir = Convert.ToString(proValue);
                    break;
                default:
                    throw new UserException("尚未实现[" + proName + "]属性配置.");
            }
        }

        /// <summary>
        /// 获取属性
        /// </summary>
        /// <param name="proName"></param>
        /// <returns></returns>
        public virtual object GetProperty(string proName)
        {
            switch (proName.ToUpper())
            {
                case "BUFDIR":
                    return BufDir;
                default:
                    throw new UserException("尚未实现[" + proName + "]属性配置.");
            }
        }
    }
}
