using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;

namespace zlMedimgSystem.Services
{
    /// <summary>
    /// FTP操作帮助类
    /// </summary>
    public class FTPFileHelp
    {
        private string _ftpServerIP;
        private string _ftpUserName;
        private string _ftpPassword;

        private DecodeType _decodeType;
        private int _timeout = 10000;
        private bool _UsePassive = true;
        private bool _UseBinary = true;

        private bool _isConnection = false;

        public object Tag { get; set; }

        public string FtpAddress
        {
            get { return _ftpServerIP; }
        }

        public string FtpUser
        {
            get { return _ftpUserName; }
        }

        public string FtpPwd
        {
            get { return _ftpPassword; }
        }

        public bool IsConnection
        {
            get { return _isConnection; }
        }

        public FTPFileHelp(int timeout = 10000)
        {
            this._timeout = timeout;
        }

        public bool UsePassive
        {
            get { return _UsePassive; }
            set { _UsePassive = value; }
        }

        public bool UseBinary
        {
            get { return _UseBinary; }
            set { _UseBinary = value; }
        }


        public string VPath
        {
            get;
            set;
        }



        /// <summary>
        /// 和FTP服务器建立连接
        /// </summary>
        /// <param name="path"></param>
        private FtpWebRequest CreateFtpConnection(string path)
        {
            try
            {
                if (!path.ToLower().Contains(("ftp://" + this._ftpServerIP).ToUpper()))
                {
                    path = "ftp://" + this._ftpServerIP + path;
                }

                path = path.Replace(@"\\", "/").Replace(@"\", "/");
                
                // 根据uri创建FtpWebRequest对象
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(path));
                // 指定数据传输类型
                reqFTP.UseBinary = _UseBinary;
                // ftp用户名和密码
                reqFTP.Credentials = new NetworkCredential(_ftpUserName, _ftpPassword);
                reqFTP.Timeout = _timeout;
                reqFTP.UsePassive = _UsePassive;

                this._isConnection = true;

                return reqFTP;
            }
            catch (Exception ex)
            {
                this._isConnection = false;
                throw new UserException(string.Format("{0}[{1}]", "FTP连接失败", path), ex);
            }
        }

        /// <summary>
        /// 连接ftp服务器
        /// </summary> 
        /// <param name="path"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ConnnectServer(string path, string userName, string password, DecodeType decodeType = DecodeType.Default)
        {
            string strDecryptionPassW;

            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                this._isConnection = false;
                return false;
            }

            //如果密码加了密，则进行解密
            if (password.Length >= 3)
            {
                if (password.Substring(0, 1) + password.Substring(2, 1) + password.Substring(password.Length - 1, 1) == "★※★")
                {
                    strDecryptionPassW = password.Substring(1);
                    strDecryptionPassW = strDecryptionPassW.Substring(0, strDecryptionPassW.Length - 1);
                    strDecryptionPassW = strDecryptionPassW.Substring(0, 1) + strDecryptionPassW.Substring(2);
                    strDecryptionPassW = this.GetDecryptionPassW(strDecryptionPassW);

                    password = strDecryptionPassW;
                }
            }

            this._ftpServerIP = path;
            this._ftpUserName = userName;
            this._ftpPassword = password;
            this._decodeType = decodeType;

            try
            {
                FtpWebRequest ftp = CreateFtpConnection("");

                ftp.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;

                WebResponse response = ftp.GetResponse();
                response.Close();

                this._isConnection = true;
                return true;
            }
            catch (Exception)
            {
                this._isConnection = false;
                return false;
            }
        }

        /// <summary>
        /// 重新连接FTP
        /// </summary>
        /// <returns></returns>
        public bool ResotreFtpConnect()
        {
            return this.ConnnectServer(this._ftpServerIP, this._ftpUserName, this._ftpPassword);
        }

