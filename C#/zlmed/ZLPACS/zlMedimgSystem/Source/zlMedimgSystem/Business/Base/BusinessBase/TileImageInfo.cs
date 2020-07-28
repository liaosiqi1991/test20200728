using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.BusinessBase
{
    public class TileImageInfo
    {
        /// <summary>
        /// 媒体ID
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 序列ID
        /// </summary>
        public string SerialId { get; set; }

        /// <summary>
        /// 媒体名称
        /// </summary>
        public string MediaName { get; set; }

        /// <summary>
        /// 媒体类型
        /// </summary>
        public string MediaType { get; set; }

        /// <summary>
        /// 本地文件
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// 存储ID
        /// </summary>
        public string StorageId { get; set; }

        /// <summary>
        /// 申请ID
        /// </summary>
        public string ApplyId { get; set; }

        /// <summary>
        /// 分类目录
        /// </summary>
        public string VPath { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// 是否报告图
        /// </summary>
        public bool IsReportImage { get; set; }

        /// <summary>
        /// 是否关键图
        /// </summary>
        public bool IsKeyImage { get; set; }

        public void CopyFrom(TileImageInfo sourceImgInfo)
        {
            this.ApplyId = sourceImgInfo.ApplyId;
            this.File = sourceImgInfo.File;
            this.IsKeyImage = sourceImgInfo.IsKeyImage;
            this.IsReportImage = sourceImgInfo.IsReportImage;
            this.MediaId = sourceImgInfo.MediaId;
            this.MediaName = sourceImgInfo.MediaName;
            this.MediaType = sourceImgInfo.MediaType;            
            this.SerialId = sourceImgInfo.SerialId;
            this.StorageId = sourceImgInfo.StorageId;
            this.VPath = sourceImgInfo.VPath;

            this.Order = sourceImgInfo.Order;
        }
    }
}
