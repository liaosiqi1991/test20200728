using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace zlMedimgSystem.Interface
{
    [Serializable]
    public class ESignResultInfo : ISerializable
    {
        /// <summary>
        /// 签名加密信息串
        /// </summary>
        public string SignResult { get; set; }

        /// <summary>
        /// 签名时间戳
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// 签名时间戳b64编码
        /// </summary>
        public string TimeStampB64 { get; set; }


        public ESignResultInfo()
        {

        }

        public void CopyFrom(ESignResultInfo signResultInfo)
        {
            SignResult = signResultInfo.SignResult;
            TimeStamp = signResultInfo.TimeStamp;
            TimeStampB64 = signResultInfo.TimeStampB64;
        }

        public ESignResultInfo CloneTo()
        {
            ESignResultInfo resultInfo = new ESignResultInfo();

            resultInfo.CopyFrom(this);

            return resultInfo;
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected ESignResultInfo(SerializationInfo info, StreamingContext context)
        {
            SignResult = info.GetString("SignResult");
            TimeStamp = info.GetString("TimeStamp");
            TimeStampB64 = info.GetString("TimeStampB64"); 
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SignResult", SignResult);
            info.AddValue("TimeStamp", TimeStamp);
            info.AddValue("TimeStampB64", TimeStampB64); 
        }
    }



    [Serializable]
    public class ECertInfo : ISerializable
    {
        /// <summary>
        /// 证书序号
        /// </summary>
        public string CertKey { get; set; }
        /// <summary>
        /// 证书用户
        /// </summary>
        public string CertUser { get; set; }


        /// <summary>
        /// 用户身份证ID
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// 有效开始日期
        /// </summary>
        public string BeginTime { get; set; }

        /// <summary>
        /// 有效结束日期
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 导出的签名证书
        /// </summary>
        public string SignCert { get; set; }

        /// <summary>
        /// 签名图像B64编码
        /// </summary>
        public Image SignImg { get; set; }

        public ECertInfo()
        {

        }

        public void CopyFrom(ECertInfo certInfo)
        {
            CertKey = certInfo.CertKey;
            CertUser = certInfo.CertUser;
            IDCard = certInfo.IDCard;
            BeginTime = certInfo.BeginTime;
            EndTime = certInfo.EndTime;
            SignCert = certInfo.SignCert;
            SignImg = certInfo.SignImg.Clone() as Image;
        }

        public ECertInfo CloneTo()
        {
            ECertInfo certInfo = new ECertInfo();

            certInfo.CopyFrom(this);

            return certInfo;
        }

        /// <summary>
        /// 图像转二进制
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        static public string ImageToString(Image img)
        {
            if (img == null) return null;

            //将Image转换成流数据，并保存为byte[] 
            using (MemoryStream mstream = new MemoryStream())
            {
                img.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);

                mstream.Position = 0;
                using (StreamReader sr = new StreamReader(mstream))
                {
                    return sr.ReadToEnd();
                } 
            }

        }

        /// <summary>
        /// 二进制转图像
        /// </summary>
        /// <param name="imgBytes"></param>
        /// <returns></returns>
        static public Image StringToImage(string imgSource)
        {
            if (string.IsNullOrEmpty(imgSource)) return null;

            //using (MemoryStream ms = new MemoryStream(imgBytes)) //ms释放后，会造成image.save产生gdi错误
            using (MemoryStream ms = new MemoryStream())
            {
                StreamWriter sw = new StreamWriter(ms);

                sw.Write(imgSource);
                sw.Flush();

                ms.Position = 0;

                using (Image newImg = Image.FromStream(ms))
                {
                    return new Bitmap(newImg);
                }
            }
        }


        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected ECertInfo(SerializationInfo info, StreamingContext context)
        {
            CertKey = info.GetString("CertKey");
            CertUser = info.GetString("CertUser");
            IDCard = info.GetString("IDCard");
            BeginTime = info.GetString("BeginTime");
            EndTime = info.GetString("EndTime");
            SignCert = info.GetString("SignCert");
            SignImg = StringToImage(info.GetString("SignImg"));
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CertKey", CertKey);
            info.AddValue("CertUser", CertUser);
            info.AddValue("IDCard", IDCard);
            info.AddValue("BeginTime", BeginTime);
            info.AddValue("EndTime", EndTime);
            info.AddValue("SignCert", SignCert);
            info.AddValue("SignImg", ImageToString(SignImg));
        }
    }

    /// <summary>
    /// 电子签名接口
    /// </summary>
    public interface IESign
    {
        void Init(IDBQuery dbQuery);

        ECertInfo GetCertInfo(string userName);

        //bool CheckCertificate(string userName);

        //bool CheckStoped(string userName);

        ESignResultInfo Signature(ECertInfo certInfo, string certSource);

        bool Verify(string certSource, ECertInfo certInfo, ESignResultInfo signInfo);

    }
}