        /// <summary>
        /// 获得文件大小
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public long GetFileSize(string filename)
        {
            long fileSize = 0;

            try
            {
                FtpWebRequest reqFTP = CreateFtpConnection(filename);
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;

                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();

                fileSize = response.ContentLength;

                response.Close();
            }
            catch (WebException ex)
            {
                throw new FtpNormalException(ex.Response as FtpWebResponse, "");
            }

            return fileSize;
        }

        /// <summary>
        /// 获得目录和文件列表
        /// </summary>
        /// <param name="path">上级目录</param>
        public List<FileDirectoryInfo> GetFileFolders(string path)
        {
            List<FileDirectoryInfo> directorys = new List<FileDirectoryInfo>();

            FtpWebRequest reqFTP = CreateFtpConnection(path);
            reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            reqFTP.KeepAlive = false;
            WebResponse response = null;
            try
            {
                response = reqFTP.GetResponse();
            }
            catch
            {
                //patch：当前连接或最近一次连接的“KeepAlive=false”时，ftp可能返回501错误。出错后再尝试一次。
                reqFTP = CreateFtpConnection(path);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                reqFTP.KeepAlive = false;
                response = reqFTP.GetResponse();
            }

            Encoding encoding = Encoding.Default;
            if (this._decodeType == DecodeType.UTF8)
            {
                encoding = Encoding.UTF8;
            }

            StreamReader reader = new StreamReader(response.GetResponseStream(), encoding);
            string line = reader.ReadLine();

            FileListStyle fileListStyle = FileListStyle.Unknown;
            if (line != null)
            {
                fileListStyle = GetFileListStyle(line);
            }

            while (line != null)
            {
                fileListStyle = GetFileListStyle(line);
                FileDirectoryInfo temp = ConvertToDirectory(line, fileListStyle);
                if (temp != null)
                {
                    if (!temp.DisplayName.StartsWith("."))
                    {
                        directorys.Add(temp);
                    }
                }
                line = reader.ReadLine();
            }

            reader.Close();
            response.Close();

            return directorys;
        }

        /// <summary>
        /// FTP文件信息字符串格式
        /// </summary>
        public enum FileListStyle
        {
            UnixStyle, WindowsStyle, Unknown
        }

