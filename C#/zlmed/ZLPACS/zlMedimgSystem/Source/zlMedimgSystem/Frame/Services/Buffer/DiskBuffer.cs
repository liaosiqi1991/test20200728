using System;
using System.Data;
using System.IO;

namespace zlMedimgSystem.Services
{

    public class DiskBuffer : BufBase, IDiskBuf 
    {
        #region 构造方法

        public DiskBuffer(string bufName)
            : this("", bufName)
        {
        }

        public DiskBuffer(string bufDir, string bufName)
            :base(bufDir, bufName)
        {
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 保存到文件
        /// </summary>
        /// <param name="strData"></param>
        /// <param name="strFile"></param>
        public static void SaveDataToFile(string strData, string strFile)
        {
            using (StreamWriter sw = new StreamWriter(strFile))
            {
                sw.Write(strData);
                sw.Close();
            }
        }

        /// <summary>
        /// 从文件读取数据
        /// </summary>
        /// <param name="strFile"></param>
        /// <returns></returns>
        public static string ReadDataFromFile(string strFile)
        {
            using (StreamReader fs = new StreamReader(strFile))
            {
                return fs.ReadToEnd();
            }
        }

        #endregion

        /// <summary>
        /// 是否存在指定KEY
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual bool HasKey(string key)
        {
            string bufFilePath = GetBufFilePath(key);

            return File.Exists(bufFilePath);
        }

        /// <summary>
        /// 写入数据到缓冲
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dtData"></param>
        public void WriteObjectToDiskBuf(string key, object objSeriallzable)
        {
            WriteObjectToDiskBuf(key, objSeriallzable, false);
        }

        /// <summary>
        /// 写入数据到缓冲
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dtData"></param>
        /// <param name="isEncrypt"></param>
        public virtual void WriteObjectToDiskBuf(string key, object objSeriallzable, bool isEncrypt)
        {
            string bufData = SerialObjectToString(objSeriallzable);

            //加密需要缓冲的数据对象
            if (isEncrypt == true)
            {
                using (Encrypt crypt = new Encrypt(BUF_DEFAULT_ENCRYPT_KEY, true))
                {
                    bufData = crypt.EncryptStr(bufData);
                }
            }

            if (string.IsNullOrEmpty(bufData) == true)
            {
                throw new UserException("无效的数据，不能写入到缓冲区。"); 
            }

            string bufFilePath = GetBufFilePath(key);

            SaveDataToFile(bufData, bufFilePath);
        }

        /// <summary>
        /// 将数据表写入缓冲
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dtData"></param>
        public void WriteTableToDiskBuf(string key, DataTable dtData)
        {
            WriteTableToDiskBuf(key, dtData, false);
        }

        /// <summary>
        /// 将数据表写入缓冲
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dtData"></param>
        /// <param name="isEncrypt"></param>
        public virtual void WriteTableToDiskBuf(string key, DataTable dtData, bool isEncrypt)
        {
            //获取缓冲的文件名称
            string filePath = GetBufFilePath(key);

            if (isEncrypt == false)
            {
                dtData.WriteXml(filePath, XmlWriteMode.WriteSchema);
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                using (Encrypt crypt = new Encrypt(key + BUF_DEFAULT_ENCRYPT_KEY))
                {
                    dtData.WriteXml(ms, XmlWriteMode.WriteSchema);
                    //将加密后的数据流写入文件
                    crypt.EncryptToFile(ms, filePath);
                    ms.Close();
                }
            }
        }


        /// <summary>
        /// 从缓冲读取数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object ReadObjectFormDiskBuf(string key)
        {
            return ReadObjectFormDiskBuf(key, false);
        }

        /// <summary>
        /// 从缓冲读取数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual object ReadObjectFormDiskBuf(string key, bool isEncrypt)
        {
            string filePath = GetBufFilePath(key);

            string bufData = ReadDataFromFile(filePath);

            //如果加密，则需要进行解密操作
            if (isEncrypt == true)
            {
                using (Encrypt crypt = new Encrypt(BUF_DEFAULT_ENCRYPT_KEY, true))
                {
                    bufData = crypt.DecryptStr(bufData);
                }                
            }

            if (string.IsNullOrEmpty(bufData) == true)
            {
                throw new UserException("缓冲区数据无效，不能进行读取。");
            }

            return StringToSerialObject(bufData);
        }

        /// <summary>
        /// 从缓冲读取表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataTable ReadTableFormDiskBuf(string key)
        {
            return ReadTableFormDiskBuf(key, false);
        }

        /// <summary>
        /// 从缓冲读取表
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isEncrypt"></param>
        /// <returns></returns>
        public virtual DataTable ReadTableFormDiskBuf(string key, bool isEncrypt)
        {
            DataTable dtBuf = new DataTable();

            //获取缓冲的文件名称
            string filePath = GetBufFilePath(key);

            if (isEncrypt == false)
            {                
                dtBuf.ReadXml(filePath);
            }
            else
            {
                //解密文件后读取到缓冲区
                using (Encrypt crypt = new Encrypt(key + BUF_DEFAULT_ENCRYPT_KEY))
                using (MemoryStream ms = crypt.DecryptFromFile(filePath))
                {
                    dtBuf.ReadXml(ms);
                    ms.Close();
                }
            }

            return dtBuf;
        }

        /// <summary>
        /// 获取最后的缓冲时间
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual DateTime GetLastBufTime(string key)
        {
            string filePath = GetBufFilePath(key);

            return File.GetLastWriteTime(filePath);
        }

        /// <summary>
        /// 获取缓冲文件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetBufFile(string key)
        {
            return GetBufFilePath(key);
        }
    }
}
