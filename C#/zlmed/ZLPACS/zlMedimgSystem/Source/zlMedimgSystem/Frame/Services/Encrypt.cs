using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Net;

namespace zlMedimgSystem.Services
{
    /// <summary>
    /// 加密解密对象
    /// </summary>
    public class Encrypt: DisposeImp
    {
        private DESCryptoServiceProvider _des = null;

        #region 构造方法

        public Encrypt(string key)
            :this(key, false)
        {
        }

        public Encrypt(string key, bool useHostName)
        {
            _des = new DESCryptoServiceProvider();

            using (MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider())
            {
                byte[] hash = hashMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(((useHostName == true) ? Dns.GetHostName() : "") + key));

                _des.Key = hash.Take(8).ToArray();
                _des.IV = hash.Skip(8).Take(8).ToArray();

                hashMD5.Clear();
            }
        }

        #endregion

        #region 析构方法

        protected override void DisposeHostedRes()
        {
            _des.Clear();

            if (_des as IDisposable != null)
            {
                ((IDisposable)_des).Dispose();
            }
        }

        protected override void DisposeNotHostedRes()
        {
            //throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        public string EncryptStr(string sourceStr)
        {
            return Convert.ToBase64String(EncryptByte(sourceStr));
        }

        /// <summary>
        /// 加密自己数组
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        public byte[] EncryptByte(string sourceStr)
        {
            using (ICryptoTransform crypt = _des.CreateEncryptor())
            {
                byte[] strSource = Encoding.UTF8.GetBytes(sourceStr);

                return crypt.TransformFinalBlock(strSource, 0, strSource.Length);
            }
        }

        /// <summary>
        /// 加密数据流
        /// </summary>
        /// <param name="sourceStream"></param>
        /// <returns></returns>
        public MemoryStream EncryptStream(Stream sourceStream)
        {
            using (ICryptoTransform crypt = _des.CreateEncryptor())
            {
                MemoryStream msReturn = new MemoryStream();

                byte[] strSource = new byte[sourceStream.Length];
                sourceStream.Read(strSource, 0, (int)sourceStream.Length);

                byte[] encrypted = crypt.TransformFinalBlock(strSource, 0, strSource.Length);
                strSource = null;

                msReturn.Write(encrypted, 0, encrypted.Length);
                encrypted = null;

                msReturn.Position = 0;
                return msReturn;
            }
        }

        /// <summary>
        /// 加密到文件
        /// </summary>
        /// <param name="sourceStream"></param>
        /// <param name="file"></param>
        public void EncryptToFile(Stream sourceStream, string file)
        {
            using (ICryptoTransform crypt = _des.CreateEncryptor())
            using (FileStream fileStream = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                byte[] strSource = new byte[sourceStream.Length];
                sourceStream.Read(strSource, 0, (int)sourceStream.Length);

                byte[] encrypted = crypt.TransformFinalBlock(strSource, 0, strSource.Length);
                strSource = null;

                fileStream.Write(encrypted, 0, encrypted.Length);
                encrypted = null;

                fileStream.Close();
            }
        }
        


        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="encryptStr"></param>
        /// <returns></returns>
        public string DecryptStr(string encryptStr)
        {
            return DecryptByte(Convert.FromBase64String(encryptStr));
        }

        /// <summary>
        /// 解密字节数组
        /// </summary>
        /// <param name="encryptStr"></param>
        /// <returns></returns>
        public string DecryptByte(byte[] encryptStr)
        {
            using (ICryptoTransform crypt = _des.CreateDecryptor())
            {
                byte[] decrypted = crypt.TransformFinalBlock(encryptStr, 0, encryptStr.Length);

                return Encoding.UTF8.GetString(decrypted);
            }
        }

        /// <summary>
        /// 解密数据流
        /// </summary>
        /// <param name="encryptStream"></param>
        /// <returns></returns>
        public MemoryStream DecryptStream(Stream encryptStream)
        {
            //try
            //{
            using (ICryptoTransform crypt = _des.CreateDecryptor())
            {
                MemoryStream msReturn = new MemoryStream();

                byte[] strSource = new byte[encryptStream.Length];
                encryptStream.Read(strSource, 0, (int)encryptStream.Length);

                byte[] decrypted = crypt.TransformFinalBlock(strSource, 0, strSource.Length);
                strSource = null;

                msReturn.Write(decrypted, 0, decrypted.Length);
                decrypted = null;

                msReturn.Position = 0;
                return msReturn;
            }
            //}
            //catch (Exception ex)
            //{
            //    Logger.OutputError(ex);
            //    Logger.OutputDebugStr("错误描述：解密数据流失败。 错误来源：" + ex.TargetSite);
            //    return null;
            //}
        }

        /// <summary>
        /// 从文件解密数据到流
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public MemoryStream DecryptFromFile(string file)
        {
            using (ICryptoTransform crypt = _des.CreateDecryptor())
            {
                MemoryStream msReturn = new MemoryStream();
                using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    byte[] strSource = new byte[fileStream.Length];
                    fileStream.Read(strSource, 0, (int)fileStream.Length);

                    byte[] decrypted = crypt.TransformFinalBlock(strSource, 0, strSource.Length);
                    strSource = null;

                    msReturn.Write(decrypted, 0, decrypted.Length);
                    decrypted = null;

                    fileStream.Close();
                }

                msReturn.Position = 0;
                return msReturn;
            }
        }
    }
}