        public FileListStyle GetFileListStyle(string fileInfoStr)
        {
            if (fileInfoStr.Length > 10
             && Regex.IsMatch(fileInfoStr.Substring(0, 10), "(-|d)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)"))
            {
                return FileListStyle.UnixStyle;
            }
            else if (fileInfoStr.Length > 8
             && Regex.IsMatch(fileInfoStr.Substring(0, 8), "[0-9][0-9]-[0-9][0-9]-[0-9][0-9]"))
            {
                return FileListStyle.WindowsStyle;
            }

            return FileListStyle.Unknown;
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="parentDirName"></param>
        /// <param name="dirName"></param>
        public void MakeDirectory(string newDirPath)
        {
            try
            {
                string[] dirs = newDirPath.Replace("\\", "/").Split('/');
                string curDir = "/";
                for (int i = 0; i < dirs.Length; i++)
                {
                    string dir = dirs[i];
                    //如果是以/开始的路径,第一个为空 
                    if (dir != null && dir.Length > 0)
                    {
                        try
                        {
                            curDir += dir + "/";
                            FtpMakeDir(curDir);
                        }
                        catch (Exception)
                        { 
                            
                        }
                    }
                }
            }
            catch (WebException we)
            {
                throw new FtpNormalException(we.Response as FtpWebResponse, "");
            }
            catch (Exception ex)
            {
                throw new UserException("创建目录 [" + newDirPath + "] 失败.", ex);
            }
        }

        //创建目录
        private bool FtpMakeDir(string localFile)
        {
            FtpWebRequest reqFTP = CreateFtpConnection(localFile);
            reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;

            try
            {
                WebResponse response = reqFTP.GetResponse();
                response.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                reqFTP.Abort();
            }
        }

        /// <summary>
        /// 判断文件或者目录是否存在
        /// </summary>
        /// <param name="pathString"></param>
        /// <returns></returns>
        public bool isExist(string pathString)
        {
            try
            {
                FtpWebRequest reqFTP = CreateFtpConnection(pathString);

                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                WebResponse response = reqFTP.GetResponse();
                response.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="dirName"></param>
        public void delDirectory(string dirPath)
        {
            try
            {
                FtpWebRequest reqFTP = CreateFtpConnection(dirPath);

                reqFTP.Method = WebRequestMethods.Ftp.RemoveDirectory;
                reqFTP.KeepAlive = true;
                WebResponse response = reqFTP.GetResponse();
                response.Close();
            }
            catch (WebException we)
            {
                throw new FtpNormalException(we.Response as FtpWebResponse, "删除目录 [" + dirPath + "] 失败");
            }
            catch (Exception ex)
            {
                throw new UserException("删除目录 [" + dirPath + "] 失败", ex);
            }
        }

        /// <summary>
        /// 重命名文件、文件夹
        /// </summary>
        /// <param name="oldFilePath"></param>
        /// <param name="newFilename">新名称，或新的相对路径。</param>
        public bool Rename(string oldFilePath, string newFilename)
        {
            try
            {
                newFilename = newFilename.Replace("\\", "/");

                FtpWebRequest reqFTP = CreateFtpConnection(oldFilePath);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                if (response != null)
                {
                    response.Close();
                }

                return true;
            }
            catch (WebException we)
            {
                throw new FtpNormalException(we.Response as FtpWebResponse, "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="uploadFile"></param>
        public bool FileUpLoad(string directoryPath, System.IO.FileInfo uploadFile)
        {

            /*
             * 上传文件时如果文件存在则重命名原服务器文件,先将原文件重命名为 【文件名称】+时间，
             * 如果上传成功则删除原文件，如果上传失败则将原文件重命名回去。
             */
            directoryPath = directoryPath.Replace("\\", "/");
            string[] strFtpDir;
            string tGuid = "";

            string tRenameFile = "";

            bool tFileExist = this.isExist(directoryPath);
            if (tFileExist == true)
            {
                strFtpDir = directoryPath.Split('/');

                tGuid = Guid.NewGuid().ToString();
                tRenameFile = strFtpDir[strFtpDir.Length-1] + "." + tGuid;
                try
                {
                    //重命名文件
                    this.Rename(directoryPath, tRenameFile);
                }
                catch
                {
                    //重命名失败
                    tRenameFile = "";
                }
            }
            
            try
            {
                FtpWebRequest reqFTP = CreateFtpConnection(directoryPath);
                reqFTP.KeepAlive = true;
                // 指定执行什么命令
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                // 上传文件时通知服务器文件的大小
                reqFTP.ContentLength = uploadFile.Length;
                // 缓冲大小设置为kb 
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];

                FileStream fs = new FileStream(uploadFile.FullName, FileMode.Open, FileAccess.Read,  FileShare.Read);

                int contentLen;

                // 把上传的文件写入流
                Stream strm = reqFTP.GetRequestStream();
                // 每次读文件流的kb 
                contentLen = fs.Read(buff, 0, buffLength);
                // 流内容没有结束
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    //strm.Flush();

                    contentLen = fs.Read(buff, 0, buffLength);                    
                }

                strm.Flush();   //统一执行flush，如果失败，ftp文件大小为0k便于发现问题
                strm.Close();
                fs.Close();
                WebResponse response = reqFTP.GetResponse();
                response.Close();

                //上传文件完毕，判断是否有重命名文件。
                if (tRenameFile.Length > 0)
                {
                    try
                    {
                        //删除原文件
                        this.DeleteFileName( directoryPath + "." + tGuid);

                    }
                    catch { }
                }

                return true;
            }
            catch (Exception ex)
            {
                //上传失败，则恢复重命名文件
                if (tRenameFile.Length > 0)
                {
                    try
                    {
                        this.Rename(tRenameFile, uploadFile.Name);
                    }
                    catch
                    {
                        //ZLSoft.BusinessHome.ApplicationFramework.ClientLogger.Error("上传文件失败，服务器的重命名文件恢复失败。请查看服务器文件名称：" + tRenameFile);
                    }
                }
                throw new UserException("文件 [" + uploadFile + "]上传出错:" + ex.Message + "\r\n" + "超时时长为(秒)：" + (_timeout / 1000).ToString() , ex);
            }
        }

        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="sourceFilePath">文件在Ftp上的Url地址</param>
        /// <param name="localFilePath">下载到本地目录的文件FullName</param>
        /// <param name="PermitOverwrite">如果本地目录已存在文件，是否覆盖。</param>
        public bool FileDownLoad(string sourceFilePath, string localFilePath, bool PermitOverwrite)
        {
            sourceFilePath = sourceFilePath.Replace("\\", "/");
            localFilePath = localFilePath.Replace("\\", "/");

            try
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(localFilePath);
                if (fi.Exists && !(PermitOverwrite))
                {
                    throw new UserException("文件已经存在");
                }
                if (string.IsNullOrEmpty(sourceFilePath))
                {
                    throw new UserException("未指定下载文件");
                }

                FtpWebRequest reqFTP = CreateFtpConnection(sourceFilePath);

                reqFTP.KeepAlive = true;
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;

                using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (FileStream fs = fi.Create())
                        {
                            try
                            {
                                byte[] buffer = new byte[2048];
                                int read = 0;
                                do
                                {
                                    read = responseStream.Read(buffer, 0, buffer.Length);
                                    fs.Write(buffer, 0, read);
                                } while (!(read == 0));
                                responseStream.Close();
                                fs.Flush();
                                fs.Close();
                            }
                            catch (Exception ex)
                            {
                                fs.Close();
                                fi.Delete();
                                throw new UserException("文件 [" + sourceFilePath + "] 下载出错", ex);
                            }
                        }
                        responseStream.Close();
                    }
                    response.Close();
                }

                fi.LastWriteTime = GetLastWriteTime(sourceFilePath);

                return true;
            }
            catch(Exception ex)
            {
                throw new UserException("文件 [" + sourceFilePath + "] 下载异常>>" + ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取FTP文件、文件夹的最后修改时间
        /// </summary>
        /// <param name="path">FTP文件、文件夹的Url</param>
        public DateTime GetLastWriteTime(string path)
        {
            FtpWebRequest reqFTP = CreateFtpConnection(path);
            reqFTP.UseBinary = false;
            reqFTP.KeepAlive = true;
            reqFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp;

            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            DateTime result = response.LastModified;
            response.Close();
            return result;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath"></param>
        public void DeleteFileName(string filePath)
        {
            try
            {
                FtpWebRequest reqFTP = CreateFtpConnection(filePath);
                reqFTP.KeepAlive = true;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
            }
            catch (WebException we)
            {
                throw new FtpNormalException(we.Response as FtpWebResponse, "");
            }
            catch (Exception ex)
            {
                throw new UserException(string.Format("“{0}”不存在或无法访问。", filePath), ex);
            }
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        public void DeleteDirectory(string directoryPath)
        {
            try
            {
                directoryPath = directoryPath.Replace("\\", "/");

                List<FileDirectoryInfo> infoList = GetFileFolders(directoryPath);
                foreach (FileDirectoryInfo info in infoList)
                {
                    string url = string.Format("{0}/{1}", directoryPath, info.DisplayName);
                    if (info.FileInfoType == DirectoryEntryTypes.目录)
                    {
                        DeleteDirectory(url);
                    }
                    else if (info.FileInfoType == DirectoryEntryTypes.文件)
                    {
                        DeleteFileName(url);
                    }
                }

                try
                {
                    delDirectory(directoryPath);
                }
                catch
                {
                    //path for ServU
                    delDirectory(directoryPath);
                }
            }
            catch (WebException we)
            {
                throw new FtpNormalException(we.Response as FtpWebResponse, "");
            }
            catch (Exception ex)
            {
                throw new UserException(string.Format("“{0}”不存在或无法访问。", directoryPath), ex);
            }
        }

        #region 得到文件(目录)信息的辅助方法

        /// <summary>
        /// 将文件详细信息字符串转换为文件类
        /// </summary>
        private FileDirectoryInfo ConvertToDirectory(string fileName, FileListStyle style)
        {
            Match m = GetMatchingRegex(fileName);
            if (m == null) return null;

            FileDirectoryInfo result = new FileDirectoryInfo();

            result.DisplayName = m.Groups["name"].Value;
            if (m.Groups["size"].Value != string.Empty)
                result.FileSize = long.Parse(m.Groups["size"].Value);
            if (m.Groups["timestamp"].Value != string.Empty)
            {
                DateTimeFormatInfo formatProvider = new CultureInfo("en-US", false).DateTimeFormat;

                try
                {
                    string dateStr = m.Groups["timestamp"].Value;
                    switch (style)
                    {
                        case FileListStyle.UnixStyle:
                            //example1：“Jan 18  2009”；example2：“Jan 11 12:29”                            
                            if (dateStr.IndexOf(":") != -1)
                            {
                                dateStr = string.Format("{0} {1}", DateTime.Now.Year, dateStr);
                            }

                            result.LastEditTime = DateTime.Parse(dateStr, formatProvider);
                            //距离当前时间（以文件服务器时间为参考点）半年以内的时间不带年份
                            if (result.LastEditTime.Month > DateTime.Now.Month)
                            {
                                result.LastEditTime = result.LastEditTime.AddYears(-1);
                            }
                            break;
                        case FileListStyle.WindowsStyle:
                        //example3：“01-11-11  06:23PM”
                        case FileListStyle.Unknown:
                        default:
                            result.LastEditTime = DateTime.Parse(dateStr, formatProvider);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(string.Format("获取文件修改时间出错[{0}]", fileName), ex);
                }
            }
            string _dir = m.Groups["dir"].Value;
            if (_dir != "" && _dir != "-")
            {
                result.FileInfoType = DirectoryEntryTypes.目录;
            }
            else
            {
                result.FileInfoType = DirectoryEntryTypes.文件;
            }

            return result;
        }

        private Match GetMatchingRegex(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return null;
            Regex rx;
            Match m;
            for (int i = 0; i <= _ParseFormats.Length - 1; i++)
            {
                rx = new Regex(_ParseFormats[i]);
                m = rx.Match(fileName);
                if (m.Success)
                {
                    return m;
                }
            }
            return null;
        }

        private static string[] _ParseFormats = new string[] { 
            "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\w+\\s+\\w+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{4})\\s+(?<name>.+)", 
            "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\d+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{4})\\s+(?<name>.+)", 
            "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\d+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{1,2}:\\d{2})\\s+(?<name>.+)", 
            "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\w+\\s+\\w+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{1,2}:\\d{2})\\s+(?<name>.+)", 
            "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})(\\s+)(?<size>(\\d+))(\\s+)(?<ctbit>(\\w+\\s\\w+))(\\s+)(?<size2>(\\d+))\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{2}:\\d{2})\\s+(?<name>.+)", 
            "(?<timestamp>\\d{2}\\-\\d{2}\\-\\d{2}\\s+\\d{2}:\\d{2}[Aa|Pp][mM])\\s+(?<dir>\\<\\w+\\>){0,1}(?<size>\\d+){0,1}\\s+(?<name>.+)" };

        #endregion


        private string GetRandom(long lngBase)
        {
            Random r = new Random();

            long lngNum = (int)r.Next(0, 99) * lngBase;

            if (lngNum <= 0) lngNum = 1;

            return ((char)lngNum).ToString();
        }

        private int CSharpASC(string s)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("GB2312").GetBytes(s);

            if (bytes.Length > 1)
            {
                return (int)((bytes[0] << 8) + bytes[1]);
            }
            else
            {
                return (int)bytes[0];
            }
        }

        /// <summary>
        /// 获取加密密码
        /// </summary>
        /// <param name="passW"></param>
        /// <returns></returns>
        public string GetEncryptionPassW(string passW)
        {
            string strRandom, strBase;
            long lngPassWLength;
            int intAsc, i = 0;

            lngPassWLength = passW.Length;

            strBase = this.GetRandom(30);
            strRandom = this.GetRandom(30);

            string[] strTemp = new string[lngPassWLength];

            while (i < lngPassWLength)
            {
                intAsc = CSharpASC(passW.Substring(i, 1));
                intAsc = intAsc ^ CSharpASC(strBase) ^ int.Parse(strRandom);
                strTemp[i] = ((char)intAsc).ToString();
                i = i + 1;
            }

            return string.Join("", strTemp);
        }

        /// <summary>
        /// 获取解密密码
        /// </summary>
        /// <param name="passW"></param>
        /// <returns></returns>
        public string GetDecryptionPassW(string passW)
        {
            string strPassSouce, strRandom;
            long lngPassWLength, lngBase;
            int intAsc, i = 0;

            strPassSouce = passW.Substring(1, passW.Length - 2);
            lngPassWLength = strPassSouce.Length;
            lngBase = CSharpASC(passW.Substring(0, 1));

            strRandom = passW.Remove(0, passW.Length - 1);

            string[] strTemp = new string[lngPassWLength];

            while (i < lngPassWLength)
            {
                intAsc = CSharpASC(strPassSouce.Substring(i, 1));
                intAsc = intAsc ^ CSharpASC(strRandom) ^ (int)lngBase;
                strTemp[i] = ((char)intAsc).ToString();
                i = i + 1;
            }

            return string.Join("", strTemp);
        }
    }


    public class FtpNormalException : Exception
    {
        private string message;
        public override string Message
        {
            get
            {
                return message;
            }

        }

        /// <summary>
        /// FTP异常
        /// </summary>
        /// <param name="response"></param>
        /// <param name="describe">其他描述信息，例如：删除失败：</param>
        public FtpNormalException(FtpWebResponse response, string describe)
        {
            if (response == null || response.StatusDescription == null)
            {
                this.message = describe + "无法连接到FTP服务器";
                return;
            }
            this.message = describe + TranslateExceptionMsg(response.StatusDescription);
        }

        /// <summary>
        /// 翻译FTP异常
        /// </summary>
        /// <returns></returns>
        private string TranslateExceptionMsg(string msg)
        {
            //获取异常的文件或者文件夹名称
            if (msg.Contains("exists") || msg.Contains("Unable to rename"))
            {
                return "文件或者文件夹已存在";
            }
            else if (msg.Contains("specified") || msg.Contains("No such"))
            {
                return "文件或者文件夹不存在";
            }
            else if (msg.Contains("denied"))
            {
                return "文件或者文件夹无操作权限";
            }
            return msg;
        }
    }

    /// <summary>
    /// 解码编码
    /// </summary>
    public enum DecodeType
    {
        Default,
        UTF8
    }

    /// <summary>
    /// Ftp连接状态
    /// </summary>
    public enum FtpConnectState
    {
        /// <summary>
        /// 未连接
        /// </summary>
        fcsNo,

        /// <summary>
        /// 连接中
        /// </summary>
        fcsConnecting,

        /// <summary>
        /// 连接失败
        /// </summary>
        fcsFailed,

        /// <summary>
        /// 连接成功
        /// </summary>
        fcsSucessed
    }
}
