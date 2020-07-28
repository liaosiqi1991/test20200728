using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Design;

namespace zlMedimgSystem.CTL.Report
{

    public class SignElementNameDefine
    {
        public const string 记录签名 = "记录签名位";
        public const string 诊断签名 = "诊断签名位";
        public const string 一级审签 = "一级审签位";
        public const string 二级审签 = "二级审签位";
        public const string 三级审签 = "三级审签位";
    }

    public enum ReportEditState
    {
        /// <summary>
        /// 被拒绝
        /// </summary>
        resRejected = -2,

        /// <summary>
        /// 拒绝
        /// </summary>
        resNoEditing = -1,

        /// <summary>
        /// 编辑/诊断
        /// </summary>
        resDiagnosing = 0,

        /// <summary>
        /// 修订
        /// </summary>
        resRevising = 1,

        /// <summary>
        /// 审订
        /// </summary>
        resAuditing = 2,

        /// <summary>
        /// 完结
        /// </summary>
        resFinished = 3, 

    }

 
    public class ReportPars
    {
        /// <summary>
        /// 平级审核级别
        /// </summary>
        public int EqualAdutingLevel { get; set; }

        /// <summary>
        /// 直接审签级别
        /// </summary>
        public int DirectAuditingLevel { get; set; }

        /// <summary>
        /// 自动发布审签级别
        /// </summary>
        public int AutoPublicLevel { get; set; }

        /// <summary>
        /// 报告审核级数
        /// </summary>
        public int ReportAuditLevel { get; set; }



        /// <summary>
        /// 是否转换pdf
        /// </summary>
        public bool PrintAutoConvertPDF { get; set; }

        /// <summary>
        /// 平诊/普通患者打印需终审
        /// </summary>
        public bool NormalDiagnosePrintNeedUltimate { get; set; }

        /// <summary>
        /// 危重患者允许直接打印
        /// </summary>
        public bool CriticalDiagnoseAllowDirectPrint { get; set; }

        /// <summary>
        /// 绿色通道患者允许直接打印
        /// </summary>
        public bool GreenDiagnoseAllowDirectPrint { get; set; }
        
        /// <summary>
        /// 使用电子签名
        /// </summary>
        public bool UseESign { get; set; }

        public string ESignLibName { get; set; }

        /// <summary>
        /// 终审后自动打印
        /// </summary>
        public bool UltimateAutoPrint { get; set; }

        /// <summary>
        /// 终审后自动完成
        /// </summary>
        public bool UltimateAutoFinish { get; set; }

        /// <summary>
        /// 书写自己检查的报告
        /// </summary>
        public bool WriteSelf { get; set; }

    }

    static public class ReportPublic
    {
        /// <summary>
        /// 获取审核次数
        /// </summary>
        /// <param name="reportData"></param>
        /// <returns></returns>
        static public int GetAuditingCount(ReportContextData reportData)
        {
            JReportSignInfo signInfo = reportData.签名信息;

            if (signInfo.签名明细.Count <= 0) return 0;

            int signCount = -1;
            string signName = reportData.报告信息.报告医生;
            for (int i = 0; i <= signInfo.签名明细.Count - 1; i++)
            {
                JReportSignItem signItem = signInfo.签名明细[i];

                if (i == 0 && signName != signItem.用户名称) return signCount;

                if (i == 0)
                {
                    //为0 表示诊断签名，如果有签名，需要将signcount设置为0以便后续审核自增
                    signCount = signCount + 1;
                }
                else
                {
                    if (signItem.是否修订 == false && signItem.是否审核)
                    {
                        signCount = signCount + 1;
                    }
                }
            }

            return signCount;
        }

        /// <summary>
        /// 获取最后签名信息
        /// </summary>
        /// <param name="reportData"></param>
        /// <returns></returns>
        static public JReportSignItem GetLastSignInfo(ReportContextData reportData)
        {
            if (reportData.签名信息 == null) return null;
            if (reportData.签名信息.签名明细.Count <= 0)  return null;

            return reportData.签名信息.签名明细[reportData.签名信息.签名明细.Count - 1]; 
        }

        /// <summary>
        /// 获取最后一次签名的内容
        /// </summary>
        /// <returns></returns>
        static public string GetLastSignContext(ReportContextData reportData)
        {
            JReportSignInfo signInfo = reportData.签名信息;

            for (int i = signInfo.签名明细.Count - 1; i >= 0; i--)
            {
                JReportSignItem signItem = signInfo.签名明细[i];

                if (string.IsNullOrEmpty(signItem.签名报告)) continue;

                return signItem.签名报告;
            }

            return "";
        }
    }
}
