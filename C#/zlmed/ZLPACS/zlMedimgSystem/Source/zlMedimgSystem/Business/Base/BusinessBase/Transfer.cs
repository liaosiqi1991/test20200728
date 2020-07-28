using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BusinessBase
{
    static public class Transfer
    {

        static private StorageData _storageData = null;

        static public FTPFileHelp GetFtp(string vpath, string storageId, IDBQuery dbHelper)
        {
            if (string.IsNullOrEmpty(storageId))
            {
                throw new Exception("存储设备ID无效，请检查配置。");
            }

            FTPFileHelp ftp = null;


            if (_storageData == null || _storageData.存储ID != storageId)
            {
                zlMedimgSystem.DataModel.StorageModel sm = new StorageModel(dbHelper);

                _storageData = sm.GetStorageDataByID(storageId);
            }

            if (_storageData == null)
            {
                throw new Exception("存储设备信息获取失败，请检查配置。");
            }

            ftp = new FTPFileHelp();

            ftp.VPath = (@"/" + _storageData.存储信息.目录 + @"/" + vpath).Replace(@"\\", @"\").Replace(@"\", @"/").Replace(@"//", @"/");

            ftp.ConnnectServer(
                                _storageData.存储信息.IP地址 + @":" + _storageData.存储信息.端口,
                                _storageData.存储信息.用户名,
                                _storageData.存储信息.密码,
                                DecodeType.Default
                                );


            if (ftp.IsConnection == false)
            {
                throw new Exception("FTP链接失败。");
            }


            return ftp;
        }
    }
}
