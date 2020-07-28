using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{

    public enum ReportSignState
    {
        /// <summary>
        /// 已创建
        /// </summary>
        rpsCreate = 0,

        /// <summary>
        /// 已诊断
        /// </summary>
        rpsDiagnosed = 1,

        /// <summary>
        /// 修订中
        /// </summary>
        rpsRevising = 2,

        /// <summary>
        /// 已修订
        /// </summary>
        rpsRevised = 3,

        /// <summary>
        /// 审订中
        /// </summary>
        rpsAuditing = 4,

        /// <summary>
        /// 已审定
        /// </summary>
        rpsAudited = 5,

        /// <summary>
        /// 审签
        /// </summary>
        rpsAuditSign = 6, 
    }

    public class ReportContextBase: DataBase
    {
        public string 报告ID { get; set; }
        public string 申请ID { get; set; }

        public string 报告名称 { get; set; }
        public string 部位名称 { get; set; }
         
    }

    /// <summary>
    /// 报告状态信息
    /// </summary>
    public class JReportStateInfo: DataBase, IJsonField
    {
        public int 签名状态 { get; set; }
        public bool 是否已完结 { get; set; }
        public bool 是否已打印 { get; set; }

        public bool 是否转PDF { get; set; }
        public bool 是否可查阅 { get; set; }
        public bool 是否已发放 { get; set; }
        //public int 打印次数 { get; set; }

        public bool 是否驳回中 { get; set; }

        public DateTime 最后更新时间 { get; set; }

        public void CopyBasePro(ReportContextBase reportContextBase)
        {
            base.CopyFrom<ReportContextBase>(reportContextBase);
        }


    }

    public class JReportSignItem
    {
        public string Key { get; set; }
        public int 用户级别 { get; set; }
        public string 用户ID { get; set; }
        public string 用户名称 { get; set; }

        //当不为第一次签名，且不是修订签名时，说明是已修订，比如报告诊断签名后的修订，
        public bool 是否修订 { get; set; }

        public bool 是否审核 { get; set; }

        public DateTime 签名时间 { get; set; }

        public ECertInfo 证书信息 { get; set; }

        public ESignResultInfo 签名结果 { get; set; }

        public int 签名时状态 { get; set; }

        public string 签名报告 { get; set; }

        public JReportSignItem()
        {
            Key = SqlHelper.GetNumGuid();

            证书信息 = new ECertInfo();
            签名结果 = new ESignResultInfo();
        }

        public JReportSignItem(int userLevel, string userId, string userName, DateTime signDate)
        {
            Key =SqlHelper.GetNumGuid();

            用户级别 = userLevel;
            用户ID = userId;
            用户名称 = userName;
            签名时间 = signDate;

            证书信息 = new ECertInfo();
            签名结果 = new ESignResultInfo();
        } 
         
        public JReportSignItem CloneTo()
        {
            JReportSignItem signClone = new JReportSignItem();

            signClone.Key = Key;
            signClone.用户级别 = 用户级别;
            signClone.用户名称 = 用户名称;
            signClone.用户ID = 用户ID;
            signClone.签名时间 = 签名时间;
            signClone.是否修订 = 是否修订;
            signClone.是否审核 = 是否审核;
            signClone.签名时状态 = 签名时状态;

            signClone.签名报告 = 签名报告;
            signClone.证书信息 = 证书信息;
            signClone.签名结果 = 签名结果;


            return signClone;
        
        }

    }

    public class JReportAnnexItem
    {
        public string Key { get; set; }
        public string 存储ID { get; set; }
        public string 附件名称 { get; set; }
        public string 访问链接 { get; set; }

        public DateTime 创建时间 { get; set; }
        public string 创建人 { get; set; }

        public JReportAnnexItem()
        {
            Key = SqlHelper.GetNumGuid();
        }
    }

    /// <summary>
    /// 报告附件信息
    /// </summary>
    public class JReportAnnexInfo: ReportContextBase, IJsonField
    {
        public List<JReportAnnexItem> 附件明细 { get; set; }
        public JReportAnnexInfo()
        {
            附件明细 = new List<JReportAnnexItem>();
        }

        public void CopyBasePro(ReportContextBase reportContextBase)
        {
            base.CopyFrom<ReportContextBase>(reportContextBase);
        }
    }

    /// <summary>
    /// 报告签名信息
    /// </summary>
    public class JReportSignInfo: ReportContextBase, IJsonField
    {
        public List<JReportSignItem> 签名明细 { get; set; }

        public JReportSignInfo()
        {
            签名明细 = new List<JReportSignItem>();

        }

        public void CopyBasePro(ReportContextBase reportContextBase)
        {
            base.CopyFrom<ReportContextBase>(reportContextBase);
        }
    }
     
    public class JReportBackItem
    {
        public string Key { get; set; }
        public string 回退人 { get; set; }
        public DateTime 回退时间 { get; set; }
        public string 回退原因 { get; set; }
        public JReportSignItem 终签状态 { get; set; }

        public JReportBackItem()
        {
            Key = SqlHelper.GetNumGuid();
             
            终签状态 = new JReportSignItem();
        }
    }

    public class JReportBackInfo : ReportContextBase, IJsonField
    {
        public List<JReportBackItem> 回退明细 { get; set; }

        public JReportBackInfo()
        {
            回退明细 = new List<JReportBackItem>();
        }

        public void CopyBasePro(ReportContextBase reportContextBase)
        {
            base.CopyFrom<ReportContextBase>(reportContextBase);
        }
    }

    public class JReportPrintItem
    {
        public string Key { get; set; }
        public string 打印人 { get; set; }
        public DateTime 打印时间 { get; set; }
        public string 打印站点 { get; set; }
        public string 打印IP地址 { get; set; }

        public JReportPrintItem()
        {
            Key = SqlHelper.GetNumGuid(); 
        }
    }

    public class JReportPrintInfo: ReportContextBase, IJsonField
    {
        public List<JReportPrintItem> 打印明细 { get; set; }

        public JReportPrintInfo()
        {
            打印明细 = new List<JReportPrintItem>();
        }

        public void CopyBasePro(ReportContextBase reportContextBase)
        {
            base.CopyFrom<ReportContextBase>(reportContextBase);
        }
    }




    /// <summary>
    /// 报告内容信息
    /// </summary>
    public class JReportContextInfo: ReportContextBase ,IJsonField
    {
        public string 模板ID { get; set; }
        public string 格式ID { get; set; }

        public string 创建人 { get; set; }
        public DateTime 创建时间 { get; set; }

        //首次签名写入报告医生和时间
        public string 报告医生 { get; set; }
        public DateTime 报告时间 { get; set; }

        public string 最后审签人 { get; set; }
        public DateTime 最后审签时间 { get; set; } 

        public string 完结人 { get; set; }
        public int 完结人级别 { get; set; }
        public DateTime 完结时间 { get; set; }

        public string 发放人 { get; set; }
        public DateTime 发放时间 { get; set; }

        //public string 首次打印人 { get; set; }
        //public DateTime 首次打印时间 { get; set; }

        //public string 最后打印人 { get; set; }
        //public DateTime 最后打印时间 { get; set; }



        public bool 是否阳性 { get; set; }

        public bool 是否危急重 { get; set; }
        public string 诊断分类 { get; set; }
        public string 报告内容 { get; set; } 

        public JReportContextInfo()
        { 
            
        }

        public void CopyBasePro(ReportContextBase reportContextBase)
        {
            base.CopyFrom<ReportContextBase>(reportContextBase);
        }
    }

    public enum ReportRejectState
    {
        /// <summary>
        /// 驳回中
        /// </summary>
        rrsRejecting = 0,

        /// <summary>
        /// 已处理
        /// </summary>
        rrsProcessed =1,

        /// <summary>
        /// 已撤销
        /// </summary>
        rrsCanceled = 2
    }


    public class JReportRejectItem
    {
        public string Key { get; set; }
        public string 驳回人 { get; set; }
        public string 驳回理由 { get; set; }
        public DateTime 驳回时间 { get; set; }
        //public int 驳回次序 { get; set; }
        public int 驳回状态 { get; set; } //0-驳回中，1-已处理，2-已撤回

        public string 处理人 { get; set; }
        public DateTime 处理时间 { get; set; }
        public string 处理描述 { get; set; }

        public JReportRejectItem()
        {
            Key = SqlHelper.GetNumGuid();
        }
    }

    /// <summary>
    /// 报告驳回信息
    /// </summary>
    public class JReportRejectInfo: ReportContextBase, IJsonField
    {
        public List<JReportRejectItem> 驳回明细 { get; set; }

        public JReportRejectInfo()
        {
            驳回明细 = new List<JReportRejectItem>();
        }

        public void CopyBasePro(ReportContextBase reportContextBase)
        {
            base.CopyFrom<ReportContextBase>(reportContextBase);
        }
    }

    /// <summary>
    /// 报告测量
    /// </summary>
    public class JReportMeasureInfo: ReportContextBase, IJsonField
    {
        public string 测量内容 { get; set; }

        public void CopyBasePro(ReportContextBase reportContextBase)
        {
            base.CopyFrom<ReportContextBase>(reportContextBase);
        }

    }

}
