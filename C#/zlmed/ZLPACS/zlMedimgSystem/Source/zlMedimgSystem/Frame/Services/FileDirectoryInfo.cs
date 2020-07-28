using System;


namespace zlMedimgSystem.Services
{
    /// <summary>
    /// 文件目录
    /// </summary>
    [Serializable]
    public class FileDirectoryInfo
    {
        private string displayName;
        /// <summary>
        /// 名称
        /// </summary>
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        private DirectoryEntryTypes fileInfoType;
        /// <summary>
        /// 类型
        /// </summary>
        public DirectoryEntryTypes FileInfoType
        {
            get { return fileInfoType; }
            set { fileInfoType = value; }
        }

        private long fileSize;
        /// <summary>
        /// 文件大小
        /// </summary>
        public long FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        private DateTime lastEditTime;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastEditTime
        {
            get { return lastEditTime; }
            set { lastEditTime = value; }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="diaplayName"></param>
        /// <param name="fileInfoType"></param>
        /// <param name="fileSize"></param>
        /// <param name="lastEditTime"></param>
        public FileDirectoryInfo(string displayName, DirectoryEntryTypes fileInfoType, long fileSize, DateTime lastEditTime)
        {
            this.displayName = displayName;
            this.fileSize = fileSize;
            this.fileInfoType = fileInfoType;
            this.lastEditTime = lastEditTime;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="diaplayName"></param>
        /// <param name="fileInfoType"></param>
        /// <param name="fileSize"></param>
        /// <param name="lastEditTime"></param>
        public FileDirectoryInfo()
        {
        }
    }


    /// <summary>
    /// 目录项类型
    /// </summary>
    public enum DirectoryEntryTypes
    {
        目录 = 0,
        文件 = 1
    }
}